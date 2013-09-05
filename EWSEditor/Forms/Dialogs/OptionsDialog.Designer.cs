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
            this.MiscSettingsGroup = new System.Windows.Forms.GroupBox();
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
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.SaveLogFileCheck = new System.Windows.Forms.CheckBox();
            this.LogFilePathLabel = new System.Windows.Forms.Label();
            this.LogFilePathText = new System.Windows.Forms.TextBox();
            this.LoggingGroup = new System.Windows.Forms.GroupBox();
            this.MiscSettingsGroup.SuspendLayout();
            this.LoggingGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // MiscSettingsGroup
            // 
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
            this.MiscSettingsGroup.Location = new System.Drawing.Point(13, 12);
            this.MiscSettingsGroup.Name = "MiscSettingsGroup";
            this.MiscSettingsGroup.Size = new System.Drawing.Size(462, 251);
            this.MiscSettingsGroup.TabIndex = 0;
            this.MiscSettingsGroup.TabStop = false;
            this.MiscSettingsGroup.Text = "Miscellaneous";
            // 
            // EnableScpLookups
            // 
            this.EnableScpLookups.Location = new System.Drawing.Point(13, 102);
            this.EnableScpLookups.Name = "EnableScpLookups";
            this.EnableScpLookups.Size = new System.Drawing.Size(231, 24);
            this.EnableScpLookups.TabIndex = 5;
            this.EnableScpLookups.Text = "Enable SCP Lookups";
            this.EnableScpLookups.UseVisualStyleBackColor = true;
            this.EnableScpLookups.CheckedChanged += new System.EventHandler(this.EnableScpLookups_CheckedChanged);
            // 
            // UserAgentText
            // 
            this.UserAgentText.Location = new System.Drawing.Point(144, 16);
            this.UserAgentText.Name = "UserAgentText";
            this.UserAgentText.Size = new System.Drawing.Size(309, 20);
            this.UserAgentText.TabIndex = 1;
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
            this.EnableSslDetailCheck.Location = new System.Drawing.Point(13, 63);
            this.EnableSslDetailCheck.Name = "EnableSslDetailCheck";
            this.EnableSslDetailCheck.Size = new System.Drawing.Size(231, 24);
            this.EnableSslDetailCheck.TabIndex = 3;
            this.EnableSslDetailCheck.Text = "Enable detailed SSL certificate log output";
            this.EnableSslDetailCheck.UseVisualStyleBackColor = true;
            // 
            // DumpFolderText
            // 
            this.DumpFolderText.Location = new System.Drawing.Point(146, 215);
            this.DumpFolderText.Name = "DumpFolderText";
            this.DumpFolderText.Size = new System.Drawing.Size(100, 20);
            this.DumpFolderText.TabIndex = 13;
            // 
            // AllowRedirectsCheck
            // 
            this.AllowRedirectsCheck.Location = new System.Drawing.Point(13, 82);
            this.AllowRedirectsCheck.Name = "AllowRedirectsCheck";
            this.AllowRedirectsCheck.Size = new System.Drawing.Size(231, 24);
            this.AllowRedirectsCheck.TabIndex = 4;
            this.AllowRedirectsCheck.Text = "Allow Autodiscover redirects";
            this.AllowRedirectsCheck.UseVisualStyleBackColor = true;
            // 
            // FindItemText
            // 
            this.FindItemText.Location = new System.Drawing.Point(146, 192);
            this.FindItemText.Name = "FindItemText";
            this.FindItemText.Size = new System.Drawing.Size(100, 20);
            this.FindItemText.TabIndex = 11;
            // 
            // OverrideSslCheck
            // 
            this.OverrideSslCheck.Location = new System.Drawing.Point(13, 42);
            this.OverrideSslCheck.Name = "OverrideSslCheck";
            this.OverrideSslCheck.Size = new System.Drawing.Size(231, 24);
            this.OverrideSslCheck.TabIndex = 2;
            this.OverrideSslCheck.Text = "Override SSL certificate verification";
            this.OverrideSslCheck.UseVisualStyleBackColor = true;
            // 
            // FindFolderText
            // 
            this.FindFolderText.Location = new System.Drawing.Point(146, 169);
            this.FindFolderText.Name = "FindFolderText";
            this.FindFolderText.Size = new System.Drawing.Size(100, 20);
            this.FindFolderText.TabIndex = 9;
            // 
            // CalendarViewText
            // 
            this.CalendarViewText.Location = new System.Drawing.Point(146, 143);
            this.CalendarViewText.Name = "CalendarViewText";
            this.CalendarViewText.Size = new System.Drawing.Size(100, 20);
            this.CalendarViewText.TabIndex = 7;
            // 
            // DumpFolderLabel
            // 
            this.DumpFolderLabel.Location = new System.Drawing.Point(12, 215);
            this.DumpFolderLabel.Name = "DumpFolderLabel";
            this.DumpFolderLabel.Size = new System.Drawing.Size(128, 23);
            this.DumpFolderLabel.TabIndex = 12;
            this.DumpFolderLabel.Text = "Dump Folder View Size:";
            // 
            // FindItemLabel
            // 
            this.FindItemLabel.Location = new System.Drawing.Point(12, 192);
            this.FindItemLabel.Name = "FindItemLabel";
            this.FindItemLabel.Size = new System.Drawing.Size(128, 23);
            this.FindItemLabel.TabIndex = 10;
            this.FindItemLabel.Text = "FindItem View Size:";
            // 
            // FindFolderLabel
            // 
            this.FindFolderLabel.Location = new System.Drawing.Point(12, 169);
            this.FindFolderLabel.Name = "FindFolderLabel";
            this.FindFolderLabel.Size = new System.Drawing.Size(128, 23);
            this.FindFolderLabel.TabIndex = 8;
            this.FindFolderLabel.Text = "FindFolder View Size:";
            // 
            // CalendarViewLabel
            // 
            this.CalendarViewLabel.Location = new System.Drawing.Point(12, 146);
            this.CalendarViewLabel.Name = "CalendarViewLabel";
            this.CalendarViewLabel.Size = new System.Drawing.Size(128, 23);
            this.CalendarViewLabel.TabIndex = 6;
            this.CalendarViewLabel.Text = "CalendarView Size:";
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(400, 379);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 3;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(319, 379);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // SaveLogFileCheck
            // 
            this.SaveLogFileCheck.Location = new System.Drawing.Point(13, 19);
            this.SaveLogFileCheck.Name = "SaveLogFileCheck";
            this.SaveLogFileCheck.Size = new System.Drawing.Size(161, 24);
            this.SaveLogFileCheck.TabIndex = 0;
            this.SaveLogFileCheck.Text = "Save logging output to a file";
            this.SaveLogFileCheck.UseVisualStyleBackColor = true;
            // 
            // LogFilePathLabel
            // 
            this.LogFilePathLabel.Location = new System.Drawing.Point(13, 50);
            this.LogFilePathLabel.Name = "LogFilePathLabel";
            this.LogFilePathLabel.Size = new System.Drawing.Size(443, 23);
            this.LogFilePathLabel.TabIndex = 1;
            this.LogFilePathLabel.Text = "Log file path:";
            // 
            // LogFilePathText
            // 
            this.LogFilePathText.Location = new System.Drawing.Point(13, 67);
            this.LogFilePathText.Name = "LogFilePathText";
            this.LogFilePathText.Size = new System.Drawing.Size(440, 20);
            this.LogFilePathText.TabIndex = 2;
            // 
            // LoggingGroup
            // 
            this.LoggingGroup.Controls.Add(this.LogFilePathText);
            this.LoggingGroup.Controls.Add(this.LogFilePathLabel);
            this.LoggingGroup.Controls.Add(this.SaveLogFileCheck);
            this.LoggingGroup.Location = new System.Drawing.Point(12, 269);
            this.LoggingGroup.Name = "LoggingGroup";
            this.LoggingGroup.Size = new System.Drawing.Size(462, 105);
            this.LoggingGroup.TabIndex = 1;
            this.LoggingGroup.TabStop = false;
            this.LoggingGroup.Text = "Logging...";
            // 
            // OptionsDialog
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.MyCancelButton;
            this.ClientSize = new System.Drawing.Size(487, 414);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.MiscSettingsGroup);
            this.Controls.Add(this.LoggingGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsDialog_Load);
            this.MiscSettingsGroup.ResumeLayout(false);
            this.MiscSettingsGroup.PerformLayout();
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
    }
}