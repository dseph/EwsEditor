using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWSEditor.Common.Exports
{
    public class MeetingMessageData
    {
 
        public string AllowedResponseActions = string.Empty;            
        public string ApprovalRequestData = string.Empty;    
        public string ArchiveTag = string.Empty;
        public string AssociatedAppointmentId = string.Empty; 
        // public string Attachments // 
        public string BccRecipients = string.Empty;
        public string Body = string.Empty;
        public string Categories = string.Empty; 
        public string CcRecipients = string.Empty;   
        public string ConversationId = string.Empty; 
        public string ConversationIndex = string.Empty;
        public string ConversationTopic = string.Empty; 
        public string Culture = string.Empty; 
        public string DateTimeCreated = string.Empty;
        public string DateTimeReceived = string.Empty;  
        public string DateTimeSent = string.Empty;  
        public string DisplayCc = string.Empty;
        public string DisplayTo = string.Empty;
        public string EffectiveRights = string.Empty;
        public string EntityExtractionResult = string.Empty;  
        public string ExtendedProperties = string.Empty;
        public string Flag = string.Empty;    
        public string From = string.Empty;  
        public string HasAttachments = string.Empty;  
        public string HasBeenProcessed = string.Empty;
        public string ICalDateTimeStamp = string.Empty;  
        public string ICalRecurrenceId = string.Empty; 
        public string ICalUid = string.Empty;    
        public string IconIndex = string.Empty; 
        public string UniqueId = string.Empty;  // Id
        public string Importance = string.Empty;
        public string InstanceKey = string.Empty;  
        public string InternetMessageHeaders = string.Empty;  
        public string InternetMessageId = string.Empty; 
        public string IsAssociated = string.Empty;          
        public string IsDelegated = string.Empty;
        public string IsDeliveryReceiptRequested = string.Empty;
        public string IsDraft = string.Empty; 
        public string IsFromMe = string.Empty;          
        public string IsOrganizer = string.Empty;   
        public string IsOutOfDate = string.Empty;   
        public string IsRead = string.Empty;   
        public string IsReadReceiptRequested = string.Empty; 
        public string IsReminderSet = string.Empty;
        public string IsResend = string.Empty;  
        public string IsResponseRequested = string.Empty;
        public string IsSubmitted = string.Empty; 
        public string IsUnmodified = string.Empty;            
        public string ItemClass = string.Empty;
        public string LastModifiedName = string.Empty;   
        public string MimeContent = string.Empty;
        public string NormalizedBody = string.Empty;
        public string ParentFolderId = string.Empty;
        public string PolicyTag = string.Empty;
        public string Preview = string.Empty;
        public string ReceivedBy = string.Empty;
        public string ReceivedRepresenting = string.Empty;
        public string References = string.Empty;
        public string ReminderDueBy = string.Empty;
        public string ReminderMinutesBeforeStart = string.Empty;
        public string ReplyTo = string.Empty;
        public string ResponseType = string.Empty; 
        public string RetentionDate = string.Empty;
         
        public string Sender = string.Empty;
        public string Sensitivity = string.Empty;
            
        public string Size = string.Empty;
        public string StoreEntryId = string.Empty;
        public string Subject = string.Empty;
        public string TextBody = string.Empty;
        public string ToRecipients  = string.Empty;
        public string UniqueBody = string.Empty;
        public string VotingInformation = string.Empty;
        public string WebClientEditFormQueryString = string.Empty;
        public string WebClientReadFormQueryString = string.Empty;


        // Randy's tool: TLMsg
        // ApptAuxFlags     // AppointmentAuxiliaryFlags
        // ApptEndWhole     // MapiEndTime              // x  End?
        // AppRecurrBlob    //AppointmentRecurrenceBlob
        //public string PidLidAppointmentRecur = string.Empty; // AppRecurrBlob    //AppointmentRecurrenceBlob  // https://msdn.microsoft.com/en-us/library/ee204268(v=exchg.80).aspx
        // ApptRecurring    // AppointmentRecurring
        // ApptStartWhole   // MapiStartTime            // x  Start?
        // AppointmentState  //AppointmentStateFlags
        // AttendeeCC       // DisplayAttendeesCc       // x    DisplayCc?
        // AttendeeTo       // DisplayAttendeesTo       // x    ToRecipients?
        // BusyStatus   // FreeBusyStatus               // PidLidBusyStatus             // https://msdn.microsoft.com/en-us/library/ee219533(v=exchg.80).aspx
        //public string BusyStatus = string.Empty;      // ?? its on the Appointmet object - LegacyFreeBusyStatus
        //public string CalProcessed = string.Empty;
        //public string CleanGOID = string.Empty;       // PidLidCleanGlobalObjectId    // https://msdn.microsoft.com/en-us/library/ee203416(v=exchg.80).aspx
        //public string ClientInfoString = string.Empty;
        //public string ClientIntent = string.Empty;
        //public string EndTime = string.Empty;         //??
        //public string EndWallClock = string.Empty;
        //public string From = string.Empty;
        //public string IsAllDayEvent = string.Empty;
        //public string IsCancelled = string.Empty;
        //public string IsException = string.Empty;
        //public string IsHijacked = string.Empty;
        //public string IsOrganizer = string.Empty;
        //public string IsProcessed = string.Empty;
        //public string IsRecurring = string.Empty;
        //public string IsSeriesCancelled = string.Empty;
        //public string IsSoftDeleted = string.Empty;
        //public string ItemMsgClass = string.Empty;
        //public string LastModTime = string.Empty;
        //public string Location = string.Empty;
        //public string MeetReqType = string.Empty;
        //public string OrganizerAddr = string.Empty;
        //public string OrganizerName = string.Empty;
        //public string OrigLastModTime = string.Empty;
        //public string ParentFolder = string.Empty;
        //public string RcvdBy = string.Empty;
        //public string RcvdRepresenting = string.Empty;
        //public string RecurPattern = string.Empty;
        //public string ResponsibleUser = string.Empty;
        //public string SenderAddress = string.Empty;
        //public string StartTime = string.Empty;
        //public string StartWallClock = string.Empty;
        //public string Subject = string.Empty;
        //public string TimeZoneDesc = string.Empty;
        //public string TriggerAction = string.Empty;
        //public string ViewEndTime = string.Empty;
        //public string ViewStartTime = string.Empty;

        // https://social.msdn.microsoft.com/Forums/pt-BR/018b0b69-8345-40db-bee7-7ae6237bb916/appointmentitem-timezone-event?forum=outlookdev

        //             _Appointment.LegacyFreeBusyStatus = (LegacyFreeBusyStatus)Enum.Parse(typeof(LegacyFreeBusyStatus), cmboLegacyFreeBusyStatus.Text.Trim());
 
        //    AppointmentStateFlags (DASL name http://schemas.microsoft.com/mapi/id/{00062002-0000-0000-C000-000000000046}/82170003)
        //FInvited (DASL name http://schemas.microsoft.com/mapi/id/{00062002-0000-0000-C000-000000000046}/8229000B)
        //    ResponseStatus (DASL name http://schemas.microsoft.com/mapi/id/{00062002-0000-0000-C000-000000000046}/82180003) 

        // PR_INTERNET_MESSAGE_ID, PR_INTERNET_MESSAGE_ID_A  http://schemas.microsoft.com/mapi/proptag/0x1035001E

        // ptagCreatorSimpleDispName Tag: 0x4038001E  Type: PT_STRING8
        // ptagLastModifierSimpleDispName  0x4039001E   PT_STRING8
        // ptagSenderSimpleDispName  0x4030001E PT_STRING8
        // R_DISPLAY_BCC, PR_DISPLAY_BCC_A, ptagDisplayBcc  PR_DISPLAY_BCC_W, PidTagDisplayBcc  0x0E02001E  PT_STRING8
        // PR_MESSAGE_DELIVERY_TIME, PidTagMessageDeliveryTime 0x0E060040  PT_SYSTIME
        // PR_MESSAGE_FLAGS, PidTagMessageFlags, ptagMessageFlags  0x0E070003  PT_LONG
        // PR_MESSAGE_LOCALE_ID, PidTagMessageLocaleId  0x3FF10003  PT_LONG

        // R_SENDER_NAME, PR_SENDER_NAME_A, ptagSenderName  PR_SENDER_NAME_W, PidTagSenderName  0x0C1A001E  PT_STRING8
        // PR_SENT_REPRESENTING_ADDRTYPE, PR_SENT_REPRESENTING_ADDRTYPE_A, ptagSentRepresentingAddrType  PR_SENT_REPRESENTING_ADDRTYPE_W, PidTagSentRepresentingAddressType  0x0064001E  PT_STRING8
        // PR_SENT_REPRESENTING_EMAIL_ADDRESS, PR_SENT_REPRESENTING_EMAIL_ADDRESS_A PR_SENT_REPRESENTING_EMAIL_ADDRESS_W, PidTagSentRepresentingEmailAddress 0x0065001E  PT_STRING8
        // PR_SENT_REPRESENTING_NAME, PR_SENT_REPRESENTING_NAME_A, ptagSentRepresentingName  PR_SENT_REPRESENTING_NAME_W, PidTagSentRepresentingName  0x0042001E  PT_STRING8
        // 
    }
}
