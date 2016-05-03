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
            this.label1 = new System.Windows.Forms.Label();
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
            // WellKnownGroup
            // 
            this.WellKnownGroup.Controls.Add(this.label1);
            this.WellKnownGroup.Controls.Add(this.TempWellKnownFolderCombo);
            this.WellKnownGroup.Controls.Add(this.label8);
            this.WellKnownGroup.Controls.Add(this.label12);
            this.WellKnownGroup.Controls.Add(this.MailboxAddressText);
            this.WellKnownGroup.Controls.Add(this.label11);
            this.WellKnownGroup.Location = new System.Drawing.Point(36, 220);
            this.WellKnownGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WellKnownGroup.Name = "WellKnownGroup";
            this.WellKnownGroup.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WellKnownGroup.Size = new System.Drawing.Size(525, 283);
            this.WellKnownGroup.TabIndex = 3;
            this.WellKnownGroup.TabStop = false;
            this.WellKnownGroup.Text = "Well Known Folder Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "SMTP address for the mailbox to do delegate access to:";
            // 
            // TempWellKnownFolderCombo
            // 
            this.TempWellKnownFolderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempWellKnownFolderCombo.FormattingEnabled = true;
            this.TempWellKnownFolderCombo.Location = new System.Drawing.Point(146, 43);
            this.TempWellKnownFolderCombo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TempWellKnownFolderCombo.Name = "TempWellKnownFolderCombo";
            this.TempWellKnownFolderCombo.Size = new System.Drawing.Size(354, 28);
            this.TempWellKnownFolderCombo.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 55);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Folder Name:";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(33, 182);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(442, 78);
            this.label12.TabIndex = 2;
            this.label12.Text = "Enter the SMTP address of the mailbox to access using delegate access.  Leave thi" +
    "s field empty to access the default mailbox.  ";
            // 
            // MailboxAddressText
            // 
            this.MailboxAddressText.Location = new System.Drawing.Point(176, 146);
            this.MailboxAddressText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MailboxAddressText.Name = "MailboxAddressText";
            this.MailboxAddressText.Size = new System.Drawing.Size(324, 26);
            this.MailboxAddressText.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(33, 151);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "SMTP Adress:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(448, 512);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(327, 512);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(112, 35);
            this.OkButton.TabIndex = 4;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // UniqueIdGroup
            // 
            this.UniqueIdGroup.Controls.Add(this.SpecFolderIdText);
            this.UniqueIdGroup.Controls.Add(this.label9);
            this.UniqueIdGroup.Location = new System.Drawing.Point(36, 66);
            this.UniqueIdGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UniqueIdGroup.Name = "UniqueIdGroup";
            this.UniqueIdGroup.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UniqueIdGroup.Size = new System.Drawing.Size(525, 88);
            this.UniqueIdGroup.TabIndex = 1;
            this.UniqueIdGroup.TabStop = false;
            this.UniqueIdGroup.Text = "Unique ID";
            // 
            // SpecFolderIdText
            // 
            this.SpecFolderIdText.Enabled = false;
            this.SpecFolderIdText.Location = new System.Drawing.Point(150, 31);
            this.SpecFolderIdText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SpecFolderIdText.Name = "SpecFolderIdText";
            this.SpecFolderIdText.Size = new System.Drawing.Size(354, 26);
            this.SpecFolderIdText.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 40);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Folder Id:";
            // 
            // UniqueIdRadio
            // 
            this.UniqueIdRadio.Location = new System.Drawing.Point(18, 18);
            this.UniqueIdRadio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UniqueIdRadio.Name = "UniqueIdRadio";
            this.UniqueIdRadio.Size = new System.Drawing.Size(543, 37);
            this.UniqueIdRadio.TabIndex = 0;
            this.UniqueIdRadio.Text = "Identify folder by unique id.";
            this.UniqueIdRadio.UseVisualStyleBackColor = true;
            this.UniqueIdRadio.CheckedChanged += new System.EventHandler(this.UniqueIdRadio_CheckedChanged);
            // 
            // WellKnownRadio
            // 
            this.WellKnownRadio.Location = new System.Drawing.Point(18, 174);
            this.WellKnownRadio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WellKnownRadio.Name = "WellKnownRadio";
            this.WellKnownRadio.Size = new System.Drawing.Size(543, 37);
            this.WellKnownRadio.TabIndex = 2;
            this.WellKnownRadio.Text = "Identify folder by well known name.";
            this.WellKnownRadio.UseVisualStyleBackColor = true;
            this.WellKnownRadio.CheckedChanged += new System.EventHandler(this.WellKnownRadio_CheckedChanged);
            // 
            // FolderIdDialog
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(579, 566);
            this.Controls.Add(this.WellKnownRadio);
            this.Controls.Add(this.UniqueIdRadio);
            this.Controls.Add(this.UniqueIdGroup);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.WellKnownGroup);
            this.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.Name = "FolderIdDialog";
            this.Text = "EWSEditor - Select a FolderId";
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
        private System.Windows.Forms.Label label1;
    }
}