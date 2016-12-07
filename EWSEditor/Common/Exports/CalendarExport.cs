using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EWSEditor.Common;
using EWSEditor.Common.Extensions;
using EWSEditor.Resources;
using Microsoft.Exchange.WebServices.Data;
using System.Net;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace EWSEditor.Common.Exports
{


    public class CalendarExport
    { 
        private static ExtendedPropertyDefinition Prop_PR_FOLDER_PATH = new ExtendedPropertyDefinition(0x66B5, MapiPropertyType.String);   // Folder Path - PR_Folder_Path
        //private static ExtendedPropertyDefinition Prop_PR_FOLDER_TYPE = new ExtendedPropertyDefinition(0x3601, MapiPropertyType.Integer);  // PR_FOLDER_TYPE 0x3601 (13825)
        private static ExtendedPropertyDefinition PidLidAppointmentRecur = new ExtendedPropertyDefinition(new Guid("00062002-0000-0000-C000-000000000046"), 0x8216, MapiPropertyType.Binary); // dispidApptRecur
        private static ExtendedPropertyDefinition PidLidClientIntent = new ExtendedPropertyDefinition(new Guid("11000E07-B51B-40D6-AF21-CAA85EDAB1D0"), 0x0015, MapiPropertyType.Integer); // dispidClientIntent
        private static ExtendedPropertyDefinition ClientInfoString = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x000B, MapiPropertyType.String); //  
        private static ExtendedPropertyDefinition LogTriggerAction = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x0006, MapiPropertyType.String); //  
        private static ExtendedPropertyDefinition PidLidCleanGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0023, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PidLidGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0003, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition Prop_PR_POLICY_TAG = new ExtendedPropertyDefinition(0x301B, MapiPropertyType.Binary);  // PR_POLICY_TAG 0x3019   Data type: PtypBinary, 0x0102
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_FLAGS = new ExtendedPropertyDefinition(0x301D, MapiPropertyType.Integer);   // PR_RETENTION_FLAGS 0x301D   
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_PERIOD = new ExtendedPropertyDefinition(0x301A, MapiPropertyType.Integer);  // PR_RETENTION_PERIOD 0x301A    
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_DATE = new ExtendedPropertyDefinition(0x301C, MapiPropertyType.SystemTime); // Prop_PR_RETENTION_DATE 0x301C    
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_TAG = new ExtendedPropertyDefinition(0x3018, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_PERIOD = new ExtendedPropertyDefinition(0x301E, MapiPropertyType.Integer); // Prop_PR_RETENTION_DATE 0x301C    
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_DATE = new ExtendedPropertyDefinition(0x301F, MapiPropertyType.SystemTime);
        private static ExtendedPropertyDefinition Prop_PR_ENTRYID = new ExtendedPropertyDefinition(0x0FFF, MapiPropertyType.Binary);  // PidTagEntryId, PidTagMemberEntryId, ptagEntryId
        private static ExtendedPropertyDefinition Prop_PR_STORE_ENTRYID = new ExtendedPropertyDefinition(0x0FFB, MapiPropertyType.Binary);  // PidTagStoreEntryId
        private static ExtendedPropertyDefinition Prop_PR_IS_HIDDEN = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.Boolean);

        //public EWSEditor.Common.EwsHelpers.CalendarData CalendarAppointment;

        //public Appointment GetAppointment(ExchangeService oExchangeService, ItemId oItemId)
        //{
        //    Appointment oAppointment = Appointment.Bind(oExchangeService, oItemId, GetCalendarPropset());
        //    //CalendarData oCalendarData = new CalendarData();
        //    SetAppointmentData(oAppointment);
        //    return oAppointment;
        //}

        //public void SetAppointmentData(Appointment oAppointment)  
        //{
        //    CalendarData oCA = new CalendarData();

        //    SetAppointmentData(oAppointment, ref oCA);

        //    this.CalendarAppointment = oCA;
        //}

        public CalendarData GetAppointmentDataFromItem(ExchangeService oExchangeService, ItemId oItemId)
        {
            Appointment oAppointment = Appointment.Bind(oExchangeService, oItemId, GetCalendarPropset());
            CalendarData oCalendarData = new CalendarData();

            SetAppointmentData(oAppointment, ref oCalendarData);

            return oCalendarData;
        }
        public bool GetFolderPath(ref string sFolder)
        {
            bool bRet = false; 
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.Description = "Pick an output folder to save the XML file to.";

            if (browser.ShowDialog() == DialogResult.OK)
            {
                sFolder =  browser.SelectedPath;
                bRet = true;
            }
            else
                bRet = false;

            return bRet;
        }

        public bool SaveAppointmentToFolder(ExchangeService oExchangeService, ItemId oItemId)
        {
            bool bRet = true;
 
            List<ItemId> oItemIds = new List<ItemId> { oItemId };
            SaveAppointmentsToFolder(oExchangeService, oItemIds);
            return bRet;
        }

        public bool SaveAppointmentsToFolder(ExchangeService oExchangeService, List<ItemId> oItemIds)
        {
            bool bRet = true;
            string sFolder = string.Empty;
            if (GetFolderPath(ref sFolder))
                SaveAppointmentsToFolder(oExchangeService, oItemIds, sFolder);
            return bRet;
        }

        public bool SaveAppointmentToFolder(ExchangeService oExchangeService, ItemId oItemId, string sFolder)
        {
            bool bRet = true;
            List<ItemId> oItemIds = new List<ItemId> { oItemId };
            SaveAppointmentsToFolder(oExchangeService, oItemIds);
            return bRet;
        }

        public bool SaveAppointmentBlobToFolder(ExchangeService oExchangeService, ItemId oItemId, string sFolder )
        {
            string ServerVersion = oExchangeService.RequestedServerVersion.ToString();
            if (ServerVersion.StartsWith("Exchange2007") || ServerVersion == "Exchange2010")
            {
                MessageBox.Show("Exchange 2010 SP1 or later is requred to use ExportItems to do a blog export of an item.", "Invalid version for blog export using ExportItem");
                return false;
            }
            string tempFile = Path.GetTempFileName().Replace(".tmp", ".bin");
            //string sFile = sFolder + "\\Appointment\\" + tempFile;
            string sFile = sFolder +  tempFile;
            return SaveAppointmentBlobToFolder(oExchangeService, oItemId, sFolder, sFile);
        }

        public bool SaveAppointmentBlobToFolder(ExchangeService oExchangeService, ItemId oItemId, string sFolder, string sFile) 
        {
            bool bRet = false;
            string ServerVersion = oExchangeService.RequestedServerVersion.ToString();

            if (ServerVersion.StartsWith("Exchange2007") || ServerVersion == "Exchange2010")
            {
                MessageBox.Show("Exchange 2010 SP1 or later is requred to use ExportItems to do a blog export of an item.", "Invalid version for blog export using ExportItem");
                    return false;
            }
            
             
            Appointment oAppointment = Appointment.Bind(oExchangeService, oItemId);

            // Exchange2010_SP1 is the minimal version
            bRet = EWSEditor.Exchange.ExportUploadHelper.ExportItemPost(ServerVersion,oItemId.UniqueId, sFile);
 
            bRet = true;
            return bRet;
        }

        public bool SaveAppointmentsToFolder(ExchangeService oExchangeService, List<ItemId> oItemIds, string sFolder)
        {
            bool bRet = true;

            string sFilePath = string.Empty;
            string sContent = string.Empty;
            string sFileName = string.Empty;

            string sStorageFolder = sFolder; // + "\\Appointment"; 
            if (!Directory.Exists(sStorageFolder))
                Directory.CreateDirectory(sStorageFolder);

            foreach (ItemId oItemId in oItemIds)
            {
                sContent = string.Empty;
                 
                sFileName = Path.GetTempFileName().Replace(".tmp", ".xml");
                sFilePath = sStorageFolder + "\\" + sFileName;

                CalendarData oCalendarData = new CalendarData();
                oCalendarData = GetAppointmentDataFromItem(oExchangeService, oItemId);

                //http://msdn.microsoft.com/en-us/library/system.xml.xmlwritersettings.newlinehandling(v=vs.110).aspx
                sContent = SerialHelper.SerializeObjectToString<CalendarData>(oCalendarData);
                if (sContent != string.Empty)
                {
                    try
                    {
                        System.IO.File.WriteAllText(sFilePath, sContent);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Saving File");
                        return false;
                    }
                }

                return true;
            }

            return bRet;
        }

  

 
        public void SetAppointmentData(Appointment oAppointment, ref CalendarData oCalendarData)
        {
            CalendarData oCA = new CalendarData();

            // Appointment:
            byte[] byteArrVal;
            StringBuilder oSB = new StringBuilder();

            oCalendarData.Subject = oAppointment.Subject;
            oCalendarData.ItemClass = oAppointment.ItemClass;
            oCalendarData.OrganizerAddress = oAppointment.Organizer.Address;
            oCalendarData.DisplayTo = oAppointment.DisplayTo;
            oCalendarData.DisplayCc = oAppointment.DisplayCc;

            oCalendarData.Subject = oAppointment.Subject;
            oCalendarData.Subject = oAppointment.Subject;


            if (oAppointment.RequiredAttendees != null)
            {
                StringBuilder sbRequired = new StringBuilder();
                foreach (Attendee oAttendee in oAppointment.RequiredAttendees)
                    sbRequired.AppendFormat("{0} <{1}>;", oAttendee.Name, oAttendee.Address);
                oCalendarData.RequiredAttendees = sbRequired.ToString();
            }
            else
                oCalendarData.RequiredAttendees = string.Empty;


            if (oAppointment.OptionalAttendees != null)
            {
                StringBuilder sbOptional = new StringBuilder();
                foreach (Attendee oAttendee in oAppointment.OptionalAttendees)
                    sbOptional.AppendFormat("{0} <{1}>;", oAttendee.Name, oAttendee.Address);
                oCalendarData.OptionalAttendees = sbOptional.ToString();
            }
            else
            {
                oCalendarData.OptionalAttendees = string.Empty;
            }

            oCalendarData.ICalUid = oAppointment.ICalUid;

            byte[] bytearrVal;
            //if (oAppointment.TryGetProperty(PidLidCleanGlobalObjectId, out bytearrVal))  // CleanGlobalObjectId
            //    oCalendarData.PidLidCleanGlobalObjectId = Convert.ToBase64String(bytearrVal);  // reverse: Convert.FromBase64String(string data)
            //else
            //    oCalendarData.PidLidCleanGlobalObjectId = "";

            oCalendarData.PidLidCleanGlobalObjectId = GetExtendedPropByteArrAsString(oAppointment, PidLidCleanGlobalObjectId);

            //if (oAppointment.TryGetProperty(PidLidGlobalObjectId, out bytearrVal))  // GlobalObjectId
            //    oCalendarData.PidLidGlobalObjectId = Convert.ToBase64String(bytearrVal);  // reverse: Convert.FromBase64String(string data)
            //else
            //    oCalendarData.PidLidGlobalObjectId = "";

            oCalendarData.PidLidGlobalObjectId = GetExtendedPropByteArrAsString(oAppointment, PidLidGlobalObjectId);



            oCalendarData.Start = oAppointment.Start.ToString();
            oCalendarData.End = oAppointment.End.ToString();



            oCalendarData.DateTimeCreated = oAppointment.DateTimeCreated.ToString();

            oCalendarData.Start = oAppointment.Start.ToString();
            oCalendarData.End = oAppointment.End.ToString();

            oCalendarData.LastModifiedName = oAppointment.LastModifiedName;
            oCalendarData.LastModifiedTime = oAppointment.LastModifiedTime.ToString();

            oCalendarData.AppointmentType = oAppointment.AppointmentType.ToString();
            oCalendarData.AppointmentState = oAppointment.AppointmentState.ToString();

            oCalendarData.IsAllDayEvent = oAppointment.IsAllDayEvent.ToString();
            oCalendarData.IsCancelled = oAppointment.IsCancelled.ToString();
            oCalendarData.IsRecurring = oAppointment.IsRecurring.ToString();
            oCalendarData.IsReminderSet = oAppointment.IsReminderSet.ToString();

            oCalendarData.IsOnlineMeeting = oAppointment.IsOnlineMeeting.ToString();
            oCalendarData.IsResend = oAppointment.IsResend.ToString();
            oCalendarData.IsDraft = oAppointment.IsDraft.ToString();

            oCalendarData.Size = oAppointment.Size.ToString();
            oCalendarData.HasAttachments = oAppointment.HasAttachments.ToString();



            if (oAppointment.TryGetProperty(PidLidAppointmentRecur, out byteArrVal))
                oCalendarData.PidLidAppointmentRecur = ConversionHelper.GetStringFromBytes(byteArrVal);
            else
                oCalendarData.PidLidAppointmentRecur = "";

            int lVal;
            if (oAppointment.TryGetProperty(PidLidClientIntent, out lVal))
                oCalendarData.PidLidClientIntent = lVal.ToString();
            else
                oCalendarData.PidLidClientIntent = "";

            string sVal;
            if (oAppointment.TryGetProperty(ClientInfoString, out sVal))
                oCalendarData.ClientInfoString = sVal;
            else
                oCalendarData.ClientInfoString = "";

            string sVal2;
            if (oAppointment.TryGetProperty(LogTriggerAction, out sVal2))
                oCalendarData.LogTriggerAction = sVal2;
            else
                oCalendarData.LogTriggerAction = "";


            string sFolderPath = string.Empty;
            if (EwsFolderHelper.GetFolderPath(oAppointment.Service, oAppointment.ParentFolderId, ref sFolderPath))
                oCalendarData.FolderPath = sFolderPath;
            else
                oCalendarData.FolderPath = "";


            if (oAppointment.TryGetProperty(Prop_PR_STORE_ENTRYID, out byteArrVal))
                oCalendarData.StoreEntryId = ConversionHelper.GetStringFromBytes(byteArrVal);
            else
                oCalendarData.StoreEntryId = "";
            
    
            if (oAppointment.TryGetProperty(Prop_PR_ENTRYID, out byteArrVal))
                oCalendarData.EntryId = ConversionHelper.GetStringFromBytes(byteArrVal);
            else
                oCalendarData.EntryId = "";
 
            if (oAppointment.TryGetProperty(Prop_PR_RETENTION_DATE, out byteArrVal))
                oCalendarData.RetentionDate = ConversionHelper.GetStringFromBytes(byteArrVal);
            else
                oCalendarData.RetentionDate = "";

            bool bolVal = false;
            if (oAppointment.TryGetProperty(Prop_PR_IS_HIDDEN, out bolVal))
                oCalendarData.RetentionDate = bolVal.ToString();
            else
                oCalendarData.RetentionDate = "";

            //if (oAppointment.AppointmentReplyTime != null) oCalendarData.AppointmentReplyTime = oAppointment.AppointmentReplyTime.ToString();   Not being returned
            try
            {
                oCalendarData.AllowNewTimeProposal = oAppointment.AllowNewTimeProposal.ToString();
            }
            catch (Exception ex)
            {
                oCalendarData.AllowNewTimeProposal = "";
            }
            //if (oAppointment.AllowNewTimeProposal != null) oCalendarData.AllowNewTimeProposal = oAppointment.AllowNewTimeProposal.ToString();
            oCalendarData.AllowedResponseActions = oAppointment.AllowedResponseActions.ToString();
            oCalendarData.AdjacentMeetingCount = oAppointment.AdjacentMeetingCount.ToString();
            oCalendarData.AppointmentSequenceNumber = oAppointment.AppointmentSequenceNumber.ToString();
            oCalendarData.Body = oAppointment.Body;
            oCalendarData.Categories = oAppointment.Categories.ToString();
            // oCalendarData.ConferenceType = oAppointment.ConferenceType.ToString();  Not being returned
            oCalendarData.ConflictingMeetingCount = oAppointment.ConflictingMeetingCount.ToString();


            if (oAppointment.ConflictingMeetings != null)
            {
                oSB = new StringBuilder();
                foreach (Appointment a in oAppointment.ConflictingMeetings)
                {
                    oSB.AppendFormat("Subject: {0}  Start: {1}  End: {2}  UniqueId: {3} \r\n", a.Subject, a.Start, a.End, a.Id.UniqueId);
                }
                oCalendarData.ConflictingMeetings = oSB.ToString();
            }
            else
                oCalendarData.ConflictingMeetings = "";

            oCalendarData.Culture = oAppointment.Culture.ToString();
            try
            {
                oCalendarData.DateTimeReceived = "";
            }
            catch (Exception ex)
            {
                oCalendarData.DateTimeReceived = null;
            }
            oCalendarData.Duration = oAppointment.Duration.ToString();
            oCalendarData.EffectiveRights = oAppointment.EffectiveRights.ToString();
            if (oCalendarData.ICalDateTimeStamp != null) oCalendarData.ICalDateTimeStamp = oAppointment.ICalDateTimeStamp.ToString();
            oCalendarData.Importance = oAppointment.Importance.ToString();
            if (oAppointment.InReplyTo != null) oCalendarData.InReplyTo = oAppointment.InReplyTo.ToString();
            if (oAppointment.InternetMessageHeaders != null) oCalendarData.InternetMessageHeaders = oAppointment.InternetMessageHeaders.ToString();

            bool boolVal = false;
            if (oAppointment.TryGetProperty(Prop_PR_IS_HIDDEN, out boolVal))
                oCalendarData.IsHidden = boolVal.ToString();
            else
                oCalendarData.IsHidden = "";

            oCalendarData.IsResponseRequested = oAppointment.IsResponseRequested.ToString();
            oCalendarData.IsSubmitted = oAppointment.IsSubmitted.ToString();
            oCalendarData.IsUnmodified = oAppointment.IsUnmodified.ToString();
            oCalendarData.LegacyFreeBusyStatus = oAppointment.LegacyFreeBusyStatus.ToString();
            if (oAppointment.Location != null) oCalendarData.Location = oAppointment.Location.ToString();
            oCalendarData.MeetingRequestWasSent = oAppointment.MeetingRequestWasSent.ToString();
            if (oAppointment.MeetingWorkspaceUrl != null) oCalendarData.MeetingWorkspaceUrl = oAppointment.MeetingWorkspaceUrl.ToString();
            if (oAppointment.MimeContent != null) oCalendarData.MimeContent = oAppointment.MimeContent.ToString();
            oCalendarData.MyResponseType = oAppointment.MyResponseType.ToString();
            if (oAppointment.NetShowUrl != null) oCalendarData.NetShowUrl = oAppointment.NetShowUrl;

            try
            {
                oCalendarData.ReminderDueBy = oAppointment.ReminderDueBy.ToString();
            }
            catch (Exception ex)
            {
                oCalendarData.ReminderDueBy = "";
            }

            oCalendarData.ReminderMinutesBeforeStart = oAppointment.ReminderMinutesBeforeStart.ToString();

            if (oAppointment.Resources != null)
            {
                oSB = new StringBuilder();
                foreach (Attendee oAttendee in oAppointment.Resources)
                    oSB.AppendFormat("{0} <{1}>;", oAttendee.Name, oAttendee.Address);
            }

            if (oCalendarData.Resources != null) oCalendarData.Resources = oCalendarData.Resources.ToString();
            if (oAppointment.StartTimeZone != null) oCalendarData.StartTimeZone = oAppointment.StartTimeZone.ToString();
            oCalendarData.Sensitivity = oAppointment.Sensitivity.ToString();
            if (oAppointment.When != null) oCalendarData.When = oAppointment.When.ToString();


 
            oCalendarData.UniqueId = oAppointment.Id.UniqueId;

            SetAppointmentRecurrenceData(oAppointment, ref oCalendarData);

        }

        private void SetAppointmentRecurrenceData(Appointment oAppointment, ref CalendarData oCalendarData)
        {
            //  Recurrence  -----------------------------------------------------------------------

            if (oAppointment.Recurrence != null)
            {

                oCalendarData.StartingDateRange = oAppointment.Recurrence.StartDate.ToString();
                oCalendarData.RecurrStartTime = oAppointment.Recurrence.StartDate.ToString();

                if (oAppointment.Recurrence.EndDate.HasValue)
                    oCalendarData.RecurrEndTime = oAppointment.Recurrence.EndDate.ToString();
                else
                    oCalendarData.RecurrEndTime = oAppointment.Recurrence.StartDate.ToString();

                if (oAppointment.Recurrence is Recurrence.DailyPattern)
                {
                    oCalendarData.RecurrencePattern = "DailyPattern";
                    Recurrence.DailyPattern o = (Recurrence.DailyPattern)oAppointment.Recurrence;

                    oCalendarData.RecurrencePatternInterval = o.Interval.ToString();

                    o = null;
                }

                if (oAppointment.Recurrence is Recurrence.WeeklyPattern)
                {
                    oCalendarData.RecurrencePattern = "WeeklyPattern";
                    Recurrence.WeeklyPattern o = (Recurrence.WeeklyPattern)oAppointment.Recurrence;

                    oCalendarData.RecurrencePatternInterval = o.Interval.ToString();



                    foreach (DayOfTheWeek dotw in o.DaysOfTheWeek)
                    {
                        switch (dotw)
                        {
                            case DayOfTheWeek.Sunday:
                                oCalendarData.RecurrencePatternDaysOfTheWeek += "Sunday, ";
                                break;
                            case DayOfTheWeek.Monday:
                                oCalendarData.RecurrencePatternDaysOfTheWeek += "Monday, ";
                                break;
                            case DayOfTheWeek.Tuesday:
                                oCalendarData.RecurrencePatternDaysOfTheWeek += "Tuesday, ";
                                break;
                            case DayOfTheWeek.Wednesday:
                                oCalendarData.RecurrencePatternDaysOfTheWeek += "Wednesday, ";
                                break;
                            case DayOfTheWeek.Thursday:
                                oCalendarData.RecurrencePatternDaysOfTheWeek += "Thursday, ";
                                break;
                            case DayOfTheWeek.Friday:
                                oCalendarData.RecurrencePatternDaysOfTheWeek += "Friday, ";
                                break;
                            case DayOfTheWeek.Saturday:
                                oCalendarData.RecurrencePatternDaysOfTheWeek += "Saturday, ";
                                break;
                            default:
                                break;
                        }
                    }

                    if (oCalendarData.RecurrencePatternDaysOfTheWeek.EndsWith(", "))
                        oCalendarData.RecurrencePatternDaysOfTheWeek = oCalendarData.RecurrencePatternDaysOfTheWeek.Remove(oCalendarData.RecurrencePatternDaysOfTheWeek.Length - 2, 2);
                    o = null;

                }

                if (oAppointment.Recurrence is Recurrence.MonthlyPattern)
                {
                    oCalendarData.RecurrencePattern = "MonthlyPattern";

                    Recurrence.MonthlyPattern o = (Recurrence.MonthlyPattern)oAppointment.Recurrence;
                    oCalendarData.RecurrMonthlyPatternDayOfMonth = o.DayOfMonth.ToString();
                    oCalendarData.RecurrMonthlyPatternEveryMonths = o.Interval.ToString();

                }

                if (oAppointment.Recurrence is Recurrence.RelativeMonthlyPattern)
                {
                    oCalendarData.RecurrencePattern = "RelativeMonthlyPattern";

                    Recurrence.RelativeMonthlyPattern o = (Recurrence.RelativeMonthlyPattern)oAppointment.Recurrence;

                    oCalendarData.RecurrDayOfTheWeekIndex = o.DayOfTheWeekIndex.ToString();
                    oCalendarData.RecurrDayOfWeek = o.DayOfTheWeek.ToString();
                    oCalendarData.RecurrInterval = o.Interval.ToString();

                }

                if (oAppointment.Recurrence is Recurrence.YearlyPattern)
                {
                    oCalendarData.RecurrencePattern = "YearlyPattern";

                    Recurrence.YearlyPattern o = (Recurrence.YearlyPattern)oAppointment.Recurrence;

                    oCalendarData.RecurrYearlyOnSpecificDay = o.DayOfMonth.ToString();

                    oCalendarData.RecurrYearlyOnSpecificDayForMonthOf = Enum.GetName(typeof(Month), o.Month);

                    o = null;
                }

                if (oAppointment.Recurrence is Recurrence.RelativeYearlyPattern)
                {
                    oCalendarData.RecurrencePattern = "RelativeYearlyPattern";

                    Recurrence.RelativeYearlyPattern o = (Recurrence.RelativeYearlyPattern)oAppointment.Recurrence;

                    oCalendarData.RecurrYearlyOnDayPatternDayOfWeekIndex = o.DayOfTheWeekIndex.ToString();
                    oCalendarData.RecurrYearlyOnDayPatternDayOfWeekIndex = Enum.GetName(typeof(DayOfTheWeekIndex), o.DayOfTheWeekIndex);
                    oCalendarData.RecurrYearlyOnDayPatternDayOfWeek = Enum.GetName(typeof(DayOfTheWeek), o.DayOfTheWeek);
                    oCalendarData.RecurrYearlyOnDayPatternMonth = Enum.GetName(typeof(Month), o.Month);

                    o = null;
                }

                // Range
                if (oAppointment.Recurrence.HasEnd == true)
                {
                    oCalendarData.RangeHasEnd = oAppointment.Recurrence.HasEnd.ToString();
                    oCalendarData.RangeNumberOccurrences = "";
                    oCalendarData.RangeEndByDate = "";
                    //RangeEndByDate = oAppointment.Recurrence.EndDate.Value;  // ??
                }
                else
                {

                    if (oAppointment.Recurrence.NumberOfOccurrences.HasValue)
                    {
                        oCalendarData.RangeNumberOccurrences = oAppointment.Recurrence.NumberOfOccurrences.ToString();
                    }
                    else
                    {
                        oCalendarData.RangeNumberOccurrences = "";
                        if (oAppointment.Recurrence.EndDate.HasValue)
                        {
                            oCalendarData.RangeEndByDate = oAppointment.Recurrence.EndDate.ToString();
                        }
                    }
                }


                if (oAppointment.Recurrence is Recurrence.MonthlyPattern)
                {
                    oCalendarData.RecurrencePattern = "MonthlyPattern";

                    Recurrence.MonthlyPattern o = (Recurrence.MonthlyPattern)oAppointment.Recurrence;
                    oCalendarData.RecurrMonthlyPatternDayOfMonth = o.DayOfMonth.ToString();
                    oCalendarData.RecurrMonthlyPatternEveryMonths = o.Interval.ToString();

                }

                if (oAppointment.Recurrence is Recurrence.RelativeMonthlyPattern)
                {
                    oCalendarData.RecurrencePattern = "RelativeMonthlyPattern";

                    Recurrence.RelativeMonthlyPattern o = (Recurrence.RelativeMonthlyPattern)oAppointment.Recurrence;

                    oCalendarData.RecurrDayOfTheWeekIndex = o.DayOfTheWeekIndex.ToString();
                    oCalendarData.RecurrDayOfWeek = o.DayOfTheWeek.ToString();
                    oCalendarData.RecurrInterval = o.Interval.ToString();

                }

                if (oAppointment.Recurrence is Recurrence.YearlyPattern)
                {
                    oCalendarData.RecurrencePattern = "YearlyPattern";

                    Recurrence.YearlyPattern o = (Recurrence.YearlyPattern)oAppointment.Recurrence;

                    oCalendarData.RecurrYearlyOnSpecificDay = o.DayOfMonth.ToString();

                    oCalendarData.RecurrYearlyOnSpecificDayForMonthOf = Enum.GetName(typeof(Month), o.Month);

                    o = null;
                }

                if (oAppointment.Recurrence is Recurrence.RelativeYearlyPattern)
                {
                    oCalendarData.RecurrencePattern = "RelativeYearlyPattern";

                    Recurrence.RelativeYearlyPattern o = (Recurrence.RelativeYearlyPattern)oAppointment.Recurrence;

                    oCalendarData.RecurrYearlyOnDayPatternDayOfWeekIndex = o.DayOfTheWeekIndex.ToString();
                    oCalendarData.RecurrYearlyOnDayPatternDayOfWeekIndex = Enum.GetName(typeof(DayOfTheWeekIndex), o.DayOfTheWeekIndex);
                    oCalendarData.RecurrYearlyOnDayPatternDayOfWeek = Enum.GetName(typeof(DayOfTheWeek), o.DayOfTheWeek);
                    oCalendarData.RecurrYearlyOnDayPatternMonth = Enum.GetName(typeof(Month), o.Month);

                    o = null;
                }

                // Range
                if (oAppointment.Recurrence.HasEnd == true)
                {
                    oCalendarData.RangeHasEnd = oAppointment.Recurrence.HasEnd.ToString();
                    oCalendarData.RangeNumberOccurrences = "";
                    oCalendarData.RangeEndByDate = "";
                    //RangeEndByDate = oAppointment.Recurrence.EndDate.Value;  // ??
                }
                else
                {

                    if (oAppointment.Recurrence.NumberOfOccurrences.HasValue)
                    {
                        oCalendarData.RangeNumberOccurrences = oAppointment.Recurrence.NumberOfOccurrences.ToString();
                    }
                    else
                    {
                        oCalendarData.RangeNumberOccurrences = "";
                        if (oAppointment.Recurrence.EndDate.HasValue)
                            oCalendarData.RangeEndByDate = oAppointment.Recurrence.EndDate.ToString();
                    }
                }
            }

        }

        private PropertySet GetCalendarPropset()
        {
            return GetCalendarPropset(false);
        }

        private PropertySet GetCalendarPropset(bool bIncludeAttachments)
        {

            PropertySet appointmentPropertySet = new PropertySet(BasePropertySet.IdOnly,

                AppointmentSchema.AdjacentMeetingCount,
                AppointmentSchema.AdjacentMeetings,
                AppointmentSchema.AllowedResponseActions,
                AppointmentSchema.AllowNewTimeProposal,
                /* AppointmentSchema.AppointmentReplyTime,  */
                AppointmentSchema.AppointmentSequenceNumber,
                AppointmentSchema.AppointmentState,
                AppointmentSchema.AppointmentType,
                AppointmentSchema.Attachments,
                AppointmentSchema.Body,
                AppointmentSchema.Categories,
                /*  AppointmentSchema.ConferenceType,   */
                AppointmentSchema.ConflictingMeetingCount,
                AppointmentSchema.ConflictingMeetings,
                AppointmentSchema.Culture,
                AppointmentSchema.DateTimeCreated,
                AppointmentSchema.DateTimeReceived,
                AppointmentSchema.DateTimeSent,
                AppointmentSchema.DeletedOccurrences,
                AppointmentSchema.DisplayCc,
                AppointmentSchema.DisplayTo,
                AppointmentSchema.Duration,
                AppointmentSchema.EffectiveRights,
                AppointmentSchema.End,
                AppointmentSchema.HasAttachments,
                AppointmentSchema.ICalDateTimeStamp,
                AppointmentSchema.ICalRecurrenceId,
                AppointmentSchema.ICalUid,
                AppointmentSchema.Id,
                AppointmentSchema.Importance,
                AppointmentSchema.InReplyTo,
                AppointmentSchema.InternetMessageHeaders,

                AppointmentSchema.IsAllDayEvent,
                AppointmentSchema.IsCancelled,
                AppointmentSchema.IsDraft,
                AppointmentSchema.IsFromMe,
                AppointmentSchema.IsMeeting,
                AppointmentSchema.IsOnlineMeeting,
                AppointmentSchema.IsRecurring,
                AppointmentSchema.IsReminderSet,
                AppointmentSchema.IsResend,
                AppointmentSchema.IsResponseRequested,
                AppointmentSchema.IsSubmitted,
                AppointmentSchema.IsUnmodified,
                AppointmentSchema.ItemClass,
                AppointmentSchema.LastModifiedName,
                AppointmentSchema.LastModifiedTime,
                AppointmentSchema.LegacyFreeBusyStatus,
                AppointmentSchema.Location,
                AppointmentSchema.MeetingRequestWasSent,
                AppointmentSchema.MeetingWorkspaceUrl,
                AppointmentSchema.MimeContent,
                AppointmentSchema.ModifiedOccurrences,
                AppointmentSchema.MyResponseType,
                AppointmentSchema.NetShowUrl,
                AppointmentSchema.OptionalAttendees,
                AppointmentSchema.Organizer,
                AppointmentSchema.OriginalStart,
                AppointmentSchema.ParentFolderId,
                AppointmentSchema.Recurrence,
                AppointmentSchema.ReminderDueBy,
                AppointmentSchema.ReminderMinutesBeforeStart,
                AppointmentSchema.RequiredAttendees,
                AppointmentSchema.Resources,
                AppointmentSchema.Sensitivity,
                AppointmentSchema.Size,
                AppointmentSchema.Start,
                AppointmentSchema.StartTimeZone,
                AppointmentSchema.Subject,
                AppointmentSchema.TimeZone,
                AppointmentSchema.When


              );

            // Not included:
            //    AppointmentSchema.FirstOccurrence.,
            //    AppointmentSchema.LastOccurrence,
            //    AppointmentSchema.ModifiedOccurrences,
            //    AppointmentSchema.DeletedOccurrences,
            //    AppointmentSchema.ExtendedProperties

            // These are version specific:
            //      AppointmentSchema.Hashtags,                     2015+
            //      AppointmentSchema.MentionedMe,                  2015+
            //      AppointmentSchema.Mentions                      2015+
            //      AppointmentSchema.MimeContentUTF8,              Exchange2013_SP1+
            //      AppointmentSchema.ArchiveTag,                   2013+                +
            //      AppointmentSchema.ConversationId                2010+                +
            //      AppointmentSchema.EndTimeZone,                  2010+                 
            //      AppointmentSchema.EnhancedLocation,             2013+
            //      AppointmentSchema.EntityExtractionResult,       2013+
            //      AppointmentSchema.Flag,                         2013+
            //      AppointmentSchema.IconIndex,                    2013+                +
            //      AppointmentSchema.InstanceKey,                  2013+                +
            //      AppointmentSchema.IsAssociated,                 2010+
            //      AppointmentSchema.JoinOnlineMeetingUrl,         2013+
            //      AppointmentSchema.NormalizedBody,               2013+
            //      AppointmentSchema.OnlineMeetingSettings,        2013+
            //      AppointmentSchema.PolicyTag,                    2013+                +
            //      AppointmentSchema.Preview,                      2013+
            //      AppointmentSchema.RetentionDate,                2013+                +
            //      AppointmentSchema.StoreEntryId,                 2013+                +
            //      AppointmentSchema.TextBody,                     2013+
            //      AppointmentSchema.UniqueBody,                   2010+
            //      AppointmentSchema.WebClientEditFormQueryString, 2010+
            //      AppointmentSchema.WebClientReadFormQueryString, 2010+

            // Problems loading or need extra work to implement:
            //   AppointmentSchema.AppointmentReplyTime 
            //   AppointmentSchema.ConferenceType 

            if (bIncludeAttachments == true)
                appointmentPropertySet.Add(AppointmentSchema.Attachments);


            // Need to add these:
            appointmentPropertySet.Add(PidLidAppointmentRecur);
            appointmentPropertySet.Add(PidLidClientIntent);
            appointmentPropertySet.Add(ClientInfoString);
            appointmentPropertySet.Add(LogTriggerAction);
            appointmentPropertySet.Add(PidLidCleanGlobalObjectId);
            appointmentPropertySet.Add(PidLidGlobalObjectId);

            appointmentPropertySet.Add(Prop_PR_POLICY_TAG);

            appointmentPropertySet.Add(Prop_PR_RETENTION_FLAGS);
            appointmentPropertySet.Add(Prop_PR_RETENTION_PERIOD);
            appointmentPropertySet.Add(Prop_PR_ARCHIVE_TAG);
            appointmentPropertySet.Add(Prop_PR_ARCHIVE_PERIOD);
            appointmentPropertySet.Add(Prop_PR_ARCHIVE_DATE);
            appointmentPropertySet.Add(Prop_PR_ENTRYID);

            appointmentPropertySet.Add(Prop_PR_RETENTION_DATE);
            appointmentPropertySet.Add(Prop_PR_STORE_ENTRYID);
            appointmentPropertySet.Add(Prop_PR_IS_HIDDEN);

            return appointmentPropertySet;
        }


        private string GetExtendedPropByteArrAsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            byte[] bytearrVal;

            string sReturn = "";
            if (oItem.TryGetProperty(oExtendedPropertyDefinition, out bytearrVal))  // Example: CleanGlobalObjectId
                sReturn = Convert.ToBase64String(bytearrVal);  // reverse: Convert.FromBase64String(string data)
            else
                sReturn = "";
            return sReturn;
        }

 

    }
}
