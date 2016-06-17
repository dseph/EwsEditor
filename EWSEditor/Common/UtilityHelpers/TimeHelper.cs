using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace EWSEditor.Common
{
 
    public class TimeHelper
    {
        // -----------------------------------------------------------------------
        // ThisHourNow
        // -----------------------------------------------------------------------
        public static DateTime ThisHourNow()
        {
            return ThisHour(DateTime.Now);
        }

        // ---------------------------------------------------------------------------------------
        // ThisHour
        // Returns a datetime for the DateTime passed to it, but with zeroed time information.
        //// ---------------------------------------------------------------------------------------
        public static DateTime ThisHour(DateTime oDateTime)
        {
            DateTime oNewDateTime = new DateTime(
                    oDateTime.Year,
                    oDateTime.Month,
                    oDateTime.Day,
                    oDateTime.Hour,
                    0,
                    0
                    );

            return oNewDateTime;
        }

        // ------------------------------------------------------------------------------------
        // ThisHour
        // Returns a datetime for the DateTime passed to it whcih will be set to tomorrow's date
        // and  with zeroed time information.
        // ------------------------------------------------------------------------------------
        public static DateTime ThisHourTomorrow(DateTime oDateTime)
        {
            DateTime oNewDateTime = new DateTime(
                    oDateTime.Year,
                    oDateTime.Month,
                    oDateTime.Day,
                    oDateTime.Hour,
                    0,
                    0
                    );

            oNewDateTime = oNewDateTime.AddDays(1);

            return oNewDateTime;
        }

        // -------------------------------------------------------------------------------
        // GetDateFromDateTimePickers
        // Combines the selected date and selected time from two DateTimePicker controls
        // -------------------------------------------------------------------------------
        public static DateTime GetDateFromDateTimePickers(DateTimePicker oDate, DateTimePicker oTime)
        {
            DateTime oDateTime = new DateTime(
                 oDate.Value.Year,
                 oDate.Value.Month,
                 oDate.Value.Day,
                 oTime.Value.Hour,
                 oTime.Value.Minute,
                 oTime.Value.Second);

            return oDateTime;
        }

        // -----------------------------------------------------------------------
        // GetFirstDayOfMonth
        // -----------------------------------------------------------------------
        public static int GetFirstDayOfMonth(int iMonth, int iYear)
        {
            DateTime oDateTime = new DateTime(
                    iYear,
                    iMonth,
                    1
                    );

            return oDateTime.Day;
        }

        // -----------------------------------------------------------------------
        // GetLastDayOfMonth
        // -----------------------------------------------------------------------
        public static int GetLastDayOfMonth(int iMonth, int iYear)
        {
            DateTime oDateTime = new DateTime(
                    iYear,
                    iMonth,
                    DateTime.DaysInMonth(iYear, iMonth)
                    );

            return oDateTime.Day;
        }

        // -----------------------------------------------------------------------
        // GetDateForFirstDayOfMonth
        // -----------------------------------------------------------------------
        public static DateTime GetDateForFirstDayOfMonth(DateTime oDateTime)
        {
            DateTime dtFirstDayOfMonth = new DateTime(
                    oDateTime.Year,
                    oDateTime.Month,
                    1
                    );

            return dtFirstDayOfMonth;
        }

        // -----------------------------------------------------------------------
        // GetDateForLastDayOfMonth
        // -----------------------------------------------------------------------
        public static DateTime GetDateForLastDayOfMonth(DateTime oDateTime)
        {
            DateTime oLastDateInMonth = new DateTime(
                    oDateTime.Year,
                    oDateTime.Month,
                    DateTime.DaysInMonth(oDateTime.Year, oDateTime.Month)
                    );

            return oLastDateInMonth;
        }


        // -----------------------------------------------------------------------
        // GetFirstDOW
        // Returns a the first day of the week for a given date. 
        // In this routine, Sunday is considered to be the first day of the 
        // However, the day considered to be the first day of the week may vary depending
        // upon culture. Cultural specific coding is not covered in this sample
        // -----------------------------------------------------------------------
        public static DateTime GetFirstDOW(DateTime dtDate)
        {
            DateTime FirstDayofWeek = dtDate;

           //CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek
            switch (dtDate.DayOfWeek)            
            {
                case DayOfWeek.Sunday:
                    FirstDayofWeek = dtDate;
                    break;
                case DayOfWeek.Monday:
                    FirstDayofWeek = dtDate.AddDays(-1);
                    break;
                case DayOfWeek.Tuesday:
                    FirstDayofWeek = dtDate.AddDays(-2);
                    break;
                case DayOfWeek.Wednesday:
                    FirstDayofWeek = dtDate.AddDays(-3);
                    break;
                case DayOfWeek.Thursday:
                    FirstDayofWeek = dtDate.AddDays(-4);
                    break;
                case DayOfWeek.Friday:
                    FirstDayofWeek = dtDate.AddDays(-5);
                    break;
                case DayOfWeek.Saturday:
                    FirstDayofWeek = dtDate.AddDays(-6);
                    break;

            }
            return FirstDayofWeek;

        }



        // -----------------------------------------------------------------------
        // GetLastDOW
        // Returns a the last day of the week for a given date. 
        // In this routine, Sunday is considered to be the last day of the 
        // However, the day considered to be the last day of the week may vary depending
        // upon culture. Cultural specific coding is not covered in this sample.
        // -----------------------------------------------------------------------
        public static DateTime GetLastDOW(DateTime dtDate)
        {
            DateTime LastDayofWeek = dtDate;
            //CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek
            switch (dtDate.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    LastDayofWeek = dtDate.AddDays(6);
                    break;
                case DayOfWeek.Monday:
                    LastDayofWeek = dtDate.AddDays(5);
                    break;
                case DayOfWeek.Tuesday:
                    LastDayofWeek = dtDate.AddDays(4);
                    break;
                case DayOfWeek.Wednesday:
                    LastDayofWeek = dtDate.AddDays(3);
                    break;
                case DayOfWeek.Thursday:
                    LastDayofWeek = dtDate.AddDays(2);
                    break;
                case DayOfWeek.Friday:
                    LastDayofWeek = dtDate.AddDays(1);
                    break;
                case DayOfWeek.Saturday:
                    LastDayofWeek = dtDate;
                    break;
            }

            return LastDayofWeek;

        }

 

        // -----------------------------------------------------------------------
        // NowMashup
        // Creates a string of the date seperated by "x" characters.
        // Its useful if you want a datetime type guid string.
        // -----------------------------------------------------------------------
        public static string NowMashup( )
        {
            string sRet = string.Empty;
            DateTime oDateTime = DateTime.Now;

            sRet = string.Format("{0}x{1}x{2}x{3}x{4}x{5}x{6}", oDateTime.Day, oDateTime.Month, oDateTime.Year, oDateTime.Hour, oDateTime.Minute, oDateTime.Second, oDateTime.Millisecond);
            return sRet;
        }

        // ---------------------------------------------------------------------------------------
        // GetTimezoneStringForCombobox
        // Note: This methods functionality is tied to GetTzIdFromTimeZoneStringUsedByComboBoxes
        // ---------------------------------------------------------------------------------------
        public static string GetTimezoneStringForCombobox(TimeZoneInfo oTimeZoneInfo)
        {
            string sString = string.Empty;
            sString = oTimeZoneInfo.DisplayName + " | " + oTimeZoneInfo.Id + " | " + oTimeZoneInfo.BaseUtcOffset.ToString();
            return sString;
        }

        // ---------------------------------------------------------------------------------------
        // GetTzIdFromTimeZoneStringUsedByComboBoxes
        // Note: This methods functionality is tied to GetTimezoneStringForCombobox
        // ---------------------------------------------------------------------------------------
        public static TimeZoneInfo GetTzIdFromTimeZoneStringUsedByComboBoxes(string s)
        {
            string sTzId = string.Empty;
            char[] cTzSep = { '|' };
            string[] arrTzId;
            TimeZoneInfo oTimeZoneInfo;

            arrTzId = s.Split(cTzSep);
            sTzId = arrTzId[1].Trim();  // get the timezone ID.
            oTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(sTzId);
            return oTimeZoneInfo;
        }

        // ---------------------------------------------------------------------------------------
        // StartTimeOfDate
        // This returns a DateTime which represents the first minute of the DateTime passed as 
        // a parmameter.
        // This can be used to get a starting date used for the starting date in the selection
        // range for the MonthCalendar control.
        // ---------------------------------------------------------------------------------------
        public static DateTime StartTimeOfDate(DateTime oBasedUponDateTime)
        {
            DateTime oNewDateTime = new DateTime(oBasedUponDateTime.Year, oBasedUponDateTime.Month, oBasedUponDateTime.Day, 0, 0, 0, DateTimeKind.Local);
            return oNewDateTime;
        }

        // ---------------------------------------------------------------------------------------
        // EndTimeOfDate
        // This returns a DateTime which represents the last minute of the DateTime passed as 
        // a parmameter.
        // This can be used to get and ending date used for the starting date in the selection
        // range for the MonthCalendar control.
        // ---------------------------------------------------------------------------------------
        public static DateTime EndTimeOfDate(DateTime oBasedUponDateTime)
        {
            DateTime oNewDateTime = new DateTime(oBasedUponDateTime.Year, oBasedUponDateTime.Month, oBasedUponDateTime.Day, 23, 59, 59, DateTimeKind.Local);
            return oNewDateTime;
        }

        // ---------------------------------------------------------------------------------------
        // EndTimeOfDate
        // This returns a DateTime for the first minute of today.
        // ---------------------------------------------------------------------------------------
        public static DateTime StartTimeOfToday()
        {
            return StartTimeOfDate(DateTime.Now);
        }

        // ---------------------------------------------------------------------------------------
        // EndTimeOfDate
        // This returns a DateTime for the last minute of today.
        // ---------------------------------------------------------------------------------------
        public static DateTime EndTimeOfToday()
        {
            return EndTimeOfDate(DateTime.Now);
        }

        public static string GetValuesFromTimezoneStringAndDateTime(string sTimeZone, DateTime oDateTime)
        {
            TimeZoneInfo oTimeZoneInfo = null;
            oTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(sTimeZone);
            return GetValuesFromTimezoneStringAndDateTime(oTimeZoneInfo, oDateTime);
        }

        public static string GetDateTimeInfo(DateTime oDateTime)
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




        public static string GetValuesFromTimezoneStringAndDateTime(TimeZoneInfo oTimeZoneInfo, DateTime oDateTime)
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
            oSB.AppendLine("    IsDaylightSavingTime: " + oTimeZoneInfo.IsDaylightSavingTime(oDateTime).ToString());
            oSB.AppendLine("    IsAmbiguousTime: " + oTimeZoneInfo.IsAmbiguousTime(oDateTime).ToString());
            if (oTimeZoneInfo.IsAmbiguousTime(oDateTime) == true)
            {
                DateTime oDT = TimeZoneInfo.ConvertTime(oDateTime, oTimeZoneInfo);
                oSB.AppendLine(ResolveAmbiguousTime(oDateTime, oTimeZoneInfo));
            }


            oSB.AppendLine("    IsInvalidTime: " + oTimeZoneInfo.IsInvalidTime(oDateTime).ToString());
            //if (oTimeZoneInfo.IsInvalidTime(oDateTime) == true)
            //{
            //    oSB.AppendLine(GetPossibleUtcTimes(oTimeZoneInfo, oDateTime));
            //}

            oSB.AppendLine("    ToSerializedString: " + oTimeZoneInfo.ToSerializedString());
            oSB.AppendLine(" ");

            oSB.AppendLine(GetAdjustmentRules(oTimeZoneInfo));

            //oSB.AppendLine("  AdjustmentRules:");
            //foreach (TimeZoneInfo.AdjustmentRule ars in oTimeZoneInfo.GetAdjustmentRules())
            //{
            //    oSB.AppendLine("    Adjustment Rule:   DateStart: " + ars.DateStart.ToString()  + "   DateEnd: " + ars.DateEnd.ToString());
            //    oSB.AppendLine("        DaylightTransitionStart: ");
            //    oSB.AppendLine("            Month: " + ars.DaylightTransitionStart.Month.ToString());
            //    oSB.AppendLine("            Day: " + ars.DaylightTransitionStart.Day.ToString());
            //    oSB.AppendLine("            DayOfWeek: " + ars.DaylightTransitionStart.DayOfWeek.ToString());
            //    oSB.AppendLine("            TimeOfDay: " + ars.DaylightTransitionStart.TimeOfDay.ToString());
            //    oSB.AppendLine("            Week: " + ars.DaylightTransitionStart.Week.ToString());
            //    oSB.AppendLine("            IsFixedDateRule: " + ars.DaylightTransitionStart.IsFixedDateRule.ToString());
            //    oSB.AppendLine("        DaylightTransitionEnd: ");
            //    oSB.AppendLine("            Month: " + ars.DaylightTransitionEnd.Month.ToString());
            //    oSB.AppendLine("            Day: " + ars.DaylightTransitionEnd.Day.ToString());
            //    oSB.AppendLine("            DayOfWeek: " + ars.DaylightTransitionEnd.DayOfWeek.ToString());
            //    oSB.AppendLine("            TimeOfDay: " + ars.DaylightTransitionEnd.TimeOfDay.ToString());
            //    oSB.AppendLine("            Week: " + ars.DaylightTransitionEnd.Week.ToString());
            //    oSB.AppendLine("            IsFixedDateRule: " + ars.DaylightTransitionEnd.IsFixedDateRule.ToString());
            //    oSB.AppendLine("        DaylightDelta: " + ars.DaylightDelta.ToString());

            //}
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
            oSB.AppendLine("****************************");

            oSB.AppendLine("Test convert to Local ****");
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
                oSB.AppendLine("    Error trying to use TimeZoneInfo.ConvertTime to convert timezone to Local time using spedified DateTime");
                oSB.AppendLine("    " + exConvertLocal.ToString());
                oSB.AppendLine("    ****************");
                oSB.AppendLine(" ");

            }
            oSB.AppendLine("**************************");
            oSB.AppendLine(" ");

            oSB.AppendLine("****************************");
            oSB.AppendLine("Test convert to UTC");
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
                oSB.AppendLine("    ****************");
                oSB.AppendLine("    Error trying to use TimeZoneInfo.ConvertTime to convert timezone to UTC time using spedified DateTime");
                oSB.AppendLine("    " + exConvertLocal.ToString());
                oSB.AppendLine("    ****************");
                oSB.AppendLine(" ");
            }
            oSB.AppendLine("**************************");
            oSB.AppendLine(" ");

            s = oSB.ToString();

            return s;
        }

        public static string GetPossibleUtcTimes(TimeZoneInfo timeZone, DateTime ambiguousTime)
        {
            StringBuilder oSB = new StringBuilder();

            oSB.AppendLine("        Possible UTC Times for timezone:");

            // Determine if time is ambiguous in target time zone 
            if (!timeZone.IsAmbiguousTime(ambiguousTime))
            {
                oSB.AppendFormat("            {0} is not ambiguous in time zone {1}.",
                                  ambiguousTime,
                                  timeZone.DisplayName);
            }
            else
            {
                // Display time and its time zone (local, UTC, or indicated by timeZone argument) 
                string originalTimeZoneName = string.Empty; ;
                if (ambiguousTime.Kind == DateTimeKind.Utc)
                    originalTimeZoneName = "UTC";
                else if (ambiguousTime.Kind == DateTimeKind.Local)
                    originalTimeZoneName = "local time";
                else
                    originalTimeZoneName = timeZone.DisplayName;

                oSB.AppendFormat("            {0} {1} maps to the following possible times:",
                                  ambiguousTime,
                                  originalTimeZoneName);
                // Get ambiguous offsets 
                TimeSpan[] offsets = timeZone.GetAmbiguousTimeOffsets(ambiguousTime);
                // Handle times not in time zone of timeZone argument 
                // Local time where timeZone is not local zone 
                if ((ambiguousTime.Kind == DateTimeKind.Local) && !timeZone.Equals(TimeZoneInfo.Local))
                    ambiguousTime = TimeZoneInfo.ConvertTime(ambiguousTime, TimeZoneInfo.Local, timeZone);
                // UTC time where timeZone is not UTC zone    
                else if ((ambiguousTime.Kind == DateTimeKind.Utc) && !timeZone.Equals(TimeZoneInfo.Utc))
                    ambiguousTime = TimeZoneInfo.ConvertTime(ambiguousTime, TimeZoneInfo.Utc, timeZone);

                // Display each offset and its mapping to UTC 
                foreach (TimeSpan offset in offsets)
                {
                    if (offset.Equals(timeZone.BaseUtcOffset))
                        oSB.AppendFormat("                If {0} is {1}, {2} UTC", ambiguousTime, timeZone.StandardName, ambiguousTime - offset);
                    else
                        oSB.AppendFormat("                If {0} is {1}, {2} UTC", ambiguousTime, timeZone.DaylightName, ambiguousTime - offset);
                }
            }

            return oSB.ToString();
        }

        // Ambigious times happen when the time is adjusted backward - ie overlapping times from a backward DST shift.
        // See http://msdn.microsoft.com/en-us/library/bb384269(v=vs.110).aspx
        public static string ResolveAmbiguousTime(DateTime ambiguousTime, TimeZoneInfo oTimeZoneInfo)
        {
            StringBuilder oSB = new StringBuilder();

            // Time is not ambiguous.
            if (!oTimeZoneInfo.IsAmbiguousTime(ambiguousTime))
            {
                return "";
            }
            // Time is ambiguous 
            else
            {
                try
                {
                    DateTime utcTime = DateTime.SpecifyKind(ambiguousTime - TimeZoneInfo.Local.BaseUtcOffset,
                                        DateTimeKind.Utc);
                    oSB.AppendFormat("        {0} local time corresponds to {1} {2}.",
                                      ambiguousTime,
                                      utcTime,
                                      utcTime.Kind.ToString());
                }
                catch (Exception ex)
                {
                    oSB.AppendFormat("        * Error trying to calculate local time for ambigious date/time and timezone combination.");
                    oSB.AppendFormat("            {0}\r\n", ex.ToString());
                }

            }
            return oSB.ToString();
        }


        public enum WeekOfMonth
        {
            First = 1,
            Second = 2,
            Third = 3,
            Fourth = 4,
            Last = 5
        }

        public static string GetValuesFromTimeZoneInfo(TimeZoneInfo oTimeZoneInfo)
        {
            string s = string.Empty;

            StringBuilder oSB = new StringBuilder();

            try
            {

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
                oSB.AppendLine("        Minutes: " + oTimeZoneInfo.BaseUtcOffset.Minutes.ToString());
                oSB.AppendLine("        Seconds: " + oTimeZoneInfo.BaseUtcOffset.Seconds.ToString());
                oSB.AppendLine("        Milliseconds: " + oTimeZoneInfo.BaseUtcOffset.Milliseconds.ToString());
                oSB.AppendLine("        TotalDays: " + oTimeZoneInfo.BaseUtcOffset.TotalDays.ToString());
                oSB.AppendLine("        TotalHours: " + oTimeZoneInfo.BaseUtcOffset.TotalHours.ToString());
                oSB.AppendLine("        TotalMinutes: " + oTimeZoneInfo.BaseUtcOffset.TotalMinutes.ToString());
                oSB.AppendLine("        TotalSeconds: " + oTimeZoneInfo.BaseUtcOffset.TotalSeconds.ToString());
                oSB.AppendLine("        TotalMilliseconds: " + oTimeZoneInfo.BaseUtcOffset.TotalMilliseconds.ToString());
                oSB.AppendLine("        Ticks: " + oTimeZoneInfo.BaseUtcOffset.Ticks.ToString());
                oSB.AppendLine("    ToSerializedString: " + oTimeZoneInfo.ToSerializedString());

                oSB.AppendLine(" ");
                oSB.AppendLine(GetAdjustmentRules(oTimeZoneInfo));



                s = oSB.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return s;
        }

        public static string GetAdjustmentRules(TimeZoneInfo oTimeZoneInfo)
        {
            StringBuilder oSB = new StringBuilder();
          
            oSB.AppendLine("    AdjustmentRules:");
            TimeZoneInfo.AdjustmentRule[] adjustmentRules = oTimeZoneInfo.GetAdjustmentRules();
            DateTimeFormatInfo dateInfo = CultureInfo.CurrentCulture.DateTimeFormat;

            int iAdjustmentRuleCount = 0;

            foreach (TimeZoneInfo.AdjustmentRule ars in adjustmentRules)
            {
                iAdjustmentRuleCount++;

                oSB.AppendLine("        Transition Rule (" + iAdjustmentRuleCount.ToString() + "):");
                oSB.AppendLine("            DateStart: " + ars.DateStart.ToString());
                oSB.AppendLine("            DateEnd: " + ars.DateEnd.ToString());
                // http://msdn.microsoft.com/en-us/library/system.timezoneinfo.transitiontime.week(v=vs.110).aspx


                TimeZoneInfo.TransitionTime daylightStart = ars.DaylightTransitionStart;
                if (daylightStart.IsFixedDateRule)
                {
                    oSB.AppendLine("            Transition - Fixed rule - Start: ");
                    oSB.AppendLine("                IsFixedDateRule: " + daylightStart.IsFixedDateRule.ToString());
                    oSB.AppendLine("                Month: " + dateInfo.GetMonthName(daylightStart.Month));
                    oSB.AppendLine("                Day: " + daylightStart.Day.ToString());
                    oSB.AppendLine("                TimeOfDay: " + daylightStart.TimeOfDay.ToString());
                }

                if (!daylightStart.IsFixedDateRule)
                {
                    oSB.AppendLine("            Transition - Non-fixed rule - Start: ");
                    oSB.AppendLine("                IsFixedDateRule: " + daylightStart.IsFixedDateRule.ToString());
                    oSB.AppendLine("                TimeOfDay: " + daylightStart.TimeOfDay.ToString());
                    oSB.AppendLine("                WeekOfMonth: " + ((WeekOfMonth)daylightStart.Week).ToString());
                    oSB.AppendLine("                DayOfWeek: " + daylightStart.DayOfWeek.ToString());
                    oSB.AppendLine("                Month: " + dateInfo.GetMonthName(daylightStart.Month));

                }

                TimeZoneInfo.TransitionTime daylightEnd = ars.DaylightTransitionEnd;

                if (daylightEnd.IsFixedDateRule)
                {
                    oSB.AppendLine("            Transition - Fixed rule - End: ");
                    oSB.AppendLine("                IsFixedDateRule: " + daylightEnd.IsFixedDateRule.ToString());
                    oSB.AppendLine("                Month: " + dateInfo.GetMonthName(daylightEnd.Month));
                    oSB.AppendLine("                Day: " + daylightEnd.Day.ToString());
                    oSB.AppendLine("                TimeOfDay: " + daylightEnd.TimeOfDay.ToString());
                }

                if (!daylightEnd.IsFixedDateRule)
                {
                    oSB.AppendLine("            Transition - Non-fixed rule - End: ");
                    oSB.AppendLine("                IsFixedDateRule: " + daylightEnd.IsFixedDateRule.ToString());
                    oSB.AppendLine("                TimeOfDay: " + daylightEnd.TimeOfDay.ToString());
                    oSB.AppendLine("                WeekOfMonth: " + ((WeekOfMonth)daylightEnd.Week).ToString());
                    oSB.AppendLine("                DayOfWeek: " + daylightEnd.DayOfWeek.ToString());
                    oSB.AppendLine("                Month: " + dateInfo.GetMonthName(daylightEnd.Month));
                }

                oSB.AppendLine("            DaylightDelta: " + ars.DaylightDelta.ToString());
                oSB.AppendLine("                Ticks: " + ars.DaylightDelta.Ticks.ToString());
                oSB.AppendLine("                Days: " + ars.DaylightDelta.Days.ToString());
                oSB.AppendLine("                Hours: " + ars.DaylightDelta.Hours.ToString());
                oSB.AppendLine("                Minutes: " + ars.DaylightDelta.Minutes.ToString());
                oSB.AppendLine("                Seconds: " + ars.DaylightDelta.Seconds.ToString());
                oSB.AppendLine("                Miliseconds: " + ars.DaylightDelta.Milliseconds.ToString());
                oSB.AppendLine("                Ticks: " + ars.DaylightDelta.Ticks.ToString());
                oSB.AppendLine("                TotalDays: " + ars.DaylightDelta.TotalDays.ToString());
                oSB.AppendLine("                TotalHours: " + ars.DaylightDelta.TotalHours.ToString());
                oSB.AppendLine("                TotalMinutes: " + ars.DaylightDelta.TotalMinutes.ToString());
                oSB.AppendLine("                TotalSeconds: " + ars.DaylightDelta.TotalSeconds.ToString());
                oSB.AppendLine("                TotalMiliseconds: " + ars.DaylightDelta.TotalMilliseconds.ToString());

            }

            return oSB.ToString();
        }
 
    }

}
