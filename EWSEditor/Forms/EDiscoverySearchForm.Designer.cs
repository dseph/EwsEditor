namespace EWSEditor.Forms
{
    partial class EDiscoverySearchForm
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
            this.lvItems = new System.Windows.Forms.ListView();
            this.txtSearchForMailboxes = new System.Windows.Forms.TextBox();
            this.chkExpandGroupMemberships = new System.Windows.Forms.CheckBox();
            this.btnListSearchableMailboxes = new System.Windows.Forms.Button();
            this.txtMailboxSearchString = new System.Windows.Forms.TextBox();
            this.btnMailboxSearch = new System.Windows.Forms.Button();
            this.lvMailboxes = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numPageSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmboSearchLocation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearchResultType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lvItems
            // 
            this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvItems.Location = new System.Drawing.Point(1, 471);
            this.lvItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(1133, 185);
            this.lvItems.TabIndex = 14;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.SelectedIndexChanged += new System.EventHandler(this.lvItems_SelectedIndexChanged);
            this.lvItems.Click += new System.EventHandler(this.lvItems_Click);
            this.lvItems.DoubleClick += new System.EventHandler(this.lvItems_DoubleClick);
            // 
            // txtSearchForMailboxes
            // 
            this.txtSearchForMailboxes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchForMailboxes.Location = new System.Drawing.Point(85, 48);
            this.txtSearchForMailboxes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearchForMailboxes.MaxLength = 0;
            this.txtSearchForMailboxes.Multiline = true;
            this.txtSearchForMailboxes.Name = "txtSearchForMailboxes";
            this.txtSearchForMailboxes.Size = new System.Drawing.Size(1049, 52);
            this.txtSearchForMailboxes.TabIndex = 3;
            // 
            // chkExpandGroupMemberships
            // 
            this.chkExpandGroupMemberships.AutoSize = true;
            this.chkExpandGroupMemberships.Location = new System.Drawing.Point(239, 20);
            this.chkExpandGroupMemberships.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkExpandGroupMemberships.Name = "chkExpandGroupMemberships";
            this.chkExpandGroupMemberships.Size = new System.Drawing.Size(209, 21);
            this.chkExpandGroupMemberships.TabIndex = 1;
            this.chkExpandGroupMemberships.Text = "Expand Group Memberships";
            this.chkExpandGroupMemberships.UseVisualStyleBackColor = true;
            // 
            // btnListSearchableMailboxes
            // 
            this.btnListSearchableMailboxes.Location = new System.Drawing.Point(16, 15);
            this.btnListSearchableMailboxes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnListSearchableMailboxes.Name = "btnListSearchableMailboxes";
            this.btnListSearchableMailboxes.Size = new System.Drawing.Size(195, 28);
            this.btnListSearchableMailboxes.TabIndex = 0;
            this.btnListSearchableMailboxes.Text = "List Searchable Mailboxes";
            this.btnListSearchableMailboxes.UseVisualStyleBackColor = true;
            this.btnListSearchableMailboxes.Click += new System.EventHandler(this.btnListSearchableMailboxes_Click);
            // 
            // txtMailboxSearchString
            // 
            this.txtMailboxSearchString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMailboxSearchString.Location = new System.Drawing.Point(81, 372);
            this.txtMailboxSearchString.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMailboxSearchString.MaxLength = 0;
            this.txtMailboxSearchString.Multiline = true;
            this.txtMailboxSearchString.Name = "txtMailboxSearchString";
            this.txtMailboxSearchString.Size = new System.Drawing.Size(1053, 91);
            this.txtMailboxSearchString.TabIndex = 13;
            // 
            // btnMailboxSearch
            // 
            this.btnMailboxSearch.Location = new System.Drawing.Point(16, 336);
            this.btnMailboxSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMailboxSearch.Name = "btnMailboxSearch";
            this.btnMailboxSearch.Size = new System.Drawing.Size(164, 28);
            this.btnMailboxSearch.TabIndex = 5;
            this.btnMailboxSearch.Text = "Mailbox Search";
            this.btnMailboxSearch.UseVisualStyleBackColor = true;
            this.btnMailboxSearch.Click += new System.EventHandler(this.btnMailboxSearch_Click);
            // 
            // lvMailboxes
            // 
            this.lvMailboxes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMailboxes.Location = new System.Drawing.Point(1, 108);
            this.lvMailboxes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvMailboxes.Name = "lvMailboxes";
            this.lvMailboxes.Size = new System.Drawing.Size(1133, 202);
            this.lvMailboxes.TabIndex = 4;
            this.lvMailboxes.UseCompatibleStateImageBehavior = false;
            this.lvMailboxes.SelectedIndexChanged += new System.EventHandler(this.lvMailboxes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 375);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Search:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Search:";
            // 
            // numPageSize
            // 
            this.numPageSize.Location = new System.Drawing.Point(609, 336);
            this.numPageSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numPageSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPageSize.Name = "numPageSize";
            this.numPageSize.Size = new System.Drawing.Size(160, 22);
            this.numPageSize.TabIndex = 9;
            this.numPageSize.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(524, 340);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Page Size:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 347);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search Location:";
            // 
            // cmboSearchLocation
            // 
            this.cmboSearchLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboSearchLocation.FormattingEnabled = true;
            this.cmboSearchLocation.Items.AddRange(new object[] {
            "PrimaryOnly",
            "ArchiveOnly",
            "All"});
            this.cmboSearchLocation.Location = new System.Drawing.Point(313, 340);
            this.cmboSearchLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmboSearchLocation.Name = "cmboSearchLocation";
            this.cmboSearchLocation.Size = new System.Drawing.Size(175, 24);
            this.cmboSearchLocation.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(800, 342);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "SearchResultType:";
            this.label5.Visible = false;
            // 
            // txtSearchResultType
            // 
            this.txtSearchResultType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSearchResultType.FormattingEnabled = true;
            this.txtSearchResultType.Items.AddRange(new object[] {
            "PreviewOnly",
            "StatisticsOnly"});
            this.txtSearchResultType.Location = new System.Drawing.Point(955, 336);
            this.txtSearchResultType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearchResultType.Name = "txtSearchResultType";
            this.txtSearchResultType.Size = new System.Drawing.Size(167, 24);
            this.txtSearchResultType.TabIndex = 11;
            this.txtSearchResultType.Visible = false;
            // 
            // EDiscoverySearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 672);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSearchResultType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmboSearchLocation);
            this.Controls.Add(this.numPageSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvMailboxes);
            this.Controls.Add(this.txtSearchForMailboxes);
            this.Controls.Add(this.chkExpandGroupMemberships);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnListSearchableMailboxes);
            this.Controls.Add(this.txtMailboxSearchString);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnMailboxSearch);
            this.Controls.Add(this.lvItems);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EDiscoverySearchForm";
            this.Text = "eDiscoverySearchForm";
            this.Load += new System.EventHandler(this.EDiscoverySearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvItems;
        public System.Windows.Forms.TextBox txtSearchForMailboxes;
        public System.Windows.Forms.CheckBox chkExpandGroupMemberships;
        private System.Windows.Forms.Button btnListSearchableMailboxes;
        public System.Windows.Forms.TextBox txtMailboxSearchString;
        private System.Windows.Forms.Button btnMailboxSearch;
        private System.Windows.Forms.ListView lvMailboxes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numPageSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cmboSearchLocation;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox txtSearchResultType;
    }
}