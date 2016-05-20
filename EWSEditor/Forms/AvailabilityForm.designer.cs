namespace EWSEditor.Forms
{
    partial class AvailabilityForm
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
            this.StartTimeWindowLabel = new System.Windows.Forms.Label();
            this.EndWindowDate = new System.Windows.Forms.DateTimePicker();
            this.StartWindowDate = new System.Windows.Forms.DateTimePicker();
            this.EndTimeWindowLabel = new System.Windows.Forms.Label();
            this.TimeWindowGroup = new System.Windows.Forms.GroupBox();
            this.MeetingDurationText = new System.Windows.Forms.TextBox();
            this.CurrentMeetingCheck = new System.Windows.Forms.CheckBox();
            this.lblMeetingDuration = new System.Windows.Forms.Label();
            this.CurrentMeetingDate = new System.Windows.Forms.DateTimePicker();
            this.DetailWindowGroup = new System.Windows.Forms.GroupBox();
            this.StartDetailLabel = new System.Windows.Forms.Label();
            this.EndDetailDate = new System.Windows.Forms.DateTimePicker();
            this.EndDetailLabel = new System.Windows.Forms.Label();
            this.StartDetailDate = new System.Windows.Forms.DateTimePicker();
            this.SuggestionsList = new System.Windows.Forms.ListView();
            this.DateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateQualityColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeQualityColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ConflictsColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsWorkTimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttendeeAvailabilityList = new System.Windows.Forms.ListView();
            this.ViewTypeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WorkingHoursColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MergedFreeBusyStatusColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CalEventsList = new System.Windows.Forms.ListView();
            this.FreeBusyStatusColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartTimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EndTimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SubjectColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LocationColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsExceptionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsMeetingColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsPrivateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsRecurringColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsReminderSetColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StoreIdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddAttendeeButton = new System.Windows.Forms.Button();
            this.SuggestionsGroup = new System.Windows.Forms.GroupBox();
            this.GoodSuggestThresholdText = new System.Windows.Forms.TextBox();
            this.lblGoodSuggestThreshold = new System.Windows.Forms.Label();
            this.MaxNonWorkSuggestText = new System.Windows.Forms.TextBox();
            this.TempMinSuggestQualCombo = new System.Windows.Forms.ComboBox();
            this.MaxSuggestPerDayText = new System.Windows.Forms.TextBox();
            this.lblMaxNonWorkSuggest = new System.Windows.Forms.Label();
            this.lblMaxSuggestPerDay = new System.Windows.Forms.Label();
            this.lblMinSuggestQual = new System.Windows.Forms.Label();
            this.TempRequestFBViewCombo = new System.Windows.Forms.ComboBox();
            this.lblRequestFBView = new System.Windows.Forms.Label();
            this.MergeFBIntervalText = new System.Windows.Forms.TextBox();
            this.lblMergeFBInterval = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GetAvailabilityButton = new System.Windows.Forms.Button();
            this.AvailabilityDataGroup = new System.Windows.Forms.GroupBox();
            this.TempAvailDataCombo = new System.Windows.Forms.ComboBox();
            this.GlobalObjectIdText = new System.Windows.Forms.TextBox();
            this.GlobalObjectIdLabel = new System.Windows.Forms.Label();
            this.RemoveAttendeeButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AttendeeList = new System.Windows.Forms.ListView();
            this.SmtpColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TypeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExcludeConflictsColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.TimeWindowGroup.SuspendLayout();
            this.DetailWindowGroup.SuspendLayout();
            this.SuggestionsGroup.SuspendLayout();
            this.AvailabilityDataGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartTimeWindowLabel
            // 
            this.StartTimeWindowLabel.Location = new System.Drawing.Point(34, 22);
            this.StartTimeWindowLabel.Margin = new System.Windows.Forms.Padding(0);
            this.StartTimeWindowLabel.Name = "StartTimeWindowLabel";
            this.StartTimeWindowLabel.Size = new System.Drawing.Size(46, 20);
            this.StartTimeWindowLabel.TabIndex = 0;
            this.StartTimeWindowLabel.Text = "Start:";
            // 
            // EndWindowDate
            // 
            this.EndWindowDate.CustomFormat = "MMM dd, yyyy - hh:mm tt";
            this.EndWindowDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndWindowDate.Location = new System.Drawing.Point(354, 21);
            this.EndWindowDate.Margin = new System.Windows.Forms.Padding(0);
            this.EndWindowDate.Name = "EndWindowDate";
            this.EndWindowDate.Size = new System.Drawing.Size(215, 22);
            this.EndWindowDate.TabIndex = 3;
            // 
            // StartWindowDate
            // 
            this.StartWindowDate.CustomFormat = "MMM dd, yyyy - hh:mm tt";
            this.StartWindowDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartWindowDate.Location = new System.Drawing.Point(80, 21);
            this.StartWindowDate.Margin = new System.Windows.Forms.Padding(0);
            this.StartWindowDate.Name = "StartWindowDate";
            this.StartWindowDate.Size = new System.Drawing.Size(220, 22);
            this.StartWindowDate.TabIndex = 1;
            // 
            // EndTimeWindowLabel
            // 
            this.EndTimeWindowLabel.Location = new System.Drawing.Point(310, 22);
            this.EndTimeWindowLabel.Margin = new System.Windows.Forms.Padding(0);
            this.EndTimeWindowLabel.Name = "EndTimeWindowLabel";
            this.EndTimeWindowLabel.Size = new System.Drawing.Size(44, 21);
            this.EndTimeWindowLabel.TabIndex = 2;
            this.EndTimeWindowLabel.Text = "End:";
            // 
            // TimeWindowGroup
            // 
            this.TimeWindowGroup.Controls.Add(this.StartTimeWindowLabel);
            this.TimeWindowGroup.Controls.Add(this.MeetingDurationText);
            this.TimeWindowGroup.Controls.Add(this.CurrentMeetingCheck);
            this.TimeWindowGroup.Controls.Add(this.EndWindowDate);
            this.TimeWindowGroup.Controls.Add(this.lblMeetingDuration);
            this.TimeWindowGroup.Controls.Add(this.CurrentMeetingDate);
            this.TimeWindowGroup.Controls.Add(this.EndTimeWindowLabel);
            this.TimeWindowGroup.Controls.Add(this.StartWindowDate);
            this.TimeWindowGroup.Location = new System.Drawing.Point(503, 3);
            this.TimeWindowGroup.Margin = new System.Windows.Forms.Padding(0);
            this.TimeWindowGroup.Name = "TimeWindowGroup";
            this.TimeWindowGroup.Padding = new System.Windows.Forms.Padding(0);
            this.TimeWindowGroup.Size = new System.Drawing.Size(581, 95);
            this.TimeWindowGroup.TabIndex = 0;
            this.TimeWindowGroup.TabStop = false;
            this.TimeWindowGroup.Text = "Availability Time Window and Current Meeting Info";
            // 
            // MeetingDurationText
            // 
            this.MeetingDurationText.Location = new System.Drawing.Point(345, 61);
            this.MeetingDurationText.Margin = new System.Windows.Forms.Padding(0);
            this.MeetingDurationText.Name = "MeetingDurationText";
            this.MeetingDurationText.Size = new System.Drawing.Size(55, 22);
            this.MeetingDurationText.TabIndex = 8;
            // 
            // CurrentMeetingCheck
            // 
            this.CurrentMeetingCheck.Location = new System.Drawing.Point(8, 43);
            this.CurrentMeetingCheck.Margin = new System.Windows.Forms.Padding(0);
            this.CurrentMeetingCheck.Name = "CurrentMeetingCheck";
            this.CurrentMeetingCheck.Size = new System.Drawing.Size(224, 21);
            this.CurrentMeetingCheck.TabIndex = 4;
            this.CurrentMeetingCheck.Text = "Specify a current meeting time";
            this.CurrentMeetingCheck.UseVisualStyleBackColor = true;
            // 
            // lblMeetingDuration
            // 
            this.lblMeetingDuration.Location = new System.Drawing.Point(275, 64);
            this.lblMeetingDuration.Margin = new System.Windows.Forms.Padding(0);
            this.lblMeetingDuration.Name = "lblMeetingDuration";
            this.lblMeetingDuration.Size = new System.Drawing.Size(67, 20);
            this.lblMeetingDuration.TabIndex = 7;
            this.lblMeetingDuration.Text = "Duration:";
            // 
            // CurrentMeetingDate
            // 
            this.CurrentMeetingDate.CustomFormat = "MMM dd, yyyy - hh:mm tt";
            this.CurrentMeetingDate.Enabled = false;
            this.CurrentMeetingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CurrentMeetingDate.Location = new System.Drawing.Point(37, 64);
            this.CurrentMeetingDate.Margin = new System.Windows.Forms.Padding(0);
            this.CurrentMeetingDate.Name = "CurrentMeetingDate";
            this.CurrentMeetingDate.Size = new System.Drawing.Size(220, 22);
            this.CurrentMeetingDate.TabIndex = 6;
            // 
            // DetailWindowGroup
            // 
            this.DetailWindowGroup.Controls.Add(this.StartDetailLabel);
            this.DetailWindowGroup.Controls.Add(this.EndDetailDate);
            this.DetailWindowGroup.Controls.Add(this.EndDetailLabel);
            this.DetailWindowGroup.Controls.Add(this.StartDetailDate);
            this.DetailWindowGroup.Location = new System.Drawing.Point(8, 18);
            this.DetailWindowGroup.Margin = new System.Windows.Forms.Padding(4);
            this.DetailWindowGroup.Name = "DetailWindowGroup";
            this.DetailWindowGroup.Padding = new System.Windows.Forms.Padding(4);
            this.DetailWindowGroup.Size = new System.Drawing.Size(344, 78);
            this.DetailWindowGroup.TabIndex = 0;
            this.DetailWindowGroup.TabStop = false;
            this.DetailWindowGroup.Text = "Detailed Suggestions Time Window";
            // 
            // StartDetailLabel
            // 
            this.StartDetailLabel.Location = new System.Drawing.Point(21, 28);
            this.StartDetailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StartDetailLabel.Name = "StartDetailLabel";
            this.StartDetailLabel.Size = new System.Drawing.Size(77, 20);
            this.StartDetailLabel.TabIndex = 0;
            this.StartDetailLabel.Text = "Start Time:";
            // 
            // EndDetailDate
            // 
            this.EndDetailDate.CustomFormat = "MMM dd, yyyy - hh:mm tt";
            this.EndDetailDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDetailDate.Location = new System.Drawing.Point(115, 52);
            this.EndDetailDate.Margin = new System.Windows.Forms.Padding(4);
            this.EndDetailDate.Name = "EndDetailDate";
            this.EndDetailDate.Size = new System.Drawing.Size(215, 22);
            this.EndDetailDate.TabIndex = 3;
            // 
            // EndDetailLabel
            // 
            this.EndDetailLabel.Location = new System.Drawing.Point(24, 53);
            this.EndDetailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EndDetailLabel.Name = "EndDetailLabel";
            this.EndDetailLabel.Size = new System.Drawing.Size(77, 20);
            this.EndDetailLabel.TabIndex = 2;
            this.EndDetailLabel.Text = "End Time:";
            // 
            // StartDetailDate
            // 
            this.StartDetailDate.CustomFormat = "MMM dd, yyyy - hh:mm tt";
            this.StartDetailDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDetailDate.Location = new System.Drawing.Point(115, 23);
            this.StartDetailDate.Margin = new System.Windows.Forms.Padding(4);
            this.StartDetailDate.Name = "StartDetailDate";
            this.StartDetailDate.Size = new System.Drawing.Size(215, 22);
            this.StartDetailDate.TabIndex = 1;
            // 
            // SuggestionsList
            // 
            this.SuggestionsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SuggestionsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DateColumn,
            this.DateQualityColumn,
            this.TimeColumn,
            this.TimeQualityColumn,
            this.ConflictsColumn,
            this.IsWorkTimeColumn});
            this.SuggestionsList.Location = new System.Drawing.Point(7, 565);
            this.SuggestionsList.Margin = new System.Windows.Forms.Padding(4);
            this.SuggestionsList.Name = "SuggestionsList";
            this.SuggestionsList.Size = new System.Drawing.Size(1127, 137);
            this.SuggestionsList.TabIndex = 2;
            this.SuggestionsList.UseCompatibleStateImageBehavior = false;
            this.SuggestionsList.View = System.Windows.Forms.View.Details;
            // 
            // DateColumn
            // 
            this.DateColumn.Text = "Date";
            this.DateColumn.Width = 91;
            // 
            // DateQualityColumn
            // 
            this.DateQualityColumn.Text = "DateQuality";
            this.DateQualityColumn.Width = 101;
            // 
            // TimeColumn
            // 
            this.TimeColumn.Text = "Time";
            this.TimeColumn.Width = 70;
            // 
            // TimeQualityColumn
            // 
            this.TimeQualityColumn.Text = "TimeQuality";
            this.TimeQualityColumn.Width = 112;
            // 
            // ConflictsColumn
            // 
            this.ConflictsColumn.Text = "Conflicts";
            this.ConflictsColumn.Width = 72;
            // 
            // IsWorkTimeColumn
            // 
            this.IsWorkTimeColumn.Text = "IsWorkTime";
            this.IsWorkTimeColumn.Width = 74;
            // 
            // AttendeeAvailabilityList
            // 
            this.AttendeeAvailabilityList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AttendeeAvailabilityList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ViewTypeColumn,
            this.WorkingHoursColumn,
            this.MergedFreeBusyStatusColumn});
            this.AttendeeAvailabilityList.FullRowSelect = true;
            this.AttendeeAvailabilityList.Location = new System.Drawing.Point(6, 339);
            this.AttendeeAvailabilityList.Margin = new System.Windows.Forms.Padding(4);
            this.AttendeeAvailabilityList.MultiSelect = false;
            this.AttendeeAvailabilityList.Name = "AttendeeAvailabilityList";
            this.AttendeeAvailabilityList.Size = new System.Drawing.Size(1127, 88);
            this.AttendeeAvailabilityList.TabIndex = 0;
            this.AttendeeAvailabilityList.UseCompatibleStateImageBehavior = false;
            this.AttendeeAvailabilityList.View = System.Windows.Forms.View.Details;
            // 
            // ViewTypeColumn
            // 
            this.ViewTypeColumn.Text = "ViewType";
            this.ViewTypeColumn.Width = 90;
            // 
            // WorkingHoursColumn
            // 
            this.WorkingHoursColumn.Text = "WorkingHours";
            this.WorkingHoursColumn.Width = 90;
            // 
            // MergedFreeBusyStatusColumn
            // 
            this.MergedFreeBusyStatusColumn.Text = "MergedFreeBusyStatus";
            this.MergedFreeBusyStatusColumn.Width = 137;
            // 
            // CalEventsList
            // 
            this.CalEventsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CalEventsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FreeBusyStatusColumn,
            this.StartTimeColumn,
            this.EndTimeColumn,
            this.SubjectColumn,
            this.LocationColumn,
            this.IsExceptionColumn,
            this.IsMeetingColumn,
            this.IsPrivateColumn,
            this.IsRecurringColumn,
            this.IsReminderSetColumn,
            this.StoreIdColumn});
            this.CalEventsList.FullRowSelect = true;
            this.CalEventsList.Location = new System.Drawing.Point(7, 435);
            this.CalEventsList.Margin = new System.Windows.Forms.Padding(4);
            this.CalEventsList.MultiSelect = false;
            this.CalEventsList.Name = "CalEventsList";
            this.CalEventsList.Size = new System.Drawing.Size(1127, 122);
            this.CalEventsList.TabIndex = 1;
            this.CalEventsList.UseCompatibleStateImageBehavior = false;
            this.CalEventsList.View = System.Windows.Forms.View.Details;
            // 
            // FreeBusyStatusColumn
            // 
            this.FreeBusyStatusColumn.Text = "FreeBusyStatus";
            this.FreeBusyStatusColumn.Width = 111;
            // 
            // StartTimeColumn
            // 
            this.StartTimeColumn.Text = "StartTime";
            this.StartTimeColumn.Width = 114;
            // 
            // EndTimeColumn
            // 
            this.EndTimeColumn.Text = "EndTime";
            this.EndTimeColumn.Width = 127;
            // 
            // SubjectColumn
            // 
            this.SubjectColumn.Text = "Subject";
            this.SubjectColumn.Width = 195;
            // 
            // LocationColumn
            // 
            this.LocationColumn.Text = "Location";
            this.LocationColumn.Width = 107;
            // 
            // IsExceptionColumn
            // 
            this.IsExceptionColumn.Text = "IsException";
            this.IsExceptionColumn.Width = 69;
            // 
            // IsMeetingColumn
            // 
            this.IsMeetingColumn.Text = "IsMeeting";
            // 
            // IsPrivateColumn
            // 
            this.IsPrivateColumn.Text = "IsPrivate";
            // 
            // IsRecurringColumn
            // 
            this.IsRecurringColumn.Text = "IsRecurring";
            this.IsRecurringColumn.Width = 66;
            // 
            // IsReminderSetColumn
            // 
            this.IsReminderSetColumn.Text = "IsReminderSet";
            this.IsReminderSetColumn.Width = 82;
            // 
            // StoreIdColumn
            // 
            this.StoreIdColumn.Text = "StoreId";
            this.StoreIdColumn.Width = 55;
            // 
            // AddAttendeeButton
            // 
            this.AddAttendeeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddAttendeeButton.Location = new System.Drawing.Point(8, 274);
            this.AddAttendeeButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddAttendeeButton.Name = "AddAttendeeButton";
            this.AddAttendeeButton.Size = new System.Drawing.Size(105, 28);
            this.AddAttendeeButton.TabIndex = 0;
            this.AddAttendeeButton.Text = "Add Attendee";
            this.AddAttendeeButton.UseVisualStyleBackColor = true;
            this.AddAttendeeButton.Click += new System.EventHandler(this.AddAttendeeButton_Click);
            // 
            // SuggestionsGroup
            // 
            this.SuggestionsGroup.BackColor = System.Drawing.SystemColors.Control;
            this.SuggestionsGroup.Controls.Add(this.GoodSuggestThresholdText);
            this.SuggestionsGroup.Controls.Add(this.lblGoodSuggestThreshold);
            this.SuggestionsGroup.Controls.Add(this.MaxNonWorkSuggestText);
            this.SuggestionsGroup.Controls.Add(this.TempMinSuggestQualCombo);
            this.SuggestionsGroup.Controls.Add(this.DetailWindowGroup);
            this.SuggestionsGroup.Controls.Add(this.MaxSuggestPerDayText);
            this.SuggestionsGroup.Controls.Add(this.lblMaxNonWorkSuggest);
            this.SuggestionsGroup.Controls.Add(this.lblMaxSuggestPerDay);
            this.SuggestionsGroup.Controls.Add(this.lblMinSuggestQual);
            this.SuggestionsGroup.Location = new System.Drawing.Point(776, 102);
            this.SuggestionsGroup.Margin = new System.Windows.Forms.Padding(4);
            this.SuggestionsGroup.Name = "SuggestionsGroup";
            this.SuggestionsGroup.Padding = new System.Windows.Forms.Padding(4);
            this.SuggestionsGroup.Size = new System.Drawing.Size(363, 210);
            this.SuggestionsGroup.TabIndex = 2;
            this.SuggestionsGroup.TabStop = false;
            this.SuggestionsGroup.Text = "Suggestion Options";
            // 
            // GoodSuggestThresholdText
            // 
            this.GoodSuggestThresholdText.Location = new System.Drawing.Point(253, 153);
            this.GoodSuggestThresholdText.Margin = new System.Windows.Forms.Padding(0);
            this.GoodSuggestThresholdText.Name = "GoodSuggestThresholdText";
            this.GoodSuggestThresholdText.Size = new System.Drawing.Size(55, 22);
            this.GoodSuggestThresholdText.TabIndex = 108;
            // 
            // lblGoodSuggestThreshold
            // 
            this.lblGoodSuggestThreshold.Location = new System.Drawing.Point(8, 150);
            this.lblGoodSuggestThreshold.Margin = new System.Windows.Forms.Padding(0);
            this.lblGoodSuggestThreshold.Name = "lblGoodSuggestThreshold";
            this.lblGoodSuggestThreshold.Size = new System.Drawing.Size(228, 25);
            this.lblGoodSuggestThreshold.TabIndex = 3;
            this.lblGoodSuggestThreshold.Text = "Good Suggestion Thresold (%):";
            // 
            // MaxNonWorkSuggestText
            // 
            this.MaxNonWorkSuggestText.Location = new System.Drawing.Point(253, 97);
            this.MaxNonWorkSuggestText.Margin = new System.Windows.Forms.Padding(0);
            this.MaxNonWorkSuggestText.Name = "MaxNonWorkSuggestText";
            this.MaxNonWorkSuggestText.Size = new System.Drawing.Size(55, 22);
            this.MaxNonWorkSuggestText.TabIndex = 104;
            // 
            // TempMinSuggestQualCombo
            // 
            this.TempMinSuggestQualCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempMinSuggestQualCombo.FormattingEnabled = true;
            this.TempMinSuggestQualCombo.Location = new System.Drawing.Point(199, 179);
            this.TempMinSuggestQualCombo.Margin = new System.Windows.Forms.Padding(4);
            this.TempMinSuggestQualCombo.Name = "TempMinSuggestQualCombo";
            this.TempMinSuggestQualCombo.Size = new System.Drawing.Size(151, 24);
            this.TempMinSuggestQualCombo.TabIndex = 106;
            // 
            // MaxSuggestPerDayText
            // 
            this.MaxSuggestPerDayText.Location = new System.Drawing.Point(253, 123);
            this.MaxSuggestPerDayText.Margin = new System.Windows.Forms.Padding(0);
            this.MaxSuggestPerDayText.Name = "MaxSuggestPerDayText";
            this.MaxSuggestPerDayText.Size = new System.Drawing.Size(55, 22);
            this.MaxSuggestPerDayText.TabIndex = 105;
            // 
            // lblMaxNonWorkSuggest
            // 
            this.lblMaxNonWorkSuggest.Location = new System.Drawing.Point(8, 96);
            this.lblMaxNonWorkSuggest.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxNonWorkSuggest.Name = "lblMaxNonWorkSuggest";
            this.lblMaxNonWorkSuggest.Size = new System.Drawing.Size(247, 23);
            this.lblMaxNonWorkSuggest.TabIndex = 1;
            this.lblMaxNonWorkSuggest.Text = "Max Non-work Hours Suggestions:";
            // 
            // lblMaxSuggestPerDay
            // 
            this.lblMaxSuggestPerDay.Location = new System.Drawing.Point(8, 126);
            this.lblMaxSuggestPerDay.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxSuggestPerDay.Name = "lblMaxSuggestPerDay";
            this.lblMaxSuggestPerDay.Size = new System.Drawing.Size(228, 23);
            this.lblMaxSuggestPerDay.TabIndex = 2;
            this.lblMaxSuggestPerDay.Text = "Max Suggestions Per Day:";
            // 
            // lblMinSuggestQual
            // 
            this.lblMinSuggestQual.Location = new System.Drawing.Point(8, 180);
            this.lblMinSuggestQual.Margin = new System.Windows.Forms.Padding(0);
            this.lblMinSuggestQual.Name = "lblMinSuggestQual";
            this.lblMinSuggestQual.Size = new System.Drawing.Size(165, 23);
            this.lblMinSuggestQual.TabIndex = 4;
            this.lblMinSuggestQual.Text = "Min. Suggestion Quality:";
            // 
            // TempRequestFBViewCombo
            // 
            this.TempRequestFBViewCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempRequestFBViewCombo.FormattingEnabled = true;
            this.TempRequestFBViewCombo.Location = new System.Drawing.Point(33, 93);
            this.TempRequestFBViewCombo.Margin = new System.Windows.Forms.Padding(0);
            this.TempRequestFBViewCombo.Name = "TempRequestFBViewCombo";
            this.TempRequestFBViewCombo.Size = new System.Drawing.Size(194, 24);
            this.TempRequestFBViewCombo.TabIndex = 8;
            // 
            // lblRequestFBView
            // 
            this.lblRequestFBView.Location = new System.Drawing.Point(4, 70);
            this.lblRequestFBView.Margin = new System.Windows.Forms.Padding(0);
            this.lblRequestFBView.Name = "lblRequestFBView";
            this.lblRequestFBView.Size = new System.Drawing.Size(188, 21);
            this.lblRequestFBView.TabIndex = 5;
            this.lblRequestFBView.Text = "Requested Free/Busy View:";
            // 
            // MergeFBIntervalText
            // 
            this.MergeFBIntervalText.Location = new System.Drawing.Point(192, 123);
            this.MergeFBIntervalText.Margin = new System.Windows.Forms.Padding(0);
            this.MergeFBIntervalText.Name = "MergeFBIntervalText";
            this.MergeFBIntervalText.Size = new System.Drawing.Size(55, 22);
            this.MergeFBIntervalText.TabIndex = 15;
            // 
            // lblMergeFBInterval
            // 
            this.lblMergeFBInterval.Location = new System.Drawing.Point(4, 122);
            this.lblMergeFBInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMergeFBInterval.Name = "lblMergeFBInterval";
            this.lblMergeFBInterval.Size = new System.Drawing.Size(184, 23);
            this.lblMergeFBInterval.TabIndex = 12;
            this.lblMergeFBInterval.Text = "Merged Free/Busy Interval:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Requested Availability Data:";
            // 
            // GetAvailabilityButton
            // 
            this.GetAvailabilityButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GetAvailabilityButton.Location = new System.Drawing.Point(305, 274);
            this.GetAvailabilityButton.Margin = new System.Windows.Forms.Padding(4);
            this.GetAvailabilityButton.Name = "GetAvailabilityButton";
            this.GetAvailabilityButton.Size = new System.Drawing.Size(177, 28);
            this.GetAvailabilityButton.TabIndex = 86;
            this.GetAvailabilityButton.Text = "Get User Availability";
            this.GetAvailabilityButton.UseVisualStyleBackColor = true;
            this.GetAvailabilityButton.Click += new System.EventHandler(this.GetAvailabilityButton_Click);
            // 
            // AvailabilityDataGroup
            // 
            this.AvailabilityDataGroup.Controls.Add(this.TempAvailDataCombo);
            this.AvailabilityDataGroup.Controls.Add(this.GlobalObjectIdText);
            this.AvailabilityDataGroup.Controls.Add(this.label1);
            this.AvailabilityDataGroup.Controls.Add(this.GlobalObjectIdLabel);
            this.AvailabilityDataGroup.Controls.Add(this.lblRequestFBView);
            this.AvailabilityDataGroup.Controls.Add(this.TempRequestFBViewCombo);
            this.AvailabilityDataGroup.Controls.Add(this.lblMergeFBInterval);
            this.AvailabilityDataGroup.Controls.Add(this.MergeFBIntervalText);
            this.AvailabilityDataGroup.Location = new System.Drawing.Point(508, 102);
            this.AvailabilityDataGroup.Margin = new System.Windows.Forms.Padding(4);
            this.AvailabilityDataGroup.Name = "AvailabilityDataGroup";
            this.AvailabilityDataGroup.Padding = new System.Windows.Forms.Padding(4);
            this.AvailabilityDataGroup.Size = new System.Drawing.Size(260, 210);
            this.AvailabilityDataGroup.TabIndex = 1;
            this.AvailabilityDataGroup.TabStop = false;
            this.AvailabilityDataGroup.Text = "Availability Data Options";
            this.AvailabilityDataGroup.Enter += new System.EventHandler(this.AvailabilityDataGroup_Enter);
            // 
            // TempAvailDataCombo
            // 
            this.TempAvailDataCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempAvailDataCombo.FormattingEnabled = true;
            this.TempAvailDataCombo.Location = new System.Drawing.Point(33, 43);
            this.TempAvailDataCombo.Margin = new System.Windows.Forms.Padding(0);
            this.TempAvailDataCombo.Name = "TempAvailDataCombo";
            this.TempAvailDataCombo.Size = new System.Drawing.Size(194, 24);
            this.TempAvailDataCombo.TabIndex = 3;
            // 
            // GlobalObjectIdText
            // 
            this.GlobalObjectIdText.Location = new System.Drawing.Point(37, 180);
            this.GlobalObjectIdText.Margin = new System.Windows.Forms.Padding(0);
            this.GlobalObjectIdText.Name = "GlobalObjectIdText";
            this.GlobalObjectIdText.Size = new System.Drawing.Size(194, 22);
            this.GlobalObjectIdText.TabIndex = 20;
            // 
            // GlobalObjectIdLabel
            // 
            this.GlobalObjectIdLabel.Location = new System.Drawing.Point(5, 158);
            this.GlobalObjectIdLabel.Margin = new System.Windows.Forms.Padding(0);
            this.GlobalObjectIdLabel.Name = "GlobalObjectIdLabel";
            this.GlobalObjectIdLabel.Size = new System.Drawing.Size(121, 17);
            this.GlobalObjectIdLabel.TabIndex = 18;
            this.GlobalObjectIdLabel.Text = "Global Object ID:";
            // 
            // RemoveAttendeeButton
            // 
            this.RemoveAttendeeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveAttendeeButton.Location = new System.Drawing.Point(121, 274);
            this.RemoveAttendeeButton.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveAttendeeButton.Name = "RemoveAttendeeButton";
            this.RemoveAttendeeButton.Size = new System.Drawing.Size(131, 28);
            this.RemoveAttendeeButton.TabIndex = 1;
            this.RemoveAttendeeButton.Text = "Remove Attendee";
            this.RemoveAttendeeButton.UseVisualStyleBackColor = true;
            this.RemoveAttendeeButton.Click += new System.EventHandler(this.RemoveAttendeeButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RemoveAttendeeButton);
            this.groupBox2.Controls.Add(this.AttendeeList);
            this.groupBox2.Controls.Add(this.AddAttendeeButton);
            this.groupBox2.Controls.Add(this.GetAvailabilityButton);
            this.groupBox2.Location = new System.Drawing.Point(7, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(486, 310);
            this.groupBox2.TabIndex = 115;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Attendees";
            // 
            // AttendeeList
            // 
            this.AttendeeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SmtpColumn,
            this.TypeColumn,
            this.ExcludeConflictsColumn});
            this.AttendeeList.Dock = System.Windows.Forms.DockStyle.Top;
            this.AttendeeList.FullRowSelect = true;
            this.AttendeeList.HideSelection = false;
            this.AttendeeList.Location = new System.Drawing.Point(4, 19);
            this.AttendeeList.Margin = new System.Windows.Forms.Padding(4);
            this.AttendeeList.MultiSelect = false;
            this.AttendeeList.Name = "AttendeeList";
            this.AttendeeList.Size = new System.Drawing.Size(478, 247);
            this.AttendeeList.TabIndex = 2;
            this.AttendeeList.UseCompatibleStateImageBehavior = false;
            this.AttendeeList.View = System.Windows.Forms.View.Details;
            this.AttendeeList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.AttendeeList_ItemSelectionChanged);
            // 
            // SmtpColumn
            // 
            this.SmtpColumn.Text = "SMTP Address";
            this.SmtpColumn.Width = 220;
            // 
            // TypeColumn
            // 
            this.TypeColumn.Text = "Attendee Type";
            this.TypeColumn.Width = 111;
            // 
            // ExcludeConflictsColumn
            // 
            this.ExcludeConflictsColumn.Text = "Exclude Conflicts";
            this.ExcludeConflictsColumn.Width = 120;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 312);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 23);
            this.label2.TabIndex = 201;
            this.label2.Text = "Attendees and Availability";
            // 
            // AvailabilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 709);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SuggestionsList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CalEventsList);
            this.Controls.Add(this.AttendeeAvailabilityList);
            this.Controls.Add(this.AvailabilityDataGroup);
            this.Controls.Add(this.TimeWindowGroup);
            this.Controls.Add(this.SuggestionsGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.MaximizeBox = false;
            this.Name = "AvailabilityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Availability";
            this.Load += new System.EventHandler(this.AvailabilityDialog_Load);
            this.TimeWindowGroup.ResumeLayout(false);
            this.TimeWindowGroup.PerformLayout();
            this.DetailWindowGroup.ResumeLayout(false);
            this.SuggestionsGroup.ResumeLayout(false);
            this.SuggestionsGroup.PerformLayout();
            this.AvailabilityDataGroup.ResumeLayout(false);
            this.AvailabilityDataGroup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label StartTimeWindowLabel;
        private System.Windows.Forms.DateTimePicker EndWindowDate;
        private System.Windows.Forms.DateTimePicker StartWindowDate;
        private System.Windows.Forms.Label EndTimeWindowLabel;
        private System.Windows.Forms.GroupBox TimeWindowGroup;
        private System.Windows.Forms.GroupBox DetailWindowGroup;
        private System.Windows.Forms.Label StartDetailLabel;
        private System.Windows.Forms.DateTimePicker EndDetailDate;
        private System.Windows.Forms.Label EndDetailLabel;
        private System.Windows.Forms.DateTimePicker StartDetailDate;
        private System.Windows.Forms.GroupBox SuggestionsGroup;
        private System.Windows.Forms.Button AddAttendeeButton;
        private System.Windows.Forms.ComboBox TempRequestFBViewCombo;
         
 
        private System.Windows.Forms.Label lblRequestFBView;
        private System.Windows.Forms.Label lblMinSuggestQual;
        private System.Windows.Forms.TextBox MergeFBIntervalText;
        private System.Windows.Forms.TextBox MeetingDurationText;
        private System.Windows.Forms.TextBox MaxSuggestPerDayText;
        private System.Windows.Forms.TextBox MaxNonWorkSuggestText;
        private System.Windows.Forms.Label lblMergeFBInterval;
        private System.Windows.Forms.Label lblMeetingDuration;
        private System.Windows.Forms.Label lblMaxSuggestPerDay;
        private System.Windows.Forms.Label lblMaxNonWorkSuggest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox GoodSuggestThresholdText;
        private System.Windows.Forms.Label lblGoodSuggestThreshold;
        private System.Windows.Forms.ComboBox TempMinSuggestQualCombo;
        private System.Windows.Forms.Button GetAvailabilityButton;
        private System.Windows.Forms.CheckBox CurrentMeetingCheck;
        private System.Windows.Forms.DateTimePicker CurrentMeetingDate;
        private System.Windows.Forms.GroupBox AvailabilityDataGroup;
        private System.Windows.Forms.ListView CalEventsList;
        private System.Windows.Forms.TextBox GlobalObjectIdText;
        private System.Windows.Forms.Label GlobalObjectIdLabel;
        private System.Windows.Forms.ColumnHeader FreeBusyStatusColumn;
        private System.Windows.Forms.ColumnHeader StartTimeColumn;
        private System.Windows.Forms.ColumnHeader EndTimeColumn;
        private System.Windows.Forms.ListView AttendeeAvailabilityList;
        private System.Windows.Forms.ColumnHeader ViewTypeColumn;
        private System.Windows.Forms.ColumnHeader WorkingHoursColumn;
        private System.Windows.Forms.ColumnHeader MergedFreeBusyStatusColumn;
        private System.Windows.Forms.ColumnHeader SubjectColumn;
        private System.Windows.Forms.ColumnHeader LocationColumn;
        private System.Windows.Forms.ColumnHeader IsExceptionColumn;
        private System.Windows.Forms.ColumnHeader IsMeetingColumn;
        private System.Windows.Forms.ColumnHeader IsPrivateColumn;
        private System.Windows.Forms.ColumnHeader IsRecurringColumn;
        private System.Windows.Forms.ColumnHeader IsReminderSetColumn;
        private System.Windows.Forms.ColumnHeader StoreIdColumn;
        private System.Windows.Forms.Button RemoveAttendeeButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView AttendeeList;
        private System.Windows.Forms.ColumnHeader SmtpColumn;
        private System.Windows.Forms.ColumnHeader TypeColumn;
        private System.Windows.Forms.ColumnHeader ExcludeConflictsColumn;
        private System.Windows.Forms.ListView SuggestionsList;
        private System.Windows.Forms.ColumnHeader DateColumn;
        private System.Windows.Forms.ColumnHeader DateQualityColumn;
        private System.Windows.Forms.ColumnHeader TimeColumn;
        private System.Windows.Forms.ColumnHeader TimeQualityColumn;
        private System.Windows.Forms.ColumnHeader ConflictsColumn;
        private System.Windows.Forms.ColumnHeader IsWorkTimeColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TempAvailDataCombo;
    }
}