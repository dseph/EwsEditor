﻿using System;
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

        private string GatherChanges( ItemChange oItemChange)
        {
            StringBuilder oSB = new StringBuilder();

            List<Item> itemList = new List<Item>();
            itemList.Add(oItemChange.Item);
            PropertySet oPropertySet = new PropertySet(BasePropertySet.FirstClassProperties);

            try
            {
                ServiceResponseCollection<ServiceResponse> oServiceResponse = CurrentService.LoadPropertiesForItems(itemList, oPropertySet);
                oSB.AppendFormat("[Change Event]===================================================================\r\n");
                oSB.AppendFormat("ItemId:             {0}\r\n", oItemChange.ItemId.ToString());
                oSB.AppendFormat("ChangeType:         {0}\r\n", oItemChange.ChangeType);
                oSB.AppendFormat("IsRead:             {0}\r\n", oItemChange.IsRead);


                oSB.AppendLine("");
                oSB.AppendFormat("[Some Item Properties loaded by LoadPropertiesForItems]-------------------------\r\n");
                oSB.AppendFormat("UniqueId:           {0}\r\n", itemList[0].Id.UniqueId);
                oSB.AppendFormat("Subject:            {0}\r\n", itemList[0].Subject);
                oSB.AppendFormat("ItemClass:          {0}\r\n", itemList[0].ItemClass);
                oSB.AppendFormat("LastModifiedTime:   {0}\r\n", itemList[0].LastModifiedTime.ToString());
                oSB.AppendFormat("LastModifiedName:   {0}\r\n", itemList[0].LastModifiedName.ToString());
                oSB.AppendFormat("DateTimeReceived:   {0}\r\n", itemList[0].DateTimeReceived.ToString());
                oSB.AppendFormat("DateTimeSent:       {0}\r\n", itemList[0].DateTimeSent.ToString());
                oSB.AppendFormat("DateTimeCreated:    {0}\r\n", itemList[0].DateTimeCreated.ToString());
                oSB.AppendFormat("DisplayTo:          {0}\r\n", itemList[0].DisplayTo);
                oSB.AppendFormat("DisplayCc:          {0}\r\n", itemList[0].DisplayCc);

                oSB.AppendLine("");
                oSB.AppendFormat("[ServiceResponse returned]----------------------------------------------------\r\n");
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
                    oSB.AppendFormat("ErrorProperties:  \r\n" );
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
                }

            }
            catch (System.Xml.Schema.XmlSchemaInferenceException oXmlSchemaInferenceException)
            {
                MessageBox.Show(oXmlSchemaInferenceException.ToString(), "XmlSchemaInferenceException");
                oSB.Append("[Exception of type 'XmlSchemaInferenceException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oXmlSchemaInferenceException.ToString());
            }
            catch (System.Xml.Schema.XmlSchemaValidationException oXmlSchemaValidationException)
            {
                MessageBox.Show(oXmlSchemaValidationException.ToString(), "XmlSchemaValidationException");
                oSB.Append("[Exception of type 'XmlSchemaValidationException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oXmlSchemaValidationException.ToString());
            } 
            catch (System.Xml.Schema.XmlSchemaException oXmlSchemaException)
            {
                MessageBox.Show(oXmlSchemaException.ToString(), "XmlSchemaException");
                oSB.Append("[Exception of type 'XmlSchemaException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oXmlSchemaException.ToString());
            }

            catch (XmlException oXmlException)
            {
                MessageBox.Show(oXmlException.ToString(), "XmlException");
                oSB.Append("[Exception of type 'XmlException' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", oXmlException.ToString());
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
                oSB.Append("[Exception of type 'Exception' was thrown]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                oSB.AppendFormat("Exception: {0}", ex.ToString());
            }

            oSB.Append("");
            string sRet = oSB.ToString();

            return sRet;

        }

        private void lstChanges_DoubleClick(object sender, EventArgs e)
        {
            if (lstChanges.SelectedItems.Count > 0)
            {

                ItemChange oItemChange = (ItemChange)lstChanges.SelectedItems[0].Tag;

                string sContent = GatherChanges(oItemChange);

                ShowTextDocument oForm = new ShowTextDocument();
                oForm.txtEntry.WordWrap = false;
                oForm.Text = "Information";
                oForm.txtEntry.Text = sContent;
                oForm.ShowDialog();
            }
        }

        private void btnTestGetAllChanges_Click(object sender, EventArgs e)
        {
            if (lstChanges.Items.Count > 0)
            {

                StringBuilder oSB = new StringBuilder();

                foreach (ListViewItem oLVI in lstChanges.Items)
                {
                    ItemChange oItemChange = (ItemChange)oLVI.Tag;

                   oSB.Append(GatherChanges(oItemChange));

                }

                string sContent = oSB.ToString();

                ShowTextDocument oForm = new ShowTextDocument();
                oForm.txtEntry.WordWrap = false;
                oForm.Text = "Information";
                oForm.txtEntry.Text = sContent;
                oForm.ShowDialog();
            }
        }

    }
}
