using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using EWSEditor.Common;
using Microsoft.Exchange.WebServices.Data;
 

namespace EWSEditor.Forms 
{
    public partial class TimeZonesForm : Form
    {
        private ExchangeService _ExchangeService = null;

        public TimeZonesForm()
        {
            InitializeComponent();
        }

        public TimeZonesForm(ExchangeService oService)
        {
            _ExchangeService = oService;
            InitializeComponent();

        }

         

        private void btnListTimezones_Click(object sender, EventArgs e)
        {
 
            try
            {
                StringBuilder sb = new StringBuilder();
                ListView oListView = lvMachineTimeZones;

                oListView.Clear();
                oListView.View = View.Details;
                oListView.GridLines = true;
                oListView.FullRowSelect = true;
                oListView.Columns.Add("Id", 150, HorizontalAlignment.Left);
                oListView.Columns.Add("DisplayName", 150, HorizontalAlignment.Left);
                oListView.Columns.Add("BaseUtcOffset", 80, HorizontalAlignment.Left);
                oListView.Columns.Add("DaylightName", 150, HorizontalAlignment.Left);
                oListView.Columns.Add("StandardName", 150, HorizontalAlignment.Left);
                oListView.Columns.Add("SupportsDaylightSavingTime", 180, HorizontalAlignment.Left);

                ListViewItem oListItem = null;

                 foreach (TimeZoneInfo tzinfo in TimeZoneInfo.GetSystemTimeZones())
                {
                     oListItem = new ListViewItem(tzinfo.Id, 0);
                    oListItem.SubItems.Add(tzinfo.DisplayName);
                    oListItem.SubItems.Add(tzinfo.BaseUtcOffset.ToString());
                    oListItem.SubItems.Add(tzinfo.DaylightName);
                    oListItem.SubItems.Add(tzinfo.StandardName);
                    oListItem.SubItems.Add(tzinfo.SupportsDaylightSavingTime.ToString());
                    // TimeZoneInfo.AdjustmentRule[] o = tzinfo.GetAdjustmentRules();

                    oListView.Items.AddRange(new ListViewItem[] { oListItem });
                    oListItem = null;
                }
 
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnServerTimeZone_Click(object sender, EventArgs e)
        {
            DateTime oDateTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);

            StringBuilder oSB = new StringBuilder();
            oSB.AppendLine("Server TimeZoneInfo:");
            oSB.AppendLine(GetValuesFromTimeZoneInfo(_ExchangeService.TimeZone));
            oSB.AppendLine("");

 
            txtServerTimezoneResults.Text = oSB.ToString();
 
        }

        private string GetValuesFromTimeZoneInfo(TimeZoneInfo oTimeZoneInfo)
        {
            string s = string.Empty;

            StringBuilder oSB = new StringBuilder();

            try{ 

                oSB.AppendLine("    Using this: " + oTimeZoneInfo.ToString());
                oSB.AppendLine("    Id: " + oTimeZoneInfo.Id);
                oSB.AppendLine("    DisplayName: " + oTimeZoneInfo.DisplayName);
                oSB.AppendLine("    StandardName: " + oTimeZoneInfo.StandardName);
                oSB.AppendLine("    DaylightName: " + oTimeZoneInfo.DaylightName);
                oSB.AppendLine("    BaseUtcOffset: " + oTimeZoneInfo.BaseUtcOffset.ToString());
                oSB.AppendLine("    SupportsDaylightSavingTime: " + oTimeZoneInfo.SupportsDaylightSavingTime.ToString());
                oSB.AppendLine("    BaseUtcOffset: " + oTimeZoneInfo.BaseUtcOffset.ToString());
                oSB.AppendLine("        Days: " + oTimeZoneInfo.BaseUtcOffset.Days.ToString());
                oSB.AppendLine("        Hours: " + oTimeZoneInfo.BaseUtcOffset.Hours.ToString());
                oSB.AppendLine("        Milliseconds: " + oTimeZoneInfo.BaseUtcOffset.Milliseconds.ToString());
                oSB.AppendLine("        Minutes: " + oTimeZoneInfo.BaseUtcOffset.Minutes.ToString());
                oSB.AppendLine("        Seconds: " + oTimeZoneInfo.BaseUtcOffset.Seconds.ToString());
                oSB.AppendLine("        Ticks: " + oTimeZoneInfo.BaseUtcOffset.Ticks.ToString());
                oSB.AppendLine("        TotalDays: " + oTimeZoneInfo.BaseUtcOffset.TotalDays.ToString());
                oSB.AppendLine("        TotalHours: " + oTimeZoneInfo.BaseUtcOffset.TotalHours.ToString());
                oSB.AppendLine("        TotalMilliseconds: " + oTimeZoneInfo.BaseUtcOffset.TotalMilliseconds.ToString());
                oSB.AppendLine("        TotalMinutes: " + oTimeZoneInfo.BaseUtcOffset.TotalMinutes.ToString());
                oSB.AppendLine("        TotalSeconds: " + oTimeZoneInfo.BaseUtcOffset.TotalSeconds.ToString());
                oSB.AppendLine("    ToSerializedString: " + oTimeZoneInfo.ToSerializedString());

                oSB.AppendLine("  AdjustmentRules:");
                foreach (TimeZoneInfo.AdjustmentRule ars in oTimeZoneInfo.GetAdjustmentRules())
                {
                    oSB.AppendLine("    DateStart: " + ars.DateStart.ToString());
                    oSB.AppendLine("    DateEnd: " + ars.DateEnd.ToString());
                    oSB.AppendLine("    DaylightTransitionStart: ");
                    oSB.AppendLine("        Month: " + ars.DaylightTransitionStart.Month.ToString());
                    oSB.AppendLine("        Day: " + ars.DaylightTransitionStart.Day.ToString());
                    oSB.AppendLine("        DayOfWeek: " + ars.DaylightTransitionStart.DayOfWeek.ToString());
                    oSB.AppendLine("        TimeOfDay: " + ars.DaylightTransitionStart.TimeOfDay.ToString());
                    oSB.AppendLine("        Week: " + ars.DaylightTransitionStart.Week.ToString());
                    oSB.AppendLine("        IsFixedDateRule: " + ars.DaylightTransitionStart.IsFixedDateRule.ToString());
                    oSB.AppendLine("    DaylightTransitionEnd: ");
                    oSB.AppendLine("        Month: " + ars.DaylightTransitionEnd.Month.ToString());
                    oSB.AppendLine("        Day: " + ars.DaylightTransitionEnd.Day.ToString());
                    oSB.AppendLine("        DayOfWeek: " + ars.DaylightTransitionEnd.DayOfWeek.ToString());
                    oSB.AppendLine("        TimeOfDay: " + ars.DaylightTransitionEnd.TimeOfDay.ToString());
                    oSB.AppendLine("        Week: " + ars.DaylightTransitionEnd.Week.ToString());
                    oSB.AppendLine("        IsFixedDateRule: " + ars.DaylightTransitionEnd.IsFixedDateRule.ToString());
                    oSB.AppendLine("    DaylightDelta: " + ars.DaylightDelta.ToString());
                }
 
                s = oSB.ToString();

             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return s;
        }

        private string GetValuesFromTimezoneStringAndDateTime(string sTimeZone, DateTime oDateTime)
        {
            TimeZoneInfo oTimeZoneInfo = null;
            oTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(sTimeZone);
            return GetValuesFromTimezoneStringAndDateTime(oTimeZoneInfo, oDateTime);
        }

        string GetDateTimeInfo(DateTime oDateTime)
        {
            StringBuilder oSB = new StringBuilder();

            oSB.AppendLine("    Date: " + oDateTime.Date.ToString());
            oSB.AppendLine("    Ticks: " + oDateTime.Ticks.ToString());
            oSB.AppendLine("    Kind: " + oDateTime.Kind.ToString());
            oSB.AppendLine("    IsDaylightSavingTime: " + oDateTime.IsDaylightSavingTime().ToString());

            oSB.AppendLine("    Month: " + oDateTime.Month.ToString());
            oSB.AppendLine("    Day: " + oDateTime.Day.ToString());
            oSB.AppendLine("    Year: " + oDateTime.Year.ToString());
            oSB.AppendLine("    DayOfYear: " + oDateTime.DayOfYear.ToString());
            oSB.AppendLine("    DayOfWeek: " + oDateTime.DayOfWeek.ToString());

            oSB.AppendLine("    TimeOfDay: " + oDateTime.TimeOfDay.ToString());
            oSB.AppendLine("    Hour: " + oDateTime.Hour.ToString());
            oSB.AppendLine("    Minute: " + oDateTime.Minute.ToString());
            oSB.AppendLine("    Second: " + oDateTime.Second.ToString());
            oSB.AppendLine("    Millisecond: " + oDateTime.Millisecond.ToString());

            oSB.AppendLine("    ToBinary: " + oDateTime.ToBinary().ToString());
            oSB.AppendLine("    ToFileTime: " + oDateTime.ToFileTime().ToString());
            oSB.AppendLine("    ToFileTimeUtc: " + oDateTime.ToFileTimeUtc().ToString());
            oSB.AppendLine("    ToLocalTime: " + oDateTime.ToLocalTime().ToString());
            oSB.AppendLine("    ToLongDateString: " + oDateTime.ToLongDateString().ToString());
            oSB.AppendLine("    ToLongTimeString: " + oDateTime.ToLongTimeString().ToString());
            oSB.AppendLine("    ToOADate: " + oDateTime.ToOADate().ToString());
            oSB.AppendLine("    ToShortDateString: " + oDateTime.ToShortDateString().ToString());
            oSB.AppendLine("    ToShortTimeString: " + oDateTime.ToShortTimeString().ToString());
            oSB.AppendLine("    ToString: " + oDateTime.ToString().ToString());
            oSB.AppendLine("    ToUniversalTime: " + oDateTime.ToUniversalTime().ToString());

            oSB.AppendLine("    TimeZoneInfo.Local.IsInvalidTime: " + TimeZoneInfo.Local.IsInvalidTime(oDateTime));
            oSB.AppendLine("    TimeZoneInfo.Local.IsAmbiguousTime: " + TimeZoneInfo.Local.IsAmbiguousTime(oDateTime));
            oSB.AppendLine("    TimeZoneInfo.Local.IsDaylightSavingTime: " + TimeZoneInfo.Local.IsDaylightSavingTime(oDateTime));

            oSB.AppendLine("    TimeZoneInfo.Utc.IsAmbiguousTime: " + TimeZoneInfo.Utc.IsAmbiguousTime(oDateTime));
            oSB.AppendLine("    TimeZoneInfo.Utc.IsDaylightSavingTime: " + TimeZoneInfo.Utc.IsDaylightSavingTime(oDateTime));
            oSB.AppendLine("    TimeZoneInfo.Utc.IsInvalidTime: " + TimeZoneInfo.Utc.IsInvalidTime(oDateTime));

            return oSB.ToString();
        }

        private string GetValuesFromTimezoneStringAndDateTime(TimeZoneInfo oTimeZoneInfo, DateTime oDateTime)
        {
            string s = string.Empty;
            StringBuilder oSB = new StringBuilder();



            oSB.AppendLine("    Using this Date: " + oDateTime.ToString());
            oSB.AppendLine("    Using this TimeZone: " + oTimeZoneInfo.ToString());
            oSB.AppendLine("    Id: " + oTimeZoneInfo.Id);
            oSB.AppendLine("    DisplayName: " + oTimeZoneInfo.DisplayName);
            oSB.AppendLine("    StandardName: " + oTimeZoneInfo.StandardName);
            oSB.AppendLine("    DaylightName: " + oTimeZoneInfo.DaylightName);
            oSB.AppendLine("    BaseUtcOffset: " + oTimeZoneInfo.BaseUtcOffset.ToString());
            oSB.AppendLine("    SupportsDaylightSavingTime: " + oTimeZoneInfo.SupportsDaylightSavingTime.ToString());
            oSB.AppendLine("    BaseUtcOffset: " + oTimeZoneInfo.BaseUtcOffset.ToString());
            oSB.AppendLine("        Days: " + oTimeZoneInfo.BaseUtcOffset.Days.ToString());
            oSB.AppendLine("        Hours: " + oTimeZoneInfo.BaseUtcOffset.Hours.ToString());
            oSB.AppendLine("        Milliseconds: " + oTimeZoneInfo.BaseUtcOffset.Milliseconds.ToString());
            oSB.AppendLine("        Minutes: " + oTimeZoneInfo.BaseUtcOffset.Minutes.ToString());
            oSB.AppendLine("        Seconds: " + oTimeZoneInfo.BaseUtcOffset.Seconds.ToString());
            oSB.AppendLine("        Ticks: " + oTimeZoneInfo.BaseUtcOffset.Ticks.ToString());
            oSB.AppendLine("        TotalDays: " + oTimeZoneInfo.BaseUtcOffset.TotalDays.ToString());
            oSB.AppendLine("        TotalHours: " + oTimeZoneInfo.BaseUtcOffset.TotalHours.ToString());
            oSB.AppendLine("        TotalMilliseconds: " + oTimeZoneInfo.BaseUtcOffset.TotalMilliseconds.ToString());
            oSB.AppendLine("        TotalMinutes: " + oTimeZoneInfo.BaseUtcOffset.TotalMinutes.ToString());
            oSB.AppendLine("        TotalSeconds: " + oTimeZoneInfo.BaseUtcOffset.TotalSeconds.ToString());
            oSB.AppendLine("    IsAmbiguousTime: " + oTimeZoneInfo.IsAmbiguousTime(oDateTime).ToString());
            oSB.AppendLine("    IsDaylightSavingTime: " + oTimeZoneInfo.IsDaylightSavingTime(oDateTime).ToString());
            oSB.AppendLine("    IsInvalidTime: " + oTimeZoneInfo.IsInvalidTime(oDateTime).ToString());
            oSB.AppendLine("    ToSerializedString: " + oTimeZoneInfo.ToSerializedString());

            oSB.AppendLine(" ");

            oSB.AppendLine("  AdjustmentRules:");
            foreach (TimeZoneInfo.AdjustmentRule ars in oTimeZoneInfo.GetAdjustmentRules())
            {
                oSB.AppendLine("    Adjustment Rule:   DateStart: " + ars.DateStart.ToString()  + "   DateEnd: " + ars.DateEnd.ToString());
                oSB.AppendLine("        DaylightTransitionStart: ");
                oSB.AppendLine("            Month: " + ars.DaylightTransitionStart.Month.ToString());
                oSB.AppendLine("            Day: " + ars.DaylightTransitionStart.Day.ToString());
                oSB.AppendLine("            DayOfWeek: " + ars.DaylightTransitionStart.DayOfWeek.ToString());
                oSB.AppendLine("            TimeOfDay: " + ars.DaylightTransitionStart.TimeOfDay.ToString());
                oSB.AppendLine("            Week: " + ars.DaylightTransitionStart.Week.ToString());
                oSB.AppendLine("            IsFixedDateRule: " + ars.DaylightTransitionStart.IsFixedDateRule.ToString());
                oSB.AppendLine("        DaylightTransitionEnd: ");
                oSB.AppendLine("            Month: " + ars.DaylightTransitionEnd.Month.ToString());
                oSB.AppendLine("            Day: " + ars.DaylightTransitionEnd.Day.ToString());
                oSB.AppendLine("            DayOfWeek: " + ars.DaylightTransitionEnd.DayOfWeek.ToString());
                oSB.AppendLine("            TimeOfDay: " + ars.DaylightTransitionEnd.TimeOfDay.ToString());
                oSB.AppendLine("            Week: " + ars.DaylightTransitionEnd.Week.ToString());
                oSB.AppendLine("            IsFixedDateRule: " + ars.DaylightTransitionEnd.IsFixedDateRule.ToString());
                oSB.AppendLine("        DaylightDelta: " + ars.DaylightDelta.ToString());
                 
            }
            oSB.AppendLine(" ");

            oSB.AppendLine("    GetAmbiguousTimeOffsets:");
            if (oTimeZoneInfo.IsAmbiguousTime(oDateTime) == false)
            {
                oSB.AppendLine("        The time is not Ambiguous for ths timezone.");
            }
            else
            {
 
                foreach (TimeSpan oTzTimeSpan in oTimeZoneInfo.GetAmbiguousTimeOffsets(oDateTime))
                {
 
                    oSB.AppendLine("    TimeSpan: " + oTzTimeSpan.ToString());
                    oSB.AppendLine("        Days: " + oTzTimeSpan.Days.ToString());
                    oSB.AppendLine("        Hours: " + oTzTimeSpan.Hours.ToString());
                    oSB.AppendLine("        Milliseconds: " + oTzTimeSpan.Milliseconds.ToString());
                    oSB.AppendLine("        Minutes: " + oTzTimeSpan.Minutes.ToString());
                    oSB.AppendLine("        Seconds: " + oTzTimeSpan.Seconds.ToString());
                    oSB.AppendLine("        Ticks: " + oTzTimeSpan.Ticks.ToString());
                    oSB.AppendLine("        TotalDays: " + oTzTimeSpan.TotalDays.ToString());
                    oSB.AppendLine("        TotalHours: " + oTzTimeSpan.TotalHours.ToString());
                    oSB.AppendLine("        TotalMilliseconds: " + oTzTimeSpan.TotalMilliseconds.ToString());
                    oSB.AppendLine("        TotalMinutes: " + oTzTimeSpan.TotalMinutes.ToString());
                    oSB.AppendLine("        TotalSeconds: " + oTzTimeSpan.TotalSeconds.ToString());
                }
            }

            oSB.AppendLine(" ");

            //// http://msdn.microsoft.com/en-us/library/bb495915(v=vs.110).aspx
            //// Convert to local time
            try
            {
                DateTime localTime = TimeZoneInfo.ConvertTime(oDateTime, oTimeZoneInfo, TimeZoneInfo.Local);
                oSB.AppendLine("    In Local: ");
                oSB.AppendLine("        DateTime: " + localTime.ToString());
                oSB.AppendLine("        IsDaylightSavingTime: " + TimeZoneInfo.Local.IsDaylightSavingTime(localTime).ToString());
                oSB.AppendLine(" ");
            }
            catch (Exception exConvertLocal)
            {
                oSB.AppendLine(" ");
                oSB.AppendLine("****************");
                oSB.AppendLine("Error trying to use TimeZoneInfo.ConvertTime to convert timezone to Local time using spedified DateTime");
                oSB.AppendLine(exConvertLocal.ToString());
                oSB.AppendLine("****************");
                oSB.AppendLine(" ");
            }

            try
            {
                // Convert to UTC
                DateTime utcTime = TimeZoneInfo.ConvertTime(oDateTime, oTimeZoneInfo, TimeZoneInfo.Utc);

                oSB.AppendLine("    In UTC - ConvertTime: ");
                oSB.AppendLine("        DateTime: " + utcTime);
                oSB.AppendLine("        IsDaylightSavingTime: " + TimeZoneInfo.Local.IsDaylightSavingTime(utcTime).ToString());
                oSB.AppendLine(" ");
            }
            catch (Exception exConvertLocal)
            {
                oSB.AppendLine(" ");
                oSB.AppendLine("****************");
                oSB.AppendLine("Error trying to use TimeZoneInfo.ConvertTime to convert timezone to UTC time using spedified DateTime");
                oSB.AppendLine(exConvertLocal.ToString());
                oSB.AppendLine("****************");
                oSB.AppendLine(" ");
            }
 
            s = oSB.ToString();
 
            return s;
        }

        private void TimeZoneByIdString_Click(object sender, EventArgs e)
        {
            string s = string.Empty;
            StringBuilder sb = new StringBuilder();

            txtTimeZoneLookupResults.Text = string.Empty;

            string sTimeZone = cmboTimeZoneIds.Text.Trim();

            if (sTimeZone.Length != 0)
            {
                try
                {

                    //oTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(cmboTimeZoneIds.Text);
                    DateTime oDateTime = TimeHelper.GetDateFromDateTimePickers(dtStartDate, dtStartTime);

                    //sb.Append("GetValuesFromTimezoneString: ");
                    //sb.Append(GetValuesFromTimezoneString(cmboTimeZoneIds.Text.Trim()));
                    //sb.Append("\r\n");
                    sb.Append("Timezone Information:" );
                    sb.Append(GetValuesFromTimezoneStringAndDateTime(cmboTimeZoneIds.Text.Trim(), oDateTime));
                    sb.Append("\r\n");

                    s = sb.ToString();
                    txtTimeZoneLookupResults.Text = s;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("A Time Zone must be selectd first.", "Error");
            }

        }

        private void TimeZonesForm_Load(object sender, EventArgs e)
        {
            try
            {
                dtStartDate.Value = new DateTime(DateTime.Now.Ticks);
                dtStartTime.Value = new DateTime(dtStartDate.Value.Ticks);

                foreach (TimeZoneInfo tzinfo in TimeZoneInfo.GetSystemTimeZones())
                {
                    cmboTimeZoneIds.Items.Add(tzinfo.Id);
                    cmboFromTimeZone.Items.Add(tzinfo.Id);
                    cmboToTimeZone.Items.Add(tzinfo.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private string GetValuesFromTimezoneString(string sTimeZone)
        {
            string s = string.Empty;

            try
            {

                //StringBuilder sb = new StringBuilder();

                TimeZoneInfo oTimeZoneInfo = null;
                oTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(sTimeZone);

                 s = GetValuesFromTimeZoneInfo(oTimeZoneInfo);

                //s = sb.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return s;
        }

        private string GetComputerTimeValues()
        {
            string s = string.Empty;

            try
            {
                 

                StringBuilder sb = new StringBuilder();
                DaylightTime oDaylightTime = null;
                TimeZone oCurrentTimeZone = TimeZone.CurrentTimeZone;

                TimeZoneInfo x = TimeZoneInfo.Local;
                  
                
                sb.Append(string.Format("\r\n"));
 
                sb.Append(string.Format("On this computer: \r\n"));
                sb.Append(string.Format("    Now:            {0} \r\n", DateTime.Now.ToString()));
                sb.Append(string.Format("    LocalTime:      {0} \r\n", DateTime.Now.ToLocalTime()));

                //sb.Append(string.Format("\r\n"));
                //sb.Append(string.Format("Local TimeZoneInfo: \r\n"));
                //sb.Append(string.Format("    Id:             {0} \r\n", x.Id));
                //sb.Append(string.Format("    StandardName:   {0} \r\n", x.StandardName));
                //sb.Append(string.Format("    DaylightName:   {0} \r\n", x.DaylightName));
                //sb.Append(string.Format("    DisplayName:    {0} \r\n", x.DisplayName));
                //sb.Append(string.Format("    DisplayName:    {0} \r\n", x.BaseUtcOffset.ToString()));
                //sb.Append(string.Format("    DisplayName:    {0} \r\n", x.SupportsDaylightSavingTime.ToString()));
 
                //sb.Append(string.Format("\r\n"));
                //sb.Append(string.Format("  TimeZone: \r\n" ));
                //sb.Append(string.Format("    DaylightName:   {0} \r\n", oCurrentTimeZone.DaylightName));
                //sb.Append(string.Format("    UniversalTime:  {0} \r\n", oCurrentTimeZone.StandardName));
 
                //sb.Append(string.Format("\r\n"));
                //sb.Append(string.Format("    Daylight Savings Time: \r\n"));
                //oDaylightTime = oCurrentTimeZone.GetDaylightChanges(DateTime.Now.Year);
                //sb.Append(string.Format("        Starts:     {0:yyyy-MM-dd HH:mm} \r\n", oDaylightTime.Start, oDaylightTime.End, oDaylightTime.Delta));
                //sb.Append(string.Format("        Ends:       {0:yyyy-MM-dd HH:mm} \r\n", oDaylightTime.End));
                //sb.Append(string.Format("        Delta:      {0} \r\n", oDaylightTime.Delta));

                sb.AppendLine("Local TimeZoneInfo:");
                sb.Append(GetValuesFromTimeZoneInfo(x));

                s = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return s;
        }

        private void dtStartTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnClientCurrentTimeZone_Click(object sender, EventArgs e)
        {
            StringBuilder oSB = new StringBuilder();
            txtClientCurrentTimezone.Text = string.Empty;

            txtClientCurrentTimezone.Text = GetComputerTimeValues();

            // GetValuesFromTimezoneString
 
        }

        private void cmboTimeZoneIds_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnConvertTimezone_Click(object sender, EventArgs e)
        {
            string s = string.Empty;
            StringBuilder sbFrom = new StringBuilder();
            StringBuilder sbTo = new StringBuilder();
            this.txtConversionResults.Text = "";

            
            this.txtFromTimeZone.Text = string.Empty;
            this.txtToTimeZone.Text = string.Empty;

            string sFromTimeZone = this.cmboFromTimeZone.Text.Trim();
            string sToTimeZone = this.cmboToTimeZone.Text.Trim();

 
            DateTime oDateTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified); 

            if (rdoConvertByDateTime.Checked == true)
            {
                oDateTime = TimeHelper.GetDateFromDateTimePickers(dtConvertStartDate, dtConvertStartTime);
            }
            if (this.rdoConvertByTicks.Checked == true)
            {
                long lTicks = 0;   // its a Int64

                string sString = this.txtTicks.Text.Trim();
                if (Int64.TryParse(sString, out lTicks))
                {
                    //iTicks = Convert.ToInt64(sString);
                    oDateTime = new DateTime(lTicks);
                }
                else
                {
                    MessageBox.Show("The Ticks value is not an int64.");
                    return;
                }
            }
            if (rdoConvertByNow.Checked == true)
            {
                DateTimeKind oDateTimeKind = DateTimeKind.Unspecified;
                switch (this.cmboConversionKind.Text)
                {
                    case "Unspecified":
                        oDateTimeKind = DateTimeKind.Unspecified;
                        break;
                    case "Utc":
                        oDateTimeKind = DateTimeKind.Utc;
                        break;
                    case "Local":
                        oDateTimeKind = DateTimeKind.Local;
                        break;
                }

                oDateTime = DateTime.SpecifyKind(DateTime.Now, oDateTimeKind); 
            }

            txtConversionDateInfo.Text = GetDateTimeInfo(oDateTime);
 
            if (sFromTimeZone.Length != 0)
            {
                try
                {

                    //oTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(cmboTimeZoneIds.Text);


                    //sbFrom.Append("GetValuesFromTimezoneString: ");
                    //sbFrom.Append(GetValuesFromTimezoneString(cmboFromTimeZone.Text.Trim()));
                    //sbFrom.Append("\r\n");
                    sbFrom.Append("Timezone Information:");
                    sbFrom.Append(GetValuesFromTimezoneStringAndDateTime(cmboFromTimeZone.Text.Trim(), oDateTime));
                    sbFrom.Append("\r\n");

                    s = sbFrom.ToString();
                    txtFromTimeZone.Text = s;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error finding From TimeZone");
                    return;
                }
            }
            else
            {
                MessageBox.Show("A From Time Zone must be selectd first.", "Error");
                return;
            }

            
        if (sToTimeZone.Length != 0)
            {
                try
                {

                    sbTo.Append("Timezone Information:");
                    sbTo.Append(GetValuesFromTimezoneStringAndDateTime(this.cmboToTimeZone.Text.Trim(), oDateTime));
                    sbTo.Append("\r\n");

                    s = sbTo.ToString();
                    txtToTimeZone.Text = s;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error finding To TimeZone");
                    return;
                }
            }
            else
            {
                MessageBox.Show("A To Time Zone must be selectd first.", "Error");
                return;
            }

            TimeZoneInfo oFromTimeZoneInfo = null;
            oFromTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(sFromTimeZone);

            TimeZoneInfo oToTimeZoneInfo = null;
            oToTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(sToTimeZone);

            try
            {

                DateTime oResultDateTime = System.TimeZoneInfo.ConvertTime(oDateTime, oFromTimeZoneInfo, oToTimeZoneInfo);

                StringBuilder oSbRestults = new StringBuilder();
                oSbRestults.AppendLine("New DateTime: " + oResultDateTime.ToString());
                oSbRestults.Append(GetDateTimeInfo(oResultDateTime));
                oSbRestults.AppendLine(" ");
 
                this.txtConversionResults.Text = oSbRestults.ToString();
            }
            catch (System.ArgumentException exSae)
            {
 
                this.txtConversionResults.Text =
                    "\r\n*********************\r\nError (ArgumentException): \r\n\r\n" + 
                    exSae.ToString() +
                    "\r\n*********************\r\n\r\n"; 

            }
            catch (TimeZoneConversionException exTz)
            {
                this.txtConversionResults.Text =
                    "\r\n*********************\r\nError (TimeZoneConversionException): \r\n\r\n" +
                    exTz.ToString() +
                    "\r\n*********************\r\n\r\n"; 

            }
            catch (Exception ex)
            {
                this.txtConversionResults.Text =
                    "\r\n*********************\r\nError (Exception): \r\n\r\n" +
                    ex.ToString() +
                    "\r\n*********************\r\n\r\n"; 
            }

 
 
            
        }
 

        private void ToTimeZone_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdoNow_CheckedChanged(object sender, EventArgs e)
        {
            SetConversionEnablement();
        }

        private void SetConversionEnablement()
        {
            if (this.rdoConvertByDateTime.Checked == true)
            {
                dtConvertStartTime.Enabled = true;
                dtConvertStartDate.Enabled = true;

                txtTicks.Enabled = false;
            }

            if (this.rdoConvertByTicks.Checked == true)
            {
                dtConvertStartTime.Enabled = false;
                dtConvertStartDate.Enabled = false;

                txtTicks.Enabled = true;
            }

            if (this.rdoConvertByNow.Checked == true)
            {
                dtConvertStartTime.Enabled = false;
                dtConvertStartDate.Enabled = false;

                txtTicks.Enabled = false;

            }

        }

        private void tabConvertTime_Click(object sender, EventArgs e)
        {
            SetConversionEnablement();
        }

        private void rdoConvertByDateTime_CheckedChanged(object sender, EventArgs e)
        {
            SetConversionEnablement();
        }

        private void rdoConvertByTicks_CheckedChanged(object sender, EventArgs e)
        {
            SetConversionEnablement();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

         

 

    }
}
