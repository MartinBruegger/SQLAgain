// Program.cs
//
// Copyright 2025 Martin Bruegger

using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Win32.TaskScheduler;
using MimeKit;
using SQLAgain.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

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
                Updater.UpdateUpdater();    // Update the updater when file not in use.
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
            //string connectString = string.Empty ;
            string sqlFile, logFile, userName, oracleSid, options, taskName, mailReceiver, sqlPlusPath, tnsAdmin, sqlPath, nlsLang, dbUserPassword, connectString,  sqlResult;
            _ =    sqlFile= logFile= userName= oracleSid= options= taskName= mailReceiver= sqlPlusPath= tnsAdmin= sqlPath= nlsLang= dbUserPassword= connectString=  sqlResult= string.Empty;
            string mailServer, mailPort, mailUser, mailPassword, mailSender;
            _ =    mailServer= mailPort= mailUser= mailPassword= mailSender = string.Empty;
            bool enableSSL, ignoreError, sysDBA, logFileAppend, removeTask;
            _=   enableSSL= ignoreError= sysDBA= logFileAppend= removeTask = false;
            int timeout = 0;      // Default: 0 - only passed when > 0
            List<string> textList = new List<string>();
            List<string> errorList = new List<string>();
            string settingsFile = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) + @"\SQLAgainSettings.xml";

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
                    case "-u":      // Argument -u USERNAME (Read Password and SYSDBA from Settings.xml)
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
                    case "-e":      // Argument -e "Email Address"
                        mailReceiver = args[ix].Substring(2);
                        SessionHistory.Record("Email Address         : " + mailReceiver);
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
            try
            {
                XDocument doc = XDocument.Load(settingsFile);
                sqlPlusPath = doc.Root.Element("Environment").Element("SqlPlusPath")?.Value;
                nlsLang = doc.Root.Element("Environment").Element("NLS_LANG")?.Value;
                tnsAdmin = doc.Root.Element("Environment").Element("TNS_ADMIN")?.Value;
                sqlPath = doc.Root.Element("Environment").Element("SQLPATH")?.Value;
                bool passwordEncrypt = (doc.Root.Element("Environment").Element("PasswordEncrypt")?.Value == "True");
                if (!string.IsNullOrEmpty(mailReceiver))

                {
                    mailServer = doc.Root.Element("Mail").Element("SmtpServerAddress")?.Value;
                    mailPort = doc.Root.Element("Mail").Element("SmtpServerPortNumber")?.Value;
                    enableSSL = (doc.Root.Element("Mail").Element("EnableSsl")?.Value == "True");
                    mailUser = doc.Root.Element("Mail").Element("SmtpUserName")?.Value;
                    mailPassword = Utils.Decrypt(doc.Root.Element("Mail").Element("SmtpUserPassword")?.Value, passwordEncrypt);
                    mailSender = doc.Root.Element("Mail").Element("Sender")?.Value;
                }
                foreach (var dm in doc.Descendants("User"))
                {
                    if (userName.ToUpper() == dm.Element("Name").Value.ToUpper())
                    {
                        dbUserPassword = dm.Element("Schema").Value + "/" + Utils.Decrypt(dm.Element("Password").Value, passwordEncrypt);
                        sysDBA = bool.Parse(dm.Element("SYSDBA").Value);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                errorList.Add(ErrorStack("Environment", "Reading configuration: " + ex.Message ));
            }
            
            if (string.IsNullOrEmpty(sqlPlusPath))
            {
                sqlPlusPath = Utils.FindExePath("sqlplus.exe");
                if (string.IsNullOrEmpty(sqlPlusPath))                     errorList.Add(ErrorStack("Environment", "SQL*Plus not found. Either define the Directory in PATH or set SQL*Plus Path in Options."));
            } else
            {
                if (!System.IO.File.Exists(sqlPlusPath)) errorList.Add(ErrorStack("Environment", "sqlplus.exe not found. Options > Environment > SQL*Plus Path: " + sqlPlusPath));
            }
            
            if (string.IsNullOrEmpty(oracleSid))        errorList.Add(ErrorStack("Options", "No Oracle SID specified. (Option: -I)")); 
            if (string.IsNullOrEmpty(sqlFile))          errorList.Add(ErrorStack("Options", "No SQL - file specified. (Option: -F)")); 
            if (string.IsNullOrEmpty(logFile))          errorList.Add(ErrorStack("Options", "No Output-file specified. (Option: -L)")); 
            if (!System.IO.File.Exists(sqlFile))        errorList.Add(ErrorStack("SQL-File", "File \"" + sqlFile  + "\" not found.")); 
            if (string.IsNullOrEmpty(dbUserPassword))   errorList.Add(ErrorStack("DB User", "User \"" + userName + "\" not found."));
            if (errorList.Count == 0)
            {
                if (!string.IsNullOrEmpty(nlsLang))  Environment.SetEnvironmentVariable("NLS_LANG", nlsLang);
                if (!string.IsNullOrEmpty(tnsAdmin)) Environment.SetEnvironmentVariable("TNS_ADMIN", tnsAdmin);
                if (!string.IsNullOrEmpty(sqlPath))  Environment.SetEnvironmentVariable("SQLPATH", sqlPath);

                if (!logFileAppend)
                {
                    if (System.IO.File.Exists(logFile)) { File.Delete(logFile); }
                }
                
                string[] oracelSids = oracleSid.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                _ = oracelSids.Count();
                SessionHistory.Record("", 1, 3);
                foreach (string db in oracelSids)
                {
                    if (sysDBA)  connectString = string.Format("{0}@{1} AS SYSDBA", dbUserPassword, db); 
                    else         connectString = string.Format("{0}@{1}", dbUserPassword, db);
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
                "<tr><td> <h3>Task Summary</h3>" +
                "<table id=\"t02\" > " +
                "<tr><th> Task Name                  </th><td> " + taskName + " </td></tr>" +
                "<tr><th> Executed on Host           </th><td> " + System.Environment.MachineName + " </td></tr>" +
                "<tr><th> SQL File                   </th><td> " + sqlFile + " </td></tr>" +
                "<tr><th> Logfile from SQL*Plus      </th><td> " + logFile + " </td></tr>" +
                "<tr><th> Oracle Databases           </th><td> " + oracleSid + " </td></tr>" +
                "<tr><th> DB-User Name               </th><td> " + userName + " </td></tr>" +
                "<tr><th> Time started               </th><td> " + timeStart.ToString(dateFormat) + " </td></tr>" +
                "<tr><th> Time ended                 </th><td> " + timeEnd.ToString(dateFormat) + " </td></tr>" +
                "</table>" +
                "</td></tr><tr><td>";
                
                if (errorList.Count ==0)
                {
                    mailBody +=
                    "<h3>Database Summary</h3>" +
                    "<table id=\"t02\" > " +
                    string.Join("", textList);
                } else
                {
                    mailBody +=
                    "<h3>Errors found - SQL File was NOT executed</h3>" +
                    "<table id=\"t02\" > " +
                    string.Join("", errorList);
                    logFile = string.Empty;     // Do not attach a (old, existing) logFile when no SQL File was executed 
                }
                mailBody +=
                "</table>" +
                "<br>" +
                "<table id=\"t03\" > " +
                "<tr><td>Product Version: " + Assembly.GetEntryAssembly().GetName().Version.ToString() +
                "<br>Date:    " + Directory.GetLastWriteTime(AppDomain.CurrentDomain.BaseDirectory + "SQLAgain.exe").ToString("yyyy'/'MM'/'dd HH:mm") +
                "</td></tr></table>" +
                SQLAgain.Properties.Resources.MailFooter;
                SessionHistory.Record("Sending Email.", 2);
                try
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(mailSender.Substring(0, mailSender.IndexOf("@")), mailSender));
                    message.To.Add(new MailboxAddress(mailReceiver.Substring(0, mailReceiver.IndexOf("@")), mailReceiver));
                    message.Subject = "SQLAgain on " + System.Environment.MachineName;
                    var builder = new BodyBuilder();
                    builder.HtmlBody = mailBody;
                    builder.Attachments.Add(logFile);
                    message.Body = builder.ToMessageBody();
                    var client = new SmtpClient();
                    if (enableSSL)
                        client.Connect(mailServer, int.Parse(mailPort), true);
                    else
                        client.Connect(mailServer, int.Parse(mailPort), SecureSocketOptions.None);
                    if (!String.IsNullOrEmpty(mailPassword))
                    {
                        client.Authenticate(mailUser, mailPassword);
                    }
                    client.Send(message);
                    client.Disconnect(true);
                }
                catch (Exception EX)
                {
                    SessionHistory.Record("Failed to send Email." + EX.Message);
                    Console.WriteLine("Failed to send Email to " + mailReceiver);
                }
            }
            if (removeTask)
            {
                SessionHistory.Record("Deleting Task. ");
                try
                {
                    using (TaskService ts = new TaskService())
                    {
                        ts.RootFolder.DeleteTask(taskName);
                    }
                }
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
    }
}
