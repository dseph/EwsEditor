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

namespace EWSEditor
{
    public partial class SyncFolderItemsForm : CountedForm
    {
        private PropertySet CurrentPropertySet = new PropertySet();
        private FolderId CurrentFolderId;

        public SyncFolderItemsForm()
        {
            InitializeComponent();
        }

        public static void Show(ExchangeService service)
        {
            Show(service, null);
        }

        public static void Show(ExchangeService service, FolderId parentFolderId)
        {
            SyncFolderItemsForm diag = new SyncFolderItemsForm();

            // Only try to populate CurrentFolderId if we were passed a value
            if (parentFolderId != null)
            {
                diag.SetAndDisplayFolderId(parentFolderId);
            }
            diag.CurrentService = service;

            diag.Show();
        }

        private void btnSynchronize_Click(object sender, EventArgs e)
        {

            
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool keepGoing = true;
                int totalItems = 0;

                this.lstChanges.Items.Clear();

                while (keepGoing)
                {
                    ChangeCollection<ItemChange> changes = this.CurrentService.SyncFolderItems(
                        this.CurrentFolderId,
                        this.CurrentPropertySet,
                        null,
                        500,
                        SyncFolderItemsScope.NormalItems,
                        this.txtSyncState.Text);

                    keepGoing = changes.MoreChangesAvailable;

                    foreach (ItemChange change in changes)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = change;
                        item.Text = change.ChangeType.ToString();
                        item.SubItems.Add(change.IsRead.ToString());
                        item.SubItems.Add(change.ItemId.UniqueId);

                        try
                        {
                            if (item.SubItems != null)
                            {
                                if (change.Item.Subject != null)
                                    item.SubItems.Add(change.Item.Subject);
                                else
                                    item.SubItems.Add("");

                                if (change.Item.ItemClass != null)
                                    item.SubItems.Add(change.Item.ItemClass);
                                else
                                    item.SubItems.Add("");

                                if (change.Item.LastModifiedTime != null)
                                    item.SubItems.Add(change.Item.LastModifiedTime.ToString());
                                else
                                    item.SubItems.Add("");
                            }
                            else
                            {
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                            }
                        }
                        catch (Exception oEx)
                        {
                            System.Diagnostics.Debug.WriteLine(oEx.ToString());  // Catch error in case no no-id propreties were not returned.
                        }
 
                        lstChanges.Items.Add(item);
                    }

                    this.txtSyncState.Text = changes.SyncState;
                    totalItems = totalItems + changes.Count;
                }

                this.lblLastSyncTime.Text = string.Format(Application.CurrentCulture, "Last SyncFolderItems: {0}", DateTime.Now.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Display the GetFolderIdDialog to get a valid FolderId object and
        /// call SetAndDisplayFolderId.
        /// </summary>
        private void btnGetFolderId_Click(object sender, EventArgs e)
        {
            FolderId folderId = null;
            if (Forms.FolderIdDialog.ShowDialog(ref folderId) == DialogResult.OK)
            {
                SetAndDisplayFolderId(folderId);
            }
        }

        /// <summary>
        /// Configure the PropertySet for the SyncFolderItems request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPropSet_Click(object sender, EventArgs e)
        {
            // Display PropertiesDialog
            PropertySet propSet = this.CurrentPropertySet;
            if (PropertySetDialog.Show(ref propSet) == DialogResult.OK)
            {
                this.CurrentPropertySet = propSet;
            }
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
            this.lstChanges.Items.Clear();
            this.lblLastSyncTime.Text = string.Empty;
        }

        private void lstChanges_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private string GatherChanges( ItemChange oItemChange)
        //{
        private string GatherChanges(List<Item> oItemList)
        {
            StringBuilder oSB = new StringBuilder();
             

            //List<Item> itemList = new List<Item>();
            //itemList.Add(oItemChange.Item);
            PropertySet oPropertySet = new PropertySet(BasePropertySet.FirstClassProperties);
            ServiceResponseCollection<ServiceResponse> oServiceResponse = null;
            try
            {
                oSB.AppendLine("");
                oSB.AppendFormat("[Calling LoadPropertiesForItems]-------------------------\r\n");

                oServiceResponse = CurrentService.LoadPropertiesForItems(oItemList, oPropertySet);
            }
            catch (ServiceObjectPropertyException oServiceObjectPropertyException)
            {
                //MessageBox.Show(oXmlSchemaInferenceException.ToString(), "XmlSchemaInferenceException");
                oSB.AppendLine("");
                oSB.Append("[ServiceObjectPropertyException - Exception of type 'ServiceObjectPropertyException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oServiceObjectPropertyException.ToString());

            }
            catch (NullReferenceException oNullReferenceException)
            {
                //MessageBox.Show(oXmlSchemaInferenceException.ToString(), "XmlSchemaInferenceException");
                oSB.AppendLine("");
                oSB.Append("[NullReferenceException - Exception of type 'NullReferenceException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oNullReferenceException.ToString());

            }
            catch (NoNullAllowedException oNoNullAllowedException)
            {
                //MessageBox.Show(oXmlSchemaInferenceException.ToString(), "XmlSchemaInferenceException");
                oSB.AppendLine("");
                oSB.Append("[NoNullAllowedException - Exception of type 'NoNullAllowedException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oNoNullAllowedException.ToString());

            }
 
            catch (System.Xml.Schema.XmlSchemaInferenceException oXmlSchemaInferenceException)
            {
                //MessageBox.Show(oXmlSchemaInferenceException.ToString(), "XmlSchemaInferenceException");
                oSB.AppendLine("");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'XmlSchemaInferenceException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oXmlSchemaInferenceException.ToString());
            }
            catch (System.Xml.Schema.XmlSchemaValidationException oXmlSchemaValidationException)
            {
                //MessageBox.Show(oXmlSchemaValidationException.ToString(), "XmlSchemaValidationException");
                oSB.AppendLine("");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'XmlSchemaValidationException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oXmlSchemaValidationException.ToString());
            }
            catch (System.Xml.Schema.XmlSchemaException oXmlSchemaException)
            {
                //MessageBox.Show(oXmlSchemaException.ToString(), "XmlSchemaException");
                oSB.AppendLine("");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'XmlSchemaException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oXmlSchemaException.ToString());
            }
 
            catch (XmlException oXmlException)
            {
                //MessageBox.Show(oXmlException.ToString(), "XmlException");
                oSB.AppendLine("");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'XmlException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oXmlException.ToString());
            }
            catch (InvalidEnumArgumentException oInvalidEnumArgumentException)
            {
                //MessageBox.Show(oXmlException.ToString(), "XmlException");
                oSB.AppendLine("");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'InvalidEnumArgumentException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oInvalidEnumArgumentException.ToString());
            }
            catch (ArgumentNullException oArgumentNullException)
            {
                //MessageBox.Show(oXmlException.ToString(), "XmlException");
                oSB.AppendLine("");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'ArgumentNullException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oArgumentNullException.ToString());
            }
            catch (ArgumentOutOfRangeException oArgumentOutOfRangeException)
            {
                //MessageBox.Show(oXmlException.ToString(), "XmlException");
                oSB.AppendLine("");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'ArgumentOutOfRangeException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oArgumentOutOfRangeException.ToString());
            }
            catch (ArgumentException oArgumentException)
            {
                //MessageBox.Show(oXmlException.ToString(), "XmlException");
                oSB.AppendLine("");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'ArgumentException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oArgumentException.ToString());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(), "Exception");
                oSB.AppendLine("");
                oSB.Append("[LoadPropertiesForItems - Exception of type 'Exception' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", ex.ToString());
            }

            int iItemTotal = oItemList.Count;
            int iItemCount = 0;

            foreach (Item oItem in oItemList)
            {

                iItemCount += 1;
                //lblStatus.Text = string.Format("Gathering properties for {0} of {1}.", iItemCount, iItemTotal);
                try
                {
 
 
                    oSB.AppendLine("");
                    oSB.AppendFormat("[Item loaded by LoadPropertiesForItems]======================================\r\n");

                    oSB.AppendFormat("UniqueId:           {0}\r\n", oItem.Id.UniqueId);

                    AddItemProps(oItem, ref oSB);

                    oSB.AppendLine("");
                    oSB.AppendFormat("[ServiceResponse]-------------------------------------------------------------\r\n");
                    if (oServiceResponse == null)
                    {
                        oSB.AppendLine("Service response was null.");
                    }
                    else
                    {
                        foreach (ServiceResponse o in oServiceResponse)
                        {
                            oSB.AppendFormat("ErrorCode:        {0}\r\n", o.ErrorCode.ToString());
                            oSB.AppendFormat("ErrorDetails:  \r\n");
                            if (o.ErrorProperties != null)
                            {

                                foreach (KeyValuePair<string, string> oProp in o.ErrorDetails)
                                {
                                    //oSB.AppendFormat("  ErrorDetails:     {0}\r\n");
                                    oSB.AppendFormat("  Key:     {0}\r\n", oProp.Key);
                                    oSB.AppendFormat("  Value:   {0}\r\n", oProp.Value);
                                    oSB.AppendLine("");
                                }
                            }
                            oSB.AppendFormat("ErrorMessage:     {0}\r\n", o.ErrorMessage);
                            oSB.AppendFormat("ErrorProperties:  \r\n");
                            if (o.ErrorProperties != null)
                            {
                                foreach (PropertyDefinitionBase oProps in o.ErrorProperties)
                                {
                                    //oSB.AppendFormat("  ErrorProperties:  {0}\r\n");
                                    oSB.AppendFormat("  ToString(): {0}\r\n", oProps.ToString());
                                    oSB.AppendFormat("  Type:       {0}\r\n", oProps.Type);
                                    oSB.AppendFormat("  Version:    {0}\r\n", oProps.Version);

                                    //System.Collections.ObjectModel.Collection<PropertyDefinitionBase>
                                }
                            }
                            oSB.AppendFormat("Result:           {0}\r\n", o.Result.ToString());
                            oSB.AppendLine("");
                        }
                    }

                }
                catch (System.Xml.Schema.XmlSchemaInferenceException oXmlSchemaInferenceException)
                {
                    //MessageBox.Show(oXmlSchemaInferenceException.ToString(), "XmlSchemaInferenceException");
                    oSB.AppendLine("");
                    oSB.Append("[Exception of type 'XmlSchemaInferenceException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                    oSB.AppendFormat("Exception: {0}", oXmlSchemaInferenceException.ToString());
                }
                catch (System.Xml.Schema.XmlSchemaValidationException oXmlSchemaValidationException)
                {
                    //MessageBox.Show(oXmlSchemaValidationException.ToString(), "XmlSchemaValidationException");
                    oSB.AppendLine("");
                    oSB.Append("[Exception of type 'XmlSchemaValidationException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                    oSB.AppendFormat("Exception: {0}", oXmlSchemaValidationException.ToString());
                } 
                catch (System.Xml.Schema.XmlSchemaException oXmlSchemaException)
                {
                    //MessageBox.Show(oXmlSchemaException.ToString(), "XmlSchemaException");
                    oSB.AppendLine("");
                    oSB.Append("[Exception of type 'XmlSchemaException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                    oSB.AppendFormat("Exception: {0}", oXmlSchemaException.ToString());
                }

                catch (XmlException oXmlException)
                {
                    //MessageBox.Show(oXmlException.ToString(), "XmlException");
                    oSB.AppendLine("");
                    oSB.Append("[Exception of type 'XmlException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                    oSB.AppendFormat("Exception: {0}", oXmlException.ToString());
                   
                }

                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString(), "Exception");
                    oSB.AppendLine("");
                    oSB.Append("[Exception of type 'Exception' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                    oSB.AppendFormat("Exception: {0}", ex.ToString());
                }

                oSB.AppendLine("");
                oSB.Append("");
  

            }
            string sRet = oSB.ToString();

            return sRet;

        }

        private void lstChanges_DoubleClick(object sender, EventArgs e)
        {
            if (lstChanges.SelectedItems.Count > 0)
            {

                ItemChange oItemChange = (ItemChange)lstChanges.SelectedItems[0].Tag;

                List<Item> oItemList = new List<Item>();
                oItemList.Add(oItemChange.Item);

                StringBuilder oSB = new StringBuilder();
                oSB.AppendFormat("\r\n");
                oSB.AppendFormat("********************************************************************************************\r\n");
                oSB.AppendFormat("[Change Event]******************************************************************************\r\n");
                oSB.AppendFormat("ItemId:             {0}\r\n", oItemChange.ItemId.ToString());
                oSB.AppendFormat("ChangeType:         {0}\r\n", oItemChange.ChangeType);
                oSB.AppendFormat("IsRead:             {0}\r\n", oItemChange.IsRead);

                 
                if (oItemChange.Item != null)
                {
                    Item oItem = oItemChange.Item;
                    oSB.AppendLine("");
                    oSB.AppendFormat("[Change Object's Item properties.]-------------------------\r\n");
                    if (oItem.Id == null)
                        oSB.AppendFormat("Problem with Item - its Id is null:           {0}\r\n", oItem.Id.UniqueId);
                    else
                        oSB.AppendFormat("UniqueId:           {0}\r\n", oItem.Id.UniqueId);

                    AddItemProps(oItem, ref oSB);
 
                }
                oSB.Append(GatherChanges(oItemList));
                string sContent = oSB.ToString();

                ShowTextDocument oForm = new ShowTextDocument();
                oForm.txtEntry.WordWrap = false;
                oForm.Text = "Properties for item";
                oForm.txtEntry.Text = sContent;
                oForm.ShowDialog();
            }
        }

        private void AddItemProps(Item oItem , ref StringBuilder oSB)
        {
            try
            {

                if (oItem.Subject != null)
                    oSB.AppendFormat("Subject:            {0}\r\n", oItem.Subject);
                if (oItem.ItemClass != null)
                    oSB.AppendFormat("ItemClass:          {0}\r\n", oItem.ItemClass);
                if (oItem.LastModifiedTime != null)
                    oSB.AppendFormat("LastModifiedTime:   {0}\r\n", oItem.LastModifiedTime.ToString());
                if (oItem.LastModifiedName != null)
                    oSB.AppendFormat("LastModifiedName:   {0}\r\n", oItem.LastModifiedName.ToString());
                if (oItem.DateTimeReceived != null)
                    oSB.AppendFormat("DateTimeReceived:   {0}\r\n", oItem.DateTimeReceived.ToString());
                if (oItem.DateTimeSent != null)
                    oSB.AppendFormat("DateTimeSent:       {0}\r\n", oItem.DateTimeSent.ToString());
                if (oItem.DateTimeCreated != null)
                    oSB.AppendFormat("DateTimeCreated:    {0}\r\n", oItem.DateTimeCreated.ToString());
                if (oItem.DisplayTo != null)
                    oSB.AppendFormat("DisplayTo:          {0}\r\n", oItem.DisplayTo);
                if (oItem.DisplayCc != null)
                    oSB.AppendFormat("DisplayCc:          {0}\r\n", oItem.DisplayCc);
                oSB.AppendFormat("Size:               {0}\r\n", oItem.Size.ToString());
            }
            catch (Exception oEx)  // Catch in case onlyIds was specified
            {
                System.Diagnostics.Debug.WriteLine(oEx.ToString());
            }
        }

        private void LoadPropertiesForAll_SeperateCalls()
        {
            StringBuilder oSB = new StringBuilder();

 
           if (lstChanges.Items.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;


                foreach (ListViewItem oLVI in lstChanges.Items)
                {
                    ItemChange oItemChange = (ItemChange)oLVI.Tag;

                    List<Item> oItemList = new List<Item>();  // next!
                    oItemList.Add(oItemChange.Item);
                    oSB.AppendFormat("");
                    oSB.AppendFormat("******************************************************************************************** *r\n");
                    oSB.AppendFormat("[Change Event]******************************************************************************\r\n");
                    oSB.AppendFormat("ItemId:             {0}\r\n", oItemChange.ItemId.ToString());
                    oSB.AppendFormat("ChangeType:         {0}\r\n", oItemChange.ChangeType);
                    oSB.AppendFormat("IsRead:             {0}\r\n", oItemChange.IsRead);

                    oSB.Append(GatherChanges(oItemList));  // get props for this one changed item

                }

                string sContent = oSB.ToString();  // get results

                ShowTextDocument oForm = new ShowTextDocument();
                oForm.txtEntry.WordWrap = false;
                oForm.Text = "Properties for all items";
                oForm.txtEntry.Text = sContent;
                oForm.ShowDialog();
                this.Cursor = Cursors.Default;
            }
        }

        private void LoadPropertiesForAll_OneCall()
        {
            if (lstChanges.Items.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;
 
                List<Item> oItemList = new List<Item>();

                foreach (ListViewItem oLVI in lstChanges.Items)
                {
                    ItemChange oItemChange = (ItemChange)oLVI.Tag;
                    oItemList.Add(oItemChange.Item);  // build a list of all items
                }

                StringBuilder oSB = new StringBuilder();
                oSB.AppendFormat("\r\n");
                oSB.AppendFormat("=================================================================================\r\n");
                oSB.AppendFormat("[ All Change Events in on call + LoadPropertiesForItems]=========================\r\n");
                oSB.AppendFormat("");
 

                oSB.Append(GatherChanges(oItemList));  // now do once call to get props for all.
                string sContent = oSB.ToString();
 
                ShowTextDocument oForm = new ShowTextDocument();
                oForm.txtEntry.WordWrap = false;
                oForm.Text = "Properties for all items";
                oForm.txtEntry.Text = sContent;
                oForm.ShowDialog();

                this.Cursor = Cursors.Default;
            }
        }

        // btnTestGetAllChanges_Click
        //private void btnShowAllCalendar_Click(object sender, EventArgs e)
        //{
        //    GetAllChanges();
        //}

        private void btnTestGetAllChanges_Click(object sender, EventArgs e)
        {
            LoadPropertiesForAll_OneCall();
        }

        private void lblLastSyncTime_Click(object sender, EventArgs e)
        {

        }

        private void SyncFolderItemsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnPropertiesForAllSeperateCalls_Click(object sender, EventArgs e)
        {
            LoadPropertiesForAll_SeperateCalls();
        }
 
    }
}
