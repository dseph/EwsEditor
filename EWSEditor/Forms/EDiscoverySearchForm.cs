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
using EWSEditor.Common.Extensions;
using EWSEditor.Resources;
using Microsoft.Exchange.WebServices.Data;
using System.Net;
using System.Xml;

namespace EWSEditor.Forms
{
    public partial class EDiscoverySearchForm : Form
    {
 
        private ExchangeService _CurrentService = null;

        public EDiscoverySearchForm()
        {
            InitializeComponent();

        }

        public EDiscoverySearchForm(ExchangeService oExchangeService)
        {
            _CurrentService = oExchangeService;
 
            InitializeComponent();
        }

        private void btnListSearchableMailboxes_Click(object sender, EventArgs e)
        {
            ListOfSearchableMailboxes(_CurrentService, this.txtSearchForMailboxes.Text, chkExpandGroupMemberships.Checked, ref this.lvMailboxes);
             
        }

        private void btnMailboxSearch_Click(object sender, EventArgs e)
        {
            string[] sMailboxIds = new string[this.lvMailboxes.Items.Count];
            int iCount = 0;
            foreach (ListViewItem oItem in this.lvMailboxes.Items)
            {
                sMailboxIds[iCount] = (string)oItem.Tag;
                iCount++;
            }

            MailboxSearchLocation oMailboxSearchLocation = MailboxSearchLocation.PrimaryOnly;
            switch (this.cmboSearchLocation.Text.Trim())
            {
                case "PrimaryOnly":
                    oMailboxSearchLocation = MailboxSearchLocation.PrimaryOnly;
                    break;
                case "ArchiveOnly":
                    oMailboxSearchLocation = MailboxSearchLocation.ArchiveOnly;
                    break;
                case "All":
                    oMailboxSearchLocation = MailboxSearchLocation.All;
                    break;
            }
 
            SearchResultType oSearchResultType = SearchResultType.PreviewOnly;
            switch (this.cmboSearchLocation.Text.Trim())
            {
                case "PreviewOnly":
                    oSearchResultType = SearchResultType.PreviewOnly;
                    break;
                case "StatisticsOnly":
                    oSearchResultType = SearchResultType.StatisticsOnly;
                    break;
            }

            DoMailboxSearchPreviewItems(_CurrentService, sMailboxIds, txtMailboxSearchString.Text.Trim(), oMailboxSearchLocation, oSearchResultType, (int)this.numPageSize.Value, ref this.lvItems);
        }

        private void ListOfSearchableMailboxes(ExchangeService oExchangeService, string sSearchMailboxString, bool bExpandGroupMemberships, ref ListView oListView)
        {
            this.Cursor = Cursors.WaitCursor;

            ListViewItem oListItem = null;
            oListView.Clear();
            oListView.View = View.Details;
            oListView.GridLines = true;
            oListView.Columns.Add("ReferenceId", 300, HorizontalAlignment.Left);
            oListView.Columns.Add("SmtpAddress", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("DisplayName", 200, HorizontalAlignment.Left);
            oListView.Columns.Add("IsExternalMailbox", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("ExternalEmailAddress", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("IsMembershipGroup", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("Guid", 500, HorizontalAlignment.Left);
 


            GetSearchableMailboxesResponse oGetSearchableMailboxResponse = oExchangeService.GetSearchableMailboxes(sSearchMailboxString, bExpandGroupMemberships);
            //MailboxSearchScope[] oMailboxSearchScope = new MailboxSearchScope[GetSearchableMailboxesResponse.];
            if (oGetSearchableMailboxResponse.Result == ServiceResult.Success)
            {
                foreach (SearchableMailbox oSearchableMailbox in oGetSearchableMailboxResponse.SearchableMailboxes)
                {

                    oListItem = new ListViewItem(oSearchableMailbox.ReferenceId, 0);
                 
                    oListItem.SubItems.Add(oSearchableMailbox.SmtpAddress);                  
                    oListItem.SubItems.Add(oSearchableMailbox.DisplayName);
                    oListItem.SubItems.Add(oSearchableMailbox.IsExternalMailbox.ToString());
                    oListItem.SubItems.Add(oSearchableMailbox.ExternalEmailAddress);
                    oListItem.SubItems.Add(oSearchableMailbox.IsMembershipGroup.ToString());
                    oListItem.SubItems.Add(oSearchableMailbox.Guid.ToString());


                    oListItem.Tag =  oSearchableMailbox.ReferenceId;
                    oListView.Items.AddRange(new ListViewItem[] { oListItem }); ;
                    oListItem = null;
                }
            }
            this.Cursor = Cursors.Default;

        }

        private void DoMailboxSearchPreviewItems(ExchangeService oExchangeService, string[] sMailboxIds, string sSearchText, MailboxSearchLocation oMailboxSearchLocation, SearchResultType oSearchResultType, int iPageSize, ref ListView oListView)
        {
            this.Cursor = Cursors.WaitCursor;

            //// Note: Specific RBAC Audit permissions needs to be set to use eDiscovery
            //// http://gsexdev.blogspot.com/2014/01/paging-ediscovery-results-with-ews.html 
            //// http://technet.microsoft.com/en-us/library/dd298021(v=exchg.150).aspx#roles

         
            ServiceResponseCollection<SearchMailboxesResponse> oServiceResponseCollection = null;

            int iMbCount = 0;
            MailboxSearchScope[] oMailboxSearchScope = new MailboxSearchScope[sMailboxIds.Length];
            foreach (string sMailboxId in sMailboxIds)
            {
                oMailboxSearchScope[iMbCount] = new MailboxSearchScope(sMailboxId, oMailboxSearchLocation);
                iMbCount++;
            }
            MailboxQuery oMailboxQuery = new MailboxQuery(sSearchText, oMailboxSearchScope);
            MailboxQuery[] arrMailboxQuery = { oMailboxQuery };
 

            SearchMailboxesParameters oSearchMailboxesParameters = new SearchMailboxesParameters();
            oSearchMailboxesParameters.SearchQueries = arrMailboxQuery;
            oSearchMailboxesParameters.PageSize = iPageSize;
            oSearchMailboxesParameters.PageDirection = SearchPageDirection.Next;
            oSearchMailboxesParameters.PerformDeduplication = false;
            oSearchMailboxesParameters.ResultType = oSearchResultType;

            ////*********************************************************************//
            //PreviewItemResponseShape PIR = new PreviewItemResponseShape();

            //ExtendedPropertyDefinition epd1 = new
            //    ExtendedPropertyDefinition(0x001A, MapiPropertyType.String); // PR_MESSAGE_CLASS
            //ExtendedPropertyDefinition epd2 = new
            //    ExtendedPropertyDefinition(0x0037, MapiPropertyType.String);  // PR_SUBJECT
            //ExtendedPropertyDefinition[] epa = new ExtendedPropertyDefinition[] { epd1, epd2 };
            //PIR.BaseShape = PreviewItemBaseShape.Default;
            //PIR.AdditionalProperties = epa;
            //oSearchMailboxesParameters.PreviewItemResponseShape = PIR;
            ////*********************************************************************//

             
            ListViewItem oListItem = null;
            oListView.Clear();
            oListView.View = View.Details;
            oListView.GridLines = true;
            oListView.Columns.Add("Count", 60, HorizontalAlignment.Left);
            oListView.Columns.Add("MailboxId", 500, HorizontalAlignment.Left);
            oListView.Columns.Add("PrimarySmtpAddress", 250, HorizontalAlignment.Left);
            oListView.Columns.Add("Id", 200, HorizontalAlignment.Left);
            oListView.Columns.Add("ParentId", 200, HorizontalAlignment.Left);
            oListView.Columns.Add("Subject", 500, HorizontalAlignment.Left);
            oListView.Columns.Add("ItemClass", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("CreatedTime", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("SentTime", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("ToRecipients", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("CcRecipients", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("BccRecipients", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("HasAttachment", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("Importance", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("OwaLink", 500, HorizontalAlignment.Left);

            oServiceResponseCollection = _CurrentService.SearchMailboxes(oSearchMailboxesParameters);
            //oSearchMailboxesParameters.PreviewItemResponseShape = new PreviewItemResponseShape( baseshape, extended properties)
  
            //int iMailboxCount = 0;
            int iResponseCount = 0;
            if (oServiceResponseCollection.OverallResult == ServiceResult.Success)
            {
                if ((oServiceResponseCollection.Count > 0) && (oServiceResponseCollection[0].SearchResult.PreviewItems != null))
                {
     
                    do
                    {
                        //iMailboxCount++;
                        //iResponseCount = 0;


                        oSearchMailboxesParameters.PageItemReference = oServiceResponseCollection[0].SearchResult.PreviewItems[oServiceResponseCollection[0].SearchResult.PreviewItems.Length - 1].SortValue;


                        foreach (SearchPreviewItem oSearchPreviewItem in oServiceResponseCollection[0].SearchResult.PreviewItems)
                        {
                            iResponseCount++;

                            oListItem = new ListViewItem(iResponseCount.ToString());
                            //oListItem = new ListViewItem(iMailboxCount.ToString() + " : " + iResponseCount.ToString(), 0);

                            oListItem.SubItems.Add(oSearchPreviewItem.Mailbox.MailboxId);
                            oListItem.SubItems.Add(oSearchPreviewItem.Mailbox.PrimarySmtpAddress);
                            oListItem.SubItems.Add(oSearchPreviewItem.Id.UniqueId);

                            if (oSearchPreviewItem.ParentId != null)
                                oListItem.SubItems.Add(oSearchPreviewItem.ParentId.UniqueId);
                            else
                                oListItem.SubItems.Add("");

                            oListItem.SubItems.Add(oSearchPreviewItem.Subject);
                            oListItem.SubItems.Add(oSearchPreviewItem.ItemClass);

                            if (oSearchPreviewItem.CreatedTime != null)
                                oListItem.SubItems.Add(oSearchPreviewItem.CreatedTime.ToString());
                            else
                                oListItem.SubItems.Add("");

                            if (oSearchPreviewItem.SentTime != null)
                                oListItem.SubItems.Add(oSearchPreviewItem.SentTime.ToString());
                            else
                                oListItem.SubItems.Add("");

                            if (oSearchPreviewItem.Sender != null)
                                oListItem.SubItems.Add(oSearchPreviewItem.Sender);
                            else
                                oListItem.SubItems.Add("");

                            if (oSearchPreviewItem.ToRecipients != null)
                                oListItem.SubItems.Add(ExpandAddrerssArray(oSearchPreviewItem.ToRecipients));
                            else
                                oListItem.SubItems.Add("");

                            if (oSearchPreviewItem.CcRecipients != null)
                                oListItem.SubItems.Add(ExpandAddrerssArray(oSearchPreviewItem.CcRecipients));
                            else
                                oListItem.SubItems.Add("");

                            if (oSearchPreviewItem.BccRecipients != null)
                                oListItem.SubItems.Add(ExpandAddrerssArray(oSearchPreviewItem.BccRecipients));
                            else
                                oListItem.SubItems.Add("");

                            oListItem.SubItems.Add(oSearchPreviewItem.HasAttachment.ToString());
                            oListItem.SubItems.Add(oSearchPreviewItem.Importance.ToString());
                            oListItem.SubItems.Add(oSearchPreviewItem.OwaLink);

                             
                            //if (oSearchPreviewItem.ExtendedProperties != null)
                            //{
                            //    foreach (ExtendedProperty oProp in oSearchPreviewItem.ExtendedProperties)
                            //    {
                            //        System.Diagnostics.Debug.WriteLine("Name:" + oProp.PropertyDefinition.Name);
                            //        System.Diagnostics.Debug.WriteLine("Id:" + oProp.PropertyDefinition.Id.ToString());
                            //        System.Diagnostics.Debug.WriteLine("Tag:"  + oProp.PropertyDefinition.Tag.ToString());
                            //        System.Diagnostics.Debug.WriteLine("Value:" + oProp.Value.ToString());
                            //        System.Diagnostics.Debug.WriteLine("------------------------------");
                            //    }
                            //}


                            oListItem.Tag = new ItemTag(oSearchPreviewItem.Id, oSearchPreviewItem.ItemClass);
                            oListView.Items.AddRange(new ListViewItem[] { oListItem }); ;
                            oListItem = null;

                        }
 
                        oServiceResponseCollection = _CurrentService.SearchMailboxes(oSearchMailboxesParameters); 
                         
                    } while (oServiceResponseCollection[0].SearchResult.ItemCount > 0);
                }

            }
            else
            {


            }

            this.Cursor = Cursors.Default;
        }

        private string ExpandAddrerssArray(string[] sAddresses)
        {
            StringBuilder oSB = new StringBuilder();
            if (sAddresses != null)
            {
                foreach (string sString in sAddresses)
                {
                    oSB.Append(sString);
                    oSB.Append("; ");
                }
            }

            return oSB.ToString();
        }

        private void EDiscoverySearchForm_Load(object sender, EventArgs e)
        {
            cmboSearchLocation.Text = "PrimaryOnly";
            txtSearchResultType.Text = "PreviewOnly";
        }

        private void lvMailboxes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
