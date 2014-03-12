namespace EWSEditor.Forms
{
    partial class DelegateUserDialog
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
            this.grpDelegatePermissions = new System.Windows.Forms.GroupBox();
            this.DelegateReceivesCopyCheck = new System.Windows.Forms.CheckBox();
            this.PrivateItemsCheck = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TempJournalPermissionComboBox = new System.Windows.Forms.ComboBox();
            this.TempNotesPermissionComboBox = new System.Windows.Forms.ComboBox();
            this.TempContactsPermissionComboBox = new System.Windows.Forms.ComboBox();
            this.TempInboxPermissionComboBox = new System.Windows.Forms.ComboBox();
            this.TempTasksPermissionComboBox = new System.Windows.Forms.ComboBox();
            this.TempCalendarPermissionComboBox = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.UserIdText = new System.Windows.Forms.TextBox();
            this.GetUserIdButton = new System.Windows.Forms.Button();
            this.grpDelegatePermissions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDelegatePermissions
            // 
            this.grpDelegatePermissions.Controls.Add(this.DelegateReceivesCopyCheck);
            this.grpDelegatePermissions.Controls.Add(this.PrivateItemsCheck);
            this.grpDelegatePermissions.Controls.Add(this.label6);
            this.grpDelegatePermissions.Controls.Add(this.label5);
            this.grpDelegatePermissions.Controls.Add(this.label4);
            this.grpDelegatePermissions.Controls.Add(this.label3);
            this.grpDelegatePermissions.Controls.Add(this.label2);
            this.grpDelegatePermissions.Controls.Add(this.label1);
            this.grpDelegatePermissions.Controls.Add(this.TempJournalPermissionComboBox);
            this.grpDelegatePermissions.Controls.Add(this.TempNotesPermissionComboBox);
            this.grpDelegatePermissions.Controls.Add(this.TempContactsPermissionComboBox);
            this.grpDelegatePermissions.Controls.Add(this.TempInboxPermissionComboBox);
            this.grpDelegatePermissions.Controls.Add(this.TempTasksPermissionComboBox);
            this.grpDelegatePermissions.Controls.Add(this.TempCalendarPermissionComboBox);
            this.grpDelegatePermissions.Location = new System.Drawing.Point(12, 37);
            this.grpDelegatePermissions.Name = "grpDelegatePermissions";
            this.grpDelegatePermissions.Size = new System.Drawing.Size(337, 254);
            this.grpDelegatePermissions.TabIndex = 4;
            this.grpDelegatePermissions.TabStop = false;
            this.grpDelegatePermissions.Text = "This delegate has the following permissions";
            // 
            // DelegateReceivesCopyCheck
            // 
            this.DelegateReceivesCopyCheck.Location = new System.Drawing.Point(20, 181);
            this.DelegateReceivesCopyCheck.Name = "DelegateReceivesCopyCheck";
            this.DelegateReceivesCopyCheck.Size = new System.Drawing.Size(311, 36);
            this.DelegateReceivesCopyCheck.TabIndex = 12;
            this.DelegateReceivesCopyCheck.Text = "Delegate receives copies of meeting-related messages sent to me";
            this.DelegateReceivesCopyCheck.UseVisualStyleBackColor = true;
            // 
            // PrivateItemsCheck
            // 
            this.PrivateItemsCheck.Location = new System.Drawing.Point(20, 223);
            this.PrivateItemsCheck.Name = "PrivateItemsCheck";
            this.PrivateItemsCheck.Size = new System.Drawing.Size(311, 24);
            this.PrivateItemsCheck.TabIndex = 13;
            this.PrivateItemsCheck.Text = "Delegate can see my private items";
            this.PrivateItemsCheck.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(17, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Journal";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(17, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Notes";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(17, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contacts";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(17, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Inbox";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Calendar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tasks";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TempJournalPermissionComboBox
            // 
            this.TempJournalPermissionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempJournalPermissionComboBox.FormattingEnabled = true;
            this.TempJournalPermissionComboBox.Location = new System.Drawing.Point(109, 154);
            this.TempJournalPermissionComboBox.Name = "TempJournalPermissionComboBox";
            this.TempJournalPermissionComboBox.Size = new System.Drawing.Size(222, 21);
            this.TempJournalPermissionComboBox.TabIndex = 11;
            // 
            // TempNotesPermissionComboBox
            // 
            this.TempNotesPermissionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempNotesPermissionComboBox.FormattingEnabled = true;
            this.TempNotesPermissionComboBox.Location = new System.Drawing.Point(109, 127);
            this.TempNotesPermissionComboBox.Name = "TempNotesPermissionComboBox";
            this.TempNotesPermissionComboBox.Size = new System.Drawing.Size(222, 21);
            this.TempNotesPermissionComboBox.TabIndex = 9;
            // 
            // TempContactsPermissionComboBox
            // 
            this.TempContactsPermissionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempContactsPermissionComboBox.FormattingEnabled = true;
            this.TempContactsPermissionComboBox.Location = new System.Drawing.Point(109, 100);
            this.TempContactsPermissionComboBox.Name = "TempContactsPermissionComboBox";
            this.TempContactsPermissionComboBox.Size = new System.Drawing.Size(222, 21);
            this.TempContactsPermissionComboBox.TabIndex = 7;
            // 
            // TempInboxPermissionComboBox
            // 
            this.TempInboxPermissionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempInboxPermissionComboBox.FormattingEnabled = true;
            this.TempInboxPermissionComboBox.Location = new System.Drawing.Point(109, 73);
            this.TempInboxPermissionComboBox.Name = "TempInboxPermissionComboBox";
            this.TempInboxPermissionComboBox.Size = new System.Drawing.Size(222, 21);
            this.TempInboxPermissionComboBox.TabIndex = 5;
            // 
            // TempTasksPermissionComboBox
            // 
            this.TempTasksPermissionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempTasksPermissionComboBox.FormattingEnabled = true;
            this.TempTasksPermissionComboBox.Location = new System.Drawing.Point(109, 46);
            this.TempTasksPermissionComboBox.Name = "TempTasksPermissionComboBox";
            this.TempTasksPermissionComboBox.Size = new System.Drawing.Size(222, 21);
            this.TempTasksPermissionComboBox.TabIndex = 3;
            // 
            // TempCalendarPermissionComboBox
            // 
            this.TempCalendarPermissionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempCalendarPermissionComboBox.FormattingEnabled = true;
            this.TempCalendarPermissionComboBox.Location = new System.Drawing.Point(109, 20);
            this.TempCalendarPermissionComboBox.Name = "TempCalendarPermissionComboBox";
            this.TempCalendarPermissionComboBox.Size = new System.Drawing.Size(222, 21);
            this.TempCalendarPermissionComboBox.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(275, 301);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(194, 301);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Delegate User:";
            // 
            // UserIdText
            // 
            this.UserIdText.Location = new System.Drawing.Point(98, 10);
            this.UserIdText.Name = "UserIdText";
            this.UserIdText.ReadOnly = true;
            this.UserIdText.Size = new System.Drawing.Size(223, 20);
            this.UserIdText.TabIndex = 0;
            // 
            // GetUserIdButton
            // 
            this.GetUserIdButton.Location = new System.Drawing.Point(324, 8);
            this.GetUserIdButton.Name = "GetUserIdButton";
            this.GetUserIdButton.Size = new System.Drawing.Size(27, 23);
            this.GetUserIdButton.TabIndex = 1;
            this.GetUserIdButton.Text = "...";
            this.GetUserIdButton.UseVisualStyleBackColor = true;
            this.GetUserIdButton.Click += new System.EventHandler(this.GetUserIdButton_Click);
            // 
            // DelegateUserDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(361, 336);
            this.Controls.Add(this.GetUserIdButton);
            this.Controls.Add(this.UserIdText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpDelegatePermissions);
            this.Name = "DelegateUserDialog";
            this.Text = "Delegate User";
            this.Load += new System.EventHandler(this.DelegateUserDialog_Load);
            this.grpDelegatePermissions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDelegatePermissions;
        private System.Windows.Forms.CheckBox DelegateReceivesCopyCheck;
        private System.Windows.Forms.CheckBox PrivateItemsCheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TempJournalPermissionComboBox;
        private System.Windows.Forms.ComboBox TempNotesPermissionComboBox;
        private System.Windows.Forms.ComboBox TempContactsPermissionComboBox;
        private System.Windows.Forms.ComboBox TempInboxPermissionComboBox;
        private System.Windows.Forms.ComboBox TempTasksPermissionComboBox;
        private System.Windows.Forms.ComboBox TempCalendarPermissionComboBox;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox UserIdText;
        private System.Windows.Forms.Button GetUserIdButton;
    }
}
