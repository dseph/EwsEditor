﻿namespace EWSEditor.Forms
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
            this.chkIncludeUsersAdditionalProperties = new System.Windows.Forms.CheckBox();
            this.txtIncludeUsersAdditionalPropertiesFile = new System.Windows.Forms.TextBox();
            this.btnPickFolderIncludeUsersAdditionalProperties = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.rdoBase64EncodeStrings = new System.Windows.Forms.RadioButton();
            this.rdoSanitizeStrings = new System.Windows.Forms.RadioButton();
            this.grpStringHandling = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rdoHexEncodeStrings = new System.Windows.Forms.RadioButton();
            this.rdoNone = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoExportAllGridData = new System.Windows.Forms.RadioButton();
            this.rdoExcludeAllGridContentExceptFolderPath = new System.Windows.Forms.RadioButton();
            this.rdoExcludeAllSearchGridContent = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.chkConvertBase64BinaryHex = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.grpStringHandling.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.rdoExportDetailedProperties.TabIndex = 4;
            this.rdoExportDetailedProperties.Text = "Export detailed propeties as CSV file.";
            this.rdoExportDetailedProperties.UseVisualStyleBackColor = true;
            this.rdoExportDetailedProperties.CheckedChanged += new System.EventHandler(this.rdoExportDetailedProperties_CheckedChanged);
            // 
            // rdoExportItemsAsBlobs
            // 
            this.rdoExportItemsAsBlobs.AutoSize = true;
            this.rdoExportItemsAsBlobs.Location = new System.Drawing.Point(6, 225);
            this.rdoExportItemsAsBlobs.Name = "rdoExportItemsAsBlobs";
            this.rdoExportItemsAsBlobs.Size = new System.Drawing.Size(446, 21);
            this.rdoExportItemsAsBlobs.TabIndex = 17;
            this.rdoExportItemsAsBlobs.Text = "Export items as blobs (you can reload them using EwsEditor later).";
            this.rdoExportItemsAsBlobs.UseVisualStyleBackColor = true;
            this.rdoExportItemsAsBlobs.CheckedChanged += new System.EventHandler(this.rdoExportItemsAsBlobs_CheckedChanged);
            // 
            // chkIncludeBodyProperties
            // 
            this.chkIncludeBodyProperties.AutoSize = true;
            this.chkIncludeBodyProperties.Location = new System.Drawing.Point(39, 171);
            this.chkIncludeBodyProperties.Name = "chkIncludeBodyProperties";
            this.chkIncludeBodyProperties.Size = new System.Drawing.Size(213, 21);
            this.chkIncludeBodyProperties.TabIndex = 11;
            this.chkIncludeBodyProperties.Text = "Include body body properties";
            this.chkIncludeBodyProperties.UseVisualStyleBackColor = true;
            // 
            // chkIncludeMime
            // 
            this.chkIncludeMime.AutoSize = true;
            this.chkIncludeMime.Location = new System.Drawing.Point(39, 198);
            this.chkIncludeMime.Name = "chkIncludeMime";
            this.chkIncludeMime.Size = new System.Drawing.Size(113, 21);
            this.chkIncludeMime.TabIndex = 12;
            this.chkIncludeMime.Text = "Include MIME";
            this.chkIncludeMime.UseVisualStyleBackColor = true;
            this.chkIncludeMime.CheckedChanged += new System.EventHandler(this.chkIncludeMime_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Appointment Export file path:";
            // 
            // txtAppointmentDetailedFolderPath
            // 
            this.txtAppointmentDetailedFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAppointmentDetailedFolderPath.Location = new System.Drawing.Point(253, 115);
            this.txtAppointmentDetailedFolderPath.Name = "txtAppointmentDetailedFolderPath";
            this.txtAppointmentDetailedFolderPath.Size = new System.Drawing.Size(668, 22);
            this.txtAppointmentDetailedFolderPath.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(883, 588);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(776, 588);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(100, 28);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBox1.Size = new System.Drawing.Size(976, 302);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export Type";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnPickFolderBlobProperties
            // 
            this.btnPickFolderBlobProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFolderBlobProperties.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnPickFolderBlobProperties.Location = new System.Drawing.Point(923, 252);
            this.btnPickFolderBlobProperties.Name = "btnPickFolderBlobProperties";
            this.btnPickFolderBlobProperties.Size = new System.Drawing.Size(43, 24);
            this.btnPickFolderBlobProperties.TabIndex = 21;
            this.btnPickFolderBlobProperties.Text = "...";
            this.btnPickFolderBlobProperties.UseVisualStyleBackColor = true;
            this.btnPickFolderBlobProperties.Click += new System.EventHandler(this.btnPickFolderBlobProperties_Click);
            // 
            // btnPickFolderMeetingMessageDetailedProperties
            // 
            this.btnPickFolderMeetingMessageDetailedProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFolderMeetingMessageDetailedProperties.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnPickFolderMeetingMessageDetailedProperties.Location = new System.Drawing.Point(927, 141);
            this.btnPickFolderMeetingMessageDetailedProperties.Name = "btnPickFolderMeetingMessageDetailedProperties";
            this.btnPickFolderMeetingMessageDetailedProperties.Size = new System.Drawing.Size(43, 24);
            this.btnPickFolderMeetingMessageDetailedProperties.TabIndex = 10;
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
            this.txtMeetingMessageDetailedFolderPath.Size = new System.Drawing.Size(668, 22);
            this.txtMeetingMessageDetailedFolderPath.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "MeetingMessage Export file path:";
            // 
            // btnPickFolderAppointmentDetailedProperties
            // 
            this.btnPickFolderAppointmentDetailedProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFolderAppointmentDetailedProperties.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnPickFolderAppointmentDetailedProperties.Location = new System.Drawing.Point(927, 115);
            this.btnPickFolderAppointmentDetailedProperties.Name = "btnPickFolderAppointmentDetailedProperties";
            this.btnPickFolderAppointmentDetailedProperties.Size = new System.Drawing.Size(43, 24);
            this.btnPickFolderAppointmentDetailedProperties.TabIndex = 7;
            this.btnPickFolderAppointmentDetailedProperties.Text = "...";
            this.btnPickFolderAppointmentDetailedProperties.UseVisualStyleBackColor = true;
            this.btnPickFolderAppointmentDetailedProperties.Click += new System.EventHandler(this.btnPickFolderAppointmentDetailedProperties_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Note: You must select items prior to exporting.";
            // 
            // txtBlobFolderPath
            // 
            this.txtBlobFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlobFolderPath.Location = new System.Drawing.Point(156, 252);
            this.txtBlobFolderPath.Name = "txtBlobFolderPath";
            this.txtBlobFolderPath.Size = new System.Drawing.Size(761, 22);
            this.txtBlobFolderPath.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Export folder path:";
            // 
            // btnPickFolderDisplayedResults
            // 
            this.btnPickFolderDisplayedResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFolderDisplayedResults.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnPickFolderDisplayedResults.Location = new System.Drawing.Point(927, 57);
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
            this.txtDisplayedResultsFolderPath.Size = new System.Drawing.Size(761, 22);
            this.txtDisplayedResultsFolderPath.TabIndex = 2;
            this.txtDisplayedResultsFolderPath.TextChanged += new System.EventHandler(this.txtDisplayedResultsFolderPath_TextChanged);
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
            // chkIncludeUsersAdditionalProperties
            // 
            this.chkIncludeUsersAdditionalProperties.AutoSize = true;
            this.chkIncludeUsersAdditionalProperties.Location = new System.Drawing.Point(12, 320);
            this.chkIncludeUsersAdditionalProperties.Name = "chkIncludeUsersAdditionalProperties";
            this.chkIncludeUsersAdditionalProperties.Size = new System.Drawing.Size(210, 21);
            this.chkIncludeUsersAdditionalProperties.TabIndex = 13;
            this.chkIncludeUsersAdditionalProperties.Text = "Include Additional Properties";
            this.chkIncludeUsersAdditionalProperties.UseVisualStyleBackColor = true;
            this.chkIncludeUsersAdditionalProperties.CheckedChanged += new System.EventHandler(this.chkIncludeUsersAdditionalProperties_CheckedChanged);
            // 
            // txtIncludeUsersAdditionalPropertiesFile
            // 
            this.txtIncludeUsersAdditionalPropertiesFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIncludeUsersAdditionalPropertiesFile.Enabled = false;
            this.txtIncludeUsersAdditionalPropertiesFile.Location = new System.Drawing.Point(168, 344);
            this.txtIncludeUsersAdditionalPropertiesFile.Name = "txtIncludeUsersAdditionalPropertiesFile";
            this.txtIncludeUsersAdditionalPropertiesFile.Size = new System.Drawing.Size(761, 22);
            this.txtIncludeUsersAdditionalPropertiesFile.TabIndex = 21;
            // 
            // btnPickFolderIncludeUsersAdditionalProperties
            // 
            this.btnPickFolderIncludeUsersAdditionalProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFolderIncludeUsersAdditionalProperties.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickFolderIncludeUsersAdditionalProperties.Location = new System.Drawing.Point(940, 340);
            this.btnPickFolderIncludeUsersAdditionalProperties.Name = "btnPickFolderIncludeUsersAdditionalProperties";
            this.btnPickFolderIncludeUsersAdditionalProperties.Size = new System.Drawing.Size(43, 24);
            this.btnPickFolderIncludeUsersAdditionalProperties.TabIndex = 22;
            this.btnPickFolderIncludeUsersAdditionalProperties.Text = "...";
            this.btnPickFolderIncludeUsersAdditionalProperties.UseVisualStyleBackColor = true;
            this.btnPickFolderIncludeUsersAdditionalProperties.Click += new System.EventHandler(this.btnPickFolderIncludeUsersAdditionalProperties_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Import from CSV:";
            // 
            // rdoBase64EncodeStrings
            // 
            this.rdoBase64EncodeStrings.AutoSize = true;
            this.rdoBase64EncodeStrings.Enabled = false;
            this.rdoBase64EncodeStrings.Location = new System.Drawing.Point(420, 24);
            this.rdoBase64EncodeStrings.Name = "rdoBase64EncodeStrings";
            this.rdoBase64EncodeStrings.Size = new System.Drawing.Size(129, 21);
            this.rdoBase64EncodeStrings.TabIndex = 24;
            this.rdoBase64EncodeStrings.Text = "Base64 Encode";
            this.rdoBase64EncodeStrings.UseVisualStyleBackColor = true;
            // 
            // rdoSanitizeStrings
            // 
            this.rdoSanitizeStrings.AutoSize = true;
            this.rdoSanitizeStrings.Checked = true;
            this.rdoSanitizeStrings.Enabled = false;
            this.rdoSanitizeStrings.Location = new System.Drawing.Point(12, 24);
            this.rdoSanitizeStrings.Name = "rdoSanitizeStrings";
            this.rdoSanitizeStrings.Size = new System.Drawing.Size(279, 21);
            this.rdoSanitizeStrings.TabIndex = 25;
            this.rdoSanitizeStrings.TabStop = true;
            this.rdoSanitizeStrings.Text = "Sanitize - Remove commas, CRLF, etc.)";
            this.rdoSanitizeStrings.UseVisualStyleBackColor = true;
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
            this.grpStringHandling.Location = new System.Drawing.Point(33, 396);
            this.grpStringHandling.Name = "grpStringHandling";
            this.grpStringHandling.Size = new System.Drawing.Size(951, 82);
            this.grpStringHandling.TabIndex = 26;
            this.grpStringHandling.TabStop = false;
            this.grpStringHandling.Text = "Exported data handling";
            this.grpStringHandling.Enter += new System.EventHandler(this.grpStringHandling_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(932, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "The data being exported may contain characters which will prevent loading the SCV" +
    " such as commas or CRLF, so special handling may be needed.";
            // 
            // rdoHexEncodeStrings
            // 
            this.rdoHexEncodeStrings.AutoSize = true;
            this.rdoHexEncodeStrings.Enabled = false;
            this.rdoHexEncodeStrings.Location = new System.Drawing.Point(297, 24);
            this.rdoHexEncodeStrings.Name = "rdoHexEncodeStrings";
            this.rdoHexEncodeStrings.Size = new System.Drawing.Size(105, 21);
            this.rdoHexEncodeStrings.TabIndex = 28;
            this.rdoHexEncodeStrings.Text = "Hex Encode";
            this.rdoHexEncodeStrings.UseVisualStyleBackColor = true;
            // 
            // rdoNone
            // 
            this.rdoNone.AutoSize = true;
            this.rdoNone.Enabled = false;
            this.rdoNone.Location = new System.Drawing.Point(555, 24);
            this.rdoNone.Name = "rdoNone";
            this.rdoNone.Size = new System.Drawing.Size(63, 21);
            this.rdoNone.TabIndex = 27;
            this.rdoNone.Text = "None";
            this.rdoNone.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rdoExportAllGridData);
            this.groupBox2.Controls.Add(this.rdoExcludeAllGridContentExceptFolderPath);
            this.groupBox2.Controls.Add(this.rdoExcludeAllSearchGridContent);
            this.groupBox2.Location = new System.Drawing.Point(33, 484);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(951, 54);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Grid Exclusions";
            // 
            // rdoExportAllGridData
            // 
            this.rdoExportAllGridData.AutoSize = true;
            this.rdoExportAllGridData.Checked = true;
            this.rdoExportAllGridData.Enabled = false;
            this.rdoExportAllGridData.Location = new System.Drawing.Point(18, 21);
            this.rdoExportAllGridData.Name = "rdoExportAllGridData";
            this.rdoExportAllGridData.Size = new System.Drawing.Size(88, 21);
            this.rdoExportAllGridData.TabIndex = 35;
            this.rdoExportAllGridData.TabStop = true;
            this.rdoExportAllGridData.Text = "Export All";
            this.rdoExportAllGridData.UseVisualStyleBackColor = true;
            // 
            // rdoExcludeAllGridContentExceptFolderPath
            // 
            this.rdoExcludeAllGridContentExceptFolderPath.AutoSize = true;
            this.rdoExcludeAllGridContentExceptFolderPath.Checked = true;
            this.rdoExcludeAllGridContentExceptFolderPath.Enabled = false;
            this.rdoExcludeAllGridContentExceptFolderPath.Location = new System.Drawing.Point(112, 21);
            this.rdoExcludeAllGridContentExceptFolderPath.Name = "rdoExcludeAllGridContentExceptFolderPath";
            this.rdoExcludeAllGridContentExceptFolderPath.Size = new System.Drawing.Size(352, 21);
            this.rdoExcludeAllGridContentExceptFolderPath.TabIndex = 34;
            this.rdoExcludeAllGridContentExceptFolderPath.TabStop = true;
            this.rdoExcludeAllGridContentExceptFolderPath.Text = "Exclude all Search Grid Content Except Folder Path";
            this.rdoExcludeAllGridContentExceptFolderPath.UseVisualStyleBackColor = true;
            // 
            // rdoExcludeAllSearchGridContent
            // 
            this.rdoExcludeAllSearchGridContent.AutoSize = true;
            this.rdoExcludeAllSearchGridContent.Checked = true;
            this.rdoExcludeAllSearchGridContent.Enabled = false;
            this.rdoExcludeAllSearchGridContent.Location = new System.Drawing.Point(493, 21);
            this.rdoExcludeAllSearchGridContent.Name = "rdoExcludeAllSearchGridContent";
            this.rdoExcludeAllSearchGridContent.Size = new System.Drawing.Size(229, 21);
            this.rdoExcludeAllSearchGridContent.TabIndex = 30;
            this.rdoExcludeAllSearchGridContent.TabStop = true;
            this.rdoExcludeAllSearchGridContent.Text = "Exclude all Search Grid Content";
            this.rdoExcludeAllSearchGridContent.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 376);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 17);
            this.label8.TabIndex = 31;
            this.label8.Text = "Export Options:";
            this.label8.Visible = false;
            // 
            // chkConvertBase64BinaryHex
            // 
            this.chkConvertBase64BinaryHex.AutoSize = true;
            this.chkConvertBase64BinaryHex.Location = new System.Drawing.Point(33, 544);
            this.chkConvertBase64BinaryHex.Name = "chkConvertBase64BinaryHex";
            this.chkConvertBase64BinaryHex.Size = new System.Drawing.Size(198, 21);
            this.chkConvertBase64BinaryHex.TabIndex = 33;
            this.chkConvertBase64BinaryHex.Text = "Encode binary data as hex";
            this.chkConvertBase64BinaryHex.UseVisualStyleBackColor = true;
            // 
            // SearchCalendarExportPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 629);
            this.Controls.Add(this.chkConvertBase64BinaryHex);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpStringHandling);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnPickFolderIncludeUsersAdditionalProperties);
            this.Controls.Add(this.txtIncludeUsersAdditionalPropertiesFile);
            this.Controls.Add(this.chkIncludeUsersAdditionalProperties);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.OkButton);
            this.Name = "SearchCalendarExportPicker";
            this.Text = "Select Export Type";
            this.Load += new System.EventHandler(this.SearchCalendarExportPicker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpStringHandling.ResumeLayout(false);
            this.grpStringHandling.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        public System.Windows.Forms.CheckBox chkIncludeUsersAdditionalProperties;
        public System.Windows.Forms.TextBox txtIncludeUsersAdditionalPropertiesFile;
        private System.Windows.Forms.Button btnPickFolderIncludeUsersAdditionalProperties;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.RadioButton rdoBase64EncodeStrings;
        public System.Windows.Forms.RadioButton rdoSanitizeStrings;
        private System.Windows.Forms.GroupBox grpStringHandling;
        public System.Windows.Forms.RadioButton rdoNone;
        public System.Windows.Forms.RadioButton rdoHexEncodeStrings;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.CheckBox chkConvertBase64BinaryHex;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.RadioButton rdoExportAllGridData;
        public System.Windows.Forms.RadioButton rdoExcludeAllGridContentExceptFolderPath;
        public System.Windows.Forms.RadioButton rdoExcludeAllSearchGridContent;
    }
}