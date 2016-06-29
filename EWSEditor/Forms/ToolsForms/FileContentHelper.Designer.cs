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
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnSaveFileGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLoad
            // 
            this.txtLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoad.Font = new System.Drawing.Font("Courier New", 7.8F);
            this.txtLoad.Location = new System.Drawing.Point(12, 44);
            this.txtLoad.Margin = new System.Windows.Forms.Padding(4);
            this.txtLoad.MaxLength = 0;
            this.txtLoad.Multiline = true;
            this.txtLoad.Name = "txtLoad";
            this.txtLoad.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLoad.Size = new System.Drawing.Size(809, 184);
            this.txtLoad.TabIndex = 5;
            // 
            // btnLoadFileSelect
            // 
            this.btnLoadFileSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadFileSelect.Location = new System.Drawing.Point(723, 7);
            this.btnLoadFileSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadFileSelect.Name = "btnLoadFileSelect";
            this.btnLoadFileSelect.Size = new System.Drawing.Size(36, 29);
            this.btnLoadFileSelect.TabIndex = 15;
            this.btnLoadFileSelect.Text = "...";
            this.btnLoadFileSelect.UseVisualStyleBackColor = true;
            this.btnLoadFileSelect.Click += new System.EventHandler(this.btnLoadFileSelect_Click);
            // 
            // txtLoadFile
            // 
            this.txtLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoadFile.Location = new System.Drawing.Point(388, 9);
            this.txtLoadFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoadFile.Name = "txtLoadFile";
            this.txtLoadFile.Size = new System.Drawing.Size(329, 22);
            this.txtLoadFile.TabIndex = 13;
            // 
            // lblLoadFile
            // 
            this.lblLoadFile.AutoSize = true;
            this.lblLoadFile.Location = new System.Drawing.Point(284, 12);
            this.lblLoadFile.Name = "lblLoadFile";
            this.lblLoadFile.Size = new System.Drawing.Size(98, 17);
            this.lblLoadFile.TabIndex = 14;
            this.lblLoadFile.Text = "Load from file:";
            this.lblLoadFile.Click += new System.EventHandler(this.lblFromFile_Click);
            // 
            // btnSaveFileSelect
            // 
            this.btnSaveFileSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFileSelect.Location = new System.Drawing.Point(723, 238);
            this.btnSaveFileSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveFileSelect.Name = "btnSaveFileSelect";
            this.btnSaveFileSelect.Size = new System.Drawing.Size(36, 29);
            this.btnSaveFileSelect.TabIndex = 20;
            this.btnSaveFileSelect.Text = "...";
            this.btnSaveFileSelect.UseVisualStyleBackColor = true;
            this.btnSaveFileSelect.Click += new System.EventHandler(this.btnSaveFileSelect_Click);
            // 
            // txtSaveFile
            // 
            this.txtSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaveFile.Location = new System.Drawing.Point(403, 240);
            this.txtSaveFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSaveFile.Name = "txtSaveFile";
            this.txtSaveFile.Size = new System.Drawing.Size(314, 22);
            this.txtSaveFile.TabIndex = 18;
            // 
            // lblSaveFile
            // 
            this.lblSaveFile.AutoSize = true;
            this.lblSaveFile.Location = new System.Drawing.Point(296, 240);
            this.lblSaveFile.Name = "lblSaveFile";
            this.lblSaveFile.Size = new System.Drawing.Size(82, 17);
            this.lblSaveFile.TabIndex = 19;
            this.lblSaveFile.Text = "Save to file:";
            // 
            // txtSave
            // 
            this.txtSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSave.Font = new System.Drawing.Font("Courier New", 7.8F);
            this.txtSave.Location = new System.Drawing.Point(12, 271);
            this.txtSave.Margin = new System.Windows.Forms.Padding(4);
            this.txtSave.MaxLength = 0;
            this.txtSave.Multiline = true;
            this.txtSave.Name = "txtSave";
            this.txtSave.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSave.Size = new System.Drawing.Size(809, 155);
            this.txtSave.TabIndex = 16;
            // 
            // cmboSaveType
            // 
            this.cmboSaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboSaveType.FormattingEnabled = true;
            this.cmboSaveType.Items.AddRange(new object[] {
            "BASE64",
            "Hex Bytes"});
            this.cmboSaveType.Location = new System.Drawing.Point(96, 236);
            this.cmboSaveType.Margin = new System.Windows.Forms.Padding(4);
            this.cmboSaveType.Name = "cmboSaveType";
            this.cmboSaveType.Size = new System.Drawing.Size(173, 24);
            this.cmboSaveType.TabIndex = 21;
            // 
            // lblSaveType
            // 
            this.lblSaveType.AutoSize = true;
            this.lblSaveType.Location = new System.Drawing.Point(9, 243);
            this.lblSaveType.Name = "lblSaveType";
            this.lblSaveType.Size = new System.Drawing.Size(78, 17);
            this.lblSaveType.TabIndex = 22;
            this.lblSaveType.Text = "Data Type:";
            // 
            // lblLoadType
            // 
            this.lblLoadType.AutoSize = true;
            this.lblLoadType.Location = new System.Drawing.Point(12, 12);
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
            this.cmboLoadType.Location = new System.Drawing.Point(96, 9);
            this.cmboLoadType.Margin = new System.Windows.Forms.Padding(4);
            this.cmboLoadType.Name = "cmboLoadType";
            this.cmboLoadType.Size = new System.Drawing.Size(173, 24);
            this.cmboLoadType.TabIndex = 23;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadFile.Location = new System.Drawing.Point(766, 5);
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
            this.btnSaveFileGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFileGo.Location = new System.Drawing.Point(766, 236);
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
            this.ClientSize = new System.Drawing.Size(828, 433);
            this.Controls.Add(this.btnSaveFileGo);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.cmboSaveType);
            this.Controls.Add(this.txtSave);
            this.Controls.Add(this.lblSaveFile);
            this.Controls.Add(this.txtLoad);
            this.Controls.Add(this.lblSaveType);
            this.Controls.Add(this.lblLoadType);
            this.Controls.Add(this.btnSaveFileSelect);
            this.Controls.Add(this.lblLoadFile);
            this.Controls.Add(this.txtSaveFile);
            this.Controls.Add(this.txtLoadFile);
            this.Controls.Add(this.btnLoadFileSelect);
            this.Controls.Add(this.cmboLoadType);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FileContentHelper";
            this.Text = "File Content Helper";
            this.Load += new System.EventHandler(this.Base64Contenthelper_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnSaveFileGo;
    }
}