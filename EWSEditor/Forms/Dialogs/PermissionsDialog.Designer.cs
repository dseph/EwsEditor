namespace EWSEditor.Forms
{
    partial class PermissionsDialog
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
            this.grpPermissions = new System.Windows.Forms.GroupBox();
            this.grpOther = new System.Windows.Forms.GroupBox();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.chkContact = new System.Windows.Forms.CheckBox();
            this.chkOwner = new System.Windows.Forms.CheckBox();
            this.grpDelete = new System.Windows.Forms.GroupBox();
            this.rdoDeleteAll = new System.Windows.Forms.RadioButton();
            this.rdoDeleteOwn = new System.Windows.Forms.RadioButton();
            this.rdoDeleteNone = new System.Windows.Forms.RadioButton();
            this.grpWrite = new System.Windows.Forms.GroupBox();
            this.chkEditAll = new System.Windows.Forms.CheckBox();
            this.chkEditOwn = new System.Windows.Forms.CheckBox();
            this.chkCreateSubFolders = new System.Windows.Forms.CheckBox();
            this.chkCreateItems = new System.Windows.Forms.CheckBox();
            this.grpRead = new System.Windows.Forms.GroupBox();
            this.rdoTimeOnly = new System.Windows.Forms.RadioButton();
            this.rdoTimeSubjectLocation = new System.Windows.Forms.RadioButton();
            this.rdoReadFull = new System.Windows.Forms.RadioButton();
            this.rdoReadNone = new System.Windows.Forms.RadioButton();
            this.TempPermissionLevelCombo = new System.Windows.Forms.ComboBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstUsers = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPermLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpPermissions.SuspendLayout();
            this.grpOther.SuspendLayout();
            this.grpDelete.SuspendLayout();
            this.grpWrite.SuspendLayout();
            this.grpRead.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPermissions
            // 
            this.grpPermissions.Controls.Add(this.grpOther);
            this.grpPermissions.Controls.Add(this.grpDelete);
            this.grpPermissions.Controls.Add(this.grpWrite);
            this.grpPermissions.Controls.Add(this.grpRead);
            this.grpPermissions.Controls.Add(this.TempPermissionLevelCombo);
            this.grpPermissions.Controls.Add(this.lblLevel);
            this.grpPermissions.Location = new System.Drawing.Point(13, 187);
            this.grpPermissions.Name = "grpPermissions";
            this.grpPermissions.Size = new System.Drawing.Size(321, 269);
            this.grpPermissions.TabIndex = 1;
            this.grpPermissions.TabStop = false;
            this.grpPermissions.Text = "Permissions";
            // 
            // grpOther
            // 
            this.grpOther.Controls.Add(this.chkVisible);
            this.grpOther.Controls.Add(this.chkContact);
            this.grpOther.Controls.Add(this.chkOwner);
            this.grpOther.Location = new System.Drawing.Point(165, 167);
            this.grpOther.Name = "grpOther";
            this.grpOther.Size = new System.Drawing.Size(150, 93);
            this.grpOther.TabIndex = 5;
            this.grpOther.TabStop = false;
            this.grpOther.Text = "Other";
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Location = new System.Drawing.Point(6, 66);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(87, 17);
            this.chkVisible.TabIndex = 2;
            this.chkVisible.Text = "Folder visible";
            this.chkVisible.UseVisualStyleBackColor = true;
            this.chkVisible.CheckedChanged += new System.EventHandler(this.FolderPermissionChanged);
            // 
            // chkContact
            // 
            this.chkContact.AutoSize = true;
            this.chkContact.Location = new System.Drawing.Point(6, 43);
            this.chkContact.Name = "chkContact";
            this.chkContact.Size = new System.Drawing.Size(94, 17);
            this.chkContact.TabIndex = 1;
            this.chkContact.Text = "Folder contact";
            this.chkContact.UseVisualStyleBackColor = true;
            this.chkContact.CheckedChanged += new System.EventHandler(this.FolderPermissionChanged);
            // 
            // chkOwner
            // 
            this.chkOwner.AutoSize = true;
            this.chkOwner.Location = new System.Drawing.Point(7, 20);
            this.chkOwner.Name = "chkOwner";
            this.chkOwner.Size = new System.Drawing.Size(89, 17);
            this.chkOwner.TabIndex = 0;
            this.chkOwner.Text = "Folder Owner";
            this.chkOwner.UseVisualStyleBackColor = true;
            this.chkOwner.CheckedChanged += new System.EventHandler(this.FolderPermissionChanged);
            // 
            // grpDelete
            // 
            this.grpDelete.Controls.Add(this.rdoDeleteAll);
            this.grpDelete.Controls.Add(this.rdoDeleteOwn);
            this.grpDelete.Controls.Add(this.rdoDeleteNone);
            this.grpDelete.Location = new System.Drawing.Point(10, 167);
            this.grpDelete.Name = "grpDelete";
            this.grpDelete.Size = new System.Drawing.Size(149, 92);
            this.grpDelete.TabIndex = 4;
            this.grpDelete.TabStop = false;
            this.grpDelete.Text = "Delete Items";
            // 
            // rdoDeleteAll
            // 
            this.rdoDeleteAll.AutoSize = true;
            this.rdoDeleteAll.Location = new System.Drawing.Point(7, 65);
            this.rdoDeleteAll.Name = "rdoDeleteAll";
            this.rdoDeleteAll.Size = new System.Drawing.Size(36, 17);
            this.rdoDeleteAll.TabIndex = 3;
            this.rdoDeleteAll.TabStop = true;
            this.rdoDeleteAll.Text = "All";
            this.rdoDeleteAll.UseVisualStyleBackColor = true;
            this.rdoDeleteAll.CheckedChanged += new System.EventHandler(this.FolderPermissionChanged);
            // 
            // rdoDeleteOwn
            // 
            this.rdoDeleteOwn.AutoSize = true;
            this.rdoDeleteOwn.Location = new System.Drawing.Point(7, 42);
            this.rdoDeleteOwn.Name = "rdoDeleteOwn";
            this.rdoDeleteOwn.Size = new System.Drawing.Size(47, 17);
            this.rdoDeleteOwn.TabIndex = 2;
            this.rdoDeleteOwn.TabStop = true;
            this.rdoDeleteOwn.Text = "Own";
            this.rdoDeleteOwn.UseVisualStyleBackColor = true;
            this.rdoDeleteOwn.CheckedChanged += new System.EventHandler(this.FolderPermissionChanged);
            // 
            // rdoDeleteNone
            // 
            this.rdoDeleteNone.AutoSize = true;
            this.rdoDeleteNone.Location = new System.Drawing.Point(7, 19);
            this.rdoDeleteNone.Name = "rdoDeleteNone";
            this.rdoDeleteNone.Size = new System.Drawing.Size(51, 17);
            this.rdoDeleteNone.TabIndex = 1;
            this.rdoDeleteNone.TabStop = true;
            this.rdoDeleteNone.Text = "None";
            this.rdoDeleteNone.UseVisualStyleBackColor = true;
            this.rdoDeleteNone.CheckedChanged += new System.EventHandler(this.FolderPermissionChanged);
            // 
            // grpWrite
            // 
            this.grpWrite.Controls.Add(this.chkEditAll);
            this.grpWrite.Controls.Add(this.chkEditOwn);
            this.grpWrite.Controls.Add(this.chkCreateSubFolders);
            this.grpWrite.Controls.Add(this.chkCreateItems);
            this.grpWrite.Location = new System.Drawing.Point(165, 47);
            this.grpWrite.Name = "grpWrite";
            this.grpWrite.Size = new System.Drawing.Size(150, 114);
            this.grpWrite.TabIndex = 3;
            this.grpWrite.TabStop = false;
            this.grpWrite.Text = "Write";
            // 
            // chkEditAll
            // 
            this.chkEditAll.AutoSize = true;
            this.chkEditAll.Location = new System.Drawing.Point(6, 88);
            this.chkEditAll.Name = "chkEditAll";
            this.chkEditAll.Size = new System.Drawing.Size(57, 17);
            this.chkEditAll.TabIndex = 4;
            this.chkEditAll.Text = "Edit all";
            this.chkEditAll.UseVisualStyleBackColor = true;
            this.chkEditAll.CheckedChanged += new System.EventHandler(this.FolderPermissionChanged);
            // 
            // chkEditOwn
            // 
            this.chkEditOwn.AutoSize = true;
            this.chkEditOwn.Location = new System.Drawing.Point(6, 65);
            this.chkEditOwn.Name = "chkEditOwn";
            this.chkEditOwn.Size = new System.Drawing.Size(67, 17);
            this.chkEditOwn.TabIndex = 3;
            this.chkEditOwn.Text = "Edit own";
            this.chkEditOwn.UseVisualStyleBackColor = true;
            this.chkEditOwn.CheckedChanged += new System.EventHandler(this.FolderPermissionChanged);
            // 
            // chkCreateSubFolders
            // 
            this.chkCreateSubFolders.AutoSize = true;
            this.chkCreateSubFolders.Location = new System.Drawing.Point(6, 42);
            this.chkCreateSubFolders.Name = "chkCreateSubFolders";
            this.chkCreateSubFolders.Size = new System.Drawing.Size(108, 17);
            this.chkCreateSubFolders.TabIndex = 2;
            this.chkCreateSubFolders.Text = "Create subfolders";
            this.chkCreateSubFolders.UseVisualStyleBackColor = true;
            this.chkCreateSubFolders.CheckedChanged += new System.EventHandler(this.FolderPermissionChanged);
            // 
            // chkCreateItems
            // 
            this.chkCreateItems.AutoSize = true;
            this.chkCreateItems.Location = new System.Drawing.Point(6, 19);
            this.chkCreateItems.Name = "chkCreateItems";
            this.chkCreateItems.Size = new System.Drawing.Size(85, 17);
            this.chkCreateItems.TabIndex = 1;
            this.chkCreateItems.Text = "Create Items";
            this.chkCreateItems.UseVisualStyleBackColor = true;
            // 
            // grpRead
            // 
            this.grpRead.Controls.Add(this.rdoTimeOnly);
            this.grpRead.Controls.Add(this.rdoTimeSubjectLocation);
            this.grpRead.Controls.Add(this.rdoReadFull);
            this.grpRead.Controls.Add(this.rdoReadNone);
            this.grpRead.Location = new System.Drawing.Point(10, 47);
            this.grpRead.Name = "grpRead";
            this.grpRead.Size = new System.Drawing.Size(149, 114);
            this.grpRead.TabIndex = 2;
            this.grpRead.TabStop = false;
            this.grpRead.Text = "Read";
            // 
            // rdoTimeOnly
            // 
            this.rdoTimeOnly.AutoSize = true;
            this.rdoTimeOnly.Location = new System.Drawing.Point(7, 87);
            this.rdoTimeOnly.Name = "rdoTimeOnly";
            this.rdoTimeOnly.Size = new System.Drawing.Size(72, 17);
            this.rdoTimeOnly.TabIndex = 3;
            this.rdoTimeOnly.TabStop = true;
            this.rdoTimeOnly.Text = "Time Only";
            this.rdoTimeOnly.UseVisualStyleBackColor = true;
            this.rdoTimeOnly.CheckedChanged += new System.EventHandler(this.FolderPermissionChanged);
            // 
            // rdoTimeSubjectLocation
            // 
            this.rdoTimeSubjectLocation.AutoSize = true;
            this.rdoTimeSubjectLocation.Location = new System.Drawing.Point(7, 64);
            this.rdoTimeSubjectLocation.Name = "rdoTimeSubjectLocation";
            this.rdoTimeSubjectLocation.Size = new System.Drawing.Size(137, 17);
            this.rdoTimeSubjectLocation.TabIndex = 2;
            this.rdoTimeSubjectLocation.TabStop = true;
            this.rdoTimeSubjectLocation.Text = "Time, Subject, Location";
            this.rdoTimeSubjectLocation.UseVisualStyleBackColor = true;
            this.rdoTimeSubjectLocation.CheckedChanged += new System.EventHandler(this.FolderPermissionChanged);
            // 
            // rdoReadFull
            // 
            this.rdoReadFull.AutoSize = true;
            this.rdoReadFull.Location = new System.Drawing.Point(7, 41);
            this.rdoReadFull.Name = "rdoReadFull";
            this.rdoReadFull.Size = new System.Drawing.Size(76, 17);
            this.rdoReadFull.TabIndex = 1;
            this.rdoReadFull.TabStop = true;
            this.rdoReadFull.Text = "Full Details";
            this.rdoReadFull.UseVisualStyleBackColor = true;
            this.rdoReadFull.CheckedChanged += new System.EventHandler(this.FolderPermissionChanged);
            // 
            // rdoReadNone
            // 
            this.rdoReadNone.AutoSize = true;
            this.rdoReadNone.Location = new System.Drawing.Point(7, 19);
            this.rdoReadNone.Name = "rdoReadNone";
            this.rdoReadNone.Size = new System.Drawing.Size(51, 17);
            this.rdoReadNone.TabIndex = 0;
            this.rdoReadNone.TabStop = true;
            this.rdoReadNone.Text = "None";
            this.rdoReadNone.UseVisualStyleBackColor = true;
            this.rdoReadNone.CheckedChanged += new System.EventHandler(this.FolderPermissionChanged);
            // 
            // TempPermissionLevelCombo
            // 
            this.TempPermissionLevelCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempPermissionLevelCombo.FormattingEnabled = true;
            this.TempPermissionLevelCombo.Location = new System.Drawing.Point(109, 20);
            this.TempPermissionLevelCombo.Name = "TempPermissionLevelCombo";
            this.TempPermissionLevelCombo.Size = new System.Drawing.Size(206, 21);
            this.TempPermissionLevelCombo.TabIndex = 1;
            this.TempPermissionLevelCombo.SelectedIndexChanged += new System.EventHandler(this.cboPermissionLevel_SelectedIndexChanged);
            // 
            // lblLevel
            // 
            this.lblLevel.Location = new System.Drawing.Point(7, 20);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(96, 23);
            this.lblLevel.TabIndex = 0;
            this.lblLevel.Text = "Permission Level:";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(259, 479);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(178, 478);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(252, 154);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(171, 154);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstUsers
            // 
            this.lstUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colPermLevel});
            this.lstUsers.FullRowSelect = true;
            this.lstUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstUsers.HideSelection = false;
            this.lstUsers.Location = new System.Drawing.Point(13, 13);
            this.lstUsers.MultiSelect = false;
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(321, 135);
            this.lstUsers.TabIndex = 6;
            this.lstUsers.UseCompatibleStateImageBehavior = false;
            this.lstUsers.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 182;
            // 
            // colPermLevel
            // 
            this.colPermLevel.Text = "Permission Level";
            this.colPermLevel.Width = 135;
            // 
            // PermissionsDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(351, 514);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpPermissions);
            this.Name = "PermissionsDialog";
            this.Text = "Permissions";
            this.Load += new System.EventHandler(this.PermissionsDialog_Load);
            this.grpPermissions.ResumeLayout(false);
            this.grpOther.ResumeLayout(false);
            this.grpOther.PerformLayout();
            this.grpDelete.ResumeLayout(false);
            this.grpDelete.PerformLayout();
            this.grpWrite.ResumeLayout(false);
            this.grpWrite.PerformLayout();
            this.grpRead.ResumeLayout(false);
            this.grpRead.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPermissions;
        private System.Windows.Forms.GroupBox grpOther;
        private System.Windows.Forms.CheckBox chkContact;
        private System.Windows.Forms.CheckBox chkOwner;
        private System.Windows.Forms.GroupBox grpDelete;
        private System.Windows.Forms.GroupBox grpWrite;
        private System.Windows.Forms.GroupBox grpRead;
        private System.Windows.Forms.ComboBox TempPermissionLevelCombo;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.RadioButton rdoDeleteAll;
        private System.Windows.Forms.RadioButton rdoDeleteOwn;
        private System.Windows.Forms.RadioButton rdoDeleteNone;
        private System.Windows.Forms.CheckBox chkEditAll;
        private System.Windows.Forms.CheckBox chkEditOwn;
        private System.Windows.Forms.CheckBox chkCreateSubFolders;
        private System.Windows.Forms.CheckBox chkCreateItems;
        private System.Windows.Forms.RadioButton rdoReadFull;
        private System.Windows.Forms.RadioButton rdoReadNone;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lstUsers;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPermLevel;
        private System.Windows.Forms.RadioButton rdoTimeOnly;
        private System.Windows.Forms.RadioButton rdoTimeSubjectLocation;
    }
}