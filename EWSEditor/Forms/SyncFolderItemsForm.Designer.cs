namespace EWSEditor
{
    partial class SyncFolderItemsForm
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
            this.lstChanges = new System.Windows.Forms.ListView();
            this.colChangeType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsRead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colItemId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpSynchronize = new System.Windows.Forms.GroupBox();
            this.btnGetFolderId = new System.Windows.Forms.Button();
            this.txtSyncState = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPropSet = new System.Windows.Forms.Button();
            this.txtFolderId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSynchronize = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblLastSyncTime = new System.Windows.Forms.Label();
            this.btnTestGetAllChanges = new System.Windows.Forms.Button();
            this.grpSynchronize.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstChanges
            // 
            this.lstChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstChanges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colChangeType,
            this.colIsRead,
            this.colItemId});
            this.lstChanges.FullRowSelect = true;
            this.lstChanges.Location = new System.Drawing.Point(16, 157);
            this.lstChanges.MultiSelect = false;
            this.lstChanges.Name = "lstChanges";
            this.lstChanges.Size = new System.Drawing.Size(596, 411);
            this.lstChanges.TabIndex = 2;
            this.lstChanges.UseCompatibleStateImageBehavior = false;
            this.lstChanges.View = System.Windows.Forms.View.Details;
            this.lstChanges.SelectedIndexChanged += new System.EventHandler(this.lstChanges_SelectedIndexChanged);
            this.lstChanges.DoubleClick += new System.EventHandler(this.lstChanges_DoubleClick);
            // 
            // colChangeType
            // 
            this.colChangeType.Text = "ChangeType";
            this.colChangeType.Width = 100;
            // 
            // colIsRead
            // 
            this.colIsRead.Text = "IsRead";
            // 
            // colItemId
            // 
            this.colItemId.Text = "ItemId";
            this.colItemId.Width = 400;
            // 
            // grpSynchronize
            // 
            this.grpSynchronize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSynchronize.Controls.Add(this.btnGetFolderId);
            this.grpSynchronize.Controls.Add(this.txtSyncState);
            this.grpSynchronize.Controls.Add(this.label3);
            this.grpSynchronize.Controls.Add(this.btnPropSet);
            this.grpSynchronize.Controls.Add(this.txtFolderId);
            this.grpSynchronize.Controls.Add(this.label2);
            this.grpSynchronize.Controls.Add(this.label1);
            this.grpSynchronize.Location = new System.Drawing.Point(12, 12);
            this.grpSynchronize.Name = "grpSynchronize";
            this.grpSynchronize.Size = new System.Drawing.Size(604, 116);
            this.grpSynchronize.TabIndex = 6;
            this.grpSynchronize.TabStop = false;
            this.grpSynchronize.Text = "SyncFolderItems Settings...";
            // 
            // btnGetFolderId
            // 
            this.btnGetFolderId.Location = new System.Drawing.Point(561, 24);
            this.btnGetFolderId.Name = "btnGetFolderId";
            this.btnGetFolderId.Size = new System.Drawing.Size(25, 23);
            this.btnGetFolderId.TabIndex = 24;
            this.btnGetFolderId.Text = "...";
            this.btnGetFolderId.UseVisualStyleBackColor = true;
            this.btnGetFolderId.Click += new System.EventHandler(this.btnGetFolderId_Click);
            // 
            // txtSyncState
            // 
            this.txtSyncState.Location = new System.Drawing.Point(104, 55);
            this.txtSyncState.Multiline = true;
            this.txtSyncState.Name = "txtSyncState";
            this.txtSyncState.Size = new System.Drawing.Size(477, 21);
            this.txtSyncState.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Property Set:";
            // 
            // btnPropSet
            // 
            this.btnPropSet.Location = new System.Drawing.Point(104, 82);
            this.btnPropSet.Name = "btnPropSet";
            this.btnPropSet.Size = new System.Drawing.Size(96, 23);
            this.btnPropSet.TabIndex = 11;
            this.btnPropSet.Text = "Configure...";
            this.btnPropSet.UseVisualStyleBackColor = true;
            this.btnPropSet.Click += new System.EventHandler(this.btnPropSet_Click);
            // 
            // txtFolderId
            // 
            this.txtFolderId.Location = new System.Drawing.Point(104, 24);
            this.txtFolderId.Name = "txtFolderId";
            this.txtFolderId.ReadOnly = true;
            this.txtFolderId.Size = new System.Drawing.Size(452, 20);
            this.txtFolderId.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Folder Id:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sync State:";
            // 
            // btnSynchronize
            // 
            this.btnSynchronize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSynchronize.Location = new System.Drawing.Point(355, 574);
            this.btnSynchronize.Name = "btnSynchronize";
            this.btnSynchronize.Size = new System.Drawing.Size(75, 23);
            this.btnSynchronize.TabIndex = 10;
            this.btnSynchronize.Text = "Sync";
            this.btnSynchronize.UseVisualStyleBackColor = true;
            this.btnSynchronize.Click += new System.EventHandler(this.btnSynchronize_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(18, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Changes Returned...";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(537, 574);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLastSyncTime
            // 
            this.lblLastSyncTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLastSyncTime.Location = new System.Drawing.Point(18, 574);
            this.lblLastSyncTime.Name = "lblLastSyncTime";
            this.lblLastSyncTime.Size = new System.Drawing.Size(331, 23);
            this.lblLastSyncTime.TabIndex = 15;
            this.lblLastSyncTime.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnTestGetAllChanges
            // 
            this.btnTestGetAllChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestGetAllChanges.Location = new System.Drawing.Point(447, 574);
            this.btnTestGetAllChanges.Name = "btnTestGetAllChanges";
            this.btnTestGetAllChanges.Size = new System.Drawing.Size(75, 23);
            this.btnTestGetAllChanges.TabIndex = 16;
            this.btnTestGetAllChanges.Text = "Show All Changed";
            this.btnTestGetAllChanges.UseVisualStyleBackColor = true;
            this.btnTestGetAllChanges.Click += new System.EventHandler(this.btnTestGetAllChanges_Click);
            // 
            // SyncFolderItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(628, 622);
            this.Controls.Add(this.btnTestGetAllChanges);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grpSynchronize);
            this.Controls.Add(this.lblLastSyncTime);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstChanges);
            this.Controls.Add(this.btnSynchronize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SyncFolderItemsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.grpSynchronize.ResumeLayout(false);
            this.grpSynchronize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstChanges;
        private System.Windows.Forms.GroupBox grpSynchronize;
        private System.Windows.Forms.Button btnSynchronize;
        private System.Windows.Forms.TextBox txtFolderId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPropSet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSyncState;
        private System.Windows.Forms.ColumnHeader colChangeType;
        private System.Windows.Forms.ColumnHeader colIsRead;
        private System.Windows.Forms.ColumnHeader colItemId;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGetFolderId;
        private System.Windows.Forms.Label lblLastSyncTime;
        private System.Windows.Forms.Button btnTestGetAllChanges;
    }
}
