﻿namespace EWSEditor.Forms
{
    partial class CalendarInstanceForm
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkIsRecurring = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmboImportance = new System.Windows.Forms.ComboBox();
            this.chkIsAllDayEvent = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOptionalAttendees = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRequiredAttendees = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.lblBody = new System.Windows.Forms.Label();
            this.txtOrganizer = new System.Windows.Forms.TextBox();
            this.lblOrganizer = new System.Windows.Forms.Label();
            this.txtAppointmentType = new System.Windows.Forms.TextBox();
            this.lblAppointmentType = new System.Windows.Forms.Label();
            this.grpSchedule = new System.Windows.Forms.GroupBox();
            this.chkSetDurationEndTimezone = new System.Windows.Forms.CheckBox();
            this.chkSetDurationStartTimezone = new System.Windows.Forms.CheckBox();
            this.cmboDurationEndTimezone = new System.Windows.Forms.ComboBox();
            this.lblDurationEndTimezone = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmboDurationStartTimezone = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDurationEndTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDurationEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtDurationStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtDurationStartTime = new System.Windows.Forms.DateTimePicker();
            this.txtResourceAttendees = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtICalDateTimeStamp = new System.Windows.Forms.TextBox();
            this.lblICalDateTimeStamp = new System.Windows.Forms.Label();
            this.txtICalRecurrenceId = new System.Windows.Forms.TextBox();
            this.lblICalRecurrenceId = new System.Windows.Forms.Label();
            this.txtICalUid = new System.Windows.Forms.TextBox();
            this.lblICalUid = new System.Windows.Forms.Label();
            this.txtConversationId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtChangeKey = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.cmboLegacyFreeBusyStatus = new System.Windows.Forms.ComboBox();
            this.btnAttendeeStatus = new System.Windows.Forms.Button();
            this.cmboCategories = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblGlobalObjectId = new System.Windows.Forms.Label();
            this.txtGlobalObjectId = new System.Windows.Forms.TextBox();
            this.btnAttachments = new System.Windows.Forms.Button();
            this.btnEditInLargerWindow = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.lblForwardTo = new System.Windows.Forms.Label();
            this.txtForwardTo = new System.Windows.Forms.TextBox();
            this.grpSchedule.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(189, 7);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(160, 45);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 7);
            this.btnSave.Margin = new System.Windows.Forms.Padding(7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 45);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkIsRecurring
            // 
            this.chkIsRecurring.AutoSize = true;
            this.chkIsRecurring.Enabled = false;
            this.chkIsRecurring.Location = new System.Drawing.Point(1371, 221);
            this.chkIsRecurring.Margin = new System.Windows.Forms.Padding(7);
            this.chkIsRecurring.Name = "chkIsRecurring";
            this.chkIsRecurring.Size = new System.Drawing.Size(159, 29);
            this.chkIsRecurring.TabIndex = 21;
            this.chkIsRecurring.Text = "Is Recurring";
            this.chkIsRecurring.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 104);
            this.label8.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 25);
            this.label8.TabIndex = 9;
            this.label8.Text = "Importance:";
            // 
            // cmboImportance
            // 
            this.cmboImportance.FormattingEnabled = true;
            this.cmboImportance.Items.AddRange(new object[] {
            "Free",
            "Tentative",
            "Busy",
            "Out Of Office"});
            this.cmboImportance.Location = new System.Drawing.Point(161, 99);
            this.cmboImportance.Margin = new System.Windows.Forms.Padding(7);
            this.cmboImportance.Name = "cmboImportance";
            this.cmboImportance.Size = new System.Drawing.Size(253, 33);
            this.cmboImportance.TabIndex = 10;
            this.cmboImportance.Text = "Normal";
            this.cmboImportance.SelectedIndexChanged += new System.EventHandler(this.cmboImportance_SelectedIndexChanged);
            // 
            // chkIsAllDayEvent
            // 
            this.chkIsAllDayEvent.AutoSize = true;
            this.chkIsAllDayEvent.Location = new System.Drawing.Point(1371, 175);
            this.chkIsAllDayEvent.Margin = new System.Windows.Forms.Padding(7);
            this.chkIsAllDayEvent.Name = "chkIsAllDayEvent";
            this.chkIsAllDayEvent.Size = new System.Drawing.Size(195, 29);
            this.chkIsAllDayEvent.TabIndex = 20;
            this.chkIsAllDayEvent.Text = "Is All Day Event";
            this.chkIsAllDayEvent.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(361, 7);
            this.btnSend.Margin = new System.Windows.Forms.Padding(7);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(160, 45);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(139, 328);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(7);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(969, 31);
            this.txtLocation.TabIndex = 25;
            this.txtLocation.TextChanged += new System.EventHandler(this.txtLocation_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 335);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 25);
            this.label6.TabIndex = 24;
            this.label6.Text = "Location:";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(139, 280);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(7);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(969, 31);
            this.txtSubject.TabIndex = 23;
            this.txtSubject.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 285);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 25);
            this.label5.TabIndex = 22;
            this.label5.Text = "Subject:";
            // 
            // txtOptionalAttendees
            // 
            this.txtOptionalAttendees.Location = new System.Drawing.Point(257, 184);
            this.txtOptionalAttendees.Margin = new System.Windows.Forms.Padding(7);
            this.txtOptionalAttendees.Name = "txtOptionalAttendees";
            this.txtOptionalAttendees.Size = new System.Drawing.Size(1083, 31);
            this.txtOptionalAttendees.TabIndex = 17;
            this.txtOptionalAttendees.TextChanged += new System.EventHandler(this.txtOptionalAttendees_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 189);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Optional Attendees:";
            // 
            // txtRequiredAttendees
            // 
            this.txtRequiredAttendees.Location = new System.Drawing.Point(257, 143);
            this.txtRequiredAttendees.Margin = new System.Windows.Forms.Padding(7);
            this.txtRequiredAttendees.Name = "txtRequiredAttendees";
            this.txtRequiredAttendees.Size = new System.Drawing.Size(1083, 31);
            this.txtRequiredAttendees.TabIndex = 15;
            this.txtRequiredAttendees.TextChanged += new System.EventHandler(this.txtRequiredAttendees_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 151);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "RequiredAttendees:";
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(139, 404);
            this.txtBody.Margin = new System.Windows.Forms.Padding(7);
            this.txtBody.MaxLength = 0;
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBody.Size = new System.Drawing.Size(1416, 135);
            this.txtBody.TabIndex = 27;
            this.txtBody.TextChanged += new System.EventHandler(this.txtBody_TextChanged);
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Location = new System.Drawing.Point(16, 373);
            this.lblBody.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(67, 25);
            this.lblBody.TabIndex = 26;
            this.lblBody.Text = "Body:";
            // 
            // txtOrganizer
            // 
            this.txtOrganizer.Enabled = false;
            this.txtOrganizer.Location = new System.Drawing.Point(161, 56);
            this.txtOrganizer.Margin = new System.Windows.Forms.Padding(7);
            this.txtOrganizer.Name = "txtOrganizer";
            this.txtOrganizer.ReadOnly = true;
            this.txtOrganizer.Size = new System.Drawing.Size(452, 31);
            this.txtOrganizer.TabIndex = 6;
            // 
            // lblOrganizer
            // 
            this.lblOrganizer.AutoSize = true;
            this.lblOrganizer.Location = new System.Drawing.Point(13, 61);
            this.lblOrganizer.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblOrganizer.Name = "lblOrganizer";
            this.lblOrganizer.Size = new System.Drawing.Size(112, 25);
            this.lblOrganizer.TabIndex = 5;
            this.lblOrganizer.Text = "Organizer:";
            // 
            // txtAppointmentType
            // 
            this.txtAppointmentType.Enabled = false;
            this.txtAppointmentType.Location = new System.Drawing.Point(853, 56);
            this.txtAppointmentType.Margin = new System.Windows.Forms.Padding(7);
            this.txtAppointmentType.Name = "txtAppointmentType";
            this.txtAppointmentType.ReadOnly = true;
            this.txtAppointmentType.Size = new System.Drawing.Size(289, 31);
            this.txtAppointmentType.TabIndex = 8;
            // 
            // lblAppointmentType
            // 
            this.lblAppointmentType.AutoSize = true;
            this.lblAppointmentType.Location = new System.Drawing.Point(643, 56);
            this.lblAppointmentType.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblAppointmentType.Name = "lblAppointmentType";
            this.lblAppointmentType.Size = new System.Drawing.Size(186, 25);
            this.lblAppointmentType.TabIndex = 7;
            this.lblAppointmentType.Text = "AppointmentType:";
            // 
            // grpSchedule
            // 
            this.grpSchedule.Controls.Add(this.chkSetDurationEndTimezone);
            this.grpSchedule.Controls.Add(this.chkSetDurationStartTimezone);
            this.grpSchedule.Controls.Add(this.cmboDurationEndTimezone);
            this.grpSchedule.Controls.Add(this.lblDurationEndTimezone);
            this.grpSchedule.Controls.Add(this.label12);
            this.grpSchedule.Controls.Add(this.cmboDurationStartTimezone);
            this.grpSchedule.Controls.Add(this.label3);
            this.grpSchedule.Controls.Add(this.dtDurationEndTime);
            this.grpSchedule.Controls.Add(this.label2);
            this.grpSchedule.Controls.Add(this.dtDurationEndDate);
            this.grpSchedule.Controls.Add(this.dtDurationStartDate);
            this.grpSchedule.Controls.Add(this.dtDurationStartTime);
            this.grpSchedule.Location = new System.Drawing.Point(16, 552);
            this.grpSchedule.Margin = new System.Windows.Forms.Padding(7);
            this.grpSchedule.Name = "grpSchedule";
            this.grpSchedule.Padding = new System.Windows.Forms.Padding(7);
            this.grpSchedule.Size = new System.Drawing.Size(1551, 129);
            this.grpSchedule.TabIndex = 28;
            this.grpSchedule.TabStop = false;
            this.grpSchedule.Text = "Scheduled:";
            this.grpSchedule.Enter += new System.EventHandler(this.grpSchedule_Enter);
            // 
            // chkSetDurationEndTimezone
            // 
            this.chkSetDurationEndTimezone.AutoSize = true;
            this.chkSetDurationEndTimezone.Location = new System.Drawing.Point(816, 79);
            this.chkSetDurationEndTimezone.Margin = new System.Windows.Forms.Padding(7);
            this.chkSetDurationEndTimezone.Name = "chkSetDurationEndTimezone";
            this.chkSetDurationEndTimezone.Size = new System.Drawing.Size(28, 27);
            this.chkSetDurationEndTimezone.TabIndex = 113;
            this.chkSetDurationEndTimezone.UseVisualStyleBackColor = true;
            this.chkSetDurationEndTimezone.CheckedChanged += new System.EventHandler(this.chkSetDurationEndTimezone_CheckedChanged);
            // 
            // chkSetDurationStartTimezone
            // 
            this.chkSetDurationStartTimezone.AutoSize = true;
            this.chkSetDurationStartTimezone.Location = new System.Drawing.Point(816, 33);
            this.chkSetDurationStartTimezone.Margin = new System.Windows.Forms.Padding(7);
            this.chkSetDurationStartTimezone.Name = "chkSetDurationStartTimezone";
            this.chkSetDurationStartTimezone.Size = new System.Drawing.Size(28, 27);
            this.chkSetDurationStartTimezone.TabIndex = 112;
            this.chkSetDurationStartTimezone.UseVisualStyleBackColor = true;
            this.chkSetDurationStartTimezone.CheckedChanged += new System.EventHandler(this.chkSetDurationStartTimezone_CheckedChanged);
            // 
            // cmboDurationEndTimezone
            // 
            this.cmboDurationEndTimezone.FormattingEnabled = true;
            this.cmboDurationEndTimezone.Items.AddRange(new object[] {
            "Free",
            "Tentative",
            "Busy",
            "Out Of Office"});
            this.cmboDurationEndTimezone.Location = new System.Drawing.Point(849, 72);
            this.cmboDurationEndTimezone.Margin = new System.Windows.Forms.Padding(7);
            this.cmboDurationEndTimezone.Name = "cmboDurationEndTimezone";
            this.cmboDurationEndTimezone.Size = new System.Drawing.Size(689, 33);
            this.cmboDurationEndTimezone.TabIndex = 9;
            this.cmboDurationEndTimezone.SelectedIndexChanged += new System.EventHandler(this.cmboDurationEndTimezone_SelectedIndexChanged);
            // 
            // lblDurationEndTimezone
            // 
            this.lblDurationEndTimezone.AutoSize = true;
            this.lblDurationEndTimezone.Location = new System.Drawing.Point(773, 79);
            this.lblDurationEndTimezone.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblDurationEndTimezone.Name = "lblDurationEndTimezone";
            this.lblDurationEndTimezone.Size = new System.Drawing.Size(44, 25);
            this.lblDurationEndTimezone.TabIndex = 8;
            this.lblDurationEndTimezone.Text = "TZ:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(773, 35);
            this.label12.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 25);
            this.label12.TabIndex = 3;
            this.label12.Text = "TZ:";
            // 
            // cmboDurationStartTimezone
            // 
            this.cmboDurationStartTimezone.FormattingEnabled = true;
            this.cmboDurationStartTimezone.Items.AddRange(new object[] {
            "Free",
            "Tentative",
            "Busy",
            "Out Of Office"});
            this.cmboDurationStartTimezone.Location = new System.Drawing.Point(849, 29);
            this.cmboDurationStartTimezone.Margin = new System.Windows.Forms.Padding(7);
            this.cmboDurationStartTimezone.Name = "cmboDurationStartTimezone";
            this.cmboDurationStartTimezone.Size = new System.Drawing.Size(689, 33);
            this.cmboDurationStartTimezone.TabIndex = 4;
            this.cmboDurationStartTimezone.SelectedIndexChanged += new System.EventHandler(this.cmboDurationStartTimezone_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Duration End:";
            // 
            // dtDurationEndTime
            // 
            this.dtDurationEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtDurationEndTime.Location = new System.Drawing.Point(585, 77);
            this.dtDurationEndTime.Margin = new System.Windows.Forms.Padding(7);
            this.dtDurationEndTime.Name = "dtDurationEndTime";
            this.dtDurationEndTime.ShowUpDown = true;
            this.dtDurationEndTime.Size = new System.Drawing.Size(165, 31);
            this.dtDurationEndTime.TabIndex = 7;
            this.dtDurationEndTime.ValueChanged += new System.EventHandler(this.dtDurationEndTime_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Duration Start:";
            // 
            // dtDurationEndDate
            // 
            this.dtDurationEndDate.Location = new System.Drawing.Point(175, 77);
            this.dtDurationEndDate.Margin = new System.Windows.Forms.Padding(7);
            this.dtDurationEndDate.Name = "dtDurationEndDate";
            this.dtDurationEndDate.Size = new System.Drawing.Size(397, 31);
            this.dtDurationEndDate.TabIndex = 6;
            this.dtDurationEndDate.ValueChanged += new System.EventHandler(this.dtDurationEndDate_ValueChanged);
            // 
            // dtDurationStartDate
            // 
            this.dtDurationStartDate.Location = new System.Drawing.Point(175, 25);
            this.dtDurationStartDate.Margin = new System.Windows.Forms.Padding(7);
            this.dtDurationStartDate.Name = "dtDurationStartDate";
            this.dtDurationStartDate.Size = new System.Drawing.Size(397, 31);
            this.dtDurationStartDate.TabIndex = 1;
            this.dtDurationStartDate.ValueChanged += new System.EventHandler(this.dtDurationStartDate_ValueChanged);
            // 
            // dtDurationStartTime
            // 
            this.dtDurationStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtDurationStartTime.Location = new System.Drawing.Point(585, 27);
            this.dtDurationStartTime.Margin = new System.Windows.Forms.Padding(7);
            this.dtDurationStartTime.Name = "dtDurationStartTime";
            this.dtDurationStartTime.ShowUpDown = true;
            this.dtDurationStartTime.Size = new System.Drawing.Size(165, 31);
            this.dtDurationStartTime.TabIndex = 2;
            this.dtDurationStartTime.Value = new System.DateTime(2024, 1, 4, 15, 21, 24, 0);
            this.dtDurationStartTime.ValueChanged += new System.EventHandler(this.dtDurationStartTime_ValueChanged);
            // 
            // txtResourceAttendees
            // 
            this.txtResourceAttendees.Location = new System.Drawing.Point(257, 232);
            this.txtResourceAttendees.Margin = new System.Windows.Forms.Padding(7);
            this.txtResourceAttendees.Name = "txtResourceAttendees";
            this.txtResourceAttendees.Size = new System.Drawing.Size(1083, 31);
            this.txtResourceAttendees.TabIndex = 19;
            this.txtResourceAttendees.TextChanged += new System.EventHandler(this.txtResourceAttendees_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 237);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "Resource Attendees:";
            // 
            // txtICalDateTimeStamp
            // 
            this.txtICalDateTimeStamp.Location = new System.Drawing.Point(251, 795);
            this.txtICalDateTimeStamp.Margin = new System.Windows.Forms.Padding(7);
            this.txtICalDateTimeStamp.Name = "txtICalDateTimeStamp";
            this.txtICalDateTimeStamp.ReadOnly = true;
            this.txtICalDateTimeStamp.Size = new System.Drawing.Size(516, 31);
            this.txtICalDateTimeStamp.TabIndex = 34;
            // 
            // lblICalDateTimeStamp
            // 
            this.lblICalDateTimeStamp.AutoSize = true;
            this.lblICalDateTimeStamp.Location = new System.Drawing.Point(17, 801);
            this.lblICalDateTimeStamp.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblICalDateTimeStamp.Name = "lblICalDateTimeStamp";
            this.lblICalDateTimeStamp.Size = new System.Drawing.Size(208, 25);
            this.lblICalDateTimeStamp.TabIndex = 33;
            this.lblICalDateTimeStamp.Text = "ICalDateTimeStamp:";
            // 
            // txtICalRecurrenceId
            // 
            this.txtICalRecurrenceId.Location = new System.Drawing.Point(248, 744);
            this.txtICalRecurrenceId.Margin = new System.Windows.Forms.Padding(7);
            this.txtICalRecurrenceId.Name = "txtICalRecurrenceId";
            this.txtICalRecurrenceId.ReadOnly = true;
            this.txtICalRecurrenceId.Size = new System.Drawing.Size(516, 31);
            this.txtICalRecurrenceId.TabIndex = 32;
            // 
            // lblICalRecurrenceId
            // 
            this.lblICalRecurrenceId.AutoSize = true;
            this.lblICalRecurrenceId.Location = new System.Drawing.Point(17, 751);
            this.lblICalRecurrenceId.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblICalRecurrenceId.Name = "lblICalRecurrenceId";
            this.lblICalRecurrenceId.Size = new System.Drawing.Size(183, 25);
            this.lblICalRecurrenceId.TabIndex = 31;
            this.lblICalRecurrenceId.Text = "ICalRecurrenceId:";
            // 
            // txtICalUid
            // 
            this.txtICalUid.Location = new System.Drawing.Point(248, 691);
            this.txtICalUid.Margin = new System.Windows.Forms.Padding(7);
            this.txtICalUid.Name = "txtICalUid";
            this.txtICalUid.ReadOnly = true;
            this.txtICalUid.Size = new System.Drawing.Size(516, 31);
            this.txtICalUid.TabIndex = 30;
            // 
            // lblICalUid
            // 
            this.lblICalUid.AutoSize = true;
            this.lblICalUid.Location = new System.Drawing.Point(19, 703);
            this.lblICalUid.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblICalUid.Name = "lblICalUid";
            this.lblICalUid.Size = new System.Drawing.Size(87, 25);
            this.lblICalUid.TabIndex = 29;
            this.lblICalUid.Text = "ICalUid:";
            // 
            // txtConversationId
            // 
            this.txtConversationId.Location = new System.Drawing.Point(1023, 791);
            this.txtConversationId.Margin = new System.Windows.Forms.Padding(7);
            this.txtConversationId.Name = "txtConversationId";
            this.txtConversationId.ReadOnly = true;
            this.txtConversationId.Size = new System.Drawing.Size(516, 31);
            this.txtConversationId.TabIndex = 40;
            this.txtConversationId.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(792, 795);
            this.label9.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 25);
            this.label9.TabIndex = 39;
            this.label9.Text = "ConversationId:";
            this.label9.Visible = false;
            // 
            // txtChangeKey
            // 
            this.txtChangeKey.Location = new System.Drawing.Point(1023, 739);
            this.txtChangeKey.Margin = new System.Windows.Forms.Padding(7);
            this.txtChangeKey.Name = "txtChangeKey";
            this.txtChangeKey.ReadOnly = true;
            this.txtChangeKey.Size = new System.Drawing.Size(516, 31);
            this.txtChangeKey.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(792, 744);
            this.label11.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 25);
            this.label11.TabIndex = 37;
            this.label11.Text = "ChangeKey:";
            // 
            // txtItemId
            // 
            this.txtItemId.Location = new System.Drawing.Point(1023, 689);
            this.txtItemId.Margin = new System.Windows.Forms.Padding(7);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.ReadOnly = true;
            this.txtItemId.Size = new System.Drawing.Size(516, 31);
            this.txtItemId.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(795, 697);
            this.label14.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 25);
            this.label14.TabIndex = 35;
            this.label14.Text = "ItemId:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(431, 104);
            this.label34.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(171, 25);
            this.label34.TabIndex = 11;
            this.label34.Text = "FreeBusyStatus:";
            // 
            // cmboLegacyFreeBusyStatus
            // 
            this.cmboLegacyFreeBusyStatus.FormattingEnabled = true;
            this.cmboLegacyFreeBusyStatus.Location = new System.Drawing.Point(623, 99);
            this.cmboLegacyFreeBusyStatus.Margin = new System.Windows.Forms.Padding(7);
            this.cmboLegacyFreeBusyStatus.Name = "cmboLegacyFreeBusyStatus";
            this.cmboLegacyFreeBusyStatus.Size = new System.Drawing.Size(204, 33);
            this.cmboLegacyFreeBusyStatus.TabIndex = 12;
            this.cmboLegacyFreeBusyStatus.Text = "OOF";
            // 
            // btnAttendeeStatus
            // 
            this.btnAttendeeStatus.Location = new System.Drawing.Point(1371, 21);
            this.btnAttendeeStatus.Margin = new System.Windows.Forms.Padding(7);
            this.btnAttendeeStatus.Name = "btnAttendeeStatus";
            this.btnAttendeeStatus.Size = new System.Drawing.Size(200, 45);
            this.btnAttendeeStatus.TabIndex = 3;
            this.btnAttendeeStatus.Text = "Attendee Status";
            this.btnAttendeeStatus.UseVisualStyleBackColor = true;
            this.btnAttendeeStatus.Click += new System.EventHandler(this.btnAttendeeStatus_Click);
            // 
            // cmboCategories
            // 
            this.cmboCategories.FormattingEnabled = true;
            this.cmboCategories.Location = new System.Drawing.Point(997, 96);
            this.cmboCategories.Margin = new System.Windows.Forms.Padding(7);
            this.cmboCategories.Name = "cmboCategories";
            this.cmboCategories.Size = new System.Drawing.Size(253, 33);
            this.cmboCategories.TabIndex = 14;
            this.cmboCategories.Text = "Normal";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(856, 104);
            this.label10.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 25);
            this.label10.TabIndex = 13;
            this.label10.Text = "Categories:";
            // 
            // lblGlobalObjectId
            // 
            this.lblGlobalObjectId.AutoSize = true;
            this.lblGlobalObjectId.Location = new System.Drawing.Point(793, 843);
            this.lblGlobalObjectId.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblGlobalObjectId.Name = "lblGlobalObjectId";
            this.lblGlobalObjectId.Size = new System.Drawing.Size(171, 25);
            this.lblGlobalObjectId.TabIndex = 41;
            this.lblGlobalObjectId.Text = "Global Object Id:";
            // 
            // txtGlobalObjectId
            // 
            this.txtGlobalObjectId.Enabled = false;
            this.txtGlobalObjectId.Location = new System.Drawing.Point(1023, 839);
            this.txtGlobalObjectId.Margin = new System.Windows.Forms.Padding(7);
            this.txtGlobalObjectId.Name = "txtGlobalObjectId";
            this.txtGlobalObjectId.ReadOnly = true;
            this.txtGlobalObjectId.Size = new System.Drawing.Size(516, 31);
            this.txtGlobalObjectId.TabIndex = 42;
            // 
            // btnAttachments
            // 
            this.btnAttachments.Location = new System.Drawing.Point(1371, 87);
            this.btnAttachments.Margin = new System.Windows.Forms.Padding(7);
            this.btnAttachments.Name = "btnAttachments";
            this.btnAttachments.Size = new System.Drawing.Size(200, 45);
            this.btnAttachments.TabIndex = 4;
            this.btnAttachments.Tag = "";
            this.btnAttachments.Text = "Attachments";
            this.btnAttachments.UseVisualStyleBackColor = true;
            this.btnAttachments.Click += new System.EventHandler(this.btnAttachments_Click);
            // 
            // btnEditInLargerWindow
            // 
            this.btnEditInLargerWindow.Location = new System.Drawing.Point(1344, 361);
            this.btnEditInLargerWindow.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnEditInLargerWindow.Name = "btnEditInLargerWindow";
            this.btnEditInLargerWindow.Size = new System.Drawing.Size(228, 39);
            this.btnEditInLargerWindow.TabIndex = 26;
            this.btnEditInLargerWindow.Text = "Edit in larger window";
            this.btnEditInLargerWindow.UseVisualStyleBackColor = true;
            this.btnEditInLargerWindow.Click += new System.EventHandler(this.btnEditInLargerWindow_Click);
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(604, 7);
            this.btnForward.Margin = new System.Windows.Forms.Padding(7);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(160, 45);
            this.btnForward.TabIndex = 43;
            this.btnForward.Text = "Forward";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Visible = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // lblForwardTo
            // 
            this.lblForwardTo.AutoSize = true;
            this.lblForwardTo.Location = new System.Drawing.Point(768, 14);
            this.lblForwardTo.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblForwardTo.Name = "lblForwardTo";
            this.lblForwardTo.Size = new System.Drawing.Size(127, 25);
            this.lblForwardTo.TabIndex = 44;
            this.lblForwardTo.Text = "Forward To:";
            // 
            // txtForwardTo
            // 
            this.txtForwardTo.Location = new System.Drawing.Point(922, 14);
            this.txtForwardTo.Margin = new System.Windows.Forms.Padding(7);
            this.txtForwardTo.Name = "txtForwardTo";
            this.txtForwardTo.Size = new System.Drawing.Size(400, 31);
            this.txtForwardTo.TabIndex = 45;
            // 
            // CalendarInstanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1592, 914);
            this.Controls.Add(this.txtForwardTo);
            this.Controls.Add(this.lblForwardTo);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnEditInLargerWindow);
            this.Controls.Add(this.btnAttachments);
            this.Controls.Add(this.txtGlobalObjectId);
            this.Controls.Add(this.lblGlobalObjectId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmboCategories);
            this.Controls.Add(this.btnAttendeeStatus);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.cmboLegacyFreeBusyStatus);
            this.Controls.Add(this.txtConversationId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtChangeKey);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtItemId);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtICalDateTimeStamp);
            this.Controls.Add(this.lblICalDateTimeStamp);
            this.Controls.Add(this.txtICalRecurrenceId);
            this.Controls.Add(this.lblICalRecurrenceId);
            this.Controls.Add(this.txtICalUid);
            this.Controls.Add(this.lblICalUid);
            this.Controls.Add(this.txtResourceAttendees);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpSchedule);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkIsRecurring);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmboImportance);
            this.Controls.Add(this.chkIsAllDayEvent);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOptionalAttendees);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRequiredAttendees);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.txtOrganizer);
            this.Controls.Add(this.lblOrganizer);
            this.Controls.Add(this.txtAppointmentType);
            this.Controls.Add(this.lblAppointmentType);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "CalendarInstanceForm";
            this.Text = "CalendarInstanceForm";
            this.Load += new System.EventHandler(this.CalendarInstanceForm_Load);
            this.grpSchedule.ResumeLayout(false);
            this.grpSchedule.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkIsRecurring;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmboImportance;
        private System.Windows.Forms.CheckBox chkIsAllDayEvent;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOptionalAttendees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRequiredAttendees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.TextBox txtOrganizer;
        private System.Windows.Forms.Label lblOrganizer;
        private System.Windows.Forms.TextBox txtAppointmentType;
        private System.Windows.Forms.Label lblAppointmentType;
        private System.Windows.Forms.GroupBox grpSchedule;
        private System.Windows.Forms.ComboBox cmboDurationEndTimezone;
        private System.Windows.Forms.Label lblDurationEndTimezone;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmboDurationStartTimezone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDurationEndTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDurationEndDate;
        private System.Windows.Forms.DateTimePicker dtDurationStartDate;
        private System.Windows.Forms.DateTimePicker dtDurationStartTime;
        private System.Windows.Forms.TextBox txtResourceAttendees;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtICalDateTimeStamp;
        private System.Windows.Forms.Label lblICalDateTimeStamp;
        private System.Windows.Forms.TextBox txtICalRecurrenceId;
        private System.Windows.Forms.Label lblICalRecurrenceId;
        private System.Windows.Forms.TextBox txtICalUid;
        private System.Windows.Forms.Label lblICalUid;
        private System.Windows.Forms.TextBox txtConversationId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtChangeKey;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.ComboBox cmboLegacyFreeBusyStatus;
        private System.Windows.Forms.Button btnAttendeeStatus;
        private System.Windows.Forms.ComboBox cmboCategories;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblGlobalObjectId;
        private System.Windows.Forms.TextBox txtGlobalObjectId;
        private System.Windows.Forms.Button btnAttachments;
        private System.Windows.Forms.CheckBox chkSetDurationStartTimezone;
        private System.Windows.Forms.CheckBox chkSetDurationEndTimezone;
        private System.Windows.Forms.Button btnEditInLargerWindow;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Label lblForwardTo;
        private System.Windows.Forms.TextBox txtForwardTo;
    }
}