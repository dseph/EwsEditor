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
            this.grpSynchronize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSynchronize
            // 
            this.grpSynchronize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.grpSynchronize.Location = new System.Drawing.Point(12, 12);
            this.grpSynchronize.Name = "grpSynchronize";
            this.grpSynchronize.Size = new System.Drawing.Size(723, 127);
            this.grpSynchronize.TabIndex = 7;
            this.grpSynchronize.TabStop = false;
            this.grpSynchronize.Text = "Notification Settings...";
            this.grpSynchronize.Enter += new System.EventHandler(this.grpSynchronize_Enter);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Timeout (minutes):";
            // 
            // numMinutes
            // 
            this.numMinutes.Location = new System.Drawing.Point(107, 98);
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
            this.numMinutes.Size = new System.Drawing.Size(66, 20);
            this.numMinutes.TabIndex = 13;
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
            this.chkAllFoldes.Location = new System.Drawing.Point(12, 19);
            this.chkAllFoldes.Name = "chkAllFoldes";
            this.chkAllFoldes.Size = new System.Drawing.Size(136, 17);
            this.chkAllFoldes.TabIndex = 1;
            this.chkAllFoldes.Text = "Subscribe to All Folders";
            this.chkAllFoldes.UseVisualStyleBackColor = true;
            this.chkAllFoldes.CheckedChanged += new System.EventHandler(this.chkAllFoldes_CheckedChanged);
            // 
            // btnGetFolderId
            // 
            this.btnGetFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetFolderId.Location = new System.Drawing.Point(687, 45);
            this.btnGetFolderId.Name = "btnGetFolderId";
            this.btnGetFolderId.Size = new System.Drawing.Size(25, 23);
            this.btnGetFolderId.TabIndex = 4;
            this.btnGetFolderId.Text = "...";
            this.btnGetFolderId.UseVisualStyleBackColor = true;
            this.btnGetFolderId.Click += new System.EventHandler(this.btnGetFolderId_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Events Types:";
            // 
            // chkNewMailEvent
            // 
            this.chkNewMailEvent.AutoSize = true;
            this.chkNewMailEvent.Checked = true;
            this.chkNewMailEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNewMailEvent.Location = new System.Drawing.Point(588, 71);
            this.chkNewMailEvent.Name = "chkNewMailEvent";
            this.chkNewMailEvent.Size = new System.Drawing.Size(95, 17);
            this.chkNewMailEvent.TabIndex = 11;
            this.chkNewMailEvent.Text = "NewMailEvent";
            this.chkNewMailEvent.UseVisualStyleBackColor = true;
            // 
            // chkMovedEvent
            // 
            this.chkMovedEvent.AutoSize = true;
            this.chkMovedEvent.Checked = true;
            this.chkMovedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMovedEvent.Location = new System.Drawing.Point(300, 75);
            this.chkMovedEvent.Name = "chkMovedEvent";
            this.chkMovedEvent.Size = new System.Drawing.Size(87, 17);
            this.chkMovedEvent.TabIndex = 8;
            this.chkMovedEvent.Text = "MovedEvent";
            this.chkMovedEvent.UseVisualStyleBackColor = true;
            // 
            // chkModifiedEvent
            // 
            this.chkModifiedEvent.AutoSize = true;
            this.chkModifiedEvent.Checked = true;
            this.chkModifiedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkModifiedEvent.Location = new System.Drawing.Point(490, 74);
            this.chkModifiedEvent.Name = "chkModifiedEvent";
            this.chkModifiedEvent.Size = new System.Drawing.Size(94, 17);
            this.chkModifiedEvent.TabIndex = 10;
            this.chkModifiedEvent.Text = "ModifiedEvent";
            this.chkModifiedEvent.UseVisualStyleBackColor = true;
            // 
            // chkDeletedEvent
            // 
            this.chkDeletedEvent.AutoSize = true;
            this.chkDeletedEvent.Checked = true;
            this.chkDeletedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeletedEvent.Location = new System.Drawing.Point(203, 75);
            this.chkDeletedEvent.Name = "chkDeletedEvent";
            this.chkDeletedEvent.Size = new System.Drawing.Size(91, 17);
            this.chkDeletedEvent.TabIndex = 7;
            this.chkDeletedEvent.Text = "DeletedEvent";
            this.chkDeletedEvent.UseVisualStyleBackColor = true;
            // 
            // chkCreatedEvent
            // 
            this.chkCreatedEvent.AutoSize = true;
            this.chkCreatedEvent.Checked = true;
            this.chkCreatedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreatedEvent.Location = new System.Drawing.Point(393, 74);
            this.chkCreatedEvent.Name = "chkCreatedEvent";
            this.chkCreatedEvent.Size = new System.Drawing.Size(91, 17);
            this.chkCreatedEvent.TabIndex = 9;
            this.chkCreatedEvent.Text = "CreatedEvent";
            this.chkCreatedEvent.UseVisualStyleBackColor = true;
            // 
            // chkCopiedEvent
            // 
            this.chkCopiedEvent.AutoSize = true;
            this.chkCopiedEvent.Checked = true;
            this.chkCopiedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopiedEvent.Location = new System.Drawing.Point(107, 75);
            this.chkCopiedEvent.Name = "chkCopiedEvent";
            this.chkCopiedEvent.Size = new System.Drawing.Size(87, 17);
            this.chkCopiedEvent.TabIndex = 6;
            this.chkCopiedEvent.Text = "CopiedEvent";
            this.chkCopiedEvent.UseVisualStyleBackColor = true;
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubscribe.Location = new System.Drawing.Point(556, 98);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(75, 23);
            this.btnSubscribe.TabIndex = 14;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // btnUnsubscribe
            // 
            this.btnUnsubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnsubscribe.Enabled = false;
            this.btnUnsubscribe.Location = new System.Drawing.Point(637, 98);
            this.btnUnsubscribe.Name = "btnUnsubscribe";
            this.btnUnsubscribe.Size = new System.Drawing.Size(75, 23);
            this.btnUnsubscribe.TabIndex = 15;
            this.btnUnsubscribe.Text = "Unsubscribe";
            this.btnUnsubscribe.UseVisualStyleBackColor = true;
            this.btnUnsubscribe.Click += new System.EventHandler(this.btnUnsubscribe_Click);
            // 
            // txtFolderId
            // 
            this.txtFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderId.Location = new System.Drawing.Point(107, 45);
            this.txtFolderId.Name = "txtFolderId";
            this.txtFolderId.ReadOnly = true;
            this.txtFolderId.Size = new System.Drawing.Size(576, 20);
            this.txtFolderId.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 23);
            this.label2.TabIndex = 2;
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
            this.lstEvents.GridLines = true;
            this.lstEvents.Location = new System.Drawing.Point(11, 182);
            this.lstEvents.MultiSelect = false;
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(723, 383);
            this.lstEvents.TabIndex = 16;
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
            this.btnClose.Location = new System.Drawing.Point(659, 571);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGetEvents
            // 
            this.btnGetEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetEvents.Enabled = false;
            this.btnGetEvents.Location = new System.Drawing.Point(580, 571);
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
            this.ClientSize = new System.Drawing.Size(749, 606);
            this.Controls.Add(this.btnGetEvents);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblEventsHeader);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.grpSynchronize);
            this.Name = "PullNotificationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
    }
}