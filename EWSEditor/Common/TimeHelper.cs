using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

 
    }

}
