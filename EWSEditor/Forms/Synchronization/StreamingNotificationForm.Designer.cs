namespace EWSEditor.Forms
{
    partial class StreamingNotificationForm
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
            this.chkAllFoldes = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numSubs = new System.Windows.Forms.NumericUpDown();
            this.numThreads = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.SubscriptionLifetime = new System.Windows.Forms.NumericUpDown();
            this.btnGetFolderId = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSerialize = new System.Windows.Forms.CheckBox();
            this.chkFreeBusyChangedEvent = new System.Windows.Forms.CheckBox();
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
            this.colEventClass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEventType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colParentFolderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOldParentFolderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colObjectId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOldObjectId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFolderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOldFolderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnreadCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ConnectionCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.EventCount = new System.Windows.Forms.Label();
            this.btnClearEvents = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.SubscriptionCount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ThreadCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.grpSynchronize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSubs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubscriptionLifetime)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSynchronize
            // 
            this.grpSynchronize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSynchronize.Controls.Add(this.chkAllFoldes);
            this.grpSynchronize.Controls.Add(this.label5);
            this.grpSynchronize.Controls.Add(this.label4);
            this.grpSynchronize.Controls.Add(this.numSubs);
            this.grpSynchronize.Controls.Add(this.numThreads);
            this.grpSynchronize.Controls.Add(this.label3);
            this.grpSynchronize.Controls.Add(this.SubscriptionLifetime);
            this.grpSynchronize.Controls.Add(this.btnGetFolderId);
            this.grpSynchronize.Controls.Add(this.label1);
            this.grpSynchronize.Controls.Add(this.chkSerialize);
            this.grpSynchronize.Controls.Add(this.chkFreeBusyChangedEvent);
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
            this.grpSynchronize.Location = new System.Drawing.Point(5, 6);
            this.grpSynchronize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpSynchronize.Name = "grpSynchronize";
            this.grpSynchronize.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpSynchronize.Size = new System.Drawing.Size(1096, 164);
            this.grpSynchronize.TabIndex = 0;
            this.grpSynchronize.TabStop = false;
            this.grpSynchronize.Text = "Notification Settings...";
            this.grpSynchronize.Enter += new System.EventHandler(this.grpSynchronize_Enter);
            // 
            // chkAllFoldes
            // 
            this.chkAllFoldes.AutoSize = true;
            this.chkAllFoldes.Checked = true;
            this.chkAllFoldes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllFoldes.Location = new System.Drawing.Point(12, 23);
            this.chkAllFoldes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkAllFoldes.Name = "chkAllFoldes";
            this.chkAllFoldes.Size = new System.Drawing.Size(179, 21);
            this.chkAllFoldes.TabIndex = 0;
            this.chkAllFoldes.Text = "Subscribe to All Folders";
            this.chkAllFoldes.UseVisualStyleBackColor = true;
            this.chkAllFoldes.CheckedChanged += new System.EventHandler(this.chkAllFoldes_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 125);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Subs/Thread";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Number of Threads";
            // 
            // numSubs
            // 
            this.numSubs.Location = new System.Drawing.Point(537, 122);
            this.numSubs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numSubs.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numSubs.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSubs.Name = "numSubs";
            this.numSubs.Size = new System.Drawing.Size(67, 22);
            this.numSubs.TabIndex = 16;
            this.numSubs.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numThreads
            // 
            this.numThreads.Location = new System.Drawing.Point(359, 122);
            this.numThreads.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numThreads.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThreads.Name = "numThreads";
            this.numThreads.Size = new System.Drawing.Size(67, 22);
            this.numThreads.TabIndex = 14;
            this.numThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(620, 125);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Connection Lifetime";
            // 
            // SubscriptionLifetime
            // 
            this.SubscriptionLifetime.Location = new System.Drawing.Point(756, 122);
            this.SubscriptionLifetime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SubscriptionLifetime.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.SubscriptionLifetime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SubscriptionLifetime.Name = "SubscriptionLifetime";
            this.SubscriptionLifetime.Size = new System.Drawing.Size(67, 22);
            this.SubscriptionLifetime.TabIndex = 18;
            this.SubscriptionLifetime.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // btnGetFolderId
            // 
            this.btnGetFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetFolderId.Location = new System.Drawing.Point(1011, 48);
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
            this.label1.Location = new System.Drawing.Point(7, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Events Types:";
            // 
            // chkSerialize
            // 
            this.chkSerialize.AutoSize = true;
            this.chkSerialize.Checked = true;
            this.chkSerialize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSerialize.Location = new System.Drawing.Point(17, 126);
            this.chkSerialize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSerialize.Name = "chkSerialize";
            this.chkSerialize.Size = new System.Drawing.Size(166, 21);
            this.chkSerialize.TabIndex = 12;
            this.chkSerialize.Text = "Serialize Connections";
            this.chkSerialize.UseVisualStyleBackColor = true;
            // 
            // chkFreeBusyChangedEvent
            // 
            this.chkFreeBusyChangedEvent.AutoSize = true;
            this.chkFreeBusyChangedEvent.Checked = true;
            this.chkFreeBusyChangedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFreeBusyChangedEvent.Location = new System.Drawing.Point(898, 91);
            this.chkFreeBusyChangedEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkFreeBusyChangedEvent.Name = "chkFreeBusyChangedEvent";
            this.chkFreeBusyChangedEvent.Size = new System.Drawing.Size(183, 21);
            this.chkFreeBusyChangedEvent.TabIndex = 11;
            this.chkFreeBusyChangedEvent.Text = "FreeBusyChangedEvent";
            this.chkFreeBusyChangedEvent.UseVisualStyleBackColor = true;
            // 
            // chkNewMailEvent
            // 
            this.chkNewMailEvent.AutoSize = true;
            this.chkNewMailEvent.Checked = true;
            this.chkNewMailEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNewMailEvent.Location = new System.Drawing.Point(764, 90);
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
            this.chkMovedEvent.Location = new System.Drawing.Point(377, 91);
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
            this.chkModifiedEvent.Location = new System.Drawing.Point(629, 90);
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
            this.chkDeletedEvent.Location = new System.Drawing.Point(247, 91);
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
            this.chkCreatedEvent.Location = new System.Drawing.Point(500, 90);
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
            this.chkCopiedEvent.Location = new System.Drawing.Point(119, 91);
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
            this.btnSubscribe.Location = new System.Drawing.Point(880, 122);
            this.btnSubscribe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(100, 28);
            this.btnSubscribe.TabIndex = 19;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // btnUnsubscribe
            // 
            this.btnUnsubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnsubscribe.Enabled = false;
            this.btnUnsubscribe.Location = new System.Drawing.Point(989, 122);
            this.btnUnsubscribe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUnsubscribe.Name = "btnUnsubscribe";
            this.btnUnsubscribe.Size = new System.Drawing.Size(100, 28);
            this.btnUnsubscribe.TabIndex = 20;
            this.btnUnsubscribe.Text = "Unsubscribe";
            this.btnUnsubscribe.UseVisualStyleBackColor = true;
            this.btnUnsubscribe.Click += new System.EventHandler(this.btnUnsubscribe_Click);
            // 
            // txtFolderId
            // 
            this.txtFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderId.Location = new System.Drawing.Point(119, 51);
            this.txtFolderId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFolderId.Name = "txtFolderId";
            this.txtFolderId.ReadOnly = true;
            this.txtFolderId.Size = new System.Drawing.Size(873, 22);
            this.txtFolderId.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Folder Id:";
            // 
            // lblEventsHeader
            // 
            this.lblEventsHeader.Location = new System.Drawing.Point(24, 174);
            this.lblEventsHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEventsHeader.Name = "lblEventsHeader";
            this.lblEventsHeader.Size = new System.Drawing.Size(804, 28);
            this.lblEventsHeader.TabIndex = 15;
            this.lblEventsHeader.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lstEvents
            // 
            this.lstEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEventClass,
            this.colTID,
            this.colTimestamp,
            this.colEventType,
            this.colParentFolderId,
            this.colOldParentFolderId,
            this.colObjectId,
            this.colOldObjectId,
            this.colFolderId,
            this.colOldFolderId,
            this.colUnreadCount});
            this.lstEvents.FullRowSelect = true;
            this.lstEvents.Location = new System.Drawing.Point(5, 206);
            this.lstEvents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstEvents.MultiSelect = false;
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.ShowItemToolTips = true;
            this.lstEvents.Size = new System.Drawing.Size(1096, 144);
            this.lstEvents.TabIndex = 1;
            this.lstEvents.UseCompatibleStateImageBehavior = false;
            this.lstEvents.View = System.Windows.Forms.View.Details;
            this.lstEvents.SelectedIndexChanged += new System.EventHandler(this.lstEvents_SelectedIndexChanged);
            this.lstEvents.DoubleClick += new System.EventHandler(this.lstEvents_DoubleClick);
            // 
            // colEventClass
            // 
            this.colEventClass.Text = "EventClass";
            this.colEventClass.Width = 93;
            // 
            // colTID
            // 
            this.colTID.Text = "Thread";
            // 
            // colTimestamp
            // 
            this.colTimestamp.Text = "Timestamp";
            this.colTimestamp.Width = 66;
            // 
            // colEventType
            // 
            this.colEventType.Text = "EventType";
            this.colEventType.Width = 72;
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
            // colObjectId
            // 
            this.colObjectId.Text = "Item.ItemId";
            this.colObjectId.Width = 81;
            // 
            // colOldObjectId
            // 
            this.colOldObjectId.Text = "Item.OldItemId";
            this.colOldObjectId.Width = 89;
            // 
            // colFolderId
            // 
            this.colFolderId.Text = "FolderEvent.FolderId";
            this.colFolderId.Width = 112;
            // 
            // colOldFolderId
            // 
            this.colOldFolderId.Text = "FolderEvent.OldFolderId";
            this.colOldFolderId.Width = 124;
            // 
            // colUnreadCount
            // 
            this.colUnreadCount.Text = "FolderEvent.UnreadCount";
            this.colUnreadCount.Width = 99;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(987, 357);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(199, 182);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Connections: ";
            // 
            // ConnectionCount
            // 
            this.ConnectionCount.AutoSize = true;
            this.ConnectionCount.Location = new System.Drawing.Point(309, 182);
            this.ConnectionCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ConnectionCount.Name = "ConnectionCount";
            this.ConnectionCount.Size = new System.Drawing.Size(16, 17);
            this.ConnectionCount.TabIndex = 18;
            this.ConnectionCount.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(973, 182);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Events:";
            // 
            // EventCount
            // 
            this.EventCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EventCount.AutoSize = true;
            this.EventCount.Location = new System.Drawing.Point(1071, 182);
            this.EventCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EventCount.Name = "EventCount";
            this.EventCount.Size = new System.Drawing.Size(16, 17);
            this.EventCount.TabIndex = 18;
            this.EventCount.Text = "0";
            // 
            // btnClearEvents
            // 
            this.btnClearEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearEvents.Location = new System.Drawing.Point(860, 358);
            this.btnClearEvents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClearEvents.Name = "btnClearEvents";
            this.btnClearEvents.Size = new System.Drawing.Size(100, 28);
            this.btnClearEvents.TabIndex = 2;
            this.btnClearEvents.Text = "Clear Events";
            this.btnClearEvents.UseVisualStyleBackColor = true;
            this.btnClearEvents.Click += new System.EventHandler(this.btnClearEvents_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(437, 182);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Subscriptions:";
            // 
            // SubscriptionCount
            // 
            this.SubscriptionCount.AutoSize = true;
            this.SubscriptionCount.Location = new System.Drawing.Point(552, 182);
            this.SubscriptionCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SubscriptionCount.Name = "SubscriptionCount";
            this.SubscriptionCount.Size = new System.Drawing.Size(16, 17);
            this.SubscriptionCount.TabIndex = 18;
            this.SubscriptionCount.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 182);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Threads:";
            this.label9.DoubleClick += new System.EventHandler(this.ThreadCountLabel_DoubleClick);
            // 
            // ThreadCount
            // 
            this.ThreadCount.AutoSize = true;
            this.ThreadCount.Location = new System.Drawing.Point(112, 182);
            this.ThreadCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ThreadCount.Name = "ThreadCount";
            this.ThreadCount.Size = new System.Drawing.Size(16, 17);
            this.ThreadCount.TabIndex = 18;
            this.ThreadCount.Text = "0";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(10, 359);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(426, 28);
            this.label10.TabIndex = 19;
            this.label10.Text = "Note:  Subscriptions are not supported for delegate user access.";
            // 
            // StreamingNotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 396);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnClearEvents);
            this.Controls.Add(this.SubscriptionCount);
            this.Controls.Add(this.EventCount);
            this.Controls.Add(this.ThreadCount);
            this.Controls.Add(this.ConnectionCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblEventsHeader);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.grpSynchronize);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "StreamingNotificationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Streaming Notifications";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StreamingNotificationForm_FormClosing);
            this.Load += new System.EventHandler(this.StreamingNotificationForm_Load);
            this.grpSynchronize.ResumeLayout(false);
            this.grpSynchronize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSubs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubscriptionLifetime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSynchronize;
        private System.Windows.Forms.TextBox txtFolderId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEventsHeader;
        private System.Windows.Forms.ListView lstEvents;
        private System.Windows.Forms.ColumnHeader colEventClass;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubscribe;
        private System.Windows.Forms.Button btnUnsubscribe;
        private System.Windows.Forms.CheckBox chkCopiedEvent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkNewMailEvent;
        private System.Windows.Forms.CheckBox chkMovedEvent;
        private System.Windows.Forms.CheckBox chkModifiedEvent;
        private System.Windows.Forms.CheckBox chkDeletedEvent;
        private System.Windows.Forms.CheckBox chkCreatedEvent;
        private System.Windows.Forms.Button btnGetFolderId;
        private System.Windows.Forms.ColumnHeader colTimestamp;
        private System.Windows.Forms.ColumnHeader colObjectId;
        private System.Windows.Forms.ColumnHeader colOldObjectId;
        private System.Windows.Forms.ColumnHeader colParentFolderId;
        private System.Windows.Forms.ColumnHeader colOldParentFolderId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown SubscriptionLifetime;
        private System.Windows.Forms.ColumnHeader colFolderId;
        private System.Windows.Forms.ColumnHeader colOldFolderId;
        private System.Windows.Forms.ColumnHeader colUnreadCount;
        private System.Windows.Forms.ColumnHeader colEventType;
        private System.Windows.Forms.CheckBox chkFreeBusyChangedEvent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numThreads;
        private System.Windows.Forms.ColumnHeader colTID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numSubs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ConnectionCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label EventCount;
        private System.Windows.Forms.Button btnClearEvents;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label SubscriptionCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label ThreadCount;
        private System.Windows.Forms.CheckBox chkSerialize;
        private System.Windows.Forms.CheckBox chkAllFoldes;
        private System.Windows.Forms.Label label10;
    }
}