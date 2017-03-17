using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;
 
using EWSEditor.Forms;
using EWSEditor.Common;

namespace EWSEditor.Common
{
 
    public class ItemHelper
    {
        public static void NewItemByFolderClass(string sFolderClass, ExchangeService oExchangeService, FolderId oFolderId)
        {
            switch (sFolderClass)
            {
                case "IPF.Note":
                    MessageForm oMessageForm = new MessageForm(oExchangeService, WellKnownFolderName.Drafts);
                    oMessageForm.ShowDialog();
                    oMessageForm = null;
                    break;
                case "IPF.Contact":
                    ContactsForm oContactsFormForm = new ContactsForm(oExchangeService, oFolderId);
                    oContactsFormForm.ShowDialog();
                    oContactsFormForm = null;
                    break;
                case "IPF.Appointment":
                    CalendarForm oCalendarFormForm = new CalendarForm(oExchangeService, oFolderId);
                    oCalendarFormForm.ShowDialog();
                    oCalendarFormForm = null;
                    break;
                case "IPF.Task":
                    TaskForm oTaskFormForm = new TaskForm(oExchangeService, oFolderId);
                    oTaskFormForm.ShowDialog();
                    oTaskFormForm = null;
                    break;
            }
        }

        public static void DisplaySelectedItemMIMEasHexDump(ExchangeService oExchangeService, ListView oListView)
        {
            if (oListView.SelectedItems.Count > 0)
            {
                string sInfo = string.Empty;
                ItemTag oItemTag = (ItemTag)oListView.SelectedItems[0].Tag;

                GetItemMime(oExchangeService, oItemTag.Id, ref sInfo);

                ShowTextDocument oForm = new ShowTextDocument();
                oForm.Text = "Item MIME Hex Dump";
                oForm.txtEntry.Text = StringHelper.DumpString(sInfo);
                oForm.ShowDialog();
                oForm = null;
            }
        }

        public static void DisplaySelectedItemMIMEasText(ExchangeService oExchangeService, ListView oListView)
        {
            if (oListView.SelectedItems.Count > 0)
            {
                string sInfo = string.Empty;
               ItemTag oItemTag = (ItemTag)oListView.SelectedItems[0].Tag;

               GetItemMime(oExchangeService, oItemTag.Id, ref sInfo);

                ShowTextDocument oForm = new ShowTextDocument();
                oForm.Text = "Item MIME";
                oForm.txtEntry.Text = sInfo;
                oForm.ShowDialog();
                oForm = null;
            }
        }

        public static void DisplaySelectedItemProperties(ExchangeService oExchangeService, ListView oListView)
        {
            if (oListView.SelectedItems.Count > 0)
            {
                string sInfo = string.Empty;
                ItemTag oItemTag = (ItemTag)oListView.SelectedItems[0].Tag;


                GetItemInfo(oExchangeService, oItemTag.Id, oItemTag.ItemClass, ref sInfo);

                ShowTextDocument oForm = new ShowTextDocument();
                oForm.Text = "Item Properties";
                oForm.txtEntry.Text = sInfo;
                oForm.ShowDialog();
                oForm = null;

                // _EwsCaller.ExchService.
            }
        }

        public static void DisplaySelectedItemAttachments(ExchangeService oExchangeService, ref ListView oListView)
        {
            if (oListView.SelectedItems.Count > 0)
            {
                string sInfo = string.Empty;
                ItemTag oItemTag = (ItemTag)oListView.SelectedItems[0].Tag;


                //sInfo = _EwsCaller.GetItemInfo(oItemTag.Id);
                
                AttachmentsByTypeForm oForm = new AttachmentsByTypeForm(oExchangeService, oItemTag.Id);

                oForm.ShowDialog();
                oForm = null;

            }
        }

        public static void GetMessageBody(Item oItem, BodyType oBodyType, ref string sMessageBody)
        {
            string sRet = string.Empty;

            oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
            PropertySet oPropSet = new PropertySet(PropertySet.FirstClassProperties);
            oItem.Load(PropertySet.FirstClassProperties);

            PropertySet oPropSetForBodyText = new PropertySet(PropertySet.FirstClassProperties);
            oPropSetForBodyText.RequestedBodyType = oBodyType;
            oPropSetForBodyText.Add(ItemSchema.Body);
            oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
            Item oItemForBodyText = Item.Bind((ExchangeService)oItem.Service, oItem.Id, (PropertySet)oPropSetForBodyText);
            oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
            oItem.Load(oPropSetForBodyText);
            sRet = oItem.Body.Text;

            sMessageBody = sRet;
        }

        public static void GetMessageBodyAsHtml(Item oItem, ref string MessageBodyHtml)
        {
            string sRet = string.Empty;

            PropertySet oPropSet = new PropertySet(PropertySet.FirstClassProperties);
            oItem.Load(PropertySet.FirstClassProperties);

            PropertySet oPropSetForBodyText = new PropertySet(PropertySet.FirstClassProperties);
            oPropSetForBodyText.RequestedBodyType = BodyType.HTML;
            oPropSetForBodyText.Add(ItemSchema.Body);
            oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
            Item oItemForBodyText = Item.Bind((ExchangeService)oItem.Service, oItem.Id, (PropertySet)oPropSetForBodyText);
            oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
            oItem.Load(oPropSetForBodyText);
            sRet = oItem.Body.Text;
            MessageBodyHtml = sRet;
        }

        public static void GetItemMime(ExchangeService oExchangeService, ItemId oItemId, ref string ItemMime)
        {
            string sReturn = string.Empty;

            try
            {

                PropertySet oMimePropertySet = new PropertySet(ItemSchema.MimeContent);
                oExchangeService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
                Item oItem = Item.Bind(oExchangeService, oItemId, oMimePropertySet);
                sReturn = oItem.MimeContent.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error obtaining MIME of item.");
            }
            ItemMime = sReturn;

        }

        public static void GetItemMime(Item oItem, ref string ItemMime)
        {
            string sReturn = string.Empty;

            try
            {
                PropertySet oMimePropertySet = new PropertySet(ItemSchema.MimeContent);
                oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
                oItem.Load(oMimePropertySet);
                sReturn = oItem.MimeContent.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error obtaining MIME of item.");
            }
            ItemMime = sReturn;


        }


        public static void CreateItemUsingMime(ExchangeService oExchangeService, WellKnownFolderName oWellKnownFolderName, string sMIME, ref ItemId oItemId)
        {

            EmailMessage oMessage = new EmailMessage(oExchangeService);

            byte[] byteMIME = Encoding.ASCII.GetBytes(sMIME);
            oMessage.MimeContent = new MimeContent();

            oMessage.MimeContent.Content = byteMIME;

            oMessage.Save(oWellKnownFolderName);
            oItemId = oMessage.Id;
        }

        public static void CreateItemUsingMime(ExchangeService oExchangeService, FolderId oFolderId, string sMIME, ref ItemId oItemId)
        {

            EmailMessage oMessage = new EmailMessage(oExchangeService);

            byte[] byteMIME = Encoding.ASCII.GetBytes(sMIME);
            oMessage.MimeContent = new MimeContent();

            oMessage.MimeContent.Content = byteMIME;

            oMessage.Save(oFolderId);
            oItemId = oMessage.Id;
        }

        public static void GetItemInfo(ExchangeService oExchangeService, ItemId oItemId, string sItemClass, ref string sInfo)
        {
            string sReturn = string.Empty;

            if (sItemClass == "IPM.Note")
            {
                oExchangeService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
                EmailMessage oEmailMessage = EmailMessage.Bind(oExchangeService, oItemId);

                GetItemInfo(oEmailMessage, ref sReturn);
            }
            else
            {
                oExchangeService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID 
                Item.Bind(oExchangeService, oItemId);
                GetItemInfo(oExchangeService,oItemId, sItemClass,ref sReturn);
            }
            sInfo = sReturn;
        }

        public static void GetItemInfo(Item oItem, ref string sInfo)
        {
            string sRet = string.Empty;
            int iNothing = 0;
            iNothing = iNothing + 0;

            PropertySet oPropSet = new PropertySet(PropertySet.FirstClassProperties);
            oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
            oItem.Load(PropertySet.FirstClassProperties);

            foreach (PropertyDefinitionBase o in oItem.GetLoadedPropertyDefinitions())
            {

                Console.WriteLine(o.ToString(), "  Type.FullName: " + o.Type.FullName + "  Type.GUID: " + o.Type.GUID + "  Type.DeclaringType: " + o.Type.DeclaringType + "\r\n");

            }

            sRet += string.Format("Subject: {0}\r\n", oItem.Subject);
            try
            {
                sRet += string.Format("ConversationId: {0}\r\n", oItem.ConversationId);
            }
            catch (Exception ex) { { if (ex != null)   iNothing = 0; } };

            sRet += "\r\n";
            sRet += string.Format("Id.UniqueId: {0}\r\n", oItem.Id.UniqueId);
            sRet += string.Format("Id.ChangeKey: {0}\r\n", oItem.Id.ChangeKey);

            sRet += "\r\n";
            sRet += string.Format("ItemClass: {0}\r\n", oItem.ItemClass);
            sRet += string.Format("DisplayTo: {0}\r\n", oItem.DisplayTo);
            sRet += string.Format("DisplayCc: {0}\r\n", oItem.DisplayCc);

            sRet += string.Format("DateTimeCreated: {0}\r\n", oItem.DateTimeCreated.ToString());
            sRet += string.Format("HasAttachments: {0}\r\n", oItem.HasAttachments.ToString());
            sRet += string.Format("Size: {0}\r\n", oItem.Size.ToString());


            sRet += string.Format("Sensitivity: {0}\r\n", oItem.Sensitivity.ToString());
            sRet += string.Format("Schema: {0}\r\n", oItem.Schema.ToString());



            sRet += string.Format("\r\n\r\n----[Body]--------------------------------------------------------------\r\n\r\n{0}\r\n", oItem.Body);


            PropertySet oPropSetForBodyText = new PropertySet(PropertySet.FirstClassProperties);
            oPropSetForBodyText.RequestedBodyType = BodyType.Text;
            oPropSetForBodyText.Add(ItemSchema.Body);
            oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
            Item oItemForBodyText = Item.Bind((ExchangeService)oItem.Service, oItem.Id, (PropertySet)oPropSetForBodyText);
            oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
            oItem.Load(oPropSetForBodyText);

            sRet += string.Format("\r\n\r\n----[Body.Text]--------------------------------------------------------------\r\n\r\n{0}\r\n", oItem.Body.Text);

            sInfo = sRet;
        }

        public static void GetItemInfo(EmailMessage oItem, ref string sInfo)
        {
            string sRet = string.Empty;

            PropertySet oPropSet = new PropertySet(PropertySet.FirstClassProperties);
            oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
            oItem.Load(PropertySet.FirstClassProperties);


            foreach (PropertyDefinitionBase o in oItem.GetLoadedPropertyDefinitions())
            {

                Console.WriteLine(o.ToString(), "  Type.FullName: " + o.Type.FullName + "  Type.GUID: " + o.Type.GUID + "  Type.DeclaringType: " + o.Type.DeclaringType + "\r\n");

            }

            sRet += string.Format("Subject: {0}\r\n", oItem.Subject);
            //if (_ExchangeService.ServerInfo.MajorVersion >= 12)
            //sRet += GetPropString("ConversationId.UniqueId: {0}\r\n", oItem.ConversationId.UniqueId);

            //sRet += string.Format("ConversationId.UniqueId: {0}\r\n", oItem.ConversationId);
            sRet += string.Format("ConversationTopic: {0}\r\n", oItem.ConversationTopic);
            sRet += string.Format("ConversationIndex: {0}\r\n", StringHelper.HexStringFromByteArray(oItem.ConversationIndex, true));


            sRet += "\r\n";
            sRet += string.Format("Id.UniqueId: {0}\r\n", oItem.Id.UniqueId);
            sRet += string.Format("Id.ChangeKey: {0}\r\n", oItem.Id.ChangeKey);


            sRet += "\r\n";


            sRet += string.Format("LastModifiedName: {0}\r\n", oItem.LastModifiedName.ToString());
            sRet += string.Format("LastModifiedTime: {0}\r\n", oItem.LastModifiedTime.ToString());
            sRet += string.Format("ItemClass: {0}\r\n", oItem.ItemClass);
            sRet += "\r\n";
            sRet += string.Format("DisplayTo: {0}\r\n", oItem.DisplayTo);
            sRet += string.Format("DisplayCc: {0}\r\n", oItem.DisplayCc);
            sRet += string.Format("DateTimeCreated: {0}\r\n", oItem.DateTimeCreated.ToString());
            if (oItem.IsSubmitted == true) sRet += string.Format("DateTimeSent: {0}\r\n", oItem.DateTimeSent.ToString());
            sRet += string.Format("DateTimeReceived: {0}\r\n", oItem.DateTimeReceived.ToString());
            sRet += string.Format("HasAttachments: {0}\r\n", oItem.HasAttachments.ToString());
            sRet += string.Format("Size: {0}\r\n", oItem.Size.ToString());

            sRet += string.Format("Sensitivity: {0}\r\n", oItem.Sensitivity.ToString());
            sRet += string.Format("Schema: {0}\r\n", oItem.Schema.ToString());

            sRet += "\r\n";
            sRet += string.Format("IsAssociated: {0}\r\n", oItem.IsAssociated.ToString());
            sRet += string.Format("IsDeliveryReceiptRequested: {0}\r\n", oItem.IsDeliveryReceiptRequested.ToString());
            sRet += string.Format("IsDirty: {0}\r\n", oItem.IsDirty.ToString());
            sRet += string.Format("IsDraft: {0}\r\n", oItem.IsDraft.ToString());
            sRet += string.Format("IsFromMe: {0}\r\n", oItem.IsFromMe.ToString());
            sRet += string.Format("IsNew: {0}\r\n", oItem.IsNew.ToString());
            sRet += string.Format("IsRead: {0}\r\n", oItem.IsRead.ToString());
            sRet += string.Format("IsReadReceiptRequested: {0}\r\n", oItem.IsReadReceiptRequested.ToString());

            //sRet += string.Format("IsReminderSet: {0}\r\n", oItem.IsReminderSet.ToString());
            sRet += string.Format("IsResend: {0}\r\n", oItem.IsResend.ToString());
            sRet += string.Format("IsResponseRequested: {0}\r\n", oItem.IsResponseRequested.ToString());
            sRet += string.Format("IsSubmitted: {0}\r\n", oItem.IsSubmitted.ToString());
            sRet += string.Format("IsUnmodified: {0}\r\n", oItem.IsUnmodified.ToString());


            sRet += "\r\n";

            sRet += string.Format("\r\n\r\n----[Body]--------------------------------------------------------------\r\n\r\n{0}\r\n", oItem.Body);


            PropertySet oPropSetForBodyText = new PropertySet(PropertySet.FirstClassProperties);
            oPropSetForBodyText.RequestedBodyType = BodyType.Text;
            oPropSetForBodyText.Add(ItemSchema.Body);
            oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
            Item oItemForBodyText = Item.Bind((ExchangeService)oItem.Service, oItem.Id, (PropertySet)oPropSetForBodyText);
            oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
            oItem.Load(oPropSetForBodyText);

            sRet += string.Format("\r\n\r\n----[Body.Text]--------------------------------------------------------------\r\n\r\n{0}\r\n", oItem.Body.Text);

            sInfo = sRet;
        }
    }
}
