using Simplify.Mail;
using SQLAgain.Properties;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace SQLAgain
{
    public partial class Form3 : Form   // Options
    {
        private string userName;
        private string dbUser;
        private string dbUserPassword;
        private string dbaFlag;
        private string check4UpdateInfo;
        private readonly string connectString;
        private XDocument doc;

        //bool isHideStringAvailable = Utils.Compatibility();
        //bool isHidePasswordActive;
        private void ButtonSQLCLPATH(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "exe Files|sqlplus.exe"
            };
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                sqlPlusPath.Text = openFileDialog.FileName;
            }
        }
        private void ButtonTNS_ADMIN(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = false,
                RootFolder = Environment.SpecialFolder.MyComputer
            };
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                tnsAdmin.Text = folderDlg.SelectedPath;
            }
        }
        private void ButtonSQLPATH(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            FolderBrowserDialog folderDlg = folderBrowserDialog;
            folderDlg.ShowNewFolderButton = false;
            folderDlg.RootFolder = Environment.SpecialFolder.MyComputer;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                sqlPath.Text = folderDlg.SelectedPath;
            }
        }
        //private void ButtonProgramName(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog
        //    {
        //        Filter = "exe Files|*.exe"
        //    };
        //    DialogResult result = openFileDialog.ShowDialog();
        //    if (result == DialogResult.OK)
        //    {
        //        editProgram.Text = openFileDialog.FileName;
        //    }
        //}
        private void ButtonTestMail(object sender, EventArgs e)
        {
            SaveMailSenderSettings();
            string maskedPassword = new string('*', smtpUserPassword.TextLength);
            string mailBody = SQLAgain.Properties.Resources.MailHeader +
                "<table id=\"t01\" > <tr><td>" +
                "Dear Oracle DBA" +
                "<br>" +
                "<i>SQLAgain</i> sends you a Test E-Mail with the following settings (Options / E-Mail Definitions):" +
                "</td></tr>" +
                "<tr><td> " +
                "<table id=\"t02\" > " +
                "<tr><td><b> SmtpServerAddress            </b></td><td> " + smtpServerAddress.Text + " </td></tr>" +
                "<tr><td><b> SmtpUserName                 </b></td><td> " + smtpUserName.Text + " </td></tr>" +
                "<tr><td><b> SmtpUserPassword             </b></td><td> " + maskedPassword + "</td></tr>" +
                "<tr><td><b> SmtpServerPortNumber         </b></td><td> " + smtpServerPortNumber.Text + " </td></tr>" +
                "<tr><td><b> AntiSpamMessagesPoolOn       </b></td><td> " + antiSpamMessagesPoolOn.Checked + " </td></tr>" +
                "<tr><td><b> AntiSpamPoolMessageLifeTime  </b></td><td> " + antiSpamPoolMessageLifeTime.Text + " </td></tr>" +
                "<tr><td><b> EnableSsl                    </b></td><td> " + enableSsl.Checked + " </td></tr>" +
                "<tr><td><b> E-Mail Sender                </b></td><td> " + mailSender.Text + " </td></tr>" +
                "<tr><td><b> E-Mail Receiver              </b></td><td> " + mailReceiver.Text + " </td></tr>" +
                "<tr><td><b> Executed on Host             </b></td><td> " + System.Environment.MachineName + " </td></tr>" +
                "<tr><td><b> Time sent                    </b></td><td> " + System.DateTime.Now.ToString("yyyy'/'MM'/'dd HH:mm:ss") + " </td></tr>" +
                "</table>" +
                "</td></tr>" +
                "<tr><td> " +
                SQLAgain.Properties.Resources.MailFooter;
            try
            {
                MailSender.Default.Send(mailSender.Text, mailReceiver.Text, "SQLAgain Test Mail", mailBody);
                MessageBox.Show("Test E-Mail sent.");
            }
            catch (Exception EX)
            {
                MessageBox.Show(string.Format("Mail Delivery failed: " + EX.Message));
            }
        }
        private void ButtonSave(object sender, EventArgs e)
        {
            //string trueOrFalse;
            //trueOrFalse = (hidePasswords.Checked) ? "true" : "false";
            //AddUpdateAppSettingsMail("AntiSpamMessagesPoolOn", trueOrFalse);
            DeleteAppSettings("APPL_LOG");          // no longer used - delete when found
            if (hidePasswords.Checked)              AddUpdateAppSettings("HidePasswords", "true");
            else                                    DeleteAppSettings(   "HidePasswords");
            if (nlsLang.Text != string.Empty)       AddUpdateAppSettings("NLS_LANG", nlsLang.Text);
            else                                    DeleteAppSettings("NLS_LANG");
            if (sqlPlusPath.Text != string.Empty)     AddUpdateAppSettings("SQLPLUS_PATH", sqlPlusPath.Text);
            else                                    DeleteAppSettings("SQLPLUS_PATH");
            if (sqlPath.Text != string.Empty)       AddUpdateAppSettings("SQLPATH", sqlPath.Text);
            else                                    DeleteAppSettings(   "SQLPATH"); 
            if (tnsAdmin.Text != string.Empty)      AddUpdateAppSettings("TNS_ADMIN", tnsAdmin.Text); 
            else                                    DeleteAppSettings(   "TNS_ADMIN"); 
            //if (editProgram.Text != string.Empty)   AddUpdateAppSettings("APPL_LOG", editProgram.Text); 
            //else                                    DeleteAppSettings(   "APPL_LOG");
            if (taskUserId.Text != string.Empty)    AddUpdateAppSettings("TASK_USER", taskUserId.Text);             
            else                                    DeleteAppSettings(   "TASK_USER");             
            if (taskPassword.Text != string.Empty)  AddUpdateAppSettings("TASK_USER_PWD", Utils.Encrypt(taskPassword.Text, hidePasswords.Checked)); 
            else                                    DeleteAppSettings(   "TASK_USER_PWD");
            if (mailSender.Text != string.Empty)    AddUpdateAppSettings("TASK_EMAIL1", mailSender.Text); 
            else                                    DeleteAppSettings(   "TASK_EMAIL1"); 
            if (mailReceiver.Text != string.Empty)  AddUpdateAppSettings("TASK_EMAIL2", mailReceiver.Text); 
            else                                    DeleteAppSettings(   "TASK_EMAIL2"); 
            if (excludeDbs.Text != string.Empty)    AddUpdateAppSettings("DBS_EXCLUDE", excludeDbs.Text); 
            else                                    DeleteAppSettings(   "DBS_EXCLUDE"); 
            if (group1Regexp.Text != string.Empty)  AddUpdateAppSettings("DBG1_REGEXP", group1Regexp.Text); 
            else                                    DeleteAppSettings(   "DBG1_REGEXP"); 
            if (group2Regexp.Text != string.Empty)  AddUpdateAppSettings("DBG2_REGEXP", group2Regexp.Text); 
            else                                    DeleteAppSettings(   "DBG2_REGEXP"); 
            if (group3Regexp.Text != string.Empty)  AddUpdateAppSettings("DBG3_REGEXP", group3Regexp.Text); 
            else                                    DeleteAppSettings(   "DBG3_REGEXP"); 
            if (group1Name.Text != string.Empty)    AddUpdateAppSettings("DBG1_TEXT", group1Name.Text); 
            else                                    DeleteAppSettings(   "DBG1_TEXT"); 
            if (group2Name.Text != string.Empty)    AddUpdateAppSettings("DBG2_TEXT", group2Name.Text); 
            else                                    DeleteAppSettings(   "DBG2_TEXT"); 
            if (group3Name.Text != string.Empty)    AddUpdateAppSettings("DBG3_TEXT", group3Name.Text); 
            else                                    DeleteAppSettings(   "DBG3_TEXT"); 
            if (group1Color.Text != string.Empty)   AddUpdateAppSettings("DBG1_COLOR", group1Color.Text); 
            else                                    DeleteAppSettings(   "DBG1_COLOR"); 
            if (group2Color.Text != string.Empty)   AddUpdateAppSettings("DBG2_COLOR", group2Color.Text); 
            else                                    DeleteAppSettings(   "DBG2_COLOR"); 
            if (group3Color.Text != string.Empty)   AddUpdateAppSettings("DBG3_COLOR", group3Color.Text); 
            else                                    DeleteAppSettings(   "DBG3_COLOR"); 
            int rows = dataGridView1.RowCount;
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (rows == i) { break; }
                userName = row.Cells[0].Value.ToString();
                dbUser = row.Cells[1].Value.ToString();
                dbUserPassword = row.Cells[2].Value.ToString();
                dbaFlag = row.Cells[3].Value.ToString();
                if (dbaFlag == "True") { dbaFlag = "1"; } else { dbaFlag = "0"; }
                AddUpdateAppSettings("DBUSER" + i, userName);
                AddUpdateAppSettings("DBCONN" + i, Utils.Encrypt(dbUser + "/" + dbUserPassword, hidePasswords.Checked));
                AddUpdateAppSettings("DBAFLAG" + i, dbaFlag);
                i++;
            }
            for (; i < 11; i++)
            {
                DeleteAppSettings("DBUSER" + i);
                DeleteAppSettings("DBCONN" + i);
                DeleteAppSettings("DBAFLAG" + i);
            }
            SaveMailSenderSettings();
            Close();
        }
        public Form3()
        {
            InitializeComponent();
            userName = connectString = dbUser = dbUserPassword = dbaFlag = string.Empty;
            string[] words;
            bool sysdba;
            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings["HidePasswords"] == "true") hidePasswords.Checked = true;
            DataTable data_tbl = new DataTable();
            data_tbl.Columns.Add("User", typeof(string));
            data_tbl.Columns.Add("Schema", typeof(string));
            data_tbl.Columns.Add("Password", typeof(string));
            data_tbl.Columns.Add("Sysdba", typeof(bool));
            for (int i = 1; i < 11; i++)
            {
                userName = appSettings["DBUSER" + i.ToString()];
                if (userName == null)
                {
                    break;
                }
                connectString = Utils.Decrypt( appSettings["DBCONN" + i.ToString()], hidePasswords.Checked);
                words = connectString.Split('/');
                dbUser = words[0];
                dbUserPassword = words[1];
                dbaFlag = appSettings["DBAFLAG" + i.ToString()];
                if (dbaFlag == "1") { sysdba = true; } else { sysdba = false; }
                data_tbl.Rows.Add(userName, dbUser, dbUserPassword, sysdba);
            }
            dataGridView1.DataSource = data_tbl;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; 
            sqlPlusPath.Text  = appSettings["SQLPLUS_PATH"];
            nlsLang.Text      = appSettings["NLS_LANG"];
            tnsAdmin.Text     = appSettings["TNS_ADMIN"];
            sqlPath.Text      = appSettings["SQLPATH"];
            //editProgram.Text  = appSettings["APPL_LOG"];
            taskUserId.Text   = appSettings["TASK_USER"];
            taskPassword.Text = Utils.Decrypt(appSettings["TASK_USER_PWD"], hidePasswords.Checked);
            mailSender.Text   = appSettings["TASK_EMAIL1"];
            mailReceiver.Text = appSettings["TASK_EMAIL2"];
            excludeDbs.Text   = appSettings["DBS_EXCLUDE"];
            group1Regexp.Text = appSettings["DBG1_REGEXP"];
            group2Regexp.Text = appSettings["DBG2_REGEXP"];
            group3Regexp.Text = appSettings["DBG3_REGEXP"];
            group1Name.Text   = appSettings["DBG1_TEXT"];
            group2Name.Text   = appSettings["DBG2_TEXT"];
            group3Name.Text   = appSettings["DBG3_TEXT"];
            group1Color.Text  = appSettings["DBG1_COLOR"];
            group2Color.Text  = appSettings["DBG2_COLOR"];
            group3Color.Text  = appSettings["DBG3_COLOR"];
            if (!string.IsNullOrEmpty(group1Color.Text))
                group1Color.BackColor = System.Drawing.ColorTranslator.FromHtml(group1Color.Text);
            if (!string.IsNullOrEmpty(group2Color.Text))
                group2Color.BackColor = System.Drawing.ColorTranslator.FromHtml(group2Color.Text);
            if (!string.IsNullOrEmpty(group3Color.Text))
                group3Color.BackColor = System.Drawing.ColorTranslator.FromHtml(group3Color.Text);

            var mailSettings = ConfigurationManager.GetSection("MailSenderSettings") as NameValueCollection;
            smtpServerAddress.Text    = mailSettings["SmtpServerAddress"];
            smtpUserName.Text         = mailSettings["SmtpUserName"];
            smtpUserPassword.Text     = mailSettings["SmtpUserPassword"];
            smtpServerPortNumber.Text = mailSettings["SmtpServerPortNumber"];
            if (mailSettings["AntiSpamMessagesPoolOn"] == "true") antiSpamMessagesPoolOn.Checked = true;
            antiSpamPoolMessageLifeTime.Text = mailSettings["AntiSpamPoolMessageLifeTime"];
            if (mailSettings["EnableSsl"] == "true") enableSsl.Checked = true;
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Password" && e.Value != null)
            {
                dataGridView1.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }
        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 3)//select target column
            {
                if (e.Control is TextBox textBox) textBox.UseSystemPasswordChar = true;
            }
            else
            {
                if (e.Control is TextBox textBox) textBox.UseSystemPasswordChar = false;
            }
        }
        private void ButtonGroup1Color(object sender, EventArgs e)
        {
            SetColor(1);
        }
        private void ButtonGroup2Color(object sender, EventArgs e)
        {
            SetColor(2);
        }
        private void ButtonGroup3Color(object sender, EventArgs e)
        {
            SetColor(3);
        }
        void SetColor(int group)
        {
            string str;
            str = SelectColor();
            if (!string.IsNullOrEmpty(str))
            {
                switch (group)
                {
                    case 1:
                        group1Color.Text = str;
                        group1Color.BackColor = System.Drawing.ColorTranslator.FromHtml(str);
                        break;
                    case 2:
                        group2Color.Text = str;
                        group2Color.BackColor = System.Drawing.ColorTranslator.FromHtml(str);
                        break;
                    case 3:
                        group3Color.Text = str;
                        group3Color.BackColor = System.Drawing.ColorTranslator.FromHtml(str);
                        break;
                }                
            }
        }
        private String SelectColor()
        {
            ColorDialog colorDlg = new ColorDialog
            {
                AllowFullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                ShowHelp = false
            };
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                string str = System.Drawing.ColorTranslator.ToHtml(colorDlg.Color);
                return str;
            }
            return null;
        }

        private void Group1Color_TextChanged(object sender, EventArgs e)
        {
            group1Name.ForeColor = System.Drawing.ColorTranslator.FromHtml(group1Color.Text);
        }

        private void Group2Color_TextChanged(object sender, EventArgs e)
        {
            group2Name.ForeColor = System.Drawing.ColorTranslator.FromHtml(group2Color.Text);
        }

        private void Group3Color_TextChanged(object sender, EventArgs e)
        {
            group3Name.ForeColor = System.Drawing.ColorTranslator.FromHtml(group3Color.Text);
        }

        void SaveMailSenderSettings()
        {
            // EMail Settings in Section MailSenderSettings
            string trueOrFalse;
            AddUpdateAppSettingsMail("SmtpServerAddress", smtpServerAddress.Text);
            AddUpdateAppSettingsMail("SmtpUserName", smtpUserName.Text);
            AddUpdateAppSettingsMail("SmtpUserPassword", smtpUserPassword.Text);
            AddUpdateAppSettingsMail("SmtpServerPortNumber", smtpServerPortNumber.Text);
            trueOrFalse = (antiSpamMessagesPoolOn.Checked) ? "true" : "false";
            AddUpdateAppSettingsMail("AntiSpamMessagesPoolOn", trueOrFalse);
            AddUpdateAppSettingsMail("AntiSpamPoolMessageLifeTime", antiSpamPoolMessageLifeTime.Text);
            trueOrFalse = (enableSsl.Checked) ? "true" : "false";
            AddUpdateAppSettingsMail("EnableSsl", trueOrFalse);
            ConfigurationManager.RefreshSection("MailSenderSettings");
        }
        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.AppSettings.SectionInformation.ForceSave = true;
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Error writing app settings (AddUpdateAppSettings)");
            }
        }   

        
        static void DeleteAppSettings(string key)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] != null)
                {
                    settings.Remove(key);
                }
                configFile.AppSettings.SectionInformation.ForceSave = true;
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Error writing app settings (DeleteAppSettings)");
            }
        }

        static void AddUpdateAppSettingsMail(string key, string value)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            // delete key
            try
            {
                XmlNode nodeDelete = xmlDoc.SelectSingleNode("//MailSenderSettings/add[@key='" + key + "']");
                nodeDelete.ParentNode.RemoveChild(nodeDelete);
            }
            catch { }
            // add new key
            var nodeAdd = xmlDoc.CreateElement("add");
            if (value != string.Empty)
            {
                nodeAdd.SetAttribute("key", key);
                nodeAdd.SetAttribute("value", value);
                xmlDoc.SelectSingleNode("//MailSenderSettings").AppendChild(nodeAdd);
            }
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }

        private void TabControl1SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)     // Tab "Ckeck for Update" pressed 
            {
                Version appVersion = Assembly.GetEntryAssembly().GetName().Version;
                string appLastWriteTime = System.IO.File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location).ToString("yyyy'/'MM'/'dd HH:mm:ss");
                try
                {
                    // download manifest
                    //XDocument doc = XDocument.Load(Settings.Default.RemoteManifest);
                    doc = XDocument.Load(Settings.Default.RemoteManifest);

        // if newer, display update dialog
        Version newestVersion = new Version((string)doc.Root.Element("version"));
                    if (newestVersion > appVersion)
                    {
                        label1Check4Update.Text = "Update available";
                        label2Check4Update.Text = string.Format("{0}   from   {1}   is your current version", appVersion, appLastWriteTime);
                        label3Check4Update.Text = string.Format("{0}   from   {1}   is the latest version", newestVersion, ((DateTime)doc.Root.Element("date")).ToString("yyyy'/'MM'/'dd HH:mm:ss"));
                        linkCheck4Update.Visible = true;
                        button_Update.Visible = true;
                        check4UpdateInfo = (string)doc.Root.Element("info");
                    } else
                    {
                        label2Check4Update.Text = appVersion.ToString() + " from ";
                        label2Check4Update.Text = string.Format("{0} from {1} is the latest version",appVersion,appLastWriteTime);
                    }
                }
                catch (Exception ex)
                {
                    label1Check4Update.Text = "Unable to check Updates";
                    label2Check4Update.Text = ex.Message;
                }
            }
        }

        private void LinkInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkCheck4Update.LinkVisited = true;
            System.Diagnostics.Process.Start(check4UpdateInfo);
        }

        private void ButtonUpdate(object sender, EventArgs e)
        {
            //MessageBox.Show("I am going to update now - Good Bye :-)");
            Updater.LaunchUpdater(doc);
            this.Close();
            Application.Exit();
        }
    }
}
