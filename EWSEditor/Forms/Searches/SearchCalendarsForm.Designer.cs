namespace EWSEditor.Forms
{
    partial class SearchCalendarsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmboSearchType = new System.Windows.Forms.ComboBox();
            this.txtAQS = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.chkBody = new System.Windows.Forms.CheckBox();
            this.txtCC = new System.Windows.Forms.TextBox();
            this.chkCC = new System.Windows.Forms.CheckBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.chkTo = new System.Windows.Forms.CheckBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.chkSubject = new System.Windows.Forms.CheckBox();
            this.lvItems = new System.Windows.Forms.ListView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rdoAqsSearch = new System.Windows.Forms.RadioButton();
            this.rdoFindItemSearch = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.numPageSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkClass = new System.Windows.Forms.CheckBox();
            this.cmboSearchDepth = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmboSubjectConditional = new System.Windows.Forms.ComboBox();
            this.cmboToConditional = new System.Windows.Forms.ComboBox();
            this.cmboCCConditional = new System.Windows.Forms.ComboBox();
            this.cmboBodyConditional = new System.Windows.Forms.ComboBox();
            this.cmboClassConditional = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cmboUidConditional = new System.Windows.Forms.ComboBox();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.chkUID = new System.Windows.Forms.CheckBox();
            this.cmboClass = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lvItemsMessages = new System.Windows.Forms.ListView();
            this.btnExportCalendarItems = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lvCommon = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Type:";
            // 
            // cmboSearchType
            // 
            this.cmboSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboSearchType.FormattingEnabled = true;
            this.cmboSearchType.Items.AddRange(new object[] {
            "Direct",
            "More Available"});
            this.cmboSearchType.Location = new System.Drawing.Point(111, 5);
            this.cmboSearchType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmboSearchType.Name = "cmboSearchType";
            this.cmboSearchType.Size = new System.Drawing.Size(151, 24);
            this.cmboSearchType.TabIndex = 1;
            // 
            // txtAQS
            // 
            this.txtAQS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAQS.Enabled = false;
            this.txtAQS.Location = new System.Drawing.Point(123, 55);
            this.txtAQS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAQS.Multiline = true;
            this.txtAQS.Name = "txtAQS";
            this.txtAQS.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAQS.Size = new System.Drawing.Size(964, 63);
            this.txtAQS.TabIndex = 8;
            // 
            // txtBody
            // 
            this.txtBody.Enabled = false;
            this.txtBody.Location = new System.Drawing.Point(679, 154);
            this.txtBody.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(261, 22);
            this.txtBody.TabIndex = 20;
            // 
            // chkBody
            // 
            this.chkBody.AutoSize = true;
            this.chkBody.Enabled = false;
            this.chkBody.Location = new System.Drawing.Point(610, 158);
            this.chkBody.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkBody.Name = "chkBody";
            this.chkBody.Size = new System.Drawing.Size(62, 21);
            this.chkBody.TabIndex = 19;
            this.chkBody.Text = "Body";
            this.chkBody.UseVisualStyleBackColor = true;
            this.chkBody.CheckedChanged += new System.EventHandler(this.chkBody_CheckedChanged);
            // 
            // txtCC
            // 
            this.txtCC.Enabled = false;
            this.txtCC.Location = new System.Drawing.Point(679, 122);
            this.txtCC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(261, 22);
            this.txtCC.TabIndex = 17;
            // 
            // chkCC
            // 
            this.chkCC.AutoSize = true;
            this.chkCC.Enabled = false;
            this.chkCC.Location = new System.Drawing.Point(611, 126);
            this.chkCC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkCC.Name = "chkCC";
            this.chkCC.Size = new System.Drawing.Size(48, 21);
            this.chkCC.TabIndex = 16;
            this.chkCC.Text = "CC";
            this.chkCC.UseVisualStyleBackColor = true;
            this.chkCC.CheckedChanged += new System.EventHandler(this.chkCC_CheckedChanged);
            // 
            // txtTo
            // 
            this.txtTo.Enabled = false;
            this.txtTo.Location = new System.Drawing.Point(228, 185);
            this.txtTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(224, 22);
            this.txtTo.TabIndex = 14;
            // 
            // chkTo
            // 
            this.chkTo.AutoSize = true;
            this.chkTo.Enabled = false;
            this.chkTo.Location = new System.Drawing.Point(154, 188);
            this.chkTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkTo.Name = "chkTo";
            this.chkTo.Size = new System.Drawing.Size(47, 21);
            this.chkTo.TabIndex = 13;
            this.chkTo.Text = "To";
            this.chkTo.UseVisualStyleBackColor = true;
            this.chkTo.CheckedChanged += new System.EventHandler(this.chkTo_CheckedChanged);
            // 
            // txtSubject
            // 
            this.txtSubject.Enabled = false;
            this.txtSubject.Location = new System.Drawing.Point(228, 156);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(224, 22);
            this.txtSubject.TabIndex = 11;
            // 
            // chkSubject
            // 
            this.chkSubject.AutoSize = true;
            this.chkSubject.Enabled = false;
            this.chkSubject.Location = new System.Drawing.Point(154, 156);
            this.chkSubject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkSubject.Name = "chkSubject";
            this.chkSubject.Size = new System.Drawing.Size(77, 21);
            this.chkSubject.TabIndex = 10;
            this.chkSubject.Text = "Subject";
            this.chkSubject.UseVisualStyleBackColor = true;
            this.chkSubject.CheckedChanged += new System.EventHandler(this.chkSubject_CheckedChanged);
            // 
            // lvItems
            // 
            this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvItems.FullRowSelect = true;
            this.lvItems.GridLines = true;
            this.lvItems.HideSelection = false;
            this.lvItems.Location = new System.Drawing.Point(6, 22);
            this.lvItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvItems.MultiSelect = false;
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(1054, 154);
            this.lvItems.TabIndex = 26;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvItems_ColumnClick);
            this.lvItems.DoubleClick += new System.EventHandler(this.lvItems_DoubleClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(748, 5);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(136, 29);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rdoAqsSearch
            // 
            this.rdoAqsSearch.AutoSize = true;
            this.rdoAqsSearch.Location = new System.Drawing.Point(10, 55);
            this.rdoAqsSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoAqsSearch.Name = "rdoAqsSearch";
            this.rdoAqsSearch.Size = new System.Drawing.Size(107, 21);
            this.rdoAqsSearch.TabIndex = 7;
            this.rdoAqsSearch.Text = "AQS Search";
            this.rdoAqsSearch.UseVisualStyleBackColor = true;
            this.rdoAqsSearch.CheckedChanged += new System.EventHandler(this.rdoAqsSearch_CheckedChanged);
            // 
            // rdoFindItemSearch
            // 
            this.rdoFindItemSearch.AutoSize = true;
            this.rdoFindItemSearch.Checked = true;
            this.rdoFindItemSearch.Location = new System.Drawing.Point(12, 130);
            this.rdoFindItemSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoFindItemSearch.Name = "rdoFindItemSearch";
            this.rdoFindItemSearch.Size = new System.Drawing.Size(135, 21);
            this.rdoFindItemSearch.TabIndex = 9;
            this.rdoFindItemSearch.TabStop = true;
            this.rdoFindItemSearch.Text = "Find Item Search";
            this.rdoFindItemSearch.UseVisualStyleBackColor = true;
            this.rdoFindItemSearch.CheckedChanged += new System.EventHandler(this.rdoFindItemSearch_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Page Size:";
            // 
            // numPageSize
            // 
            this.numPageSize.Location = new System.Drawing.Point(361, 5);
            this.numPageSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numPageSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPageSize.Name = "numPageSize";
            this.numPageSize.Size = new System.Drawing.Size(150, 22);
            this.numPageSize.TabIndex = 3;
            this.numPageSize.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(563, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Note:  Exchange Online may limit AQS results to 250 items due to default policy s" +
    "ettings.";
            // 
            // chkClass
            // 
            this.chkClass.AutoSize = true;
            this.chkClass.Enabled = false;
            this.chkClass.Location = new System.Drawing.Point(610, 190);
            this.chkClass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkClass.Name = "chkClass";
            this.chkClass.Size = new System.Drawing.Size(64, 21);
            this.chkClass.TabIndex = 22;
            this.chkClass.Text = "Class";
            this.chkClass.UseVisualStyleBackColor = true;
            this.chkClass.CheckedChanged += new System.EventHandler(this.chkClass_CheckedChanged);
            // 
            // cmboSearchDepth
            // 
            this.cmboSearchDepth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboSearchDepth.FormattingEnabled = true;
            this.cmboSearchDepth.Items.AddRange(new object[] {
            "Shallow",
            "ItemTraversal",
            "SoftDeleted"});
            this.cmboSearchDepth.Location = new System.Drawing.Point(580, 4);
            this.cmboSearchDepth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmboSearchDepth.Name = "cmboSearchDepth";
            this.cmboSearchDepth.Size = new System.Drawing.Size(126, 24);
            this.cmboSearchDepth.TabIndex = 5;
            this.cmboSearchDepth.SelectedIndexChanged += new System.EventHandler(this.cmboSearchDepth_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(524, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Depth:";
            // 
            // cmboSubjectConditional
            // 
            this.cmboSubjectConditional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboSubjectConditional.FormattingEnabled = true;
            this.cmboSubjectConditional.Items.AddRange(new object[] {
            "ContainsSubstring",
            "IsEqualTo",
            "IsNotEqualTo",
            "IsGreaterThan",
            "IsLessThan",
            "IsGreaterThanOrEqualTo",
            "IsNotEqualTo"});
            this.cmboSubjectConditional.Location = new System.Drawing.Point(459, 155);
            this.cmboSubjectConditional.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmboSubjectConditional.Name = "cmboSubjectConditional";
            this.cmboSubjectConditional.Size = new System.Drawing.Size(135, 24);
            this.cmboSubjectConditional.TabIndex = 12;
            this.cmboSubjectConditional.SelectedIndexChanged += new System.EventHandler(this.cmboSubjectConditional_SelectedIndexChanged);
            // 
            // cmboToConditional
            // 
            this.cmboToConditional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboToConditional.FormattingEnabled = true;
            this.cmboToConditional.Items.AddRange(new object[] {
            "ContainsSubstring",
            "IsEqualTo",
            "IsNotEqualTo",
            "IsGreaterThan",
            "IsLessThan",
            "IsGreaterThanOrEqualTo",
            "IsNotEqualTo"});
            this.cmboToConditional.Location = new System.Drawing.Point(458, 187);
            this.cmboToConditional.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmboToConditional.Name = "cmboToConditional";
            this.cmboToConditional.Size = new System.Drawing.Size(136, 24);
            this.cmboToConditional.TabIndex = 15;
            this.cmboToConditional.SelectedIndexChanged += new System.EventHandler(this.cmboToConditional_SelectedIndexChanged);
            // 
            // cmboCCConditional
            // 
            this.cmboCCConditional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboCCConditional.FormattingEnabled = true;
            this.cmboCCConditional.Items.AddRange(new object[] {
            "ContainsSubstring",
            "IsEqualTo",
            "IsNotEqualTo",
            "IsGreaterThan",
            "IsLessThan",
            "IsGreaterThanOrEqualTo",
            "IsNotEqualTo"});
            this.cmboCCConditional.Location = new System.Drawing.Point(946, 122);
            this.cmboCCConditional.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmboCCConditional.Name = "cmboCCConditional";
            this.cmboCCConditional.Size = new System.Drawing.Size(136, 24);
            this.cmboCCConditional.TabIndex = 18;
            this.cmboCCConditional.SelectedIndexChanged += new System.EventHandler(this.cmboCCConditional_SelectedIndexChanged);
            // 
            // cmboBodyConditional
            // 
            this.cmboBodyConditional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboBodyConditional.FormattingEnabled = true;
            this.cmboBodyConditional.Items.AddRange(new object[] {
            "ContainsSubstring",
            "IsEqualTo",
            "IsNotEqualTo",
            "IsGreaterThan",
            "IsLessThan",
            "IsGreaterThanOrEqualTo",
            "IsNotEqualTo"});
            this.cmboBodyConditional.Location = new System.Drawing.Point(945, 152);
            this.cmboBodyConditional.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmboBodyConditional.Name = "cmboBodyConditional";
            this.cmboBodyConditional.Size = new System.Drawing.Size(136, 24);
            this.cmboBodyConditional.TabIndex = 21;
            this.cmboBodyConditional.SelectedIndexChanged += new System.EventHandler(this.cmboBodyConditional_SelectedIndexChanged);
            // 
            // cmboClassConditional
            // 
            this.cmboClassConditional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboClassConditional.FormattingEnabled = true;
            this.cmboClassConditional.Items.AddRange(new object[] {
            "ContainsSubstring",
            "IsEqualTo",
            "IsNotEqualTo",
            "IsGreaterThan",
            "IsLessThan",
            "IsGreaterThanOrEqualTo",
            "IsNotEqualTo"});
            this.cmboClassConditional.Location = new System.Drawing.Point(947, 184);
            this.cmboClassConditional.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmboClassConditional.Name = "cmboClassConditional";
            this.cmboClassConditional.Size = new System.Drawing.Size(136, 24);
            this.cmboClassConditional.TabIndex = 24;
            this.cmboClassConditional.SelectedIndexChanged += new System.EventHandler(this.cmboClassConditional_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1093, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cmboUidConditional
            // 
            this.cmboUidConditional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboUidConditional.FormattingEnabled = true;
            this.cmboUidConditional.Items.AddRange(new object[] {
            "ContainsSubstring",
            "IsEqualTo",
            "IsNotEqualTo",
            "IsGreaterThan",
            "IsLessThan",
            "IsGreaterThanOrEqualTo",
            "IsNotEqualTo"});
            this.cmboUidConditional.Location = new System.Drawing.Point(459, 126);
            this.cmboUidConditional.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmboUidConditional.Name = "cmboUidConditional";
            this.cmboUidConditional.Size = new System.Drawing.Size(135, 24);
            this.cmboUidConditional.TabIndex = 33;
            this.cmboUidConditional.SelectedIndexChanged += new System.EventHandler(this.cmboUidConditional_SelectedIndexChanged);
            // 
            // txtUID
            // 
            this.txtUID.Enabled = false;
            this.txtUID.Location = new System.Drawing.Point(228, 131);
            this.txtUID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(224, 22);
            this.txtUID.TabIndex = 32;
            // 
            // chkUID
            // 
            this.chkUID.AutoSize = true;
            this.chkUID.Enabled = false;
            this.chkUID.Location = new System.Drawing.Point(154, 131);
            this.chkUID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkUID.Name = "chkUID";
            this.chkUID.Size = new System.Drawing.Size(53, 21);
            this.chkUID.TabIndex = 31;
            this.chkUID.Text = "UID";
            this.chkUID.UseVisualStyleBackColor = true;
            this.chkUID.CheckedChanged += new System.EventHandler(this.chkUID_CheckedChanged);
            // 
            // cmboClass
            // 
            this.cmboClass.FormattingEnabled = true;
            this.cmboClass.Items.AddRange(new object[] {
            "IPM.Appointment",
            "IPM.Appointment.MeetingPlace",
            "IPM.Appointment.MP",
            "IPM.Schedule",
            "IPM.Schedule.Request",
            "IPM.Schedule.Meeting.Resp.Neg",
            "IPM.Schedule.Meeting.Resp.Tent",
            "IPM.Schedule.Meeting.Pos",
            "IPM.Schedule.Meeting.Forward",
            "IPM.Schedule.Meeting.Canceled",
            "IPM.Schedule.Meeting.Notification.Forward",
            "IPM.OLE.CLASS.{00061055-0000-0000-C000-000000000046}\""});
            this.cmboClass.Location = new System.Drawing.Point(680, 184);
            this.cmboClass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmboClass.Name = "cmboClass";
            this.cmboClass.Size = new System.Drawing.Size(261, 24);
            this.cmboClass.TabIndex = 23;
            this.cmboClass.Text = "IPM.Appointment ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(235, 17);
            this.label7.TabIndex = 34;
            this.label7.Text = "Calendar Items (IPM.Appointment.*):";
            // 
            // lvItemsMessages
            // 
            this.lvItemsMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvItemsMessages.FullRowSelect = true;
            this.lvItemsMessages.GridLines = true;
            this.lvItemsMessages.HideSelection = false;
            this.lvItemsMessages.Location = new System.Drawing.Point(6, 201);
            this.lvItemsMessages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvItemsMessages.MultiSelect = false;
            this.lvItemsMessages.Name = "lvItemsMessages";
            this.lvItemsMessages.Size = new System.Drawing.Size(1054, 146);
            this.lvItemsMessages.TabIndex = 35;
            this.lvItemsMessages.UseCompatibleStateImageBehavior = false;
            this.lvItemsMessages.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvItemsMessages_ColumnClick);
            this.lvItemsMessages.SelectedIndexChanged += new System.EventHandler(this.lvItemsMessages_SelectedIndexChanged);
            this.lvItemsMessages.DoubleClick += new System.EventHandler(this.lvItemsMessages_DoubleClick);
            // 
            // btnExportCalendarItems
            // 
            this.btnExportCalendarItems.Location = new System.Drawing.Point(904, 5);
            this.btnExportCalendarItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportCalendarItems.Name = "btnExportCalendarItems";
            this.btnExportCalendarItems.Size = new System.Drawing.Size(153, 29);
            this.btnExportCalendarItems.TabIndex = 37;
            this.btnExportCalendarItems.Text = "Export Results";
            this.btnExportCalendarItems.UseVisualStyleBackColor = true;
            this.btnExportCalendarItems.Click += new System.EventHandler(this.btnExportCalendarItems_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(248, 17);
            this.label8.TabIndex = 38;
            this.label8.Text = "Schedule Messages (IPM.Schedule.*):";
            // 
            // lvCommon
            // 
            this.lvCommon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCommon.GridLines = true;
            this.lvCommon.Location = new System.Drawing.Point(4, 7);
            this.lvCommon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvCommon.MultiSelect = false;
            this.lvCommon.Name = "lvCommon";
            this.lvCommon.Size = new System.Drawing.Size(1060, 340);
            this.lvCommon.TabIndex = 39;
            this.lvCommon.UseCompatibleStateImageBehavior = false;
            this.lvCommon.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvCommon_ColumnClick);
            this.lvCommon.DoubleClick += new System.EventHandler(this.lvCommon_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 218);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1074, 383);
            this.tabControl1.TabIndex = 40;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvCommon);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1066, 354);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Combined Calendar and Meeting Messages";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvItems);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.lvItemsMessages);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1066, 354);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Details";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SearchCalendarsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1093, 605);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnExportCalendarItems);
            this.Controls.Add(this.cmboClass);
            this.Controls.Add(this.cmboUidConditional);
            this.Controls.Add(this.txtUID);
            this.Controls.Add(this.chkUID);
            this.Controls.Add(this.cmboClassConditional);
            this.Controls.Add(this.cmboBodyConditional);
            this.Controls.Add(this.cmboCCConditional);
            this.Controls.Add(this.cmboToConditional);
            this.Controls.Add(this.cmboSubjectConditional);
            this.Controls.Add(this.cmboSearchDepth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkClass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPageSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdoFindItemSearch);
            this.Controls.Add(this.rdoAqsSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmboSearchType);
            this.Controls.Add(this.txtAQS);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.chkBody);
            this.Controls.Add(this.txtCC);
            this.Controls.Add(this.chkCC);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.chkTo);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.chkSubject);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SearchCalendarsForm";
            this.Text = "Search Calendars Form";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cmboSearchType;
        public System.Windows.Forms.TextBox txtAQS;
        public System.Windows.Forms.TextBox txtBody;
        public System.Windows.Forms.CheckBox chkBody;
        public System.Windows.Forms.TextBox txtCC;
        public System.Windows.Forms.CheckBox chkCC;
        public System.Windows.Forms.TextBox txtTo;
        public System.Windows.Forms.CheckBox chkTo;
        public System.Windows.Forms.TextBox txtSubject;
        public System.Windows.Forms.CheckBox chkSubject;
        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rdoAqsSearch;
        private System.Windows.Forms.RadioButton rdoFindItemSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPageSize;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox chkClass;
        public System.Windows.Forms.ComboBox cmboSearchDepth;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cmboSubjectConditional;
        public System.Windows.Forms.ComboBox cmboToConditional;
        public System.Windows.Forms.ComboBox cmboCCConditional;
        public System.Windows.Forms.ComboBox cmboBodyConditional;
        public System.Windows.Forms.ComboBox cmboClassConditional;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ComboBox cmboUidConditional;
        public System.Windows.Forms.TextBox txtUID;
        public System.Windows.Forms.CheckBox chkUID;
        public System.Windows.Forms.ComboBox cmboClass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lvItemsMessages;
        private System.Windows.Forms.Button btnExportCalendarItems;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lvCommon;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}