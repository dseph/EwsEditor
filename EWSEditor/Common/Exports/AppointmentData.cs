using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWSEditor.Common.Exports;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Common.Exports
{
    public class AppointmentData
    {   
        // Appointment master properties:
        public string UniqueId = string.Empty;
        public string FolderPath = string.Empty;
        public string OrganizerName = string.Empty;
        public string OrganizerAddress = string.Empty;
        public string ParentFolderId = string.Empty;

        public string Subject = string.Empty;
        public string DisplayTo = string.Empty;

         
        public string DisplayCc = string.Empty;

        public string RequiredAttendees = string.Empty;
        public string OptionalAttendees = string.Empty;

        public string DateTimeCreated = string.Empty;

        public string LastModifiedName = string.Empty;
        public string LastModifiedTime = string.Empty;
        public string HasAttachments = string.Empty;
        public string ItemClass = string.Empty;
        public string Start = string.Empty;
        public string End = string.Empty;

 
        public string AppointmentState = string.Empty;
        public string AppointmentType = string.Empty;

        public string IsAllDayEvent = string.Empty;
        public string IsCancelled = string.Empty;

        public string IsRecurring = string.Empty;
        public string IsReminderSet = string.Empty;
        public string IsOnlineMeeting = string.Empty;

        public string IsResponseRequested = string.Empty;
        public string IsSubmitted = string.Empty;
        public string IsUnmodified = string.Empty;

        public string IsResend = string.Empty;
        public string IsDraft = string.Empty;

        public string RetentionDate = string.Empty;

        public string EntryId = string.Empty;
        public string StoreEntryId = string.Empty;

       // public string PidLidAppointmentRecur = string.Empty;
        public string PidLidClientIntent = string.Empty;
        public string ClientInfoString = string.Empty;
        public string LogTriggerAction = string.Empty;
        public string PidLidCleanGlobalObjectId = string.Empty;
        public string PidLidGlobalObjectId = string.Empty;
        public string IsHidden = string.Empty;

        public string AppointmentReplyTime = string.Empty;
        public string AllowNewTimeProposal = string.Empty;
        public string AllowedResponseActions = string.Empty;
        public string AdjacentMeetingCount = string.Empty;
        public string AppointmentSequenceNumber = string.Empty;
        public string Body = string.Empty;
        public string Categories = string.Empty;
        public string ConferenceType = string.Empty;
        public string ConflictingMeetingCount = string.Empty;
        public string ConflictingMeetings = string.Empty;
        public string ConversationId = string.Empty;

        public string Culture = string.Empty;
        public string DateTimeReceived = string.Empty;
        public string Duration = string.Empty;
        public string EffectiveRights = string.Empty;
    
        public string ICalDateTimeStamp = string.Empty;
        public string ICalRecurrenceId = string.Empty;
        public string ICalUid = string.Empty;
        public string Importance = string.Empty;
        public string InReplyTo = string.Empty;

        public string InternetMessageHeaders = string.Empty;


        public string LegacyFreeBusyStatus = string.Empty;
        public string Location = string.Empty;
        public string MeetingRequestWasSent = string.Empty;
        public string MeetingWorkspaceUrl = string.Empty;
        public string MimeContent = string.Empty;
        public string MyResponseType = string.Empty;
        public string NetShowUrl = string.Empty;
        public string ModifiedOccurrences = string.Empty;
        public string ReminderDueBy = string.Empty;
        public string ReminderMinutesBeforeStart = string.Empty;
        public string Resources = string.Empty;
        public string Size = string.Empty;
        public string StartTimeZone = string.Empty;
        public string Sensitivity = string.Empty;
        public string TextBody = string.Empty;
        public string When = string.Empty;
        public string WebClientEditFormQueryString = string.Empty;
        public string WebClientReadFormQueryString = string.Empty;

 
        //private string PidLidInboundICalStream = string.Empty;
        //private string PidLidAppointmentAuxiliaryFlags = string.Empty;
        //private string PidLidRecurrencePattern = string.Empty;
        //private string PidLidRecurrenceType = string.Empty;
        //private string PidLidRecurring = string.Empty;
        //private string PidLidAppointmentRecur = string.Empty;
        ////private string PidLidAppointmentStartWhole = 
        //private string PidLidAppointmentStartDate = string.Empty;
        //private string PidLidAppointmentStartTime = string.Empty;
        //private string PidLidAppointmentStartWhole = string.Empty;
        //private string PidLidAppointmentStateFlags = string.Empty;
        //private string PidNameFrom = string.Empty;
        //private string PidNameHttpmailFrom = string.Empty;
        //private string PidNameHttpmailFromEmail = string.Empty;
        //private string PidTagSenderEmailAddress = string.Empty;
        //private string PidTagSenderFlags = string.Empty;
        //// private static PidTagSenderName = new (0x0C1A, MapiPropertyType.String);  // 
        //private string PidTagSenderSimpleDisplayName = string.Empty;
        //private string PidTagSentRepresentingEmailAddress = string.Empty;
        //private string PidTagSentRepresentingFlags = string.Empty;
        //private string PidTagSentRepresentingName = string.Empty;
        //private string PidTagSentRepresentingSimpleDisplayName = string.Empty;
        //private string PidTagProcessed = string.Empty;
        //private string PidLidResponseStatus = string.Empty;
        //private string PidLidIsException = string.Empty;
        //private string PidTagCreatorName = string.Empty;
        //private string PidTagCreatorSimpleDisplayName = string.Empty;

        // Additional master

        public string PidLidCurrentVersion = string.Empty;
        public string PidLidCurrentVersionName = string.Empty;
        public string PidNameCalendarUid = string.Empty;
        public string PidLidOrganizerAlias = string.Empty;
        public string PidTagSenderSmtpAddress = string.Empty;

        public string PidLidAppointmentAuxiliaryFlags = string.Empty;
        public string PidLidRecurrencePattern = string.Empty;
        public string PidLidRecurrenceType = string.Empty;
        public string PidLidRecurring = string.Empty;
        public string PidLidAppointmentRecur = string.Empty;  //PidLidAppointmentRecur  is dispidApptRecur
        public string PidLidAppointmentStartDate = string.Empty;
        public string PidLidAppointmentStartTime = string.Empty;
 

        public string PidLidAppointmentStartWhole = string.Empty;
        public string PidLidAppointmentEndWhole= string.Empty;
        public string PidLidAppointmentStateFlags = string.Empty;
        public string PidNameCalendarIsOrganizer  = string.Empty;

        public string PidNameFrom = string.Empty;
        public string PidNameHttpmailFrom = string.Empty;
        public string PidNameHttpmailFromEmail = string.Empty;
        public string PidTagSenderEmailAddress = string.Empty;
        public string PidTagSenderFlags = string.Empty;
        public string PidTagSenderName = string.Empty;
        public string PidTagSenderSimpleDisplayName = string.Empty;
        public string PidTagSentRepresentingEmailAddress = string.Empty;
        public string PidTagSentRepresentingFlags = string.Empty;
        public string PidTagSentRepresentingName = string.Empty;
        public string PidTagSentRepresentingSimpleDisplayName = string.Empty;
        public string PidTagProcessed = string.Empty;
        //public string PidLidResponseStatus = string.Empty;
        public string PidLidIsException = string.Empty;
        public string PidLidInboundICalStream = string.Empty;
        public string PidTagCreatorName = string.Empty;
        public string PidTagCreatorSimpleDisplayName = string.Empty;

 
 
        // Recurrence pattern properties:
        public string StartingDateRange = string.Empty;
        public string RecurrStartTime = string.Empty;
        public string RecurrEndTime = string.Empty;
        public string RecurrencePattern = string.Empty;
        public string RecurrencePatternInterval = string.Empty;
        public string RecurrencePatternDaysOfTheWeek = string.Empty;
        public string RecurrMonthlyPatternDayOfMonth = string.Empty;
        public string RecurrMonthlyPatternEveryMonths = string.Empty;
        public string RecurrDayOfTheWeekIndex = string.Empty;
        public string RecurrDayOfWeek = string.Empty;
        public string RecurrInterval = string.Empty;
        public string RecurrYearlyOnSpecificDay = string.Empty;
        public string RecurrYearlyOnSpecificDayForMonthOf = string.Empty;
        public string RecurrYearlyOnDayPatternDayOfWeekIndex = string.Empty;
        public string RecurrYearlyOnDayPatternDayOfWeek = string.Empty;
        public string RecurrYearlyOnDayPatternMonth = string.Empty;
        public string RangeHasEnd = string.Empty;
        public string RangeNumberOccurrences = string.Empty;
        public string RangeEndByDate = string.Empty;

        public string AttendeeStatus = string.Empty;  // calculated by AttachmentExport 

        //public List<ExtendedProperty> AdditionalExtendedProperties = null;
 
   }
}
