using System;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using System.Drawing;
using Simplify.Mail;
using System.Text;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace SQLAgain
{
    
    public partial class Form2 : Form  // Schedule Task, send e-Mail confirmation incl. calendar entry
    {
        private string taskArguments;
        private readonly string taskUserId;
        private readonly string taskPassword;
        private readonly string mailSender;

        private void Form2_load(object sender, EventArgs e)
        {
            if (Owner != null)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2 -105,
                    Owner.Location.Y + Owner.Height / 2 - Height / 2 + 265);
        }

        public Form2(string parmArguments, string sqlFile, string parmUserId, string parmPassword, string parmMailSender, string parmMailReceiver)
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
            tt.StartBoundary = startDate.Value ;
            td.Triggers.Add(tt);
            // Create an action that will launch SQLAgain in Batch-Mode whenever the trigger fires
            if (checkBoxDeleteTask.Checked == true)
            {
                SessionHistory.Record("Delete Task           : TRUE" );              
                taskArguments +=  " -r" ;
            }
            if (checkBoxSendMail.Checked == true)
            {
                SessionHistory.Record("Send E-Mail to        : " + mailReceiver.Text);
                taskArguments +=  " -E\"" + mailReceiver.Text + "\"";
            }
            td.Actions.Add(programPath, taskArguments);
            SessionHistory.Record("Task Action/Program   : " + programPath);
            SessionHistory.Record("Task Action/Arguments : " + taskArguments);
            // Register the task in the root folder of the local machine
            if (taskPassword == null )
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
                string formatDate = "yyyy'/'MM'/'dd HH:mm:ss";
                string mailBody = SQLAgain.Properties.Resources.MailHeader +
                "<table id=\"t01\" > <tr><td>" +
                "Dear Oracle DBA" +
                "<br>" +
                "<i>SQLAgain</i> confirms that the following task has been scheduled:" +
                "</td></tr>" +
                "<tr><td> " +
                "<div style = \"border-style: solid; border-width: thin; border-color:#dadce0; border-radius: 8px; padding: 10px 10px;\" >" +
                "<table id=\"t02\" > " +
                "<tr><td><b> Host Name                    </b></td><td> " + System.Environment.MachineName + " </td></tr>" +
                "<tr><td><b> Task Name                    </b></td><td> " + taskName.Text + " </td></tr>" +
                "<tr><td><b> Task Start Date              </b></td><td> " + startDate.Text + " </td></tr>" +               
                "<tr><td><b> Task Action/Program          </b></td><td> " + programPath + " </td></tr>" +
                "<tr><td><b> Task Action/Arguments        </b></td><td> " +  taskArguments + " </td></tr>" +
                "<tr><td><b> Delete Task after execution  </b></td><td> " + checkBoxDeleteTask.Checked + "</td></tr>" +
                "<tr><td><b> Task Creation Date           </b></td><td> " + System.DateTime.Now.ToString(formatDate) + " </td></tr>" +
                "</table>" +
                "</div>" +
                "</td></tr>" +
                "<tr><td> " +
                SQLAgain.Properties.Resources.MailFooter;
                StringBuilder sb = new StringBuilder();
                string calendarDateFormat = "yyyyMMddTHHmmss";

                sb.AppendLine("BEGIN: VCALENDAR");
                sb.AppendLine("PRODID:-//martin.bruegger@gmail.com//SQLAgain//EN");       
                sb.AppendLine("VERSION:2.0");
                sb.AppendLine("METHOD: PUBLISH");
                sb.AppendLine("BEGIN:VEVENT");
                sb.AppendLine("SUMMARY:" + taskName.Text);
                sb.AppendLine("PRIORITY: 0");                   // A value of 0 specifies an undefined priority.
                sb.AppendLine("CLASS: PRIVATE");                // PUBLIC, PRIVATE, CONFIDENTIAL; Default: PUBLIC 
                sb.AppendLine("TRANSP: TRANSPARENT");           // Time Transparency, TRANSPARENT or OPAQUE: Blocks or opaque on busy time searches.
                sb.AppendLine("X-MICROSOFT-CDO-BUSYSTATUS:FREE");  // Microsoft Outlook: "Show As" Free/Busy/Tentative/Out of Office
                sb.AppendLine("DTSTART:" + DateTime.Parse( startDate.Text).ToString(calendarDateFormat));
                sb.AppendLine("DTEND:" + DateTime.Parse(startDate.Text).ToString(calendarDateFormat));
                sb.AppendLine("DESCRIPTION: Task " + taskName.Text + " on Server " + System.Environment.MachineName);
                sb.AppendLine("LOCATION: " + System.Environment.MachineName);
                sb.AppendLine("END:VEVENT");
                sb.AppendLine("BEGIN: VALARM");
                sb.AppendLine("TRIGGER:-PT0M");                 // set VALARM to DTSTART
                sb.AppendLine("ACTION:DISPLAY");
                sb.AppendLine("DESCRIPTION:SQLAgain Task " + taskName.Text + " on Server " + System.Environment.MachineName);
                sb.AppendLine("END: VALARM");
                sb.AppendLine("END:VCALENDAR");

                var calendarBytes = Encoding.UTF8.GetBytes(sb.ToString());
                MemoryStream ms = new MemoryStream(calendarBytes);
                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(ms, "SQLAgain_event.ics", "text/calendar");
                
                try
                {
                    MailSender.Default.Send(mailSender, mailReceiver.Text, "SQLAgain Task scheduled", mailBody, null, attachment);
                    //MessageBox.Show("Task scheduled, confirmation E-Mail and Calendar Event sent.");
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
