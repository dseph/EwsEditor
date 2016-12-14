using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Common.Exports;
using MeetingAnalyzer;

namespace ItemCheckers
{
    // Convert code from: https://calcheck.codeplex.com/
    // Convert code from: https://meetinganalyzer.codeplex.com/

    public class CalendarCheck
    {
        ExchangeService _ExchangeService = null;
        FolderId _FolderId = null;
        ItemId _ItemId = null;

        string _ResultsSummary = string.Empty;
        List<CalCheckResult> _Results = new List<CalCheckResult> { };

        public static RecurBlob m_rbPrevious = new RecurBlob();
        public static RecurBlob m_rbCurrent = new RecurBlob();
        public static string m_strMbx = "";
        public static bool m_bHeader = false;
        public static bool m_FirstAppt = true;
        public static int m_iMsgNum = 1;
        public static bool m_bExtMsgClass = false;
        public static bool m_bInitPropsSaved = false;
        public static string m_FromX500 = "";
        public static string m_FromSMTP = "";
        public static string m_Role = "";
        public static bool m_bAccepted = false;
        public static bool m_bFirstItem = true;
        public static int m_iNumMsgs = 0;
        public static bool m_bOLProcessedLast = false;
        public static bool m_bOLProcessedItem = false;
        public static bool m_bOrganizer = false;
        public static bool m_DelCheck = false;

        //Initial Appt Prop value members
        public static string m_strApptRecurring = "";
        public static string m_strIsRecurring = "";
        public static string m_strStartWhole = "";
        public static string m_strEndWhole = "";
        public static string m_strBusyStatus = "";
        public static string m_strApptStateFlags = "";
        public static string m_strLocation = "";
        public static string m_strOrganizerAddr = "";
        public static string m_strOrganizerName = "";
        public static string m_strSender = "";
        public static string m_strTo = "";
        public static string m_strCc = "";
        public static string m_strViewEnd = "";

        // message classes we know of that are valid for meeting/calendar items
        private static string[] rgstrMsgClasses = new string[] {
                    "IPM.Appointment",
                    "IPM.Schedule.Meeting.Request",
                    "IPM.Schedule.Meeting.Canceled",
                    "IPM.Schedule.Meeting.Resp.Pos",
                    "IPM.Schedule.Meeting.Resp.Neg",
                    "IPM.Schedule.Meeting.Resp.Tent",
                    "IPM.Schedule.Meeting.Notification.Forward",
                    "IPM.Schedule.Inquiry",                                     // Calendar Repair Agent
                    "IPM.OLE.CLASS.{00061055-0000-0000-C000-000000000046}"};    // string for a meeting exception - which shows up "sometimes"};



        /// <summary>
        ///  CheckFolder 
        ///  Check all calendar items in the mailbox
        /// </summary>
        /// <param name="oExchangeService"></param>
        //public void CheckFolder(ExchangeService oExchangeService, ref string _ResultsSummary, ref List<CalCheckResult> oResults)
        //{
        //    _Results = null;

        //}
   
        ///// <summary>
        ///// CheckFolder
        ///// Check the specific calendar folder
        ///// </summary>
        ///// <param name="oExchangeService"></param>
        ///// <param name="oFolder"></param>
        //public void CheckFolder(ExchangeService oExchangeService, FolderId oFolder, ref string _ResultsSummary, ref List<CalCheckResult> oResults)
        //{
        //    _ExchangeService = oExchangeService;
        //    _FolderId = oFolder;

        //    _Results = null;

        //}

        ///// <summary>
        ///// CheckItem
        ///// Check the specified item.
        ///// </summary>
        ///// <param name="oExchangeService"></param>
        ///// <param name="oItemId"></param>
        //public void CheckItem(ExchangeService oExchangeService, ItemId oItemId, ref string _ResultsSummary, ref List<CalCheckResult> oResults)
        //{
        //    _ExchangeService = oExchangeService;
        //    _ItemId = oItemId;

        //    _Results = null;

        //}

        public class CalCheckResult
        {
            string FolderId = string.Empty;
            string FolderName = string.Empty;
            string ItemId = string.Empty;
            string Subject = string.Empty;
            string Location = string.Empty;
            string StartTime = string.Empty;
            string EndTime = string.Empty;
            string Recurring = string.Empty;
            string Organizer = string.Empty;
            string IsPastItem = string.Empty;
            string ErrorsAndWarnings = string.Empty;
            string OtherItemId = string.Empty;
            string OtherItemSubject = string.Empty;
            string OtherItemStart = string.Empty;
            string OtherItemEnd = string.Empty;
        }


        private static string CheckCurrentItem(AppointmentData oAppointmentData)
        {
            //  SeekToConditionItemView Timeline.cs in MeetingAnalyzer
            StringBuilder oSB = new StringBuilder();

        //    // Check that the PidLidRecurring prop is there
        //    if (string.IsNullOrEmpty(oAppointmentData.IsRecurring))
        //    {
        //        oSB.AppendLine("ERROR: The Recurring property is not set on this item.");
        //    }
        //    // Check that the dispidApptRecurring prop is there
        //    if (string.IsNullOrEmpty(oAppointmentData.ApptRecurring))
        //    {
        //        oSB.AppendLine("ERROR: The Appointment Recurring property is not set on this item.");
        //    }
        //    // Check Start time
        //    if (oAppointmentData.ApptStartWhole.Contains("01/01/1601") || string.IsNullOrEmpty(msg.ApptStartWhole))
        //    {
        //        oSB.AppendLine("ERROR: The Start Date and Time property is not set on this item.");
        //    }
        //    // Check End time
        //    if (oAppointmentData.ApptEndWhole.Contains("01/01/1601") || string.IsNullOrEmpty(msg.ApptEndWhole))
        //    {
        //        oSB.AppendLine("ERROR: The End Date and Time property is not set on this item.");
        //    }
        //    // Check Organizer address
        //    if (string.IsNullOrEmpty(oAppointmentData.OrganizerAddr))
        //    {
        //        oSB.AppendLine("ERROR: Missing Organizer address on this item.");
        //    }
        //    // Check Sender address
        //    if (string.IsNullOrEmpty(oAppointmentData.SenderAddress))
        //    {
        //        oSB.AppendLine("ERROR: Missing Sender address on this item.");
        //    }
        //    // Check "IsOrganizer" with ApptStateFlags
        //    if (!(string.IsNullOrEmpty(oAppointmentData.IsOrganizer)) && !(string.IsNullOrEmpty(oAppointmentData.ApptStateFlags)))
        //    {
        //        if (oAppointmentData.IsOrganizer.ToLower() == "false")
        //        {
        //            if (oAppointmentData.ApptStateFlags == "1")
        //            {
        //                oSB.AppendLine("ERROR: This user should be an attendee, but properties indicate this user is the Organizer.");
        //            }
        //        }
        //    }
        //    // Check the new "IsHijacked" property
        //    if (!(string.IsNullOrEmpty(oAppointmentData.IsHijacked)))
        //    {
        //        if (oAppointmentData.IsHijacked.ToLower() == "true")
        //        {
        //            oSB.AppendLine("ERROR: Meeting is set as Hijacked.");
        //        }
        //    }
        //    // Check to see if this is a copied item in the calendar
        //    if (!(string.IsNullOrEmpty(oAppointmentData.ApptAuxFlags)))
        //    {
        //        string strAuxFlags = oAppointmentData.ApptAuxFlags;
        //        Utils.HandleAuxFlags(ref strAuxFlags);

        //        if (strAuxFlags.Contains("auxApptFlagCopied"))
        //        {
        //            oSB.AppendLine("This Calendar item was copied.");
        //        }
        //    }
          return oSB.ToString();
        }

        public   void CreateTimeline(ref AppointmentData[] oAppointmentDatas)
        {
            foreach (AppointmentData o in oAppointmentDatas)
            {


            }
        }


        public string CompareApptProps(TLMsg msg)
        {
            StringBuilder oSB = new StringBuilder();

            if (m_strApptRecurring.ToLower() != msg.ApptRecurring.ToLower())
            {
                if (msg.ApptRecurring.ToLower() == "true")
                {
                    Utils.Write("The item changed from a single-instance meeting to a recurring meeting.");
                }
                else if (msg.ApptRecurring.ToLower() == "false")
                {
                    Utils.Write("The item changed from a recurring meeting to a single-instance meeting.");
                }
                m_strApptRecurring = msg.ApptRecurring;
            }

            if (m_strStartWhole.ToLower() != msg.ApptStartWhole.ToLower())
            {
                Utils.Write("The start time changed from " + m_strStartWhole + " to " + msg.ApptStartWhole);
                m_strStartWhole = msg.ApptStartWhole;
            }

            if (m_strEndWhole.ToLower() != msg.ApptEndWhole.ToLower())
            {
                Utils.Write("The end time changed from " + m_strEndWhole + " to " + msg.ApptEndWhole);
                m_strEndWhole = msg.ApptEndWhole;
            }

            if (m_strViewEnd.ToLower() != msg.ViewEndTime.ToLower())
            {
                Utils.Write("The series final instance end time changed from " + m_strViewEnd + " to " + msg.ViewEndTime);
                m_strViewEnd = msg.ViewEndTime;
            }

            if (m_strOrganizerAddr.ToLower() != msg.OrganizerAddr.ToLower())
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Utils.Write("The organizer address changed. This should not happen and is potentially an error.");
                Utils.Write("    Was: " + m_strOrganizerAddr);
                Utils.Write("    Now: " + msg.OrganizerAddr);
                Console.ResetColor();
                m_strOrganizerAddr = msg.OrganizerAddr;
            }

            if (m_strTo.Length != msg.AttendeeTo.Length) // check length - Apple devices switch order of same recips on items
            {
                if (m_strTo.ToLower() != msg.AttendeeTo.ToLower())
                {
                    Utils.Write("The attendee list (To: line) changed.");
                    Utils.Write("    Was: " + m_strTo);
                    Utils.Write("    Now: " + msg.AttendeeTo);
                    m_strTo = msg.AttendeeTo;
                }
            }

            if (m_strCc.Length != msg.AttendeeCC.Length) // check length - Apple devices switch order of same recips on items
            {
                if (m_strCc.ToLower() != msg.AttendeeCC.ToLower())
                {
                    Utils.Write("The attendee list (Cc: line) changed.");
                    Utils.Write("    Was: " + m_strCc);
                    Utils.Write("    Now: " + msg.AttendeeCC);
                    m_strCc = msg.AttendeeCC;
                }
            }

            if (m_strBusyStatus != msg.BusyStatus)
            {
                string strBusyLast = m_strBusyStatus;
                string strBusyNow = msg.BusyStatus;
                Utils.HandleBusyStatus(ref strBusyLast);
                Utils.HandleBusyStatus(ref strBusyNow);

                Utils.Write("The Free Busy Status changed from " + strBusyLast + " to " + strBusyNow);

                if (msg.BusyStatus == "0")
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (m_strBusyStatus == "2")
                    {
                        Utils.Write("This previously accepted item has been declined or deleted from this user's Calendar.");
                    }
                    if (m_strBusyStatus == "1")
                    {
                        Utils.Write("The tentative item has been declined or deleted from this user's Calendar.");
                    }
                    Console.ResetColor();
                }

                m_strBusyStatus = msg.BusyStatus;
            }

            if (m_strApptStateFlags != msg.ApptStateFlags)
            {
                string strASFLast = m_strApptStateFlags;
                string strASFNow = msg.ApptStateFlags;
                Utils.HandleASF(ref strASFLast);
                Utils.HandleASF(ref strASFNow);

                Utils.Write("The Appointment State changed from " + strASFLast + " to " + strASFNow);
                m_strApptStateFlags = msg.ApptStateFlags;

                if (msg.ApptStateFlags == "1")
                {
                    if (m_strApptStateFlags == "3")
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Utils.Write("ERROR: This user was set as an attendee, and is now set as the Organizer.");
                        Console.ResetColor();
                    }
                }
            }

            if (m_strLocation.ToLower() != msg.Location.ToLower())
            {
                Utils.Write("The location of the meeting changed.");
                Utils.Write("    Was: " + m_strLocation);
                Utils.Write("    Now: " + msg.Location);
                m_strLocation = msg.Location;
            }

            return oSB.ToString();
        }

      
     
    }
}
