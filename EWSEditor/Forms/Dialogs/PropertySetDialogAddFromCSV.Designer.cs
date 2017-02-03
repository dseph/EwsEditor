namespace EWSEditor.Forms
{
    partial class PropertySetDialogAddFromCSV
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
            this.label7 = new System.Windows.Forms.Label();
            this.btnPickFolderIncludeUsersAdditionalProperties = new System.Windows.Forms.Button();
            this.txtIncludeUsersAdditionalPropertiesFile = new System.Windows.Forms.TextBox();
            this.txtCsv = new System.Windows.Forms.TextBox();
            this.lvCsv = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLoadFromCsv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 17);
            this.label7.TabIndex = 27;
            this.label7.Text = "Load from CSV:";
            // 
            // btnPickFolderIncludeUsersAdditionalProperties
            // 
            this.btnPickFolderIncludeUsersAdditionalProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFolderIncludeUsersAdditionalProperties.Location = new System.Drawing.Point(883, 5);
            this.btnPickFolderIncludeUsersAdditionalProperties.Name = "btnPickFolderIncludeUsersAdditionalProperties";
            this.btnPickFolderIncludeUsersAdditionalProperties.Size = new System.Drawing.Size(31, 29);
            this.btnPickFolderIncludeUsersAdditionalProperties.TabIndex = 26;
            this.btnPickFolderIncludeUsersAdditionalProperties.Text = "...";
            this.btnPickFolderIncludeUsersAdditionalProperties.UseVisualStyleBackColor = true;
            this.btnPickFolderIncludeUsersAdditionalProperties.Click += new System.EventHandler(this.btnPickFolderIncludeUsersAdditionalProperties_Click);
            // 
            // txtIncludeUsersAdditionalPropertiesFile
            // 
            this.txtIncludeUsersAdditionalPropertiesFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIncludeUsersAdditionalPropertiesFile.Enabled = false;
            this.txtIncludeUsersAdditionalPropertiesFile.Location = new System.Drawing.Point(134, 12);
            this.txtIncludeUsersAdditionalPropertiesFile.Name = "txtIncludeUsersAdditionalPropertiesFile";
            this.txtIncludeUsersAdditionalPropertiesFile.Size = new System.Drawing.Size(743, 22);
            this.txtIncludeUsersAdditionalPropertiesFile.TabIndex = 25;
            // 
            // txtCsv
            // 
            this.txtCsv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCsv.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCsv.Location = new System.Drawing.Point(12, 66);
            this.txtCsv.MaxLength = 0;
            this.txtCsv.Multiline = true;
            this.txtCsv.Name = "txtCsv";
            this.txtCsv.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCsv.Size = new System.Drawing.Size(903, 212);
            this.txtCsv.TabIndex = 28;
            this.txtCsv.WordWrap = false;
            // 
            // lvCsv
            // 
            this.lvCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCsv.FullRowSelect = true;
            this.lvCsv.GridLines = true;
            this.lvCsv.HideSelection = false;
            this.lvCsv.Location = new System.Drawing.Point(12, 318);
            this.lvCsv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvCsv.Name = "lvCsv";
            this.lvCsv.Size = new System.Drawing.Size(903, 237);
            this.lvCsv.TabIndex = 29;
            this.lvCsv.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "CSV File Contents:";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(758, 562);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 32;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(839, 562);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLoadFromCsv
            // 
            this.btnLoadFromCsv.Location = new System.Drawing.Point(12, 284);
            this.btnLoadFromCsv.Name = "btnLoadFromCsv";
            this.btnLoadFromCsv.Size = new System.Drawing.Size(258, 27);
            this.btnLoadFromCsv.TabIndex = 34;
            this.btnLoadFromCsv.Text = "Import CSV based Property Definitions";
            this.btnLoadFromCsv.UseVisualStyleBackColor = true;
            this.btnLoadFromCsv.Click += new System.EventHandler(this.btnLoadFromCsv_Click);
            // 
            // PropertySetDialogAddFromCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 595);
            this.Controls.Add(this.btnLoadFromCsv);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvCsv);
            this.Controls.Add(this.txtCsv);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnPickFolderIncludeUsersAdditionalProperties);
            this.Controls.Add(this.txtIncludeUsersAdditionalPropertiesFile);
            this.Name = "PropertySetDialogAddFromCSV";
            this.Text = "PropertySetDialogAddFromCSV";
            this.Load += new System.EventHandler(this.PropertySetDialogAddFromCSV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPickFolderIncludeUsersAdditionalProperties;
        public System.Windows.Forms.TextBox txtIncludeUsersAdditionalPropertiesFile;
        private System.Windows.Forms.TextBox txtCsv;
        private System.Windows.Forms.ListView lvCsv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLoadFromCsv;
    }
}