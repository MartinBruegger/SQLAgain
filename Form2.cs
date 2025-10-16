// Form2.cs
//
// Copyright 2025 Martin Bruegger

using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Win32.TaskScheduler;
using MimeKit;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SQLAgain
{
    
    public partial class Form2 : Form  // Schedule Task, send e-Mail confirmation incl. calendar entry
    {
        private string taskArguments;
        private readonly string taskUserId;
        private readonly string taskPassword;
        private readonly string mailSender;
        private readonly string mailServer;
        private readonly string mailPort;
        private readonly bool   enableSSL;
        private readonly string mailUser;
        private readonly string mailPassword;

        private void Form2_load(object sender, EventArgs e)
        {
            if (Owner != null)
                Location = new Point(Owner.Location.X + Owner.Width - 370, Owner.Location.Y + 480); // Below Button "Schedule"
        }

        public Form2(string parmArguments, string sqlFile, string parmUserId, string parmPassword, string parmMailSender, string parmMailReceiver, 
            string parmMailServer, string parmMailPort, bool parmEnableSSL, string parmMailUser, string parmMailPassword, bool darkMode)
        {
            InitializeComponent();
            taskUserId                 = parmUserId;
            taskPassword               = parmPassword;
            taskName.Text              = "SQLAgain " + sqlFile;
            taskArguments              = "-d\"" + taskName.Text + "\" " + parmArguments;
            startDate.Value            = DateTime.Today + TimeSpan.FromHours(21);
            checkBoxDeleteTask.Checked = true ;            
            mailSender                 = parmMailSender;
            if (parmMailReceiver != null)
            {
                mailReceiver.Text = parmMailReceiver; 
                checkBoxSendMail.Checked = true;
            } else
            {
                mailReceiver.Text = null;
                checkBoxSendMail.Checked = false;
            }      
            mailServer = parmMailServer;
            mailPort = parmMailPort;
            enableSSL = parmEnableSSL;
            mailUser = parmMailUser;
            mailPassword = parmMailPassword;
            if (!darkMode)
            {
                this.BackColor = SystemColors.Control;
                Utils.SetColorMode(this, darkMode);
            }
        }

        private void ButtonCreateTask(object sender, EventArgs e)
        {
            string programPath = "\"" + System.Reflection.Assembly.GetEntryAssembly().Location + "\"";
            SessionHistory.Record("***** Create Windows Task started.", 2);
            SessionHistory.Record("Task Name             : " + taskName.Text);
            SessionHistory.Record("Schedule Date/Time    : " + startDate.Text);
            // Create a new task definition for the local machine and assign properties
            TaskDefinition td = TaskService.Instance.NewTask();
            TimeTrigger timeTrigger = new TimeTrigger();
            TimeTrigger tt = timeTrigger;
            tt.StartBoundary = startDate.Value;
            td.Triggers.Add(tt);
            // Create an action that will launch SQLAgain in Batch-Mode whenever the trigger fires
            if (checkBoxDeleteTask.Checked == true)
            {
                SessionHistory.Record("Delete Task           : TRUE");
                taskArguments += " -r";
            }
            if (checkBoxSendMail.Checked == true)
            {
                SessionHistory.Record("Send E-Mail to        : " + mailReceiver.Text);
                taskArguments += " -E\"" + mailReceiver.Text + "\"";
            }
            td.Actions.Add(programPath, taskArguments);
            SessionHistory.Record("Task Action/Program   : " + programPath);
            SessionHistory.Record("Task Action/Arguments : " + taskArguments);
            // Register the task in the root folder of the local machine
            if (taskPassword == null)
            {
                try
                {
                    TaskService.Instance.RootFolder.RegisterTaskDefinition(taskName.Text, td);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to create Windows Scheduler Task:\n " + ex.Message);
                }

            } else
            {
                try
                {
                    TaskService.Instance.RootFolder.RegisterTaskDefinition(taskName.Text, td,
                    TaskCreation.CreateOrUpdate, taskUserId, taskPassword, TaskLogonType.Password);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to create Windows Scheduler Task:\n " + ex.Message);
                }
            }
            SessionHistory.Record("***** Create Windows Task ended.");
            if (checkBoxSendMail.Checked == true)
            {
                try
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(mailSender.Substring(0, mailSender.IndexOf("@")), mailSender));
                    message.To.Add(new MailboxAddress(mailReceiver.Text.Substring(0, mailReceiver.Text.IndexOf("@")), mailReceiver.Text));
                    message.Subject = "SQLAgain Task scheduled";
                    var builder = new BodyBuilder();
                    builder.HtmlBody =
                        SQLAgain.Properties.Resources.MailHeader +
                            "<table id=\"t01\" > <tr><td>" +
                            "Dear Oracle DBA" +
                            "<br>" +
                            "<i>SQLAgain</i> confirms that the following task has been scheduled:" +
                            "</td></tr>" +
                            "<tr><td> " +
                            "<table id=\"t02\"> " +
                            "<tr><th> Host Name                    </th><td> " + System.Environment.MachineName                          + " </td></tr>" +
                            "<tr><th> Task Name                    </th><td> " + taskName.Text                                           + " </td></tr>" +
                            "<tr><th> Task Start Date              </th><td> " + startDate.Text                                          + " </td></tr>" +
                            "<tr><th> Task Action/Program          </th><td> " + programPath                                             + " </td></tr>" +
                            "<tr><th> Task Action/Arguments        </th><td> " + taskArguments                                           + " </td></tr>" +
                            "<tr><th> Delete Task after execution  </th><td> " + checkBoxDeleteTask.Checked                              + " </td></tr>" +
                            "<tr><th> Task Creation Date           </th><td> " + System.DateTime.Now.ToString("yyyy'/'MM'/'dd HH:mm:ss") + " </td></tr>" +
                            "</table>" +
                            "</td></tr>" +
                            "<tr><td> " +
                            SQLAgain.Properties.Resources.MailFooter;

                    var calendarDateFormat = "yyyyMMddTHHmmss";
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("BEGIN: VCALENDAR");
                    sb.AppendLine("PRODID: -//martin.bruegger@gmail.com//SQLAgain//EN");
                    sb.AppendLine("VERSION: 2.0");
                    sb.AppendLine("METHOD: PUBLISH");
                    sb.AppendLine("BEGIN: VEVENT");
                    sb.AppendLine("SUMMARY:" + taskName.Text);
                    sb.AppendLine("PRIORITY: 0");                                                       // A value of 0 specifies an undefined priority.
                    sb.AppendLine("CLASS: PRIVATE");                                                    // PUBLIC, PRIVATE, CONFIDENTIAL; Default: PUBLIC 
                    sb.AppendLine("TRANSP: TRANSPARENT");                                               // Time Transparency, TRANSPARENT or OPAQUE: Blocks or opaque on busy time searches.
                    sb.AppendLine("X-MICROSOFT-CDO-BUSYSTATUS: FREE");                                   // Microsoft Outlook: "Show As" Free/Busy/Tentative/Out of Office
                    sb.AppendLine("DTSTART: " + DateTime.Parse(startDate.Text).ToString(calendarDateFormat));
                    sb.AppendLine("DTEND: " + DateTime.Parse(startDate.Text).ToString(calendarDateFormat));
                    sb.AppendLine("DESCRIPTION: SQLAgain Task \"" + taskName.Text.Trim() + "\" on Server " + System.Environment.MachineName);
                    sb.AppendLine("LOCATION: " + System.Environment.MachineName);
                    sb.AppendLine("END: VEVENT");
                    sb.AppendLine("BEGIN: VALARM");
                    sb.AppendLine("TRIGGER:-PT0M");                                                     // set VALARM to DTSTART
                    sb.AppendLine("ACTION: DISPLAY");
                    sb.AppendLine("DESCRIPTION: SQLAgain Task \"" + taskName.Text.Trim() + "\" on Server " + System.Environment.MachineName);
                    sb.AppendLine("END: VALARM");
                    sb.AppendLine("END: VCALENDAR");
                    builder.Attachments.Add("SQLAgain-calendar.ics", Encoding.UTF8.GetBytes(sb.ToString()));
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
                    MessageBox.Show(string.Format("Mail Delivery failed: " + EX.Message));
                }
            }
            this.Close();
        }
    }
}
