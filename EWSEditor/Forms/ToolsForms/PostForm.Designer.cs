namespace EWSEditor.Common
{
    partial class PostForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmboAuthentication = new System.Windows.Forms.ComboBox();
            this.lblAuthentication = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.GoRun = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmboVerb = new System.Windows.Forms.ComboBox();
            this.cmboContentType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownTimeoutSeconds = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLoadExample = new System.Windows.Forms.Button();
            this.btnSaveExample = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadSettings = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.chkTranslateF = new System.Windows.Forms.CheckBox();
            this.chkPragmaNocache = new System.Windows.Forms.CheckBox();
            this.chkAllowRedirect = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.wbRequest = new System.Windows.Forms.WebBrowser();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.wbResponse = new System.Windows.Forms.WebBrowser();
            this.txtResponseSummary = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddQuickHeaders = new System.Windows.Forms.Button();
            this.dgvOptions = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteHeader = new System.Windows.Forms.Button();
            this.btnAddHeaders = new System.Windows.Forms.Button();
            this.grpHttpVerbOptions = new System.Windows.Forms.GroupBox();
            this.cmboUserAgent = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoSpecifyProxySettings = new System.Windows.Forms.RadioButton();
            this.rdoDontOverrideProxySettings = new System.Windows.Forms.RadioButton();
            this.txtProxyServerPort = new System.Windows.Forms.TextBox();
            this.lblProxyPort = new System.Windows.Forms.Label();
            this.txtProxyServerName = new System.Windows.Forms.TextBox();
            this.lblProxyServer = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkLogCalls = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeoutSeconds)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOptions)).BeginInit();
            this.grpHttpVerbOptions.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmboAuthentication);
            this.groupBox1.Controls.Add(this.lblAuthentication);
            this.groupBox1.Controls.Add(this.txtDomain);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(11, 74);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(475, 195);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // cmboAuthentication
            // 
            this.cmboAuthentication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmboAuthentication.FormattingEnabled = true;
            this.cmboAuthentication.Items.AddRange(new object[] {
            "DefaultNetworkCredentials",
            "DefaultCredentials",
            "Basic",
            "NTLM",
            "Kerberos",
            "Negotiate",
            "Digest"});
            this.cmboAuthentication.Location = new System.Drawing.Point(125, 22);
            this.cmboAuthentication.Margin = new System.Windows.Forms.Padding(6);
            this.cmboAuthentication.Name = "cmboAuthentication";
            this.cmboAuthentication.Size = new System.Drawing.Size(337, 33);
            this.cmboAuthentication.TabIndex = 1;
            this.cmboAuthentication.Text = "Basic";
            this.cmboAuthentication.SelectedIndexChanged += new System.EventHandler(this.cmboAuthentication_SelectedIndexChanged);
            // 
            // lblAuthentication
            // 
            this.lblAuthentication.AutoSize = true;
            this.lblAuthentication.Location = new System.Drawing.Point(11, 21);
            this.lblAuthentication.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAuthentication.Name = "lblAuthentication";
            this.lblAuthentication.Size = new System.Drawing.Size(62, 25);
            this.lblAuthentication.TabIndex = 0;
            this.lblAuthentication.Text = "Auth:";
            // 
            // txtDomain
            // 
            this.txtDomain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDomain.Location = new System.Drawing.Point(125, 138);
            this.txtDomain.Margin = new System.Windows.Forms.Padding(6);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(337, 31);
            this.txtDomain.TabIndex = 7;
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(125, 60);
            this.txtUser.Margin = new System.Windows.Forms.Padding(6);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(337, 31);
            this.txtUser.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(125, 101);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(6);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(337, 31);
            this.txtPassword.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 141);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Domain:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(96, 285);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(6);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(1890, 31);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.Text = "https://outlook.office365.com/EWS/Exchange.asmx";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 288);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 47;
            this.label4.Text = "URL:";
            // 
            // txtRequest
            // 
            this.txtRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequest.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRequest.Location = new System.Drawing.Point(11, 10);
            this.txtRequest.Margin = new System.Windows.Forms.Padding(6);
            this.txtRequest.MaxLength = 0;
            this.txtRequest.Multiline = true;
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRequest.Size = new System.Drawing.Size(1910, 131);
            this.txtRequest.TabIndex = 1;
            this.txtRequest.WordWrap = false;
            // 
            // txtResponse
            // 
            this.txtResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponse.Location = new System.Drawing.Point(6, 6);
            this.txtResponse.Margin = new System.Windows.Forms.Padding(6);
            this.txtResponse.MaxLength = 0;
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResponse.Size = new System.Drawing.Size(1930, 171);
            this.txtResponse.TabIndex = 2;
            this.txtResponse.WordWrap = false;
            this.txtResponse.TextChanged += new System.EventHandler(this.txtResponse_TextChanged);
            // 
            // GoRun
            // 
            this.GoRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GoRun.Location = new System.Drawing.Point(1821, 16);
            this.GoRun.Margin = new System.Windows.Forms.Padding(6);
            this.GoRun.Name = "GoRun";
            this.GoRun.Size = new System.Drawing.Size(162, 45);
            this.GoRun.TabIndex = 2;
            this.GoRun.Text = "Run";
            this.GoRun.UseVisualStyleBackColor = true;
            this.GoRun.Click += new System.EventHandler(this.GoRun_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 67);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "ContentType:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Verb:";
            // 
            // cmboVerb
            // 
            this.cmboVerb.FormattingEnabled = true;
            this.cmboVerb.Items.AddRange(new object[] {
            "POST",
            "GET",
            "PUT",
            "RAW"});
            this.cmboVerb.Location = new System.Drawing.Point(182, 22);
            this.cmboVerb.Margin = new System.Windows.Forms.Padding(6);
            this.cmboVerb.Name = "cmboVerb";
            this.cmboVerb.Size = new System.Drawing.Size(252, 33);
            this.cmboVerb.TabIndex = 1;
            this.cmboVerb.Text = "POST";
            this.cmboVerb.SelectedIndexChanged += new System.EventHandler(this.cmboVerb_SelectedIndexChanged);
            // 
            // cmboContentType
            // 
            this.cmboContentType.FormattingEnabled = true;
            this.cmboContentType.Items.AddRange(new object[] {
            "text/xml",
            "text/html"});
            this.cmboContentType.Location = new System.Drawing.Point(182, 64);
            this.cmboContentType.Margin = new System.Windows.Forms.Padding(6);
            this.cmboContentType.Name = "cmboContentType";
            this.cmboContentType.Size = new System.Drawing.Size(252, 33);
            this.cmboContentType.TabIndex = 3;
            this.cmboContentType.Text = "text/xml";
            this.cmboContentType.SelectedIndexChanged += new System.EventHandler(this.cmboContentType_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 107);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 25);
            this.label9.TabIndex = 4;
            this.label9.Text = "Timeout Secs:";
            // 
            // numericUpDownTimeoutSeconds
            // 
            this.numericUpDownTimeoutSeconds.Location = new System.Drawing.Point(182, 105);
            this.numericUpDownTimeoutSeconds.Margin = new System.Windows.Forms.Padding(6);
            this.numericUpDownTimeoutSeconds.Name = "numericUpDownTimeoutSeconds";
            this.numericUpDownTimeoutSeconds.Size = new System.Drawing.Size(256, 31);
            this.numericUpDownTimeoutSeconds.TabIndex = 5;
            this.numericUpDownTimeoutSeconds.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnLoadExample);
            this.panel2.Controls.Add(this.btnSaveExample);
            this.panel2.Location = new System.Drawing.Point(464, 9);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(443, 52);
            this.panel2.TabIndex = 1;
            // 
            // btnLoadExample
            // 
            this.btnLoadExample.Location = new System.Drawing.Point(6, 6);
            this.btnLoadExample.Margin = new System.Windows.Forms.Padding(6);
            this.btnLoadExample.Name = "btnLoadExample";
            this.btnLoadExample.Size = new System.Drawing.Size(207, 42);
            this.btnLoadExample.TabIndex = 0;
            this.btnLoadExample.Text = "Load Example";
            this.btnLoadExample.UseVisualStyleBackColor = true;
            this.btnLoadExample.Click += new System.EventHandler(this.btnLoadExample_Click);
            // 
            // btnSaveExample
            // 
            this.btnSaveExample.Location = new System.Drawing.Point(225, 5);
            this.btnSaveExample.Margin = new System.Windows.Forms.Padding(6);
            this.btnSaveExample.Name = "btnSaveExample";
            this.btnSaveExample.Size = new System.Drawing.Size(207, 42);
            this.btnSaveExample.TabIndex = 1;
            this.btnSaveExample.Text = "Save Example";
            this.btnSaveExample.UseVisualStyleBackColor = true;
            this.btnSaveExample.Click += new System.EventHandler(this.btnSaveExample_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnLoadSettings);
            this.panel1.Controls.Add(this.btnSaveSettings);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 52);
            this.panel1.TabIndex = 0;
            // 
            // btnLoadSettings
            // 
            this.btnLoadSettings.Location = new System.Drawing.Point(6, 6);
            this.btnLoadSettings.Margin = new System.Windows.Forms.Padding(6);
            this.btnLoadSettings.Name = "btnLoadSettings";
            this.btnLoadSettings.Size = new System.Drawing.Size(207, 42);
            this.btnLoadSettings.TabIndex = 0;
            this.btnLoadSettings.Text = "Load Settings";
            this.btnLoadSettings.UseVisualStyleBackColor = true;
            this.btnLoadSettings.Click += new System.EventHandler(this.btnLoadSettings_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(225, 6);
            this.btnSaveSettings.Margin = new System.Windows.Forms.Padding(6);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(207, 42);
            this.btnSaveSettings.TabIndex = 1;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 149);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 25);
            this.label11.TabIndex = 6;
            this.label11.Text = "UserAgent:";
            // 
            // chkTranslateF
            // 
            this.chkTranslateF.AutoSize = true;
            this.chkTranslateF.Location = new System.Drawing.Point(472, 69);
            this.chkTranslateF.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.chkTranslateF.Name = "chkTranslateF";
            this.chkTranslateF.Size = new System.Drawing.Size(159, 29);
            this.chkTranslateF.TabIndex = 9;
            this.chkTranslateF.Text = "Translate: F";
            this.chkTranslateF.UseVisualStyleBackColor = true;
            // 
            // chkPragmaNocache
            // 
            this.chkPragmaNocache.AutoSize = true;
            this.chkPragmaNocache.Checked = true;
            this.chkPragmaNocache.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPragmaNocache.Location = new System.Drawing.Point(472, 24);
            this.chkPragmaNocache.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.chkPragmaNocache.Name = "chkPragmaNocache";
            this.chkPragmaNocache.Size = new System.Drawing.Size(219, 29);
            this.chkPragmaNocache.TabIndex = 8;
            this.chkPragmaNocache.Text = "Pragma: no-cache";
            this.chkPragmaNocache.UseVisualStyleBackColor = true;
            // 
            // chkAllowRedirect
            // 
            this.chkAllowRedirect.AutoSize = true;
            this.chkAllowRedirect.Location = new System.Drawing.Point(472, 110);
            this.chkAllowRedirect.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.chkAllowRedirect.Name = "chkAllowRedirect";
            this.chkAllowRedirect.Size = new System.Drawing.Size(181, 29);
            this.chkAllowRedirect.TabIndex = 10;
            this.chkAllowRedirect.Text = "AllowRedirect:";
            this.chkAllowRedirect.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(8, 3);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1956, 228);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtRequest);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tabPage1.Size = new System.Drawing.Size(1940, 181);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Request Text";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.wbRequest);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tabPage2.Size = new System.Drawing.Size(1940, 181);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Xml View of Request Text (Read Only)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // wbRequest
            // 
            this.wbRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbRequest.CausesValidation = false;
            this.wbRequest.Location = new System.Drawing.Point(5, 6);
            this.wbRequest.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.wbRequest.MinimumSize = new System.Drawing.Size(29, 26);
            this.wbRequest.Name = "wbRequest";
            this.wbRequest.Size = new System.Drawing.Size(1916, 140);
            this.wbRequest.TabIndex = 48;
            this.wbRequest.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbRequest_DocumentCompleted);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1954, 225);
            this.tabControl2.TabIndex = 3;
            this.tabControl2.Click += new System.EventHandler(this.tabControl2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtResponse);
            this.tabPage3.Location = new System.Drawing.Point(8, 39);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tabPage3.Size = new System.Drawing.Size(1938, 178);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Response Text";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.wbResponse);
            this.tabPage4.Location = new System.Drawing.Point(8, 39);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tabPage4.Size = new System.Drawing.Size(1938, 178);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Response XML (Read Only)";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // wbResponse
            // 
            this.wbResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbResponse.CausesValidation = false;
            this.wbResponse.Location = new System.Drawing.Point(5, 6);
            this.wbResponse.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.wbResponse.MinimumSize = new System.Drawing.Size(29, 26);
            this.wbResponse.Name = "wbResponse";
            this.wbResponse.ScriptErrorsSuppressed = true;
            this.wbResponse.Size = new System.Drawing.Size(2126, 214);
            this.wbResponse.TabIndex = 49;
            this.wbResponse.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbResponse_DocumentCompleted);
            // 
            // txtResponseSummary
            // 
            this.txtResponseSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponseSummary.BackColor = System.Drawing.SystemColors.Window;
            this.txtResponseSummary.Location = new System.Drawing.Point(8, 956);
            this.txtResponseSummary.Margin = new System.Windows.Forms.Padding(6);
            this.txtResponseSummary.MaxLength = 0;
            this.txtResponseSummary.Multiline = true;
            this.txtResponseSummary.Name = "txtResponseSummary";
            this.txtResponseSummary.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResponseSummary.Size = new System.Drawing.Size(1978, 167);
            this.txtResponseSummary.TabIndex = 1;
            this.txtResponseSummary.WordWrap = false;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 922);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 25);
            this.label10.TabIndex = 0;
            this.label10.Text = "EWS Call Info:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnAddQuickHeaders);
            this.groupBox2.Controls.Add(this.dgvOptions);
            this.groupBox2.Controls.Add(this.btnDeleteHeader);
            this.groupBox2.Controls.Add(this.btnAddHeaders);
            this.groupBox2.Location = new System.Drawing.Point(1177, 16);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox2.Size = new System.Drawing.Size(433, 253);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Headers - (select row to use delete button)";
            // 
            // btnAddQuickHeaders
            // 
            this.btnAddQuickHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddQuickHeaders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddQuickHeaders.Location = new System.Drawing.Point(354, 112);
            this.btnAddQuickHeaders.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnAddQuickHeaders.Name = "btnAddQuickHeaders";
            this.btnAddQuickHeaders.Size = new System.Drawing.Size(69, 44);
            this.btnAddQuickHeaders.TabIndex = 3;
            this.btnAddQuickHeaders.Text = "*";
            this.btnAddQuickHeaders.UseVisualStyleBackColor = true;
            this.btnAddQuickHeaders.Click += new System.EventHandler(this.btnAddQuickHeaders_Click);
            // 
            // dgvOptions
            // 
            this.dgvOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colValue});
            this.dgvOptions.Location = new System.Drawing.Point(21, 24);
            this.dgvOptions.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.dgvOptions.Name = "dgvOptions";
            this.dgvOptions.RowHeadersWidth = 82;
            this.dgvOptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOptions.Size = new System.Drawing.Size(323, 221);
            this.dgvOptions.TabIndex = 0;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colName.FillWeight = 150F;
            this.colName.HeaderText = "Name";
            this.colName.MinimumWidth = 10;
            this.colName.Name = "colName";
            this.colName.Width = 113;
            // 
            // colValue
            // 
            this.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colValue.FillWeight = 150F;
            this.colValue.HeaderText = "Value";
            this.colValue.MinimumWidth = 10;
            this.colValue.Name = "colValue";
            this.colValue.Width = 112;
            // 
            // btnDeleteHeader
            // 
            this.btnDeleteHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteHeader.Image = global::EWSEditor.Properties.Resources.StatusAnnotations_Blocked_16xLG;
            this.btnDeleteHeader.Location = new System.Drawing.Point(354, 66);
            this.btnDeleteHeader.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnDeleteHeader.Name = "btnDeleteHeader";
            this.btnDeleteHeader.Size = new System.Drawing.Size(69, 44);
            this.btnDeleteHeader.TabIndex = 2;
            this.btnDeleteHeader.UseVisualStyleBackColor = true;
            this.btnDeleteHeader.Click += new System.EventHandler(this.btnDeleteHeader_Click);
            // 
            // btnAddHeaders
            // 
            this.btnAddHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddHeaders.Image = global::EWSEditor.Properties.Resources.action_add_16xLG;
            this.btnAddHeaders.Location = new System.Drawing.Point(354, 24);
            this.btnAddHeaders.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnAddHeaders.Name = "btnAddHeaders";
            this.btnAddHeaders.Size = new System.Drawing.Size(69, 40);
            this.btnAddHeaders.TabIndex = 1;
            this.btnAddHeaders.UseVisualStyleBackColor = true;
            this.btnAddHeaders.Click += new System.EventHandler(this.btnAddHeaders_Click);
            // 
            // grpHttpVerbOptions
            // 
            this.grpHttpVerbOptions.Controls.Add(this.cmboUserAgent);
            this.grpHttpVerbOptions.Controls.Add(this.chkPragmaNocache);
            this.grpHttpVerbOptions.Controls.Add(this.label7);
            this.grpHttpVerbOptions.Controls.Add(this.chkAllowRedirect);
            this.grpHttpVerbOptions.Controls.Add(this.cmboContentType);
            this.grpHttpVerbOptions.Controls.Add(this.label9);
            this.grpHttpVerbOptions.Controls.Add(this.cmboVerb);
            this.grpHttpVerbOptions.Controls.Add(this.chkTranslateF);
            this.grpHttpVerbOptions.Controls.Add(this.label8);
            this.grpHttpVerbOptions.Controls.Add(this.numericUpDownTimeoutSeconds);
            this.grpHttpVerbOptions.Controls.Add(this.label11);
            this.grpHttpVerbOptions.Location = new System.Drawing.Point(488, 74);
            this.grpHttpVerbOptions.Margin = new System.Windows.Forms.Padding(6);
            this.grpHttpVerbOptions.Name = "grpHttpVerbOptions";
            this.grpHttpVerbOptions.Padding = new System.Windows.Forms.Padding(6);
            this.grpHttpVerbOptions.Size = new System.Drawing.Size(687, 195);
            this.grpHttpVerbOptions.TabIndex = 4;
            this.grpHttpVerbOptions.TabStop = false;
            this.grpHttpVerbOptions.Enter += new System.EventHandler(this.grpHttpVerbOptions_Enter);
            // 
            // cmboUserAgent
            // 
            this.cmboUserAgent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmboUserAgent.FormattingEnabled = true;
            this.cmboUserAgent.Location = new System.Drawing.Point(182, 141);
            this.cmboUserAgent.Margin = new System.Windows.Forms.Padding(6);
            this.cmboUserAgent.Name = "cmboUserAgent";
            this.cmboUserAgent.Size = new System.Drawing.Size(477, 33);
            this.cmboUserAgent.TabIndex = 7;
            this.cmboUserAgent.SelectedIndexChanged += new System.EventHandler(this.cmboUserAgent_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(14, 336);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1972, 63);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rdoSpecifyProxySettings);
            this.groupBox3.Controls.Add(this.rdoDontOverrideProxySettings);
            this.groupBox3.Controls.Add(this.txtProxyServerPort);
            this.groupBox3.Controls.Add(this.lblProxyPort);
            this.groupBox3.Controls.Add(this.txtProxyServerName);
            this.groupBox3.Controls.Add(this.lblProxyServer);
            this.groupBox3.Location = new System.Drawing.Point(1621, 74);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(314, 200);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set WebProxy Settings";
            // 
            // rdoSpecifyProxySettings
            // 
            this.rdoSpecifyProxySettings.AutoSize = true;
            this.rdoSpecifyProxySettings.Location = new System.Drawing.Point(18, 67);
            this.rdoSpecifyProxySettings.Margin = new System.Windows.Forms.Padding(6);
            this.rdoSpecifyProxySettings.Name = "rdoSpecifyProxySettings";
            this.rdoSpecifyProxySettings.Size = new System.Drawing.Size(259, 29);
            this.rdoSpecifyProxySettings.TabIndex = 1;
            this.rdoSpecifyProxySettings.Text = "Specify Proxy Settings";
            this.rdoSpecifyProxySettings.UseVisualStyleBackColor = true;
            // 
            // rdoDontOverrideProxySettings
            // 
            this.rdoDontOverrideProxySettings.AutoSize = true;
            this.rdoDontOverrideProxySettings.Checked = true;
            this.rdoDontOverrideProxySettings.Location = new System.Drawing.Point(18, 34);
            this.rdoDontOverrideProxySettings.Margin = new System.Windows.Forms.Padding(6);
            this.rdoDontOverrideProxySettings.Name = "rdoDontOverrideProxySettings";
            this.rdoDontOverrideProxySettings.Size = new System.Drawing.Size(241, 29);
            this.rdoDontOverrideProxySettings.TabIndex = 0;
            this.rdoDontOverrideProxySettings.TabStop = true;
            this.rdoDontOverrideProxySettings.Text = "Don\'t Override Proxy";
            this.rdoDontOverrideProxySettings.UseVisualStyleBackColor = true;
            this.rdoDontOverrideProxySettings.CheckedChanged += new System.EventHandler(this.rdoDontOverrideProxySettings_CheckedChanged);
            // 
            // txtProxyServerPort
            // 
            this.txtProxyServerPort.Location = new System.Drawing.Point(138, 149);
            this.txtProxyServerPort.Margin = new System.Windows.Forms.Padding(6);
            this.txtProxyServerPort.Name = "txtProxyServerPort";
            this.txtProxyServerPort.Size = new System.Drawing.Size(167, 31);
            this.txtProxyServerPort.TabIndex = 5;
            this.txtProxyServerPort.Text = "8888";
            // 
            // lblProxyPort
            // 
            this.lblProxyPort.Location = new System.Drawing.Point(56, 150);
            this.lblProxyPort.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblProxyPort.Name = "lblProxyPort";
            this.lblProxyPort.Size = new System.Drawing.Size(80, 34);
            this.lblProxyPort.TabIndex = 4;
            this.lblProxyPort.Text = "Port:";
            // 
            // txtProxyServerName
            // 
            this.txtProxyServerName.Location = new System.Drawing.Point(138, 110);
            this.txtProxyServerName.Margin = new System.Windows.Forms.Padding(6);
            this.txtProxyServerName.Name = "txtProxyServerName";
            this.txtProxyServerName.Size = new System.Drawing.Size(167, 31);
            this.txtProxyServerName.TabIndex = 3;
            this.txtProxyServerName.Text = "127.0.0.1";
            this.txtProxyServerName.TextChanged += new System.EventHandler(this.txtProxyServerName_TextChanged);
            // 
            // lblProxyServer
            // 
            this.lblProxyServer.Location = new System.Drawing.Point(56, 112);
            this.lblProxyServer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblProxyServer.Name = "lblProxyServer";
            this.lblProxyServer.Size = new System.Drawing.Size(99, 34);
            this.lblProxyServer.TabIndex = 2;
            this.lblProxyServer.Text = "Server:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(11, 430);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(1971, 487);
            this.splitContainer1.SplitterDistance = 237;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 48;
            // 
            // chkLogCalls
            // 
            this.chkLogCalls.AutoSize = true;
            this.chkLogCalls.Location = new System.Drawing.Point(960, 16);
            this.chkLogCalls.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.chkLogCalls.Name = "chkLogCalls";
            this.chkLogCalls.Size = new System.Drawing.Size(134, 29);
            this.chkLogCalls.TabIndex = 11;
            this.chkLogCalls.Text = "Log Calls";
            this.chkLogCalls.UseVisualStyleBackColor = true;
            // 
            // PostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1997, 1129);
            this.Controls.Add(this.chkLogCalls);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtResponseSummary);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.grpHttpVerbOptions);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GoRun);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "PostForm";
            this.Text = "EWS POST";
            this.Load += new System.EventHandler(this.PostForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeoutSeconds)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOptions)).EndInit();
            this.grpHttpVerbOptions.ResumeLayout(false);
            this.grpHttpVerbOptions.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Button GoRun;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmboVerb;
        private System.Windows.Forms.ComboBox cmboContentType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeoutSeconds;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLoadExample;
        private System.Windows.Forms.Button btnSaveExample;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoadSettings;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmboAuthentication;
        private System.Windows.Forms.Label lblAuthentication;
        private System.Windows.Forms.CheckBox chkTranslateF;
        private System.Windows.Forms.CheckBox chkPragmaNocache;
        private System.Windows.Forms.CheckBox chkAllowRedirect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvOptions;
        private System.Windows.Forms.Button btnDeleteHeader;
        private System.Windows.Forms.Button btnAddHeaders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.GroupBox grpHttpVerbOptions;
        private System.Windows.Forms.ComboBox cmboUserAgent;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoSpecifyProxySettings;
        private System.Windows.Forms.RadioButton rdoDontOverrideProxySettings;
        private System.Windows.Forms.TextBox txtProxyServerPort;
        private System.Windows.Forms.Label lblProxyPort;
        private System.Windows.Forms.TextBox txtProxyServerName;
        private System.Windows.Forms.Label lblProxyServer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtResponseSummary;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.WebBrowser wbRequest;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.WebBrowser wbResponse;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnAddQuickHeaders;
        private System.Windows.Forms.CheckBox chkLogCalls;
    }
}