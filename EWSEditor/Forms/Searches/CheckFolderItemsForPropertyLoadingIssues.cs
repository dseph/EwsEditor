using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
 
using Microsoft.Exchange.WebServices.Data;

using EWSEditor.Forms;

namespace EWSEditor.Forms
{
    public partial class CheckFolderItemsForPropertyLoadingIssues : CountedForm
    {
        private PropertySet CurrentPropertySet = new PropertySet();
        private FolderId CurrentFolderId;

        public CheckFolderItemsForPropertyLoadingIssues()
        {
            InitializeComponent();
        }

        public static void Show(ExchangeService service)
        {
            Show(service, null);
        }

        public static void Show(ExchangeService service, FolderId parentFolderId)
        {
            CheckFolderItemsForPropertyLoadingIssues diag = new CheckFolderItemsForPropertyLoadingIssues();

            // Only try to populate CurrentFolderId if we were passed a value
            if (parentFolderId != null)
            {
                diag.SetAndDisplayFolderId(parentFolderId);
            }
            diag.CurrentService = service;

            diag.Show();
        }

        private void CheckFolderItemsForPropertyLoadingIssues_Load(object sender, EventArgs e)
        {
  
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //this.lstErrors.Items.Clear();
            //this.txtErrorInfo.Text = string.Empty;
            //Item oItem = null;

            //foreach (ListViewItem oListViewItem in lstItems.Items)
            //{
            //    //if (oListViewItem.Selected == true)
            //    //{
            //        oItem = (Item)oListViewItem.Tag;
            //        List<Item> oItemList = new List<Item>(); 
            //        oItemList.Add(oItem);
            //        DoPropertyLoadCheck(oItemList);
            //    //}
            //}
 
 
        }

        private void btnPropSet_Click(object sender, EventArgs e)
        {
            PropertySet propSet = this.CurrentPropertySet;
            if (PropertySetDialog.Show(ref propSet) == DialogResult.OK)
            {
                this.CurrentPropertySet = propSet;
            }
        }

        private void btnGetFolderId_Click(object sender, EventArgs e)
        {


            FolderIdDialog oForm = new FolderIdDialog(this.CurrentService);
            oForm.ShowDialog();
            if (oForm.ChoseOK == true)
            {
                SetAndDisplayFolderId(oForm.ChosenFolderId);
            }

            //FolderId folderId = null;
            //if (Forms.FolderIdDialog.ShowDialog(ref folderId) == DialogResult.OK)
            //{
            //    SetAndDisplayFolderId(folderId);
            //}
        }

        /// <summary>
        /// Set the class variable and disaply the proper text for the given
        /// FolderId
        /// </summary>
        /// <param name="folderId"></param>
        private void SetAndDisplayFolderId(FolderId folderId)
        {
            this.txtFolderId.Text = PropertyInformation.TypeValues.FolderIdTypeValue.GetValue(folderId, true);
            this.CurrentFolderId = folderId;

            // Reset form elements
 
            this.lstErrors.Items.Clear();
            this.txtErrorInfo.Text = string.Empty;
        }

        private void btnPopulateItemList_Click(object sender, EventArgs e)
        {
         

        }

        //private string GatherChanges( ItemChange oItemChange)
        //{
        private void DoPropertyLoadCheck(List<Item> oItemList)
        {
            StringBuilder oSB = new StringBuilder();

            bool bErrorFound = false;

            //List<Item> itemList = new List<Item>();
            //itemList.Add(oItemChange.Item);

            string sItem = oItemList[0].Id.UniqueId;
            oSB.AppendFormat("Item: {0}\r\n", sItem);
            oSB.AppendLine("");

            ServiceResponseCollection<ServiceResponse> oServiceResponse = null;
            try
            {
                oServiceResponse = CurrentService.LoadPropertiesForItems(oItemList, CurrentPropertySet);
            }
            catch (ServiceObjectPropertyException oServiceObjectPropertyException)
            {
                bErrorFound = true;
                oSB.AppendFormat("[Error Calling LoadPropertiesForItems]\r\n");
                oSB.Append("[ServiceObjectPropertyException - Exception of type 'ServiceObjectPropertyException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oServiceObjectPropertyException.ToString());

            }
            catch (NullReferenceException oNullReferenceException)
            {
                bErrorFound = true;
                oSB.AppendFormat("[Error Calling LoadPropertiesForItems]\r\n");
                oSB.Append("[NullReferenceException - Exception of type 'NullReferenceException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oNullReferenceException.ToString());

            }
            catch (NoNullAllowedException oNoNullAllowedException)
            {
                bErrorFound = true;
                oSB.AppendFormat("[Error Calling LoadPropertiesForItems]\r\n");
                oSB.Append("[NoNullAllowedException - Exception of type 'NoNullAllowedException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oNoNullAllowedException.ToString());

            }

            catch (System.Xml.Schema.XmlSchemaInferenceException oXmlSchemaInferenceException)
            {
                bErrorFound = true;
                oSB.AppendFormat("[Error Calling LoadPropertiesForItems]\r\n");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'XmlSchemaInferenceException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oXmlSchemaInferenceException.ToString());
            }
            catch (System.Xml.Schema.XmlSchemaValidationException oXmlSchemaValidationException)
            {
                bErrorFound = true;
                oSB.AppendFormat("[Error Calling LoadPropertiesForItems]\r\n");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'XmlSchemaValidationException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oXmlSchemaValidationException.ToString());
            }
            catch (System.Xml.Schema.XmlSchemaException oXmlSchemaException)
            {
                bErrorFound = true;
                oSB.AppendFormat("[Error Calling LoadPropertiesForItems]\r\n");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'XmlSchemaException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oXmlSchemaException.ToString());
            }

            catch (XmlException oXmlException)
            {
                bErrorFound = true;
                oSB.AppendFormat("[Error Calling LoadPropertiesForItems]\r\n");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'XmlException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oXmlException.ToString());
            }
            catch (InvalidEnumArgumentException oInvalidEnumArgumentException)
            {
                bErrorFound = true;
                oSB.AppendFormat("[Error Calling LoadPropertiesForItems]\r\n");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'InvalidEnumArgumentException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oInvalidEnumArgumentException.ToString());
            }
            catch (ArgumentNullException oArgumentNullException)
            {
                bErrorFound = true;
                oSB.AppendFormat("[Error Calling LoadPropertiesForItems]\r\n");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'ArgumentNullException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oArgumentNullException.ToString());
            }
            catch (ArgumentOutOfRangeException oArgumentOutOfRangeException)
            {
                oSB.AppendFormat("[Error Calling LoadPropertiesForItems]\r\n");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'ArgumentOutOfRangeException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oArgumentOutOfRangeException.ToString());
            }
            catch (ArgumentException oArgumentException)
            {
                bErrorFound = true;
                oSB.AppendFormat("[Error Calling LoadPropertiesForItems]\r\n");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'ArgumentException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oArgumentException.ToString());
            }
            catch (Exception ex)
            {
                bErrorFound = true;
                oSB.AppendFormat("[Error Calling LoadPropertiesForItems]\r\n");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'Exception' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", ex.ToString());
            }
 
            if (oServiceResponse != null)
            {
 
                foreach (ServiceResponse o in oServiceResponse)
                {
                    oSB.AppendFormat("ErrorCode:        {0}\r\n", o.ErrorCode.ToString());
                    oSB.AppendLine("");
                    oSB.AppendFormat("ErrorMessage:     {0}\r\n", o.ErrorMessage);
                    oSB.AppendLine("");

                    if (o.ErrorDetails != null)
                    {
                        if (o.ErrorDetails.Count != 0)
                        {
                            bErrorFound = true;
                            oSB.AppendFormat("ErrorDetails:  \r\n");
                            foreach (KeyValuePair<string, string> oProp in o.ErrorDetails)
                            {
                                oSB.AppendFormat("  Key:     {0}\r\n", oProp.Key);
                                oSB.AppendFormat("  Value:   {0}\r\n", oProp.Value);
                                oSB.AppendLine("");
                            }
                        }
                    }

                    if (o.ErrorProperties != null)
                    {
                        if (o.ErrorProperties.Count != 0)
                        {
                            oSB.AppendFormat("ErrorProperties:  \r\n");
                            bErrorFound = true;
                            foreach (PropertyDefinitionBase oProps in o.ErrorProperties)
                            {
                                //oSB.AppendFormat("  ErrorProperties:  {0}\r\n");
                                oSB.AppendFormat("  ToString(): {0}\r\n", oProps.ToString());
                                oSB.AppendFormat("  Type:       {0}\r\n", oProps.Type);
                                oSB.AppendFormat("  Version:    {0}\r\n", oProps.Version);

                                //System.Collections.ObjectModel.Collection<PropertyDefinitionBase>
                            }
                        }
                    }
                    oSB.AppendLine("");
                    oSB.AppendFormat("Result:           {0}\r\n", o.Result.ToString());
                    oSB.AppendLine("");
                }
            }


            //AddItemProps(oItemList[0], ref oSB);  // try to get more identity info added.
 
            int iItemTotal = oItemList.Count;

            if (bErrorFound == true)
            {
                ListViewItem oLVI = lstErrors.Items.Add(sItem);
                oLVI.Tag = oSB.ToString();
            }
      
             
 
             
        }

        private void AddItemProps(Item oItem, ref StringBuilder oSB)
        {
            try
            {
                oSB.AppendLine("");
                oSB.AppendLine("");
                oSB.AppendFormat("Additional identifying information:  {0}\r\n");
                if (oItem.Subject != null)
                    oSB.AppendFormat("    Subject:            {0}\r\n", oItem.Subject);
                if (oItem.ItemClass != null)
                    oSB.AppendFormat("    ItemClass:          {0}\r\n", oItem.ItemClass);
                if (oItem.LastModifiedTime != null)
                    oSB.AppendFormat("    LastModifiedTime:   {0}\r\n", oItem.LastModifiedTime.ToString());
                if (oItem.LastModifiedName != null)
                    oSB.AppendFormat("    LastModifiedName:   {0}\r\n", oItem.LastModifiedName.ToString());
                if (oItem.DateTimeReceived != null)
                    oSB.AppendFormat("    DateTimeReceived:   {0}\r\n", oItem.DateTimeReceived.ToString());
                if (oItem.DateTimeSent != null)
                    oSB.AppendFormat("    DateTimeSent:       {0}\r\n", oItem.DateTimeSent.ToString());
                if (oItem.DateTimeCreated != null)
                    oSB.AppendFormat("    DateTimeCreated:    {0}\r\n", oItem.DateTimeCreated.ToString());
                if (oItem.DisplayTo != null)
                    oSB.AppendFormat("    DisplayTo:          {0}\r\n", oItem.DisplayTo);
                if (oItem.DisplayCc != null)
                    oSB.AppendFormat("    DisplayCc:          {0}\r\n", oItem.DisplayCc);
                oSB.AppendFormat("    Size:               {0}\r\n", oItem.Size.ToString());
            }
            catch (Exception oEx)  // Catch in case onlyIds was specified
            {
                System.Diagnostics.Debug.WriteLine(oEx.ToString());
            }
        }

        private void lstErrors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstErrors.SelectedItems.Count > 0)
            {
                string sInfo = lstErrors.SelectedItems[0].Tag.ToString();
                txtErrorInfo.Text = sInfo;
            }
        }

        private void lstErrors_DoubleClick(object sender, EventArgs e)
        {
            if (lstErrors.SelectedItems.Count > 0)
            {

                string sItem = lstErrors.SelectedItems[0].Text;
                ItemId itemId = new ItemId(sItem);
 
                List<ItemId> item = new List<ItemId>();
                item.Add(itemId);

                ItemsContentForm.Show(
                    "Displaying item by ItemId",
                    item,
                    this.CurrentService,
                    this);
 
            }
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            int offset = 0;
            const int pageSize = 100;
            bool MoreItems = true;

            this.lstErrors.Items.Clear();
            this.txtErrorInfo.Text = string.Empty;

            int iCount = 0;

            while (MoreItems)
            {
                ItemView oView = new ItemView(pageSize, offset, OffsetBasePoint.Beginning);
                CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                FindItemsResults<Item> oFound = CurrentService.FindItems(CurrentFolderId, oView);

                foreach (Item oItem in oFound.Items)
                {
                    iCount++;
                    lblStatus.Text = iCount.ToString();
                    lblStatus.Update();
                    List<Item> oItemList = new List<Item>();
                    oItemList.Add(oItem);
                    DoPropertyLoadCheck(oItemList);

                }

                if (!oFound.MoreAvailable)
                    MoreItems = false;

                if (MoreItems)
                    offset += pageSize;


            }
        }
    }
}
