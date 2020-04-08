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
using EWSEditor.PropertyInformation;
using EWSEditor.Common.EwsHelpers;

namespace EWSEditor.Common.Exports
{


    public class CalendarExport
    { 
        private static ExtendedPropertyDefinition Prop_PR_FOLDER_PATH = new ExtendedPropertyDefinition(0x66B5, MapiPropertyType.String);   // Folder Path - PR_Folder_Path

  
        private static ExtendedPropertyDefinition PidLidClientIntent = new ExtendedPropertyDefinition(new Guid("11000E07-B51B-40D6-AF21-CAA85EDAB1D0"), 0x0015, MapiPropertyType.Integer); // dispidClientIntent
        private static ExtendedPropertyDefinition ClientInfoString = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x000B, MapiPropertyType.String); //  
        private static ExtendedPropertyDefinition LogTriggerAction = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x0006, MapiPropertyType.String); //  
        private static ExtendedPropertyDefinition PidLidCleanGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0023, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PidLidGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0003, MapiPropertyType.Binary);

       // private static ExtendedPropertyDefinition Prop_PR_START_DATE_ETC = new ExtendedPropertyDefinition(0x3019, MapiPropertyType.SystemTime); // PR_START_DATE_ETC SystemTime for items
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
 
        //private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_DATE = new ExtendedPropertyDefinition(0x301F, MapiPropertyType.SystemTime);
         //private static ExtendedPropertyDefinition Prop_PR_START_DATE_ETC = new ExtendedPropertyDefinition(0x3019, MapiPropertyType.String); // PR_START_DATE_ETC  GUID 0x30190102



        private static ExtendedPropertyDefinition PR_SENT_REPRESENTING_EMAIL_ADDRESS = new ExtendedPropertyDefinition(0x0065, MapiPropertyType.String);
        private static ExtendedPropertyDefinition PR_SENDER_EMAIL_ADDRESS = new ExtendedPropertyDefinition(0x4030, MapiPropertyType.String);
        private static ExtendedPropertyDefinition ptagSenderSimpleDispName  = new ExtendedPropertyDefinition(0x0C1F, MapiPropertyType.String);

        private static ExtendedPropertyDefinition PR_PARENT_ENTRYID = new ExtendedPropertyDefinition(0x0E09, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PR_MESSAGE_FLAGS = new ExtendedPropertyDefinition(0x0E07, MapiPropertyType.Integer); // PT_LONG
        private static ExtendedPropertyDefinition PR_MSG_STATUS = new ExtendedPropertyDefinition(0x0E17, MapiPropertyType.Integer);// PT_LONG
        private static ExtendedPropertyDefinition PR_MESSAGE_DELIVERY_TIME = new ExtendedPropertyDefinition(0x0E06, MapiPropertyType.SystemTime);   // PT_SYSTIME  
        private static ExtendedPropertyDefinition PR_CONVERSATION_TOPIC = new ExtendedPropertyDefinition(0x0070, MapiPropertyType.String);   
        private static ExtendedPropertyDefinition PR_CONVERSATION_ID  = new ExtendedPropertyDefinition(0x3013, MapiPropertyType.Binary);   
        private static ExtendedPropertyDefinition PPR_CONVERSATION_INDEX = new ExtendedPropertyDefinition(0x0071, MapiPropertyType.Binary);   
        private static ExtendedPropertyDefinition PR_CONTROL_FLAGS = new ExtendedPropertyDefinition(0x3F00, MapiPropertyType.Integer);// PT_LONG
 
        // New:

         //public static ExtendedPropertyDefinition PidLidCurrentVersion = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x00008552, MapiPropertyType.Long);  
        public static ExtendedPropertyDefinition PidLidCurrentVersionName = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x00008554, MapiPropertyType.String);  
        public static ExtendedPropertyDefinition PidNameCalendarUid = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x001F, MapiPropertyType.String);
        public static ExtendedPropertyDefinition PidLidOrganizerAlias = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008243, MapiPropertyType.String);  
        
        public static ExtendedPropertyDefinition PidTagSenderSmtpAddress = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x5D01, MapiPropertyType.String);
        public static ExtendedPropertyDefinition PidLidAppointmentStateFlags = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008217, MapiPropertyType.Integer);


        public static ExtendedPropertyDefinition PidLidInboundICalStream = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x0102, MapiPropertyType.Binary);   
        public static ExtendedPropertyDefinition PidLidAppointmentAuxiliaryFlags = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008207, MapiPropertyType.Integer);
        public static ExtendedPropertyDefinition PidLidRecurrencePattern = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008232, MapiPropertyType.String);
        public static ExtendedPropertyDefinition PidLidRecurrenceType = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008231, MapiPropertyType.Integer);
        public static ExtendedPropertyDefinition PidLidRecurring = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008223, MapiPropertyType.Boolean); // "dispidRecurring, http://schemas.microsoft.com/mapi/recurring", "Calendar", "[MS-OXCDATA], [MS-OXCICAL], [MS-OXOCAL], [MS-OXOSFLD], [MS-OXWAVLS], [MS-XWDCAL]"));
        public static ExtendedPropertyDefinition PidLidAppointmentRecur = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008216, MapiPropertyType.Binary); // "dispidApptRecur, http://schemas.microsoft.com/mapi/apptrecur", "Calendar", "[MS-OXCICAL], [MS-OXOCAL], [MS-OXORMDR], [MS-OXOTASK],[MS-XWDCAL]"));

 
        //public static ExtendedPropertyDefinition PidLidAppointmentStartDate = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008212, MapiPropertyType.SystemTime);
        //public static ExtendedPropertyDefinition PidLidAppointmentStartTime = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x0000820F, MapiPropertyType.SystemTime);

        public static ExtendedPropertyDefinition PidLidAppointmentStartWhole = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x0000820D, MapiPropertyType.SystemTime); // "PidLidAppointmentStartWhole", "dispidApptStartWhole, http://schemas.microsoft.com/mapi/apptstartwhole", "Calendar", "[MS-OXCICAL], [MS-OXOCAL], [MS-OXOPFFB], [MS-XWDCAL]"));
        public static ExtendedPropertyDefinition PidLidAppointmentEndWhole = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x0000820E, MapiPropertyType.SystemTime); // "PidLidAppointmentEndWhole", "dispidApptEndWhole, 
 
        //public static ExtendedPropertyDefinition PidLidAppointmentStartWhole = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x0000820D, MapiPropertyType.SystemTime);
        
         private static ExtendedPropertyDefinition PidNameCalendarIsOrganizer = new ExtendedPropertyDefinition(new Guid("00062002-0000-0000-C000-000000000046"), 0x000B, MapiPropertyType.Boolean);  

        public static ExtendedPropertyDefinition PidNameFrom = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.InternetHeaders, "From", MapiPropertyType.String);  // PidNameFrom -  Its the Organizer.
        public static ExtendedPropertyDefinition PidNameHttpmailFrom = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.PublicStrings, "urn:schemas:httpmail:from", MapiPropertyType.String); // PidNameHttpmailFromEmail - 
        public static ExtendedPropertyDefinition PidNameHttpmailFromEmail = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.PublicStrings, "urn:schemas:httpmail:fromemail", MapiPropertyType.String); // PidNameHttpmailFromEmail          

        public static ExtendedPropertyDefinition PidTagSenderEmailAddress = new ExtendedPropertyDefinition(0x0C1F, MapiPropertyType.String); //  "PidTagSenderEmailAddress", "PR_SENDER_EMAIL_ADDRESS,PR_SENDER_EMAIL_ADDRESS_A, PR_SENDER_EMAIL_ADDRESS_W", "Address Properties", "[MS-OXCFXICS], [MS-OXCICAL], [MS-OXCSPAM], [MS-OXOMSG],[MS-OXORSS], [MS-OXOTASK], [MS-OXPSVAL], [MS-OXTNEF]"));        
        public static ExtendedPropertyDefinition PidTagSenderFlags = new ExtendedPropertyDefinition(0x4019, MapiPropertyType.Integer); // "PidTagSenderFlags", "ptagSenderFlags", "Miscellaneous Properties", "[MS-OXCFXICS], [MS-OXTNEF]")); 
        public static ExtendedPropertyDefinition PidTagSenderName = new ExtendedPropertyDefinition(0x0C1A, MapiPropertyType.String);  // 
        public static ExtendedPropertyDefinition PidTagSenderSimpleDisplayName = new ExtendedPropertyDefinition(0x4030, MapiPropertyType.String);   

        public static ExtendedPropertyDefinition PidTagSentRepresentingEmailAddress = new ExtendedPropertyDefinition(0x0065, MapiPropertyType.String); // PR_SENT_REPRESENTING_EMAIL_ADDRESS,PR_SENT_REPRESENTING_EMAIL_ADDRESS_A,PR_SENT_REPRESENTING_EMAIL_ADDRESS_W"
        public static ExtendedPropertyDefinition PidTagSentRepresentingFlags = new ExtendedPropertyDefinition(0x401A, MapiPropertyType.Integer);  // ptagSentRepresentingFlags
        public static ExtendedPropertyDefinition PidTagSentRepresentingName = new ExtendedPropertyDefinition(0x0042, MapiPropertyType.String);   // // ptagSentRepresentingName, PR_SENT_REPRESENTING_NAME,PR_SENT_REPRESENTING_NAME_A,PR_SENT_REPRESENTING_NAME_W        public string PidTagSentRepresentingSimpleDisplayName = new ExtendedPropertyDefinition(0x4031, MapiPropertyType.String);  // ptagSentRepresentingName, PR_SENT_REPRESENTING_NAME,PR_SENT_REPRESENTING_NAME_A,PR_SENT_REPRESENTING_NAME_W       
        public static ExtendedPropertyDefinition PidTagSentRepresentingSimpleDisplayName = new ExtendedPropertyDefinition(0x4031, MapiPropertyType.String);  // PidTagSentRepresentingSimpleDisplayName", "ptagSentRepresentingSimpleDispName",  
        
        public static ExtendedPropertyDefinition PidTagProcessed = new ExtendedPropertyDefinition(0x7D01, MapiPropertyType.Boolean); // (PidTagProcessed, new KnownExtendedPropertyInfo("PidTagProcessed", "PR_PROCESSED", "Calendar", "[MS-OXCICAL], [MS-OXOCAL], [MS-OXOTASK]"));
        // public static ExtendedPropertyDefinition PidLidResponseStatus = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008218, MapiPropertyType.Long); //"dispidResponseStatus, urn:schemas:calendar:attendeestatus,http://schemas.microsoft.com/mapi/responsestatus", "Meetings", "[MS-OXCICAL], [MS-OXOCAL], [MS-XWDCAL]"));
        public static ExtendedPropertyDefinition PidLidIsException = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0000000A, MapiPropertyType.Boolean); // "PidLidIsException", "LID_IS_EXCEPTION, http://schemas.microsoft.com/mapi/is_exception", "Meetings", "[MS-OXCICAL], [MS-OXOCAL], [MS-OXWAVLS], [MS-XWDCAL]"));
        public static ExtendedPropertyDefinition PidTagCreatorName = new ExtendedPropertyDefinition(0x3FF8, MapiPropertyType.String);  // "PidTagCreatorName", "PR_CREATOR_NAME, PR_CREATOR_NAME_A, ptagCreatorName,PR_CREATOR_NAME_W", "General Message Properties", "[MS-OXCFXICS], [MS-OXCMSG], [MS-OXTNEF]"));
        public static ExtendedPropertyDefinition PidTagCreatorSimpleDisplayName = new ExtendedPropertyDefinition(0x4038, MapiPropertyType.String);  // "PidTagCreatorSimpleDisplayName", "ptagCreatorSimpleDispName", "TransportEnvelope", "[MS-OXTNEF]"));

 
 

        //PR_CreatorEmailAddr http://stackoverflow.com/questions/30911510/getting-information-from-delegated-email-account-from-appointment-inspector-wind
        // PR_CreatorEmailAddr
        // PidNameCalendarIsOrganizer ............................................................................

        // ClientMachineName may be PidLidCurrentVersionName
        // ClientBuildVersion  may be PidLidCurrentVersion
        // PidLidCurrentVersion PSETID_Common {00062008-0000-0000-C000-000000000046}  0x00008552  PtypInteger32
        // PidLidCurrentVersionName  PSETID_Common {00062008-0000-0000-C000-000000000046}   0x00008554 string
        // 2.400 PidNameCalendarUid  Specifies the unique identifier of an appointment or meeting.  0x001F string  {00020329-0000-0000-C000-000000000046}
        // 2.195 PidLidOrganizerAlias  Specifies the email address of the organizer.  PSETID_Appointment {00062002-0000-0000-C000-000000000046} 0x00008243 string
        // PidLidCurrentVersion  Specifies the build number of the client application that sent the message.  
        // 2.386 PidNameCalendarIsOrganizer  PS_PUBLIC_STRINGS {00020329-0000-0000-C000-000000000046}   (urn:schemas:calendar:isorganizer)  bool
        
        // https://msdn.microsoft.com/en-us/library/ee203891(v=exchg.80).aspx
        // 2.89 PidLidCurrentVersionName
        // 2.997 PidTagSenderSmtpAddress 0x5D01   Contains the SMTP email address format of the e–mail address of the sending mailbox owner.
        // 2.995 PidTagSenderName  0x0C1A  2.995  Contains the display name of the sending mailbox owner.
        //  

        // 2.386 PidNameCalendarIsOrganizer Specifies whether an attendee is the organizer of an appointment or meeting.
        //2.400 PidNameCalendarUid
        // 2.724 PidTagHtml

        // 2.5 PidLidAllAttendeesString  Specifies a list of all the attendees except for the organizer, including resources and unsendable attendees.
        // 2.37 PidLidAttendeeCriticalChange
        // 2.343 PidLidToAttendeesString   Description: Contains a list of all of the sendable attendees who are also required attendees.
        // 2.230 PidLidResourceAttendees   Description: Identifies resource attendees for the appointment or meeting.
        // 2.229 PidLidRequiredAttendees Description: Identifies required attendees for the appointment or meeting.
        // 2.194 PidLidOptionalAttendees  Specifies optional attendees.
        // 2.50 PidLidCcAttendeesString  Contains a list of all the sendable attendees who are also optional attendees.
        // 2.130 PidLidFExceptionalAttendees   Description: Indicates that the object is a Recurring Calendar object with one or more exceptions, and that at least one of the Exception Embedded Message objects has at least one RecipientRow structure, as described in [MS-OXCDATA] section 2.8.3.
        // 2.341 PidLidTimeZoneDescription    Specifies a human-readable description of the time zone that is represented by the data in the PidLidTimeZoneStruct property (section 2.342).
        // 2.340 PidLidTimeZone   Description: Specifies information about the time zone of a recurring meeting.
        // 2.191 PidLidOldWhenEndWhole  Description: Indicates the original value of the PidLidAppointmentEndWhole property (section 2.14) before a meeting update
        // 2.188 PidLidOccurrences     Indicates the number of occurrences in the recurring appointment or meeting.
        // 2.148 PidLidInboundICalStream  Contains the contents of the iCalendar MIME part of the original MIME message.
        // https://msdn.microsoft.com/en-us/library/ee625158(v=exchg.80).aspx
        // 2.2.1.55 PidTagSentRepresentingEmailAddress The PidTagSentRepresentingEmailAddress property ([MS-OXPROPS] section 2.1004) contains an e-mail address, as specified by the EmailAddress field of the RecipientRow structure ([MS-OXCDATA] section 2.8.3.2), for the end user who is represented by the sending mailbox owner. If a sending mailbox owner is sending on his or her own behalf, this property is set to the value of the PidTagSenderEmailAddress property (section 2.2.1.49).
        // 2.647 PidTagCreatorName   Contains the name of the creator of a Message object.
        // READ: https://msdn.microsoft.com/en-us/library/ee237379(v=exchg.80).aspx


       // MailboxAuditLogEvent
        //https://msdn.microsoft.com/en-us/library/microsoft.exchange.data.directory.management.mailboxauditlogevent.clientmachinename(v=exchg.150).aspx
        // MailboxAuditLogEvent.ClientIPAddress
        // MailboxAuditLogEvent.ClientMachineName property

        // 2.130 PidLidFExceptionalAttendees
 
        // PT_LONG  0003
 

 

       public AppointmentData GetAppointmentDataFromItem(
           ExchangeService oExchangeService, 
           ItemId oItemId,
           List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions, 
           List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions,
           bool bIncludeBody, 
           bool bIncludeMime)
        {
            string ServerVersion = oExchangeService.RequestedServerVersion.ToString();
            PropertySet oPropertySet = null;
            oPropertySet = GetCalendarPropset(ServerVersion, bIncludeBody, bIncludeMime, oExtendedPropertyDefinitions);


            oExchangeService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            Appointment oAppointment = Appointment.Bind(oExchangeService, oItemId, oPropertySet);
            AppointmentData oAppointmentData = new AppointmentData();

            SetAppointmentData(oAppointment, ref oAppointmentData, oAdditionalPropertyDefinitions);

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

 

        public bool SaveAppointmentsToFolder(
            ExchangeService oExchangeService, 
            List<ItemId> oItemIds, 
            List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions,
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions 
            )
        {
            bool bRet = true;
            string sFolder = string.Empty;
            if (GetFolderPath(ref sFolder))
            {
                SaveAppointmentsToFolder(
                    oExchangeService,
                    oItemIds,
                    sFolder,
                    oAdditionalPropertyDefinitions,
                    oExtendedPropertyDefinitions
                    );
            }
            return bRet;
        }
         
     

        public bool SaveAppointmentBlobToFolder(ExchangeService oExchangeService, ItemId oItemId,  string sFile) 
        {
            bool bRet = false;
            string ServerVersion = oExchangeService.RequestedServerVersion.ToString();

            if (ServerVersion.StartsWith("Exchange2007") || ServerVersion == "Exchange2010")
            {
                MessageBox.Show("Exchange 2010 SP1 or later is requred to use ExportItems to do a blob export of an item.", "Invalid version for blob export using ExportItem");
                    return false;
            }

            oExchangeService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
            Appointment oAppointment = Appointment.Bind(oExchangeService, oItemId);

            // Exchange2010_SP1 is the minimal version
            bRet = EWSEditor.Exchange.ExportUploadHelper.ExportItemPost(ServerVersion,oItemId.UniqueId, sFile);
 
            bRet = true;
            return bRet;
        }

        public bool SaveAppointmentsToFolder(
            ExchangeService oExchangeService, 
            List<ItemId> oItemIds, 
            string sFolder, 
            List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions, 
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions 
            )
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
                oAppointmentData = GetAppointmentDataFromItem(
                    oExchangeService, 
                    oItemId,
                    oAdditionalPropertyDefinitions,
                    oExtendedPropertyDefinitions,
                    false,
                    false);

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




        public void SetAppointmentData(Appointment oAppointment, ref AppointmentData oAppointmentData, List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions)
        {
            AppointmentData oCA = new AppointmentData();

 

            // Appointment:
  
            StringBuilder oSB = new StringBuilder();

            //string sProp;
            //foreach (ExtendedPropertyDefinition ap in oAdditionalPropertiesDefs)
            //{
            //    //sProp = GetExtendedProp_String_AsString(oAppointment, Prop_PR_STORE_ENTRYID);
            //}

            //foreach (ExtendedPropertyDefinition apd in oAppointmentData.AdditionalExtendedPropertyDefinitions)
            //{
                 
            //}
    
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


            try
            {
                oAppointmentData.IsOnlineMeeting = oAppointment.IsOnlineMeeting.ToString();
            }
            catch (Exception exIsOnlineMeeting)
            {
                System.Diagnostics.Debug.WriteLine(exIsOnlineMeeting.ToString());
                oAppointmentData.IsOnlineMeeting = "";
            }
            oAppointmentData.IsResend = oAppointment.IsResend.ToString();
            oAppointmentData.IsDraft = oAppointment.IsDraft.ToString();

            oAppointmentData.Size = oAppointment.Size.ToString();
            oAppointmentData.HasAttachments = oAppointment.HasAttachments.ToString();


 
            oAppointmentData.PidNameCalendarIsOrganizer = EwsExtendedPropertyHelper.GetExtendedProp_Bool_AsString(oAppointment, PidNameCalendarIsOrganizer);


            oAppointmentData.PidLidCleanGlobalObjectId = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oAppointment, PidLidCleanGlobalObjectId);
            oAppointmentData.PidLidGlobalObjectId = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oAppointment, PidLidGlobalObjectId);
            oAppointmentData.PidLidAppointmentRecur = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oAppointment, PidLidAppointmentRecur);
            oAppointmentData.PidLidClientIntent = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oAppointment, PidLidClientIntent);
            oAppointmentData.ClientInfoString = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, ClientInfoString);
            oAppointmentData.StoreEntryId = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oAppointment, Prop_PR_STORE_ENTRYID);
            oAppointmentData.EntryId = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oAppointment, Prop_PR_ENTRYID);
            oAppointmentData.RetentionDate = EwsExtendedPropertyHelper.GetExtendedProp_DateTime_AsString(oAppointment, Prop_PR_RETENTION_DATE);
            oAppointmentData.IsHidden = EwsExtendedPropertyHelper.GetExtendedProp_Bool_AsString(oAppointment, Prop_PR_IS_HIDDEN);
            oAppointmentData.LogTriggerAction = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, LogTriggerAction);

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
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            //if (oAppointment.AllowNewTimeProposal != null) oAppointmentData.AllowNewTimeProposal = oAppointment.AllowNewTimeProposal.ToString();
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (oAppointment.AllowedResponseActions != null) 
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                oAppointmentData.AllowedResponseActions = oAppointment.AllowedResponseActions.ToString();
             
            oAppointmentData.AdjacentMeetingCount = oAppointment.AdjacentMeetingCount.ToString();
            oAppointmentData.AppointmentSequenceNumber = oAppointment.AppointmentSequenceNumber.ToString();
            try
            {
                oAppointmentData.Body = oAppointment.Body.Text;
            }
            catch (Exception ex)
            {
                oAppointmentData.Body = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
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
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            oAppointmentData.Culture = oAppointment.Culture.ToString();

            try
            {
                oAppointmentData.DateTimeReceived = oAppointment.DateTimeReceived.ToString();
            }
            catch (Exception ex)
            {
                oAppointmentData.DateTimeReceived = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
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
                System.Diagnostics.Debug.WriteLine(ex.ToString());
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
                System.Diagnostics.Debug.WriteLine(ex.ToString());
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
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            if (oAppointment.When != null) oAppointmentData.When = oAppointment.When.ToString();
            
            try
            { 
                oAppointmentData.WebClientEditFormQueryString = oAppointment.WebClientEditFormQueryString.ToString();
            }
            catch (Exception ex)
            {
                oAppointmentData.WebClientEditFormQueryString = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            try
            { 
                oAppointmentData.WebClientReadFormQueryString = oAppointment.WebClientReadFormQueryString.ToString();
            }
            catch (Exception ex)
            {
                oAppointmentData.WebClientReadFormQueryString = "";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            oAppointmentData.UniqueId = oAppointment.Id.UniqueId;



            SetAppointmentRecurrenceData(oAppointment, ref oAppointmentData);

            //string s = AppointmentHelper.GetAttendeeStatusAsInfoString(oAppointment);
            oAppointmentData.AttendeeStatus = AppointmentHelper.GetAttendeeStatusAsInfoString(oAppointment);

            oAppointmentData.PidLidAppointmentRecur = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oAppointment, PidLidAppointmentRecur);
            oAppointmentData.PidLidClientIntent = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oAppointment, PidLidClientIntent);
            oAppointmentData.ClientInfoString = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, ClientInfoString);
            oAppointmentData.StoreEntryId = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oAppointment, Prop_PR_STORE_ENTRYID);
            oAppointmentData.EntryId = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oAppointment, Prop_PR_ENTRYID);
            oAppointmentData.RetentionDate = EwsExtendedPropertyHelper.GetExtendedProp_DateTime_AsString(oAppointment, Prop_PR_RETENTION_DATE);
            oAppointmentData.IsHidden = EwsExtendedPropertyHelper.GetExtendedProp_Bool_AsString(oAppointment, Prop_PR_IS_HIDDEN);
            oAppointmentData.LogTriggerAction = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, LogTriggerAction);

            //oAppointmentData.PidLidCurrentVersion = GetExtendedProp_Int_AsString(oAppointment, PidLidCurrentVersion);
            oAppointmentData.PidLidCurrentVersionName = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, PidLidCurrentVersionName);
            oAppointmentData.PidNameCalendarUid = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oAppointment, PidNameCalendarUid);
            oAppointmentData.PidLidOrganizerAlias = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, PidLidOrganizerAlias);
            oAppointmentData.PidTagSenderSmtpAddress = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oAppointment, PidTagSenderSmtpAddress);


            oAppointmentData.PidLidInboundICalStream = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oAppointment, PidLidInboundICalStream);
            oAppointmentData.PidLidAppointmentAuxiliaryFlags = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oAppointment, PidLidAppointmentAuxiliaryFlags);
            oAppointmentData.PidLidRecurrencePattern = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, PidLidRecurrencePattern);
            oAppointmentData.PidLidRecurrenceType = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oAppointment, PidLidRecurrenceType);
            oAppointmentData.PidLidRecurring = EwsExtendedPropertyHelper.GetExtendedProp_Bool_AsString(oAppointment, PidLidRecurring);

            oAppointmentData.PidLidAppointmentRecur = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oAppointment, PidLidAppointmentRecur);

            //oAppointmentData.PidLidAppointmentStartDate = GetExtendedProp_DateTime_AsString(oAppointment, PidLidAppointmentStartDate);
            //oAppointmentData.PidLidAppointmentStartTime = GetExtendedProp_DateTime_AsString(oAppointment, PidLidAppointmentStartTime);

            oAppointmentData.PidLidAppointmentStartWhole = EwsExtendedPropertyHelper.GetExtendedProp_DateTime_AsString(oAppointment, PidLidAppointmentStartWhole);
            oAppointmentData.PidLidAppointmentEndWhole = EwsExtendedPropertyHelper.GetExtendedProp_DateTime_AsString(oAppointment, PidLidAppointmentEndWhole);

            oAppointmentData.PidLidAppointmentStateFlags = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oAppointment, PidLidAppointmentStateFlags);

            oAppointmentData.PidNameFrom = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, PidNameFrom);
            oAppointmentData.PidNameHttpmailFrom = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, PidNameHttpmailFrom);
            oAppointmentData.PidNameHttpmailFromEmail = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, PidNameHttpmailFromEmail);

            oAppointmentData.PidTagSenderEmailAddress = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, PidTagSenderEmailAddress);
            oAppointmentData.PidTagSenderFlags = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oAppointment, PidTagSenderFlags);
            oAppointmentData.PidTagSenderName = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, PidTagSenderName);
            oAppointmentData.PidTagSenderSimpleDisplayName = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, PidTagSenderSimpleDisplayName);

            oAppointmentData.PidTagSentRepresentingEmailAddress = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, PidTagSentRepresentingEmailAddress);
            oAppointmentData.PidTagSentRepresentingFlags = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oAppointment, PidTagSentRepresentingFlags);
            oAppointmentData.PidTagSentRepresentingName = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, PidTagSentRepresentingName);
            oAppointmentData.PidTagSentRepresentingSimpleDisplayName = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, PidTagSentRepresentingSimpleDisplayName);

            oAppointmentData.PidTagProcessed = EwsExtendedPropertyHelper.GetExtendedProp_Bool_AsString(oAppointment, PidTagProcessed);
            // oAppointmentData.PidLidResponseStatus = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oAppointment, PidLidResponseStatus);
            oAppointmentData.PidLidIsException = EwsExtendedPropertyHelper.GetExtendedProp_Bool_AsString(oAppointment, PidLidIsException);

            oAppointmentData.PidTagCreatorName = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, PidTagCreatorName);
            oAppointmentData.PidTagCreatorSimpleDisplayName = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oAppointment, PidTagCreatorSimpleDisplayName);
            oAppointmentData.PidNameCalendarIsOrganizer = EwsExtendedPropertyHelper.GetExtendedProp_Bool_AsString(oAppointment, PidNameCalendarIsOrganizer);

            if (oAdditionalPropertyDefinitions != null)
            {
                foreach (AdditionalPropertyDefinition oAPD in oAdditionalPropertyDefinitions)
                {
                    //oAppointmentData.AdditionalExtendedPropertyDefinitions.Add
                }
            }
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


        //public PropertySet GetCalendarPropset(string ExchangeVersion)
        //{
        //    return GetCalendarPropset(ExchangeVersion, false, false, false);

            
        //}

        //List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions

 
        public static PropertySet GetCalendarPropset(string ExchangeVersion, bool bIncludeBodies, bool bIncludeMime, List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions)
        { 
            
            PropertySet appointmentPropertySet = new PropertySet(
                
                BasePropertySet.IdOnly,
                 
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

 
            if (bIncludeBodies == true)  // 2007 +
            {
                appointmentPropertySet.Add(AppointmentSchema.Body);
     
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

            //if (bIncludeAttachments == true)
            //    appointmentPropertySet.Add(AppointmentSchema.Attachments);


            // Need to add these:
 
            appointmentPropertySet.Add(PidLidCurrentVersionName);
            appointmentPropertySet.Add(PidNameCalendarUid);
            appointmentPropertySet.Add(PidLidOrganizerAlias);
            appointmentPropertySet.Add(PidTagSenderSmtpAddress);
            appointmentPropertySet.Add(PidLidInboundICalStream);
            appointmentPropertySet.Add(PidLidAppointmentAuxiliaryFlags);
            appointmentPropertySet.Add(PidLidRecurrencePattern);
            appointmentPropertySet.Add(PidLidRecurrenceType);
            appointmentPropertySet.Add(PidLidRecurring);
            appointmentPropertySet.Add(PidLidAppointmentRecur);

            //appointmentPropertySet.Add(PidLidAppointmentStartDate);
            //appointmentPropertySet.Add(PidLidAppointmentStartTime);
 
         
            appointmentPropertySet.Add(PidLidAppointmentStartWhole);
            appointmentPropertySet.Add(PidLidAppointmentEndWhole);
            appointmentPropertySet.Add(PidLidAppointmentStateFlags);

            appointmentPropertySet.Add(PidNameFrom); // PidNameFrom -  Its the Organizer.
            appointmentPropertySet.Add(PidNameHttpmailFrom);
            appointmentPropertySet.Add(PidNameHttpmailFromEmail);

            appointmentPropertySet.Add(PidTagSenderEmailAddress);
            appointmentPropertySet.Add(PidTagSenderFlags);
            appointmentPropertySet.Add(PidTagSenderName);
            appointmentPropertySet.Add(PidTagSenderSimpleDisplayName);

            appointmentPropertySet.Add(PidTagSentRepresentingEmailAddress);
            appointmentPropertySet.Add(PidTagSentRepresentingFlags);
            appointmentPropertySet.Add(PidTagSentRepresentingName);
            appointmentPropertySet.Add(PidTagSentRepresentingSimpleDisplayName);

            appointmentPropertySet.Add(PidTagProcessed);
            //appointmentPropertySet.Add(PidLidResponseStatus);
            appointmentPropertySet.Add(PidLidIsException);
            appointmentPropertySet.Add(PidTagCreatorName);
            appointmentPropertySet.Add(PidTagCreatorSimpleDisplayName);
            appointmentPropertySet.Add(PidNameCalendarIsOrganizer);
     

 


            // older
            appointmentPropertySet.Add(PidLidAppointmentRecur);
            appointmentPropertySet.Add(PidLidClientIntent);
            appointmentPropertySet.Add(ClientInfoString);
            appointmentPropertySet.Add(LogTriggerAction);
            appointmentPropertySet.Add(PidLidCleanGlobalObjectId);
            appointmentPropertySet.Add(PidLidGlobalObjectId);

            //appointmentPropertySet.Add(Prop_PR_START_DATE_ETC);
            appointmentPropertySet.Add(Prop_PR_RETENTION_PERIOD);
            appointmentPropertySet.Add(Prop_PR_RETENTION_DATE);
            appointmentPropertySet.Add(Prop_PR_POLICY_TAG);
            appointmentPropertySet.Add(Prop_PR_RETENTION_FLAGS);
            appointmentPropertySet.Add(Prop_PR_ARCHIVE_TAG);
            appointmentPropertySet.Add(Prop_PR_ARCHIVE_PERIOD);
            appointmentPropertySet.Add(Prop_PR_ARCHIVE_DATE);

            appointmentPropertySet.Add(Prop_PR_ENTRYID);
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
                    {
                        appointmentPropertySet.Add(AppointmentSchema.NormalizedBody);
                        appointmentPropertySet.Add(AppointmentSchema.TextBody);
                    } 
                    appointmentPropertySet.Add(AppointmentSchema.OnlineMeetingSettings);
                    //appointmentPropertySet.Add(AppointmentSchema.PolicyTag);            // covered by extended property
                    appointmentPropertySet.Add(AppointmentSchema.Preview);
                    //appointmentPropertySet.Add(AppointmentSchema.RetentionDate);        // covered by extended property
                    //appointmentPropertySet.Add(AppointmentSchema.StoreEntryId);         // covered by extended property
                     
 
                }

                //if (!ExchangeVersion.StartsWith("Exchange_2013"))   
                //{
                //    appointmentPropertySet.Add(AppointmentSchema.TextBody);
                //}

                foreach (ExtendedPropertyDefinition oEPD in oExtendedPropertyDefinitions)
                {
                    appointmentPropertySet.Add(oEPD);
                }

                 
            }

            return appointmentPropertySet;
        }

        public List<string> GetAppointmentDataAsList(AppointmentData oAppointmentData)
        {
            List<string> o = new List<string> { };

            o.Add(CleanString(oAppointmentData.UniqueId));
            o.Add(CleanString(oAppointmentData.FolderPath));
            o.Add(CleanString(oAppointmentData.OrganizerName));
            o.Add(CleanString(oAppointmentData.OrganizerAddress));
            o.Add(CleanString(oAppointmentData.ParentFolderId));

            o.Add(CleanString(oAppointmentData.Subject));
            o.Add(CleanString(oAppointmentData.DisplayTo));
            o.Add(CleanString(oAppointmentData.DisplayCc));

            o.Add(CleanString(oAppointmentData.RequiredAttendees));
            o.Add(CleanString(oAppointmentData.OptionalAttendees));
            o.Add(CleanString(oAppointmentData.DateTimeCreated));
            o.Add(CleanString(oAppointmentData.LastModifiedName));
            o.Add(CleanString(oAppointmentData.LastModifiedTime));

            o.Add(CleanString(oAppointmentData.HasAttachments));
            o.Add(CleanString(oAppointmentData.ItemClass));
            o.Add(CleanString(oAppointmentData.Start));
            o.Add(CleanString(oAppointmentData.End));

            o.Add(CleanString(oAppointmentData.IsAllDayEvent));
            o.Add(CleanString(oAppointmentData.IsCancelled));
            o.Add(CleanString(oAppointmentData.AppointmentState));
            o.Add(CleanString(oAppointmentData.AppointmentType));

            o.Add(CleanString(oAppointmentData.IsRecurring));
            o.Add(CleanString(oAppointmentData.IsReminderSet));
            o.Add(CleanString(oAppointmentData.IsOnlineMeeting));
            o.Add(CleanString(oAppointmentData.RetentionDate));


            o.Add(CleanString(oAppointmentData.IsResend));
            o.Add(CleanString(oAppointmentData.IsDraft));
            o.Add(CleanString(oAppointmentData.EntryId));
            o.Add(CleanString(oAppointmentData.StoreEntryId));

            o.Add(CleanString(oAppointmentData.PidLidAppointmentRecur));
            o.Add(CleanString(oAppointmentData.PidLidClientIntent));
            o.Add(CleanString(oAppointmentData.ClientInfoString));
            o.Add(CleanString(oAppointmentData.LogTriggerAction));

            o.Add(CleanString(oAppointmentData.PidLidCleanGlobalObjectId));
            o.Add(CleanString(oAppointmentData.PidLidGlobalObjectId));
            o.Add(CleanString(oAppointmentData.IsHidden));

            o.Add(CleanString(oAppointmentData.AppointmentReplyTime));
            o.Add(CleanString(oAppointmentData.AllowNewTimeProposal));
            o.Add(CleanString(oAppointmentData.AllowedResponseActions));
            o.Add(CleanString(oAppointmentData.AdjacentMeetingCount));
            o.Add(CleanString(oAppointmentData.AppointmentSequenceNumber)); 

            o.Add(CleanString(oAppointmentData.Body));
            o.Add(CleanString(oAppointmentData.Categories));
            o.Add(CleanString(oAppointmentData.ConferenceType));
            o.Add(CleanString(oAppointmentData.ConflictingMeetingCount));
            o.Add(CleanString(oAppointmentData.ConflictingMeetings));
            o.Add(CleanString(oAppointmentData.ConversationId));

            o.Add(CleanString(oAppointmentData.Culture));
            o.Add(CleanString(oAppointmentData.DateTimeReceived));
            o.Add(CleanString(oAppointmentData.Duration));
            o.Add(CleanString(oAppointmentData.EffectiveRights));

            o.Add(CleanString(oAppointmentData.ICalDateTimeStamp));
            o.Add(CleanString(oAppointmentData.ICalRecurrenceId));
            o.Add(CleanString(oAppointmentData.ICalUid));
            o.Add(CleanString(oAppointmentData.Importance));
            o.Add(CleanString(oAppointmentData.InReplyTo));

            o.Add(CleanString(oAppointmentData.InternetMessageHeaders));
            o.Add(CleanString(oAppointmentData.IsResponseRequested));
            o.Add(CleanString(oAppointmentData.IsSubmitted));
            o.Add(CleanString(oAppointmentData.IsUnmodified));
            o.Add(CleanString(oAppointmentData.LegacyFreeBusyStatus));
            o.Add(CleanString(oAppointmentData.Location));

            o.Add(CleanString(oAppointmentData.MeetingRequestWasSent));
            o.Add(CleanString(oAppointmentData.MeetingWorkspaceUrl));
            o.Add(CleanString(oAppointmentData.MimeContent));
            o.Add(CleanString(oAppointmentData.MyResponseType));
            o.Add(CleanString(oAppointmentData.NetShowUrl));
            o.Add(CleanString(oAppointmentData.ModifiedOccurrences));

            o.Add(CleanString(oAppointmentData.ReminderDueBy));
            o.Add(CleanString(oAppointmentData.ReminderMinutesBeforeStart));
            o.Add(CleanString(oAppointmentData.Resources));
            o.Add(CleanString(oAppointmentData.Size));
            o.Add(CleanString(oAppointmentData.StartTimeZone));
            o.Add(CleanString(oAppointmentData.Sensitivity));

            o.Add(CleanString(oAppointmentData.TextBody));
            o.Add(CleanString(oAppointmentData.When));
            o.Add(CleanString(oAppointmentData.WebClientEditFormQueryString));
            o.Add(CleanString(oAppointmentData.WebClientReadFormQueryString));

            // New:

 
            //o.Add(CleanString(oAppointmentData.PidLidCurrentVersion));
            o.Add(CleanString(oAppointmentData.PidLidCurrentVersionName));
            o.Add(CleanString(oAppointmentData.PidNameCalendarUid));
            o.Add(CleanString(oAppointmentData.PidLidOrganizerAlias));
            o.Add(CleanString(oAppointmentData.PidTagSenderSmtpAddress));

            o.Add(CleanString(oAppointmentData.PidLidInboundICalStream));
            o.Add(CleanString(oAppointmentData.PidLidAppointmentAuxiliaryFlags));
            o.Add(CleanString(oAppointmentData.PidLidRecurrencePattern));

            o.Add(CleanString(oAppointmentData.PidLidRecurrenceType));
            o.Add(CleanString(oAppointmentData.PidLidRecurring));
            o.Add(CleanString(oAppointmentData.PidLidAppointmentRecur));
 
            o.Add(CleanString(oAppointmentData.PidLidAppointmentStartWhole));
            o.Add(CleanString(oAppointmentData.PidLidAppointmentEndWhole));
            o.Add(CleanString(oAppointmentData.PidLidAppointmentStateFlags));

            o.Add(CleanString(oAppointmentData.PidNameFrom)); // PidNameFrom -  Its the Organizer.
            o.Add(CleanString(oAppointmentData.PidNameHttpmailFrom));
            o.Add(CleanString(oAppointmentData.PidNameHttpmailFromEmail));

            o.Add(CleanString(oAppointmentData.PidTagSenderEmailAddress));
            o.Add(CleanString(oAppointmentData.PidTagSenderFlags));
            o.Add(CleanString(oAppointmentData.PidTagSenderName));
            o.Add(CleanString(oAppointmentData.PidTagSenderSimpleDisplayName));

            o.Add(CleanString(oAppointmentData.PidTagSentRepresentingEmailAddress));
            o.Add(CleanString(oAppointmentData.PidTagSentRepresentingFlags));
            o.Add(CleanString(oAppointmentData.PidTagSentRepresentingName));
            o.Add(CleanString(oAppointmentData.PidTagSentRepresentingSimpleDisplayName));

            o.Add(CleanString(oAppointmentData.PidTagProcessed));
            //o.Add(CleanString(oAppointmentData.PidLidResponseStatus));
            o.Add(CleanString(oAppointmentData.PidLidIsException));
            o.Add(CleanString(oAppointmentData.PidTagCreatorName));
            o.Add(CleanString(oAppointmentData.PidTagCreatorSimpleDisplayName));
            o.Add(CleanString(oAppointmentData.PidNameCalendarIsOrganizer));

      

            // recurring
            o.Add(CleanString(oAppointmentData.StartingDateRange));
            o.Add(CleanString(oAppointmentData.RecurrStartTime));
            o.Add(CleanString(oAppointmentData.RecurrEndTime));

            o.Add(CleanString(oAppointmentData.RecurrencePattern));
            o.Add(CleanString(oAppointmentData.RecurrencePatternInterval));
            o.Add(CleanString(oAppointmentData.RecurrencePatternDaysOfTheWeek));
            o.Add(CleanString(oAppointmentData.RecurrMonthlyPatternDayOfMonth));
            o.Add(CleanString(oAppointmentData.RecurrMonthlyPatternEveryMonths));

            o.Add(CleanString(oAppointmentData.RecurrDayOfTheWeekIndex));
            o.Add(CleanString(oAppointmentData.RecurrDayOfWeek));
            o.Add(CleanString(oAppointmentData.RecurrInterval));

            o.Add(CleanString(oAppointmentData.RecurrYearlyOnSpecificDay));
            o.Add(CleanString(oAppointmentData.RecurrYearlyOnSpecificDayForMonthOf));
            o.Add(CleanString(oAppointmentData.RecurrYearlyOnDayPatternDayOfWeekIndex));
            o.Add(CleanString(oAppointmentData.RecurrYearlyOnDayPatternDayOfWeek));
            o.Add(CleanString(oAppointmentData.RecurrYearlyOnDayPatternMonth));

            o.Add(CleanString(oAppointmentData.RangeHasEnd));
            o.Add(CleanString(oAppointmentData.RangeNumberOccurrences));
            o.Add(CleanString(oAppointmentData.RangeEndByDate));

 
  
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

        public string GetAppointmentDataAsCsv2(AppointmentData oAppointmentData, CsvExportOptions oCsvExportOptions)
        {

            //Todo:  Add coding for new paramater:  CsvExportOptions oCsvExportOption) - need to use it for encoding each string.

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
                    ////string x = h[i];
                    //if (d[i] != null)
                    //{ 
                    //    d[i] = EWSEditor.Common.Exports.AdditionalProperties.DoStringHandling(d[i], CsvStringHandling.HexEncode);

                    //    //d[i] = d[i].Replace(',', ' ');
                    //}
                    //else
                    //    d[i] = "";


                    if (d[i] == null) // No null data
                        d[i] = "";

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
            sRet = sRet.Replace("\r\n", "");
            return sRet;

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
 
 

            // older

            o.Add("PidTagProcessed");
            //o.Add("PidLidResponseStatus");
            o.Add("PidLidIsException");
            o.Add("PidTagCreatorName");
            o.Add("PidTagCreatorSimpleDisplayName");
            o.Add("PidNameCalendarIsOrganizer");



            // recurring

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



        public string GetAppointmentDataAsCsvHeaders(List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions)
        {
            char[] TrimChars = { ',', ' ' };
            string sRet = string.Empty;

            List<string> o = GetAppointmentDataHeadersAsList();


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

// Replace:

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


        // GetDiagMeetingMessageDataAsCsv
        public string GetDiagtAppointmenDataAsCsv(AppointmentData oAppointmentData)
        {
            string sRet = string.Empty;
            char[] TrimChars = { ',', ' ' };
           
            List<string> h = GetDiagHeadersAsList();
            List<string> d = GetDiagAppointmentDataAsList(oAppointmentData);

            string ToText = string.Empty;
            //byte[] oFromBytes = null;

            for (int i = 0; i < d.Count - 1; i++)
            {
 
                if (d[i] != null)
                    d[i] = d[i].Replace(',', ' ');
                else
                    d[i] = "";
              
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

        public List<string> GetDiagAppointmentDataAsList(AppointmentData oAppointmentData)
        {
            List<string> o = new List<string> { };
 
            return o;


       
        }
 
         


    }
}
