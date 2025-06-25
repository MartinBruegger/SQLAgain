namespace SQLAgain
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelDB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxLog = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxUser = new System.Windows.Forms.ListBox();
            this.buttonOptions = new System.Windows.Forms.Button();
            this.buttonTNSPing = new System.Windows.Forms.Button();
            this.textBoxSqlFile = new System.Windows.Forms.TextBox();
            this.textBoxLogFile = new System.Windows.Forms.TextBox();
            this.buttonRunSQL = new System.Windows.Forms.Button();
            this.buttonSqlFile = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxOptSilent = new System.Windows.Forms.CheckBox();
            this.checkBoxOptCSV = new System.Windows.Forms.CheckBox();
            this.checkBoxOptHTML = new System.Windows.Forms.CheckBox();
            this.buttonViewLog = new System.Windows.Forms.Button();
            this.checkBoxLogAppend = new System.Windows.Forms.CheckBox();
            this.buttonScheduleSQL = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listViewStatusMessages = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelSessionHistory_Message = new System.Windows.Forms.Label();
            this.textBoxSessionHistory = new System.Windows.Forms.RichTextBox();
            this.timeoutHH = new System.Windows.Forms.NumericUpDown();
            this.timeoutMM = new System.Windows.Forms.NumericUpDown();
            this.timeoutSS = new System.Windows.Forms.NumericUpDown();
            this.checkBoxOptIgnoreError = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.buttonAddFavorites = new System.Windows.Forms.Button();
            this.listViewFavorites = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuFavorites = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.favoritesRun = new System.Windows.Forms.ToolStripMenuItem();
            this.favoritesLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.favoritesEditFile = new System.Windows.Forms.ToolStripMenuItem();
            this.favoritesUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.favoritesDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBoxAbout = new System.Windows.Forms.RichTextBox();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonSelectGroup1 = new System.Windows.Forms.Button();
            this.buttonSelectGroup2 = new System.Windows.Forms.Button();
            this.buttonSelectGroup3 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonCancelSQL = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.contextMenuSessionHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sessionHistoryEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionHistoryRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStatusMessages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusMessagesClear = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDBsSelected = new System.Windows.Forms.Label();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutHH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutMM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutSS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.contextMenuFavorites.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.contextMenuSessionHistory.SuspendLayout();
            this.contextMenuStatusMessages.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDB
            // 
            this.labelDB.AutoSize = true;
            this.labelDB.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelDB.Location = new System.Drawing.Point(10, 11);
            this.labelDB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDB.Name = "labelDB";
            this.labelDB.Size = new System.Drawing.Size(159, 13);
            this.labelDB.TabIndex = 0;
            this.labelDB.Text = "Oracle Database (tnsnames.ora)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(15, 346);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SQL File to execute";
            // 
            // checkBoxLog
            // 
            this.checkBoxLog.AutoSize = true;
            this.checkBoxLog.Checked = true;
            this.checkBoxLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLog.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.checkBoxLog.Location = new System.Drawing.Point(17, 394);
            this.checkBoxLog.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxLog.Name = "checkBoxLog";
            this.checkBoxLog.Size = new System.Drawing.Size(75, 17);
            this.checkBoxLog.TabIndex = 17;
            this.checkBoxLog.Text = "Log to File";
            this.checkBoxLog.UseVisualStyleBackColor = true;
            this.checkBoxLog.CheckedChanged += new System.EventHandler(this.CheckBoxLogChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Location = new System.Drawing.Point(0, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "DB User";
            // 
            // listBoxUser
            // 
            this.listBoxUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.listBoxUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listBoxUser.FormattingEnabled = true;
            this.listBoxUser.Location = new System.Drawing.Point(0, 18);
            this.listBoxUser.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxUser.Name = "listBoxUser";
            this.listBoxUser.Size = new System.Drawing.Size(158, 82);
            this.listBoxUser.TabIndex = 6;
            this.toolTip1.SetToolTip(this.listBoxUser, "Select Database User for the Database Connection.");
            this.listBoxUser.SelectedIndexChanged += new System.EventHandler(this.ListBoxUserChanged);
            // 
            // buttonOptions
            // 
            this.buttonOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonOptions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonOptions.BackgroundImage")));
            this.buttonOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonOptions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOptions.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonOptions.Location = new System.Drawing.Point(0, 113);
            this.buttonOptions.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOptions.Name = "buttonOptions";
            this.buttonOptions.Size = new System.Drawing.Size(93, 29);
            this.buttonOptions.TabIndex = 7;
            this.toolTip1.SetToolTip(this.buttonOptions, "Define your DB Users including Alias, Name and Password or Environment Settings l" +
        "ike TNS_ADMIN and SQLPATH.");
            this.buttonOptions.UseVisualStyleBackColor = false;
            this.buttonOptions.Click += new System.EventHandler(this.ButtonOptions);
            // 
            // buttonTNSPing
            // 
            this.buttonTNSPing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonTNSPing.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTNSPing.BackgroundImage")));
            this.buttonTNSPing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTNSPing.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTNSPing.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonTNSPing.Location = new System.Drawing.Point(0, 152);
            this.buttonTNSPing.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTNSPing.Name = "buttonTNSPing";
            this.buttonTNSPing.Size = new System.Drawing.Size(93, 29);
            this.buttonTNSPing.TabIndex = 8;
            this.toolTip1.SetToolTip(this.buttonTNSPing, "Test the Connectifity to the selected Databases using Oracles tnsping Utility.");
            this.buttonTNSPing.UseVisualStyleBackColor = false;
            this.buttonTNSPing.Click += new System.EventHandler(this.ButtonTNSPing);
            // 
            // textBoxSqlFile
            // 
            this.textBoxSqlFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSqlFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBoxSqlFile.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxSqlFile.Location = new System.Drawing.Point(17, 370);
            this.textBoxSqlFile.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSqlFile.Name = "textBoxSqlFile";
            this.textBoxSqlFile.Size = new System.Drawing.Size(650, 20);
            this.textBoxSqlFile.TabIndex = 15;
            this.toolTip1.SetToolTip(this.textBoxSqlFile, "Enter the Filename with your SQL Statements to execute.");
            this.textBoxSqlFile.TextChanged += new System.EventHandler(this.SqlFileTextChanged);
            // 
            // textBoxLogFile
            // 
            this.textBoxLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLogFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBoxLogFile.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxLogFile.Location = new System.Drawing.Point(17, 420);
            this.textBoxLogFile.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLogFile.Name = "textBoxLogFile";
            this.textBoxLogFile.Size = new System.Drawing.Size(650, 20);
            this.textBoxLogFile.TabIndex = 19;
            this.toolTip1.SetToolTip(this.textBoxLogFile, "Enter the Filename where the Output of Oracle SQL*Plus will be saved.");
            this.textBoxLogFile.TextChanged += new System.EventHandler(this.TextBoxLogfileTextChanged);
            // 
            // buttonRunSQL
            // 
            this.buttonRunSQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonRunSQL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRunSQL.BackgroundImage")));
            this.buttonRunSQL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonRunSQL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRunSQL.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRunSQL.Location = new System.Drawing.Point(11, 450);
            this.buttonRunSQL.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRunSQL.Name = "buttonRunSQL";
            this.buttonRunSQL.Size = new System.Drawing.Size(93, 29);
            this.buttonRunSQL.TabIndex = 21;
            this.toolTip1.SetToolTip(this.buttonRunSQL, "Press this Button when you selected at least one Database, the correct DB User an" +
        "d the SQL File to execute in Oracle SQL*Plus.");
            this.buttonRunSQL.UseVisualStyleBackColor = false;
            this.buttonRunSQL.Click += new System.EventHandler(this.ButtonRunSQL);
            // 
            // buttonSqlFile
            // 
            this.buttonSqlFile.AutoSize = true;
            this.buttonSqlFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonSqlFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSqlFile.BackgroundImage")));
            this.buttonSqlFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSqlFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSqlFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSqlFile.Location = new System.Drawing.Point(0, 356);
            this.buttonSqlFile.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSqlFile.Name = "buttonSqlFile";
            this.buttonSqlFile.Size = new System.Drawing.Size(93, 29);
            this.buttonSqlFile.TabIndex = 16;
            this.toolTip1.SetToolTip(this.buttonSqlFile, "Explore your Directories where you may create and select Files including SQL Stat" +
        "ements.");
            this.buttonSqlFile.UseVisualStyleBackColor = false;
            this.buttonSqlFile.Click += new System.EventHandler(this.ButtonSqlFile);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 15000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // checkBoxOptSilent
            // 
            this.checkBoxOptSilent.AutoSize = true;
            this.checkBoxOptSilent.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.checkBoxOptSilent.Location = new System.Drawing.Point(5, 205);
            this.checkBoxOptSilent.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxOptSilent.Name = "checkBoxOptSilent";
            this.checkBoxOptSilent.Size = new System.Drawing.Size(65, 17);
            this.checkBoxOptSilent.TabIndex = 9;
            this.checkBoxOptSilent.Text = "-S Silent";
            this.toolTip1.SetToolTip(this.checkBoxOptSilent, "-S[ILENT] Suppresses all SQL*Plus information and prompt messages.");
            this.checkBoxOptSilent.UseVisualStyleBackColor = true;
            // 
            // checkBoxOptCSV
            // 
            this.checkBoxOptCSV.AutoSize = true;
            this.checkBoxOptCSV.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.checkBoxOptCSV.Location = new System.Drawing.Point(86, 239);
            this.checkBoxOptCSV.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxOptCSV.Name = "checkBoxOptCSV";
            this.checkBoxOptCSV.Size = new System.Drawing.Size(72, 17);
            this.checkBoxOptCSV.TabIndex = 11;
            this.checkBoxOptCSV.Text = "CSV ON  ";
            this.toolTip1.SetToolTip(this.checkBoxOptCSV, "-M[ARKUP] CSV ON  Output from a query will be displayed in CSV format (Version 12" +
        ".2 required).");
            this.checkBoxOptCSV.UseVisualStyleBackColor = true;
            this.checkBoxOptCSV.CheckedChanged += new System.EventHandler(this.CheckBoxOptCSVChanged);
            // 
            // checkBoxOptHTML
            // 
            this.checkBoxOptHTML.AutoSize = true;
            this.checkBoxOptHTML.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.checkBoxOptHTML.Location = new System.Drawing.Point(5, 239);
            this.checkBoxOptHTML.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxOptHTML.Name = "checkBoxOptHTML";
            this.checkBoxOptHTML.Size = new System.Drawing.Size(75, 17);
            this.checkBoxOptHTML.TabIndex = 10;
            this.checkBoxOptHTML.Text = "HTML ON";
            this.toolTip1.SetToolTip(this.checkBoxOptHTML, "-M[ARKUP] HTML ON  Output from a query will be displayed in HTML format.");
            this.checkBoxOptHTML.UseVisualStyleBackColor = true;
            this.checkBoxOptHTML.CheckedChanged += new System.EventHandler(this.CheckBoxOptHTMLChanged);
            // 
            // buttonViewLog
            // 
            this.buttonViewLog.AutoSize = true;
            this.buttonViewLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonViewLog.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonViewLog.BackgroundImage")));
            this.buttonViewLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonViewLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonViewLog.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonViewLog.Location = new System.Drawing.Point(0, 406);
            this.buttonViewLog.Margin = new System.Windows.Forms.Padding(2);
            this.buttonViewLog.Name = "buttonViewLog";
            this.buttonViewLog.Size = new System.Drawing.Size(93, 29);
            this.buttonViewLog.TabIndex = 20;
            this.toolTip1.SetToolTip(this.buttonViewLog, "View the logfile with SQL*Plus Output from earlier runs.");
            this.buttonViewLog.UseVisualStyleBackColor = false;
            this.buttonViewLog.Click += new System.EventHandler(this.ButtonViewLog);
            // 
            // checkBoxLogAppend
            // 
            this.checkBoxLogAppend.AutoSize = true;
            this.checkBoxLogAppend.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.checkBoxLogAppend.Location = new System.Drawing.Point(106, 394);
            this.checkBoxLogAppend.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxLogAppend.Name = "checkBoxLogAppend";
            this.checkBoxLogAppend.Size = new System.Drawing.Size(63, 17);
            this.checkBoxLogAppend.TabIndex = 18;
            this.checkBoxLogAppend.Text = "Append";
            this.toolTip1.SetToolTip(this.checkBoxLogAppend, "Append to existing log file or create a new log file.");
            this.checkBoxLogAppend.UseVisualStyleBackColor = true;
            // 
            // buttonScheduleSQL
            // 
            this.buttonScheduleSQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonScheduleSQL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonScheduleSQL.BackgroundImage")));
            this.buttonScheduleSQL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonScheduleSQL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonScheduleSQL.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonScheduleSQL.Location = new System.Drawing.Point(110, 450);
            this.buttonScheduleSQL.Margin = new System.Windows.Forms.Padding(2);
            this.buttonScheduleSQL.Name = "buttonScheduleSQL";
            this.buttonScheduleSQL.Size = new System.Drawing.Size(93, 29);
            this.buttonScheduleSQL.TabIndex = 22;
            this.toolTip1.SetToolTip(this.buttonScheduleSQL, "Creates a Windows Task Scheduler Job to execute the SQL File later");
            this.buttonScheduleSQL.UseVisualStyleBackColor = false;
            this.buttonScheduleSQL.Click += new System.EventHandler(this.ButtonScheduleSQL);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tabPage1.Controls.Add(this.listViewStatusMessages);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(918, 267);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Status Messages";
            this.toolTip1.SetToolTip(this.tabPage1, "this is ToolTip on toolTip1");
            this.tabPage1.ToolTipText = "this is Tool Tip Text";
            // 
            // listViewStatusMessages
            // 
            this.listViewStatusMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewStatusMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.listViewStatusMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listViewStatusMessages.Font = new System.Drawing.Font("Consolas", 8F);
            this.listViewStatusMessages.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.listViewStatusMessages.GridLines = true;
            this.listViewStatusMessages.HideSelection = false;
            this.listViewStatusMessages.Location = new System.Drawing.Point(2, 4);
            this.listViewStatusMessages.Margin = new System.Windows.Forms.Padding(1);
            this.listViewStatusMessages.MultiSelect = false;
            this.listViewStatusMessages.Name = "listViewStatusMessages";
            this.listViewStatusMessages.Size = new System.Drawing.Size(917, 264);
            this.listViewStatusMessages.TabIndex = 15;
            this.listViewStatusMessages.UseCompatibleStateImageBehavior = false;
            this.listViewStatusMessages.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Date/Time";
            this.columnHeader5.Width = 126;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Database";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Action";
            this.columnHeader7.Width = 160;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Result";
            this.columnHeader8.Width = 526;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tabPage2.Controls.Add(this.labelSessionHistory_Message);
            this.tabPage2.Controls.Add(this.textBoxSessionHistory);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(918, 267);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Session History";
            this.toolTip1.SetToolTip(this.tabPage2, "Trace Records from earlier Sessions.");
            // 
            // labelSessionHistory_Message
            // 
            this.labelSessionHistory_Message.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSessionHistory_Message.AutoSize = true;
            this.labelSessionHistory_Message.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelSessionHistory_Message.Location = new System.Drawing.Point(2, 252);
            this.labelSessionHistory_Message.Name = "labelSessionHistory_Message";
            this.labelSessionHistory_Message.Size = new System.Drawing.Size(0, 13);
            this.labelSessionHistory_Message.TabIndex = 1;
            // 
            // textBoxSessionHistory
            // 
            this.textBoxSessionHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSessionHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBoxSessionHistory.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSessionHistory.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxSessionHistory.Location = new System.Drawing.Point(2, 0);
            this.textBoxSessionHistory.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSessionHistory.Name = "textBoxSessionHistory";
            this.textBoxSessionHistory.Size = new System.Drawing.Size(900, 247);
            this.textBoxSessionHistory.TabIndex = 0;
            this.textBoxSessionHistory.Text = "";
            this.textBoxSessionHistory.WordWrap = false;
            this.textBoxSessionHistory.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.TextBoxSessionHistoryLinkClicked);
            this.textBoxSessionHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxSessionHistory_KeyDown);
            this.textBoxSessionHistory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxSessionHistory_MouseDoubleClick);
            // 
            // timeoutHH
            // 
            this.timeoutHH.Location = new System.Drawing.Point(5, 330);
            this.timeoutHH.Margin = new System.Windows.Forms.Padding(2);
            this.timeoutHH.Maximum = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            this.timeoutHH.Name = "timeoutHH";
            this.timeoutHH.Size = new System.Drawing.Size(41, 20);
            this.timeoutHH.TabIndex = 12;
            this.toolTip1.SetToolTip(this.timeoutHH, "Kill SQL*Plus Session after x hours");
            this.timeoutHH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTimeoutHH);
            // 
            // timeoutMM
            // 
            this.timeoutMM.Location = new System.Drawing.Point(44, 330);
            this.timeoutMM.Margin = new System.Windows.Forms.Padding(2);
            this.timeoutMM.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.timeoutMM.Name = "timeoutMM";
            this.timeoutMM.Size = new System.Drawing.Size(34, 20);
            this.timeoutMM.TabIndex = 13;
            this.toolTip1.SetToolTip(this.timeoutMM, "Kill SQL*Plus Session after x minutes");
            this.timeoutMM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTimeoutMM);
            // 
            // timeoutSS
            // 
            this.timeoutSS.Location = new System.Drawing.Point(74, 330);
            this.timeoutSS.Margin = new System.Windows.Forms.Padding(2);
            this.timeoutSS.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.timeoutSS.Name = "timeoutSS";
            this.timeoutSS.Size = new System.Drawing.Size(34, 20);
            this.timeoutSS.TabIndex = 14;
            this.toolTip1.SetToolTip(this.timeoutSS, "Kill SQL*Plus Session after x seconds.");
            this.timeoutSS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTimeoutSS);
            // 
            // checkBoxOptIgnoreError
            // 
            this.checkBoxOptIgnoreError.AutoSize = true;
            this.checkBoxOptIgnoreError.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.checkBoxOptIgnoreError.Location = new System.Drawing.Point(5, 275);
            this.checkBoxOptIgnoreError.Name = "checkBoxOptIgnoreError";
            this.checkBoxOptIgnoreError.Size = new System.Drawing.Size(116, 17);
            this.checkBoxOptIgnoreError.TabIndex = 32;
            this.checkBoxOptIgnoreError.Text = "Ignore severe Error";
            this.toolTip1.SetToolTip(this.checkBoxOptIgnoreError, "Do not stop the SQL Session when SQLAgain detects a severe Error (ORA-01017 or si" +
        "milar)");
            this.checkBoxOptIgnoreError.UseVisualStyleBackColor = true;
            this.checkBoxOptIgnoreError.CheckedChanged += new System.EventHandler(this.CheckBoxOptIgnoreError_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(0, 188);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "SQL*Plus Options";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(0, 224);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "-M Markup Options";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(14, 499);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(926, 293);
            this.tabControl1.TabIndex = 23;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1SelectedIndexChanged);
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TabControl1MouseClick);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tabPage4.Controls.Add(this.buttonAddFavorites);
            this.tabPage4.Controls.Add(this.listViewFavorites);
            this.tabPage4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(918, 267);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Favorites";
            // 
            // buttonAddFavorites
            // 
            this.buttonAddFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddFavorites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonAddFavorites.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAddFavorites.BackgroundImage")));
            this.buttonAddFavorites.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddFavorites.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonAddFavorites.Location = new System.Drawing.Point(2, 236);
            this.buttonAddFavorites.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddFavorites.Name = "buttonAddFavorites";
            this.buttonAddFavorites.Size = new System.Drawing.Size(110, 29);
            this.buttonAddFavorites.TabIndex = 1;
            this.buttonAddFavorites.UseVisualStyleBackColor = false;
            this.buttonAddFavorites.Click += new System.EventHandler(this.ButtonAddFavorites);
            // 
            // listViewFavorites
            // 
            this.listViewFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFavorites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.listViewFavorites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewFavorites.ContextMenuStrip = this.contextMenuFavorites;
            this.listViewFavorites.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listViewFavorites.FullRowSelect = true;
            this.listViewFavorites.GridLines = true;
            this.listViewFavorites.HideSelection = false;
            this.listViewFavorites.Location = new System.Drawing.Point(2, 2);
            this.listViewFavorites.Margin = new System.Windows.Forms.Padding(2);
            this.listViewFavorites.MultiSelect = false;
            this.listViewFavorites.Name = "listViewFavorites";
            this.listViewFavorites.Size = new System.Drawing.Size(914, 230);
            this.listViewFavorites.TabIndex = 0;
            this.listViewFavorites.UseCompatibleStateImageBehavior = false;
            this.listViewFavorites.View = System.Windows.Forms.View.Details;
            this.listViewFavorites.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewFavoritesColumnClick);
            this.listViewFavorites.DoubleClick += new System.EventHandler(this.ListViewFavoritesDoubleClick);
            this.listViewFavorites.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListViewFavoritesKeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "DB User";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Database";
            this.columnHeader4.Width = 531;
            // 
            // contextMenuFavorites
            // 
            this.contextMenuFavorites.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuFavorites.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.favoritesRun,
            this.favoritesLoad,
            this.favoritesEditFile,
            this.favoritesUpdate,
            this.favoritesDelete});
            this.contextMenuFavorites.Name = "contextMenuStrip3";
            this.contextMenuFavorites.Size = new System.Drawing.Size(116, 114);
            // 
            // favoritesRun
            // 
            this.favoritesRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.favoritesRun.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.favoritesRun.Name = "favoritesRun";
            this.favoritesRun.Size = new System.Drawing.Size(115, 22);
            this.favoritesRun.Text = "Execute";
            this.favoritesRun.Click += new System.EventHandler(this.FavoritesRun);
            // 
            // favoritesLoad
            // 
            this.favoritesLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.favoritesLoad.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.favoritesLoad.Name = "favoritesLoad";
            this.favoritesLoad.Size = new System.Drawing.Size(115, 22);
            this.favoritesLoad.Text = "Load";
            this.favoritesLoad.Click += new System.EventHandler(this.FavoritesLoad);
            // 
            // favoritesEditFile
            // 
            this.favoritesEditFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.favoritesEditFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.favoritesEditFile.Name = "favoritesEditFile";
            this.favoritesEditFile.Size = new System.Drawing.Size(115, 22);
            this.favoritesEditFile.Text = "Edit File";
            this.favoritesEditFile.Click += new System.EventHandler(this.FavoritesEditFile_Click);
            // 
            // favoritesUpdate
            // 
            this.favoritesUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.favoritesUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.favoritesUpdate.Name = "favoritesUpdate";
            this.favoritesUpdate.Size = new System.Drawing.Size(115, 22);
            this.favoritesUpdate.Text = "Update";
            this.favoritesUpdate.Click += new System.EventHandler(this.FavoritesUpdate);
            // 
            // favoritesDelete
            // 
            this.favoritesDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.favoritesDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.favoritesDelete.Name = "favoritesDelete";
            this.favoritesDelete.Size = new System.Drawing.Size(115, 22);
            this.favoritesDelete.Text = "Delete";
            this.favoritesDelete.Click += new System.EventHandler(this.FavoritesDelete);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tabPage3.Controls.Add(this.textBoxAbout);
            this.tabPage3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(918, 267);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "About SQLAgain";
            // 
            // textBoxAbout
            // 
            this.textBoxAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.textBoxAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAbout.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxAbout.Location = new System.Drawing.Point(2, 0);
            this.textBoxAbout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 5);
            this.textBoxAbout.Name = "textBoxAbout";
            this.textBoxAbout.ReadOnly = true;
            this.textBoxAbout.Size = new System.Drawing.Size(900, 247);
            this.textBoxAbout.TabIndex = 0;
            this.textBoxAbout.Text = "";
            this.textBoxAbout.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.TextBoxAboutLink);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonSelectAll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSelectAll.Location = new System.Drawing.Point(0, 0);
            this.buttonSelectAll.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(110, 24);
            this.buttonSelectAll.TabIndex = 2;
            this.buttonSelectAll.Text = "Select All";
            this.buttonSelectAll.UseVisualStyleBackColor = false;
            this.buttonSelectAll.Click += new System.EventHandler(this.ButtonSelectAll);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.listView1.CheckBoxes = true;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(14, 28);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(223, 302);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView1_ItemChecked);
            this.listView1.MouseLeave += new System.EventHandler(this.ListView1MouseLeave);
            // 
            // buttonSelectGroup1
            // 
            this.buttonSelectGroup1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonSelectGroup1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSelectGroup1.Location = new System.Drawing.Point(0, 28);
            this.buttonSelectGroup1.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSelectGroup1.Name = "buttonSelectGroup1";
            this.buttonSelectGroup1.Size = new System.Drawing.Size(110, 24);
            this.buttonSelectGroup1.TabIndex = 3;
            this.buttonSelectGroup1.Text = "Select Group 1";
            this.buttonSelectGroup1.UseVisualStyleBackColor = false;
            this.buttonSelectGroup1.Click += new System.EventHandler(this.ButtonSelectGroup1);
            // 
            // buttonSelectGroup2
            // 
            this.buttonSelectGroup2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonSelectGroup2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSelectGroup2.Location = new System.Drawing.Point(0, 56);
            this.buttonSelectGroup2.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSelectGroup2.Name = "buttonSelectGroup2";
            this.buttonSelectGroup2.Size = new System.Drawing.Size(110, 24);
            this.buttonSelectGroup2.TabIndex = 4;
            this.buttonSelectGroup2.Text = "Select Group 2";
            this.buttonSelectGroup2.UseVisualStyleBackColor = false;
            this.buttonSelectGroup2.Click += new System.EventHandler(this.ButtonSelectGroup2);
            // 
            // buttonSelectGroup3
            // 
            this.buttonSelectGroup3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonSelectGroup3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSelectGroup3.Location = new System.Drawing.Point(0, 84);
            this.buttonSelectGroup3.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSelectGroup3.Name = "buttonSelectGroup3";
            this.buttonSelectGroup3.Size = new System.Drawing.Size(110, 24);
            this.buttonSelectGroup3.TabIndex = 5;
            this.buttonSelectGroup3.Text = "Select Group 3";
            this.buttonSelectGroup3.UseVisualStyleBackColor = false;
            this.buttonSelectGroup3.Click += new System.EventHandler(this.ButtonSelectGroup3);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1__RunWorkerCompleted);
            // 
            // buttonCancelSQL
            // 
            this.buttonCancelSQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonCancelSQL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCancelSQL.BackgroundImage")));
            this.buttonCancelSQL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCancelSQL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancelSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelSQL.Location = new System.Drawing.Point(207, 450);
            this.buttonCancelSQL.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancelSQL.Name = "buttonCancelSQL";
            this.buttonCancelSQL.Size = new System.Drawing.Size(93, 29);
            this.buttonCancelSQL.TabIndex = 21;
            this.buttonCancelSQL.UseVisualStyleBackColor = false;
            this.buttonCancelSQL.Visible = false;
            this.buttonCancelSQL.Click += new System.EventHandler(this.Button_CancelSQL_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(145)))));
            this.progressBar1.Location = new System.Drawing.Point(14, 488);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.MarqueeAnimationSpeed = 30;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(926, 4);
            this.progressBar1.TabIndex = 23;
            this.progressBar1.Visible = false;
            // 
            // contextMenuSessionHistory
            // 
            this.contextMenuSessionHistory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuSessionHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sessionHistoryEdit,
            this.sessionHistoryRefresh});
            this.contextMenuSessionHistory.Name = "contextMenuStrip1";
            this.contextMenuSessionHistory.Size = new System.Drawing.Size(175, 48);
            this.contextMenuSessionHistory.Text = "Edit SessionHistory";
            // 
            // sessionHistoryEdit
            // 
            this.sessionHistoryEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.sessionHistoryEdit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sessionHistoryEdit.Name = "sessionHistoryEdit";
            this.sessionHistoryEdit.Size = new System.Drawing.Size(174, 22);
            this.sessionHistoryEdit.Text = "Edit SessionHistory";
            this.sessionHistoryEdit.Click += new System.EventHandler(this.SessionHistoryEdit);
            // 
            // sessionHistoryRefresh
            // 
            this.sessionHistoryRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.sessionHistoryRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sessionHistoryRefresh.Name = "sessionHistoryRefresh";
            this.sessionHistoryRefresh.Size = new System.Drawing.Size(174, 22);
            this.sessionHistoryRefresh.Text = "Refresh";
            this.sessionHistoryRefresh.Click += new System.EventHandler(this.SessionHistoryRefresh);
            // 
            // contextMenuStatusMessages
            // 
            this.contextMenuStatusMessages.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStatusMessages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMessagesClear});
            this.contextMenuStatusMessages.Name = "contextMenuStrip3";
            this.contextMenuStatusMessages.Size = new System.Drawing.Size(191, 26);
            // 
            // statusMessagesClear
            // 
            this.statusMessagesClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.statusMessagesClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.statusMessagesClear.Name = "statusMessagesClear";
            this.statusMessagesClear.Size = new System.Drawing.Size(190, 22);
            this.statusMessagesClear.Text = "Clear Status Messages";
            this.statusMessagesClear.Click += new System.EventHandler(this.StatusMessagesClear);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 296);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Timeout for SQL*Plus";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(74, 313);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Sec.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label7.Location = new System.Drawing.Point(45, 313);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Min.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label8.Location = new System.Drawing.Point(5, 313);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Hours";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.checkBoxOptIgnoreError);
            this.panel1.Controls.Add(this.buttonTNSPing);
            this.panel1.Controls.Add(this.buttonOptions);
            this.panel1.Controls.Add(this.listBoxUser);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.timeoutSS);
            this.panel1.Controls.Add(this.timeoutHH);
            this.panel1.Controls.Add(this.timeoutMM);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.checkBoxOptSilent);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.checkBoxOptHTML);
            this.panel1.Controls.Add(this.checkBoxOptCSV);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonSqlFile);
            this.panel1.Controls.Add(this.buttonViewLog);
            this.panel1.Location = new System.Drawing.Point(673, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 469);
            this.panel1.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(0, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Error Condition";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonSelectAll);
            this.panel2.Controls.Add(this.buttonSelectGroup1);
            this.panel2.Controls.Add(this.buttonSelectGroup2);
            this.panel2.Controls.Add(this.buttonSelectGroup3);
            this.panel2.Location = new System.Drawing.Point(271, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(112, 145);
            this.panel2.TabIndex = 32;
            // 
            // labelDBsSelected
            // 
            this.labelDBsSelected.AutoSize = true;
            this.labelDBsSelected.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelDBsSelected.Location = new System.Drawing.Point(271, 188);
            this.labelDBsSelected.Name = "labelDBsSelected";
            this.labelDBsSelected.Size = new System.Drawing.Size(0, 13);
            this.labelDBsSelected.TabIndex = 33;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(954, 791);
            this.Controls.Add(this.labelDBsSelected);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonCancelSQL);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonScheduleSQL);
            this.Controls.Add(this.checkBoxLogAppend);
            this.Controls.Add(this.buttonRunSQL);
            this.Controls.Add(this.textBoxLogFile);
            this.Controls.Add(this.textBoxSqlFile);
            this.Controls.Add(this.checkBoxLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelDB);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.helpProvider1.SetHelpString(this, "das ist keine hilfe");
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "SQL again and again";
            this.toolTip1.SetToolTip(this, "Use Oracle SQL*Plus to excute one File with SQL Statements in multiple Databases." +
        "");
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1FormClosing);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutHH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutMM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutSS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.contextMenuFavorites.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.contextMenuSessionHistory.ResumeLayout(false);
            this.contextMenuStatusMessages.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxUser;
        private System.Windows.Forms.Button buttonOptions;
        private System.Windows.Forms.Button buttonTNSPing;
        private System.Windows.Forms.TextBox textBoxSqlFile;
        private System.Windows.Forms.TextBox textBoxLogFile;
        private System.Windows.Forms.Button buttonRunSQL;
        private System.Windows.Forms.Button buttonSqlFile;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBoxOptSilent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxOptCSV;
        private System.Windows.Forms.CheckBox checkBoxOptHTML;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button buttonViewLog;
        private System.Windows.Forms.CheckBox checkBoxLogAppend;
        private System.Windows.Forms.Button buttonScheduleSQL;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox textBoxAbout;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.RichTextBox textBoxSessionHistory;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonSelectGroup1;
        private System.Windows.Forms.Button buttonSelectGroup2;
        private System.Windows.Forms.Button buttonSelectGroup3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonCancelSQL;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuSessionHistory;
        private System.Windows.Forms.ToolStripMenuItem sessionHistoryEdit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStatusMessages;
        private System.Windows.Forms.ToolStripMenuItem statusMessagesClear;
        private System.Windows.Forms.ToolStripMenuItem sessionHistoryRefresh;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView listViewFavorites;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button buttonAddFavorites;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip contextMenuFavorites;
        private System.Windows.Forms.ToolStripMenuItem favoritesLoad;
        private System.Windows.Forms.ToolStripMenuItem favoritesEditFile;
        private System.Windows.Forms.ToolStripMenuItem favoritesUpdate;
        private System.Windows.Forms.ToolStripMenuItem favoritesDelete;
        private System.Windows.Forms.ToolStripMenuItem favoritesRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown timeoutHH;
        private System.Windows.Forms.NumericUpDown timeoutMM;
        private System.Windows.Forms.NumericUpDown timeoutSS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView listViewStatusMessages;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBoxOptIgnoreError;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelDBsSelected;
        private System.Windows.Forms.Label labelSessionHistory_Message;
    }
}

