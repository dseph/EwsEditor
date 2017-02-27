namespace EWSEditor.Forms.Searches
{
    partial class SearchExportPicker
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
            this.chkConvertBase64BinaryHex = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grpStringHandling = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rdoHexEncodeStrings = new System.Windows.Forms.RadioButton();
            this.rdoNone = new System.Windows.Forms.RadioButton();
            this.rdoBase64EncodeStrings = new System.Windows.Forms.RadioButton();
            this.rdoSanitizeStrings = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPickFolderIncludeUsersAdditionalProperties = new System.Windows.Forms.Button();
            this.txtIncludeUsersAdditionalPropertiesFile = new System.Windows.Forms.TextBox();
            this.chkIncludeUsersAdditionalProperties = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPickFolderBlobProperties = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoExportAllGridData = new System.Windows.Forms.RadioButton();
            this.rdoExcludeAllGridContentExceptFolderPath = new System.Windows.Forms.RadioButton();
            this.rdoExcludeAllSearchGridContent = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBlobFolderPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPickFolderDisplayedResults = new System.Windows.Forms.Button();
            this.txtDisplayedResultsFolderPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoExportDisplayedResults = new System.Windows.Forms.RadioButton();
            this.rdoExportItemsAsBlobs = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.grpStringHandling.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkConvertBase64BinaryHex
            // 
            this.chkConvertBase64BinaryHex.AutoSize = true;
            this.chkConvertBase64BinaryHex.Location = new System.Drawing.Point(41, 409);
            this.chkConvertBase64BinaryHex.Name = "chkConvertBase64BinaryHex";
            this.chkConvertBase64BinaryHex.Size = new System.Drawing.Size(507, 21);
            this.chkConvertBase64BinaryHex.TabIndex = 41;
            this.chkConvertBase64BinaryHex.Text = "Encode binary data as hex (Search grid and included additional properties).";
            this.chkConvertBase64BinaryHex.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 17);
            this.label8.TabIndex = 39;
            this.label8.Text = "Export Options:";
            // 
            // grpStringHandling
            // 
            this.grpStringHandling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStringHandling.Controls.Add(this.label6);
            this.grpStringHandling.Controls.Add(this.rdoHexEncodeStrings);
            this.grpStringHandling.Controls.Add(this.rdoNone);
            this.grpStringHandling.Controls.Add(this.rdoBase64EncodeStrings);
            this.grpStringHandling.Controls.Add(this.rdoSanitizeStrings);
            this.grpStringHandling.Location = new System.Drawing.Point(38, 321);
            this.grpStringHandling.Name = "grpStringHandling";
            this.grpStringHandling.Size = new System.Drawing.Size(960, 82);
            this.grpStringHandling.TabIndex = 40;
            this.grpStringHandling.TabStop = false;
            this.grpStringHandling.Text = "Exported data handling";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(932, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "The data being exported may contain characters which will prevent loading the SCV" +
    " such as commas or CRLF, so special handling may be needed.";
            // 
            // rdoHexEncodeStrings
            // 
            this.rdoHexEncodeStrings.AutoSize = true;
            this.rdoHexEncodeStrings.Location = new System.Drawing.Point(337, 24);
            this.rdoHexEncodeStrings.Name = "rdoHexEncodeStrings";
            this.rdoHexEncodeStrings.Size = new System.Drawing.Size(105, 21);
            this.rdoHexEncodeStrings.TabIndex = 1;
            this.rdoHexEncodeStrings.Text = "Hex Encode";
            this.rdoHexEncodeStrings.UseVisualStyleBackColor = true;
            // 
            // rdoNone
            // 
            this.rdoNone.AutoSize = true;
            this.rdoNone.Location = new System.Drawing.Point(601, 21);
            this.rdoNone.Name = "rdoNone";
            this.rdoNone.Size = new System.Drawing.Size(63, 21);
            this.rdoNone.TabIndex = 3;
            this.rdoNone.Text = "None";
            this.rdoNone.UseVisualStyleBackColor = true;
            // 
            // rdoBase64EncodeStrings
            // 
            this.rdoBase64EncodeStrings.AutoSize = true;
            this.rdoBase64EncodeStrings.Location = new System.Drawing.Point(456, 24);
            this.rdoBase64EncodeStrings.Name = "rdoBase64EncodeStrings";
            this.rdoBase64EncodeStrings.Size = new System.Drawing.Size(129, 21);
            this.rdoBase64EncodeStrings.TabIndex = 2;
            this.rdoBase64EncodeStrings.Text = "Base64 Encode";
            this.rdoBase64EncodeStrings.UseVisualStyleBackColor = true;
            // 
            // rdoSanitizeStrings
            // 
            this.rdoSanitizeStrings.AutoSize = true;
            this.rdoSanitizeStrings.Checked = true;
            this.rdoSanitizeStrings.Location = new System.Drawing.Point(12, 24);
            this.rdoSanitizeStrings.Name = "rdoSanitizeStrings";
            this.rdoSanitizeStrings.Size = new System.Drawing.Size(319, 21);
            this.rdoSanitizeStrings.TabIndex = 0;
            this.rdoSanitizeStrings.TabStop = true;
            this.rdoSanitizeStrings.Text = "Sanitize - Remove comma, CR, LF characters.";
            this.rdoSanitizeStrings.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 17);
            this.label7.TabIndex = 36;
            this.label7.Text = "Import from CSV:";
            // 
            // btnPickFolderIncludeUsersAdditionalProperties
            // 
            this.btnPickFolderIncludeUsersAdditionalProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFolderIncludeUsersAdditionalProperties.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickFolderIncludeUsersAdditionalProperties.Location = new System.Drawing.Point(945, 265);
            this.btnPickFolderIncludeUsersAdditionalProperties.Name = "btnPickFolderIncludeUsersAdditionalProperties";
            this.btnPickFolderIncludeUsersAdditionalProperties.Size = new System.Drawing.Size(43, 24);
            this.btnPickFolderIncludeUsersAdditionalProperties.TabIndex = 38;
            this.btnPickFolderIncludeUsersAdditionalProperties.Text = "...";
            this.btnPickFolderIncludeUsersAdditionalProperties.UseVisualStyleBackColor = true;
            this.btnPickFolderIncludeUsersAdditionalProperties.Click += new System.EventHandler(this.btnPickFolderIncludeUsersAdditionalProperties_Click);
            // 
            // txtIncludeUsersAdditionalPropertiesFile
            // 
            this.txtIncludeUsersAdditionalPropertiesFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIncludeUsersAdditionalPropertiesFile.Enabled = false;
            this.txtIncludeUsersAdditionalPropertiesFile.Location = new System.Drawing.Point(254, 263);
            this.txtIncludeUsersAdditionalPropertiesFile.Name = "txtIncludeUsersAdditionalPropertiesFile";
            this.txtIncludeUsersAdditionalPropertiesFile.Size = new System.Drawing.Size(685, 22);
            this.txtIncludeUsersAdditionalPropertiesFile.TabIndex = 37;
            // 
            // chkIncludeUsersAdditionalProperties
            // 
            this.chkIncludeUsersAdditionalProperties.AutoSize = true;
            this.chkIncludeUsersAdditionalProperties.Location = new System.Drawing.Point(38, 265);
            this.chkIncludeUsersAdditionalProperties.Name = "chkIncludeUsersAdditionalProperties";
            this.chkIncludeUsersAdditionalProperties.Size = new System.Drawing.Size(210, 21);
            this.chkIncludeUsersAdditionalProperties.TabIndex = 35;
            this.chkIncludeUsersAdditionalProperties.Text = "Include Additional Properties";
            this.chkIncludeUsersAdditionalProperties.UseVisualStyleBackColor = true;
            this.chkIncludeUsersAdditionalProperties.CheckedChanged += new System.EventHandler(this.chkIncludeUsersAdditionalProperties_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnPickFolderBlobProperties);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBlobFolderPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnPickFolderDisplayedResults);
            this.groupBox1.Controls.Add(this.txtDisplayedResultsFolderPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rdoExportDisplayedResults);
            this.groupBox1.Controls.Add(this.rdoExportItemsAsBlobs);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(986, 216);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export Type";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnPickFolderBlobProperties
            // 
            this.btnPickFolderBlobProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFolderBlobProperties.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnPickFolderBlobProperties.Location = new System.Drawing.Point(933, 164);
            this.btnPickFolderBlobProperties.Name = "btnPickFolderBlobProperties";
            this.btnPickFolderBlobProperties.Size = new System.Drawing.Size(43, 24);
            this.btnPickFolderBlobProperties.TabIndex = 17;
            this.btnPickFolderBlobProperties.Text = "...";
            this.btnPickFolderBlobProperties.UseVisualStyleBackColor = true;
            this.btnPickFolderBlobProperties.Click += new System.EventHandler(this.btnPickFolderBlobProperties_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rdoExportAllGridData);
            this.groupBox2.Controls.Add(this.rdoExcludeAllGridContentExceptFolderPath);
            this.groupBox2.Controls.Add(this.rdoExcludeAllSearchGridContent);
            this.groupBox2.Location = new System.Drawing.Point(33, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(949, 46);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Grid Exclusions";
            // 
            // rdoExportAllGridData
            // 
            this.rdoExportAllGridData.AutoSize = true;
            this.rdoExportAllGridData.Checked = true;
            this.rdoExportAllGridData.Location = new System.Drawing.Point(18, 21);
            this.rdoExportAllGridData.Name = "rdoExportAllGridData";
            this.rdoExportAllGridData.Size = new System.Drawing.Size(88, 21);
            this.rdoExportAllGridData.TabIndex = 0;
            this.rdoExportAllGridData.TabStop = true;
            this.rdoExportAllGridData.Text = "Export All";
            this.rdoExportAllGridData.UseVisualStyleBackColor = true;
            // 
            // rdoExcludeAllGridContentExceptFolderPath
            // 
            this.rdoExcludeAllGridContentExceptFolderPath.AutoSize = true;
            this.rdoExcludeAllGridContentExceptFolderPath.Location = new System.Drawing.Point(112, 21);
            this.rdoExcludeAllGridContentExceptFolderPath.Name = "rdoExcludeAllGridContentExceptFolderPath";
            this.rdoExcludeAllGridContentExceptFolderPath.Size = new System.Drawing.Size(352, 21);
            this.rdoExcludeAllGridContentExceptFolderPath.TabIndex = 1;
            this.rdoExcludeAllGridContentExceptFolderPath.Text = "Exclude all Search Grid Content Except Folder Path";
            this.rdoExcludeAllGridContentExceptFolderPath.UseVisualStyleBackColor = true;
            // 
            // rdoExcludeAllSearchGridContent
            // 
            this.rdoExcludeAllSearchGridContent.AutoSize = true;
            this.rdoExcludeAllSearchGridContent.Location = new System.Drawing.Point(493, 21);
            this.rdoExcludeAllSearchGridContent.Name = "rdoExcludeAllSearchGridContent";
            this.rdoExcludeAllSearchGridContent.Size = new System.Drawing.Size(229, 21);
            this.rdoExcludeAllSearchGridContent.TabIndex = 2;
            this.rdoExcludeAllSearchGridContent.Text = "Exclude all Search Grid Content";
            this.rdoExcludeAllSearchGridContent.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Note: You must select items prior to exporting.";
            // 
            // txtBlobFolderPath
            // 
            this.txtBlobFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlobFolderPath.Location = new System.Drawing.Point(156, 164);
            this.txtBlobFolderPath.Name = "txtBlobFolderPath";
            this.txtBlobFolderPath.Size = new System.Drawing.Size(771, 22);
            this.txtBlobFolderPath.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Export folder path:";
            // 
            // btnPickFolderDisplayedResults
            // 
            this.btnPickFolderDisplayedResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFolderDisplayedResults.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnPickFolderDisplayedResults.Location = new System.Drawing.Point(937, 57);
            this.btnPickFolderDisplayedResults.Name = "btnPickFolderDisplayedResults";
            this.btnPickFolderDisplayedResults.Size = new System.Drawing.Size(43, 24);
            this.btnPickFolderDisplayedResults.TabIndex = 3;
            this.btnPickFolderDisplayedResults.Text = "...";
            this.btnPickFolderDisplayedResults.UseVisualStyleBackColor = true;
            this.btnPickFolderDisplayedResults.Click += new System.EventHandler(this.btnPickFolderDisplayedResults_Click);
            // 
            // txtDisplayedResultsFolderPath
            // 
            this.txtDisplayedResultsFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDisplayedResultsFolderPath.Location = new System.Drawing.Point(160, 57);
            this.txtDisplayedResultsFolderPath.Name = "txtDisplayedResultsFolderPath";
            this.txtDisplayedResultsFolderPath.Size = new System.Drawing.Size(771, 22);
            this.txtDisplayedResultsFolderPath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Export fiile path:";
            // 
            // rdoExportDisplayedResults
            // 
            this.rdoExportDisplayedResults.AutoSize = true;
            this.rdoExportDisplayedResults.Checked = true;
            this.rdoExportDisplayedResults.Location = new System.Drawing.Point(10, 30);
            this.rdoExportDisplayedResults.Name = "rdoExportDisplayedResults";
            this.rdoExportDisplayedResults.Size = new System.Drawing.Size(185, 21);
            this.rdoExportDisplayedResults.TabIndex = 0;
            this.rdoExportDisplayedResults.TabStop = true;
            this.rdoExportDisplayedResults.Text = "Export Displayed reulsts:";
            this.rdoExportDisplayedResults.UseVisualStyleBackColor = true;
            this.rdoExportDisplayedResults.CheckedChanged += new System.EventHandler(this.rdoExportDisplayedResults_CheckedChanged);
            // 
            // rdoExportItemsAsBlobs
            // 
            this.rdoExportItemsAsBlobs.AutoSize = true;
            this.rdoExportItemsAsBlobs.Location = new System.Drawing.Point(10, 137);
            this.rdoExportItemsAsBlobs.Name = "rdoExportItemsAsBlobs";
            this.rdoExportItemsAsBlobs.Size = new System.Drawing.Size(446, 21);
            this.rdoExportItemsAsBlobs.TabIndex = 14;
            this.rdoExportItemsAsBlobs.Text = "Export items as blobs (you can reload them using EwsEditor later):";
            this.rdoExportItemsAsBlobs.UseVisualStyleBackColor = true;
            this.rdoExportItemsAsBlobs.CheckedChanged += new System.EventHandler(this.rdoExportItemsAsBlobs_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(888, 464);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(781, 464);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(100, 28);
            this.OkButton.TabIndex = 42;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // SearchExportPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 505);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.chkConvertBase64BinaryHex);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.grpStringHandling);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnPickFolderIncludeUsersAdditionalProperties);
            this.Controls.Add(this.txtIncludeUsersAdditionalPropertiesFile);
            this.Controls.Add(this.chkIncludeUsersAdditionalProperties);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchExportPicker";
            this.Text = "Item Search Result Export";
            this.Load += new System.EventHandler(this.SearchExportPicker_Load);
            this.grpStringHandling.ResumeLayout(false);
            this.grpStringHandling.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox chkConvertBase64BinaryHex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grpStringHandling;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.RadioButton rdoHexEncodeStrings;
        public System.Windows.Forms.RadioButton rdoNone;
        public System.Windows.Forms.RadioButton rdoBase64EncodeStrings;
        public System.Windows.Forms.RadioButton rdoSanitizeStrings;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPickFolderIncludeUsersAdditionalProperties;
        public System.Windows.Forms.TextBox txtIncludeUsersAdditionalPropertiesFile;
        public System.Windows.Forms.CheckBox chkIncludeUsersAdditionalProperties;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPickFolderBlobProperties;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtBlobFolderPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPickFolderDisplayedResults;
        public System.Windows.Forms.TextBox txtDisplayedResultsFolderPath;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RadioButton rdoExportDisplayedResults;
        public System.Windows.Forms.RadioButton rdoExportItemsAsBlobs;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.RadioButton rdoExportAllGridData;
        public System.Windows.Forms.RadioButton rdoExcludeAllGridContentExceptFolderPath;
        public System.Windows.Forms.RadioButton rdoExcludeAllSearchGridContent;
    }
}