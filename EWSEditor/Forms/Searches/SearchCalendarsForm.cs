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
    public partial class SearchCalendarsForm : Form
    {
        public bool ChoseOK = false;
        private ExchangeService _CurrentService = null;
        private FolderId _CurrentFolderId = null;

        private int _lvItems_SortColumn = -1;
        private int _lvItemsMessages_SortColumn = -1;
        private int _lvCommon_SortColumn = -1;

        private static ExtendedPropertyDefinition Prop_PR_FOLDER_PATH = new ExtendedPropertyDefinition(0x66B5, MapiPropertyType.String);   // Folder Path - PR_Folder_Path
        private static ExtendedPropertyDefinition PidLidAppointmentRecur = new ExtendedPropertyDefinition(new Guid("00062002-0000-0000-C000-000000000046"), 0x8216, MapiPropertyType.Binary); // dispidApptRecur
        private static ExtendedPropertyDefinition PidLidClientIntent = new ExtendedPropertyDefinition(new Guid("11000E07-B51B-40D6-AF21-CAA85EDAB1D0"), 0x0015, MapiPropertyType.Integer); // dispidClientIntent
        private static ExtendedPropertyDefinition ClientInfoString = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x000B, MapiPropertyType.String); //  
        private static ExtendedPropertyDefinition LogTriggerAction = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x0006, MapiPropertyType.String); //  
        private static ExtendedPropertyDefinition PidLidCleanGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0023, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PidLidGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0003, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition ICalId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 3, MapiPropertyType.String);
        private static ExtendedPropertyDefinition Prop_PR_STORE_ENTRYID = new ExtendedPropertyDefinition(0x0FFB, MapiPropertyType.Binary);  // PidTagStoreEntryId
 
        //private static ExtendedPropertyDefinition dispidCalLogClientInfoString = new ExtendedPropertyDefinition(new Guid("xxxxxxxxxxxxxxx"), 0x0015, MapiPropertyType.Integer);  

        // see: https://blogs.msdn.microsoft.com/mstehle/2009/09/02/ews-uid-not-always-the-same-for-orphaned-instances-of-the-same-meeting/
        //private static ExtendedPropertyDefinition PidLidCleanGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0023, MapiPropertyType.Binary);
        //private static ExtendedPropertyDefinition PidLidGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0003, MapiPropertyType.Binary);
        // Microsoft.Exchange.WebServices.Data.DefaultExtendedPropertySet]::CalendarAssistant

        // https://ingogegenwarth.wordpress.com/2015/05/01/troubleshooting-calendar-items/
        //    0x8059001E This extended property records the client, which modified the item. 
        //    0x8054001E This extended property records the last action performed on the item. 
        ////$Client = new-object Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition([Microsoft.Exchange.WebServices.Data.DefaultExtendedPropertySet]::CalendarAssistant,0x000B,[Microsoft.Exchange.WebServices.Data.MapiPropertyType]::String)
        ////$Action = new-object Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition([Microsoft.Exchange.WebServices.Data.DefaultExtendedPropertySet]::CalendarAssistant,0x0006,[Microsoft.Exchange.WebServices.Data.MapiPropertyType]::String)
        ////$PidLidGlobalObjectId = new-object Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition([Microsoft.Exchange.WebServices.Data.DefaultExtendedPropertySet]::Meeting,0x0003,[Microsoft.Exchange.WebServices.Data.MapiPropertyType]::Binary)
        ////$PidLidCleanGlobalObjectId = new-object Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition([Microsoft.Exchange.WebServices.Data.DefaultExtendedPropertySet]::Meeting,0x0023,[Microsoft.Exchange.WebServices.Data.MapiPropertyType]::Binary)
        ////$PidLidAppointmentMessageClass = new-object Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition([Microsoft.Exchange.WebServices.Data.DefaultExtendedPropertySet]::Meeting,0x0024,[Microsoft.Exchange.WebServices.Data.MapiPropertyType]::String)
        ////#$PidLidClientIntent = new-object Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition([Microsoft.Exchange.WebServices.Data.DefaultExtendedPropertySet]::CalendarAssistant,0x0015,[Microsoft.Exchange.WebServices.Data.MapiPropertyType]::Long)
        ////$PidLidClientIntent = new-object Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition([Microsoft.Exchange.WebServices.Data.DefaultExtendedPropertySet]::CalendarAssistant,0x0015,[Microsoft.Exchange.WebServices.Data.MapiPropertyType]::Integer)
        ////$ItemView =  New-Object Microsoft.Exchange.WebServices.Data.ItemView(1000)

        private void x()
        {
            
            //DataSet m_DS;
            //DataSet msgDataSet { get { return m_DS; } }

            //DataTable dt = m_DS.Tables.Add("tblAppointment");
            //dt.Columns.Add("PropName");
            //dt.Columns.Add("PropVal");
            //dt.Columns.Add("SmartVal");

            //foreach property
        }



        //private static ExtendedPropertyDefinition PROP_DEF_PidLidGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x00000003, MapiPropertyType.Binary);

        public SearchCalendarsForm()
        {
            InitializeComponent();
        }

        public SearchCalendarsForm(ExchangeService oExchangeService, FolderId oCurrentFolderId)
        {
            _CurrentService = oExchangeService;
            _CurrentFolderId = oCurrentFolderId;

            InitializeComponent();

        }


        private void SearchForm_Load(object sender, EventArgs e)
        {
            //http://technet.microsoft.com/en-us/library/cc535025%28EXCHG.80%29.aspx

            //http://msdn.microsoft.com/en-us/library/exchange/dd633674(v=exchg.80).aspx

            // http://msdn.microsoft.com/en-us/library/exchange/dd633693(v=exchg.80).aspx 

            cmboSearchType.Text = "Direct";

            cmboSearchDepth.Text = "Shallow";

            //cmboLogicalOperation.Text = "And";

            cmboUidConditional.Text = "ContainsSubstring";
            cmboSubjectConditional.Text = "ContainsSubstring";
            cmboToConditional.Text = "ContainsSubstring";
            cmboCCConditional.Text = "ContainsSubstring";
            cmboBodyConditional.Text = "ContainsSubstring";
            cmboClassConditional.Text = "ContainsSubstring";


            SetCheckboxes();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ChoseOK = false;
            this.Close();
        }

        private void SetCheckboxes()
        {
            if (this.rdoAqsSearch.Checked == true)
            {
                this.txtUID.Enabled = false;
                this.txtSubject.Enabled = false;
                this.txtTo.Enabled = false;
                this.txtCC.Enabled = false;
                this.txtBody.Enabled = false;
                this.cmboClass.Enabled = false;

                this.chkUID.Enabled = false;
                this.chkSubject.Enabled = false;
                this.chkTo.Enabled = false;
                this.chkCC.Enabled = false;
                this.chkBody.Enabled = false;
                this.chkClass.Enabled = false;

                cmboUidConditional.Enabled = false;
                cmboSubjectConditional.Enabled = false;
                cmboToConditional.Enabled = false;
                cmboCCConditional.Enabled = false;
                cmboBodyConditional.Enabled = false;
                cmboClassConditional.Enabled = false;


            }
            if (this.rdoFindItemSearch.Checked == true)
            {
                this.chkUID.Enabled = true;
                this.chkSubject.Enabled = true;
                this.chkTo.Enabled = true;
                this.chkCC.Enabled = true;
                this.chkBody.Enabled = true;
                this.chkClass.Enabled = true;

                this.txtUID.Enabled = true;
                this.txtSubject.Enabled = true;
                this.txtTo.Enabled = true;
                this.txtCC.Enabled = true;
                this.txtBody.Enabled = true;
                this.cmboClass.Enabled = true;

                cmboUidConditional.Enabled = chkSubject.Checked;
                cmboSubjectConditional.Enabled = chkSubject.Checked;
                cmboToConditional.Enabled = chkTo.Checked;
                cmboCCConditional.Enabled = chkCC.Checked;
                cmboBodyConditional.Enabled = chkBody.Checked;
                cmboClassConditional.Enabled = chkClass.Checked;

            }

            this.txtAQS.Enabled = rdoAqsSearch.Checked;
            this.txtUID.Enabled = chkUID.Checked;
            this.txtSubject.Enabled = chkSubject.Checked;
            this.txtTo.Enabled = chkTo.Checked;
            this.txtCC.Enabled = chkCC.Checked;
            this.txtBody.Enabled = chkBody.Checked;
            this.cmboClass.Enabled = chkClass.Checked;
 
        }

        private bool CheckFields()
        {
            bool bRet = true;

            if (this.chkUID.Checked == true)
                if (this.txtUID.Text.Trim().Length == 0)
                {
                    MessageBox.Show("UID line text cannot be blank");
                }


            if (this.chkSubject.Checked == true)
                if (this.txtSubject.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Subject line text cannot be blank");
                }

            if (this.chkTo.Checked == true)
                if (this.txtTo.Text.Trim().Length == 0)
                {
                    MessageBox.Show("To line text cannot be blank");
                }

            if (this.chkCC.Checked == true)
                if (this.txtCC.Text.Trim().Length == 0)
                {
                    MessageBox.Show("CC line text cannot be blank");
                }

            if (this.chkBody.Checked == true)
                if (this.txtBody.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Body line text cannot be blank");
                }

            if (this.chkClass.Checked == true)
                if (this.cmboClass.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Class line text cannot be blank");
                }

            if (this.rdoAqsSearch.Checked == true)
                if (this.txtAQS.Text.Trim().Length == 0)
                {
                    MessageBox.Show("AQS line text cannot be blank");
                }

            return bRet;

        }

        private void chkAQS_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckboxes();
            txtAQS.Enabled = this.rdoAqsSearch.Checked;
        }

        private void chkSubject_CheckedChanged(object sender, EventArgs e)
        {
            txtSubject.Enabled = chkSubject.Checked;
            cmboSubjectConditional.Enabled = chkSubject.Checked;
        }

        private void chkTo_CheckedChanged(object sender, EventArgs e)
        {
            txtTo.Enabled = chkTo.Checked;
            cmboToConditional.Enabled = chkTo.Checked;
        }

        private void chkCC_CheckedChanged(object sender, EventArgs e)
        {
            txtCC.Enabled = chkCC.Checked;
            cmboCCConditional.Enabled = chkCC.Checked;
        }

        private void ConfigureListView_Calendar(ref ListView oListView, string SearchType)
        {

            oListView.Clear();
            oListView.View = View.Details;
            oListView.GridLines = true;
            //oListView.Dock = DockStyle.Fill;

            if (SearchType == "Direct")
                oListView.Columns.Add("Count", 100, HorizontalAlignment.Left);
            else
                oListView.Columns.Add("Frame:Count", 100, HorizontalAlignment.Left);

            oListView.Columns.Add("Subject", 170, HorizontalAlignment.Left);
            oListView.Columns.Add("Class", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("Organizer", 100, HorizontalAlignment.Left);

            oListView.Columns.Add("DisplayTo", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("DisplayCc", 100, HorizontalAlignment.Left);

            oListView.Columns.Add("RequiredAttendees", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("OptionalAttendees", 100, HorizontalAlignment.Left);

            oListView.Columns.Add("ICalUid", 200, HorizontalAlignment.Left);
            oListView.Columns.Add("CleanGlobalObjectId", 200, HorizontalAlignment.Left);
            oListView.Columns.Add("GlobalObjectId", 200, HorizontalAlignment.Left);

            oListView.Columns.Add("Start", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("End", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("RetentionDate", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("DateTimeCreated", 150, HorizontalAlignment.Left);

            oListView.Columns.Add("LastModifiedName", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("LastModifiedTime", 150, HorizontalAlignment.Left);

            oListView.Columns.Add("AppointmentType", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("AppointmentState", 150, HorizontalAlignment.Left);

            oListView.Columns.Add("IsAllDayEvent", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("IsCancelled", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("IsRecurring", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("IsReminderSet", 100, HorizontalAlignment.Left);

            oListView.Columns.Add("IsOnlineMeeting", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("IsResend", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("IsDraft", 100, HorizontalAlignment.Left);

            oListView.Columns.Add("Size", 70, HorizontalAlignment.Left);
            oListView.Columns.Add("Attatch", 80, HorizontalAlignment.Left);


            oListView.Columns.Add("PidLidAppointmentRecur ", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("PidLidClientIntent ", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("ClientInfoString ", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("LogTriggerAction ", 100, HorizontalAlignment.Left);

            oListView.Columns.Add("IsHidden", 50, HorizontalAlignment.Left);
            oListView.Columns.Add("FolderPath", 200, HorizontalAlignment.Left);

            oListView.Columns.Add("StoreEntryId", 250, HorizontalAlignment.Left);
            oListView.Columns.Add("UniqueId", 250, HorizontalAlignment.Left);
            //oListView.Columns.Add("ChangeKey", 250, HorizontalAlignment.Left);

            oListView.Tag = -1;

        }



        private void ConfigureListView_Common(ref ListView oListView, string SearchType)
        {

           
            oListView.Clear();
            oListView.View = View.Details;
            oListView.GridLines = true;
            //oListView.Dock = DockStyle.Fill;

            if (SearchType == "Direct")
                oListView.Columns.Add("Count", 100, HorizontalAlignment.Left);
            else
                oListView.Columns.Add("Frame:Count", 100, HorizontalAlignment.Left);

            oListView.Columns.Add("Subject", 170, HorizontalAlignment.Left);
            oListView.Columns.Add("Class", 150, HorizontalAlignment.Left);


            oListView.Columns.Add("DisplayTo", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("DisplayCc", 100, HorizontalAlignment.Left);

            oListView.Columns.Add("ICalDateTimeStamp", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("ICalUid", 200, HorizontalAlignment.Left);
            oListView.Columns.Add("CleanGlobalObjectId", 200, HorizontalAlignment.Left);
            oListView.Columns.Add("GlobalObjectId", 200, HorizontalAlignment.Left);

 
 

            oListView.Columns.Add("LastModifiedName", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("LastModifiedTime", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("DateTimeCreated", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("DateTimeReceived", 150, HorizontalAlignment.Left);

            oListView.Columns.Add("Size", 90, HorizontalAlignment.Left);
            oListView.Columns.Add("IsHidden", 90, HorizontalAlignment.Left);

            oListView.Columns.Add("ClientInfoString", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("PidLidClientIntent", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("LogTriggerAction ", 100, HorizontalAlignment.Left);


            //oListView.Columns.Add("PidLidAppointmentRecur ", 100, HorizontalAlignment.Left);
            //oListView.Columns.Add("PidLidClientIntent ", 100, HorizontalAlignment.Left);
            //oListView.Columns.Add("dispidCalLogClientInfoString ", 100, HorizontalAlignment.Left);

             
            oListView.Columns.Add("FolderPath", 250, HorizontalAlignment.Left);
            oListView.Columns.Add("StoreEntryId", 250, HorizontalAlignment.Left);
            oListView.Columns.Add("UniqueId", 250, HorizontalAlignment.Left);

            oListView.Tag = -1;
        }

        
        private void ConfigureListView_Message(ref ListView oListView, string SearchType)
        {

            oListView.Clear();
            oListView.View = View.Details;
            oListView.GridLines = true;
            //oListView.Dock = DockStyle.Fill;

            if (SearchType == "Direct")
                oListView.Columns.Add("Count", 100, HorizontalAlignment.Left);
            else
                oListView.Columns.Add("Frame:Count", 100, HorizontalAlignment.Left);
             
            oListView.Columns.Add("Subject", 170, HorizontalAlignment.Left);
            oListView.Columns.Add("Class", 150, HorizontalAlignment.Left);


            oListView.Columns.Add("DisplayTo", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("DisplayCc", 100, HorizontalAlignment.Left);


            oListView.Columns.Add("RetentionDate", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("DateTimeCreated", 150, HorizontalAlignment.Left);

            oListView.Columns.Add("LastModifiedName", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("LastModifiedTime", 150, HorizontalAlignment.Left);

            oListView.Columns.Add("IsResend", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("IsDraft", 100, HorizontalAlignment.Left);

            oListView.Columns.Add("Size", 70, HorizontalAlignment.Left);
            oListView.Columns.Add("Attatch", 80, HorizontalAlignment.Left);

            oListView.Columns.Add("PidLidAppointmentRecur ", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("PidLidClientIntent ", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("dispidCalLogClientInfoString ", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("LogTriggerAction ", 100, HorizontalAlignment.Left);

            oListView.Columns.Add("ICalUid", 200, HorizontalAlignment.Left);
            oListView.Columns.Add("CleanGlobalObjectId", 200, HorizontalAlignment.Left);
            oListView.Columns.Add("GlobalObjectId", 200, HorizontalAlignment.Left);

            oListView.Columns.Add("FolderPath", 250, HorizontalAlignment.Left);
            oListView.Columns.Add("StoreEntryId", 250, HorizontalAlignment.Left);
            oListView.Columns.Add("UniqueId", 250, HorizontalAlignment.Left);

            oListView.Tag = -1;

             
        }



        private FindItemsResults<Item> DoSearch(FolderId oFolderId, ref ItemView oItemView)
        {
            FindItemsResults<Item> oFindItemsResults = null;
            List<SearchFilter> searchFilterCollection = new List<SearchFilter>();

            if (this.rdoAqsSearch.Checked == true)
            {
                try
                {
                    oFindItemsResults = _CurrentService.FindItems(oFolderId, this.txtAQS.Text, oItemView);
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    throw ex;

                }
            }
            else
            {

                string sSearchCleanGlobalObjectId = GetObjectIdStringFromUid(this.txtUID.Text.Trim());

                if (this.chkUID.Checked == true)
                    AddCondition(ref searchFilterCollection, PidLidCleanGlobalObjectId, sSearchCleanGlobalObjectId, this.cmboUidConditional.Text);
                if (this.chkClass.Checked == true)
                    AddCondition(ref searchFilterCollection, ItemSchema.ItemClass, this.cmboClass.Text.Trim(), cmboClassConditional.Text);
                if (this.chkSubject.Checked == true)
                    AddCondition(ref searchFilterCollection, ItemSchema.Subject, this.txtSubject.Text.Trim(), cmboSubjectConditional.Text);
                if (this.chkTo.Checked == true)
                    AddCondition(ref searchFilterCollection, ItemSchema.DisplayTo, this.txtTo.Text.Trim(), cmboToConditional.Text);
                if (this.chkCC.Checked == true)
                    AddCondition(ref searchFilterCollection, ItemSchema.DisplayCc, this.txtCC.Text.Trim(), cmboCCConditional.Text);
                if (this.chkBody.Checked == true)
                    AddCondition(ref searchFilterCollection, ItemSchema.Body, this.txtBody.Text.Trim(), cmboBodyConditional.Text);


                SearchFilter searchFilter = null;
                if (searchFilterCollection.Count == 0)
                {
                    try
                    {
                        oFindItemsResults = _CurrentService.FindItems(oFolderId, oItemView);
                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        throw ex;

                    }
                }
                else
                {
                    searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, searchFilterCollection.ToArray());
                    //if (cmboLogicalOperation.Text == "And")
                    //    searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, searchFilterCollection.ToArray());
                    //if (cmboLogicalOperation.Text == "Or")
                    //    searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.Or, searchFilterCollection.ToArray());

                    oFindItemsResults = _CurrentService.FindItems(oFolderId, searchFilter, oItemView);
                }

            }

            return oFindItemsResults;
        }

        // http://www.infinitec.de/post/2009/04/13/Searching-a-meeting-with-a-specific-UID-using-Exchange-Web-Services-2007.aspx
        private static string GetObjectIdStringFromUid(string id)
        {
            var buffer = new byte[id.Length/2];
            for (int i = 0; i < id.Length/2; i++)
            {
                var hexValue = byte.Parse(id.Substring(i*2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                buffer[i] = hexValue;
            }
            return Convert.ToBase64String(buffer);
        }

        private bool AddSearchResultsToListViews(FindItemsResults<Item> oFindItemsResults, int iCountMore)
        {
            bool bRet = false;

            lvItemsMessages.Visible = false;
            lvItems.Visible = false;

            ListViewItem oListItem = null;

            int iCountAppointment = 0;
            int iCountCommon = 0;
            int iCountMeetingMessage = 0;

            oListItem = null;

 
            foreach (Item oItem in oFindItemsResults.Items)
            {
                //1 // update window for appointment items
                //2 // create a window fo message meetings
                //3// have both of the item windows be used by the calendar search window
                
                //5// add an export window to be used by the calendar search window.  Export as xml - text view, 
                //  // Export serialized appointment and export serialized calendar message, export appointments.
                //  // export attachments table
              
                //7 // find which properties are common betwen appointments and meeting messages - create a new list view '
                //// on a tab control on the search window - it will need to be sortable by date and by global object id at lease.
                //8 // add more columns to listvies based on Randy's code.
                //9 // demo to randy.

                if (oItem.ItemClass.ToUpper().StartsWith("IPM.APPOINTMENT") )
                {

                    iCountAppointment++;

                    EWSEditor.Common.Exports.AppointmentData oAppointmentData = new EWSEditor.Common.Exports.AppointmentData();
                    EWSEditor.Common.Exports.CalendarExport oCalendarExport = new EWSEditor.Common.Exports.CalendarExport();
                    oAppointmentData = oCalendarExport.GetAppointmentDataFromItem(oItem.Service, oItem.Id);


                    //if (this.cmboSearchType.Text == "Direct")
                    //    oListItem = new ListViewItem(iCountAppointment.ToString(), 0);
                    //else
                    //    oListItem = new ListViewItem(iCountMore.ToString() + ":" + iCountAppointment.ToString(), 0);

                    //oListItem.SubItems.Add(oAppointmentData.Subject);
                    //oListItem.SubItems.Add(oAppointmentData.ItemClass);
                    //oListItem.SubItems.Add(oAppointmentData.OrganizerAddress);

                    //oListItem.SubItems.Add(oAppointmentData.DisplayTo);
                    //oListItem.SubItems.Add(oAppointmentData.DisplayCc);
                    //oListItem.SubItems.Add(oAppointmentData.RequiredAttendees);
                    //oListItem.SubItems.Add(oAppointmentData.OptionalAttendees);
                    //oListItem.SubItems.Add(oAppointmentData.ICalUid);

                    //oListItem.SubItems.Add(oAppointmentData.PidLidCleanGlobalObjectId);
                    //oListItem.SubItems.Add(oAppointmentData.PidLidGlobalObjectId);

                    //oListItem.SubItems.Add(oAppointmentData.Start);
                    //oListItem.SubItems.Add(oAppointmentData.End);

                    //oListItem.SubItems.Add(oAppointmentData.RetentionDate);
                    //oListItem.SubItems.Add(oAppointmentData.DateTimeCreated);

                    //oListItem.SubItems.Add(oAppointmentData.LastModifiedName);
                    //oListItem.SubItems.Add(oAppointmentData.LastModifiedTime);

                    //oListItem.SubItems.Add(oAppointmentData.AppointmentType);
                    //oListItem.SubItems.Add(oAppointmentData.AppointmentState);

                    //oListItem.SubItems.Add(oAppointmentData.IsAllDayEvent);
                    //oListItem.SubItems.Add(oAppointmentData.IsCancelled);
                    //oListItem.SubItems.Add(oAppointmentData.IsRecurring);
                    //oListItem.SubItems.Add(oAppointmentData.IsReminderSet);

                    //oListItem.SubItems.Add(oAppointmentData.IsOnlineMeeting);
                    //oListItem.SubItems.Add(oAppointmentData.IsResend);
                    //oListItem.SubItems.Add(oAppointmentData.IsDraft);

                    //oListItem.SubItems.Add(oAppointmentData.Size);
                    //oListItem.SubItems.Add(oAppointmentData.HasAttachments);

                    //oListItem.SubItems.Add(oAppointmentData.PidLidAppointmentRecur);

                    //oListItem.SubItems.Add(oAppointmentData.PidLidClientIntent);
                    //oListItem.SubItems.Add(oAppointmentData.ClientInfoString);
                    //oListItem.SubItems.Add(oAppointmentData.LogTriggerAction);

                    //oListItem.SubItems.Add(oAppointmentData.IsHidden);

                    //// instancecount
                    //// Exception count

                    //oListItem.SubItems.Add(oAppointmentData.FolderPath);
                    //oListItem.SubItems.Add(oAppointmentData.StoreEntryId);
                    //oListItem.SubItems.Add(oAppointmentData.UniqueId);
 

                    //oListItem.Tag = new ItemTag(oAppointmentData.UniqueId, oAppointmentData.ItemClass);
                    //lvItems.Items.AddRange(new ListViewItem[] { oListItem }); ;
                    //oListItem = null;

                    //  Load common data listview ------------------------------------------------
                    iCountCommon++;

                    if (this.cmboSearchType.Text == "Direct")
                        oListItem = new ListViewItem(iCountCommon.ToString(), 0);
                    else
                        oListItem = new ListViewItem(iCountCommon.ToString() + ":" + iCountCommon.ToString(), 0);

                    oListItem.SubItems.Add(oAppointmentData.Subject);

                    oListItem.SubItems.Add(oAppointmentData.ItemClass);

                    //oListItem.SubItems.Add(oAppointmentData.Organizer);
                    oListItem.SubItems.Add(oAppointmentData.DisplayTo);
                    oListItem.SubItems.Add(oAppointmentData.DisplayCc);

                    oListItem.SubItems.Add(oAppointmentData.ICalDateTimeStamp);
                    oListItem.SubItems.Add(oAppointmentData.ICalUid);
                    oListItem.SubItems.Add(oAppointmentData.PidLidCleanGlobalObjectId);
                    oListItem.SubItems.Add(oAppointmentData.PidLidGlobalObjectId);


                    oListItem.SubItems.Add(oAppointmentData.LastModifiedName);
                    oListItem.SubItems.Add(oAppointmentData.LastModifiedTime);
                    oListItem.SubItems.Add(oAppointmentData.DateTimeCreated);
                    oListItem.SubItems.Add(oAppointmentData.DateTimeReceived);

                    oListItem.SubItems.Add(oAppointmentData.Size);
                    oListItem.SubItems.Add(oAppointmentData.IsHidden);

                    oListItem.SubItems.Add(oAppointmentData.ClientInfoString);
                    oListItem.SubItems.Add(oAppointmentData.PidLidClientIntent);
                    oListItem.SubItems.Add(oAppointmentData.LogTriggerAction);

                    oListItem.SubItems.Add(oAppointmentData.FolderPath);
                    oListItem.SubItems.Add(oAppointmentData.StoreEntryId);
                    oListItem.SubItems.Add(oAppointmentData.UniqueId);
                

                    oListItem.Tag = new ItemTag(oAppointmentData.UniqueId, oAppointmentData.ItemClass);
                    lvCommon.Items.AddRange(new ListViewItem[] { oListItem }); ;
                    oListItem = null;

                    // --- finally...

                    bRet = true;

                }

                if (oItem.ItemClass.ToUpper().StartsWith("IPM.SCHEDULE"))
                {

                    iCountMeetingMessage++;

                    EWSEditor.Common.Exports.MeetingMessageData oMeetingMessageData = new EWSEditor.Common.Exports.MeetingMessageData();
                    EWSEditor.Common.Exports.MeetingMessageExport oMeetingMessageExport = new EWSEditor.Common.Exports.MeetingMessageExport();
                    oMeetingMessageData = oMeetingMessageExport.GetMeetingMessageDataFromItem(oItem.Service, oItem.Id);

                    //if (this.cmboSearchType.Text == "Direct")
                    //    oListItem = new ListViewItem(iCountMeetingMessage.ToString(), 0);
                    //else
                    //    oListItem = new ListViewItem(iCountMore.ToString() + ":" + iCountMeetingMessage.ToString(), 0);

                    //oListItem.SubItems.Add(oMeetingMessageData.Subject);
                    //oListItem.SubItems.Add(oMeetingMessageData.ItemClass);

                    //oListItem.SubItems.Add(oMeetingMessageData.DisplayTo);
                    //oListItem.SubItems.Add(oMeetingMessageData.DisplayCc);
 
                    //oListItem.SubItems.Add(oMeetingMessageData.RetentionDate.ToString());
                    //oListItem.SubItems.Add(oMeetingMessageData.DateTimeCreated.ToString());
                    //oListItem.SubItems.Add(oMeetingMessageData.LastModifiedName);
                    //oListItem.SubItems.Add(oMeetingMessageData.LastModifiedName.ToString());
                    //oListItem.SubItems.Add(oMeetingMessageData.IsResend.ToString());
                    //oListItem.SubItems.Add(oMeetingMessageData.IsDraft.ToString());
                    //oListItem.SubItems.Add(oMeetingMessageData.Size.ToString());
                    //oListItem.SubItems.Add(oMeetingMessageData.HasAttachments.ToString());
            
                    //oListItem.SubItems.Add(oMeetingMessageData.PidLidAppointmentRecur);
                    //oListItem.SubItems.Add(oMeetingMessageData.PidLidClientIntent);
                    //oListItem.SubItems.Add(oMeetingMessageData.ClientInfoString);
                    //oListItem.SubItems.Add(oMeetingMessageData.LogTriggerAction);

                    //oListItem.SubItems.Add(oMeetingMessageData.ICalUid);  // ICalUid
                    //oListItem.SubItems.Add(oMeetingMessageData.PidLidCleanGlobalObjectId);
                    //oListItem.SubItems.Add(oMeetingMessageData.PidLidGlobalObjectId);
   
                    //oListItem.SubItems.Add(oMeetingMessageData.FolderPath); 
                    //oListItem.SubItems.Add(oMeetingMessageData.StoreEntryId);
                    //oListItem.SubItems.Add(oItem.Id.UniqueId);
 

                    //oListItem.Tag = new ItemTag(oItem.Id, oItem.ItemClass);
                    //lvItemsMessages.Items.AddRange(new ListViewItem[] { oListItem }); ;
                    //oListItem = null;

                    //  Load common data listview ------------------------------------------------
                    iCountCommon++;

                    if (this.cmboSearchType.Text == "Direct")
                        oListItem = new ListViewItem(iCountCommon.ToString(), 0);
                    else
                        oListItem = new ListViewItem(iCountCommon.ToString() + ":" + iCountCommon.ToString(), 0);

                    oListItem.SubItems.Add(oMeetingMessageData.Subject);

                    oListItem.SubItems.Add(oMeetingMessageData.ItemClass);

                    //oListItem.SubItems.Add(oMeetingMessageData.Organizer);
                    oListItem.SubItems.Add(oMeetingMessageData.DisplayTo);
                    oListItem.SubItems.Add(oMeetingMessageData.DisplayCc);

                    oListItem.SubItems.Add(oMeetingMessageData.ICalDateTimeStamp);
                    oListItem.SubItems.Add(oMeetingMessageData.ICalUid);
                    oListItem.SubItems.Add(oMeetingMessageData.PidLidCleanGlobalObjectId);
                    oListItem.SubItems.Add(oMeetingMessageData.PidLidGlobalObjectId);

                     
                    oListItem.SubItems.Add(oMeetingMessageData.LastModifiedName);
                    oListItem.SubItems.Add(oMeetingMessageData.LastModifiedTime);
                    oListItem.SubItems.Add(oMeetingMessageData.DateTimeCreated);
                    oListItem.SubItems.Add(oMeetingMessageData.DateTimeReceived);

                    oListItem.SubItems.Add(oMeetingMessageData.Size);
                    oListItem.SubItems.Add(oMeetingMessageData.IsHidden);

                    oListItem.SubItems.Add(oMeetingMessageData.ClientInfoString);
                    oListItem.SubItems.Add(oMeetingMessageData.PidLidClientIntent);
                    oListItem.SubItems.Add(oMeetingMessageData.LogTriggerAction);

                    oListItem.SubItems.Add(oMeetingMessageData.FolderPath);
                    oListItem.SubItems.Add(oMeetingMessageData.StoreEntryId);
                    oListItem.SubItems.Add(oMeetingMessageData.UniqueId);
                

                    oListItem.Tag = new ItemTag(oMeetingMessageData.UniqueId, oMeetingMessageData.ItemClass);
                    lvCommon.Items.AddRange(new ListViewItem[] { oListItem }); ;
                    oListItem = null;

                    // --- finally...

                    bRet = true;

                }

 

            }

            oListItem = null;

            lvItemsMessages.Visible = true;
            lvItems.Visible = true;


            return bRet;
        }

        string GetappointmentFromMeetingMessage(MeetingMessage oMeetingMessage)
        {
            string sRet = string.Empty;

            foreach (Attachment oAttachment in oMeetingMessage.Attachments)
            {
                if (oAttachment is FileAttachment)
                {
                    if (oAttachment.ContentType.ToUpper() == ".ICS")
                    {
                        FileAttachment fileAttachment = oAttachment as FileAttachment;
                        // Load the file attachment into memory and print out its file name.
                        fileAttachment.Load();
                        

                        //Console.WriteLine("Attachment name: " + fileAttachment.Name);

                        //// Load attachment contents into a file.
                        //fileAttachment.Load("C:\\temp\\" + fileAttachment.Name);

                        //// Stream attachment contents into a file.
                        //FileStream theStream = new FileStream("C:\\temp\\Stream_" + fileAttachment.Name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        //fileAttachment.Load(theStream);
                        //theStream.Close();
                        //theStream.Dispose();

                    }
                }
            }
            return sRet;
        }

        private bool CheckAppointmentforProblems(Appointment oAppointment)
        {
            bool bRet = false;

            return bRet;
        }

        private bool CheckRecurringforProblems(Appointment oAppointment)
        {
            bool bRet = false;



            return bRet;
        }

        private bool CheckMeetingMessageforProblems(MeetingMessage oMeetingMessage)
        {
            bool bRet = false;

           

            return bRet;
        }

        private bool CheckAppointmentChangesforProblems(Appointment oAppointment)
        {
            bool bRet = false;

            // Loop through them, compare and check...

            // see CompareApptProps(Appointment oAppointment)

            return bRet; 
        }

        // Used for comparing current appointment vs prior one.
        public static class ApptProps 
        {

            //public string ApptStateFlags = string.Empty;
            //public string ApptRecurring = string.Empty;
            //public string BusyStatus = string.Empty;
            //public string EndWhole = string.Empty;
            //public string IsRecurring = string.Empty;
            //public string Location = string.Empty;
            //public string OrganizerAddr = string.Empty;  
            //public string OrganizerName = string.Empty;
            //public string Sender = string.Empty;
            //public string StartWhole = string.Empty;
            //public string Cc = string.Empty;
            //public string To = string.Empty;
            //public string ViewEnd = string.Empty;
        }

        //public static void SaveApptProps(ref ApptProps oApptProps, Appointment oAppointment)
        //{

        //    //oApptProps.ApptStateFlags = oAppointment.ApptStateFlags;
        //    //oApptProps.ApptRecurring = oAppointment.ApptRecurring;
        //    //oApptProps.BusyStatus = oAppointment.BusyStatus;
        //    //oApptProps.EndWhole = oAppointment.ApptEndWhole;
        //    //oApptProps.IsRecurring = oAppointment.IsRecurring;
        //    //oApptProps.Location = oAppointment.Location;
        //    //oApptProps.OrganizerAddr = oAppointment.OrganizerAddr;
        //    //oApptProps.OrganizerName = oAppointment.OrganizerName;
        //    //oApptProps.Sender = oAppointment.SenderAddress;
        //    //oApptProps.StartWhole = oAppointment.ApptStartWhole;
        //    //oApptProps.Cc = oAppointment.AttendeeCC;
        //    //oApptProps.To = oAppointment.AttendeeTo;
        //    //oApptProps.ViewEnd = oAppointment.ViewEndTime;
        //}

  



        //xx

        // http://stackoverflow.com/questions/3829039/get-the-organizers-calendar-appointment-using-ews-for-exchange-2010
            
   

       

 


        private bool ProcessSearch(FolderId oFolderId, int iPageSize)
        {
            //int iCount = 0;
            bool bRet = false;

            if (oFolderId != null)
            {

                //FindItemsResults<Item> oFindItemsResults = null;

                if (this.cmboSearchType.Text == "Direct")
                {
                    List<SearchFilter> searchFilterCollection = new List<SearchFilter>();
                    ItemView oItemView = new ItemView(iPageSize);

                    oItemView.PropertySet = GetPropertySet();

              //      oItemView.OrderBy.Add(ItemSchema.LastModifiedTime, SortDirection.Descending);
                    //oItemView.OrderBy.Add(AppointmentSchema.LastModifiedTime, SortDirection.Descending);

                    //oItemView.Traversal = ItemTraversal.Shallow; // shallow, associated, soft deleted

                    SetSearchDepth(ref oItemView);

                    FindItemsResults<Item> oFindItemsResults = null;
                    oFindItemsResults = DoSearch(oFolderId, ref oItemView);


                    ConfigureListView_Calendar(ref lvItems, cmboSearchType.Text.Trim());

                    ConfigureListView_Message(ref lvItemsMessages, cmboSearchType.Text.Trim());

                    ConfigureListView_Common(ref lvCommon, cmboSearchType.Text.Trim());

                    AddSearchResultsToListViews(oFindItemsResults, 0);

                    
                }


                if (this.cmboSearchType.Text == "More Available")
                {

                    // http://msdn.microsoft.com/en-us/library/exchange/dd633698(v=exchg.80).aspx

                    int offset = 0;


                    bool MoreItems = true;
                    //ListViewItem oListItem = null;

                    ConfigureListView_Calendar(ref lvItems, cmboSearchType.Text.Trim());

                    ConfigureListView_Message(ref lvItemsMessages, cmboSearchType.Text.Trim());
                 
                    ConfigureListView_Common(ref lvCommon, cmboSearchType.Text.Trim());

                    int iCountMore = 0;

                    while (MoreItems)
                    {
                        iCountMore++;


                        ItemView oItemView = new ItemView(iPageSize, offset, OffsetBasePoint.Beginning);


                        oItemView.PropertySet = GetPropertySet();

                    
                        //oItemView.OrderBy.Add(ContactSchema.LastModifiedTime, SortDirection.Ascending);
              //          oItemView.OrderBy.Add(ItemSchema.LastModifiedTime, SortDirection.Ascending);
                        //oItemView.Traversal = ItemTraversal.Shallow; // shallow, associated, soft deleted

                        SetSearchDepth(ref oItemView);

                        FindItemsResults<Item> oFindItemsResults = null;
                        oFindItemsResults = DoSearch(oFolderId, ref oItemView);

                        AddSearchResultsToListViews(oFindItemsResults, iCountMore);

                        // Set the flag to discontinue paging.
                        if (!oFindItemsResults.MoreAvailable)
                        {
                            MoreItems = false;
                        }

                        // Update the offset if there are more items to page.
                        if (MoreItems)
                        {
                            offset += iPageSize;
                        }

                    }

                    bRet = true;
                }
            }
            this.Cursor = Cursors.Default;
            return bRet;

        }

        private PropertySet GetPropertySet()
        {

            //PropertySet oPropertySet = new PropertySet(BasePropertySet.FirstClassProperties);
            PropertySet oPropertySet = new PropertySet(BasePropertySet.IdOnly);
            oPropertySet.Add(ItemSchema.LastModifiedTime);
            oPropertySet.Add(ItemSchema.ItemClass);
            //oPropertySet.Add(ItemSchema.LastModifiedTime);
            //oPropertySet.Add(PidLidAppointmentRecur);
            //oPropertySet.Add(PidLidClientIntent);
            //oPropertySet.Add(ClientInfoString);

            //oPropertySet.Add(LogTriggerAction);

            return oPropertySet;


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int iPageSize = 100;
            iPageSize = (int)this.numPageSize.Value;
            this.Cursor = Cursors.WaitCursor;
            ProcessSearch(_CurrentFolderId, iPageSize);
            this.Cursor = Cursors.Default;
        }

        private void rdoAqsSearch_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckboxes();
        }

        private void rdoFindItemSearch_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckboxes();
        }

        private void chkBody_CheckedChanged(object sender, EventArgs e)
        {
            this.txtBody.Enabled = this.chkBody.Checked;
            cmboBodyConditional.Enabled = this.chkBody.Checked;

        }

        private void btnMailboxSearch_Click(object sender, EventArgs e)
        {
            //DoMailboxSearch();
        }



        private void btnListSearchableMailboxes_Click(object sender, EventArgs e)
        {
        }

 

        private void lvItems_DoubleClick(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems.Count > 0)
            {
                ItemTag oItemTag = (ItemTag)lvItems.SelectedItems[0].Tag;
                string sId = oItemTag.Id.UniqueId;
                //string sClass = oItemTag.ItemClass;

                DisplayItems(sId);
                //DisplayItems(sId, "IPM.Appointment");
            }
        }

        //private void DisplayItems(string sId, string sClass)
        //{

        //    ItemId oItemId = new ItemId(sId);
        //    List<ItemId> item = new List<ItemId>();
        //    item.Add(oItemId);
        //    DisplayItems(item, sClass);
        //}

        //private void DisplayItems(string sId, string sClass)
        //{
        //    ItemId oItemId = new ItemId(sId);
        //    List<ItemId> item = new List<ItemId>();
        //    item.Add(oItemId);
        //    DisplayItems(item, sClass);
        //}

     

        private void DisplayItems(string sId)
        {
            ItemId oItemId = new ItemId(sId);
            List<ItemId> item = new List<ItemId>();
            item.Add(oItemId);
            DisplayItems(item);
        }

        private void DisplayItems(List<ItemId> oItemIds)
        {
 
            ItemsContentForm.Show(
                "Displaying items",
                oItemIds,
                _CurrentService,
                this
                );
        }

        //private void DisplayItems(List<ItemId> oItemIds, string sClass)
        //{
        //    PropertySet oPropertySet = null;

        //    if (sClass.StartsWith("IPM.Appointment"))
        //        oPropertySet = EWSEditor.Common.Exports.MeetingMessageExport.GetMeetingMessageDataPropset(false);
        //    if (sClass.StartsWith("IPM.Schedule"))
        //        oPropertySet = EWSEditor.Common.Exports.CalendarExport.GetCalendarPropset(false);
 
        //    ItemsContentForm.Show(
        //        "Displaying items",
        //        oItemIds,
        //        _CurrentService,
        //        this 
        //        );
        //}

        //private void DisplayItem(string sId, string sClass)
        //{
        //    PropertySet oPropertySet = null;

        //    if (sClass.StartsWith("IPM.Appointment"))
        //        oPropertySet = EWSEditor.Common.Exports.ExportMeetingMessage.GetMeetingMessageDataPropset(false);
        //    if (sClass.StartsWith("IPM.SCHEDULE"))
        //        oPropertySet = EWSEditor.Common.Exports.CalendarExport.GetCalendarPropset(false);

        //    ItemId oItemId = new ItemId(sId);
        //    List<ItemId> item = new List<ItemId>();
        //    item.Add(oItemId);

        //    ItemsContentForm.Show(
        //        "Displaying item",
        //        item,
        //        _CurrentService,
        //        this,
        //        oPropertySet
        //        );
        //}

        private void chkClass_CheckedChanged(object sender, EventArgs e)
        {
            this.cmboClass.Enabled = this.chkClass.Checked;
            cmboClassConditional.Enabled = this.chkClass.Checked;

        }

        private void cmboSearchDepth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SetSearchDepth(ref ItemView oItemView)
        {
            switch (cmboSearchDepth.Text)
            {
                case "Shallow":
                    oItemView.Traversal = ItemTraversal.Shallow; // Shallow, Associated, SoftDeleted
                    break;
                case "Associated":
                    oItemView.Traversal = ItemTraversal.Associated; // Shallow, Associated, SoftDeleted
                    break;
                case "SoftDeleted":
                    oItemView.Traversal = ItemTraversal.SoftDeleted; // Shallow, Associated, SoftDeleted
                    break;
            }
        }

        private void AddCondition(ref List<SearchFilter> searchFilterCollection, PropertyDefinitionBase oProp, string sValue, string sConditional)
        {
            switch (sConditional)
            {
                case "ContainsSubstring":
                    searchFilterCollection.Add(new SearchFilter.ContainsSubstring(oProp, sValue));
                    break;
                case "IsEqualTo":
                    searchFilterCollection.Add(new SearchFilter.IsEqualTo(oProp, sValue));
                    break;
                case "IsGreaterThan":
                    searchFilterCollection.Add(new SearchFilter.IsGreaterThan(oProp, sValue));
                    break;
                case "IsGreaterThanOrEqualTo":
                    searchFilterCollection.Add(new SearchFilter.IsGreaterThanOrEqualTo(oProp, sValue));
                    break;
                case "IsLessThan":
                    searchFilterCollection.Add(new SearchFilter.IsLessThan(oProp, sValue));
                    break;
                case "IsLessThanOrEqualTo":
                    searchFilterCollection.Add(new SearchFilter.IsLessThanOrEqualTo(oProp, sValue));
                    break;
                case "IsNotEqualTo":
                    searchFilterCollection.Add(new SearchFilter.IsNotEqualTo(oProp, sValue));
                    break;

            }
        }

        private void chkUID_CheckedChanged(object sender, EventArgs e)
        {
            txtUID.Enabled = chkUID.Checked;
            cmboUidConditional.Enabled = chkUID.Checked;
        }

        private void cmboSubjectConditional_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmboClassConditional_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmboBodyConditional_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmboCCConditional_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmboToConditional_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmboUidConditional_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnExportCalendarItems_Click(object sender, EventArgs e)
        {

        }

        private void lvItemsMessages_DoubleClick(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems.Count > 0)
            {
                ItemTag oItemTag = (ItemTag)lvItemsMessages.SelectedItems[0].Tag;
                string sId = oItemTag.Id.UniqueId;
                //string sClass = oItemTag.ItemClass;

                DisplayItems(sId);
                //DisplayItems(sId, "IPM.Schedule");
            }

        }

        private void lvItemsMessages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvItems_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            LvColumnSort(ref lvItems, e.Column);
        }

        private void lvItemsMessages_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            LvColumnSort(ref lvItemsMessages, e.Column);
        }

        private void lvCommon_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            LvColumnSort(ref lvCommon, e.Column);
        }

        private void LvColumnSort(ref ListView oListView, int iClickedColumn)
        {
            this.Cursor = Cursors.WaitCursor;

            int iLastColumn = (int) oListView.Tag;  
            if (iClickedColumn != iLastColumn)  //Already sorted On the clicked column?
            { 
                iLastColumn = iClickedColumn;
                oListView.Tag = iLastColumn;
                oListView.Sorting = SortOrder.Ascending;
            }
            else
            { 
                if (oListView.Sorting == SortOrder.Ascending)  // togle sort order if same column clicked
                    oListView.Sorting = SortOrder.Descending;
                else
                    oListView.Sorting = SortOrder.Ascending;
            }
            oListView.Sort();
            oListView.ListViewItemSorter = new EWSEditor.Common.UIHelpers.ListViewItemComparer_Dates(iClickedColumn, oListView.Sorting);
            this.Cursor = Cursors.Default;
        }

        private void lvCommon_DoubleClick(object sender, EventArgs e)
        {
            if (lvCommon.SelectedItems.Count > 0)
            {
                ItemTag oItemTag = (ItemTag)lvCommon.SelectedItems[0].Tag;
                string sId = oItemTag.Id.UniqueId;
                DisplayItems(sId);
            }
        }
 

        //    }

        //    private PropertySet GetCalendarPropset()
        //    {

        //        PropertySet appointmentPropertySet = new PropertySet(BasePropertySet.IdOnly,

        //            AppointmentSchema.AdjacentMeetingCount,
        //            AppointmentSchema.AdjacentMeetings,
        //            AppointmentSchema.AllowedResponseActions,
        //            AppointmentSchema.AllowNewTimeProposal,
        //            /* AppointmentSchema.AppointmentReplyTime,  */
        //            AppointmentSchema.AppointmentSequenceNumber,
        //            AppointmentSchema.AppointmentState,
        //            AppointmentSchema.AppointmentType,
        //            AppointmentSchema.Attachments,
        //            AppointmentSchema.Body,
        //            AppointmentSchema.Categories,
        //            /*  AppointmentSchema.ConferenceType,   */
        //            AppointmentSchema.ConflictingMeetingCount,
        //            AppointmentSchema.ConflictingMeetings,  
        //            AppointmentSchema.Culture,
        //            AppointmentSchema.DateTimeCreated,
        //            AppointmentSchema.DateTimeReceived,
        //            AppointmentSchema.DateTimeSent,
        //            AppointmentSchema.DeletedOccurrences,
        //            AppointmentSchema.DisplayCc,
        //            AppointmentSchema.DisplayTo,
        //            AppointmentSchema.Duration,
        //            AppointmentSchema.EffectiveRights,
        //            AppointmentSchema.End,
        //            AppointmentSchema.HasAttachments,
        //            AppointmentSchema.ICalDateTimeStamp,
        //            AppointmentSchema.ICalRecurrenceId,
        //            AppointmentSchema.ICalUid,
        //            AppointmentSchema.Id,
        //            AppointmentSchema.Importance,
        //            AppointmentSchema.InReplyTo,
        //            AppointmentSchema.InternetMessageHeaders,

        //            AppointmentSchema.IsAllDayEvent,
        //            AppointmentSchema.IsCancelled,
        //            AppointmentSchema.IsDraft,
        //            AppointmentSchema.IsFromMe,
        //            AppointmentSchema.IsMeeting,
        //            AppointmentSchema.IsOnlineMeeting,
        //            AppointmentSchema.IsRecurring,
        //            AppointmentSchema.IsReminderSet,
        //            AppointmentSchema.IsResend,
        //            AppointmentSchema.IsResponseRequested,
        //            AppointmentSchema.IsSubmitted,
        //            AppointmentSchema.IsUnmodified,
        //            AppointmentSchema.ItemClass, 
        //            AppointmentSchema.LastModifiedName,
        //            AppointmentSchema.LastModifiedTime,
        //            AppointmentSchema.LegacyFreeBusyStatus,
        //            AppointmentSchema.Location,
        //            AppointmentSchema.MeetingRequestWasSent,
        //            AppointmentSchema.MeetingWorkspaceUrl,
        //            AppointmentSchema.MimeContent,
        //            AppointmentSchema.ModifiedOccurrences,
        //            AppointmentSchema.MyResponseType,
        //            AppointmentSchema.NetShowUrl,
        //            AppointmentSchema.OptionalAttendees,
        //            AppointmentSchema.Organizer,
        //            AppointmentSchema.OriginalStart,
        //            AppointmentSchema.ParentFolderId,
        //            AppointmentSchema.Recurrence,
        //            AppointmentSchema.ReminderDueBy,
        //            AppointmentSchema.ReminderMinutesBeforeStart,
        //            AppointmentSchema.RequiredAttendees,
        //            AppointmentSchema.Resources,  
        //            AppointmentSchema.Sensitivity,
        //            AppointmentSchema.Size,
        //            AppointmentSchema.Start,
        //            AppointmentSchema.StartTimeZone,
        //            AppointmentSchema.Subject,
        //            AppointmentSchema.TimeZone,
        //            AppointmentSchema.When


        //          );

        //        // Not included:
        //        //    AppointmentSchema.FirstOccurrence.,
        //        //    AppointmentSchema.LastOccurrence,
        //        //    AppointmentSchema.ModifiedOccurrences,
        //        //    AppointmentSchema.DeletedOccurrences,
        //        //    AppointmentSchema.ExtendedProperties

        //        // These are version specific:
        //        //      AppointmentSchema.Hashtags,                     2015+
        //        //      AppointmentSchema.MentionedMe,                  2015+
        //        //      AppointmentSchema.Mentions                      2015+
        //        //      AppointmentSchema.MimeContentUTF8,              Exchange2013_SP1+
        //        //      AppointmentSchema.ArchiveTag,                   2013+                +
        //        //      AppointmentSchema.ConversationId                2010+                +
        //        //      AppointmentSchema.EndTimeZone,                  2010+                 
        //        //      AppointmentSchema.EnhancedLocation,             2013+
        //        //      AppointmentSchema.EntityExtractionResult,       2013+
        //        //      AppointmentSchema.Flag,                         2013+
        //        //      AppointmentSchema.IconIndex,                    2013+                +
        //        //      AppointmentSchema.InstanceKey,                  2013+                +
        //        //      AppointmentSchema.IsAssociated,                 2010+
        //        //      AppointmentSchema.JoinOnlineMeetingUrl,         2013+
        //        //      AppointmentSchema.NormalizedBody,               2013+
        //        //      AppointmentSchema.OnlineMeetingSettings,        2013+
        //        //      AppointmentSchema.PolicyTag,                    2013+                +
        //        //      AppointmentSchema.Preview,                      2013+
        //        //      AppointmentSchema.RetentionDate,                2013+                +
        //        //      AppointmentSchema.StoreEntryId,                 2013+                +
        //        //      AppointmentSchema.TextBody,                     2013+
        //        //      AppointmentSchema.UniqueBody,                   2010+
        //        //      AppointmentSchema.WebClientEditFormQueryString, 2010+
        //        //      AppointmentSchema.WebClientReadFormQueryString, 2010+

        //        // Problems loading or need extra work to implement:
        //        //   AppointmentSchema.AppointmentReplyTime 
        //        //   AppointmentSchema.ConferenceType 


        //        // Need to add these:
        //        appointmentPropertySet.Add(PidLidAppointmentRecur);
        //        appointmentPropertySet.Add(PidLidClientIntent);
        //        appointmentPropertySet.Add(ClientInfoString);
        //        appointmentPropertySet.Add(LogTriggerAction);
        //        appointmentPropertySet.Add(PidLidCleanGlobalObjectId);
        //        appointmentPropertySet.Add(PidLidGlobalObjectId);

        //        appointmentPropertySet.Add(Prop_PR_POLICY_TAG);

        //        appointmentPropertySet.Add(Prop_PR_RETENTION_FLAGS);
        //        appointmentPropertySet.Add(Prop_PR_RETENTION_PERIOD);
        //        appointmentPropertySet.Add(Prop_PR_ARCHIVE_TAG);
        //        appointmentPropertySet.Add(Prop_PR_ARCHIVE_PERIOD);
        //        appointmentPropertySet.Add(Prop_PR_ARCHIVE_DATE);
        //        appointmentPropertySet.Add(Prop_PR_ENTRYID);

        //        appointmentPropertySet.Add(Prop_PR_RETENTION_DATE);
        //        appointmentPropertySet.Add(Prop_PR_STORE_ENTRYID);
        //        appointmentPropertySet.Add(Prop_PR_IS_HIDDEN);

        //        return appointmentPropertySet;
        //    }
        //}

        //private void MnuExportXml_Click(object sender, EventArgs e)
        //{
        //    // Get the folder to save the output files to, if the user
        //    // cancels this dialog bail out
        //    FolderBrowserDialog browser = new FolderBrowserDialog();
        //    browser.Description = "Pick an output folder to save the XML file to.";
        //    if (browser.ShowDialog() != DialogResult.OK)
        //    {
        //        return;
        //    }

        //    try
        //    {
        //        ItemId id = GetSelectedContentId();
        //        if (id == null)
        //        {
        //            return;
        //        }

        //        DumpHelper.DumpXML(
        //            new List<ItemId> { id },
        //            this.CurrentDetailPropertySet,
        //            browser.SelectedPath,
        //            this.CurrentService);
        //    }
        //    finally
        //    {
        //        this.Cursor = Cursors.Default;
        //    }
        //}

    }
 
}
