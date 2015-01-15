namespace EWSEditor.Forms
{
    partial class CalendarForm
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
            this.txtBody = new System.Windows.Forms.TextBox();
            this.lblBody = new System.Windows.Forms.Label();
            this.txtOrganizer = new System.Windows.Forms.TextBox();
            this.lblOrganizer = new System.Windows.Forms.Label();
            this.txtAppointmentType = new System.Windows.Forms.TextBox();
            this.lblAppointmentType = new System.Windows.Forms.Label();
            this.chkIsAllDayEvent = new System.Windows.Forms.CheckBox();
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
            this.txtRequiredAttendees = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOptionalAttendees = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmboImportance = new System.Windows.Forms.ComboBox();
            this.chkIsRecurring = new System.Windows.Forms.CheckBox();
            this.grpRecurring = new System.Windows.Forms.GroupBox();
            this.grpRange = new System.Windows.Forms.GroupBox();
            this.dtStartingDateRange = new System.Windows.Forms.DateTimePicker();
            this.label32 = new System.Windows.Forms.Label();
            this.rdoRangeNoEnd = new System.Windows.Forms.RadioButton();
            this.rdoRangeEndAfterNumberOccurrences = new System.Windows.Forms.RadioButton();
            this.dtRangeEndByDate = new System.Windows.Forms.DateTimePicker();
            this.txtRangeNumberOccurrences = new System.Windows.Forms.TextBox();
            this.rdoRangeEndByDate = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmboRecurrYearlyOnDayPatternDayOfWeek = new System.Windows.Forms.ComboBox();
            this.rdoRecurrYearlyOnSpecificDay = new System.Windows.Forms.RadioButton();
            this.rdoRelativeYearlyPattern = new System.Windows.Forms.RadioButton();
            this.cmboRecurrYearlyOnSpecificDayForMonthOf = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cmboRecurrYearlyOnSpecificDay = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmboRecurrYearlyOnDayPatternDayOfWeekIndex = new System.Windows.Forms.ComboBox();
            this.cmboRecurrYearlyOnDayPatternMonth = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.grpMonthly = new System.Windows.Forms.GroupBox();
            this.rdoRecurrRelativeMonthyPattern = new System.Windows.Forms.RadioButton();
            this.cmboRecurrInterval = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.cmboRecurrMonthlyPatternEveryMonths = new System.Windows.Forms.ComboBox();
            this.cmboRecurrDayOfWeek = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cmboRecurrMonthlyPatternDayOfMonth = new System.Windows.Forms.ComboBox();
            this.cmboRecurrDayOfTheWeekIndex = new System.Windows.Forms.ComboBox();
            this.lblMontlyDayOfMonth = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.rdoRecurrMonthlyPattern = new System.Windows.Forms.RadioButton();
            this.grpDaily = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmboRecurrDailyEveryDays = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cmboRecurrWeeklyEveryWeeks = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkRecurrWeeklySaturday = new System.Windows.Forms.CheckBox();
            this.chkRecurrWeeklyFriday = new System.Windows.Forms.CheckBox();
            this.chkRecurrWeeklyThursday = new System.Windows.Forms.CheckBox();
            this.chkRecurrWeeklyWednesday = new System.Windows.Forms.CheckBox();
            this.chkRecurrWeeklyTuesday = new System.Windows.Forms.CheckBox();
            this.chkRecurrWeeklyMonday = new System.Windows.Forms.CheckBox();
            this.chkRecurrWeeklySunday = new System.Windows.Forms.CheckBox();
            this.rdoYearly = new System.Windows.Forms.RadioButton();
            this.rdoMonthly = new System.Windows.Forms.RadioButton();
            this.rdoWeekly = new System.Windows.Forms.RadioButton();
            this.rdoDaily = new System.Windows.Forms.RadioButton();
            this.cmboRecurrEndTimezone = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmboRecurrStartTimezone = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtRecurrEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtRecurrStartTime = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtResourceAttendees = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtChangeKey = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtICalUid = new System.Windows.Forms.TextBox();
            this.lblICalUid = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.cmboLegacyFreeBusyStatus = new System.Windows.Forms.ComboBox();
            this.btnAttendeeStatus = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblMessageType = new System.Windows.Forms.Label();
            this.cmboBodyType = new System.Windows.Forms.ComboBox();
            this.btnAttachments = new System.Windows.Forms.Button();
            this.grpSchedule.SuspendLayout();
            this.grpRecurring.SuspendLayout();
            this.grpRange.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpMonthly.SuspendLayout();
            this.grpDaily.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(48, 253);
            this.txtBody.MaxLength = 0;
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBody.Size = new System.Drawing.Size(828, 53);
            this.txtBody.TabIndex = 43;
            this.txtBody.TextChanged += new System.EventHandler(this.txtBody_TextChanged);
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Location = new System.Drawing.Point(9, 253);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(34, 13);
            this.lblBody.TabIndex = 42;
            this.lblBody.Text = "Body:";
            // 
            // txtOrganizer
            // 
            this.txtOrganizer.Enabled = false;
            this.txtOrganizer.Location = new System.Drawing.Point(124, 47);
            this.txtOrganizer.Name = "txtOrganizer";
            this.txtOrganizer.Size = new System.Drawing.Size(214, 20);
            this.txtOrganizer.TabIndex = 33;
            // 
            // lblOrganizer
            // 
            this.lblOrganizer.AutoSize = true;
            this.lblOrganizer.Location = new System.Drawing.Point(17, 47);
            this.lblOrganizer.Name = "lblOrganizer";
            this.lblOrganizer.Size = new System.Drawing.Size(55, 13);
            this.lblOrganizer.TabIndex = 32;
            this.lblOrganizer.Text = "Organizer:";
            // 
            // txtAppointmentType
            // 
            this.txtAppointmentType.Enabled = false;
            this.txtAppointmentType.Location = new System.Drawing.Point(457, 47);
            this.txtAppointmentType.Name = "txtAppointmentType";
            this.txtAppointmentType.Size = new System.Drawing.Size(214, 20);
            this.txtAppointmentType.TabIndex = 31;
            this.txtAppointmentType.TextChanged += new System.EventHandler(this.txtAppointmentType_TextChanged);
            // 
            // lblAppointmentType
            // 
            this.lblAppointmentType.AutoSize = true;
            this.lblAppointmentType.Location = new System.Drawing.Point(350, 47);
            this.lblAppointmentType.Name = "lblAppointmentType";
            this.lblAppointmentType.Size = new System.Drawing.Size(93, 13);
            this.lblAppointmentType.TabIndex = 30;
            this.lblAppointmentType.Text = "AppointmentType:";
            // 
            // chkIsAllDayEvent
            // 
            this.chkIsAllDayEvent.AutoSize = true;
            this.chkIsAllDayEvent.Location = new System.Drawing.Point(11, 311);
            this.chkIsAllDayEvent.Name = "chkIsAllDayEvent";
            this.chkIsAllDayEvent.Size = new System.Drawing.Size(101, 17);
            this.chkIsAllDayEvent.TabIndex = 45;
            this.chkIsAllDayEvent.Text = "Is All Day Event";
            this.chkIsAllDayEvent.UseVisualStyleBackColor = true;
            this.chkIsAllDayEvent.CheckedChanged += new System.EventHandler(this.chkIsAllDayEvent_CheckedChanged);
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
            this.grpSchedule.Location = new System.Drawing.Point(20, 334);
            this.grpSchedule.Name = "grpSchedule";
            this.grpSchedule.Size = new System.Drawing.Size(862, 75);
            this.grpSchedule.TabIndex = 46;
            this.grpSchedule.TabStop = false;
            this.grpSchedule.Text = "Scheduled:";
            this.grpSchedule.Enter += new System.EventHandler(this.grpSchedule_Enter);
            // 
            // cmboDurationEndTimezone
            // 
            this.cmboDurationEndTimezone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboDurationEndTimezone.FormattingEnabled = true;
            this.cmboDurationEndTimezone.Items.AddRange(new object[] {
            "Free",
            "Tentative",
            "Busy",
            "Out Of Office"});
            this.cmboDurationEndTimezone.Location = new System.Drawing.Point(493, 40);
            this.cmboDurationEndTimezone.Name = "cmboDurationEndTimezone";
            this.cmboDurationEndTimezone.Size = new System.Drawing.Size(363, 21);
            this.cmboDurationEndTimezone.TabIndex = 65;
            this.cmboDurationEndTimezone.SelectedIndexChanged += new System.EventHandler(this.cmboDurationEndTimezone_SelectedIndexChanged);
            // 
            // lblDurationEndTimezone
            // 
            this.lblDurationEndTimezone.AutoSize = true;
            this.lblDurationEndTimezone.Location = new System.Drawing.Point(463, 43);
            this.lblDurationEndTimezone.Name = "lblDurationEndTimezone";
            this.lblDurationEndTimezone.Size = new System.Drawing.Size(24, 13);
            this.lblDurationEndTimezone.TabIndex = 64;
            this.lblDurationEndTimezone.Text = "TZ:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(463, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 13);
            this.label12.TabIndex = 63;
            this.label12.Text = "TZ:";
            // 
            // cmboDurationStartTimezone
            // 
            this.cmboDurationStartTimezone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboDurationStartTimezone.FormattingEnabled = true;
            this.cmboDurationStartTimezone.Items.AddRange(new object[] {
            "Free",
            "Tentative",
            "Busy",
            "Out Of Office"});
            this.cmboDurationStartTimezone.Location = new System.Drawing.Point(493, 17);
            this.cmboDurationStartTimezone.Name = "cmboDurationStartTimezone";
            this.cmboDurationStartTimezone.Size = new System.Drawing.Size(363, 21);
            this.cmboDurationStartTimezone.TabIndex = 61;
            this.cmboDurationStartTimezone.SelectedIndexChanged += new System.EventHandler(this.cmboDurationStartTimezone_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Duration End:";
            // 
            // dtDurationEndTime
            // 
            this.dtDurationEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtDurationEndTime.Location = new System.Drawing.Point(318, 43);
            this.dtDurationEndTime.Name = "dtDurationEndTime";
            this.dtDurationEndTime.ShowUpDown = true;
            this.dtDurationEndTime.Size = new System.Drawing.Size(135, 20);
            this.dtDurationEndTime.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Duration Start:";
            // 
            // dtDurationEndDate
            // 
            this.dtDurationEndDate.Location = new System.Drawing.Point(95, 43);
            this.dtDurationEndDate.Name = "dtDurationEndDate";
            this.dtDurationEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtDurationEndDate.TabIndex = 20;
            this.dtDurationEndDate.ValueChanged += new System.EventHandler(this.dtDurationEndDate_ValueChanged);
            // 
            // dtDurationStartDate
            // 
            this.dtDurationStartDate.Location = new System.Drawing.Point(95, 17);
            this.dtDurationStartDate.Name = "dtDurationStartDate";
            this.dtDurationStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtDurationStartDate.TabIndex = 16;
            this.dtDurationStartDate.ValueChanged += new System.EventHandler(this.dtDurationStartDate_ValueChanged);
            // 
            // dtDurationStartTime
            // 
            this.dtDurationStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtDurationStartTime.Location = new System.Drawing.Point(318, 18);
            this.dtDurationStartTime.Name = "dtDurationStartTime";
            this.dtDurationStartTime.ShowUpDown = true;
            this.dtDurationStartTime.Size = new System.Drawing.Size(135, 20);
            this.dtDurationStartTime.TabIndex = 17;
            this.dtDurationStartTime.ValueChanged += new System.EventHandler(this.dtDurationStartTime_ValueChanged);
            // 
            // txtRequiredAttendees
            // 
            this.txtRequiredAttendees.Location = new System.Drawing.Point(121, 96);
            this.txtRequiredAttendees.Name = "txtRequiredAttendees";
            this.txtRequiredAttendees.Size = new System.Drawing.Size(755, 20);
            this.txtRequiredAttendees.TabIndex = 48;
            this.txtRequiredAttendees.TextChanged += new System.EventHandler(this.txtRequiredAttendees_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "RequiredAttendees:";
            // 
            // txtOptionalAttendees
            // 
            this.txtOptionalAttendees.Location = new System.Drawing.Point(121, 123);
            this.txtOptionalAttendees.Name = "txtOptionalAttendees";
            this.txtOptionalAttendees.Size = new System.Drawing.Size(755, 20);
            this.txtOptionalAttendees.TabIndex = 51;
            this.txtOptionalAttendees.TextChanged += new System.EventHandler(this.txtOptionalAttendees_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Optional Attendees:";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(74, 173);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(803, 20);
            this.txtSubject.TabIndex = 54;
            this.txtSubject.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Subject:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(74, 199);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(802, 20);
            this.txtLocation.TabIndex = 56;
            this.txtLocation.TextChanged += new System.EventHandler(this.txtLocation_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Location:";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(87, 13);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 57;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Importance:";
            // 
            // cmboImportance
            // 
            this.cmboImportance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboImportance.FormattingEnabled = true;
            this.cmboImportance.Location = new System.Drawing.Point(86, 71);
            this.cmboImportance.Name = "cmboImportance";
            this.cmboImportance.Size = new System.Drawing.Size(98, 21);
            this.cmboImportance.TabIndex = 60;
            this.cmboImportance.SelectedIndexChanged += new System.EventHandler(this.cmboImportance_SelectedIndexChanged);
            // 
            // chkIsRecurring
            // 
            this.chkIsRecurring.AutoSize = true;
            this.chkIsRecurring.Location = new System.Drawing.Point(11, 415);
            this.chkIsRecurring.Name = "chkIsRecurring";
            this.chkIsRecurring.Size = new System.Drawing.Size(83, 17);
            this.chkIsRecurring.TabIndex = 46;
            this.chkIsRecurring.Text = "Is Recurring";
            this.chkIsRecurring.UseVisualStyleBackColor = true;
            this.chkIsRecurring.CheckedChanged += new System.EventHandler(this.chkIsRecurring_CheckedChanged);
            // 
            // grpRecurring
            // 
            this.grpRecurring.Controls.Add(this.grpRange);
            this.grpRecurring.Controls.Add(this.groupBox1);
            this.grpRecurring.Controls.Add(this.grpMonthly);
            this.grpRecurring.Controls.Add(this.grpDaily);
            this.grpRecurring.Controls.Add(this.label31);
            this.grpRecurring.Controls.Add(this.label19);
            this.grpRecurring.Controls.Add(this.cmboRecurrWeeklyEveryWeeks);
            this.grpRecurring.Controls.Add(this.label11);
            this.grpRecurring.Controls.Add(this.chkRecurrWeeklySaturday);
            this.grpRecurring.Controls.Add(this.chkRecurrWeeklyFriday);
            this.grpRecurring.Controls.Add(this.chkRecurrWeeklyThursday);
            this.grpRecurring.Controls.Add(this.chkRecurrWeeklyWednesday);
            this.grpRecurring.Controls.Add(this.chkRecurrWeeklyTuesday);
            this.grpRecurring.Controls.Add(this.chkRecurrWeeklyMonday);
            this.grpRecurring.Controls.Add(this.chkRecurrWeeklySunday);
            this.grpRecurring.Controls.Add(this.rdoYearly);
            this.grpRecurring.Controls.Add(this.rdoMonthly);
            this.grpRecurring.Controls.Add(this.rdoWeekly);
            this.grpRecurring.Controls.Add(this.rdoDaily);
            this.grpRecurring.Controls.Add(this.cmboRecurrEndTimezone);
            this.grpRecurring.Controls.Add(this.label14);
            this.grpRecurring.Controls.Add(this.label15);
            this.grpRecurring.Controls.Add(this.cmboRecurrStartTimezone);
            this.grpRecurring.Controls.Add(this.label9);
            this.grpRecurring.Controls.Add(this.label10);
            this.grpRecurring.Controls.Add(this.dtRecurrEndTime);
            this.grpRecurring.Controls.Add(this.dtRecurrStartTime);
            this.grpRecurring.Location = new System.Drawing.Point(30, 438);
            this.grpRecurring.Margin = new System.Windows.Forms.Padding(0);
            this.grpRecurring.Name = "grpRecurring";
            this.grpRecurring.Padding = new System.Windows.Forms.Padding(0);
            this.grpRecurring.Size = new System.Drawing.Size(847, 354);
            this.grpRecurring.TabIndex = 62;
            this.grpRecurring.TabStop = false;
            this.grpRecurring.Text = "Scheduled:";
            this.grpRecurring.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // grpRange
            // 
            this.grpRange.Controls.Add(this.dtStartingDateRange);
            this.grpRange.Controls.Add(this.label32);
            this.grpRange.Controls.Add(this.rdoRangeNoEnd);
            this.grpRange.Controls.Add(this.rdoRangeEndAfterNumberOccurrences);
            this.grpRange.Controls.Add(this.dtRangeEndByDate);
            this.grpRange.Controls.Add(this.txtRangeNumberOccurrences);
            this.grpRange.Controls.Add(this.rdoRangeEndByDate);
            this.grpRange.Location = new System.Drawing.Point(85, 277);
            this.grpRange.Name = "grpRange";
            this.grpRange.Size = new System.Drawing.Size(652, 74);
            this.grpRange.TabIndex = 102;
            this.grpRange.TabStop = false;
            // 
            // dtStartingDateRange
            // 
            this.dtStartingDateRange.Location = new System.Drawing.Point(60, 15);
            this.dtStartingDateRange.Name = "dtStartingDateRange";
            this.dtStartingDateRange.Size = new System.Drawing.Size(200, 20);
            this.dtStartingDateRange.TabIndex = 116;
            this.dtStartingDateRange.ValueChanged += new System.EventHandler(this.dtStartingDateRange_ValueChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(11, 18);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(43, 13);
            this.label32.TabIndex = 117;
            this.label32.Text = "Starting";
            // 
            // rdoRangeNoEnd
            // 
            this.rdoRangeNoEnd.AutoSize = true;
            this.rdoRangeNoEnd.Location = new System.Drawing.Point(290, 10);
            this.rdoRangeNoEnd.Name = "rdoRangeNoEnd";
            this.rdoRangeNoEnd.Size = new System.Drawing.Size(61, 17);
            this.rdoRangeNoEnd.TabIndex = 118;
            this.rdoRangeNoEnd.Text = "No End";
            this.rdoRangeNoEnd.UseVisualStyleBackColor = true;
            this.rdoRangeNoEnd.CheckedChanged += new System.EventHandler(this.rdoRangeNoEnd_CheckedChanged);
            // 
            // rdoRangeEndAfterNumberOccurrences
            // 
            this.rdoRangeEndAfterNumberOccurrences.AutoSize = true;
            this.rdoRangeEndAfterNumberOccurrences.Location = new System.Drawing.Point(290, 30);
            this.rdoRangeEndAfterNumberOccurrences.Name = "rdoRangeEndAfterNumberOccurrences";
            this.rdoRangeEndAfterNumberOccurrences.Size = new System.Drawing.Size(143, 17);
            this.rdoRangeEndAfterNumberOccurrences.TabIndex = 119;
            this.rdoRangeEndAfterNumberOccurrences.Text = "End after # occurrences:";
            this.rdoRangeEndAfterNumberOccurrences.UseVisualStyleBackColor = true;
            this.rdoRangeEndAfterNumberOccurrences.CheckedChanged += new System.EventHandler(this.rdoRangeEndAfterNumberOccurrences_CheckedChanged);
            // 
            // dtRangeEndByDate
            // 
            this.dtRangeEndByDate.Location = new System.Drawing.Point(398, 48);
            this.dtRangeEndByDate.Name = "dtRangeEndByDate";
            this.dtRangeEndByDate.Size = new System.Drawing.Size(200, 20);
            this.dtRangeEndByDate.TabIndex = 121;
            this.dtRangeEndByDate.ValueChanged += new System.EventHandler(this.dtRangeEndByDate_ValueChanged);
            // 
            // txtRangeNumberOccurrences
            // 
            this.txtRangeNumberOccurrences.Location = new System.Drawing.Point(447, 27);
            this.txtRangeNumberOccurrences.Name = "txtRangeNumberOccurrences";
            this.txtRangeNumberOccurrences.Size = new System.Drawing.Size(43, 20);
            this.txtRangeNumberOccurrences.TabIndex = 122;
            this.txtRangeNumberOccurrences.Text = "10";
            this.txtRangeNumberOccurrences.TextChanged += new System.EventHandler(this.txtRangeNumberOccurrences_TextChanged);
            // 
            // rdoRangeEndByDate
            // 
            this.rdoRangeEndByDate.AutoSize = true;
            this.rdoRangeEndByDate.Location = new System.Drawing.Point(291, 51);
            this.rdoRangeEndByDate.Name = "rdoRangeEndByDate";
            this.rdoRangeEndByDate.Size = new System.Drawing.Size(87, 17);
            this.rdoRangeEndByDate.TabIndex = 120;
            this.rdoRangeEndByDate.Text = "End by Date:";
            this.rdoRangeEndByDate.UseVisualStyleBackColor = true;
            this.rdoRangeEndByDate.CheckedChanged += new System.EventHandler(this.rdoRangeEndByDate_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmboRecurrYearlyOnDayPatternDayOfWeek);
            this.groupBox1.Controls.Add(this.rdoRecurrYearlyOnSpecificDay);
            this.groupBox1.Controls.Add(this.rdoRelativeYearlyPattern);
            this.groupBox1.Controls.Add(this.cmboRecurrYearlyOnSpecificDayForMonthOf);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.cmboRecurrYearlyOnSpecificDay);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.cmboRecurrYearlyOnDayPatternDayOfWeekIndex);
            this.groupBox1.Controls.Add(this.cmboRecurrYearlyOnDayPatternMonth);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Location = new System.Drawing.Point(85, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 68);
            this.groupBox1.TabIndex = 131;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // cmboRecurrYearlyOnDayPatternDayOfWeek
            // 
            this.cmboRecurrYearlyOnDayPatternDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRecurrYearlyOnDayPatternDayOfWeek.FormattingEnabled = true;
            this.cmboRecurrYearlyOnDayPatternDayOfWeek.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.cmboRecurrYearlyOnDayPatternDayOfWeek.Location = new System.Drawing.Point(465, 41);
            this.cmboRecurrYearlyOnDayPatternDayOfWeek.Name = "cmboRecurrYearlyOnDayPatternDayOfWeek";
            this.cmboRecurrYearlyOnDayPatternDayOfWeek.Size = new System.Drawing.Size(91, 21);
            this.cmboRecurrYearlyOnDayPatternDayOfWeek.TabIndex = 98;
            this.cmboRecurrYearlyOnDayPatternDayOfWeek.SelectedIndexChanged += new System.EventHandler(this.cmboRecurrYearlyOnDayPatternDayOfWeek_SelectedIndexChanged);
            // 
            // rdoRecurrYearlyOnSpecificDay
            // 
            this.rdoRecurrYearlyOnSpecificDay.AutoSize = true;
            this.rdoRecurrYearlyOnSpecificDay.Location = new System.Drawing.Point(13, 19);
            this.rdoRecurrYearlyOnSpecificDay.Name = "rdoRecurrYearlyOnSpecificDay";
            this.rdoRecurrYearlyOnSpecificDay.Size = new System.Drawing.Size(101, 17);
            this.rdoRecurrYearlyOnSpecificDay.TabIndex = 90;
            this.rdoRecurrYearlyOnSpecificDay.Text = "On specific day ";
            this.rdoRecurrYearlyOnSpecificDay.UseVisualStyleBackColor = true;
            this.rdoRecurrYearlyOnSpecificDay.CheckedChanged += new System.EventHandler(this.rdoRecurrYearlyOnSpecificDay_CheckedChanged);
            // 
            // rdoRelativeYearlyPattern
            // 
            this.rdoRelativeYearlyPattern.AutoSize = true;
            this.rdoRelativeYearlyPattern.Location = new System.Drawing.Point(13, 45);
            this.rdoRelativeYearlyPattern.Name = "rdoRelativeYearlyPattern";
            this.rdoRelativeYearlyPattern.Size = new System.Drawing.Size(133, 17);
            this.rdoRelativeYearlyPattern.TabIndex = 91;
            this.rdoRelativeYearlyPattern.Text = "Relative Yearly Pattern";
            this.rdoRelativeYearlyPattern.UseVisualStyleBackColor = true;
            this.rdoRelativeYearlyPattern.CheckedChanged += new System.EventHandler(this.rdoRecurrYearlyOnDayPattern_CheckedChanged);
            // 
            // cmboRecurrYearlyOnSpecificDayForMonthOf
            // 
            this.cmboRecurrYearlyOnSpecificDayForMonthOf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRecurrYearlyOnSpecificDayForMonthOf.FormattingEnabled = true;
            this.cmboRecurrYearlyOnSpecificDayForMonthOf.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmboRecurrYearlyOnSpecificDayForMonthOf.Location = new System.Drawing.Point(171, 16);
            this.cmboRecurrYearlyOnSpecificDayForMonthOf.Name = "cmboRecurrYearlyOnSpecificDayForMonthOf";
            this.cmboRecurrYearlyOnSpecificDayForMonthOf.Size = new System.Drawing.Size(83, 21);
            this.cmboRecurrYearlyOnSpecificDayForMonthOf.TabIndex = 92;
            this.cmboRecurrYearlyOnSpecificDayForMonthOf.SelectedIndexChanged += new System.EventHandler(this.cmboRecurrYearlyOnSpecificDayMonth_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(125, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 13);
            this.label20.TabIndex = 93;
            this.label20.Text = "Month:";
            // 
            // cmboRecurrYearlyOnSpecificDay
            // 
            this.cmboRecurrYearlyOnSpecificDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRecurrYearlyOnSpecificDay.FormattingEnabled = true;
            this.cmboRecurrYearlyOnSpecificDay.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmboRecurrYearlyOnSpecificDay.Location = new System.Drawing.Point(307, 13);
            this.cmboRecurrYearlyOnSpecificDay.Name = "cmboRecurrYearlyOnSpecificDay";
            this.cmboRecurrYearlyOnSpecificDay.Size = new System.Drawing.Size(55, 21);
            this.cmboRecurrYearlyOnSpecificDay.TabIndex = 94;
            this.cmboRecurrYearlyOnSpecificDay.SelectedIndexChanged += new System.EventHandler(this.cmboRecurrYearlyOnSpecificDay_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(270, 21);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 13);
            this.label21.TabIndex = 95;
            this.label21.Text = "Day:";
            // 
            // cmboRecurrYearlyOnDayPatternDayOfWeekIndex
            // 
            this.cmboRecurrYearlyOnDayPatternDayOfWeekIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRecurrYearlyOnDayPatternDayOfWeekIndex.FormattingEnabled = true;
            this.cmboRecurrYearlyOnDayPatternDayOfWeekIndex.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmboRecurrYearlyOnDayPatternDayOfWeekIndex.Location = new System.Drawing.Point(310, 39);
            this.cmboRecurrYearlyOnDayPatternDayOfWeekIndex.Name = "cmboRecurrYearlyOnDayPatternDayOfWeekIndex";
            this.cmboRecurrYearlyOnDayPatternDayOfWeekIndex.Size = new System.Drawing.Size(68, 21);
            this.cmboRecurrYearlyOnDayPatternDayOfWeekIndex.TabIndex = 96;
            this.cmboRecurrYearlyOnDayPatternDayOfWeekIndex.SelectedIndexChanged += new System.EventHandler(this.cmboRecurrYearlyOnDayPatternWeekNumber_SelectedIndexChanged);
            // 
            // cmboRecurrYearlyOnDayPatternMonth
            // 
            this.cmboRecurrYearlyOnDayPatternMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRecurrYearlyOnDayPatternMonth.FormattingEnabled = true;
            this.cmboRecurrYearlyOnDayPatternMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmboRecurrYearlyOnDayPatternMonth.Location = new System.Drawing.Point(624, 41);
            this.cmboRecurrYearlyOnDayPatternMonth.Name = "cmboRecurrYearlyOnDayPatternMonth";
            this.cmboRecurrYearlyOnDayPatternMonth.Size = new System.Drawing.Size(107, 21);
            this.cmboRecurrYearlyOnDayPatternMonth.TabIndex = 101;
            this.cmboRecurrYearlyOnDayPatternMonth.SelectedIndexChanged += new System.EventHandler(this.cmboRecurrYearlyOnDayPatternMonth_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(195, 44);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(104, 13);
            this.label23.TabIndex = 97;
            this.label23.Text = "Day Of Week Index:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(578, 47);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 13);
            this.label24.TabIndex = 100;
            this.label24.Text = "Month:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(384, 44);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 13);
            this.label22.TabIndex = 99;
            this.label22.Text = "Day Of Week:";
            // 
            // grpMonthly
            // 
            this.grpMonthly.Controls.Add(this.rdoRecurrRelativeMonthyPattern);
            this.grpMonthly.Controls.Add(this.cmboRecurrInterval);
            this.grpMonthly.Controls.Add(this.label27);
            this.grpMonthly.Controls.Add(this.label25);
            this.grpMonthly.Controls.Add(this.cmboRecurrMonthlyPatternEveryMonths);
            this.grpMonthly.Controls.Add(this.cmboRecurrDayOfWeek);
            this.grpMonthly.Controls.Add(this.label26);
            this.grpMonthly.Controls.Add(this.label28);
            this.grpMonthly.Controls.Add(this.cmboRecurrMonthlyPatternDayOfMonth);
            this.grpMonthly.Controls.Add(this.cmboRecurrDayOfTheWeekIndex);
            this.grpMonthly.Controls.Add(this.lblMontlyDayOfMonth);
            this.grpMonthly.Controls.Add(this.label29);
            this.grpMonthly.Controls.Add(this.rdoRecurrMonthlyPattern);
            this.grpMonthly.Location = new System.Drawing.Point(86, 139);
            this.grpMonthly.Name = "grpMonthly";
            this.grpMonthly.Size = new System.Drawing.Size(748, 67);
            this.grpMonthly.TabIndex = 105;
            this.grpMonthly.TabStop = false;
            this.grpMonthly.Enter += new System.EventHandler(this.grpMonthly_Enter);
            // 
            // rdoRecurrRelativeMonthyPattern
            // 
            this.rdoRecurrRelativeMonthyPattern.AutoSize = true;
            this.rdoRecurrRelativeMonthyPattern.Location = new System.Drawing.Point(14, 42);
            this.rdoRecurrRelativeMonthyPattern.Name = "rdoRecurrRelativeMonthyPattern";
            this.rdoRecurrRelativeMonthyPattern.Size = new System.Drawing.Size(141, 17);
            this.rdoRecurrRelativeMonthyPattern.TabIndex = 124;
            this.rdoRecurrRelativeMonthyPattern.Text = "Relative Monthly Pattern";
            this.rdoRecurrRelativeMonthyPattern.UseVisualStyleBackColor = true;
            this.rdoRecurrRelativeMonthyPattern.CheckedChanged += new System.EventHandler(this.rdoRecurrRelativeMonthyPattern_CheckedChanged);
            // 
            // cmboRecurrInterval
            // 
            this.cmboRecurrInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRecurrInterval.FormattingEnabled = true;
            this.cmboRecurrInterval.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmboRecurrInterval.Location = new System.Drawing.Point(223, 43);
            this.cmboRecurrInterval.Name = "cmboRecurrInterval";
            this.cmboRecurrInterval.Size = new System.Drawing.Size(55, 21);
            this.cmboRecurrInterval.TabIndex = 102;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(412, 15);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(47, 13);
            this.label27.TabIndex = 129;
            this.label27.Text = "month(s)";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(172, 47);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(45, 13);
            this.label25.TabIndex = 103;
            this.label25.Text = "Interval:";
            // 
            // cmboRecurrMonthlyPatternEveryMonths
            // 
            this.cmboRecurrMonthlyPatternEveryMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRecurrMonthlyPatternEveryMonths.FormattingEnabled = true;
            this.cmboRecurrMonthlyPatternEveryMonths.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmboRecurrMonthlyPatternEveryMonths.Location = new System.Drawing.Point(366, 15);
            this.cmboRecurrMonthlyPatternEveryMonths.Name = "cmboRecurrMonthlyPatternEveryMonths";
            this.cmboRecurrMonthlyPatternEveryMonths.Size = new System.Drawing.Size(43, 21);
            this.cmboRecurrMonthlyPatternEveryMonths.TabIndex = 128;
            this.cmboRecurrMonthlyPatternEveryMonths.SelectedIndexChanged += new System.EventHandler(this.cmboRecurrMonthlyPatternEveryMonths_SelectedIndexChanged);
            // 
            // cmboRecurrDayOfWeek
            // 
            this.cmboRecurrDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRecurrDayOfWeek.FormattingEnabled = true;
            this.cmboRecurrDayOfWeek.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Day",
            "Weekday",
            "WeekendDay"});
            this.cmboRecurrDayOfWeek.Location = new System.Drawing.Point(387, 44);
            this.cmboRecurrDayOfWeek.Name = "cmboRecurrDayOfWeek";
            this.cmboRecurrDayOfWeek.Size = new System.Drawing.Size(82, 21);
            this.cmboRecurrDayOfWeek.TabIndex = 109;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(329, 14);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(37, 13);
            this.label26.TabIndex = 127;
            this.label26.Text = "Every ";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(477, 46);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(104, 13);
            this.label28.TabIndex = 111;
            this.label28.Text = "Day Of Week Index:";
            // 
            // cmboRecurrMonthlyPatternDayOfMonth
            // 
            this.cmboRecurrMonthlyPatternDayOfMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRecurrMonthlyPatternDayOfMonth.FormattingEnabled = true;
            this.cmboRecurrMonthlyPatternDayOfMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmboRecurrMonthlyPatternDayOfMonth.Location = new System.Drawing.Point(265, 14);
            this.cmboRecurrMonthlyPatternDayOfMonth.Name = "cmboRecurrMonthlyPatternDayOfMonth";
            this.cmboRecurrMonthlyPatternDayOfMonth.Size = new System.Drawing.Size(55, 21);
            this.cmboRecurrMonthlyPatternDayOfMonth.TabIndex = 126;
            // 
            // cmboRecurrDayOfTheWeekIndex
            // 
            this.cmboRecurrDayOfTheWeekIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRecurrDayOfTheWeekIndex.FormattingEnabled = true;
            this.cmboRecurrDayOfTheWeekIndex.Items.AddRange(new object[] {
            "First",
            "Second",
            "Third",
            "Fourth",
            "Last"});
            this.cmboRecurrDayOfTheWeekIndex.Location = new System.Drawing.Point(586, 40);
            this.cmboRecurrDayOfTheWeekIndex.Name = "cmboRecurrDayOfTheWeekIndex";
            this.cmboRecurrDayOfTheWeekIndex.Size = new System.Drawing.Size(84, 21);
            this.cmboRecurrDayOfTheWeekIndex.TabIndex = 112;
            // 
            // lblMontlyDayOfMonth
            // 
            this.lblMontlyDayOfMonth.AutoSize = true;
            this.lblMontlyDayOfMonth.Location = new System.Drawing.Point(165, 16);
            this.lblMontlyDayOfMonth.Name = "lblMontlyDayOfMonth";
            this.lblMontlyDayOfMonth.Size = new System.Drawing.Size(91, 13);
            this.lblMontlyDayOfMonth.TabIndex = 125;
            this.lblMontlyDayOfMonth.Text = "Day of the month:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(284, 47);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(97, 13);
            this.label29.TabIndex = 113;
            this.label29.Text = "Day Of The Week:";
            // 
            // rdoRecurrMonthlyPattern
            // 
            this.rdoRecurrMonthlyPattern.AutoSize = true;
            this.rdoRecurrMonthlyPattern.Location = new System.Drawing.Point(14, 12);
            this.rdoRecurrMonthlyPattern.Name = "rdoRecurrMonthlyPattern";
            this.rdoRecurrMonthlyPattern.Size = new System.Drawing.Size(99, 17);
            this.rdoRecurrMonthlyPattern.TabIndex = 123;
            this.rdoRecurrMonthlyPattern.Text = "Monthly Pattern";
            this.rdoRecurrMonthlyPattern.UseVisualStyleBackColor = true;
            this.rdoRecurrMonthlyPattern.CheckedChanged += new System.EventHandler(this.rdoRecurrMonthlyPattern_CheckedChanged);
            // 
            // grpDaily
            // 
            this.grpDaily.Controls.Add(this.label13);
            this.grpDaily.Controls.Add(this.cmboRecurrDailyEveryDays);
            this.grpDaily.Controls.Add(this.label16);
            this.grpDaily.Location = new System.Drawing.Point(85, 73);
            this.grpDaily.Margin = new System.Windows.Forms.Padding(0);
            this.grpDaily.Name = "grpDaily";
            this.grpDaily.Padding = new System.Windows.Forms.Padding(0);
            this.grpDaily.Size = new System.Drawing.Size(156, 37);
            this.grpDaily.TabIndex = 130;
            this.grpDaily.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 85;
            this.label13.Text = "Every";
            // 
            // cmboRecurrDailyEveryDays
            // 
            this.cmboRecurrDailyEveryDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRecurrDailyEveryDays.FormattingEnabled = true;
            this.cmboRecurrDailyEveryDays.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmboRecurrDailyEveryDays.Location = new System.Drawing.Point(57, 9);
            this.cmboRecurrDailyEveryDays.Name = "cmboRecurrDailyEveryDays";
            this.cmboRecurrDailyEveryDays.Size = new System.Drawing.Size(40, 21);
            this.cmboRecurrDailyEveryDays.TabIndex = 83;
            this.cmboRecurrDailyEveryDays.SelectedIndexChanged += new System.EventHandler(this.cmboRecurrDailyEveryDays_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(106, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 13);
            this.label16.TabIndex = 84;
            this.label16.Text = "days";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(12, 288);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(42, 13);
            this.label31.TabIndex = 115;
            this.label31.Text = "Range:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(174, 118);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 89;
            this.label19.Text = "weeks.";
            // 
            // cmboRecurrWeeklyEveryWeeks
            // 
            this.cmboRecurrWeeklyEveryWeeks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRecurrWeeklyEveryWeeks.FormattingEnabled = true;
            this.cmboRecurrWeeklyEveryWeeks.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmboRecurrWeeklyEveryWeeks.Location = new System.Drawing.Point(129, 112);
            this.cmboRecurrWeeklyEveryWeeks.Name = "cmboRecurrWeeklyEveryWeeks";
            this.cmboRecurrWeeklyEveryWeeks.Size = new System.Drawing.Size(40, 21);
            this.cmboRecurrWeeklyEveryWeeks.TabIndex = 66;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(89, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 81;
            this.label11.Text = "Every";
            // 
            // chkRecurrWeeklySaturday
            // 
            this.chkRecurrWeeklySaturday.AutoSize = true;
            this.chkRecurrWeeklySaturday.Location = new System.Drawing.Point(656, 113);
            this.chkRecurrWeeklySaturday.Name = "chkRecurrWeeklySaturday";
            this.chkRecurrWeeklySaturday.Size = new System.Drawing.Size(68, 17);
            this.chkRecurrWeeklySaturday.TabIndex = 80;
            this.chkRecurrWeeklySaturday.Text = "Saturday";
            this.chkRecurrWeeklySaturday.UseVisualStyleBackColor = true;
            // 
            // chkRecurrWeeklyFriday
            // 
            this.chkRecurrWeeklyFriday.AutoSize = true;
            this.chkRecurrWeeklyFriday.Location = new System.Drawing.Point(596, 113);
            this.chkRecurrWeeklyFriday.Name = "chkRecurrWeeklyFriday";
            this.chkRecurrWeeklyFriday.Size = new System.Drawing.Size(54, 17);
            this.chkRecurrWeeklyFriday.TabIndex = 79;
            this.chkRecurrWeeklyFriday.Text = "Friday";
            this.chkRecurrWeeklyFriday.UseVisualStyleBackColor = true;
            // 
            // chkRecurrWeeklyThursday
            // 
            this.chkRecurrWeeklyThursday.AutoSize = true;
            this.chkRecurrWeeklyThursday.Location = new System.Drawing.Point(520, 113);
            this.chkRecurrWeeklyThursday.Name = "chkRecurrWeeklyThursday";
            this.chkRecurrWeeklyThursday.Size = new System.Drawing.Size(70, 17);
            this.chkRecurrWeeklyThursday.TabIndex = 78;
            this.chkRecurrWeeklyThursday.Text = "Thursday";
            this.chkRecurrWeeklyThursday.UseVisualStyleBackColor = true;
            // 
            // chkRecurrWeeklyWednesday
            // 
            this.chkRecurrWeeklyWednesday.AutoSize = true;
            this.chkRecurrWeeklyWednesday.Location = new System.Drawing.Point(432, 113);
            this.chkRecurrWeeklyWednesday.Name = "chkRecurrWeeklyWednesday";
            this.chkRecurrWeeklyWednesday.Size = new System.Drawing.Size(83, 17);
            this.chkRecurrWeeklyWednesday.TabIndex = 77;
            this.chkRecurrWeeklyWednesday.Text = "Wednesday";
            this.chkRecurrWeeklyWednesday.UseVisualStyleBackColor = true;
            // 
            // chkRecurrWeeklyTuesday
            // 
            this.chkRecurrWeeklyTuesday.AutoSize = true;
            this.chkRecurrWeeklyTuesday.Location = new System.Drawing.Point(359, 113);
            this.chkRecurrWeeklyTuesday.Name = "chkRecurrWeeklyTuesday";
            this.chkRecurrWeeklyTuesday.Size = new System.Drawing.Size(67, 17);
            this.chkRecurrWeeklyTuesday.TabIndex = 76;
            this.chkRecurrWeeklyTuesday.Text = "Tuesday";
            this.chkRecurrWeeklyTuesday.UseVisualStyleBackColor = true;
            // 
            // chkRecurrWeeklyMonday
            // 
            this.chkRecurrWeeklyMonday.AutoSize = true;
            this.chkRecurrWeeklyMonday.Location = new System.Drawing.Point(289, 115);
            this.chkRecurrWeeklyMonday.Name = "chkRecurrWeeklyMonday";
            this.chkRecurrWeeklyMonday.Size = new System.Drawing.Size(64, 17);
            this.chkRecurrWeeklyMonday.TabIndex = 75;
            this.chkRecurrWeeklyMonday.Text = "Monday";
            this.chkRecurrWeeklyMonday.UseVisualStyleBackColor = true;
            // 
            // chkRecurrWeeklySunday
            // 
            this.chkRecurrWeeklySunday.AutoSize = true;
            this.chkRecurrWeeklySunday.Location = new System.Drawing.Point(221, 115);
            this.chkRecurrWeeklySunday.Name = "chkRecurrWeeklySunday";
            this.chkRecurrWeeklySunday.Size = new System.Drawing.Size(62, 17);
            this.chkRecurrWeeklySunday.TabIndex = 74;
            this.chkRecurrWeeklySunday.Text = "Sunday";
            this.chkRecurrWeeklySunday.UseVisualStyleBackColor = true;
            // 
            // rdoYearly
            // 
            this.rdoYearly.AutoSize = true;
            this.rdoYearly.Location = new System.Drawing.Point(17, 214);
            this.rdoYearly.Name = "rdoYearly";
            this.rdoYearly.Size = new System.Drawing.Size(54, 17);
            this.rdoYearly.TabIndex = 73;
            this.rdoYearly.Text = "Yearly";
            this.rdoYearly.UseVisualStyleBackColor = true;
            this.rdoYearly.CheckedChanged += new System.EventHandler(this.rdoYearly_CheckedChanged);
            // 
            // rdoMonthly
            // 
            this.rdoMonthly.AutoSize = true;
            this.rdoMonthly.Location = new System.Drawing.Point(16, 149);
            this.rdoMonthly.Name = "rdoMonthly";
            this.rdoMonthly.Size = new System.Drawing.Size(62, 17);
            this.rdoMonthly.TabIndex = 72;
            this.rdoMonthly.Text = "Monthly";
            this.rdoMonthly.UseVisualStyleBackColor = true;
            this.rdoMonthly.CheckedChanged += new System.EventHandler(this.rdoMonthly_CheckedChanged);
            // 
            // rdoWeekly
            // 
            this.rdoWeekly.AutoSize = true;
            this.rdoWeekly.Location = new System.Drawing.Point(15, 113);
            this.rdoWeekly.Name = "rdoWeekly";
            this.rdoWeekly.Size = new System.Drawing.Size(61, 17);
            this.rdoWeekly.TabIndex = 71;
            this.rdoWeekly.Text = "Weekly";
            this.rdoWeekly.UseVisualStyleBackColor = true;
            this.rdoWeekly.CheckedChanged += new System.EventHandler(this.rdoWeekly_CheckedChanged);
            // 
            // rdoDaily
            // 
            this.rdoDaily.AutoSize = true;
            this.rdoDaily.Location = new System.Drawing.Point(17, 86);
            this.rdoDaily.Name = "rdoDaily";
            this.rdoDaily.Size = new System.Drawing.Size(48, 17);
            this.rdoDaily.TabIndex = 70;
            this.rdoDaily.Text = "Daily";
            this.rdoDaily.UseVisualStyleBackColor = true;
            this.rdoDaily.CheckedChanged += new System.EventHandler(this.rdoDaily_CheckedChanged);
            this.rdoDaily.EnabledChanged += new System.EventHandler(this.rdoDaily_EnabledChanged);
            // 
            // cmboRecurrEndTimezone
            // 
            this.cmboRecurrEndTimezone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRecurrEndTimezone.FormattingEnabled = true;
            this.cmboRecurrEndTimezone.Location = new System.Drawing.Point(271, 49);
            this.cmboRecurrEndTimezone.Name = "cmboRecurrEndTimezone";
            this.cmboRecurrEndTimezone.Size = new System.Drawing.Size(482, 21);
            this.cmboRecurrEndTimezone.TabIndex = 69;
            this.cmboRecurrEndTimezone.SelectedIndexChanged += new System.EventHandler(this.cmboRecurrEndTimezon_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(238, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 13);
            this.label14.TabIndex = 68;
            this.label14.Text = "TZ:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(238, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 13);
            this.label15.TabIndex = 67;
            this.label15.Text = "TZ:";
            // 
            // cmboRecurrStartTimezone
            // 
            this.cmboRecurrStartTimezone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRecurrStartTimezone.FormattingEnabled = true;
            this.cmboRecurrStartTimezone.Location = new System.Drawing.Point(271, 26);
            this.cmboRecurrStartTimezone.Name = "cmboRecurrStartTimezone";
            this.cmboRecurrStartTimezone.Size = new System.Drawing.Size(482, 21);
            this.cmboRecurrStartTimezone.TabIndex = 66;
            this.cmboRecurrStartTimezone.SelectedIndexChanged += new System.EventHandler(this.cmboRecurrStartTimezon_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Duration End:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Duration Start:";
            // 
            // dtRecurrEndTime
            // 
            this.dtRecurrEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtRecurrEndTime.Location = new System.Drawing.Point(97, 51);
            this.dtRecurrEndTime.Name = "dtRecurrEndTime";
            this.dtRecurrEndTime.ShowUpDown = true;
            this.dtRecurrEndTime.Size = new System.Drawing.Size(135, 20);
            this.dtRecurrEndTime.TabIndex = 21;
            // 
            // dtRecurrStartTime
            // 
            this.dtRecurrStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtRecurrStartTime.Location = new System.Drawing.Point(97, 26);
            this.dtRecurrStartTime.Name = "dtRecurrStartTime";
            this.dtRecurrStartTime.ShowUpDown = true;
            this.dtRecurrStartTime.Size = new System.Drawing.Size(135, 20);
            this.dtRecurrStartTime.TabIndex = 17;
            this.dtRecurrStartTime.ValueChanged += new System.EventHandler(this.dtRecurrStartTime_ValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 63;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtResourceAttendees
            // 
            this.txtResourceAttendees.Location = new System.Drawing.Point(124, 146);
            this.txtResourceAttendees.Name = "txtResourceAttendees";
            this.txtResourceAttendees.Size = new System.Drawing.Size(752, 20);
            this.txtResourceAttendees.TabIndex = 90;
            this.txtResourceAttendees.TextChanged += new System.EventHandler(this.txtResourceAttendees_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 89;
            this.label7.Text = "Resource Attendees:";
            // 
            // txtChangeKey
            // 
            this.txtChangeKey.Location = new System.Drawing.Point(630, 795);
            this.txtChangeKey.Name = "txtChangeKey";
            this.txtChangeKey.ReadOnly = true;
            this.txtChangeKey.Size = new System.Drawing.Size(244, 20);
            this.txtChangeKey.TabIndex = 102;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(559, 798);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(65, 13);
            this.label30.TabIndex = 101;
            this.label30.Text = "ChangeKey:";
            // 
            // txtItemId
            // 
            this.txtItemId.Location = new System.Drawing.Point(290, 795);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.ReadOnly = true;
            this.txtItemId.Size = new System.Drawing.Size(244, 20);
            this.txtItemId.TabIndex = 100;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(245, 802);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(39, 13);
            this.label33.TabIndex = 99;
            this.label33.Text = "ItemId:";
            // 
            // txtICalUid
            // 
            this.txtICalUid.Location = new System.Drawing.Point(58, 795);
            this.txtICalUid.Name = "txtICalUid";
            this.txtICalUid.ReadOnly = true;
            this.txtICalUid.Size = new System.Drawing.Size(181, 20);
            this.txtICalUid.TabIndex = 104;
            // 
            // lblICalUid
            // 
            this.lblICalUid.AutoSize = true;
            this.lblICalUid.Location = new System.Drawing.Point(8, 801);
            this.lblICalUid.Name = "lblICalUid";
            this.lblICalUid.Size = new System.Drawing.Size(44, 13);
            this.lblICalUid.TabIndex = 103;
            this.lblICalUid.Text = "ICalUid:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(208, 74);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(84, 13);
            this.label34.TabIndex = 106;
            this.label34.Text = "FreeBusyStatus:";
            // 
            // cmboLegacyFreeBusyStatus
            // 
            this.cmboLegacyFreeBusyStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboLegacyFreeBusyStatus.FormattingEnabled = true;
            this.cmboLegacyFreeBusyStatus.Location = new System.Drawing.Point(298, 69);
            this.cmboLegacyFreeBusyStatus.Name = "cmboLegacyFreeBusyStatus";
            this.cmboLegacyFreeBusyStatus.Size = new System.Drawing.Size(98, 21);
            this.cmboLegacyFreeBusyStatus.TabIndex = 105;
            // 
            // btnAttendeeStatus
            // 
            this.btnAttendeeStatus.Location = new System.Drawing.Point(788, 12);
            this.btnAttendeeStatus.Name = "btnAttendeeStatus";
            this.btnAttendeeStatus.Size = new System.Drawing.Size(94, 23);
            this.btnAttendeeStatus.TabIndex = 107;
            this.btnAttendeeStatus.Text = "Attendee Status";
            this.btnAttendeeStatus.UseVisualStyleBackColor = true;
            this.btnAttendeeStatus.Click += new System.EventHandler(this.btnAttendeeStatus_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnSend);
            this.groupBox3.Location = new System.Drawing.Point(12, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 39);
            this.groupBox3.TabIndex = 108;
            this.groupBox3.TabStop = false;
            // 
            // lblMessageType
            // 
            this.lblMessageType.AutoSize = true;
            this.lblMessageType.Location = new System.Drawing.Point(9, 229);
            this.lblMessageType.Name = "lblMessageType";
            this.lblMessageType.Size = new System.Drawing.Size(61, 13);
            this.lblMessageType.TabIndex = 109;
            this.lblMessageType.Text = "Body Type:";
            // 
            // cmboBodyType
            // 
            this.cmboBodyType.FormattingEnabled = true;
            this.cmboBodyType.Items.AddRange(new object[] {
            "Text",
            "HTML"});
            this.cmboBodyType.Location = new System.Drawing.Point(74, 227);
            this.cmboBodyType.Name = "cmboBodyType";
            this.cmboBodyType.Size = new System.Drawing.Size(110, 21);
            this.cmboBodyType.TabIndex = 57;
            this.cmboBodyType.Text = "HTML";
            // 
            // btnAttachments
            // 
            this.btnAttachments.Location = new System.Drawing.Point(788, 38);
            this.btnAttachments.Name = "btnAttachments";
            this.btnAttachments.Size = new System.Drawing.Size(94, 23);
            this.btnAttachments.TabIndex = 110;
            this.btnAttachments.Tag = "";
            this.btnAttachments.Text = "Attachments";
            this.btnAttachments.UseVisualStyleBackColor = true;
            this.btnAttachments.Click += new System.EventHandler(this.btnAttachments_Click);
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 825);
            this.Controls.Add(this.btnAttachments);
            this.Controls.Add(this.lblMessageType);
            this.Controls.Add(this.cmboBodyType);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnAttendeeStatus);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.cmboLegacyFreeBusyStatus);
            this.Controls.Add(this.txtICalUid);
            this.Controls.Add(this.lblICalUid);
            this.Controls.Add(this.txtChangeKey);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.txtItemId);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.txtResourceAttendees);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpRecurring);
            this.Controls.Add(this.chkIsRecurring);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmboImportance);
            this.Controls.Add(this.chkIsAllDayEvent);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOptionalAttendees);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRequiredAttendees);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpSchedule);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.txtOrganizer);
            this.Controls.Add(this.lblOrganizer);
            this.Controls.Add(this.txtAppointmentType);
            this.Controls.Add(this.lblAppointmentType);
            this.Name = "CalendarForm";
            this.Text = "CalendarForm";
            this.Load += new System.EventHandler(this.CalendarForm_Load);
            this.grpSchedule.ResumeLayout(false);
            this.grpSchedule.PerformLayout();
            this.grpRecurring.ResumeLayout(false);
            this.grpRecurring.PerformLayout();
            this.grpRange.ResumeLayout(false);
            this.grpRange.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpMonthly.ResumeLayout(false);
            this.grpMonthly.PerformLayout();
            this.grpDaily.ResumeLayout(false);
            this.grpDaily.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.TextBox txtOrganizer;
        private System.Windows.Forms.Label lblOrganizer;
        private System.Windows.Forms.TextBox txtAppointmentType;
        private System.Windows.Forms.Label lblAppointmentType;
        private System.Windows.Forms.CheckBox chkIsAllDayEvent;
        private System.Windows.Forms.GroupBox grpSchedule;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDurationEndTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDurationEndDate;
        private System.Windows.Forms.DateTimePicker dtDurationStartDate;
        private System.Windows.Forms.DateTimePicker dtDurationStartTime;
        private System.Windows.Forms.TextBox txtRequiredAttendees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOptionalAttendees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox cmboDurationEndTimezone;
        private System.Windows.Forms.Label lblDurationEndTimezone;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmboDurationStartTimezone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmboImportance;
        private System.Windows.Forms.CheckBox chkIsRecurring;
        private System.Windows.Forms.GroupBox grpRecurring;
        private System.Windows.Forms.ComboBox cmboRecurrEndTimezone;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmboRecurrStartTimezone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtRecurrEndTime;
        private System.Windows.Forms.DateTimePicker dtRecurrStartTime;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rdoYearly;
        private System.Windows.Forms.RadioButton rdoMonthly;
        private System.Windows.Forms.RadioButton rdoWeekly;
        private System.Windows.Forms.RadioButton rdoDaily;
        private System.Windows.Forms.CheckBox chkRecurrWeeklySaturday;
        private System.Windows.Forms.CheckBox chkRecurrWeeklyFriday;
        private System.Windows.Forms.CheckBox chkRecurrWeeklyThursday;
        private System.Windows.Forms.CheckBox chkRecurrWeeklyWednesday;
        private System.Windows.Forms.CheckBox chkRecurrWeeklyTuesday;
        private System.Windows.Forms.CheckBox chkRecurrWeeklyMonday;
        private System.Windows.Forms.CheckBox chkRecurrWeeklySunday;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmboRecurrDailyEveryDays;
        private System.Windows.Forms.ComboBox cmboRecurrWeeklyEveryWeeks;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cmboRecurrDayOfTheWeekIndex;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cmboRecurrDayOfWeek;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cmboRecurrInterval;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmboRecurrYearlyOnSpecificDay;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmboRecurrYearlyOnSpecificDayForMonthOf;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtResourceAttendees;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtRangeEndByDate;
        private System.Windows.Forms.RadioButton rdoRangeEndByDate;
        private System.Windows.Forms.RadioButton rdoRangeEndAfterNumberOccurrences;
        private System.Windows.Forms.RadioButton rdoRangeNoEnd;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DateTimePicker dtStartingDateRange;
        private System.Windows.Forms.TextBox txtRangeNumberOccurrences;
        private System.Windows.Forms.ComboBox cmboRecurrYearlyOnDayPatternMonth;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmboRecurrYearlyOnDayPatternDayOfWeek;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmboRecurrYearlyOnDayPatternDayOfWeekIndex;
        private System.Windows.Forms.RadioButton rdoRelativeYearlyPattern;
        private System.Windows.Forms.RadioButton rdoRecurrYearlyOnSpecificDay;
        private System.Windows.Forms.RadioButton rdoRecurrRelativeMonthyPattern;
        private System.Windows.Forms.RadioButton rdoRecurrMonthlyPattern;
        private System.Windows.Forms.ComboBox cmboRecurrMonthlyPatternDayOfMonth;
        private System.Windows.Forms.Label lblMontlyDayOfMonth;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cmboRecurrMonthlyPatternEveryMonths;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtChangeKey;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtICalUid;
        private System.Windows.Forms.Label lblICalUid;
        private System.Windows.Forms.GroupBox grpMonthly;
        private System.Windows.Forms.GroupBox grpDaily;
        private System.Windows.Forms.GroupBox grpRange;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.ComboBox cmboLegacyFreeBusyStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnAttendeeStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblMessageType;
        private System.Windows.Forms.ComboBox cmboBodyType;
        private System.Windows.Forms.Button btnAttachments;
    }
}