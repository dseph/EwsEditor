using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using System.IO;
using System.Windows.Forms; 
using System.Xml.Serialization;

using EWSEditor.Common;
using EWSEditor.Common.Extensions;
using EWSEditor.Resources;
using Microsoft.Exchange.WebServices.Data;


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

        private static ExtendedPropertyDefinition PR_SENT_REPRESENTING_EMAIL_ADDRESS = new ExtendedPropertyDefinition(0x0065, MapiPropertyType.String);
        private static ExtendedPropertyDefinition PR_SENDER_EMAIL_ADDRESS = new ExtendedPropertyDefinition(0x4030, MapiPropertyType.String);
        private static ExtendedPropertyDefinition ptagSenderSimpleDispName  = new ExtendedPropertyDefinition(0x0C1F, MapiPropertyType.String);

        private static ExtendedPropertyDefinition PR_PARENT_ENTRYID = new ExtendedPropertyDefinition(0x0E09, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PR_MESSAGE_FLAGS = new ExtendedPropertyDefinition(0x0E07, MapiPropertyType.Integer); // PT_LONG
        private static ExtendedPropertyDefinition PR_MSG_STATUS = new ExtendedPropertyDefinition(0x0E17, MapiPropertyType.Integer);// PT_LONG
        private static ExtendedPropertyDefinition PR_MESSAGE_DELIVERY_TIME = new ExtendedPropertyDefinition(0x0E06, MapiPropertyType.Binary);   // PT_SYSTIME  
        private static ExtendedPropertyDefinition PR_CONVERSATION_TOPIC = new ExtendedPropertyDefinition(0x0070, MapiPropertyType.String);   
        private static ExtendedPropertyDefinition PR_CONVERSATION_ID  = new ExtendedPropertyDefinition(0x3013, MapiPropertyType.Binary);   
        private static ExtendedPropertyDefinition PPR_CONVERSATION_INDEX = new ExtendedPropertyDefinition(0x0071, MapiPropertyType.Binary);   
        private static ExtendedPropertyDefinition PR_CONTROL_FLAGS = new ExtendedPropertyDefinition(0x3F00, MapiPropertyType.Integer);// PT_LONG

 
        // PT_LONG  0003

        //// From calcheck
        //private static ExtendedPropertyDefinition dispidRecurring = new ExtendedPropertyDefinition(0x8223, MapiPropertyType.xxxx);
        //private static ExtendedPropertyDefinition dispidRecurType = new ExtendedPropertyDefinition(0x8231, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidApptStartWhole = new ExtendedPropertyDefinition(0x820D, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidApptEndWhole = new ExtendedPropertyDefinition(0x820E, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidApptStateFlags = new ExtendedPropertyDefinition(0x8217, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidLocation = new ExtendedPropertyDefinition(0x8208, MapiPropertyType.xxxxxxxxxx);
        //// ?  private static ExtendedPropertyDefinition dispidTimeZoneDesc = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidApptRecur = new ExtendedPropertyDefinition(0x8216, MapiPropertyType.xxxxxxxxxx);  // tagAllDayEvt
        //private static ExtendedPropertyDefinition PidLidIsRecurring = new ExtendedPropertyDefinition(0x0005, MapiPropertyType.xxxxxxxxxx);
        ////    private static ExtendedPropertyDefinition PidLidGlobalObjectId = new ExtendedPropertyDefinition(0x0003, MapiPropertyType.xxxxxxxxxx);
        ////    private static ExtendedPropertyDefinition PidLidCleanGlobalObjectId = new ExtendedPropertyDefinition(0x0023, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidApptAuxFlags = new ExtendedPropertyDefinition(0x8207, MapiPropertyType.Integer);
        //private static ExtendedPropertyDefinition PidLidIsException = new ExtendedPropertyDefinition(0x000A, MapiPropertyType.xxxxxxxxxx);
        //// ?  private static ExtendedPropertyDefinition Keywords = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidTimeZoneDesc = new ExtendedPropertyDefinition(0x8234, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidTimeZoneStruct = new ExtendedPropertyDefinition(0X8233, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidApptTZDefStartDisplay = new ExtendedPropertyDefinition(0X825E, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidApptTZDefEndDisplay = new ExtendedPropertyDefinition(0X825F, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidApptTZDefRecur = new ExtendedPropertyDefinition(0X8260, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidPropDefStream = new ExtendedPropertyDefinition(0X8540, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidApptDuration = new ExtendedPropertyDefinition(0x8213, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidApptSubType = new ExtendedPropertyDefinition(0x8215, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidAllAttendeesString = new ExtendedPropertyDefinition(0x8238, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidToAttendeesString = new ExtendedPropertyDefinition(0x823B, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidCCAttendeesString = new ExtendedPropertyDefinition(0x823C, MapiPropertyType.xxxxxxxxxx);
        //private static ExtendedPropertyDefinition dispidResponseStatus = new ExtendedPropertyDefinition(0x8218, MapiPropertyType.xxxxxxxxxx);

 

        //public EWSEditor.Common.EwsHelpers.AppointmentData CalendarAppointment;

        //public Appointment GetAppointment(ExchangeService oExchangeService, ItemId oItemId)
        //{
        //    Appointment oAppointment = Appointment.Bind(oExchangeService, oItemId, GetCalendarPropset());
        //    //AppointmentData oAppointmentData = new AppointmentData();
        //    SetAppointmentData(oAppointment);
        //    return oAppointment;
        //}

        //public void SetAppointmentData(Appointment oAppointment)  
        //{
        //    AppointmentData oCA = new AppointmentData();

        //    SetAppointmentData(oAppointment, ref oCA);

        //    this.CalendarAppointment = oCA;
        //}

       public AppointmentData GetAppointmentDataFromItem(ExchangeService oExchangeService, ItemId oItemId)
        {
            AppointmentData oAppointmentData = GetAppointmentDataFromItem(oExchangeService, oItemId, false, false, false);
            return oAppointmentData;
       }

       public AppointmentData GetAppointmentDataFromItem(ExchangeService oExchangeService, ItemId oItemId, bool bIncludeAttachments, bool bIncludeBody, bool bIncludeMime)
        {
            string ServerVersion = oExchangeService.RequestedServerVersion.ToString();
            PropertySet oPropertySet = null;
            oPropertySet = GetCalendarPropset(ServerVersion,  bIncludeAttachments,  bIncludeBody,  bIncludeMime);
            Appointment oAppointment = Appointment.Bind(oExchangeService, oItemId, GetCalendarPropset(ServerVersion));
            AppointmentData oAppointmentData = new AppointmentData();

            SetAppointmentData(oAppointment, ref oAppointmentData);

            return oAppointmentData;
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

        //public bool SaveAppointmentBlobToFolder(ExchangeService oExchangeService, ItemId oItemId, string sFolder, string sSeedFileName)
        //{
        //    string ServerVersion = oExchangeService.RequestedServerVersion.ToString();
        //    if (ServerVersion.StartsWith("Exchange2007") || ServerVersion == "Exchange2010")
        //    {
        //        MessageBox.Show("Exchange 2010 SP1 or later is requred to use ExportItems to do a blog export of an item.", "Invalid version for blog export using ExportItem");
        //        return false;
        //    }
        //    //string tempFile = Path.GetTempFileName().Replace(".tmp", ".bin");
        //    string tempFile = Path.GetTempFileName();
        //    tempFile = tempFile.Replace(".tmp", ".bin");

        //    //string sFile = sFolder + "\\Appointment\\" + tempFile;

        //    string sFile = sSeedFileName + " - " + tempFile + ".bin";
        //    sFile = Path.Combine(sFolder, sSeedFileName );
        //    return SaveAppointmentBlobToFolder(oExchangeService, oItemId,  sFile);
        //}

        public bool SaveAppointmentBlobToFolder(ExchangeService oExchangeService, ItemId oItemId,  string sFile) 
        {
            bool bRet = false;
            string ServerVersion = oExchangeService.RequestedServerVersion.ToString();

            if (ServerVersion.StartsWith("Exchange2007") || ServerVersion == "Exchange2010")
            {
                MessageBox.Show("Exchange 2010 SP1 or later is requred to use ExportItems to do a blob export of an item.", "Invalid version for blob export using ExportItem");
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

                AppointmentData oAppointmentData = new AppointmentData();
                oAppointmentData = GetAppointmentDataFromItem(oExchangeService, oItemId);

                //http://msdn.microsoft.com/en-us/library/system.xml.xmlwritersettings.newlinehandling(v=vs.110).aspx
                sContent = SerialHelper.SerializeObjectToString<AppointmentData>(oAppointmentData);
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

  

 
        public void SetAppointmentData(Appointment oAppointment, ref AppointmentData oAppointmentData)
        {
            AppointmentData oCA = new AppointmentData();

            // Appointment:
            byte[] byteArrVal;
            StringBuilder oSB = new StringBuilder();

             
            oAppointmentData.Subject = oAppointment.Subject;
            oAppointmentData.ItemClass = oAppointment.ItemClass;
            oAppointmentData.OrganizerName = oAppointment.Organizer.Name;
            oAppointmentData.OrganizerAddress = oAppointment.Organizer.Address;
            if (oAppointment.DisplayTo != null)
                oAppointmentData.DisplayTo = oAppointment.DisplayTo;
            if (oAppointment.DisplayCc != null)
                oAppointmentData.DisplayCc = oAppointment.DisplayCc;

        
            oAppointmentData.Subject = oAppointment.Subject;


            if (oAppointment.RequiredAttendees != null)
            {
                StringBuilder sbRequired = new StringBuilder();
                foreach (Attendee oAttendee in oAppointment.RequiredAttendees)
                    sbRequired.AppendFormat("{0} <{1}>;", oAttendee.Name, oAttendee.Address);
                oAppointmentData.RequiredAttendees = sbRequired.ToString();
            }
            else
                oAppointmentData.RequiredAttendees = string.Empty;


            if (oAppointment.OptionalAttendees != null)
            {
                StringBuilder sbOptional = new StringBuilder();
                foreach (Attendee oAttendee in oAppointment.OptionalAttendees)
                    sbOptional.AppendFormat("{0} <{1}>;", oAttendee.Name, oAttendee.Address);
                oAppointmentData.OptionalAttendees = sbOptional.ToString();
            }
            else
            {
                oAppointmentData.OptionalAttendees = string.Empty;
            }

            oAppointmentData.ICalUid = oAppointment.ICalUid;

            byte[] bytearrVal;
            //if (oAppointment.TryGetProperty(PidLidCleanGlobalObjectId, out bytearrVal))  // CleanGlobalObjectId
            //    oAppointmentData.PidLidCleanGlobalObjectId = Convert.ToBase64String(bytearrVal);  // reverse: Convert.FromBase64String(string data)
            //else
            //    oAppointmentData.PidLidCleanGlobalObjectId = "";

            //oAppointmentData.PidLidCleanGlobalObjectId = GetExtendedPropByteArrAsString(oAppointment, PidLidCleanGlobalObjectId);

            oAppointmentData.PidLidCleanGlobalObjectId = EwsExtendedPropertyHelper.GetExtendedPropByteArrAsString(oAppointment, PidLidCleanGlobalObjectId);

            //if (oAppointment.TryGetProperty(PidLidGlobalObjectId, out bytearrVal))  // GlobalObjectId
            //    oAppointmentData.PidLidGlobalObjectId = Convert.ToBase64String(bytearrVal);  // reverse: Convert.FromBase64String(string data)
            //else
            //    oAppointmentData.PidLidGlobalObjectId = "";

            oAppointmentData.PidLidGlobalObjectId = EwsExtendedPropertyHelper.GetExtendedPropByteArrAsString(oAppointment, PidLidGlobalObjectId);



            oAppointmentData.Start = oAppointment.Start.ToString();
            oAppointmentData.End = oAppointment.End.ToString();



            oAppointmentData.DateTimeCreated = oAppointment.DateTimeCreated.ToString();

            oAppointmentData.Start = oAppointment.Start.ToString();
            oAppointmentData.End = oAppointment.End.ToString();

            oAppointmentData.LastModifiedName = oAppointment.LastModifiedName;
            oAppointmentData.LastModifiedTime = oAppointment.LastModifiedTime.ToString();

            oAppointmentData.AppointmentType = oAppointment.AppointmentType.ToString();
            oAppointmentData.AppointmentState = oAppointment.AppointmentState.ToString();

            oAppointmentData.IsAllDayEvent = oAppointment.IsAllDayEvent.ToString();
            oAppointmentData.IsCancelled = oAppointment.IsCancelled.ToString();
            oAppointmentData.IsRecurring = oAppointment.IsRecurring.ToString();
            oAppointmentData.IsReminderSet = oAppointment.IsReminderSet.ToString();

            oAppointmentData.IsOnlineMeeting = oAppointment.IsOnlineMeeting.ToString();
            oAppointmentData.IsResend = oAppointment.IsResend.ToString();
            oAppointmentData.IsDraft = oAppointment.IsDraft.ToString();

            oAppointmentData.Size = oAppointment.Size.ToString();
            oAppointmentData.HasAttachments = oAppointment.HasAttachments.ToString();

            oAppointmentData.PidLidAppointmentRecur = GetExtendedProp_ByteArr_AsString(oAppointment, PidLidAppointmentRecur);
            oAppointmentData.PidLidClientIntent = GetExtendedProp_Int_AsString(oAppointment, PidLidClientIntent);
            oAppointmentData.ClientInfoString = GetExtendedProp_String_AsString(oAppointment, ClientInfoString);
            oAppointmentData.StoreEntryId = GetExtendedProp_ByteArr_AsString(oAppointment, Prop_PR_STORE_ENTRYID);
            oAppointmentData.EntryId = GetExtendedProp_ByteArr_AsString(oAppointment, Prop_PR_ENTRYID);
            oAppointmentData.RetentionDate = GetExtendedProp_DateTime_AsString(oAppointment, Prop_PR_RETENTION_DATE);
            oAppointmentData.IsHidden = GetExtendedProp_Bool_AsString(oAppointment, Prop_PR_IS_HIDDEN);
            oAppointmentData.LogTriggerAction = GetExtendedProp_String_AsString(oAppointment, LogTriggerAction);

            oAppointmentData.ParentFolderId = oAppointment.ParentFolderId.ToString();
  
            string sFolderPath = string.Empty;
            if (EwsFolderHelper.GetFolderPath(oAppointment.Service, oAppointment.ParentFolderId, ref sFolderPath))
                oAppointmentData.FolderPath = sFolderPath;
            else
                oAppointmentData.FolderPath = "";

               

            //if (oAppointment.AppointmentReplyTime != null) oAppointmentData.AppointmentReplyTime = oAppointment.AppointmentReplyTime.ToString();   Not being returned
            try
            {
                oAppointmentData.AllowNewTimeProposal = oAppointment.AllowNewTimeProposal.ToString();
            }
            catch (Exception ex)
            {
                oAppointmentData.AllowNewTimeProposal = "";
            }
            //if (oAppointment.AllowNewTimeProposal != null) oAppointmentData.AllowNewTimeProposal = oAppointment.AllowNewTimeProposal.ToString();
            if (oAppointment.AllowedResponseActions != null) oAppointmentData.AllowedResponseActions = oAppointment.AllowedResponseActions.ToString();
            oAppointmentData.AdjacentMeetingCount = oAppointment.AdjacentMeetingCount.ToString();
            oAppointmentData.AppointmentSequenceNumber = oAppointment.AppointmentSequenceNumber.ToString();
            try
            {
                oAppointmentData.Body = oAppointment.Body.Text;
            }
            catch (Exception ex)
            {
                oAppointmentData.Body = "";
            }
            oAppointmentData.Categories = oAppointment.Categories.ToString();
            // oAppointmentData.ConferenceType = oAppointment.ConferenceType.ToString();  Not being returned
            oAppointmentData.ConflictingMeetingCount = oAppointment.ConflictingMeetingCount.ToString();


            if (oAppointment.ConflictingMeetings != null)
            {
                oSB = new StringBuilder();
                foreach (Appointment a in oAppointment.ConflictingMeetings)
                {
                    oSB.AppendFormat("Subject: {0}  Start: {1}  End: {2}  UniqueId: {3} \r\n", a.Subject, a.Start, a.End, a.Id.UniqueId);
                }
                oAppointmentData.ConflictingMeetings = oSB.ToString();
            }
            else
                oAppointmentData.ConflictingMeetings = "";

            try
            {
                oAppointmentData.ConversationId = oAppointment.ConversationId.ToString();
            }
            catch (Exception ex)
            {
                oAppointmentData.ConversationId = "";
            }

            oAppointmentData.Culture = oAppointment.Culture.ToString();

            try
            {
                oAppointmentData.DateTimeReceived = oAppointment.DateTimeReceived.ToString();
            }
            catch (Exception ex)
            {
                oAppointmentData.DateTimeReceived = "";
            }

            oAppointmentData.Duration = oAppointment.Duration.ToString();
            oAppointmentData.EffectiveRights = oAppointment.EffectiveRights.ToString();

            if (oAppointmentData.ICalDateTimeStamp != null) oAppointmentData.ICalDateTimeStamp = oAppointment.ICalDateTimeStamp.ToString();
            if (oAppointmentData.ICalRecurrenceId != null) oAppointmentData.ICalRecurrenceId = oAppointment.ICalRecurrenceId.ToString();
 
            oAppointmentData.Importance = oAppointment.Importance.ToString();
            if (oAppointment.InReplyTo != null) oAppointmentData.InReplyTo = oAppointment.InReplyTo.ToString();
            if (oAppointment.InternetMessageHeaders != null) oAppointmentData.InternetMessageHeaders = oAppointment.InternetMessageHeaders.ToString();

            bool boolVal = false;
            if (oAppointment.TryGetProperty(Prop_PR_IS_HIDDEN, out boolVal))
                oAppointmentData.IsHidden = boolVal.ToString();
            else
                oAppointmentData.IsHidden = "";

            oAppointmentData.IsResponseRequested = oAppointment.IsResponseRequested.ToString();
            oAppointmentData.IsSubmitted = oAppointment.IsSubmitted.ToString();
            oAppointmentData.IsUnmodified = oAppointment.IsUnmodified.ToString();
            oAppointmentData.LegacyFreeBusyStatus = oAppointment.LegacyFreeBusyStatus.ToString();
            if (oAppointment.Location != null) oAppointmentData.Location = oAppointment.Location.ToString();
            oAppointmentData.MeetingRequestWasSent = oAppointment.MeetingRequestWasSent.ToString();
            if (oAppointment.MeetingWorkspaceUrl != null) oAppointmentData.MeetingWorkspaceUrl = oAppointment.MeetingWorkspaceUrl.ToString();

            try
            {
                oAppointmentData.MimeContent = oAppointment.MimeContent.ToString();
            }
            catch (Exception ex)
            {
                oAppointmentData.MimeContent = "";
            }
            //if (oAppointment.MimeContent != null) oAppointmentData.MimeContent = oAppointment.MimeContent.ToString();
            
            oAppointmentData.MyResponseType = oAppointment.MyResponseType.ToString();
            if (oAppointment.NetShowUrl != null) oAppointmentData.NetShowUrl = oAppointment.NetShowUrl;

            try
            {
                oAppointmentData.ReminderDueBy = oAppointment.ReminderDueBy.ToString();
            }
            catch (Exception ex)
            {
                oAppointmentData.ReminderDueBy = "";
            }

            oAppointmentData.ReminderMinutesBeforeStart = oAppointment.ReminderMinutesBeforeStart.ToString();

            if (oAppointment.Resources != null)
            {
                oSB = new StringBuilder();
                foreach (Attendee oAttendee in oAppointment.Resources)
                    oSB.AppendFormat("{0} <{1}>;", oAttendee.Name, oAttendee.Address);
            }

            if (oAppointmentData.Resources != null) oAppointmentData.Resources = oAppointment.Resources.ToString();
            oAppointmentData.Size = oAppointment.Size.ToString();
            if (oAppointment.StartTimeZone != null) oAppointmentData.StartTimeZone = oAppointment.StartTimeZone.ToString();
            oAppointmentData.Sensitivity = oAppointment.Sensitivity.ToString();

            //oAppointment.Body
            try
            {
                oAppointmentData.TextBody = oAppointment.TextBody;
            }
            catch (Exception ex)
            {
                oAppointmentData.TextBody = "";
            }

            if (oAppointment.When != null) oAppointmentData.When = oAppointment.When.ToString();
            
            try
            { 
                oAppointmentData.WebClientEditFormQueryString = oAppointment.WebClientEditFormQueryString.ToString();
            }
            catch (Exception ex)
            {
                oAppointmentData.WebClientEditFormQueryString = "";
            }

            try
            { 
                oAppointmentData.WebClientReadFormQueryString = oAppointment.WebClientReadFormQueryString.ToString();
            }
            catch (Exception ex)
            {
                oAppointmentData.WebClientReadFormQueryString = "";
            }

            oAppointmentData.UniqueId = oAppointment.Id.UniqueId;

            SetAppointmentRecurrenceData(oAppointment, ref oAppointmentData);

            //string s = AppointmentHelper.GetAttendeeStatusAsInfoString(oAppointment);
            oAppointmentData.AttendeeStatus = AppointmentHelper.GetAttendeeStatusAsInfoString(oAppointment);
        }


        private string GetExtendedProp_DateTime_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            DateTime oDateTime;

            string sReturn = "";
            if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oDateTime))
                sReturn = oDateTime.ToString();
            else
                sReturn = "";
            return sReturn;
        }

        private string GetExtendedProp_ByteArr_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            byte[] bytearrVal;

            string sReturn = "";
            if (oItem.TryGetProperty(oExtendedPropertyDefinition, out bytearrVal))  // Example: CleanGlobalObjectId
                sReturn = Convert.ToBase64String(bytearrVal);  // reverse: Convert.FromBase64String(string data)
            else
                sReturn = "";
            return sReturn;
        }

        private string GetExtendedProp_String_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            string sString = string.Empty;

            string sReturn = "";
            if (oItem.TryGetProperty(oExtendedPropertyDefinition, out sString))
                sReturn = sString;
            else
                sReturn = "";
            return sReturn;
        }

        private string GetExtendedProp_Int_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            int lVal = 0;

            string sReturn = "";
            if (oItem.TryGetProperty(oExtendedPropertyDefinition, out lVal))
                sReturn = lVal.ToString();
            else
                sReturn = "";
            return sReturn;
        }

        private string GetExtendedProp_Bool_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            bool bVal = false;

            string sReturn = "";
            if (oItem.TryGetProperty(oExtendedPropertyDefinition, out bVal))
                sReturn = bVal.ToString();
            else
                sReturn = "";
            return sReturn;
        }

        private void SetAppointmentRecurrenceData(Appointment oAppointment, ref AppointmentData oAppointmentData)
        {
            //  Recurrence  -----------------------------------------------------------------------

            if (oAppointment.Recurrence != null)
            {

                oAppointmentData.StartingDateRange = oAppointment.Recurrence.StartDate.ToString();
                oAppointmentData.RecurrStartTime = oAppointment.Recurrence.StartDate.ToString();

                if (oAppointment.Recurrence.EndDate.HasValue)
                    oAppointmentData.RecurrEndTime = oAppointment.Recurrence.EndDate.ToString();
                else
                    oAppointmentData.RecurrEndTime = oAppointment.Recurrence.StartDate.ToString();

                if (oAppointment.Recurrence is Recurrence.DailyPattern)
                {
                    oAppointmentData.RecurrencePattern = "DailyPattern";
                    Recurrence.DailyPattern o = (Recurrence.DailyPattern)oAppointment.Recurrence;

                    oAppointmentData.RecurrencePatternInterval = o.Interval.ToString();
              
                    o = null;
                }

                if (oAppointment.Recurrence is Recurrence.WeeklyPattern)
                {
                    oAppointmentData.RecurrencePattern = "WeeklyPattern";
                    Recurrence.WeeklyPattern o = (Recurrence.WeeklyPattern)oAppointment.Recurrence;

                    oAppointmentData.RecurrencePatternInterval = o.Interval.ToString();

                  

                    foreach (DayOfTheWeek dotw in o.DaysOfTheWeek)
                    {
                        switch (dotw)
                        {
                            case DayOfTheWeek.Sunday:
                                oAppointmentData.RecurrencePatternDaysOfTheWeek += "Sunday, ";
                                break;
                            case DayOfTheWeek.Monday:
                                oAppointmentData.RecurrencePatternDaysOfTheWeek += "Monday, ";
                                break;
                            case DayOfTheWeek.Tuesday:
                                oAppointmentData.RecurrencePatternDaysOfTheWeek += "Tuesday, ";
                                break;
                            case DayOfTheWeek.Wednesday:
                                oAppointmentData.RecurrencePatternDaysOfTheWeek += "Wednesday, ";
                                break;
                            case DayOfTheWeek.Thursday:
                                oAppointmentData.RecurrencePatternDaysOfTheWeek += "Thursday, ";
                                break;
                            case DayOfTheWeek.Friday:
                                oAppointmentData.RecurrencePatternDaysOfTheWeek += "Friday, ";
                                break;
                            case DayOfTheWeek.Saturday:
                                oAppointmentData.RecurrencePatternDaysOfTheWeek += "Saturday, ";
                                break;
                            default:
                                break;
                        }
                    }

                    if (oAppointmentData.RecurrencePatternDaysOfTheWeek.EndsWith(", "))
                        oAppointmentData.RecurrencePatternDaysOfTheWeek = oAppointmentData.RecurrencePatternDaysOfTheWeek.Remove(oAppointmentData.RecurrencePatternDaysOfTheWeek.Length - 2, 2);
                    o = null;

                }

                if (oAppointment.Recurrence is Recurrence.MonthlyPattern)
                {
                    oAppointmentData.RecurrencePattern = "MonthlyPattern";

                    Recurrence.MonthlyPattern o = (Recurrence.MonthlyPattern)oAppointment.Recurrence;
                    oAppointmentData.RecurrMonthlyPatternDayOfMonth = o.DayOfMonth.ToString();
                    oAppointmentData.RecurrMonthlyPatternEveryMonths = o.Interval.ToString();

                     
                }

                if (oAppointment.Recurrence is Recurrence.RelativeMonthlyPattern)
                {
                    oAppointmentData.RecurrencePattern = "RelativeMonthlyPattern";

                    Recurrence.RelativeMonthlyPattern o = (Recurrence.RelativeMonthlyPattern)oAppointment.Recurrence;

                    oAppointmentData.RecurrDayOfTheWeekIndex = o.DayOfTheWeekIndex.ToString();
                    oAppointmentData.RecurrDayOfWeek = o.DayOfTheWeek.ToString();
                    oAppointmentData.RecurrInterval = o.Interval.ToString();
                   
                }

                if (oAppointment.Recurrence is Recurrence.YearlyPattern)
                {
                    oAppointmentData.RecurrencePattern = "YearlyPattern";

                    Recurrence.YearlyPattern o = (Recurrence.YearlyPattern)oAppointment.Recurrence;

                    oAppointmentData.RecurrYearlyOnSpecificDay = o.DayOfMonth.ToString();

                    oAppointmentData.RecurrYearlyOnSpecificDayForMonthOf = Enum.GetName(typeof(Month), o.Month);
                
                    o = null;
                }

                if (oAppointment.Recurrence is Recurrence.RelativeYearlyPattern)
                {
                    oAppointmentData.RecurrencePattern = "RelativeYearlyPattern";

                    Recurrence.RelativeYearlyPattern o = (Recurrence.RelativeYearlyPattern)oAppointment.Recurrence;

                    oAppointmentData.RecurrYearlyOnDayPatternDayOfWeekIndex = o.DayOfTheWeekIndex.ToString();
                    oAppointmentData.RecurrYearlyOnDayPatternDayOfWeekIndex = Enum.GetName(typeof(DayOfTheWeekIndex), o.DayOfTheWeekIndex);
                    oAppointmentData.RecurrYearlyOnDayPatternDayOfWeek = Enum.GetName(typeof(DayOfTheWeek), o.DayOfTheWeek);
                    oAppointmentData.RecurrYearlyOnDayPatternMonth = Enum.GetName(typeof(Month), o.Month);
                   
                    o = null;
                }

                // Range
                if (oAppointment.Recurrence.HasEnd == true)
                {
                    oAppointmentData.RangeHasEnd = oAppointment.Recurrence.HasEnd.ToString();
                    oAppointmentData.RangeNumberOccurrences = "";
                    oAppointmentData.RangeEndByDate = "";
                    //RangeEndByDate = oAppointment.Recurrence.EndDate.Value;  // ??
                }
                else
                {

                    if (oAppointment.Recurrence.NumberOfOccurrences.HasValue)
                    {
                        oAppointmentData.RangeNumberOccurrences = oAppointment.Recurrence.NumberOfOccurrences.ToString();
                    }
                    else
                    {
                        oAppointmentData.RangeNumberOccurrences = "";
                        if (oAppointment.Recurrence.EndDate.HasValue)
                        {
                            oAppointmentData.RangeEndByDate = oAppointment.Recurrence.EndDate.ToString();
                        }
                    }
                }


                if (oAppointment.Recurrence is Recurrence.MonthlyPattern)
                {
                    oAppointmentData.RecurrencePattern = "MonthlyPattern";

                    Recurrence.MonthlyPattern o = (Recurrence.MonthlyPattern)oAppointment.Recurrence;
                    oAppointmentData.RecurrMonthlyPatternDayOfMonth = o.DayOfMonth.ToString();
                    oAppointmentData.RecurrMonthlyPatternEveryMonths = o.Interval.ToString();

                }

                if (oAppointment.Recurrence is Recurrence.RelativeMonthlyPattern)
                {
                    oAppointmentData.RecurrencePattern = "RelativeMonthlyPattern";

                    Recurrence.RelativeMonthlyPattern o = (Recurrence.RelativeMonthlyPattern)oAppointment.Recurrence;

                    oAppointmentData.RecurrDayOfTheWeekIndex = o.DayOfTheWeekIndex.ToString();
                    oAppointmentData.RecurrDayOfWeek = o.DayOfTheWeek.ToString();
                    oAppointmentData.RecurrInterval = o.Interval.ToString();

                }

                if (oAppointment.Recurrence is Recurrence.YearlyPattern)
                {
                    oAppointmentData.RecurrencePattern = "YearlyPattern";

                    Recurrence.YearlyPattern o = (Recurrence.YearlyPattern)oAppointment.Recurrence;

                    oAppointmentData.RecurrYearlyOnSpecificDay = o.DayOfMonth.ToString();

                    oAppointmentData.RecurrYearlyOnSpecificDayForMonthOf = Enum.GetName(typeof(Month), o.Month);

                    o = null;
                }

                if (oAppointment.Recurrence is Recurrence.RelativeYearlyPattern)
                {
                    oAppointmentData.RecurrencePattern = "RelativeYearlyPattern";

                    Recurrence.RelativeYearlyPattern o = (Recurrence.RelativeYearlyPattern)oAppointment.Recurrence;

                    oAppointmentData.RecurrYearlyOnDayPatternDayOfWeekIndex = o.DayOfTheWeekIndex.ToString();
                    oAppointmentData.RecurrYearlyOnDayPatternDayOfWeekIndex = Enum.GetName(typeof(DayOfTheWeekIndex), o.DayOfTheWeekIndex);
                    oAppointmentData.RecurrYearlyOnDayPatternDayOfWeek = Enum.GetName(typeof(DayOfTheWeek), o.DayOfTheWeek);
                    oAppointmentData.RecurrYearlyOnDayPatternMonth = Enum.GetName(typeof(Month), o.Month);

                    o = null;
                }

                // Range
                if (oAppointment.Recurrence.HasEnd == true)
                {
                    oAppointmentData.RangeHasEnd = oAppointment.Recurrence.HasEnd.ToString();
                    oAppointmentData.RangeNumberOccurrences = "";
                    oAppointmentData.RangeEndByDate = "";
                    //RangeEndByDate = oAppointment.Recurrence.EndDate.Value;  // ??
                }
                else
                {

                    if (oAppointment.Recurrence.NumberOfOccurrences.HasValue)
                    {
                        oAppointmentData.RangeNumberOccurrences = oAppointment.Recurrence.NumberOfOccurrences.ToString();
                    }
                    else
                    {
                        oAppointmentData.RangeNumberOccurrences = "";
                        if (oAppointment.Recurrence.EndDate.HasValue)
                            oAppointmentData.RangeEndByDate = oAppointment.Recurrence.EndDate.ToString();
                    }
                }
            }

        }


        public PropertySet GetCalendarPropset(string ExchangeVersion)
        {
            return GetCalendarPropset(ExchangeVersion, false, false, false);

            
        }

        public static PropertySet GetCalendarPropset(string ExchangeVersion, bool bIncludeAttachments, bool bIncludeBodies, bool bIncludeMime)
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
            //Appointment appDetailed = Appointment.Bind(service, app.Id, new PropertySet(BasePropertySet.FirstClassProperties) { RequestedBodyType = BodyType.Text });

            if (bIncludeBodies == true)
            {
                appointmentPropertySet.Add(AppointmentSchema.Body);
                appointmentPropertySet.Add(AppointmentSchema.TextBody);
    
                //appointmentPropertySet.Add(AppointmentSchema.NormalizedBody);
                //appointmentPropertySet.Add(AppointmentSchema.UniqueBody);    
            }
            if (bIncludeMime == true)
                appointmentPropertySet.Add(AppointmentSchema.MimeContent);
                             

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
              
            //      AppointmentSchema.EnhancedLocation,             2013+
            //      AppointmentSchema.EntityExtractionResult,       2013+
            //      AppointmentSchema.Flag,                         2013+
            //      AppointmentSchema.IconIndex,                    2013+                +
            //      AppointmentSchema.InstanceKey,                  2013+                +
 
            //      AppointmentSchema.JoinOnlineMeetingUrl,         2013+
            //      AppointmentSchema.NormalizedBody,               2013+
            //      AppointmentSchema.OnlineMeetingSettings,        2013+
            //      AppointmentSchema.PolicyTag,                    2013+                +
            //      AppointmentSchema.Preview,                      2013+
            //      AppointmentSchema.RetentionDate,                2013+                +
            //      AppointmentSchema.StoreEntryId,                 2013+                +
            //      AppointmentSchema.TextBody,                     2013+

            //      AppointmentSchema.ConversationId                2010+                +
            //      AppointmentSchema.EndTimeZone,                  2010+  
            //      AppointmentSchema.IsAssociated,                 2010+
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

            if (!ExchangeVersion.StartsWith("Exchange_2007"))
            {
                // Already accounted for.

            }
            else
            {
                // 2010 and above...

                appointmentPropertySet.Add(AppointmentSchema.ConversationId);
                appointmentPropertySet.Add(AppointmentSchema.EndTimeZone);
                appointmentPropertySet.Add(AppointmentSchema.IsAssociated);
                appointmentPropertySet.Add(AppointmentSchema.UniqueBody);
                appointmentPropertySet.Add(AppointmentSchema.UniqueBody);
                appointmentPropertySet.Add(AppointmentSchema.WebClientEditFormQueryString);
                appointmentPropertySet.Add(AppointmentSchema.WebClientReadFormQueryString);
 
                if (!ExchangeVersion.StartsWith("Exchange_2010"))  // after 2010 (2013, 2016, etc.)
                {
                    // appointmentPropertySet.Add(AppointmentSchema.ArchiveTag);           // covered by extended property
                    appointmentPropertySet.Add(AppointmentSchema.EnhancedLocation);
                    appointmentPropertySet.Add(AppointmentSchema.EntityExtractionResult);
                    appointmentPropertySet.Add(AppointmentSchema.Flag);
                    appointmentPropertySet.Add(AppointmentSchema.IconIndex);
                    appointmentPropertySet.Add(AppointmentSchema.InstanceKey);
                    appointmentPropertySet.Add(AppointmentSchema.JoinOnlineMeetingUrl);
                    if (bIncludeBodies == true) 
                        appointmentPropertySet.Add(AppointmentSchema.NormalizedBody);
                    appointmentPropertySet.Add(AppointmentSchema.OnlineMeetingSettings);
                    //appointmentPropertySet.Add(AppointmentSchema.PolicyTag);            // covered by extended property
                    appointmentPropertySet.Add(AppointmentSchema.Preview);
                    //appointmentPropertySet.Add(AppointmentSchema.RetentionDate);        // covered by extended property
                    //appointmentPropertySet.Add(AppointmentSchema.StoreEntryId);         // covered by extended property
                    appointmentPropertySet.Add(AppointmentSchema.TextBody);
 
                }
            }

            return appointmentPropertySet;
        }

        public List<string> GetAppointmentDataAsList(AppointmentData oAppointmentData)
        {
            List<string> o = new List<string> { };
 
            o.Add(oAppointmentData.UniqueId);
            o.Add(oAppointmentData.FolderPath);
            o.Add(oAppointmentData.OrganizerName);
            o.Add(oAppointmentData.OrganizerAddress);
            o.Add(oAppointmentData.ParentFolderId);

            o.Add(oAppointmentData.Subject);
            o.Add(oAppointmentData.DisplayTo);

            if (oAppointmentData.DisplayCc != null)
                o.Add(oAppointmentData.DisplayCc);
            else
                o.Add("");

            o.Add(oAppointmentData.RequiredAttendees);
            o.Add(oAppointmentData.OptionalAttendees);

            o.Add(oAppointmentData.DateTimeCreated);

            o.Add(oAppointmentData.LastModifiedName);
            o.Add(oAppointmentData.LastModifiedTime);
            o.Add(oAppointmentData.HasAttachments);
            o.Add(oAppointmentData.ItemClass);
            o.Add(oAppointmentData.Start);
            o.Add(oAppointmentData.End);

            o.Add(oAppointmentData.IsAllDayEvent);
            o.Add(oAppointmentData.IsCancelled);
            o.Add(oAppointmentData.AppointmentState);
            o.Add(oAppointmentData.AppointmentType);

            o.Add(oAppointmentData.IsRecurring);
            o.Add(oAppointmentData.IsReminderSet);
            o.Add(oAppointmentData.IsOnlineMeeting);
            o.Add(oAppointmentData.RetentionDate);

 
            o.Add(oAppointmentData.IsResend);
            o.Add(oAppointmentData.IsDraft);

            o.Add(oAppointmentData.EntryId);
            o.Add(oAppointmentData.StoreEntryId);

            o.Add(oAppointmentData.PidLidAppointmentRecur);
            o.Add(oAppointmentData.PidLidClientIntent);
            o.Add(oAppointmentData.ClientInfoString);
            o.Add(oAppointmentData.LogTriggerAction);
            o.Add(oAppointmentData.PidLidCleanGlobalObjectId);
            o.Add(oAppointmentData.PidLidGlobalObjectId);
            o.Add(oAppointmentData.IsHidden);

            o.Add(oAppointmentData.AppointmentReplyTime);
            o.Add(oAppointmentData.AllowNewTimeProposal);
            o.Add(oAppointmentData.AllowedResponseActions);
            o.Add(oAppointmentData.AdjacentMeetingCount);
            o.Add(oAppointmentData.AppointmentSequenceNumber);
            if (oAppointmentData.Body != null)
                o.Add(oAppointmentData.Body);
            else
                o.Add("");
            o.Add(oAppointmentData.Categories);
            o.Add(oAppointmentData.ConferenceType);
            o.Add(oAppointmentData.ConflictingMeetingCount);
            o.Add(oAppointmentData.ConflictingMeetings);
            if (oAppointmentData.ConversationId != null)
                o.Add(oAppointmentData.ConversationId);
            else
                o.Add("");
            o.Add(oAppointmentData.Culture);
            o.Add(oAppointmentData.DateTimeReceived);
            o.Add(oAppointmentData.Duration);
            o.Add(oAppointmentData.EffectiveRights);
    
            o.Add(oAppointmentData.ICalDateTimeStamp);
            o.Add(oAppointmentData.ICalRecurrenceId);
            o.Add(oAppointmentData.ICalUid);
            o.Add(oAppointmentData.Importance);
            o.Add(oAppointmentData.InReplyTo);
            o.Add(oAppointmentData.InternetMessageHeaders);
            o.Add(oAppointmentData.IsResponseRequested);
            o.Add(oAppointmentData.IsSubmitted);
            o.Add(oAppointmentData.IsUnmodified);
            o.Add(oAppointmentData.LegacyFreeBusyStatus);
            o.Add(oAppointmentData.Location);
            o.Add(oAppointmentData.MeetingRequestWasSent);
            o.Add(oAppointmentData.MeetingWorkspaceUrl);
            o.Add(oAppointmentData.MimeContent);
            o.Add(oAppointmentData.MyResponseType);
            o.Add(oAppointmentData.NetShowUrl);
            o.Add(oAppointmentData.ModifiedOccurrences);
            o.Add(oAppointmentData.ReminderDueBy);
            o.Add(oAppointmentData.ReminderMinutesBeforeStart);
            o.Add(oAppointmentData.Resources);
            o.Add(oAppointmentData.Size);
            o.Add(oAppointmentData.StartTimeZone);
            o.Add(oAppointmentData.Sensitivity);
            o.Add(oAppointmentData.TextBody);
            o.Add(oAppointmentData.When);
            o.Add(oAppointmentData.WebClientEditFormQueryString);
            o.Add(oAppointmentData.WebClientReadFormQueryString);
 
            o.Add(oAppointmentData.StartingDateRange);
            o.Add(oAppointmentData.RecurrStartTime);
            o.Add(oAppointmentData.RecurrEndTime);
            o.Add(oAppointmentData.RecurrencePattern);
            o.Add(oAppointmentData.RecurrencePatternInterval);
            o.Add(oAppointmentData.RecurrencePatternDaysOfTheWeek);
            o.Add(oAppointmentData.RecurrMonthlyPatternDayOfMonth);
            o.Add(oAppointmentData.RecurrMonthlyPatternEveryMonths);
            o.Add(oAppointmentData.RecurrDayOfTheWeekIndex);
            o.Add(oAppointmentData.RecurrDayOfWeek);
            o.Add(oAppointmentData.RecurrInterval);
            o.Add(oAppointmentData.RecurrYearlyOnSpecificDay);
            o.Add(oAppointmentData.RecurrYearlyOnSpecificDayForMonthOf);
            o.Add(oAppointmentData.RecurrYearlyOnDayPatternDayOfWeekIndex);
            o.Add(oAppointmentData.RecurrYearlyOnDayPatternDayOfWeek);
            o.Add(oAppointmentData.RecurrYearlyOnDayPatternMonth);
            o.Add(oAppointmentData.RangeHasEnd);
            o.Add(oAppointmentData.RangeNumberOccurrences);
            o.Add(oAppointmentData.RangeEndByDate);

            return o;
        }

        public string GetAppointmentDataAsCsv2(AppointmentData oAppointmentData)
        {
            string sRet = string.Empty;
            char[] TrimChars = { ',', ' ' };

            List<string> h = GetAppointmentDataHeadersAsList();
            List<string> d = GetAppointmentDataAsList(oAppointmentData);

            string ToText = string.Empty;
            byte[] oFromBytes = null;

            for (int i = 0; i < d.Count - 1; i++)
            {
                // Some fields need to be base64 encoded.
                if (h[i] == "Body" || h[i] == "MimeContent" || h[i] == "TextBody" || h[i] == "ConversationIndex")
                {
                    oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(d[i]);
                    ToText = System.Convert.ToBase64String(oFromBytes);

                    d[i] = ToText;
                }
                else
                {
                    //string x = h[i];
                    if (d[i] != null)
                        d[i] = d[i].Replace(',', ' ');
                    else
                        d[i] = "";
                }
            }

            StringBuilder oSB = new StringBuilder();
            for (int i = 0; i < d.Count - 1; i++)
            {
                oSB.AppendFormat("{0}, ", d[i]);
            }

            sRet = oSB.ToString();
            sRet = sRet.TrimEnd(TrimChars); // remove last comma
            sRet = sRet.Replace("\r\n", "");
            return sRet;

        }

        public string GetAppointmentDataAsCsv(AppointmentData oAppointmentData)
        {
            char[] TrimChars = { ',', ' ' };
            string sRet = string.Empty;
            List<string> o = new List<string> { };
 
            o.Add(oAppointmentData.UniqueId.Replace(',', ' '));
            o.Add(oAppointmentData.FolderPath.Replace(',', ' '));
            o.Add(oAppointmentData.OrganizerName.Replace(',', ' '));
            o.Add(oAppointmentData.OrganizerAddress.Replace(',', ' '));
            o.Add(oAppointmentData.ParentFolderId.Replace(',', ' '));

            o.Add(oAppointmentData.Subject.Replace(',', ' '));
            o.Add(oAppointmentData.DisplayTo.Replace(',', ' '));

            if (oAppointmentData.DisplayCc != null)
                o.Add(oAppointmentData.DisplayCc.Replace(',', ' '));
            else
                o.Add("");

            o.Add(oAppointmentData.RequiredAttendees.Replace(',', ' '));
            o.Add(oAppointmentData.OptionalAttendees.Replace(',', ' '));

            o.Add(oAppointmentData.DateTimeCreated.Replace(',', ' '));

            o.Add(oAppointmentData.LastModifiedName.Replace(',', ' '));
            o.Add(oAppointmentData.LastModifiedTime.Replace(',', ' '));
            o.Add(oAppointmentData.HasAttachments.Replace(',', ' '));
            o.Add(oAppointmentData.ItemClass.Replace(',', ' '));
            o.Add(oAppointmentData.Start.Replace(',', ' '));
            o.Add(oAppointmentData.End.Replace(',', ' '));

            o.Add(oAppointmentData.IsAllDayEvent.Replace(',', ' '));
            o.Add(oAppointmentData.IsCancelled.Replace(',', ' '));
            o.Add(oAppointmentData.AppointmentState.Replace(',', ' '));
            o.Add(oAppointmentData.AppointmentType.Replace(',', ' '));

            o.Add(oAppointmentData.IsRecurring.Replace(',', ' '));
            o.Add(oAppointmentData.IsReminderSet.Replace(',', ' '));
            o.Add(oAppointmentData.IsOnlineMeeting.Replace(',', ' '));
            o.Add(oAppointmentData.RetentionDate.Replace(',', ' '));

 
            o.Add(oAppointmentData.IsResend.Replace(',', ' '));
            o.Add(oAppointmentData.IsDraft.Replace(',', ' '));

            o.Add(oAppointmentData.EntryId.Replace(',', ' '));
            o.Add(oAppointmentData.StoreEntryId.Replace(',', ' '));

            o.Add(oAppointmentData.PidLidAppointmentRecur.Replace(',', ' '));
            o.Add(oAppointmentData.PidLidClientIntent.Replace(',', ' '));
            o.Add(oAppointmentData.ClientInfoString.Replace(',', ' '));
            o.Add(oAppointmentData.LogTriggerAction.Replace(',', ' '));
            o.Add(oAppointmentData.PidLidCleanGlobalObjectId.Replace(',', ' '));
            o.Add(oAppointmentData.PidLidGlobalObjectId.Replace(',', ' '));
            o.Add(oAppointmentData.IsHidden.Replace(',', ' '));

            o.Add(oAppointmentData.AppointmentReplyTime.Replace(',', ' '));
            o.Add(oAppointmentData.AllowNewTimeProposal.Replace(',', ' '));
            o.Add(oAppointmentData.AllowedResponseActions.Replace(',', ' '));
            o.Add(oAppointmentData.AdjacentMeetingCount.Replace(',', ' '));
            o.Add(oAppointmentData.AppointmentSequenceNumber.Replace(',', ' '));
            if (oAppointmentData.Body != null)
                o.Add(oAppointmentData.Body.Replace(',', ' '));
            else
                o.Add("");
            o.Add(oAppointmentData.Categories.Replace(',', ' '));
            o.Add(oAppointmentData.ConferenceType.Replace(',', ' '));
            o.Add(oAppointmentData.ConflictingMeetingCount.Replace(',', ' '));
            o.Add(oAppointmentData.ConflictingMeetings.Replace(',', ' '));
            if (oAppointmentData.ConversationId != null)
                o.Add(oAppointmentData.ConversationId.Replace(',', ' '));
            else
                o.Add("");
            o.Add(oAppointmentData.Culture.Replace(',', ' '));
            o.Add(oAppointmentData.DateTimeReceived.Replace(',', ' '));
            o.Add(oAppointmentData.Duration.Replace(',', ' '));
            o.Add(oAppointmentData.EffectiveRights.Replace(',', ' '));
    
            o.Add(oAppointmentData.ICalDateTimeStamp.Replace(',', ' '));
            o.Add(oAppointmentData.ICalRecurrenceId.Replace(',', ' '));
            o.Add(oAppointmentData.ICalUid.Replace(',', ' '));
            o.Add(oAppointmentData.Importance.Replace(',', ' '));
            o.Add(oAppointmentData.InReplyTo.Replace(',', ' '));
            o.Add(oAppointmentData.InternetMessageHeaders.Replace(',', ' '));
            o.Add(oAppointmentData.IsResponseRequested.Replace(',', ' '));
            o.Add(oAppointmentData.IsSubmitted.Replace(',', ' '));
            o.Add(oAppointmentData.IsUnmodified.Replace(',', ' '));
            o.Add(oAppointmentData.LegacyFreeBusyStatus.Replace(',', ' '));
            o.Add(oAppointmentData.Location.Replace(',', ' '));
            o.Add(oAppointmentData.MeetingRequestWasSent.Replace(',', ' '));
            o.Add(oAppointmentData.MeetingWorkspaceUrl.Replace(',', ' '));
            o.Add(oAppointmentData.MimeContent.Replace(',', ' '));
            o.Add(oAppointmentData.MyResponseType.Replace(',', ' '));
            o.Add(oAppointmentData.NetShowUrl.Replace(',', ' '));
            o.Add(oAppointmentData.ModifiedOccurrences.Replace(',', ' '));
            o.Add(oAppointmentData.ReminderDueBy.Replace(',', ' '));
            o.Add(oAppointmentData.ReminderMinutesBeforeStart.Replace(',', ' '));
            o.Add(oAppointmentData.Resources.Replace(',', ' '));
            o.Add(oAppointmentData.Size.Replace(',', ' '));
            o.Add(oAppointmentData.StartTimeZone.Replace(',', ' '));
            o.Add(oAppointmentData.Sensitivity.Replace(',', ' '));
            o.Add(oAppointmentData.TextBody.Replace(',', ' '));
            o.Add(oAppointmentData.When.Replace(',', ' '));
            o.Add(oAppointmentData.WebClientEditFormQueryString.Replace(',', ' '));
            o.Add(oAppointmentData.WebClientReadFormQueryString.Replace(',', ' '));
 
            o.Add(oAppointmentData.StartingDateRange.Replace(',', ' '));
            o.Add(oAppointmentData.RecurrStartTime.Replace(',', ' '));
            o.Add(oAppointmentData.RecurrEndTime.Replace(',', ' '));
            o.Add(oAppointmentData.RecurrencePattern.Replace(',', ' '));
            o.Add(oAppointmentData.RecurrencePatternInterval.Replace(',', ' '));
            o.Add(oAppointmentData.RecurrencePatternDaysOfTheWeek.Replace(',', ' '));
            o.Add(oAppointmentData.RecurrMonthlyPatternDayOfMonth.Replace(',', ' '));
            o.Add(oAppointmentData.RecurrMonthlyPatternEveryMonths.Replace(',', ' '));
            o.Add(oAppointmentData.RecurrDayOfTheWeekIndex.Replace(',', ' '));
            o.Add(oAppointmentData.RecurrDayOfWeek.Replace(',', ' '));
            o.Add(oAppointmentData.RecurrInterval.Replace(',', ' '));
            o.Add(oAppointmentData.RecurrYearlyOnSpecificDay.Replace(',', ' '));
            o.Add(oAppointmentData.RecurrYearlyOnSpecificDayForMonthOf.Replace(',', ' '));
            o.Add(oAppointmentData.RecurrYearlyOnDayPatternDayOfWeekIndex.Replace(',', ' '));
            o.Add(oAppointmentData.RecurrYearlyOnDayPatternDayOfWeek.Replace(',', ' '));
            o.Add(oAppointmentData.RecurrYearlyOnDayPatternMonth.Replace(',', ' '));
            o.Add(oAppointmentData.RangeHasEnd.Replace(',', ' '));
            o.Add(oAppointmentData.RangeNumberOccurrences.Replace(',', ' '));
            o.Add(oAppointmentData.RangeEndByDate.Replace(',', ' '));

            // ...

            StringBuilder oSB = new StringBuilder();
            for (int i = 0; i < o.Count - 1; i++)
            {
                oSB.AppendFormat("{0}, ", o[i]);
            }

            sRet = oSB.ToString();
            sRet = sRet.TrimEnd(TrimChars);
            sRet = sRet.Replace("\r\n", "");  // There shold be no crlf
            return sRet;
        }

        public string GetAppointmentDataAsXml(AppointmentData oAppointmentData)
        {
            string sXML = string.Empty;
            List<string> h = GetAppointmentDataHeadersAsList();
            List<string> d = GetAppointmentDataAsList(oAppointmentData);

            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("AppointmentData");
            xmlDoc.AppendChild(rootNode);

            for (int i = 0; i < d.Count - 1; i++)
            {
                XmlNode dataNode = xmlDoc.CreateElement(h[i]);
                dataNode.InnerText = d[i];
                rootNode.AppendChild(dataNode);
            }

            sXML = xmlDoc.Value;
             
            return sXML;
        }

        public List<string> GetAppointmentDataHeadersAsList()
        {

            List<string> o = new List<string> { };
             

            o.Add("UniqueId");
            o.Add("FolderPath");
            o.Add("OrganizerName");
            o.Add("OrganizerAddress");
            o.Add("ParentFolderId");

            o.Add("Subject");
            o.Add("DisplayTo");


            o.Add("DisplayCc");

            o.Add("RequiredAttendees");
            o.Add("OptionalAttendees");

            o.Add("DateTimeCreated");

            o.Add("LastModifiedName");
            o.Add("LastModifiedTime");
            o.Add("HasAttachments");
            o.Add("ItemClass");
            o.Add("Start");
            o.Add("End");

            o.Add("IsAllDayEvent");
            o.Add("IsCancelled");
            o.Add("AppointmentState");
            o.Add("AppointmentType");

            o.Add("IsRecurring");
            o.Add("IsReminderSet");
            o.Add("IsOnlineMeeting");
            o.Add("RetentionDate");


            o.Add("IsResend");
            o.Add("IsDraft");

            o.Add("EntryId");
            o.Add("StoreEntryId");

            o.Add("PidLidAppointmentRecur");
            o.Add("PidLidClientIntent");
            o.Add("ClientInfoString");
            o.Add("LogTriggerAction");
            o.Add("PidLidCleanGlobalObjectId");
            o.Add("PidLidGlobalObjectId");
            o.Add("IsHidden");

            o.Add("AppointmentReplyTime");
            o.Add("AllowNewTimeProposal");
            o.Add("AllowedResponseActions");
            o.Add("AdjacentMeetingCount");
            o.Add("AppointmentSequenceNumber");
            o.Add("Body");
            o.Add("Categories");
            o.Add("ConferenceType");
            o.Add("ConflictingMeetingCount");
            o.Add("ConflictingMeetings");
            o.Add("ConversationId");

            o.Add("Culture");
            o.Add("DateTimeReceived");
            o.Add("Duration");
            o.Add("EffectiveRights");

            o.Add("ICalDateTimeStamp");
            o.Add("ICalRecurrenceId");
            o.Add("ICalUid");
            o.Add("Importance");
            o.Add("InReplyTo");
            o.Add("InternetMessageHeaders");
            o.Add("IsResponseRequested");
            o.Add("IsSubmitted");
            o.Add("IsUnmodified");
            o.Add("LegacyFreeBusyStatus");
            o.Add("Location");
            o.Add("MeetingRequestWasSent");
            o.Add("MeetingWorkspaceUrl");
            o.Add("MimeContent");
            o.Add("MyResponseType");
            o.Add("NetShowUrl");
            o.Add("ModifiedOccurrences");
            o.Add("ReminderDueBy");
            o.Add("ReminderMinutesBeforeStart");
            o.Add("Resources");
            o.Add("Size");
            o.Add("StartTimeZone");
            o.Add("Sensitivity");
            o.Add("TextBody");
            o.Add("When");
            o.Add("WebClientEditFormQueryString");
            o.Add("WebClientReadFormQueryString");

            o.Add("StartingDateRange");
            o.Add("RecurrStartTime");
            o.Add("RecurrEndTime");
            o.Add("RecurrencePattern");
            o.Add("RecurrencePatternInterval");
            o.Add("RecurrencePatternDaysOfTheWeek");
            o.Add("RecurrMonthlyPatternDayOfMonth");
            o.Add("RecurrMonthlyPatternEveryMonths");
            o.Add("RecurrDayOfTheWeekIndex");
            o.Add("RecurrDayOfWeek");
            o.Add("RecurrInterval");
            o.Add("RecurrYearlyOnSpecificDay");
            o.Add("RecurrYearlyOnSpecificDayForMonthOf");
            o.Add("RecurrYearlyOnDayPatternDayOfWeekIndex");
            o.Add("RecurrYearlyOnDayPatternDayOfWeek");
            o.Add("RecurrYearlyOnDayPatternMonth");
            o.Add("RangeHasEnd");
            o.Add("RangeNumberOccurrences");
            o.Add("RangeEndByDate");


            return o;
        }

        public string GetAppointmentDataAsCsvHeaders()
        {
            char[] TrimChars = { ',', ' ' };
            string sRet = string.Empty;

            List<string> o = GetAppointmentDataHeadersAsList();

            //List<string> o = new List<string> { };
            //o.Add("AllowedResponseActions");


            //o.Add("UniqueId");
            //o.Add("FolderPath");
            //o.Add("OrganizerName");
            //o.Add("OrganizerAddress");
            //o.Add("ParentFolderId");

            //o.Add("Subject");
            //o.Add("DisplayTo");


            //o.Add("DisplayCc");

            //o.Add("RequiredAttendees");
            //o.Add("OptionalAttendees");

            //o.Add("DateTimeCreated");

            //o.Add("LastModifiedName");
            //o.Add("LastModifiedTime");
            //o.Add("HasAttachments");
            //o.Add("ItemClass");
            //o.Add("Start");
            //o.Add("End");

            //o.Add("IsAllDayEvent");
            //o.Add("IsCancelled");
            //o.Add("AppointmentState");
            //o.Add("AppointmentType");

            //o.Add("IsRecurring");
            //o.Add("IsReminderSet");
            //o.Add("IsOnlineMeeting");
            //o.Add("RetentionDate");


            //o.Add("IsResend");
            //o.Add("IsDraft");

            //o.Add("EntryId");
            //o.Add("StoreEntryId");

            //o.Add("PidLidAppointmentRecur");
            //o.Add("PidLidClientIntent");
            //o.Add("ClientInfoString");
            //o.Add("LogTriggerAction");
            //o.Add("PidLidCleanGlobalObjectId");
            //o.Add("PidLidGlobalObjectId");
            //o.Add("IsHidden");

            //o.Add("AppointmentReplyTime");
            //o.Add("AllowNewTimeProposal");
            //o.Add("AllowedResponseActions");
            //o.Add("AdjacentMeetingCount");
            //o.Add("AppointmentSequenceNumber");
            //o.Add("Body");
            //o.Add("Categories");
            //o.Add("ConferenceType");
            //o.Add("ConflictingMeetingCount");
            //o.Add("ConflictingMeetings");
            //o.Add("ConversationId");

            //o.Add("Culture");
            //o.Add("DateTimeReceived");
            //o.Add("Duration");
            //o.Add("EffectiveRights");

            //o.Add("ICalDateTimeStamp");
            //o.Add("ICalRecurrenceId");
            //o.Add("ICalUid");
            //o.Add("Importance");
            //o.Add("InReplyTo");
            //o.Add("InternetMessageHeaders");
            //o.Add("IsResponseRequested");
            //o.Add("IsSubmitted");
            //o.Add("IsUnmodified");
            //o.Add("LegacyFreeBusyStatus");
            //o.Add("Location");
            //o.Add("MeetingRequestWasSent");
            //o.Add("MeetingWorkspaceUrl");
            //o.Add("MimeContent");
            //o.Add("MyResponseType");
            //o.Add("NetShowUrl");
            //o.Add("ModifiedOccurrences");
            //o.Add("ReminderDueBy");
            //o.Add("ReminderMinutesBeforeStart");
            //o.Add("Resources");
            //o.Add("Size");
            //o.Add("StartTimeZone");
            //o.Add("Sensitivity");
            //o.Add("TextBody");
            //o.Add("When");
            //o.Add("WebClientEditFormQueryString");
            //o.Add("WebClientReadFormQueryString");

            //o.Add("StartingDateRange");
            //o.Add("RecurrStartTime");
            //o.Add("RecurrEndTime");
            //o.Add("RecurrencePattern");
            //o.Add("RecurrencePatternInterval");
            //o.Add("RecurrencePatternDaysOfTheWeek");
            //o.Add("RecurrMonthlyPatternDayOfMonth");
            //o.Add("RecurrMonthlyPatternEveryMonths");
            //o.Add("RecurrDayOfTheWeekIndex");
            //o.Add("RecurrDayOfWeek");
            //o.Add("RecurrInterval");
            //o.Add("RecurrYearlyOnSpecificDay");
            //o.Add("RecurrYearlyOnSpecificDayForMonthOf");
            //o.Add("RecurrYearlyOnDayPatternDayOfWeekIndex");
            //o.Add("RecurrYearlyOnDayPatternDayOfWeek");
            //o.Add("RecurrYearlyOnDayPatternMonth");
            //o.Add("RangeHasEnd");
            //o.Add("RangeNumberOccurrences");
            //o.Add("RangeEndByDate");

            // ...

            StringBuilder oSB = new StringBuilder();
            for (int i = 0; i < o.Count - 1; i++)
            {
                oSB.AppendFormat("{0}, ", o[i]);
            }

            sRet = oSB.ToString();
            sRet = sRet.TrimEnd(TrimChars);

            return sRet;
        }


        //private string GetExtendedPropByteArrAsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        //{
        //    byte[] bytearrVal;

        //    string sReturn = "";
        //    if (oItem.TryGetProperty(oExtendedPropertyDefinition, out bytearrVal))  // Example: CleanGlobalObjectId
        //        sReturn = Convert.ToBase64String(bytearrVal);  // reverse: Convert.FromBase64String(string data)
        //    else
        //        sReturn = "";
        //    return sReturn;
        //}

 

    }
}
