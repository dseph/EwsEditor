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

using EWSEditor.Common.Exports;
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

        private int _CountAppointment = 0;
        private int _CountMeetingMessage = 0;

        private static ExtendedPropertyDefinition PidNameCalendarIsOrganizer = new ExtendedPropertyDefinition(new Guid("00062002-0000-0000-C000-000000000046"), 0x000B, MapiPropertyType.Boolean);  
        private static ExtendedPropertyDefinition Prop_PR_FOLDER_PATH = new ExtendedPropertyDefinition(0x66B5, MapiPropertyType.String);   // Folder Path - PR_Folder_Path
        private static ExtendedPropertyDefinition PidLidAppointmentRecur = new ExtendedPropertyDefinition(new Guid("00062002-0000-0000-C000-000000000046"), 0x8216, MapiPropertyType.Binary); // dispidApptRecur
        private static ExtendedPropertyDefinition PidLidClientIntent = new ExtendedPropertyDefinition(new Guid("11000E07-B51B-40D6-AF21-CAA85EDAB1D0"), 0x0015, MapiPropertyType.Integer); // dispidClientIntent
        private static ExtendedPropertyDefinition ClientInfoString = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x000B, MapiPropertyType.String); //  
        private static ExtendedPropertyDefinition LogTriggerAction = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x0006, MapiPropertyType.String); //  
        private static ExtendedPropertyDefinition PidLidCleanGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0023, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PidLidGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0003, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition ICalId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Appointment, 3, MapiPropertyType.String);
        private static ExtendedPropertyDefinition Prop_PR_STORE_ENTRYID = new ExtendedPropertyDefinition(0x0FFB, MapiPropertyType.Binary);  // PidTagStoreEntryId
 
 
        // see: https://blogs.msdn.microsoft.com/mstehle/2009/09/02/ews-uid-not-always-the-same-for-orphaned-instances-of-the-same-meeting/
 
        // https://ingogegenwarth.wordpress.com/2015/05/01/troubleshooting-calendar-items/
  
 



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

            toolStripStatusLabel1.Text = "Ready to search.";

            cmboSearchType.Text = "Direct";

            cmboSearchDepth.Text = "Shallow";

            //cmboLogicalOperation.Text = "And";

            cmboUidConditional.Text = "IsEqualTo";
            cmboSubjectConditional.Text = "ContainsSubstring";
            cmboToConditional.Text = "ContainsSubstring";
            cmboCCConditional.Text = "ContainsSubstring";
            cmboBodyConditional.Text = "ContainsSubstring";
            cmboClassConditional.Text = "ContainsSubstring";
            //cmboGlobalObjIdConditional.Text = "ContainsSubstring";


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
                this.txtGlobalObjId.Enabled = false;
                 

                this.chkUID.Enabled = false;
                this.chkSubject.Enabled = false;
                this.chkTo.Enabled = false;
                this.chkCC.Enabled = false;
                this.chkBody.Enabled = false;
                this.chkClass.Enabled = false;
                this.chkGlobalObjId.Enabled = false;

                cmboUidConditional.Enabled = false;
                cmboSubjectConditional.Enabled = false;
                cmboToConditional.Enabled = false;
                cmboCCConditional.Enabled = false;
                cmboBodyConditional.Enabled = false;
                cmboClassConditional.Enabled = false;
                //this.cmboGlobalObjIdConditional.Enabled = false;


            }
            if (this.rdoFindItemSearch.Checked == true)
            {
                this.chkUID.Enabled = true;
                this.chkSubject.Enabled = true;
                this.chkTo.Enabled = true;
                this.chkCC.Enabled = true;
                this.chkBody.Enabled = true;
                this.chkClass.Enabled = true;
                this.chkGlobalObjId.Enabled = true;

                this.txtUID.Enabled = true;
                this.txtSubject.Enabled = true;
                this.txtTo.Enabled = true;
                this.txtCC.Enabled = true;
                this.txtBody.Enabled = true;
                this.cmboClass.Enabled = true;
                this.txtGlobalObjId.Enabled = true;
                 

                cmboUidConditional.Enabled = chkSubject.Checked;
                cmboSubjectConditional.Enabled = chkSubject.Checked;
                cmboToConditional.Enabled = chkTo.Checked;
                cmboCCConditional.Enabled = chkCC.Checked;
                cmboBodyConditional.Enabled = chkBody.Checked;
                cmboClassConditional.Enabled = chkClass.Checked;
                //cmboGlobalObjIdConditional.Enabled = chkGlobalObjId.Checked;

            }

            this.txtAQS.Enabled = rdoAqsSearch.Checked;
            this.txtUID.Enabled = chkUID.Checked;
            this.txtSubject.Enabled = chkSubject.Checked;
            this.txtTo.Enabled = chkTo.Checked;
            this.txtCC.Enabled = chkCC.Checked;
            this.txtBody.Enabled = chkBody.Checked;
            this.cmboClass.Enabled = chkClass.Checked;
            this.txtGlobalObjId.Enabled = chkGlobalObjId.Checked;
  
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

            if (this.chkGlobalObjId.Checked == true)
                if (this.txtGlobalObjId.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Global Obj ID line text cannot be blank");
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

        private void chkGlobalObjId_CheckedChanged(object sender, EventArgs e)
        { 
            txtGlobalObjId.Enabled = chkGlobalObjId.Checked;
            //cmboGlobalObjIdConditional.Enabled = chkGlobalObjId.Checked;

        }

        //private void ConfigureListView_Calendar(ref ListView oListView, string SearchType)
        //{
        //    ColumnHeader o = null;
        //    oListView.Clear();
        //    oListView.View = View.Details;
        //    oListView.GridLines = true;
        //    //oListView.Dock = DockStyle.Fill;

        //    if (SearchType == "Direct")
        //        oListView.Columns.Add("Count", 100, HorizontalAlignment.Left);
        //    else
        //        oListView.Columns.Add("Frame:Count", 100, HorizontalAlignment.Left);

        //    oListView.Columns.Add("Subject", 170, HorizontalAlignment.Left);
        //    oListView.Columns.Add("Class", 150, HorizontalAlignment.Left);
        //    oListView.Columns.Add("Organizer", 100, HorizontalAlignment.Left);

        //    oListView.Columns.Add("DisplayTo", 100, HorizontalAlignment.Left);
        //    oListView.Columns.Add("DisplayCc", 100, HorizontalAlignment.Left);

        //    oListView.Columns.Add("RequiredAttendees", 100, HorizontalAlignment.Left);
        //    oListView.Columns.Add("OptionalAttendees", 100, HorizontalAlignment.Left);

        //    oListView.Columns.Add("ICalUid", 200, HorizontalAlignment.Left);
        //    oListView.Columns.Add("CleanGlobalObjectId", 200, HorizontalAlignment.Left);
        //    oListView.Columns.Add("GlobalObjectId", 200, HorizontalAlignment.Left);

        //    oListView.Columns.Add("Start", 150, HorizontalAlignment.Left);
        //    oListView.Columns.Add("End", 150, HorizontalAlignment.Left);
        //    oListView.Columns.Add("RetentionDate", 150, HorizontalAlignment.Left);
        //    oListView.Columns.Add("DateTimeCreated", 150, HorizontalAlignment.Left);

        //    oListView.Columns.Add("LastModifiedName", 150, HorizontalAlignment.Left);
        //    oListView.Columns.Add("LastModifiedTime", 150, HorizontalAlignment.Left);

        //    oListView.Columns.Add("AppointmentType", 150, HorizontalAlignment.Left);
        //    oListView.Columns.Add("AppointmentState", 150, HorizontalAlignment.Left);

        //    oListView.Columns.Add("IsAllDayEvent", 100, HorizontalAlignment.Left);
        //    oListView.Columns.Add("IsCancelled", 100, HorizontalAlignment.Left);
        //    oListView.Columns.Add("IsRecurring", 100, HorizontalAlignment.Left);
        //    oListView.Columns.Add("IsReminderSet", 100, HorizontalAlignment.Left);

        //    oListView.Columns.Add("IsOnlineMeeting", 100, HorizontalAlignment.Left);
        //    oListView.Columns.Add("IsResend", 100, HorizontalAlignment.Left);
        //    oListView.Columns.Add("IsDraft", 100, HorizontalAlignment.Left);

        //    o = oListView.Columns.Add("Size", 70, HorizontalAlignment.Left);
        //    o.Tag = "int";
        //    o.TextAlign = HorizontalAlignment.Right;
        //    oListView.Columns.Add("Attatch", 80, HorizontalAlignment.Left);


        //    oListView.Columns.Add("PidLidAppointmentRecur ", 100, HorizontalAlignment.Left);
        //    o = oListView.Columns.Add("PidLidClientIntent ", 100, HorizontalAlignment.Left);
        //    o.Tag = "int";
        //    o.TextAlign = HorizontalAlignment.Right;

        //    oListView.Columns.Add("ClientInfoString ", 100, HorizontalAlignment.Left);
        //    oListView.Columns.Add("LogTriggerAction ", 100, HorizontalAlignment.Left);

        //    oListView.Columns.Add("IsHidden", 50, HorizontalAlignment.Left);
        //    oListView.Columns.Add("FolderPath", 200, HorizontalAlignment.Left);

        //    oListView.Columns.Add("StoreEntryId", 250, HorizontalAlignment.Left);
        //    oListView.Columns.Add("UniqueId", 250, HorizontalAlignment.Left);
        //    //oListView.Columns.Add("ChangeKey", 250, HorizontalAlignment.Left);

        //    oListView.Tag = -1;

        //}



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
 
            oListView.Columns.Add("Organizer", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("PidNameCalendarIsOrganizer", 150, HorizontalAlignment.Left);
             
            oListView.Columns.Add("From", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("Sender", 150, HorizontalAlignment.Left);

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

        
        //private void ConfigureListView_Message(ref ListView oListView, string SearchType)
        //{

        //    oListView.Clear();
        //    oListView.View = View.Details;
        //    oListView.GridLines = true;
        //    //oListView.Dock = DockStyle.Fill;

        //    if (SearchType == "Direct")
        //        oListView.Columns.Add("Count", 100, HorizontalAlignment.Left);
        //    else
        //        oListView.Columns.Add("Frame:Count", 100, HorizontalAlignment.Left);
             
        //    oListView.Columns.Add("Subject", 170, HorizontalAlignment.Left);
        //    oListView.Columns.Add("Class", 150, HorizontalAlignment.Left);


        //    oListView.Columns.Add("DisplayTo", 100, HorizontalAlignment.Left);
        //    oListView.Columns.Add("DisplayCc", 100, HorizontalAlignment.Left);


        //    oListView.Columns.Add("RetentionDate", 150, HorizontalAlignment.Left);
        //    oListView.Columns.Add("DateTimeCreated", 150, HorizontalAlignment.Left);

        //    oListView.Columns.Add("LastModifiedName", 150, HorizontalAlignment.Left);
        //    oListView.Columns.Add("LastModifiedTime", 150, HorizontalAlignment.Left);

        //    oListView.Columns.Add("IsResend", 100, HorizontalAlignment.Left);
        //    oListView.Columns.Add("IsDraft", 100, HorizontalAlignment.Left);

        //    oListView.Columns.Add("Size", 70, HorizontalAlignment.Left);
        //    oListView.Columns.Add("Attatch", 80, HorizontalAlignment.Left);

        //    oListView.Columns.Add("PidLidAppointmentRecur ", 100, HorizontalAlignment.Left);
        //    oListView.Columns.Add("PidLidClientIntent ", 100, HorizontalAlignment.Left);
        //    oListView.Columns.Add("dispidCalLogClientInfoString ", 100, HorizontalAlignment.Left);
        //    oListView.Columns.Add("LogTriggerAction ", 100, HorizontalAlignment.Left);

        //    oListView.Columns.Add("ICalUid", 200, HorizontalAlignment.Left);
        //    oListView.Columns.Add("CleanGlobalObjectId", 200, HorizontalAlignment.Left);
        //    oListView.Columns.Add("GlobalObjectId", 200, HorizontalAlignment.Left);

        //    oListView.Columns.Add("FolderPath", 250, HorizontalAlignment.Left);
        //    oListView.Columns.Add("StoreEntryId", 250, HorizontalAlignment.Left);
        //    oListView.Columns.Add("UniqueId", 250, HorizontalAlignment.Left);

        //    oListView.Tag = -1;
 
        //}



        private FindItemsResults<Item> DoSearch(FolderId oFolderId, ref ItemView oItemView)
        {
            FindItemsResults<Item> oFindItemsResults = null;
            List<SearchFilter> searchFilterCollection = new List<SearchFilter>();

            toolStripStatusLabel1.Text = "Searching...";

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

                // Cannot search on PidLidCleanGlobalObjectId because its a binary property... so, need to loop through results later and
                // skip processing any result which has a PidLidCleanGlobalObjectId that does not match the PidLidCleanGlobalObjectId to filter on.
                //if (this.chkGlobalObjId.Checked == true)
                //    AddCondition(ref searchFilterCollection, PidLidCleanGlobalObjectId, this.txtGlobalObjId.Text.Trim(), cmboGlobalObjIdConditional.Text);

 
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

        private bool AddSearchResultsToListViews(FindItemsResults<Item> oFindItemsResults, 
            int iCountMore, 
            List < AdditionalPropertyDefinition > oAdditionalPropertyDefinitions,
            List < ExtendedPropertyDefinition > oExtendedPropertyDefinitions 
            )
        {
            bool bRet = false;

  
            ListViewItem oListItem = null;

            int iCountAppointment = 0;
            int iCountCommon = 0;
            int iCountMeetingMessage = 0;

            oListItem = null;

            toolStripStatusLabel1.Text = "Processing Items...";
            lvCommon.Visible = false;

            string sPidLidCleanGlobalObjectId = string.Empty;
 
            foreach (Item oItem in oFindItemsResults.Items)
            { 
 
                if (this.chkGlobalObjId.Checked == true)
                {
                    // Cannot search on binary data in EWS... so we need to read everything and Check to see if sPidLidCleanGlobalObjectId matches. 
                    sPidLidCleanGlobalObjectId = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oItem, PidLidCleanGlobalObjectId);

 
                    if (this.txtGlobalObjId.Text == sPidLidCleanGlobalObjectId)
                    {
                    }
                    else
                    {
                        continue;
                    }
 
 
                }
                if (oItem.ItemClass.ToUpper().StartsWith("IPM.APPOINTMENT"))
                { 
                    Appointment o = (Appointment)oItem;
                    if (this.txtUID.Text == (o.ICalUid))
                    {
                        System.Diagnostics.Debug.WriteLine("Query: " + this.txtGlobalObjId.Text.Trim());
                        System.Diagnostics.Debug.WriteLine("sPidLidCleanGlobalObjectId: " + sPidLidCleanGlobalObjectId);
                        System.Diagnostics.Debug.WriteLine("PidLidGlobalObjectId:       " + PidLidGlobalObjectId);
                        System.Diagnostics.Debug.WriteLine("ICalUid: " + AppointmentSchema.ICalUid);
                        System.Diagnostics.Debug.WriteLine("Subject: " + ItemSchema.Subject);
                        System.Diagnostics.Debug.WriteLine(" ");

                    }
                }
                if (oItem.ItemClass.ToUpper().StartsWith("IPM.SCHEDULE"))
                {
                    MeetingMessage o = (MeetingMessage)oItem;
                    
                    if (this.txtUID.Text == (o.ICalUid))
                    {
                        System.Diagnostics.Debug.WriteLine("Query: " + this.txtGlobalObjId.Text.Trim());
                        System.Diagnostics.Debug.WriteLine("sPidLidCleanGlobalObjectId: " + sPidLidCleanGlobalObjectId);
                        System.Diagnostics.Debug.WriteLine("PidLidGlobalObjectId:       " + PidLidGlobalObjectId);
                        System.Diagnostics.Debug.WriteLine("ICalUid: " + AppointmentSchema.ICalUid);
                        System.Diagnostics.Debug.WriteLine("Subject: " + ItemSchema.Subject);
                        System.Diagnostics.Debug.WriteLine(" ");

                    }
                }
               
          
 

                //System.Diagnostics.Debug.WriteLine("Query: " + this.txtGlobalObjId.Text.Trim());
                //System.Diagnostics.Debug.WriteLine("Data: " + sPidLidCleanGlobalObjectId);

                if (oItem.ItemClass.ToUpper().StartsWith("IPM.APPOINTMENT") )
                {

                    _CountAppointment++;
                    iCountAppointment++;

                    EWSEditor.Common.Exports.AppointmentData oAppointmentData = new EWSEditor.Common.Exports.AppointmentData();
                    EWSEditor.Common.Exports.CalendarExport oCalendarExport = new EWSEditor.Common.Exports.CalendarExport();
                    oAppointmentData = oCalendarExport.GetAppointmentDataFromItem(
                        oItem.Service, 
                        oItem.Id,
                        oAdditionalPropertyDefinitions,
                        oExtendedPropertyDefinitions,
                        false, 
                        false);

 
                    //  Load common data listview ------------------------------------------------
                     
                    iCountCommon++;

                    if (this.cmboSearchType.Text == "Direct")
                        oListItem = new ListViewItem(iCountCommon.ToString(), 0);
                    else
                        oListItem = new ListViewItem(iCountCommon.ToString() + ":" + iCountCommon.ToString(), 0);

                    oListItem.SubItems.Add(oAppointmentData.OrganizerName + " <" +  oAppointmentData.OrganizerAddress + ">");
                    oListItem.SubItems.Add(oAppointmentData.PidNameCalendarIsOrganizer);

                    oListItem.SubItems.Add(""); // From
                    oListItem.SubItems.Add(""); // Sender
 

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


                    oListItem.Tag = new CalendarItemTag(oAppointmentData.UniqueId, oAppointmentData.ItemClass, oAppointmentData.ICalUid);
                    lvCommon.Items.AddRange(new ListViewItem[] { oListItem }); ;
                    oListItem = null;

                    // --- finally...

                    bRet = true;

                }

                if (oItem.ItemClass.ToUpper().StartsWith("IPM.SCHEDULE"))
                {

                    _CountMeetingMessage++;
                    iCountMeetingMessage++;

                    EWSEditor.Common.Exports.MeetingMessageData oMeetingMessageData = new EWSEditor.Common.Exports.MeetingMessageData();
                    EWSEditor.Common.Exports.MeetingMessageExport oMeetingMessageExport = new EWSEditor.Common.Exports.MeetingMessageExport();

                    oMeetingMessageData = oMeetingMessageExport.GetMeetingMessageDataFromItem(
                            oItem.Service, 
                            oItem.Id,
                            oAdditionalPropertyDefinitions,
                            oExtendedPropertyDefinitions,
                            false,
                            false
                            ); 
 

                    //  Load common data listview ------------------------------------------------
                    iCountCommon++;

                    if (this.cmboSearchType.Text == "Direct")
                        oListItem = new ListViewItem(iCountCommon.ToString(), 0);
                    else
                        oListItem = new ListViewItem(iCountCommon.ToString() + ":" + iCountCommon.ToString(), 0);

                    oListItem.SubItems.Add(""); // Organizer
                    oListItem.SubItems.Add(oMeetingMessageData.PidNameCalendarIsOrganizer);

                    oListItem.SubItems.Add(oMeetingMessageData.From);
                    oListItem.SubItems.Add(oMeetingMessageData.Sender);

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


                    oListItem.Tag = new CalendarItemTag(oMeetingMessageData.UniqueId, oMeetingMessageData.ItemClass, oMeetingMessageData.ICalUid);
                    //oListItem.Tag = new ItemTag(oMeetingMessageData.UniqueId, oMeetingMessageData.ItemClass);
                    lvCommon.Items.AddRange(new ListViewItem[] { oListItem }); ;
                    oListItem = null;

                    // --- finally...

                    bRet = true;

                    if (iCountCommon % 10 == 0)
                        toolStripStatusLabel1.Text = string.Format("Searching - Retrieved {0} Calendar item(s), {1} Meeting Message(s) ...", _CountAppointment, _CountMeetingMessage);

                }

                toolStripStatusLabel1.Text = string.Format("Searching - Retrieved {0} Calendar item(s), {1} Meeting message(s).", _CountAppointment, _CountMeetingMessage);

                
            }

            oListItem = null;

            lvCommon.Visible = true;
 

            return bRet;
        }

        #region CalendarCheck definition

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
  

                    }
                }
            }
            return sRet;
        }
 
 

        // http://stackoverflow.com/questions/3829039/get-the-organizers-calendar-appointment-using-ews-for-exchange-2010



        #endregion




        private bool ProcessSearch(FolderId oFolderId, 
            int iPageSize, 
            List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions,
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions )
        {
            //int iCount = 0;
            bool bRet = false;

            int TotalRetrieved = 0;

            if (oFolderId != null)
            {

                //FindItemsResults<Item> oFindItemsResults = null;

                if (this.cmboSearchType.Text == "Direct")
                {
                    List<SearchFilter> searchFilterCollection = new List<SearchFilter>();
                    ItemView oItemView = new ItemView(iPageSize);

                    oItemView.PropertySet = GetPropertySet();
 

                    SetSearchDepth(ref oItemView);

     

                    FindItemsResults<Item> oFindItemsResults = null;
                    oFindItemsResults = DoSearch(oFolderId, ref oItemView);


               
 
                    ConfigureListView_Common(ref lvCommon, cmboSearchType.Text.Trim());

                    AddSearchResultsToListViews(
                        oFindItemsResults, 
                        0,  
                        oAdditionalPropertyDefinitions,
                        oExtendedPropertyDefinitions  
                        );

                    
                }


                if (this.cmboSearchType.Text == "More Available")
                {

                    // http://msdn.microsoft.com/en-us/library/exchange/dd633698(v=exchg.80).aspx

                    int offset = 0;

                    bool MoreItems = true;
 
                 
                    ConfigureListView_Common(ref lvCommon, cmboSearchType.Text.Trim());

                    int iCountMore = 0;

                    TotalRetrieved = 0;

                    while (MoreItems)
                    {
                        iCountMore++;

 
                        ItemView oItemView = new ItemView(iPageSize, offset, OffsetBasePoint.Beginning);


                        oItemView.PropertySet = GetPropertySet();
 

                        SetSearchDepth(ref oItemView);

                        FindItemsResults<Item> oFindItemsResults = null;
                        oFindItemsResults = DoSearch(oFolderId, ref oItemView);

                        AddSearchResultsToListViews(
                            oFindItemsResults, 
                            iCountMore, 
                            oAdditionalPropertyDefinitions,
                            oExtendedPropertyDefinitions 
                            );

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
            oPropertySet.Add(PidLidCleanGlobalObjectId);
            oPropertySet.Add(PidLidGlobalObjectId);

            oPropertySet.Add(ItemSchema.Subject);
            oPropertySet.Add(AppointmentSchema.ICalUid);
 
            return oPropertySet;


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _CountAppointment = 0;
            _CountMeetingMessage = 0;
            int iPageSize = 100;
            iPageSize = (int)this.numPageSize.Value;
            this.Cursor = Cursors.WaitCursor;

 
            List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions = null;
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions = null;
            ProcessSearch(_CurrentFolderId, iPageSize, oAdditionalPropertyDefinitions, oExtendedPropertyDefinitions);

            toolStripStatusLabel1.Text = "Ready to search."; 
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
 
        }



        private void btnListSearchableMailboxes_Click(object sender, EventArgs e)
        {
        }

 

        private void lvItems_DoubleClick(object sender, EventArgs e)
        {
 
        }
 

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
                case "IsEqualTo":  //Convert.FromBase64String
                    //searchFilterCollection.Add(new SearchFilter.IsEqualTo(oProp, Convert.FromBase64String(sValue)));
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
            toolStripStatusLabel1.Text = "Exporting...";
            this.Cursor = Cursors.WaitCursor;
            ExportCalendarItems();
            toolStripStatusLabel1.Text = "Ready to search.";
            this.Cursor = Cursors.Default;
        }

        #region ExportCalendarItems definition

        private void ExportCalendarItems( ) 
        { 
            SearchCalendarExportPicker oForm = new SearchCalendarExportPicker();
            oForm.ShowDialog();

            List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions = null;
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions = null;
 
            //List<AdditionalProperty> oAdditionalPropertiesDefs = null;
 
            if (oForm.bChoseOk == true)
            {

                if (oForm.chkIncludeUsersAdditionalProperties.Checked == true)
                {
                    oAdditionalPropertyDefinitions = oForm.AdditionalPropertyDefinitions;
                    oExtendedPropertyDefinitions = oForm.ExtendedPropertyDefinitions;
                }
 
                if (oForm.rdoExportDisplayedResults.Checked == true)
                {
                    string sPath = oForm.txtDisplayedResultsFolderPath.Text.Trim();
                    string sRoot = Path.GetPathRoot(sPath);

                    if (CheckFolder(sRoot))
                    { 
                        if (File.Exists(sPath))
                        {
                            MessageBox.Show("File Already Exists",  "File already exists.  Choose a different file name.");
                        }
                        else
                        {
                            ExportDisplayedResults(_CurrentService, sPath, oAdditionalPropertyDefinitions, oExtendedPropertyDefinitions, oForm.StringHandling);

 
                        }
                    }
                }                
                
                if (oForm.rdoExportDetailedProperties.Checked == true)
                {
                    string sAppointmentPath = oForm.txtAppointmentDetailedFolderPath.Text.Trim();
                    string sAppointmentRoot = Path.GetPathRoot(sAppointmentPath);

                    string sMeetingMessagePath = oForm.txtMeetingMessageDetailedFolderPath.Text.Trim();
                    string sMeetingMessageRoot = Path.GetPathRoot(sMeetingMessagePath);

                    if (CheckFolder(sAppointmentRoot))
                    {
                        if (File.Exists(sAppointmentPath))
                        {
                            MessageBox.Show("Appoinment export file Already Exists", "File already exists.  Choose a different file name.");
                            return;
                        }
                    }
                    else
                        return;

                    if (CheckFolder(sMeetingMessageRoot))
                    {
                        if (File.Exists(sMeetingMessagePath))
                        {
                            MessageBox.Show("Meeting Message export file already exists", "File already exists.  Choose a different file name.");
                            return;
                        }
                    }
                    else
                        return;

                    ExportDetailedProperties(
                        sAppointmentPath,
                        sMeetingMessagePath,
                        oAdditionalPropertyDefinitions,
                        oExtendedPropertyDefinitions,
                        oForm.chkIncludeBodyProperties.Checked,
                        oForm.chkIncludeMime.Checked,
                        oForm.StringHandling
                        );

  
                }

                if (oForm.rdoDiagnosticExport.Checked == true)
                {
                    string sPath = oForm.txtDiagnosticExportFolderPath.Text.Trim();
                    string sRoot = Path.GetPathRoot(sPath);

                    if (CheckFolder(sRoot))
                    {
                        if (File.Exists(sPath))
                        {
                            MessageBox.Show("File Already Exists", "File already exists.  Choose a different file name.");
                        }
                        else
                        {
                            this.ExportDiagProperties(
                                sPath,   
                                oAdditionalPropertyDefinitions,
                                oExtendedPropertyDefinitions 
                                );                            
                        }
                    }
                }  

                if (oForm.rdoExportItemsAsBlobs.Checked == true)
                {
                    
                    if (CheckFolder(oForm.txtBlobFolderPath.Text.Trim()))
                        ExportItemsAsBlobs(oForm.txtBlobFolderPath.Text.Trim());
                }

            }

        }

        private bool CheckFolder(string sFolderPath)
        {
            // validate folder path is correct.
            if (System.IO.Directory.Exists(sFolderPath) == false)
            {
                DialogResult oDlg = MessageBox.Show("Create Folder", "The folder path chosen does not exist.  Do you wish to create this folder?", MessageBoxButtons.YesNo);
                if (oDlg == System.Windows.Forms.DialogResult.Yes)
                {
                    System.IO.Directory.CreateDirectory(sFolderPath);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private void ExportDisplayedResults(
            ExchangeService oExchangeService,
            string sFolderPath,
            List<EWSEditor.Common.Exports.AdditionalPropertyDefinition> oAdditionalPropertyDefinitions, 
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions,
            CsvStringHandling oCsvStringHandling
            )
        {

            ListViewExport.SaveCalendarListViewToCsv(oExchangeService, lvCommon, sFolderPath, oAdditionalPropertyDefinitions, oExtendedPropertyDefinitions, oCsvStringHandling);
        }

       

        /// ExportDetailedProperties()
        /// Save items in grid with many properties to CSV files.
        private bool ExportDetailedProperties(
                string sAppointmentFilePath,
                string sMeetingMessageFilePath,
                List<EWSEditor.Common.Exports.AdditionalPropertyDefinition> oAdditionalPropertyDefinitions, 
                List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions,
                bool chkIncludeBodyProperties,
                bool chkIncludeMime,
                CsvStringHandling oCsvStringHandling)
        {
            bool bRet = false;
            EWSEditor.Common.Exports.CalendarExport oCalendarExport = new EWSEditor.Common.Exports.CalendarExport();
            EWSEditor.Common.Exports.MeetingMessageExport oMeetingMessageExport = new EWSEditor.Common.Exports.MeetingMessageExport();

            string sHeader = string.Empty;
            string sLine = string.Empty;

 
            ItemId oItemId = null;
            CalendarItemTag oCalendarItemTag = null;
            string sFile = string.Empty;
           
            int iCount = 0;
            string s = string.Empty;
            string sId = string.Empty;
            string sUID = string.Empty;
            string sClass = string.Empty;

            AppointmentData oAppointmentData;
            MeetingMessageData oMeetingMessageData;

      
            StreamWriter swAppointment = File.CreateText(sAppointmentFilePath);
            StreamWriter swMeetingMessage = File.CreateText(sMeetingMessageFilePath);

            sHeader = oCalendarExport.GetAppointmentDataAsCsvHeaders(oAdditionalPropertyDefinitions);
            swAppointment.WriteLine(sHeader);

            sHeader = oMeetingMessageExport.GetMeetingMessageDataAsCsvHeaders(oAdditionalPropertyDefinitions);
            swMeetingMessage.WriteLine(sHeader);
            char[] TrimChars = { ',', ' ' };

            foreach (ListViewItem oListViewItem in lvCommon.Items)
            {
                if (oListViewItem.Selected == true)
                {
                    iCount++;
                    sLine = string.Empty;
                    oCalendarItemTag = (CalendarItemTag)oListViewItem.Tag;
                    sId = oCalendarItemTag.Id.UniqueId;
                    sUID = oCalendarItemTag.ItemUid;
                    sClass = oCalendarItemTag.ItemClass.ToUpper();
                    oItemId = new ItemId(sId);
 
                    if (sClass.StartsWith("IPM.APPOINTMENT"))
                    {
                        oAppointmentData = oCalendarExport.GetAppointmentDataFromItem(
                            _CurrentService, 
                            oItemId,
                            oAdditionalPropertyDefinitions,
                            oExtendedPropertyDefinitions,
                            chkIncludeBodyProperties,
                            chkIncludeMime
                            );

                        string sExtendedProps = string.Empty;
  
                        //if (oExtendedPropertyDefinitions != null)
                        //{
                        //    sExtendedProps = AdditionalProperties.GetExtendedPropertiesForItemAsCsvContent(_CurrentService, oItemId, oExtendedPropertyDefinitions);
                        //}
                      
                        sLine = oCalendarExport.GetAppointmentDataAsCsv2(oAppointmentData);

                        if (oExtendedPropertyDefinitions != null)
                        {
                            sLine = sLine.Trim();
                            sLine += "," + AdditionalProperties.GetExtendedPropertiesForItemAsCsvContent(
                                        _CurrentService, 
                                        oItemId, 
                                        oExtendedPropertyDefinitions,
                                        oCsvStringHandling);
                            sLine = sLine.TrimEnd(TrimChars);
                            //sLine = sLine + "\r\n";
                        }

                        swAppointment.WriteLine(sLine);

                         
                    }

                    if (sClass.StartsWith("IPM.SCHEDULE"))
                    {
                        oMeetingMessageData = oMeetingMessageExport.GetMeetingMessageDataFromItem(
                            _CurrentService, 
                            oItemId,
                            oAdditionalPropertyDefinitions,
                            oExtendedPropertyDefinitions,
                            chkIncludeBodyProperties,
                            chkIncludeMime
                            );

                        sLine = oMeetingMessageExport.GetMeetingMessageDataAsCsv2(oMeetingMessageData);


                        if (oExtendedPropertyDefinitions != null)
                        {
                            sLine = sLine.Trim();
                            sLine += "," + AdditionalProperties.GetExtendedPropertiesForItemAsCsvContent(
                                    _CurrentService, 
                                    oItemId, 
                                    oExtendedPropertyDefinitions,
                                    oCsvStringHandling
                                    );
                            sLine = sLine.TrimEnd(TrimChars);
                            //sLine = sLine + "\r\n";
                        }

                        swMeetingMessage.WriteLine(sLine);
                    }
                    bRet = true;
                }
            }

            swAppointment.Close();
            swMeetingMessage.Close();

            return bRet;
        }

        /// ExportItemsAsBlobs()
        /// Save all items in grid as blobs. These can be reloaded later with EWSEditor.
        private bool ExportItemsAsBlobs(string sFolderPath)
        {
            bool bRet = false;
            EWSEditor.Common.Exports.CalendarExport oCalendarExport = new EWSEditor.Common.Exports.CalendarExport();
            EWSEditor.Common.Exports.MeetingMessageExport oMeetingMessageExport = new EWSEditor.Common.Exports.MeetingMessageExport();

             
            ItemId oItemId = null;
            CalendarItemTag oCalendarItemTag = null;
            string sFile = string.Empty;
            string sFilePath = string.Empty;
            int iCount = 0;
            string s = string.Empty;
            string sId = string.Empty;
            string sUID = string.Empty;
            string sClass = string.Empty;

            foreach (ListViewItem oListViewItem in  lvCommon.Items)
            {
                if (oListViewItem.Selected == true)
                {
                    iCount++;
                    oCalendarItemTag = (CalendarItemTag)oListViewItem.Tag;
                    sId = oCalendarItemTag.Id.UniqueId;
                    sUID = oCalendarItemTag.ItemUid;
                    sClass = oCalendarItemTag.ItemClass.ToUpper();
                    oItemId = new ItemId(sId);

                    sFile = sUID + "-" + sClass + "-" + iCount.ToString() + ".bin";

                    sFilePath = Path.Combine(sFolderPath, sFile);

                    if (sClass.StartsWith("IPM.APPOINTMENT"))
                        oCalendarExport.SaveAppointmentBlobToFolder(_CurrentService, oItemId, sFilePath);

                    if (sClass.StartsWith("IPM.SCHEDULE"))
                        oMeetingMessageExport.SaveMeetingMessageBlobToFolder(_CurrentService, oItemId, sFilePath);
                    bRet = true;
                }                
            }

            return bRet;
        }

        #endregion

        //private void lvItemsMessages_DoubleClick(object sender, EventArgs e)
        //{
        //    //if (lvItems.SelectedItems.Count > 0)
        //    //{
        //    //    ItemTag oItemTag = (ItemTag)lvItemsMessages.SelectedItems[0].Tag;
        //    //    string sId = oItemTag.Id.UniqueId;
        //    //    //string sClass = oItemTag.ItemClass;

        //    //    DisplayItems(sId);
        //    //    //DisplayItems(sId, "IPM.Schedule");
        //    //}

        //}

        //private void lvItemsMessages_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //private void lvItems_ColumnClick(object sender, ColumnClickEventArgs e)
        //{
        //    //LvColumnSort(ref lvItems, e.Column);
        //}

        //private void lvItemsMessages_ColumnClick(object sender, ColumnClickEventArgs e)
        //{
        //    //LvColumnSort(ref lvItemsMessages, e.Column);
        //}

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
                CalendarItemTag oCalendarItemTag = (CalendarItemTag)lvCommon.SelectedItems[0].Tag;
                string sId = oCalendarItemTag.Id.UniqueId;
                DisplayItems(sId);
            }
        }

        private void lvCommon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public string GetExtendedProp_Byte_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            byte[] bytearrVal;

            string sReturn = "";
            if (oItem.TryGetProperty(oExtendedPropertyDefinition, out bytearrVal))  // Example: CleanGlobalObjectId
                sReturn = Convert.ToBase64String(bytearrVal);  // reverse: Convert.FromBase64String(string data)
            else
                sReturn = "";
            return sReturn;
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


        private bool ExportDiagProperties(
            string sDiagFilePath, 
            List < AdditionalPropertyDefinition > oAdditionalPropertyDefinitions,
            List < ExtendedPropertyDefinition > oExtendedPropertyDefinitions 
            )
        {
            bool bRet = false;
            EWSEditor.Common.Exports.CalendarExport oCalendarExport = new EWSEditor.Common.Exports.CalendarExport();
            EWSEditor.Common.Exports.MeetingMessageExport oMeetingMessageExport = new EWSEditor.Common.Exports.MeetingMessageExport();

            string sHeader = string.Empty;
            string sLine = string.Empty;
 

            ItemId oItemId = null;
            CalendarItemTag oCalendarItemTag = null;
            string sFile = string.Empty;

            int iCount = 0;
            string s = string.Empty;
            string sId = string.Empty;
            string sUID = string.Empty;
            string sClass = string.Empty;

            AppointmentData oAppointmentData;
            MeetingMessageData oMeetingMessageData;

            //E:\msft tools\ewseditor\EWSEditor\bin\Debug\Export
            StreamWriter swDiag = File.CreateText(sDiagFilePath);


            sHeader = oCalendarExport.GetDiagMeetingMessageDataAsCsvHeaders();
            swDiag.WriteLine(sHeader);
 

            foreach (ListViewItem oListViewItem in lvCommon.Items)
            {
                if (oListViewItem.Selected == true)
                {
                    iCount++;
                    sLine = string.Empty;
                    oCalendarItemTag = (CalendarItemTag)oListViewItem.Tag;
                    sId = oCalendarItemTag.Id.UniqueId;
                    sUID = oCalendarItemTag.ItemUid;
                    sClass = oCalendarItemTag.ItemClass.ToUpper();
                    oItemId = new ItemId(sId);

                    if (sClass.StartsWith("IPM.APPOINTMENT"))
                    {
                        oAppointmentData = oCalendarExport.GetAppointmentDataFromItem(
                            _CurrentService, 
                            oItemId,
                            oAdditionalPropertyDefinitions,
                            oExtendedPropertyDefinitions,
                            false,
                            false
                            );
                        sLine = oCalendarExport.GetDiagtAppointmenDataAsCsv(oAppointmentData);
                        swDiag.WriteLine(sLine);
                    }


                    if (sClass.StartsWith("IPM.SCHEDULE"))
                    {
                        oMeetingMessageData = oMeetingMessageExport.GetMeetingMessageDataFromItem(
                            _CurrentService, 
                            oItemId,
                            oAdditionalPropertyDefinitions,
                            oExtendedPropertyDefinitions,
                            false,
                            false
                            );
                        sLine = oMeetingMessageExport.GetDiagMeetingMessageDataAsCsv(oMeetingMessageData);
                        swDiag.WriteLine(sLine);
                    }
                    bRet = true;
                }
            }

            swDiag.Close();
 

            return bRet;
        }

    }
 
 
}
