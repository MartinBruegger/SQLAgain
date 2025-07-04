
using Microsoft.VisualBasic;
using Microsoft.Win32.TaskScheduler;
using Simplify.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace SQLAgain
{   
    static class Program
    {
        /// <summary>
        /// Executes a SQL-file in one or multiple Oracle databases using SQL*Plus.
        /// </summary>
        [STAThread]

        static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                // Command line given, display console
                if (!AttachConsole(-1))   { // Attach to an parent process console
                    AllocConsole();         // Alloc a new console
                }
                ConsoleMain(args);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(args));
            }           
        }
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int pid);  
        private static void ConsoleMain(string[] args)
        { 
            string sqlPlusPath, sqlFile, logFile, userName, oracleSid, options, nlsLang, taskName, mailSender, mailReceiver, dbUserPassword, connectString, sqlResult;
            _ = sqlFile = logFile = userName = oracleSid = options = taskName = mailReceiver = string.Empty;
            bool ignoreError = false;
            int dbaFlag = 0;
            int timeout = 0;      // Default: 0 - only passed when > 0
            bool logFileAppend = false;
            bool removeTask = false;
            List<string> textList = new List<string>();
            List<string> errorList = new List<string>();


            DateTime timeStart = DateTime.Now;
            string dateFormat = "yyyy'/'MM'/'dd HH:mm:ss";
            SessionHistory.Record("***** Batch Session started.",2);
            for (int ix = 0; ix < args.Length; ++ix)
            {
                string arg1 = args[ix];
                switch (arg1.ToLower().Substring(0, 2))
                {
                    case "-d":      // Argument -d "TASKNAME"
                        taskName = args[ix].Substring(2);
                        SessionHistory.Record("Task Name             : " + taskName);
                        break;
                    case "-f":      // Argument -f SQLFILE
                        sqlFile = args[ix].Substring(2);
                        SessionHistory.Record("SQL-File              : file:\\\\" + sqlFile);
                        break;
                    case "-l":      // Argument -l LOGFILE
                        logFile = args[ix].Substring(2);
                        SessionHistory.Record("Log File              : file:\\\\" + logFile);
                        break;
                    case "-i":      // Argument -i "Instance List"
                        oracleSid = args[ix].Substring(2);
                        SessionHistory.Record("Instance List         : " + oracleSid);
                        break;
                    case "-u":      // Argument -u USERNAME (from config file, incl. password and sysdba flag)
                        userName = args[ix].Substring(2);
                        SessionHistory.Record("DB User               : " + userName);
                        break;
                    case "-s":      // Argument -s SQL*Plus option -S (silent)
                        options += " -S";
                        SessionHistory.Record("SQL*Plus Option       : -S");
                        break;
                    case "-a":      // Argument -a  append to logfile
                        logFileAppend = true ;
                        SessionHistory.Record("Append to Log File    : TRUE");
                        break;
                    case "-r":      // Argument -r 
                        removeTask = true;
                        SessionHistory.Record("Remove Task           : TRUE");
                        break;
                    case "-e":      // Argument -e "E-Mail Address"
                        mailReceiver = args[ix].Substring(2);
                        SessionHistory.Record("E-Mail Address        : " + mailReceiver);
                        break;
                    case "-m":      // Argument -m MARKUP "HTML" or "CSV";
                        if (args[ix].ToLower().Substring(2) == "html")
                        {
                            SessionHistory.Record("SQL*Plus Format Option: HTML");
                            options += " HTML";
                            //formatOption = 10;
                        } 
                        else if (args[ix].ToLower().Substring(2) == "csv" )
                        {
                            SessionHistory.Record("SQL*Plus Format Option: CSV");
                            options += " CSV";
                        }
                        else
                        {
                            errorList.Add(ErrorStack("Options", "Option -m" + args[ix].Substring(2) + " invalid. Valid values are -mhtml or -mcsv"));
                        }
                        break;
                    case "-t":      // Argument -t "timeout in seconds"
                        Int32.TryParse(args[ix].Substring(2), out timeout);
                        SessionHistory.Record("Timeout (Seconds)     : " + timeout);
                        break;
                    case "-b":      // Argument -r ignoreError
                        ignoreError = true;
                        SessionHistory.Record("Ignore severe Error   : TRU");
                        break;
                }
            }
            var appSettings = ConfigurationManager.AppSettings;
            sqlPlusPath = appSettings["SQLPLUS_PATH"];
            if (string.IsNullOrEmpty(sqlPlusPath))
            {
                sqlPlusPath = Utils.FindExePath("sqlplus.exe");
                if (string.IsNullOrEmpty(sqlPlusPath))
                {
                    errorList.Add(ErrorStack("Environment", "SQL*Plus not found. Either define the Directory in PATH or set SQL*Plus Path in Options."));
                }
            }
            nlsLang = appSettings["nlsLang"];
            if (nlsLang != null)
            {
                Environment.SetEnvironmentVariable("nlsLang", nlsLang);
            }
            if (oracleSid == string.Empty)       { errorList.Add(ErrorStack("Options", "No Oracle SID specified. (Option: -I)")); }
            if (sqlFile == string.Empty)         { errorList.Add(ErrorStack("Options", "No SQL - file specified. (Option: -F)")); }
            if (logFile == string.Empty)         { errorList.Add(ErrorStack("Options", "No Output-file specified. (Option: -L)")); }
            if (!System.IO.File.Exists(sqlFile)) { errorList.Add(ErrorStack("SQL-File", "File \"" + sqlFile  + "\" not found.")); }

            dbUserPassword = GetConnectString(userName);
            if (dbUserPassword == string.Empty)
            {
                errorList.Add(ErrorStack("DB User", "User \"" + userName + "\" not found in AppSettings."));
            } else
            {
                if (dbUserPassword.Substring(0, 1) == "-")
                {
                    dbaFlag = 1;
                    dbUserPassword = dbUserPassword.Substring(1);
                }
            }

            if (errorList.Count == 0)
            {
                string directory;
                string sqlFilePath, sqlPath;
                System.IO.FileInfo fileinfo = new System.IO.FileInfo(sqlFile);
                sqlFilePath = fileinfo.DirectoryName;
                directory = appSettings["TNS_ADMIN"];
                if (directory != null) { Environment.SetEnvironmentVariable("TNS_ADMIN", directory); }
                directory = appSettings["SQLPATH"];
                if (directory != null) { sqlPath = string.Format("{0};{1}", sqlFilePath, directory); }
                else { sqlPath = sqlFilePath; }
                Environment.SetEnvironmentVariable("SQLPATH", sqlPath);

                if (logFileAppend == false)
                {
                    if (System.IO.File.Exists(logFile)) { File.Delete(logFile); }
                }
                
                string[] oracelSids = oracleSid.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                _ = oracelSids.Count();
                SessionHistory.Record("", 1, 3);
                foreach (string db in oracelSids)
                {
                    if (dbaFlag == 1) { connectString = string.Format("{0}@{1} as sysdba", dbUserPassword, db); }
                    else { connectString = string.Format("{0}@{1}", dbUserPassword, db); }
                    SessionHistory.Record(db.PadRight(24) + Path.GetFileName(sqlFile).PadRight(50), 0, 1);
                    sqlResult = ExecSQL.DoSQL(sqlPlusPath, db, connectString, sqlFile, logFile, options, null, timeout, ignoreError);
                    if (sqlResult.StartsWith("OK"))
                    {
                        textList.Add("<tr><td> " + DateTime.Now.ToString(dateFormat) + " </td><td> " + db + " </td><td> " + sqlResult + " </td></tr>");
                    }
                    else
                    {
                        textList.Add("<tr><td> " + DateTime.Now.ToString(dateFormat) + " </td><td> " + db + @" </td><td class=""red""> " + sqlResult + " </td></tr>");
                    }
                }
            }
            if (mailReceiver != string.Empty)
            {
                DateTime timeEnd = DateTime.Now;
                string mailBody = SQLAgain.Properties.Resources.MailHeader +
                "<table id=\"t01\" > <tr><td>" +
                "Dear Oracle DBA" +
                "<br>" +
                "<i>SQLAgain</i> executed a SQL-File and sends you its Output." +
                "</td></tr>" +
                "<tr><td> Job Summary" +
                "<div style=\"border-style: solid; border-width: thin; border-color:#dadce0; border-radius: 8px; padding: 10px 10px;\" >" +
                "<table id=\"t02\" > " +
                "<tr><td><b> Task Name                  </b></td><td> " + taskName + " </td></tr>" +
                "<tr><td><b> Executed on Host           </b></td><td> " + System.Environment.MachineName + " </td></tr>" +
                "<tr><td><b> SQL File                   </b></td><td> " + sqlFile + " </td></tr>" +
                "<tr><td><b> Logfile from SQL*Plus     </b></td><td> " + logFile + " </td></tr>" +
                "<tr><td><b> Oracle Databases           </b></td><td> " + oracleSid + " </td></tr>" +
                "<tr><td><b> DB-User Name               </b></td><td> " + userName + " </td></tr>" +
                "<tr><td><b> Time started               </b></td><td> " + timeStart.ToString(dateFormat) + " </td></tr>" +
                "<tr><td><b> Time ended                 </b></td><td> " + timeEnd.ToString(dateFormat) + " </td></tr>" +
                "</table>" +
                "</div>" +
                "</td></tr><tr><td>";
                
                if (errorList.Count ==0)
                {
                    mailBody +=
                    "Database Summary" +
                    "<div style=\"border-style: solid; border-width: thin; border-color:#dadce0; border-radius: 8px; padding: 10px 10px;\" >" +
                    "<table id=\"t02\" > " +
                    string.Join("", textList);
                } else
                {
                    mailBody +=
                    "Errors found - SQL File was NOT executed" +
                    "<div style=\"border-style: solid; border-width: thin; border-color:#dadce0; border-radius: 8px; padding: 10px 10px;\" >" +
                    "<table id=\"t02\" > " +
                    string.Join("", errorList);
                    logFile = string.Empty;     // Do not attach a (old, existing) logFile when no SQL File was executed 
                }
                mailBody +=
                "</table>" +
                "</div><br>" +
                "<table id=\"t03\" > " +
                "<tr><td>Product Version: " + Assembly.GetEntryAssembly().GetName().Version.ToString() +
                "<br>Date:    " + Directory.GetLastWriteTime(AppDomain.CurrentDomain.BaseDirectory + "SQLAgain.exe").ToString("yyyy'/'MM'/'dd HH:mm") +
                "</td></tr></table>" +
                SQLAgain.Properties.Resources.MailFooter;

                mailSender = appSettings["TASK_EMAIL1"];
                if (mailSender == null)                
                    mailSender = System.Environment.UserName + "@" + System.Environment.MachineName;
                
                SessionHistory.Record("Sending E-Mail.",2);
                try
                {
                    if (logFile == string.Empty) MailSender.Default.Send(mailSender, mailReceiver, "SQLAgain on " + System.Environment.MachineName, mailBody, null);
                    else                         MailSender.Default.Send(mailSender, mailReceiver, "SQLAgain on " + System.Environment.MachineName, mailBody, null, new System.Net.Mail.Attachment(logFile));
                }                
                catch (Exception EX)
                {
                    SessionHistory.Record("Failed to send E-Mail." + EX.Message);
                    Console.WriteLine("Failed to send E-Mail to " + mailReceiver);
                }
            }
            if (removeTask)
            {
                SessionHistory.Record("Deleting Task. ");
                try { DeleteTask(taskName); }
                catch (Exception)
                {
                    SessionHistory.Record("Failed to delete Scheduler Task");
                    Console.WriteLine("Failed to delete Scheduler Task " + taskName);
                }
            }
            SessionHistory.Record("***** Batch Session ended.");

            if (errorList.Count > 0) Environment.Exit(1);
        }
        public static string ErrorStack(string Subject, string Message)
        {
            SessionHistory.Record("SQLAgain Batch-Mode Error: " + Subject + ": " + Message);
            return "<tr><td> " + Subject + " </td><td class=\"red\"> " + Message + " </td></tr>";
        }
        public static string GetConnectString(string userName)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string dbUser, connectString, dbaFlag;
            connectString = string.Empty;
            bool isHidePasswordsActive = false;

            if (appSettings["HidePasswords"] == "true") isHidePasswordsActive = true;
            if (userName == string.Empty) { userName = appSettings["DBUSER1"]; }
            for (int i = 1; i < 11; i++)
            {
                dbUser = appSettings["DBUSER" + i.ToString()];
                if (dbUser != null)
                {
                    if (userName.ToUpper() == dbUser.ToUpper())
                    {
                        connectString = Utils.Decrypt(appSettings["DBCONN" + i.ToString()], isHidePasswordsActive);
                        dbaFlag = appSettings["DBAFLAG" + i.ToString()];
                        if (dbaFlag == "1") { connectString = "-" + connectString; }
                        break;
                    }
                }
            }
            return connectString;
        }
        public static void DeleteTask(string TASKNAME)
        {
            using (TaskService ts = new TaskService())
            {
                ts.RootFolder.DeleteTask(TASKNAME);
            }
        }
    }
}
