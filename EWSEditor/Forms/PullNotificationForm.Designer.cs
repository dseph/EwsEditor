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
            this.colEventType = new System.Windows.Forms.ColumnHeader();
            this.colTimestamp = new System.Windows.Forms.ColumnHeader();
            this.colObjectType = new System.Windows.Forms.ColumnHeader();
            this.colObjectId = new System.Windows.Forms.ColumnHeader();
            this.colOldObjectId = new System.Windows.Forms.ColumnHeader();
            this.colParentFolderId = new System.Windows.Forms.ColumnHeader();
            this.colOldParentFolderId = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGetEvents = new System.Windows.Forms.Button();
            this.grpSynchronize.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSynchronize
            // 
            this.grpSynchronize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.grpSynchronize.Location = new System.Drawing.Point(12, 12);
            this.grpSynchronize.Name = "grpSynchronize";
            this.grpSynchronize.Size = new System.Drawing.Size(722, 127);
            this.grpSynchronize.TabIndex = 7;
            this.grpSynchronize.TabStop = false;
            this.grpSynchronize.Text = "Notification Settings...";
            // 
            // btnGetFolderId
            // 
            this.btnGetFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetFolderId.Location = new System.Drawing.Point(686, 24);
            this.btnGetFolderId.Name = "btnGetFolderId";
            this.btnGetFolderId.Size = new System.Drawing.Size(25, 23);
            this.btnGetFolderId.TabIndex = 23;
            this.btnGetFolderId.Text = "...";
            this.btnGetFolderId.UseVisualStyleBackColor = true;
            this.btnGetFolderId.Click += new System.EventHandler(this.btnGetFolderId_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "Events Types:";
            // 
            // chkNewMailEvent
            // 
            this.chkNewMailEvent.AutoSize = true;
            this.chkNewMailEvent.Checked = true;
            this.chkNewMailEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNewMailEvent.Location = new System.Drawing.Point(297, 74);
            this.chkNewMailEvent.Name = "chkNewMailEvent";
            this.chkNewMailEvent.Size = new System.Drawing.Size(95, 17);
            this.chkNewMailEvent.TabIndex = 21;
            this.chkNewMailEvent.Text = "NewMailEvent";
            this.chkNewMailEvent.UseVisualStyleBackColor = true;
            // 
            // chkMovedEvent
            // 
            this.chkMovedEvent.AutoSize = true;
            this.chkMovedEvent.Checked = true;
            this.chkMovedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMovedEvent.Location = new System.Drawing.Point(297, 51);
            this.chkMovedEvent.Name = "chkMovedEvent";
            this.chkMovedEvent.Size = new System.Drawing.Size(87, 17);
            this.chkMovedEvent.TabIndex = 20;
            this.chkMovedEvent.Text = "MovedEvent";
            this.chkMovedEvent.UseVisualStyleBackColor = true;
            // 
            // chkModifiedEvent
            // 
            this.chkModifiedEvent.AutoSize = true;
            this.chkModifiedEvent.Checked = true;
            this.chkModifiedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkModifiedEvent.Location = new System.Drawing.Point(201, 74);
            this.chkModifiedEvent.Name = "chkModifiedEvent";
            this.chkModifiedEvent.Size = new System.Drawing.Size(94, 17);
            this.chkModifiedEvent.TabIndex = 19;
            this.chkModifiedEvent.Text = "ModifiedEvent";
            this.chkModifiedEvent.UseVisualStyleBackColor = true;
            // 
            // chkDeletedEvent
            // 
            this.chkDeletedEvent.AutoSize = true;
            this.chkDeletedEvent.Checked = true;
            this.chkDeletedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeletedEvent.Location = new System.Drawing.Point(200, 51);
            this.chkDeletedEvent.Name = "chkDeletedEvent";
            this.chkDeletedEvent.Size = new System.Drawing.Size(91, 17);
            this.chkDeletedEvent.TabIndex = 18;
            this.chkDeletedEvent.Text = "DeletedEvent";
            this.chkDeletedEvent.UseVisualStyleBackColor = true;
            // 
            // chkCreatedEvent
            // 
            this.chkCreatedEvent.AutoSize = true;
            this.chkCreatedEvent.Checked = true;
            this.chkCreatedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreatedEvent.Location = new System.Drawing.Point(104, 74);
            this.chkCreatedEvent.Name = "chkCreatedEvent";
            this.chkCreatedEvent.Size = new System.Drawing.Size(91, 17);
            this.chkCreatedEvent.TabIndex = 17;
            this.chkCreatedEvent.Text = "CreatedEvent";
            this.chkCreatedEvent.UseVisualStyleBackColor = true;
            // 
            // chkCopiedEvent
            // 
            this.chkCopiedEvent.AutoSize = true;
            this.chkCopiedEvent.Checked = true;
            this.chkCopiedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopiedEvent.Location = new System.Drawing.Point(104, 51);
            this.chkCopiedEvent.Name = "chkCopiedEvent";
            this.chkCopiedEvent.Size = new System.Drawing.Size(87, 17);
            this.chkCopiedEvent.TabIndex = 16;
            this.chkCopiedEvent.Text = "CopiedEvent";
            this.chkCopiedEvent.UseVisualStyleBackColor = true;
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubscribe.Location = new System.Drawing.Point(555, 98);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(75, 23);
            this.btnSubscribe.TabIndex = 15;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // btnUnsubscribe
            // 
            this.btnUnsubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnsubscribe.Enabled = false;
            this.btnUnsubscribe.Location = new System.Drawing.Point(636, 98);
            this.btnUnsubscribe.Name = "btnUnsubscribe";
            this.btnUnsubscribe.Size = new System.Drawing.Size(75, 23);
            this.btnUnsubscribe.TabIndex = 14;
            this.btnUnsubscribe.Text = "Unsubscribe";
            this.btnUnsubscribe.UseVisualStyleBackColor = true;
            this.btnUnsubscribe.Click += new System.EventHandler(this.btnUnsubscribe_Click);
            // 
            // txtFolderId
            // 
            this.txtFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderId.Location = new System.Drawing.Point(104, 24);
            this.txtFolderId.Name = "txtFolderId";
            this.txtFolderId.ReadOnly = true;
            this.txtFolderId.Size = new System.Drawing.Size(575, 20);
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
            // lblEventsHeader
            // 
            this.lblEventsHeader.Location = new System.Drawing.Point(18, 141);
            this.lblEventsHeader.Name = "lblEventsHeader";
            this.lblEventsHeader.Size = new System.Drawing.Size(716, 23);
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
            this.lstEvents.Location = new System.Drawing.Point(12, 167);
            this.lstEvents.MultiSelect = false;
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(722, 383);
            this.lstEvents.TabIndex = 14;
            this.lstEvents.UseCompatibleStateImageBehavior = false;
            this.lstEvents.View = System.Windows.Forms.View.Details;
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
            this.btnClose.Location = new System.Drawing.Point(659, 558);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGetEvents
            // 
            this.btnGetEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetEvents.Enabled = false;
            this.btnGetEvents.Location = new System.Drawing.Point(580, 558);
            this.btnGetEvents.Name = "btnGetEvents";
            this.btnGetEvents.Size = new System.Drawing.Size(75, 23);
            this.btnGetEvents.TabIndex = 17;
            this.btnGetEvents.Text = "Get Events";
            this.btnGetEvents.UseVisualStyleBackColor = true;
            this.btnGetEvents.Click += new System.EventHandler(this.btnGetEvents_Click);
            // 
            // PullNotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 606);
            this.Controls.Add(this.btnGetEvents);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblEventsHeader);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.grpSynchronize);
            this.Name = "PullNotificationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grpSynchronize.ResumeLayout(false);
            this.grpSynchronize.PerformLayout();
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
    }
}