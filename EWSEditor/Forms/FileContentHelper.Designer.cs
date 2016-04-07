namespace EWSEditor.Forms
{
    partial class FileContentHelper
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
            this.txtLoad = new System.Windows.Forms.TextBox();
            this.btnLoadFileSelect = new System.Windows.Forms.Button();
            this.txtLoadFile = new System.Windows.Forms.TextBox();
            this.lblLoadFile = new System.Windows.Forms.Label();
            this.btnSaveFileSelect = new System.Windows.Forms.Button();
            this.txtSaveFile = new System.Windows.Forms.TextBox();
            this.lblSaveFile = new System.Windows.Forms.Label();
            this.txtSave = new System.Windows.Forms.TextBox();
            this.cmboSaveType = new System.Windows.Forms.ComboBox();
            this.lblSaveType = new System.Windows.Forms.Label();
            this.lblLoadType = new System.Windows.Forms.Label();
            this.cmboLoadType = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnSaveFileGo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLoad
            // 
            this.txtLoad.Font = new System.Drawing.Font("Courier New", 7.8F);
            this.txtLoad.Location = new System.Drawing.Point(13, 50);
            this.txtLoad.Margin = new System.Windows.Forms.Padding(4);
            this.txtLoad.MaxLength = 0;
            this.txtLoad.Multiline = true;
            this.txtLoad.Name = "txtLoad";
            this.txtLoad.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLoad.Size = new System.Drawing.Size(1183, 256);
            this.txtLoad.TabIndex = 5;
            // 
            // btnLoadFileSelect
            // 
            this.btnLoadFileSelect.Location = new System.Drawing.Point(1102, 15);
            this.btnLoadFileSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadFileSelect.Name = "btnLoadFileSelect";
            this.btnLoadFileSelect.Size = new System.Drawing.Size(36, 23);
            this.btnLoadFileSelect.TabIndex = 15;
            this.btnLoadFileSelect.Text = "...";
            this.btnLoadFileSelect.UseVisualStyleBackColor = true;
            this.btnLoadFileSelect.Click += new System.EventHandler(this.btnLoadFileSelect_Click);
            // 
            // txtLoadFile
            // 
            this.txtLoadFile.Location = new System.Drawing.Point(399, 15);
            this.txtLoadFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoadFile.Name = "txtLoadFile";
            this.txtLoadFile.Size = new System.Drawing.Size(697, 22);
            this.txtLoadFile.TabIndex = 13;
            // 
            // lblLoadFile
            // 
            this.lblLoadFile.AutoSize = true;
            this.lblLoadFile.Location = new System.Drawing.Point(292, 18);
            this.lblLoadFile.Name = "lblLoadFile";
            this.lblLoadFile.Size = new System.Drawing.Size(98, 17);
            this.lblLoadFile.TabIndex = 14;
            this.lblLoadFile.Text = "Load from file:";
            this.lblLoadFile.Click += new System.EventHandler(this.lblFromFile_Click);
            // 
            // btnSaveFileSelect
            // 
            this.btnSaveFileSelect.Location = new System.Drawing.Point(1102, 6);
            this.btnSaveFileSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveFileSelect.Name = "btnSaveFileSelect";
            this.btnSaveFileSelect.Size = new System.Drawing.Size(36, 23);
            this.btnSaveFileSelect.TabIndex = 20;
            this.btnSaveFileSelect.Text = "...";
            this.btnSaveFileSelect.UseVisualStyleBackColor = true;
            this.btnSaveFileSelect.Click += new System.EventHandler(this.btnSaveFileSelect_Click);
            // 
            // txtSaveFile
            // 
            this.txtSaveFile.Location = new System.Drawing.Point(399, 6);
            this.txtSaveFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSaveFile.Name = "txtSaveFile";
            this.txtSaveFile.Size = new System.Drawing.Size(697, 22);
            this.txtSaveFile.TabIndex = 18;
            // 
            // lblSaveFile
            // 
            this.lblSaveFile.AutoSize = true;
            this.lblSaveFile.Location = new System.Drawing.Point(292, 11);
            this.lblSaveFile.Name = "lblSaveFile";
            this.lblSaveFile.Size = new System.Drawing.Size(82, 17);
            this.lblSaveFile.TabIndex = 19;
            this.lblSaveFile.Text = "Save to file:";
            // 
            // txtSave
            // 
            this.txtSave.Font = new System.Drawing.Font("Courier New", 7.8F);
            this.txtSave.Location = new System.Drawing.Point(9, 42);
            this.txtSave.Margin = new System.Windows.Forms.Padding(4);
            this.txtSave.MaxLength = 0;
            this.txtSave.Multiline = true;
            this.txtSave.Name = "txtSave";
            this.txtSave.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSave.Size = new System.Drawing.Size(1187, 266);
            this.txtSave.TabIndex = 16;
            // 
            // cmboSaveType
            // 
            this.cmboSaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboSaveType.FormattingEnabled = true;
            this.cmboSaveType.Items.AddRange(new object[] {
            "BASE64",
            "Hex Bytes"});
            this.cmboSaveType.Location = new System.Drawing.Point(92, 7);
            this.cmboSaveType.Margin = new System.Windows.Forms.Padding(4);
            this.cmboSaveType.Name = "cmboSaveType";
            this.cmboSaveType.Size = new System.Drawing.Size(173, 24);
            this.cmboSaveType.TabIndex = 21;
            // 
            // lblSaveType
            // 
            this.lblSaveType.AutoSize = true;
            this.lblSaveType.Location = new System.Drawing.Point(5, 14);
            this.lblSaveType.Name = "lblSaveType";
            this.lblSaveType.Size = new System.Drawing.Size(78, 17);
            this.lblSaveType.TabIndex = 22;
            this.lblSaveType.Text = "Data Type:";
            // 
            // lblLoadType
            // 
            this.lblLoadType.AutoSize = true;
            this.lblLoadType.Location = new System.Drawing.Point(5, 21);
            this.lblLoadType.Name = "lblLoadType";
            this.lblLoadType.Size = new System.Drawing.Size(78, 17);
            this.lblLoadType.TabIndex = 24;
            this.lblLoadType.Text = "Data Type:";
            // 
            // cmboLoadType
            // 
            this.cmboLoadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboLoadType.FormattingEnabled = true;
            this.cmboLoadType.Items.AddRange(new object[] {
            "BASE64",
            "Hex Bytes",
            "Hex Dump"});
            this.cmboLoadType.Location = new System.Drawing.Point(92, 17);
            this.cmboLoadType.Margin = new System.Windows.Forms.Padding(4);
            this.cmboLoadType.Name = "cmboLoadType";
            this.cmboLoadType.Size = new System.Drawing.Size(173, 24);
            this.cmboLoadType.TabIndex = 23;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(7, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitContainer1.Panel1.Controls.Add(this.btnLoadFile);
            this.splitContainer1.Panel1.Controls.Add(this.txtLoad);
            this.splitContainer1.Panel1.Controls.Add(this.lblLoadType);
            this.splitContainer1.Panel1.Controls.Add(this.txtLoadFile);
            this.splitContainer1.Panel1.Controls.Add(this.cmboLoadType);
            this.splitContainer1.Panel1.Controls.Add(this.btnLoadFileSelect);
            this.splitContainer1.Panel1.Controls.Add(this.lblLoadFile);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSaveFileGo);
            this.splitContainer1.Panel2.Controls.Add(this.cmboSaveType);
            this.splitContainer1.Panel2.Controls.Add(this.txtSave);
            this.splitContainer1.Panel2.Controls.Add(this.lblSaveFile);
            this.splitContainer1.Panel2.Controls.Add(this.lblSaveType);
            this.splitContainer1.Panel2.Controls.Add(this.btnSaveFileSelect);
            this.splitContainer1.Panel2.Controls.Add(this.txtSaveFile);
            this.splitContainer1.Size = new System.Drawing.Size(1214, 628);
            this.splitContainer1.SplitterDistance = 311;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 25;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(1145, 15);
            this.btnLoadFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(55, 31);
            this.btnLoadFile.TabIndex = 26;
            this.btnLoadFile.Text = "Go";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnSaveFileGo
            // 
            this.btnSaveFileGo.Location = new System.Drawing.Point(1145, 4);
            this.btnSaveFileGo.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveFileGo.Name = "btnSaveFileGo";
            this.btnSaveFileGo.Size = new System.Drawing.Size(55, 31);
            this.btnSaveFileGo.TabIndex = 24;
            this.btnSaveFileGo.Text = "Go";
            this.btnSaveFileGo.UseVisualStyleBackColor = true;
            this.btnSaveFileGo.Click += new System.EventHandler(this.btnSaveFileGo_Click);
            // 
            // FileContentHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1224, 633);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FileContentHelper";
            this.Text = "File Content Helper";
            this.Load += new System.EventHandler(this.Base64Contenthelper_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLoad;
        private System.Windows.Forms.Button btnLoadFileSelect;
        private System.Windows.Forms.TextBox txtLoadFile;
        private System.Windows.Forms.Label lblLoadFile;
        private System.Windows.Forms.Button btnSaveFileSelect;
        private System.Windows.Forms.TextBox txtSaveFile;
        private System.Windows.Forms.Label lblSaveFile;
        private System.Windows.Forms.TextBox txtSave;
        private System.Windows.Forms.ComboBox cmboSaveType;
        private System.Windows.Forms.Label lblSaveType;
        private System.Windows.Forms.Label lblLoadType;
        private System.Windows.Forms.ComboBox cmboLoadType;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnSaveFileGo;
    }
}