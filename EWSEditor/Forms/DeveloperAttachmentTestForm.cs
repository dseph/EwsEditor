using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EWSEditor.Common;
using EWSEditor.Exchange;
using EWSEditor.Logging;
using EWSEditor.Resources;
using EWSEditor.Settings;
using System.Net;
using System.Xml;
using Microsoft.Exchange.WebServices.Data;
using System.Collections;
using EWSEditor.Common;

namespace EWSEditor.Forms
{
    public partial class DeveloperAttachmentTestForm : Form
    {
        ExchangeService _service = null;
        ItemId _itemId = null;
        Attachment _Attachment = null;

        public DeveloperAttachmentTestForm()
        {
            InitializeComponent();
        }

        public DeveloperAttachmentTestForm(ExchangeService service, ItemId itemId, Attachment attachment)
        {
            InitializeComponent(); 
            _service = service;
            _itemId = itemId;
            _Attachment = attachment;
        }

        private void DeveloperAttachmentTestForm_Load(object sender, EventArgs e)
        {
            StringBuilder oSB = new StringBuilder();
            oSB.Append("This window is to be used by develpers with EWSEditor source in order that they may test their EWS Managed API code  to work on a selected attachment.  ");
            oSB.Append("  The ExchangeService, ItemId and Attachment are availible in ths form so that you can use them in your custom test code.");
            oSB.AppendLine("");
            oSB.AppendLine("");
            oSB.AppendFormat("Service.Url.AbsolutePath: {0}\r\n", _service.Url.AbsoluteUri.ToString());
            oSB.AppendLine("");
            oSB.AppendLine("ItemId.UniqueId: " + _itemId.UniqueId);
            oSB.AppendLine("ItemId.ChangeKey: " + _itemId.ChangeKey);
            oSB.AppendLine("");
            oSB.AppendLine("Attachment.Name: " + StringHelper.DeNullString(_Attachment.Name));
            oSB.AppendLine("Attachment.Id: " + StringHelper.DeNullString(_Attachment.Id));
            oSB.AppendLine("Attachment.ContentId: " + StringHelper.DeNullString(_Attachment.ContentId));
            oSB.AppendLine("Attachment.ContentLocation: " + StringHelper.DeNullString(_Attachment.ContentLocation));

            textBox1.Text = oSB.ToString();
        }

        //private string DeNullString(string s)
        //{
        //    if (s == null)
        //        return "";
        //    else
        //        return s;
        //}


        // LoadItem
        // This will load an item by ID.
        // Test code to load a folder object with many properties - modify as needed for your code.
        bool LoadItem(ExchangeService oService, ItemId oItemId, out Item oItem)
        {
            bool bRet = true;

            ExtendedPropertyDefinition Prop_IsHidden = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.Boolean);

            Item oReturnItem = null;
            oItem = null;

            List<ItemId> oItems = new List<ItemId>();
            oItems.Add(oItemId);

            PropertySet oPropertySet = new PropertySet(
                BasePropertySet.IdOnly,
                EmailMessageSchema.ItemClass,
                EmailMessageSchema.Subject);

            // Add more properties?
            oPropertySet.Add(Prop_IsHidden);
            oPropertySet.Add(EmailMessageSchema.DateTimeCreated);
            oPropertySet.Add(EmailMessageSchema.DateTimeReceived);
            oPropertySet.Add(EmailMessageSchema.DateTimeSent);
            //oPropertySet.Add(EmailMessageSchema.RetentionDate);
            oPropertySet.Add(EmailMessageSchema.ToRecipients);
            oPropertySet.Add(EmailMessageSchema.MimeContent);
            oPropertySet.Add(EmailMessageSchema.StoreEntryId);
            oPropertySet.Add(EmailMessageSchema.Size);

            ServiceResponseCollection<GetItemResponse> oGetItemResponses = oService.BindToItems(oItems, oPropertySet);


            foreach (GetItemResponse oGetItemResponse in oGetItemResponses)
            {
                switch (oGetItemResponse.Result)
                {
                    case ServiceResult.Success:

                        oReturnItem = oGetItemResponse.Item;

                        // EmailMessage oEmailMessage = (EmailMessage)oReturnItem; // recasting example

                        MessageBox.Show("ServiceResult.Success");

                        //// The following is for geting the MIME string
                        //if (oGetItemResponse.Item.MimeContent == null)
                        //{
                        //    // Do something
                        //}
                        //UTF8Encoding oUTF8Encoding = new UTF8Encoding();
                        //string sMIME = oUTF8Encoding.GetString(oGetItemResponse.Item.MimeContent.Content);

                        break;
                    case ServiceResult.Error:
                        string sError =
                                "ErrorCode:           " + oGetItemResponse.ErrorCode.ToString() + "\r\n" +
                                "\r\nErrorMessage:    " + oGetItemResponse.ErrorMessage + "\r\n";

                        MessageBox.Show(sError, "ServiceResult.Error");

                        break;
                    case ServiceResult.Warning:
                        string sWarning =
                               "ErrorCode:           " + oGetItemResponse.ErrorCode.ToString() + "\r\n" +
                               "\r\nErrorMessage:    " + oGetItemResponse.ErrorMessage + "\r\n";

                        MessageBox.Show(sWarning, "ServiceResult.Warning");

                        break;
                    //default:
                    //    // Should never get here.
                    //    string sSomeError =
                    //            "ErrorCode:           " + oGetItemResponse.ErrorCode.ToString() + "\r\n" +
                    //            "\r\nErrorMessage:    " + oGetItemResponse.ErrorMessage + "\r\n";

                    //    MessageBox.Show(sSomeError, "Some sort of error");
                    //    break;
                }

            }

            oItem = oReturnItem;

            return bRet;
        }
 


        private void btnTest_Click(object sender, EventArgs e)
        {
            bool bRet = false;
            Item oItem = null;

            //  Load item properties...
            bRet = LoadItem(this._service, this._itemId, out oItem);
            
            // Want more properties?
            oItem.Load(new PropertySet(BasePropertySet.FirstClassProperties, ItemSchema.MimeContent, ItemSchema.Attachments));
 
 
            if (_Attachment is FileAttachment)
            {
                FileAttachment fileAttachment = _Attachment as FileAttachment;

                // Load the attachment into a file.
                // This call results in a GetAttachment call to EWS.

                // fileAttachment.Load("C:\\temp\\" + fileAttachment.Name);

                // textBox1.Text = "File attachment name: " + fileAttachment.Name;
            }
            else // Attachment is an item attachment.
            {
                ItemAttachment itemAttachment = _Attachment as ItemAttachment;

     
                // itemAttachment.Load();
 
                // textBox1.Text =  "Item attachment name: " + itemAttachment.Name;
            }



            // ******************************************************************************
            // Your code below **************************************************************
            // ******************************************************************************


        }

    }
}
