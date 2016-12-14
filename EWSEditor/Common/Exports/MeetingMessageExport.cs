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

        public MeetingMessageData GetMeetingMessageDataFromItem(ExchangeService oExchangeService, ItemId oItemId)
        {
            PropertySet oPropertySet = null;
            oPropertySet = GetMeetingMessageDataPropset(false, false);
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

 

        public bool SaveMeetingMessageBlobToFolder(ExchangeService oExchangeService, ItemId oItemId, string sFolder)
        {
            string ServerVersion = oExchangeService.RequestedServerVersion.ToString();
            if (ServerVersion.StartsWith("Exchange2007") || ServerVersion == "Exchange2010")
            {
                MessageBox.Show("Exchange 2010 SP1 or later is requred to use ExportItems to do a blog export of an item.", "Invalid version for blog export using ExportItem");
                return false;
            }
            string tempFile = Path.GetTempFileName().Replace(".tmp", ".bin");
            //string sFile = sFolder + "\\MeetingMessage\\" + tempFile;
            string sFile = sFolder + "\\" + tempFile;
            return SaveMeetingMessageBlobToFolder(oExchangeService, oItemId, sFolder, sFile);
        }

        public bool SaveMeetingMessageBlobToFolder(ExchangeService oExchangeService, ItemId oItemId, string sFolder, string sFile)
        {
            bool bRet = false;
            string ServerVersion = oExchangeService.RequestedServerVersion.ToString();

            if (ServerVersion.StartsWith("Exchange2007") || ServerVersion == "Exchange2010")
            {
                MessageBox.Show("Exchange 2010 SP1 or later is requred to use ExportItems to do a blog export of an item.", "Invalid version for blog export using ExportItem");
                return false;
            }


            MeetingMessage oMeetingMessage = MeetingMessage.Bind(oExchangeService, oItemId);

            // Exchange2010_SP1 is the minimal version
            bRet = EWSEditor.Exchange.ExportUploadHelper.ExportItemPost(ServerVersion, oItemId.UniqueId, sFile);

            bRet = true;
            return bRet;
        }

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
            
            oMM.AllowedResponseActions = oMeetingMessage.AllowedResponseActions.ToString();              
            if (oMeetingMessage.ApprovalRequestData != null) oMM.ApprovalRequestData  = oMeetingMessage.ApprovalRequestData.ToString();
            if (oMeetingMessage.ArchiveTag != null) oMM.ArchiveTag = oMeetingMessage.ArchiveTag.ToString();
            if (oMeetingMessage.AssociatedAppointmentId != null) oMM.AssociatedAppointmentId = oMeetingMessage.AssociatedAppointmentId.UniqueId;    
  
            //oMM.Attachments = oMeetingMessage.Attachments;  
            if (oMeetingMessage.BccRecipients != null) oMM.BccRecipients = oMeetingMessage.BccRecipients.ToString();  
             
            try
            {
                oMM.Body = oMeetingMessage.Body;
            }
            catch (Exception ex)
            {
                oMM.Body = ex.Message.ToString();
            }
            // if (oMeetingMessage.xxxxxx != null) 
            if (oMeetingMessage.Categories != null) oMM.Categories = oMeetingMessage.Categories.ToString();
            if (oMeetingMessage.CcRecipients != null) oMM.CcRecipients = oMeetingMessage.CcRecipients.ToString();
            if (oMeetingMessage.ConversationId != null) oMM.ConversationId = oMeetingMessage.ConversationId.ToString();
            try
            {
                if (oMeetingMessage.ConversationIndex != null) oMM.ConversationIndex = oMeetingMessage.ConversationIndex.ToString();
            }
            catch (Exception ex)
            {
                oMM.ConversationIndex = ex.Message.ToString();
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

            if (oMeetingMessage.EffectiveRights != null) oMM.EffectiveRights = oMeetingMessage.EffectiveRights.ToString();   
            //oMM.EntityExtractionResult = oMeetingMessage.EntityExtractionResult;    ?
            //oMM.ExtendedProperties = oMeetingMessage.ExtendedProperties;   
            if (oMeetingMessage.Flag != null) oMM.Flag = oMeetingMessage.Flag.ToString();
            if (oMeetingMessage.From != null) oMM.From = oMeetingMessage.From.ToString();   
           // oMM.HasAttachments = oMeetingMessage.;   
            
            //if (oMeetingMessage.HasBeenProcessed != null) oMM.HasBeenProcessed = oMeetingMessage.HasBeenProcessed.ToString();
            if (oMeetingMessage.ICalDateTimeStamp != null) oMM.ICalDateTimeStamp = oMeetingMessage.ICalDateTimeStamp.ToString();
            if (oMeetingMessage.ICalRecurrenceId != null) oMM.ICalRecurrenceId = oMeetingMessage.ICalRecurrenceId.ToString();
            if (oMeetingMessage.ICalUid != null) oMM.ICalUid = oMeetingMessage.ICalUid.ToString();
            
            try
            {
                if (oMeetingMessage.IconIndex != null) oMM.ConversationTopic = oMeetingMessage.IconIndex.ToString();
            }
            catch (Exception ex)
            {
                oMM.IconIndex = ex.Message.ToString();
            }
            if (oMeetingMessage.Id != null) oMM.UniqueId = oMeetingMessage.Id.UniqueId;
            if (oMeetingMessage.Importance != null) oMM.Importance = oMeetingMessage.Importance.ToString();
            if (oMeetingMessage.InstanceKey != null) oMM.InstanceKey = oMeetingMessage.InstanceKey.ToString();
            if (oMeetingMessage.InternetMessageHeaders != null) oMM.InternetMessageHeaders = oMeetingMessage.InternetMessageHeaders.ToString();
            if (oMeetingMessage.InternetMessageId != null) oMM.InternetMessageId = oMeetingMessage.InternetMessageId.ToString();
            if (oMeetingMessage.IsAssociated != null) oMM.IsAssociated = oMeetingMessage.IsAssociated.ToString();

            if (oMeetingMessage.IsDelegated != null) oMM.IsDelegated = oMeetingMessage.IsDelegated.ToString();
            try
            {
                if (oMeetingMessage.IsDeliveryReceiptRequested != null) oMM.IsDeliveryReceiptRequested = oMeetingMessage.IsDeliveryReceiptRequested.ToString();
            }
            catch (Exception ex)
            {
                oMM.IsDeliveryReceiptRequested = ex.Message.ToString();
            }

           
            
            if (oMeetingMessage.IsDraft != null) oMM.IsDraft = oMeetingMessage.IsDraft.ToString();
           // if (oMeetingMessage.IsFromMe != null) oMM.IsFromMe = oMeetingMessage.IsFromMe.ToString();//

            //if (oMeetingMessage.IsOrganizer != null) oMM.IsOrganizer = oMeetingMessage.IsOrganizer.ToString();

            if (oMeetingMessage.IsOutOfDate != null) oMM.IsOutOfDate = oMeetingMessage.IsOutOfDate.ToString();
            if (oMeetingMessage.IsRead != null) oMM.IsRead = oMeetingMessage.IsRead.ToString();
            if (oMeetingMessage.IsReadReceiptRequested != null) oMM.IsReadReceiptRequested = oMeetingMessage.IsReadReceiptRequested.ToString();
            //if (oMeetingMessage.IsReminderSet != null) oMM.IsReminderSet = oMeetingMessage.IsReminderSet.ToString();
            try
            {
                if (oMeetingMessage.IsReminderSet != null) oMM.IsReminderSet = oMeetingMessage.IsReminderSet.ToString();
            }
            catch (Exception ex)
            {
                oMM.IsReminderSet = ex.Message.ToString();
            }
            if (oMeetingMessage.IsResend != null) oMM.IsResend = oMeetingMessage.IsResend.ToString();
            if (oMeetingMessage.IsResponseRequested != null) oMM.IsResponseRequested = oMeetingMessage.IsResponseRequested.ToString();
            if (oMeetingMessage.IsSubmitted != null) oMM.IsSubmitted = oMeetingMessage.IsSubmitted.ToString();
            if (oMeetingMessage.IsUnmodified != null) oMM.IsUnmodified = oMeetingMessage.IsUnmodified.ToString();

            if (oMeetingMessage.ItemClass != null) oMM.ItemClass = oMeetingMessage.ItemClass;
            if (oMeetingMessage.LastModifiedName != null) oMM.LastModifiedName = oMeetingMessage.LastModifiedName.ToString();
            if (oMeetingMessage.LastModifiedTime != null) oMM.LastModifiedTime = oMeetingMessage.LastModifiedTime.ToString();
            //oMM.MimeContent  = oMeetingMessage.MimeContent.; 
            
            
            //try
            //{
            //    oMM.NormalizedBody = oMeetingMessage.NormalizedBody;
            //}
            //catch (Exception ex)
            //{
            //    oMM.NormalizedBody = ex.Message.ToString();
            //}
            if (oMeetingMessage.ParentFolderId != null) oMM.ParentFolderId = oMeetingMessage.ParentFolderId.ToString();
            if (oMeetingMessage.PolicyTag != null) oMM.PolicyTag = oMeetingMessage.PolicyTag.ToString();
            if (oMeetingMessage.Preview != null) oMM.Preview = oMeetingMessage.Preview.ToString();
            if (oMeetingMessage.ReceivedBy != null) oMM.ReceivedBy = oMeetingMessage.ReceivedBy.Name + " <" + oMeetingMessage.ReceivedBy.Address + ">";
            if (oMeetingMessage.ReceivedRepresenting != null) oMM.ReceivedRepresenting = oMeetingMessage.ReceivedRepresenting.ToString();
            if (oMeetingMessage.References != null) oMM.References = oMeetingMessage.References.ToString();
            try
            {
                if (oMeetingMessage.ReminderDueBy != null) oMM.ReminderDueBy = oMeetingMessage.ReminderDueBy.ToString();
            }   
            catch (Exception ex)
            {
                oMM.ReminderDueBy = ex.Message.ToString();
            }
           // oMM.ReminderMinutesBeforeStart = GetItemValue(oMeetingMessage.ReminderMinutesBeforeStart);
            
            try
            {
                if (oMeetingMessage.ReminderMinutesBeforeStart != null) oMM.ReminderMinutesBeforeStart = oMeetingMessage.ReminderMinutesBeforeStart.ToString();
            }
            catch (Exception ex)
            {
                oMM.ReminderMinutesBeforeStart = ex.Message.ToString();
            }

            if (oMeetingMessage.ReplyTo != null) oMM.ReplyTo = oMeetingMessage.ReplyTo.ToString(); //  //.name+ " <" + oMeetingMessage.ReplyTo.Address + ">";
            
            try
            { 
                if (oMeetingMessage.ResponseType != null) oMM.ResponseType = oMeetingMessage.ResponseType.ToString();
            }
            catch (Exception ex)
            {
                oMM.ResponseType = ex.Message.ToString();
            }

            if (oMeetingMessage.RetentionDate != null) oMM.RetentionDate = oMeetingMessage.RetentionDate.ToString();

            if (oMeetingMessage.Sender.Name != null) oMM.Sender = oMeetingMessage.Sender.Name + " <" + oMeetingMessage.Sender.Address + ">";
            if (oMeetingMessage.Sensitivity != null) oMM.Sensitivity = oMeetingMessage.Sensitivity.ToString();
            if (oMeetingMessage.Size != null) oMM.Size = oMeetingMessage.Size.ToString();

            if (oMeetingMessage.StoreEntryId != null) oMM.StoreEntryId = oMeetingMessage.StoreEntryId.ToString();

            oMM.Subject = oMeetingMessage.Subject.ToString();
            try
            {
                oMM.TextBody = oMeetingMessage.TextBody;
            }
            catch (Exception ex)
            {
                oMM.TextBody = ex.Message.ToString();
            }
            if (oMeetingMessage.ToRecipients != null) oMM.ToRecipients = oMeetingMessage.ToRecipients.ToString();

            //if (oMeetingMessage.UniqueBody != null) oMM.UniqueBody = oMeetingMessage.UniqueBody.Text.ToString();

            try
            {
                oMM.UniqueBody = oMeetingMessage.UniqueBody;
            }
            catch (Exception ex)
            {
                oMM.UniqueBody = ex.Message.ToString();
            }
             
            //try
            //{
            //    oMM.UniqueBody = oMeetingMessage.UniqueBody;
            //}
            //catch (Exception ex)
            //{
            //    oMM.UniqueBody = ex.Message.ToString();
            //}
            if (oMeetingMessage.VotingInformation != null) oMM.VotingInformation = oMeetingMessage.VotingInformation.ToString();
            if (oMeetingMessage.WebClientEditFormQueryString != null) oMM.WebClientEditFormQueryString = oMeetingMessage.WebClientEditFormQueryString;
            if (oMeetingMessage.WebClientReadFormQueryString != null) oMM.WebClientReadFormQueryString = oMeetingMessage.WebClientReadFormQueryString;

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

            string sFolderPath = string.Empty;
            if (EwsFolderHelper.GetFolderPath(oMeetingMessage.Service, oMeetingMessage.ParentFolderId, ref sFolderPath))
                oMM.FolderPath = sFolderPath;
            else
                oMM.FolderPath = "";

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



        public PropertySet GetCalendarPropset()
        {
            return GetMeetingMessageDataPropset(false, false);
        }

        public static PropertySet GetMeetingMessageDataPropset(bool bIncludeAttachments, bool bIncludeBody)
        {

            PropertySet meetingMessagePropertySet = new PropertySet(BasePropertySet.IdOnly,
                MeetingMessageSchema.AllowedResponseActions,      
                MeetingMessageSchema.ApprovalRequestData,    
                MeetingMessageSchema.ArchiveTag,
                MeetingMessageSchema.AssociatedAppointmentId, 
                // MeetingMessageSchema.Attachments // 
                MeetingMessageSchema.BccRecipients,
                // MeetingMessageSchema.Body, //
                MeetingMessageSchema.Categories, 
                MeetingMessageSchema.CcRecipients,   
                MeetingMessageSchema.ConversationId, 
                MeetingMessageSchema.ConversationIndex,
                MeetingMessageSchema.ConversationTopic, 
                MeetingMessageSchema.Culture, 
                MeetingMessageSchema.DateTimeCreated,
                MeetingMessageSchema.DateTimeReceived,  

                MeetingMessageSchema.DateTimeSent,  

                MeetingMessageSchema.DisplayCc,
                MeetingMessageSchema.DisplayTo,

                MeetingMessageSchema.EffectiveRights,
                MeetingMessageSchema.EntityExtractionResult,  
                MeetingMessageSchema.ExtendedProperties,
                MeetingMessageSchema.Flag,    
                MeetingMessageSchema.From,  
                MeetingMessageSchema.HasAttachments,  
                MeetingMessageSchema.HasBeenProcessed,
                MeetingMessageSchema.ICalDateTimeStamp,  
                MeetingMessageSchema.ICalRecurrenceId, 
                MeetingMessageSchema.ICalUid,    
                MeetingMessageSchema.IconIndex, 
                MeetingMessageSchema.Id,  
                MeetingMessageSchema.Importance,
                MeetingMessageSchema.InstanceKey,  
                MeetingMessageSchema.InternetMessageHeaders,  
                MeetingMessageSchema.InternetMessageId, 
                MeetingMessageSchema.IsAssociated,          
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
                MeetingMessageSchema.MimeContent,
               
                MeetingMessageSchema.ParentFolderId,
                MeetingMessageSchema.PolicyTag,
                MeetingMessageSchema.Preview,
                MeetingMessageSchema.ReceivedBy,
                MeetingMessageSchema.ReceivedRepresenting,
                MeetingMessageSchema.References,
                MeetingMessageSchema.ReminderDueBy,
                MeetingMessageSchema.ReminderMinutesBeforeStart,
                MeetingMessageSchema.ReplyTo,
                MeetingMessageSchema.ResponseType, 
                MeetingMessageSchema.RetentionDate,
         
                MeetingMessageSchema.Sender,
                MeetingMessageSchema.Sensitivity,
            
                MeetingMessageSchema.Size,
                MeetingMessageSchema.StoreEntryId,
                MeetingMessageSchema.Subject,
                MeetingMessageSchema.TextBody,
                MeetingMessageSchema.ToRecipients ,
               
                MeetingMessageSchema.VotingInformation,
                MeetingMessageSchema.WebClientEditFormQueryString, 
                MeetingMessageSchema.WebClientReadFormQueryString 
            );

            if (bIncludeBody == true)
            {
                meetingMessagePropertySet.Add(MeetingMessageSchema.Body);
                //meetingMessagePropertySet.Add(MeetingMessageSchema.NormalizedBody);
                //meetingMessagePropertySet.Add(MeetingMessageSchema.UniqueBody);    
            }

            if (bIncludeAttachments == true)
               meetingMessagePropertySet.Add(MeetingMessageSchema.Attachments);
 
            // Need to add these:
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

            return meetingMessagePropertySet;
        }
    }
}
