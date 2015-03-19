using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
 
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Forms.Controls;
using EWSEditor.Logging;
using EWSEditor.Common;

namespace EWSEditor.Forms
{
    public partial class AttachmentsForm : Form
    {
        private ExchangeService _CurrentService = null;

        //private bool _AttachmentsListModified = false;
        //private ItemId _ItemId = null;     
        private Item _Item = null;
        
        public AttachmentsForm()
        {
            InitializeComponent();
        }

 

        public AttachmentsForm(ExchangeService CurrentService, ItemId oItemId)
        {
            InitializeComponent();

            _CurrentService = CurrentService;  // oEwsCaller contains the ExchangeService object, plus some wraps some additonal common calls.
             
            _Item = Item.Bind(CurrentService, oItemId);
 
            //_Item = Item.Bind(oEwsCaller.ExchService, new ItemId(oItemId.UniqueId),new PropertySet(BasePropertySet.FirstClassProperties, ItemSchema.Attachments));

            LoadFileNonInlineAttachmentsLv(oItemId, ref lvFileAttachments);
            LoadFileInlineAttachmentsLv(oItemId, ref lvInlineFileAttachments);
            LoadEmbededItemsAttachmentsListLv(oItemId, ref lvEmbededItemsAttachments);
            //_AttachmentsListModified = false;

        }

        private void AttachmentsForm_Load(object sender, EventArgs e)
        {
            //ShowTextDocument oForm = new ShowTextDocument();
            //oForm.txtEntry.Text = sInfo;
            //oForm.ShowDialog();
            //oForm = null;
        }

        private int LoadFileNonInlineAttachmentsLv(ItemId oItemId, ref ListView oListView)
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
            oListView.Columns.Add("FileName", 200, HorizontalAlignment.Left);
            oListView.Columns.Add("IsInline", 50, HorizontalAlignment.Left);  // Exchange 2010 and later.
            oListView.Columns.Add("LastModifiedTime", 70, HorizontalAlignment.Left);    // Exchange 2010 and later.
            oListView.Columns.Add("Size", 70, HorizontalAlignment.Right);    // Exchange 2010 and later.

            ListViewItem oListItem = null;
            int iAttachmentCount = 0;
            foreach (Attachment oAttachment in _Item.Attachments)
            {
                if (oAttachment is FileAttachment)
                {
                    FileAttachment oAttach = oAttachment as FileAttachment;
                    oAttachment.Load();

                    // For Exchange 2010, check for Inline attachments using:
                    //   if (oAttachment.IsInline == false) 
                    // For earlier versions, resort to checking for ContentId not being set.
                    //   if (oAttach.ContentId.Length == 0)
                    if (oAttachment.IsInline == false) 
                    {

                        //ExtendedPropertyDefinition myProperty = new ExtendedPropertyDefinition(
                        //        DefaultExtendedPropertySet.PublicStrings,
                        //        "urn:schemas:contacts:propertyx",
                        //        MapiPropertyType.String);

                        //Item item = Item.Bind(
                        //    service,
                        //    new ItemId("your id"),
                        //    new PropertySet(BasePropertySet.FirstClassProperties, myProperty));


                        oListItem = new ListViewItem(oAttach.Id, 0);
                        oListItem.SubItems.Add(oAttach.ContentId);
                        oListItem.SubItems.Add(oAttach.ContentLocation);
                        oListItem.SubItems.Add(oAttach.ContentType);
                        oListItem.SubItems.Add(oAttach.Name);
                        oListItem.SubItems.Add(oAttach.FileName);
                        oListItem.SubItems.Add(oAttach.IsInline.ToString()); // Exchange 2010 and later.
                        oListItem.SubItems.Add(oAttachment.LastModifiedTime.ToString()); // Exchange 2010 and later.
                        oListItem.SubItems.Add(oAttach.Size.ToString());    // Exchange 2010 and later.
                         
                         
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

        private int LoadFileInlineAttachmentsLv(ItemId oItemId, ref ListView oListView)
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
            oListView.Columns.Add("LastModifiedTime", 70, HorizontalAlignment.Left); // Exchange 2010 and later.
            oListView.Columns.Add("Size", 70, HorizontalAlignment.Right);    // Exchange 2010 and later.

            ListViewItem oListItem = null;
            int iAttachmentCount = 0;
            foreach (Attachment oAttachment in _Item.Attachments)
            {
                oAttachment.Load(); 

                if (oAttachment is FileAttachment)
                {
                    FileAttachment oAttach = oAttachment as FileAttachment;
                     

                    // For Exchange 2010, check for Inline attachments using:
                    //   if (oAttachment.IsInline == true) 
                    // For earlier versions, resort to checking for a set ContentId.
                    //  if (oAttach.ContentId.Length != 0)
                    if (oAttachment.IsInline == true)
                    {
                        oListItem = new ListViewItem(oAttach.Id, 0);
                        oListItem.SubItems.Add(oAttach.ContentId);
                        oListItem.SubItems.Add(oAttach.ContentLocation);
                        oListItem.SubItems.Add(oAttach.ContentType);
                        oListItem.SubItems.Add(oAttach.Name);
                        oListItem.SubItems.Add(oAttach.FileName);
                        oListItem.SubItems.Add(oAttach.IsInline.ToString()); // Exchange 2010 and later.
                        oListItem.SubItems.Add(oAttach.IsContactPhoto.ToString());
                         
                        oListItem.SubItems.Add(oAttachment.LastModifiedTime.ToString());    // Exchange 2010 and later.
                        oListItem.SubItems.Add(oAttach.Size.ToString());    // Exchange 2010 and later.

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

        private void LoadEmbededItemsAttachmentsListLv(ItemId oItemId, ref ListView oListView)
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
            oListView.Columns.Add("LastModifiedTime", 70, HorizontalAlignment.Left); // Exchange 2010 and later.
            oListView.Columns.Add("Size", 70, HorizontalAlignment.Right);    // Exchange 2010 and later.

            oListView.Columns.Add("Item.Subject", 140, HorizontalAlignment.Left);
            oListView.Columns.Add("Item.ItemClass", 70, HorizontalAlignment.Left);
            oListView.Columns.Add("Item.LastModifiedTime", 70, HorizontalAlignment.Left);
            oListView.Columns.Add("Item.HasAttachments", 70, HorizontalAlignment.Left);
            oListView.Columns.Add("Item.DisplayTo", 70, HorizontalAlignment.Left);
            oListView.Columns.Add("Item.Size", 70, HorizontalAlignment.Right);

            ListViewItem oListItem = null;
            int iAttachmentCount = 0;
            foreach (Attachment oAttachment in _Item.Attachments)
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
                    oListItem.SubItems.Add(oItemAttachment.LastModifiedTime.ToString());
                    oListItem.SubItems.Add(oItemAttachment.Item.Size.ToString());


                    oListItem.SubItems.Add(oItemAttachment.Item.Subject);
                    oListItem.SubItems.Add(oItemAttachment.Item.ItemClass);
                    oListItem.SubItems.Add(oItemAttachment.Item.LastModifiedTime.ToString());
                    oListItem.SubItems.Add(oItemAttachment.Item.HasAttachments.ToString());
                    oListItem.SubItems.Add(oItemAttachment.Item.DisplayTo);
                    oListItem.SubItems.Add(oItemAttachment.Item.Size.ToString());
                    
                    oListItem.Tag = iAttachmentCount;
                    oListView.Items.AddRange(new ListViewItem[] { oListItem });
                    oListItem = null;
                }

            }
            iAttachmentCount++;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmsFileAttachmentsSaveAs_Click(object sender, EventArgs e)
        {
            if (lvFileAttachments.SelectedItems.Count > 0)
            {
                int iAttachment = 0;
                string SelectedFile = string.Empty;
                iAttachment = (int)lvFileAttachments.SelectedItems[0].Tag;
                if (_Item.Attachments[iAttachment] is FileAttachment)
                {
                    FileAttachment oFileAttachment = (FileAttachment)_Item.Attachments[iAttachment];
                    if (UserIoHelper.PickSaveFileToFolder(oFileAttachment.Name, ref SelectedFile))
                    {
                        oFileAttachment.Load((SelectedFile));
                    }
                }
            }
        }

        private void cmsInlineFileAttachmentsSaveAs_Click(object sender, EventArgs e)
        {
            if (lvInlineFileAttachments.SelectedItems.Count > 0)
            {
                int iAttachment = 0;
                string SelectedFile = string.Empty;
                iAttachment = (int)lvInlineFileAttachments.SelectedItems[0].Tag;
                if (_Item.Attachments[iAttachment] is FileAttachment)
                {
                    FileAttachment oFileAttachment = (FileAttachment)_Item.Attachments[iAttachment];
                    if (UserIoHelper.PickSaveFileToFolder(oFileAttachment.Name, ref SelectedFile))
                    {
                        oFileAttachment.Load((SelectedFile));
                    }
                }
            }
        }

        private void cmsEmbededItemsAttachmentsSaveAs_Click(object sender, EventArgs e)
        {
            if (lvEmbededItemsAttachments.SelectedItems.Count > 0)
            {
                int iAttachment = 0;
                string SelectedFile = string.Empty;
                iAttachment = (int)lvEmbededItemsAttachments.SelectedItems[0].Tag;

 
 
                if (_Item.Attachments[iAttachment] is FileAttachment)
                {
                    FileAttachment oFileAttachment = (FileAttachment)_Item.Attachments[iAttachment];
                    if (UserIoHelper.PickSaveFileToFolder(oFileAttachment.Name, ref SelectedFile))
                    {
                        oFileAttachment.Load((SelectedFile));
                    }
                }

                //if (_Item.Attachments[iAttachment] is ItemAttachment)
                //{
                //    ItemAttachment oAttachment = (ItemAttachment)_Item.Attachments[iAttachment];
                    
                //    ItemAttachment oItemAttachment = oAttachment as ItemAttachment;
                //    oItemAttachment.Load();  // Load attachment into memory so we can get to the item properties (such as subject).
                      
                //    //_EwsCaller.GetItemMime(

                    
                //    //PropertySet oMimePropertySet = new PropertySet(ItemSchema.MimeContent);
                //    //Item oAttachmentItem = Item.Bind(_ExchangeService, oItemAttachment.Id, oMimePropertySet);
                //    //string sStuff =  oAttachmentItem.MimeContent.ToString() ;

                //    // string sStuff = _EwsCaller.GetItemMime(oItemAttachment.Id);


                //    //oAttachmentItem.

                //    //EmailMessage email = EmailMessage.Bind(es, current.Id) ;

                //    //Attachment x = (Attachment)ItemAttachment;
                //    // TODO: Get it working. 
                //    // Should be able to get the stream of the attachment and save it...
                //    //oItemAttachment = _Item.Service.FileAttachmentContentHandler
                //    //Item oxItem = (Item)oItemAttachment;
                     
                //    if (UserIoHelper.PickSaveFileToFolder(oItemAttachment.Item.Subject + ".msg", ref SelectedFile))
                //    {
                         
                //        byte[] MimeBytes = oItemAttachment.Item.MimeContent.Content;

                //        System.IO.File.WriteAllBytes(SelectedFile, MimeBytes);

                //        //PropertySet mimeSet = new PropertySet(BasePropertySet.IdOnly);

                //        //mimeSet.Add(EmailMessageSchema.MimeContent);
                //        //mimeSet.Add(EmailMessageSchema.Subject);

                //        //FileAttachment fileAttachment = oItemAttachment as FileAttachment;

                //        //FileAttachment oFileAttachment = (FileAttachment)oItemAttachment;
                //        //MemoryStream oMemoryStream = new MemoryStream();
                //        //oFileAttachment.Load(oMemoryStream);
                //        //StreamReader oStreamReader = new StreamReader(oMemoryStream);
                //        //oMemoryStream.Seek(0, SeekOrigin.Begin);
                //        //byte[] bytes = oMemoryStream.GetBuffer();

                //        //PropertySet oMimePropertySet = new PropertySet(ItemSchema.MimeContent);
                //        //oItem.Load(oMimePropertySet);
                //        //sReturn = oItem.MimeContent.ToString();

                //        //Attachment oA = (Attachment)_Item.Attachments[iAttachment];
                //        //FileAttachment oFA = (FileAttachment)oA;
                //        // System.IO.File.WriteAllBytes(SelectedFile, oItemAttachment.Item.Copy();
                //        //oFA.Load(SelectedFile);
                //        //FileStream theStream = new FileStream("C:\\testx\\Stream_" + SelectedFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                //        //theStream.w
                //        //theStream.Close();
                //        //theStream.Dispose();
                //        //System.IO.File.WriteAllBytes("C:\\testx\\Stream_" + SelectedFile, (bytes[])sStuff.ToCharArray());

                         
                //    }
                // }
            }
        }

        private void cmsEmbededItemsAttachments_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cmsInlineFileAttachmentsViewMime_Click(object sender, EventArgs e)
        {
            if (lvInlineFileAttachments.SelectedItems.Count > 0)
            {
                int iAttachment = 0;
                string SelectedFile = string.Empty;
                iAttachment = (int)lvInlineFileAttachments.SelectedItems[0].Tag;
                if (_Item.Attachments[0] is FileAttachment)
                {
                    FileAttachment oFileAttachment = (FileAttachment)_Item.Attachments[iAttachment];
                    if (UserIoHelper.PickSaveFileToFolder(oFileAttachment.Name, ref SelectedFile))
                    {
                        //oFileAttachment.Load((SelectedFile));
                        //oFileAttachment.Load(
                        //_EwsCaller.ExchService.getGetItemMime(oFileAttachment); 
                        //ShowTextDocument oForm = new ShowTextDocument();
                        //oForm.txtEntry.Text = sInfo;
                        //oForm.ShowDialog();
                        //oForm = null;
                    }
                }
            }
        }

        private void cmsFileAttachmentsViewMime_Click(object sender, EventArgs e)
        {
            if (lvInlineFileAttachments.SelectedItems.Count > 0)
            {
                 
                int iAttachment = 0;
                string SelectedFile = string.Empty;
                iAttachment = (int)lvFileAttachments.SelectedItems[0].Tag;
                if (_Item.Attachments[0] is FileAttachment)
                {
                    FileAttachment oFileAttachment = (FileAttachment)_Item.Attachments[iAttachment];
                    if (UserIoHelper.PickSaveFileToFolder(oFileAttachment.Name, ref SelectedFile))
                    {
                        //oFileAttachment.Load((SelectedFile));
                        //oFileAttachment.Load(
                        //_EwsCaller.ExchService.getGetItemMime(oFileAttachment); 
                        //ShowTextDocument oForm = new ShowTextDocument();
                        //oForm.txtEntry.Text = sInfo;
                        //oForm.ShowDialog();
                        //oForm = null;
                    }
                }
            }
        }

        private void lvFileAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvInlineFileAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmsEmbededItemsAttachmentsViewMime_Click(object sender, EventArgs e)
        {

        }

        private void cmsEmbededItemsAttachmentsViewsWithOutlook_Click(object sender, EventArgs e)
        {

        }
    }
}
