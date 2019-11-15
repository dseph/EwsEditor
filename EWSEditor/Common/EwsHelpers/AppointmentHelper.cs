using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Common
{
    public class AppointmentHelper
    {
        private static ExtendedPropertyDefinition PidLidAppointmentRecur = new ExtendedPropertyDefinition(new Guid("00062002-0000-0000-C000-000000000046"), 0x8216, MapiPropertyType.Binary); // dispidApptRecur
        private static ExtendedPropertyDefinition PidLidClientIntent = new ExtendedPropertyDefinition(new Guid("11000E07-B51B-40D6-AF21-CAA85EDAB1D0"), 0x0015, MapiPropertyType.Integer); // dispidClientIntent
 
        public static Appointment GetAppointmentDetails(string sId, ExchangeService oExchangeService)
        {
            ItemId oItem = new ItemId(sId);

            PropertySet appointmentPropertySet = GetAppointmentCalendarPropertySet();
            oExchangeService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
            Appointment oAppointment = Appointment.Bind(oExchangeService, oItem, appointmentPropertySet);

            return (oAppointment);
        }

        public static Appointment GetAppointmentDetails(Appointment oAppointment)
        {
            PropertySet appointmentPropertySet = GetAppointmentCalendarPropertySet();
            oAppointment.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
            oAppointment.Load(appointmentPropertySet);

            return (oAppointment);
        }

        private static PropertySet GetAppointmentCalendarPropertySet()
        {
            PropertySet appointmentPropertySet = new PropertySet
            (
                BasePropertySet.FirstClassProperties// ,
                //new PropertyDefinitionBase[] 
                //{ 
                //    AppointmentSchema.Organizer,
                //    AppointmentSchema.ParentFolderId,
                //    AppointmentSchema.Organizer,
                //    AppointmentSchema.StoreEntryId,
                //    AppointmentSchema.RequiredAttendees,
                //    AppointmentSchema.OptionalAttendees,
                //    AppointmentSchema.Subject,
                //    AppointmentSchema.DisplayTo,
                //    AppointmentSchema.DisplayCc,
                //    AppointmentSchema.Subject,
                //    AppointmentSchema.ICalUid,
                //    AppointmentSchema.DateTimeCreated,
                //    AppointmentSchema.LastModifiedName,
                //    AppointmentSchema.LastModifiedTime,
                //    AppointmentSchema.HasAttachments,
                //    AppointmentSchema.ItemClass,
                //    AppointmentSchema.Start,
                //    AppointmentSchema.End,            
                //    AppointmentSchema.IsAllDayEvent,
                //    AppointmentSchema.IsRecurring,
                //    AppointmentSchema.IsReminderSet,
                //    AppointmentSchema.IsOnlineMeeting,
                //    AppointmentSchema.RetentionDate,
                //    AppointmentSchema.Organizer,
                //    AppointmentSchema.ICalRecurrenceId,
                //    AppointmentSchema.IsResend,
                //    AppointmentSchema.IsDraft,
                //    AppointmentSchema.Size
                //}
            );

            appointmentPropertySet.Add(PidLidAppointmentRecur);
            appointmentPropertySet.Add(PidLidClientIntent);

            return appointmentPropertySet;
        }

        public static string GetAttendeeStatusAsInfoString(Appointment oAppointment)
        {

            // http://msdn.microsoft.com/en-us/library/dd633669(EXCHG.80).aspx
            string s = string.Empty;


            // Check responses from required attendees.
            s += "Required attendee:\r\n";
            for (int i = 0; i < oAppointment.RequiredAttendees.Count; i++)
            {
                if (oAppointment.RequiredAttendees[i].ResponseType != null)
                    s += "    " + oAppointment.RequiredAttendees[i].Address + ": " + oAppointment.RequiredAttendees[i].ResponseType.Value.ToString() + "\r\n";
                else
                    s += "    " + oAppointment.RequiredAttendees[i].Address + ": \r\n";

            }

            // Check responses from optional attendees.
            s += "Optional attendee:\r\n";
            for (int i = 0; i < oAppointment.OptionalAttendees.Count; i++)
            {
                if (oAppointment.OptionalAttendees[i].ResponseType != null)
                    s += "    " + oAppointment.OptionalAttendees[i].Address + ": " + oAppointment.OptionalAttendees[i].ResponseType.Value.ToString() + "\r\n";
                else
                    s += "    " + oAppointment.OptionalAttendees[i].Address + ": \r\n";
            }

            // Check responses from resources.
            s += "Resource attendee:\r\n";
            for (int i = 0; i < oAppointment.Resources.Count; i++)
            {
                if (oAppointment.Resources[i].ResponseType  != null)
                    s += "    " + oAppointment.Resources[i].Address + ": " + oAppointment.Resources[i].ResponseType.Value.ToString() + "\r\n";
                else
                    s += "    " + oAppointment.Resources[i].Address + ": \r\n";
            }

            return s;

        }

        public static void LoadItemsAttachmentsListLv(Item oItem, ref ListView oListView)
        {

            oListView.Clear();
            oListView.View = View.Details;
            oListView.GridLines = true;
            oListView.FullRowSelect = true;
            oListView.Columns.Add("Id", 70, HorizontalAlignment.Left);

            oListView.Columns.Add("ContentId", 70, HorizontalAlignment.Left);
            oListView.Columns.Add("ContentLocation", 70, HorizontalAlignment.Left);
            oListView.Columns.Add("ContentType", 70, HorizontalAlignment.Left);
            oListView.Columns.Add("Name", 140, HorizontalAlignment.Left);
            oListView.Columns.Add("IsInline", 50, HorizontalAlignment.Left);  // Exchange 2010 and later.
            //oListView.Columns.Add("LastModifiedTime", 70, HorizontalAlignment.Left); // Exchange 2010 and later.
            //oListView.Columns.Add("Size", 70, HorizontalAlignment.Right);    // Exchange 2010 and later.

 
            ListViewItem oListItem = null;
            int iAttachmentCount = 0;
            foreach (Attachment oAttachment in oItem.Attachments)
            {
                oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
                oAttachment.Load();
                if (oAttachment is ItemAttachment)
                {
                    ItemAttachment oItemAttachment = oAttachment as ItemAttachment;

                    // Load attachment into memory so we can get to the item properties (such as subject).
                    oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
                    oItemAttachment.Load();

                    oListItem = new ListViewItem(oAttachment.Id, 0);

                    oListItem.SubItems.Add(oItemAttachment.ContentId);
                    oListItem.SubItems.Add(oItemAttachment.ContentLocation);
                    oListItem.SubItems.Add(oItemAttachment.ContentType);
                    oListItem.SubItems.Add(oItemAttachment.Name);
                    oListItem.SubItems.Add(oItemAttachment.IsInline.ToString());
             
                

                    oListItem.Tag = iAttachmentCount;
                    oListView.Items.AddRange(new ListViewItem[] { oListItem });
                    oListItem = null;
                }

                if (oAttachment is FileAttachment)
                {

                } 

            }
            iAttachmentCount++;
        }

        public static int LoadFileAttachmentsLv(Item oItem, ref ListView oListView)
        {
            int iAttachments = 0;

            oListView.Clear();
            oListView.View = View.Details;
            oListView.GridLines = true;
            oListView.FullRowSelect = true;
            oListView.Columns.Add("Id", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("ContentId", 120, HorizontalAlignment.Left);
            oListView.Columns.Add("ContentLocation", 70, HorizontalAlignment.Left);
            oListView.Columns.Add("ContentType", 120, HorizontalAlignment.Left);
            oListView.Columns.Add("Name", 200, HorizontalAlignment.Left);
            oListView.Columns.Add("FileName", 200, HorizontalAlignment.Left);
            oListView.Columns.Add("IsInline", 50, HorizontalAlignment.Left);  // Exchange 2010 and later.
            oListView.Columns.Add("IsContactPhoto", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("Size", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("LastModifiedTime", 200, HorizontalAlignment.Left);

            ListViewItem oListItem = null;
            int iAttachmentCount = 0;
            bool bIsInline = false;
            foreach (Attachment oAttachment in oItem.Attachments)
            {
                if (oAttachment.Id != null)   // dont reload if attachment was added but message was not saved yet.
                {
                    oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
                    oAttachment.Load();
                }
                // Note: As of EWS 2013_sp1 the schema for attachments is fixed, so we cannot pull extended properties like the ones below
                //      ExtendedPropertyDefinition PidTagAttachPathname = new ExtendedPropertyDefinition(0x3708, MapiPropertyType.String);
                //      ExtendedPropertyDefinition PidTagAttachEncoding = new ExtendedPropertyDefinition(0x3702, MapiPropertyType.Binary);
                //      ExtendedPropertyDefinition PidTagAttachMethod = new ExtendedPropertyDefinition(0x3705, MapiPropertyType.Long);
                //      ExtendedPropertyDefinition PidTagCreationTime = new ExtendedPropertyDefinition(0x3007, MapiPropertyType.ApplicationTime);
                //      ExtendedPropertyDefinition PidTagDisplayName = new ExtendedPropertyDefinition(0x3001, MapiPropertyType.String);
                //      ExtendedPropertyDefinition PidTagAttachExtension = new ExtendedPropertyDefinition(0x3703, MapiPropertyType.String);
                //      ExtendedPropertyDefinition PidTagAttachLongFilename = new ExtendedPropertyDefinition(0x3707, MapiPropertyType.String);
                //      ExtendedPropertyDefinition PidTagAttachTag = new ExtendedPropertyDefinition(0x370A, MapiPropertyType.Binary);
                //      ExtendedPropertyDefinition PidTagAttachTransportName = new ExtendedPropertyDefinition(0x370C, MapiPropertyType.String);
                //      ExtendedPropertyDefinition PidTagLastModificationTime = new ExtendedPropertyDefinition(0x370B, MapiPropertyType.Long);
                //      ExtendedPropertyDefinition PidTagAttachNumber = new ExtendedPropertyDefinition(0x0E21, MapiPropertyType.Long);
                //      ExtendedPropertyDefinition PidTagInstanceKey = new ExtendedPropertyDefinition(0x0FF6, MapiPropertyType.Binary);
                //      ExtendedPropertyDefinition PidTagRecordKey = new ExtendedPropertyDefinition(0x0FF9, MapiPropertyType.Binary);
                //      ExtendedPropertyDefinition PidTagRenderingPosition = new ExtendedPropertyDefinition(0x370B, MapiPropertyType.Long);


                //ExtendedPropertyDefinition TransportMsgHdr = new ExtendedPropertyDefinition(0x007D, MapiPropertyType.String);
                //ExtendedPropertyDefinition PidTagRtfCompressed = new ExtendedPropertyDefinition(0x1009, MapiPropertyType.Binary);
                //ExtendedPropertyDefinition PidTagMimeSkeleton = new ExtendedPropertyDefinition(0x64F00102, MapiPropertyType.String);
                // // http://msdn.microsoft.com/en-us/library/office/hh545614(v=exchg.140).aspx

                //ExtendedPropertyDefinition PidTagRtfCompressed = new ExtendedPropertyDefinition(0x1009, MapiPropertyType.Binary);   
                //PropertySet propertySet = new PropertySet(
                //    new PropertyDefinitionBase[] 
                //        { ItemSchema.MimeContent, 
                //            ItemSchema.Subject, 
                //            PidTagRtfCompressed 
                //        }
                //    );
                //message.Load(propertySet); 

                

                if (oAttachment is FileAttachment)
                {
                    FileAttachment oAttach = oAttachment as FileAttachment;


                    // For Exchange 2010, check for Inline attachments using:
                    //   if (oAttachment.IsInline == true) 
                    // For earlier versions, resort to checking for a set ContentId.
                    //  if (oAttach.ContentId.Length != 0)

                    if (oItem.Service.RequestedServerVersion == ExchangeVersion.Exchange2007_SP1)
                    {
                        if (oAttach.ContentId.Length != 0)
                            bIsInline = true;
                        else
                            bIsInline = false;
                    }
                    else
                    {
                        bIsInline = oAttachment.IsInline;
                    }
                         
                    //if (oAttachment.IsInline == true)
                    //{
                        oListItem = new ListViewItem(oAttach.Id, 0);
                        oListItem.SubItems.Add(oAttach.ContentId);
                        oListItem.SubItems.Add(oAttach.ContentLocation);
                        oListItem.SubItems.Add(oAttach.ContentType);
                        oListItem.SubItems.Add(oAttach.Name);
                        oListItem.SubItems.Add(oAttach.FileName);
                        oListItem.SubItems.Add(bIsInline.ToString());  
                        oListItem.SubItems.Add(oAttach.IsContactPhoto.ToString());
                        oListItem.SubItems.Add(oAttach.Size.ToString());
                        oListItem.SubItems.Add(oAttach.LastModifiedTime.ToString());

                        oListItem.Tag = oAttach;
                        oListView.Items.AddRange(new ListViewItem[] { oListItem });
                        oListItem = null;

 
                        iAttachments++;
 

                }

                if (oAttachment is ItemAttachment)
                {

                }

                iAttachmentCount++;
            }
            return iAttachments;
        }

    }
}
