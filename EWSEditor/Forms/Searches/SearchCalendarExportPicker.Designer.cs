namespace EWSEditor.Forms
{
    partial class SearchCalendarExportPicker
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
            this.rdoExportDisplayedResults = new System.Windows.Forms.RadioButton();
            this.rdoExportDetailedProperties = new System.Windows.Forms.RadioButton();
            this.rdoExportItemsAsBlobs = new System.Windows.Forms.RadioButton();
            this.chkIncludeBodyProperties = new System.Windows.Forms.CheckBox();
            this.chkIncludeMime = new System.Windows.Forms.CheckBox();
            this.chkIncludeAttachments = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPickFolder = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoExportDisplayedResults
            // 
            this.rdoExportDisplayedResults.AutoSize = true;
            this.rdoExportDisplayedResults.Location = new System.Drawing.Point(10, 30);
            this.rdoExportDisplayedResults.Name = "rdoExportDisplayedResults";
            this.rdoExportDisplayedResults.Size = new System.Drawing.Size(179, 21);
            this.rdoExportDisplayedResults.TabIndex = 0;
            this.rdoExportDisplayedResults.TabStop = true;
            this.rdoExportDisplayedResults.Text = "Export displayed results";
            this.rdoExportDisplayedResults.UseVisualStyleBackColor = true;
            this.rdoExportDisplayedResults.CheckedChanged += new System.EventHandler(this.rdoExportDisplayedResults_CheckedChanged);
            // 
            // rdoExportDetailedProperties
            // 
            this.rdoExportDetailedProperties.AutoSize = true;
            this.rdoExportDetailedProperties.Location = new System.Drawing.Point(10, 57);
            this.rdoExportDetailedProperties.Name = "rdoExportDetailedProperties";
            this.rdoExportDetailedProperties.Size = new System.Drawing.Size(186, 21);
            this.rdoExportDetailedProperties.TabIndex = 1;
            this.rdoExportDetailedProperties.TabStop = true;
            this.rdoExportDetailedProperties.Text = "Export detailed propeties";
            this.rdoExportDetailedProperties.UseVisualStyleBackColor = true;
            this.rdoExportDetailedProperties.CheckedChanged += new System.EventHandler(this.rdoExportDetailedProperties_CheckedChanged);
            // 
            // rdoExportItemsAsBlobs
            // 
            this.rdoExportItemsAsBlobs.AutoSize = true;
            this.rdoExportItemsAsBlobs.Location = new System.Drawing.Point(10, 165);
            this.rdoExportItemsAsBlobs.Name = "rdoExportItemsAsBlobs";
            this.rdoExportItemsAsBlobs.Size = new System.Drawing.Size(357, 21);
            this.rdoExportItemsAsBlobs.TabIndex = 2;
            this.rdoExportItemsAsBlobs.TabStop = true;
            this.rdoExportItemsAsBlobs.Text = "Export items as blobs (reload using EwsEditor later).";
            this.rdoExportItemsAsBlobs.UseVisualStyleBackColor = true;
            this.rdoExportItemsAsBlobs.CheckedChanged += new System.EventHandler(this.rdoExportItemsAsBlobs_CheckedChanged);
            // 
            // chkIncludeBodyProperties
            // 
            this.chkIncludeBodyProperties.AutoSize = true;
            this.chkIncludeBodyProperties.Location = new System.Drawing.Point(30, 84);
            this.chkIncludeBodyProperties.Name = "chkIncludeBodyProperties";
            this.chkIncludeBodyProperties.Size = new System.Drawing.Size(213, 21);
            this.chkIncludeBodyProperties.TabIndex = 3;
            this.chkIncludeBodyProperties.Text = "Include body body properties";
            this.chkIncludeBodyProperties.UseVisualStyleBackColor = true;
            // 
            // chkIncludeMime
            // 
            this.chkIncludeMime.AutoSize = true;
            this.chkIncludeMime.Location = new System.Drawing.Point(30, 111);
            this.chkIncludeMime.Name = "chkIncludeMime";
            this.chkIncludeMime.Size = new System.Drawing.Size(113, 21);
            this.chkIncludeMime.TabIndex = 4;
            this.chkIncludeMime.Text = "Include MIME";
            this.chkIncludeMime.UseVisualStyleBackColor = true;
            // 
            // chkIncludeAttachments
            // 
            this.chkIncludeAttachments.AutoSize = true;
            this.chkIncludeAttachments.Location = new System.Drawing.Point(30, 138);
            this.chkIncludeAttachments.Name = "chkIncludeAttachments";
            this.chkIncludeAttachments.Size = new System.Drawing.Size(157, 21);
            this.chkIncludeAttachments.TabIndex = 5;
            this.chkIncludeAttachments.Text = "Include Attachments";
            this.chkIncludeAttachments.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Export path:";
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderPath.Location = new System.Drawing.Point(104, 218);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(527, 22);
            this.txtFolderPath.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(572, 252);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(465, 252);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(100, 28);
            this.OkButton.TabIndex = 8;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIncludeAttachments);
            this.groupBox1.Controls.Add(this.rdoExportDisplayedResults);
            this.groupBox1.Controls.Add(this.rdoExportDetailedProperties);
            this.groupBox1.Controls.Add(this.rdoExportItemsAsBlobs);
            this.groupBox1.Controls.Add(this.chkIncludeBodyProperties);
            this.groupBox1.Controls.Add(this.chkIncludeMime);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(661, 194);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export Type";
            // 
            // btnPickFolder
            // 
            this.btnPickFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPickFolder.Location = new System.Drawing.Point(637, 218);
            this.btnPickFolder.Name = "btnPickFolder";
            this.btnPickFolder.Size = new System.Drawing.Size(36, 22);
            this.btnPickFolder.TabIndex = 11;
            this.btnPickFolder.Text = "...";
            this.btnPickFolder.UseVisualStyleBackColor = true;
            this.btnPickFolder.Click += new System.EventHandler(this.btnPickFolder_Click);
            // 
            // SearchCalendarExportPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 293);
            this.Controls.Add(this.btnPickFolder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.label1);
            this.Name = "SearchCalendarExportPicker";
            this.Text = "Select Export Type";
            this.Load += new System.EventHandler(this.SearchCalendarExportPicker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPickFolder;
        public System.Windows.Forms.TextBox txtFolderPath;
        public System.Windows.Forms.RadioButton rdoExportDisplayedResults;
        public System.Windows.Forms.RadioButton rdoExportDetailedProperties;
        public System.Windows.Forms.RadioButton rdoExportItemsAsBlobs;
        public System.Windows.Forms.CheckBox chkIncludeBodyProperties;
        public System.Windows.Forms.CheckBox chkIncludeMime;
        public System.Windows.Forms.CheckBox chkIncludeAttachments;
    }
}