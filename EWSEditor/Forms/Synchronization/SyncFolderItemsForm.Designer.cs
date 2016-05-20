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
            this.colSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colItemClass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastModifiedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpSynchronize = new System.Windows.Forms.GroupBox();
            this.btnGetFolderId = new System.Windows.Forms.Button();
            this.txtSyncState = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPropSet = new System.Windows.Forms.Button();
            this.txtFolderId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSynchronize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblLastSyncTime = new System.Windows.Forms.Label();
            this.btnTestGetAllChanges = new System.Windows.Forms.Button();
            this.btnPropertiesForAllSeperateCalls = new System.Windows.Forms.Button();
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
            this.colItemId,
            this.colSubject,
            this.colItemClass,
            this.colLastModifiedDate});
            this.lstChanges.FullRowSelect = true;
            this.lstChanges.Location = new System.Drawing.Point(13, 244);
            this.lstChanges.Margin = new System.Windows.Forms.Padding(4);
            this.lstChanges.MultiSelect = false;
            this.lstChanges.Name = "lstChanges";
            this.lstChanges.Size = new System.Drawing.Size(990, 233);
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
            // colSubject
            // 
            this.colSubject.Text = "Subject";
            this.colSubject.Width = 200;
            // 
            // colItemClass
            // 
            this.colItemClass.Text = "ItemClass";
            this.colItemClass.Width = 100;
            // 
            // colLastModifiedDate
            // 
            this.colLastModifiedDate.Text = "LastModifiedDate";
            this.colLastModifiedDate.Width = 120;
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
            this.grpSynchronize.Controls.Add(this.btnSynchronize);
            this.grpSynchronize.Controls.Add(this.label1);
            this.grpSynchronize.Location = new System.Drawing.Point(16, 15);
            this.grpSynchronize.Margin = new System.Windows.Forms.Padding(4);
            this.grpSynchronize.Name = "grpSynchronize";
            this.grpSynchronize.Padding = new System.Windows.Forms.Padding(4);
            this.grpSynchronize.Size = new System.Drawing.Size(987, 194);
            this.grpSynchronize.TabIndex = 0;
            this.grpSynchronize.TabStop = false;
            this.grpSynchronize.Text = "SyncFolderItems Settings...";
            this.grpSynchronize.Enter += new System.EventHandler(this.grpSynchronize_Enter);
            // 
            // btnGetFolderId
            // 
            this.btnGetFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetFolderId.Location = new System.Drawing.Point(946, 27);
            this.btnGetFolderId.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetFolderId.Name = "btnGetFolderId";
            this.btnGetFolderId.Size = new System.Drawing.Size(33, 28);
            this.btnGetFolderId.TabIndex = 2;
            this.btnGetFolderId.Text = "...";
            this.btnGetFolderId.UseVisualStyleBackColor = true;
            this.btnGetFolderId.Click += new System.EventHandler(this.btnGetFolderId_Click);
            // 
            // txtSyncState
            // 
            this.txtSyncState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSyncState.Location = new System.Drawing.Point(139, 68);
            this.txtSyncState.Margin = new System.Windows.Forms.Padding(4);
            this.txtSyncState.Multiline = true;
            this.txtSyncState.Name = "txtSyncState";
            this.txtSyncState.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSyncState.Size = new System.Drawing.Size(839, 83);
            this.txtSyncState.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Property Set:";
            // 
            // btnPropSet
            // 
            this.btnPropSet.Location = new System.Drawing.Point(140, 159);
            this.btnPropSet.Margin = new System.Windows.Forms.Padding(4);
            this.btnPropSet.Name = "btnPropSet";
            this.btnPropSet.Size = new System.Drawing.Size(128, 28);
            this.btnPropSet.TabIndex = 6;
            this.btnPropSet.Text = "Configure...";
            this.btnPropSet.UseVisualStyleBackColor = true;
            this.btnPropSet.Click += new System.EventHandler(this.btnPropSet_Click);
            // 
            // txtFolderId
            // 
            this.txtFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderId.Location = new System.Drawing.Point(139, 30);
            this.txtFolderId.Margin = new System.Windows.Forms.Padding(4);
            this.txtFolderId.Name = "txtFolderId";
            this.txtFolderId.ReadOnly = true;
            this.txtFolderId.Size = new System.Drawing.Size(798, 22);
            this.txtFolderId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Folder Id:";
            // 
            // btnSynchronize
            // 
            this.btnSynchronize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSynchronize.Location = new System.Drawing.Point(879, 159);
            this.btnSynchronize.Margin = new System.Windows.Forms.Padding(4);
            this.btnSynchronize.Name = "btnSynchronize";
            this.btnSynchronize.Size = new System.Drawing.Size(100, 28);
            this.btnSynchronize.TabIndex = 7;
            this.btnSynchronize.Text = "Sync";
            this.btnSynchronize.UseVisualStyleBackColor = true;
            this.btnSynchronize.Click += new System.EventHandler(this.btnSynchronize_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sync State:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 213);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 28);
            this.label4.TabIndex = 1;
            this.label4.Text = "Changes Returned...";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(903, 522);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLastSyncTime
            // 
            this.lblLastSyncTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLastSyncTime.Location = new System.Drawing.Point(24, 517);
            this.lblLastSyncTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastSyncTime.Name = "lblLastSyncTime";
            this.lblLastSyncTime.Size = new System.Drawing.Size(413, 28);
            this.lblLastSyncTime.TabIndex = 15;
            this.lblLastSyncTime.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblLastSyncTime.Click += new System.EventHandler(this.lblLastSyncTime_Click);
            // 
            // btnTestGetAllChanges
            // 
            this.btnTestGetAllChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTestGetAllChanges.Location = new System.Drawing.Point(16, 485);
            this.btnTestGetAllChanges.Margin = new System.Windows.Forms.Padding(4);
            this.btnTestGetAllChanges.Name = "btnTestGetAllChanges";
            this.btnTestGetAllChanges.Size = new System.Drawing.Size(461, 28);
            this.btnTestGetAllChanges.TabIndex = 3;
            this.btnTestGetAllChanges.Text = "Show Properties of All Items - one LoadPropertiesForItems call";
            this.btnTestGetAllChanges.UseVisualStyleBackColor = true;
            this.btnTestGetAllChanges.Click += new System.EventHandler(this.btnTestGetAllChanges_Click);
            // 
            // btnPropertiesForAllSeperateCalls
            // 
            this.btnPropertiesForAllSeperateCalls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPropertiesForAllSeperateCalls.Location = new System.Drawing.Point(495, 486);
            this.btnPropertiesForAllSeperateCalls.Margin = new System.Windows.Forms.Padding(4);
            this.btnPropertiesForAllSeperateCalls.Name = "btnPropertiesForAllSeperateCalls";
            this.btnPropertiesForAllSeperateCalls.Size = new System.Drawing.Size(461, 28);
            this.btnPropertiesForAllSeperateCalls.TabIndex = 4;
            this.btnPropertiesForAllSeperateCalls.Text = "Show Properties of All Items - seperate LoadPropertiesForItems calls";
            this.btnPropertiesForAllSeperateCalls.UseVisualStyleBackColor = true;
            this.btnPropertiesForAllSeperateCalls.Click += new System.EventHandler(this.btnPropertiesForAllSeperateCalls_Click);
            // 
            // SyncFolderItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1010, 556);
            this.Controls.Add(this.btnPropertiesForAllSeperateCalls);
            this.Controls.Add(this.btnTestGetAllChanges);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grpSynchronize);
            this.Controls.Add(this.lblLastSyncTime);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstChanges);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "SyncFolderItemsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item Synchronization";
            this.Load += new System.EventHandler(this.SyncFolderItemsForm_Load);
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
        private System.Windows.Forms.Button btnPropertiesForAllSeperateCalls;
        private System.Windows.Forms.ColumnHeader colSubject;
        private System.Windows.Forms.ColumnHeader colItemClass;
        private System.Windows.Forms.ColumnHeader colLastModifiedDate;
    }
}
