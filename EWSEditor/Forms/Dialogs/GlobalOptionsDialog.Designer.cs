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
            this.MiscSettingsGroup = new System.Windows.Forms.GroupBox();
            this.chkOverrideTimezone = new System.Windows.Forms.CheckBox();
            this.PreAuthenticate = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkOverrideTimeout = new System.Windows.Forms.CheckBox();
            this.cmboSelectedTimeZoneId = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownTimeout = new System.Windows.Forms.NumericUpDown();
            this.EnableScpLookups = new System.Windows.Forms.CheckBox();
            this.UserAgentText = new System.Windows.Forms.TextBox();
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
            this.MiscSettingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).BeginInit();
            this.LoggingGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(430, 570);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(100, 28);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(538, 570);
            this.MyCancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(100, 28);
            this.MyCancelButton.TabIndex = 3;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // MiscSettingsGroup
            // 
            this.MiscSettingsGroup.Controls.Add(this.chkOverrideTimezone);
            this.MiscSettingsGroup.Controls.Add(this.PreAuthenticate);
            this.MiscSettingsGroup.Controls.Add(this.label1);
            this.MiscSettingsGroup.Controls.Add(this.chkOverrideTimeout);
            this.MiscSettingsGroup.Controls.Add(this.cmboSelectedTimeZoneId);
            this.MiscSettingsGroup.Controls.Add(this.label9);
            this.MiscSettingsGroup.Controls.Add(this.numericUpDownTimeout);
            this.MiscSettingsGroup.Controls.Add(this.EnableScpLookups);
            this.MiscSettingsGroup.Controls.Add(this.UserAgentText);
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
            this.MiscSettingsGroup.Location = new System.Drawing.Point(17, 15);
            this.MiscSettingsGroup.Margin = new System.Windows.Forms.Padding(4);
            this.MiscSettingsGroup.Name = "MiscSettingsGroup";
            this.MiscSettingsGroup.Padding = new System.Windows.Forms.Padding(4);
            this.MiscSettingsGroup.Size = new System.Drawing.Size(616, 426);
            this.MiscSettingsGroup.TabIndex = 0;
            this.MiscSettingsGroup.TabStop = false;
            this.MiscSettingsGroup.Text = "Miscellaneous";
            this.MiscSettingsGroup.Enter += new System.EventHandler(this.MiscSettingsGroup_Enter);
            // 
            // chkOverrideTimezone
            // 
            this.chkOverrideTimezone.Location = new System.Drawing.Point(16, 353);
            this.chkOverrideTimezone.Margin = new System.Windows.Forms.Padding(4);
            this.chkOverrideTimezone.Name = "chkOverrideTimezone";
            this.chkOverrideTimezone.Size = new System.Drawing.Size(469, 23);
            this.chkOverrideTimezone.TabIndex = 5;
            this.chkOverrideTimezone.Text = "Use specified timezone:";
            this.chkOverrideTimezone.UseVisualStyleBackColor = true;
            this.chkOverrideTimezone.CheckedChanged += new System.EventHandler(this.chkOverrideTimezone_CheckedChanged);
            // 
            // PreAuthenticate
            // 
            this.PreAuthenticate.AutoSize = true;
            this.PreAuthenticate.Location = new System.Drawing.Point(17, 166);
            this.PreAuthenticate.Margin = new System.Windows.Forms.Padding(4);
            this.PreAuthenticate.Name = "PreAuthenticate";
            this.PreAuthenticate.Size = new System.Drawing.Size(220, 20);
            this.PreAuthenticate.TabIndex = 6;
            this.PreAuthenticate.Text = "Pre-Authenticate HTTP requests";
            this.PreAuthenticate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 388);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "TimeZone:";
            // 
            // chkOverrideTimeout
            // 
            this.chkOverrideTimeout.Location = new System.Drawing.Point(17, 189);
            this.chkOverrideTimeout.Margin = new System.Windows.Forms.Padding(4);
            this.chkOverrideTimeout.Name = "chkOverrideTimeout";
            this.chkOverrideTimeout.Size = new System.Drawing.Size(166, 30);
            this.chkOverrideTimeout.TabIndex = 79;
            this.chkOverrideTimeout.Text = "Override timeout:";
            this.chkOverrideTimeout.UseVisualStyleBackColor = true;
            // 
            // cmboSelectedTimeZoneId
            // 
            this.cmboSelectedTimeZoneId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboSelectedTimeZoneId.Enabled = false;
            this.cmboSelectedTimeZoneId.FormattingEnabled = true;
            this.cmboSelectedTimeZoneId.Location = new System.Drawing.Point(149, 384);
            this.cmboSelectedTimeZoneId.Margin = new System.Windows.Forms.Padding(4);
            this.cmboSelectedTimeZoneId.Name = "cmboSelectedTimeZoneId";
            this.cmboSelectedTimeZoneId.Size = new System.Drawing.Size(408, 24);
            this.cmboSelectedTimeZoneId.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(190, 194);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 16);
            this.label9.TabIndex = 77;
            this.label9.Text = "Timeout milliseconds :";
            // 
            // numericUpDownTimeout
            // 
            this.numericUpDownTimeout.Location = new System.Drawing.Point(345, 189);
            this.numericUpDownTimeout.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownTimeout.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownTimeout.Name = "numericUpDownTimeout";
            this.numericUpDownTimeout.Size = new System.Drawing.Size(130, 22);
            this.numericUpDownTimeout.TabIndex = 78;
            this.numericUpDownTimeout.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // EnableScpLookups
            // 
            this.EnableScpLookups.Location = new System.Drawing.Point(17, 138);
            this.EnableScpLookups.Margin = new System.Windows.Forms.Padding(4);
            this.EnableScpLookups.Name = "EnableScpLookups";
            this.EnableScpLookups.Size = new System.Drawing.Size(494, 30);
            this.EnableScpLookups.TabIndex = 5;
            this.EnableScpLookups.Text = "Enable SCP Lookups (Disabling will skip AD lookup of Autodiscover URLs)";
            this.EnableScpLookups.UseVisualStyleBackColor = true;
            this.EnableScpLookups.CheckedChanged += new System.EventHandler(this.EnableScpLookups_CheckedChanged);
            // 
            // UserAgentText
            // 
            this.UserAgentText.Location = new System.Drawing.Point(192, 20);
            this.UserAgentText.Margin = new System.Windows.Forms.Padding(4);
            this.UserAgentText.Name = "UserAgentText";
            this.UserAgentText.Size = new System.Drawing.Size(411, 22);
            this.UserAgentText.TabIndex = 1;
            // 
            // UserAgentLabel
            // 
            this.UserAgentLabel.Location = new System.Drawing.Point(13, 23);
            this.UserAgentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UserAgentLabel.Name = "UserAgentLabel";
            this.UserAgentLabel.Size = new System.Drawing.Size(171, 28);
            this.UserAgentLabel.TabIndex = 0;
            this.UserAgentLabel.Text = "UserAgent Value:";
            // 
            // EnableSslDetailCheck
            // 
            this.EnableSslDetailCheck.Location = new System.Drawing.Point(17, 90);
            this.EnableSslDetailCheck.Margin = new System.Windows.Forms.Padding(4);
            this.EnableSslDetailCheck.Name = "EnableSslDetailCheck";
            this.EnableSslDetailCheck.Size = new System.Drawing.Size(308, 30);
            this.EnableSslDetailCheck.TabIndex = 3;
            this.EnableSslDetailCheck.Text = "Enable detailed SSL certificate log output";
            this.EnableSslDetailCheck.UseVisualStyleBackColor = true;
            // 
            // DumpFolderText
            // 
            this.DumpFolderText.Location = new System.Drawing.Point(192, 320);
            this.DumpFolderText.Margin = new System.Windows.Forms.Padding(4);
            this.DumpFolderText.Name = "DumpFolderText";
            this.DumpFolderText.Size = new System.Drawing.Size(132, 22);
            this.DumpFolderText.TabIndex = 13;
            // 
            // AllowRedirectsCheck
            // 
            this.AllowRedirectsCheck.Location = new System.Drawing.Point(17, 116);
            this.AllowRedirectsCheck.Margin = new System.Windows.Forms.Padding(4);
            this.AllowRedirectsCheck.Name = "AllowRedirectsCheck";
            this.AllowRedirectsCheck.Size = new System.Drawing.Size(308, 30);
            this.AllowRedirectsCheck.TabIndex = 4;
            this.AllowRedirectsCheck.Text = "Allow Autodiscover redirects";
            this.AllowRedirectsCheck.UseVisualStyleBackColor = true;
            // 
            // FindItemText
            // 
            this.FindItemText.Location = new System.Drawing.Point(192, 291);
            this.FindItemText.Margin = new System.Windows.Forms.Padding(4);
            this.FindItemText.Name = "FindItemText";
            this.FindItemText.Size = new System.Drawing.Size(132, 22);
            this.FindItemText.TabIndex = 11;
            // 
            // OverrideSslCheck
            // 
            this.OverrideSslCheck.Location = new System.Drawing.Point(16, 65);
            this.OverrideSslCheck.Margin = new System.Windows.Forms.Padding(4);
            this.OverrideSslCheck.Name = "OverrideSslCheck";
            this.OverrideSslCheck.Size = new System.Drawing.Size(308, 30);
            this.OverrideSslCheck.TabIndex = 2;
            this.OverrideSslCheck.Text = "Override SSL certificate verification";
            this.OverrideSslCheck.UseVisualStyleBackColor = true;
            // 
            // FindFolderText
            // 
            this.FindFolderText.Location = new System.Drawing.Point(192, 263);
            this.FindFolderText.Margin = new System.Windows.Forms.Padding(4);
            this.FindFolderText.Name = "FindFolderText";
            this.FindFolderText.Size = new System.Drawing.Size(132, 22);
            this.FindFolderText.TabIndex = 9;
            // 
            // CalendarViewText
            // 
            this.CalendarViewText.Location = new System.Drawing.Point(192, 231);
            this.CalendarViewText.Margin = new System.Windows.Forms.Padding(4);
            this.CalendarViewText.Name = "CalendarViewText";
            this.CalendarViewText.Size = new System.Drawing.Size(132, 22);
            this.CalendarViewText.TabIndex = 7;
            // 
            // DumpFolderLabel
            // 
            this.DumpFolderLabel.Location = new System.Drawing.Point(13, 320);
            this.DumpFolderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DumpFolderLabel.Name = "DumpFolderLabel";
            this.DumpFolderLabel.Size = new System.Drawing.Size(171, 28);
            this.DumpFolderLabel.TabIndex = 12;
            this.DumpFolderLabel.Text = "Dump Folder View Size:";
            // 
            // FindItemLabel
            // 
            this.FindItemLabel.Location = new System.Drawing.Point(13, 291);
            this.FindItemLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FindItemLabel.Name = "FindItemLabel";
            this.FindItemLabel.Size = new System.Drawing.Size(171, 28);
            this.FindItemLabel.TabIndex = 10;
            this.FindItemLabel.Text = "FindItem View Size:";
            // 
            // FindFolderLabel
            // 
            this.FindFolderLabel.Location = new System.Drawing.Point(13, 263);
            this.FindFolderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FindFolderLabel.Name = "FindFolderLabel";
            this.FindFolderLabel.Size = new System.Drawing.Size(171, 28);
            this.FindFolderLabel.TabIndex = 8;
            this.FindFolderLabel.Text = "FindFolder View Size:";
            // 
            // CalendarViewLabel
            // 
            this.CalendarViewLabel.Location = new System.Drawing.Point(13, 235);
            this.CalendarViewLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CalendarViewLabel.Name = "CalendarViewLabel";
            this.CalendarViewLabel.Size = new System.Drawing.Size(171, 28);
            this.CalendarViewLabel.TabIndex = 6;
            this.CalendarViewLabel.Text = "CalendarView Size:";
            // 
            // LoggingGroup
            // 
            this.LoggingGroup.Controls.Add(this.LogFilePathText);
            this.LoggingGroup.Controls.Add(this.LogFilePathLabel);
            this.LoggingGroup.Controls.Add(this.SaveLogFileCheck);
            this.LoggingGroup.Location = new System.Drawing.Point(17, 449);
            this.LoggingGroup.Margin = new System.Windows.Forms.Padding(4);
            this.LoggingGroup.Name = "LoggingGroup";
            this.LoggingGroup.Padding = new System.Windows.Forms.Padding(4);
            this.LoggingGroup.Size = new System.Drawing.Size(616, 84);
            this.LoggingGroup.TabIndex = 1;
            this.LoggingGroup.TabStop = false;
            this.LoggingGroup.Text = "Logging...";
            // 
            // LogFilePathText
            // 
            this.LogFilePathText.Location = new System.Drawing.Point(137, 54);
            this.LogFilePathText.Margin = new System.Windows.Forms.Padding(4);
            this.LogFilePathText.Name = "LogFilePathText";
            this.LogFilePathText.Size = new System.Drawing.Size(466, 22);
            this.LogFilePathText.TabIndex = 2;
            // 
            // LogFilePathLabel
            // 
            this.LogFilePathLabel.Location = new System.Drawing.Point(49, 57);
            this.LogFilePathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LogFilePathLabel.Name = "LogFilePathLabel";
            this.LogFilePathLabel.Size = new System.Drawing.Size(459, 21);
            this.LogFilePathLabel.TabIndex = 1;
            this.LogFilePathLabel.Text = "Log file path:";
            // 
            // SaveLogFileCheck
            // 
            this.SaveLogFileCheck.Location = new System.Drawing.Point(17, 23);
            this.SaveLogFileCheck.Margin = new System.Windows.Forms.Padding(4);
            this.SaveLogFileCheck.Name = "SaveLogFileCheck";
            this.SaveLogFileCheck.Size = new System.Drawing.Size(215, 30);
            this.SaveLogFileCheck.TabIndex = 0;
            this.SaveLogFileCheck.Text = "Save logging output to a file";
            this.SaveLogFileCheck.UseVisualStyleBackColor = true;
            this.SaveLogFileCheck.CheckedChanged += new System.EventHandler(this.SaveLogFileCheck_CheckedChanged);
            // 
            // OptionsDialog
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.MyCancelButton;
            this.ClientSize = new System.Drawing.Size(651, 611);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.MiscSettingsGroup);
            this.Controls.Add(this.LoggingGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsDialog_Load);
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
        private System.Windows.Forms.TextBox UserAgentText;
        private System.Windows.Forms.Label UserAgentLabel;
        private System.Windows.Forms.CheckBox EnableScpLookups;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeout;
        private System.Windows.Forms.CheckBox chkOverrideTimeout;
        private System.Windows.Forms.CheckBox PreAuthenticate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmboSelectedTimeZoneId;
        private System.Windows.Forms.CheckBox chkOverrideTimezone;
    }
}