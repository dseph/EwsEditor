using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;


using EWSEditor.Common;
using EWSEditor.Exchange;
using EWSEditor.Logging;
using EWSEditor.Resources;
using EWSEditor.Settings;
using System.Net;
using System.Xml;
using Microsoft.Exchange.WebServices.Data;

 

namespace EWSEditor.Forms
{

    public partial class ItemsContentForm : BaseContentForm
    {
        protected const string ColNameSubject = "colSubject";
        protected const string ColNameDisplayTo = "colDisplayTo";
        protected const string ColNameItemClass = "colItemClass";
        protected const string ColNameSize = "colSize";
        protected const string ColNameHasAttach = "colHasAttachments";
        protected const string ColNameDateReceived = "colDateReceived";
        protected const string ColNameDateCreated = "colDateCreated";
        protected const string ColNameDateSent = "colDateSent";
        protected const string ColNameLastModifiedTime = "colLastModifiedTime";
        protected const string ColNameLastModifiedName = "colLastModifiedName";
        protected const string ColNameIsAssociated = "colIsAssociated";
        protected const string ColNameSensitivity = "colSensitivity";
        protected const string ColNameDisplayCc = "colDisplayCC";
        protected const string ColNameCategories = "colCategories";
        protected const string ColNameCulture = "colCulture";
        protected const string ColNameItemId = "colItemId";
        protected const string ColPidLidClientIntent = "colPidLidClientIntent";
        protected const string ColClientInfoString = "colClientInfoString";
        protected const string ColLogTriggerAction = "colLogTriggerAction";
        protected const string ColPidLidGlobalObjectId = "colPidLidGlobalObjectId";
        protected const string ColPidLidCleanGlobalObjectId = "colPidLidCleanGlobalObjectId";
         
        //protected const string ColNameItemId = "colTimeZone";

        private static ExtendedPropertyDefinition Prop_PR_FOLDER_PATH = new ExtendedPropertyDefinition(0x66B5, MapiPropertyType.String);   // Folder Path - PR_Folder_Path
        private static ExtendedPropertyDefinition PidLidCleanGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0023, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PidLidGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0003, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition Prop_PR_STORE_ENTRYID = new ExtendedPropertyDefinition(0x0FFB, MapiPropertyType.Binary);  // PidTagStoreEntryId
        private static ExtendedPropertyDefinition Prop_PR_IS_HIDDEN = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.Boolean);

        //private static ExtendedPropertyDefinition Prop_PR_START_DATE_ETC = new ExtendedPropertyDefinition(0x3019, MapiPropertyType.String); // PR_START_DATE_ETC  GUID 0x30190102

        private static ExtendedPropertyDefinition PidLidClientIntent = new ExtendedPropertyDefinition(new Guid("11000E07-B51B-40D6-AF21-CAA85EDAB1D0"), 0x0015, MapiPropertyType.Integer); // dispidClientIntent
        private static ExtendedPropertyDefinition ClientInfoString = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x000B, MapiPropertyType.String); //  
        private static ExtendedPropertyDefinition LogTriggerAction = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x0006, MapiPropertyType.String); //  

        //private static ExtendedPropertyDefinition Prop_PR_START_DATE_ETC = new ExtendedPropertyDefinition(0x3019, MapiPropertyType.SystemTime); // PR_START_DATE_ETC SystemTime for items
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_PERIOD = new ExtendedPropertyDefinition(0x301A, MapiPropertyType.Integer);  // PR_RETENTION_PERIOD 0x301A    
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_DATE = new ExtendedPropertyDefinition(0x301C, MapiPropertyType.SystemTime); // Prop_PR_RETENTION_DATE 0x301C           
        private static ExtendedPropertyDefinition Prop_PR_POLICY_TAG = new ExtendedPropertyDefinition(0x301B, MapiPropertyType.Binary);  // PR_POLICY_TAG 0x3019   Data type: PtypBinary, 0x0102
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_FLAGS = new ExtendedPropertyDefinition(0x301D, MapiPropertyType.Integer);   // PR_RETENTION_FLAGS 0x301D   
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_TAG = new ExtendedPropertyDefinition(0x3018, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_PERIOD = new ExtendedPropertyDefinition(0x301E, MapiPropertyType.Integer); // Prop_PR_RETENTION_DATE 0x301C    
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_DATE = new ExtendedPropertyDefinition(0x301F, MapiPropertyType.SystemTime);


        //private static ExtendedPropertyDefinition Prop_PR_POLICY_TAG = new ExtendedPropertyDefinition(0x301B, MapiPropertyType.Binary);  // PR_POLICY_TAG 0x3019   Data type: PtypBinary, 0x0102
        //private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_TAG = new ExtendedPropertyDefinition(0x3018, MapiPropertyType.Binary);

       // private static ExtendedPropertyDefinition Prop_PR_POLICY_TAG = new ExtendedPropertyDefinition(0x301B, MapiPropertyType.Binary);  // PR_POLICY_TAG 0x3019   Data type: PtypBinary, 0x0102
        //private static ExtendedPropertyDefinition Prop_PR_RETENTION_FLAGS = new ExtendedPropertyDefinition(0x301D, MapiPropertyType.Integer);   // PR_RETENTION_FLAGS 0x301D   
        //private static ExtendedPropertyDefinition Prop_PR_RETENTION_PERIOD = new ExtendedPropertyDefinition(0x301A, MapiPropertyType.Integer);  // PR_RETENTION_PERIOD 0x301A    
        //private static ExtendedPropertyDefinition Prop_PR_RETENTION_DATE = new ExtendedPropertyDefinition(0x301C, MapiPropertyType.SystemTime); // Prop_PR_RETENTION_DATE 0x301C    
        //private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_PERIOD = new ExtendedPropertyDefinition(0x301E, MapiPropertyType.Integer); // Prop_PR_RETENTION_DATE 0x301C    
        //private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_DATE = new ExtendedPropertyDefinition(0x301F, MapiPropertyType.SystemTime);
        
        
        private static ExtendedPropertyDefinition Prop_PR_ENTRYID = new ExtendedPropertyDefinition(0x0FFF, MapiPropertyType.Binary);  // PidTagEntryId, PidTagMemberEntryId, ptagEntryId
  
        private static ExtendedPropertyDefinition PR_SENT_REPRESENTING_EMAIL_ADDRESS = new ExtendedPropertyDefinition(0x0065, MapiPropertyType.String);
        private static ExtendedPropertyDefinition PR_SENDER_EMAIL_ADDRESS = new ExtendedPropertyDefinition(0x4030, MapiPropertyType.String);
        private static ExtendedPropertyDefinition ptagSenderSimpleDispName = new ExtendedPropertyDefinition(0x0C1F, MapiPropertyType.String);

        private static ExtendedPropertyDefinition PR_PARENT_ENTRYID = new ExtendedPropertyDefinition(0x0E09, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PR_MESSAGE_FLAGS = new ExtendedPropertyDefinition(0x0E07, MapiPropertyType.Integer); // PT_LONG
        private static ExtendedPropertyDefinition PR_MSG_STATUS = new ExtendedPropertyDefinition(0x0E17, MapiPropertyType.Integer);// PT_LONG
        private static ExtendedPropertyDefinition PR_MESSAGE_DELIVERY_TIME = new ExtendedPropertyDefinition(0x0E06, MapiPropertyType.SystemTime);   // PT_SYSTIME  
        private static ExtendedPropertyDefinition PR_CONVERSATION_TOPIC = new ExtendedPropertyDefinition(0x0070, MapiPropertyType.String);
        private static ExtendedPropertyDefinition PR_CONVERSATION_ID = new ExtendedPropertyDefinition(0x3013, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PPR_CONVERSATION_INDEX = new ExtendedPropertyDefinition(0x0071, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PR_CONTROL_FLAGS = new ExtendedPropertyDefinition(0x3F00, MapiPropertyType.Integer);// PT_LONG

        private static ExtendedPropertyDefinition PR_TRANSPORT_MESSAGE_HEADERS = new ExtendedPropertyDefinition(0x007D, MapiPropertyType.String); 


        public static ExtendedPropertyDefinition PidLidCurrentVersion = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x00008552, MapiPropertyType.Integer);
        public static ExtendedPropertyDefinition PidLidCurrentVersionName = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x00008554, MapiPropertyType.String);
        public static ExtendedPropertyDefinition PidNameCalendarUid = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x001F, MapiPropertyType.String);
        public static ExtendedPropertyDefinition PidLidOrganizerAlias = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008243, MapiPropertyType.String);
        //public static ExtendedPropertyDefinition PidNameCalendarIsOrganizer = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x00008552, MapiPropertyType.String);  
        public static ExtendedPropertyDefinition PidTagSenderSmtpAddress = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x5D01, MapiPropertyType.String);
        public static ExtendedPropertyDefinition PidTagSenderName = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x0C1A, MapiPropertyType.String);

        //dispidapptrecur

        private static ExtendedPropertyDefinition PidLidInboundICalStream = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x0102, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PidLidAppointmentAuxiliaryFlags = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008207, MapiPropertyType.Integer);
        private static ExtendedPropertyDefinition PidLidRecurrencePattern = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008232, MapiPropertyType.String);
        private static ExtendedPropertyDefinition PidLidRecurrenceType = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008231, MapiPropertyType.Integer);
        private static ExtendedPropertyDefinition PidLidRecurring = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008223, MapiPropertyType.Boolean); // "dispidRecurring, http://schemas.microsoft.com/mapi/recurring", "Calendar", "[MS-OXCDATA], [MS-OXCICAL], [MS-OXOCAL], [MS-OXOSFLD], [MS-OXWAVLS], [MS-XWDCAL]"));
        private static ExtendedPropertyDefinition PidLidAppointmentRecur = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008216, MapiPropertyType.Binary); // "dispidApptRecur, http://schemas.microsoft.com/mapi/apptrecur", "Calendar", "[MS-OXCICAL], [MS-OXOCAL], [MS-OXORMDR], [MS-OXOTASK],[MS-XWDCAL]"));
        //private static ExtendedPropertyDefinition PidLidAppointmentStartWhole = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x0000820D, MapiPropertyType.SystemTime); // "PidLidAppointmentStartWhole", "dispidApptStartWhole, http://schemas.microsoft.com/mapi/apptstartwhole", "Calendar", "[MS-OXCICAL], [MS-OXOCAL], [MS-OXOPFFB], [MS-XWDCAL]"));
        private static ExtendedPropertyDefinition PidLidAppointmentStartDate = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008212, MapiPropertyType.SystemTime);
        private static ExtendedPropertyDefinition PidLidAppointmentStartTime = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x0000820F, MapiPropertyType.SystemTime);
        private static ExtendedPropertyDefinition PidLidAppointmentStartWhole = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x0000820D, MapiPropertyType.SystemTime);
        private static ExtendedPropertyDefinition PidLidAppointmentStateFlags = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008217, MapiPropertyType.Integer);
        private static ExtendedPropertyDefinition PidNameFrom = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.InternetHeaders, "From", MapiPropertyType.String);  // PidNameFrom -  Its the Organizer.
        private static ExtendedPropertyDefinition PidNameHttpmailFrom = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.PublicStrings, "urn:schemas:httpmail:from", MapiPropertyType.String); // PidNameHttpmailFromEmail - 
        private static ExtendedPropertyDefinition PidNameHttpmailFromEmail = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.PublicStrings, "urn:schemas:httpmail:fromemail", MapiPropertyType.String); // PidNameHttpmailFromEmail          
        private static ExtendedPropertyDefinition PidTagSenderEmailAddress = new ExtendedPropertyDefinition(0x0C1F, MapiPropertyType.String); //  "PidTagSenderEmailAddress", "PR_SENDER_EMAIL_ADDRESS,PR_SENDER_EMAIL_ADDRESS_A, PR_SENDER_EMAIL_ADDRESS_W", "Address Properties", "[MS-OXCFXICS], [MS-OXCICAL], [MS-OXCSPAM], [MS-OXOMSG],[MS-OXORSS], [MS-OXOTASK], [MS-OXPSVAL], [MS-OXTNEF]"));        
        private static ExtendedPropertyDefinition PidTagSenderFlags = new ExtendedPropertyDefinition(0x4019, MapiPropertyType.Integer); // "PidTagSenderFlags", "ptagSenderFlags", "Miscellaneous Properties", "[MS-OXCFXICS], [MS-OXTNEF]")); 
       // private static ExtendedPropertyDefinition PidTagSenderName = new ExtendedPropertyDefinition(0x0C1A, MapiPropertyType.String);  // 
        private static ExtendedPropertyDefinition PidTagSenderSimpleDisplayName = new ExtendedPropertyDefinition(0x4030, MapiPropertyType.String);  // "PidTagSenderName", "PR_SENDER_NAME, PR_SENDER_NAME_A, ptagSenderName,PR_SENDER_NAME_W, urn:schemas:httpmail:sendername,http://schemas.microsoft.com/exchange/sender-name-utf8", "Address Properties Property set", "[MS-OXCFXICS], [MS-OXCICAL], [MS-OXCSYNC], [MS-OXOCAL], [MS-OXOMSG], [MS-OXOPOST], [MS-OXORSS], [MS-OXOTASK], [MS-OXTNEF], [MS-XWDMAIL]")); 
        private static ExtendedPropertyDefinition PidTagSentRepresentingEmailAddress = new ExtendedPropertyDefinition(0x0065, MapiPropertyType.String); // PR_SENT_REPRESENTING_EMAIL_ADDRESS,PR_SENT_REPRESENTING_EMAIL_ADDRESS_A,PR_SENT_REPRESENTING_EMAIL_ADDRESS_W"
        private static ExtendedPropertyDefinition PidTagSentRepresentingFlags = new ExtendedPropertyDefinition(0x401A, MapiPropertyType.Integer);  // ptagSentRepresentingFlags
        private static ExtendedPropertyDefinition PidTagSentRepresentingName = new ExtendedPropertyDefinition(0x0042, MapiPropertyType.String);   // // ptagSentRepresentingName, PR_SENT_REPRESENTING_NAME,PR_SENT_REPRESENTING_NAME_A,PR_SENT_REPRESENTING_NAME_W        public string PidTagSentRepresentingSimpleDisplayName = new ExtendedPropertyDefinition(0x4031, MapiPropertyType.String);  // ptagSentRepresentingName, PR_SENT_REPRESENTING_NAME,PR_SENT_REPRESENTING_NAME_A,PR_SENT_REPRESENTING_NAME_W
        private static ExtendedPropertyDefinition PidTagSentRepresentingSimpleDisplayName = new ExtendedPropertyDefinition(0x4031, MapiPropertyType.String);  // PidTagSentRepresentingSimpleDisplayName", "ptagSentRepresentingSimpleDispName",  
        private static ExtendedPropertyDefinition PidTagProcessed = new ExtendedPropertyDefinition(0x7D01, MapiPropertyType.Boolean); // (PidTagProcessed, new KnownExtendedPropertyInfo("PidTagProcessed", "PR_PROCESSED", "Calendar", "[MS-OXCICAL], [MS-OXOCAL], [MS-OXOTASK]"));
       // private static ExtendedPropertyDefinition PidLidResponseStatus = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 0x00008218, MapiPropertyType.Integer); //"dispidResponseStatus, urn:schemas:calendar:attendeestatus,http://schemas.microsoft.com/mapi/responsestatus", "Meetings", "[MS-OXCICAL], [MS-OXOCAL], [MS-XWDCAL]"));
        private static ExtendedPropertyDefinition PidLidIsException = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0000000A, MapiPropertyType.Boolean); // "PidLidIsException", "LID_IS_EXCEPTION, http://schemas.microsoft.com/mapi/is_exception", "Meetings", "[MS-OXCICAL], [MS-OXOCAL], [MS-OXWAVLS], [MS-XWDCAL]"));
        private static ExtendedPropertyDefinition PidTagCreatorName = new ExtendedPropertyDefinition(0x3FF8, MapiPropertyType.String);  // "PidTagCreatorName", "PR_CREATOR_NAME, PR_CREATOR_NAME_A, ptagCreatorName,PR_CREATOR_NAME_W", "General Message Properties", "[MS-OXCFXICS], [MS-OXCMSG], [MS-OXTNEF]"));
        private static ExtendedPropertyDefinition PidTagCreatorSimpleDisplayName = new ExtendedPropertyDefinition(0x4038, MapiPropertyType.String);  // "PidTagCreatorSimpleDisplayName", "ptagCreatorSimpleDispName", "TransportEnvelope", "[MS-OXTNEF]"));

        

        private List<ItemId> currentItemIds = new List<ItemId>();
        private ItemView contentItemView = new ItemView(GlobalSettings.FindItemViewSize);

        protected ItemsContentForm()
        {
            InitializeComponent();
        }

        protected List<ItemId> CurrentItemIds
        {
            get
            {
                return this.currentItemIds;
            }
        }

        protected ItemView ContentItemView
        {
            get
            {
                return this.contentItemView;
            }
        }

        /// <summary>
        /// Load the form with each of the Items specified in the
        /// ItemId list instead of displaying the contents of a folder.
        /// </summary>
        /// <param name="caption">Text to display in form caption</param>
        /// <param name="itemIds">ItemIds of items to be displayed.</param>
        /// <param name="service">ExchangeService to use.</param>
        /// <param name="parentForm">Parent form that called this method.</param>
        public static void Show(
            string caption,
            List<ItemId> itemIds,
            ExchangeService service,
            Form parentForm)
        {
            ItemsContentForm form = new ItemsContentForm();

            form.CurrentService = service;
            form.PropertyDetailsGrid.CurrentService = service;
            form.currentItemIds = itemIds;
            form.Text = caption;
            form.CallingForm = parentForm;
            form.Show();
        }

        public static void Show(
            string caption,
            List<ItemId> itemIds,
            ExchangeService service,
            Form parentForm,
            PropertySet OverrideDetailPropertySet )
        {
            ItemsContentForm form = new ItemsContentForm();

            form.CurrentService = service;
            form.PropertyDetailsGrid.CurrentService = service;
            form.currentItemIds = itemIds;
            form.Text = caption;
            form.CallingForm = parentForm;
            form.OverrideDetailPropertySet = OverrideDetailPropertySet;

            form.Show();
        }

 

        protected override void SetupForm()
        {
            this.ContentIdColumnName = ColNameItemId;

            if (OverrideDetailPropertySet != null)
            {
                this.DefaultDetailPropertySet = OverrideDetailPropertySet;
            }
            else
            {
 


                this.DefaultDetailPropertySet = new PropertySet(BasePropertySet.FirstClassProperties,
                    Prop_PR_STORE_ENTRYID,
                    Prop_PR_IS_HIDDEN,
                    PidLidCleanGlobalObjectId,
                    PidLidGlobalObjectId,
                    ClientInfoString,
                    PidLidClientIntent,
                    LogTriggerAction,
                   
                   
                    Prop_PR_RETENTION_PERIOD,
                    Prop_PR_RETENTION_DATE,
                    Prop_PR_POLICY_TAG,
                    Prop_PR_RETENTION_FLAGS,
                    Prop_PR_ARCHIVE_TAG,
                    Prop_PR_ARCHIVE_PERIOD,
                    Prop_PR_ARCHIVE_DATE,


                    Prop_PR_ENTRYID,

                    Prop_PR_IS_HIDDEN,
                    PR_SENT_REPRESENTING_EMAIL_ADDRESS,
                    PR_SENDER_EMAIL_ADDRESS,
                    ptagSenderSimpleDispName,
                    PR_PARENT_ENTRYID,
                    PR_MESSAGE_FLAGS,
                    PR_MSG_STATUS,
                    PR_MESSAGE_DELIVERY_TIME,
                    PR_CONVERSATION_TOPIC,
                    PR_CONVERSATION_ID,
                    PPR_CONVERSATION_INDEX,
                    PR_CONTROL_FLAGS,

                    PR_TRANSPORT_MESSAGE_HEADERS,

                    PidLidCurrentVersion,
                    PidLidCurrentVersionName, 
                    PidNameCalendarUid, 
                    PidLidOrganizerAlias,
 
                    PidLidInboundICalStream,
                    PidLidAppointmentAuxiliaryFlags,
                    PidLidRecurrencePattern,
                    PidLidRecurrenceType,
                    PidLidRecurring,
                    PidLidAppointmentRecur,
                    PidLidAppointmentStartDate,
                    PidLidAppointmentStartTime,
                    PidLidAppointmentStartWhole,
                    PidLidAppointmentStateFlags,
                    PidNameFrom,
                    PidNameHttpmailFrom,
                    PidNameHttpmailFromEmail,
                    PidTagSenderEmailAddress,
                    PidTagSenderFlags,
                    PidTagSenderName,
                    PidTagSenderSimpleDisplayName,
                    PidTagSentRepresentingEmailAddress,
                    PidTagSentRepresentingFlags,
                    PidTagSentRepresentingName,
                    PidTagSentRepresentingSimpleDisplayName,
                    PidTagProcessed,
                 
                    PidLidIsException,
                    PidTagCreatorName,
                    PidTagCreatorSimpleDisplayName 
                    );
          
                    //Prop_PR_IS_HIDDEN,
                    //PR_SENT_REPRESENTING_EMAIL_ADDRESS,
                    //PR_SENDER_EMAIL_ADDRESS,
                    //ptagSenderSimpleDispName,
                    //PR_PARENT_ENTRYID,
                    //PR_MESSAGE_FLAGS,
                    //PR_MSG_STATUS,
                    //PR_MESSAGE_DELIVERY_TIME,
                    //PR_CONVERSATION_TOPIC,
                    //PR_CONVERSATION_ID,
                    //PPR_CONVERSATION_INDEX,
                    //PR_CONTROL_FLAGS,
                    //PidLidInboundICalStream,
                    //PidLidAppointmentAuxiliaryFlags,
                    //PidLidRecurrencePattern,
                    //PidLidRecurrenceType,
                    //PidLidRecurring, 
                    //PidLidAppointmentRecur,
                    //PidLidAppointmentStartDate,
                    //PidLidAppointmentStartTime,
                    //PidLidAppointmentStartWhole,
                    //PidLidAppointmentStateFlags,
                    //PidNameFrom,
                    //PidNameHttpmailFrom,
                    //PidNameHttpmailFromEmail,     
                    //PidTagSenderEmailAddress,       
                    //PidTagSenderFlags,
                    //PidTagSenderName,
                    //PidTagSenderSimpleDisplayName,
                    //PidTagSentRepresentingEmailAddress,
                    //PidTagSentRepresentingFlags,
                    //PidTagSentRepresentingName,
                    //PidTagSentRepresentingSimpleDisplayName,
                    //PidTagProcessed,
                   
                    //PidLidIsException,
                    //PidTagCreatorName,
                    //PidTagCreatorSimpleDisplayName 
                
 
            }
            //this.contentItemView.PropertySet.Add(Prop_PR_STORE_ENTRYID);
            //this.contentItemView.PropertySet.Add(Prop_PR_IS_HIDDEN);
            ////this.contentItemView.PropertySet.Add(Prop_PR_FOLDER_PATH);
            //this.contentItemView.PropertySet.Add(PidLidCleanGlobalObjectId);
            //this.contentItemView.PropertySet.Add(PidLidGlobalObjectId);

            //this.contentItemView.PropertySet.Add(PidLidClientIntent);
            //this.contentItemView.PropertySet.Add(ClientInfoString);
            //this.contentItemView.PropertySet.Add(Prop_PR_POLICY_TAG);
            //this.contentItemView.PropertySet.Add(Prop_PR_ARCHIVE_TAG);

            // Create the folder contents property set, including specifying *only*
            // the properties to be displayed in the data grid in order to get the
            // best response time possible.
            this.contentItemView.PropertySet = new PropertySet(BasePropertySet.IdOnly);
            this.contentItemView.PropertySet.Add(ItemSchema.Subject);
            this.contentItemView.PropertySet.Add(ItemSchema.DisplayTo);
            this.contentItemView.PropertySet.Add(ItemSchema.ItemClass);
            this.contentItemView.PropertySet.Add(ItemSchema.Size);
            this.contentItemView.PropertySet.Add(ItemSchema.HasAttachments);
            this.contentItemView.PropertySet.Add(ItemSchema.DateTimeCreated);
            this.contentItemView.PropertySet.Add(ItemSchema.DateTimeReceived);
            this.contentItemView.PropertySet.Add(ItemSchema.DateTimeSent);
            this.contentItemView.PropertySet.Add(ItemSchema.LastModifiedTime);
            this.contentItemView.PropertySet.Add(ItemSchema.LastModifiedName);

            this.contentItemView.PropertySet.Add(PidLidClientIntent);
            this.contentItemView.PropertySet.Add(ClientInfoString);
            this.contentItemView.PropertySet.Add(LogTriggerAction);
 
            this.contentItemView.PropertySet.Add(PidLidGlobalObjectId);
            this.contentItemView.PropertySet.Add(PidLidCleanGlobalObjectId);
             
 
        //private PropertySet defaultDetailPropertySet = new PropertySet(BasePropertySet.FirstClassProperties,
        //    Prop_PR_STORE_ENTRYID,
        //    Prop_PR_IS_HIDDEN,
        //    Prop_PR_FOLDER_PATH,
        //    PidLidCleanGlobalObjectId,
        //    PidLidGlobalObjectId);

            // IsAssociated is not supported in Exchange 2007
            if (this.CurrentService != null &&
                this.CurrentService.RequestedServerVersion != ExchangeVersion.Exchange2007_SP1)
            {
                this.contentItemView.PropertySet.Add(ItemSchema.IsAssociated);
            }

            this.contentItemView.PropertySet.Add(ItemSchema.Sensitivity);
            this.contentItemView.PropertySet.Add(ItemSchema.DisplayCc);
            this.contentItemView.PropertySet.Add(ItemSchema.Categories);
            this.contentItemView.PropertySet.Add(ItemSchema.Culture);

            // Setup the this.ContentsGrid with columns for displaying item collections
            int col = 0;
            col = this.ContentsGrid.Columns.Add(ColNameSubject, "Subject");
            this.ContentsGrid.Columns[col].Width = 175;

            col = this.ContentsGrid.Columns.Add(ColNameDisplayTo, "DisplayTo");
            this.ContentsGrid.Columns[col].Width = 125;

            col = this.ContentsGrid.Columns.Add(ColNameItemClass, "ItemClass");
            this.ContentsGrid.Columns[col].Width = 175;

            col = this.ContentsGrid.Columns.Add(ColNameSize, "Size");
            this.ContentsGrid.Columns[col].Width = 50;

            col = this.ContentsGrid.Columns.Add(ColNameHasAttach, "HasAttachments");
            this.ContentsGrid.Columns[col].Width = 50;

            col = this.ContentsGrid.Columns.Add(ColNameDateReceived, "DateTimeReceived");
            this.ContentsGrid.Columns[col].ValueType = typeof(DateTime);
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameDateCreated, "DateTimeCreated");
            this.ContentsGrid.Columns[col].ValueType = typeof(DateTime);
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameDateSent, "DateTimeSent");
            this.ContentsGrid.Columns[col].ValueType = typeof(DateTime);
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameLastModifiedTime, "LastModifiedTime");
            this.ContentsGrid.Columns[col].ValueType = typeof(DateTime);
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameLastModifiedName, "LastModifiedName");
            this.ContentsGrid.Columns[col].Width = 125;

            col = this.ContentsGrid.Columns.Add(ColNameIsAssociated, "IsAssociated");
            this.ContentsGrid.Columns[col].Width = 75;

            col = this.ContentsGrid.Columns.Add(ColNameSensitivity, "Sensitivity");
            this.ContentsGrid.Columns[col].Width = 75;

            col = this.ContentsGrid.Columns.Add(ColNameDisplayCc, "DisplayCC");
            this.ContentsGrid.Columns[col].Width = 125;

            col = this.ContentsGrid.Columns.Add(ColNameCategories, "Categories");
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameCulture, "Culture");
            this.ContentsGrid.Columns[col].Width = 50;

            col = this.ContentsGrid.Columns.Add(ColClientInfoString, "ClientInfoString");
            this.ContentsGrid.Columns[col].Width = 200;
            this.ContentsGrid.Columns[col].Visible = true; 
            
            col = this.ContentsGrid.Columns.Add(ColPidLidClientIntent, "PidLidClientIntent");
            this.ContentsGrid.Columns[col].Visible = true;

            col = this.ContentsGrid.Columns.Add(ColLogTriggerAction, "LogTriggerAction");
            this.ContentsGrid.Columns[col].Visible = true;
 
            col = this.ContentsGrid.Columns.Add(ColPidLidGlobalObjectId, "PidLidGlobalObjectId");
            this.ContentsGrid.Columns[col].Width = 200;
            this.ContentsGrid.Columns[col].Visible = true;

            col = this.ContentsGrid.Columns.Add(ColPidLidCleanGlobalObjectId, "PidLidCleanGlobalObjectId");
            this.ContentsGrid.Columns[col].Width = 200;
            this.ContentsGrid.Columns[col].Visible = true;

 

            col = this.ContentsGrid.Columns.Add(ColNameItemId, "ItemId");
            this.ContentsGrid.Columns[col].Visible = false;
        }

 

        protected override void LoadContents()
        {
             
            // Make one call to get all the items.
            CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            IEnumerable<GetItemResponse> getItems;
            if (currentItemIds.Count > 0)
            {
                getItems = this.CurrentService.BindToItems(
                    this.currentItemIds.ToArray(),
                    this.contentItemView.PropertySet);
            }
            else
            {
                getItems = Enumerable.Empty<GetItemResponse>();
            }

            // Convert the GetItemResponseCollection to an Item list.
            List<Item> items = new List<Item>();
            foreach (GetItemResponse getItem in getItems)
            {
                if (getItem.Item != null)
                {
                    Item item = getItem.Item as Item;

                    if (item != null)
                    {
                        this.AddContentItem(item);
                    }
                    else
                    {
                        DebugLog.WriteVerbose("GetItemResponse.Item is not an Item.");
                    }
                }
                else
                {
                    DebugLog.WriteVerbose(String.Format("GetItemResponse.Item is null, GetItemResponse.ErrorCode is {0}.", getItem.ErrorCode.ToString()));
                }
            }
        }

        protected override void LoadSelectionDetails()
        {
            // Only load details if a content row is selected
            if (this.ContentsGrid.SelectedRows.Count == 0 ||
                this.GetSelectedContentId().Length == 0)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                Item details = EWSEditor.Forms.FormsUtil.PerformRetryableItemBind(
                    this.CurrentService,
                    new ItemId(this.GetSelectedContentId()),
                    this.CurrentDetailPropertySet);

                if (details != null)
                {
                    this.PropertyDetailsGrid.LoadObject(details);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Add the given item to the ContentsGrid
        /// </summary>
        /// <param name="item">Item to add</param>
        protected void AddContentItem(Item item)
        {
            // TODO: Add Try/Catch blocks
            int row = this.ContentsGrid.Rows.Add();
            this.ContentsGrid.Rows[row].Cells[ColNameSubject].Value = item.Subject;
            this.ContentsGrid.Rows[row].Cells[ColNameDisplayTo].Value = item.DisplayTo;
            this.ContentsGrid.Rows[row].Cells[ColNameItemClass].Value = item.ItemClass;
            this.ContentsGrid.Rows[row].Cells[ColNameSize].Value = item.Size;
            this.ContentsGrid.Rows[row].Cells[ColNameHasAttach].Value = item.HasAttachments;

            try
            {
                this.ContentsGrid.Rows[row].Cells[ColNameDateReceived].Value = item.DateTimeReceived.ToString();
            }
            catch (Exception ex)
            {
                DebugLog.WriteVerbose("Handled exception when getting DateTimeReceived", ex);
                this.ContentsGrid.Rows[row].Cells[ColNameDateReceived].Value = ex.Message;
            }

            this.ContentsGrid.Rows[row].Cells[ColNameDateCreated].Value = item.DateTimeCreated.ToString();

            try
            {
                this.ContentsGrid.Rows[row].Cells[ColNameDateSent].Value = item.DateTimeSent.ToString();
            }
            catch (Exception ex)
            {
                DebugLog.WriteVerbose("Handled exception when getting DateTimeSent", ex);
                this.ContentsGrid.Rows[row].Cells[ColNameDateSent].Value = ex.Message;
            }

            this.ContentsGrid.Rows[row].Cells[ColNameLastModifiedTime].Value = item.LastModifiedTime.ToString();
            this.ContentsGrid.Rows[row].Cells[ColNameLastModifiedName].Value = item.LastModifiedName;

            try
            {
                this.ContentsGrid.Rows[row].Cells[ColNameIsAssociated].Value = item.IsAssociated;
            }
            catch (Exception ex)
            {
                DebugLog.WriteVerbose("Handled exception when getting IsAssociated", ex);
                this.ContentsGrid.Rows[row].Cells[ColNameIsAssociated].Value = ex.Message;
            }

            this.ContentsGrid.Rows[row].Cells[ColNameSensitivity].Value = item.Sensitivity;
            this.ContentsGrid.Rows[row].Cells[ColNameDisplayCc].Value = item.DisplayCc;
            this.ContentsGrid.Rows[row].Cells[ColNameCategories].Value = item.Categories;

            try
            {
                this.ContentsGrid.Rows[row].Cells[ColNameCulture].Value = item.Culture;
            }
            catch (Exception ex)
            {
                DebugLog.WriteVerbose("Handled exception when getting Culture", ex);
                this.ContentsGrid.Rows[row].Cells[ColNameCulture].Value = ex.Message;
            }

            string sVal = string.Empty;
            try
            {
                if (item.TryGetProperty(ClientInfoString, out sVal))  //  
                    this.ContentsGrid.Rows[row].Cells[ColClientInfoString].Value = sVal;
                else
                    this.ContentsGrid.Rows[row].Cells[ColClientInfoString].Value = "";
            }
            catch (Exception ex)
            {
                this.ContentsGrid.Rows[row].Cells[ColPidLidClientIntent].Value = ex.Message;
            }

 

             

            Int32 iVal;
            try
            {
                if (item.TryGetProperty(PidLidClientIntent, out iVal))  //  
                {
                    // https://msdn.microsoft.com/en-us/library/ff368035(v=exchg.80).aspx
                    string sDesc = GetPidLidClientIntentDescription(iVal);
                    //string s = iVal.ToString() + ":  " + GetPidLidClientIntentDescription(iVal);
                    if (sDesc.Length != 0)
                        this.ContentsGrid.Rows[row].Cells[ColPidLidClientIntent].Value = iVal.ToString() + ":  " + sDesc;
                    else
                        this.ContentsGrid.Rows[row].Cells[ColPidLidClientIntent].Value = iVal.ToString();
                }
                else
                    this.ContentsGrid.Rows[row].Cells[ColPidLidClientIntent].Value = "";
            }
            catch (Exception ex)
            {
                this.ContentsGrid.Rows[row].Cells[ColPidLidClientIntent].Value = ex.Message;
            }

            try
            {
                if (item.TryGetProperty(LogTriggerAction, out sVal))  //  
                    this.ContentsGrid.Rows[row].Cells[ColLogTriggerAction].Value = sVal;
                else
                    this.ContentsGrid.Rows[row].Cells[ColLogTriggerAction].Value = "";
            }
            catch (Exception ex)
            {
                this.ContentsGrid.Rows[row].Cells[ColPidLidClientIntent].Value = ex.Message;
            }


            byte[] bytearrVal;
            try
            {
                 if (item.TryGetProperty(PidLidGlobalObjectId, out bytearrVal))  // CleanGlobalObjectId
                     this.ContentsGrid.Rows[row].Cells[ColPidLidGlobalObjectId].Value = Convert.ToBase64String(bytearrVal);
                else
                     this.ContentsGrid.Rows[row].Cells[ColPidLidGlobalObjectId].Value = "";
            }
            catch (Exception ex)
            {
                this.ContentsGrid.Rows[row].Cells[ColPidLidGlobalObjectId].Value = ex.Message;
            }

            try
            {
                 if (item.TryGetProperty(PidLidCleanGlobalObjectId, out bytearrVal))  // CleanGlobalObjectId
                     this.ContentsGrid.Rows[row].Cells[ColPidLidCleanGlobalObjectId].Value = Convert.ToBase64String(bytearrVal);
                else
                     this.ContentsGrid.Rows[row].Cells[ColPidLidCleanGlobalObjectId].Value = "";
            }
            catch (Exception ex)
            {
                this.ContentsGrid.Rows[row].Cells[ColPidLidCleanGlobalObjectId].Value = ex.Message;
            }

 

            this.ContentsGrid.Rows[row].Cells[ColNameItemId].Value = item.Id.UniqueId;
            this.ContentsGrid.Rows[row].ContextMenuStrip = this.mnuItemContext;
        }

        private string GetPidLidClientIntentDescription(int iVal)
        {
            string s = "";
            if (IsBitSet(iVal, 0))
                s += "ciManager: The user is the owner of the Meeting object's Calendar folder. If this bit is set, the ciDelegate bit SHOULD NOT be set. ";
            if (IsBitSet(iVal, 1))
                s += " ciDelegate: The user is a delegate acting on a Meeting object in a delegator's Calendar folder.  If this bit is set, the ciManager bit SHOULD NOT be set. ";
            if (IsBitSet(iVal, 2))
                s += "ciDeletedWithNoResponse: The user deleted the Meeting object with no response sent to the organizer. ";
            if (IsBitSet(iVal, 3))
                s += "ciDeletedExceptionWithNoResponse: The user deleted an exception to a recurring series with no response sent to the organizer. ";
            if (IsBitSet(iVal, 4))
                s += "ciRespondedTentative: The user tentatively accepted the meeting request. ";
            if (IsBitSet(iVal, 5))  // F
                s += "ciRespondedAccept: The user accepted the meeting request. ";
            if (IsBitSet(iVal, 6)) // G
                s += "ciRespondedDecline: The user declined the meeting request. ";
            if (IsBitSet(iVal, 7)) // H
                s += "ciModifiedStartTime: The user modified the start time. ";
            if (IsBitSet(iVal, 8)) // I
                s += "ciModifiedEndTime: The user modified the end time.  ";
            if (IsBitSet(iVal, 9)) // J
                s += "ciModifiedLocation: The user changed the location of the meeting.  ";
            if (IsBitSet(iVal, 10)) // K
                s += "ciRespondedExceptionDecline: The user declined an exception to a recurring series.  ";
            if (IsBitSet(iVal, 11)) // L
                s += " ciCanceled: The user canceled a meeting request.  ";
            if (IsBitSet(iVal, 12)) // M
                s += "ciExceptionCanceled: The user canceled an exception to a recurring series.  ";
            return s;
        }

        // http://stackoverflow.com/questions/2431732/checking-if-a-bit-is-set-or-not
        private bool IsBitSet(byte b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }
        private bool IsBitSet(int b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }

        #region Item Right-Click Menu

        /// <summary>
        /// Display a file open dialog to get a file path to the
        /// file to attach to this meesage.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuAddFileAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select the file to attach...";
            ofd.Multiselect = false;
            DialogResult res = ofd.ShowDialog();

            if (res == DialogResult.OK && System.IO.File.Exists(ofd.FileName))
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    ItemId id = GetSelectedContentId();
                    if (id == null)
                    {
                        return;
                    }
                    CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
                    Item item = Item.Bind(this.CurrentService, id, this.CurrentDetailPropertySet);
                    item.Attachments.AddFileAttachment(ofd.FileName);
                    item.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                    item.Update(ConflictResolutionMode.AutoResolve);

                    // Refresh the view
                    this.RefreshContentAndDetails();
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void MnuAddItemAttach_Click(object sender, EventArgs e)
        {
            ItemId itemId = null;
            DialogResult res = ItemIdDialog.ShowDialog(out itemId, this.CurrentService);

            if (res == DialogResult.OK && itemId != null)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    ItemId id = GetSelectedContentId();
                    if (id == null)
                    {
                        return;
                    }
                    CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
                    Item item = Item.Bind(this.CurrentService, id, this.CurrentDetailPropertySet);
                    ItemAttachment<Item> itemAttach = item.Attachments.AddItemAttachment<Item>();

                    item.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                    item.Update(ConflictResolutionMode.AutoResolve);
          

                    // Refresh the view
                    this.RefreshContentAndDetails();
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// Display the ContentsForm with the item's attachments
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuAttachments_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }
                CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
                Item item = Item.Bind(this.CurrentService, id, this.CurrentDetailPropertySet);
                if (item.Attachments.Count == 0)
                {
                    ErrorDialog.ShowInfo(DisplayStrings.MSG_NO_ATTACHMENTS);
                    return;
                }

                AttachmentsContentForm.Show(item, this.CurrentService, this);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Move the currently seleced item to a destination folder.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuMoveItem_Click(object sender, EventArgs e)
        {
            FolderId destId = null;

            FolderIdDialog oForm = new FolderIdDialog(this.CurrentService);
            oForm.ShowDialog();
            if (oForm.ChoseOK != true)
            {
                //oForm.ChosenFolderId 
                destId = oForm.ChosenFolderId;
                return;
            }

            //FolderId destId = null;
            //if (FolderIdDialog.ShowDialog(ref destId) != DialogResult.OK)
            //{
            //    return;
            //}

            StringBuilder oSB = new StringBuilder();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }

                List<ItemId> itemId = new List<ItemId>();
                itemId.Add(id);

                ServiceResponseCollection<MoveCopyItemResponse> oResponses = this.CurrentService.MoveItems(itemId, destId, true);

 

                if (oResponses.OverallResult != ServiceResult.Success)
                {

                    oSB.AppendFormat("Errors found in some of {0} response(s) .\r\n", oResponses.Count);

                    foreach (MoveCopyItemResponse oResponse in oResponses)
                    {

                        oSB.AppendFormat("    Error code: {0}\r\n", oResponse.ErrorCode.ToString());
                        oSB.AppendFormat("    Item - Id: {0}\r\n", oResponse.Result.ToString());
                        oSB.AppendFormat("    ErrorMessage: {0}\r\n", oResponse.ErrorMessage.ToString());
                        if (oResponse.ErrorDetails != null)
                        {
                            oSB.AppendFormat("    ErrorDetails: \r\n");
                            foreach (KeyValuePair<string, string> kvp in oResponse.ErrorDetails)
                            {
                                oSB.AppendFormat("         Item: {0}\r\n", kvp.Key);
                                oSB.AppendFormat("        Value: {0}\r\n", kvp.Value);

                                oSB.AppendLine();
                            }
                        }


                        if (oResponse.Item != null)
                        {   // copy/moved item - null if between mailboxes or from mailbox to public folder.
                            oSB.AppendFormat("    Item - Id: {0}\r\n", oResponse.Item.Id.UniqueId);

                        }
                        if (oResponse.ErrorProperties != null)
                        {
                            oSB.AppendFormat("    ErrorProperties:  \r\n");
                            foreach (PropertyDefinitionBase oProps in oResponse.ErrorProperties)
                            {
                                oSB.AppendFormat("        Property: {0}\r\n", oProps.ToString());

                            }
                        }
                        oSB.AppendLine();
                    }
                    ShowTextDocument oForm3 = new ShowTextDocument();
                    oForm3.txtEntry.WordWrap = false;
                    oForm3.Text = "Move Results";
                    oForm3.txtEntry.Text = oSB.ToString();
                    oForm3.ShowDialog();
                }
                else
                {
                    oSB.AppendFormat("Operation completed.\r\n\r\n");
                    oSB.AppendFormat("Ending item IDs: \r\n");
                    foreach (MoveCopyItemResponse oResponse in oResponses)
                    {

                        if (oResponse.Item != null)
                        {   // copy/moved item - null if between mailboxes or from mailbox to public folder.
                            oSB.AppendFormat("    Item - Id: {0}\r\n", oResponse.Item.Id.UniqueId);
                            //oSB.AppendFormat("           ParentFolderId: {0}\r\n", oResponse.Item.ParentFolderId);
                        }
                    }

                    oSB.AppendLine();
                    oSB.AppendFormat("Note: Ids will not be returned when copying between mailboxes or to a public folder.\r\n");

                    ShowTextDocument oForm4 = new ShowTextDocument();
                    oForm4.txtEntry.WordWrap = false;
                    oForm4.Text = "Move Result";
                    oForm4.txtEntry.Text = oSB.ToString();
                    oForm4.ShowDialog();
                }

                // Refresh the view
                this.RefreshContentAndDetails();
            }
            catch (ServiceResponseException ex)
            {

                oSB.AppendFormat("Error code: {0}\r\n", ex.ErrorCode);
                oSB.AppendFormat("Error message: {0}\r\n", ex.Message);
                oSB.AppendFormat("Response: {0}\r\n", ex.Response);

                ShowTextDocument oForm7 = new ShowTextDocument();
                oForm7.txtEntry.WordWrap = false;
                oForm7.Text = "Move Error";
                oForm7.txtEntry.Text = oSB.ToString();
                oForm7.ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void MnuHardDelete_Click(object sender, EventArgs e)
        {
            this.CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
            this.DeleteItem(DeleteMode.HardDelete);
        }

        private void MnuSoftDelete_Click(object sender, EventArgs e)
        {

            this.CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
            this.DeleteItem(DeleteMode.SoftDelete);
        }

        private void MnuMoveToDeleted_Click(object sender, EventArgs e)
        {
            this.CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
            this.DeleteItem(DeleteMode.MoveToDeletedItems);
        }

        /// <summary>
        /// There are three different delete modes, this function is called by
        /// each of the menu events passing a different mode.
        /// </summary>
        /// <param name="mode">Type of delete to peform</param>
        private void DeleteItem(DeleteMode mode)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }

                List<ItemId> item = new List<ItemId>();
                ///item.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                item.Add(id);

                this.CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                this.CurrentService.DeleteItems(
                    item,
                    mode,
                    SendCancellationsMode.SendToAllAndSaveCopy,
                    AffectedTaskOccurrence.AllOccurrences);

                // Refresh the view
                this.RefreshContentAndDetails();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void PropertyDetailsGrid_PropertyChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // Refresh the view
                this.RefreshContentAndDetails();
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void MnuExportXml_Click(object sender, EventArgs e)
        {
            // Get the folder to save the output files to, if the user
            // cancels this dialog bail out
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.Description = "Pick an output folder to save the XML file to.";
            if (browser.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }

                DumpHelper.DumpXML(
                    new List<ItemId> { id },
                    this.CurrentDetailPropertySet,
                    browser.SelectedPath,
                    this.CurrentService);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void MnuExportMIMEContent_Click(object sender, EventArgs e)
        {
            // Get the folder to save the output files to, if the user
            // cancels this dialog bail out
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.Description = "Pick an output folder to save the MIME file to.";
            if (browser.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }

                DumpHelper.DumpMIME(
                    new List<ItemId> { id },
                    browser.SelectedPath,
                    this.CurrentService);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void MnuExportToStream_Click(object sender, EventArgs e)
        {
            // Get the currently selected item
            ItemId id = GetSelectedContentId();
            if (id == null) { return; }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save exported stream to a file...";
            dialog.OverwritePrompt = true;
            dialog.CheckPathExists = true;
            dialog.Filter = "Binary file (*.bin)|*.bin";

            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            try
            {
                string sVersion = this.CurrentService.RequestedServerVersion.ToString();
           
                ExportUploadHelper.ExportItemPost(sVersion, id.UniqueId, dialog.FileName);
               
        
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void MnuMeetingAccept_Click(object sender, EventArgs e) 
        { 
            this.MeetingResponse_Click(MeetingResponseType.Accept); 
        }
        
        private void MnuMeetingDecline_Click(object sender, EventArgs e) 
        {
            this.MeetingResponse_Click(MeetingResponseType.Decline); 
        }

        private void MnuMeetingTenative_Click(object sender, EventArgs e) 
        {
            this.MeetingResponse_Click(MeetingResponseType.Tentative); 
        }

        /// <summary>
        /// Handler for multiple meeting response types.  Rather than recreate our
        /// own enumeration, we "borrow" one in the Managed API to indicate which
        /// response method to call
        /// </summary>
        /// <param name="respType">
        /// Borrowed this enumeration - only Accept, Decline, and Tentative
        /// are acceptable.
        /// </param>
        private void MeetingResponse_Click(MeetingResponseType respType)
        {
            try
            {
                ItemId id = GetSelectedContentId();
                if (id == null) 
                {
                    return;
                }
                CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
                Item item = Item.Bind(this.CurrentService, id, new PropertySet(BasePropertySet.FirstClassProperties));

                MeetingRequest meeting;
                Appointment appt;

                if (null != (meeting = item as MeetingRequest))
                {
                    switch (respType)
                    {
                        case MeetingResponseType.Accept:
                            meeting.Accept(true);
                            break;
                        case MeetingResponseType.Decline:
                            meeting.Decline(true);
                            break;
                        case MeetingResponseType.Tentative:
                            meeting.AcceptTentatively(true);
                            break;
                        default:
                            // It's bad to end up here
                            throw new ApplicationException("Unexpected response type requested.");
                    }
                }
                else if (null != (appt = item as Appointment))
                {
                    switch (respType)
                    {
                        case MeetingResponseType.Accept:
                            appt.Accept(true);
                            break;
                        case MeetingResponseType.Decline:
                            appt.Decline(true);
                            break;
                        case MeetingResponseType.Tentative:
                            appt.AcceptTentatively(true);
                            break;
                        default:
                            // It's bad to end up here
                            throw new ApplicationException("Unexpected response type requested.");
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        private void mnuViewMIMEContent_Click(object sender, EventArgs e)
        {
            string MimeOfItem = string.Empty;
            try
            {
                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }
 
                DumpHelper.GetItemMime(
                    id,
                    this.CurrentService,
                    ref MimeOfItem);

                ShowTextDocument oForm = new ShowTextDocument();
                oForm.txtEntry.WordWrap = false;
                oForm.Text = "MIME";
                oForm.txtEntry.Text = MimeOfItem;
                oForm.ShowDialog();

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
 
 
        
        }

        private void mnuItemContext_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HandleItemMenuOpening();
        }

        private void ContentsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ContentsGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {

        }

        private void EditCurrentItemByType()
        {
            ItemId id = GetSelectedContentId();
            CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            Item oItem = Item.Bind(CurrentService, id);
            string sClass = string.Empty;
            sClass = GetBaseClass(oItem.ItemClass);

            EditItemByClass(oItem, sClass);

        }

        private void EditItemByClass(Item oItem, string sClass)
        {
 
            if (sClass.Length != 0)
            {

                switch (sClass)
                {
                    case "IPM.Note":
                        MessageForm oMessageForm = new MessageForm(CurrentService, oItem.Id);
                        oMessageForm.ShowDialog();
                        oMessageForm = null;
                        break;

                    case "IPM.Contact":
                        CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
                        Contact oContact = Contact.Bind(CurrentService, oItem.Id);
                        ContactsForm oContactsForm = new ContactsForm(CurrentService, ref oContact);
                        oContactsForm.ShowDialog();
                        oContactsForm = null;
                        break;

                    case "IPM.Appointment":
                        CalendarForm oCalendarForm = new CalendarForm(CurrentService, oItem.Id);
                        oCalendarForm.ShowDialog();
                        oCalendarForm = null;
                        break;

                    case "IPM.Task":
                        TaskForm oTasksForm = new TaskForm(CurrentService, oItem.Id);
                        oTasksForm.ShowDialog();
                        oTasksForm = null;
                        break;

                    //case "IPM.Activity":
                    //    TasksForm oJournalForm = new JournalForm(_EwsCaller, oItemTag.Id);
                    //    oJournalForm.ShowDialog();
                    //    oJournalForm = null;
                    //case "IPM.StickyNote":
                    //    TasksForm oStickyNoteForm = new StickyNoteForm(_EwsCaller, oItemTag.Id);
                    //    oStickyNoteForm.ShowDialog();
                    //    oStickyNoteForm = null;
                    //    break;
                    default:
                        //EditMailItem();
                        break;
                }
            }
        }

        public string GetBaseClass(string ClassName)
        {
            string sClass = string.Empty;
            char[] splitchar = { '.' };
            string[] NameParts;
             
 
            NameParts = ClassName.Split(splitchar);
            if (NameParts.Count() > 1)    
                sClass = NameParts[0] + "." + NameParts[1];
            else
                sClass = ClassName;

            return sClass;
        }

        private void mnuCopyItem_Click(object sender, EventArgs e)
        {
            FolderId destId = null;

            FolderIdDialog oForm = new FolderIdDialog(this.CurrentService);
            oForm.ShowDialog();
            if (oForm.ChoseOK != true)
            {
                //oForm.ChosenFolderId 
                destId = oForm.ChosenFolderId;
                return;
            }
            destId = oForm.ChosenFolderId;

            //FolderId destId = null;
            //if (FolderIdDialog.ShowDialog(ref destId) != DialogResult.OK)
            //{
            //    return;
            //}

            StringBuilder oSB = new StringBuilder();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }

                List<ItemId> itemId = new List<ItemId>();
                itemId.Add(id);


                // https://msdn.microsoft.com/en-us/library/office/Dn771039(v=EXCHG.150).aspx#bk_ewsmaerrors

                 

                ServiceResponseCollection <MoveCopyItemResponse > oResponses = this.CurrentService.CopyItems(itemId, destId, true);

                if (oResponses.OverallResult != ServiceResult.Success)
                {
                    
                    oSB.AppendFormat("Errors found in some of {0} response(s) .\r\n", oResponses.Count);

                    foreach (MoveCopyItemResponse oResponse in oResponses)
                    {

                        oSB.AppendFormat("    Error code: {0}\r\n", oResponse.ErrorCode.ToString());
                        oSB.AppendFormat("    Item - Id: {0}\r\n", oResponse.Result.ToString());
                        oSB.AppendFormat("    ErrorMessage: {0}\r\n", oResponse.ErrorMessage.ToString());
                        if (oResponse.ErrorDetails != null)
                        { 
                            oSB.AppendFormat("    ErrorDetails: \r\n") ;
                            foreach (KeyValuePair<string, string> kvp in oResponse.ErrorDetails)
                            {
                                oSB.AppendFormat("         Item: {0}\r\n", kvp.Key);
                                oSB.AppendFormat("        Value: {0}\r\n", kvp.Value);

                                oSB.AppendLine();
                            }
                        }
                       

                        if (oResponse.Item != null)
                        {   // copy/moved item - null if between mailboxes or from mailbox to public folder.
                            oSB.AppendFormat("    Item - Id: {0}\r\n", oResponse.Item.Id.UniqueId);
                             
                        }
                        if (oResponse.ErrorProperties != null)
                        {
                            oSB.AppendFormat("    ErrorProperties:  \r\n" );
                            foreach (PropertyDefinitionBase oProps in oResponse.ErrorProperties)
                            {
                                oSB.AppendFormat("        Property: {0}\r\n", oProps.ToString());

                            }
                        }
                        oSB.AppendLine();
                    }
                    ShowTextDocument oForm6 = new ShowTextDocument();
                    oForm6.txtEntry.WordWrap = false;
                    oForm6.Text = "Copy Results";
                    oForm6.txtEntry.Text = oSB.ToString();
                    oForm6.ShowDialog();
                }
                else
                {
                    oSB.AppendFormat("Operation completed.\r\n\r\n");
                    oSB.AppendFormat("Ending item IDs: \r\n");
                    foreach (MoveCopyItemResponse oResponse in oResponses)
                    {

                        if (oResponse.Item != null)
                        {   // copy/moved item - null if between mailboxes or from mailbox to public folder.
                            oSB.AppendFormat("    Item - Id: {0}\r\n", oResponse.Item.Id.UniqueId);
                            //oSB.AppendFormat("           ParentFolderId: {0}\r\n", oResponse.Item.ParentFolderId);
                        }
                    }




                    oSB.AppendLine();
                    oSB.AppendFormat("Note: Ids will not be returned when copying between mailboxes or to a public folder.\r\n");

                    ShowTextDocument oForm2 = new ShowTextDocument();
                    oForm2.txtEntry.WordWrap = false;
                    oForm2.Text = "Copy Result";
                    oForm2.txtEntry.Text = oSB.ToString();
                    oForm2.ShowDialog();
                }

                // Refresh the view
                this.RefreshContentAndDetails();
            }
            catch (ServiceResponseException ex)
            {
                
                oSB.AppendFormat("Error code: {0}\r\n", ex.ErrorCode);
                oSB.AppendFormat("Error message: {0}\r\n", ex.Message);
                oSB.AppendFormat("Response: {0}\r\n", ex.Response);

                ShowTextDocument oFormShowDocument = new ShowTextDocument();
                oFormShowDocument.txtEntry.WordWrap = false;
                oFormShowDocument.Text = "Copy Error";
                oFormShowDocument.txtEntry.Text = oSB.ToString();
                oFormShowDocument.ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

 
        }

        private void mnuItemContext_Click(object sender, EventArgs e)
        {

        }

        private void mnuClientEditItem_Click(object sender, EventArgs e)
        {
            EditCurrentItemByType();
        }

        private void HandleItemMenuOpening()
        {
            ItemId id = GetSelectedContentId();
            CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            Item oItem = Item.Bind(CurrentService, id);
            string sClass = string.Empty;
            sClass = GetBaseClass(oItem.ItemClass);

            if (sClass.Length != 0)
            {

                switch (sClass)
                {
                    case "IPM.Note":
                        mnuClientEditItem.Visible = true;
                        break;
                    case "IPM.Contact":
                        mnuClientEditItem.Visible = true;
                        break;
                    case "IPM.Appointment":
                        mnuClientEditItem.Visible = true;
                        break;
                    case "IPM.Task":
                        mnuClientEditItem.Visible = true;
                        break;
                    case "IPM.StickyNote":
                        mnuClientEditItem.Visible = false;
                        break;
                    default:
                        mnuClientEditItem.Visible = false;
                        break;
                }
            }
        }

        private void ContentsGrid_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mnuPlayOnPhone_Click(object sender, EventArgs e)
        {
 
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }
                string sDialString = string.Empty;
                PlayItemOnPhoneForm oForm = new PlayItemOnPhoneForm(this.CurrentService, id, sDialString);
                oForm.ShowDialog();

   

                // Refresh the view
                this.RefreshContentAndDetails();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ContentsGrid_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PropertyDetailsGrid_Load(object sender, EventArgs e)
        {

        }

        private void mnuViewItemInOWA_Click(object sender, EventArgs e)
        {

            ItemId id = GetSelectedContentId();
            if (id == null)
            {
                return;
            }

            OpenOWAFromWebClientReadFormQueryString(this.CurrentService, id);
        }



        // taken from https://msdn.microsoft.com/en-us/library/microsoft.exchange.webservices.data.item.webclientreadformquerystring(v=exchg.80).aspx
        private void OpenOWAFromWebClientReadFormQueryString(ExchangeService service, ItemId oItemId)
        {

            ExchangeServerInfo serverInfo = service.ServerInfo;
            string sWebClientReadFormQueryString = string.Empty;

            string owaReadFormQueryString = string.Empty;
            var ewsIdentifer = oItemId.UniqueId;
 
            string sClass = string.Empty;
            CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            Item oSomeItem = Item.Bind(service, oItemId);
            sClass =  GetBaseClass(oSomeItem.ItemClass);  // need to get class id.
            oSomeItem = null;

            CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            Item oWorkItem = Item.Bind(service, oItemId);
            oWorkItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            oWorkItem.Load(new PropertySet(BasePropertySet.IdOnly, ItemSchema.WebClientReadFormQueryString));
            sWebClientReadFormQueryString = oWorkItem.WebClientReadFormQueryString;
            oWorkItem = null;
           
             
            
            try
            {
 
                 // Versions of Exchange starting with major version 15 and ending with Exchange Server 2013 build 15.0.775.09
                // returned a different query string fragment. This optional check is not required for applications that
                // target Exchange Online.
                if ((serverInfo.MajorVersion == 15) && (serverInfo.MajorBuildNumber < 775) && (serverInfo.MinorBuildNumber < 09))
                {
                    // If your client is connected to an Exchange 2013 server that has not been updated to CU3,
                    // this query string will be returned.
                    owaReadFormQueryString = string.Format("#viewmodel=_y.$Ep&ItemID={0}",
                      System.Web.HttpUtility.UrlEncode(ewsIdentifer, Encoding.UTF8));
                }
                else
                {
                    // If your client is connected to an Exchanger 2010, Exchange 2013 CU3, or Exchange Online server,
                    // the WebClientReadFormQueryString is used.
                    owaReadFormQueryString = sWebClientReadFormQueryString;
                }

                // Create the URL that Outlook Web App uses to open the email message.
                Uri url = service.Url;
                string owaReadAccessUrl = string.Empty;

                if (owaReadFormQueryString.StartsWith("https:") || owaReadFormQueryString.StartsWith("http:"))
                    owaReadAccessUrl = owaReadFormQueryString;
                else
                    owaReadAccessUrl = string.Format("{0}://{1}/owa/{2}", url.Scheme, url.Host, owaReadFormQueryString);
                

                if (!string.IsNullOrEmpty(owaReadAccessUrl))
                {
                    System.Diagnostics.Process.Start("IEXPLORE.EXE", owaReadAccessUrl);
                }
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRROR: Internet Explorer cannot be found.");
 
            }
        }


        private void OpenOWAFromWebClientEditFormQueryString(ExchangeService service, ItemId oItemId)
        {


            //  The WebClientEditFormQueryString element is not applicable to versions of Exchange starting with Exchange Server 2013, including Exchange Online.
            //  See:  https://msdn.microsoft.com/en-us/library/office/dd899477(v=exchg.150).aspx
            //      For versions of Exchange starting with Exchange Server 2013, including Exchange Online, 
            //      use the information from the WebClientReadFormQueryString element to open a draft item in 
            //      Outlook Web App and then use the UI to edit the draft item. The WebClientEditFormQueryString 
            //      element is not applicable to versions of Exchange starting with Exchange Server 2013, including Exchange Online.

            ExchangeServerInfo serverInfo = service.ServerInfo;
            if (serverInfo.MajorVersion == 15)
            {   // https://msdn.microsoft.com/en-us/library/office/dd899477(v=exchg.150).aspx
                MessageBox.Show("The WebClientEditFormQueryString element is not applicable to versions of Exchange starting with Exchange Server 2013, including Exchange Online.", "Not valid for Exchange version.");
                return;
            }

             
            string owaEditFormQueryString = string.Empty;
            var ewsIdentifer = oItemId.UniqueId;

            try
            {
                string sWebClientEditFormQueryString = string.Empty;
                service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
                Item oItem = Item.Bind(service, oItemId);
                oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
                oItem.Load(new PropertySet(BasePropertySet.IdOnly, ItemSchema.WebClientEditFormQueryString));
                owaEditFormQueryString = oItem.WebClientEditFormQueryString;


                string sClass = string.Empty;
                CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
                Item oSomeItem = Item.Bind(service, oItemId);
                sClass = GetBaseClass(oSomeItem.ItemClass);  // need to get class id.
                oSomeItem = null;

                CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
                service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
                Item oWorkItem = Item.Bind(service, oItemId);
                oWorkItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                oWorkItem.Load(new PropertySet(BasePropertySet.IdOnly, ItemSchema.WebClientEditFormQueryString));
                sWebClientEditFormQueryString = oWorkItem.WebClientEditFormQueryString;
                oWorkItem = null;
              

                 


 

                Uri url = service.Url;
                string owaEditAccessUrl = string.Empty;

                if (owaEditFormQueryString.StartsWith("https:") || owaEditFormQueryString.StartsWith("http:"))
                    owaEditAccessUrl = owaEditFormQueryString;
                else
                    owaEditAccessUrl = string.Format("{0}://{1}/owa/{2}", url.Scheme, url.Host, owaEditFormQueryString);


                if (!string.IsNullOrEmpty(owaEditAccessUrl))
                {
                    System.Diagnostics.Process.Start("IEXPLORE.EXE", owaEditAccessUrl);
                }
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRROR: Internet Explorer cannot be found.");
 
            }
        }

        private void mnuEditItemInOWA_Click(object sender, EventArgs e)
        {
            ItemId id = GetSelectedContentId();
            if (id == null)
            {
                return;
            }

            OpenOWAFromWebClientEditFormQueryString(this.CurrentService, id); 
        }

        private void mnuExportItem_Click(object sender, EventArgs e)
        {

        }

        private void developerItemTestWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }

                DeveloperItemTestForm oForm = new DeveloperItemTestForm(this.CurrentService, id);
                oForm.Show();

                this.RefreshContentAndDetails();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dispalyAttachmentsByTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }

                AttachmentsByTypeForm oForm = new AttachmentsByTypeForm(this.CurrentService, id);
                oForm.ShowDialog();
                oForm = null;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void mnuAddItemAttach_Click_1(object sender, EventArgs e)
        {

        }

        private void mnuMarkAsJunk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }

                MarkAsJunkForm oForm = new MarkAsJunkForm(this.CurrentService, id);
                oForm.ShowDialog();

                // Refresh the view
                this.RefreshContentAndDetails();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void mnuParseAndViewMIMEContent_Click(object sender, EventArgs e)
        {
            string MimeOfItem = string.Empty;
            try
            {
                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }

                DumpHelper.GetItemMime(
                    id,
                    this.CurrentService,
                    ref MimeOfItem);

                MimeParserForm oForm = new MimeParserForm( MimeOfItem);
 
                oForm.ShowDialog();

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


    }
}
