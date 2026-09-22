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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelDB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxLog = new System.Windows.Forms.CheckBox();
            this.listBox_User = new System.Windows.Forms.ListBox();
            this.buttonTNSPing = new System.Windows.Forms.Button();
            this.textBox_SqlFile = new System.Windows.Forms.TextBox();
            this.textBox_LogFile = new System.Windows.Forms.TextBox();
            this.buttonRunSQL = new System.Windows.Forms.Button();
            this.buttonSqlFile = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxOptSilent = new System.Windows.Forms.CheckBox();
            this.checkBoxOptCSV = new System.Windows.Forms.CheckBox();
            this.checkBoxOptHTML = new System.Windows.Forms.CheckBox();
            this.buttonViewLog = new System.Windows.Forms.Button();
            this.checkBoxLogAppend = new System.Windows.Forms.CheckBox();
            this.buttonScheduleSQL = new System.Windows.Forms.Button();
            this.tabPageMessages = new System.Windows.Forms.TabPage();
            this.listViewStatusMessages = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageHistory = new System.Windows.Forms.TabPage();
            this.textBoxSessionHistory = new System.Windows.Forms.RichTextBox();
            this.contextMenuSessionHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sessionHistoryEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionHistoryRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.timeoutHH = new System.Windows.Forms.NumericUpDown();
            this.timeoutMM = new System.Windows.Forms.NumericUpDown();
            this.timeoutSS = new System.Windows.Forms.NumericUpDown();
            this.checkBoxOptIgnoreError = new System.Windows.Forms.CheckBox();
            this.listView_DBGroups = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox_OptTask_Username = new System.Windows.Forms.TextBox();
            this.button_OptUpdate_Update = new System.Windows.Forms.Button();
            this.textBox_Favorites_NewDBs = new System.Windows.Forms.TextBox();
            this.textBox_Favorites_NewUser = new System.Windows.Forms.TextBox();
            this.textBox_Favorites_NewFile = new System.Windows.Forms.TextBox();
            this.textBox_Favorites_NewDesc = new System.Windows.Forms.TextBox();
            this.button_Favorites_Add = new System.Windows.Forms.Button();
            this.button_OptMail_Test = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageFavorites = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
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
            this.favoritesMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.favoritesMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageOptions = new System.Windows.Forms.TabPage();
            this.tabControloptions = new System.Windows.Forms.TabControl();
            this.tabPageOptionsEnvironment = new System.Windows.Forms.TabPage();
            this.groupBox_OptEnv3 = new System.Windows.Forms.GroupBox();
            this.checkBox_OptEnv_Mode = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox_OptEnv2 = new System.Windows.Forms.GroupBox();
            this.hidePasswords = new System.Windows.Forms.CheckBox();
            this.label31 = new System.Windows.Forms.Label();
            this.button_OptEnv_SqlPlusPath = new System.Windows.Forms.Button();
            this.textBox_OptEnv_SqlPlusPath = new System.Windows.Forms.TextBox();
            this.groupBox_OptEnv1 = new System.Windows.Forms.GroupBox();
            this.button_OptEnv_TNS_ADMIN = new System.Windows.Forms.Button();
            this.button_OptEnv_SQLPATH = new System.Windows.Forms.Button();
            this.textBox_OptEnv_SQLPATH = new System.Windows.Forms.TextBox();
            this.textBox_OptEnv_TNS_ADMIN = new System.Windows.Forms.TextBox();
            this.textBox_OptEnv_NLS_LANG = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPageOptionsDBs = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_OptDBGroup_NewColor = new System.Windows.Forms.TextBox();
            this.textBox_OptDBGroup_NewRegExp = new System.Windows.Forms.TextBox();
            this.textBox_OptDBGroup_NewName = new System.Windows.Forms.TextBox();
            this.button_OptDBGroup_Add = new System.Windows.Forms.Button();
            this.dataGridView_DBGroups = new System.Windows.Forms.DataGridView();
            this.contextMenuOptDBGroups = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuOptDBGroup_Up = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuOptDBGroup_Down = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_OptDBGroup_ExcludeDBs = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPageOptionsDBUser = new System.Windows.Forms.TabPage();
            this.groupBox_OptDBUser = new System.Windows.Forms.GroupBox();
            this.checkBox_OptDBUser_NewSYSDBA = new System.Windows.Forms.CheckBox();
            this.textBox_OptDBUser_NewPassword = new System.Windows.Forms.TextBox();
            this.textBox_OptDBUser_NewSchema = new System.Windows.Forms.TextBox();
            this.textBox_OptDBUser_NewUser = new System.Windows.Forms.TextBox();
            this.buttonOptDBUser_Add = new System.Windows.Forms.Button();
            this.dataGridView_DBUsers = new System.Windows.Forms.DataGridView();
            this.contextMenuOptDBUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuOptDBUser_Up = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuOptDBUser_Down = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageOptionsTaskScheduler = new System.Windows.Forms.TabPage();
            this.groupBox_OptJobScheduler = new System.Windows.Forms.GroupBox();
            this.textBox_OptTask_Password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageOptionsMail = new System.Windows.Forms.TabPage();
            this.groupBox_OptMail = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_OptMail_Port = new System.Windows.Forms.MaskedTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.checkBox_OptMail_EnableSSL = new System.Windows.Forms.CheckBox();
            this.textBox_OptMail_MailReceiver = new System.Windows.Forms.TextBox();
            this.textBox_OptMail_MailSender = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_OptMail_Password = new System.Windows.Forms.TextBox();
            this.textBox_OptMail_User = new System.Windows.Forms.TextBox();
            this.textBox_OptMail_Server = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPageOptionsCheckForUpdates = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.linkCheck4Update = new System.Windows.Forms.LinkLabel();
            this.label_OptUpdate_Message3 = new System.Windows.Forms.Label();
            this.label_OptUpdate_Message2 = new System.Windows.Forms.Label();
            this.label_OptUpdate_Message1 = new System.Windows.Forms.Label();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.textBoxAbout = new System.Windows.Forms.RichTextBox();
            this.listView_DBs = new System.Windows.Forms.ListView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonCancelSQL = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.contextMenuStatusMessages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusMessagesClear = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.labelDBsSelected = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabPageMessages.SuspendLayout();
            this.tabPageHistory.SuspendLayout();
            this.contextMenuSessionHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutHH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutMM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutSS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageFavorites.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.contextMenuFavorites.SuspendLayout();
            this.tabPageOptions.SuspendLayout();
            this.tabControloptions.SuspendLayout();
            this.tabPageOptionsEnvironment.SuspendLayout();
            this.groupBox_OptEnv3.SuspendLayout();
            this.groupBox_OptEnv2.SuspendLayout();
            this.groupBox_OptEnv1.SuspendLayout();
            this.tabPageOptionsDBs.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DBGroups)).BeginInit();
            this.contextMenuOptDBGroups.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPageOptionsDBUser.SuspendLayout();
            this.groupBox_OptDBUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DBUsers)).BeginInit();
            this.contextMenuOptDBUser.SuspendLayout();
            this.tabPageOptionsTaskScheduler.SuspendLayout();
            this.groupBox_OptJobScheduler.SuspendLayout();
            this.tabPageOptionsMail.SuspendLayout();
            this.groupBox_OptMail.SuspendLayout();
            this.tabPageOptionsCheckForUpdates.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tabPageAbout.SuspendLayout();
            this.contextMenuStatusMessages.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDB
            // 
            this.labelDB.AutoSize = true;
            this.labelDB.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelDB.Location = new System.Drawing.Point(10, 300);
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
            this.label2.Location = new System.Drawing.Point(11, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SQL Filename";
            // 
            // checkBoxLog
            // 
            this.checkBoxLog.AutoSize = true;
            this.checkBoxLog.Checked = true;
            this.checkBoxLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLog.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.checkBoxLog.Location = new System.Drawing.Point(100, 51);
            this.checkBoxLog.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxLog.Name = "checkBoxLog";
            this.checkBoxLog.Size = new System.Drawing.Size(75, 17);
            this.checkBoxLog.TabIndex = 2;
            this.checkBoxLog.Text = "Log to File";
            this.checkBoxLog.UseVisualStyleBackColor = true;
            this.checkBoxLog.CheckedChanged += new System.EventHandler(this.CheckBoxLogChanged);
            // 
            // listBox_User
            // 
            this.listBox_User.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.listBox_User.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_User.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.listBox_User.FormattingEnabled = true;
            this.listBox_User.Location = new System.Drawing.Point(10, 18);
            this.listBox_User.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_User.Name = "listBox_User";
            this.listBox_User.Size = new System.Drawing.Size(105, 65);
            this.listBox_User.TabIndex = 0;
            this.listBox_User.SelectedIndexChanged += new System.EventHandler(this.ListBoxUserChanged);
            // 
            // buttonTNSPing
            // 
            this.buttonTNSPing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonTNSPing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTNSPing.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTNSPing.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonTNSPing.Image = ((System.Drawing.Image)(resources.GetObject("buttonTNSPing.Image")));
            this.buttonTNSPing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTNSPing.Location = new System.Drawing.Point(475, 255);
            this.buttonTNSPing.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTNSPing.Name = "buttonTNSPing";
            this.buttonTNSPing.Size = new System.Drawing.Size(76, 30);
            this.buttonTNSPing.TabIndex = 2;
            this.buttonTNSPing.Text = "Ping DB";
            this.buttonTNSPing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonTNSPing.UseVisualStyleBackColor = false;
            this.buttonTNSPing.Click += new System.EventHandler(this.ButtonTNSPing);
            // 
            // textBox_SqlFile
            // 
            this.textBox_SqlFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_SqlFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_SqlFile.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_SqlFile.Location = new System.Drawing.Point(100, 24);
            this.textBox_SqlFile.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SqlFile.Name = "textBox_SqlFile";
            this.textBox_SqlFile.Size = new System.Drawing.Size(356, 20);
            this.textBox_SqlFile.TabIndex = 0;
            this.textBox_SqlFile.TextChanged += new System.EventHandler(this.TextBox_SqlFile_TextChanged);
            // 
            // textBox_LogFile
            // 
            this.textBox_LogFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_LogFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_LogFile.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_LogFile.Location = new System.Drawing.Point(100, 68);
            this.textBox_LogFile.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_LogFile.Name = "textBox_LogFile";
            this.textBox_LogFile.Size = new System.Drawing.Size(356, 20);
            this.textBox_LogFile.TabIndex = 4;
            // 
            // buttonRunSQL
            // 
            this.buttonRunSQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonRunSQL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonRunSQL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRunSQL.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRunSQL.Image = ((System.Drawing.Image)(resources.GetObject("buttonRunSQL.Image")));
            this.buttonRunSQL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRunSQL.Location = new System.Drawing.Point(9, 380);
            this.buttonRunSQL.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRunSQL.Name = "buttonRunSQL";
            this.buttonRunSQL.Size = new System.Drawing.Size(93, 29);
            this.buttonRunSQL.TabIndex = 0;
            this.buttonRunSQL.Text = "Execute";
            this.buttonRunSQL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRunSQL.UseVisualStyleBackColor = false;
            this.buttonRunSQL.Click += new System.EventHandler(this.ButtonRunSQL);
            // 
            // buttonSqlFile
            // 
            this.buttonSqlFile.AutoSize = true;
            this.buttonSqlFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonSqlFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSqlFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSqlFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSqlFile.Image = ((System.Drawing.Image)(resources.GetObject("buttonSqlFile.Image")));
            this.buttonSqlFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSqlFile.Location = new System.Drawing.Point(475, 23);
            this.buttonSqlFile.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSqlFile.Name = "buttonSqlFile";
            this.buttonSqlFile.Size = new System.Drawing.Size(76, 30);
            this.buttonSqlFile.TabIndex = 1;
            this.buttonSqlFile.Text = "Open";
            this.buttonSqlFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.checkBoxOptSilent.Checked = true;
            this.checkBoxOptSilent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOptSilent.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.checkBoxOptSilent.Location = new System.Drawing.Point(10, 18);
            this.checkBoxOptSilent.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxOptSilent.Name = "checkBoxOptSilent";
            this.checkBoxOptSilent.Size = new System.Drawing.Size(65, 17);
            this.checkBoxOptSilent.TabIndex = 0;
            this.checkBoxOptSilent.Text = "-S Silent";
            this.toolTip1.SetToolTip(this.checkBoxOptSilent, "-S[ILENT] Suppresses all SQL*Plus information and prompt messages.");
            this.checkBoxOptSilent.UseVisualStyleBackColor = true;
            // 
            // checkBoxOptCSV
            // 
            this.checkBoxOptCSV.AutoSize = true;
            this.checkBoxOptCSV.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.checkBoxOptCSV.Location = new System.Drawing.Point(100, 60);
            this.checkBoxOptCSV.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxOptCSV.Name = "checkBoxOptCSV";
            this.checkBoxOptCSV.Size = new System.Drawing.Size(72, 17);
            this.checkBoxOptCSV.TabIndex = 2;
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
            this.checkBoxOptHTML.Location = new System.Drawing.Point(10, 60);
            this.checkBoxOptHTML.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxOptHTML.Name = "checkBoxOptHTML";
            this.checkBoxOptHTML.Size = new System.Drawing.Size(75, 17);
            this.checkBoxOptHTML.TabIndex = 1;
            this.checkBoxOptHTML.Text = "HTML ON";
            this.toolTip1.SetToolTip(this.checkBoxOptHTML, "-M[ARKUP] HTML ON  Output from a query will be displayed in HTML format.");
            this.checkBoxOptHTML.UseVisualStyleBackColor = true;
            this.checkBoxOptHTML.CheckedChanged += new System.EventHandler(this.CheckBoxOptHTMLChanged);
            // 
            // buttonViewLog
            // 
            this.buttonViewLog.AutoSize = true;
            this.buttonViewLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonViewLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonViewLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonViewLog.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonViewLog.Image = ((System.Drawing.Image)(resources.GetObject("buttonViewLog.Image")));
            this.buttonViewLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonViewLog.Location = new System.Drawing.Point(475, 63);
            this.buttonViewLog.Margin = new System.Windows.Forms.Padding(2);
            this.buttonViewLog.Name = "buttonViewLog";
            this.buttonViewLog.Size = new System.Drawing.Size(76, 30);
            this.buttonViewLog.TabIndex = 5;
            this.buttonViewLog.Text = "Open";
            this.buttonViewLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.buttonViewLog, "View the Logfile ");
            this.buttonViewLog.UseVisualStyleBackColor = false;
            this.buttonViewLog.Click += new System.EventHandler(this.ButtonViewLog);
            // 
            // checkBoxLogAppend
            // 
            this.checkBoxLogAppend.AutoSize = true;
            this.checkBoxLogAppend.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.checkBoxLogAppend.Location = new System.Drawing.Point(179, 51);
            this.checkBoxLogAppend.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxLogAppend.Name = "checkBoxLogAppend";
            this.checkBoxLogAppend.Size = new System.Drawing.Size(132, 17);
            this.checkBoxLogAppend.TabIndex = 3;
            this.checkBoxLogAppend.Text = "Append to existing File";
            this.toolTip1.SetToolTip(this.checkBoxLogAppend, "Append to existing log file or create a new log file.");
            this.checkBoxLogAppend.UseVisualStyleBackColor = true;
            // 
            // buttonScheduleSQL
            // 
            this.buttonScheduleSQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonScheduleSQL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonScheduleSQL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonScheduleSQL.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonScheduleSQL.Image = ((System.Drawing.Image)(resources.GetObject("buttonScheduleSQL.Image")));
            this.buttonScheduleSQL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonScheduleSQL.Location = new System.Drawing.Point(9, 421);
            this.buttonScheduleSQL.Margin = new System.Windows.Forms.Padding(2);
            this.buttonScheduleSQL.Name = "buttonScheduleSQL";
            this.buttonScheduleSQL.Size = new System.Drawing.Size(93, 29);
            this.buttonScheduleSQL.TabIndex = 2;
            this.buttonScheduleSQL.Text = "Schedule";
            this.buttonScheduleSQL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.buttonScheduleSQL, "Creates a Windows Task Scheduler Job to execute the SQL File later");
            this.buttonScheduleSQL.UseVisualStyleBackColor = false;
            this.buttonScheduleSQL.Click += new System.EventHandler(this.ButtonScheduleSQL);
            // 
            // tabPageMessages
            // 
            this.tabPageMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tabPageMessages.Controls.Add(this.listViewStatusMessages);
            this.tabPageMessages.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPageMessages.Location = new System.Drawing.Point(4, 22);
            this.tabPageMessages.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageMessages.Name = "tabPageMessages";
            this.tabPageMessages.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageMessages.Size = new System.Drawing.Size(918, 299);
            this.tabPageMessages.TabIndex = 0;
            this.tabPageMessages.Text = "Messages - Log";
            this.toolTip1.SetToolTip(this.tabPageMessages, "this is ToolTip on toolTip1");
            this.tabPageMessages.ToolTipText = "this is Tool Tip Text";
            // 
            // listViewStatusMessages
            // 
            this.listViewStatusMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewStatusMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.listViewStatusMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewStatusMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listViewStatusMessages.Font = new System.Drawing.Font("Consolas", 8F);
            this.listViewStatusMessages.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.listViewStatusMessages.HideSelection = false;
            this.listViewStatusMessages.Location = new System.Drawing.Point(2, 4);
            this.listViewStatusMessages.Margin = new System.Windows.Forms.Padding(1);
            this.listViewStatusMessages.MultiSelect = false;
            this.listViewStatusMessages.Name = "listViewStatusMessages";
            this.listViewStatusMessages.Size = new System.Drawing.Size(918, 299);
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
            // tabPageHistory
            // 
            this.tabPageHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tabPageHistory.Controls.Add(this.textBoxSessionHistory);
            this.tabPageHistory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPageHistory.Location = new System.Drawing.Point(4, 22);
            this.tabPageHistory.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageHistory.Name = "tabPageHistory";
            this.tabPageHistory.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageHistory.Size = new System.Drawing.Size(918, 299);
            this.tabPageHistory.TabIndex = 1;
            this.tabPageHistory.Text = "Session History";
            this.toolTip1.SetToolTip(this.tabPageHistory, "Trace Records from earlier Sessions.");
            // 
            // textBoxSessionHistory
            // 
            this.textBoxSessionHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSessionHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.textBoxSessionHistory.ContextMenuStrip = this.contextMenuSessionHistory;
            this.textBoxSessionHistory.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSessionHistory.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxSessionHistory.Location = new System.Drawing.Point(2, 0);
            this.textBoxSessionHistory.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSessionHistory.Name = "textBoxSessionHistory";
            this.textBoxSessionHistory.Size = new System.Drawing.Size(918, 299);
            this.textBoxSessionHistory.TabIndex = 0;
            this.textBoxSessionHistory.Text = "";
            this.textBoxSessionHistory.WordWrap = false;
            this.textBoxSessionHistory.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.TextBoxSessionHistoryLinkClicked);
            this.textBoxSessionHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxSessionHistory_KeyDown);
            this.textBoxSessionHistory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxSessionHistory_MouseDoubleClick);
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
            this.sessionHistoryRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.sessionHistoryRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sessionHistoryRefresh.Name = "sessionHistoryRefresh";
            this.sessionHistoryRefresh.Size = new System.Drawing.Size(174, 22);
            this.sessionHistoryRefresh.Text = "Refresh";
            this.sessionHistoryRefresh.Click += new System.EventHandler(this.SessionHistoryRefresh);
            // 
            // timeoutHH
            // 
            this.timeoutHH.Location = new System.Drawing.Point(10, 75);
            this.timeoutHH.Margin = new System.Windows.Forms.Padding(2);
            this.timeoutHH.Maximum = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            this.timeoutHH.Name = "timeoutHH";
            this.timeoutHH.Size = new System.Drawing.Size(41, 20);
            this.timeoutHH.TabIndex = 7;
            this.toolTip1.SetToolTip(this.timeoutHH, "Kill SQL*Plus Session after x hours");
            this.timeoutHH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTimeoutHH);
            // 
            // timeoutMM
            // 
            this.timeoutMM.Location = new System.Drawing.Point(55, 75);
            this.timeoutMM.Margin = new System.Windows.Forms.Padding(2);
            this.timeoutMM.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.timeoutMM.Name = "timeoutMM";
            this.timeoutMM.Size = new System.Drawing.Size(34, 20);
            this.timeoutMM.TabIndex = 0;
            this.toolTip1.SetToolTip(this.timeoutMM, "Kill SQL*Plus Session after x minutes");
            this.timeoutMM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTimeoutMM);
            // 
            // timeoutSS
            // 
            this.timeoutSS.Location = new System.Drawing.Point(92, 75);
            this.timeoutSS.Margin = new System.Windows.Forms.Padding(2);
            this.timeoutSS.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.timeoutSS.Name = "timeoutSS";
            this.timeoutSS.Size = new System.Drawing.Size(34, 20);
            this.timeoutSS.TabIndex = 1;
            this.toolTip1.SetToolTip(this.timeoutSS, "Kill SQL*Plus Session after x seconds.");
            this.timeoutSS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressTimeoutSS);
            // 
            // checkBoxOptIgnoreError
            // 
            this.checkBoxOptIgnoreError.AutoSize = true;
            this.checkBoxOptIgnoreError.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.checkBoxOptIgnoreError.Location = new System.Drawing.Point(10, 18);
            this.checkBoxOptIgnoreError.Name = "checkBoxOptIgnoreError";
            this.checkBoxOptIgnoreError.Size = new System.Drawing.Size(116, 17);
            this.checkBoxOptIgnoreError.TabIndex = 0;
            this.checkBoxOptIgnoreError.Text = "Ignore severe Error";
            this.toolTip1.SetToolTip(this.checkBoxOptIgnoreError, "Do not stop the SQL Session when SQLAgain detects a severe Error (ORA-01017 or si" +
        "milar)");
            this.checkBoxOptIgnoreError.UseVisualStyleBackColor = true;
            this.checkBoxOptIgnoreError.CheckedChanged += new System.EventHandler(this.CheckBoxOptIgnoreError_CheckedChanged);
            // 
            // listView_DBGroups
            // 
            this.listView_DBGroups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.listView_DBGroups.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_DBGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10});
            this.listView_DBGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_DBGroups.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.listView_DBGroups.FullRowSelect = true;
            this.listView_DBGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_DBGroups.HideSelection = false;
            this.listView_DBGroups.Location = new System.Drawing.Point(270, 40);
            this.listView_DBGroups.Margin = new System.Windows.Forms.Padding(2);
            this.listView_DBGroups.Name = "listView_DBGroups";
            this.listView_DBGroups.Size = new System.Drawing.Size(144, 166);
            this.listView_DBGroups.TabIndex = 1;
            this.toolTip1.SetToolTip(this.listView_DBGroups, "Select a Group of Databases");
            this.listView_DBGroups.UseCompatibleStateImageBehavior = false;
            this.listView_DBGroups.View = System.Windows.Forms.View.Details;
            this.listView_DBGroups.SelectedIndexChanged += new System.EventHandler(this.ListView_DBGroups_SelectedIndexChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Group";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "DBs";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader10.Width = 44;
            // 
            // textBox_OptTask_Username
            // 
            this.textBox_OptTask_Username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptTask_Username.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptTask_Username.Location = new System.Drawing.Point(100, 24);
            this.textBox_OptTask_Username.Name = "textBox_OptTask_Username";
            this.textBox_OptTask_Username.Size = new System.Drawing.Size(356, 20);
            this.textBox_OptTask_Username.TabIndex = 35;
            this.toolTip1.SetToolTip(this.textBox_OptTask_Username, "When running the Task, use the following User Account");
            // 
            // button_OptUpdate_Update
            // 
            this.button_OptUpdate_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.button_OptUpdate_Update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_OptUpdate_Update.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_OptUpdate_Update.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_OptUpdate_Update.Image = ((System.Drawing.Image)(resources.GetObject("button_OptUpdate_Update.Image")));
            this.button_OptUpdate_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_OptUpdate_Update.Location = new System.Drawing.Point(605, 126);
            this.button_OptUpdate_Update.Margin = new System.Windows.Forms.Padding(2);
            this.button_OptUpdate_Update.Name = "button_OptUpdate_Update";
            this.button_OptUpdate_Update.Size = new System.Drawing.Size(93, 29);
            this.button_OptUpdate_Update.TabIndex = 23;
            this.button_OptUpdate_Update.Text = "Update";
            this.button_OptUpdate_Update.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.button_OptUpdate_Update, "Download and Update to latest Version");
            this.button_OptUpdate_Update.UseVisualStyleBackColor = false;
            this.button_OptUpdate_Update.Click += new System.EventHandler(this.Button_OptUpdate_Update_Click);
            // 
            // textBox_Favorites_NewDBs
            // 
            this.textBox_Favorites_NewDBs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_Favorites_NewDBs.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_Favorites_NewDBs.Location = new System.Drawing.Point(550, 16);
            this.textBox_Favorites_NewDBs.Name = "textBox_Favorites_NewDBs";
            this.textBox_Favorites_NewDBs.ReadOnly = true;
            this.textBox_Favorites_NewDBs.Size = new System.Drawing.Size(274, 20);
            this.textBox_Favorites_NewDBs.TabIndex = 5;
            this.toolTip1.SetToolTip(this.textBox_Favorites_NewDBs, "List of Selected Databases");
            // 
            // textBox_Favorites_NewUser
            // 
            this.textBox_Favorites_NewUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_Favorites_NewUser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_Favorites_NewUser.Location = new System.Drawing.Point(450, 16);
            this.textBox_Favorites_NewUser.Name = "textBox_Favorites_NewUser";
            this.textBox_Favorites_NewUser.ReadOnly = true;
            this.textBox_Favorites_NewUser.Size = new System.Drawing.Size(95, 20);
            this.textBox_Favorites_NewUser.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textBox_Favorites_NewUser, "Name of Selected DB User");
            // 
            // textBox_Favorites_NewFile
            // 
            this.textBox_Favorites_NewFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_Favorites_NewFile.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_Favorites_NewFile.Location = new System.Drawing.Point(295, 16);
            this.textBox_Favorites_NewFile.Name = "textBox_Favorites_NewFile";
            this.textBox_Favorites_NewFile.ReadOnly = true;
            this.textBox_Favorites_NewFile.Size = new System.Drawing.Size(150, 20);
            this.textBox_Favorites_NewFile.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textBox_Favorites_NewFile, "Copy of above SQL Filename");
            // 
            // textBox_Favorites_NewDesc
            // 
            this.textBox_Favorites_NewDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_Favorites_NewDesc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_Favorites_NewDesc.Location = new System.Drawing.Point(5, 16);
            this.textBox_Favorites_NewDesc.Name = "textBox_Favorites_NewDesc";
            this.textBox_Favorites_NewDesc.Size = new System.Drawing.Size(285, 20);
            this.textBox_Favorites_NewDesc.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBox_Favorites_NewDesc, "Description of the Favorite-Entry");
            this.textBox_Favorites_NewDesc.Enter += new System.EventHandler(this.TextBox_Favorites_NewDesc_Enter);
            // 
            // button_Favorites_Add
            // 
            this.button_Favorites_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Favorites_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.button_Favorites_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Favorites_Add.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_Favorites_Add.Image = ((System.Drawing.Image)(resources.GetObject("button_Favorites_Add.Image")));
            this.button_Favorites_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Favorites_Add.Location = new System.Drawing.Point(829, 11);
            this.button_Favorites_Add.Margin = new System.Windows.Forms.Padding(2);
            this.button_Favorites_Add.Name = "button_Favorites_Add";
            this.button_Favorites_Add.Size = new System.Drawing.Size(76, 29);
            this.button_Favorites_Add.TabIndex = 1;
            this.button_Favorites_Add.Text = "Add";
            this.button_Favorites_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.button_Favorites_Add, "Adds a new Favorite");
            this.button_Favorites_Add.UseVisualStyleBackColor = false;
            this.button_Favorites_Add.Click += new System.EventHandler(this.Button_Favorites_Add);
            // 
            // button_OptMail_Test
            // 
            this.button_OptMail_Test.AutoSize = true;
            this.button_OptMail_Test.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.button_OptMail_Test.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_OptMail_Test.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_OptMail_Test.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_OptMail_Test.Image = ((System.Drawing.Image)(resources.GetObject("button_OptMail_Test.Image")));
            this.button_OptMail_Test.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_OptMail_Test.Location = new System.Drawing.Point(595, 196);
            this.button_OptMail_Test.Margin = new System.Windows.Forms.Padding(2);
            this.button_OptMail_Test.Name = "button_OptMail_Test";
            this.button_OptMail_Test.Size = new System.Drawing.Size(93, 30);
            this.button_OptMail_Test.TabIndex = 44;
            this.button_OptMail_Test.Text = "Test Email";
            this.button_OptMail_Test.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_OptMail_Test.UseVisualStyleBackColor = false;
            this.button_OptMail_Test.Click += new System.EventHandler(this.Button_OptMailTest_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label6.Location = new System.Drawing.Point(10, 40);
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
            this.tabControl1.Controls.Add(this.tabPageMessages);
            this.tabControl1.Controls.Add(this.tabPageFavorites);
            this.tabControl1.Controls.Add(this.tabPageOptions);
            this.tabControl1.Controls.Add(this.tabPageHistory);
            this.tabControl1.Controls.Add(this.tabPageAbout);
            this.tabControl1.Location = new System.Drawing.Point(14, 480);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(926, 325);
            this.tabControl1.TabIndex = 16;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1SelectedIndexChanged);
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TabControl1MouseClick);
            // 
            // tabPageFavorites
            // 
            this.tabPageFavorites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.tabPageFavorites.Controls.Add(this.groupBox11);
            this.tabPageFavorites.Controls.Add(this.listViewFavorites);
            this.tabPageFavorites.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPageFavorites.Location = new System.Drawing.Point(4, 22);
            this.tabPageFavorites.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageFavorites.Name = "tabPageFavorites";
            this.tabPageFavorites.Size = new System.Drawing.Size(918, 299);
            this.tabPageFavorites.TabIndex = 3;
            this.tabPageFavorites.Text = "Favorites";
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.groupBox11.Controls.Add(this.textBox_Favorites_NewDBs);
            this.groupBox11.Controls.Add(this.textBox_Favorites_NewUser);
            this.groupBox11.Controls.Add(this.textBox_Favorites_NewFile);
            this.groupBox11.Controls.Add(this.textBox_Favorites_NewDesc);
            this.groupBox11.Controls.Add(this.button_Favorites_Add);
            this.groupBox11.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox11.Location = new System.Drawing.Point(3, 250);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(912, 47);
            this.groupBox11.TabIndex = 2;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "New";
            // 
            // listViewFavorites
            // 
            this.listViewFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFavorites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.listViewFavorites.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewFavorites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewFavorites.ContextMenuStrip = this.contextMenuFavorites;
            this.listViewFavorites.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listViewFavorites.FullRowSelect = true;
            this.listViewFavorites.HideSelection = false;
            this.listViewFavorites.Location = new System.Drawing.Point(2, 2);
            this.listViewFavorites.Margin = new System.Windows.Forms.Padding(2);
            this.listViewFavorites.MultiSelect = false;
            this.listViewFavorites.Name = "listViewFavorites";
            this.listViewFavorites.Size = new System.Drawing.Size(914, 242);
            this.listViewFavorites.TabIndex = 0;
            this.listViewFavorites.UseCompatibleStateImageBehavior = false;
            this.listViewFavorites.View = System.Windows.Forms.View.Details;
            this.listViewFavorites.DoubleClick += new System.EventHandler(this.ListViewFavoritesDoubleClick);
            this.listViewFavorites.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListViewFavoritesKeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "DB User";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Database";
            this.columnHeader4.Width = 331;
            // 
            // contextMenuFavorites
            // 
            this.contextMenuFavorites.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuFavorites.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.favoritesRun,
            this.favoritesLoad,
            this.favoritesEditFile,
            this.favoritesUpdate,
            this.favoritesDelete,
            this.favoritesMoveUp,
            this.favoritesMoveDown});
            this.contextMenuFavorites.Name = "contextMenuStrip3";
            this.contextMenuFavorites.Size = new System.Drawing.Size(139, 158);
            // 
            // favoritesRun
            // 
            this.favoritesRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.favoritesRun.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.favoritesRun.Name = "favoritesRun";
            this.favoritesRun.Size = new System.Drawing.Size(138, 22);
            this.favoritesRun.Text = "Execute";
            this.favoritesRun.Click += new System.EventHandler(this.FavoritesRun);
            // 
            // favoritesLoad
            // 
            this.favoritesLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.favoritesLoad.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.favoritesLoad.Name = "favoritesLoad";
            this.favoritesLoad.Size = new System.Drawing.Size(138, 22);
            this.favoritesLoad.Text = "Load";
            this.favoritesLoad.Click += new System.EventHandler(this.FavoritesLoad);
            // 
            // favoritesEditFile
            // 
            this.favoritesEditFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.favoritesEditFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.favoritesEditFile.Name = "favoritesEditFile";
            this.favoritesEditFile.Size = new System.Drawing.Size(138, 22);
            this.favoritesEditFile.Text = "Edit File";
            this.favoritesEditFile.Click += new System.EventHandler(this.FavoritesEditFile_Click);
            // 
            // favoritesUpdate
            // 
            this.favoritesUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.favoritesUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.favoritesUpdate.Name = "favoritesUpdate";
            this.favoritesUpdate.Size = new System.Drawing.Size(138, 22);
            this.favoritesUpdate.Text = "Update";
            this.favoritesUpdate.Click += new System.EventHandler(this.FavoritesUpdate);
            // 
            // favoritesDelete
            // 
            this.favoritesDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.favoritesDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.favoritesDelete.Name = "favoritesDelete";
            this.favoritesDelete.Size = new System.Drawing.Size(138, 22);
            this.favoritesDelete.Text = "Delete";
            this.favoritesDelete.Click += new System.EventHandler(this.FavoritesDelete);
            // 
            // favoritesMoveUp
            // 
            this.favoritesMoveUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.favoritesMoveUp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.favoritesMoveUp.Name = "favoritesMoveUp";
            this.favoritesMoveUp.Size = new System.Drawing.Size(138, 22);
            this.favoritesMoveUp.Text = "Move Up";
            this.favoritesMoveUp.Click += new System.EventHandler(this.FavoritesMoveUp_Click);
            // 
            // favoritesMoveDown
            // 
            this.favoritesMoveDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.favoritesMoveDown.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.favoritesMoveDown.Name = "favoritesMoveDown";
            this.favoritesMoveDown.Size = new System.Drawing.Size(138, 22);
            this.favoritesMoveDown.Text = "Move Down";
            this.favoritesMoveDown.Click += new System.EventHandler(this.FavoritesMoveDown_Click);
            // 
            // tabPageOptions
            // 
            this.tabPageOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.tabPageOptions.Controls.Add(this.tabControloptions);
            this.tabPageOptions.Controls.Add(this.panelOptions);
            this.tabPageOptions.Location = new System.Drawing.Point(4, 22);
            this.tabPageOptions.Name = "tabPageOptions";
            this.tabPageOptions.Size = new System.Drawing.Size(918, 299);
            this.tabPageOptions.TabIndex = 4;
            this.tabPageOptions.Text = "Options";
            // 
            // tabControloptions
            // 
            this.tabControloptions.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControloptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControloptions.Controls.Add(this.tabPageOptionsEnvironment);
            this.tabControloptions.Controls.Add(this.tabPageOptionsDBs);
            this.tabControloptions.Controls.Add(this.tabPageOptionsDBUser);
            this.tabControloptions.Controls.Add(this.tabPageOptionsTaskScheduler);
            this.tabControloptions.Controls.Add(this.tabPageOptionsMail);
            this.tabControloptions.Controls.Add(this.tabPageOptionsCheckForUpdates);
            this.tabControloptions.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControloptions.ItemSize = new System.Drawing.Size(18, 100);
            this.tabControloptions.Location = new System.Drawing.Point(5, 5);
            this.tabControloptions.Margin = new System.Windows.Forms.Padding(0);
            this.tabControloptions.Multiline = true;
            this.tabControloptions.Name = "tabControloptions";
            this.tabControloptions.SelectedIndex = 0;
            this.tabControloptions.Size = new System.Drawing.Size(918, 334);
            this.tabControloptions.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControloptions.TabIndex = 1;
            this.tabControloptions.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabControlOptions_DrawItem);
            this.tabControloptions.SelectedIndexChanged += new System.EventHandler(this.TabControloptions_SelectedIndexChanged);
            this.tabControloptions.Leave += new System.EventHandler(this.TabControloptions_Leave);
            // 
            // tabPageOptionsEnvironment
            // 
            this.tabPageOptionsEnvironment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.tabPageOptionsEnvironment.Controls.Add(this.groupBox_OptEnv3);
            this.tabPageOptionsEnvironment.Controls.Add(this.label10);
            this.tabPageOptionsEnvironment.Controls.Add(this.groupBox_OptEnv2);
            this.tabPageOptionsEnvironment.Controls.Add(this.button_OptEnv_SqlPlusPath);
            this.tabPageOptionsEnvironment.Controls.Add(this.textBox_OptEnv_SqlPlusPath);
            this.tabPageOptionsEnvironment.Controls.Add(this.groupBox_OptEnv1);
            this.tabPageOptionsEnvironment.Location = new System.Drawing.Point(104, 4);
            this.tabPageOptionsEnvironment.Name = "tabPageOptionsEnvironment";
            this.tabPageOptionsEnvironment.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOptionsEnvironment.Size = new System.Drawing.Size(810, 326);
            this.tabPageOptionsEnvironment.TabIndex = 0;
            this.tabPageOptionsEnvironment.Text = "Environment";
            // 
            // groupBox_OptEnv3
            // 
            this.groupBox_OptEnv3.Controls.Add(this.checkBox_OptEnv_Mode);
            this.groupBox_OptEnv3.Controls.Add(this.label19);
            this.groupBox_OptEnv3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox_OptEnv3.Location = new System.Drawing.Point(15, 238);
            this.groupBox_OptEnv3.Name = "groupBox_OptEnv3";
            this.groupBox_OptEnv3.Size = new System.Drawing.Size(566, 47);
            this.groupBox_OptEnv3.TabIndex = 54;
            this.groupBox_OptEnv3.TabStop = false;
            this.groupBox_OptEnv3.Text = "User Interface / Mode";
            // 
            // checkBox_OptEnv_Mode
            // 
            this.checkBox_OptEnv_Mode.AutoSize = true;
            this.checkBox_OptEnv_Mode.Checked = true;
            this.checkBox_OptEnv_Mode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_OptEnv_Mode.Location = new System.Drawing.Point(189, 20);
            this.checkBox_OptEnv_Mode.Name = "checkBox_OptEnv_Mode";
            this.checkBox_OptEnv_Mode.Size = new System.Drawing.Size(15, 14);
            this.checkBox_OptEnv_Mode.TabIndex = 0;
            this.checkBox_OptEnv_Mode.UseVisualStyleBackColor = false;
            this.checkBox_OptEnv_Mode.CheckedChanged += new System.EventHandler(this.CheckBox_OptEnv_Mode_CheckedChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label19.Location = new System.Drawing.Point(12, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 13);
            this.label19.TabIndex = 48;
            this.label19.Text = "- Dark Mode";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label10.Location = new System.Drawing.Point(15, 21);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 53;
            this.label10.Text = "SQL*Plus Path";
            // 
            // groupBox_OptEnv2
            // 
            this.groupBox_OptEnv2.Controls.Add(this.hidePasswords);
            this.groupBox_OptEnv2.Controls.Add(this.label31);
            this.groupBox_OptEnv2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox_OptEnv2.Location = new System.Drawing.Point(15, 177);
            this.groupBox_OptEnv2.Name = "groupBox_OptEnv2";
            this.groupBox_OptEnv2.Size = new System.Drawing.Size(566, 47);
            this.groupBox_OptEnv2.TabIndex = 52;
            this.groupBox_OptEnv2.TabStop = false;
            this.groupBox_OptEnv2.Text = "Security / Encryption";
            // 
            // hidePasswords
            // 
            this.hidePasswords.AutoSize = true;
            this.hidePasswords.Checked = true;
            this.hidePasswords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hidePasswords.Location = new System.Drawing.Point(189, 20);
            this.hidePasswords.Name = "hidePasswords";
            this.hidePasswords.Size = new System.Drawing.Size(15, 14);
            this.hidePasswords.TabIndex = 0;
            this.hidePasswords.UseVisualStyleBackColor = false;
            this.hidePasswords.CheckedChanged += new System.EventHandler(this.HidePasswords_CheckedChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label31.Location = new System.Drawing.Point(12, 20);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(152, 13);
            this.label31.TabIndex = 48;
            this.label31.Text = "- Hide Passwords in Config File";
            // 
            // button_OptEnv_SqlPlusPath
            // 
            this.button_OptEnv_SqlPlusPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.button_OptEnv_SqlPlusPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_OptEnv_SqlPlusPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_OptEnv_SqlPlusPath.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_OptEnv_SqlPlusPath.Image = ((System.Drawing.Image)(resources.GetObject("button_OptEnv_SqlPlusPath.Image")));
            this.button_OptEnv_SqlPlusPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_OptEnv_SqlPlusPath.Location = new System.Drawing.Point(490, 18);
            this.button_OptEnv_SqlPlusPath.Margin = new System.Windows.Forms.Padding(2);
            this.button_OptEnv_SqlPlusPath.Name = "button_OptEnv_SqlPlusPath";
            this.button_OptEnv_SqlPlusPath.Size = new System.Drawing.Size(76, 22);
            this.button_OptEnv_SqlPlusPath.TabIndex = 1;
            this.button_OptEnv_SqlPlusPath.Text = "Open";
            this.button_OptEnv_SqlPlusPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_OptEnv_SqlPlusPath.UseVisualStyleBackColor = false;
            this.button_OptEnv_SqlPlusPath.Click += new System.EventHandler(this.Button_OptEnv_SqlPlusPath_Click);
            // 
            // textBox_OptEnv_SqlPlusPath
            // 
            this.textBox_OptEnv_SqlPlusPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptEnv_SqlPlusPath.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptEnv_SqlPlusPath.Location = new System.Drawing.Point(115, 18);
            this.textBox_OptEnv_SqlPlusPath.Name = "textBox_OptEnv_SqlPlusPath";
            this.textBox_OptEnv_SqlPlusPath.Size = new System.Drawing.Size(356, 20);
            this.textBox_OptEnv_SqlPlusPath.TabIndex = 0;
            this.textBox_OptEnv_SqlPlusPath.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_OptEnv_SqlPlusPath_Validating);
            // 
            // groupBox_OptEnv1
            // 
            this.groupBox_OptEnv1.Controls.Add(this.button_OptEnv_TNS_ADMIN);
            this.groupBox_OptEnv1.Controls.Add(this.button_OptEnv_SQLPATH);
            this.groupBox_OptEnv1.Controls.Add(this.textBox_OptEnv_SQLPATH);
            this.groupBox_OptEnv1.Controls.Add(this.textBox_OptEnv_TNS_ADMIN);
            this.groupBox_OptEnv1.Controls.Add(this.textBox_OptEnv_NLS_LANG);
            this.groupBox_OptEnv1.Controls.Add(this.label33);
            this.groupBox_OptEnv1.Controls.Add(this.label11);
            this.groupBox_OptEnv1.Controls.Add(this.label12);
            this.groupBox_OptEnv1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox_OptEnv1.Location = new System.Drawing.Point(15, 48);
            this.groupBox_OptEnv1.Name = "groupBox_OptEnv1";
            this.groupBox_OptEnv1.Size = new System.Drawing.Size(566, 115);
            this.groupBox_OptEnv1.TabIndex = 49;
            this.groupBox_OptEnv1.TabStop = false;
            this.groupBox_OptEnv1.Text = "SQL*Plus environment variables";
            // 
            // button_OptEnv_TNS_ADMIN
            // 
            this.button_OptEnv_TNS_ADMIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.button_OptEnv_TNS_ADMIN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_OptEnv_TNS_ADMIN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_OptEnv_TNS_ADMIN.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_OptEnv_TNS_ADMIN.Image = ((System.Drawing.Image)(resources.GetObject("button_OptEnv_TNS_ADMIN.Image")));
            this.button_OptEnv_TNS_ADMIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_OptEnv_TNS_ADMIN.Location = new System.Drawing.Point(475, 52);
            this.button_OptEnv_TNS_ADMIN.Margin = new System.Windows.Forms.Padding(2);
            this.button_OptEnv_TNS_ADMIN.Name = "button_OptEnv_TNS_ADMIN";
            this.button_OptEnv_TNS_ADMIN.Size = new System.Drawing.Size(76, 22);
            this.button_OptEnv_TNS_ADMIN.TabIndex = 2;
            this.button_OptEnv_TNS_ADMIN.Text = "Open";
            this.button_OptEnv_TNS_ADMIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_OptEnv_TNS_ADMIN.UseVisualStyleBackColor = false;
            this.button_OptEnv_TNS_ADMIN.Click += new System.EventHandler(this.Button_OptEnv_TNS_ADMIN_Click);
            // 
            // button_OptEnv_SQLPATH
            // 
            this.button_OptEnv_SQLPATH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.button_OptEnv_SQLPATH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_OptEnv_SQLPATH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_OptEnv_SQLPATH.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_OptEnv_SQLPATH.Image = ((System.Drawing.Image)(resources.GetObject("button_OptEnv_SQLPATH.Image")));
            this.button_OptEnv_SQLPATH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_OptEnv_SQLPATH.Location = new System.Drawing.Point(475, 78);
            this.button_OptEnv_SQLPATH.Margin = new System.Windows.Forms.Padding(2);
            this.button_OptEnv_SQLPATH.Name = "button_OptEnv_SQLPATH";
            this.button_OptEnv_SQLPATH.Size = new System.Drawing.Size(76, 22);
            this.button_OptEnv_SQLPATH.TabIndex = 4;
            this.button_OptEnv_SQLPATH.Text = "Open";
            this.button_OptEnv_SQLPATH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_OptEnv_SQLPATH.UseVisualStyleBackColor = false;
            this.button_OptEnv_SQLPATH.Click += new System.EventHandler(this.Button_OptEnv_SQLPATH_Click);
            // 
            // textBox_OptEnv_SQLPATH
            // 
            this.textBox_OptEnv_SQLPATH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptEnv_SQLPATH.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptEnv_SQLPATH.Location = new System.Drawing.Point(100, 80);
            this.textBox_OptEnv_SQLPATH.Name = "textBox_OptEnv_SQLPATH";
            this.textBox_OptEnv_SQLPATH.Size = new System.Drawing.Size(356, 20);
            this.textBox_OptEnv_SQLPATH.TabIndex = 3;
            this.textBox_OptEnv_SQLPATH.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_OptEnv_SQLPATH_Validating);
            // 
            // textBox_OptEnv_TNS_ADMIN
            // 
            this.textBox_OptEnv_TNS_ADMIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptEnv_TNS_ADMIN.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptEnv_TNS_ADMIN.Location = new System.Drawing.Point(100, 52);
            this.textBox_OptEnv_TNS_ADMIN.Name = "textBox_OptEnv_TNS_ADMIN";
            this.textBox_OptEnv_TNS_ADMIN.Size = new System.Drawing.Size(356, 20);
            this.textBox_OptEnv_TNS_ADMIN.TabIndex = 1;
            this.textBox_OptEnv_TNS_ADMIN.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_OptEnv_TNS_ADMIN_Validating);
            // 
            // textBox_OptEnv_NLS_LANG
            // 
            this.textBox_OptEnv_NLS_LANG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptEnv_NLS_LANG.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptEnv_NLS_LANG.Location = new System.Drawing.Point(100, 24);
            this.textBox_OptEnv_NLS_LANG.Name = "textBox_OptEnv_NLS_LANG";
            this.textBox_OptEnv_NLS_LANG.Size = new System.Drawing.Size(356, 20);
            this.textBox_OptEnv_NLS_LANG.TabIndex = 0;
            this.textBox_OptEnv_NLS_LANG.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_OptEnv_NLS_LANG_Validating);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label33.Location = new System.Drawing.Point(14, 31);
            this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(69, 13);
            this.label33.TabIndex = 9;
            this.label33.Text = "- NLS_LANG";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label11.Location = new System.Drawing.Point(14, 55);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "- TNS_ADMIN";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label12.Location = new System.Drawing.Point(14, 83);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "- SQLPATH";
            // 
            // tabPageOptionsDBs
            // 
            this.tabPageOptionsDBs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.tabPageOptionsDBs.Controls.Add(this.groupBox4);
            this.tabPageOptionsDBs.Controls.Add(this.dataGridView_DBGroups);
            this.tabPageOptionsDBs.Controls.Add(this.groupBox3);
            this.tabPageOptionsDBs.Location = new System.Drawing.Point(104, 4);
            this.tabPageOptionsDBs.Name = "tabPageOptionsDBs";
            this.tabPageOptionsDBs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOptionsDBs.Size = new System.Drawing.Size(810, 326);
            this.tabPageOptionsDBs.TabIndex = 1;
            this.tabPageOptionsDBs.Text = "DB Groups";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.textBox_OptDBGroup_NewColor);
            this.groupBox4.Controls.Add(this.textBox_OptDBGroup_NewRegExp);
            this.groupBox4.Controls.Add(this.textBox_OptDBGroup_NewName);
            this.groupBox4.Controls.Add(this.button_OptDBGroup_Add);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox4.Location = new System.Drawing.Point(15, 240);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(772, 47);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "New";
            // 
            // textBox_OptDBGroup_NewColor
            // 
            this.textBox_OptDBGroup_NewColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptDBGroup_NewColor.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptDBGroup_NewColor.Location = new System.Drawing.Point(640, 16);
            this.textBox_OptDBGroup_NewColor.Name = "textBox_OptDBGroup_NewColor";
            this.textBox_OptDBGroup_NewColor.Size = new System.Drawing.Size(60, 20);
            this.textBox_OptDBGroup_NewColor.TabIndex = 29;
            this.textBox_OptDBGroup_NewColor.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TextBox_OptDBGroup_NewColor_MouseDoubleClick);
            // 
            // textBox_OptDBGroup_NewRegExp
            // 
            this.textBox_OptDBGroup_NewRegExp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptDBGroup_NewRegExp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptDBGroup_NewRegExp.Location = new System.Drawing.Point(110, 16);
            this.textBox_OptDBGroup_NewRegExp.Name = "textBox_OptDBGroup_NewRegExp";
            this.textBox_OptDBGroup_NewRegExp.Size = new System.Drawing.Size(525, 20);
            this.textBox_OptDBGroup_NewRegExp.TabIndex = 28;
            this.textBox_OptDBGroup_NewRegExp.Leave += new System.EventHandler(this.TextBox_OptDBGroup_NewRegExp_Leave);
            // 
            // textBox_OptDBGroup_NewName
            // 
            this.textBox_OptDBGroup_NewName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptDBGroup_NewName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptDBGroup_NewName.Location = new System.Drawing.Point(5, 16);
            this.textBox_OptDBGroup_NewName.Name = "textBox_OptDBGroup_NewName";
            this.textBox_OptDBGroup_NewName.Size = new System.Drawing.Size(100, 20);
            this.textBox_OptDBGroup_NewName.TabIndex = 27;
            // 
            // button_OptDBGroup_Add
            // 
            this.button_OptDBGroup_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_OptDBGroup_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.button_OptDBGroup_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_OptDBGroup_Add.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_OptDBGroup_Add.Image = ((System.Drawing.Image)(resources.GetObject("button_OptDBGroup_Add.Image")));
            this.button_OptDBGroup_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_OptDBGroup_Add.Location = new System.Drawing.Point(710, 11);
            this.button_OptDBGroup_Add.Margin = new System.Windows.Forms.Padding(2);
            this.button_OptDBGroup_Add.Name = "button_OptDBGroup_Add";
            this.button_OptDBGroup_Add.Size = new System.Drawing.Size(55, 29);
            this.button_OptDBGroup_Add.TabIndex = 30;
            this.button_OptDBGroup_Add.Text = "Add";
            this.button_OptDBGroup_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_OptDBGroup_Add.UseVisualStyleBackColor = false;
            this.button_OptDBGroup_Add.Click += new System.EventHandler(this.Button_OptDBGroup_Add_Click);
            // 
            // dataGridView_DBGroups
            // 
            this.dataGridView_DBGroups.AllowUserToAddRows = false;
            this.dataGridView_DBGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_DBGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_DBGroups.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.dataGridView_DBGroups.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_DBGroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_DBGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DBGroups.ContextMenuStrip = this.contextMenuOptDBGroups;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_DBGroups.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_DBGroups.EnableHeadersVisualStyles = false;
            this.dataGridView_DBGroups.Location = new System.Drawing.Point(15, 90);
            this.dataGridView_DBGroups.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_DBGroups.MultiSelect = false;
            this.dataGridView_DBGroups.Name = "dataGridView_DBGroups";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_DBGroups.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_DBGroups.RowHeadersVisible = false;
            this.dataGridView_DBGroups.RowHeadersWidth = 51;
            this.dataGridView_DBGroups.RowTemplate.Height = 24;
            this.dataGridView_DBGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_DBGroups.Size = new System.Drawing.Size(713, 150);
            this.dataGridView_DBGroups.TabIndex = 9;
            this.dataGridView_DBGroups.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_DBGroups_CellDoubleClick);
            this.dataGridView_DBGroups.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_DBGroups_CellEndEdit);
            this.dataGridView_DBGroups.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView_DBGroups_CellFormatting);
            this.dataGridView_DBGroups.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DataGridView_DBGroups_UserDeletedRow);
            // 
            // contextMenuOptDBGroups
            // 
            this.contextMenuOptDBGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuOptDBGroup_Up,
            this.toolStripMenuOptDBGroup_Down});
            this.contextMenuOptDBGroups.Name = "contextMenuOptDBGroups";
            this.contextMenuOptDBGroups.Size = new System.Drawing.Size(139, 48);
            // 
            // toolStripMenuOptDBGroup_Up
            // 
            this.toolStripMenuOptDBGroup_Up.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.toolStripMenuOptDBGroup_Up.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripMenuOptDBGroup_Up.Name = "toolStripMenuOptDBGroup_Up";
            this.toolStripMenuOptDBGroup_Up.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuOptDBGroup_Up.Text = "Move Up";
            this.toolStripMenuOptDBGroup_Up.Click += new System.EventHandler(this.ToolStripMenuOptDBGroup_Up_Click);
            // 
            // toolStripMenuOptDBGroup_Down
            // 
            this.toolStripMenuOptDBGroup_Down.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.toolStripMenuOptDBGroup_Down.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripMenuOptDBGroup_Down.Name = "toolStripMenuOptDBGroup_Down";
            this.toolStripMenuOptDBGroup_Down.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuOptDBGroup_Down.Text = "Move Down";
            this.toolStripMenuOptDBGroup_Down.Click += new System.EventHandler(this.ToolStripMenuOptDBGroup_Down_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_OptDBGroup_ExcludeDBs);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox3.Location = new System.Drawing.Point(15, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(713, 55);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Exclude DBs";
            // 
            // textBox_OptDBGroup_ExcludeDBs
            // 
            this.textBox_OptDBGroup_ExcludeDBs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptDBGroup_ExcludeDBs.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptDBGroup_ExcludeDBs.Location = new System.Drawing.Point(101, 22);
            this.textBox_OptDBGroup_ExcludeDBs.Name = "textBox_OptDBGroup_ExcludeDBs";
            this.textBox_OptDBGroup_ExcludeDBs.Size = new System.Drawing.Size(604, 20);
            this.textBox_OptDBGroup_ExcludeDBs.TabIndex = 26;
            this.textBox_OptDBGroup_ExcludeDBs.Leave += new System.EventHandler(this.TextBox_OptDBGroup_ExcludeDBs_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label13.Location = new System.Drawing.Point(5, 25);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Regular expression";
            // 
            // tabPageOptionsDBUser
            // 
            this.tabPageOptionsDBUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.tabPageOptionsDBUser.Controls.Add(this.groupBox_OptDBUser);
            this.tabPageOptionsDBUser.Controls.Add(this.dataGridView_DBUsers);
            this.tabPageOptionsDBUser.Location = new System.Drawing.Point(104, 4);
            this.tabPageOptionsDBUser.Name = "tabPageOptionsDBUser";
            this.tabPageOptionsDBUser.Size = new System.Drawing.Size(810, 326);
            this.tabPageOptionsDBUser.TabIndex = 2;
            this.tabPageOptionsDBUser.Text = "DB User";
            // 
            // groupBox_OptDBUser
            // 
            this.groupBox_OptDBUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_OptDBUser.Controls.Add(this.checkBox_OptDBUser_NewSYSDBA);
            this.groupBox_OptDBUser.Controls.Add(this.textBox_OptDBUser_NewPassword);
            this.groupBox_OptDBUser.Controls.Add(this.textBox_OptDBUser_NewSchema);
            this.groupBox_OptDBUser.Controls.Add(this.textBox_OptDBUser_NewUser);
            this.groupBox_OptDBUser.Controls.Add(this.buttonOptDBUser_Add);
            this.groupBox_OptDBUser.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox_OptDBUser.Location = new System.Drawing.Point(15, 240);
            this.groupBox_OptDBUser.Name = "groupBox_OptDBUser";
            this.groupBox_OptDBUser.Size = new System.Drawing.Size(772, 47);
            this.groupBox_OptDBUser.TabIndex = 13;
            this.groupBox_OptDBUser.TabStop = false;
            this.groupBox_OptDBUser.Text = "New";
            // 
            // checkBox_OptDBUser_NewSYSDBA
            // 
            this.checkBox_OptDBUser_NewSYSDBA.AutoSize = true;
            this.checkBox_OptDBUser_NewSYSDBA.Location = new System.Drawing.Point(620, 20);
            this.checkBox_OptDBUser_NewSYSDBA.Name = "checkBox_OptDBUser_NewSYSDBA";
            this.checkBox_OptDBUser_NewSYSDBA.Size = new System.Drawing.Size(15, 14);
            this.checkBox_OptDBUser_NewSYSDBA.TabIndex = 12;
            this.checkBox_OptDBUser_NewSYSDBA.UseVisualStyleBackColor = true;
            // 
            // textBox_OptDBUser_NewPassword
            // 
            this.textBox_OptDBUser_NewPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptDBUser_NewPassword.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptDBUser_NewPassword.Location = new System.Drawing.Point(365, 16);
            this.textBox_OptDBUser_NewPassword.Name = "textBox_OptDBUser_NewPassword";
            this.textBox_OptDBUser_NewPassword.PasswordChar = '●';
            this.textBox_OptDBUser_NewPassword.Size = new System.Drawing.Size(175, 20);
            this.textBox_OptDBUser_NewPassword.TabIndex = 33;
            // 
            // textBox_OptDBUser_NewSchema
            // 
            this.textBox_OptDBUser_NewSchema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptDBUser_NewSchema.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptDBUser_NewSchema.Location = new System.Drawing.Point(185, 16);
            this.textBox_OptDBUser_NewSchema.Name = "textBox_OptDBUser_NewSchema";
            this.textBox_OptDBUser_NewSchema.Size = new System.Drawing.Size(175, 20);
            this.textBox_OptDBUser_NewSchema.TabIndex = 32;
            // 
            // textBox_OptDBUser_NewUser
            // 
            this.textBox_OptDBUser_NewUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptDBUser_NewUser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptDBUser_NewUser.Location = new System.Drawing.Point(5, 16);
            this.textBox_OptDBUser_NewUser.Name = "textBox_OptDBUser_NewUser";
            this.textBox_OptDBUser_NewUser.Size = new System.Drawing.Size(175, 20);
            this.textBox_OptDBUser_NewUser.TabIndex = 31;
            // 
            // buttonOptDBUser_Add
            // 
            this.buttonOptDBUser_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOptDBUser_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonOptDBUser_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOptDBUser_Add.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonOptDBUser_Add.Image = ((System.Drawing.Image)(resources.GetObject("buttonOptDBUser_Add.Image")));
            this.buttonOptDBUser_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOptDBUser_Add.Location = new System.Drawing.Point(710, 11);
            this.buttonOptDBUser_Add.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOptDBUser_Add.Name = "buttonOptDBUser_Add";
            this.buttonOptDBUser_Add.Size = new System.Drawing.Size(55, 29);
            this.buttonOptDBUser_Add.TabIndex = 34;
            this.buttonOptDBUser_Add.Text = "Add";
            this.buttonOptDBUser_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOptDBUser_Add.UseVisualStyleBackColor = false;
            this.buttonOptDBUser_Add.Click += new System.EventHandler(this.ButtonOptDBUser_Add_Click);
            // 
            // dataGridView_DBUsers
            // 
            this.dataGridView_DBUsers.AllowUserToAddRows = false;
            this.dataGridView_DBUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_DBUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_DBUsers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.dataGridView_DBUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_DBUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_DBUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DBUsers.ContextMenuStrip = this.contextMenuOptDBUser;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_DBUsers.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView_DBUsers.EnableHeadersVisualStyles = false;
            this.dataGridView_DBUsers.Location = new System.Drawing.Point(15, 21);
            this.dataGridView_DBUsers.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_DBUsers.Name = "dataGridView_DBUsers";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_DBUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView_DBUsers.RowHeadersVisible = false;
            this.dataGridView_DBUsers.RowHeadersWidth = 51;
            this.dataGridView_DBUsers.RowTemplate.Height = 24;
            this.dataGridView_DBUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_DBUsers.Size = new System.Drawing.Size(713, 220);
            this.dataGridView_DBUsers.TabIndex = 8;
            this.dataGridView_DBUsers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewDBUsers_CellFormatting);
            this.dataGridView_DBUsers.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridView_DBUsers_RowValidating);
            this.dataGridView_DBUsers.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DataGridViewDBUsers_UserDeletedRow);
            // 
            // contextMenuOptDBUser
            // 
            this.contextMenuOptDBUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuOptDBUser_Up,
            this.toolStripMenuOptDBUser_Down});
            this.contextMenuOptDBUser.Name = "contextMenuOptDBUser";
            this.contextMenuOptDBUser.Size = new System.Drawing.Size(139, 48);
            // 
            // toolStripMenuOptDBUser_Up
            // 
            this.toolStripMenuOptDBUser_Up.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.toolStripMenuOptDBUser_Up.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripMenuOptDBUser_Up.Name = "toolStripMenuOptDBUser_Up";
            this.toolStripMenuOptDBUser_Up.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuOptDBUser_Up.Text = "Move Up";
            this.toolStripMenuOptDBUser_Up.Click += new System.EventHandler(this.ToolStripMenuOptDBUser_Up_Click);
            // 
            // toolStripMenuOptDBUser_Down
            // 
            this.toolStripMenuOptDBUser_Down.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.toolStripMenuOptDBUser_Down.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripMenuOptDBUser_Down.Name = "toolStripMenuOptDBUser_Down";
            this.toolStripMenuOptDBUser_Down.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuOptDBUser_Down.Text = "Move Down";
            this.toolStripMenuOptDBUser_Down.Click += new System.EventHandler(this.ToolStripMenuOptDBUser_Down_Click);
            // 
            // tabPageOptionsTaskScheduler
            // 
            this.tabPageOptionsTaskScheduler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.tabPageOptionsTaskScheduler.Controls.Add(this.groupBox_OptJobScheduler);
            this.tabPageOptionsTaskScheduler.Location = new System.Drawing.Point(104, 4);
            this.tabPageOptionsTaskScheduler.Name = "tabPageOptionsTaskScheduler";
            this.tabPageOptionsTaskScheduler.Size = new System.Drawing.Size(810, 326);
            this.tabPageOptionsTaskScheduler.TabIndex = 3;
            this.tabPageOptionsTaskScheduler.Text = "Task Scheduler";
            // 
            // groupBox_OptJobScheduler
            // 
            this.groupBox_OptJobScheduler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.groupBox_OptJobScheduler.Controls.Add(this.textBox_OptTask_Password);
            this.groupBox_OptJobScheduler.Controls.Add(this.textBox_OptTask_Username);
            this.groupBox_OptJobScheduler.Controls.Add(this.label3);
            this.groupBox_OptJobScheduler.Controls.Add(this.label5);
            this.groupBox_OptJobScheduler.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox_OptJobScheduler.Location = new System.Drawing.Point(15, 21);
            this.groupBox_OptJobScheduler.Name = "groupBox_OptJobScheduler";
            this.groupBox_OptJobScheduler.Size = new System.Drawing.Size(566, 101);
            this.groupBox_OptJobScheduler.TabIndex = 0;
            this.groupBox_OptJobScheduler.TabStop = false;
            this.groupBox_OptJobScheduler.Text = "Task Owner";
            // 
            // textBox_OptTask_Password
            // 
            this.textBox_OptTask_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptTask_Password.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptTask_Password.Location = new System.Drawing.Point(100, 52);
            this.textBox_OptTask_Password.Name = "textBox_OptTask_Password";
            this.textBox_OptTask_Password.PasswordChar = '●';
            this.textBox_OptTask_Password.Size = new System.Drawing.Size(356, 20);
            this.textBox_OptTask_Password.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Location = new System.Drawing.Point(14, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "- Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label5.Location = new System.Drawing.Point(14, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "- O/S Username";
            // 
            // tabPageOptionsMail
            // 
            this.tabPageOptionsMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.tabPageOptionsMail.Controls.Add(this.button_OptMail_Test);
            this.tabPageOptionsMail.Controls.Add(this.groupBox_OptMail);
            this.tabPageOptionsMail.Location = new System.Drawing.Point(104, 4);
            this.tabPageOptionsMail.Name = "tabPageOptionsMail";
            this.tabPageOptionsMail.Size = new System.Drawing.Size(810, 326);
            this.tabPageOptionsMail.TabIndex = 4;
            this.tabPageOptionsMail.Text = "Mail";
            // 
            // groupBox_OptMail
            // 
            this.groupBox_OptMail.Controls.Add(this.maskedTextBox_OptMail_Port);
            this.groupBox_OptMail.Controls.Add(this.label21);
            this.groupBox_OptMail.Controls.Add(this.checkBox_OptMail_EnableSSL);
            this.groupBox_OptMail.Controls.Add(this.textBox_OptMail_MailReceiver);
            this.groupBox_OptMail.Controls.Add(this.textBox_OptMail_MailSender);
            this.groupBox_OptMail.Controls.Add(this.label23);
            this.groupBox_OptMail.Controls.Add(this.label22);
            this.groupBox_OptMail.Controls.Add(this.label18);
            this.groupBox_OptMail.Controls.Add(this.textBox_OptMail_Password);
            this.groupBox_OptMail.Controls.Add(this.textBox_OptMail_User);
            this.groupBox_OptMail.Controls.Add(this.textBox_OptMail_Server);
            this.groupBox_OptMail.Controls.Add(this.label17);
            this.groupBox_OptMail.Controls.Add(this.label16);
            this.groupBox_OptMail.Controls.Add(this.label15);
            this.groupBox_OptMail.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox_OptMail.Location = new System.Drawing.Point(15, 21);
            this.groupBox_OptMail.Name = "groupBox_OptMail";
            this.groupBox_OptMail.Size = new System.Drawing.Size(566, 210);
            this.groupBox_OptMail.TabIndex = 0;
            this.groupBox_OptMail.TabStop = false;
            this.groupBox_OptMail.Text = "Mail";
            // 
            // maskedTextBox_OptMail_Port
            // 
            this.maskedTextBox_OptMail_Port.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.maskedTextBox_OptMail_Port.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.maskedTextBox_OptMail_Port.Location = new System.Drawing.Point(180, 52);
            this.maskedTextBox_OptMail_Port.Mask = "009";
            this.maskedTextBox_OptMail_Port.Name = "maskedTextBox_OptMail_Port";
            this.maskedTextBox_OptMail_Port.Size = new System.Drawing.Size(28, 20);
            this.maskedTextBox_OptMail_Port.TabIndex = 38;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label21.Location = new System.Drawing.Point(14, 79);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 13);
            this.label21.TabIndex = 54;
            this.label21.Text = "- Enable SSL";
            // 
            // checkBox_OptMail_EnableSSL
            // 
            this.checkBox_OptMail_EnableSSL.AutoSize = true;
            this.checkBox_OptMail_EnableSSL.Location = new System.Drawing.Point(180, 76);
            this.checkBox_OptMail_EnableSSL.Name = "checkBox_OptMail_EnableSSL";
            this.checkBox_OptMail_EnableSSL.Size = new System.Drawing.Size(15, 14);
            this.checkBox_OptMail_EnableSSL.TabIndex = 39;
            this.checkBox_OptMail_EnableSSL.UseVisualStyleBackColor = true;
            // 
            // textBox_OptMail_MailReceiver
            // 
            this.textBox_OptMail_MailReceiver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptMail_MailReceiver.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptMail_MailReceiver.Location = new System.Drawing.Point(180, 173);
            this.textBox_OptMail_MailReceiver.Name = "textBox_OptMail_MailReceiver";
            this.textBox_OptMail_MailReceiver.Size = new System.Drawing.Size(305, 20);
            this.textBox_OptMail_MailReceiver.TabIndex = 43;
            // 
            // textBox_OptMail_MailSender
            // 
            this.textBox_OptMail_MailSender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptMail_MailSender.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptMail_MailSender.Location = new System.Drawing.Point(180, 148);
            this.textBox_OptMail_MailSender.Name = "textBox_OptMail_MailSender";
            this.textBox_OptMail_MailSender.Size = new System.Drawing.Size(305, 20);
            this.textBox_OptMail_MailSender.TabIndex = 42;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label23.Location = new System.Drawing.Point(13, 175);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(84, 13);
            this.label23.TabIndex = 48;
            this.label23.Text = "- Email Receiver";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label22.Location = new System.Drawing.Point(14, 151);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 13);
            this.label22.TabIndex = 47;
            this.label22.Text = "- Email Sender";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label18.Location = new System.Drawing.Point(14, 55);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 13);
            this.label18.TabIndex = 16;
            this.label18.Text = "- SMTP Server Port";
            // 
            // textBox_OptMail_Password
            // 
            this.textBox_OptMail_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptMail_Password.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptMail_Password.Location = new System.Drawing.Point(180, 121);
            this.textBox_OptMail_Password.Name = "textBox_OptMail_Password";
            this.textBox_OptMail_Password.PasswordChar = '●';
            this.textBox_OptMail_Password.Size = new System.Drawing.Size(305, 20);
            this.textBox_OptMail_Password.TabIndex = 41;
            // 
            // textBox_OptMail_User
            // 
            this.textBox_OptMail_User.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptMail_User.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptMail_User.Location = new System.Drawing.Point(180, 96);
            this.textBox_OptMail_User.Name = "textBox_OptMail_User";
            this.textBox_OptMail_User.Size = new System.Drawing.Size(305, 20);
            this.textBox_OptMail_User.TabIndex = 40;
            // 
            // textBox_OptMail_Server
            // 
            this.textBox_OptMail_Server.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox_OptMail_Server.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_OptMail_Server.Location = new System.Drawing.Point(180, 28);
            this.textBox_OptMail_Server.Name = "textBox_OptMail_Server";
            this.textBox_OptMail_Server.Size = new System.Drawing.Size(305, 20);
            this.textBox_OptMail_Server.TabIndex = 37;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label17.Location = new System.Drawing.Point(14, 127);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 13);
            this.label17.TabIndex = 12;
            this.label17.Text = "- Password";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label16.Location = new System.Drawing.Point(14, 103);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "- User";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label15.Location = new System.Drawing.Point(14, 31);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "- SMTP Server";
            // 
            // tabPageOptionsCheckForUpdates
            // 
            this.tabPageOptionsCheckForUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.tabPageOptionsCheckForUpdates.Controls.Add(this.button_OptUpdate_Update);
            this.tabPageOptionsCheckForUpdates.Controls.Add(this.groupBox10);
            this.tabPageOptionsCheckForUpdates.Location = new System.Drawing.Point(104, 4);
            this.tabPageOptionsCheckForUpdates.Name = "tabPageOptionsCheckForUpdates";
            this.tabPageOptionsCheckForUpdates.Size = new System.Drawing.Size(810, 326);
            this.tabPageOptionsCheckForUpdates.TabIndex = 5;
            this.tabPageOptionsCheckForUpdates.Text = "Check for Updates";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.linkCheck4Update);
            this.groupBox10.Controls.Add(this.label_OptUpdate_Message3);
            this.groupBox10.Controls.Add(this.label_OptUpdate_Message2);
            this.groupBox10.Controls.Add(this.label_OptUpdate_Message1);
            this.groupBox10.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox10.Location = new System.Drawing.Point(15, 21);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(566, 140);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Check for Updates";
            // 
            // linkCheck4Update
            // 
            this.linkCheck4Update.AutoSize = true;
            this.linkCheck4Update.LinkColor = System.Drawing.SystemColors.Highlight;
            this.linkCheck4Update.Location = new System.Drawing.Point(14, 103);
            this.linkCheck4Update.Name = "linkCheck4Update";
            this.linkCheck4Update.Size = new System.Drawing.Size(52, 13);
            this.linkCheck4Update.TabIndex = 18;
            this.linkCheck4Update.TabStop = true;
            this.linkCheck4Update.Text = "More Info";
            this.linkCheck4Update.Visible = false;
            this.linkCheck4Update.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkCheck4Update.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkCheck4Update_LinkClicked);
            // 
            // label_OptUpdate_Message3
            // 
            this.label_OptUpdate_Message3.AutoSize = true;
            this.label_OptUpdate_Message3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label_OptUpdate_Message3.Location = new System.Drawing.Point(14, 79);
            this.label_OptUpdate_Message3.Name = "label_OptUpdate_Message3";
            this.label_OptUpdate_Message3.Size = new System.Drawing.Size(35, 13);
            this.label_OptUpdate_Message3.TabIndex = 17;
            this.label_OptUpdate_Message3.Text = "label3";
            // 
            // label_OptUpdate_Message2
            // 
            this.label_OptUpdate_Message2.AutoSize = true;
            this.label_OptUpdate_Message2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label_OptUpdate_Message2.Location = new System.Drawing.Point(14, 55);
            this.label_OptUpdate_Message2.Name = "label_OptUpdate_Message2";
            this.label_OptUpdate_Message2.Size = new System.Drawing.Size(41, 13);
            this.label_OptUpdate_Message2.TabIndex = 16;
            this.label_OptUpdate_Message2.Text = "label27";
            // 
            // label_OptUpdate_Message1
            // 
            this.label_OptUpdate_Message1.AutoSize = true;
            this.label_OptUpdate_Message1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_OptUpdate_Message1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_OptUpdate_Message1.Location = new System.Drawing.Point(14, 31);
            this.label_OptUpdate_Message1.Name = "label_OptUpdate_Message1";
            this.label_OptUpdate_Message1.Size = new System.Drawing.Size(125, 13);
            this.label_OptUpdate_Message1.TabIndex = 15;
            this.label_OptUpdate_Message1.Text = "Nothing to update ...";
            // 
            // panelOptions
            // 
            this.panelOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOptions.Location = new System.Drawing.Point(124, 14);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(800, 282);
            this.panelOptions.TabIndex = 1;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tabPageAbout.Controls.Add(this.textBoxAbout);
            this.tabPageAbout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPageAbout.Location = new System.Drawing.Point(4, 22);
            this.tabPageAbout.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Size = new System.Drawing.Size(918, 299);
            this.tabPageAbout.TabIndex = 2;
            this.tabPageAbout.Text = "About SQLAgain";
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
            this.textBoxAbout.Size = new System.Drawing.Size(918, 299);
            this.textBoxAbout.TabIndex = 0;
            this.textBoxAbout.Text = "";
            this.textBoxAbout.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.TextBoxAboutLink);
            // 
            // listView_DBs
            // 
            this.listView_DBs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.listView_DBs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_DBs.CheckBoxes = true;
            this.listView_DBs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_DBs.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.listView_DBs.FullRowSelect = true;
            this.listView_DBs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_DBs.HideSelection = false;
            this.listView_DBs.Location = new System.Drawing.Point(10, 18);
            this.listView_DBs.Margin = new System.Windows.Forms.Padding(2);
            this.listView_DBs.Name = "listView_DBs";
            this.listView_DBs.Size = new System.Drawing.Size(223, 267);
            this.listView_DBs.TabIndex = 0;
            this.listView_DBs.UseCompatibleStateImageBehavior = false;
            this.listView_DBs.View = System.Windows.Forms.View.Details;
            this.listView_DBs.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView_DBs_ItemChecked);
            this.listView_DBs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListView_DBs_KeyDown);
            this.listView_DBs.MouseLeave += new System.EventHandler(this.ListView_DBs_MouseLeave);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // buttonCancelSQL
            // 
            this.buttonCancelSQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.buttonCancelSQL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCancelSQL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancelSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelSQL.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonCancelSQL.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancelSQL.Image")));
            this.buttonCancelSQL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelSQL.Location = new System.Drawing.Point(9, 396);
            this.buttonCancelSQL.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancelSQL.Name = "buttonCancelSQL";
            this.buttonCancelSQL.Size = new System.Drawing.Size(93, 29);
            this.buttonCancelSQL.TabIndex = 1;
            this.buttonCancelSQL.Text = "Cancel";
            this.buttonCancelSQL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.progressBar1.Location = new System.Drawing.Point(14, 468);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.MarqueeAnimationSpeed = 30;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(926, 4);
            this.progressBar1.TabIndex = 23;
            this.progressBar1.Visible = false;
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
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(10, 40);
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
            this.label4.Location = new System.Drawing.Point(92, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sec.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label7.Location = new System.Drawing.Point(55, 60);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Min.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label8.Location = new System.Drawing.Point(10, 60);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Hours";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox8);
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.buttonRunSQL);
            this.panel1.Controls.Add(this.buttonScheduleSQL);
            this.panel1.Controls.Add(this.buttonCancelSQL);
            this.panel1.Location = new System.Drawing.Point(732, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 457);
            this.panel1.TabIndex = 2;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.checkBoxOptIgnoreError);
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.timeoutHH);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Controls.Add(this.timeoutMM);
            this.groupBox8.Controls.Add(this.timeoutSS);
            this.groupBox8.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox8.Location = new System.Drawing.Point(9, 230);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(200, 100);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "SQLAgain Runtime";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkBoxOptSilent);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.checkBoxOptHTML);
            this.groupBox7.Controls.Add(this.checkBoxOptCSV);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox7.Location = new System.Drawing.Point(9, 115);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 100);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "SQL*Plus Options";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.listBox_User);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox6.Location = new System.Drawing.Point(9, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 100);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "DB User";
            // 
            // labelDBsSelected
            // 
            this.labelDBsSelected.AutoSize = true;
            this.labelDBsSelected.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelDBsSelected.Location = new System.Drawing.Point(270, 235);
            this.labelDBsSelected.Name = "labelDBsSelected";
            this.labelDBsSelected.Size = new System.Drawing.Size(0, 13);
            this.labelDBsSelected.TabIndex = 33;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.buttonTNSPing);
            this.groupBox5.Controls.Add(this.labelDBsSelected);
            this.groupBox5.Controls.Add(this.labelDB);
            this.groupBox5.Controls.Add(this.listView_DBs);
            this.groupBox5.Controls.Add(this.listView_DBGroups);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox5.Location = new System.Drawing.Point(17, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(566, 325);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Databases";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label14.Location = new System.Drawing.Point(270, 18);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(144, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Select a Group of Databases";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label9);
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Controls.Add(this.textBox_SqlFile);
            this.groupBox9.Controls.Add(this.buttonSqlFile);
            this.groupBox9.Controls.Add(this.textBox_LogFile);
            this.groupBox9.Controls.Add(this.buttonViewLog);
            this.groupBox9.Controls.Add(this.checkBoxLog);
            this.groupBox9.Controls.Add(this.checkBoxLogAppend);
            this.groupBox9.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox9.Location = new System.Drawing.Point(17, 360);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(566, 100);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "SQL File";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label9.Location = new System.Drawing.Point(14, 71);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Log Filename";
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxStatus.Controls.Add(this.statusStrip1);
            this.groupBoxStatus.Location = new System.Drawing.Point(14, 810);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(926, 36);
            this.groupBoxStatus.TabIndex = 99;
            this.groupBoxStatus.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(3, 11);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(920, 22);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.toolStripStatusLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(954, 851);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBoxStatus);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "SQL again and again";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPageMessages.ResumeLayout(false);
            this.tabPageHistory.ResumeLayout(false);
            this.contextMenuSessionHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeoutHH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutMM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutSS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageFavorites.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.contextMenuFavorites.ResumeLayout(false);
            this.tabPageOptions.ResumeLayout(false);
            this.tabControloptions.ResumeLayout(false);
            this.tabPageOptionsEnvironment.ResumeLayout(false);
            this.tabPageOptionsEnvironment.PerformLayout();
            this.groupBox_OptEnv3.ResumeLayout(false);
            this.groupBox_OptEnv3.PerformLayout();
            this.groupBox_OptEnv2.ResumeLayout(false);
            this.groupBox_OptEnv2.PerformLayout();
            this.groupBox_OptEnv1.ResumeLayout(false);
            this.groupBox_OptEnv1.PerformLayout();
            this.tabPageOptionsDBs.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DBGroups)).EndInit();
            this.contextMenuOptDBGroups.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPageOptionsDBUser.ResumeLayout(false);
            this.groupBox_OptDBUser.ResumeLayout(false);
            this.groupBox_OptDBUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DBUsers)).EndInit();
            this.contextMenuOptDBUser.ResumeLayout(false);
            this.tabPageOptionsTaskScheduler.ResumeLayout(false);
            this.groupBox_OptJobScheduler.ResumeLayout(false);
            this.groupBox_OptJobScheduler.PerformLayout();
            this.tabPageOptionsMail.ResumeLayout(false);
            this.tabPageOptionsMail.PerformLayout();
            this.groupBox_OptMail.ResumeLayout(false);
            this.groupBox_OptMail.PerformLayout();
            this.tabPageOptionsCheckForUpdates.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.tabPageAbout.ResumeLayout(false);
            this.contextMenuStatusMessages.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxLog;
        private System.Windows.Forms.ListBox listBox_User;
        private System.Windows.Forms.Button buttonTNSPing;
        private System.Windows.Forms.TextBox textBox_SqlFile;
        private System.Windows.Forms.TextBox textBox_LogFile;
        private System.Windows.Forms.Button buttonRunSQL;
        private System.Windows.Forms.Button buttonSqlFile;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBoxOptSilent;
        private System.Windows.Forms.CheckBox checkBoxOptCSV;
        private System.Windows.Forms.CheckBox checkBoxOptHTML;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button buttonViewLog;
        private System.Windows.Forms.CheckBox checkBoxLogAppend;
        private System.Windows.Forms.Button buttonScheduleSQL;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMessages;
        private System.Windows.Forms.TabPage tabPageHistory;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.RichTextBox textBoxAbout;
        private System.Windows.Forms.RichTextBox textBoxSessionHistory;
        private System.Windows.Forms.ListView listView_DBs;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonCancelSQL;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuSessionHistory;
        private System.Windows.Forms.ToolStripMenuItem sessionHistoryEdit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStatusMessages;
        private System.Windows.Forms.ToolStripMenuItem statusMessagesClear;
        private System.Windows.Forms.ToolStripMenuItem sessionHistoryRefresh;
        private System.Windows.Forms.TabPage tabPageFavorites;
        private System.Windows.Forms.ListView listViewFavorites;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button_Favorites_Add;
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
        private System.Windows.Forms.CheckBox checkBoxOptIgnoreError;
        private System.Windows.Forms.Label labelDBsSelected;
        private System.Windows.Forms.TabPage tabPageOptions;
        private System.Windows.Forms.TabControl tabControloptions;
        private System.Windows.Forms.TabPage tabPageOptionsEnvironment;
        private System.Windows.Forms.TabPage tabPageOptionsDBs;
        private System.Windows.Forms.TabPage tabPageOptionsDBUser;
        private System.Windows.Forms.TabPage tabPageOptionsTaskScheduler;
        private System.Windows.Forms.TabPage tabPageOptionsMail;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox_OptEnv1;
        private System.Windows.Forms.CheckBox hidePasswords;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox textBox_OptEnv_SQLPATH;
        private System.Windows.Forms.TextBox textBox_OptEnv_TNS_ADMIN;
        private System.Windows.Forms.TextBox textBox_OptEnv_NLS_LANG;
        private System.Windows.Forms.GroupBox groupBox_OptEnv2;
        private System.Windows.Forms.Button button_OptEnv_SqlPlusPath;
        private System.Windows.Forms.TextBox textBox_OptEnv_SqlPlusPath;
        private System.Windows.Forms.Button button_OptEnv_TNS_ADMIN;
        private System.Windows.Forms.Button button_OptEnv_SQLPATH;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_OptDBGroup_ExcludeDBs;
        private System.Windows.Forms.DataGridView dataGridView_DBUsers;
        private System.Windows.Forms.ContextMenuStrip contextMenuOptDBUser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuOptDBUser_Up;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuOptDBUser_Down;
        private System.Windows.Forms.TextBox textBox_OptDBUser_NewUser;
        private System.Windows.Forms.TextBox textBox_OptDBUser_NewPassword;
        private System.Windows.Forms.TextBox textBox_OptDBUser_NewSchema;
        private System.Windows.Forms.CheckBox checkBox_OptDBUser_NewSYSDBA;
        private System.Windows.Forms.GroupBox groupBox_OptDBUser;
        private System.Windows.Forms.Button buttonOptDBUser_Add;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_OptDBGroup_NewColor;
        private System.Windows.Forms.TextBox textBox_OptDBGroup_NewRegExp;
        private System.Windows.Forms.TextBox textBox_OptDBGroup_NewName;
        private System.Windows.Forms.Button button_OptDBGroup_Add;
        private System.Windows.Forms.DataGridView dataGridView_DBGroups;
        private System.Windows.Forms.ListView listView_DBGroups;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox_OptJobScheduler;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_OptTask_Password;
        private System.Windows.Forms.TextBox textBox_OptTask_Username;
        private System.Windows.Forms.ContextMenuStrip contextMenuOptDBGroups;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuOptDBGroup_Up;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuOptDBGroup_Down;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox_OptMail;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox_OptMail_Password;
        private System.Windows.Forms.TextBox textBox_OptMail_User;
        private System.Windows.Forms.TextBox textBox_OptMail_Server;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button button_OptMail_Test;
        private System.Windows.Forms.TextBox textBox_OptMail_MailReceiver;
        private System.Windows.Forms.TextBox textBox_OptMail_MailSender;
        private System.Windows.Forms.CheckBox checkBox_OptMail_EnableSSL;
        private System.Windows.Forms.TabPage tabPageOptionsCheckForUpdates;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button button_OptUpdate_Update;
        private System.Windows.Forms.Label label_OptUpdate_Message1;
        private System.Windows.Forms.Label label_OptUpdate_Message2;
        private System.Windows.Forms.Label label_OptUpdate_Message3;
        private System.Windows.Forms.LinkLabel linkCheck4Update;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox textBox_Favorites_NewFile;
        private System.Windows.Forms.TextBox textBox_Favorites_NewDesc;
        private System.Windows.Forms.TextBox textBox_Favorites_NewUser;
        private System.Windows.Forms.TextBox textBox_Favorites_NewDBs;
        private System.Windows.Forms.ToolStripMenuItem favoritesMoveUp;
        private System.Windows.Forms.ToolStripMenuItem favoritesMoveDown;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_OptMail_Port;
        private System.Windows.Forms.GroupBox groupBox_OptEnv3;
        private System.Windows.Forms.CheckBox checkBox_OptEnv_Mode;
        private System.Windows.Forms.Label label19;
    }
}

