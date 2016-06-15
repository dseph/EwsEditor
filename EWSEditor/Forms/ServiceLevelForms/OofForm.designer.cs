﻿namespace EWSEditor.Forms
{
    partial class OofForm
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
        private new void InitializeComponent()
        {
            this.CloseButton = new System.Windows.Forms.Button();
            this.GetOofButton = new System.Windows.Forms.Button();
            this.SetOofButton = new System.Windows.Forms.Button();
            this.TargetMailboxLabel = new System.Windows.Forms.Label();
            this.ResolveTargetButton = new System.Windows.Forms.Button();
            this.TargetMailboxText = new System.Windows.Forms.TextBox();
            this.OofSettingsGroup = new System.Windows.Forms.GroupBox();
            this.OofEnabledOption = new System.Windows.Forms.RadioButton();
            this.OofDisabledOption = new System.Windows.Forms.RadioButton();
            this.OofSettingsPanel = new System.Windows.Forms.Panel();
            this.OofScheduledCheck = new System.Windows.Forms.CheckBox();
            this.ReplyMessageTabs = new System.Windows.Forms.TabControl();
            this.InternalReplyTab = new System.Windows.Forms.TabPage();
            this.InternalReplyText = new System.Windows.Forms.TextBox();
            this.InternalReplyCulture = new System.Windows.Forms.TextBox();
            this.InternalReplyCultureLabel = new System.Windows.Forms.Label();
            this.ExternalReplyTab = new System.Windows.Forms.TabPage();
            this.ExternalReplyText = new System.Windows.Forms.TextBox();
            this.TempExternalAudienceCombo = new System.Windows.Forms.ComboBox();
            this.ExternalAudienceLabel = new System.Windows.Forms.Label();
            this.ExternalReplyCulture = new System.Windows.Forms.TextBox();
            this.ExternalReplyCultureLabel = new System.Windows.Forms.Label();
            this.ScheduleEndTimeLabel = new System.Windows.Forms.Label();
            this.ScheduleStartTimeLabel = new System.Windows.Forms.Label();
            this.ScheduledStartTime = new System.Windows.Forms.DateTimePicker();
            this.ScheduledEndTime = new System.Windows.Forms.DateTimePicker();
            this.OofSettingsGroup.SuspendLayout();
            this.OofSettingsPanel.SuspendLayout();
            this.ReplyMessageTabs.SuspendLayout();
            this.InternalReplyTab.SuspendLayout();
            this.ExternalReplyTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.CloseButton.Location = new System.Drawing.Point(726, 820);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(112, 35);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // GetOofButton
            // 
            this.GetOofButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GetOofButton.Location = new System.Drawing.Point(728, 46);
            this.GetOofButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GetOofButton.Name = "GetOofButton";
            this.GetOofButton.Size = new System.Drawing.Size(112, 39);
            this.GetOofButton.TabIndex = 3;
            this.GetOofButton.Text = "Get OOF";
            this.GetOofButton.UseVisualStyleBackColor = true;
            this.GetOofButton.Click += new System.EventHandler(this.GetOofButton_Click);
            // 
            // SetOofButton
            // 
            this.SetOofButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SetOofButton.Location = new System.Drawing.Point(604, 820);
            this.SetOofButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SetOofButton.Name = "SetOofButton";
            this.SetOofButton.Size = new System.Drawing.Size(112, 35);
            this.SetOofButton.TabIndex = 30;
            this.SetOofButton.Text = "Set OOF";
            this.SetOofButton.UseVisualStyleBackColor = true;
            this.SetOofButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // TargetMailboxLabel
            // 
            this.TargetMailboxLabel.AutoSize = true;
            this.TargetMailboxLabel.Location = new System.Drawing.Point(11, 14);
            this.TargetMailboxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TargetMailboxLabel.Name = "TargetMailboxLabel";
            this.TargetMailboxLabel.Size = new System.Drawing.Size(505, 20);
            this.TargetMailboxLabel.TabIndex = 0;
            this.TargetMailboxLabel.Text = "Enter the SMTP address of the mailbox to retrieve OOF settings from...";
            // 
            // ResolveTargetButton
            // 
            this.ResolveTargetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ResolveTargetButton.Location = new System.Drawing.Point(681, 50);
            this.ResolveTargetButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ResolveTargetButton.Name = "ResolveTargetButton";
            this.ResolveTargetButton.Size = new System.Drawing.Size(36, 31);
            this.ResolveTargetButton.TabIndex = 2;
            this.ResolveTargetButton.Text = "...";
            this.ResolveTargetButton.UseVisualStyleBackColor = true;
            this.ResolveTargetButton.Click += new System.EventHandler(this.ResolveTargetButton_Click);
            // 
            // TargetMailboxText
            // 
            this.TargetMailboxText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetMailboxText.Location = new System.Drawing.Point(15, 51);
            this.TargetMailboxText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TargetMailboxText.Name = "TargetMailboxText";
            this.TargetMailboxText.Size = new System.Drawing.Size(650, 26);
            this.TargetMailboxText.TabIndex = 1;
            // 
            // OofSettingsGroup
            // 
            this.OofSettingsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OofSettingsGroup.Controls.Add(this.OofEnabledOption);
            this.OofSettingsGroup.Controls.Add(this.OofDisabledOption);
            this.OofSettingsGroup.Controls.Add(this.OofSettingsPanel);
            this.OofSettingsGroup.Location = new System.Drawing.Point(4, 91);
            this.OofSettingsGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OofSettingsGroup.Name = "OofSettingsGroup";
            this.OofSettingsGroup.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OofSettingsGroup.Size = new System.Drawing.Size(836, 716);
            this.OofSettingsGroup.TabIndex = 4;
            this.OofSettingsGroup.TabStop = false;
            this.OofSettingsGroup.Text = "OOF Settings";
            this.OofSettingsGroup.Enter += new System.EventHandler(this.OofSettingsGroup_Enter);
            // 
            // OofEnabledOption
            // 
            this.OofEnabledOption.AutoSize = true;
            this.OofEnabledOption.Location = new System.Drawing.Point(21, 66);
            this.OofEnabledOption.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OofEnabledOption.Name = "OofEnabledOption";
            this.OofEnabledOption.Size = new System.Drawing.Size(196, 24);
            this.OofEnabledOption.TabIndex = 1;
            this.OofEnabledOption.Text = "Send automatic replies";
            this.OofEnabledOption.UseVisualStyleBackColor = true;
            this.OofEnabledOption.CheckedChanged += new System.EventHandler(this.OofEnabledOption_CheckedChanged);
            // 
            // OofDisabledOption
            // 
            this.OofDisabledOption.AutoSize = true;
            this.OofDisabledOption.Checked = true;
            this.OofDisabledOption.Location = new System.Drawing.Point(21, 31);
            this.OofDisabledOption.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OofDisabledOption.Name = "OofDisabledOption";
            this.OofDisabledOption.Size = new System.Drawing.Size(245, 24);
            this.OofDisabledOption.TabIndex = 0;
            this.OofDisabledOption.TabStop = true;
            this.OofDisabledOption.Text = "Do not send automatic replies";
            this.OofDisabledOption.UseVisualStyleBackColor = true;
            this.OofDisabledOption.CheckedChanged += new System.EventHandler(this.OofDisabledOption_CheckedChanged);
            // 
            // OofSettingsPanel
            // 
            this.OofSettingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OofSettingsPanel.Controls.Add(this.OofScheduledCheck);
            this.OofSettingsPanel.Controls.Add(this.ReplyMessageTabs);
            this.OofSettingsPanel.Controls.Add(this.ScheduleEndTimeLabel);
            this.OofSettingsPanel.Controls.Add(this.ScheduleStartTimeLabel);
            this.OofSettingsPanel.Controls.Add(this.ScheduledStartTime);
            this.OofSettingsPanel.Controls.Add(this.ScheduledEndTime);
            this.OofSettingsPanel.Location = new System.Drawing.Point(9, 101);
            this.OofSettingsPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OofSettingsPanel.Name = "OofSettingsPanel";
            this.OofSettingsPanel.Size = new System.Drawing.Size(825, 606);
            this.OofSettingsPanel.TabIndex = 2;
            // 
            // OofScheduledCheck
            // 
            this.OofScheduledCheck.AutoSize = true;
            this.OofScheduledCheck.Location = new System.Drawing.Point(9, 5);
            this.OofScheduledCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OofScheduledCheck.Name = "OofScheduledCheck";
            this.OofScheduledCheck.Size = new System.Drawing.Size(265, 24);
            this.OofScheduledCheck.TabIndex = 0;
            this.OofScheduledCheck.Text = "Only send during this time range:";
            this.OofScheduledCheck.UseVisualStyleBackColor = true;
            this.OofScheduledCheck.CheckedChanged += new System.EventHandler(this.OofScheduledCheck_CheckedChanged);
            // 
            // ReplyMessageTabs
            // 
            this.ReplyMessageTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReplyMessageTabs.Controls.Add(this.InternalReplyTab);
            this.ReplyMessageTabs.Controls.Add(this.ExternalReplyTab);
            this.ReplyMessageTabs.Location = new System.Drawing.Point(4, 111);
            this.ReplyMessageTabs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ReplyMessageTabs.Name = "ReplyMessageTabs";
            this.ReplyMessageTabs.SelectedIndex = 0;
            this.ReplyMessageTabs.Size = new System.Drawing.Size(816, 489);
            this.ReplyMessageTabs.TabIndex = 5;
            // 
            // InternalReplyTab
            // 
            this.InternalReplyTab.Controls.Add(this.InternalReplyText);
            this.InternalReplyTab.Controls.Add(this.InternalReplyCulture);
            this.InternalReplyTab.Controls.Add(this.InternalReplyCultureLabel);
            this.InternalReplyTab.Location = new System.Drawing.Point(4, 29);
            this.InternalReplyTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InternalReplyTab.Name = "InternalReplyTab";
            this.InternalReplyTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InternalReplyTab.Size = new System.Drawing.Size(808, 456);
            this.InternalReplyTab.TabIndex = 0;
            this.InternalReplyTab.Text = "Internal Reply";
            this.InternalReplyTab.UseVisualStyleBackColor = true;
            // 
            // InternalReplyText
            // 
            this.InternalReplyText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InternalReplyText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InternalReplyText.Location = new System.Drawing.Point(10, 54);
            this.InternalReplyText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InternalReplyText.Multiline = true;
            this.InternalReplyText.Name = "InternalReplyText";
            this.InternalReplyText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InternalReplyText.Size = new System.Drawing.Size(792, 384);
            this.InternalReplyText.TabIndex = 2;
            // 
            // InternalReplyCulture
            // 
            this.InternalReplyCulture.Location = new System.Drawing.Point(82, 14);
            this.InternalReplyCulture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InternalReplyCulture.Name = "InternalReplyCulture";
            this.InternalReplyCulture.Size = new System.Drawing.Size(156, 26);
            this.InternalReplyCulture.TabIndex = 1;
            // 
            // InternalReplyCultureLabel
            // 
            this.InternalReplyCultureLabel.AutoSize = true;
            this.InternalReplyCultureLabel.Location = new System.Drawing.Point(9, 19);
            this.InternalReplyCultureLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InternalReplyCultureLabel.Name = "InternalReplyCultureLabel";
            this.InternalReplyCultureLabel.Size = new System.Drawing.Size(64, 20);
            this.InternalReplyCultureLabel.TabIndex = 0;
            this.InternalReplyCultureLabel.Text = "Culture:";
            // 
            // ExternalReplyTab
            // 
            this.ExternalReplyTab.Controls.Add(this.ExternalReplyText);
            this.ExternalReplyTab.Controls.Add(this.TempExternalAudienceCombo);
            this.ExternalReplyTab.Controls.Add(this.ExternalAudienceLabel);
            this.ExternalReplyTab.Controls.Add(this.ExternalReplyCulture);
            this.ExternalReplyTab.Controls.Add(this.ExternalReplyCultureLabel);
            this.ExternalReplyTab.Location = new System.Drawing.Point(4, 29);
            this.ExternalReplyTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExternalReplyTab.Name = "ExternalReplyTab";
            this.ExternalReplyTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExternalReplyTab.Size = new System.Drawing.Size(808, 456);
            this.ExternalReplyTab.TabIndex = 1;
            this.ExternalReplyTab.Text = "External Reply";
            this.ExternalReplyTab.UseVisualStyleBackColor = true;
            // 
            // ExternalReplyText
            // 
            this.ExternalReplyText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExternalReplyText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExternalReplyText.Location = new System.Drawing.Point(10, 54);
            this.ExternalReplyText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExternalReplyText.Multiline = true;
            this.ExternalReplyText.Name = "ExternalReplyText";
            this.ExternalReplyText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ExternalReplyText.Size = new System.Drawing.Size(790, 392);
            this.ExternalReplyText.TabIndex = 52;
            // 
            // TempExternalAudienceCombo
            // 
            this.TempExternalAudienceCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TempExternalAudienceCombo.FormattingEnabled = true;
            this.TempExternalAudienceCombo.Location = new System.Drawing.Point(504, 9);
            this.TempExternalAudienceCombo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TempExternalAudienceCombo.Name = "TempExternalAudienceCombo";
            this.TempExternalAudienceCombo.Size = new System.Drawing.Size(237, 28);
            this.TempExternalAudienceCombo.TabIndex = 51;
            // 
            // ExternalAudienceLabel
            // 
            this.ExternalAudienceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExternalAudienceLabel.AutoSize = true;
            this.ExternalAudienceLabel.Location = new System.Drawing.Point(346, 14);
            this.ExternalAudienceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ExternalAudienceLabel.Name = "ExternalAudienceLabel";
            this.ExternalAudienceLabel.Size = new System.Drawing.Size(142, 20);
            this.ExternalAudienceLabel.TabIndex = 50;
            this.ExternalAudienceLabel.Text = "External Audience:";
            // 
            // ExternalReplyCulture
            // 
            this.ExternalReplyCulture.Location = new System.Drawing.Point(82, 14);
            this.ExternalReplyCulture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExternalReplyCulture.Name = "ExternalReplyCulture";
            this.ExternalReplyCulture.Size = new System.Drawing.Size(156, 26);
            this.ExternalReplyCulture.TabIndex = 28;
            // 
            // ExternalReplyCultureLabel
            // 
            this.ExternalReplyCultureLabel.AutoSize = true;
            this.ExternalReplyCultureLabel.Location = new System.Drawing.Point(9, 19);
            this.ExternalReplyCultureLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ExternalReplyCultureLabel.Name = "ExternalReplyCultureLabel";
            this.ExternalReplyCultureLabel.Size = new System.Drawing.Size(64, 20);
            this.ExternalReplyCultureLabel.TabIndex = 29;
            this.ExternalReplyCultureLabel.Text = "Culture:";
            // 
            // ScheduleEndTimeLabel
            // 
            this.ScheduleEndTimeLabel.AutoSize = true;
            this.ScheduleEndTimeLabel.Enabled = false;
            this.ScheduleEndTimeLabel.Location = new System.Drawing.Point(40, 74);
            this.ScheduleEndTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ScheduleEndTimeLabel.Name = "ScheduleEndTimeLabel";
            this.ScheduleEndTimeLabel.Size = new System.Drawing.Size(80, 20);
            this.ScheduleEndTimeLabel.TabIndex = 3;
            this.ScheduleEndTimeLabel.Text = "End Time:";
            // 
            // ScheduleStartTimeLabel
            // 
            this.ScheduleStartTimeLabel.AutoSize = true;
            this.ScheduleStartTimeLabel.Enabled = false;
            this.ScheduleStartTimeLabel.Location = new System.Drawing.Point(40, 36);
            this.ScheduleStartTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ScheduleStartTimeLabel.Name = "ScheduleStartTimeLabel";
            this.ScheduleStartTimeLabel.Size = new System.Drawing.Size(86, 20);
            this.ScheduleStartTimeLabel.TabIndex = 1;
            this.ScheduleStartTimeLabel.Text = "Start Time:";
            // 
            // ScheduledStartTime
            // 
            this.ScheduledStartTime.CustomFormat = "MMM dd, yyyy - hh:mm tt";
            this.ScheduledStartTime.Enabled = false;
            this.ScheduledStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ScheduledStartTime.Location = new System.Drawing.Point(136, 36);
            this.ScheduledStartTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ScheduledStartTime.Name = "ScheduledStartTime";
            this.ScheduledStartTime.Size = new System.Drawing.Size(237, 26);
            this.ScheduledStartTime.TabIndex = 2;
            // 
            // ScheduledEndTime
            // 
            this.ScheduledEndTime.CustomFormat = "MMM dd, yyyy - hh:mm tt";
            this.ScheduledEndTime.Enabled = false;
            this.ScheduledEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ScheduledEndTime.Location = new System.Drawing.Point(136, 74);
            this.ScheduledEndTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ScheduledEndTime.Name = "ScheduledEndTime";
            this.ScheduledEndTime.Size = new System.Drawing.Size(237, 26);
            this.ScheduledEndTime.TabIndex = 4;
            // 
            // OofForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(855, 871);
            this.Controls.Add(this.OofSettingsGroup);
            this.Controls.Add(this.TargetMailboxLabel);
            this.Controls.Add(this.ResolveTargetButton);
            this.Controls.Add(this.TargetMailboxText);
            this.Controls.Add(this.SetOofButton);
            this.Controls.Add(this.GetOofButton);
            this.Controls.Add(this.CloseButton);
            this.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Name = "OofForm";
            this.Text = "User OOF Settings";
            this.Load += new System.EventHandler(this.OofForm_Load);
            this.OofSettingsGroup.ResumeLayout(false);
            this.OofSettingsGroup.PerformLayout();
            this.OofSettingsPanel.ResumeLayout(false);
            this.OofSettingsPanel.PerformLayout();
            this.ReplyMessageTabs.ResumeLayout(false);
            this.InternalReplyTab.ResumeLayout(false);
            this.InternalReplyTab.PerformLayout();
            this.ExternalReplyTab.ResumeLayout(false);
            this.ExternalReplyTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button GetOofButton;
        private System.Windows.Forms.Button SetOofButton;
        private System.Windows.Forms.Label TargetMailboxLabel;
        private System.Windows.Forms.Button ResolveTargetButton;
        private System.Windows.Forms.TextBox TargetMailboxText;
        private System.Windows.Forms.GroupBox OofSettingsGroup;
        private System.Windows.Forms.Label ScheduleEndTimeLabel;
        private System.Windows.Forms.Label ScheduleStartTimeLabel;
        private System.Windows.Forms.DateTimePicker ScheduledEndTime;
        private System.Windows.Forms.DateTimePicker ScheduledStartTime;
        private System.Windows.Forms.Panel OofSettingsPanel;
        private System.Windows.Forms.TabControl ReplyMessageTabs;
        private System.Windows.Forms.TabPage InternalReplyTab;
        private System.Windows.Forms.TextBox InternalReplyText;
        private System.Windows.Forms.TextBox InternalReplyCulture;
        private System.Windows.Forms.Label InternalReplyCultureLabel;
        private System.Windows.Forms.TabPage ExternalReplyTab;
        private System.Windows.Forms.TextBox ExternalReplyCulture;
        private System.Windows.Forms.Label ExternalReplyCultureLabel;
        private System.Windows.Forms.RadioButton OofEnabledOption;
        private System.Windows.Forms.RadioButton OofDisabledOption;
        private System.Windows.Forms.CheckBox OofScheduledCheck;
        private System.Windows.Forms.ComboBox TempExternalAudienceCombo;
        private System.Windows.Forms.Label ExternalAudienceLabel;
        private System.Windows.Forms.TextBox ExternalReplyText;
    }
}