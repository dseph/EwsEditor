using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Forms; 
using EWSEditor.Forms.Controls;
using EWSEditor.Logging;
using EWSEditor.Common;

// TODO: Determine if its recurring.
// TODO: If recurring, ask if they want to open occurance or series.

namespace EWSEditor.Forms
{
    public partial class CalendarForm : Form
    {
        private bool _IsExistingAppointment = false;
        private ExchangeService _ExchangeService = null;
        private Appointment _Appointment = null;
        private FolderId _FolderId = null;
        private bool _isDirty = false;
        public bool _WasDeleted { get; set; }
        public bool _WasSaved { get; set; }
        public bool _WasSent { get; set; }

        public CalendarForm()
        {
            InitializeComponent();
        }

        public CalendarForm(ExchangeService oExchangeService, FolderId oFolderId)
        {
            InitializeComponent();
            _ExchangeService = oExchangeService;
            _IsExistingAppointment = false;
            _FolderId = oFolderId;
            NewAppointment();
            //ClearForm();
        }

        public CalendarForm(ExchangeService oExchangeService, ItemId oItemId)
        {
            InitializeComponent();
            _ExchangeService = oExchangeService;


            _Appointment = LoadAppointmentForEdit(oExchangeService, oItemId);
            _FolderId = _Appointment.ParentFolderId;
            _IsExistingAppointment = true;
            SetFormFromAppointment(_Appointment);

            _isDirty = false;
        }

        //public CalendarForm(EwsCaller oEwsCaller, ItemId oAppointment)
        //{
        //    InitializeComponent();
        //    _EwsCaller = oEwsCaller;


        //    _Appointment = LoadAppointmentForEdit(oEwsCaller, oAppointment);
        //    _FolderId = _Appointment.ParentFolderId;
        //    _IsExistingAppointment = true;
        //    SetFormFromAppointment(_Appointment);

        //    _isDirty = false;
        //}


        private void CalendarForm_Load(object sender, EventArgs e)
        {
            // http://msdn.microsoft.com/en-us/library/dd633685(EXCHG.80).aspx
            string s = string.Empty;
            this.cmboDurationStartTimezone.Items.Clear();
            this.cmboDurationEndTimezone.Items.Clear();
            this.cmboRecurrStartTimezone.Items.Clear();
            this.cmboRecurrEndTimezone.Items.Clear();
            foreach (TimeZoneInfo tzinfo in TimeZoneInfo.GetSystemTimeZones())
            {
                s = TimeHelper.GetTimezoneStringForCombobox(tzinfo);
                //s = tzinfo.DisplayName + " | " + tzinfo.Id + " | " + tzinfo.BaseUtcOffset.ToString();
                this.cmboDurationStartTimezone.Items.Add(s);    
                this.cmboDurationEndTimezone.Items.Add(s);
                this.cmboRecurrStartTimezone.Items.Add(s);
                this.cmboRecurrEndTimezone.Items.Add(s);
            }
            // Default local timezones. 
            s = TimeZoneInfo.Local.DisplayName + " | " + TimeZoneInfo.Local.Id + " | " + TimeZoneInfo.Local.BaseUtcOffset.ToString();
            this.cmboDurationStartTimezone.Text = s;  
            this.cmboDurationEndTimezone.Text = s;  
            this.cmboRecurrStartTimezone.Text = s;  
            this.cmboRecurrEndTimezone.Text = s;  

            //DateTime.Now.ToLocalTime().time

            _WasDeleted = false;
            _WasSaved = false;
            _WasSent = false;
 
        }

        private void SetMonthlyRdoEnablement()
        {
            if (rdoRecurrMonthlyPattern.Checked == true)
            {
                this.rdoRecurrRelativeMonthyPattern.Checked = false;
            }
            if (rdoRecurrRelativeMonthyPattern.Checked == true)
            {
                this.rdoRecurrMonthlyPattern.Checked = false;
            }

            cmboRecurrMonthlyPatternDayOfMonth.Enabled = rdoRecurrMonthlyPattern.Checked;
            cmboRecurrMonthlyPatternEveryMonths.Enabled = rdoRecurrMonthlyPattern.Checked;
            cmboRecurrInterval.Enabled = rdoRecurrRelativeMonthyPattern.Checked;
            cmboRecurrDayOfWeek.Enabled = rdoRecurrRelativeMonthyPattern.Checked;
            cmboRecurrDayOfTheWeekIndex.Enabled = rdoRecurrRelativeMonthyPattern.Checked;
        }

        private void SetYearlyRdoEnablement()
        {
            if (rdoRecurrYearlyOnSpecificDay.Checked == true)
            {
                this.rdoRelativeYearlyPattern.Checked = false;
            }
            if (rdoRelativeYearlyPattern.Checked == true)
            {
                this.rdoRecurrYearlyOnSpecificDay.Checked = false;
            }

            cmboRecurrYearlyOnSpecificDayForMonthOf.Enabled = rdoRecurrYearlyOnSpecificDay.Checked;
            cmboRecurrYearlyOnSpecificDay.Enabled = rdoRecurrYearlyOnSpecificDay.Checked;

            cmboRecurrYearlyOnDayPatternDayOfWeekIndex.Enabled = rdoRelativeYearlyPattern.Checked;
            cmboRecurrYearlyOnDayPatternDayOfWeek.Enabled = rdoRelativeYearlyPattern.Checked;
            cmboRecurrYearlyOnDayPatternMonth.Enabled = rdoRelativeYearlyPattern.Checked;
        }

        private void SetRangeRdoEnablement()
        {

        }

        private Appointment LoadAppointmentForEdit(ExchangeService oExchangeService, ItemId oItemId)
        {
            PropertySet oPropertySet = null;


            //if (oExchangeService.ServerInfo.VersionString.StartsWith("Exchange2010") == true ||
            //    oExchangeService.ServerInfo.VersionString.StartsWith("Exchange2013") == true ||
            //    oExchangeService.ServerInfo.VersionString.StartsWith("Exchange2013_SP1") == true ||
            //    oExchangeService.ServerInfo.VersionString.StartsWith("V2_") == true)
            //{   // 2010 and above
            if (_ExchangeService.ServerInfo.VersionString.CompareTo("Exchange2010") >= 0)
              {   // 2010 and above
                oPropertySet = new PropertySet(BasePropertySet.IdOnly,
                AppointmentSchema.Subject,
                AppointmentSchema.Location,
                AppointmentSchema.Start,
                AppointmentSchema.End,
                AppointmentSchema.IsRecurring,
                AppointmentSchema.AppointmentType,
                AppointmentSchema.ItemClass,
                AppointmentSchema.Organizer,
                AppointmentSchema.Body,
                AppointmentSchema.IsAllDayEvent,
                AppointmentSchema.IsRecurring,
                AppointmentSchema.IsMeeting,
                AppointmentSchema.RequiredAttendees,
                AppointmentSchema.OptionalAttendees,
                AppointmentSchema.Resources,

                AppointmentSchema.HasAttachments,
                AppointmentSchema.Importance,

                AppointmentSchema.Attachments,
                AppointmentSchema.ConferenceType,
                AppointmentSchema.ConversationId,
                AppointmentSchema.AppointmentType,
                AppointmentSchema.AppointmentState,
                AppointmentSchema.AppointmentSequenceNumber,
                AppointmentSchema.Categories,
 
                AppointmentSchema.DateTimeCreated,
                AppointmentSchema.DateTimeReceived,
                AppointmentSchema.DateTimeSent,
                AppointmentSchema.ICalUid,
                AppointmentSchema.ICalRecurrenceId,
                AppointmentSchema.ICalDateTimeStamp,
                AppointmentSchema.IsMeeting,
                AppointmentSchema.IsDraft,
                AppointmentSchema.IsAssociated,
                AppointmentSchema.IsCancelled,
                AppointmentSchema.IsFromMe,
                AppointmentSchema.IsOnlineMeeting,
                AppointmentSchema.IsReminderSet,
                AppointmentSchema.IsResend,
                AppointmentSchema.IsResponseRequested,
                AppointmentSchema.IsSubmitted,
                AppointmentSchema.IsUnmodified,
                AppointmentSchema.ItemClass,
                AppointmentSchema.LastModifiedName,
                AppointmentSchema.LastModifiedTime,
                AppointmentSchema.LastOccurrence,
                AppointmentSchema.LegacyFreeBusyStatus,
                AppointmentSchema.MeetingRequestWasSent,
                AppointmentSchema.MeetingWorkspaceUrl,
                AppointmentSchema.MimeContent,
                AppointmentSchema.ModifiedOccurrences,
                AppointmentSchema.NetShowUrl,
                AppointmentSchema.OriginalStart,
                AppointmentSchema.ParentFolderId,
                AppointmentSchema.Recurrence,
                AppointmentSchema.ReminderDueBy,
                AppointmentSchema.ReminderMinutesBeforeStart,
                AppointmentSchema.Resources,
                AppointmentSchema.Sensitivity,
                AppointmentSchema.Size,
                AppointmentSchema.StartTimeZone,
                AppointmentSchema.TimeZone,
                AppointmentSchema.EndTimeZone
                );
            }
            else
            {  // 2007 and 2007 sp1
                oPropertySet = new PropertySet(BasePropertySet.IdOnly,
                AppointmentSchema.Subject,
                AppointmentSchema.Location,
                AppointmentSchema.Start,
                AppointmentSchema.End,
                AppointmentSchema.IsRecurring,
                AppointmentSchema.AppointmentType,
                AppointmentSchema.ItemClass,
                AppointmentSchema.Organizer,
                AppointmentSchema.Body,
                AppointmentSchema.IsAllDayEvent,
                AppointmentSchema.IsRecurring,
                AppointmentSchema.IsMeeting,
                AppointmentSchema.RequiredAttendees,
                AppointmentSchema.OptionalAttendees,
                AppointmentSchema.Resources,

                AppointmentSchema.HasAttachments,
                AppointmentSchema.Importance,

                AppointmentSchema.Attachments,
                AppointmentSchema.ConferenceType,
                                 
                AppointmentSchema.AppointmentType,
                AppointmentSchema.AppointmentState,
                AppointmentSchema.AppointmentSequenceNumber,
                AppointmentSchema.Categories,
                                   
                AppointmentSchema.DateTimeCreated,
                AppointmentSchema.DateTimeReceived,
                AppointmentSchema.DateTimeSent,
                AppointmentSchema.ICalUid,
                AppointmentSchema.ICalRecurrenceId,
                AppointmentSchema.ICalDateTimeStamp,
                AppointmentSchema.IsMeeting,
                AppointmentSchema.IsDraft,
                                  
                AppointmentSchema.IsCancelled,
                AppointmentSchema.IsFromMe,
                AppointmentSchema.IsOnlineMeeting,
                AppointmentSchema.IsReminderSet,
                AppointmentSchema.IsResend,
                AppointmentSchema.IsResponseRequested,
                AppointmentSchema.IsSubmitted,
                AppointmentSchema.IsUnmodified,
                AppointmentSchema.ItemClass,
                AppointmentSchema.LastModifiedName,
                AppointmentSchema.LastModifiedTime,
                AppointmentSchema.LastOccurrence,
                AppointmentSchema.LegacyFreeBusyStatus,
                AppointmentSchema.MeetingRequestWasSent,
                AppointmentSchema.MeetingWorkspaceUrl,
                AppointmentSchema.MimeContent,
                AppointmentSchema.ModifiedOccurrences,
                AppointmentSchema.NetShowUrl,
                AppointmentSchema.OriginalStart,
                AppointmentSchema.ParentFolderId,
                AppointmentSchema.Recurrence,
                AppointmentSchema.ReminderDueBy,
                AppointmentSchema.ReminderMinutesBeforeStart,
                AppointmentSchema.Resources,
                AppointmentSchema.Sensitivity,
                AppointmentSchema.Size,
                AppointmentSchema.StartTimeZone,
                AppointmentSchema.TimeZone 
                );
            }

            Appointment oAppointment = Appointment.Bind(oExchangeService, oItemId) as Appointment;


            oAppointment.Load(oPropertySet);

            return oAppointment;
        }

        private TimeZoneInfo GetTzIdFromControl(string s)
        {
            string sTzId = string.Empty;
            char[] cTzSep  = {'|'};
            string[] arrTzId;
            TimeZoneInfo oTimeZoneInfo;

            arrTzId = s.Split(cTzSep);
            sTzId = arrTzId[1].Trim();
            oTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(sTzId);
            return oTimeZoneInfo;
        }

        private void SetAppointmentFromForm()
        {
            //oAppointment.AppointmentType = txtAppointmentType.Text;
            //oAppointment.Organizer.Name = txtOrganizer.Text;
            _Appointment.Subject = txtSubject.Text;
            _Appointment.Location = txtLocation.Text;
            //_Appointment.Importance = cmboImportance.Text;

            DateTime oStartTime = new DateTime(
                dtDurationStartDate.Value.Year,
                dtDurationStartDate.Value.Month,
                dtDurationStartDate.Value.Day,
                dtDurationStartTime.Value.Hour,
                dtDurationStartTime.Value.Minute,
                dtDurationStartTime.Value.Second);

            DateTime oEndTime = new DateTime(
                dtDurationEndDate.Value.Year,
                dtDurationEndDate.Value.Month,
                dtDurationEndDate.Value.Day,
                dtDurationEndTime.Value.Hour,
                dtDurationEndTime.Value.Minute,
                dtDurationEndTime.Value.Second);

            _Appointment.Start = oStartTime;
            _Appointment.End = oEndTime;

   
            _Appointment.StartTimeZone = TimeHelper.GetTzIdFromTimeZoneStringUsedByComboBoxes(this.cmboDurationStartTimezone.Text);
            
            //if (_ExchangeService.ServerInfo.VersionString.StartsWith("Exchange2010") == true ||
            //    _ExchangeService.ServerInfo.VersionString.StartsWith("Exchange2013") == true ||
            //    _ExchangeService.ServerInfo.VersionString.StartsWith("V2_") == true)

            if (_ExchangeService.ServerInfo.VersionString.CompareTo("Exchange2010") >= 0)
            {   // 2010 and above
                _Appointment.EndTimeZone = TimeHelper.GetTzIdFromTimeZoneStringUsedByComboBoxes(this.cmboDurationEndTimezone.Text);
      
            }
  
            if (cmboBodyType.Text == "HTML")
                _Appointment.Body = new MessageBody(BodyType.HTML, this.txtBody.Text);
            else
                _Appointment.Body = new MessageBody(BodyType.Text, this.txtBody.Text);
 
            _Appointment.IsAllDayEvent = chkIsAllDayEvent.Checked;

            //_Appointment.LegacyFreeBusyStatus = AppointmentHelper.GetFreeBusyStatus( cmboLegacyFreeBusyStatus.Text);
            _Appointment.LegacyFreeBusyStatus = (LegacyFreeBusyStatus)Enum.Parse(typeof(LegacyFreeBusyStatus), cmboLegacyFreeBusyStatus.Text.Trim());
            //_Appointment.Importance = AppointmentHelper.GetImportance(cmboImportance.Text);
            _Appointment.Importance = (Importance)Enum.Parse(typeof(Importance), cmboImportance.Text.Trim());
             
            RecipeintHelper.SetAppointmentRecipientsFromString(ref _Appointment, "Required", txtRequiredAttendees.Text.Trim());
            RecipeintHelper.SetAppointmentRecipientsFromString(ref _Appointment, "Optional", txtOptionalAttendees.Text.Trim());
            RecipeintHelper.SetAppointmentRecipientsFromString(ref _Appointment, "Resource", txtResourceAttendees.Text.Trim());


            if (chkIsRecurring.Checked == true)
            {
                 //http://msdn.microsoft.com/en-us/library/dd633694(EXCHG.80).aspx
                if (this.rdoDaily.Checked == true)
                {
                     
                    //if (chkRecurrDailyEveryDays.Checked == true)
                    //{
                        int iInterval = Int32.Parse(cmboRecurrDailyEveryDays.Text.Trim());
                        _Appointment.Recurrence = new Recurrence.DailyPattern(dtStartingDateRange.Value.Date, iInterval);
                        _Appointment.Recurrence.StartDate = dtStartingDateRange.Value.Date;

 
                    //}
		 
                    //if (chkRecurrDailyEveryDays.Checked == true)
                    //{
                    //    DayOfTheWeek[] arrDayOfTheWeek = new DayOfTheWeek[iDaysOfWeekChecked];
                    //    //_Appointment.Recurrence = new Recurrence.DailyPattern(dtRecurrStartTime.Value.Date, 7);
                    //}
                }

                if (this.rdoWeekly.Checked == true)
                {
                    //cmboRecurrWeeklyEveryWeeks
                    int iRecurrWeeklyEveryWeeks = 1;
                    int iDaysOfWeekChecked = DaysOfWeekChecked();
                    iRecurrWeeklyEveryWeeks = Int32.Parse(cmboRecurrWeeklyEveryWeeks.Text.Trim());

                    DayOfTheWeek[] arrDayOfTheWeek = new DayOfTheWeek[iDaysOfWeekChecked];
                    int iCount = 0;
                    if (chkRecurrWeeklySunday.Checked == true)
                    {
                        arrDayOfTheWeek[iCount] = DayOfTheWeek.Sunday;
                        iCount++;
                    }
                    if (chkRecurrWeeklyMonday.Checked == true)
                    {
                        arrDayOfTheWeek[iCount] = DayOfTheWeek.Monday;
                        iCount++;
                    }
                    if (chkRecurrWeeklyTuesday.Checked == true)
                    {
                        arrDayOfTheWeek[iCount] = DayOfTheWeek.Tuesday;
                        iCount++;
                    }
                    if (chkRecurrWeeklyWednesday.Checked == true)
                    {
                        arrDayOfTheWeek[iCount] = DayOfTheWeek.Wednesday;
                        iCount++;
                    }
                    if (chkRecurrWeeklyThursday.Checked == true)
                    {
                        arrDayOfTheWeek[iCount] = DayOfTheWeek.Thursday;
                        iCount++;
                    }
                    if (chkRecurrWeeklyFriday.Checked == true)
                    {
                        arrDayOfTheWeek[iCount] = DayOfTheWeek.Friday;
                        iCount++;
                    }
                    if (chkRecurrWeeklySaturday.Checked == true)
                    {
                        arrDayOfTheWeek[iCount] = DayOfTheWeek.Saturday;
                        iCount++;
                    }
 

                    _Appointment.Recurrence = new Recurrence.WeeklyPattern(dtRecurrStartTime.Value.Date, iRecurrWeeklyEveryWeeks, arrDayOfTheWeek);
                    
                }
                if (this.rdoMonthly.Checked == true)
                {
                    if (rdoRecurrMonthlyPattern.Checked == true)
                    {

  
                        _Appointment.Recurrence = new Recurrence.MonthlyPattern(
                            dtRecurrStartTime.Value.Date,
                            Int32.Parse(cmboRecurrMonthlyPatternDayOfMonth.Text.Trim()),
                            Int32.Parse(cmboRecurrMonthlyPatternEveryMonths.Text.Trim()) 

                            );
                    }

                    if (rdoRecurrRelativeMonthyPattern.Checked == true)
                    {
                        DayOfTheWeek oDayOfTheWeek = DayOfTheWeek.Sunday;
                        DayOfTheWeekIndex oDayOfTheWeekIndex = DayOfTheWeekIndex.First;

                        //oDayOfTheWeek = AppointmentHelper.GetDayOfWeekFromString(cmboRecurrDayOfWeek.Text.Trim());
                        oDayOfTheWeek = (DayOfTheWeek)Enum.Parse(typeof(DayOfTheWeek), cmboRecurrDayOfWeek.Text.Trim());

                        //string sItem = Enum.GetName(typeof(DayOfTheWeek), DayOfTheWeek.Monday); // String for name
                        //string = Enum.GetName(typeof(DayOfTheWeek), 3));  // Third Instnace
                        //oDayOfTheWeek = (DayOfTheWeek)Enum.Parse(typeof(DayOfTheWeek), "Monday"); // Convert from string to enumerated value

 
                        //oDayOfTheWeekIndex = AppointmentHelper.GetDayOfTheWeekIndexString(cmboRecurrDayOfTheWeekIndex.Text.Trim());
                         oDayOfTheWeekIndex = (DayOfTheWeekIndex)Enum.Parse(typeof(DayOfTheWeekIndex), cmboRecurrDayOfTheWeekIndex.Text.Trim());

                        _Appointment.Recurrence = new Recurrence.RelativeMonthlyPattern(
                                dtRecurrStartTime.Value.Date,
                                Int32.Parse(cmboRecurrInterval.Text.Trim()),
                                oDayOfTheWeek,
                                oDayOfTheWeekIndex
                                );
                    }
 
                }
                if (this.rdoYearly.Checked == true)
                {

                    //int iRecurrYearlyYears = Int32.Parse(cmboxRecurrYearlyYears.Text.Trim());
                   
 
                    if (rdoRecurrYearlyOnSpecificDay.Checked == true)
                    {
                        Month oMonth = Month.January;
                         
                        //oMonth = AppointmentHelper.GetMonthFromMonthString(cmboRecurrYearlyOnSpecificDayMonth.Text.Trim());
                        oMonth = (Month)Enum.Parse(typeof(Month), cmboRecurrYearlyOnSpecificDayForMonthOf.Text.Trim());

                        _Appointment.Recurrence = new Recurrence.YearlyPattern(
                            dtRecurrStartTime.Value.Date,
                            oMonth,
                            Int32.Parse(cmboRecurrYearlyOnSpecificDay.Text.Trim())
                            );
                        //_Appointment.Recurrence.NumberOfOccurrences = iRecurrYearlyYears;
                    }

                     
                    if (rdoRelativeYearlyPattern.Checked == true)
                    {
                         
                        Month oMonth = Month.January;
                        //oMonth = AppointmentHelper.GetMonthFromMonthString(cmboRecurrYearlyOnDayPatternMonth.Text.Trim());
                        oMonth = (Month)Enum.Parse(typeof(Month), cmboRecurrYearlyOnDayPatternMonth.Text.Trim());

                        DayOfTheWeekIndex oDayOfTheWeekIndex = DayOfTheWeekIndex.First;
                        oDayOfTheWeekIndex = (DayOfTheWeekIndex)Enum.Parse(typeof(DayOfTheWeekIndex), cmboRecurrYearlyOnDayPatternDayOfWeekIndex.Text.Trim());
                        //oDayOfTheWeekIndex = AppointmentHelper.GetDayOfTheWeekIndexString(cmboRecurrYearlyOnDayPatternDayOfWeekIndex.Text.Trim());
                      
                        //DayOfTheWeek oDayOfTheWeek = AppointmentHelper.GetDayOfWeekFromString(cmboRecurrYearlyOnDayPatternDayOfWeek.Text.Trim());
                        DayOfTheWeek oDayOfTheWeek = DayOfTheWeek.Monday;
                        oDayOfTheWeek = (DayOfTheWeek)Enum.Parse(typeof(DayOfTheWeek), cmboRecurrYearlyOnDayPatternDayOfWeek.Text.Trim());
  
                        _Appointment.Recurrence = new Recurrence.RelativeYearlyPattern(
                            dtRecurrStartTime.Value.Date,
                            oMonth,
                            oDayOfTheWeek,
                            oDayOfTheWeekIndex 
                            );

                            //_Appointment.Recurrence.NumberOfOccurrences = iRecurrYearlyYears;
                    }
 

                }
        
                // Range:
                 
                _Appointment.Recurrence.StartDate = dtStartingDateRange.Value.Date;
                if (this.rdoRangeNoEnd.Checked == false)
                {
                    if (this.rdoRangeEndAfterNumberOccurrences.Checked == true)
                    {
                        _Appointment.Recurrence.NumberOfOccurrences = Int32.Parse(this.txtRangeNumberOccurrences.Text.Trim());
                    }
                    if (rdoRangeEndByDate.Checked == true)
                    {
                        _Appointment.Recurrence.EndDate = this.dtRangeEndByDate.Value.Date;
                    }
                }
                else
                {
                    _Appointment.Recurrence.NeverEnds();
                }

            }
        }

 
        private bool CheckForm()
        {
            int iTest = 0;
            bool bNoErrors = true;
            bool result = false;

            if (this.txtSubject.Text.Trim().Length == 0)
            {
                MessageBox.Show("Subject Needs to be set", "Entry Error");
                bNoErrors = false;
            }

            if (this.txtLocation.Text.Trim().Length == 0)
            {
                MessageBox.Show("Location Needs to be set", "Entry Error");
                bNoErrors = false;
            }

            if (this.txtBody.Text.Trim().Length == 0)
            {
                MessageBox.Show("Body Needs to be set", "Entry Error");
                bNoErrors = false;
            }

            if (rdoDaily.Checked == true)
            {
                //if (chkRecurrDailyEveryDays.Checked == true)
                //{
                    result = Int32.TryParse(cmboRecurrDailyEveryDays.Text.Trim(), out iTest);
                    if (result == false)
                    {
                        MessageBox.Show("cmboRecurrDailyEveryDays is not set to an integer value", "Entry Error");
                        bNoErrors = false;
                    }
                //}
            }

            if (chkIsRecurring.Checked == true)
            {

                // Weekly Recurrence:
                if (rdoWeekly.Checked == true)
                {
                    result = Int32.TryParse(cmboRecurrWeeklyEveryWeeks.Text.Trim(), out iTest);
                    if (result == false)
                    {
                        MessageBox.Show("cmboRecurrWeeklyEveryWeeks is not set to an integer value", "Entry Error");
                        bNoErrors = false;
                    }
                }



                // Yearly Recurrence:
                if (rdoYearly.Checked == true)
                {
                    if (rdoRecurrYearlyOnSpecificDay.Checked == true)
                    {
                        //result = Int32.TryParse(cmboRecurrYearlyOnSpecificDayMonth.Text.Trim(), out iTest);
                        //if (result == false)
                        //{
                        //    MessageBox.Show("cmboRecurrYearlyOnSpecificDayMonth is not set to an integer value", "Entry Error");
                        //    bNoErrors = false;
                        //}

                        result = Int32.TryParse(cmboRecurrYearlyOnSpecificDay.Text.Trim(), out iTest);
                        if (result == false)
                        {
                            MessageBox.Show("RecurrYearlyOnSpecificDay is not set to an integer value", "Entry Error");
                            bNoErrors = false;
                        }

                    }

                    if (rdoRelativeYearlyPattern.Checked == true)
                    {
                        result = Int32.TryParse(cmboRecurrInterval.Text.Trim(), out iTest);
                        if (result == false)
                        {
                            MessageBox.Show("Recurrence Interval is not set to an integer value", "Entry Error");
                            bNoErrors = false;
                        }
                    }
                }

                if (rdoRangeEndAfterNumberOccurrences.Checked == true)
                {
                    result = Int32.TryParse(this.txtRangeNumberOccurrences.Text.Trim(), out iTest);
                    if (result == false)
                    {
                        MessageBox.Show("txtRangeNumberOccurrences is not set to an integer value", "Entry Error");
                        bNoErrors = false;
                    }
                }

                if (rdoRangeEndAfterNumberOccurrences.Checked == true)
                {

                }

                if (rdoRangeNoEnd.Checked == false && rdoRangeNoEnd.Checked == false && rdoRangeNoEnd.Checked == false)
                {
                    MessageBox.Show("Need to specify Range Ending", "Entry Error");
                    bNoErrors = false;
                }
            }

            return bNoErrors;
        }

        private int DaysOfWeekChecked()
        {
            int iDOW = 0;
            if (chkRecurrWeeklySunday.Checked == true) iDOW++;
	        if (chkRecurrWeeklySunday.Checked == true) iDOW++;
	        if (chkRecurrWeeklyMonday.Checked == true) iDOW++;
	        if (chkRecurrWeeklyTuesday.Checked == true) iDOW++;
	        if (chkRecurrWeeklyWednesday.Checked == true) iDOW++;
	        if (chkRecurrWeeklyThursday.Checked == true) iDOW++;
	        if (chkRecurrWeeklyFriday.Checked == true) iDOW++;
	        if (chkRecurrWeeklySaturday.Checked == true) iDOW++;
            return iDOW;
        }

        private void ClearForm()
        {

            // Master defaults ---------------------------------------
            //DateTime oDateTime = DateTime.Now;

            txtAppointmentType.Text = string.Empty;
            txtOrganizer.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtLocation.Text = string.Empty;
            DateTime oBaseTime = DateTime.Now;
            DateTime oDefaultTime = new DateTime(oBaseTime.Year, oBaseTime.Month, oBaseTime.Day, oBaseTime.Hour, 0,0);


            this.dtDurationStartDate.Value = oDefaultTime;
            this.dtDurationStartTime.Value = oDefaultTime;
            this.dtDurationEndDate.Value = oDefaultTime.AddMinutes(30);
            this.dtDurationEndTime.Value = oDefaultTime.AddMinutes(30);

            //http://msdn.microsoft.com/en-us/library/dd633707(EXCHG.80).aspx
            this.cmboDurationStartTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(TimeZoneInfo.Local);
            this.cmboDurationEndTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(TimeZoneInfo.Local);

            this.cmboRecurrStartTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(TimeZoneInfo.Local);
            this.cmboRecurrEndTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(TimeZoneInfo.Local);

            txtBody.Text = string.Empty;
            cmboBodyType.Text = "Text";

            chkIsAllDayEvent.Checked = false;
            chkIsRecurring.Checked = false;

            ComboBoxHelper.AddEnumsToComboBox(ref cmboLegacyFreeBusyStatus, typeof(LegacyFreeBusyStatus));
            cmboLegacyFreeBusyStatus.Text = "OOF";
            ComboBoxHelper.AddEnumsToComboBox(ref cmboImportance, typeof(Importance));
            cmboImportance.Text = "Normal";
              
 
            // Daily defaults ------------------------------------------------
            rdoDaily.Checked = true;
            cmboRecurrDailyEveryDays.Text = "1";

            // Weekly Defaults ------------------------------------------------
            cmboRecurrWeeklyEveryWeeks.Text = "1";
            chkRecurrWeeklySunday.Checked = false;
            chkRecurrWeeklyMonday.Checked = false;
            chkRecurrWeeklyTuesday.Checked = false;
            chkRecurrWeeklyWednesday.Checked = false;
            chkRecurrWeeklyThursday.Checked = false;
            chkRecurrWeeklyFriday.Checked = false;
            chkRecurrWeeklySaturday.Checked = false;

            // Monthly Defaults ---------------------------------------
            rdoRecurrMonthlyPattern.Enabled = false;
            rdoRecurrMonthlyPattern.Checked = true;  // Default for Monthly
            rdoRecurrRelativeMonthyPattern.Enabled = false;
            cmboRecurrMonthlyPatternDayOfMonth.Text = DateTime.Now.Day.ToString();
            cmboRecurrMonthlyPatternDayOfMonth.Text = "1";
            cmboRecurrMonthlyPatternEveryMonths.Text = "1";
            cmboRecurrInterval.Text = "1";
            cmboRecurrDayOfWeek.Text = DateTime.Now.DayOfWeek.ToString();
            cmboRecurrDayOfTheWeekIndex.Text = "First";
            

            // Yearly Defaults ---------------------------------------
 

            rdoRecurrYearlyOnSpecificDay.Checked = true;  // Default for Yearly
            rdoRecurrYearlyOnSpecificDay.Enabled = false;
            cmboRecurrYearlyOnSpecificDayForMonthOf.Text = "January";
            cmboRecurrYearlyOnSpecificDay.Text = "1";
                
            rdoRelativeYearlyPattern.Checked = false; 
            rdoRelativeYearlyPattern.Enabled = false;
            cmboRecurrYearlyOnDayPatternDayOfWeekIndex.Text = "1";
            cmboRecurrYearlyOnDayPatternDayOfWeek.Text = DateTime.Now.DayOfWeek.ToString();
            cmboRecurrYearlyOnDayPatternMonth.Text =  "January";

             
 

            // Range Defaults --------------------------------------------
            dtStartingDateRange.Value = dtRecurrStartTime.Value;

            rdoRangeNoEnd.Checked = true;  // Default
            rdoRangeEndAfterNumberOccurrences.Checked = false;
            rdoRangeEndByDate.Checked = false;
            
            txtRangeNumberOccurrences.Enabled = false;
            txtRangeNumberOccurrences.Text = "10";
            dtRangeEndByDate.Enabled = false;
            dtRangeEndByDate.Text = dtDurationEndDate.Value.Date.ToString();

 

            CheckRdoRecurringTypeEnablement();
                        
        }

        private void NewAppointment()
        {
            ClearForm();
            _Appointment = new Appointment(_ExchangeService);
            _isDirty = true;
            _IsExistingAppointment = false;

            DateTime oBaseTime = DateTime.Now;
            DateTime oDefaultTime = new DateTime(oBaseTime.Year, oBaseTime.Month, oBaseTime.Day, oBaseTime.Hour, 0, 0);
 
            DateTime oDateTimeStart = oDefaultTime;
            DateTime oDateTimeEnd = oDefaultTime.AddMinutes(30);
            //oDateTimeStart = DateTime.Now;
            //oDateTimeEnd = oDateTimeStart.AddMinutes(30);

            TimeZoneInfo oTimeZoneInfo;
            oTimeZoneInfo = TimeZoneInfo.Local; 

            this.dtDurationStartDate.Value = oDateTimeStart;
            this.dtDurationStartTime.Value = oDateTimeStart;
            this.dtDurationEndDate.Value = oDateTimeEnd;
            this.dtDurationEndTime.Value = oDateTimeEnd;
            this.cmboDurationStartTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(oTimeZoneInfo);
            this.cmboDurationEndTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(oTimeZoneInfo);

            chkIsAllDayEvent.Checked = false;
            chkIsRecurring.Checked = false;

            cmboLegacyFreeBusyStatus.Text = "OOF";
            cmboImportance.Text = "Normal";

            rdoDaily.Checked = true;

             
            //chkRecurrDailyEveryDays.Checked = true;
            cmboRecurrDailyEveryDays.Text = "1";
            //chkRecurrDailyEveryWeek.Checked = false;

            rdoRangeNoEnd.Checked = true;
            rdoRangeEndAfterNumberOccurrences.Checked = false;
            txtRangeNumberOccurrences.Enabled = false;
            rdoRangeEndByDate.Checked = false;
            dtRangeEndByDate.Enabled = false;

            dtRecurrStartTime.Value = dtDurationStartDate.Value;
            dtRecurrEndTime.Value = dtDurationEndDate.Value;
            dtStartingDateRange.Value = dtRecurrStartTime.Value;

            grpRecurring.Enabled = false;

            CheckRdoRecurringTypeEnablement();
        }

        private bool SetFormFromAppointment(Appointment oAppointment)
        {
            bool bRet = false;
            ClearForm();
            txtAppointmentType.Text = oAppointment.AppointmentType.ToString();
            txtOrganizer.Text = oAppointment.Organizer.Name;
            txtSubject.Text = oAppointment.Subject;
            txtLocation.Text = oAppointment.Location;

            this.dtDurationStartDate.Value = oAppointment.Start;
            this.dtDurationStartTime.Value = oAppointment.Start;
            this.dtDurationEndDate.Value = oAppointment.End;
            this.dtDurationEndTime.Value = oAppointment.End;    //this.dtDurationEndTime.Value = oAppointment.End;

            if (oAppointment.StartTimeZone == null)  // could it ever be not null and be OK???
                oAppointment.StartTimeZone = TimeZoneInfo.Local;
            this.cmboDurationStartTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(oAppointment.StartTimeZone);

            if (_ExchangeService.ServerInfo.VersionString.CompareTo("Exchange2010") >= 0)
              {   // 2010 and above
            //if (_ExchangeService.ServerInfo.VersionString.StartsWith("Exchange2010") == true ||
            //    _ExchangeService.ServerInfo.VersionString.StartsWith("Exchange2013") == true ||
            //    _ExchangeService.ServerInfo.VersionString.StartsWith("V2") == true)
            //{   // 2010 and above
                if (oAppointment.EndTimeZone == null)  // could it ever be not null and be OK???
                    oAppointment.EndTimeZone = TimeZoneInfo.Local;
                this.cmboDurationEndTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(oAppointment.EndTimeZone);
                this.cmboDurationEndTimezone.Visible = true;
                this.lblDurationEndTimezone.Visible = true;
            }
            else
            {
                this.cmboDurationEndTimezone.Visible = false;
                this.lblDurationEndTimezone.Visible = false;
            }

         
            //this.cmboImportance.Text =   oAppointment.Importance;
            if (oAppointment.Body.BodyType == BodyType.HTML)
                cmboBodyType.Text = "HTML";
            else
                cmboBodyType.Text = "Text";
            txtBody.Text = oAppointment.Body.Text;
            chkIsAllDayEvent.Checked = oAppointment.IsAllDayEvent;
            chkIsRecurring.Checked = oAppointment.IsRecurring;

            //cmboLegacyFreeBusyStatus.Text = AppointmentHelper.GetFreeBusyStatus(oAppointment.LegacyFreeBusyStatus);
            cmboLegacyFreeBusyStatus.Text = Enum.GetName(typeof(LegacyFreeBusyStatus), oAppointment.LegacyFreeBusyStatus); // String for name

            //cmboImportance.Text = AppointmentHelper.GetImportance(oAppointment.Importance);
            cmboImportance.Text = Enum.GetName(typeof(Importance), oAppointment.Importance); // String for name


            if (oAppointment.IsMeeting)
            {
                foreach (Attendee oAttendee in oAppointment.RequiredAttendees)
                {
                    this.txtRequiredAttendees.Text += oAttendee.Address + "; ";
                }

                foreach (Attendee oAttendee in oAppointment.OptionalAttendees)
                {
                    this.txtOptionalAttendees.Text += oAttendee.Address + "; ";
                }
                foreach (Attendee oAttendee in oAppointment.Resources)
                {
                    this.txtResourceAttendees.Text += oAttendee.Address + "; ";
                }
            }

            grpRecurring.Enabled = false;
            chkIsRecurring.Checked = false;
            if (oAppointment.Recurrence != null)
            {

                chkIsRecurring.Checked = true;
                grpRecurring.Enabled = true;

                 dtStartingDateRange.Value  = _Appointment.Recurrence.StartDate;
                dtRecurrStartTime.Value = _Appointment.Recurrence.StartDate;
                if (_Appointment.Recurrence.EndDate.HasValue)
                    dtRecurrEndTime.Value = _Appointment.Recurrence.EndDate.Value;
                else
                    dtRecurrEndTime.Value = _Appointment.Recurrence.StartDate;

                if (oAppointment.Recurrence is Recurrence.DailyPattern)
                {
                    rdoDaily.Checked = true;
                    Recurrence.DailyPattern o = (Recurrence.DailyPattern)_Appointment.Recurrence;


                    cmboRecurrDailyEveryDays.Text = o.Interval.ToString();
                    //if (o.NumberOfOccurrences.HasValue)
                    //{
                        //chkRecurrDailyEveryDays.Checked = true;
                        //chkRecurrDailyEveryWeek.Checked = false;
                    //    cmboRecurrDailyEveryDays.Text = o.NumberOfOccurrences.ToString();
                    //}
                    //else
                    //{
                    //    //chkRecurrDailyEveryDays.Checked = true;
                    //    //chkRecurrDailyEveryWeek.Checked = false;
                    //    cmboRecurrDailyEveryDays.Text = "1";
                    //}

                    o = null; 
                }

                if (oAppointment.Recurrence is Recurrence.WeeklyPattern)
                {
                    rdoWeekly.Checked = true;
                    Recurrence.WeeklyPattern o = (Recurrence.WeeklyPattern)oAppointment.Recurrence;
                    
                    
                    cmboRecurrWeeklyEveryWeeks.Text = o.Interval.ToString();

                    foreach (DayOfTheWeek dotw in o.DaysOfTheWeek)
                    {
                        switch(dotw)
                        {
                            case DayOfTheWeek.Sunday:
                                chkRecurrWeeklySunday.Checked = true;
                                break;
                            case DayOfTheWeek.Monday:
                                chkRecurrWeeklyMonday.Checked = true;
                                break;
                            case DayOfTheWeek.Tuesday:
                                chkRecurrWeeklyTuesday.Checked = true;
                                break;
                            case DayOfTheWeek.Wednesday:
                                chkRecurrWeeklyWednesday.Checked = true;
                                break;
                            case DayOfTheWeek.Thursday:
                                chkRecurrWeeklyThursday.Checked = true;
                                break;
                            case DayOfTheWeek.Friday:
                                chkRecurrWeeklyFriday.Checked = true;
                                break;
                            case DayOfTheWeek.Saturday:
                                chkRecurrWeeklySaturday.Checked = true;
                                break;
                            default:
                                break;
                        }
                    }
                    o = null; 
      
                }

               if (oAppointment.Recurrence is Recurrence.MonthlyPattern)
               {
                   rdoMonthly.Checked = true;
                   rdoRecurrMonthlyPattern.Checked = true;
                   Recurrence.MonthlyPattern o = (Recurrence.MonthlyPattern)oAppointment.Recurrence;
                   cmboRecurrMonthlyPatternDayOfMonth.Text = o.DayOfMonth.ToString();
                   cmboRecurrMonthlyPatternEveryMonths.Text = o.Interval.ToString();

   
               }

                if (oAppointment.Recurrence is Recurrence.RelativeMonthlyPattern)
                {
                    rdoMonthly.Checked = true;
                    rdoRecurrRelativeMonthyPattern.Checked = true;
                     
                    Recurrence.RelativeMonthlyPattern o = (Recurrence.RelativeMonthlyPattern)oAppointment.Recurrence;
  
                    cmboRecurrDayOfTheWeekIndex.Text = o.DayOfTheWeekIndex.ToString();
                    cmboRecurrDayOfWeek.Text = o.DayOfTheWeek.ToString();
                    cmboRecurrInterval.Text = o.Interval.ToString();
                     
                }

                if (oAppointment.Recurrence is Recurrence.YearlyPattern)
                {
                    rdoYearly.Checked = true;
                    rdoRecurrYearlyOnSpecificDay.Checked = true;
                    Recurrence.YearlyPattern o = (Recurrence.YearlyPattern)oAppointment.Recurrence;

                    cmboRecurrYearlyOnSpecificDay.Text = o.DayOfMonth.ToString();
                   
                    //cmboRecurrYearlyOnSpecificDayForMonthOf.Text = o.Month.ToString();
                    cmboRecurrYearlyOnSpecificDayForMonthOf.Text = Enum.GetName(typeof(Month), o.Month);

                    //cmboRecurrMonthlyPatternDayOfMonth.Text = o.Month.ToString();
 

                    o = null;
                }

                if (oAppointment.Recurrence is Recurrence.RelativeYearlyPattern)
                {
                    rdoYearly.Checked = true;
                    rdoRelativeYearlyPattern.Checked = true;

                    Recurrence.RelativeYearlyPattern o = (Recurrence.RelativeYearlyPattern)oAppointment.Recurrence;
                    //cmboRecurrYearlyOnSpecificDayForMonthOf.Text = o.Month.ToString();
 
                    cmboRecurrYearlyOnDayPatternDayOfWeekIndex.Text = o.DayOfTheWeekIndex.ToString();
                    cmboRecurrYearlyOnDayPatternDayOfWeekIndex.Text = Enum.GetName(typeof(DayOfTheWeekIndex), o.DayOfTheWeekIndex);
                    //cmboRecurrYearlyOnDayPatternDayOfWeek.Text = o.DayOfTheWeek.ToString();
                    cmboRecurrYearlyOnDayPatternDayOfWeek.Text = Enum.GetName(typeof(DayOfTheWeek), o.DayOfTheWeek);
                    //cmboRecurrYearlyOnDayPatternMonth.Text = o.Month.ToString();
                    cmboRecurrYearlyOnDayPatternMonth.Text = Enum.GetName(typeof(Month), o.Month);
                     
                    o = null;
                }
  
                // Range
                if (_Appointment.Recurrence.HasEnd == true)
                {
                    rdoRangeNoEnd.Checked = true;
                    txtRangeNumberOccurrences.Text = "0";
                    this.dtRangeEndByDate.Value = DateTime.Now;
                }
                else
                {

                    if (oAppointment.Recurrence.NumberOfOccurrences.HasValue )
                    {
                        rdoRangeEndAfterNumberOccurrences.Checked = true;
                        txtRangeNumberOccurrences.Text = oAppointment.Recurrence.NumberOfOccurrences.ToString();
                        this.dtRangeEndByDate.Value = DateTime.Now;
                    }
                    else
                    {
                        txtRangeNumberOccurrences.Text = "0";
                        if (_Appointment.Recurrence.EndDate.HasValue )
                        {
                            this.dtRangeEndByDate.Value  = _Appointment.Recurrence.EndDate.Value;
                        }
                    }
                }

                SetRecurrenceFieldsEnablement();


            }

            txtICalUid.Text = _Appointment.ICalUid;
            txtItemId.Text = _Appointment.Id.UniqueId;
            txtChangeKey.Text = _Appointment.Id.ChangeKey;
            
            //txtConversationId.Text = _Appointment.ConversationId.ToString();

            return bRet;
        }

        private void SetRecurrenceFieldsEnablement()
        {
          
 
        }


        private void SetButtonState()
        {

            //if (_IsExistingAppointment == true)
            //{
            //    btnDelete.Enabled = true;
            //}
            //else
            //{
            //    btnDelete.Enabled = false;
            //}

            if (_isDirty == true)
            {
                btnSend.Enabled = true;
                btnSave.Enabled = true;
            }
            else
            {
                btnSend.Enabled = true;
                btnSave.Enabled = true;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveSend(false) == true)
            {
                this.Close();
            }
        }

        private bool SaveSend(bool bSend)
        {
            bool bRet = false;

            if (CheckForm() == true)
            {
                if (_IsExistingAppointment == false)
                {
                    //_Appointment = new Appointment(_EwsCaller.ExchService);
                    //NewAppointment();

                }
                SetAppointmentFromForm();
                try
                {

                    if (_isDirty)
                    {
                        if (_IsExistingAppointment == true)
                        {
                            if (bSend == true)
                            {
                                SelectSendMeetingNotificationOptions oForm = new SelectSendMeetingNotificationOptions();
                                oForm.ShowDialog();
                                if (oForm.ChoseOK == true)
                                {
                                     
                          
                                    _Appointment.Update(ConflictResolutionMode.AlwaysOverwrite, oForm.SelectedSendInvitationsOrCancellationsMode);
                                    _WasSaved = true;
                                    _WasSent = true;
                                    bRet = true;
                                }

                                oForm = null; 
                                ////_Appointment.Save(SendInvitationsMode.SendToAllAndSaveCopy);
                                //_Appointment.Update(ConflictResolutionMode.AutoResolve, SendInvitationsOrCancellationsMode.SendToAllAndSaveCopy);
                                //_WasSaved = true;
                                //_WasSent = true;
                                //bRet = true;
                            }
                            else
                            {
                                //_Appointment.Save();
                                _Appointment.Update(ConflictResolutionMode.AutoResolve);
                                _WasSaved = true;
                                bRet = true;
                            }

                        }  
                        else
                        {       // New item.
                            if (bSend == true)
                            {
                                SelectSendNewMeetingNotificationOptions oForm = new SelectSendNewMeetingNotificationOptions();
                                oForm.ShowDialog();
                                if (oForm.ChoseOK == true)
                                {
                                    _Appointment.Save(_FolderId, oForm.SelectedSendInvitationsMode);
                                    _WasSaved = true;
                                    _WasSent = true;
                                    bRet = true;
                                }
                            }
                            else
                            {
                                _Appointment.Save(_FolderId);
                                _WasSaved = true;
                                bRet = true;
                            }
                        }
                        //_IsExistingAppointment = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            return bRet;
        }

        private void txtRequiredAttendees_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void cmboDurationStartTimezone_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void cmboDurationEndTimezone_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void dtDurationStartDate_ValueChanged(object sender, EventArgs e)
        {
            _isDirty = true;
            dtStartingDateRange.Value = dtRecurrStartTime.Value.Date;  // Set default in case they set recurring starting range  
        }

        private void dtDurationEndDate_ValueChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void cmboRecurrStartTimezon_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void cmboRecurrEndTimezon_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void dtDurationStartTime_ValueChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void cmboImportance_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtOptionalAttendees_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtResourceAttendees_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtBody_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void chkIsAllDayEvent_CheckedChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtAppointmentType_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtRecurrStartTime_ValueChanged(object sender, EventArgs e)
        {
            _isDirty = true;

             
 
        }

        private void rdoDaily_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDaily.Checked == true)
            {
                this.rdoWeekly.Checked = false;
                this.rdoMonthly.Checked = false;
                this.rdoYearly.Checked = false;
            }

            CheckRdoRecurringTypeEnablement();
        }

        private void CheckRdoRecurringTypeEnablement()
        {
 

            _isDirty = true;
            

            

            // Daily
            //chkRecurrDailyEveryDays.Enabled = this.rdoDaily.Checked;
            cmboRecurrDailyEveryDays.Enabled = this.rdoDaily.Checked;
            //chkRecurrDailyEveryWeek.Enabled = this.rdoDaily.Checked;

            // Weekly
            cmboRecurrWeeklyEveryWeeks.Enabled = this.rdoWeekly.Checked;
            chkRecurrWeeklySunday.Enabled = this.rdoWeekly.Checked;
            chkRecurrWeeklyMonday.Enabled = this.rdoWeekly.Checked;
            chkRecurrWeeklyTuesday.Enabled = this.rdoWeekly.Checked;
            chkRecurrWeeklyWednesday.Enabled = this.rdoWeekly.Checked;
            chkRecurrWeeklyThursday.Enabled = this.rdoWeekly.Checked;
            chkRecurrWeeklyFriday.Enabled = this.rdoWeekly.Checked;
            chkRecurrWeeklySaturday.Enabled = this.rdoWeekly.Checked;

            // Monthly
            CheckRdoRecurringTypeMonthlyEnablement();

            // Yearly
            CheckRdoRecurringTypeYearlyEnablement();
        }

        private void CheckRdoRecurringTypeYearlyEnablement()
        {
            if (rdoYearly.Checked == true)
            {
                 

                if (rdoRecurrYearlyOnSpecificDay.Checked == true)
                {
                    rdoRelativeYearlyPattern.Checked = false;
                }

                if (rdoRelativeYearlyPattern.Checked == true)
                {
                    rdoRecurrYearlyOnSpecificDay.Checked = false;
                }

                rdoRecurrYearlyOnSpecificDay.Enabled = true;
                rdoRelativeYearlyPattern.Enabled = true;

                this.cmboRecurrYearlyOnSpecificDayForMonthOf.Enabled = this.rdoRecurrYearlyOnSpecificDay.Checked;
                this.cmboRecurrYearlyOnSpecificDayForMonthOf.Enabled = this.rdoRecurrMonthlyPattern.Checked;

                this.cmboRecurrYearlyOnDayPatternDayOfWeekIndex.Enabled = this.rdoRelativeYearlyPattern.Checked;
                this.cmboRecurrYearlyOnDayPatternDayOfWeek.Enabled = this.rdoRelativeYearlyPattern.Checked;
                this.cmboRecurrYearlyOnDayPatternMonth.Enabled = this.rdoRelativeYearlyPattern.Checked;
            }
            else
            {
                rdoRecurrYearlyOnSpecificDay.Enabled = false;
                rdoRelativeYearlyPattern.Enabled = false;

              
                rdoRecurrYearlyOnSpecificDay.Enabled = false;
                rdoRelativeYearlyPattern.Checked = false;
                this.cmboRecurrYearlyOnSpecificDayForMonthOf.Enabled = false;
                this.cmboRecurrYearlyOnSpecificDayForMonthOf.Enabled = false;

                this.cmboRecurrYearlyOnDayPatternDayOfWeekIndex.Enabled = false;
                this.cmboRecurrYearlyOnDayPatternDayOfWeek.Enabled = false;
                this.cmboRecurrYearlyOnDayPatternMonth.Enabled = false;
            }
        }
        private void CheckRdoRecurringTypeMonthlyEnablement()
        {
            if (rdoMonthly.Checked == true)
            {
                 
                if (rdoRecurrMonthlyPattern.Checked == true)
                {
                    rdoRecurrRelativeMonthyPattern.Checked = false;
                }

                if (rdoRecurrRelativeMonthyPattern.Checked == true)
                {
                    rdoRecurrMonthlyPattern.Checked = false;
                }

                rdoRecurrMonthlyPattern.Enabled = true;
                rdoRecurrRelativeMonthyPattern.Enabled = true;
 
                this.cmboRecurrMonthlyPatternDayOfMonth.Enabled = this.rdoRecurrMonthlyPattern.Checked;
                this.cmboRecurrMonthlyPatternEveryMonths.Enabled = this.rdoRecurrMonthlyPattern.Checked;

                this.cmboRecurrInterval.Enabled = this.rdoRecurrRelativeMonthyPattern.Checked;
                this.cmboRecurrDayOfWeek.Enabled = this.rdoRecurrRelativeMonthyPattern.Checked;
                this.cmboRecurrDayOfTheWeekIndex.Enabled = this.rdoRecurrRelativeMonthyPattern.Checked;
            }
            else
            {
                rdoRecurrMonthlyPattern.Enabled = false;
                rdoRecurrRelativeMonthyPattern.Enabled = false;

                this.cmboRecurrMonthlyPatternDayOfMonth.Enabled = false;
                this.cmboRecurrMonthlyPatternEveryMonths.Enabled = false;

                this.cmboRecurrInterval.Enabled = false;
                this.cmboRecurrDayOfWeek.Enabled = false;
                this.cmboRecurrDayOfTheWeekIndex.Enabled = false;
            }
        }
        private void rdoWeekly_CheckedChanged(object sender, EventArgs e)
        {
            _isDirty = true;
            if (rdoWeekly.Checked == true)
            {
                this.rdoDaily.Checked = false;
                this.rdoMonthly.Checked = false;
                this.rdoYearly.Checked = false;
            }
            CheckRdoRecurringTypeEnablement();
        }


        private void rdoMonthly_CheckedChanged(object sender, EventArgs e)
        {
            _isDirty = true;
            if (rdoMonthly.Checked == true)
            {
                this.rdoDaily.Checked = false;
                this.rdoWeekly.Checked = false;
                this.rdoYearly.Checked = false;

                //rdoRecurrMonthlyPattern.Enabled = true;
                //rdoRecurrRelativeMonthyPattern.Enabled = true;
            }
            else
            {
                //rdoRecurrMonthlyPattern.Enabled = false;
                //rdoRecurrRelativeMonthyPattern.Enabled = false;
            }
            CheckRdoRecurringTypeEnablement();
        }

        private void rdoRangeNoEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRangeNoEnd.Checked == true)
            {
                rdoRangeEndAfterNumberOccurrences.Checked = false;
                rdoRangeEndByDate.Checked = false;

                txtRangeNumberOccurrences.Enabled = false;
                dtRangeEndByDate.Enabled = false;
            }
        }

        private void rdoRangeEndAfterNumberOccurrences_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRangeEndAfterNumberOccurrences.Checked == true)
            {
                rdoRangeNoEnd.Checked = false;
                rdoRangeEndByDate.Checked = false;

                txtRangeNumberOccurrences.Enabled = true;
                dtRangeEndByDate.Enabled = false;
            }
        }

        private void rdoRangeEndByDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRangeEndByDate.Checked == true)
            {
                rdoRangeNoEnd.Checked = false;
                rdoRangeEndAfterNumberOccurrences.Checked = false;

                txtRangeNumberOccurrences.Enabled = false;
                dtRangeEndByDate.Enabled = true;
               
            }
        }

        private void rdoRecurrYearlyOnSpecificDay_CheckedChanged(object sender, EventArgs e)
        {
            _isDirty = true;
            SetYearlyRdoEnablement();
        }

        private void chkIsRecurring_CheckedChanged(object sender, EventArgs e)
        {
            grpRecurring.Enabled = chkIsRecurring.Checked;

            if (chkIsRecurring.Checked == true)
            {
                //dtStartingDateRange.Value = dtDurationStartDate.Value;

            }
            else
            {
                //rdoDaily.Enabled = false;
                //rdoWeekly.Enabled = false;
                //rdoMonthly.Enabled = false;
                //rdoYearly.Enabled = false; 
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rdoYearly_CheckedChanged(object sender, EventArgs e)
        {
            _isDirty = true;
            if (rdoYearly.Checked == true)
            {
                this.rdoDaily.Checked = false;
                this.rdoWeekly.Checked = false;
                this.rdoMonthly.Checked = false;
            }

            CheckRdoRecurringTypeEnablement();
        }

        private void rdoRecurrYearlyOnDayPattern_CheckedChanged(object sender, EventArgs e)
        {
            _isDirty = true;
            SetYearlyRdoEnablement();
        }

        private void cmboRecurrYearlyOnSpecificDayMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void cmboRecurrYearlyOnDayPatternWeekNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void cmboRecurrYearlyOnSpecificDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void cmboRecurrYearlyOnDayPatternDayOfWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void cmboRecurrYearlyOnDayPatternMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void rdoRecurrMonthlyPattern_CheckedChanged(object sender, EventArgs e)
        {
            CheckRdoRecurringTypeMonthlyEnablement();
        }

        private void rdoRecurrRelativeMonthyPattern_CheckedChanged(object sender, EventArgs e)
        {
            CheckRdoRecurringTypeMonthlyEnablement();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (SaveSend(true) == true)
            {
                this.Close();
            }
        }

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if (_IsExistingAppointment == false)
        //    {
        //        _WasDeleted = true;
        //        this.Close();
        //    }
        //    else
        //    {
        //        _Appointment.Delete(DeleteMode.MoveToDeletedItems, SendCancellationsMode.SendToAllAndSaveCopy);
        //        _WasDeleted = true;
        //        this.Close();
        //    }
        //}

        private void grpSchedule_Enter(object sender, EventArgs e)
        {

        }

        private void chkRecurrDailyEveryDays_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkRecurrDailyEveryDays.Checked == true)
            //{
            //    cmboRecurrDailyEveryDays.Enabled = true;
            //    chkRecurrDailyEveryWeek.Checked = false;
            //}
            //else
            //{
            //    cmboRecurrDailyEveryDays.Enabled = false;
            //    chkRecurrDailyEveryWeek.Checked = true;
            //}
        }

        //private void chkRecurrDailyEveryWeek_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkRecurrDailyEveryDays.Checked == true)
        //    {

        //    }
        //    else
        //    {

        //    }
        //}

        private void dtRangeEndByDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtRangeNumberOccurrences_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdoDaily_EnabledChanged(object sender, EventArgs e)
        {
            int iNothing = 0;
            iNothing = iNothing+ 0;
        }

        private void cmboRecurrDailyEveryDays_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtStartingDateRange_ValueChanged(object sender, EventArgs e)
        {
            dtRecurrStartTime.Value  = dtStartingDateRange.Value ;
        }

        private void btnAttendeeStatus_Click(object sender, EventArgs e)
        {
            string s = AppointmentHelper.GetAttendeeStatusAsInfoString(_Appointment);

            ShowTextDocument oForm = new ShowTextDocument();
            oForm.Text = "Attendee Status";
            oForm.txtEntry.Text = s;
            oForm.ShowDialog();
            oForm = null;
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void grpMonthly_Enter(object sender, EventArgs e)
        {

        }

        private void cmboxRecurrYearlyYears_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmboRecurrMonthlyPatternEveryMonths_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAttachments_Click(object sender, EventArgs e)
        {
            if (_isDirty == true)
            {
                //DialogResult oDlg = MessageBox.Show("Save?", "Item needs to be saved before working with attachments.", MessageBoxButtons.OKCancel);
                //if (oDlg == System.Windows.Forms.DialogResult.OK)
                //{ 
                    Item oItem = (Item)_Appointment;
                    AddRemoveAttachments oAddRemoveAttachments = new AddRemoveAttachments(ref oItem, _IsExistingAppointment);
                    oAddRemoveAttachments.ShowDialog();
                //}
            }
 
        }

        private void dtDurationEndTime_ValueChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }
    }
}
