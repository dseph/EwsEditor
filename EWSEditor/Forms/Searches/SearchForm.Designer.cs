namespace EWSEditor.Forms
{
    partial class SearchForm
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
            this.components = new System.ComponentModel.Container();
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
            this.mnuItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopyItems = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveItems = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteItems = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHardDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSoftDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveToDeletedItems = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rdoAqsSearch = new System.Windows.Forms.RadioButton();
            this.rdoFindItemSearch = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.numPageSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.chkClass = new System.Windows.Forms.CheckBox();
            this.cmboSearchDepth = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmboSubjectConditional = new System.Windows.Forms.ComboBox();
            this.cmboToConditional = new System.Windows.Forms.ComboBox();
            this.cmboCCConditional = new System.Windows.Forms.ComboBox();
            this.cmboBodyConditional = new System.Windows.Forms.ComboBox();
            this.cmboClassConditional = new System.Windows.Forms.ComboBox();
            this.cmboLogicalOperation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnExportCalendarItems = new System.Windows.Forms.Button();
            this.cmboInternetMessageIdConditional = new System.Windows.Forms.ComboBox();
            this.txtInternetMessageId = new System.Windows.Forms.TextBox();
            this.chkInternetMessageId = new System.Windows.Forms.CheckBox();
            this.mnuItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search Type:";
            // 
            // cmboSearchType
            // 
            this.cmboSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboSearchType.FormattingEnabled = true;
            this.cmboSearchType.Items.AddRange(new object[] {
            "Direct",
            "More Available"});
            this.cmboSearchType.Location = new System.Drawing.Point(198, 19);
            this.cmboSearchType.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmboSearchType.Name = "cmboSearchType";
            this.cmboSearchType.Size = new System.Drawing.Size(239, 33);
            this.cmboSearchType.TabIndex = 2;
            // 
            // txtAQS
            // 
            this.txtAQS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAQS.Enabled = false;
            this.txtAQS.Location = new System.Drawing.Point(203, 106);
            this.txtAQS.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtAQS.Multiline = true;
            this.txtAQS.Name = "txtAQS";
            this.txtAQS.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAQS.Size = new System.Drawing.Size(1526, 89);
            this.txtAQS.TabIndex = 11;
            // 
            // txtBody
            // 
            this.txtBody.Enabled = false;
            this.txtBody.Location = new System.Drawing.Point(932, 250);
            this.txtBody.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(332, 31);
            this.txtBody.TabIndex = 19;
            // 
            // chkBody
            // 
            this.chkBody.AutoSize = true;
            this.chkBody.Enabled = false;
            this.chkBody.Location = new System.Drawing.Point(755, 253);
            this.chkBody.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chkBody.Name = "chkBody";
            this.chkBody.Size = new System.Drawing.Size(93, 29);
            this.chkBody.TabIndex = 18;
            this.chkBody.Text = "Body";
            this.chkBody.UseVisualStyleBackColor = true;
            this.chkBody.CheckedChanged += new System.EventHandler(this.chkBody_CheckedChanged);
            // 
            // txtCC
            // 
            this.txtCC.Enabled = false;
            this.txtCC.Location = new System.Drawing.Point(186, 363);
            this.txtCC.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(308, 31);
            this.txtCC.TabIndex = 20;
            // 
            // chkCC
            // 
            this.chkCC.AutoSize = true;
            this.chkCC.Enabled = false;
            this.chkCC.Location = new System.Drawing.Point(53, 365);
            this.chkCC.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chkCC.Name = "chkCC";
            this.chkCC.Size = new System.Drawing.Size(74, 29);
            this.chkCC.TabIndex = 19;
            this.chkCC.Text = "CC";
            this.chkCC.UseVisualStyleBackColor = true;
            this.chkCC.CheckedChanged += new System.EventHandler(this.chkCC_CheckedChanged);
            // 
            // txtTo
            // 
            this.txtTo.Enabled = false;
            this.txtTo.Location = new System.Drawing.Point(190, 312);
            this.txtTo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(306, 31);
            this.txtTo.TabIndex = 17;
            // 
            // chkTo
            // 
            this.chkTo.AutoSize = true;
            this.chkTo.Enabled = false;
            this.chkTo.Location = new System.Drawing.Point(54, 312);
            this.chkTo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chkTo.Name = "chkTo";
            this.chkTo.Size = new System.Drawing.Size(69, 29);
            this.chkTo.TabIndex = 16;
            this.chkTo.Text = "To";
            this.chkTo.UseVisualStyleBackColor = true;
            this.chkTo.CheckedChanged += new System.EventHandler(this.chkTo_CheckedChanged);
            // 
            // txtSubject
            // 
            this.txtSubject.Enabled = false;
            this.txtSubject.Location = new System.Drawing.Point(190, 261);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(306, 31);
            this.txtSubject.TabIndex = 14;
            // 
            // chkSubject
            // 
            this.chkSubject.AutoSize = true;
            this.chkSubject.Enabled = false;
            this.chkSubject.Location = new System.Drawing.Point(54, 258);
            this.chkSubject.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chkSubject.Name = "chkSubject";
            this.chkSubject.Size = new System.Drawing.Size(116, 29);
            this.chkSubject.TabIndex = 13;
            this.chkSubject.Text = "Subject";
            this.chkSubject.UseVisualStyleBackColor = true;
            this.chkSubject.CheckedChanged += new System.EventHandler(this.chkSubject_CheckedChanged);
            // 
            // lvItems
            // 
            this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvItems.ContextMenuStrip = this.mnuItems;
            this.lvItems.FullRowSelect = true;
            this.lvItems.HideSelection = false;
            this.lvItems.Location = new System.Drawing.Point(18, 462);
            this.lvItems.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(1711, 364);
            this.lvItems.TabIndex = 25;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvItems_ColumnClick);
            this.lvItems.SelectedIndexChanged += new System.EventHandler(this.lvItems_SelectedIndexChanged);
            this.lvItems.DoubleClick += new System.EventHandler(this.lvItems_DoubleClick);
            // 
            // mnuItems
            // 
            this.mnuItems.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopyItems,
            this.mnuMoveItems,
            this.mnuDeleteItems});
            this.mnuItems.Name = "mnuItems";
            this.mnuItems.Size = new System.Drawing.Size(159, 118);
            // 
            // mnuCopyItems
            // 
            this.mnuCopyItems.Name = "mnuCopyItems";
            this.mnuCopyItems.Size = new System.Drawing.Size(158, 38);
            this.mnuCopyItems.Text = "Copy";
            this.mnuCopyItems.Click += new System.EventHandler(this.mnuCopyItems_Click);
            // 
            // mnuMoveItems
            // 
            this.mnuMoveItems.Name = "mnuMoveItems";
            this.mnuMoveItems.Size = new System.Drawing.Size(158, 38);
            this.mnuMoveItems.Text = "Move";
            this.mnuMoveItems.Click += new System.EventHandler(this.mnuMoveItems_Click);
            // 
            // mnuDeleteItems
            // 
            this.mnuDeleteItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHardDelete,
            this.mnuSoftDelete,
            this.mnuMoveToDeletedItems});
            this.mnuDeleteItems.Name = "mnuDeleteItems";
            this.mnuDeleteItems.Size = new System.Drawing.Size(158, 38);
            this.mnuDeleteItems.Text = "Delete";
            this.mnuDeleteItems.Visible = false;
            this.mnuDeleteItems.Click += new System.EventHandler(this.mnuDeleteItems_Click);
            // 
            // mnuHardDelete
            // 
            this.mnuHardDelete.Name = "mnuHardDelete";
            this.mnuHardDelete.Size = new System.Drawing.Size(393, 44);
            this.mnuHardDelete.Text = "Hard Delete";
            // 
            // mnuSoftDelete
            // 
            this.mnuSoftDelete.Name = "mnuSoftDelete";
            this.mnuSoftDelete.Size = new System.Drawing.Size(393, 44);
            this.mnuSoftDelete.Text = "Soft Delete";
            this.mnuSoftDelete.Click += new System.EventHandler(this.mnuSoftDelete_Click);
            // 
            // mnuMoveToDeletedItems
            // 
            this.mnuMoveToDeletedItems.Name = "mnuMoveToDeletedItems";
            this.mnuMoveToDeletedItems.Size = new System.Drawing.Size(393, 44);
            this.mnuMoveToDeletedItems.Text = "Move to Deleted Items";
            this.mnuMoveToDeletedItems.Click += new System.EventHandler(this.mnuMoveToDeletedItems_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1203, 10);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(245, 46);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rdoAqsSearch
            // 
            this.rdoAqsSearch.AutoSize = true;
            this.rdoAqsSearch.Location = new System.Drawing.Point(18, 106);
            this.rdoAqsSearch.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.rdoAqsSearch.Name = "rdoAqsSearch";
            this.rdoAqsSearch.Size = new System.Drawing.Size(161, 29);
            this.rdoAqsSearch.TabIndex = 10;
            this.rdoAqsSearch.Text = "AQS Search";
            this.rdoAqsSearch.UseVisualStyleBackColor = true;
            this.rdoAqsSearch.CheckedChanged += new System.EventHandler(this.rdoAqsSearch_CheckedChanged);
            // 
            // rdoFindItemSearch
            // 
            this.rdoFindItemSearch.AutoSize = true;
            this.rdoFindItemSearch.Checked = true;
            this.rdoFindItemSearch.Location = new System.Drawing.Point(18, 211);
            this.rdoFindItemSearch.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.rdoFindItemSearch.Name = "rdoFindItemSearch";
            this.rdoFindItemSearch.Size = new System.Drawing.Size(205, 29);
            this.rdoFindItemSearch.TabIndex = 12;
            this.rdoFindItemSearch.TabStop = true;
            this.rdoFindItemSearch.Text = "Find Item Search";
            this.rdoFindItemSearch.UseVisualStyleBackColor = true;
            this.rdoFindItemSearch.CheckedChanged += new System.EventHandler(this.rdoFindItemSearch_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(477, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Page Size:";
            // 
            // numPageSize
            // 
            this.numPageSize.Location = new System.Drawing.Point(608, 16);
            this.numPageSize.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.numPageSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPageSize.Name = "numPageSize";
            this.numPageSize.Size = new System.Drawing.Size(240, 31);
            this.numPageSize.TabIndex = 4;
            this.numPageSize.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(858, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Note:  Exchange Online may limit AQS results to 250 items due to default policy s" +
    "ettings.";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1112, 411);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(580, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "Note:  Double click a result for more properties and options.";
            // 
            // txtClass
            // 
            this.txtClass.Enabled = false;
            this.txtClass.Location = new System.Drawing.Point(932, 309);
            this.txtClass.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(332, 31);
            this.txtClass.TabIndex = 22;
            // 
            // chkClass
            // 
            this.chkClass.AutoSize = true;
            this.chkClass.Enabled = false;
            this.chkClass.Location = new System.Drawing.Point(752, 312);
            this.chkClass.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chkClass.Name = "chkClass";
            this.chkClass.Size = new System.Drawing.Size(98, 29);
            this.chkClass.TabIndex = 21;
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
            this.cmboSearchDepth.Location = new System.Drawing.Point(965, 14);
            this.cmboSearchDepth.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmboSearchDepth.Name = "cmboSearchDepth";
            this.cmboSearchDepth.Size = new System.Drawing.Size(199, 33);
            this.cmboSearchDepth.TabIndex = 6;
            this.cmboSearchDepth.SelectedIndexChanged += new System.EventHandler(this.cmboSearchDepth_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(875, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 25);
            this.label5.TabIndex = 5;
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
            this.cmboSubjectConditional.Location = new System.Drawing.Point(509, 258);
            this.cmboSubjectConditional.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmboSubjectConditional.Name = "cmboSubjectConditional";
            this.cmboSubjectConditional.Size = new System.Drawing.Size(214, 33);
            this.cmboSubjectConditional.TabIndex = 15;
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
            this.cmboToConditional.Location = new System.Drawing.Point(509, 309);
            this.cmboToConditional.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmboToConditional.Name = "cmboToConditional";
            this.cmboToConditional.Size = new System.Drawing.Size(214, 33);
            this.cmboToConditional.TabIndex = 18;
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
            this.cmboCCConditional.Location = new System.Drawing.Point(509, 360);
            this.cmboCCConditional.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmboCCConditional.Name = "cmboCCConditional";
            this.cmboCCConditional.Size = new System.Drawing.Size(214, 33);
            this.cmboCCConditional.TabIndex = 21;
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
            this.cmboBodyConditional.Location = new System.Drawing.Point(1279, 247);
            this.cmboBodyConditional.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmboBodyConditional.Name = "cmboBodyConditional";
            this.cmboBodyConditional.Size = new System.Drawing.Size(214, 33);
            this.cmboBodyConditional.TabIndex = 20;
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
            this.cmboClassConditional.Location = new System.Drawing.Point(1276, 306);
            this.cmboClassConditional.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmboClassConditional.Name = "cmboClassConditional";
            this.cmboClassConditional.Size = new System.Drawing.Size(214, 33);
            this.cmboClassConditional.TabIndex = 23;
            // 
            // cmboLogicalOperation
            // 
            this.cmboLogicalOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboLogicalOperation.FormattingEnabled = true;
            this.cmboLogicalOperation.Items.AddRange(new object[] {
            "And",
            "Or"});
            this.cmboLogicalOperation.Location = new System.Drawing.Point(216, 406);
            this.cmboLogicalOperation.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmboLogicalOperation.Name = "cmboLogicalOperation";
            this.cmboLogicalOperation.Size = new System.Drawing.Size(199, 33);
            this.cmboLogicalOperation.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 414);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 25);
            this.label6.TabIndex = 22;
            this.label6.Text = "Logical Operation:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1754, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 849);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 22, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1754, 42);
            this.statusStrip1.TabIndex = 32;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(237, 32);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // btnExportCalendarItems
            // 
            this.btnExportCalendarItems.Location = new System.Drawing.Point(1486, 10);
            this.btnExportCalendarItems.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnExportCalendarItems.Name = "btnExportCalendarItems";
            this.btnExportCalendarItems.Size = new System.Drawing.Size(245, 46);
            this.btnExportCalendarItems.TabIndex = 8;
            this.btnExportCalendarItems.Text = "Export Results";
            this.btnExportCalendarItems.UseVisualStyleBackColor = true;
            this.btnExportCalendarItems.Click += new System.EventHandler(this.btnExportCalendarItems_Click);
            // 
            // cmboInternetMessageIdConditional
            // 
            this.cmboInternetMessageIdConditional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboInternetMessageIdConditional.FormattingEnabled = true;
            this.cmboInternetMessageIdConditional.Items.AddRange(new object[] {
            "ContainsSubstring",
            "IsEqualTo",
            "IsNotEqualTo",
            "IsGreaterThan",
            "IsLessThan",
            "IsGreaterThanOrEqualTo",
            "IsNotEqualTo"});
            this.cmboInternetMessageIdConditional.Location = new System.Drawing.Point(1276, 357);
            this.cmboInternetMessageIdConditional.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmboInternetMessageIdConditional.Name = "cmboInternetMessageIdConditional";
            this.cmboInternetMessageIdConditional.Size = new System.Drawing.Size(214, 33);
            this.cmboInternetMessageIdConditional.TabIndex = 35;
            // 
            // txtInternetMessageId
            // 
            this.txtInternetMessageId.Enabled = false;
            this.txtInternetMessageId.Location = new System.Drawing.Point(932, 360);
            this.txtInternetMessageId.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtInternetMessageId.Name = "txtInternetMessageId";
            this.txtInternetMessageId.Size = new System.Drawing.Size(332, 31);
            this.txtInternetMessageId.TabIndex = 34;
            // 
            // chkInternetMessageId
            // 
            this.chkInternetMessageId.AutoSize = true;
            this.chkInternetMessageId.Enabled = false;
            this.chkInternetMessageId.Location = new System.Drawing.Point(755, 363);
            this.chkInternetMessageId.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chkInternetMessageId.Name = "chkInternetMessageId";
            this.chkInternetMessageId.Size = new System.Drawing.Size(155, 29);
            this.chkInternetMessageId.TabIndex = 33;
            this.chkInternetMessageId.Text = "Message Id";
            this.chkInternetMessageId.UseVisualStyleBackColor = true;
            this.chkInternetMessageId.CheckedChanged += new System.EventHandler(this.chkInternetMessageId_CheckedChanged);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1754, 891);
            this.Controls.Add(this.cmboInternetMessageIdConditional);
            this.Controls.Add(this.txtInternetMessageId);
            this.Controls.Add(this.chkInternetMessageId);
            this.Controls.Add(this.btnExportCalendarItems);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmboLogicalOperation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmboClassConditional);
            this.Controls.Add(this.cmboBodyConditional);
            this.Controls.Add(this.cmboCCConditional);
            this.Controls.Add(this.cmboToConditional);
            this.Controls.Add(this.cmboSubjectConditional);
            this.Controls.Add(this.cmboSearchDepth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.chkClass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPageSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdoFindItemSearch);
            this.Controls.Add(this.rdoAqsSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lvItems);
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
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "SearchForm";
            this.Text = "Search Items Form";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.mnuItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtClass;
        public System.Windows.Forms.CheckBox chkClass;
        public System.Windows.Forms.ComboBox cmboSearchDepth;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cmboSubjectConditional;
        public System.Windows.Forms.ComboBox cmboToConditional;
        public System.Windows.Forms.ComboBox cmboCCConditional;
        public System.Windows.Forms.ComboBox cmboBodyConditional;
        public System.Windows.Forms.ComboBox cmboClassConditional;
        public System.Windows.Forms.ComboBox cmboLogicalOperation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip mnuItems;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyItems;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveItems;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteItems;
        private System.Windows.Forms.ToolStripMenuItem mnuHardDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuSoftDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveToDeletedItems;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnExportCalendarItems;
        public System.Windows.Forms.ComboBox cmboInternetMessageIdConditional;
        public System.Windows.Forms.TextBox txtInternetMessageId;
        public System.Windows.Forms.CheckBox chkInternetMessageId;
    }
}