namespace EWSEditor.Forms
{
    partial class OptionsDialog
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
            this.OkButton = new System.Windows.Forms.Button();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBypassProxyForLocalAddress = new System.Windows.Forms.CheckBox();
            this.rdoSpecifyProxySettings = new System.Windows.Forms.RadioButton();
            this.rdoDontOverrideProxySettings = new System.Windows.Forms.RadioButton();
            this.chkOverrideProxyCredentials = new System.Windows.Forms.CheckBox();
            this.txtProxyServerDomain = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblDomain = new System.Windows.Forms.Label();
            this.txtProxyServerPassword = new System.Windows.Forms.TextBox();
            this.txtProxyServerUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtProxyServerPort = new System.Windows.Forms.TextBox();
            this.lblProxyPort = new System.Windows.Forms.Label();
            this.txtProxyServerName = new System.Windows.Forms.TextBox();
            this.lblProxyServer = new System.Windows.Forms.Label();
            this.MiscSettingsGroup = new System.Windows.Forms.GroupBox();
            this.chkOverrideTimezone = new System.Windows.Forms.CheckBox();
            this.PreAuthenticate = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkOverrideTimeout = new System.Windows.Forms.CheckBox();
            this.cmboSelectedTimeZoneId = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownTimeout = new System.Windows.Forms.NumericUpDown();
            this.EnableScpLookups = new System.Windows.Forms.CheckBox();
            this.UserAgentLabel = new System.Windows.Forms.Label();
            this.EnableSslDetailCheck = new System.Windows.Forms.CheckBox();
            this.DumpFolderText = new System.Windows.Forms.TextBox();
            this.AllowRedirectsCheck = new System.Windows.Forms.CheckBox();
            this.FindItemText = new System.Windows.Forms.TextBox();
            this.OverrideSslCheck = new System.Windows.Forms.CheckBox();
            this.FindFolderText = new System.Windows.Forms.TextBox();
            this.CalendarViewText = new System.Windows.Forms.TextBox();
            this.DumpFolderLabel = new System.Windows.Forms.Label();
            this.FindItemLabel = new System.Windows.Forms.Label();
            this.FindFolderLabel = new System.Windows.Forms.Label();
            this.CalendarViewLabel = new System.Windows.Forms.Label();
            this.LoggingGroup = new System.Windows.Forms.GroupBox();
            this.LogFilePathText = new System.Windows.Forms.TextBox();
            this.LogFilePathLabel = new System.Windows.Forms.Label();
            this.SaveLogFileCheck = new System.Windows.Forms.CheckBox();
            this.cmboUserAgent = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.MiscSettingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).BeginInit();
            this.LoggingGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(701, 409);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 4;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(783, 409);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 0;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBypassProxyForLocalAddress);
            this.groupBox1.Controls.Add(this.rdoSpecifyProxySettings);
            this.groupBox1.Controls.Add(this.rdoDontOverrideProxySettings);
            this.groupBox1.Controls.Add(this.chkOverrideProxyCredentials);
            this.groupBox1.Controls.Add(this.txtProxyServerDomain);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.lblDomain);
            this.groupBox1.Controls.Add(this.txtProxyServerPassword);
            this.groupBox1.Controls.Add(this.txtProxyServerUserName);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.txtProxyServerPort);
            this.groupBox1.Controls.Add(this.lblProxyPort);
            this.groupBox1.Controls.Add(this.txtProxyServerName);
            this.groupBox1.Controls.Add(this.lblProxyServer);
            this.groupBox1.Location = new System.Drawing.Point(481, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 312);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set WebProxy Settings";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chkBypassProxyForLocalAddress
            // 
            this.chkBypassProxyForLocalAddress.Location = new System.Drawing.Point(26, 147);
            this.chkBypassProxyForLocalAddress.Name = "chkBypassProxyForLocalAddress";
            this.chkBypassProxyForLocalAddress.Size = new System.Drawing.Size(268, 19);
            this.chkBypassProxyForLocalAddress.TabIndex = 6;
            this.chkBypassProxyForLocalAddress.Text = "BypassProxy For Local Address";
            this.chkBypassProxyForLocalAddress.UseVisualStyleBackColor = true;
            // 
            // rdoSpecifyProxySettings
            // 
            this.rdoSpecifyProxySettings.AutoSize = true;
            this.rdoSpecifyProxySettings.Location = new System.Drawing.Point(6, 63);
            this.rdoSpecifyProxySettings.Name = "rdoSpecifyProxySettings";
            this.rdoSpecifyProxySettings.Size = new System.Drawing.Size(130, 17);
            this.rdoSpecifyProxySettings.TabIndex = 1;
            this.rdoSpecifyProxySettings.Text = "Specify Proxy Settings";
            this.rdoSpecifyProxySettings.UseVisualStyleBackColor = true;
            this.rdoSpecifyProxySettings.CheckedChanged += new System.EventHandler(this.rdoSpecifyProxySettings_CheckedChanged);
            // 
            // rdoDontOverrideProxySettings
            // 
            this.rdoDontOverrideProxySettings.AutoSize = true;
            this.rdoDontOverrideProxySettings.Checked = true;
            this.rdoDontOverrideProxySettings.Location = new System.Drawing.Point(6, 28);
            this.rdoDontOverrideProxySettings.Name = "rdoDontOverrideProxySettings";
            this.rdoDontOverrideProxySettings.Size = new System.Drawing.Size(163, 17);
            this.rdoDontOverrideProxySettings.TabIndex = 0;
            this.rdoDontOverrideProxySettings.TabStop = true;
            this.rdoDontOverrideProxySettings.Text = "Don\'t Override Proxy Settings";
            this.rdoDontOverrideProxySettings.UseVisualStyleBackColor = true;
            this.rdoDontOverrideProxySettings.CheckedChanged += new System.EventHandler(this.rdoDontOverrideProxySettings_CheckedChanged);
            // 
            // chkOverrideProxyCredentials
            // 
            this.chkOverrideProxyCredentials.Location = new System.Drawing.Point(26, 178);
            this.chkOverrideProxyCredentials.Name = "chkOverrideProxyCredentials";
            this.chkOverrideProxyCredentials.Size = new System.Drawing.Size(268, 19);
            this.chkOverrideProxyCredentials.TabIndex = 7;
            this.chkOverrideProxyCredentials.Text = "Override Proxy Server Credentials";
            this.chkOverrideProxyCredentials.UseVisualStyleBackColor = true;
            this.chkOverrideProxyCredentials.CheckedChanged += new System.EventHandler(this.chkOverrideProxyCredentials_CheckedChanged);
            // 
            // txtProxyServerDomain
            // 
            this.txtProxyServerDomain.Enabled = false;
            this.txtProxyServerDomain.Location = new System.Drawing.Point(147, 254);
            this.txtProxyServerDomain.Name = "txtProxyServerDomain";
            this.txtProxyServerDomain.Size = new System.Drawing.Size(173, 20);
            this.txtProxyServerDomain.TabIndex = 13;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(51, 236);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "Password:";
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Location = new System.Drawing.Point(51, 257);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(46, 13);
            this.lblDomain.TabIndex = 12;
            this.lblDomain.Text = "Domain:";
            // 
            // txtProxyServerPassword
            // 
            this.txtProxyServerPassword.Enabled = false;
            this.txtProxyServerPassword.Location = new System.Drawing.Point(147, 229);
            this.txtProxyServerPassword.Name = "txtProxyServerPassword";
            this.txtProxyServerPassword.PasswordChar = '•';
            this.txtProxyServerPassword.Size = new System.Drawing.Size(173, 20);
            this.txtProxyServerPassword.TabIndex = 11;
            // 
            // txtProxyServerUserName
            // 
            this.txtProxyServerUserName.Enabled = false;
            this.txtProxyServerUserName.Location = new System.Drawing.Point(147, 203);
            this.txtProxyServerUserName.Name = "txtProxyServerUserName";
            this.txtProxyServerUserName.Size = new System.Drawing.Size(173, 20);
            this.txtProxyServerUserName.TabIndex = 9;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(51, 210);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(32, 13);
            this.lblUserName.TabIndex = 8;
            this.lblUserName.Text = "User:";
            // 
            // txtProxyServerPort
            // 
            this.txtProxyServerPort.Location = new System.Drawing.Point(118, 120);
            this.txtProxyServerPort.Name = "txtProxyServerPort";
            this.txtProxyServerPort.Size = new System.Drawing.Size(202, 20);
            this.txtProxyServerPort.TabIndex = 5;
            // 
            // lblProxyPort
            // 
            this.lblProxyPort.Location = new System.Drawing.Point(23, 122);
            this.lblProxyPort.Name = "lblProxyPort";
            this.lblProxyPort.Size = new System.Drawing.Size(77, 17);
            this.lblProxyPort.TabIndex = 4;
            this.lblProxyPort.Text = "Proxy Port:";
            // 
            // txtProxyServerName
            // 
            this.txtProxyServerName.Location = new System.Drawing.Point(118, 94);
            this.txtProxyServerName.Name = "txtProxyServerName";
            this.txtProxyServerName.Size = new System.Drawing.Size(202, 20);
            this.txtProxyServerName.TabIndex = 3;
            // 
            // lblProxyServer
            // 
            this.lblProxyServer.Location = new System.Drawing.Point(23, 94);
            this.lblProxyServer.Name = "lblProxyServer";
            this.lblProxyServer.Size = new System.Drawing.Size(77, 17);
            this.lblProxyServer.TabIndex = 2;
            this.lblProxyServer.Text = "Proxy Server:";
            // 
            // MiscSettingsGroup
            // 
            this.MiscSettingsGroup.Controls.Add(this.cmboUserAgent);
            this.MiscSettingsGroup.Controls.Add(this.chkOverrideTimezone);
            this.MiscSettingsGroup.Controls.Add(this.PreAuthenticate);
            this.MiscSettingsGroup.Controls.Add(this.label1);
            this.MiscSettingsGroup.Controls.Add(this.chkOverrideTimeout);
            this.MiscSettingsGroup.Controls.Add(this.cmboSelectedTimeZoneId);
            this.MiscSettingsGroup.Controls.Add(this.label9);
            this.MiscSettingsGroup.Controls.Add(this.numericUpDownTimeout);
            this.MiscSettingsGroup.Controls.Add(this.EnableScpLookups);
            this.MiscSettingsGroup.Controls.Add(this.UserAgentLabel);
            this.MiscSettingsGroup.Controls.Add(this.EnableSslDetailCheck);
            this.MiscSettingsGroup.Controls.Add(this.DumpFolderText);
            this.MiscSettingsGroup.Controls.Add(this.AllowRedirectsCheck);
            this.MiscSettingsGroup.Controls.Add(this.FindItemText);
            this.MiscSettingsGroup.Controls.Add(this.OverrideSslCheck);
            this.MiscSettingsGroup.Controls.Add(this.FindFolderText);
            this.MiscSettingsGroup.Controls.Add(this.CalendarViewText);
            this.MiscSettingsGroup.Controls.Add(this.DumpFolderLabel);
            this.MiscSettingsGroup.Controls.Add(this.FindItemLabel);
            this.MiscSettingsGroup.Controls.Add(this.FindFolderLabel);
            this.MiscSettingsGroup.Controls.Add(this.CalendarViewLabel);
            this.MiscSettingsGroup.Location = new System.Drawing.Point(13, 12);
            this.MiscSettingsGroup.Name = "MiscSettingsGroup";
            this.MiscSettingsGroup.Size = new System.Drawing.Size(462, 346);
            this.MiscSettingsGroup.TabIndex = 1;
            this.MiscSettingsGroup.TabStop = false;
            this.MiscSettingsGroup.Text = "Miscellaneous";
            this.MiscSettingsGroup.Enter += new System.EventHandler(this.MiscSettingsGroup_Enter);
            // 
            // chkOverrideTimezone
            // 
            this.chkOverrideTimezone.Location = new System.Drawing.Point(12, 287);
            this.chkOverrideTimezone.Name = "chkOverrideTimezone";
            this.chkOverrideTimezone.Size = new System.Drawing.Size(352, 19);
            this.chkOverrideTimezone.TabIndex = 17;
            this.chkOverrideTimezone.Text = "Use specified timezone:";
            this.chkOverrideTimezone.UseVisualStyleBackColor = true;
            this.chkOverrideTimezone.CheckedChanged += new System.EventHandler(this.chkOverrideTimezone_CheckedChanged);
            // 
            // PreAuthenticate
            // 
            this.PreAuthenticate.AutoSize = true;
            this.PreAuthenticate.Location = new System.Drawing.Point(13, 135);
            this.PreAuthenticate.Name = "PreAuthenticate";
            this.PreAuthenticate.Size = new System.Drawing.Size(180, 17);
            this.PreAuthenticate.TabIndex = 6;
            this.PreAuthenticate.Text = "Pre-Authenticate HTTP requests";
            this.PreAuthenticate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(30, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "TimeZone:";
            // 
            // chkOverrideTimeout
            // 
            this.chkOverrideTimeout.Location = new System.Drawing.Point(13, 154);
            this.chkOverrideTimeout.Name = "chkOverrideTimeout";
            this.chkOverrideTimeout.Size = new System.Drawing.Size(124, 24);
            this.chkOverrideTimeout.TabIndex = 7;
            this.chkOverrideTimeout.Text = "Override timeout:";
            this.chkOverrideTimeout.UseVisualStyleBackColor = true;
            // 
            // cmboSelectedTimeZoneId
            // 
            this.cmboSelectedTimeZoneId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboSelectedTimeZoneId.Enabled = false;
            this.cmboSelectedTimeZoneId.FormattingEnabled = true;
            this.cmboSelectedTimeZoneId.Location = new System.Drawing.Point(112, 312);
            this.cmboSelectedTimeZoneId.Name = "cmboSelectedTimeZoneId";
            this.cmboSelectedTimeZoneId.Size = new System.Drawing.Size(307, 21);
            this.cmboSelectedTimeZoneId.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(142, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 13);
            this.label9.TabIndex = 77;
            this.label9.Text = "Timeout milliseconds :";
            // 
            // numericUpDownTimeout
            // 
            this.numericUpDownTimeout.Location = new System.Drawing.Point(259, 154);
            this.numericUpDownTimeout.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownTimeout.Name = "numericUpDownTimeout";
            this.numericUpDownTimeout.Size = new System.Drawing.Size(98, 20);
            this.numericUpDownTimeout.TabIndex = 8;
            this.numericUpDownTimeout.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // EnableScpLookups
            // 
            this.EnableScpLookups.Location = new System.Drawing.Point(13, 112);
            this.EnableScpLookups.Name = "EnableScpLookups";
            this.EnableScpLookups.Size = new System.Drawing.Size(370, 24);
            this.EnableScpLookups.TabIndex = 5;
            this.EnableScpLookups.Text = "Enable SCP Lookups (Disabling will skip AD lookup of Autodiscover URLs)";
            this.EnableScpLookups.UseVisualStyleBackColor = true;
            this.EnableScpLookups.CheckedChanged += new System.EventHandler(this.EnableScpLookups_CheckedChanged);
            // 
            // UserAgentLabel
            // 
            this.UserAgentLabel.Location = new System.Drawing.Point(10, 19);
            this.UserAgentLabel.Name = "UserAgentLabel";
            this.UserAgentLabel.Size = new System.Drawing.Size(128, 23);
            this.UserAgentLabel.TabIndex = 0;
            this.UserAgentLabel.Text = "UserAgent Value:";
            // 
            // EnableSslDetailCheck
            // 
            this.EnableSslDetailCheck.Location = new System.Drawing.Point(13, 73);
            this.EnableSslDetailCheck.Name = "EnableSslDetailCheck";
            this.EnableSslDetailCheck.Size = new System.Drawing.Size(231, 24);
            this.EnableSslDetailCheck.TabIndex = 3;
            this.EnableSslDetailCheck.Text = "Enable detailed SSL certificate log output";
            this.EnableSslDetailCheck.UseVisualStyleBackColor = true;
            // 
            // DumpFolderText
            // 
            this.DumpFolderText.Location = new System.Drawing.Point(144, 260);
            this.DumpFolderText.Name = "DumpFolderText";
            this.DumpFolderText.Size = new System.Drawing.Size(100, 20);
            this.DumpFolderText.TabIndex = 16;
            // 
            // AllowRedirectsCheck
            // 
            this.AllowRedirectsCheck.Location = new System.Drawing.Point(13, 94);
            this.AllowRedirectsCheck.Name = "AllowRedirectsCheck";
            this.AllowRedirectsCheck.Size = new System.Drawing.Size(231, 24);
            this.AllowRedirectsCheck.TabIndex = 4;
            this.AllowRedirectsCheck.Text = "Allow Autodiscover redirects";
            this.AllowRedirectsCheck.UseVisualStyleBackColor = true;
            // 
            // FindItemText
            // 
            this.FindItemText.Location = new System.Drawing.Point(144, 236);
            this.FindItemText.Name = "FindItemText";
            this.FindItemText.Size = new System.Drawing.Size(100, 20);
            this.FindItemText.TabIndex = 14;
            // 
            // OverrideSslCheck
            // 
            this.OverrideSslCheck.Location = new System.Drawing.Point(12, 53);
            this.OverrideSslCheck.Name = "OverrideSslCheck";
            this.OverrideSslCheck.Size = new System.Drawing.Size(231, 24);
            this.OverrideSslCheck.TabIndex = 2;
            this.OverrideSslCheck.Text = "Override SSL certificate verification";
            this.OverrideSslCheck.UseVisualStyleBackColor = true;
            // 
            // FindFolderText
            // 
            this.FindFolderText.Location = new System.Drawing.Point(144, 214);
            this.FindFolderText.Name = "FindFolderText";
            this.FindFolderText.Size = new System.Drawing.Size(100, 20);
            this.FindFolderText.TabIndex = 12;
            // 
            // CalendarViewText
            // 
            this.CalendarViewText.Location = new System.Drawing.Point(144, 188);
            this.CalendarViewText.Name = "CalendarViewText";
            this.CalendarViewText.Size = new System.Drawing.Size(100, 20);
            this.CalendarViewText.TabIndex = 10;
            // 
            // DumpFolderLabel
            // 
            this.DumpFolderLabel.Location = new System.Drawing.Point(10, 260);
            this.DumpFolderLabel.Name = "DumpFolderLabel";
            this.DumpFolderLabel.Size = new System.Drawing.Size(128, 23);
            this.DumpFolderLabel.TabIndex = 15;
            this.DumpFolderLabel.Text = "Dump Folder View Size:";
            // 
            // FindItemLabel
            // 
            this.FindItemLabel.Location = new System.Drawing.Point(10, 236);
            this.FindItemLabel.Name = "FindItemLabel";
            this.FindItemLabel.Size = new System.Drawing.Size(128, 23);
            this.FindItemLabel.TabIndex = 13;
            this.FindItemLabel.Text = "FindItem View Size:";
            // 
            // FindFolderLabel
            // 
            this.FindFolderLabel.Location = new System.Drawing.Point(10, 214);
            this.FindFolderLabel.Name = "FindFolderLabel";
            this.FindFolderLabel.Size = new System.Drawing.Size(128, 23);
            this.FindFolderLabel.TabIndex = 11;
            this.FindFolderLabel.Text = "FindFolder View Size:";
            // 
            // CalendarViewLabel
            // 
            this.CalendarViewLabel.Location = new System.Drawing.Point(10, 191);
            this.CalendarViewLabel.Name = "CalendarViewLabel";
            this.CalendarViewLabel.Size = new System.Drawing.Size(128, 23);
            this.CalendarViewLabel.TabIndex = 9;
            this.CalendarViewLabel.Text = "CalendarView Size:";
            // 
            // LoggingGroup
            // 
            this.LoggingGroup.Controls.Add(this.LogFilePathText);
            this.LoggingGroup.Controls.Add(this.LogFilePathLabel);
            this.LoggingGroup.Controls.Add(this.SaveLogFileCheck);
            this.LoggingGroup.Location = new System.Drawing.Point(13, 365);
            this.LoggingGroup.Name = "LoggingGroup";
            this.LoggingGroup.Size = new System.Drawing.Size(462, 68);
            this.LoggingGroup.TabIndex = 2;
            this.LoggingGroup.TabStop = false;
            this.LoggingGroup.Text = "Logging...";
            // 
            // LogFilePathText
            // 
            this.LogFilePathText.Location = new System.Drawing.Point(111, 44);
            this.LogFilePathText.Name = "LogFilePathText";
            this.LogFilePathText.Size = new System.Drawing.Size(342, 20);
            this.LogFilePathText.TabIndex = 2;
            // 
            // LogFilePathLabel
            // 
            this.LogFilePathLabel.Location = new System.Drawing.Point(37, 46);
            this.LogFilePathLabel.Name = "LogFilePathLabel";
            this.LogFilePathLabel.Size = new System.Drawing.Size(68, 17);
            this.LogFilePathLabel.TabIndex = 1;
            this.LogFilePathLabel.Text = "Log file path:";
            // 
            // SaveLogFileCheck
            // 
            this.SaveLogFileCheck.Location = new System.Drawing.Point(13, 19);
            this.SaveLogFileCheck.Name = "SaveLogFileCheck";
            this.SaveLogFileCheck.Size = new System.Drawing.Size(161, 24);
            this.SaveLogFileCheck.TabIndex = 0;
            this.SaveLogFileCheck.Text = "Save logging output to a file";
            this.SaveLogFileCheck.UseVisualStyleBackColor = true;
            this.SaveLogFileCheck.CheckedChanged += new System.EventHandler(this.SaveLogFileCheck_CheckedChanged);
            // 
            // cmboUserAgent
            // 
            this.cmboUserAgent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmboUserAgent.FormattingEnabled = true;
            this.cmboUserAgent.Location = new System.Drawing.Point(111, 16);
            this.cmboUserAgent.Name = "cmboUserAgent";
            this.cmboUserAgent.Size = new System.Drawing.Size(319, 21);
            this.cmboUserAgent.TabIndex = 10;
            // 
            // OptionsDialog
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.MyCancelButton;
            this.ClientSize = new System.Drawing.Size(869, 444);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.MiscSettingsGroup);
            this.Controls.Add(this.LoggingGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.MiscSettingsGroup.ResumeLayout(false);
            this.MiscSettingsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).EndInit();
            this.LoggingGroup.ResumeLayout(false);
            this.LoggingGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MiscSettingsGroup;
        private System.Windows.Forms.Label FindFolderLabel;
        private System.Windows.Forms.Label CalendarViewLabel;
        private System.Windows.Forms.Label FindItemLabel;
        private System.Windows.Forms.Label DumpFolderLabel;
        private System.Windows.Forms.TextBox DumpFolderText;
        private System.Windows.Forms.TextBox FindItemText;
        private System.Windows.Forms.TextBox FindFolderText;
        private System.Windows.Forms.TextBox CalendarViewText;
        private System.Windows.Forms.CheckBox OverrideSslCheck;
        private System.Windows.Forms.CheckBox AllowRedirectsCheck;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.CheckBox EnableSslDetailCheck;
        private System.Windows.Forms.CheckBox SaveLogFileCheck;
        private System.Windows.Forms.Label LogFilePathLabel;
        private System.Windows.Forms.TextBox LogFilePathText;
        private System.Windows.Forms.GroupBox LoggingGroup;
        private System.Windows.Forms.Label UserAgentLabel;
        private System.Windows.Forms.CheckBox EnableScpLookups;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeout;
        private System.Windows.Forms.CheckBox chkOverrideTimeout;
        private System.Windows.Forms.CheckBox PreAuthenticate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmboSelectedTimeZoneId;
        private System.Windows.Forms.CheckBox chkOverrideTimezone;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtProxyServerPort;
        private System.Windows.Forms.Label lblProxyPort;
        private System.Windows.Forms.TextBox txtProxyServerName;
        private System.Windows.Forms.Label lblProxyServer;
        private System.Windows.Forms.TextBox txtProxyServerDomain;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.TextBox txtProxyServerPassword;
        private System.Windows.Forms.TextBox txtProxyServerUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.CheckBox chkOverrideProxyCredentials;
        private System.Windows.Forms.RadioButton rdoSpecifyProxySettings;
        private System.Windows.Forms.RadioButton rdoDontOverrideProxySettings;
        private System.Windows.Forms.CheckBox chkBypassProxyForLocalAddress;
        private System.Windows.Forms.ComboBox cmboUserAgent;
    }
}