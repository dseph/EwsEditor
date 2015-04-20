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


// Note:  This form is not curently used and is incomplete.

namespace EWSEditor
{
    public partial class AddRemoveHeaders : Form
    {
        Item _Item = null;
        bool _IsExistingEmail = false;
        public bool IsDirty = true;
        public AddRemoveHeaders()
        {
            InitializeComponent();
        }


        public AddRemoveHeaders(ref Item oItem, bool IsExistingEmail)
        {
            _Item = oItem;
            _IsExistingEmail = IsExistingEmail;

            IsDirty = false;
      
            InitializeComponent();
        }

        private void AddRemoveHeaders_Load(object sender, EventArgs e)
        {
            this.btnAdd.Enabled = !(_IsExistingEmail);
            this.btnDelete.Enabled = !(_IsExistingEmail);

            // TODO: Load existing x-headers for this draft message...  
            //      Be sure to test on a new message and loaded one from Drafts

            //AppointmentHelper.LoadFileAttachmentsLv(_Item, ref lvFileAttachments);
        }

        private void btnDeleteFileAttachment_Click(object sender, EventArgs e)
        {
 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //AttachmentSelect oSelectAttachmentToAdd = new AttachmentSelect();
            //oSelectHeaderAdd.ShowDialog();

            //ListViewItem oListItem = null;

            //if (oSelectHeaderAdd.ChoseOK == true)
            //{
                //FileAttachment oNewFileAttachment = _Item.Attachments.AddFileAttachment(oSelectAttachmentToAdd.txtFile.Text);

                //if (oSelectAttachmentToAdd.chkIsInline.Checked == true)
                //{
                //    if (oSelectAttachmentToAdd.txtContentId.Text.Trim().Length != 0)
                //        oNewFileAttachment.ContentId = oSelectAttachmentToAdd.txtContentId.Text.Trim();
                //    if (oSelectAttachmentToAdd.txtContentLocation.Text.Trim().Length != 0)
                //        oNewFileAttachment.ContentLocation = oSelectAttachmentToAdd.txtContentLocation.Text.Trim();
                //    if (oSelectAttachmentToAdd.txtContentType.Text.Trim().Length != 0)
                //        oNewFileAttachment.ContentType = oSelectAttachmentToAdd.txtContentType.Text.Trim();
                //    //oNewFileAttachment.Name = oSelectAttachmentToAdd.Name.Text.Trim();
                //    oNewFileAttachment.IsInline = oSelectAttachmentToAdd.chkIsInline.Checked;
                //}
                //oNewFileAttachment.IsContactPhoto = oSelectAttachmentToAdd.chkIsContactPhoto.Checked;


                //oListItem = new ListViewItem(oNewFileAttachment.Id, 0);
   
                //oListItem.SubItems.Add(oNewFileAttachment.ContentId);
                //oListItem.SubItems.Add(oNewFileAttachment.ContentLocation);
                //oListItem.SubItems.Add(oNewFileAttachment.ContentType);
                //oListItem.SubItems.Add(oNewFileAttachment.Name);
                //oListItem.SubItems.Add(oNewFileAttachment.FileName);
                //oListItem.SubItems.Add(oNewFileAttachment.IsInline.ToString());
                //oListItem.SubItems.Add(oNewFileAttachment.IsContactPhoto.ToString());

                //oListItem.SubItems.Add("");
                //oListItem.SubItems.Add("");
                
                //oListItem.Tag = (Attachment)oNewFileAttachment;

            //    lvHeaders.Items.AddRange(new ListViewItem[] { oListItem });
            //    oListItem = null;

            //    IsDirty = true;

            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvHeaders.SelectedItems.Count != 0)
            {

                Attachment oAttachment = (Attachment)lvHeaders.SelectedItems[0].Tag;

                //_Item.Attachments.Remove(oAttachment);
 
                lvHeaders.Items.Remove(lvHeaders.SelectedItems[0]);
                IsDirty = true;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

  
    }
}
