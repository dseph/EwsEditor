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

        public static string GetAttendeeStatusAsInfoString(Appointment oAppointment)
        {

            // http://msdn.microsoft.com/en-us/library/dd633669(EXCHG.80).aspx
            string s = string.Empty;


            // Check responses from required attendees.
            s += "Required attendee:\r\n";
            for (int i = 0; i < oAppointment.RequiredAttendees.Count; i++)
            {
                s += "    " + oAppointment.RequiredAttendees[i].Address + ": " + oAppointment.RequiredAttendees[i].ResponseType.Value.ToString() + "\r\n";
            }

            // Check responses from optional attendees.
            s += "Optional attendee:\r\n";
            for (int i = 0; i < oAppointment.OptionalAttendees.Count; i++)
            {
                s += "    " + oAppointment.OptionalAttendees[i].Address + ": " + oAppointment.OptionalAttendees[i].ResponseType.Value.ToString() + "\r\n";
            }

            // Check responses from resources.
            s += "Resource attendee:\r\n";
            for (int i = 0; i < oAppointment.Resources.Count; i++)
            {
                s += "    " + oAppointment.Resources[i].Address + ": " + oAppointment.Resources[i].ResponseType.Value.ToString() + "\r\n";
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
                oAttachment.Load();
                if (oAttachment is ItemAttachment)
                {
                    ItemAttachment oItemAttachment = oAttachment as ItemAttachment;

                    // Load attachment into memory so we can get to the item properties (such as subject).
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
            oListView.Columns.Add("Id", 70, HorizontalAlignment.Left);
            oListView.Columns.Add("ContentId", 70, HorizontalAlignment.Left);
            oListView.Columns.Add("ContentLocation", 70, HorizontalAlignment.Left);
            oListView.Columns.Add("ContentType", 70, HorizontalAlignment.Left);
            oListView.Columns.Add("Name", 140, HorizontalAlignment.Left);
            oListView.Columns.Add("FileName", 140, HorizontalAlignment.Left);
            oListView.Columns.Add("IsInline", 50, HorizontalAlignment.Left);  // Exchange 2010 and later.
            oListView.Columns.Add("IsContactPhoto", 50, HorizontalAlignment.Left);
        

            ListViewItem oListItem = null;
            int iAttachmentCount = 0;
            bool bIsInline = false;
            foreach (Attachment oAttachment in oItem.Attachments)
            {
                oAttachment.Load();

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
                        
                    if (oAttachment.IsInline == true)
                    {
                        oListItem = new ListViewItem(oAttach.Id, 0);
                        oListItem.SubItems.Add(oAttach.ContentId);
                        oListItem.SubItems.Add(oAttach.ContentLocation);
                        oListItem.SubItems.Add(oAttach.ContentType);
                        oListItem.SubItems.Add(oAttach.Name);
                        oListItem.SubItems.Add(oAttach.FileName);
                        oListItem.SubItems.Add(bIsInline.ToString());  
                        oListItem.SubItems.Add(oAttach.IsContactPhoto.ToString());
 
                        oListItem.Tag = iAttachmentCount;
                        oListView.Items.AddRange(new ListViewItem[] { oListItem });
                        oListItem = null;
                        iAttachments++;
                    }
                }
                iAttachmentCount++;
            }
            return iAttachments;
        }

    }
}
