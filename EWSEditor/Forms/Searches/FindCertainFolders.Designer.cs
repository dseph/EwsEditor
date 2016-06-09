namespace EWSEditor.Forms.Searches
{
    partial class FindCertainFolders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindCertainFolders));
            this.txtMailboxes = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.chkClass = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkName = new System.Windows.Forms.CheckBox();
            this.rdoDisplayHere = new System.Windows.Forms.RadioButton();
            this.rdoSaveToCsvFile = new System.Windows.Forms.RadioButton();
            this.txtCsvFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lvFolders = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMailboxes
            // 
            this.txtMailboxes.Location = new System.Drawing.Point(12, 65);
            this.txtMailboxes.MaxLength = 0;
            this.txtMailboxes.Multiline = true;
            this.txtMailboxes.Name = "txtMailboxes";
            this.txtMailboxes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMailboxes.Size = new System.Drawing.Size(642, 122);
            this.txtMailboxes.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(692, 152);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(184, 35);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtClass
            // 
            this.txtClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClass.Enabled = false;
            this.txtClass.Location = new System.Drawing.Point(114, 281);
            this.txtClass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(762, 26);
            this.txtClass.TabIndex = 20;
            // 
            // chkClass
            // 
            this.chkClass.AutoSize = true;
            this.chkClass.Enabled = false;
            this.chkClass.Location = new System.Drawing.Point(30, 281);
            this.chkClass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkClass.Name = "chkClass";
            this.chkClass.Size = new System.Drawing.Size(74, 24);
            this.chkClass.TabIndex = 19;
            this.chkClass.Text = "Class";
            this.chkClass.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(115, 245);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(761, 26);
            this.txtName.TabIndex = 18;
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.Enabled = false;
            this.chkName.Location = new System.Drawing.Point(30, 247);
            this.chkName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(77, 24);
            this.chkName.TabIndex = 17;
            this.chkName.Text = "Name";
            this.chkName.UseVisualStyleBackColor = true;
            // 
            // rdoDisplayHere
            // 
            this.rdoDisplayHere.AutoSize = true;
            this.rdoDisplayHere.Location = new System.Drawing.Point(30, 381);
            this.rdoDisplayHere.Name = "rdoDisplayHere";
            this.rdoDisplayHere.Size = new System.Drawing.Size(128, 24);
            this.rdoDisplayHere.TabIndex = 26;
            this.rdoDisplayHere.TabStop = true;
            this.rdoDisplayHere.Text = "Display Here:";
            this.rdoDisplayHere.UseVisualStyleBackColor = true;
            this.rdoDisplayHere.CheckedChanged += new System.EventHandler(this.rdoDisplayHere_CheckedChanged);
            // 
            // rdoSaveToCsvFile
            // 
            this.rdoSaveToCsvFile.AutoSize = true;
            this.rdoSaveToCsvFile.Location = new System.Drawing.Point(30, 351);
            this.rdoSaveToCsvFile.Name = "rdoSaveToCsvFile";
            this.rdoSaveToCsvFile.Size = new System.Drawing.Size(153, 24);
            this.rdoSaveToCsvFile.TabIndex = 27;
            this.rdoSaveToCsvFile.TabStop = true;
            this.rdoSaveToCsvFile.Text = "Save to CSV file:";
            this.rdoSaveToCsvFile.UseVisualStyleBackColor = true;
            this.rdoSaveToCsvFile.CheckedChanged += new System.EventHandler(this.rdoSaveToCsvFile_CheckedChanged);
            // 
            // txtCsvFilePath
            // 
            this.txtCsvFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCsvFilePath.Enabled = false;
            this.txtCsvFilePath.Location = new System.Drawing.Point(206, 351);
            this.txtCsvFilePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCsvFilePath.Name = "txtCsvFilePath";
            this.txtCsvFilePath.Size = new System.Drawing.Size(670, 26);
            this.txtCsvFilePath.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Output:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Search On:";
            // 
            // lvFolders
            // 
            this.lvFolders.Location = new System.Drawing.Point(45, 420);
            this.lvFolders.Name = "lvFolders";
            this.lvFolders.Size = new System.Drawing.Size(822, 180);
            this.lvFolders.TabIndex = 32;
            this.lvFolders.UseCompatibleStateImageBehavior = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(10, 3);
            this.textBox1.MaxLength = 0;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(866, 56);
            this.textBox1.TabIndex = 33;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // FindCertainFolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 612);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lvFolders);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCsvFilePath);
            this.Controls.Add(this.rdoSaveToCsvFile);
            this.Controls.Add(this.rdoDisplayHere);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.chkClass);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.chkName);
            this.Controls.Add(this.txtMailboxes);
            this.Name = "FindCertainFolders";
            this.Text = "FindCertainFolders";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMailboxes;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.TextBox txtClass;
        public System.Windows.Forms.CheckBox chkClass;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.CheckBox chkName;
        private System.Windows.Forms.RadioButton rdoDisplayHere;
        private System.Windows.Forms.RadioButton rdoSaveToCsvFile;
        public System.Windows.Forms.TextBox txtCsvFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvFolders;
        private System.Windows.Forms.TextBox textBox1;
    }
}