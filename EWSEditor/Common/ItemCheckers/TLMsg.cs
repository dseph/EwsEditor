using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MeetingAnalyzer
{
    public class TLMsg
    {
        DataTable m_dt;

        public TLMsg(DataTable dt)
        {
            m_dt = dt;
        }

        public TLMsg() { }

        // Get Values for these props for use in this tool
        public string ApptAuxFlags { get { return GetProp("AppointmentAuxiliaryFlags"); } }             //dispidApptAuxFlags
        public string ApptRecurBlob { get { return GetProp("AppointmentRecurrenceBlob"); } }            //dispidApptRecur
        public string ApptRecurring { get { return GetProp("AppointmentRecurring"); } }                 //dispidApptRecurring
        public string ApptStateFlags { get { return GetProp("AppointmentState"); } }                    //dispidApptStateFlags
        public string TriggerAction { get { return GetProp("CalendarLogTriggerAction"); } }             //0x0006 Cal Asst
        public string CalProcessed { get { return GetProp("CalendarProcessed"); } }                     //0x0001 Cal Asst
        public string CleanGOID { get { return GetProp("CleanGlobalObjectId"); } }                      //0x0023
        public string ClientInfoString { get { return GetProp("ClientInfoString"); } }                  //0x000B Cal Asst
        public string ClientIntent { get { return GetProp("ClientIntent"); } }                          //0x0015 Cal Asst
        public string AttendeeCC { get { return GetProp("DisplayAttendeesCc"); } }
        public string AttendeeTo { get { return GetProp("DisplayAttendeesTo"); } }
        public string EndTime { get { return GetProp("EndTime"); } }                                    // Calculated
        public string EndWallClock { get { return GetProp("EndWallClock"); } }
        //public string EndTimeZone { get { return GetProp("EndTimeZone"); } }                            // Calculated
        public string BusyStatus { get { return GetProp("FreeBusyStatus"); } }                          //dispidBusyStatus
        public string From { get { return GetProp("From"); } }
        public string IsHijacked { get { return GetProp("HijackedMeeting"); } }                         //0x0019 Cal Asst
        public string IsAllDayEvent { get { return GetProp("IsAllDayEvent"); } }
        public string IsCancelled { get { return GetProp("IsCancelled"); } }
        public string IsException { get { return GetProp("IsException"); } }                            //PidLidIsException
        public string IsOrganizer { get { return GetProp("IsOrganizerProperty"); } }                    // Calculated
        public string IsProcessed { get { return GetProp("IsProcessed"); } }                            //PR_PROCESSED
        public string IsRecurring { get { return GetProp("IsRecurring"); } }                            //PidLidIsRecurring
        public string IsSeriesCancelled { get { return GetProp("IsSeriesCancelled"); } }                // Calculated
        public string IsSoftDeleted { get { return GetProp("IsSoftDeleted"); } }                        //0x6770000B
        public string ItemMsgClass { get { return GetProp("ItemClass"); } }                             //PR_MESSAGE_CLASS
        public string LastModTime { get { return GetProp("LastModifiedTime"); } }                       //PR_LAST_MODIFICATION_TIME
        public string Location { get { return GetProp("Location"); } }                                  //0x0002 Meet or dispidLocation
        public string ApptEndWhole { get { return GetProp("MapiEndTime"); } }                           //dispidApptEndWhole
        public string ApptStartWhole { get { return GetProp("MapiStartTime"); } }                       //dispidApptStartWhole
        public string MeetReqType { get { return GetProp("MeetingRequestType"); } }
        public string OrigLastModTime { get { return GetProp("OriginalLastModifiedTime"); } }           //0x0009 Cal Asst
        public string RcvdBy { get { return GetProp("ReceivedBy"); } }                                  //PR_ReceivedByName and PR_ReceivedByAddr
        public string RcvdRepresenting { get { return GetProp("ReceivedRepresenting"); } }              //PR_ReceivedReprName and PR_ReceievedReprAddr
        public string RecurPattern { get { return GetProp("RecurrencePattern"); } }                     //dispidRecurPattern
        public string ResponsibleUser { get { return GetProp("ResponsibleUserName"); } }                //0x000A Cal Asst
        public string SenderAddress { get { return GetProp("SenderEmailAddress"); } }                   //PR_SENDER_EMAIL_ADDRESS
        public string OrganizerName { get { return GetProp("SentRepresentingDisplayName"); } }
        public string OrganizerAddr { get { return GetProp("SentRepresentingEmailAddress"); } }         //PR_SENT_REPRESENTING_ADDRESS
        public string StartTime { get { return GetProp("StartTime"); } }                                // Calculated
        //public string StartTimeZone { get { return GetProp("StartTimeZone"); } }                        // Calculated
        public string StartWallClock { get { return GetProp("StartWallClock"); } }                      // Calculated
        public string Subject { get { return GetProp("SubjectProperty"); } }                            //PR_SUBJECT + Calculation
        public string TimeZoneDesc { get { return GetProp("TimeZone"); } }                              //dispidTimeZoneDesc
        public string ViewEndTime { get { return GetProp("ViewEndTime"); } }                            //0x0022 Cal Asst
        public string ViewStartTime { get { return GetProp("ViewStartTime"); } }                        //0x0021 Cal Asst
        public string ParentFolder { get { return GetProp("ParentDisplay"); } }                        //PR_PARENT_DISPLAY

        // Get the value for a given property
        public string GetProp(string strName, string strProp = "PropVal")
        {
            return MsgData.GetProp(m_dt, strName, strProp);
        }
    }
}