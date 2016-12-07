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
    class ExportMeetingMessage
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
            MeetingMessage oMeetingMessage = MeetingMessage.Bind(oExchangeService, oItemId, GetMeetingMessageDataPropset(false));
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
            oMM.ApprovalRequestData  = oMeetingMessage.ApprovalRequestData.ToString();    
            oMM.ArchiveTag = oMeetingMessage.ArchiveTag.ToString();
            oMM.AssociatedAppointmentId = oMeetingMessage.AssociatedAppointmentId.UniqueId;      
            //oMM.Attachments = oMeetingMessage.Attachments;  
            oMM.BccRecipients = oMeetingMessage.BccRecipients.ToString();  
            oMM.Body  = oMeetingMessage.Body.Text;
            oMM.Categories = oMeetingMessage.Categories.ToString();    
            oMM.CcRecipients = oMeetingMessage.CcRecipients.ToString();    
            oMM.ConversationId = oMeetingMessage.ConversationId.ToString();   
            oMM.ConversationIndex = oMeetingMessage.ConversationIndex.ToString();   
            oMM.ConversationTopic = oMeetingMessage.ConversationTopic.ToString();   
            oMM.Culture = oMeetingMessage.Culture.ToString();    
            oMM.DateTimeCreated = oMeetingMessage.DateTimeCreated.ToString();  
            oMM.DateTimeReceived = oMeetingMessage.DateTimeReceived.ToString();    

            oMM.DateTimeSent = oMeetingMessage.DateTimeSent.ToString();    

            oMM.DisplayCc = oMeetingMessage.DisplayCc.ToString();   
            oMM.DisplayTo = oMeetingMessage.DisplayTo.ToString();   
            
            oMM.EffectiveRights = oMeetingMessage.EffectiveRights.ToString();   
            //oMM.EntityExtractionResult = oMeetingMessage.EntityExtractionResult;    ?
            //oMM.ExtendedProperties = oMeetingMessage.ExtendedProperties;   
            oMM.Flag = oMeetingMessage.Flag.ToString();     
            oMM.From = oMeetingMessage.From.ToString();   
           // oMM.HasAttachments = oMeetingMessage.;   
            oMM.HasBeenProcessed = oMeetingMessage.HasBeenProcessed.ToString();  
            oMM.ICalDateTimeStamp = oMeetingMessage.ICalDateTimeStamp.ToString();    
            oMM.ICalRecurrenceId = oMeetingMessage.ICalRecurrenceId.ToString();   
            oMM.ICalUid = oMeetingMessage.ICalUid.ToString();    
            oMM.IconIndex = oMeetingMessage.IconIndex.ToString();
            oMM.UniqueId = oMeetingMessage.Id.UniqueId;  
            oMM.Importance = oMeetingMessage.Importance.ToString();  
            oMM.InstanceKey = oMeetingMessage.InstanceKey.ToString();    
            oMM.InternetMessageHeaders = oMeetingMessage.InternetMessageHeaders.ToString();   
            oMM.InternetMessageId = oMeetingMessage.InternetMessageId.ToString();    
            oMM.IsAssociated = oMeetingMessage.IsAssociated.ToString();     
            
            oMM.IsDelegated = oMeetingMessage.IsDelegated.ToString();  
            oMM.IsDeliveryReceiptRequested = oMeetingMessage.IsDeliveryReceiptRequested.ToString();  
             
            oMM.IsDraft = oMeetingMessage.IsDraft.ToString();   
            oMM.IsFromMe  = oMeetingMessage.IsFromMe.ToString();  
 
            oMM.IsOrganizer = oMeetingMessage.IsOrganizer.ToString();    
            oMM.IsOutOfDate = oMeetingMessage.IsOutOfDate.ToString();    
            oMM.IsRead  = oMeetingMessage.IsRead.ToString();   
            oMM.IsReadReceiptRequested   = oMeetingMessage.IsReadReceiptRequested.ToString();  
            oMM.IsReminderSet  = oMeetingMessage.IsReminderSet.ToString();  
            oMM.IsResend   = oMeetingMessage.IsResend.ToString();   
            oMM.IsResponseRequested   = oMeetingMessage.IsResponseRequested.ToString();  
            oMM.IsSubmitted   = oMeetingMessage.IsSubmitted.ToString();  
            oMM.IsUnmodified   = oMeetingMessage.IsUnmodified.ToString();   
 
            oMM.ItemClass  = oMeetingMessage.ItemClass; 
            oMM.LastModifiedName = oMeetingMessage.LastModifiedName.ToString();   
            //oMM.MimeContent  = oMeetingMessage.MimeContent.; 
            oMM.NormalizedBody = oMeetingMessage.NormalizedBody.Text; 
            oMM.ParentFolderId  = oMeetingMessage.ParentFolderId.ToString();   
            oMM.PolicyTag  = oMeetingMessage.PolicyTag.ToString();    
            oMM.Preview   = oMeetingMessage.Preview.ToString();
            oMM.ReceivedBy =  oMeetingMessage.ReceivedBy.Name + " <" + oMeetingMessage.ReceivedBy.Address + ">";
            oMM.ReceivedRepresenting   = oMeetingMessage.ReceivedRepresenting.ToString();  
            oMM.References = oMeetingMessage.References; 
            oMM.ReminderDueBy = oMeetingMessage.ReminderDueBy.ToString();  
            oMM.ReminderMinutesBeforeStart  = oMeetingMessage.ReminderMinutesBeforeStart.ToString();
            oMM.ReplyTo = oMeetingMessage.ReplyTo.ToString(); //  //.name+ " <" + oMeetingMessage.ReplyTo.Address + ">";
            oMM.ResponseType = oMeetingMessage.ResponseType.ToString();
            oMM.RetentionDate = oMeetingMessage.RetentionDate.ToString();

            oMM.Sender = oMeetingMessage.Sender.Name + " <" + oMeetingMessage.Sender.Address + ">";
            oMM.Sensitivity = oMeetingMessage.Sensitivity.ToString();
            oMM.Size = oMeetingMessage.Size.ToString();

            oMM.StoreEntryId = oMeetingMessage.StoreEntryId.ToString();

            oMM.Subject = oMeetingMessage.Subject.ToString();
            oMM.TextBody = oMeetingMessage.TextBody.ToString();
            oMM.ToRecipients = oMeetingMessage.ToRecipients.ToString();  
            oMM.UniqueBody = oMeetingMessage.UniqueBody.Text.ToString();
            oMM.VotingInformation = oMeetingMessage.VotingInformation.ToString();   
            oMM.WebClientEditFormQueryString   = oMeetingMessage.WebClientEditFormQueryString;  
            oMM.WebClientReadFormQueryString  = oMeetingMessage.WebClientReadFormQueryString; 

 
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

 

        private PropertySet GetCalendarPropset()
        {
            return GetMeetingMessageDataPropset(false);
        }

        private PropertySet GetMeetingMessageDataPropset(bool bIncludeAttachments)
        {

            PropertySet meetingMessagePropertySet = new PropertySet(BasePropertySet.IdOnly,
                MeetingMessageSchema.AllowedResponseActions,      
                MeetingMessageSchema.ApprovalRequestData,    
                MeetingMessageSchema.ArchiveTag,
                MeetingMessageSchema.AssociatedAppointmentId, 
                // MeetingMessageSchema.Attachments // 
                MeetingMessageSchema.BccRecipients,
                MeetingMessageSchema.Body,
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
                MeetingMessageSchema.IsFromMe,          
                MeetingMessageSchema.IsOrganizer,   
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
                MeetingMessageSchema.MimeContent,
                MeetingMessageSchema.NormalizedBody,
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
                MeetingMessageSchema.UniqueBody,
                MeetingMessageSchema.VotingInformation,
                MeetingMessageSchema.WebClientEditFormQueryString, 
                MeetingMessageSchema.WebClientReadFormQueryString 
            );

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
