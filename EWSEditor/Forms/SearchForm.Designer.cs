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
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Search Type:";
            // 
            // cmboSearchType
            // 
            this.cmboSearchType.FormattingEnabled = true;
            this.cmboSearchType.Items.AddRange(new object[] {
            "Direct",
            "More Available"});
            this.cmboSearchType.Location = new System.Drawing.Point(112, 12);
            this.cmboSearchType.Name = "cmboSearchType";
            this.cmboSearchType.Size = new System.Drawing.Size(121, 21);
            this.cmboSearchType.TabIndex = 30;
            this.cmboSearchType.Text = "More Available";
            // 
            // txtAQS
            // 
            this.txtAQS.Enabled = false;
            this.txtAQS.Location = new System.Drawing.Point(38, 71);
            this.txtAQS.Name = "txtAQS";
            this.txtAQS.Size = new System.Drawing.Size(559, 20);
            this.txtAQS.TabIndex = 29;
            // 
            // txtBody
            // 
            this.txtBody.Enabled = false;
            this.txtBody.Location = new System.Drawing.Point(124, 212);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(310, 20);
            this.txtBody.TabIndex = 24;
            // 
            // chkBody
            // 
            this.chkBody.AutoSize = true;
            this.chkBody.Enabled = false;
            this.chkBody.Location = new System.Drawing.Point(38, 215);
            this.chkBody.Name = "chkBody";
            this.chkBody.Size = new System.Drawing.Size(50, 17);
            this.chkBody.TabIndex = 23;
            this.chkBody.Text = "Body";
            this.chkBody.UseVisualStyleBackColor = true;
            this.chkBody.CheckedChanged += new System.EventHandler(this.chkBody_CheckedChanged);
            // 
            // txtCC
            // 
            this.txtCC.Enabled = false;
            this.txtCC.Location = new System.Drawing.Point(124, 186);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(310, 20);
            this.txtCC.TabIndex = 22;
            // 
            // chkCC
            // 
            this.chkCC.AutoSize = true;
            this.chkCC.Enabled = false;
            this.chkCC.Location = new System.Drawing.Point(38, 189);
            this.chkCC.Name = "chkCC";
            this.chkCC.Size = new System.Drawing.Size(40, 17);
            this.chkCC.TabIndex = 21;
            this.chkCC.Text = "CC";
            this.chkCC.UseVisualStyleBackColor = true;
            this.chkCC.CheckedChanged += new System.EventHandler(this.chkCC_CheckedChanged);
            // 
            // txtTo
            // 
            this.txtTo.Enabled = false;
            this.txtTo.Location = new System.Drawing.Point(124, 160);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(310, 20);
            this.txtTo.TabIndex = 20;
            // 
            // chkTo
            // 
            this.chkTo.AutoSize = true;
            this.chkTo.Enabled = false;
            this.chkTo.Location = new System.Drawing.Point(38, 163);
            this.chkTo.Name = "chkTo";
            this.chkTo.Size = new System.Drawing.Size(39, 17);
            this.chkTo.TabIndex = 19;
            this.chkTo.Text = "To";
            this.chkTo.UseVisualStyleBackColor = true;
            this.chkTo.CheckedChanged += new System.EventHandler(this.chkTo_CheckedChanged);
            // 
            // txtSubject
            // 
            this.txtSubject.Enabled = false;
            this.txtSubject.Location = new System.Drawing.Point(124, 134);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(310, 20);
            this.txtSubject.TabIndex = 18;
            // 
            // chkSubject
            // 
            this.chkSubject.AutoSize = true;
            this.chkSubject.Enabled = false;
            this.chkSubject.Location = new System.Drawing.Point(38, 137);
            this.chkSubject.Name = "chkSubject";
            this.chkSubject.Size = new System.Drawing.Size(62, 17);
            this.chkSubject.TabIndex = 17;
            this.chkSubject.Text = "Subject";
            this.chkSubject.UseVisualStyleBackColor = true;
            this.chkSubject.CheckedChanged += new System.EventHandler(this.chkSubject_CheckedChanged);
            // 
            // lvItems
            // 
            this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvItems.Location = new System.Drawing.Point(2, 248);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(958, 325);
            this.lvItems.TabIndex = 32;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(825, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(123, 23);
            this.btnSearch.TabIndex = 33;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rdoAqsSearch
            // 
            this.rdoAqsSearch.AutoSize = true;
            this.rdoAqsSearch.Checked = true;
            this.rdoAqsSearch.Location = new System.Drawing.Point(22, 48);
            this.rdoAqsSearch.Name = "rdoAqsSearch";
            this.rdoAqsSearch.Size = new System.Drawing.Size(84, 17);
            this.rdoAqsSearch.TabIndex = 34;
            this.rdoAqsSearch.TabStop = true;
            this.rdoAqsSearch.Text = "AQS Search";
            this.rdoAqsSearch.UseVisualStyleBackColor = true;
            this.rdoAqsSearch.CheckedChanged += new System.EventHandler(this.rdoAqsSearch_CheckedChanged);
            // 
            // rdoFindItemSearch
            // 
            this.rdoFindItemSearch.AutoSize = true;
            this.rdoFindItemSearch.Location = new System.Drawing.Point(20, 104);
            this.rdoFindItemSearch.Name = "rdoFindItemSearch";
            this.rdoFindItemSearch.Size = new System.Drawing.Size(105, 17);
            this.rdoFindItemSearch.TabIndex = 35;
            this.rdoFindItemSearch.Text = "Find Item Search";
            this.rdoFindItemSearch.UseVisualStyleBackColor = true;
            this.rdoFindItemSearch.CheckedChanged += new System.EventHandler(this.rdoFindItemSearch_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Page Size:";
            // 
            // numPageSize
            // 
            this.numPageSize.Location = new System.Drawing.Point(358, 12);
            this.numPageSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPageSize.Name = "numPageSize";
            this.numPageSize.Size = new System.Drawing.Size(120, 20);
            this.numPageSize.TabIndex = 38;
            this.numPageSize.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 574);
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
    }
}