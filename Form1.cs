// Form1.cs
//
// Copyright 2025 Martin Bruegger

using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using SQLAgain.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace SQLAgain
{
    /// <summary> 
    /// SQLAgain executes a SQL File in a iteration against multiple Oracle Databases
    /// </summary> 
    /// <remarks> 
    /// You need the Oracle sqlplus.exe (Oracle Client or Oracle DB Installation) and a tnsNames.ora file containing your databases.
    /// In SQLAgain, you define usernames and passwords and select SQL Files to execute.
    /// </remarks> 
    /// 

    public partial class Form1 : Form
    {        
        private class Favorite
        {   
            public string File { get; set; }
            public bool Log2File { get; set; }
            public bool LogAppend { get; set; }
            public string LogFile { get; set; }
            public string DBUser { get; set; }
            public bool OptSilent { get; set; }
            public int OptFormat { get; set; }   // 0=none, 1=HTML, 2=CSV
            public string Timeout { get; set; }
            public bool IgnoreError { get; set; }
            public string DBList { get; set; }   // list of DBs; *=all, whitespace=none            
            public string Text { get; set; }           
            public Favorite(string _File, bool _Log2File, bool _LogAppend, string _LogFile, string _DBUser, 
                bool _OptSilent, int _OptFormat, string _Timeout, bool _IgnoreError, string _DBList, string _Text)
            {  
                File = _File;
                Log2File = _Log2File;
                LogAppend = _LogAppend;
                LogFile = _LogFile;
                DBUser = _DBUser;
                OptSilent = _OptSilent;
                OptFormat = _OptFormat;
                Timeout = _Timeout;
                IgnoreError = _IgnoreError;
                DBList = _DBList;               
                Text = _Text;
            }
        }
        private readonly string settingsFile = "SQLAgainSettings.xml";
        private readonly List<Favorite> listFavorites = new List<Favorite>();
        private readonly List<List<int>> listDBMatches = new List<List<int>>();
        private string sqlPlusPath = string.Empty;
        private string nlsLang = string.Empty;
        private string tnsAdmin = string.Empty;
        private string sqlPath = string.Empty;                                                      // Options / Environment
        private bool passwordEncrypt = true;
        private string sqlFile = string.Empty;
        private string logFile = string.Empty;
        private readonly string logFileTemporary;
        private readonly string processIDFile;                      // temporary file containing Proc.ID of SQLcl - option to "Abort SQL"
        private string namesDefaultDomain = string.Empty;           // Default_Domain from sqlnet.ora - suppress this part in the db-list
        private string dbUser = string.Empty;                                                       // selected DBUser in listBoxUser
        private string dbSchema;                                                                    // DB Schema (selected in listBoxUser)
        private string dbUserPassword;                                                              // Password of DB Schema
        private bool sysDBA;                                                                        // SYSDBA Flag
        private bool buildDBListPending;
        private bool inInit = true;
        private string sqlPlusVersion;
        private string tnsNames;
        private string sqlResult;
        private int selectedDbCount;
        private readonly List<string> dbList = new List<string>();
        private int timeout;
        private bool ignoreError ;
        private bool pingWithSqlPlus = false;                                                       // When sqlPlusVersion >= 23, then use "sqlplus -P" instead of tnsping.exe
        private readonly DataTable tableDBUser = new DataTable();
        private readonly DataTable tableDBGroups = new DataTable();
        private XDocument doc;
        private string check4UpdateInfo;
        private  Color textColorStatusLabel1 = Color.DarkOrange;                                    // StatusLabel ForegroundColor Text High   (Orange  Mode white: Red)
        private  Color textColorStatusLabel2 = Color.Gold;                                          // StatusLabel ForegroundColor Text Normal (Gold    Mode white: Green) 
        private  Color colorBack1 = Color.FromArgb(44, 44, 44);                                     // ListView BackColor - we are changing BackColor SELECTED and normal in a DB loop
        private readonly Queue<string> pendingMessages = new Queue<string>();
        public Form1(string[] file)
        {
            InitializeComponent();
            tabControloptions.SelectedIndex = 0;
            ReadSettings();                                                                         // Read Favorites, load into listViewFavorites; file: Favorites.xml
            textBoxAbout.LoadFile("SQLAgain_About.rtf");
            Process currentProcess = Process.GetCurrentProcess();
            processIDFile = Path.GetTempPath() + "sqlagain.ProcID_" + currentProcess.Id + ".tmp";
            SessionHistory.Reorg();                                                             
            if (file.Length != 0) { textBox_SqlFile.Text = Pathing.GetUNCPath(file[0]); }           //=== FILE passed as parameter (drag/drop file on SQLAgain Icon)
            logFileTemporary = Path.GetTempPath() + "sqlagain.txt";
            AllowDrop = true;
            DragEnter += new DragEventHandler(Form1_DragEnter);
            DragDrop += new DragEventHandler(Form1_DragDrop);
            checkBoxOptIgnoreError.Checked = false;
            buttonViewLog.Enabled = false;
            InitEnv();
            ShowSessionHistory();                                                                   // init - just to speed up ...
            inInit = false;                                                                         // init-phase completed
        }
        private void InitEnv()
        {
            sqlPlusVersion = SqlPlusVersion(sqlPlusPath);
            if (sqlPlusVersion != "-1")
            {
                tnsNames = GetTNSFile();
                if (File.Exists(tnsNames))
                {
                    namesDefaultDomain = GetSqlnetOra(Path.GetDirectoryName(tnsNames));
                    BuildDBList();
                }
                else
                {
                    if (!string.IsNullOrEmpty(dbUser))
                        SetMessage("", "Startup", "Error: File tnsNames.ora not found. Please configure your settings in Options.", true);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(dbUser))
                    SetMessage("", "Startup", "SQL*Plus Version Detection failed. Please configure your settings in Options.", true);
            }
            if (string.IsNullOrEmpty(dbUser))
            {
                SetMessage("", "Startup", "No DB-User found. Please configure your settings in Options.", true);
            }
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files) textBox_SqlFile.Text = Pathing.GetUNCPath(file);
        }
        private void BuildDBList()
        {
            bool colorSet;
            int iDB = 0;
            int iGroup;
            labelDB.Text = "Oracle Databases from file \"" + tnsNames + "\"";            
            listView_DBs.Clear();
            listDBMatches.Clear();
            List<Regex> dbGroupRegex = new List<Regex>();
            List<int> dbGroupMatches = new List<int>();
            for (iGroup = 0; iGroup < tableDBGroups.Rows.Count; iGroup++)
            {
                try
                {
                    dbGroupRegex.Add(new Regex(tableDBGroups.Rows[iGroup][1].ToString(), RegexOptions.IgnorePatternWhitespace));
                }
                catch {
                    dbGroupRegex.Add(new Regex("^$", RegexOptions.IgnorePatternWhitespace));
                }
                dbGroupMatches.Add(0);
            }
            Regex excludeDbSearch = new Regex(textBox_OptDBGroup_ExcludeDBs.Text, RegexOptions.IgnorePatternWhitespace); 
            listView_DBs.Columns.Add("DB", 200);
            
            foreach (string DB in ListTNSAlias(tnsNames, namesDefaultDomain))
            {
                if ((string.IsNullOrEmpty(textBox_OptDBGroup_ExcludeDBs.Text)) || (!excludeDbSearch.IsMatch(DB)))
                {
                    colorSet = false;
                    List<int> Data = new List<int>();
                    ListViewItem item1 = new ListViewItem(DB)
                    {
                        Text = DB
                    };
                    for (iGroup = 0; iGroup < dbGroupRegex.Count; iGroup++)
                    {
                        if (dbGroupRegex[iGroup].IsMatch(DB))
                        {
                            Data.Add(1);
                            dbGroupMatches[iGroup]++;
                            if (!colorSet)
                            {
                                try
                                {
                                    item1.ForeColor = ColorTranslator.FromHtml(tableDBGroups.Rows[iGroup][2].ToString());
                                    colorSet = true;
                                }
                                catch (Exception) 
                                {
                                    tableDBGroups.Rows[iGroup][2] = "#666666";
                                }
                            }
                        } else
                        {
                            Data.Add(0);
                        }
                    }
                    iDB++;
                    listView_DBs.Items.Add(item1);
                    listDBMatches.Add(Data);
                }
            }
            listView_DBGroups.BeginUpdate();
            listView_DBGroups.Items.Clear();
            for (iGroup = 0; iGroup < tableDBGroups.Rows.Count; iGroup++)
            {
                if (dbGroupMatches[iGroup] > 0)                                                     // skip DBGroups where no DB was matched
                {
                    ListViewItem item = new ListViewItem(new string[]
                        {
                        tableDBGroups.Rows[iGroup][0].ToString() ,
                        dbGroupMatches[iGroup].ToString()
                        })
                    {
                        Tag = iGroup,
                        ForeColor = ColorTranslator.FromHtml(tableDBGroups.Rows[iGroup][2].ToString())
                    };
                    listView_DBGroups.Items.Add(item);
                }
            }
            listView_DBGroups.EndUpdate();
            buildDBListPending = false;
        }
        public System.Diagnostics.Process p = new System.Diagnostics.Process();
        private void ListBoxUserChanged(object sender, EventArgs e)
        {
            dbUser         = tableDBUser.Rows[listBox_User.SelectedIndex].Field<string>(0);
            dbSchema       = tableDBUser.Rows[listBox_User.SelectedIndex].Field<string>(1);
            dbUserPassword = tableDBUser.Rows[listBox_User.SelectedIndex].Field<string>(2);
            sysDBA         = tableDBUser.Rows[listBox_User.SelectedIndex].Field<bool>(3);
        }
        private void ButtonTNSPing(object sender, EventArgs e)
        {
            if (listView_DBs.CheckedItems.Count == 0)
            {
                SetMessage("", "Ping DB", "No Database selected. Please select at least one Database in the List.", true);
            }
            else
            {
                tabControl1.SelectedIndex = 0;                                                      // switch always to Tab "Status Message"
                string db;
                foreach (ListViewItem listItem in listView_DBs.CheckedItems)
                {
                    listItem.EnsureVisible();
                    listItem.BackColor = ColorTranslator.FromHtml("Highlight");
                    db = listItem.SubItems[0].Text;
                    if (pingWithSqlPlus)
                            SetMessage(db, "sqlplus -P", TnsPing(db),false,true);                   // Show Message in Message/Log - but not in toolStripStatus
                    else    SetMessage(db, "tnsping", TnsPing(db),false,true);                      // because tnsping is normally faster than "await Task.Delay(5000);" - 5 seconds
                    listItem.BackColor = colorBack1;
                }
            }
        }
        private void SetMessage(string db, string action, string message, bool error = false, bool skipStatus = false)
        {
            string[] array = new string[4] { DateTime.Now.ToString("yyyy'/'MM'/'dd HH:mm:ss"), db, action, message };
            var itm = new ListViewItem(array);
            listViewStatusMessages.Items.Add(itm);
            listViewStatusMessages.EnsureVisible(listViewStatusMessages.Items.Count - 1); /* Ensure last element visible */
            listViewStatusMessages.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewStatusMessages.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            if(!skipStatus)
            {
                if (error)
                    toolStripStatusLabel.ForeColor = textColorStatusLabel1;
                else
                    toolStripStatusLabel.ForeColor = textColorStatusLabel2;
                pendingMessages.Enqueue(message);
            }
        }
        
        private void ButtonSqlFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "sql files (*.sql,*.pls)|*.sql;*.pls|All files (*.*)|*.*",
                FilterIndex = 1,
                Title = "Select a SQL-File to execute in SQLAgain"
            };
            if (!string.IsNullOrEmpty(sqlFile))
            {
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(sqlFile);
                openFileDialog1.FileName = Path.GetFileName(sqlFile);
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sqlFile = Pathing.GetUNCPath(openFileDialog1.FileName);
                textBox_SqlFile.Text = sqlFile;
            }
        }
        private void CheckBoxLogChanged(object sender, EventArgs e)
        {
            if (checkBoxLog.Checked == false) checkBoxLogAppend.Checked = false;
        }
        private string TestAccessLogFile(string logFile)
        {
            string message = string.Empty;
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(logFile, true);
            }
            catch (Exception ex)
            {
                message = "WRITE - Access to Log File failed: " + ex.Message;
            }
            finally
            {
                sw?.Close();
                if (File.Exists(logFile))
                {
                    FileInfo file_info = new FileInfo(logFile);
                    if (file_info.Length < 1) File.Delete(logFile);     // delete only when file is empty (Length=0)
                }
            }
            return message;
        }
        private void EnableDisableViewLogfile()
        {
            if (File.Exists(logFile))
            {
                DateTime last_modified = File.GetLastWriteTime(logFile);
                toolTip1.SetToolTip(buttonViewLog, string.Format("View the logfile with Output from " + last_modified.ToString("yyyy'/'MM'/'dd HH:mm:ss")));
                buttonViewLog.Enabled = true;
            }
            else
                buttonViewLog.Enabled = false;
        }
        private void ButtonViewLog(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(logFile))
                MessageBox.Show("No Logfile defined.");
            else
            {
                if (File.Exists(logFile))
                {
                    if (logFile.EndsWith(".log"))
                        EditLog(logFile);
                    else
                        EditLog(logFile);
                }
                else { MessageBox.Show("Logfile does not exist."); }
            }
        }
        private void ButtonRunSQL(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (checkBoxLog.Checked == false)
                {
                    string mimeType = ".log";
                    if (checkBoxOptHTML.Checked) mimeType = ".html";
                    if (checkBoxOptCSV.Checked)  mimeType = ".csv";
                    logFile = logFileTemporary;
                    logFile = string.Format("{0}\\{1}{2}", Path.GetDirectoryName(logFile), Path.GetFileNameWithoutExtension(logFile), mimeType);
                } else {
                    logFile = textBox_LogFile.Text;
                }
                tabControl1.SelectedIndex = 0;                                                      // switch always to Tab "Status Message"
                SessionHistory.Record("***** Foreground Session started.", 2);
                SessionHistory.Record("SQL-File              : file:\\\\" + sqlFile);
                SessionHistory.Record("Log File              : file:\\\\" + logFile);
                if (checkBoxLogAppend.Checked == false)
                {
                    if (File.Exists(logFile))
                    {
                        try
                        {
                            File.Delete(logFile);
                        }
                        catch { }                        
                    }
                } else {
                    SessionHistory.Record("Append to Log File    : TRUE");
                }                    
                if (listView_DBs.CheckedItems.Count > 1)
                {
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    progressBar1.Maximum = 100;
                    progressBar1.Step = 1;
                    progressBar1.Value = 0;
                } else {
                    progressBar1.Style = ProgressBarStyle.Marquee;
                }                
                buttonRunSQL.Visible = false;
                buttonScheduleSQL.Visible = false;
                buttonCancelSQL.Visible = true;
                progressBar1.Visible = true;
                foreach (ListViewItem listItem in listView_DBs.CheckedItems)
                {
                    dbList.Add(listItem.SubItems[0].Text);
                }
                backgroundWorker1.RunWorkerAsync();  
            }            
            EnableDisableViewLogfile();            
        }
        private void ButtonScheduleSQL(object sender, EventArgs e)
        {
            string form2Parms = "-F\"" + sqlFile + "\"";
            string dbs;
            if (ValidateInput())
            {
                form2Parms = form2Parms + " -L\"" + logFile + "\"";
                form2Parms += " -I\"";
                foreach (ListViewItem listItem in listView_DBs.CheckedItems)
                {
                    dbs = listItem.SubItems[0].Text;
                    form2Parms = form2Parms + dbs + " ";
                }
                form2Parms += "\" -U" + dbUser;
                if (checkBoxOptSilent.Checked == true) { form2Parms += " -S "; }
                if (checkBoxLogAppend.Checked == true) { form2Parms += " -A "; }
                if (checkBoxOptHTML.Checked == true)   { form2Parms += " -Mhtml "; }
                if (checkBoxOptCSV.Checked == true)    { form2Parms += " -Mcsv "; }
                if (timeout > 0) form2Parms += " -T" + timeout;
                if (ignoreError) form2Parms += " -b";
                Form2 f = new Form2(form2Parms, Path.GetFileName(sqlFile), textBox_OptTask_Username.Text, textBox_OptTask_Password.Text, textBox_OptMail_MailSender.Text, textBox_OptMail_MailReceiver.Text, 
                    textBox_OptMail_Server.Text, maskedTextBox_OptMail_Port.Text, checkBox_OptMail_EnableSSL.Checked,textBox_OptMail_User.Text, textBox_OptMail_Password.Text, checkBox_OptEnv_Mode.Checked);
                //f.StartPosition = FormStartPosition.CenterParent;
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    WriteSettings();                                                                // Save current Settings for future Scheduler Tasks 
                    tabControl1.SelectedIndex = 0;                                                  // switch always to Tab "Status Message"
                    SetMessage("", "Task scheduled", string.Format("Task \"{0}\" starts at {1}.", f.taskName.Text.Trim(), f.startDate.Text));
                }
                f.Dispose();
            }
        }
        private void Button_CancelSQL_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            // if SQL*Plus is active (maybe hanging because of a missing character ?)
            // we're going to kill the SQL*Plus process ID, wait for the exit and write a corresponding message into the SQL logfile
            if (backgroundWorker1.IsBusy)
            {
                try
                {
                    string sqlPlusProcID = File.ReadAllText(processIDFile);
                    Process p = Process.GetProcessById(Convert.ToInt32(sqlPlusProcID));
                    if (!string.IsNullOrEmpty(sqlPlusProcID))
                    {
                        ExecSQL.EndProcessTree(p.Id);
                        p.WaitForExit();
                        Thread.Sleep(1000);
                        DateTime time = DateTime.Now;
                        using (StreamWriter sw = File.AppendText(logFile))
                        {
                            sw.WriteLine("*** " + time.ToString("yyyy'/'MM'/'dd HH:mm:ss")
                                       + "   ***   Button 'Cancel SQL' was pressed - SQL*Plus Process-Tree killed.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cancel SQL - the following exception was raised:\n " + ex.Message);
                }
            }
            sqlResult = "Button 'Cancel SQL' was pressed, stopped SQL*Plus Process-Tree.";
            SessionHistory.Record("Button 'Cancel SQL' was pressed, stopping SQL*Plus Process-Tree.");
        }
        private bool ValidateInput()
        {
            // DB selected ?   ---------------------------------------------------------------------------------------------
            if (listView_DBs.CheckedItems.Count == 0)
            {
                SetMessage("", "Execute/Schedule", "No Database selected. Please select one or more Database in the List above.", true);
                return false;
            }
            // SQL File valid ?   ------------------------------------------------------------------------------------------
            bool valid = true;
            string message = string.Empty;
            if (string.IsNullOrEmpty(textBox_SqlFile.Text))                                         // Empty Textbox
            {
                valid = false;
                message = "Please enter a Filename";
            } else {
                if (File.Exists(textBox_SqlFile.Text))                                              // existing File
                {
                    if (Utils.CheckPLSQLBlock(sqlFile) == false)                                    // validate Contents
                    {
                        valid = false;
                        message = "File Contents: Missing slash (/) after CREATE (FUNCTION|PACKAGE|PROCEDURE|TRIGGER) detected";
                    }
                } else {
                    valid = false;
                    message = "File does not exist";
                }
            }
            if (!valid)
            {
                SetMessage("", "Execute/Schedule", "SQL Filename: " + message, true);
                return false;
            }
            // Log File valid ?   ------------------------------------------------------------------------------------------
            if (checkBoxLog.Checked == true)                                                         // Log to File checked
            {
                if (!string.IsNullOrEmpty(textBox_LogFile.Text))
                {
                    logFile = Pathing.GetUNCPath(textBox_LogFile.Text);
                    message = TestAccessLogFile(logFile);                                           // Test WRITE Access
                    if (!string.IsNullOrEmpty(message))
                    {
                        SetMessage("", "Execute/Schedule", "Log Filename: " + message, true);
                        return false;
                    }
                } else {                                                                            // Log File is empty (erased by User)
                    SetMessage("", "Execute/Schedule", "Log Filename: Please enter a Logfile or de-select the Loging Option.", true);
                    return false;
                } 
            } else {                                                                                // Log to File not checked
                logFile = logFileTemporary;                                                         // use TEMPFILE
                DeleteTempFile(logFileTemporary);                                                   // delete existing TEMPFILE
            }
            timeout = decimal.ToInt32(timeoutHH.Value) * 3600 + decimal.ToInt32(timeoutMM.Value) * 60 + decimal.ToInt32(timeoutSS.Value);
            return true;
        }
        private string GetTNSFile()
        {
            string tnsAdmin;
            string oracleHome;
            string tnsNames = "tnsnames.ora";
            // Check if TNS_ADMIN or ORACLE_HOME is set. If not: search oracle in PATH
            tnsAdmin = Environment.GetEnvironmentVariable("TNS_ADMIN");
            if (!string.IsNullOrEmpty(tnsAdmin))            
                tnsNames = tnsAdmin += "\\tnsnames.ora";            
            else
            {
                oracleHome = Environment.GetEnvironmentVariable("ORACLE_HOME");
                if (!string.IsNullOrEmpty(oracleHome)) { tnsNames = oracleHome += "\\network\\admin\\tnsnames.ora"; }
                else
                {
                    string sqlplus = "sqlplus.exe";
                    foreach (string test in (Environment.GetEnvironmentVariable("PATH") ?? "").Split(';'))
                    {
                        string path = test.Trim();
                        if (!String.IsNullOrEmpty(path) && File.Exists(path = Path.Combine(path, sqlplus)))
                        {
                            tnsNames = Path.GetFullPath(path).Substring(0, Path.GetFullPath(path).Length - 15) + "network\\admin\\tnsNames.ora";
                            return tnsNames;        
                        }
                    }
                }
            }
            return tnsNames;
        }
        private string GetSqlnetOra(string directory)
        {
            string namesDefaultDomain = string.Empty;
            string fileSqlnetOra = Path.Combine(directory, "sqlnet.ora");
            int startIndex;
            int endIndex;
            if (File.Exists(fileSqlnetOra))
            {
                Regex g = new Regex(@"^NAMES.DEFAULT_DOMAIN.*=");
                using (StreamReader r = new StreamReader(fileSqlnetOra))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        Match m = g.Match(line);
                        if (m.Success)
                        {
                            line = line.Replace(" ", "");
                             startIndex = line.IndexOf('=')+1;
                             endIndex = line.IndexOf('#', startIndex);
                            if (endIndex > 0)
                                namesDefaultDomain = line.Substring(startIndex, endIndex - startIndex);
                            else
                                namesDefaultDomain = line.Substring(startIndex);                            
                            break;
                        }                            
                    }
                }
            }
            return namesDefaultDomain;
        }
        public static List<string> ListTNSAlias(string tnsNames, string namesDefaultDomain)
        {
            Regex g = new Regex(pattern: @"^(\w+\.*\w*\.*\w*)\s+=");
            using (StreamReader r = new StreamReader(tnsNames))
            {
                string line;
                string value;
                string dbDomain;
                ListDBs.ResetList();    // Options changed - re-read tnsNames in cleared dbs list
                while ((line = r.ReadLine()) != null)
                {
                    Match m = g.Match(line);
                    if (m.Success)
                    {
                        value = m.Groups[1].Value;
                        if (!string.IsNullOrEmpty(namesDefaultDomain))
                        {
                            dbDomain = value.Substring(value.IndexOf(".") + 1);
                            if (dbDomain.Equals(namesDefaultDomain, StringComparison.OrdinalIgnoreCase))
                                value = value.Split('.').First();
                        }
                        ListDBs.Record(value);
                    }
                }
            }
            return ListDBs.GetList();
        }
        public static class ListDBs
        {
            private static readonly List<string> dbs; 
            static ListDBs()
            {
                dbs = new List<string>();
            }
            public static void ResetList()
            {
                dbs.Clear();
            }
            public static void Record(string value)
            {
                dbs.Add(value);
            }
            public static List<string> GetList()
            {
                dbs.Sort();
                return dbs;
            }
        }

        private string SqlPlusVersion(string sqlPlusPath)
        {     
            if (string.IsNullOrEmpty(sqlPlusPath))
            {
                return string.Format("{0}", -1);
            }
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = sqlPlusPath;
            p.StartInfo.Arguments = "-V";
            try
            {
                p.Start();
                var output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                Match match = Regex.Match(output, @"Version (\d{1,2}).(\d{1,2})\.*", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    if (int.Parse(match.Groups[1].Value) >= 23)                                     // SQL*Plus Version 23 introduced Option -P to ping DB
                    {
                        pingWithSqlPlus = true;
                    }
                    else                                                                            // older Version: instant client without tnsping ?
                    {
                        if (!File.Exists(Regex.Replace(sqlPlusPath, @"\bsqlplus.exe\b", "tnsping.exe")))
                        {
                            buttonTNSPing.Visible = false;                                          // disable Button TNS-Ping
                        }
                    }
                    SetMessage("", "Environment", string.Format("Detected SQL*Plus Version: {0}", match.Groups[1].Value + "." + match.Groups[2].Value));
                    return match.Groups[1].Value + "." + match.Groups[2].Value;
                }
                MessageBox.Show(text: "Call to \"sqlplus -V\" was not successful - wrong NLS_LANG defined? "  + output);
                return string.Format("{0}", -1);
            }
            catch
            {
                return string.Format("{0}", -1);
            }            
        }
        private string TnsPing(string db)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            if (pingWithSqlPlus)
            {
                p.StartInfo.FileName = sqlPlusPath;
                p.StartInfo.Arguments = "-P " + db;
            } else
            {
                p.StartInfo.FileName = "tnsping";
                p.StartInfo.Arguments = db;
            }
            string standardOutput;
            string lastLine = "failed";
            bool tnspingFailed = false;
            try
            {
                p.Start();
            }
            catch (Exception)
            {
                tnspingFailed = true;
                lastLine = "not found";
            }
            if (! tnspingFailed)
            {                
                p.WaitForExit();
                while ((standardOutput = p.StandardOutput.ReadLine()) != null)
                {
                    if (standardOutput != null)
                    {
                        lastLine = standardOutput;
                        Match match = Regex.Match(standardOutput, @"^[A-Z].*-\d{3,5}:");
                        if (match.Success) return lastLine;
                    }
                }
            }
            return lastLine;
        }
        public static void EditLog(string logfile)
        {
            if (string.IsNullOrEmpty(logfile))
            {
                throw new ArgumentException($"'{nameof(logfile)}' cannot be null or empty.", nameof(logfile));
            }
            Process p = new Process();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = logfile;
            try { p.Start(); }
            catch (Exception EX)
            {
                MessageBox.Show(string.Format(EX.Message));
            }
        }
        public static string AddQuotesIfRequired(string path)
        {
            return !string.IsNullOrWhiteSpace(path) ?
                path.Contains(" ") && (!path.StartsWith("\"") && !path.EndsWith("\"")) ?
                    "\"" + path + "\"" : path :
                    string.Empty;
        }
        public static void DeleteTempFile(string tempFile)
        {
            try
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error deleteing TEMP file: " + ex.Message));
            }
        }
        
        private void CheckBoxOptHTMLChanged(object sender, EventArgs e)
        {
            if (checkBoxOptHTML.Checked == true)
            {
                if (checkBoxOptCSV.Checked == true)
                    checkBoxOptCSV.Checked = false;
            }
            SetLogfileSuffix();
        }
        private void CheckBoxOptCSVChanged(object sender, EventArgs e)
        {
            if (checkBoxOptCSV.Checked == true)
            {
                if (checkBoxOptHTML.Checked == true)
                    checkBoxOptHTML.Checked = false;
            }
            SetLogfileSuffix();
        }
        private void SetLogfileSuffix()
        {
            string mimeType = ".log";
            logFile = sqlFile;
            if (checkBoxOptHTML.Checked) mimeType = ".html";
            if (checkBoxOptCSV.Checked) mimeType = ".csv";
            logFile = string.Format("{0}\\{1}{2}", Path.GetDirectoryName(logFile), Path.GetFileNameWithoutExtension(logFile), mimeType);
            textBox_LogFile.Text = logFile;
            textBox_LogFile.CausesValidation = true;
            EnableDisableViewLogfile();
        }
        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {            
            string connectString;
            string sqlPlusOptions = string.Empty;
            string oracleSIDList = string.Empty;
            int percentage;
            string sqlPathNew ;
            selectedDbCount = 0;
            // SQLPATH: add directory of SQLFILE in front of SQLPATH; reset after calling SQL*Plus
            string sqlFileDirectory = new System.IO.FileInfo(sqlFile).DirectoryName;
            if (sqlPath != string.Empty)
                sqlPathNew = string.Format("{0};{1}", sqlFileDirectory, sqlPath);
            else
                sqlPathNew = sqlFileDirectory;
            Environment.SetEnvironmentVariable("SQLPATH", sqlPathNew);
            if (checkBoxOptSilent.Checked == true)
            {
                sqlPlusOptions = "-S";
                SessionHistory.Record("SQL*Plus Option       : -S");
            }
            if (checkBoxOptHTML.Checked == true)
            {
                SessionHistory.Record("SQL*Plus Format Option: HTML");
                sqlPlusOptions = string.Format("{0} HTML", sqlPlusOptions);
            }
            if (checkBoxOptCSV.Checked == true)
            {
                SessionHistory.Record("SQL*Plus Format Option: CSV");
                sqlPlusOptions = string.Format("{0} CSV", sqlPlusOptions);
            }
            if (checkBoxOptIgnoreError.Checked == true)
            {
                SessionHistory.Record("Ignore severe Error   : true");
            }
            if (timeout > 0)
            {
                SessionHistory.Record("Timeout for SQL*Plus  : " + String.Format("{0}:{1}:{2}", timeoutHH.Value, timeoutMM.Value, timeoutSS.Value));
            }
            foreach (string db in dbList)
            {
                oracleSIDList = oracleSIDList + db + " ";
            }
            SessionHistory.Record("Instance List         : " + oracleSIDList);
            SessionHistory.Record("DB User               : " + dbUser);
            SessionHistory.Record("",1,3);
            foreach (string db in dbList)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                } 
                selectedDbCount++;
                percentage = selectedDbCount * 100 / dbList.Count;
                backgroundWorker1.ReportProgress((percentage), db);
                connectString = string.Format("{0}/{1}@{2}", dbSchema, dbUserPassword, db);
                if (sysDBA) connectString += " AS SYSDBA";
                SessionHistory.Record(db.PadRight(24) + Path.GetFileName(sqlFile).PadRight(50), 0, 1);
                sqlResult = ExecSQL.DoSQL(sqlPlusPath, db, connectString, sqlFile, logFile, sqlPlusOptions, processIDFile, timeout, ignoreError);
            }
            Environment.SetEnvironmentVariable("SQLPATH", sqlPath);
        }
        private void BackgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            string db = Convert.ToString(e.UserState);
            int x = 0;
            EnableDisableViewLogfile();
            if (selectedDbCount > 1)
            {
                ListViewItem itm = listViewStatusMessages.Items[listViewStatusMessages.Items.Count - 1];
                itm.SubItems[3].Text = sqlResult;
            }
            foreach (ListViewItem listItem in listView_DBs.Items)
            {
                x++;
                if (listItem.Text == db)
                {
                    listItem.Focused = true;
                    listItem.BackColor = ColorTranslator.FromHtml("Highlight");
                    listItem.EnsureVisible();
                }
                else
                {
                    listItem.BackColor = colorBack1;
                }
                    
            }
            progressBar1.Value = e.ProgressPercentage;
            SetMessage(db, Path.GetFileName(sqlFile), string.Empty,false,true);
        }
        private void BackgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            EnableDisableViewLogfile();
            if (selectedDbCount > 0)
            {
                ListViewItem itm = listViewStatusMessages.Items[listViewStatusMessages.Items.Count - 1];
                itm.SubItems[3].Text = sqlResult;
            }
            foreach (ListViewItem listItem in listView_DBs.Items)
            {
                listItem.BackColor = colorBack1;
                //listItem.ForeColor = System.Drawing.ColorTranslator.FromHtml(listItem.SubItems[4].Text);
            }
            buttonRunSQL.Visible = true;
            buttonScheduleSQL.Visible = true;
            buttonCancelSQL.Visible = false;
            progressBar1.Value = 0;
            progressBar1.Visible = false;
            SessionHistory.Record("***** Foreground Session ended.", 2);
            EditLog(logFile);
            dbList.Clear();
        }
        
        private void TabControl1MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // right MouseButton pressed not in selected tab ? select tab first ...
                for (int i=0; i < tabControl1.TabCount; i++)
                {
                    if (tabControl1.GetTabRect(i).Contains(e.X, e.Y))
                        tabControl1.SelectedIndex = i;                   
                } 
                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        this.contextMenuStatusMessages.Show(this.tabControl1, e.Location);
                        break;
                    case 3:
                        this.contextMenuSessionHistory.Show(this.tabControl1, e.Location);
                        break;                    
                }                
            }            
        }
        private void SessionHistoryEdit(object sender, EventArgs e)
        {
            EditLog(SessionHistory.traceFile);
        }
        
        private void SessionHistoryRefresh(object sender, EventArgs e)
        {
            ShowSessionHistory();
        }
        private void StatusMessagesClear(object sender, EventArgs e)
        {
            listViewStatusMessages.Items.Clear();
        }
        private void TextBoxAboutLink(object sender, LinkClickedEventArgs e)
        {
            try
            {
                p = Process.Start(e.LinkText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TextBoxSessionHistoryLinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (e.LinkText.Substring(0, 7) == "file:\\")
                try
                {
                    p = Process.Start(e.LinkText.Substring(6));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
           
            else
                try
                {
                    p = Process.Start(e.LinkText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        private void FavoritesLoad(object sender, EventArgs e)
        {
            foreach (ListViewItem lVFavorite in listViewFavorites.SelectedItems)
            {               
                Favorite favorite = listFavorites[Convert.ToInt16(lVFavorite.Tag)];
                textBox_SqlFile.Text = favorite.File;                
                checkBoxLog.Checked = (favorite.Log2File);
                checkBoxLogAppend.Checked = (favorite.LogAppend);
                textBox_LogFile.Text = favorite.LogFile;
                checkBoxOptSilent.Checked = (favorite.OptSilent);
                checkBoxOptHTML.Checked = (favorite.OptFormat == 1);
                checkBoxOptCSV.Checked = (favorite.OptFormat == 2);
                string[] words = favorite.Timeout.Split(':');
                timeoutHH.Value = Convert.ToInt16(words[0]);
                timeoutMM.Value = Convert.ToInt16(words[1]);
                timeoutSS.Value = Convert.ToInt16(words[2]);
                checkBoxOptIgnoreError.Checked = (favorite.IgnoreError);
                for (int i = 0; i < listBox_User.Items.Count; i++)  // listBox_User: select favorite.DBUser
                {
                    if (listBox_User.Items[i].ToString() == favorite.DBUser)
                    {
                        listBox_User.SetSelected(i, true);
                        break;
                    }                        
                } 
                string[] dbs = favorite.DBList.Split(' ');           // ListView_DBs (DBs): select favorite.DBList
                foreach (ListViewItem listDB in listView_DBs.Items)
                {
                    listDB.Checked = false;                         // uncheck all DBs
                    foreach (string db in dbs)
                    {
                        string[] db_name = db.Split('.');
                        if (listDB.SubItems[0].Text == db_name[0])
                            listDB.Checked = true;                  // check when in favorite.DBList 
                    }
                }
                SetMessage("", "Favorites", "loaded \"" + favorite.Text + "\".");
            }     
        }
        private void FavoritesDelete(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFavorites.SelectedItems)
            {
                listViewFavorites.Items.Remove(item);
                SetMessage("", "Favorites", "deleted \"" + item.SubItems[0].Text + "\".");
            }
        }

        private void FavoritesEditFile_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lVFavorite in listViewFavorites.SelectedItems)
            {
                Favorite favorite = listFavorites[Convert.ToInt16(lVFavorite.Tag)];
                EditLog(favorite.File);
            }
        }
        private void FavoritesUpdate(object sender, EventArgs e)
        {
            FavoritesLoad(sender, e);
            foreach (ListViewItem lVFavorite in listViewFavorites.SelectedItems)
            {
                textBox_Favorites_NewDesc.Text = lVFavorite.SubItems[0].Text;
                textBox_Favorites_NewFile.Text = lVFavorite.SubItems[1].Text; 
                textBox_Favorites_NewUser.Text = lVFavorite.SubItems[2].Text;
                textBox_Favorites_NewDBs.Text  = lVFavorite.SubItems[3].Text;
                button_Favorites_Add.Text = "Update";
                textBox_Favorites_NewDesc.Focus();
            }
        }
        private void FavoritesRun(object sender, EventArgs e)
        {
            FavoritesLoad(sender, e);
            ButtonRunSQL(sender, e);
        }
        private void KeyPressTimeoutHH(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void KeyPressTimeoutMM(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void KeyPressTimeoutSS(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ListViewFavoritesDoubleClick(object sender, EventArgs e)
        {
            FavoritesRun(sender, e);
        }
                
        private void ListView_DBs_MouseLeave(object sender, EventArgs e)
        {
            listView_DBs.SelectedItems.Clear();
        }

        private void TextBoxSessionHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)  // Key F5 is the standard refresh, calls the same function as Context-Menu "Refresh"
            {
                ShowSessionHistory();
            }
        }

        private void CheckBoxOptIgnoreError_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOptIgnoreError.Checked)
            {
                ignoreError = true;
            }
            else 
            {
                ignoreError = false;
            }
        }
                        
        private void ListView_DBs_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            switch (listView_DBs.CheckedItems.Count)
            {
                case 0:
                    labelDBsSelected.Text = string.Empty;
                    break;
                case 1:
                    labelDBsSelected.Text = "1 Database selected.";
                    break;
                default:
                    labelDBsSelected.Text = listView_DBs.CheckedItems.Count + " Databases selected.";
                    break;
            }
        }
               
        private void TextBoxSessionHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int startLine = -1;                             // On Mouse DoubleClick (in SessionHistory Area)
            bool searchLines = true;                        // Read from above Section "Session started" until following
            string selectedText ;                           // empty line and copy all Options/Parameters to the 
            string selectedArgument = string.Empty;         // Form1 Input- resp. Selection-Fields
            bool startBlockFound = false;
            bool searchBlockIsTask = false;
            
            
            textBoxSessionHistory.SelectionStart = textBoxSessionHistory.GetCharIndexFromPosition(e.Location);
            int selectedLine = textBoxSessionHistory.GetLineFromCharIndex(textBoxSessionHistory.SelectionStart);
            while (selectedLine >= 0 )
            {
                selectedText = textBoxSessionHistory.Lines[selectedLine];
                Match match = Regex.Match(selectedText, @"Session started.", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    startLine = selectedLine;
                    startBlockFound = true;
                    break;
                }
                match = Regex.Match(selectedText, @"Create Windows Task started.", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    startLine = selectedLine;
                    startBlockFound = true;
                    searchBlockIsTask = true;
                    break;
                }
                else
                {
                    selectedLine--;
                }
            }
            if (startBlockFound)
            {
                textBoxSessionHistory.SelectionStart = textBoxSessionHistory.GetFirstCharIndexFromLine(startLine);
                // reset all Checkbox-Options
                checkBoxLogAppend.Checked = false;
                checkBoxOptSilent.Checked = false;
                checkBoxOptCSV.Checked = false;
                checkBoxOptHTML.Checked = false;
                checkBoxOptIgnoreError.Checked = false;
                timeoutHH.Value = 0;
                timeoutMM.Value = 0;
                timeoutSS.Value = 0;
                if (searchBlockIsTask)                  // Process Block: ***** Create Windows Task 
                {
                    try 
                    { 
                    
                        while (searchLines)
                        {
                            startLine++;
                            selectedText = textBoxSessionHistory.Lines[startLine];
                            if (string.IsNullOrEmpty(selectedText) || string.IsNullOrWhiteSpace(selectedText))
                            {
                                searchLines = false;
                            }
                            else
                            {
                                if (selectedText.Substring(21, 23) == "Task Action/Arguments :")    // Only Task-Arguments, skip Scheduler-Arguments
                                {
                                    searchLines = false;
                                    startLine++;
                                    string[] stringSeparators = new string[] { " -" };
                                    string[] taskArgs = selectedText.Substring(46).Split(stringSeparators, StringSplitOptions.None);
                                    for (int ix = 0; ix < taskArgs.Length; ++ix)
                                    {
                                        string arg1 = taskArgs[ix];
                                        switch (arg1.ToLower().Substring(0, 1))
                                        {
                                            case "f":       // Argument -f "SQLFILE"
                                                textBox_SqlFile.Text = taskArgs[ix].Substring(2, taskArgs[ix].Length-3);
                                                break;
                                            case "l":       // Argument -l LOGFILE
                                                textBox_LogFile.Text = taskArgs[ix].Substring(2, taskArgs[ix].Length-3);
                                                checkBoxLog.Checked = true;
                                                string logFileShort = textBox_LogFile.Text.Substring(0, textBox_LogFile.Text.LastIndexOf('.'));
                                                string tempFileShort = logFileTemporary.Substring(0, logFileTemporary.LastIndexOf('.'));
                                                if (logFileShort == tempFileShort)
                                                {
                                                    checkBoxLog.Checked = false;
                                                }
                                                break;
                                            case "a":       // Argument -a  append to logfile
                                                checkBoxLogAppend.Checked = true;
                                                break;
                                            case "i":       // Argument -i "DB1 DB2 DB3"
                                                string[] dbs = taskArgs[ix].Substring(1).Split(' ');
                                                foreach (ListViewItem listDB in listView_DBs.Items)
                                                {
                                                    listDB.Checked = false;
                                                    foreach (string db in dbs)
                                                    {
                                                        string[] db_name = db.Split('.');
                                                        if (listDB.SubItems[0].Text == db_name[0].Trim('"'))
                                                            listDB.Checked = true;
                                                    }
                                                }
                                                break;
                                            case "s":       // Argument -s SQL*Plus option -S (silent)
                                                checkBoxOptSilent.Checked = true;
                                                break;
                                        
                                            case "u":       // Argument -u USERNAME (ListBoxUser)
                                                for (int i = 0; i < listBox_User.Items.Count; i++)
                                                {
                                                    if (listBox_User.Items[i].ToString() == taskArgs[ix].Substring(1).Trim())
                                                    {
                                                        listBox_User.SetSelected(i, true);
                                                        break;
                                                    }
                                                }
                                                break;
                                            case "m":      // Argument -m MARKUP "HTML" or "CSV";
                                                if (taskArgs[ix].ToLower().Substring(1,3) == "csv")
                                                {
                                                    checkBoxOptCSV.Checked = true;
                                                }
                                                else if (taskArgs[ix].ToLower().Substring(1,4) == "html")
                                                {
                                                    checkBoxOptHTML.Checked = true;
                                                }                                            
                                                break;
                                            case "t":       // Argument -t seconds
                                                if (Double.TryParse(taskArgs[ix].Substring(1), out double number))
                                                {
                                                    TimeSpan t = TimeSpan.FromSeconds(number);
                                                    timeoutHH.Value = Convert.ToInt16(t.Hours);
                                                    timeoutMM.Value = Convert.ToInt16(t.Minutes);
                                                    timeoutSS.Value = Convert.ToInt16(t.Seconds);
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                        
                        }
                    }
                    catch {
                        MessageBox.Show("Unable to Capture Text - String possibly  contains character \"-\" ?.");
                    }
                    ;
                }
                if (!searchBlockIsTask)                 // Process Block: ***** Foreground Session  and   ***** Batch Session
                {
                    while (searchLines)
                    {
                        startLine++;
                        selectedText = textBoxSessionHistory.Lines[startLine];
                        if (string.IsNullOrEmpty(selectedText))
                        {
                            searchLines = false;
                        }
                        else
                        {
                            if (selectedText.Length > 20)
                                selectedArgument = selectedText.Substring(21) + "                    ";

                            switch (selectedArgument.Substring(0, 19))
                            {
                                case "SQL-File           ":
                                    Match match = Regex.Match(selectedArgument, @"SQL-File.*: file:\\\\(.*)", RegexOptions.IgnoreCase);
                                    if (match.Success)
                                    {
                                        textBox_SqlFile.Text = match.Groups[1].Value.Trim();
                                    }
                                    break;
                                case "Log File           ":
                                    match = Regex.Match(selectedArgument, @"Log File.*: file:\\\\(.*)", RegexOptions.IgnoreCase);
                                    if (match.Success)
                                    {
                                        textBox_LogFile.Text = match.Groups[1].Value.Trim();
                                        checkBoxLog.Checked = true;
                                        string logFileShort = textBox_LogFile.Text.Substring(0, textBox_LogFile.Text.LastIndexOf('.'));
                                        string tempFileShort = logFileTemporary.Substring(0, logFileTemporary.LastIndexOf('.'));
                                        if (logFileShort == tempFileShort)
                                        {
                                            checkBoxLog.Checked = false;
                                        }
                                    }
                                    break;
                                case "Append to Log File ":
                                    checkBoxLogAppend.Checked = true;
                                    break;
                                case "SQLcl Option       ":             // SQLAgain Version1
                                    checkBoxOptSilent.Checked = true;
                                    break;
                                case "SQL*Plus Option    ":             // SQLAgain Version2
                                    checkBoxOptSilent.Checked = true;
                                    break;
                                case "SQLcl Format Option":             // SQLAgain Version1
                                    match = Regex.Match(selectedArgument, @"SQLcl Format Option.*: ([A-Z]{3,4})", RegexOptions.IgnoreCase);
                                    if (match.Success)
                                    {
                                        if (match.Groups[1].Value == "CSV") { checkBoxOptCSV.Checked = true; }
                                        else { checkBoxOptHTML.Checked = true; }
                                    }
                                    break;
                                case "SQL*Plus Format Opt":             // SQLAgain Version2
                                    match = Regex.Match(selectedArgument, @"SQL\*Plus Format Option: ([A-Z]{3,4})", RegexOptions.IgnoreCase);
                                    if (match.Success)
                                    {
                                        if (match.Groups[1].Value == "CSV") { checkBoxOptCSV.Checked = true; }
                                        else { checkBoxOptHTML.Checked = true; }
                                    }
                                    break;
                                case "Ignore severe Error":
                                    checkBoxOptIgnoreError.Checked = true;
                                    break;

                                case "Timeout for SQLcl  ":             // SQLAgain Version1
                                    match = Regex.Match(selectedArgument, @"Timeout for SQLcl.*: (.*)$", RegexOptions.IgnoreCase);
                                    if (match.Success)
                                    {
                                        string[] words = match.Groups[1].Value.Split(':');
                                        timeoutHH.Value = Convert.ToInt16(words[0]);
                                        timeoutMM.Value = Convert.ToInt16(words[1]);
                                        timeoutSS.Value = Convert.ToInt16(words[2]);
                                    }
                                    break;
                                case "Timeout for SQL*Plu":             // SQLAgain Version2
                                    match = Regex.Match(selectedArgument, @"Timeout for SQL\*Plus.*: (.*)$", RegexOptions.IgnoreCase);
                                    if (match.Success)
                                    {
                                        string[] words = match.Groups[1].Value.Split(':');
                                        timeoutHH.Value = Convert.ToInt16(words[0]);
                                        timeoutMM.Value = Convert.ToInt16(words[1]);
                                        timeoutSS.Value = Convert.ToInt16(words[2]);
                                    }
                                    break;
                                case "Instance List      ":
                                    match = Regex.Match(selectedArgument, @"Instance List .*: (.*)$", RegexOptions.IgnoreCase);
                                    if (match.Success)
                                    {
                                        string[] dbs = match.Groups[1].Value.Split(' ');
                                        foreach (ListViewItem listDB in listView_DBs.Items)
                                        {
                                            listDB.Checked = false;
                                            foreach (string db in dbs)
                                            {
                                                string[] db_name = db.Split('.');
                                                if (listDB.SubItems[0].Text == db_name[0])
                                                    listDB.Checked = true;
                                            }
                                        }
                                    }
                                    break;
                                case "DB User            ":
                                    match = Regex.Match(selectedArgument, @"DB User .*: (.*)$", RegexOptions.IgnoreCase);
                                    if (match.Success)
                                    {
                                        for (int i = 0; i < listBox_User.Items.Count; i++)
                                        {
                                            if (listBox_User.Items[i].ToString() == match.Groups[1].Value.Trim())
                                            {
                                                listBox_User.SetSelected(i, true);
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                case "Remove Task        ":         // Batch Session started - stop at the Remove Task
                                    searchLines = false;
                                    break;
                                case "Email Address      ":         // Batch Session started - stop at the Email (new format)
                                    searchLines = false;
                                    break;
                                case "E-Mail Address     ":         // Batch Session started - stop at the E-Mail (old format) 
                                    searchLines = false;
                                    break;
                            }
                        }
                    }
                }
                textBoxSessionHistory.SelectionLength = textBoxSessionHistory.GetFirstCharIndexFromLine(startLine) - textBoxSessionHistory.SelectionStart;
                textBoxSessionHistory.Select(textBoxSessionHistory.SelectionStart, textBoxSessionHistory.SelectionLength);
                SetMessage("", "Session History", "Selected Session-Parameters copied.");
            } else
            {
                MessageBox.Show("Unable to Select Text - String \"Session started.\" not found in the selected Block.");
            }
            
        }

        private void TabControloptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (buildDBListPending)
                BuildDBList();
            if (tabControloptions.SelectedIndex == 1)                                                  // Database Groups
            {
                try
                {
                    if (dataGridView_DBGroups.ColumnCount > 0)
                    {
                        DataGridViewColumn col1 = dataGridView_DBGroups.Columns[0];
                        DataGridViewColumn col2 = dataGridView_DBGroups.Columns[1];
                        DataGridViewColumn col3 = dataGridView_DBGroups.Columns[2];
                        col1.Width = 100;
                        col2.Width = 525;
                        col3.Width = 60;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (tabControloptions.SelectedIndex == 5)                                                  // Check for Update
            {
                Version appVersion = Assembly.GetEntryAssembly().GetName().Version;
                string appLastWriteTime = File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location).ToString("yyyy'/'MM'/'dd HH:mm:ss");
                label_OptUpdate_Message1.Text = string.Empty;
                label_OptUpdate_Message2.Text = string.Empty;
                label_OptUpdate_Message3.Text = string.Empty;
                try
                {
                    // download manifest
                    doc = XDocument.Load(Settings.Default.RemoteManifest);

                    // if newer, display update dialog
                    Version newestVersion = new Version((string)doc.Root.Element("version"));
                    if (newestVersion > appVersion)
                    {
                        label_OptUpdate_Message1.Text = "Update available";
                        label_OptUpdate_Message2.Text = string.Format("{0}   from   {1}   is your current version", appVersion, appLastWriteTime);
                        label_OptUpdate_Message3.Text = string.Format("{0}   from   {1}   is the latest version", newestVersion, ((DateTime)doc.Root.Element("date")).ToString("yyyy'/'MM'/'dd HH:mm:ss"));
                        linkCheck4Update.Visible = true;
                        button_OptUpdate_Update.Visible = true;
                        check4UpdateInfo = (string)doc.Root.Element("info");
                    }
                    else
                    {
                        label_OptUpdate_Message1.Text = "Nothing to update ...";
                        label_OptUpdate_Message2.Text = appVersion.ToString() + " from ";
                        label_OptUpdate_Message2.Text = string.Format("{0} from {1} is the latest version", appVersion, appLastWriteTime);
                        button_OptUpdate_Update.Visible = false;
                        linkCheck4Update.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    label_OptUpdate_Message1.Text = "Unable to check Updates";
                    label_OptUpdate_Message2.Text = ex.Message;
                }
            }
        }

        private void Button_OptUpdate_Update_Click(object sender, EventArgs e)
        {
            Updater.LaunchUpdater(doc);
            this.Close();
        }

        private void DataGridViewDBUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView_DBUsers.Columns[e.ColumnIndex].Name == "Password" && e.Value != null)
            {
                dataGridView_DBUsers.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('●', e.Value.ToString().Length);
            }
        }
        private enum MoveDirection { Up = -1, Down = 1 };
        private void MoveItems_DBUser(MoveDirection direction)
        {
            int rowIndex = dataGridView_DBUsers.SelectedCells[0].OwningRow.Index;

            bool valid = dataGridView_DBUsers.RowCount > 0 &&
                        ((direction == MoveDirection.Down && (rowIndex - 1 < dataGridView_DBUsers.RowCount - 1))
                        || (direction == MoveDirection.Up && (rowIndex > 0)));
            if (valid)
            {
                DataRow row = tableDBUser.NewRow();
                row.ItemArray = tableDBUser.Rows[rowIndex].ItemArray;
                tableDBUser.Rows.RemoveAt(rowIndex);
                tableDBUser.Rows.InsertAt(row, rowIndex + (int)direction);
                Reload_listBoxUser();
                try 
                {
                    dataGridView_DBUsers.Rows[rowIndex + (int)direction].Selected = true;
                }
                catch { }
                
            }
        }
        private void ToolStripMenuOptDBUser_Up_Click(object sender, EventArgs e)
        {
            MoveItems_DBUser(MoveDirection.Up);
        }
        private void ToolStripMenuOptDBUser_Down_Click(object sender, EventArgs e)
        {
            MoveItems_DBUser(MoveDirection.Down);
        }
        private void Reload_listBoxUser()
        {
            listBox_User.BeginUpdate();
            listBox_User.Items.Clear();
            int i = 0;
            foreach (DataRow row1 in tableDBUser.Rows)
            {
                listBox_User.Items.Add(row1.Field<string>(0));
                if (row1.Field<string>(0) == dbUser)
                    listBox_User.SetSelected(i, true);
                dataGridView_DBUsers.Rows[i].Selected = false;
                i++;
            }
            listBox_User.EndUpdate();
            if (listBox_User.Items.Count == 0)
                dbUser = string.Empty;
            if (listBox_User.SelectedIndex == -1)
                listBox_User.SelectedIndex = 0;
        }
        private void ButtonOptDBUser_Add_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow row = tableDBUser.NewRow();
                row[0] = textBox_OptDBUser_NewUser.Text;
                row[1] = textBox_OptDBUser_NewSchema.Text;
                row[2] = textBox_OptDBUser_NewPassword.Text;
                row[3] = (checkBox_OptDBUser_NewSYSDBA.Checked) ? "True" : "False";
                tableDBUser.Rows.Add(row);
                listBox_User.Items.Add(row.Field<string>(0));
            }
            catch (Exception ex)
            {
                textBoxSessionHistory.Text = "Add new DB User failed: " + ex.Message;
                return;
            }
            textBox_OptDBUser_NewUser.Text = string.Empty;
            textBox_OptDBUser_NewSchema.Text = string.Empty;
            textBox_OptDBUser_NewPassword.Text = string.Empty;
            checkBox_OptDBUser_NewSYSDBA.Checked = false;
            Reload_listBoxUser();
        }
        private void DataGridViewDBUsers_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                Reload_listBoxUser();
            }
            catch (Exception ex)
            {
                textBoxSessionHistory.Text = "Delete DB User failed: " + ex.Message;
                return;
            }
        }
        private void DataGridView_DBUsers_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dataGridView_DBUsers.Rows[e.RowIndex];
            try
            {
                if ((String.IsNullOrEmpty(row.Cells[0].Value.ToString())) ||
                (String.IsNullOrEmpty(row.Cells[1].Value.ToString())) ||
                (String.IsNullOrEmpty(row.Cells[2].Value.ToString())))
                {
                    SetMessage("", "Options/DB User", "Column USER or SCHEMA or PASSWORD is empty.", true);
                }
                else
                    Reload_listBoxUser();
            }
            catch { }
        }
        private void HidePasswords_CheckedChanged(object sender, EventArgs e)
        {
            if (hidePasswords.Checked) { passwordEncrypt = true; } else { passwordEncrypt = false; }
        }
        private void Button_OptEnv_SqlPlusPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "exe Files|sqlplus.exe"
            };
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_OptEnv_SqlPlusPath.Text = openFileDialog.FileName;
            }
        }
        private void Button_OptEnv_TNS_ADMIN_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = false,
                RootFolder = Environment.SpecialFolder.MyComputer
            };
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_OptEnv_TNS_ADMIN.Text = folderDlg.SelectedPath;
                TextBox_OptEnv_TNS_ADMIN_Validating(sender, null);
            }
        }
        private void Button_OptEnv_SQLPATH_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            FolderBrowserDialog folderDlg = folderBrowserDialog;
            folderDlg.ShowNewFolderButton = false;
            folderDlg.RootFolder = Environment.SpecialFolder.MyComputer;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_OptEnv_SQLPATH.Text = folderDlg.SelectedPath;
                TextBox_OptEnv_SQLPATH_Validating(sender, null);
            }
        }

        private void ListView_DBs_KeyDown(object sender, KeyEventArgs e)                            // ListView_DBs: Ctrl+A selects all rows
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                listView_DBs.MultiSelect = true;
                foreach (ListViewItem item in listView_DBs.Items)
                {
                    item.Selected = true;
                }
            }
        }

        private void Button_OptDBGroup_Add_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow row = tableDBGroups.NewRow();
                row[0] = textBox_OptDBGroup_NewName.Text;
                row[1] = textBox_OptDBGroup_NewRegExp.Text;
                row[2] = textBox_OptDBGroup_NewColor.Text;
                tableDBGroups.Rows.Add(row);
                int rowIndex = dataGridView_DBGroups.RowCount - 1;                                  // new rows always at the end
                dataGridView_DBGroups.Rows[rowIndex].Cells[0].Style.ForeColor = ColorTranslator.FromHtml(textBox_OptDBGroup_NewColor.Text);
                dataGridView_DBGroups.Rows[rowIndex].Cells[2].Style.BackColor = ColorTranslator.FromHtml(textBox_OptDBGroup_NewColor.Text);
                dataGridView_DBGroups.Rows[rowIndex].Cells[2].Style.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                textBoxSessionHistory.Text = "Add new DB Group failed: " + ex.Message;
                return;
            }
            textBox_OptDBGroup_NewName.Text = string.Empty;
            textBox_OptDBGroup_NewRegExp.Text = string.Empty;
            textBox_OptDBGroup_NewColor.Text = string.Empty;
            buildDBListPending = true;                                                              // call BuildDBList when leaving this TabPage
        }
        private String SelectColor()
        {
            ColorDialog colorDlg = new ColorDialog
            {
                AllowFullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                ShowHelp = false,
                CustomColors = new int[] {  ColorTranslator.ToOle(ColorTranslator.FromHtml("#D34C00")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#a5d46a")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#ffff80")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#ffdf80")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#ffc080")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#ffa080")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#f5ce89")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#e4a331")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#cc8014")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#b17900")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#996100")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#ff6f00")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#db6a00")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#c45f00")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#934e00")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#633a00"))
                                            }
            };
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                string str = ColorTranslator.ToHtml(colorDlg.Color);
                return str;
            }
            return null;
        }

        private void DataGridView_DBGroups_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView_DBGroups.Columns[e.ColumnIndex].Name == "Color" && e.Value != null)
            {
                string color = e.Value.ToString();
                try 
                {
                    dataGridView_DBGroups.Rows[e.RowIndex].Cells[0].Style.ForeColor = ColorTranslator.FromHtml(color);
                    dataGridView_DBGroups.Rows[e.RowIndex].Cells[2].Style.BackColor = ColorTranslator.FromHtml(color);
                    dataGridView_DBGroups.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.Black;
                }
                catch { }
            }
        }

        private void DataGridView_DBGroups_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            buildDBListPending = true;                                                              // call BuildDBList when leaving this TabPage
        }

        private void TextBox_OptDBGroup_NewColor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_OptDBGroup_NewColor.Text = SelectColor();
        }
        

        private void DataGridView_DBGroups_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((dataGridView_DBGroups.Columns[e.ColumnIndex].Name == "Color") && (e.RowIndex > -1))
            {
                string color = SelectColor();
                tableDBGroups.Rows[e.RowIndex][e.ColumnIndex] = color;
                dataGridView_DBGroups.Rows[e.RowIndex].Cells[0].Style.ForeColor = ColorTranslator.FromHtml(color);
                dataGridView_DBGroups.Rows[e.RowIndex].Cells[2].Style.BackColor = ColorTranslator.FromHtml(color);
                dataGridView_DBGroups.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.Black;
            }
            buildDBListPending = true;                                                              // call BuildDBList when leaving this TabPage
        }


        private void TextBox_OptDBGroup_NewRegExp_Leave(object sender, EventArgs e)
        {
            try
            { Regex test_Regex = new Regex(textBox_OptDBGroup_NewRegExp.Text, RegexOptions.IgnorePatternWhitespace); }
            catch (Exception ex)
            {
                MessageBox.Show("Regular Expression is in Error: " + Environment.NewLine + ex.Message);
                textBox_OptDBGroup_NewRegExp.Focus();
            }
            buildDBListPending = true;                                                              // call BuildDBList when leaving this TabPage
        }


        private void DataGridView_DBGroups_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string value;
            if (dataGridView_DBGroups.Columns[e.ColumnIndex].Name == "Regular Expression")
            {
                value = dataGridView_DBGroups.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                try
                { Regex test_Regex = new Regex(value, RegexOptions.IgnorePatternWhitespace); }
                catch (Exception ex)
                {
                    MessageBox.Show("Regular Expression is in Error: " + Environment.NewLine + ex.Message);
                    dataGridView_DBGroups.CurrentCell = dataGridView_DBGroups.Rows[e.RowIndex].Cells[e.ColumnIndex];
                }
            }
            buildDBListPending = true;                                                              // call BuildDBList when leaving this TabPage
        }

        private void TextBox_OptDBGroup_ExcludeDBs_Leave(object sender, EventArgs e)
        {
            try
            { Regex test_Regex = new Regex(textBox_OptDBGroup_ExcludeDBs.Text, RegexOptions.IgnorePatternWhitespace); }
            catch (Exception ex)
            {
                MessageBox.Show("Regular Expression is in Error: " + Environment.NewLine + ex.Message);
                textBox_OptDBGroup_ExcludeDBs.Focus();
            }
            buildDBListPending = true;
        }

        private void TabControloptions_Leave(object sender, EventArgs e)
        {
            if (buildDBListPending)
                BuildDBList();
        }

        private void ToolStripMenuOptDBGroup_Up_Click(object sender, EventArgs e)
        {
            MoveItems_DBGroup(MoveDirection.Up);
        }
        private void ToolStripMenuOptDBGroup_Down_Click(object sender, EventArgs e)
        {
            MoveItems_DBGroup(MoveDirection.Down);
        }
        private void MoveItems_DBGroup(MoveDirection direction)
        {
            int rowIndex = dataGridView_DBGroups.SelectedCells[0].OwningRow.Index;

            bool valid = dataGridView_DBGroups.RowCount > 0 &&
                        ((direction == MoveDirection.Down && (rowIndex - 1 < dataGridView_DBGroups.RowCount - 1))
                        || (direction == MoveDirection.Up && (rowIndex > 0)));
            if (valid)
            {
                DataRow row = tableDBGroups.NewRow();
                row.ItemArray = tableDBGroups.Rows[rowIndex].ItemArray;
                tableDBGroups.Rows.RemoveAt(rowIndex);
                tableDBGroups.Rows.InsertAt(row, rowIndex + (int)direction);
                try
                {
                    dataGridView_DBGroups.Rows[rowIndex + (int)direction].Selected = true;
                }
                catch { }
                buildDBListPending = true;                                                              // call BuildDBList when leaving this TabPage
            }
        }
        private void MoveItems_Favorites(MoveDirection direction)
        {
            int rowIndex = 0;
            foreach (ListViewItem item2 in listViewFavorites.SelectedItems)
            {
                rowIndex = (int)item2.Tag;
            }
            bool valid = listViewFavorites.Items.Count > 0 &&
                        ((direction == MoveDirection.Down && (rowIndex - 1 < listViewFavorites.Items.Count - 1))
                        || (direction == MoveDirection.Up && (rowIndex > 0)));
            if (valid)
            {
                Favorite item1 = listFavorites[rowIndex];
                listFavorites.RemoveAt(rowIndex);
                listFavorites.Insert(rowIndex + (int)direction, new Favorite(
                        item1.File,
                        item1.Log2File,
                        item1.LogAppend,
                        item1.LogFile,
                        item1.DBUser,
                        item1.OptSilent,
                        item1.OptFormat,
                        item1.Timeout,
                        item1.IgnoreError,
                        item1.DBList,
                        item1.Text
                        )
                    );
                Reload_listViewFavorites();
            }
        }
        private void Reload_listViewFavorites()
        {
            listViewFavorites.BeginUpdate();
            listViewFavorites.Items.Clear();
            for (int i = 0; i < listFavorites.Count(); i++)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                        listFavorites[i].Text,
                        Path.GetFileNameWithoutExtension(listFavorites[i].File),
                        listFavorites[i].DBUser,
                        listFavorites[i].DBList
                }
                )
                { Tag = i };
                listViewFavorites.Items.Add(item);
            }
            listViewFavorites.EndUpdate();
        }


        private void ListView_DBGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_DBGroups.SelectedItems)
            {
                int i = (int)item.Tag;
                
                if (item.Checked)
                    item.Checked = false;
               else
                    item.Checked = true;
                SelectDBGroup(i, item.Checked);
            }
        }
        private void SelectDBGroup(int iGroup, bool selected)
        {
            int iDB;
            listView_DBs.BeginUpdate();
            for (iDB = 0; iDB < listDBMatches.Count; iDB++)
            {
                if (listDBMatches[iDB][iGroup] == 1)
                {
                    if (selected)
                        listView_DBs.Items[iDB].Checked = true;
                    else
                        listView_DBs.Items[iDB].Checked = false;
                }
            }
            listView_DBs.EndUpdate();
        }

        private void Button_OptMailTest_Click(object sender, EventArgs e)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(textBox_OptMail_MailSender.Text.Substring(0, textBox_OptMail_MailSender.Text.IndexOf("@")), textBox_OptMail_MailSender.Text));
            message.To.Add(new MailboxAddress(textBox_OptMail_MailReceiver.Text.Substring(0, textBox_OptMail_MailReceiver.Text.IndexOf("@")), textBox_OptMail_MailReceiver.Text));
            message.Subject = "SQLAgain Test Email";
            message.Body = new TextPart("html")
            {
                Text = Resources.MailHeader + "<table id=\"t01\" > <tr><td>" +
                "Dear Oracle DBA" +
                "<br>" +
                "<i>SQLAgain</i> sends you a Test Email with the following settings " +
                "<h3>Options / Email</h3>" +
                "</td></tr>" +
                "<tr><td> " +
                "<table id=\"t02\" > " +
                "<tr><th> SMTP Server      </th><td> " + textBox_OptMail_Server.Text + " </td></tr>" +
                "<tr><th> SMTP Server Port </th><td> " + maskedTextBox_OptMail_Port.Text + " </td></tr>" +
                "<tr><th> Enable SSL       </th><td> " + checkBox_OptMail_EnableSSL.Checked + " </td></tr>" +
                "<tr><th> User             </th><td> " + textBox_OptMail_User.Text + " </td></tr>" +
                "<tr><th> Password         </th><td> " + new string('●', textBox_OptMail_Password.TextLength) + "</td></tr>" +
                "<tr><th> Email Sender     </th><td> " + textBox_OptMail_MailSender.Text + " </td></tr>" +
                "<tr><th> Email Receiver   </th><td> " + textBox_OptMail_MailReceiver.Text + " </td></tr>" +
                "<tr><th> Executed on Host </th><td> " + Environment.MachineName + " </td></tr>" +
                "<tr><th> Time sent        </th><td> " + DateTime.Now.ToString("yyyy'/'MM'/'dd HH:mm:ss") + " </td></tr>" +
                "</table>" +
                "</td></tr>" +
                "<tr><td> " +
                Resources.MailFooter
            };
            try
            {
                using (var client = new SmtpClient())
                {
                    if (checkBox_OptMail_EnableSSL.Checked)
                        client.Connect(textBox_OptMail_Server.Text, int.Parse(maskedTextBox_OptMail_Port.Text), true);
                    else
                        client.Connect(textBox_OptMail_Server.Text, int.Parse(maskedTextBox_OptMail_Port.Text), SecureSocketOptions.None);
                    if (!string.IsNullOrEmpty(textBox_OptMail_Password.Text))
                    {
                        client.Authenticate(textBox_OptMail_User.Text, textBox_OptMail_Password.Text);
                    }
                    client.Send(message);
                    client.Disconnect(true);
                } ;
                
                SetMessage("", "Options", "Test Email sent to \"" + textBox_OptMail_MailReceiver.Text + "\".");
            }
            catch (Exception ex)
            {
                SetMessage("", "Options", "Test Email: " + ex.Message, true);
            }
        }
        private void TextBox_Favorites_NewDesc_Enter(object sender, EventArgs e)
        {
            if (button_Favorites_Add.Text == "Add")
            {
                textBox_Favorites_NewFile.Text = Path.GetFileNameWithoutExtension(textBox_SqlFile.Text);
                textBox_Favorites_NewUser.Text = dbUser;
                StringBuilder builder = new StringBuilder();
                foreach (ListViewItem listItem in listView_DBs.CheckedItems)
                {
                    builder.Append(listItem.SubItems[0].Text + " ");
                }
                textBox_Favorites_NewDBs.Text = builder.ToString(); ;
            }
        }

        private void Button_Favorites_Add(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (string.IsNullOrEmpty(textBox_Favorites_NewDesc.Text))
                {
                    SetMessage("", "Favorites", "Please enter a Description", true);
                    return;
                }
                int optFormat = 0;
                if (checkBoxOptHTML.Checked)
                    optFormat = 1;
                if (checkBoxOptCSV.Checked)
                    optFormat = 2;
                string dbList;
                StringBuilder builder = new StringBuilder();
                foreach (ListViewItem listItem in listView_DBs.CheckedItems)
                {
                    builder.Append(listItem.SubItems[0].Text + " ");
                }
                dbList = builder.ToString();
                if (button_Favorites_Add.Text == "Add")                                             // Add new Favorite
                {
                    int i;
                    listFavorites.Add(new Favorite(
                        sqlFile,
                        (checkBoxLog.Checked),
                        (checkBoxLogAppend.Checked),
                        logFile,
                        dbUser,
                        (checkBoxOptSilent.Checked),
                        optFormat,
                        String.Format("{0}:{1}:{2}", timeoutHH.Value, timeoutMM.Value, timeoutSS.Value),
                        (checkBoxOptIgnoreError.Checked),
                        dbList,
                        textBox_Favorites_NewDesc.Text)
                    );
                    i = listFavorites.Count() - 1;
                    ListViewItem item2 = new ListViewItem(new string[]
                        {
                        textBox_Favorites_NewDesc.Text,
                        Path.GetFileNameWithoutExtension( sqlFile),
                        dbUser,
                        dbList
                        }
                        )
                    { Tag = i };
                    listViewFavorites.Items.Add(item2);
                    SetMessage("", "Favorites", "added \"" + textBox_Favorites_NewDesc.Text + "\".");
                }
                else                                                                                // Update Favorite (after ContextMenuStrup FavoritesUpdate/FavoritesLoad)
                {
                    foreach (ListViewItem lVFavorite in listViewFavorites.SelectedItems)
                    {
                        lVFavorite.SubItems[0].Text = textBox_Favorites_NewDesc.Text;
                        lVFavorite.SubItems[1].Text = Path.GetFileNameWithoutExtension(textBox_SqlFile.Text);
                        lVFavorite.SubItems[2].Text = dbUser;
                        lVFavorite.SubItems[3].Text = dbList;
                        Favorite favorite = listFavorites[Convert.ToInt16(lVFavorite.Tag)];
                        favorite.File = sqlFile;
                        favorite.Log2File = (checkBoxLog.Checked);
                        favorite.LogAppend = (checkBoxLogAppend.Checked);
                        favorite.LogFile = logFile;
                        favorite.DBUser = dbUser;
                        favorite.OptSilent = (checkBoxOptSilent.Checked);
                        favorite.OptFormat = optFormat;
                        favorite.Timeout = String.Format("{0}:{1}:{2}", timeoutHH.Value, timeoutMM.Value, timeoutSS.Value);
                        favorite.IgnoreError = (checkBoxOptIgnoreError.Checked);
                        favorite.DBList = dbList;
                        favorite.Text = textBox_Favorites_NewDesc.Text;
                        SetMessage("", "Favorites", "updated \"" + favorite.Text + "\".");
                        button_Favorites_Add.Text = "Add";
                        textBox_Favorites_NewDesc.Text = string.Empty;
                        textBox_Favorites_NewFile.Text = string.Empty;
                        textBox_Favorites_NewUser.Text = string.Empty;
                        textBox_Favorites_NewDBs.Text = string.Empty;
                    }
                }
            }
        }

        private void FavoritesMoveUp_Click(object sender, EventArgs e)
        {
            MoveItems_Favorites(MoveDirection.Up);
        }

        private void FavoritesMoveDown_Click(object sender, EventArgs e)
        {
            MoveItems_Favorites(MoveDirection.Down);
        }

        private void LinkCheck4Update_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkCheck4Update.LinkVisited = true;
            Process.Start(check4UpdateInfo);
        }
        private void ListViewFavoritesKeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Delete == e.KeyCode)
            {
                foreach (ListViewItem item in listViewFavorites.SelectedItems)
                {
                    listViewFavorites.Items.Remove(item);   
                    SetMessage("", "Favorites", "deleted \"" + item.SubItems[0].Text + "\".");
                }
            }
        }
        private void TabControl1SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1) ShowFavorites();
            if (tabControl1.SelectedIndex == 3) ShowSessionHistory();
        }
        private void ShowSessionHistory()
        {
            try
            {
                textBoxSessionHistory.Text = File.ReadAllText(SessionHistory.traceFile);
                textBoxSessionHistory.SelectionStart = textBoxSessionHistory.TextLength;
                textBoxSessionHistory.ScrollToCaret();
            }
            catch (Exception ex)
            {
                textBoxSessionHistory.Text = "Error reading Trace file: " + ex.Message;
            }
        }
        private void ReadSettings()
        {
            int i;
            tableDBGroups.Columns.Add("Name", typeof(string));                                      // DB Groups
            tableDBGroups.Columns.Add("Regular Expression", typeof(string));                        //   define tableDBGroups Columns
            tableDBGroups.Columns.Add("Color", typeof(string));
            BindingSource bindingSourceDBGroups = new BindingSource                                 //   define BindingSource
            {
                DataSource = tableDBGroups                                                          //   set DataSource of BindingSource to table
            };                              
            dataGridView_DBGroups.DataSource = bindingSourceDBGroups;                               //   set dataGridView DataSource in Options>DBs
            foreach (DataGridViewColumn column in dataGridView_DBGroups.Columns)                    //   disable Column Sort-Mode
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            listView_DBGroups.Items.Clear();
            tableDBUser.Columns.Add("User", typeof(string));                                        // DB Users
            tableDBUser.Columns.Add("Schema", typeof(string));                                      //   define tableDBGroups Columns
            tableDBUser.Columns.Add("Password", typeof(string));
            tableDBUser.Columns.Add("SYSDBA", typeof(bool));
            BindingSource bindingSourceDBUser = new BindingSource                                   //   define BindingSource
            {
                DataSource = tableDBUser                                                            //   set DataSource of BindingSource to table
            };                                
            dataGridView_DBUsers.DataSource = bindingSourceDBUser;                                  //   set dataGridView DataSource in Options>DBs
            foreach (DataGridViewColumn column in dataGridView_DBUsers.Columns)                     //   disable Column Sort-Mode
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            listBox_User.Items.Clear();
            try
            {
                XDocument doc = XDocument.Load(settingsFile);
                sqlPlusPath = doc.Root.Element("Environment").Element("SqlPlusPath")?.Value;        // =Start=> Environment
                nlsLang = doc.Root.Element("Environment").Element("NLS_LANG")?.Value;
                tnsAdmin = doc.Root.Element("Environment").Element("TNS_ADMIN")?.Value;
                sqlPath = doc.Root.Element("Environment").Element("SQLPATH")?.Value;
                passwordEncrypt = (doc.Root.Element("Environment").Element("PasswordEncrypt")?.Value == "True");
                if (!string.IsNullOrEmpty(nlsLang))
                {
                    Environment.SetEnvironmentVariable("NLS_LANG", nlsLang);
                    textBox_OptEnv_NLS_LANG.Text = nlsLang;
                }
                else
                    Environment.SetEnvironmentVariable("NLS_LANG", null);
                if (!string.IsNullOrEmpty(tnsAdmin))
                {
                    Environment.SetEnvironmentVariable("TNS_ADMIN", tnsAdmin);
                    textBox_OptEnv_TNS_ADMIN.Text = tnsAdmin;
                }
                if (!string.IsNullOrEmpty(sqlPath))
                {
                    Environment.SetEnvironmentVariable("SQLPATH", sqlPath);
                    textBox_OptEnv_SQLPATH.Text = sqlPath;
                }
                if (string.IsNullOrEmpty(sqlPlusPath))
                {
                    sqlPlusPath = Utils.FindExePath("sqlplus.exe");
                    if (string.IsNullOrEmpty(sqlPlusPath))
                        SetMessage("", "Environment", "SQL*Plus not found. Please configure your settings in Options.",true);
                }
                else
                    textBox_OptEnv_SqlPlusPath.Text = sqlPlusPath;
                if (passwordEncrypt)
                    hidePasswords.Checked = true;
                else hidePasswords.Checked = false;                                                 // <==End== Environment
                                                                                                    // =Start=> DBGroups
                textBox_OptDBGroup_ExcludeDBs.Text = doc.Root.Element("DBGroups").Element("ExcludeDBs")?.Value;
                i = 0;
                foreach (var dm in doc.Descendants("DBGroup"))                                      // .. =Start=> DBGroup                    
                {
                    tableDBGroups.Rows.Add(dm.Element("Name").Value, dm.Element("RegExp").Value,
                        dm.Element("Color").Value);
                    listView_DBGroups.Items.Add(dm.Element("Name").Value);
                    listView_DBGroups.Items[i].ForeColor = ColorTranslator.FromHtml(dm.Element("Color").Value);
                    i++;
                }                                                                                   // .. <==End== DBGroup
                foreach (var dm in doc.Descendants("User"))                                         // =Start=> User
                {
                    dbUserPassword = dm.Element("Password").Value;
                    tableDBUser.Rows.Add(dm.Element("Name").Value, dm.Element("Schema").Value,
                        Utils.Decrypt(dm.Element("Password").Value, passwordEncrypt),
                        bool.Parse(dm.Element("SYSDBA").Value));
                    listBox_User.Items.Add(dm.Element("Name").Value);
                }
                if (tableDBUser.Rows.Count > 0)
                    listBox_User.SelectedIndex = 0; 
                else
                {
                    SetMessage("", "Startup", "No DB User found. Please configure your settings in Options.", true);
                }
                //                                                                                  // <==End== User
                //                                                                                  // =Start=> TaskScheduler
                textBox_OptTask_Username.Text = doc.Root.Element("TaskScheduler").Element("Name")?.Value;
                textBox_OptTask_Password.Text = Utils.Decrypt(doc.Root.Element("TaskScheduler").Element("Password")?.Value, passwordEncrypt);
                //                                                                                  // =End=> TaskScheduler
                //                                                                                  // =Start=> Mail
                textBox_OptMail_Server.Text = doc.Root.Element("Mail").Element("SmtpServerAddress")?.Value;
                maskedTextBox_OptMail_Port.Text = doc.Root.Element("Mail").Element("SmtpServerPortNumber")?.Value;
                checkBox_OptMail_EnableSSL.Checked = (doc.Root.Element("Mail").Element("EnableSsl")?.Value == "True");
                textBox_OptMail_User.Text = doc.Root.Element("Mail").Element("SmtpUserName")?.Value;
                textBox_OptMail_Password.Text = Utils.Decrypt(doc.Root.Element("Mail").Element("SmtpUserPassword")?.Value, passwordEncrypt);
                textBox_OptMail_MailSender.Text = doc.Root.Element("Mail").Element("Sender")?.Value;
                textBox_OptMail_MailReceiver.Text = doc.Root.Element("Mail").Element("Receiver")?.Value;
                //                                                                                  // =End=> Mail
                i = 0;
                foreach (var dm in doc.Descendants("Favorite"))                                     // =Start=> Favorite
                {
                    var item = new Favorite(
                        dm.Element("File").Value,
                        Convert.ToBoolean(dm.Element("Log2File").Value),
                        Convert.ToBoolean(dm.Element("LogAppend").Value),
                        dm.Element("LogFile").Value,
                        dm.Element("DBUser").Value,
                        Convert.ToBoolean(dm.Element("OptSilent").Value),
                        Convert.ToInt16(dm.Element("OptFormat").Value),
                        dm.Element("Timeout").Value,
                        Convert.ToBoolean(dm.Element("IgnoreError").Value),
                        dm.Element("DBList").Value,
                        dm.Element("Text").Value);
                    listFavorites.Add(item);
                    // listViewFavorites is a sub-select of favorites. Tag references favorites index -> favorites[Convert.ToInt16(listFavorites.Tag)]
                    ListViewItem item2 = new ListViewItem(new string[]
                    {
                        dm.Element("Text").Value,
                        Path.GetFileNameWithoutExtension( dm.Element("File").Value),
                        dm.Element("DBUser").Value,
                        dm.Element("DBList").Value
                    })
                    {
                        Tag = i             // Tag in listViewFavorites is index to favorites
                    };
                    listViewFavorites.Items.Add(item2);
                    i++;
                }
                
            }
            catch (Exception)
            {
                if (string.IsNullOrEmpty(nlsLang))                                                  // no config, nlsLang empty:
                {                                                                                   // set "Default" .UTF8
                    nlsLang = ".UTF8";                                                              // assume SQL-Files use .UTF8
                    Environment.SetEnvironmentVariable("NLS_LANG", nlsLang);
                    textBox_OptEnv_NLS_LANG.Text = nlsLang;
                }
                else
                    Environment.SetEnvironmentVariable("NLS_LANG", null);
                sqlPlusPath = Utils.FindExePath("sqlplus.exe");
                if (string.IsNullOrEmpty(sqlPlusPath))
                    SetMessage("", "Startup", "SQL*Plus not found. Please configure your settings in Options.", true);
            }
            
        }
        private void WriteSettings()
        {
            using (XmlWriter writer = XmlWriter.Create(settingsFile))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Settings");                                           // Start Settings
                writer.WriteStartElement("Environment");                                        // Start Environment
                writer.WriteElementString("SqlPlusPath", textBox_OptEnv_SqlPlusPath.Text);
                writer.WriteElementString("NLS_LANG", textBox_OptEnv_NLS_LANG.Text);
                writer.WriteElementString("TNS_ADMIN", textBox_OptEnv_TNS_ADMIN.Text);
                writer.WriteElementString("SQLPATH", textBox_OptEnv_SQLPATH.Text);
                writer.WriteElementString("PasswordEncrypt", (passwordEncrypt) ? "True" : "False");
                writer.WriteEndElement();                                                       // End Environment
                writer.WriteStartElement("DBGroups");                                           // Start DBGroups
                writer.WriteElementString("ExcludeDBs", textBox_OptDBGroup_ExcludeDBs.Text);
                foreach (DataRow row in tableDBGroups.Rows)
                {
                    writer.WriteStartElement("DBGroup");                                        // .. Start DBGroup
                    writer.WriteElementString("Name", row[0].ToString());
                    writer.WriteElementString("RegExp", row[1].ToString());
                    writer.WriteElementString("Color", row[2].ToString());
                    writer.WriteEndElement();                                                   // .. End DBGroup
                }
                writer.WriteEndElement();                                                       // End DBGroups
                writer.WriteStartElement("Users");                                              // Start Users
                foreach (DataRow row in tableDBUser.Rows)
                {
                    writer.WriteStartElement("User");                                           // .. Start User
                    writer.WriteElementString("Name", row[0].ToString());
                    writer.WriteElementString("Schema", row[1].ToString());
                    writer.WriteElementString("Password", Utils.Encrypt(row[2].ToString(), passwordEncrypt));
                    writer.WriteElementString("SYSDBA", (row[3].ToString() == "True") ? "True" : "False");
                    writer.WriteEndElement();                                                   // .. End User
                }
                writer.WriteEndElement();                                                       // End Users
                writer.WriteStartElement("TaskScheduler");                                      // Start TaskScheduler
                writer.WriteElementString("Name", textBox_OptTask_Username.Text);
                writer.WriteElementString("Password", Utils.Encrypt(textBox_OptTask_Password.Text, passwordEncrypt));
                writer.WriteEndElement();                                                       // End TaskScheduler
                writer.WriteStartElement("Mail");                                               // Start Mail
                writer.WriteElementString("SmtpServerAddress", textBox_OptMail_Server.Text);
                writer.WriteElementString("SmtpServerPortNumber", maskedTextBox_OptMail_Port.Text);
                writer.WriteElementString("EnableSsl", (checkBox_OptMail_EnableSSL.Checked) ? "True" : "False");
                writer.WriteElementString("SmtpUserName", textBox_OptMail_User.Text);
                writer.WriteElementString("SmtpUserPassword", Utils.Encrypt(textBox_OptMail_Password.Text, passwordEncrypt));
                writer.WriteElementString("Sender", textBox_OptMail_MailSender.Text);
                writer.WriteElementString("Receiver", textBox_OptMail_MailReceiver.Text);
                writer.WriteEndElement();                                                       // End Mail
                writer.WriteStartElement("Favorites");                                          // Start Favorites
                foreach (ListViewItem lVFavorite in listViewFavorites.Items)
                {
                    Favorite favorite = listFavorites[Convert.ToInt16(lVFavorite.Tag)];
                    writer.WriteStartElement("Favorite");
                    writer.WriteElementString("Text", favorite.Text);
                    writer.WriteElementString("File", favorite.File);
                    writer.WriteElementString("Log2File", favorite.Log2File.ToString());
                    writer.WriteElementString("LogAppend", favorite.LogAppend.ToString());
                    writer.WriteElementString("LogFile", favorite.LogFile);
                    writer.WriteElementString("DBUser", favorite.DBUser);
                    writer.WriteElementString("OptSilent", favorite.OptSilent.ToString());
                    writer.WriteElementString("OptFormat", favorite.OptFormat.ToString());
                    writer.WriteElementString("Timeout", favorite.Timeout);
                    writer.WriteElementString("IgnoreError", favorite.IgnoreError.ToString());
                    writer.WriteElementString("DBList", favorite.DBList);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();                                                       // End Favorites
                writer.WriteEndElement();                                                       // End Settings
                writer.WriteEndDocument();
                writer.Close();
            }
        }
        
        
        private async void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            while (pendingMessages.Count > 0)
            {
                toolStripStatusLabel.Text = pendingMessages.Dequeue();
                await Task.Delay(5000);                                                             // Show Message 5 seconds
            }

            toolStripStatusLabel.Text = "";
            timer1.Start();
        }


        private void TextBox_SqlFile_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(textBox_SqlFile.Text))
            {
                sqlFile = Pathing.GetUNCPath(textBox_SqlFile.Text);
                SetLogfileSuffix();
            }
        }

        private void ShowFavorites()
        {
            listViewFavorites.Select();
        }

        private void CheckBox_OptEnv_Mode_CheckedChanged(object sender, EventArgs e)
        {
            Color colorText1;
            if (checkBox_OptEnv_Mode.Checked)
            {
                colorBack1 = Color.FromArgb(44, 44, 44);
                colorText1 = SystemColors.ButtonShadow;
                textColorStatusLabel1 = Color.DarkOrange;
                textColorStatusLabel2 = Color.Gold;
            }
                
            else
            {
                colorBack1 = SystemColors.Control;
                colorText1 = SystemColors.ControlText;
                textColorStatusLabel1 = Color.Red;
                textColorStatusLabel2 = Color.Green;
            }
                
            this.BackColor = colorBack1;
            toolStripStatusLabel.BackColor = colorBack1;
            toolStripStatusLabel.ForeColor = colorText1;
            foreach (ListViewItem listItem in listView_DBs.Items)
                listItem.BackColor = colorBack1;

            Utils.SetColorMode(this, checkBox_OptEnv_Mode.Checked);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Upgrade?
            string configPath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
            if (!File.Exists(configPath))
            {
                //Existing user config does not exist, so load settings from previous assembly
                Settings.Default.Upgrade();
                Settings.Default.Reload();
                Settings.Default.Save();
            }
            if (Settings.Default.F1Size.Width == 0 || Settings.Default.F1Size.Height == 0)
            {
                // first start
                // optional: add default values
            }
            else
            {
                this.WindowState = Settings.Default.F1State;

                // we don't want a minimized window at startup
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;

                this.Location = Settings.Default.F1Location;
                this.Size = Settings.Default.F1Size;
            }
            checkBox_OptEnv_Mode.Checked = (Settings.Default.F1DarkMode);
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            WriteSettings();
            File.Delete(processIDFile);
            Settings.Default.F1State = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.Default.F1Location = this.Location;                             // save location and size if the state is normal
                Settings.Default.F1Size = this.Size;
            }
            else
            {
                Settings.Default.F1Location = this.RestoreBounds.Location;               // save the RestoreBounds if the form is minimized or maximized!
                Settings.Default.F1Size = this.RestoreBounds.Size;
            }
            Settings.Default.F1DarkMode = checkBox_OptEnv_Mode.Checked;
            Settings.Default.Save();
        }
        private void TextBox_OptEnv_TNS_ADMIN_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Directory.Exists(textBox_OptEnv_TNS_ADMIN.Text))
            {
                tnsAdmin = textBox_OptEnv_TNS_ADMIN.Text;
                if (File.Exists(textBox_OptEnv_TNS_ADMIN.Text + "\\tnsnames.ora"))
                {
                    tnsNames = textBox_OptEnv_TNS_ADMIN.Text + "\\tnsnames.ora";
                    if (!inInit)
                    {
                        Environment.SetEnvironmentVariable("TNS_ADMIN", tnsAdmin);
                        namesDefaultDomain = GetSqlnetOra(textBox_OptEnv_TNS_ADMIN.Text);
                        BuildDBList();
                    }
                }
                else
                    SetMessage("", "Options", "TNS_ADMIN: File tnsnames.ora in Directory " + textBox_OptEnv_TNS_ADMIN.Text + " not found.", true);
            }
            else
                if (String.IsNullOrEmpty(textBox_OptEnv_TNS_ADMIN.Text))
            {
                Environment.SetEnvironmentVariable("TNS_ADMIN", null);
                tnsNames = GetTNSFile();                                                            // try to get tnsnames.ora from default PATH
                if ((File.Exists(tnsNames)) && (!inInit))
                {
                    Environment.SetEnvironmentVariable("TNS_ADMIN", tnsAdmin);
                    namesDefaultDomain = GetSqlnetOra(Path.GetDirectoryName(tnsNames));
                    BuildDBList();
                }
                else
                {
                    SetMessage("", "Options", "TNS_ADMIN: unable to detect a default TNS_ADMIN directory - Please define in Options > Environment", true);
                }
            }
        }

        private void TextBox_OptEnv_SqlPlusPath_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!inInit)
            {
                if (File.Exists(textBox_OptEnv_SqlPlusPath.Text))
                {
                    SqlPlusVersion(textBox_OptEnv_SqlPlusPath.Text);
                    sqlPlusPath = textBox_OptEnv_SqlPlusPath.Text;
                }
            }
            else
                SetMessage("", "Options", "SQL*Plus Path: File sqlplus.exe not found.", true);
        }

        private void TextBox_OptEnv_NLS_LANG_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!inInit)
            {
                nlsLang = textBox_OptEnv_NLS_LANG.Text;
                Environment.SetEnvironmentVariable("NLS_LANG", nlsLang);
            }
        }

        private void TextBox_OptEnv_SQLPATH_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!inInit)
            {
                sqlPath = textBox_OptEnv_SQLPATH.Text ;
                Environment.SetEnvironmentVariable("SQLPATH", sqlPath);
            }
        }

        private void TabControlOptions_DrawItem(object sender, DrawItemEventArgs e)
        {                                                                   // TabControl Tabs on the left side - DrawItemEvent is required to print the TabPage Item Text
            Graphics g = e.Graphics;
            Brush _textBrush = new SolidBrush(Color.Black);
            if (e.Index == 0)
            {
                Rectangle _clientRectangle = tabControloptions.ClientRectangle;
                _clientRectangle.Width = 100;                               // reduce width to paint only the left side of the tabControloptions, avoid drawing over the tab pages
                _clientRectangle.Height = _clientRectangle.Height - 110;    // reduce height to avoid drawing over existing the tab pages, 6 Items in Options, 6*20=120 plus 2 for the border
                _clientRectangle.Y = _clientRectangle.Y + 110;              // top position of the rectangle to paint, after 6 Items in Options, 6*18=108 plus 2 for the border
                _clientRectangle.X = _clientRectangle.X + 2;                // left position of the rectangle to paint, avoid drawing over the border
                Brush myBrush = new SolidBrush(colorBack1);                 // colorBack1 is set in CheckBox_OptEnv_Mode_CheckedChanged
                g.FillRectangle(myBrush, _clientRectangle);                 // fill the rectangle with the background color
            }

            Rectangle _tabBounds = tabControloptions.GetTabRect(e.Index);   // Get the real bounds for the tab rectangle.
            Brush _clientItemBG = new SolidBrush(Color.FromArgb(243, 243, 243));

            if (e.State == DrawItemState.Selected)                          // Selected TabPage Item, paint with different background color
            {
                _clientItemBG = new SolidBrush(Color.FromArgb(249, 249, 249));
                g.FillRectangle(_clientItemBG, e.Bounds);
            }
            else
            {
                g.FillRectangle(_clientItemBG, e.Bounds);
            }

            TabPage _tabPage = tabControloptions.TabPages[e.Index];         // Get the item from the collection.
            StringFormat _stringFlags = new StringFormat();                 // Draw string. Center the text.
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, e.Font, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }
    }
}