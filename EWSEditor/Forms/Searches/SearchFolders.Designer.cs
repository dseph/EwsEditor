namespace EWSEditor.Forms 
{
    partial class SearchFolders
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
            this.txtClass = new System.Windows.Forms.TextBox();
            this.chkClass = new System.Windows.Forms.CheckBox();
            this.numPageSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvItems = new System.Windows.Forms.ListView();
            this.mnuFolderStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuFolderStripFolderProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cmboSearchType = new System.Windows.Forms.ComboBox();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.chkDisplayName = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmboSearchDepth = new System.Windows.Forms.ComboBox();
            this.cmboClassConditional = new System.Windows.Forms.ComboBox();
            this.cmboDisplayNameConditional = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmboLogicalOperation = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).BeginInit();
            this.mnuFolderStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtClass
            // 
            this.txtClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClass.Enabled = false;
            this.txtClass.Location = new System.Drawing.Point(135, 52);
            this.txtClass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(400, 22);
            this.txtClass.TabIndex = 11;
            // 
            // chkClass
            // 
            this.chkClass.AutoSize = true;
            this.chkClass.Enabled = false;
            this.chkClass.Location = new System.Drawing.Point(11, 52);
            this.chkClass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkClass.Name = "chkClass";
            this.chkClass.Size = new System.Drawing.Size(64, 21);
            this.chkClass.TabIndex = 10;
            this.chkClass.Text = "Class";
            this.chkClass.UseVisualStyleBackColor = true;
            this.chkClass.CheckedChanged += new System.EventHandler(this.chkClass_CheckedChanged);
            // 
            // numPageSize
            // 
            this.numPageSize.Location = new System.Drawing.Point(386, 7);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Page Size:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(19, 144);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(153, 29);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvItems
            // 
            this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvItems.ContextMenuStrip = this.mnuFolderStrip;
            this.lvItems.FullRowSelect = true;
            this.lvItems.Location = new System.Drawing.Point(19, 190);
            this.lvItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(741, 179);
            this.lvItems.TabIndex = 17;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.DoubleClick += new System.EventHandler(this.lvItems_DoubleClick);
            // 
            // mnuFolderStrip
            // 
            this.mnuFolderStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuFolderStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFolderStripFolderProperties});
            this.mnuFolderStrip.Name = "mnuFolderStrip";
            this.mnuFolderStrip.Size = new System.Drawing.Size(195, 28);
            // 
            // mnuFolderStripFolderProperties
            // 
            this.mnuFolderStripFolderProperties.Name = "mnuFolderStripFolderProperties";
            this.mnuFolderStripFolderProperties.Size = new System.Drawing.Size(194, 24);
            this.mnuFolderStripFolderProperties.Text = "Folder Poperties...";
            this.mnuFolderStripFolderProperties.Click += new System.EventHandler(this.mnuFolderStripFolderProperties_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
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
            this.cmboSearchType.Location = new System.Drawing.Point(130, 9);
            this.cmboSearchType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmboSearchType.Name = "cmboSearchType";
            this.cmboSearchType.Size = new System.Drawing.Size(138, 24);
            this.cmboSearchType.TabIndex = 1;
            this.cmboSearchType.SelectedIndexChanged += new System.EventHandler(this.cmboSearchType_SelectedIndexChanged);
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDisplayName.Enabled = false;
            this.txtDisplayName.Location = new System.Drawing.Point(135, 80);
            this.txtDisplayName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(400, 22);
            this.txtDisplayName.TabIndex = 14;
            // 
            // chkDisplayName
            // 
            this.chkDisplayName.AutoSize = true;
            this.chkDisplayName.Enabled = false;
            this.chkDisplayName.Location = new System.Drawing.Point(12, 84);
            this.chkDisplayName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDisplayName.Name = "chkDisplayName";
            this.chkDisplayName.Size = new System.Drawing.Size(117, 21);
            this.chkDisplayName.TabIndex = 13;
            this.chkDisplayName.Text = "Display Name";
            this.chkDisplayName.UseVisualStyleBackColor = true;
            this.chkDisplayName.CheckedChanged += new System.EventHandler(this.chkSubject_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(552, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Depth:";
            // 
            // cmboSearchDepth
            // 
            this.cmboSearchDepth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboSearchDepth.FormattingEnabled = true;
            this.cmboSearchDepth.Items.AddRange(new object[] {
            "Shallow",
            "Deep"});
            this.cmboSearchDepth.Location = new System.Drawing.Point(608, 6);
            this.cmboSearchDepth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmboSearchDepth.Name = "cmboSearchDepth";
            this.cmboSearchDepth.Size = new System.Drawing.Size(126, 24);
            this.cmboSearchDepth.TabIndex = 5;
            this.cmboSearchDepth.SelectedIndexChanged += new System.EventHandler(this.cmboSearchDepth_SelectedIndexChanged);
            // 
            // cmboClassConditional
            // 
            this.cmboClassConditional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.cmboClassConditional.Location = new System.Drawing.Point(585, 48);
            this.cmboClassConditional.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmboClassConditional.Name = "cmboClassConditional";
            this.cmboClassConditional.Size = new System.Drawing.Size(181, 24);
            this.cmboClassConditional.TabIndex = 12;
            // 
            // cmboDisplayNameConditional
            // 
            this.cmboDisplayNameConditional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmboDisplayNameConditional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboDisplayNameConditional.FormattingEnabled = true;
            this.cmboDisplayNameConditional.Items.AddRange(new object[] {
            "ContainsSubstring",
            "IsEqualTo",
            "IsNotEqualTo",
            "IsGreaterThan",
            "IsLessThan",
            "IsGreaterThanOrEqualTo",
            "IsNotEqualTo"});
            this.cmboDisplayNameConditional.Location = new System.Drawing.Point(585, 80);
            this.cmboDisplayNameConditional.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmboDisplayNameConditional.Name = "cmboDisplayNameConditional";
            this.cmboDisplayNameConditional.Size = new System.Drawing.Size(181, 24);
            this.cmboDisplayNameConditional.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Logical Operation:";
            // 
            // cmboLogicalOperation
            // 
            this.cmboLogicalOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboLogicalOperation.FormattingEnabled = true;
            this.cmboLogicalOperation.Items.AddRange(new object[] {
            "And",
            "Or"});
            this.cmboLogicalOperation.Location = new System.Drawing.Point(145, 110);
            this.cmboLogicalOperation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmboLogicalOperation.Name = "cmboLogicalOperation";
            this.cmboLogicalOperation.Size = new System.Drawing.Size(126, 24);
            this.cmboLogicalOperation.TabIndex = 19;
            // 
            // SearchFolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 382);
            this.Controls.Add(this.cmboLogicalOperation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmboDisplayNameConditional);
            this.Controls.Add(this.cmboClassConditional);
            this.Controls.Add(this.cmboSearchDepth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.chkClass);
            this.Controls.Add(this.numPageSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lvItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmboSearchType);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.chkDisplayName);
            this.Name = "SearchFolders";
            this.Text = "Search Folders Form";
            this.Load += new System.EventHandler(this.SearchFolders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).EndInit();
            this.mnuFolderStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtClass;
        public System.Windows.Forms.CheckBox chkClass;
        private System.Windows.Forms.NumericUpDown numPageSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cmboSearchType;
        public System.Windows.Forms.TextBox txtDisplayName;
        public System.Windows.Forms.CheckBox chkDisplayName;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cmboSearchDepth;
        public System.Windows.Forms.ComboBox cmboClassConditional;
        public System.Windows.Forms.ComboBox cmboDisplayNameConditional;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cmboLogicalOperation;
        private System.Windows.Forms.ContextMenuStrip mnuFolderStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFolderStripFolderProperties;
    }
}