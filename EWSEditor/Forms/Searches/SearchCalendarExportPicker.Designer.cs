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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAppointmentDetailedFolderPath = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPickFolderBlobProperties = new System.Windows.Forms.Button();
            this.btnPickFolderMeetingMessageDetailedProperties = new System.Windows.Forms.Button();
            this.txtMeetingMessageDetailedFolderPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPickFolderAppointmentDetailedProperties = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBlobFolderPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPickFolderDisplayedResults = new System.Windows.Forms.Button();
            this.txtDisplayedResultsFolderPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoExportDisplayedResults
            // 
            this.rdoExportDisplayedResults.AutoSize = true;
            this.rdoExportDisplayedResults.Checked = true;
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
            this.rdoExportDetailedProperties.Location = new System.Drawing.Point(10, 89);
            this.rdoExportDetailedProperties.Name = "rdoExportDetailedProperties";
            this.rdoExportDetailedProperties.Size = new System.Drawing.Size(262, 21);
            this.rdoExportDetailedProperties.TabIndex = 1;
            this.rdoExportDetailedProperties.Text = "Export detailed propeties as CSV file.";
            this.rdoExportDetailedProperties.UseVisualStyleBackColor = true;
            this.rdoExportDetailedProperties.CheckedChanged += new System.EventHandler(this.rdoExportDetailedProperties_CheckedChanged);
            // 
            // rdoExportItemsAsBlobs
            // 
            this.rdoExportItemsAsBlobs.AutoSize = true;
            this.rdoExportItemsAsBlobs.Location = new System.Drawing.Point(6, 236);
            this.rdoExportItemsAsBlobs.Name = "rdoExportItemsAsBlobs";
            this.rdoExportItemsAsBlobs.Size = new System.Drawing.Size(357, 21);
            this.rdoExportItemsAsBlobs.TabIndex = 2;
            this.rdoExportItemsAsBlobs.Text = "Export items as blobs (reload using EwsEditor later).";
            this.rdoExportItemsAsBlobs.UseVisualStyleBackColor = true;
            this.rdoExportItemsAsBlobs.CheckedChanged += new System.EventHandler(this.rdoExportItemsAsBlobs_CheckedChanged);
            // 
            // chkIncludeBodyProperties
            // 
            this.chkIncludeBodyProperties.AutoSize = true;
            this.chkIncludeBodyProperties.Location = new System.Drawing.Point(39, 171);
            this.chkIncludeBodyProperties.Name = "chkIncludeBodyProperties";
            this.chkIncludeBodyProperties.Size = new System.Drawing.Size(213, 21);
            this.chkIncludeBodyProperties.TabIndex = 3;
            this.chkIncludeBodyProperties.Text = "Include body body properties";
            this.chkIncludeBodyProperties.UseVisualStyleBackColor = true;
            // 
            // chkIncludeMime
            // 
            this.chkIncludeMime.AutoSize = true;
            this.chkIncludeMime.Location = new System.Drawing.Point(39, 198);
            this.chkIncludeMime.Name = "chkIncludeMime";
            this.chkIncludeMime.Size = new System.Drawing.Size(113, 21);
            this.chkIncludeMime.TabIndex = 4;
            this.chkIncludeMime.Text = "Include MIME";
            this.chkIncludeMime.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Appointment Export file path:";
            // 
            // txtAppointmentDetailedFolderPath
            // 
            this.txtAppointmentDetailedFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAppointmentDetailedFolderPath.Location = new System.Drawing.Point(253, 115);
            this.txtAppointmentDetailedFolderPath.Name = "txtAppointmentDetailedFolderPath";
            this.txtAppointmentDetailedFolderPath.Size = new System.Drawing.Size(542, 22);
            this.txtAppointmentDetailedFolderPath.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(743, 348);
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
            this.OkButton.Location = new System.Drawing.Point(636, 348);
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
            this.groupBox1.Controls.Add(this.btnPickFolderBlobProperties);
            this.groupBox1.Controls.Add(this.btnPickFolderMeetingMessageDetailedProperties);
            this.groupBox1.Controls.Add(this.txtMeetingMessageDetailedFolderPath);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnPickFolderAppointmentDetailedProperties);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBlobFolderPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnPickFolderDisplayedResults);
            this.groupBox1.Controls.Add(this.txtDisplayedResultsFolderPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAppointmentDetailedFolderPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdoExportDisplayedResults);
            this.groupBox1.Controls.Add(this.rdoExportDetailedProperties);
            this.groupBox1.Controls.Add(this.rdoExportItemsAsBlobs);
            this.groupBox1.Controls.Add(this.chkIncludeBodyProperties);
            this.groupBox1.Controls.Add(this.chkIncludeMime);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(832, 322);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export Type";
            // 
            // btnPickFolderBlobProperties
            // 
            this.btnPickFolderBlobProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFolderBlobProperties.Location = new System.Drawing.Point(797, 263);
            this.btnPickFolderBlobProperties.Name = "btnPickFolderBlobProperties";
            this.btnPickFolderBlobProperties.Size = new System.Drawing.Size(31, 22);
            this.btnPickFolderBlobProperties.TabIndex = 20;
            this.btnPickFolderBlobProperties.Text = "...";
            this.btnPickFolderBlobProperties.UseVisualStyleBackColor = true;
            this.btnPickFolderBlobProperties.Click += new System.EventHandler(this.btnPickFolderBlobProperties_Click);
            // 
            // btnPickFolderMeetingMessageDetailedProperties
            // 
            this.btnPickFolderMeetingMessageDetailedProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFolderMeetingMessageDetailedProperties.Location = new System.Drawing.Point(801, 139);
            this.btnPickFolderMeetingMessageDetailedProperties.Name = "btnPickFolderMeetingMessageDetailedProperties";
            this.btnPickFolderMeetingMessageDetailedProperties.Size = new System.Drawing.Size(31, 22);
            this.btnPickFolderMeetingMessageDetailedProperties.TabIndex = 19;
            this.btnPickFolderMeetingMessageDetailedProperties.Text = "...";
            this.btnPickFolderMeetingMessageDetailedProperties.UseVisualStyleBackColor = true;
            this.btnPickFolderMeetingMessageDetailedProperties.Click += new System.EventHandler(this.btnPickFolderMeetingMessageDetailedProperties_Click);
            // 
            // txtMeetingMessageDetailedFolderPath
            // 
            this.txtMeetingMessageDetailedFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMeetingMessageDetailedFolderPath.Location = new System.Drawing.Point(253, 141);
            this.txtMeetingMessageDetailedFolderPath.Name = "txtMeetingMessageDetailedFolderPath";
            this.txtMeetingMessageDetailedFolderPath.Size = new System.Drawing.Size(542, 22);
            this.txtMeetingMessageDetailedFolderPath.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "MeetingMessage Export file path:";
            // 
            // btnPickFolderAppointmentDetailedProperties
            // 
            this.btnPickFolderAppointmentDetailedProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFolderAppointmentDetailedProperties.Location = new System.Drawing.Point(801, 113);
            this.btnPickFolderAppointmentDetailedProperties.Name = "btnPickFolderAppointmentDetailedProperties";
            this.btnPickFolderAppointmentDetailedProperties.Size = new System.Drawing.Size(31, 22);
            this.btnPickFolderAppointmentDetailedProperties.TabIndex = 16;
            this.btnPickFolderAppointmentDetailedProperties.Text = "...";
            this.btnPickFolderAppointmentDetailedProperties.UseVisualStyleBackColor = true;
            this.btnPickFolderAppointmentDetailedProperties.Click += new System.EventHandler(this.btnPickFolderAppointmentDetailedProperties_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Note: You must select items prior to exporting.";
            // 
            // txtBlobFolderPath
            // 
            this.txtBlobFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlobFolderPath.Location = new System.Drawing.Point(156, 263);
            this.txtBlobFolderPath.Name = "txtBlobFolderPath";
            this.txtBlobFolderPath.Size = new System.Drawing.Size(635, 22);
            this.txtBlobFolderPath.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Export folder path:";
            // 
            // btnPickFolderDisplayedResults
            // 
            this.btnPickFolderDisplayedResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFolderDisplayedResults.Location = new System.Drawing.Point(801, 55);
            this.btnPickFolderDisplayedResults.Name = "btnPickFolderDisplayedResults";
            this.btnPickFolderDisplayedResults.Size = new System.Drawing.Size(31, 22);
            this.btnPickFolderDisplayedResults.TabIndex = 14;
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
            this.txtDisplayedResultsFolderPath.Size = new System.Drawing.Size(635, 22);
            this.txtDisplayedResultsFolderPath.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Export fiile path:";
            // 
            // SearchCalendarExportPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 389);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.OkButton);
            this.Name = "SearchCalendarExportPicker";
            this.Text = "Select Export Type";
            this.Load += new System.EventHandler(this.SearchCalendarExportPicker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtAppointmentDetailedFolderPath;
        public System.Windows.Forms.RadioButton rdoExportDisplayedResults;
        public System.Windows.Forms.RadioButton rdoExportDetailedProperties;
        public System.Windows.Forms.RadioButton rdoExportItemsAsBlobs;
        public System.Windows.Forms.CheckBox chkIncludeBodyProperties;
        public System.Windows.Forms.CheckBox chkIncludeMime;
        public System.Windows.Forms.TextBox txtBlobFolderPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPickFolderDisplayedResults;
        public System.Windows.Forms.TextBox txtDisplayedResultsFolderPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPickFolderAppointmentDetailedProperties;
        private System.Windows.Forms.Button btnPickFolderMeetingMessageDetailedProperties;
        public System.Windows.Forms.TextBox txtMeetingMessageDetailedFolderPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPickFolderBlobProperties;
    }
}