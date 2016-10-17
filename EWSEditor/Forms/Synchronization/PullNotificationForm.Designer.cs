namespace EWSEditor.Forms
{
    partial class PullNotificationForm
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
            this.grpSynchronize = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numMinutes = new System.Windows.Forms.NumericUpDown();
            this.chkAllFoldes = new System.Windows.Forms.CheckBox();
            this.btnGetFolderId = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkNewMailEvent = new System.Windows.Forms.CheckBox();
            this.chkMovedEvent = new System.Windows.Forms.CheckBox();
            this.chkModifiedEvent = new System.Windows.Forms.CheckBox();
            this.chkDeletedEvent = new System.Windows.Forms.CheckBox();
            this.chkCreatedEvent = new System.Windows.Forms.CheckBox();
            this.chkCopiedEvent = new System.Windows.Forms.CheckBox();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.btnUnsubscribe = new System.Windows.Forms.Button();
            this.txtFolderId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEventsHeader = new System.Windows.Forms.Label();
            this.lstEvents = new System.Windows.Forms.ListView();
            this.colEventType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colObjectType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colObjectId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOldObjectId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colParentFolderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOldParentFolderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGetEvents = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.grpSynchronize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSynchronize
            // 
            this.grpSynchronize.Controls.Add(this.label3);
            this.grpSynchronize.Controls.Add(this.numMinutes);
            this.grpSynchronize.Controls.Add(this.chkAllFoldes);
            this.grpSynchronize.Controls.Add(this.btnGetFolderId);
            this.grpSynchronize.Controls.Add(this.label1);
            this.grpSynchronize.Controls.Add(this.chkNewMailEvent);
            this.grpSynchronize.Controls.Add(this.chkMovedEvent);
            this.grpSynchronize.Controls.Add(this.chkModifiedEvent);
            this.grpSynchronize.Controls.Add(this.chkDeletedEvent);
            this.grpSynchronize.Controls.Add(this.chkCreatedEvent);
            this.grpSynchronize.Controls.Add(this.chkCopiedEvent);
            this.grpSynchronize.Controls.Add(this.btnSubscribe);
            this.grpSynchronize.Controls.Add(this.btnUnsubscribe);
            this.grpSynchronize.Controls.Add(this.txtFolderId);
            this.grpSynchronize.Controls.Add(this.label2);
            this.grpSynchronize.Location = new System.Drawing.Point(8, 13);
            this.grpSynchronize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpSynchronize.Name = "grpSynchronize";
            this.grpSynchronize.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpSynchronize.Size = new System.Drawing.Size(884, 156);
            this.grpSynchronize.TabIndex = 0;
            this.grpSynchronize.TabStop = false;
            this.grpSynchronize.Text = "Notification Settings...";
            this.grpSynchronize.Enter += new System.EventHandler(this.grpSynchronize_Enter);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 28);
            this.label3.TabIndex = 11;
            this.label3.Text = "Timeout (minutes):";
            // 
            // numMinutes
            // 
            this.numMinutes.Location = new System.Drawing.Point(143, 121);
            this.numMinutes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numMinutes.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinutes.Name = "numMinutes";
            this.numMinutes.Size = new System.Drawing.Size(88, 22);
            this.numMinutes.TabIndex = 12;
            this.numMinutes.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chkAllFoldes
            // 
            this.chkAllFoldes.AutoSize = true;
            this.chkAllFoldes.Checked = true;
            this.chkAllFoldes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllFoldes.Location = new System.Drawing.Point(16, 23);
            this.chkAllFoldes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkAllFoldes.Name = "chkAllFoldes";
            this.chkAllFoldes.Size = new System.Drawing.Size(179, 21);
            this.chkAllFoldes.TabIndex = 0;
            this.chkAllFoldes.Text = "Subscribe to All Folders";
            this.chkAllFoldes.UseVisualStyleBackColor = true;
            this.chkAllFoldes.CheckedChanged += new System.EventHandler(this.chkAllFoldes_CheckedChanged);
            // 
            // btnGetFolderId
            // 
            this.btnGetFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetFolderId.Location = new System.Drawing.Point(836, 55);
            this.btnGetFolderId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetFolderId.Name = "btnGetFolderId";
            this.btnGetFolderId.Size = new System.Drawing.Size(33, 28);
            this.btnGetFolderId.TabIndex = 3;
            this.btnGetFolderId.Text = "...";
            this.btnGetFolderId.UseVisualStyleBackColor = true;
            this.btnGetFolderId.Click += new System.EventHandler(this.btnGetFolderId_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Events Types:";
            // 
            // chkNewMailEvent
            // 
            this.chkNewMailEvent.AutoSize = true;
            this.chkNewMailEvent.Checked = true;
            this.chkNewMailEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNewMailEvent.Location = new System.Drawing.Point(751, 91);
            this.chkNewMailEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkNewMailEvent.Name = "chkNewMailEvent";
            this.chkNewMailEvent.Size = new System.Drawing.Size(118, 21);
            this.chkNewMailEvent.TabIndex = 10;
            this.chkNewMailEvent.Text = "NewMailEvent";
            this.chkNewMailEvent.UseVisualStyleBackColor = true;
            // 
            // chkMovedEvent
            // 
            this.chkMovedEvent.AutoSize = true;
            this.chkMovedEvent.Checked = true;
            this.chkMovedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMovedEvent.Location = new System.Drawing.Point(384, 91);
            this.chkMovedEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkMovedEvent.Name = "chkMovedEvent";
            this.chkMovedEvent.Size = new System.Drawing.Size(108, 21);
            this.chkMovedEvent.TabIndex = 7;
            this.chkMovedEvent.Text = "MovedEvent";
            this.chkMovedEvent.UseVisualStyleBackColor = true;
            // 
            // chkModifiedEvent
            // 
            this.chkModifiedEvent.AutoSize = true;
            this.chkModifiedEvent.Checked = true;
            this.chkModifiedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkModifiedEvent.Location = new System.Drawing.Point(624, 91);
            this.chkModifiedEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkModifiedEvent.Name = "chkModifiedEvent";
            this.chkModifiedEvent.Size = new System.Drawing.Size(119, 21);
            this.chkModifiedEvent.TabIndex = 9;
            this.chkModifiedEvent.Text = "ModifiedEvent";
            this.chkModifiedEvent.UseVisualStyleBackColor = true;
            // 
            // chkDeletedEvent
            // 
            this.chkDeletedEvent.AutoSize = true;
            this.chkDeletedEvent.Checked = true;
            this.chkDeletedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeletedEvent.Location = new System.Drawing.Point(261, 91);
            this.chkDeletedEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDeletedEvent.Name = "chkDeletedEvent";
            this.chkDeletedEvent.Size = new System.Drawing.Size(115, 21);
            this.chkDeletedEvent.TabIndex = 6;
            this.chkDeletedEvent.Text = "DeletedEvent";
            this.chkDeletedEvent.UseVisualStyleBackColor = true;
            // 
            // chkCreatedEvent
            // 
            this.chkCreatedEvent.AutoSize = true;
            this.chkCreatedEvent.Checked = true;
            this.chkCreatedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreatedEvent.Location = new System.Drawing.Point(500, 91);
            this.chkCreatedEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCreatedEvent.Name = "chkCreatedEvent";
            this.chkCreatedEvent.Size = new System.Drawing.Size(116, 21);
            this.chkCreatedEvent.TabIndex = 8;
            this.chkCreatedEvent.Text = "CreatedEvent";
            this.chkCreatedEvent.UseVisualStyleBackColor = true;
            // 
            // chkCopiedEvent
            // 
            this.chkCopiedEvent.AutoSize = true;
            this.chkCopiedEvent.Checked = true;
            this.chkCopiedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopiedEvent.Location = new System.Drawing.Point(143, 92);
            this.chkCopiedEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCopiedEvent.Name = "chkCopiedEvent";
            this.chkCopiedEvent.Size = new System.Drawing.Size(110, 21);
            this.chkCopiedEvent.TabIndex = 5;
            this.chkCopiedEvent.Text = "CopiedEvent";
            this.chkCopiedEvent.UseVisualStyleBackColor = true;
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubscribe.Location = new System.Drawing.Point(660, 121);
            this.btnSubscribe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(100, 28);
            this.btnSubscribe.TabIndex = 13;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // btnUnsubscribe
            // 
            this.btnUnsubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnsubscribe.Enabled = false;
            this.btnUnsubscribe.Location = new System.Drawing.Point(769, 121);
            this.btnUnsubscribe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUnsubscribe.Name = "btnUnsubscribe";
            this.btnUnsubscribe.Size = new System.Drawing.Size(100, 28);
            this.btnUnsubscribe.TabIndex = 14;
            this.btnUnsubscribe.Text = "Unsubscribe";
            this.btnUnsubscribe.UseVisualStyleBackColor = true;
            this.btnUnsubscribe.Click += new System.EventHandler(this.btnUnsubscribe_Click);
            // 
            // txtFolderId
            // 
            this.txtFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderId.Location = new System.Drawing.Point(143, 55);
            this.txtFolderId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFolderId.Name = "txtFolderId";
            this.txtFolderId.ReadOnly = true;
            this.txtFolderId.Size = new System.Drawing.Size(687, 22);
            this.txtFolderId.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Folder Id:";
            // 
            // lblEventsHeader
            // 
            this.lblEventsHeader.Location = new System.Drawing.Point(16, 174);
            this.lblEventsHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEventsHeader.Name = "lblEventsHeader";
            this.lblEventsHeader.Size = new System.Drawing.Size(874, 28);
            this.lblEventsHeader.TabIndex = 15;
            this.lblEventsHeader.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lstEvents
            // 
            this.lstEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEventType,
            this.colTimestamp,
            this.colObjectType,
            this.colObjectId,
            this.colOldObjectId,
            this.colParentFolderId,
            this.colOldParentFolderId});
            this.lstEvents.FullRowSelect = true;
            this.lstEvents.GridLines = true;
            this.lstEvents.Location = new System.Drawing.Point(8, 216);
            this.lstEvents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstEvents.MultiSelect = false;
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(881, 178);
            this.lstEvents.TabIndex = 3;
            this.lstEvents.UseCompatibleStateImageBehavior = false;
            this.lstEvents.View = System.Windows.Forms.View.Details;
            this.lstEvents.SelectedIndexChanged += new System.EventHandler(this.lstEvents_SelectedIndexChanged);
            this.lstEvents.DoubleClick += new System.EventHandler(this.lstEvents_DoubleClick);
            // 
            // colEventType
            // 
            this.colEventType.Text = "EventType";
            this.colEventType.Width = 100;
            // 
            // colTimestamp
            // 
            this.colTimestamp.Text = "Timestamp";
            this.colTimestamp.Width = 100;
            // 
            // colObjectType
            // 
            this.colObjectType.Text = "ObjectType";
            this.colObjectType.Width = 100;
            // 
            // colObjectId
            // 
            this.colObjectId.Text = "ObjectId";
            this.colObjectId.Width = 100;
            // 
            // colOldObjectId
            // 
            this.colOldObjectId.Text = "OldObjectId";
            this.colOldObjectId.Width = 100;
            // 
            // colParentFolderId
            // 
            this.colParentFolderId.Text = "ParentFolderId";
            this.colParentFolderId.Width = 100;
            // 
            // colOldParentFolderId
            // 
            this.colOldParentFolderId.Text = "OldParentFolderId";
            this.colOldParentFolderId.Width = 100;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(782, 411);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGetEvents
            // 
            this.btnGetEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetEvents.Enabled = false;
            this.btnGetEvents.Location = new System.Drawing.Point(676, 411);
            this.btnGetEvents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetEvents.Name = "btnGetEvents";
            this.btnGetEvents.Size = new System.Drawing.Size(100, 28);
            this.btnGetEvents.TabIndex = 1;
            this.btnGetEvents.Text = "Get Events";
            this.btnGetEvents.UseVisualStyleBackColor = true;
            this.btnGetEvents.Click += new System.EventHandler(this.btnGetEvents_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(5, 417);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(521, 28);
            this.label4.TabIndex = 16;
            this.label4.Text = "Note:  Subscriptions are not supported for delegate user access.";
            // 
            // PullNotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 454);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGetEvents);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblEventsHeader);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.grpSynchronize);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "PullNotificationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pull Notifications";
            this.Load += new System.EventHandler(this.PullNotificationForm_Load);
            this.grpSynchronize.ResumeLayout(false);
            this.grpSynchronize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSynchronize;
        private System.Windows.Forms.TextBox txtFolderId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEventsHeader;
        private System.Windows.Forms.ListView lstEvents;
        private System.Windows.Forms.ColumnHeader colEventType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubscribe;
        private System.Windows.Forms.Button btnUnsubscribe;
        private System.Windows.Forms.CheckBox chkCopiedEvent;
        private System.Windows.Forms.Button btnGetEvents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkNewMailEvent;
        private System.Windows.Forms.CheckBox chkMovedEvent;
        private System.Windows.Forms.CheckBox chkModifiedEvent;
        private System.Windows.Forms.CheckBox chkDeletedEvent;
        private System.Windows.Forms.CheckBox chkCreatedEvent;
        private System.Windows.Forms.Button btnGetFolderId;
        private System.Windows.Forms.ColumnHeader colTimestamp;
        private System.Windows.Forms.ColumnHeader colObjectType;
        private System.Windows.Forms.ColumnHeader colObjectId;
        private System.Windows.Forms.ColumnHeader colOldObjectId;
        private System.Windows.Forms.ColumnHeader colParentFolderId;
        private System.Windows.Forms.ColumnHeader colOldParentFolderId;
        private System.Windows.Forms.CheckBox chkAllFoldes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numMinutes;
        private System.Windows.Forms.Label label4;
    }
}