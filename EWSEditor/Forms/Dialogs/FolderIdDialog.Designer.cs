namespace EWSEditor.Forms
{
    partial class FolderIdDialog
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
            this.WellKnownGroup = new System.Windows.Forms.GroupBox();
            this.TempWellKnownFolderCombo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.MailboxAddressText = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.UniqueIdGroup = new System.Windows.Forms.GroupBox();
            this.SpecFolderIdText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.UniqueIdRadio = new System.Windows.Forms.RadioButton();
            this.WellKnownRadio = new System.Windows.Forms.RadioButton();
            this.WellKnownGroup.SuspendLayout();
            this.UniqueIdGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpWellKnown
            // 
            this.WellKnownGroup.Controls.Add(this.TempWellKnownFolderCombo);
            this.WellKnownGroup.Controls.Add(this.label8);
            this.WellKnownGroup.Controls.Add(this.label12);
            this.WellKnownGroup.Controls.Add(this.MailboxAddressText);
            this.WellKnownGroup.Controls.Add(this.label11);
            this.WellKnownGroup.Location = new System.Drawing.Point(24, 143);
            this.WellKnownGroup.Name = "grpWellKnown";
            this.WellKnownGroup.Size = new System.Drawing.Size(350, 132);
            this.WellKnownGroup.TabIndex = 0;
            this.WellKnownGroup.TabStop = false;
            this.WellKnownGroup.Text = "Well Known Folder Name";
            // 
            // cboDistFolder
            // 
            this.TempWellKnownFolderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempWellKnownFolderCombo.FormattingEnabled = true;
            this.TempWellKnownFolderCombo.Location = new System.Drawing.Point(97, 28);
            this.TempWellKnownFolderCombo.Name = "cboDistFolder";
            this.TempWellKnownFolderCombo.Size = new System.Drawing.Size(237, 21);
            this.TempWellKnownFolderCombo.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Folder Name:";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(328, 26);
            this.label12.TabIndex = 33;
            this.label12.Text = "Enter the SMTP address of the mailbox to access.  Leave this field empty to acces" +
                "s the default mailbox.";
            // 
            // txtMailboxAddress
            // 
            this.MailboxAddressText.Location = new System.Drawing.Point(97, 96);
            this.MailboxAddressText.Name = "txtMailboxAddress";
            this.MailboxAddressText.Size = new System.Drawing.Size(237, 20);
            this.MailboxAddressText.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "SMTP Adress:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(299, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(218, 296);
            this.OkButton.Name = "btnOK";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 8;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // grpUniqueId
            // 
            this.UniqueIdGroup.Controls.Add(this.SpecFolderIdText);
            this.UniqueIdGroup.Controls.Add(this.label9);
            this.UniqueIdGroup.Location = new System.Drawing.Point(24, 43);
            this.UniqueIdGroup.Name = "grpUniqueId";
            this.UniqueIdGroup.Size = new System.Drawing.Size(350, 57);
            this.UniqueIdGroup.TabIndex = 10;
            this.UniqueIdGroup.TabStop = false;
            this.UniqueIdGroup.Text = "Unique ID";
            // 
            // txtSpecFolderId
            // 
            this.SpecFolderIdText.Enabled = false;
            this.SpecFolderIdText.Location = new System.Drawing.Point(100, 20);
            this.SpecFolderIdText.Name = "txtSpecFolderId";
            this.SpecFolderIdText.Size = new System.Drawing.Size(237, 20);
            this.SpecFolderIdText.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Folder Id:";
            // 
            // rdoUniqueId
            // 
            this.UniqueIdRadio.Location = new System.Drawing.Point(12, 12);
            this.UniqueIdRadio.Name = "rdoUniqueId";
            this.UniqueIdRadio.Size = new System.Drawing.Size(362, 24);
            this.UniqueIdRadio.TabIndex = 11;
            this.UniqueIdRadio.Text = "Identify folder by unique id.";
            this.UniqueIdRadio.UseVisualStyleBackColor = true;
            this.UniqueIdRadio.CheckedChanged += new System.EventHandler(this.UniqueIdRadio_CheckedChanged);
            // 
            // rdoWellKnown
            // 
            this.WellKnownRadio.Location = new System.Drawing.Point(12, 113);
            this.WellKnownRadio.Name = "rdoWellKnown";
            this.WellKnownRadio.Size = new System.Drawing.Size(362, 24);
            this.WellKnownRadio.TabIndex = 12;
            this.WellKnownRadio.Text = "Identify folder by well known name.";
            this.WellKnownRadio.UseVisualStyleBackColor = true;
            this.WellKnownRadio.CheckedChanged += new System.EventHandler(this.WellKnownRadio_CheckedChanged);
            // 
            // FolderIdDialog
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(386, 331);
            this.ControlBox = true;
            this.Controls.Add(this.WellKnownRadio);
            this.Controls.Add(this.UniqueIdRadio);
            this.Controls.Add(this.UniqueIdGroup);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.WellKnownGroup);
            this.Name = "FolderIdDialog";
            this.Text = "EWSEditor - Create a FolderId";
            this.Load += new System.EventHandler(this.FolderIdDialog_Load);
            this.WellKnownGroup.ResumeLayout(false);
            this.WellKnownGroup.PerformLayout();
            this.UniqueIdGroup.ResumeLayout(false);
            this.UniqueIdGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox WellKnownGroup;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox MailboxAddressText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.ComboBox TempWellKnownFolderCombo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox UniqueIdGroup;
        private System.Windows.Forms.TextBox SpecFolderIdText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton UniqueIdRadio;
        private System.Windows.Forms.RadioButton WellKnownRadio;
    }
}