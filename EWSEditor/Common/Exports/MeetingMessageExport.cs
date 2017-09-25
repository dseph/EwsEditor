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

using EWSEditor.PropertyInformation;

namespace EWSEditor.Common.Exports
{ 
    class MeetingMessageExport
    {
        private static ExtendedPropertyDefinition Prop_PR_FOLDER_PATH = new ExtendedPropertyDefinition(0x66B5, MapiPropertyType.String);   // Folder Path - PR_Folder_Path
        //private static ExtendedPropertyDefinition Prop_PR_FOLDER_TYPE = new ExtendedPropertyDefinition(0x3601, MapiPropertyType.Integer);  // PR_FOLDER_TYPE 0x3601 (13825)
        //private static ExtendedPropertyDefinition PidLidAppointmentRecur = new ExtendedPropertyDefinition(new Guid("00062002-0000-0000-C000-000000000046"), 0x8216, MapiPropertyType.Binary); // dispidApptRecur
        private static ExtendedPropertyDefinition PidLidClientIntent = new ExtendedPropertyDefinition(new Guid("11000E07-B51B-40D6-AF21-CAA85EDAB1D0"), 0x0015, MapiPropertyType.Integer); // dispidClientIntent
        private static ExtendedPropertyDefinition ClientInfoString = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x000B, MapiPropertyType.String); //  
        private static ExtendedPropertyDefinition LogTriggerAction = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x0006, MapiPropertyType.String); //  
        private static ExtendedPropertyDefinition PidLidCleanGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0023, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PidLidGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0003, MapiPropertyType.Binary);
        //private static ExtendedPropertyDefinition Prop_PR_START_DATE_ETC = new ExtendedPropertyDefinition(0x3019, MapiPropertyType.String); // PR_START_DATE_ETC  GUID 0x30190102

        //private static ExtendedPropertyDefinition Prop_PR_POLICY_TAG = new ExtendedPropertyDefinition(0x301B, MapiPropertyType.Binary);  // PR_POLICY_TAG 0x3019   Data type: PtypBinary, 0x0102
        //private static ExtendedPropertyDefinition Prop_PR_RETENTION_FLAGS = new ExtendedPropertyDefinition(0x301D, MapiPropertyType.Integer);   // PR_RETENTION_FLAGS 0x301D   
        //private static ExtendedPropertyDefinition Prop_PR_RETENTION_PERIOD = new ExtendedPropertyDefinition(0x301A, MapiPropertyType.Integer);  // PR_RETENTION_PERIOD 0x301A    
        //private static ExtendedPropertyDefinition Prop_PR_RETENTION_DATE = new ExtendedPropertyDefinition(0x301C, MapiPropertyType.SystemTime); // Prop_PR_RETENTION_DATE 0x301C    
        //private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_TAG = new ExtendedPropertyDefinition(0x3018, MapiPropertyType.Binary);
        //private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_PERIOD = new ExtendedPropertyDefinition(0x301E, MapiPropertyType.Integer); // Prop_PR_RETENTION_DATE 0x301C    
        //private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_DATE = new ExtendedPropertyDefinition(0x301F, MapiPropertyType.SystemTime);

        //private static ExtendedPropertyDefinition Prop_PR_START_DATE_ETC = new ExtendedPropertyDefinition(0x3019, MapiPropertyType.SystemTime); // PR_START_DATE_ETC SystemTime for items
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_PERIOD = new ExtendedPropertyDefinition(0x301A, MapiPropertyType.Integer);  // PR_RETENTION_PERIOD 0x301A    
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_DATE = new ExtendedPropertyDefinition(0x301C, MapiPropertyType.SystemTime); // Prop_PR_RETENTION_DATE 0x301C           
        private static ExtendedPropertyDefinition Prop_PR_POLICY_TAG = new ExtendedPropertyDefinition(0x301B, MapiPropertyType.Binary);  // PR_POLICY_TAG 0x3019   Data type: PtypBinary, 0x0102
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_FLAGS = new ExtendedPropertyDefinition(0x301D, MapiPropertyType.Integer);   // PR_RETENTION_FLAGS 0x301D   
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_TAG = new ExtendedPropertyDefinition(0x3018, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_PERIOD = new ExtendedPropertyDefinition(0x301E, MapiPropertyType.Integer); // Prop_PR_RETENTION_DATE 0x301C    
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_DATE = new ExtendedPropertyDefinition(0x301F, MapiPropertyType.SystemTime);



        private static ExtendedPropertyDefinition Prop_PR_ENTRYID = new ExtendedPropertyDefinition(0x0FFF, MapiPropertyType.Binary);  // PidTagEntryId, PidTagMemberEntryId, ptagEntryId
        private static ExtendedPropertyDefinition Prop_PR_STORE_ENTRYID = new ExtendedPropertyDefinition(0x0FFB, MapiPropertyType.Binary);  // PidTagStoreEntryId       
        private static ExtendedPropertyDefinition Prop_PR_IS_HIDDEN = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.Boolean);

        private static ExtendedPropertyDefinition PR_SENT_REPRESENTING_EMAIL_ADDRESS = new ExtendedPropertyDefinition(0x0065, MapiPropertyType.String);
        //private static ExtendedPropertyDefinition PR_SENDER_EMAIL_ADDRESS = new ExtendedPropertyDefinition(0x4030, MapiPropertyType.String);
        //private static ExtendedPropertyDefinition ptagSenderSimpleDispName = new ExtendedPropertyDefinition(0x0C1F, MapiPropertyType.String);
        private static ExtendedPropertyDefinition PR_PARENT_ENTRYID = new ExtendedPropertyDefinition(0x0E09, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PR_MESSAGE_FLAGS = new ExtendedPropertyDefinition(0x0E07, MapiPropertyType.Integer); // PT_LONG
        private static ExtendedPropertyDefinition PR_MSG_STATUS = new ExtendedPropertyDefinition(0x0E17, MapiPropertyType.Integer);// PT_LONG
        private static ExtendedPropertyDefinition PR_MESSAGE_DELIVERY_TIME = new ExtendedPropertyDefinition(0x0E06, MapiPropertyType.Binary);   // PT_SYSTIME  
        private static ExtendedPropertyDefinition PR_CONVERSATION_TOPIC = new ExtendedPropertyDefinition(0x0070, MapiPropertyType.String);
        private static ExtendedPropertyDefinition PR_CONVERSATION_ID = new ExtendedPropertyDefinition(0x3013, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PPR_CONVERSATION_INDEX = new ExtendedPropertyDefinition(0x0071, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PR_CONTROL_FLAGS = new ExtendedPropertyDefinition(0x3F00, MapiPropertyType.Integer);// PT_LONG

        // New:
//        private static ExtendedPropertyDefinition PidLidCurrentVersion = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x00008552, MapiPropertyType.Integer);
        private static ExtendedPropertyDefinition PidLidCurrentVersionName = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x00008554, MapiPropertyType.String);
        private static ExtendedPropertyDefinition PidNameCalendarUid = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x001F, MapiPropertyType.String);
        private static ExtendedPropertyDefinition PidLidOrganizerAlias = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008243, MapiPropertyType.String);
        private static ExtendedPropertyDefinition PidTagSenderSmtpAddress = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x5D01, MapiPropertyType.String);   

        private static ExtendedPropertyDefinition PidLidInboundICalStream = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x0102, MapiPropertyType.Binary);

        private static ExtendedPropertyDefinition PidLidAppointmentAuxiliaryFlags = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008207, MapiPropertyType.Integer);
        private static ExtendedPropertyDefinition PidLidRecurrencePattern = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008232, MapiPropertyType.String);
        private static ExtendedPropertyDefinition PidLidRecurrenceType = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008231, MapiPropertyType.Integer);
        private static ExtendedPropertyDefinition PidLidRecurring = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008223, MapiPropertyType.Boolean); // "dispidRecurring, http://schemas.microsoft.com/mapi/recurring", "Calendar", "[MS-OXCDATA], [MS-OXCICAL], [MS-OXOCAL], [MS-OXOSFLD], [MS-OXWAVLS], [MS-XWDCAL]"));
        private static ExtendedPropertyDefinition PidLidAppointmentRecur = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008216, MapiPropertyType.Binary); // "dispidApptRecur, http://schemas.microsoft.com/mapi/apptrecur", "Calendar", "[MS-OXCICAL], [MS-OXOCAL], [MS-OXORMDR], [MS-OXOTASK],[MS-XWDCAL]"));
        //private ExtendedPropertyDefinition PidLidAppointmentStartWhole = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x0000820D, MapiPropertyType.SystemTime); // "PidLidAppointmentStartWhole", "dispidApptStartWhole, http://schemas.microsoft.com/mapi/apptstartwhole", "Calendar", "[MS-OXCICAL], [MS-OXOCAL], [MS-OXOPFFB], [MS-XWDCAL]"));
        //private static ExtendedPropertyDefinition PidLidAppointmentStartDate = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008212, MapiPropertyType.SystemTime);
        //private static ExtendedPropertyDefinition PidLidAppointmentStartTime = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x0000820F, MapiPropertyType.SystemTime);

        public static ExtendedPropertyDefinition PidLidAppointmentStartWhole = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x0000820D, MapiPropertyType.SystemTime); // "PidLidAppointmentStartWhole", "dispidApptStartWhole, http://schemas.microsoft.com/mapi/apptstartwhole", "Calendar", "[MS-OXCICAL], [MS-OXOCAL], [MS-OXOPFFB], [MS-XWDCAL]"));
        public static ExtendedPropertyDefinition PidLidAppointmentEndWhole = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x0000820E, MapiPropertyType.SystemTime); // "PidLidAppointmentEndWhole", "dispidApptEndWhole, 
        
        private static ExtendedPropertyDefinition PidLidAppointmentStateFlags = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008217, MapiPropertyType.Integer);
        private static ExtendedPropertyDefinition PidNameFrom = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.InternetHeaders, "From", MapiPropertyType.String);  // PidNameFrom -  Its the Organizer.
        private static ExtendedPropertyDefinition PidNameHttpmailFrom = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.PublicStrings, "urn:schemas:httpmail:from", MapiPropertyType.String); // PidNameHttpmailFromEmail - 
        private static ExtendedPropertyDefinition PidNameHttpmailFromEmail = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.PublicStrings, "urn:schemas:httpmail:fromemail", MapiPropertyType.String); // PidNameHttpmailFromEmail          
        private static ExtendedPropertyDefinition PidTagSenderEmailAddress = new ExtendedPropertyDefinition(0x0C1F, MapiPropertyType.String); //  "PidTagSenderEmailAddress", "PR_SENDER_EMAIL_ADDRESS,PR_SENDER_EMAIL_ADDRESS_A, PR_SENDER_EMAIL_ADDRESS_W", "Address Properties", "[MS-OXCFXICS], [MS-OXCICAL], [MS-OXCSPAM], [MS-OXOMSG],[MS-OXORSS], [MS-OXOTASK], [MS-OXPSVAL], [MS-OXTNEF]"));        
        private static ExtendedPropertyDefinition PidTagSenderFlags = new ExtendedPropertyDefinition(0x4019, MapiPropertyType.Integer); // "PidTagSenderFlags", "ptagSenderFlags", "Miscellaneous Properties", "[MS-OXCFXICS], [MS-OXTNEF]")); 
        private static ExtendedPropertyDefinition PidTagSenderName = new ExtendedPropertyDefinition(0x0C1A, MapiPropertyType.String);  // 
        private static ExtendedPropertyDefinition PidTagSenderSimpleDisplayName = new ExtendedPropertyDefinition(0x4030, MapiPropertyType.String);  // "PidTagSenderName", "PR_SENDER_NAME, PR_SENDER_NAME_A, ptagSenderName,PR_SENDER_NAME_W, urn:schemas:httpmail:sendername,http://schemas.microsoft.com/exchange/sender-name-utf8", "Address Properties Property set", "[MS-OXCFXICS], [MS-OXCICAL], [MS-OXCSYNC], [MS-OXOCAL], [MS-OXOMSG], [MS-OXOPOST], [MS-OXORSS], [MS-OXOTASK], [MS-OXTNEF], [MS-XWDMAIL]")); 
        private static ExtendedPropertyDefinition PidTagSentRepresentingEmailAddress = new ExtendedPropertyDefinition(0x0065, MapiPropertyType.String); // PR_SENT_REPRESENTING_EMAIL_ADDRESS,PR_SENT_REPRESENTING_EMAIL_ADDRESS_A,PR_SENT_REPRESENTING_EMAIL_ADDRESS_W"
        private static ExtendedPropertyDefinition PidTagSentRepresentingFlags = new ExtendedPropertyDefinition(0x401A, MapiPropertyType.Integer);  // ptagSentRepresentingFlags
        private static ExtendedPropertyDefinition PidTagSentRepresentingName = new ExtendedPropertyDefinition(0x0042, MapiPropertyType.String);   // // ptagSentRepresentingName, PR_SENT_REPRESENTING_NAME,PR_SENT_REPRESENTING_NAME_A,PR_SENT_REPRESENTING_NAME_W        private string PidTagSentRepresentingSimpleDisplayName = new ExtendedPropertyDefinition(0x4031, MapiPropertyType.String);  // ptagSentRepresentingName, PR_SENT_REPRESENTING_NAME,PR_SENT_REPRESENTING_NAME_A,PR_SENT_REPRESENTING_NAME_W
        private static ExtendedPropertyDefinition PidTagSentRepresentingSimpleDisplayName = new ExtendedPropertyDefinition(0x4031, MapiPropertyType.String);  // PidTagSentRepresentingSimpleDisplayName", "ptagSentRepresentingSimpleDispName",  
        private static ExtendedPropertyDefinition PidTagProcessed = new ExtendedPropertyDefinition(0x7D01, MapiPropertyType.Boolean); // (PidTagProcessed, new KnownExtendedPropertyInfo("PidTagProcessed", "PR_PROCESSED", "Calendar", "[MS-OXCICAL], [MS-OXOCAL], [MS-OXOTASK]"));
     //   private static ExtendedPropertyDefinition PidLidResponseStatus = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008218, MapiPropertyType.Long); //"dispidResponseStatus, urn:schemas:calendar:attendeestatus,http://schemas.microsoft.com/mapi/responsestatus", "Meetings", "[MS-OXCICAL], [MS-OXOCAL], [MS-XWDCAL]"));
        private static ExtendedPropertyDefinition PidLidIsException = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0000000A, MapiPropertyType.Boolean); // "PidLidIsException", "LID_IS_EXCEPTION, http://schemas.microsoft.com/mapi/is_exception", "Meetings", "[MS-OXCICAL], [MS-OXOCAL], [MS-OXWAVLS], [MS-XWDCAL]")); 
 
// Replace1s
  // Replace1e

        private static ExtendedPropertyDefinition PidTagCreatorName = new ExtendedPropertyDefinition(0x3FF8, MapiPropertyType.String);  // "PidTagCreatorName", "PR_CREATOR_NAME, PR_CREATOR_NAME_A, ptagCreatorName,PR_CREATOR_NAME_W", "General Message Properties", "[MS-OXCFXICS], [MS-OXCMSG], [MS-OXTNEF]"));
        private static ExtendedPropertyDefinition PidTagCreatorSimpleDisplayName = new ExtendedPropertyDefinition(0x4038, MapiPropertyType.String);  // "PidTagCreatorSimpleDisplayName", "ptagCreatorSimpleDispName", "TransportEnvelope", "[MS-OXTNEF]"));
        private static ExtendedPropertyDefinition PidNameCalendarIsOrganizer = new ExtendedPropertyDefinition(new Guid("00062002-0000-0000-C000-000000000046"), 0x000B, MapiPropertyType.Boolean);  

        // https://msdn.microsoft.com/en-us/library/ee203019(v=exchg.80).aspx


        //PR_CreatorEmailAddr  http://schemas.microsoft.com/mapi/id/{11000E07-B51B-40D6-AF21-CAA85EDAB1D0}/000A001F) 
        // PSETID_CalendarAssistant = Guid("11000e07-b51b-40d6-af21-caa85edab1d0")  // http://stackoverflow.com/questions/30911510/getting-information-from-delegated-email-account-from-appointment-inspector-wind
  

        //public MeetingMessageData GetMeetingMessageDataFromItem(ExchangeService oExchangeService, ItemId oItemId)
        //{AdditionalPropertiesDefs
        //    MeetingMessageData oMeetingMessageData = GetMeetingMessageDataFromItem(oExchangeService, oItemId, false, faAdditionalPropertyDefinitionslse, false);
        //    return oMeetingMessageData;
        //}

 
        public MeetingMessageData GetMeetingMessageDataFromItem(
            ExchangeService oExchangeService, 
            ItemId oItemId,
            List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions,
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions,
            bool bIncludeBody, 
            bool bIncludeMime)
        {        
            string ServerVersion = oExchangeService.RequestedServerVersion.ToString();
            PropertySet oPropertySet = null;

            oPropertySet = GetMeetingMessageDataPropset(ServerVersion, bIncludeBody, bIncludeMime, oExtendedPropertyDefinitions);
            oExchangeService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            MeetingMessage oMeetingMessage = MeetingMessage.Bind(oExchangeService, oItemId, oPropertySet);
            MeetingMessageData oMeetingMessageData = new MeetingMessageData();

            SetMeetingMessageData(
                oMeetingMessage, 
                ref oMeetingMessageData,  
                oAdditionalPropertyDefinitions, 
                oExtendedPropertyDefinitions);
 
            return oMeetingMessageData;
 
        }
        public bool GetFolderPath(ref string sFolder)
        {
            bool bRet = false;
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.Description = "Pick an output folder to save the XML file to.";

            if (browser.ShowDialog() == DialogResult.OK)
            {
                sFolder = browser.SelectedPath;
                bRet = true;
            }
            else
                bRet = false;

            return bRet;
        }

   

        public bool SaveMeetingMessageBlobToFolder(ExchangeService oExchangeService, ItemId oItemId, string sFile)
        {
            string ServerVersion = oExchangeService.RequestedServerVersion.ToString();
            if (ServerVersion.StartsWith("Exchange2007") || ServerVersion == "Exchange2010")
            {
                MessageBox.Show("Exchange 2010 SP1 or later is requred to use ExportItems to do a blog export of an item.", "Invalid version for blog export using ExportItem");
                return false;
            }
            //string tempFile = Path.GetTempFileName().Replace(".tmp", ".bin");
            ////string sFile = sFolder + "\\MeetingMessage\\" + tempFile;
            //string sFile = sFolder + "\\" + tempFile;

            return EWSEditor.Exchange.ExportUploadHelper.ExportItemPost(ServerVersion, oItemId.UniqueId, sFile);

            //return SaveMeetingMessageBlobToFolder(oExchangeService, oItemId, sFolder, sFile);
        }

        //public bool SaveMeetingMessageBlobToFolder(ExchangeService oExchangeService, ItemId oItemId, string sFolder, string sFile)
        //{
        //    bool bRet = false;
        //    string ServerVersion = oExchangeService.RequestedServerVersion.ToString();

        //    if (ServerVersion.StartsWith("Exchange2007") || ServerVersion == "Exchange2010")
        //    {
        //        MessageBox.Show("Exchange 2010 SP1 or later is requred to use ExportItems to do a blog export of an item.", "Invalid version for blog export using ExportItem");
        //        return false;
        //    }


        //    MeetingMessage oMeetingMessage = MeetingMessage.Bind(oExchangeService, oItemId);

        //    // Exchange2010_SP1 is the minimal version
        //    bRet = EWSEditor.Exchange.ExportUploadHelper.ExportItemPost(ServerVersion, oItemId.UniqueId, sFile);

        //    bRet = true;
        //    return bRet;
        //}

        public bool SaveMeetingMessagesToFolder(
            ExchangeService oExchangeService, 
            List<ItemId> oItemIds, string sFolder, 
            List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions, 
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions 
            )
        {
            bool bRet = true;

            string sFilePath = string.Empty;
            string sContent = string.Empty;
            string sFileName = string.Empty;

            string sStorageFolder = sFolder; // + "\\MeetingMessage";
            if (!Directory.Exists(sStorageFolder))
                Directory.CreateDirectory(sStorageFolder);

            foreach (ItemId oItemId in oItemIds)
            {
                sContent = string.Empty;

                sFileName = Path.GetTempFileName().Replace(".tmp", ".xml");
                sFilePath = sStorageFolder + "\\" + sFileName;

                MeetingMessageData oMeetingMessageData = GetMeetingMessageDataFromItem(
                        oExchangeService, 
                        oItemId,
                        oAdditionalPropertyDefinitions,
                        oExtendedPropertyDefinitions,
                        false,
                        false
                        );

                //http://msdn.microsoft.com/en-us/library/system.xml.xmlwritersettings.newlinehandling(v=vs.110).aspx
                sContent = SerialHelper.SerializeObjectToString<MeetingMessageData>(oMeetingMessageData);
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


        public void SetMeetingMessageData(
            MeetingMessage oMeetingMessage, 
            ref MeetingMessageData oMeetingMessageData, 
            List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions, 
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions 
            )
        {
            MeetingMessageData oMM = new MeetingMessageData();
       
            StringBuilder oSB = new StringBuilder();

            try
            {
                oMM.AllowedResponseActions = oMeetingMessage.AllowedResponseActions.ToString(); 
            }
            catch (Exception ex)
            {
                oMM.AllowedResponseActions = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            //oMM.AllowedResponseActions = oMeetingMessage.AllowedResponseActions.ToString();       
            try
            {
                oMM.ApprovalRequestData = oMeetingMessage.ApprovalRequestData.ToString();
            }
            catch (Exception ex)
            {
                oMM.ApprovalRequestData = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            try
            {
                oMM.AssociatedAppointmentId = oMeetingMessage.AssociatedAppointmentId.ToString();
            }
            catch (Exception ex)
            {
                oMM.AssociatedAppointmentId = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            if (oMeetingMessage.BccRecipients != null)
            {
                StringBuilder oSbBccRecipients = new StringBuilder();
                foreach (EmailAddress oEmailAddress in oMeetingMessage.BccRecipients)
                    oSbBccRecipients.AppendFormat("{0} <{1}>;", oEmailAddress.Name, oEmailAddress.Address);
                oMM.BccRecipients = oSbBccRecipients.ToString();
            }
            else
                oMM.BccRecipients = "";
             
            try
            {
                oMM.Body = oMeetingMessage.Body.Text;
            }
            catch (Exception ex)
            {
                oMM.Body = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
             if (oMeetingMessage.Categories != null) oMM.Categories = oMeetingMessage.Categories.ToString();


            if (oMeetingMessage.CcRecipients != null)
            {
                StringBuilder oSbCcRecipients = new StringBuilder();
                foreach (EmailAddress oEmailAddress in oMeetingMessage.CcRecipients)
                    oSbCcRecipients.AppendFormat("{0} <{1}>;", oEmailAddress.Name, oEmailAddress.Address);
                oMM.CcRecipients = oSbCcRecipients.ToString();
            }
            else
                oMM.CcRecipients = "";

             try
            {
                oMM.ConversationIndex = oMeetingMessage.ConversationIndex.ToString();
            }
            catch (Exception ex)
            {
                oMM.ConversationIndex = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            try
            {
                if (oMeetingMessage.ConversationTopic != null) oMM.ConversationTopic = oMeetingMessage.ConversationTopic.ToString();
            }
            catch (Exception ex)
            {
                oMM.ConversationTopic = ex.Message.ToString();
            }
            if (oMeetingMessage.Culture != null) oMM.Culture = oMeetingMessage.Culture.ToString();
            if (oMeetingMessage.DateTimeCreated != null) oMM.DateTimeCreated = oMeetingMessage.DateTimeCreated.ToString();
            if (oMeetingMessage.DateTimeReceived != null) oMM.DateTimeReceived = oMeetingMessage.DateTimeReceived.ToString();    
             
            oMM.DateTimeSent = oMeetingMessage.DateTimeSent.ToString();

            if (oMeetingMessage.DisplayCc != null) oMM.DisplayCc = oMeetingMessage.DisplayCc.ToString();
            if (oMeetingMessage.DisplayTo != null) oMM.DisplayTo = oMeetingMessage.DisplayTo.ToString();

            oMM.EffectiveRights = oMeetingMessage.EffectiveRights.ToString();   
            //oMM.EntityExtractionResult = oMeetingMessage.EntityExtractionResult;    ?
            //oMM.ExtendedProperties = oMeetingMessage.ExtendedProperties;   
            //if (oMeetingMessage.Flag != null) oMM.Flag = oMeetingMessage.Flag.ToString();
            if (oMeetingMessage.From != null) oMM.From = oMeetingMessage.From.ToString();   
           // oMM.HasAttachments = oMeetingMessage.;   
            
            //if (oMeetingMessage.HasBeenProcessed != null) oMM.HasBeenProcessed = oMeetingMessage.HasBeenProcessed.ToString();
            if (oMeetingMessage.ICalDateTimeStamp != null) oMM.ICalDateTimeStamp = oMeetingMessage.ICalDateTimeStamp.ToString();
            if (oMeetingMessage.ICalRecurrenceId != null) oMM.ICalRecurrenceId = oMeetingMessage.ICalRecurrenceId.ToString();
           if (oMeetingMessage.ICalUid != null) oMM.ICalUid = oMeetingMessage.ICalUid.ToString();
            
            try
            {
                oMM.ConversationTopic = oMeetingMessage.IconIndex.ToString();
            }
            catch (Exception ex)
            {
                oMM.IconIndex = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            
            if (oMeetingMessage.Id != null) oMM.UniqueId = oMeetingMessage.Id.UniqueId;
            oMM.Importance = oMeetingMessage.Importance.ToString();
//            if (oMeetingMessage.InstanceKey != null) oMM.InstanceKey = oMeetingMessage.InstanceKey.ToString();
            if (oMeetingMessage.InternetMessageHeaders != null) oMM.InternetMessageHeaders = oMeetingMessage.InternetMessageHeaders.ToString();


            if (oMeetingMessage.InternetMessageHeaders != null)
            {
                StringBuilder oSbInternetMessageHeaders = new StringBuilder();
                foreach (InternetMessageHeader imh in oMeetingMessage.InternetMessageHeaders)
                    oSbInternetMessageHeaders.AppendFormat("{0}: {1};", imh.Name, imh.Value.ToString());
                oMM.InternetMessageHeaders = oSbInternetMessageHeaders.ToString();
            }
            else
                oMM.InternetMessageHeaders = "";

            //oMeetingMessage.InternetMessageHeaders = 
              
            if (oMeetingMessage.InternetMessageId != null) oMM.InternetMessageId = oMeetingMessage.InternetMessageId.ToString();
//            if (oMeetingMessage.IsAssociated != null) oMM.IsAssociated = oMeetingMessage.IsAssociated.ToString();

            oMM.IsDelegated = oMeetingMessage.IsDelegated.ToString();
            try
            {
                oMM.IsDeliveryReceiptRequested = oMeetingMessage.IsDeliveryReceiptRequested.ToString();
            }
            catch (Exception ex)
            {
                oMM.IsDeliveryReceiptRequested = ""; ;
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

           
            
            //oMM.IsDraft = oMeetingMessage.IsDraft.ToString();

            try
            {
                oMM.IsDraft = oMeetingMessage.IsDraft.ToString();
            }
            catch (Exception ex)
            {
                oMM.IsDraft = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
           // if (oMeetingMessage.IsFromMe != null) oMM.IsFromMe = oMeetingMessage.IsFromMe.ToString();//

            //if (oMeetingMessage.IsOrganizer != null) oMM.IsOrganizer = oMeetingMessage.IsOrganizer.ToString();

            try
            {
                oMM.IsOutOfDate = oMeetingMessage.IsOutOfDate.ToString();
            }
            catch (Exception ex)
            {
                oMM.IsOutOfDate = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            //oMM.IsRead = oMeetingMessage.IsRead.ToString();

            try
            {
                oMM.IsRead = oMeetingMessage.IsRead.ToString();
            }
            catch (Exception ex)
            {
                oMM.IsRead = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            //oMM.IsReadReceiptRequested = oMeetingMessage.IsReadReceiptRequested.ToString();
            try
            {
                oMM.IsReadReceiptRequested = oMeetingMessage.IsReadReceiptRequested.ToString();
            }
            catch (Exception ex)
            {
                oMM.IsReadReceiptRequested = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            //if (oMeetingMessage.IsReminderSet != null) oMM.IsReminderSet = oMeetingMessage.IsReminderSet.ToString();
            try
            {
                oMM.IsReminderSet = oMeetingMessage.IsReminderSet.ToString();
            }
            catch (Exception ex)
            {
                oMM.IsReminderSet = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            //oMM.IsResend = oMeetingMessage.IsResend.ToString();
            try
            {
                oMM.IsResend = oMeetingMessage.IsResend.ToString();
            }
            catch (Exception ex)
            {
                oMM.IsResend = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

           // if (oMeetingMessage.IsResponseRequested != null) oMM.IsResponseRequested = oMeetingMessage.IsResponseRequested.ToString();
            try
            {
                if (oMeetingMessage.IsResponseRequested != null) oMM.IsResponseRequested = oMeetingMessage.IsResponseRequested.ToString();
            }
            catch (Exception ex)
            {
                oMM.IsResponseRequested = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            //oMM.IsSubmitted = oMeetingMessage.IsSubmitted.ToString();
            try
            {
                oMM.IsSubmitted = oMeetingMessage.IsSubmitted.ToString();
            }
            catch (Exception ex)
            {
                oMM.IsSubmitted = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            //oMM.IsUnmodified = oMeetingMessage.IsUnmodified.ToString();
            try
            {
                oMM.IsUnmodified = oMeetingMessage.IsUnmodified.ToString();
            }
            catch (Exception ex)
            {
                oMM.IsUnmodified = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            if (oMeetingMessage.ItemClass != null) oMM.ItemClass = oMeetingMessage.ItemClass;
            if (oMeetingMessage.LastModifiedName != null) oMM.LastModifiedName = oMeetingMessage.LastModifiedName.ToString();
            if (oMeetingMessage.LastModifiedTime != null) oMM.LastModifiedTime = oMeetingMessage.LastModifiedTime.ToString();

            //if (oMeetingMessage.Location != null) oMM.Location = oMeetingMessage.Location.ToString();
            oMM.Location = "";

            try
            {
                oMM.NormalizedBody = oMeetingMessage.NormalizedBody;
            }
            catch (Exception ex)
            {
                oMM.NormalizedBody = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            //oMM.ParentFolderId = "";
            try
            {  
                if (oMeetingMessage.ParentFolderId != null) oMM.ParentFolderId = oMeetingMessage.ParentFolderId.ToString();
            }
            catch (Exception ex)
            {
                oMM.ParentFolderId = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
//            if (oMeetingMessage.PolicyTag != null) oMM.PolicyTag = oMeetingMessage.PolicyTag.ToString();
//            if (oMeetingMessage.Preview != null) oMM.Preview = oMeetingMessage.Preview.ToString();
            if (oMeetingMessage.ReceivedBy != null) oMM.ReceivedBy = oMeetingMessage.ReceivedBy.Name + " <" + oMeetingMessage.ReceivedBy.Address + ">";
            if (oMeetingMessage.ReceivedRepresenting != null) oMM.ReceivedRepresenting = oMeetingMessage.ReceivedRepresenting.ToString();
            if (oMeetingMessage.References != null) oMM.References = oMeetingMessage.References.ToString();
            try
            {
                if (oMeetingMessage.ReminderDueBy != null) oMM.ReminderDueBy = oMeetingMessage.ReminderDueBy.ToString();
            }   
            catch (Exception ex)
            {
                oMM.ReminderDueBy = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
           // oMM.ReminderMinutesBeforeStart = GetItemValue(oMeetingMessage.ReminderMinutesBeforeStart);
            
            try
            {
                oMM.ReminderMinutesBeforeStart = oMeetingMessage.ReminderMinutesBeforeStart.ToString();
            }
            catch (Exception ex)
            {
                oMM.ReminderMinutesBeforeStart = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            //if (oMeetingMessage.ReplyTo != null) oMM.ReplyTo = oMeetingMessage.ReplyTo.ToString(); //  //.name+ " <" + oMeetingMessage.ReplyTo.Address + ">";

            if (oMeetingMessage.ReplyTo != null)
            {
                StringBuilder oSbReplyTo = new StringBuilder();
                foreach (EmailAddress oEmailAddress in oMeetingMessage.ReplyTo)
                    oSbReplyTo.AppendFormat("{0} <{1}>;", oEmailAddress.Name, oEmailAddress.Address);
                oMM.ReplyTo = oSbReplyTo.ToString();
            }
            else
                oMM.ReplyTo = "";

            try
            { 
                oMM.ResponseType = oMeetingMessage.ResponseType.ToString();
            }
            catch (Exception ex)
            {
                oMM.ResponseType = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

//           if (oMeetingMessage.RetentionDate != null) oMM.RetentionDate = oMeetingMessage.RetentionDate.ToString();

            if (oMeetingMessage.Sender.Name != null) oMM.Sender = oMeetingMessage.Sender.Name + " <" + oMeetingMessage.Sender.Address + ">";
            oMM.Sensitivity = oMeetingMessage.Sensitivity.ToString();
            oMM.Size = oMeetingMessage.Size.ToString();

            // if (oMeetingMessage.StoreEntryId != null) oMM.StoreEntryId = oMeetingMessage.StoreEntryId.ToString();

            oMM.Subject = oMeetingMessage.Subject.ToString();
            try
            {
                oMM.TextBody = oMeetingMessage.TextBody;
           }
            catch (Exception ex)
            {
                oMM.TextBody = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            //if (oMeetingMessage.ToRecipients != null) oMM.ToRecipients = oMeetingMessage.ToRecipients.ToString();

            if (oMeetingMessage.ToRecipients != null)
            {
                StringBuilder oSbToRecipients = new StringBuilder();
                foreach (EmailAddress oEmailAddress in oMeetingMessage.ToRecipients)
                    oSbToRecipients.AppendFormat("{0} <{1}>;", oEmailAddress.Name, oEmailAddress.Address);
                oMM.ToRecipients = oSbToRecipients.ToString();
            }
            else
                oMM.ToRecipients = "";

            //if (oMeetingMessage.UniqueBody != null) oMM.UniqueBody = oMeetingMessage.UniqueBody.Text.ToString();

            try
            {
                oMM.UniqueBody = oMeetingMessage.UniqueBody;
            }
            catch (Exception ex)
            {
                oMM.UniqueBody = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
             
            //try
            //{
            //    oMM.UniqueBody = oMeetingMessage.UniqueBody;
            //}
            //catch (Exception ex)
            //{
            //    oMM.UniqueBody = ex.Message.ToString();
            //}
            try
           {
                oMM.VotingInformation = oMeetingMessage.VotingInformation.ToString();
            }
            catch (Exception ex)
            {
                oMM.UniqueBody = ex.Message.ToString();
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            try
            {
                oMM.WebClientEditFormQueryString = oMeetingMessage.WebClientEditFormQueryString.ToString();
            }
            catch (Exception ex)
            {
                oMM.WebClientEditFormQueryString = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            try
            {
                oMM.WebClientReadFormQueryString = oMeetingMessage.WebClientReadFormQueryString.ToString();
            }
            catch (Exception ex)
            {
                oMM.WebClientReadFormQueryString = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            //oAppointmentData.PidLidAppointmentRecur = GetExtendedProp_Byte_AsString(oAppointment, PidLidAppointmentRecur);
            //oAppointmentData.PidLidClientIntent = GetExtendedProp_Int_AsString(oAppointment, PidLidClientIntent);
            //oAppointmentData.ClientInfoString = GetExtendedProp_String_AsString(oAppointment, ClientInfoString);
            //oAppointmentData.StoreEntryId = GetExtendedProp_Byte_AsString(oAppointment, Prop_PR_STORE_ENTRYID);
            //oAppointmentData.EntryId = GetExtendedProp_Byte_AsString(oAppointment, Prop_PR_ENTRYID);
            //oAppointmentData.RetentionDate = GetExtendedProp_DateTime_AsString(oAppointment, Prop_PR_RETENTION_DATE);
            //oAppointmentData.IsHidden = GetExtendedProp_Bool_AsString(oAppointment, Prop_PR_IS_HIDDEN);
            //oAppointmentData.LogTriggerAction = GetExtendedProp_String_AsString(oAppointment, LogTriggerAction);

            //oAppointmentData.PidLidCurrentVersion = GetExtendedProp_Int_AsString(oAppointment, PidLidCurrentVersion);
            //oAppointmentData.PidLidCurrentVersion = GetExtendedProp_Int_AsString(oAppointment, PidLidCurrentVersion);
            //oAppointmentData.PidNameCalendarUid = GetExtendedProp_Int_AsString(oAppointment, PidNameCalendarUid);
            //oAppointmentData.PidLidOrganizerAlias = GetExtendedProp_Int_AsString(oAppointment, PidLidOrganizerAlias);
            //oAppointmentData.PidTagSenderSmtpAddress = GetExtendedProp_Int_AsString(oAppointment, PidTagSenderSmtpAddress);

//            if (oMeetingMessage.VotingInformation != null) oMM.VotingInformation = oMeetingMessage.VotingInformation.ToString();
//            if (oMeetingMessage.WebClientEditFormQueryString != null) oMM.WebClientEditFormQueryString = oMeetingMessage.WebClientEditFormQueryString;
//            if (oMeetingMessage.WebClientReadFormQueryString != null) oMM.WebClientReadFormQueryString = oMeetingMessage.WebClientReadFormQueryString;

            //oMM.PidLidCleanGlobalObjectId = EwsExtendedPropertyHelper.GetExtendedPropByteArrAsString(oMeetingMessage, PidLidCleanGlobalObjectId);
            //oMM.PidLidGlobalObjectId = EwsExtendedPropertyHelper.GetExtendedPropByteArrAsString(oMeetingMessage, PidLidGlobalObjectId);

            oMM.PidLidCleanGlobalObjectId = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oMeetingMessage, PidLidCleanGlobalObjectId);

            oMM.PidLidGlobalObjectId = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oMeetingMessage, PidLidGlobalObjectId);

            oMM.PidLidAppointmentRecur = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oMeetingMessage, PidLidAppointmentRecur);
            oMM.PidLidClientIntent = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oMeetingMessage, PidLidClientIntent);
            oMM.ClientInfoString = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, ClientInfoString);
            oMM.StoreEntryId = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oMeetingMessage, Prop_PR_STORE_ENTRYID);
            oMM.EntryId = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oMeetingMessage, Prop_PR_ENTRYID);
            oMM.RetentionDate = EwsExtendedPropertyHelper.GetExtendedProp_DateTime_AsString(oMeetingMessage, Prop_PR_RETENTION_DATE);
            oMM.IsHidden = EwsExtendedPropertyHelper.GetExtendedProp_Bool_AsString(oMeetingMessage, Prop_PR_IS_HIDDEN);
            oMM.LogTriggerAction = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, LogTriggerAction);

            //oMM.PidLidCurrentVersion = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oMeetingMessage, PidLidCurrentVersion);
            oMM.PidLidCurrentVersionName = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidLidCurrentVersionName);
            oMM.PidNameCalendarUid = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidNameCalendarUid);
            oMM.PidLidOrganizerAlias = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidLidOrganizerAlias);
            oMM.PidTagSenderSmtpAddress = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidTagSenderSmtpAddress);

            oMM.PidLidInboundICalStream = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oMeetingMessage, PidLidInboundICalStream);
            oMM.PidLidAppointmentAuxiliaryFlags = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oMeetingMessage, PidLidAppointmentAuxiliaryFlags);
            oMM.PidLidRecurrencePattern = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidLidRecurrencePattern);
            oMM.PidLidRecurrenceType = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oMeetingMessage, PidLidRecurrenceType);
            oMM.PidLidRecurring = EwsExtendedPropertyHelper.GetExtendedProp_Bool_AsString(oMeetingMessage, PidLidRecurring);

            oMM.PidLidAppointmentRecur = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oMeetingMessage, PidLidAppointmentRecur);
            //oMM.PidLidAppointmentStartDate = EwsExtendedPropertyHelper.GetExtendedProp_DateTime_AsString(oMeetingMessage, PidLidAppointmentStartDate);
            //oMM.PidLidAppointmentStartTime = EwsExtendedPropertyHelper.GetExtendedProp_DateTime_AsString(oMeetingMessage, PidLidAppointmentStartTime);
            oMM.PidLidAppointmentStartWhole = EwsExtendedPropertyHelper.GetExtendedProp_DateTime_AsString(oMeetingMessage, PidLidAppointmentStartWhole);
            oMM.PidLidAppointmentEndWhole = EwsExtendedPropertyHelper.GetExtendedProp_DateTime_AsString(oMeetingMessage, PidLidAppointmentEndWhole);
            oMM.PidLidAppointmentStateFlags = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oMeetingMessage, PidLidAppointmentStateFlags);

            oMM.PidNameFrom = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidNameFrom);
            oMM.PidNameHttpmailFrom = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidNameHttpmailFrom);
            oMM.PidNameHttpmailFromEmail = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidNameHttpmailFromEmail);

            oMM.PidTagSenderEmailAddress = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidTagSenderEmailAddress);
            oMM.PidTagSenderFlags = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oMeetingMessage, PidTagSenderFlags);
            oMM.PidTagSenderName = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidTagSenderName);
            oMM.PidTagSenderSimpleDisplayName = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidTagSenderSimpleDisplayName);

            oMM.PidTagSentRepresentingEmailAddress = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidTagSentRepresentingEmailAddress);
            oMM.PidTagSentRepresentingFlags = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oMeetingMessage, PidTagSentRepresentingFlags);
            oMM.PidTagSentRepresentingName = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidTagSentRepresentingName);
            oMM.PidTagSentRepresentingSimpleDisplayName = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidTagSentRepresentingSimpleDisplayName);

            oMM.PidTagProcessed = EwsExtendedPropertyHelper.GetExtendedProp_Bool_AsString(oMeetingMessage, PidTagProcessed);
            //oMM.PidLidResponseStatus = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oMeetingMessage, PidLidResponseStatus);
            oMM.PidLidIsException = EwsExtendedPropertyHelper.GetExtendedProp_Bool_AsString(oMeetingMessage, PidLidIsException);

            oMM.PidTagCreatorName = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidTagCreatorName);
            oMM.PidTagCreatorSimpleDisplayName = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidTagCreatorSimpleDisplayName);
            oMM.PidNameCalendarIsOrganizer = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oMeetingMessage, PidNameCalendarIsOrganizer);

      
 
        //public string PidLidAppointmentRecur = string.Empty;
        //public string PidLidClientIntent = string.Empty;
        //public string ClientInfoString    = string.Empty;
        //public string EntryId  = string.Empty;
        //public string IsHidden = string.Empty;
        //public string FolderPath = string.Empty;
        //public string LogTriggerAction = string.Empty;

            oMM.UniqueId = oMeetingMessage.Id.UniqueId;

            oMM.FolderPath = "";
            if (oMM.ParentFolderId != "")
            { 
                string sFolderPath = string.Empty;
                if (EwsFolderHelper.GetFolderPath(oMeetingMessage.Service, oMeetingMessage.ParentFolderId, ref sFolderPath))
                    oMM.FolderPath = sFolderPath;
            }

            try
            {
                oMM.MimeContent = oMeetingMessage.MimeContent.ToString();
            }
            catch (Exception ex)
            {
                oMM.MimeContent = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            //oMM.MimeContent = oMeetingMessage.MimeContent.ToString();

            oMeetingMessageData = oMM;
        }

        private string GetItemValue(PropertyDefinition oProp)
        {
            string sRet = string.Empty;

            try
            {
                oProp.ToString();
            }
            catch (Exception ex)
            {
                 return ex.Message.ToString();
            }

            return sRet;
        }



        //public PropertySet GetCalendarPropset(string ExchangeVersion)
        //{
        //    return GetMeetingMessageDataPropset(
        //        ExchangeVersion,
        //        false, 
        //        false);
        //} 

        public static PropertySet GetMeetingMessageDataPropset(
            string ExchangeVersion,
            bool bIncludeBodies, 
            bool bIncludeMime,
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions
            )
        {
            // Removed for testing:
            //      BasePropertySet.IdOnly,
            //      MeetingMessageSchema.ParentFolderId, 
            //      MeetingMessageSchema.Id,  
            //      MeetingMessageSchema.AssociatedAppointmentId, 

            //// test basic 
            //PropertySet meetingMessagePropertySet = new PropertySet(BasePropertySet.IdOnly);
            //return meetingMessagePropertySet;

            // 

            PropertySet meetingMessagePropertySet = new PropertySet(
                 
                
                MeetingMessageSchema.Id,
                MeetingMessageSchema.ParentFolderId,

                 MeetingMessageSchema.AllowedResponseActions, 

                // MeetingMessageSchema.Attachments // 
                MeetingMessageSchema.BccRecipients,
                // MeetingMessageSchema.Body, //
                MeetingMessageSchema.Categories,
                 MeetingMessageSchema.CcRecipients,

                MeetingMessageSchema.ConversationIndex,
                MeetingMessageSchema.ConversationTopic,
                MeetingMessageSchema.Culture,
                MeetingMessageSchema.DateTimeCreated,
                MeetingMessageSchema.DateTimeReceived,

                MeetingMessageSchema.DateTimeSent,

                MeetingMessageSchema.DisplayCc,
                MeetingMessageSchema.DisplayTo,

                MeetingMessageSchema.EffectiveRights, 

                MeetingMessageSchema.ExtendedProperties,

                MeetingMessageSchema.From,
                MeetingMessageSchema.HasAttachments,
                MeetingMessageSchema.HasBeenProcessed,
                MeetingMessageSchema.ICalDateTimeStamp,
                MeetingMessageSchema.ICalRecurrenceId,
                MeetingMessageSchema.ICalUid,


                MeetingMessageSchema.Importance,

                MeetingMessageSchema.InternetMessageHeaders,
                MeetingMessageSchema.InternetMessageId,

                MeetingMessageSchema.IsDelegated,
                MeetingMessageSchema.IsDeliveryReceiptRequested,
                MeetingMessageSchema.IsDraft,


                MeetingMessageSchema.IsOutOfDate,
                MeetingMessageSchema.IsRead,
                MeetingMessageSchema.IsReadReceiptRequested,
                MeetingMessageSchema.IsReminderSet,
                MeetingMessageSchema.IsResend,
                MeetingMessageSchema.IsResponseRequested,
                MeetingMessageSchema.IsSubmitted,
                MeetingMessageSchema.IsUnmodified,

                MeetingMessageSchema.ItemClass,
                MeetingMessageSchema.LastModifiedName,
                MeetingMessageSchema.LastModifiedTime,
             

                MeetingMessageSchema.ReceivedBy,
                MeetingMessageSchema.ReceivedRepresenting,
                MeetingMessageSchema.References,
                MeetingMessageSchema.ReminderDueBy,
                MeetingMessageSchema.ReminderMinutesBeforeStart,
                MeetingMessageSchema.ReplyTo,
                MeetingMessageSchema.ResponseType,


                MeetingMessageSchema.Sender,
                MeetingMessageSchema.Sensitivity,

                MeetingMessageSchema.Size,

                MeetingMessageSchema.Subject,

                MeetingMessageSchema.ToRecipients
            );

            if (bIncludeBodies == true)
            {
                meetingMessagePropertySet.Add(MeetingMessageSchema.Body);
                //meetingMessagePropertySet.Add(MeetingMessageSchema.NormalizedBody);
                meetingMessagePropertySet.Add(MeetingMessageSchema.UniqueBody);    
            }

            //if (bIncludeAttachments == true)
            //    meetingMessagePropertySet.Add(MeetingMessageSchema.Attachments);

            if (bIncludeMime == true)
                meetingMessagePropertySet.Add(MeetingMessageSchema.MimeContent);

            //// Need to add these:


            //meetingMessagePropertySet.Add(PidLidCurrentVersion);
            meetingMessagePropertySet.Add(PidLidCurrentVersionName);
            meetingMessagePropertySet.Add(PidNameCalendarUid);
            meetingMessagePropertySet.Add(PidLidOrganizerAlias);
            meetingMessagePropertySet.Add(PidTagSenderSmtpAddress);
            meetingMessagePropertySet.Add(PidLidInboundICalStream);
            meetingMessagePropertySet.Add(PidLidAppointmentAuxiliaryFlags);
            meetingMessagePropertySet.Add(PidLidRecurrencePattern);
            meetingMessagePropertySet.Add(PidLidRecurrenceType);
            meetingMessagePropertySet.Add(PidLidRecurring);
            meetingMessagePropertySet.Add(PidLidAppointmentRecur);

            //meetingMessagePropertySet.Add(PidLidAppointmentStartDate);
            //meetingMessagePropertySet.Add(PidLidAppointmentStartTime);
            meetingMessagePropertySet.Add(PidLidAppointmentStartWhole);
            meetingMessagePropertySet.Add(PidLidAppointmentEndWhole);
            meetingMessagePropertySet.Add(PidLidAppointmentStateFlags);

            meetingMessagePropertySet.Add(PidNameFrom); // PidNameFrom -  Its the Organizer.
            meetingMessagePropertySet.Add(PidNameHttpmailFrom);
            meetingMessagePropertySet.Add(PidNameHttpmailFromEmail);

            meetingMessagePropertySet.Add(PidTagSenderEmailAddress);
            meetingMessagePropertySet.Add(PidTagSenderFlags);
            meetingMessagePropertySet.Add(PidTagSenderName);
            meetingMessagePropertySet.Add(PidTagSenderSimpleDisplayName);

            meetingMessagePropertySet.Add(PidTagSentRepresentingEmailAddress);
            meetingMessagePropertySet.Add(PidTagSentRepresentingFlags);
            meetingMessagePropertySet.Add(PidTagSentRepresentingName);
            meetingMessagePropertySet.Add(PidTagSentRepresentingSimpleDisplayName);

            meetingMessagePropertySet.Add(PidTagProcessed);
            //meetingMessagePropertySet.Add(PidLidResponseStatus);
            meetingMessagePropertySet.Add(PidLidIsException);
            meetingMessagePropertySet.Add(PidTagCreatorName);
            meetingMessagePropertySet.Add(PidTagCreatorSimpleDisplayName);
            meetingMessagePropertySet.Add(PidNameCalendarIsOrganizer);

            meetingMessagePropertySet.Add(PidLidAppointmentRecur);
            meetingMessagePropertySet.Add(PidLidClientIntent);
            meetingMessagePropertySet.Add(ClientInfoString);
            meetingMessagePropertySet.Add(LogTriggerAction);
            meetingMessagePropertySet.Add(PidLidCleanGlobalObjectId);
            meetingMessagePropertySet.Add(PidLidGlobalObjectId);


  
  
            //meetingMessagePropertySet.Add(Prop_PR_START_DATE_ETC);
            
            meetingMessagePropertySet.Add(Prop_PR_RETENTION_PERIOD);
            meetingMessagePropertySet.Add(Prop_PR_RETENTION_DATE);
            meetingMessagePropertySet.Add(Prop_PR_POLICY_TAG);
            meetingMessagePropertySet.Add(Prop_PR_RETENTION_FLAGS);
       
           
            meetingMessagePropertySet.Add(Prop_PR_ARCHIVE_TAG);
            meetingMessagePropertySet.Add(Prop_PR_ARCHIVE_PERIOD);
            meetingMessagePropertySet.Add(Prop_PR_ARCHIVE_DATE);

            meetingMessagePropertySet.Add(Prop_PR_ENTRYID);
            meetingMessagePropertySet.Add(Prop_PR_STORE_ENTRYID);
            meetingMessagePropertySet.Add(Prop_PR_IS_HIDDEN);

            if (!ExchangeVersion.StartsWith("Exchange_2007"))
            {
                // Allready accounted for.

            }
            else
            {
                // 2010 and above...

                meetingMessagePropertySet.Add(MeetingMessageSchema.ConversationId);
                meetingMessagePropertySet.Add(MeetingMessageSchema.IsAssociated);
                meetingMessagePropertySet.Add(MeetingMessageSchema.WebClientEditFormQueryString);
                meetingMessagePropertySet.Add(MeetingMessageSchema.WebClientReadFormQueryString);

                if (!ExchangeVersion.StartsWith("Exchange_2010"))  // after 2010 (2013, 2016, etc.)
                {
                    meetingMessagePropertySet.Add(MeetingMessageSchema.ApprovalRequestData);
                    //meetingMessagePropertySet.Add(MeetingMessageSchema.ArchiveTag);  // covered by extended property
                    meetingMessagePropertySet.Add(MeetingMessageSchema.EntityExtractionResult);
                    meetingMessagePropertySet.Add(MeetingMessageSchema.Flag);
                    meetingMessagePropertySet.Add(MeetingMessageSchema.IconIndex);
                    meetingMessagePropertySet.Add(MeetingMessageSchema.InstanceKey);
                    //meetingMessagePropertySet.Add(MeetingMessageSchema.PolicyTag); // covered by extended property
                    meetingMessagePropertySet.Add(MeetingMessageSchema.Preview);
                    //meetingMessagePropertySet.Add(MeetingMessageSchema.RetentionDate); // covered by extended property
                    //meetingMessagePropertySet.Add(MeetingMessageSchema.TextBody);
                    meetingMessagePropertySet.Add(MeetingMessageSchema.VotingInformation);

                    if (bIncludeBodies == true)
                    {
                        meetingMessagePropertySet.Add(MeetingMessageSchema.TextBody);
                        meetingMessagePropertySet.Add(MeetingMessageSchema.NormalizedBody);
                    }
  
                }
            }

            if (oExtendedPropertyDefinitions != null)
            {
                foreach (ExtendedPropertyDefinition oEPD in oExtendedPropertyDefinitions)
                {
                    meetingMessagePropertySet.Add(oEPD);
                }
            }



            // Schema properties not requested due to not being viable for 2007 sp1
            // Exchange2013:
            //      MeetingMessageSchema.ApprovalRequestData,           Exchange2013
            //      MeetingMessageSchema.ArchiveTag,                    Exchange2013        xp Prop_PR_ARCHIVE_TAG          
            //      MeetingMessageSchema.EntityExtractionResult,        Exchange2013  
            //      MeetingMessageSchema.Flag,                          Exchange2013  
            //      MeetingMessageSchema.IconIndex,                     Exchange2013
            //      MeetingMessageSchema.InstanceKey,                   Exchange2013                
            //      MeetingMessageSchema.PolicyTag,                     Exchange2013  
            //      MeetingMessageSchema.Preview,                       Exchange2013  
            //      MeetingMessageSchema.RetentionDate,                 Exchange2013        xp Prop_PR_RETENTION_DATE      
            //      MeetingMessageSchema.TextBody,                      Exchange2013  
            //      MeetingMessageSchema.VotingInformation,             Exchange2013 
            // Exchange2010:
            //      MeetingMessageSchema.ConversationId,                Exchange2010 
            //      MeetingMessageSchema.IsAssociated,                  Exchange2010
            //      MeetingMessageSchema.WebClientEditFormQueryString,  Exchange2010  
            //      MeetingMessageSchema.WebClientReadFormQueryString,  Exchange2010 
            // Exchange2010_SP2:  
            //      MeetingMessageSchema.StoreEntryId,                  Exchange2010_SP2    xp Prop_PR_STORE_ENTRYID

            return meetingMessagePropertySet;
        }

        public List<string> GetMeetingMessageDataAsList(MeetingMessageData oMeetingMessageData)
        {
            List<string> o = new List<string> { };

             o.Add(CleanString(oMeetingMessageData.AllowedResponseActions));
             o.Add(CleanString(oMeetingMessageData.ApprovalRequestData));
             o.Add(CleanString(oMeetingMessageData.ArchiveTag));
             o.Add(CleanString(oMeetingMessageData.AssociatedAppointmentId));

            //  o.Add(CleanString(oMeetingMessageData.Attachments // 
             o.Add(CleanString(oMeetingMessageData.BccRecipients));
            
             o.Add(CleanString(oMeetingMessageData.Body));
             o.Add(CleanString(oMeetingMessageData.Categories));
             o.Add(CleanString(oMeetingMessageData.CcRecipients));

             o.Add(CleanString(oMeetingMessageData.ConversationId));
             o.Add(CleanString(oMeetingMessageData.ConversationIndex));
             o.Add(CleanString(oMeetingMessageData.ConversationTopic));
             o.Add(CleanString(oMeetingMessageData.Culture));

             o.Add(CleanString(oMeetingMessageData.DateTimeCreated));
             o.Add(CleanString(oMeetingMessageData.DateTimeReceived));
             o.Add(CleanString(oMeetingMessageData.DateTimeSent));

             o.Add(CleanString(oMeetingMessageData.DisplayCc));
             o.Add(CleanString(oMeetingMessageData.DisplayTo));

             o.Add(CleanString(oMeetingMessageData.EffectiveRights));
             o.Add(CleanString(oMeetingMessageData.EntityExtractionResult));
             o.Add(CleanString(oMeetingMessageData.ExtendedProperties));

             o.Add(CleanString(oMeetingMessageData.Flag));
             o.Add(CleanString(oMeetingMessageData.From));

             o.Add(CleanString(oMeetingMessageData.HasAttachments));
            o.Add(CleanString(oMeetingMessageData.HasBeenProcessed));

             o.Add(CleanString(oMeetingMessageData.ICalDateTimeStamp));
             o.Add(CleanString(oMeetingMessageData.ICalRecurrenceId));
             o.Add(CleanString(oMeetingMessageData.ICalUid));

             o.Add(CleanString(oMeetingMessageData.IconIndex));
             o.Add(CleanString(oMeetingMessageData.UniqueId));   // Id
             o.Add(CleanString(oMeetingMessageData.Importance));
             o.Add(CleanString(oMeetingMessageData.InstanceKey));

             o.Add(CleanString(oMeetingMessageData.InternetMessageHeaders));
             o.Add(CleanString(oMeetingMessageData.InternetMessageId));

             o.Add(CleanString(oMeetingMessageData.IsAssociated));
             o.Add(CleanString(oMeetingMessageData.IsDelegated));
             o.Add(CleanString(oMeetingMessageData.IsDeliveryReceiptRequested));

             o.Add(CleanString(oMeetingMessageData.IsDraft));
             o.Add(CleanString(oMeetingMessageData.IsFromMe));
             o.Add(CleanString(oMeetingMessageData.IsOrganizer));
             o.Add(CleanString(oMeetingMessageData.IsOutOfDate));

             o.Add(CleanString(oMeetingMessageData.IsRead));
             o.Add(CleanString(oMeetingMessageData.IsReadReceiptRequested));
             o.Add(CleanString(oMeetingMessageData.IsReminderSet));
             o.Add(CleanString(oMeetingMessageData.IsResend));

             o.Add(CleanString(oMeetingMessageData.IsResponseRequested));
             o.Add(CleanString(oMeetingMessageData.IsSubmitted));
             o.Add(CleanString(oMeetingMessageData.IsUnmodified));
             o.Add(CleanString(oMeetingMessageData.ItemClass));

             o.Add(CleanString(oMeetingMessageData.LastModifiedName));
             o.Add(CleanString(oMeetingMessageData.LastModifiedTime));
             o.Add(CleanString(oMeetingMessageData.MimeContent));


             o.Add(CleanString(oMeetingMessageData.NormalizedBody));

             o.Add(CleanString(oMeetingMessageData.ParentFolderId));
             o.Add(CleanString(oMeetingMessageData.PolicyTag));
             o.Add(CleanString(oMeetingMessageData.Preview));
             o.Add(CleanString(oMeetingMessageData.ReceivedBy));
             o.Add(CleanString(oMeetingMessageData.ReceivedRepresenting));

             o.Add(CleanString(oMeetingMessageData.References));
             o.Add(CleanString(oMeetingMessageData.ReminderDueBy));
             o.Add(CleanString(oMeetingMessageData.ReminderMinutesBeforeStart));
             o.Add(CleanString(oMeetingMessageData.ReplyTo));
             o.Add(CleanString(oMeetingMessageData.ResponseType));
             o.Add(CleanString(oMeetingMessageData.RetentionDate));

             o.Add(CleanString(oMeetingMessageData.Sender));
             o.Add(CleanString(oMeetingMessageData.Sensitivity));

             o.Add(CleanString(oMeetingMessageData.Size));
             o.Add(CleanString(oMeetingMessageData.StoreEntryId));
             o.Add(CleanString(oMeetingMessageData.Subject));
             o.Add(CleanString(oMeetingMessageData.TextBody));
             o.Add(CleanString(oMeetingMessageData.ToRecipients));

             o.Add(CleanString(oMeetingMessageData.UniqueBody));
             o.Add(CleanString(oMeetingMessageData.VotingInformation));
             o.Add(CleanString(oMeetingMessageData.WebClientEditFormQueryString));
             o.Add(CleanString(oMeetingMessageData.WebClientReadFormQueryString));

            // New:
             //o.Add(CleanString(oMeetingMessageData.PidLidCurrentVersion));
             o.Add(CleanString(oMeetingMessageData.PidLidCurrentVersionName));
             o.Add(CleanString(oMeetingMessageData.PidNameCalendarUid));

             o.Add(CleanString(oMeetingMessageData.PidLidOrganizerAlias));
             o.Add(CleanString(oMeetingMessageData.PidTagSenderSmtpAddress));
             o.Add(CleanString(oMeetingMessageData.PidLidInboundICalStream));

             o.Add(CleanString(oMeetingMessageData.PidLidAppointmentAuxiliaryFlags));
             o.Add(CleanString(oMeetingMessageData.PidLidRecurrencePattern));
             o.Add(CleanString(oMeetingMessageData.PidLidRecurrenceType));
             o.Add(CleanString(oMeetingMessageData.PidLidRecurring));
             o.Add(CleanString(oMeetingMessageData.PidLidAppointmentRecur));

            // o.Add(CleanString(oMeetingMessageData.PidLidAppointmentStartDate));
            // o.Add(CleanString(oMeetingMessageData.PidLidAppointmentStartTime));
             o.Add(CleanString(oMeetingMessageData.PidLidAppointmentStartWhole));
             o.Add(CleanString(oMeetingMessageData.PidLidAppointmentEndWhole));
             o.Add(CleanString(oMeetingMessageData.PidLidAppointmentStateFlags));

             o.Add(CleanString(oMeetingMessageData.PidNameFrom)); // PidNameFrom -  Its the Organizer.
             o.Add(CleanString(oMeetingMessageData.PidNameHttpmailFrom));
             o.Add(CleanString(oMeetingMessageData.PidNameHttpmailFromEmail));

             o.Add(CleanString(oMeetingMessageData.PidTagSenderEmailAddress));
             o.Add(CleanString(oMeetingMessageData.PidTagSenderFlags));
             o.Add(CleanString(oMeetingMessageData.PidTagSenderName));
             o.Add(CleanString(oMeetingMessageData.PidTagSenderSimpleDisplayName));

             o.Add(CleanString(oMeetingMessageData.PidTagSentRepresentingEmailAddress));
             o.Add(CleanString(oMeetingMessageData.PidTagSentRepresentingFlags));
             o.Add(CleanString(oMeetingMessageData.PidTagSentRepresentingName));
             o.Add(CleanString(oMeetingMessageData.PidTagSentRepresentingSimpleDisplayName));

             o.Add(CleanString(oMeetingMessageData.PidTagProcessed));
           //  o.Add(CleanString(oMeetingMessageData.PidLidResponseStatus));
             o.Add(CleanString(oMeetingMessageData.PidLidIsException));
             o.Add(CleanString(oMeetingMessageData.PidTagCreatorName));
             o.Add(CleanString(oMeetingMessageData.PidTagCreatorSimpleDisplayName));
             o.Add(CleanString(oMeetingMessageData.PidNameCalendarIsOrganizer));

   
            // older

            o.Add(CleanString(oMeetingMessageData.PidLidAppointmentRecur));

             o.Add(CleanString(oMeetingMessageData.PidLidCleanGlobalObjectId));
             o.Add(CleanString(oMeetingMessageData.PidLidGlobalObjectId)); 
             o.Add(CleanString(oMeetingMessageData.PidLidClientIntent));
             o.Add(CleanString(oMeetingMessageData.ClientInfoString));
             o.Add(CleanString(oMeetingMessageData.EntryId));
             o.Add(CleanString(oMeetingMessageData.IsHidden));
             o.Add(CleanString(oMeetingMessageData.FolderPath));
             o.Add(CleanString(oMeetingMessageData.LogTriggerAction));

            return o;
        }

        private string CleanString(string s)
        {

            string sRet = string.Empty;
            if (s != null)
                return s;
            else
                return "";

        }


        // GetMeetingMessageDataAsCsv2
        public string GetMeetingMessageDataAsCsv2(MeetingMessageData oMeetingMessageData, CsvExportOptions oCsvExportOptions)
        {
 
            string sRet = string.Empty;
            char[] TrimChars = { ',', ' ' };

            List<string> h = GetMeetingMessageDataHeadersAsList();
            List<string> d = GetMeetingMessageDataAsList(oMeetingMessageData);

            string ToText = string.Empty;
            byte[] oFromBytes = null;
            string sHeader = string.Empty;
            for (int i = 0; i < d.Count - 1; i++)
            {
                sHeader = h[i];
                if (sHeader == "Body" ||
                    sHeader == "MimeContent" ||
                    sHeader == "TextBody" ||
                    sHeader == "NormalizedBody" ||
                    sHeader == "UniqueBody" ||
                    sHeader == "ConversationIndex")
                {
                    string x = d[i];
                    if (d[i] != null)
                    {
                        oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(d[i]);
                        ToText = System.Convert.ToBase64String(oFromBytes);

                        d[i] = ToText;
                    }
                    else
                        d[i] = "";
                }
                else
                {
 
                    // String  Handling
                    if (oCsvExportOptions._CsvStringHandling != CsvStringHandling.None)
                    { 
                        d[i] = AdditionalProperties.DoStringHandling(d[i], oCsvExportOptions._CsvStringHandling);
                    }

                    //// Hex encode binary (base64 encoded) data.
                    //if (oCsvExportOptions.HexEncodeBinaryData == true)
                    //{
                    //    //bColumnIsByteArray = StringHelper.IsBase64Encoded(s);
                    //    if (StringHelper.IsBase64Encoded(d[i]) == true)
                    //    {
                    //        oFromBytes = System.Convert.FromBase64String(d[i]); // Base64 to byte array.
                    //        d[i] = StringHelper.HexStringFromByteArray(oFromBytes, false);
                    //    }
                    //}

                }
            }

            StringBuilder oSB = new StringBuilder();
            for (int i = 0; i < d.Count - 1; i++)
            {
                oSB.AppendFormat("{0}, ", d[i]);
            }

            sRet = oSB.ToString();
            sRet = sRet.TrimEnd(TrimChars); // remove last comma
            sRet = sRet.Replace("\r\n", "");  // There shold be no crlf
            return sRet;

        }
         

        public List<string> GetMeetingMessageDataHeadersAsList()
        {

            List<string> o = new List<string> { };
            o.Add("AllowedResponseActions");
            o.Add("ApprovalRequestData");
            o.Add("ArchiveTag");
            o.Add("AssociatedAppointmentId");
            // o.Add("Attachments // 

            o.Add("BccRecipients");
            o.Add("Body");
            o.Add("Categories");
            o.Add("CcRecipients");

            o.Add("ConversationId");
            o.Add("ConversationIndex");
            o.Add("ConversationTopic");
            o.Add("Culture");

            o.Add("DateTimeCreated");
            o.Add("DateTimeReceived");
            o.Add("DateTimeSent");

            o.Add("DisplayCc");
            o.Add("DisplayTo");

            o.Add("EffectiveRights");
            o.Add("EntityExtractionResult");
            o.Add("ExtendedProperties");


            o.Add("Flag");
            o.Add("From");

            o.Add("HasAttachments");
            o.Add("HasBeenProcessed");

            o.Add("ICalDateTimeStamp");
            o.Add("ICalRecurrenceId");
            o.Add("ICalUid");

            o.Add("IconIndex");
            o.Add("UniqueId");  // Id
            o.Add("Importance");
            o.Add("InstanceKey");

            o.Add("InternetMessageHeaders");
            o.Add("InternetMessageId");

            o.Add("IsAssociated");
            o.Add("IsDelegated");
            o.Add("IsDeliveryReceiptRequested");

            o.Add("IsDraft");
            o.Add("IsFromMe");
            o.Add("IsOrganizer");
            o.Add("IsOutOfDate");

            o.Add("IsRead");
            o.Add("IsReadReceiptRequested");
            o.Add("IsReminderSet");
            o.Add("IsResend");

            o.Add("IsResponseRequested");
            o.Add("IsSubmitted");
            o.Add("IsUnmodified");
            o.Add("ItemClass");

            o.Add("LastModifiedName");
            o.Add("LastModifiedTime");
            o.Add("MimeContent");
            o.Add("NormalizedBody");

            o.Add("ParentFolderId");
            o.Add("PolicyTag");
            o.Add("Preview");
            o.Add("ReceivedBy");
            o.Add("ReceivedRepresenting");

            o.Add("References");
            o.Add("ReminderDueBy");
            o.Add("ReminderMinutesBeforeStart");
            o.Add("ReplyTo");
            o.Add("ResponseType");
            o.Add("RetentionDate");

            o.Add("Sender");
            o.Add("Sensitivity");

            o.Add("Size");
            o.Add("StoreEntryId");
            o.Add("Subject");
            o.Add("TextBody");
            o.Add("ToRecipients");

            o.Add("UniqueBody");
            o.Add("VotingInformation");
            o.Add("WebClientEditFormQueryString");
            o.Add("WebClientReadFormQueryString");


            // New:
            //o.Add("PidLidCurrentVersion");
            o.Add("PidLidCurrentVersionName");
            o.Add("PidNameCalendarUid");

            o.Add("PidLidOrganizerAlias");
            o.Add("PidTagSenderSmtpAddress");
            o.Add("PidLidInboundICalStream");

            o.Add("PidLidAppointmentAuxiliaryFlags");
            o.Add("PidLidRecurrencePattern");
            o.Add("PidLidRecurrenceType");
            o.Add("PidLidRecurring");
            o.Add("PidLidAppointmentRecur");

            //o.Add("PidLidAppointmentStartDate");
            //o.Add("PidLidAppointmentStartTime");
            o.Add("PidLidAppointmentStartWhole");
            o.Add("PidLidAppointmentEndWhole");
            o.Add("PidLidAppointmentStateFlags");

            o.Add("PidNameFrom"); // PidNameFrom -  Its the Organizer.
            o.Add("PidNameHttpmailFrom");
            o.Add("PidNameHttpmailFromEmail");

            o.Add("PidTagSenderEmailAddress");
            o.Add("PidTagSenderFlags");
            o.Add("PidTagSenderName");
            o.Add("PidTagSenderSimpleDisplayName");

            o.Add("PidTagSentRepresentingEmailAddress");
            o.Add("PidTagSentRepresentingFlags");
            o.Add("PidTagSentRepresentingName");
            o.Add("PidTagSentRepresentingSimpleDisplayName");

            o.Add("PidTagProcessed");
            // o.Add("PidLidResponseStatus");
            o.Add("PidLidIsException");
            o.Add("PidTagCreatorName");
            o.Add("PidTagCreatorSimpleDisplayName");
            o.Add("PidNameCalendarIsOrganizer");




            o.Add("PidLidAppointmentRecur");

            o.Add("PidLidCleanGlobalObjectId");
            o.Add("PidLidGlobalObjectId");
            o.Add("PidLidClientIntent");
            o.Add("ClientInfoString");
            o.Add("EntryId");
            o.Add("IsHidden");
            o.Add("FolderPath");
            o.Add("LogTriggerAction");


            return o;
        }



        //  
        public string GetMeetingMessageDataAsCsvHeaders(List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions)
        {
            char[] TrimChars = { ',', ' ' };
            string sRet = string.Empty;

            List<string> o = GetMeetingMessageDataHeadersAsList();


            StringBuilder oSB = new StringBuilder();
            for (int i = 0; i < o.Count - 1; i++)
            {
                oSB.AppendFormat("{0}, ", o[i]);
            }

            sRet = oSB.ToString();
            sRet = sRet.TrimEnd(TrimChars);

            if (oAdditionalPropertyDefinitions != null)
            {
                sRet += "," + AdditionalProperties.GetExtendedPropertyHeadersAsCsvContent(oAdditionalPropertyDefinitions);
                sRet = sRet.TrimEnd(TrimChars);
            }

            return sRet;
        }

 
 



        public List<string> GetDiagHeadersAsList()
        {

            List<string> o = new List<string> { };

         
// Replace2s
   
// Replace2e

            return o;
        }

        public string GetDiagMeetingMessageDataAsCsvHeaders()
        {
            char[] TrimChars = { ',', ' ' };
            string sRet = string.Empty;

            List<string> o = GetDiagHeadersAsList();


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

         public string GetDiagMeetingMessageDataAsCsv(MeetingMessageData oMeetingMessageData)
        {
            string sRet = string.Empty;
            char[] TrimChars = { ',', ' ' };

            List<string> h = GetDiagHeadersAsList();
            List<string> d = GetDiagMeetingMessageDataAsList(oMeetingMessageData);

            string ToText = string.Empty;
            byte[] oFromBytes = null;
            string sHeader = string.Empty;
            for (int i = 0; i < d.Count - 1; i++)
            {
                sHeader = h[i];
                if (sHeader == "Body" ||
                    sHeader == "MimeContent" ||
                    sHeader == "TextBody" ||
                   sHeader == "NormalizedBody" ||
                    sHeader == "UniqueBody" ||
                    sHeader == "ConversationIndex")
                {
                    string x = d[i];
                    if (d[i] != null)
                    {
                        oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(d[i]);
                        ToText = System.Convert.ToBase64String(oFromBytes);

                        d[i] = ToText;
                    }
                    else
                        d[i] = "";
                }
                else
                {
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
            sRet = sRet.Replace("\r\n", "");  // There shold be no crlf
            return sRet;

        }


         public List<string> GetDiagMeetingMessageDataAsList(MeetingMessageData oMeetingMessageData)
        {
            List<string> o = new List<string> { };
            //MeetingMessageData x = null;
            //AppointmentData a = null;
          
            // https://technet.microsoft.com/en-us/library/dd638102(v=exchg.160).aspx
            // https://technet.microsoft.com/en-us/library/jj552406(v=exchg.160).aspx

            // TODO: Map meeting properties - the commented out ones below need to be mapped.
 
            return o;


        }

         
    }
}

