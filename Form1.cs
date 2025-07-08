// Form1.cs
//
// Copyright 2025 Martin Bruegger

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Configuration;
using System.Threading;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Drawing;
using System.Text;

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

        private readonly List<Favorite> favorites = new List<Favorite>();
        private string sqlPlusPath = string.Empty;
        private string sqlFile = string.Empty;
        private string logFile = string.Empty;
        public const string favoritesFile = "Favorites.xml";
        private readonly string logFileTemporary;
        private readonly string processIDFile;                      // temporary file containing Proc.ID of SQLcl - option to "Abort SQL"
        private string namesDefaultDomain = string.Empty;           // Default_Domain from sqlnet.ora - suppress this part in the db-list
        private string dbUser;
        private string dbUserPassword;
        private string dbaFlag;
        private string mailSender;
        private string mailReceiver;
        private string sqlPlusVersion;
        private string tnsNames;
        private string taskUserId, taskPassword;
        private string group1Regexp, group2Regexp, group3Regexp;
        private string group1Name, group2Name, group3Name;
        private string group1Color, group2Color, group3Color;
        private string excludeDbs;
        private string sqlResult;
        private int selectedDbCount;
        private readonly List<string> dbUserList = new List<string>();
        private readonly List<string> connectStringList = new List<string>();
        private readonly List<string> dbaFlagList = new List<string>();
        private readonly List<string> dbList = new List<string>();
        private BindingSource BS ;                                  // Options (Form3) may change DBUSERs Listbox
        private readonly ListViewColumnSorter lvwColumnSorter;
        private int timeout;
        private bool ignoreError ;
        private bool pingWithSqlPlus = false;                      // When sqlPlusVersion >= 23, then use "sqlplus -P" instead of tnsping.exe
        public Form1(string[] file)
        {
            InitializeComponent();
            
            // Create an instance of a ListView column sorter and assign it to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            listViewFavorites.ListViewItemSorter = lvwColumnSorter;
            ReadFavorites();            // Read Favorites, load into listViewFavorites; file: Favorites.xml
            textBoxAbout.LoadFile("SQLAgain_About.rtf");
            Process currentProcess = Process.GetCurrentProcess();
            processIDFile = Path.GetTempPath() + "sqlagain.ProcID_" + currentProcess.Id + ".tmp";
            SessionHistory.Reorg();
            //=== FILE passed as parameter (drag/drop file on SQLAgain Icon)
            if (file.Length != 0) { textBoxSqlFile.Text = Pathing.GetUNCPath(file[0]); }
            logFileTemporary = Path.GetTempPath() + "sqlagain.txt";
            AllowDrop = true;
            DragEnter += new DragEventHandler(Form1_DragEnter);
            DragDrop += new DragEventHandler(Form1_DragDrop);
            checkBoxOptSilent.Checked = false;
            checkBoxLogAppend.Checked = true;
            checkBoxOptIgnoreError.Checked = false;
            buttonViewLog.Enabled = false;
            InitEnv();              // may be called more than once - at Startup and when Options are changed/saved
        }
        private void InitEnv()
        {
            GetConfig();                // Read Options; file: SQLAgain.exe.Config
            sqlPlusVersion = SqlPlusVersion(sqlPlusPath);
            if (sqlPlusVersion != "-1")
            {
                if (!pingWithSqlPlus)   // if tnsping.exe is required: check tnsping.exe in same dir as sqlplus.exe (instant client without tnsping.exe)
                {
                    if (! File.Exists(Regex.Replace(sqlPlusPath, @"\bsqlplus.exe\b", "tnsping.exe")))
                    {
                        buttonTNSPing.Visible = false;
                    }
                }
                StatusMessages("", "Environment", string.Format("Detected SQL*Plus Version: {0}", sqlPlusVersion));
                tnsNames = GetTNSFile();
                if (!System.IO.File.Exists(tnsNames))
                {
                    StatusMessages("", "Environment", "Error: File tnsNames.ora not found. Please consult Tab  --> About SQLAgain.");
                }
                else
                {
                    namesDefaultDomain = GetSqlnetOra(Path.GetDirectoryName(tnsNames));
                    BuildDBList(namesDefaultDomain);
                }
            }
            else
            {
                StatusMessages("", "Environment", "SQL*Plus Version Detection failed. Please consult About SQLAgain.");
            }
                
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files) textBoxSqlFile.Text = Pathing.GetUNCPath(file);
        }
        private void GetConfig()
        {
            try
            {
                var appSettingsTest = ConfigurationManager.AppSettings;
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Error reading app settings.");
                Thread.Sleep(5000);                                 // wait 5 seconds - hope the user gets the message above ?
                Application.Exit();
            }
            string nlsLang;
            string tnsAdmin ;
            string sqlPath ;
            string dbUser;
            string connectString;
            string dbaFlag;
            bool isHidePasswordsActive = false;
            var appSettings = ConfigurationManager.AppSettings;
            dbUserList.Clear();
            connectStringList.Clear();
            dbaFlagList.Clear();
            if (appSettings["HidePasswords"] == "true") isHidePasswordsActive = true;
            if (string.IsNullOrEmpty(appSettings["DBS_EXCLUDE"]))
            { excludeDbs = "^$"; }     // DBS_EXCLUDE not set: exclude empty lines
            else { excludeDbs = appSettings["DBS_EXCLUDE"]; }
            if (string.IsNullOrEmpty(appSettings["DBG1_REGEXP"]))
            {
                group1Regexp = "^$";
                buttonSelectGroup1.Visible = false;
            } else
            {
                group1Regexp = appSettings["DBG1_REGEXP"];
                group1Name   = appSettings["DBG1_TEXT"];
                group1Color  = appSettings["DBG1_COLOR"];
                buttonSelectGroup1.Visible = true;
            }
            if (string.IsNullOrEmpty(appSettings["DBG2_REGEXP"]))
            {
                group2Regexp = "^$";
                buttonSelectGroup2.Visible = false;
            }
            else
            {
                group2Regexp = appSettings["DBG2_REGEXP"];
                group2Name   = appSettings["DBG2_TEXT"];
                group2Color  = appSettings["DBG2_COLOR"];
                buttonSelectGroup2.Visible = true;
            }
            if (string.IsNullOrEmpty(appSettings["DBG3_REGEXP"]))
            {
                group3Regexp = "^$";
                buttonSelectGroup3.Visible = false;
            }
            else
            {
                group3Regexp = appSettings["DBG3_REGEXP"];
                group3Name   = appSettings["DBG3_TEXT"];
                group3Color  = appSettings["DBG3_COLOR"];
                buttonSelectGroup3.Visible = true;
            }
            mailSender   = appSettings["TASK_EMAIL1"];
            mailReceiver = appSettings["TASK_EMAIL2"];
            tnsAdmin     = appSettings["TNS_ADMIN"];
            if (tnsAdmin != null)
            {
                Environment.SetEnvironmentVariable("TNS_ADMIN", tnsAdmin);
            }
            sqlPlusPath = appSettings["SQLPLUS_PATH"];
            if (string.IsNullOrEmpty (sqlPlusPath))
            {
                sqlPlusPath = Utils.FindExePath("sqlplus.exe");
                if (string.IsNullOrEmpty(sqlPlusPath)) {
                    StatusMessages("", "Environment", "SQL*Plus not found. Either define the Directory in PATH or set SQL*Plus Path in Options.");
                }
            }
            nlsLang = appSettings["NLS_LANG"];
            if (nlsLang != null)
            {
                Environment.SetEnvironmentVariable("NLS_LANG", nlsLang);
            } else
            {
                Environment.SetEnvironmentVariable("NLS_LANG", null);
            }
                sqlPath = appSettings["SQLPATH"];
            if (sqlPath != null)
            {
                Environment.SetEnvironmentVariable("SQLPATH", sqlPath);
            }
            for (int i = 1; i < 11; i++)
            {
                dbUser = appSettings["DBUSER" + i.ToString()];
                if (dbUser == null)
                {
                    break;
                }
                connectString  = Utils.Decrypt(appSettings["DBCONN" + i.ToString()], isHidePasswordsActive);
                dbaFlag = appSettings["DBAFLAG" + i.ToString()];
                dbUserList.Add(dbUser);
                connectStringList.Add(connectString);
                dbaFlagList.Add(dbaFlag);
            }
            //editProgram  = appSettings["APPL_LOG"];
            taskUserId   = appSettings["TASK_USER"];
            taskPassword = Utils.Decrypt(appSettings["TASK_USER_PWD"], isHidePasswordsActive);
            BindingSource bindingSource = new BindingSource();
            BS = bindingSource;  // required when Options changed
            BS.DataSource = dbUserList;
            listBoxUser.DataSource = BS;
            listBoxUser.SelectedIndex = 0;
        }
        private void BuildDBList( string namesDefaultDomain)
        {
            labelDB.Text = "Oracle Databases (from file " + tnsNames + ")";            
            listView1.Clear();
            int countAll = 0;
            int group1Count = 0;
            int group2Count = 0;
            int group3Count = 0;

            try
            {Regex test_Regex = new Regex(group1Regexp, RegexOptions.IgnorePatternWhitespace);}
            catch (Exception ex)
            {
                MessageBox.Show("Options Regular Expression is in Error: "+ Environment.NewLine + ex.Message);
                group1Regexp = "";
            }
            try
            { Regex test_Regex = new Regex(group2Regexp, RegexOptions.IgnorePatternWhitespace); }
            catch (Exception ex)
            {
                MessageBox.Show("Options Regular Expression is in Error: " + Environment.NewLine + ex.Message);
                group2Regexp = "";
            }
            try
            { Regex test_Regex = new Regex(group3Regexp, RegexOptions.IgnorePatternWhitespace); }
            catch (Exception ex)
            {
                MessageBox.Show("Options Regular Expression is in Error: " + Environment.NewLine + ex.Message);
                group3Regexp = "";
            }
            try
            { Regex test_Regex = new Regex(excludeDbs, RegexOptions.IgnorePatternWhitespace); }
            catch (Exception ex)
            {
                MessageBox.Show("Options Regular Expression is in Error: " + Environment.NewLine + ex.Message);
                excludeDbs = "";
            }
            Regex group1Search = new Regex(group1Regexp, RegexOptions.IgnorePatternWhitespace);
            Regex group2Search = new Regex(group2Regexp, RegexOptions.IgnorePatternWhitespace);
            Regex group3Search = new Regex(group3Regexp, RegexOptions.IgnorePatternWhitespace);
            Regex excludeDbSearch = new Regex(excludeDbs, RegexOptions.IgnorePatternWhitespace); 
            listView1.Columns.Add("DB", 200);
            foreach (string DB in ListTNSAlias(tnsNames, namesDefaultDomain))
            {
                if (!excludeDbSearch.IsMatch(DB))
                {
                    countAll++;
                    ListViewItem item1 = new ListViewItem(DB);
                    item1.SubItems[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("ButtonFace");
                    if (group1Search.IsMatch(DB))
                    {
                        group1Count++;
                        item1.SubItems.Add(".");
                        item1.SubItems[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(group1Color);
                    }
                    else { item1.SubItems.Add(" "); }
                    if (group2Search.IsMatch(DB))
                    {
                        group2Count++;
                        item1.SubItems.Add(".");
                        item1.SubItems[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(group2Color);
                    }
                    else { item1.SubItems.Add(" "); }
                    if (group3Search.IsMatch(DB))
                    {
                        group3Count++;
                        item1.SubItems.Add(".");
                        item1.SubItems[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(group3Color);
                    }
                    else { item1.SubItems.Add(" "); }
                    item1.UseItemStyleForSubItems = false;
                    Color color = item1.SubItems[0].ForeColor;
                    item1.SubItems.Add(System.Drawing.ColorTranslator.ToHtml(color));
                    listView1.Items.Add(item1);
                }
            }            
            buttonSelectAll.Text = "Select All   (" + countAll + ")";
            buttonSelectGroup1.Text = group1Name + "   (" + group1Count + ")";
            buttonSelectGroup1.ForeColor = System.Drawing.ColorTranslator.FromHtml(group1Color);
            buttonSelectGroup2.Text = group2Name + "   (" + group2Count + ")";
            buttonSelectGroup2.ForeColor = System.Drawing.ColorTranslator.FromHtml(group2Color);
            buttonSelectGroup3.Text = group3Name + "   (" + group3Count + ")";
            buttonSelectGroup3.ForeColor = System.Drawing.ColorTranslator.FromHtml(group3Color);
        }
        public System.Diagnostics.Process p = new System.Diagnostics.Process();
        private void ListBoxUserChanged(object sender, EventArgs e)
        {
            if (listBoxUser.SelectedIndex > -1) // no items are selected
            {
                dbUserPassword = connectStringList[listBoxUser.SelectedIndex];
                dbaFlag = dbaFlagList[listBoxUser.SelectedIndex];
                dbUser = dbUserList[listBoxUser.SelectedIndex];
            }
        }
        private void ButtonTNSPing(object sender, EventArgs e)
        {
            if (listView1.CheckedItems.Count == 0)
            {
                MessageBox.Show("No Database selected. Please select at least one Database in the List.");
            }
            else
            {
                string db;
                foreach (ListViewItem listItem in listView1.CheckedItems)
                {
                    listItem.EnsureVisible();
                    listItem.BackColor = System.Drawing.ColorTranslator.FromHtml("#0078d7");
                    db = listItem.SubItems[0].Text;
                    if (pingWithSqlPlus)
                            StatusMessages(db, "sqlplus -P", TnsPing(db));
                    else    StatusMessages(db, "tnsping", TnsPing(db));
                    listItem.BackColor = System.Drawing.ColorTranslator.FromHtml("#414141");
                }
            }
        }
        private void StatusMessages(string db, string action, string result)
        {
            string[] array = new string[4] { DateTime.Now.ToString("yyyy'/'MM'/'dd HH:mm:ss"), db, action, result };
            var itm = new ListViewItem(array);
            listViewStatusMessages.Items.Add(itm);
            listViewStatusMessages.EnsureVisible(listViewStatusMessages.Items.Count - 1); /* Ensure last element visible */
            listViewStatusMessages.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewStatusMessages.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        
        private void SqlFileTextChanged(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip() ;
            t.SetToolTip(textBoxSqlFile, "Enter the Filename with your SQL Statements to execute.");
            if (File.Exists(textBoxSqlFile.Text))
            {
                textBoxSqlFile.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                sqlFile = Pathing.GetUNCPath(textBoxSqlFile.Text);
                string mimeType = ".log";
                if (checkBoxOptHTML.Checked) mimeType = ".html";
                if (checkBoxOptCSV.Checked) mimeType = ".csv";
                logFile = string.Format("{0}\\{1}{2}", Path.GetDirectoryName(sqlFile), Path.GetFileNameWithoutExtension(sqlFile), mimeType);
                textBoxLogFile.Text = logFile;
                EnableDisableViewLogfile();
                if (Utils.CheckPLSQLBlock(sqlFile) == false)
                {
                    textBoxSqlFile.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF3700");
                    t.SetToolTip(textBoxSqlFile, "Missing slash (/) after CREATE (FUNCTION|PACKAGE|PROCEDURE|TRIGGER) detected");
                    StatusMessages("", Path.GetFileName(sqlFile), "Missing slash (/) after CREATE (FUNCTION|PACKAGE|PROCEDURE|TRIGGER) detected");

                } 
            }
            else
            {                
                sqlFile = string.Empty;
                textBoxSqlFile.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF3700");
                t.SetToolTip(textBoxSqlFile, "File does not exist");
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
                textBoxSqlFile.Text = sqlFile;
            }
        }
        private void CheckBoxLogChanged(object sender, EventArgs e)
        {
            if (checkBoxLog.Checked == false) checkBoxLogAppend.Checked = false;
        }
        private void TextBoxLogfileTextChanged(object sender, EventArgs e)
        {
            if (sqlFile.Equals(textBoxSqlFile.Text))   // test only when sqlFile is valid
            {
                logFile = Pathing.GetUNCPath(textBoxLogFile.Text);
                if (checkBoxLog.Checked == true)  TestAccessLogFile(logFile);
                EnableDisableViewLogfile();
                textBoxLogFile.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");             }
        }
        private void TestAccessLogFile(string logFile)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(logFile, true);
            }
            catch (Exception ex)
            {
                textBoxLogFile.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF3700");
                textBoxLogFile.Select();
                MessageBox.Show("WRITE-Access to Log File failed: " + Environment.NewLine + ex.Message);
                //this.ActiveControl = textBoxLogFile;
            }
            finally
            {
                sw?.Close();
                if (System.IO.File.Exists(logFile))
                {
                    FileInfo file_info = new FileInfo(logFile);
                    if (file_info.Length < 1) File.Delete(logFile);     // delete only when file is empty (Length=0)
                }
            }
        }
        private void EnableDisableViewLogfile()
        {
            if (File.Exists(logFile))
            {
                DateTime last_modified = System.IO.File.GetLastWriteTime(logFile);
                toolTip1.SetToolTip(buttonViewLog, string.Format("View the logfile with SQLcl Output from " + last_modified.ToString("yyyy'/'MM'/'dd HH:mm:ss")));
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
                if (System.IO.File.Exists(logFile))
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
            if (ValidateInput() == true)
            {
                if (checkBoxLog.Checked == false)
                {
                    string mimeType = ".log";
                    if (checkBoxOptHTML.Checked) mimeType = ".html";
                    if (checkBoxOptCSV.Checked)  mimeType = ".csv";
                    logFile = logFileTemporary;
                    logFile = string.Format("{0}\\{1}{2}", Path.GetDirectoryName(logFile), Path.GetFileNameWithoutExtension(logFile), mimeType);
                }
                else
                {
                    logFile = textBoxLogFile.Text;
                }
                tabControl1.SelectedIndex = 0;  // switch always to Tab "Status Message"
                SessionHistory.Record("***** Foreground Session started.", 2);
                SessionHistory.Record("SQL-File              : file:\\\\" + sqlFile);
                SessionHistory.Record("Log File              : file:\\\\" + logFile);
                if (checkBoxLogAppend.Checked == false)
                {
                    if (System.IO.File.Exists(logFile))
                    {
                        try
                        {
                            File.Delete(logFile);
                        }
                        catch { }                        
                    }
                } else
                {
                    SessionHistory.Record("Append to Log File    : TRUE");
                }                    
                if (listView1.CheckedItems.Count > 1)
                {
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    progressBar1.Maximum = 100;
                    progressBar1.Step = 1;
                    progressBar1.Value = 0;
                }
                else
                {
                    progressBar1.Style = ProgressBarStyle.Marquee;
                }                
                buttonRunSQL.Visible = false;
                buttonScheduleSQL.Visible = false;
                buttonCancelSQL.Visible = true;
                progressBar1.Visible = true;
                foreach (ListViewItem listItem in listView1.CheckedItems)
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
            if (ValidateInput() == true)
            {
                form2Parms = form2Parms + " -L\"" + logFile + "\"";
                form2Parms += " -I\"";
                foreach (ListViewItem listItem in listView1.CheckedItems)
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
                Form2 f = new Form2(form2Parms, Path.GetFileName(sqlFile), taskUserId, taskPassword, mailSender, mailReceiver);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    tabControl1.SelectedIndex = 0;  // switch always to Tab "Status Message"
                    StatusMessages("", "Task scheduled", string.Format("Task \"{0}\" starts at {1}.", f.taskName.Text, f.startDate.Text));
                }
                f.Dispose();
            }
        }
        private void Button_CancelSQL_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();   
            // if SQLcl is active (maybe hanging because of a missing character ?)
            // we're going to kill the SQLcl process ID, wait for the exit and write a 
            // corresponding message into the SQLcl logfile
            if (backgroundWorker1.IsBusy)
            {
                try
                {
                    string sqlclProcID = File.ReadAllText(processIDFile);
                    Process p = Process.GetProcessById(Convert.ToInt32(sqlclProcID));
                    if (!string.IsNullOrEmpty(sqlclProcID))
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
            bool isFormValid = true;
            if (string.IsNullOrEmpty(sqlFile)) // when textBoxSqlFile.Text contains an invalid file or is empty
            {
                isFormValid = false;
                textBoxSqlFile.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF3700");
                textBoxSqlFile.Select();
                MessageBox.Show("SQL File does not exist.\n Please enter or select a SQL File to execute.");
            }  
            if (isFormValid == true)
            {
                if (checkBoxLog.Checked == true)
                {
                    if (string.IsNullOrEmpty(logFile))
                    {
                        isFormValid = false;
                        MessageBox.Show("Please enter a Logfile or de-select the Loging Option.");
                    }
                }
                else
                {
                    logFile = logFileTemporary;
                    DeleteTempFile(logFileTemporary);
                }
            }
            if (isFormValid == true)
            {
                if (listView1.CheckedItems.Count == 0)
                {
                    isFormValid = false;
                    MessageBox.Show("No Database selected.\nPlease select at least one Database in the List.");
                }
            }
            timeout = decimal.ToInt32(timeoutHH.Value) * 3600 + decimal.ToInt32(timeoutMM.Value) * 60 + decimal.ToInt32(timeoutSS.Value);
            return isFormValid;
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
                    if (int.Parse(match.Groups[1].Value) >= 23)        // SQL*Plus Version 23 introduced Option -P to ping DB
                    {
                        pingWithSqlPlus = true;
                    }
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
            //return string.Format("{ 0}", lastLine);
            return lastLine;
        }
        //public static void EditLog(string logfile, string editProgram)
        public static void EditLog(string logfile)
        {
            if (string.IsNullOrEmpty(logfile))
            {
                throw new ArgumentException($"'{nameof(logfile)}' cannot be null or empty.", nameof(logfile));
            }
            //if (string.IsNullOrEmpty(editProgram) == false)
            //{
            //    try { Process.Start(editProgram, AddQuotesIfRequired(logfile));  }
            //    catch (Exception EX)
            //    {
            //        MessageBox.Show(string.Format("Application APPL_LOG in config file is not able to edit the logfile. " + EX.Message));
            //    }
            //}
            //else
            //{
            //}
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
            if ( ! string.IsNullOrEmpty(logFile ))
            {
                if(checkBoxOptHTML.Checked) mimeType = ".html";
                if (checkBoxOptCSV.Checked) mimeType = ".csv";
                logFile = string.Format("{0}\\{1}{2}", Path.GetDirectoryName(logFile), Path.GetFileNameWithoutExtension(logFile), mimeType);
                textBoxLogFile.Text = logFile;
                EnableDisableViewLogfile();
            }
        }
        
        
        private void ButtonOptions(object sender, EventArgs e)
        {
            List<string> selectedDBs = new List<string>();                  // Save the selected DBs in List selectedDBs
            foreach (ListViewItem listItem in listView1.CheckedItems)
            {
                selectedDBs.Add(listItem.SubItems[0].Text);
            }
            Form3 F = new Form3();
            if (F.ShowDialog(this) == DialogResult.OK)
            {
                ConfigurationManager.RefreshSection("appSettings");
                InitEnv();
                foreach (var selectedDB in selectedDBs)                     // InitEnv reloads the DB List; restore using selectedDBs 
                {
                    foreach (ListViewItem listDB in listView1.Items)
                    {
                        if (listDB.SubItems[0].Text == selectedDB)
                        {
                            listDB.Checked = true;
                            break;
                        }                            
                    }
                }
            }
            F.Dispose();
        }
        
        private void ButtonSelectAll(object sender, EventArgs e)
        {
            if (buttonSelectAll.Font.Style == FontStyle.Bold)
                ResetSelectAll(false);
            else
                ResetSelectAll(true);
            buttonSelectAll.SwtichToBoldRegular();
        }
        private void ResetSelectAll( bool x)
        {
            if (buttonSelectGroup1.Font.Style == FontStyle.Bold)
                buttonSelectGroup1.SwtichToBoldRegular();
            if (buttonSelectGroup2.Font.Style == FontStyle.Bold)
                buttonSelectGroup2.SwtichToBoldRegular();
            if (buttonSelectGroup3.Font.Style == FontStyle.Bold)
                buttonSelectGroup3.SwtichToBoldRegular();
            foreach (ListViewItem listItem in listView1.Items)
                listItem.Checked = x;
        }
        private void ButtonSelectGroup1(object sender, EventArgs e)
        {
            if (buttonSelectGroup1.Font.Style == FontStyle.Regular)
                SelectGroup(1, true);
            else
                SelectGroup(1, false);
            buttonSelectGroup1.SwtichToBoldRegular();
        }
        private void ButtonSelectGroup2(object sender, EventArgs e)
        {
            if (buttonSelectGroup2.Font.Style == FontStyle.Regular)
                SelectGroup(2, true);
            else
                SelectGroup(2, false);
            buttonSelectGroup2.SwtichToBoldRegular();
        }
        private void ButtonSelectGroup3(object sender, EventArgs e)
        {
            if (buttonSelectGroup3.Font.Style == FontStyle.Regular)
                SelectGroup(3, true);
            else
                SelectGroup(3, false);
            buttonSelectGroup3.SwtichToBoldRegular();
        }
        private void SelectGroup(int x, bool y)
        {
            foreach (ListViewItem listItem in listView1.Items)
            {
                if (listItem.SubItems[x].Text == ".") listItem.Checked = y;
            }
        }
        private void Form1FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteFavorites();
            File.Delete(processIDFile);
        }
        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {            
            string connectString;
            string sqlclOptions = string.Empty;
            string oracleSIDList = string.Empty;
            int percentage;
            string sqlpathOldValue ;
            string sqlPath ;
            string sqlFilePath ;
            selectedDbCount = 0;
            // SQLPATH: add directory of SQLFILE in front of SQLPATH; reset after calling SQL*Plus
            sqlpathOldValue = Environment.GetEnvironmentVariable("SQLPATH");
            System.IO.FileInfo fileinfo = new System.IO.FileInfo(sqlFile);
            sqlFilePath = fileinfo.DirectoryName;
            if (sqlpathOldValue != string.Empty)
                sqlPath = string.Format("{0};{1}", sqlFilePath, sqlpathOldValue);
            else
                sqlPath = sqlFilePath;
            Environment.SetEnvironmentVariable("SQLPATH", sqlPath);
            if (checkBoxOptSilent.Checked == true)
            {
                sqlclOptions = "-S";
                SessionHistory.Record("SQL*Plus Option       : -S");
            }
            if (checkBoxOptHTML.Checked == true)
            {
                SessionHistory.Record("SQL*Plus Format Option: HTML");
                sqlclOptions = string.Format("{0} HTML", sqlclOptions);
            }
            if (checkBoxOptCSV.Checked == true)
            {
                SessionHistory.Record("SQL*Plus Format Option: CSV");
                sqlclOptions = string.Format("{0} CSV", sqlclOptions);
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
                if (dbaFlag == "1") { connectString = string.Format("{0}@{1} as sysdba", dbUserPassword, db); }
                else { connectString = string.Format("{0}@{1}", dbUserPassword, db); }
                SessionHistory.Record(db.PadRight(24) + Path.GetFileName(sqlFile).PadRight(50), 0,1);
                sqlResult = ExecSQL.DoSQL(sqlPlusPath, db, connectString, sqlFile, logFile, sqlclOptions, processIDFile, timeout, ignoreError);
            }
            Environment.SetEnvironmentVariable("SQLPATH", sqlpathOldValue);
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
            foreach (ListViewItem listItem in listView1.Items)
            {
                x++;
                if (listItem.Text == db)
                {
                    listItem.Focused = true;
                    listItem.BackColor = System.Drawing.ColorTranslator.FromHtml("Highlight");
                    listItem.ForeColor = System.Drawing.ColorTranslator.FromHtml("ButtonFace");
                    listItem.EnsureVisible();
                }
                else
                {
                    listItem.BackColor = System.Drawing.ColorTranslator.FromHtml("#414141");
                    listItem.ForeColor = System.Drawing.ColorTranslator.FromHtml(listItem.SubItems[4].Text);
                }
                    
            }
            progressBar1.Value = e.ProgressPercentage;
            StatusMessages(db, Path.GetFileName(sqlFile), "");
        }
        private void BackgroundWorker1__RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            EnableDisableViewLogfile();
            if (selectedDbCount > 0)
            {
                ListViewItem itm = listViewStatusMessages.Items[listViewStatusMessages.Items.Count - 1];
                itm.SubItems[3].Text = sqlResult;
            }
            foreach (ListViewItem listItem in listView1.Items)
            {                
                listItem.BackColor = System.Drawing.ColorTranslator.FromHtml("#414141");
                listItem.ForeColor = System.Drawing.ColorTranslator.FromHtml(listItem.SubItems[4].Text);
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
                    case 2:
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
                p = System.Diagnostics.Process.Start(e.LinkText);
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
                    p = System.Diagnostics.Process.Start(e.LinkText.Substring(6));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
           
            else
                try
                {
                    p = System.Diagnostics.Process.Start(e.LinkText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        private void ButtonAddFavorites(object sender, EventArgs e)
        {
            int i ;
            string text = Microsoft.VisualBasic.Interaction.InputBox("Add description for the actual selection (File, DBs, DB User, Format options)", "Add favorite", "", -1, -1);
            if (!string.IsNullOrEmpty(text))
            {
                int optFormat = 0;
                if (checkBoxOptHTML.Checked)
                    optFormat = 1;
                if (checkBoxOptCSV.Checked)
                    optFormat = 2;
                string dbList ;       
                StringBuilder builder = new StringBuilder();
                foreach (ListViewItem listItem in listView1.CheckedItems)
                {
                    builder.Append(listItem.SubItems[0].Text + " ");
                }
                dbList = builder.ToString();

                favorites.Add(new Favorite(
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
                    text)); 
                i = favorites.Count() - 1;
                ListViewItem item2 = new ListViewItem(new string[]
                    {
                    text,
                    Path.GetFileNameWithoutExtension( sqlFile),
                    dbUser,
                    dbList
                    })
                {
                    Tag = i
                };
                listViewFavorites.Items.Add(item2);
                listViewFavorites.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewFavorites.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                StatusMessages("", "Favorites", "added \"" + text + "\".");
            }
        }
        private void FavoritesLoad(object sender, EventArgs e)
        {
            foreach (ListViewItem listFavorites in listViewFavorites.SelectedItems)
            {               
                Favorite favorite = favorites[Convert.ToInt16(listFavorites.Tag)];
                textBoxSqlFile.Text = favorite.File;                
                checkBoxLog.Checked = (favorite.Log2File);
                checkBoxLogAppend.Checked = (favorite.LogAppend);
                textBoxLogFile.Text = favorite.LogFile;
                checkBoxOptSilent.Checked = (favorite.OptSilent);
                checkBoxOptHTML.Checked = (favorite.OptFormat == 1);
                checkBoxOptCSV.Checked = (favorite.OptFormat == 2);
                string[] words = favorite.Timeout.Split(':');
                timeoutHH.Value = Convert.ToInt16(words[0]);
                timeoutMM.Value = Convert.ToInt16(words[1]);
                timeoutSS.Value = Convert.ToInt16(words[2]);
                checkBoxOptIgnoreError.Checked = (favorite.IgnoreError);
                for (int i = 0; i < listBoxUser.Items.Count; i++)  // listBox_User: select favorite.DBUser
                {
                    if (listBoxUser.Items[i].ToString() == favorite.DBUser)
                    {
                        listBoxUser.SetSelected(i, true);
                        break;
                    }                        
                } 
                string[] dbs = favorite.DBList.Split(' ');           // ListView1 (DBs): select favorite.DBList
                foreach (ListViewItem listDB in listView1.Items)
                {
                    listDB.Checked = false;                         // uncheck all DBs
                    foreach (string db in dbs)
                    {
                        string[] db_name = db.Split('.');
                        if (listDB.SubItems[0].Text == db_name[0])
                            listDB.Checked = true;                  // check when in favorite.DBList 
                    }
                }
                StatusMessages("", "Favorites", "loaded \"" + favorite.Text + "\".");
            }     
        }
        private void FavoritesDelete(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFavorites.SelectedItems)
            {
                listViewFavorites.Items.Remove(item);
                StatusMessages("", "Favorites", "deleted \"" + item.SubItems[0].Text + "\".");
            }
        }

        private void FavoritesEditFile_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem listFavorites in listViewFavorites.SelectedItems)
            {
                Favorite favorite = favorites[Convert.ToInt16(listFavorites.Tag)];
                EditLog(favorite.File);
            }
        }
        private void FavoritesUpdate(object sender, EventArgs e)
        {
            int optFormat = 0;
            if (checkBoxOptHTML.Checked)
                optFormat = 1;
            if (checkBoxOptCSV.Checked)
                optFormat = 2;
            string dbList;
            StringBuilder builder = new StringBuilder();
            foreach (ListViewItem listItem in listView1.CheckedItems)
            {
                builder.Append(listItem.SubItems[0].Text + " ");
            }
            dbList = builder.ToString();
            foreach (ListViewItem listFavorites in listViewFavorites.SelectedItems)
            {
                string text = Microsoft.VisualBasic.Interaction.InputBox("Modify description of selected item", "Edit favorite", listFavorites.SubItems[0].Text, -1, -1);
                if (!string.IsNullOrEmpty(text))
                {
                    listFavorites.SubItems[0].Text = text;
                    listFavorites.SubItems[1].Text = Path.GetFileNameWithoutExtension(sqlFile);
                    listFavorites.SubItems[2].Text = dbUser;
                    listFavorites.SubItems[3].Text = dbList;
                    Favorite favorite = favorites[Convert.ToInt16(listFavorites.Tag)];
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
                    favorite.Text = text;
                    StatusMessages("", "Favorites", "modified description to \"" + listFavorites.SubItems[0].Text + "\".");
                }
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
                
        private void ListView1MouseLeave(object sender, EventArgs e)
        {
            listView1.SelectedItems.Clear();
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
                        
        private void ListView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            switch (listView1.CheckedItems.Count)
            {
                case 0:
                    labelDBsSelected.Text = string.Empty;
                    break;
                case 1:
                    labelDBsSelected.Text = "1 Database selected.";
                    break;
                default:
                    labelDBsSelected.Text = listView1.CheckedItems.Count + " Databases selected.";
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
                                                textBoxSqlFile.Text = taskArgs[ix].Substring(2, taskArgs[ix].Length-3);
                                                break;
                                            case "l":       // Argument -l LOGFILE
                                                textBoxLogFile.Text = taskArgs[ix].Substring(2, taskArgs[ix].Length-3);
                                                checkBoxLog.Checked = true;
                                                string logFileShort = textBoxLogFile.Text.Substring(0, textBoxLogFile.Text.LastIndexOf('.'));
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
                                                foreach (ListViewItem listDB in listView1.Items)
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
                                                for (int i = 0; i < listBoxUser.Items.Count; i++)
                                                {
                                                    if (listBoxUser.Items[i].ToString() == taskArgs[ix].Substring(1).Trim())
                                                    {
                                                        listBoxUser.SetSelected(i, true);
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
                                        textBoxSqlFile.Text = match.Groups[1].Value;
                                    }
                                    break;
                                case "Log File           ":
                                    match = Regex.Match(selectedArgument, @"Log File.*: file:\\\\(.*)", RegexOptions.IgnoreCase);
                                    if (match.Success)
                                    {
                                        textBoxLogFile.Text = match.Groups[1].Value;
                                        checkBoxLog.Checked = true;
                                        string logFileShort = textBoxLogFile.Text.Substring(0, textBoxLogFile.Text.LastIndexOf('.'));
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
                                        foreach (ListViewItem listDB in listView1.Items)
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
                                        for (int i = 0; i < listBoxUser.Items.Count; i++)
                                        {
                                            if (listBoxUser.Items[i].ToString() == match.Groups[1].Value.Trim())
                                            {
                                                listBoxUser.SetSelected(i, true);
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                case "Remove Task        ":         // Batch Session started - stop at the Remove Task
                                    searchLines = false;
                                    break;
                                case "E-Mail Address     ":         // Batch Session started - stop at the E-Mail 
                                    searchLines = false;
                                    break;
                            }
                        }
                    }
                }
                textBoxSessionHistory.SelectionLength = textBoxSessionHistory.GetFirstCharIndexFromLine(startLine) - textBoxSessionHistory.SelectionStart;
                textBoxSessionHistory.Select(textBoxSessionHistory.SelectionStart, textBoxSessionHistory.SelectionLength);
                labelSessionHistory_Message.Text = "Selected Session-Parameters copyed.";
            } else
            {
                MessageBox.Show("Unable to Select Text - String \"Session started.\" not found in the selected Block.");
            }
            
        }

        private void ListViewFavoritesColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)   lvwColumnSorter.Order = SortOrder.Descending;
                else                                                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            // Perform the sort with these new sort options.
            listViewFavorites.Sort();
        }
        private void ListViewFavoritesKeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Delete == e.KeyCode)
            {
                foreach (ListViewItem item in listViewFavorites.SelectedItems)
                {
                    listViewFavorites.Items.Remove(item);   
                    StatusMessages("", "Favorites", "deleted \"" + item.SubItems[0].Text + "\".");
                }
            }
        }
        private void TabControl1SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1) ShowFavorites();
            if (tabControl1.SelectedIndex == 2) ShowSessionHistory();
        }
        private void ShowSessionHistory()
        {
            try
            {
                labelSessionHistory_Message.Text = string.Empty;
                textBoxSessionHistory.Text = File.ReadAllText(SessionHistory.traceFile);
                textBoxSessionHistory.SelectionStart = textBoxSessionHistory.TextLength;
                //textBoxSessionHistory.ScrollBars = RichTextBoxScrollBars.Both; 
                textBoxSessionHistory.ScrollToCaret();
            }
            catch (Exception ex)
            {
                textBoxSessionHistory.Text = "Error reading Trace file: " + ex.Message;
            }
        }
        private void ReadFavorites()
        {
            int i = 0;
            if (File.Exists(favoritesFile))
            {
                XDocument doc = XDocument.Load(favoritesFile);
                foreach (var dm in doc.Descendants("Favorite"))
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
                    favorites.Add(item);
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
                listViewFavorites.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewFavorites.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        private void WriteFavorites()
        {
            if (favorites.Count > 0)
                using (XmlWriter writer = XmlWriter.Create(favoritesFile))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Favorites");

                    foreach (ListViewItem listFavorites in listViewFavorites.Items)
                    {
                        Favorite favorite = favorites[Convert.ToInt16(listFavorites.Tag)];
                        writer.WriteStartElement("Favorite");
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
                        writer.WriteElementString("Text", favorite.Text);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
        }
        private void ShowFavorites()
        {
            listViewFavorites.Select();
        }
        
    }
    static class Helper
    {
        public static void SwtichToBoldRegular(this Button c)
        {
            if (c.Font.Style != FontStyle.Bold)
                c.Font = new Font(c.Font, FontStyle.Bold);
            else
                c.Font = new Font(c.Font, FontStyle.Regular);
        }
    }
}