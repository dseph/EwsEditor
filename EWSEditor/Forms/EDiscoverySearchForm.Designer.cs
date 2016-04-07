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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EDiscoverySearchForm));
            this.lvItems = new System.Windows.Forms.ListView();
            this.txtSearchForMailboxes = new System.Windows.Forms.TextBox();
            this.chkExpandGroupMemberships = new System.Windows.Forms.CheckBox();
            this.btnListSearchableMailboxes = new System.Windows.Forms.Button();
            this.txtMailboxSearchString = new System.Windows.Forms.TextBox();
            this.btnMailboxSearch = new System.Windows.Forms.Button();
            this.lvMailboxes = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.numPageSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmboSearchLocation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearchResultType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lvItems
            // 
            this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvItems.Location = new System.Drawing.Point(45, 576);
            this.lvItems.Margin = new System.Windows.Forms.Padding(4);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(843, 170);
            this.lvItems.TabIndex = 19;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.SelectedIndexChanged += new System.EventHandler(this.lvItems_SelectedIndexChanged);
            this.lvItems.Click += new System.EventHandler(this.lvItems_Click);
            this.lvItems.DoubleClick += new System.EventHandler(this.lvItems_DoubleClick);
            // 
            // txtSearchForMailboxes
            // 
            this.txtSearchForMailboxes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchForMailboxes.Location = new System.Drawing.Point(39, 121);
            this.txtSearchForMailboxes.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchForMailboxes.MaxLength = 0;
            this.txtSearchForMailboxes.Multiline = true;
            this.txtSearchForMailboxes.Name = "txtSearchForMailboxes";
            this.txtSearchForMailboxes.Size = new System.Drawing.Size(849, 61);
            this.txtSearchForMailboxes.TabIndex = 4;
            this.txtSearchForMailboxes.TextChanged += new System.EventHandler(this.txtSearchForMailboxes_TextChanged);
            // 
            // chkExpandGroupMemberships
            // 
            this.chkExpandGroupMemberships.AutoSize = true;
            this.chkExpandGroupMemberships.Location = new System.Drawing.Point(16, 72);
            this.chkExpandGroupMemberships.Margin = new System.Windows.Forms.Padding(4);
            this.chkExpandGroupMemberships.Name = "chkExpandGroupMemberships";
            this.chkExpandGroupMemberships.Size = new System.Drawing.Size(209, 21);
            this.chkExpandGroupMemberships.TabIndex = 2;
            this.chkExpandGroupMemberships.Text = "Expand Group Memberships";
            this.chkExpandGroupMemberships.UseVisualStyleBackColor = true;
            // 
            // btnListSearchableMailboxes
            // 
            this.btnListSearchableMailboxes.Location = new System.Drawing.Point(13, 190);
            this.btnListSearchableMailboxes.Margin = new System.Windows.Forms.Padding(4);
            this.btnListSearchableMailboxes.Name = "btnListSearchableMailboxes";
            this.btnListSearchableMailboxes.Size = new System.Drawing.Size(195, 28);
            this.btnListSearchableMailboxes.TabIndex = 5;
            this.btnListSearchableMailboxes.Text = "List Searchable Mailboxes";
            this.btnListSearchableMailboxes.UseVisualStyleBackColor = true;
            this.btnListSearchableMailboxes.Click += new System.EventHandler(this.btnListSearchableMailboxes_Click);
            // 
            // txtMailboxSearchString
            // 
            this.txtMailboxSearchString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMailboxSearchString.Location = new System.Drawing.Point(39, 431);
            this.txtMailboxSearchString.Margin = new System.Windows.Forms.Padding(4);
            this.txtMailboxSearchString.MaxLength = 0;
            this.txtMailboxSearchString.Multiline = true;
            this.txtMailboxSearchString.Name = "txtMailboxSearchString";
            this.txtMailboxSearchString.Size = new System.Drawing.Size(849, 79);
            this.txtMailboxSearchString.TabIndex = 16;
            // 
            // btnMailboxSearch
            // 
            this.btnMailboxSearch.Location = new System.Drawing.Point(13, 518);
            this.btnMailboxSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnMailboxSearch.Name = "btnMailboxSearch";
            this.btnMailboxSearch.Size = new System.Drawing.Size(164, 28);
            this.btnMailboxSearch.TabIndex = 17;
            this.btnMailboxSearch.Text = "Mailbox Search";
            this.btnMailboxSearch.UseVisualStyleBackColor = true;
            this.btnMailboxSearch.Click += new System.EventHandler(this.btnMailboxSearch_Click);
            // 
            // lvMailboxes
            // 
            this.lvMailboxes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMailboxes.Location = new System.Drawing.Point(41, 243);
            this.lvMailboxes.Margin = new System.Windows.Forms.Padding(4);
            this.lvMailboxes.Name = "lvMailboxes";
            this.lvMailboxes.Size = new System.Drawing.Size(847, 103);
            this.lvMailboxes.TabIndex = 7;
            this.lvMailboxes.UseCompatibleStateImageBehavior = false;
            this.lvMailboxes.SelectedIndexChanged += new System.EventHandler(this.lvMailboxes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 410);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Search string:";
            // 
            // numPageSize
            // 
            this.numPageSize.Location = new System.Drawing.Point(443, 379);
            this.numPageSize.Margin = new System.Windows.Forms.Padding(4);
            this.numPageSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPageSize.Name = "numPageSize";
            this.numPageSize.Size = new System.Drawing.Size(105, 22);
            this.numPageSize.TabIndex = 12;
            this.numPageSize.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 382);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Page Size:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 380);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 9;
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
            this.cmboSearchLocation.Location = new System.Drawing.Point(163, 379);
            this.cmboSearchLocation.Margin = new System.Windows.Forms.Padding(4);
            this.cmboSearchLocation.Name = "cmboSearchLocation";
            this.cmboSearchLocation.Size = new System.Drawing.Size(175, 24);
            this.cmboSearchLocation.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(573, 382);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 17);
            this.label5.TabIndex = 13;
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
            this.txtSearchResultType.Location = new System.Drawing.Point(710, 379);
            this.txtSearchResultType.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchResultType.Name = "txtSearchResultType";
            this.txtSearchResultType.Size = new System.Drawing.Size(167, 24);
            this.txtSearchResultType.TabIndex = 14;
            this.txtSearchResultType.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 222);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Mailboxes Found:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 351);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(615, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Note: Select a mailbox above.  Next enter criteria to search on below then click " +
    "\"Mailbox Search\".";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 555);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Results:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 51);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(602, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Note: Enter search criteria to find searchable mailboxes then click \"List Searcha" +
    "ble Mailboxes\".";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 100);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "Search string:";
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInfo.Location = new System.Drawing.Point(13, 7);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtInfo.MaxLength = 0;
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(864, 40);
            this.txtInfo.TabIndex = 0;
            this.txtInfo.Text = resources.GetString("txtInfo.Text");
            // 
            // EDiscoverySearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 752);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSearchResultType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmboSearchLocation);
            this.Controls.Add(this.numPageSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvMailboxes);
            this.Controls.Add(this.txtSearchForMailboxes);
            this.Controls.Add(this.chkExpandGroupMemberships);
            this.Controls.Add(this.btnListSearchableMailboxes);
            this.Controls.Add(this.txtMailboxSearchString);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnMailboxSearch);
            this.Controls.Add(this.lvItems);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.NumericUpDown numPageSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cmboSearchLocation;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox txtSearchResultType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtInfo;
    }
}