namespace SQLAgain
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label2 = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.buttonCreateTask = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.taskName = new System.Windows.Forms.TextBox();
            this.checkBoxDeleteTask = new System.Windows.Forms.CheckBox();
            this.checkBoxSendMail = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mailReceiver = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(30, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start Date";
            // 
            // startDate
            // 
            this.startDate.CalendarForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.startDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.startDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.startDate.CalendarTitleForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.startDate.CustomFormat = "yyyy/MM/dd HH:mm";
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(119, 65);
            this.startDate.Margin = new System.Windows.Forms.Padding(2);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(186, 20);
            this.startDate.TabIndex = 4;
            // 
            // buttonCreateTask
            // 
            this.buttonCreateTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonCreateTask.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCreateTask.BackgroundImage")));
            this.buttonCreateTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCreateTask.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonCreateTask.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCreateTask.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonCreateTask.Location = new System.Drawing.Point(32, 197);
            this.buttonCreateTask.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCreateTask.Name = "buttonCreateTask";
            this.buttonCreateTask.Size = new System.Drawing.Size(110, 29);
            this.buttonCreateTask.TabIndex = 6;
            this.buttonCreateTask.UseVisualStyleBackColor = false;
            this.buttonCreateTask.Click += new System.EventHandler(this.ButtonCreateTask);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(30, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Task Name";
            // 
            // taskName
            // 
            this.taskName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.taskName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.taskName.Location = new System.Drawing.Point(119, 37);
            this.taskName.Margin = new System.Windows.Forms.Padding(2);
            this.taskName.Name = "taskName";
            this.taskName.Size = new System.Drawing.Size(187, 20);
            this.taskName.TabIndex = 8;
            // 
            // checkBoxDeleteTask
            // 
            this.checkBoxDeleteTask.AutoSize = true;
            this.checkBoxDeleteTask.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.checkBoxDeleteTask.Location = new System.Drawing.Point(32, 98);
            this.checkBoxDeleteTask.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxDeleteTask.Name = "checkBoxDeleteTask";
            this.checkBoxDeleteTask.Size = new System.Drawing.Size(263, 17);
            this.checkBoxDeleteTask.TabIndex = 10;
            this.checkBoxDeleteTask.Text = "Delete Task in Task Scheduler after 1st execution";
            this.checkBoxDeleteTask.UseVisualStyleBackColor = true;
            // 
            // checkBoxSendMail
            // 
            this.checkBoxSendMail.AutoSize = true;
            this.checkBoxSendMail.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.checkBoxSendMail.Location = new System.Drawing.Point(32, 134);
            this.checkBoxSendMail.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxSendMail.Name = "checkBoxSendMail";
            this.checkBoxSendMail.Size = new System.Drawing.Size(86, 17);
            this.checkBoxSendMail.TabIndex = 11;
            this.checkBoxSendMail.Text = "Send E-Mail ";
            this.checkBoxSendMail.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(30, 154);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "- Mail receiver";
            // 
            // mailReceiver
            // 
            this.mailReceiver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.mailReceiver.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.mailReceiver.Location = new System.Drawing.Point(119, 151);
            this.mailReceiver.Margin = new System.Windows.Forms.Padding(2);
            this.mailReceiver.Name = "mailReceiver";
            this.mailReceiver.Size = new System.Drawing.Size(186, 20);
            this.mailReceiver.TabIndex = 13;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(341, 235);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.mailReceiver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxSendMail);
            this.Controls.Add(this.checkBoxDeleteTask);
            this.Controls.Add(this.taskName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonCreateTask);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Text = "Schedule Task for later";
            this.Load += new System.EventHandler(this.Form2_load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCreateTask;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox taskName;
        public System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.CheckBox checkBoxDeleteTask;
        private System.Windows.Forms.CheckBox checkBoxSendMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mailReceiver;
    }
}