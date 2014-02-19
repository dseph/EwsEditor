using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Forms.Controls;
using EWSEditor.Logging;
using EWSEditor.Common;

namespace EWSEditor.Forms
{
    public partial class AddRemoveAttachments : Form
    {
        Item _Item = null;
        public AddRemoveAttachments()
        {
            InitializeComponent();
        }

        public AddRemoveAttachments(ref Item oItem)
        {
            _Item = oItem;
            InitializeComponent();
        }

        private void PopulateAttachmentsList()
        {
          
        }


        private void btnInsertAttachment_Click(object sender, EventArgs e)
        {
          

            AttachmentSelect oSelectAttachmentToAdd = new AttachmentSelect();
            oSelectAttachmentToAdd.ShowDialog();

            ListViewItem oListItem = null;

            if (oSelectAttachmentToAdd.ChoseOK == true)
            {
                FileAttachment oNewFileAttachment = _Item.Attachments.AddFileAttachment(oSelectAttachmentToAdd.txtFile.Text);

                oNewFileAttachment.ContentId = oSelectAttachmentToAdd.txtContentId.Text.Trim();
                oNewFileAttachment.ContentLocation = oSelectAttachmentToAdd.txtContentLocation.Text.Trim();
                oNewFileAttachment.ContentType = oSelectAttachmentToAdd.cmboContentType.Text.Trim();
                //oNewFileAttachment.Name = oSelectAttachmentToAdd.Name.Text.Trim();
                oNewFileAttachment.IsInline = oSelectAttachmentToAdd.chkIsInline.Checked;
                oNewFileAttachment.IsContactPhoto = oSelectAttachmentToAdd.chkIsContactPhoto.Checked;

                oListItem = new ListViewItem(oNewFileAttachment.Id, 0);
                //oListItem.SubItems.Add(oNewFileAttachment.Id);
                oListItem.SubItems.Add(oNewFileAttachment.ContentId);
                oListItem.SubItems.Add(oNewFileAttachment.ContentLocation);
                oListItem.SubItems.Add(oNewFileAttachment.ContentType);
                oListItem.SubItems.Add(oNewFileAttachment.Name);
                oListItem.SubItems.Add(oNewFileAttachment.IsInline.ToString());
   
                lvFileAttachments.Items.AddRange(new ListViewItem[] { oListItem });
                oListItem = null;

            }
 
        }

        private void btnDeleteAttachment_Click(object sender, EventArgs e)
        {
            //if (chkListAttachments.CheckedItems.Count != 0)
            //{
            //    while (chkListAttachments.CheckedIndices.Count > 0)
            //    {
            //        chkListAttachments.Items.RemoveAt(chkListAttachments.CheckedIndices[0]);
            //    }
            //}
        }

        private void AddRemoveAttachments_Load(object sender, EventArgs e)
        {
            AppointmentHelper.LoadFileAttachmentsLv(_Item, ref lvFileAttachments);
            //AppointmentHelper.LoadItemsAttachmentsListLv(_Item, ref lvItemAttachments);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        //private void btnInsertInlineAttachment_Click(object sender, EventArgs e)
        //{
        //    AttachmentSelect oSelectAttachmentToAdd = new AttachmentSelect();
        //    oSelectAttachmentToAdd.ShowDialog();

        //    ListViewItem oListItem = null;

        //    if (oSelectAttachmentToAdd.ChoseOK == true)
        //    {
        //        FileAttachment oNewFileAttachment = _Item.Attachments.AddFileAttachment(oSelectAttachmentToAdd.txtFile.Text);
        //        oNewFileAttachment.ContentId = oSelectAttachmentToAdd.txtContentId.Text.Trim();
        //        oNewFileAttachment.ContentLocation = oSelectAttachmentToAdd.txtContentLocation.Text.Trim();
        //        oNewFileAttachment.ContentType = oSelectAttachmentToAdd.txtContentId.Text.Trim();
        //        oNewFileAttachment.Name = oSelectAttachmentToAdd.txtContentId.Text.Trim();
        //        oNewFileAttachment.IsInline = oSelectAttachmentToAdd.chkIsInline.Checked;
        //        oNewFileAttachment.IsContactPhoto = oSelectAttachmentToAdd.chkIsContactPhoto.Checked;



        //        //oListView.Columns.Add("Id", 70, HorizontalAlignment.Left);
        //        //oListView.Columns.Add("ContentId", 70, HorizontalAlignment.Left);
        //        //oListView.Columns.Add("ContentLocation", 70, HorizontalAlignment.Left);
        //        //oListView.Columns.Add("ContentType", 70, HorizontalAlignment.Left);
        //        //oListView.Columns.Add("Name", 140, HorizontalAlignment.Left);
        //        //oListView.Columns.Add("FileName", 140, HorizontalAlignment.Left);
        //        //oListView.Columns.Add("IsInline", 50, HorizontalAlignment.Left);  // Exchange 2010 and later.
        //        //oListView.Columns.Add("IsContactPhoto", 50, HorizontalAlignment.Left);


        //        // Now add to ListView
        //        oListItem = new ListViewItem(oNewFileAttachment.Id, 0);
        //        oListItem.SubItems.Add(oNewFileAttachment.ContentId);
        //        oListItem.SubItems.Add(oNewFileAttachment.ContentLocation);
        //        oListItem.SubItems.Add(oNewFileAttachment.ContentType);
        //        oListItem.SubItems.Add(oNewFileAttachment.Name);
        //        oListItem.SubItems.Add(oNewFileAttachment.FileName);
        //        oListItem.SubItems.Add(oNewFileAttachment.IsInline.ToString());
        //        oListItem.SubItems.Add(oNewFileAttachment.IsContactPhoto.ToString());

        //        lvFileAttachments.Items.AddRange(new ListViewItem[] { oListItem });
        //        oListItem = null;

        //    }
        //}

        private void lvFileAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvFileAttachments_DoubleClick(object sender, EventArgs e)
        {
            // EditSelectedItem();
        }

        private void EditSelectedItem()
        {
            if (lvFileAttachments.SelectedItems.Count != 0)
            {
                AttachmentSelect oSelectAttachmentToAdd = new AttachmentSelect();
                oSelectAttachmentToAdd.ShowDialog();
                if (oSelectAttachmentToAdd.ChoseOK == true)
                {
                    //FileAttachment oNewFileAttachment = _Item.Attachments.AddFileAttachment(oSelectAttachmentToAdd.txtFile.Text);
                    //oNewFileAttachment.ContentId = oSelectAttachmentToAdd.txtContentId.Text.Trim();
                    ////oNewFileAttachment.ContentLocation = oSelectAttachmentToAdd.ContentLocation.Text.Trim();
                    //oNewFileAttachment.ContentType = oSelectAttachmentToAdd.txtContentId.Text.Trim();
                    //oNewFileAttachment.Name = oSelectAttachmentToAdd.txtContentId.Text.Trim();
                    //oNewFileAttachment.IsInline = oSelectAttachmentToAdd.chkIsInline.Checked;


                    //// Now add to ListView
                    //oListItem = new ListViewItem(oNewFileAttachment.Id, 0);
                    //oListItem.SubItems.Add(oNewFileAttachment.ContentId);
                    //oListItem.SubItems.Add(oNewFileAttachment.ContentLocation);
                    //oListItem.SubItems.Add(oNewFileAttachment.ContentType);
                    //oListItem.SubItems.Add(oNewFileAttachment.Name);
                    //oListItem.SubItems.Add(oNewFileAttachment.IsInline.ToString());

                    //lvFileAttachments.Items.AddRange(new ListViewItem[] { oListItem });
                    //oListItem = null;
                }

            }
        }
    }
}
