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
    class MeetingMessageExport
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

        //  PR_CONVERSATION_ID
        //  PR_PARENT_ENTRYID

        public MeetingMessageData GetMeetingMessageDataFromItem(ExchangeService oExchangeService, ItemId oItemId)
        {
            //string ServerVersion = oExchangeService.RequestedServerVersion.ToString();
            //PropertySet oPropertySet = null;
            //oPropertySet = GetMeetingMessageDataPropset(ServerVersion, false, false, false);
            //MeetingMessage oMeetingMessage = MeetingMessage.Bind(oExchangeService, oItemId, oPropertySet);
            //MeetingMessageData oMeetingMessageData = new MeetingMessageData();

            //SetMeetingMessageData(oMeetingMessage, ref oMeetingMessageData);
            MeetingMessageData oMeetingMessageData = GetMeetingMessageDataFromItem(oExchangeService, oItemId, false, false, false);

            return oMeetingMessageData;
        }

        public MeetingMessageData GetMeetingMessageDataFromItem(ExchangeService oExchangeService, ItemId oItemId, bool bIncludeAttachments, bool bIncludeBody, bool bIncludeMime)
        {
            string ServerVersion = oExchangeService.RequestedServerVersion.ToString();
            PropertySet oPropertySet = null;
            oPropertySet = GetMeetingMessageDataPropset(ServerVersion, bIncludeAttachments, bIncludeBody, bIncludeMime);
            MeetingMessage oMeetingMessage = MeetingMessage.Bind(oExchangeService, oItemId, oPropertySet);
            MeetingMessageData oMeetingMessageData = new MeetingMessageData();

            SetMeetingMessageData(oMeetingMessage, ref oMeetingMessageData);

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

        public bool SaveMeetingMessageToFolder(ExchangeService oExchangeService, ItemId oItemId)
        {
            bool bRet = true;

            List<ItemId> oItemIds = new List<ItemId> { oItemId };
            SaveMeetingMessagesToFolder(oExchangeService, oItemIds);
            return bRet;
        }

        public bool SaveMeetingMessagesToFolder(ExchangeService oExchangeService, List<ItemId> oItemIds)
        {
            bool bRet = true;
            string sFolder = string.Empty;
            if (GetFolderPath(ref sFolder))
                SaveMeetingMessagesToFolder(oExchangeService, oItemIds, sFolder);
            return bRet;
        }

        public bool SaveMeetingMessageToFolder(ExchangeService oExchangeService, ItemId oItemId, string sFolder)
        {
            bool bRet = true;
            List<ItemId> oItemIds = new List<ItemId> { oItemId };
            SaveMeetingMessagesToFolder(oExchangeService, oItemIds);
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

        public bool SaveMeetingMessagesToFolder(ExchangeService oExchangeService, List<ItemId> oItemIds, string sFolder)
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

                MeetingMessageData oMeetingMessageData = GetMeetingMessageDataFromItem(oExchangeService, oItemId);

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


        public void SetMeetingMessageData(MeetingMessage oMeetingMessage, ref MeetingMessageData oMeetingMessageData)
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
            }
            //oMM.AllowedResponseActions = oMeetingMessage.AllowedResponseActions.ToString();       
            try
            {
                oMM.ApprovalRequestData = oMeetingMessage.ApprovalRequestData.ToString();
            }
            catch (Exception ex)
            {
                oMM.ApprovalRequestData = "";
            }
//            if (oMeetingMessage.ApprovalRequestData != null) oMM.ApprovalRequestData  = oMeetingMessage.ApprovalRequestData.ToString();
//            if (oMeetingMessage.ArchiveTag != null) oMM.ArchiveTag = oMeetingMessage.ArchiveTag.ToString();
//            if (oMeetingMessage.AssociatedAppointmentId != null) oMM.AssociatedAppointmentId = oMeetingMessage.AssociatedAppointmentId.UniqueId;    
            try
            {
                oMM.AssociatedAppointmentId = oMeetingMessage.AssociatedAppointmentId.ToString();
            }
            catch (Exception ex)
            {
                oMM.AssociatedAppointmentId = "";
            }
            //oMM.Attachments = oMeetingMessage.Attachments;  
            //if (oMeetingMessage.BccRecipients != null) oMM.BccRecipients = oMeetingMessage.BccRecipients.ToString();

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
            }
            // if (oMeetingMessage.xxxxxx != null) 
            if (oMeetingMessage.Categories != null) oMM.Categories = oMeetingMessage.Categories.ToString();
            //if (oMeetingMessage.CcRecipients != null) oMM.CcRecipients = oMeetingMessage.CcRecipients.ToString();



            if (oMeetingMessage.CcRecipients != null)
            {
                StringBuilder oSbCcRecipients = new StringBuilder();
                foreach (EmailAddress oEmailAddress in oMeetingMessage.CcRecipients)
                    oSbCcRecipients.AppendFormat("{0} <{1}>;", oEmailAddress.Name, oEmailAddress.Address);
                oMM.CcRecipients = oSbCcRecipients.ToString();
            }
            else
                oMM.CcRecipients = "";

 //           if (oMeetingMessage.ConversationId != null) oMM.ConversationId = oMeetingMessage.ConversationId.ToString();
            try
            {
                oMM.ConversationIndex = oMeetingMessage.ConversationIndex.ToString();
            }
            catch (Exception ex)
            {
                oMM.ConversationIndex = "";
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
            }

           
            
            oMM.IsDraft = oMeetingMessage.IsDraft.ToString();
           // if (oMeetingMessage.IsFromMe != null) oMM.IsFromMe = oMeetingMessage.IsFromMe.ToString();//

            //if (oMeetingMessage.IsOrganizer != null) oMM.IsOrganizer = oMeetingMessage.IsOrganizer.ToString();

            oMM.IsOutOfDate = oMeetingMessage.IsOutOfDate.ToString();
            oMM.IsRead = oMeetingMessage.IsRead.ToString();
            oMM.IsReadReceiptRequested = oMeetingMessage.IsReadReceiptRequested.ToString();
            //if (oMeetingMessage.IsReminderSet != null) oMM.IsReminderSet = oMeetingMessage.IsReminderSet.ToString();
            try
            {
                oMM.IsReminderSet = oMeetingMessage.IsReminderSet.ToString();
            }
            catch (Exception ex)
            {
                oMM.IsReminderSet = "";
            }
            oMM.IsResend = oMeetingMessage.IsResend.ToString();
            if (oMeetingMessage.IsResponseRequested != null) oMM.IsResponseRequested = oMeetingMessage.IsResponseRequested.ToString();
            oMM.IsSubmitted = oMeetingMessage.IsSubmitted.ToString();
            oMM.IsUnmodified = oMeetingMessage.IsUnmodified.ToString();

            if (oMeetingMessage.ItemClass != null) oMM.ItemClass = oMeetingMessage.ItemClass;
            if (oMeetingMessage.LastModifiedName != null) oMM.LastModifiedName = oMeetingMessage.LastModifiedName.ToString();
            if (oMeetingMessage.LastModifiedTime != null) oMM.LastModifiedTime = oMeetingMessage.LastModifiedTime.ToString();
            //oMM.MimeContent  = oMeetingMessage.MimeContent.; 


            try
            {
                oMM.NormalizedBody = oMeetingMessage.NormalizedBody;
            }
            catch (Exception ex)
            {
                oMM.NormalizedBody = "";
            }
            //oMM.ParentFolderId = "";
            try
            {  
                if (oMeetingMessage.ParentFolderId != null) oMM.ParentFolderId = oMeetingMessage.ParentFolderId.ToString();
            }
            catch (Exception ex)
            {
                oMM.ParentFolderId = "";
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
            }
           // oMM.ReminderMinutesBeforeStart = GetItemValue(oMeetingMessage.ReminderMinutesBeforeStart);
            
            try
            {
                oMM.ReminderMinutesBeforeStart = oMeetingMessage.ReminderMinutesBeforeStart.ToString();
            }
            catch (Exception ex)
            {
                oMM.ReminderMinutesBeforeStart = "";
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
            }
            try
            {
                oMM.WebClientEditFormQueryString = oMeetingMessage.WebClientEditFormQueryString.ToString();
            }
            catch (Exception ex)
            {
                oMM.WebClientEditFormQueryString = "";
            }
            try
            {
                oMM.WebClientReadFormQueryString = oMeetingMessage.WebClientReadFormQueryString.ToString();
            }
            catch (Exception ex)
            {
                oMM.WebClientReadFormQueryString = "";
            }

//            if (oMeetingMessage.VotingInformation != null) oMM.VotingInformation = oMeetingMessage.VotingInformation.ToString();
//            if (oMeetingMessage.WebClientEditFormQueryString != null) oMM.WebClientEditFormQueryString = oMeetingMessage.WebClientEditFormQueryString;
//            if (oMeetingMessage.WebClientReadFormQueryString != null) oMM.WebClientReadFormQueryString = oMeetingMessage.WebClientReadFormQueryString;

            oMM.PidLidAppointmentRecur = GetExtendedProp_ByteArr_AsString(oMeetingMessage, PidLidAppointmentRecur);
            oMM.PidLidClientIntent = GetExtendedProp_Int_AsString(oMeetingMessage, PidLidClientIntent);
            oMM.ClientInfoString = GetExtendedProp_String_AsString(oMeetingMessage, ClientInfoString);
            oMM.StoreEntryId = GetExtendedProp_ByteArr_AsString(oMeetingMessage, Prop_PR_STORE_ENTRYID);
            oMM.EntryId = GetExtendedProp_ByteArr_AsString(oMeetingMessage, Prop_PR_ENTRYID);
            oMM.RetentionDate = GetExtendedProp_DateTime_AsString(oMeetingMessage, Prop_PR_RETENTION_DATE);
            oMM.IsHidden = GetExtendedProp_Bool_AsString(oMeetingMessage, Prop_PR_IS_HIDDEN);
            oMM.LogTriggerAction = GetExtendedProp_String_AsString(oMeetingMessage, LogTriggerAction);

 
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



        public PropertySet GetCalendarPropset(string ExchangeVersion)
        {
            return GetMeetingMessageDataPropset(ExchangeVersion, false, false, false);
        } 

        public static PropertySet GetMeetingMessageDataPropset(string ExchangeVersion, bool bIncludeAttachments, bool bIncludeBody, bool bIncludeMime)
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

            if (bIncludeBody == true)
            {
                meetingMessagePropertySet.Add(MeetingMessageSchema.Body);
                meetingMessagePropertySet.Add(MeetingMessageSchema.NormalizedBody);
                meetingMessagePropertySet.Add(MeetingMessageSchema.UniqueBody);    
            }

            if (bIncludeAttachments == true)
                meetingMessagePropertySet.Add(MeetingMessageSchema.Attachments);

            if (bIncludeMime == true)
                meetingMessagePropertySet.Add(MeetingMessageSchema.MimeContent);

            //// Need to add these:
            meetingMessagePropertySet.Add(PidLidAppointmentRecur);
            meetingMessagePropertySet.Add(PidLidClientIntent);
            meetingMessagePropertySet.Add(ClientInfoString);
            meetingMessagePropertySet.Add(LogTriggerAction);
            meetingMessagePropertySet.Add(PidLidCleanGlobalObjectId);
            meetingMessagePropertySet.Add(PidLidGlobalObjectId);

            meetingMessagePropertySet.Add(Prop_PR_POLICY_TAG);

            meetingMessagePropertySet.Add(Prop_PR_RETENTION_FLAGS);
            meetingMessagePropertySet.Add(Prop_PR_RETENTION_PERIOD);
            meetingMessagePropertySet.Add(Prop_PR_ARCHIVE_TAG);
            meetingMessagePropertySet.Add(Prop_PR_ARCHIVE_PERIOD);
            meetingMessagePropertySet.Add(Prop_PR_ARCHIVE_DATE);
            meetingMessagePropertySet.Add(Prop_PR_ENTRYID);

            meetingMessagePropertySet.Add(Prop_PR_RETENTION_DATE);
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
                    meetingMessagePropertySet.Add(MeetingMessageSchema.TextBody);
                    meetingMessagePropertySet.Add(MeetingMessageSchema.VotingInformation);
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
            o.Add(oMeetingMessageData.AllowedResponseActions);
            o.Add(oMeetingMessageData.ApprovalRequestData);
            o.Add(oMeetingMessageData.ArchiveTag);
            o.Add(oMeetingMessageData.AssociatedAppointmentId);
            // o.Add(oMeetingMessageData.Attachments // 
            o.Add(oMeetingMessageData.BccRecipients);
            o.Add(oMeetingMessageData.Body);
            o.Add(oMeetingMessageData.Categories);
            o.Add(oMeetingMessageData.CcRecipients);
            o.Add(oMeetingMessageData.ConversationId);
            o.Add(oMeetingMessageData.ConversationIndex);
            o.Add(oMeetingMessageData.ConversationTopic);
            o.Add(oMeetingMessageData.Culture);
            o.Add(oMeetingMessageData.DateTimeCreated);
            o.Add(oMeetingMessageData.DateTimeReceived);
            o.Add(oMeetingMessageData.DateTimeSent);
            o.Add(oMeetingMessageData.DisplayCc);
            o.Add(oMeetingMessageData.DisplayTo);
            o.Add(oMeetingMessageData.EffectiveRights);
            o.Add(oMeetingMessageData.EntityExtractionResult);
            o.Add(oMeetingMessageData.ExtendedProperties);
            o.Add(oMeetingMessageData.Flag);
            o.Add(oMeetingMessageData.From);
            o.Add(oMeetingMessageData.HasAttachments);
            o.Add(oMeetingMessageData.HasBeenProcessed);
            o.Add(oMeetingMessageData.ICalDateTimeStamp);
            o.Add(oMeetingMessageData.ICalRecurrenceId);
            o.Add(oMeetingMessageData.ICalUid);
            o.Add(oMeetingMessageData.IconIndex);
            o.Add(oMeetingMessageData.UniqueId);   // Id
            o.Add(oMeetingMessageData.Importance);
            o.Add(oMeetingMessageData.InstanceKey);
            o.Add(oMeetingMessageData.InternetMessageHeaders);
            o.Add(oMeetingMessageData.InternetMessageId);
            o.Add(oMeetingMessageData.IsAssociated);
            o.Add(oMeetingMessageData.IsDelegated);
            o.Add(oMeetingMessageData.IsDeliveryReceiptRequested);
            o.Add(oMeetingMessageData.IsDraft);
            o.Add(oMeetingMessageData.IsFromMe);
            o.Add(oMeetingMessageData.IsOrganizer);
            o.Add(oMeetingMessageData.IsOutOfDate);
            o.Add(oMeetingMessageData.IsRead);
            o.Add(oMeetingMessageData.IsReadReceiptRequested);
            o.Add(oMeetingMessageData.IsReminderSet);
            o.Add(oMeetingMessageData.IsResend);
            o.Add(oMeetingMessageData.IsResponseRequested);
            o.Add(oMeetingMessageData.IsSubmitted);
            o.Add(oMeetingMessageData.IsUnmodified);
            o.Add(oMeetingMessageData.ItemClass);
            o.Add(oMeetingMessageData.LastModifiedName);
            o.Add(oMeetingMessageData.LastModifiedTime);
            o.Add(oMeetingMessageData.MimeContent);
            o.Add(oMeetingMessageData.NormalizedBody);
            o.Add(oMeetingMessageData.ParentFolderId);
            o.Add(oMeetingMessageData.PolicyTag);
            o.Add(oMeetingMessageData.Preview);
            o.Add(oMeetingMessageData.ReceivedBy);
            o.Add(oMeetingMessageData.ReceivedRepresenting);
            o.Add(oMeetingMessageData.References);
            o.Add(oMeetingMessageData.ReminderDueBy);
            o.Add(oMeetingMessageData.ReminderMinutesBeforeStart);
            o.Add(oMeetingMessageData.ReplyTo);
            o.Add(oMeetingMessageData.ResponseType);
            o.Add(oMeetingMessageData.RetentionDate);

            o.Add(oMeetingMessageData.Sender);
            o.Add(oMeetingMessageData.Sensitivity);

            o.Add(oMeetingMessageData.Size);
            o.Add(oMeetingMessageData.StoreEntryId);
            o.Add(oMeetingMessageData.Subject);
            o.Add(oMeetingMessageData.TextBody);
            o.Add(oMeetingMessageData.ToRecipients);

            o.Add(oMeetingMessageData.UniqueBody);
            o.Add(oMeetingMessageData.VotingInformation);
            o.Add(oMeetingMessageData.WebClientEditFormQueryString);
            o.Add(oMeetingMessageData.WebClientReadFormQueryString);

            o.Add(oMeetingMessageData.PidLidCleanGlobalObjectId);
            o.Add(oMeetingMessageData.PidLidGlobalObjectId);
            o.Add(oMeetingMessageData.PidLidAppointmentRecur);
            o.Add(oMeetingMessageData.PidLidClientIntent);
            o.Add(oMeetingMessageData.ClientInfoString);
            o.Add(oMeetingMessageData.EntryId);
            o.Add(oMeetingMessageData.IsHidden);
            o.Add(oMeetingMessageData.FolderPath);
            o.Add(oMeetingMessageData.LogTriggerAction);

            return o;
        }


        public string GetMeetingMessageDataAsCsv2(MeetingMessageData oMeetingMessageData)
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
                    d[i] = d[i].Replace(',', ' ');
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

        public string GetMeetingMessageDataAsCsv(MeetingMessageData oMeetingMessageData)
        {
            char[] TrimChars = { ',', ' ' };
            string sRet = string.Empty;
            List<string> o = new List<string> { }; 
            o.Add(oMeetingMessageData.AllowedResponseActions.Replace(',', ' '));            
            o.Add(oMeetingMessageData.ApprovalRequestData.Replace(',', ' '));     
            o.Add(oMeetingMessageData.ArchiveTag.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.AssociatedAppointmentId.Replace(',', ' '));  
            // o.Add(oMeetingMessageData.Attachments // 
            o.Add(oMeetingMessageData.BccRecipients.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.Body.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.Categories.Replace(',', ' '));  
            o.Add(oMeetingMessageData.CcRecipients.Replace(',', ' '));    
            o.Add(oMeetingMessageData.ConversationId.Replace(',', ' '));  
            o.Add(oMeetingMessageData.ConversationIndex.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.ConversationTopic.Replace(',', ' '));  
            o.Add(oMeetingMessageData.Culture.Replace(',', ' '));  
            o.Add(oMeetingMessageData.DateTimeCreated.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.DateTimeReceived.Replace(',', ' '));   
            o.Add(oMeetingMessageData.DateTimeSent.Replace(',', ' '));   
            o.Add(oMeetingMessageData.DisplayCc.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.DisplayTo.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.EffectiveRights.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.EntityExtractionResult.Replace(',', ' '));   
            o.Add(oMeetingMessageData.ExtendedProperties.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.Flag.Replace(',', ' '));     
            o.Add(oMeetingMessageData.From.Replace(',', ' '));   
            o.Add(oMeetingMessageData.HasAttachments.Replace(',', ' '));   
            o.Add(oMeetingMessageData.HasBeenProcessed.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.ICalDateTimeStamp.Replace(',', ' '));   
            o.Add(oMeetingMessageData.ICalRecurrenceId.Replace(',', ' '));  
            o.Add(oMeetingMessageData.ICalUid.Replace(',', ' '));     
            o.Add(oMeetingMessageData.IconIndex.Replace(',', ' '));  
            o.Add(oMeetingMessageData.UniqueId.Replace(',', ' '));   // Id
            o.Add(oMeetingMessageData.Importance.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.InstanceKey.Replace(',', ' '));   
            o.Add(oMeetingMessageData.InternetMessageHeaders.Replace(',', ' '));   
            o.Add(oMeetingMessageData.InternetMessageId.Replace(',', ' '));  
            o.Add(oMeetingMessageData.IsAssociated.Replace(',', ' '));           
            o.Add(oMeetingMessageData.IsDelegated.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.IsDeliveryReceiptRequested.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.IsDraft.Replace(',', ' '));  
            o.Add(oMeetingMessageData.IsFromMe.Replace(',', ' '));           
            o.Add(oMeetingMessageData.IsOrganizer.Replace(',', ' '));    
            o.Add(oMeetingMessageData.IsOutOfDate.Replace(',', ' '));    
            o.Add(oMeetingMessageData.IsRead.Replace(',', ' '));    
            o.Add(oMeetingMessageData.IsReadReceiptRequested.Replace(',', ' '));  
            o.Add(oMeetingMessageData.IsReminderSet.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.IsResend.Replace(',', ' '));   
            o.Add(oMeetingMessageData.IsResponseRequested.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.IsSubmitted.Replace(',', ' '));  
            o.Add(oMeetingMessageData.IsUnmodified.Replace(',', ' '));             
            o.Add(oMeetingMessageData.ItemClass.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.LastModifiedName.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.LastModifiedTime.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.MimeContent.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.NormalizedBody.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.ParentFolderId.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.PolicyTag.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.Preview.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.ReceivedBy.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.ReceivedRepresenting.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.References.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.ReminderDueBy.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.ReminderMinutesBeforeStart.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.ReplyTo.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.ResponseType.Replace(',', ' '));  
            o.Add(oMeetingMessageData.RetentionDate.Replace(',', ' ')); 
         
            o.Add(oMeetingMessageData.Sender.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.Sensitivity.Replace(',', ' ')); 
            
            o.Add(oMeetingMessageData.Size.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.StoreEntryId.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.Subject.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.TextBody.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.ToRecipients .Replace(',', ' '));

            o.Add(oMeetingMessageData.UniqueBody.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.VotingInformation.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.WebClientEditFormQueryString.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.WebClientReadFormQueryString.Replace(',', ' ')); 

            o.Add(oMeetingMessageData.PidLidCleanGlobalObjectId.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.PidLidGlobalObjectId.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.PidLidAppointmentRecur.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.PidLidClientIntent.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.ClientInfoString   .Replace(',', ' ')); 
            o.Add(oMeetingMessageData.EntryId .Replace(',', ' ')); 
            o.Add(oMeetingMessageData.IsHidden.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.FolderPath.Replace(',', ' ')); 
            o.Add(oMeetingMessageData.LogTriggerAction.Replace(',', ' ')); 
            
            // ...

            StringBuilder oSB = new StringBuilder();
            for (int i = 0; i < o.Count - 1; i++ )
            {
                oSB.AppendFormat("{0}, ", o[i]);
            }
 
            sRet = oSB.ToString();
            sRet = sRet.TrimEnd(TrimChars);
            sRet = sRet.Replace("\r\n", "");  // There shold be no crlf
            return sRet;
        }

        public string GetMeetingMessageDataAsXml(MeetingMessageData oMeetingMessageData)
        {
            string sXML = string.Empty;
            List<string> h = GetMeetingMessageDataHeadersAsList();
            List<string> d = GetMeetingMessageDataAsList(oMeetingMessageData);

            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("MeetingMessage");
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

            o.Add("PidLidCleanGlobalObjectId");
            o.Add("PidLidGlobalObjectId");
            o.Add("PidLidAppointmentRecur");
            o.Add("PidLidClientIntent");
            o.Add("ClientInfoString");
            o.Add("EntryId");
            o.Add("IsHidden");
            o.Add("FolderPath");
            o.Add("LogTriggerAction");

            return o;
        }

        public string GetMeetingMessageDataAsCsvHeaders()
        {
            char[] TrimChars = { ',', ' ' };
            string sRet = string.Empty;
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

            o.Add("PidLidCleanGlobalObjectId");
            o.Add("PidLidGlobalObjectId");
            o.Add("PidLidAppointmentRecur");
            o.Add("PidLidClientIntent");
            o.Add("ClientInfoString");
            o.Add("EntryId");
            o.Add("IsHidden");
            o.Add("FolderPath");
            o.Add("LogTriggerAction");

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
    }
}
