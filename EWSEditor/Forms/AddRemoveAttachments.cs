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
        bool _IsExistingEmail = false;
        public bool IsDirty = true;

        public AddRemoveAttachments()
        {
            InitializeComponent();
        }

        public AddRemoveAttachments(ref Item oItem, bool IsExistingEmail)
        {
            _Item = oItem;
            _IsExistingEmail = IsExistingEmail;

            IsDirty = false;
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
            
                if (oSelectAttachmentToAdd.chkIsInline.Checked == true)
                {
                    if (oSelectAttachmentToAdd.txtContentId.Text.Trim().Length != 0)
                        oNewFileAttachment.ContentId = oSelectAttachmentToAdd.txtContentId.Text.Trim();
                    if (oSelectAttachmentToAdd.txtContentLocation.Text.Trim().Length != 0)
                        oNewFileAttachment.ContentLocation = oSelectAttachmentToAdd.txtContentLocation.Text.Trim();
                    if (oSelectAttachmentToAdd.txtContentType.Text.Trim().Length != 0)
                        oNewFileAttachment.ContentType = oSelectAttachmentToAdd.txtContentType.Text.Trim();
                    //oNewFileAttachment.Name = oSelectAttachmentToAdd.Name.Text.Trim();
                    oNewFileAttachment.IsInline = oSelectAttachmentToAdd.chkIsInline.Checked;
                }
                oNewFileAttachment.IsContactPhoto = oSelectAttachmentToAdd.chkIsContactPhoto.Checked;


                oListItem = new ListViewItem(oNewFileAttachment.Id, 0);
                //oListItem.SubItems.Add(oNewFileAttachment.Id);
                //if (oSelectAttachmentToAdd.chkIsInline.Checked == true)
                //{
                    oListItem.SubItems.Add(oNewFileAttachment.ContentId);
                    oListItem.SubItems.Add(oNewFileAttachment.ContentLocation);
                    oListItem.SubItems.Add(oNewFileAttachment.ContentType);
                    oListItem.SubItems.Add(oNewFileAttachment.Name);
                    oListItem.SubItems.Add(oNewFileAttachment.FileName);
                    oListItem.SubItems.Add(oNewFileAttachment.IsInline.ToString());
                    oListItem.SubItems.Add(oNewFileAttachment.IsContactPhoto.ToString());

                    oListItem.SubItems.Add("");
                    oListItem.SubItems.Add("");
                    //oListItem.SubItems.Add(oNewFileAttachment.Size.ToString());
                    //oListItem.SubItems.Add(oNewFileAttachment.LastModifiedTime.ToString());
                    //}
                //else
                //{
                //    oListItem.SubItems.Add("");
                //    oListItem.SubItems.Add("");
                //    oListItem.SubItems.Add("");
                //    oListItem.SubItems.Add(oNewFileAttachment.Name);
                //    oListItem.SubItems.Add("");
                //}
                oListItem.Tag = (Attachment) oNewFileAttachment;

                lvFileAttachments.Items.AddRange(new ListViewItem[] { oListItem });
                oListItem = null;

                IsDirty = true;

            }
 
        }

        private void btnDeleteAttachment_Click(object sender, EventArgs e)
        {
            if (lvFileAttachments.SelectedItems.Count != 0)
            {
                 
                Attachment oAttachment = (Attachment)lvFileAttachments.SelectedItems[0].Tag;
                _Item.Attachments.Remove(oAttachment);
                //AppointmentHelper.LoadFileAttachmentsLv(_Item, ref lvFileAttachments);  

                lvFileAttachments.Items.Remove(lvFileAttachments.SelectedItems[0]);
                IsDirty = true;
            }
        }

        private void AddRemoveAttachments_Load(object sender, EventArgs e)
        {
            btnInsertFileAttachment.Enabled = !(_IsExistingEmail);
            btnDeleteFileAttachment.Enabled = !(_IsExistingEmail);

            AppointmentHelper.LoadFileAttachmentsLv(_Item, ref lvFileAttachments);

       
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

       

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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
