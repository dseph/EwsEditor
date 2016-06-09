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
            this.label4 = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.chkClass = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
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
            this.cmboSearchType.Location = new System.Drawing.Point(149, 14);
            this.cmboSearchType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmboSearchType.Name = "cmboSearchType";
            this.cmboSearchType.Size = new System.Drawing.Size(180, 28);
            this.cmboSearchType.TabIndex = 1;
            // 
            // txtAQS
            // 
            this.txtAQS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAQS.Enabled = false;
            this.txtAQS.Location = new System.Drawing.Point(43, 113);
            this.txtAQS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAQS.Multiline = true;
            this.txtAQS.Name = "txtAQS";
            this.txtAQS.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAQS.Size = new System.Drawing.Size(874, 92);
            this.txtAQS.TabIndex = 6;
            // 
            // txtBody
            // 
            this.txtBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBody.Enabled = false;
            this.txtBody.Location = new System.Drawing.Point(147, 354);
            this.txtBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(774, 26);
            this.txtBody.TabIndex = 15;
            // 
            // chkBody
            // 
            this.chkBody.AutoSize = true;
            this.chkBody.Enabled = false;
            this.chkBody.Location = new System.Drawing.Point(45, 356);
            this.chkBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkBody.Name = "chkBody";
            this.chkBody.Size = new System.Drawing.Size(71, 24);
            this.chkBody.TabIndex = 14;
            this.chkBody.Text = "Body";
            this.chkBody.UseVisualStyleBackColor = true;
            this.chkBody.CheckedChanged += new System.EventHandler(this.chkBody_CheckedChanged);
            // 
            // txtCC
            // 
            this.txtCC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCC.Enabled = false;
            this.txtCC.Location = new System.Drawing.Point(147, 318);
            this.txtCC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(774, 26);
            this.txtCC.TabIndex = 13;
            // 
            // chkCC
            // 
            this.chkCC.AutoSize = true;
            this.chkCC.Enabled = false;
            this.chkCC.Location = new System.Drawing.Point(45, 318);
            this.chkCC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkCC.Name = "chkCC";
            this.chkCC.Size = new System.Drawing.Size(57, 24);
            this.chkCC.TabIndex = 12;
            this.chkCC.Text = "CC";
            this.chkCC.UseVisualStyleBackColor = true;
            this.chkCC.CheckedChanged += new System.EventHandler(this.chkCC_CheckedChanged);
            // 
            // txtTo
            // 
            this.txtTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTo.Enabled = false;
            this.txtTo.Location = new System.Drawing.Point(147, 282);
            this.txtTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(774, 26);
            this.txtTo.TabIndex = 11;
            // 
            // chkTo
            // 
            this.chkTo.AutoSize = true;
            this.chkTo.Enabled = false;
            this.chkTo.Location = new System.Drawing.Point(45, 280);
            this.chkTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTo.Name = "chkTo";
            this.chkTo.Size = new System.Drawing.Size(53, 24);
            this.chkTo.TabIndex = 10;
            this.chkTo.Text = "To";
            this.chkTo.UseVisualStyleBackColor = true;
            this.chkTo.CheckedChanged += new System.EventHandler(this.chkTo_CheckedChanged);
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Enabled = false;
            this.txtSubject.Location = new System.Drawing.Point(148, 246);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(774, 26);
            this.txtSubject.TabIndex = 9;
            // 
            // chkSubject
            // 
            this.chkSubject.AutoSize = true;
            this.chkSubject.Enabled = false;
            this.chkSubject.Location = new System.Drawing.Point(45, 246);
            this.chkSubject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkSubject.Name = "chkSubject";
            this.chkSubject.Size = new System.Drawing.Size(89, 24);
            this.chkSubject.TabIndex = 8;
            this.chkSubject.Text = "Subject";
            this.chkSubject.UseVisualStyleBackColor = true;
            this.chkSubject.CheckedChanged += new System.EventHandler(this.chkSubject_CheckedChanged);
            // 
            // lvItems
            // 
            this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvItems.FullRowSelect = true;
            this.lvItems.Location = new System.Drawing.Point(45, 477);
            this.lvItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(876, 130);
            this.lvItems.TabIndex = 19;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.SelectedIndexChanged += new System.EventHandler(this.lvItems_SelectedIndexChanged);
            this.lvItems.DoubleClick += new System.EventHandler(this.lvItems_DoubleClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(13, 432);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(184, 35);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rdoAqsSearch
            // 
            this.rdoAqsSearch.AutoSize = true;
            this.rdoAqsSearch.Checked = true;
            this.rdoAqsSearch.Location = new System.Drawing.Point(13, 81);
            this.rdoAqsSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoAqsSearch.Name = "rdoAqsSearch";
            this.rdoAqsSearch.Size = new System.Drawing.Size(123, 24);
            this.rdoAqsSearch.TabIndex = 5;
            this.rdoAqsSearch.TabStop = true;
            this.rdoAqsSearch.Text = "AQS Search";
            this.rdoAqsSearch.UseVisualStyleBackColor = true;
            this.rdoAqsSearch.CheckedChanged += new System.EventHandler(this.rdoAqsSearch_CheckedChanged);
            // 
            // rdoFindItemSearch
            // 
            this.rdoFindItemSearch.AutoSize = true;
            this.rdoFindItemSearch.Location = new System.Drawing.Point(14, 215);
            this.rdoFindItemSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoFindItemSearch.Name = "rdoFindItemSearch";
            this.rdoFindItemSearch.Size = new System.Drawing.Size(156, 24);
            this.rdoFindItemSearch.TabIndex = 7;
            this.rdoFindItemSearch.Text = "Find Item Search";
            this.rdoFindItemSearch.UseVisualStyleBackColor = true;
            this.rdoFindItemSearch.CheckedChanged += new System.EventHandler(this.rdoFindItemSearch_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Page Size:";
            // 
            // numPageSize
            // 
            this.numPageSize.Location = new System.Drawing.Point(456, 12);
            this.numPageSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numPageSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPageSize.Name = "numPageSize";
            this.numPageSize.Size = new System.Drawing.Size(180, 26);
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
            this.label3.Location = new System.Drawing.Point(13, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(628, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Note:  Exchange Online may limit AQS results to 250 items due to default policy s" +
    "ettings.";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 610);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(425, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Note:  Double click a result for more properties and options.";
            // 
            // txtClass
            // 
            this.txtClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClass.Enabled = false;
            this.txtClass.Location = new System.Drawing.Point(147, 388);
            this.txtClass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(774, 26);
            this.txtClass.TabIndex = 17;
            // 
            // chkClass
            // 
            this.chkClass.AutoSize = true;
            this.chkClass.Enabled = false;
            this.chkClass.Location = new System.Drawing.Point(43, 390);
            this.chkClass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkClass.Name = "chkClass";
            this.chkClass.Size = new System.Drawing.Size(74, 24);
            this.chkClass.TabIndex = 16;
            this.chkClass.Text = "Class";
            this.chkClass.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(938, 632);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SearchForm";
            this.Text = "Search Form";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).EndInit();
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
    }
}