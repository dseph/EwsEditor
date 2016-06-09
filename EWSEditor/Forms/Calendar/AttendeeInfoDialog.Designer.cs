namespace EWSEditor.Forms
{
    partial class AttendeeInfoDialog
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
            this.OkButton = new System.Windows.Forms.Button();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.AttendeeInfoGroup = new System.Windows.Forms.GroupBox();
            this.AttendeeTypeLabelName = new System.Windows.Forms.Label();
            this.ExcludeConflictsLabelDesc = new System.Windows.Forms.Label();
            this.ExcludeConflictsCheck = new System.Windows.Forms.CheckBox();
            this.AttendeeTypeLabelDesc = new System.Windows.Forms.Label();
            this.TempAttendeeTypeCombo = new System.Windows.Forms.ComboBox();
            this.SmtpAddressLabelName = new System.Windows.Forms.Label();
            this.SmtpAddressLabelDesc = new System.Windows.Forms.Label();
            this.ResolveNamesButton = new System.Windows.Forms.Button();
            this.SmtpAddressText = new System.Windows.Forms.TextBox();
            this.AttendeeInfoGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(153, 214);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 5;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(234, 214);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 6;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            // 
            // AttendeeInfoGroup
            // 
            this.AttendeeInfoGroup.Controls.Add(this.AttendeeTypeLabelName);
            this.AttendeeInfoGroup.Controls.Add(this.ExcludeConflictsLabelDesc);
            this.AttendeeInfoGroup.Controls.Add(this.ExcludeConflictsCheck);
            this.AttendeeInfoGroup.Controls.Add(this.AttendeeTypeLabelDesc);
            this.AttendeeInfoGroup.Controls.Add(this.TempAttendeeTypeCombo);
            this.AttendeeInfoGroup.Location = new System.Drawing.Point(10, 70);
            this.AttendeeInfoGroup.Name = "AttendeeInfoGroup";
            this.AttendeeInfoGroup.Size = new System.Drawing.Size(299, 131);
            this.AttendeeInfoGroup.TabIndex = 4;
            this.AttendeeInfoGroup.TabStop = false;
            this.AttendeeInfoGroup.Text = "Attendee Settings";
            // 
            // AttendeeTypeLabelName
            // 
            this.AttendeeTypeLabelName.Location = new System.Drawing.Point(25, 37);
            this.AttendeeTypeLabelName.Name = "AttendeeTypeLabelName";
            this.AttendeeTypeLabelName.Size = new System.Drawing.Size(75, 18);
            this.AttendeeTypeLabelName.TabIndex = 1;
            this.AttendeeTypeLabelName.Text = "AttendeeType:";
            // 
            // ExcludeConflictsLabelDesc
            // 
            this.ExcludeConflictsLabelDesc.Location = new System.Drawing.Point(11, 73);
            this.ExcludeConflictsLabelDesc.Name = "ExcludeConflictsLabelDesc";
            this.ExcludeConflictsLabelDesc.Size = new System.Drawing.Size(262, 18);
            this.ExcludeConflictsLabelDesc.TabIndex = 3;
            this.ExcludeConflictsLabelDesc.Text = "Should conflicts be excluded from availabilty results?";
            // 
            // ExcludeConflictsCheck
            // 
            this.ExcludeConflictsCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExcludeConflictsCheck.Location = new System.Drawing.Point(28, 94);
            this.ExcludeConflictsCheck.Name = "ExcludeConflictsCheck";
            this.ExcludeConflictsCheck.Size = new System.Drawing.Size(110, 20);
            this.ExcludeConflictsCheck.TabIndex = 4;
            this.ExcludeConflictsCheck.Text = "ExcludeConflicts:";
            this.ExcludeConflictsCheck.UseVisualStyleBackColor = true;
            // 
            // AttendeeTypeLabelDesc
            // 
            this.AttendeeTypeLabelDesc.Location = new System.Drawing.Point(11, 16);
            this.AttendeeTypeLabelDesc.Name = "AttendeeTypeLabelDesc";
            this.AttendeeTypeLabelDesc.Size = new System.Drawing.Size(262, 18);
            this.AttendeeTypeLabelDesc.TabIndex = 0;
            this.AttendeeTypeLabelDesc.Text = "Select the meeting attendee type.";
            // 
            // TempAttendeeTypeCombo
            // 
            this.TempAttendeeTypeCombo.FormattingEnabled = true;
            this.TempAttendeeTypeCombo.Location = new System.Drawing.Point(106, 36);
            this.TempAttendeeTypeCombo.Name = "TempAttendeeTypeCombo";
            this.TempAttendeeTypeCombo.Size = new System.Drawing.Size(164, 21);
            this.TempAttendeeTypeCombo.TabIndex = 2;
            // 
            // SmtpAddressLabelName
            // 
            this.SmtpAddressLabelName.Location = new System.Drawing.Point(21, 46);
            this.SmtpAddressLabelName.Name = "SmtpAddressLabelName";
            this.SmtpAddressLabelName.Size = new System.Drawing.Size(89, 18);
            this.SmtpAddressLabelName.TabIndex = 1;
            this.SmtpAddressLabelName.Text = "Attendee SMTP:";
            // 
            // SmtpAddressLabelDesc
            // 
            this.SmtpAddressLabelDesc.Location = new System.Drawing.Point(7, 9);
            this.SmtpAddressLabelDesc.Name = "SmtpAddressLabelDesc";
            this.SmtpAddressLabelDesc.Size = new System.Drawing.Size(302, 32);
            this.SmtpAddressLabelDesc.TabIndex = 0;
            this.SmtpAddressLabelDesc.Text = "Enter the attendee\'s SMTP address or use the ResolveNames dialog to find it.";
            // 
            // ResolveNamesButton
            // 
            this.ResolveNamesButton.Location = new System.Drawing.Point(280, 44);
            this.ResolveNamesButton.Name = "ResolveNamesButton";
            this.ResolveNamesButton.Size = new System.Drawing.Size(26, 20);
            this.ResolveNamesButton.TabIndex = 3;
            this.ResolveNamesButton.Text = "...";
            this.ResolveNamesButton.UseVisualStyleBackColor = true;
            this.ResolveNamesButton.Click += new System.EventHandler(this.ResolveNamesButton_Click);
            // 
            // SmtpAddressText
            // 
            this.SmtpAddressText.Location = new System.Drawing.Point(116, 44);
            this.SmtpAddressText.Name = "SmtpAddressText";
            this.SmtpAddressText.Size = new System.Drawing.Size(164, 20);
            this.SmtpAddressText.TabIndex = 2;
            // 
            // AttendeeInfoDialog
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 249);
            this.Controls.Add(this.SmtpAddressLabelName);
            this.Controls.Add(this.AttendeeInfoGroup);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.SmtpAddressLabelDesc);
            this.Controls.Add(this.SmtpAddressText);
            this.Controls.Add(this.ResolveNamesButton);
            this.Name = "AttendeeInfoDialog";
            this.Text = "Attendee Info";
            this.Load += new System.EventHandler(this.AttendeeInfoDialog_Load);
            this.AttendeeInfoGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.GroupBox AttendeeInfoGroup;
        private System.Windows.Forms.Label SmtpAddressLabelName;
        private System.Windows.Forms.Label AttendeeTypeLabelName;
        private System.Windows.Forms.Label ExcludeConflictsLabelDesc;
        private System.Windows.Forms.CheckBox ExcludeConflictsCheck;
        private System.Windows.Forms.Label AttendeeTypeLabelDesc;
        private System.Windows.Forms.ComboBox TempAttendeeTypeCombo;
        private System.Windows.Forms.Label SmtpAddressLabelDesc;
        private System.Windows.Forms.Button ResolveNamesButton;
        private System.Windows.Forms.TextBox SmtpAddressText;

    }
}