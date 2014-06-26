namespace EWSEditor.Forms
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
            this.cmboTimezone = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.grpTimeZone = new System.Windows.Forms.GroupBox();
            this.grpSchedule.SuspendLayout();
            this.grpTimeZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(102, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkIsRecurring
            // 
            this.chkIsRecurring.AutoSize = true;
            this.chkIsRecurring.Enabled = false;
            this.chkIsRecurring.Location = new System.Drawing.Point(716, 105);
            this.chkIsRecurring.Name = "chkIsRecurring";
            this.chkIsRecurring.Size = new System.Drawing.Size(83, 17);
            this.chkIsRecurring.TabIndex = 15;
            this.chkIsRecurring.Text = "Is Recurring";
            this.chkIsRecurring.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 10;
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
            this.cmboImportance.Location = new System.Drawing.Point(85, 73);
            this.cmboImportance.Name = "cmboImportance";
            this.cmboImportance.Size = new System.Drawing.Size(121, 21);
            this.cmboImportance.TabIndex = 11;
            this.cmboImportance.Text = "Normal";
            this.cmboImportance.SelectedIndexChanged += new System.EventHandler(this.cmboImportance_SelectedIndexChanged);
            // 
            // chkIsAllDayEvent
            // 
            this.chkIsAllDayEvent.AutoSize = true;
            this.chkIsAllDayEvent.Location = new System.Drawing.Point(716, 82);
            this.chkIsAllDayEvent.Name = "chkIsAllDayEvent";
            this.chkIsAllDayEvent.Size = new System.Drawing.Size(101, 17);
            this.chkIsAllDayEvent.TabIndex = 14;
            this.chkIsAllDayEvent.Text = "Is All Day Event";
            this.chkIsAllDayEvent.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(189, 12);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(66, 207);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(484, 20);
            this.txtLocation.TabIndex = 25;
            this.txtLocation.TextChanged += new System.EventHandler(this.txtLocation_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Location:";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(66, 181);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(484, 20);
            this.txtSubject.TabIndex = 23;
            this.txtSubject.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Subject:";
            // 
            // txtOptionalAttendees
            // 
            this.txtOptionalAttendees.Location = new System.Drawing.Point(121, 129);
            this.txtOptionalAttendees.Name = "txtOptionalAttendees";
            this.txtOptionalAttendees.Size = new System.Drawing.Size(535, 20);
            this.txtOptionalAttendees.TabIndex = 19;
            this.txtOptionalAttendees.TextChanged += new System.EventHandler(this.txtOptionalAttendees_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Optional Attendees:";
            // 
            // txtRequiredAttendees
            // 
            this.txtRequiredAttendees.Location = new System.Drawing.Point(121, 102);
            this.txtRequiredAttendees.Name = "txtRequiredAttendees";
            this.txtRequiredAttendees.Size = new System.Drawing.Size(535, 20);
            this.txtRequiredAttendees.TabIndex = 17;
            this.txtRequiredAttendees.TextChanged += new System.EventHandler(this.txtRequiredAttendees_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "RequiredAttendees:";
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(48, 233);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBody.Size = new System.Drawing.Size(757, 80);
            this.txtBody.TabIndex = 29;
            this.txtBody.TextChanged += new System.EventHandler(this.txtBody_TextChanged);
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Location = new System.Drawing.Point(8, 233);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(34, 13);
            this.lblBody.TabIndex = 28;
            this.lblBody.Text = "Body:";
            // 
            // txtOrganizer
            // 
            this.txtOrganizer.Enabled = false;
            this.txtOrganizer.Location = new System.Drawing.Point(124, 47);
            this.txtOrganizer.Name = "txtOrganizer";
            this.txtOrganizer.ReadOnly = true;
            this.txtOrganizer.Size = new System.Drawing.Size(214, 20);
            this.txtOrganizer.TabIndex = 7;
            // 
            // lblOrganizer
            // 
            this.lblOrganizer.AutoSize = true;
            this.lblOrganizer.Location = new System.Drawing.Point(17, 47);
            this.lblOrganizer.Name = "lblOrganizer";
            this.lblOrganizer.Size = new System.Drawing.Size(55, 13);
            this.lblOrganizer.TabIndex = 6;
            this.lblOrganizer.Text = "Organizer:";
            // 
            // txtAppointmentType
            // 
            this.txtAppointmentType.Enabled = false;
            this.txtAppointmentType.Location = new System.Drawing.Point(457, 47);
            this.txtAppointmentType.Name = "txtAppointmentType";
            this.txtAppointmentType.ReadOnly = true;
            this.txtAppointmentType.Size = new System.Drawing.Size(214, 20);
            this.txtAppointmentType.TabIndex = 9;
            // 
            // lblAppointmentType
            // 
            this.lblAppointmentType.AutoSize = true;
            this.lblAppointmentType.Location = new System.Drawing.Point(350, 47);
            this.lblAppointmentType.Name = "lblAppointmentType";
            this.lblAppointmentType.Size = new System.Drawing.Size(93, 13);
            this.lblAppointmentType.TabIndex = 8;
            this.lblAppointmentType.Text = "AppointmentType:";
            // 
            // grpSchedule
            // 
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
            this.grpSchedule.Location = new System.Drawing.Point(12, 319);
            this.grpSchedule.Name = "grpSchedule";
            this.grpSchedule.Size = new System.Drawing.Size(799, 74);
            this.grpSchedule.TabIndex = 30;
            this.grpSchedule.TabStop = false;
            this.grpSchedule.Text = "Scheduled:";
            this.grpSchedule.Enter += new System.EventHandler(this.grpSchedule_Enter);
            // 
            // cmboDurationEndTimezone
            // 
            this.cmboDurationEndTimezone.FormattingEnabled = true;
            this.cmboDurationEndTimezone.Items.AddRange(new object[] {
            "Free",
            "Tentative",
            "Busy",
            "Out Of Office"});
            this.cmboDurationEndTimezone.Location = new System.Drawing.Point(468, 40);
            this.cmboDurationEndTimezone.Name = "cmboDurationEndTimezone";
            this.cmboDurationEndTimezone.Size = new System.Drawing.Size(325, 21);
            this.cmboDurationEndTimezone.TabIndex = 9;
            this.cmboDurationEndTimezone.SelectedIndexChanged += new System.EventHandler(this.cmboDurationEndTimezone_SelectedIndexChanged);
            // 
            // lblDurationEndTimezone
            // 
            this.lblDurationEndTimezone.AutoSize = true;
            this.lblDurationEndTimezone.Location = new System.Drawing.Point(438, 43);
            this.lblDurationEndTimezone.Name = "lblDurationEndTimezone";
            this.lblDurationEndTimezone.Size = new System.Drawing.Size(24, 13);
            this.lblDurationEndTimezone.TabIndex = 8;
            this.lblDurationEndTimezone.Text = "TZ:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(438, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 13);
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
            this.cmboDurationStartTimezone.Location = new System.Drawing.Point(468, 17);
            this.cmboDurationStartTimezone.Name = "cmboDurationStartTimezone";
            this.cmboDurationStartTimezone.Size = new System.Drawing.Size(325, 21);
            this.cmboDurationStartTimezone.TabIndex = 4;
            this.cmboDurationStartTimezone.SelectedIndexChanged += new System.EventHandler(this.cmboDurationStartTimezone_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Duration End:";
            // 
            // dtDurationEndTime
            // 
            this.dtDurationEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtDurationEndTime.Location = new System.Drawing.Point(318, 43);
            this.dtDurationEndTime.Name = "dtDurationEndTime";
            this.dtDurationEndTime.ShowUpDown = true;
            this.dtDurationEndTime.Size = new System.Drawing.Size(113, 20);
            this.dtDurationEndTime.TabIndex = 7;
            this.dtDurationEndTime.ValueChanged += new System.EventHandler(this.dtDurationEndTime_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Duration Start:";
            // 
            // dtDurationEndDate
            // 
            this.dtDurationEndDate.Location = new System.Drawing.Point(95, 43);
            this.dtDurationEndDate.Name = "dtDurationEndDate";
            this.dtDurationEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtDurationEndDate.TabIndex = 6;
            this.dtDurationEndDate.ValueChanged += new System.EventHandler(this.dtDurationEndDate_ValueChanged);
            // 
            // dtDurationStartDate
            // 
            this.dtDurationStartDate.Location = new System.Drawing.Point(95, 17);
            this.dtDurationStartDate.Name = "dtDurationStartDate";
            this.dtDurationStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtDurationStartDate.TabIndex = 1;
            this.dtDurationStartDate.ValueChanged += new System.EventHandler(this.dtDurationStartDate_ValueChanged);
            // 
            // dtDurationStartTime
            // 
            this.dtDurationStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtDurationStartTime.Location = new System.Drawing.Point(318, 18);
            this.dtDurationStartTime.Name = "dtDurationStartTime";
            this.dtDurationStartTime.ShowUpDown = true;
            this.dtDurationStartTime.Size = new System.Drawing.Size(113, 20);
            this.dtDurationStartTime.TabIndex = 2;
            this.dtDurationStartTime.ValueChanged += new System.EventHandler(this.dtDurationStartTime_ValueChanged);
            // 
            // txtResourceAttendees
            // 
            this.txtResourceAttendees.Location = new System.Drawing.Point(123, 155);
            this.txtResourceAttendees.Name = "txtResourceAttendees";
            this.txtResourceAttendees.Size = new System.Drawing.Size(535, 20);
            this.txtResourceAttendees.TabIndex = 21;
            this.txtResourceAttendees.TextChanged += new System.EventHandler(this.txtResourceAttendees_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Resource Attendees:";
            // 
            // txtICalDateTimeStamp
            // 
            this.txtICalDateTimeStamp.Location = new System.Drawing.Point(119, 500);
            this.txtICalDateTimeStamp.Name = "txtICalDateTimeStamp";
            this.txtICalDateTimeStamp.ReadOnly = true;
            this.txtICalDateTimeStamp.Size = new System.Drawing.Size(244, 20);
            this.txtICalDateTimeStamp.TabIndex = 40;
            // 
            // lblICalDateTimeStamp
            // 
            this.lblICalDateTimeStamp.AutoSize = true;
            this.lblICalDateTimeStamp.Location = new System.Drawing.Point(9, 503);
            this.lblICalDateTimeStamp.Name = "lblICalDateTimeStamp";
            this.lblICalDateTimeStamp.Size = new System.Drawing.Size(104, 13);
            this.lblICalDateTimeStamp.TabIndex = 39;
            this.lblICalDateTimeStamp.Text = "ICalDateTimeStamp:";
            // 
            // txtICalRecurrenceId
            // 
            this.txtICalRecurrenceId.Location = new System.Drawing.Point(117, 474);
            this.txtICalRecurrenceId.Name = "txtICalRecurrenceId";
            this.txtICalRecurrenceId.ReadOnly = true;
            this.txtICalRecurrenceId.Size = new System.Drawing.Size(244, 20);
            this.txtICalRecurrenceId.TabIndex = 36;
            // 
            // lblICalRecurrenceId
            // 
            this.lblICalRecurrenceId.AutoSize = true;
            this.lblICalRecurrenceId.Location = new System.Drawing.Point(9, 477);
            this.lblICalRecurrenceId.Name = "lblICalRecurrenceId";
            this.lblICalRecurrenceId.Size = new System.Drawing.Size(93, 13);
            this.lblICalRecurrenceId.TabIndex = 35;
            this.lblICalRecurrenceId.Text = "ICalRecurrenceId:";
            // 
            // txtICalUid
            // 
            this.txtICalUid.Location = new System.Drawing.Point(117, 447);
            this.txtICalUid.Name = "txtICalUid";
            this.txtICalUid.ReadOnly = true;
            this.txtICalUid.Size = new System.Drawing.Size(244, 20);
            this.txtICalUid.TabIndex = 32;
            // 
            // lblICalUid
            // 
            this.lblICalUid.AutoSize = true;
            this.lblICalUid.Location = new System.Drawing.Point(10, 453);
            this.lblICalUid.Name = "lblICalUid";
            this.lblICalUid.Size = new System.Drawing.Size(44, 13);
            this.lblICalUid.TabIndex = 31;
            this.lblICalUid.Text = "ICalUid:";
            // 
            // txtConversationId
            // 
            this.txtConversationId.Location = new System.Drawing.Point(490, 503);
            this.txtConversationId.Name = "txtConversationId";
            this.txtConversationId.ReadOnly = true;
            this.txtConversationId.Size = new System.Drawing.Size(244, 20);
            this.txtConversationId.TabIndex = 42;
            this.txtConversationId.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(380, 506);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "ConversationId:";
            this.label9.Visible = false;
            // 
            // txtChangeKey
            // 
            this.txtChangeKey.Location = new System.Drawing.Point(488, 477);
            this.txtChangeKey.Name = "txtChangeKey";
            this.txtChangeKey.ReadOnly = true;
            this.txtChangeKey.Size = new System.Drawing.Size(244, 20);
            this.txtChangeKey.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(380, 480);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "ChangeKey:";
            // 
            // txtItemId
            // 
            this.txtItemId.Location = new System.Drawing.Point(488, 450);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.ReadOnly = true;
            this.txtItemId.Size = new System.Drawing.Size(244, 20);
            this.txtItemId.TabIndex = 34;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(381, 456);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "ItemId:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(223, 74);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(84, 13);
            this.label34.TabIndex = 12;
            this.label34.Text = "FreeBusyStatus:";
            // 
            // cmboLegacyFreeBusyStatus
            // 
            this.cmboLegacyFreeBusyStatus.FormattingEnabled = true;
            this.cmboLegacyFreeBusyStatus.Items.AddRange(new object[] {
            "Free",
            "Tentative",
            "Busy",
            "Out Of Office"});
            this.cmboLegacyFreeBusyStatus.Location = new System.Drawing.Point(313, 69);
            this.cmboLegacyFreeBusyStatus.Name = "cmboLegacyFreeBusyStatus";
            this.cmboLegacyFreeBusyStatus.Size = new System.Drawing.Size(98, 21);
            this.cmboLegacyFreeBusyStatus.TabIndex = 13;
            this.cmboLegacyFreeBusyStatus.Text = "OOF";
            // 
            // btnAttendeeStatus
            // 
            this.btnAttendeeStatus.Location = new System.Drawing.Point(717, 12);
            this.btnAttendeeStatus.Name = "btnAttendeeStatus";
            this.btnAttendeeStatus.Size = new System.Drawing.Size(94, 23);
            this.btnAttendeeStatus.TabIndex = 5;
            this.btnAttendeeStatus.Text = "Attendee Status";
            this.btnAttendeeStatus.UseVisualStyleBackColor = true;
            this.btnAttendeeStatus.Click += new System.EventHandler(this.btnAttendeeStatus_Click);
            // 
            // cmboCategories
            // 
            this.cmboCategories.FormattingEnabled = true;
            this.cmboCategories.Location = new System.Drawing.Point(676, 202);
            this.cmboCategories.Name = "cmboCategories";
            this.cmboCategories.Size = new System.Drawing.Size(121, 21);
            this.cmboCategories.TabIndex = 27;
            this.cmboCategories.Text = "Normal";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(610, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Categories:";
            // 
            // lblGlobalObjectId
            // 
            this.lblGlobalObjectId.AutoSize = true;
            this.lblGlobalObjectId.Location = new System.Drawing.Point(350, 17);
            this.lblGlobalObjectId.Name = "lblGlobalObjectId";
            this.lblGlobalObjectId.Size = new System.Drawing.Size(86, 13);
            this.lblGlobalObjectId.TabIndex = 3;
            this.lblGlobalObjectId.Text = "Global Object Id:";
            // 
            // txtGlobalObjectId
            // 
            this.txtGlobalObjectId.Enabled = false;
            this.txtGlobalObjectId.Location = new System.Drawing.Point(453, 14);
            this.txtGlobalObjectId.Name = "txtGlobalObjectId";
            this.txtGlobalObjectId.ReadOnly = true;
            this.txtGlobalObjectId.Size = new System.Drawing.Size(214, 20);
            this.txtGlobalObjectId.TabIndex = 4;
            // 
            // btnAttachments
            // 
            this.btnAttachments.Location = new System.Drawing.Point(719, 41);
            this.btnAttachments.Name = "btnAttachments";
            this.btnAttachments.Size = new System.Drawing.Size(94, 23);
            this.btnAttachments.TabIndex = 111;
            this.btnAttachments.Tag = "";
            this.btnAttachments.Text = "Attachments";
            this.btnAttachments.UseVisualStyleBackColor = true;
            this.btnAttachments.Visible = false;
            this.btnAttachments.Click += new System.EventHandler(this.btnAttachments_Click);
            // 
            // cmboTimezone
            // 
            this.cmboTimezone.FormattingEnabled = true;
            this.cmboTimezone.Items.AddRange(new object[] {
            "Free",
            "Tentative",
            "Busy",
            "Out Of Office"});
            this.cmboTimezone.Location = new System.Drawing.Point(91, 13);
            this.cmboTimezone.Name = "cmboTimezone";
            this.cmboTimezone.Size = new System.Drawing.Size(325, 21);
            this.cmboTimezone.TabIndex = 116;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(52, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 13);
            this.label13.TabIndex = 115;
            this.label13.Text = "TZ:";
            // 
            // grpTimeZone
            // 
            this.grpTimeZone.Controls.Add(this.cmboTimezone);
            this.grpTimeZone.Controls.Add(this.label13);
            this.grpTimeZone.Location = new System.Drawing.Point(11, 399);
            this.grpTimeZone.Name = "grpTimeZone";
            this.grpTimeZone.Size = new System.Drawing.Size(434, 42);
            this.grpTimeZone.TabIndex = 118;
            this.grpTimeZone.TabStop = false;
            this.grpTimeZone.Text = "TimeZone";
            // 
            // CalendarInstanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 535);
            this.Controls.Add(this.grpTimeZone);
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
            this.Name = "CalendarInstanceForm";
            this.Text = "CalendarInstanceForm";
            this.Load += new System.EventHandler(this.CalendarInstanceForm_Load);
            this.grpSchedule.ResumeLayout(false);
            this.grpSchedule.PerformLayout();
            this.grpTimeZone.ResumeLayout(false);
            this.grpTimeZone.PerformLayout();
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
        private System.Windows.Forms.ComboBox cmboTimezone;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox grpTimeZone;
    }
}