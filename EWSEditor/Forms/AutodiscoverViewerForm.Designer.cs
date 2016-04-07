namespace EWSEditor.Forms
{
    partial class AutodiscoverViewerForm
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
            this.GoRun = new System.Windows.Forms.Button();
            this.TargetMailboxLabel = new System.Windows.Forms.Label();
            this.TargetMailboxText = new System.Windows.Forms.TextBox();
            this.chkDefaultWindowsCredentials = new System.Windows.Forms.CheckBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDefaultUser = new System.Windows.Forms.Button();
            this.chkPreAuthenticate = new System.Windows.Forms.CheckBox();
            this.chkEnableScpLookup = new System.Windows.Forms.CheckBox();
            this.TempExchangeVersionCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.lvItems = new System.Windows.Forms.ListView();
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmboUserAgent = new System.Windows.Forms.ComboBox();
            this.chkOverrideUserAgent = new System.Windows.Forms.CheckBox();
            this.txtValues = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDefaultSmtp = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoSpecifyProxySettings = new System.Windows.Forms.RadioButton();
            this.rdoDontOverrideProxySettings = new System.Windows.Forms.RadioButton();
            this.txtProxyServerPort = new System.Windows.Forms.TextBox();
            this.lblProxyPort = new System.Windows.Forms.Label();
            this.txtProxyServerName = new System.Windows.Forms.TextBox();
            this.lblProxyServer = new System.Windows.Forms.Label();
            this.rdoUseAutoDiscover = new System.Windows.Forms.RadioButton();
            this.rdoUseUserSpecifiedUrl = new System.Windows.Forms.RadioButton();
            this.txtAutodiscoverServiceURL = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkOptHeader1 = new System.Windows.Forms.CheckBox();
            this.chkOptHeader2 = new System.Windows.Forms.CheckBox();
            this.chkOptHeader3 = new System.Windows.Forms.CheckBox();
            this.txtHeader1Name = new System.Windows.Forms.TextBox();
            this.txtHeader2Name = new System.Windows.Forms.TextBox();
            this.txtHeader3Name = new System.Windows.Forms.TextBox();
            this.txtHeader1Value = new System.Windows.Forms.TextBox();
            this.txtHeader2Value = new System.Windows.Forms.TextBox();
            this.txtHeader3Value = new System.Windows.Forms.TextBox();
            this.lblHeader1Value = new System.Windows.Forms.Label();
            this.lblHeader2Value = new System.Windows.Forms.Label();
            this.lblHeader3Value = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GoRun
            // 
            this.GoRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GoRun.Location = new System.Drawing.Point(900, 269);
            this.GoRun.Margin = new System.Windows.Forms.Padding(4);
            this.GoRun.Name = "GoRun";
            this.GoRun.Size = new System.Drawing.Size(105, 28);
            this.GoRun.TabIndex = 26;
            this.GoRun.Text = "Run";
            this.GoRun.UseVisualStyleBackColor = true;
            this.GoRun.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // TargetMailboxLabel
            // 
            this.TargetMailboxLabel.AutoSize = true;
            this.TargetMailboxLabel.Location = new System.Drawing.Point(2, 217);
            this.TargetMailboxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TargetMailboxLabel.Name = "TargetMailboxLabel";
            this.TargetMailboxLabel.Size = new System.Drawing.Size(101, 17);
            this.TargetMailboxLabel.TabIndex = 2;
            this.TargetMailboxLabel.Text = "Mailbox SMTP:";
            // 
            // TargetMailboxText
            // 
            this.TargetMailboxText.Location = new System.Drawing.Point(121, 212);
            this.TargetMailboxText.Margin = new System.Windows.Forms.Padding(4);
            this.TargetMailboxText.Name = "TargetMailboxText";
            this.TargetMailboxText.Size = new System.Drawing.Size(293, 22);
            this.TargetMailboxText.TabIndex = 3;
            // 
            // chkDefaultWindowsCredentials
            // 
            this.chkDefaultWindowsCredentials.AutoSize = true;
            this.chkDefaultWindowsCredentials.Checked = true;
            this.chkDefaultWindowsCredentials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefaultWindowsCredentials.Location = new System.Drawing.Point(8, 16);
            this.chkDefaultWindowsCredentials.Margin = new System.Windows.Forms.Padding(4);
            this.chkDefaultWindowsCredentials.Name = "chkDefaultWindowsCredentials";
            this.chkDefaultWindowsCredentials.Size = new System.Drawing.Size(210, 21);
            this.chkDefaultWindowsCredentials.TabIndex = 0;
            this.chkDefaultWindowsCredentials.Text = "Default Windows Credentials";
            this.chkDefaultWindowsCredentials.UseVisualStyleBackColor = true;
            this.chkDefaultWindowsCredentials.CheckedChanged += new System.EventHandler(this.chkDefaultWindowsCredentials_CheckedChanged);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(109, 37);
            this.txtUser.Margin = new System.Windows.Forms.Padding(1);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(293, 22);
            this.txtUser.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(109, 62);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(1);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(293, 22);
            this.txtPassword.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Domain:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(109, 86);
            this.txtDomain.Margin = new System.Windows.Forms.Padding(1);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(293, 22);
            this.txtDomain.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDefaultUser);
            this.groupBox1.Controls.Add(this.txtDomain);
            this.groupBox1.Controls.Add(this.chkDefaultWindowsCredentials);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 93);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(499, 117);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnDefaultUser
            // 
            this.btnDefaultUser.Location = new System.Drawing.Point(423, 37);
            this.btnDefaultUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnDefaultUser.Name = "btnDefaultUser";
            this.btnDefaultUser.Size = new System.Drawing.Size(68, 28);
            this.btnDefaultUser.TabIndex = 3;
            this.btnDefaultUser.Text = "Default";
            this.btnDefaultUser.UseVisualStyleBackColor = true;
            this.btnDefaultUser.Click += new System.EventHandler(this.btnDefaultUser_Click);
            // 
            // chkPreAuthenticate
            // 
            this.chkPreAuthenticate.AutoSize = true;
            this.chkPreAuthenticate.Location = new System.Drawing.Point(516, 67);
            this.chkPreAuthenticate.Margin = new System.Windows.Forms.Padding(4);
            this.chkPreAuthenticate.Name = "chkPreAuthenticate";
            this.chkPreAuthenticate.Size = new System.Drawing.Size(236, 21);
            this.chkPreAuthenticate.TabIndex = 8;
            this.chkPreAuthenticate.Text = "Pre-Authenticate HTTP requests";
            this.chkPreAuthenticate.UseVisualStyleBackColor = true;
            // 
            // chkEnableScpLookup
            // 
            this.chkEnableScpLookup.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkEnableScpLookup.Checked = true;
            this.chkEnableScpLookup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableScpLookup.Location = new System.Drawing.Point(517, 12);
            this.chkEnableScpLookup.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnableScpLookup.Name = "chkEnableScpLookup";
            this.chkEnableScpLookup.Size = new System.Drawing.Size(298, 39);
            this.chkEnableScpLookup.TabIndex = 7;
            this.chkEnableScpLookup.Text = "Enable SCP record lookup (Disabling will skip AD lookup of Autodiscover URLs)";
            this.chkEnableScpLookup.UseVisualStyleBackColor = true;
            // 
            // TempExchangeVersionCombo
            // 
            this.TempExchangeVersionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempExchangeVersionCombo.FormattingEnabled = true;
            this.TempExchangeVersionCombo.Location = new System.Drawing.Point(121, 239);
            this.TempExchangeVersionCombo.Margin = new System.Windows.Forms.Padding(4);
            this.TempExchangeVersionCombo.Name = "TempExchangeVersionCombo";
            this.TempExchangeVersionCombo.Size = new System.Drawing.Size(293, 24);
            this.TempExchangeVersionCombo.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 239);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "EWS Schema:";
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Location = new System.Drawing.Point(5, 307);
            this.txtResults.Margin = new System.Windows.Forms.Padding(4);
            this.txtResults.MaxLength = 0;
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(1006, 74);
            this.txtResults.TabIndex = 28;
            // 
            // lvItems
            // 
            this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colType,
            this.colValue});
            this.lvItems.FullRowSelect = true;
            this.lvItems.Location = new System.Drawing.Point(5, 404);
            this.lvItems.Margin = new System.Windows.Forms.Padding(4);
            this.lvItems.MultiSelect = false;
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(1006, 84);
            this.lvItems.TabIndex = 30;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.Details;
            this.lvItems.SelectedIndexChanged += new System.EventHandler(this.lvItems_SelectedIndexChanged);
            this.lvItems.Click += new System.EventHandler(this.lvItems_Click);
            this.lvItems.DoubleClick += new System.EventHandler(this.lvItems_DoubleClick);
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 300;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.Width = 500;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 383);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Data:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 287);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Errors:";
            // 
            // cmboUserAgent
            // 
            this.cmboUserAgent.FormattingEnabled = true;
            this.cmboUserAgent.Location = new System.Drawing.Point(541, 137);
            this.cmboUserAgent.Margin = new System.Windows.Forms.Padding(4);
            this.cmboUserAgent.Name = "cmboUserAgent";
            this.cmboUserAgent.Size = new System.Drawing.Size(470, 24);
            this.cmboUserAgent.TabIndex = 10;
            // 
            // chkOverrideUserAgent
            // 
            this.chkOverrideUserAgent.AutoSize = true;
            this.chkOverrideUserAgent.Location = new System.Drawing.Point(516, 109);
            this.chkOverrideUserAgent.Margin = new System.Windows.Forms.Padding(4);
            this.chkOverrideUserAgent.Name = "chkOverrideUserAgent";
            this.chkOverrideUserAgent.Size = new System.Drawing.Size(165, 21);
            this.chkOverrideUserAgent.TabIndex = 9;
            this.chkOverrideUserAgent.Text = "Override User-Agent:";
            this.chkOverrideUserAgent.UseVisualStyleBackColor = true;
            this.chkOverrideUserAgent.CheckedChanged += new System.EventHandler(this.chkOverrideUserAgent_CheckedChanged);
            // 
            // txtValues
            // 
            this.txtValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValues.Location = new System.Drawing.Point(5, 511);
            this.txtValues.Margin = new System.Windows.Forms.Padding(4);
            this.txtValues.MaxLength = 0;
            this.txtValues.Multiline = true;
            this.txtValues.Name = "txtValues";
            this.txtValues.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtValues.Size = new System.Drawing.Size(1006, 82);
            this.txtValues.TabIndex = 32;
            this.txtValues.TextChanged += new System.EventHandler(this.txtValues_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 490);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 17);
            this.label6.TabIndex = 31;
            this.label6.Text = "Value (shows multiple lines):";
            // 
            // btnDefaultSmtp
            // 
            this.btnDefaultSmtp.Location = new System.Drawing.Point(435, 212);
            this.btnDefaultSmtp.Margin = new System.Windows.Forms.Padding(4);
            this.btnDefaultSmtp.Name = "btnDefaultSmtp";
            this.btnDefaultSmtp.Size = new System.Drawing.Size(65, 28);
            this.btnDefaultSmtp.TabIndex = 4;
            this.btnDefaultSmtp.Text = "Default";
            this.btnDefaultSmtp.UseVisualStyleBackColor = true;
            this.btnDefaultSmtp.Click += new System.EventHandler(this.btnDefaultSmtp_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoSpecifyProxySettings);
            this.groupBox3.Controls.Add(this.rdoDontOverrideProxySettings);
            this.groupBox3.Controls.Add(this.txtProxyServerPort);
            this.groupBox3.Controls.Add(this.lblProxyPort);
            this.groupBox3.Controls.Add(this.txtProxyServerName);
            this.groupBox3.Controls.Add(this.lblProxyServer);
            this.groupBox3.Location = new System.Drawing.Point(811, 5);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(200, 129);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set WebProxy Settings";
            // 
            // rdoSpecifyProxySettings
            // 
            this.rdoSpecifyProxySettings.AutoSize = true;
            this.rdoSpecifyProxySettings.Location = new System.Drawing.Point(12, 48);
            this.rdoSpecifyProxySettings.Margin = new System.Windows.Forms.Padding(4);
            this.rdoSpecifyProxySettings.Name = "rdoSpecifyProxySettings";
            this.rdoSpecifyProxySettings.Size = new System.Drawing.Size(169, 21);
            this.rdoSpecifyProxySettings.TabIndex = 1;
            this.rdoSpecifyProxySettings.Text = "Specify Proxy Settings";
            this.rdoSpecifyProxySettings.UseVisualStyleBackColor = true;
            // 
            // rdoDontOverrideProxySettings
            // 
            this.rdoDontOverrideProxySettings.AutoSize = true;
            this.rdoDontOverrideProxySettings.Checked = true;
            this.rdoDontOverrideProxySettings.Location = new System.Drawing.Point(11, 21);
            this.rdoDontOverrideProxySettings.Margin = new System.Windows.Forms.Padding(4);
            this.rdoDontOverrideProxySettings.Name = "rdoDontOverrideProxySettings";
            this.rdoDontOverrideProxySettings.Size = new System.Drawing.Size(176, 21);
            this.rdoDontOverrideProxySettings.TabIndex = 0;
            this.rdoDontOverrideProxySettings.TabStop = true;
            this.rdoDontOverrideProxySettings.Text = "Don\'t Override Settings";
            this.rdoDontOverrideProxySettings.UseVisualStyleBackColor = true;
            // 
            // txtProxyServerPort
            // 
            this.txtProxyServerPort.Location = new System.Drawing.Point(91, 98);
            this.txtProxyServerPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtProxyServerPort.Name = "txtProxyServerPort";
            this.txtProxyServerPort.Size = new System.Drawing.Size(101, 22);
            this.txtProxyServerPort.TabIndex = 5;
            this.txtProxyServerPort.Text = "8888";
            // 
            // lblProxyPort
            // 
            this.lblProxyPort.Location = new System.Drawing.Point(33, 99);
            this.lblProxyPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProxyPort.Name = "lblProxyPort";
            this.lblProxyPort.Size = new System.Drawing.Size(45, 21);
            this.lblProxyPort.TabIndex = 4;
            this.lblProxyPort.Text = "Port:";
            // 
            // txtProxyServerName
            // 
            this.txtProxyServerName.Location = new System.Drawing.Point(91, 69);
            this.txtProxyServerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProxyServerName.Name = "txtProxyServerName";
            this.txtProxyServerName.Size = new System.Drawing.Size(101, 22);
            this.txtProxyServerName.TabIndex = 3;
            this.txtProxyServerName.Text = "127.0.0.1";
            // 
            // lblProxyServer
            // 
            this.lblProxyServer.Location = new System.Drawing.Point(33, 72);
            this.lblProxyServer.Margin = new System.Windows.Forms.Padding(1);
            this.lblProxyServer.Name = "lblProxyServer";
            this.lblProxyServer.Size = new System.Drawing.Size(62, 22);
            this.lblProxyServer.TabIndex = 2;
            this.lblProxyServer.Text = "Server:";
            // 
            // rdoUseAutoDiscover
            // 
            this.rdoUseAutoDiscover.AutoSize = true;
            this.rdoUseAutoDiscover.Checked = true;
            this.rdoUseAutoDiscover.Location = new System.Drawing.Point(8, 25);
            this.rdoUseAutoDiscover.Margin = new System.Windows.Forms.Padding(4);
            this.rdoUseAutoDiscover.Name = "rdoUseAutoDiscover";
            this.rdoUseAutoDiscover.Size = new System.Drawing.Size(353, 21);
            this.rdoUseAutoDiscover.TabIndex = 0;
            this.rdoUseAutoDiscover.TabStop = true;
            this.rdoUseAutoDiscover.Text = "Use Autodiscover to get AutoDiscover service URL.";
            this.rdoUseAutoDiscover.UseVisualStyleBackColor = true;
            this.rdoUseAutoDiscover.CheckedChanged += new System.EventHandler(this.rdoUseAutoDiscover_CheckedChanged);
            // 
            // rdoUseUserSpecifiedUrl
            // 
            this.rdoUseUserSpecifiedUrl.AutoSize = true;
            this.rdoUseUserSpecifiedUrl.Location = new System.Drawing.Point(7, 54);
            this.rdoUseUserSpecifiedUrl.Margin = new System.Windows.Forms.Padding(4);
            this.rdoUseUserSpecifiedUrl.Name = "rdoUseUserSpecifiedUrl";
            this.rdoUseUserSpecifiedUrl.Size = new System.Drawing.Size(61, 21);
            this.rdoUseUserSpecifiedUrl.TabIndex = 1;
            this.rdoUseUserSpecifiedUrl.Text = "URL:";
            this.rdoUseUserSpecifiedUrl.UseVisualStyleBackColor = true;
            this.rdoUseUserSpecifiedUrl.CheckedChanged += new System.EventHandler(this.rdoUseUserSpecifiedUrl_CheckedChanged);
            // 
            // txtAutodiscoverServiceURL
            // 
            this.txtAutodiscoverServiceURL.Location = new System.Drawing.Point(68, 53);
            this.txtAutodiscoverServiceURL.Margin = new System.Windows.Forms.Padding(4);
            this.txtAutodiscoverServiceURL.Name = "txtAutodiscoverServiceURL";
            this.txtAutodiscoverServiceURL.Size = new System.Drawing.Size(423, 22);
            this.txtAutodiscoverServiceURL.TabIndex = 2;
            this.txtAutodiscoverServiceURL.Text = "https://autodiscover-s.outlook.com/autodiscover/autodiscover.svc";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAutodiscoverServiceURL);
            this.groupBox2.Controls.Add(this.rdoUseAutoDiscover);
            this.groupBox2.Controls.Add(this.rdoUseUserSpecifiedUrl);
            this.groupBox2.Location = new System.Drawing.Point(12, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 82);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AutoDiscover Service";
            // 
            // chkOptHeader1
            // 
            this.chkOptHeader1.AutoSize = true;
            this.chkOptHeader1.Location = new System.Drawing.Point(541, 184);
            this.chkOptHeader1.Margin = new System.Windows.Forms.Padding(4);
            this.chkOptHeader1.Name = "chkOptHeader1";
            this.chkOptHeader1.Size = new System.Drawing.Size(89, 21);
            this.chkOptHeader1.TabIndex = 12;
            this.chkOptHeader1.Text = "Header 1";
            this.chkOptHeader1.UseVisualStyleBackColor = true;
            this.chkOptHeader1.CheckedChanged += new System.EventHandler(this.chkOptHeader1_CheckedChanged);
            // 
            // chkOptHeader2
            // 
            this.chkOptHeader2.AutoSize = true;
            this.chkOptHeader2.Location = new System.Drawing.Point(541, 214);
            this.chkOptHeader2.Margin = new System.Windows.Forms.Padding(4);
            this.chkOptHeader2.Name = "chkOptHeader2";
            this.chkOptHeader2.Size = new System.Drawing.Size(89, 21);
            this.chkOptHeader2.TabIndex = 16;
            this.chkOptHeader2.Text = "Header 2";
            this.chkOptHeader2.UseVisualStyleBackColor = true;
            this.chkOptHeader2.CheckedChanged += new System.EventHandler(this.chkOptHeader2_CheckedChanged);
            // 
            // chkOptHeader3
            // 
            this.chkOptHeader3.AutoSize = true;
            this.chkOptHeader3.Location = new System.Drawing.Point(541, 241);
            this.chkOptHeader3.Margin = new System.Windows.Forms.Padding(4);
            this.chkOptHeader3.Name = "chkOptHeader3";
            this.chkOptHeader3.Size = new System.Drawing.Size(89, 21);
            this.chkOptHeader3.TabIndex = 20;
            this.chkOptHeader3.Text = "Header 3";
            this.chkOptHeader3.UseVisualStyleBackColor = true;
            this.chkOptHeader3.CheckedChanged += new System.EventHandler(this.chkOptHeader3_CheckedChanged);
            // 
            // txtHeader1Name
            // 
            this.txtHeader1Name.Location = new System.Drawing.Point(635, 182);
            this.txtHeader1Name.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeader1Name.Name = "txtHeader1Name";
            this.txtHeader1Name.Size = new System.Drawing.Size(152, 22);
            this.txtHeader1Name.TabIndex = 13;
            // 
            // txtHeader2Name
            // 
            this.txtHeader2Name.Location = new System.Drawing.Point(635, 212);
            this.txtHeader2Name.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeader2Name.Name = "txtHeader2Name";
            this.txtHeader2Name.Size = new System.Drawing.Size(152, 22);
            this.txtHeader2Name.TabIndex = 17;
            // 
            // txtHeader3Name
            // 
            this.txtHeader3Name.Location = new System.Drawing.Point(635, 239);
            this.txtHeader3Name.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeader3Name.Name = "txtHeader3Name";
            this.txtHeader3Name.Size = new System.Drawing.Size(152, 22);
            this.txtHeader3Name.TabIndex = 21;
            // 
            // txtHeader1Value
            // 
            this.txtHeader1Value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeader1Value.Location = new System.Drawing.Point(847, 182);
            this.txtHeader1Value.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeader1Value.Name = "txtHeader1Value";
            this.txtHeader1Value.Size = new System.Drawing.Size(158, 22);
            this.txtHeader1Value.TabIndex = 15;
            // 
            // txtHeader2Value
            // 
            this.txtHeader2Value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeader2Value.Location = new System.Drawing.Point(847, 211);
            this.txtHeader2Value.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeader2Value.Name = "txtHeader2Value";
            this.txtHeader2Value.Size = new System.Drawing.Size(158, 22);
            this.txtHeader2Value.TabIndex = 19;
            // 
            // txtHeader3Value
            // 
            this.txtHeader3Value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeader3Value.Location = new System.Drawing.Point(847, 239);
            this.txtHeader3Value.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeader3Value.Name = "txtHeader3Value";
            this.txtHeader3Value.Size = new System.Drawing.Size(158, 22);
            this.txtHeader3Value.TabIndex = 23;
            // 
            // lblHeader1Value
            // 
            this.lblHeader1Value.AutoSize = true;
            this.lblHeader1Value.Location = new System.Drawing.Point(795, 181);
            this.lblHeader1Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader1Value.Name = "lblHeader1Value";
            this.lblHeader1Value.Size = new System.Drawing.Size(48, 17);
            this.lblHeader1Value.TabIndex = 14;
            this.lblHeader1Value.Text = "Value:";
            // 
            // lblHeader2Value
            // 
            this.lblHeader2Value.AutoSize = true;
            this.lblHeader2Value.Location = new System.Drawing.Point(795, 214);
            this.lblHeader2Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader2Value.Name = "lblHeader2Value";
            this.lblHeader2Value.Size = new System.Drawing.Size(48, 17);
            this.lblHeader2Value.TabIndex = 18;
            this.lblHeader2Value.Text = "Value:";
            // 
            // lblHeader3Value
            // 
            this.lblHeader3Value.AutoSize = true;
            this.lblHeader3Value.Location = new System.Drawing.Point(795, 242);
            this.lblHeader3Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader3Value.Name = "lblHeader3Value";
            this.lblHeader3Value.Size = new System.Drawing.Size(48, 17);
            this.lblHeader3Value.TabIndex = 22;
            this.lblHeader3Value.Text = "Value:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(521, 163);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 17);
            this.label11.TabIndex = 11;
            this.label11.Text = "Optional Headers:";
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfo.Location = new System.Drawing.Point(5, 268);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(871, 15);
            this.txtInfo.TabIndex = 25;
            // 
            // AutodiscoverViewerForm
            // 
            this.AcceptButton = this.GoRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1016, 595);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblHeader3Value);
            this.Controls.Add(this.lblHeader2Value);
            this.Controls.Add(this.lblHeader1Value);
            this.Controls.Add(this.txtHeader3Value);
            this.Controls.Add(this.txtHeader2Value);
            this.Controls.Add(this.txtHeader1Value);
            this.Controls.Add(this.txtHeader3Name);
            this.Controls.Add(this.txtHeader2Name);
            this.Controls.Add(this.txtHeader1Name);
            this.Controls.Add(this.chkOptHeader3);
            this.Controls.Add(this.chkOptHeader2);
            this.Controls.Add(this.chkOptHeader1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnDefaultSmtp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtValues);
            this.Controls.Add(this.chkOverrideUserAgent);
            this.Controls.Add(this.cmboUserAgent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lvItems);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.chkPreAuthenticate);
            this.Controls.Add(this.chkEnableScpLookup);
            this.Controls.Add(this.TempExchangeVersionCombo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TargetMailboxLabel);
            this.Controls.Add(this.TargetMailboxText);
            this.Controls.Add(this.GoRun);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AutodiscoverViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Autodiscover Viewer";
            this.Load += new System.EventHandler(this.AutodiscoverViewerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GoRun;
        private System.Windows.Forms.Label TargetMailboxLabel;
        private System.Windows.Forms.TextBox TargetMailboxText;
        private System.Windows.Forms.CheckBox chkDefaultWindowsCredentials;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPreAuthenticate;
        private System.Windows.Forms.CheckBox chkEnableScpLookup;
        private System.Windows.Forms.ComboBox TempExchangeVersionCombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmboUserAgent;
        private System.Windows.Forms.CheckBox chkOverrideUserAgent;
        private System.Windows.Forms.TextBox txtValues;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDefaultUser;
        private System.Windows.Forms.Button btnDefaultSmtp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoSpecifyProxySettings;
        private System.Windows.Forms.RadioButton rdoDontOverrideProxySettings;
        private System.Windows.Forms.TextBox txtProxyServerPort;
        private System.Windows.Forms.Label lblProxyPort;
        private System.Windows.Forms.TextBox txtProxyServerName;
        private System.Windows.Forms.Label lblProxyServer;
        private System.Windows.Forms.RadioButton rdoUseAutoDiscover;
        private System.Windows.Forms.RadioButton rdoUseUserSpecifiedUrl;
        private System.Windows.Forms.TextBox txtAutodiscoverServiceURL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkOptHeader1;
        private System.Windows.Forms.CheckBox chkOptHeader2;
        private System.Windows.Forms.CheckBox chkOptHeader3;
        private System.Windows.Forms.TextBox txtHeader1Name;
        private System.Windows.Forms.TextBox txtHeader2Name;
        private System.Windows.Forms.TextBox txtHeader3Name;
        private System.Windows.Forms.TextBox txtHeader1Value;
        private System.Windows.Forms.TextBox txtHeader2Value;
        private System.Windows.Forms.TextBox txtHeader3Value;
        private System.Windows.Forms.Label lblHeader1Value;
        private System.Windows.Forms.Label lblHeader2Value;
        private System.Windows.Forms.Label lblHeader3Value;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtInfo;

    }
}
