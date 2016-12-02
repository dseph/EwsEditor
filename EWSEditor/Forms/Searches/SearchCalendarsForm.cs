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

        private static ExtendedPropertyDefinition Prop_PR_FOLDER_PATH = new ExtendedPropertyDefinition(0x66B5, MapiPropertyType.String);   // Folder Path - PR_Folder_Path
        //private static ExtendedPropertyDefinition Prop_PR_FOLDER_TYPE = new ExtendedPropertyDefinition(0x3601, MapiPropertyType.Integer);  // PR_FOLDER_TYPE 0x3601 (13825)

        private static ExtendedPropertyDefinition PidLidAppointmentRecur = new ExtendedPropertyDefinition(new Guid("00062002-0000-0000-C000-000000000046"), 0x8216, MapiPropertyType.Binary); // dispidApptRecur
        private static ExtendedPropertyDefinition PidLidClientIntent = new ExtendedPropertyDefinition(new Guid("11000E07-B51B-40D6-AF21-CAA85EDAB1D0"), 0x0015, MapiPropertyType.Integer); // dispidClientIntent

        private static ExtendedPropertyDefinition ClientInfoString = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x000B, MapiPropertyType.String); //  
        private static ExtendedPropertyDefinition LogTriggerAction = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x0006, MapiPropertyType.String); //  

        private static ExtendedPropertyDefinition PidLidCleanGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0023, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PidLidGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0003, MapiPropertyType.Binary);


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
            
            cmboLogicalOperation.Text = "And";

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
            this.txtTo.Enabled  = chkTo.Checked;
            this.txtCC.Enabled  = chkCC.Checked;
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

        private void ConfigureListView_Calendar(ref ListView lvItems, string SearchType)
        {

            lvItems.Clear();
            lvItems.View = View.Details;
            lvItems.GridLines = true;
            //lvItems.Dock = DockStyle.Fill;

            if (SearchType == "Direct")
                lvItems.Columns.Add("Count", 100, HorizontalAlignment.Left);
            else
                lvItems.Columns.Add("Frame:Count", 100, HorizontalAlignment.Left);

            lvItems.Columns.Add("Subject", 170, HorizontalAlignment.Left);
            lvItems.Columns.Add("Class", 150, HorizontalAlignment.Left);
            lvItems.Columns.Add("Organizer", 100, HorizontalAlignment.Left);

            lvItems.Columns.Add("DisplayTo", 100, HorizontalAlignment.Left);
            lvItems.Columns.Add("DisplayCc", 100, HorizontalAlignment.Left);

            lvItems.Columns.Add("RequiredAttendees", 100, HorizontalAlignment.Left);
            lvItems.Columns.Add("OptionalAttendees", 100, HorizontalAlignment.Left);

            lvItems.Columns.Add("ICalUid", 200, HorizontalAlignment.Left);
            lvItems.Columns.Add("CleanGlobalObjectId", 200, HorizontalAlignment.Left);
            lvItems.Columns.Add("GlobalObjectId", 200, HorizontalAlignment.Left);

            lvItems.Columns.Add("Start", 150, HorizontalAlignment.Left);
            lvItems.Columns.Add("End", 150, HorizontalAlignment.Left);
            lvItems.Columns.Add("RetentionDate", 150, HorizontalAlignment.Left);
            lvItems.Columns.Add("DateTimeCreated", 150, HorizontalAlignment.Left);

            lvItems.Columns.Add("LastModifiedName", 150, HorizontalAlignment.Left);
            lvItems.Columns.Add("LastModifiedTime", 150, HorizontalAlignment.Left);
 
            lvItems.Columns.Add("AppointmentType", 150, HorizontalAlignment.Left);
            lvItems.Columns.Add("AppointmentState", 150, HorizontalAlignment.Left);
 
            lvItems.Columns.Add("IsAllDayEvent", 100, HorizontalAlignment.Left);
            lvItems.Columns.Add("IsCancelled", 100, HorizontalAlignment.Left);
            lvItems.Columns.Add("IsRecurring", 100, HorizontalAlignment.Left);
            lvItems.Columns.Add("IsReminderSet", 100, HorizontalAlignment.Left);

            lvItems.Columns.Add("IsOnlineMeeting", 100, HorizontalAlignment.Left);
            lvItems.Columns.Add("IsResend", 100, HorizontalAlignment.Left);
            lvItems.Columns.Add("IsDraft", 100, HorizontalAlignment.Left);

            lvItems.Columns.Add("Size", 70, HorizontalAlignment.Left);
            lvItems.Columns.Add("Attatch", 80, HorizontalAlignment.Left);


            lvItems.Columns.Add("PidLidAppointmentRecur ", 100, HorizontalAlignment.Left);
            lvItems.Columns.Add("PidLidClientIntent ", 100, HorizontalAlignment.Left);
            lvItems.Columns.Add("ClientInfoString ", 100, HorizontalAlignment.Left); 
            lvItems.Columns.Add("LogTriggerAction ", 100, HorizontalAlignment.Left);

            lvItems.Columns.Add("IsHidden", 50, HorizontalAlignment.Left);
            lvItems.Columns.Add("FolderPath", 200, HorizontalAlignment.Left);

            lvItems.Columns.Add("StoreEntryId", 250, HorizontalAlignment.Left);
            lvItems.Columns.Add("UniqueId", 250, HorizontalAlignment.Left);
            //lvItems.Columns.Add("ChangeKey", 250, HorizontalAlignment.Left);

        }

      

        private void ConfigureListView_Message(ref ListView lvItems, string SearchType)
        {

            lvItems.Clear();
            lvItems.View = View.Details;
            lvItems.GridLines = true;
            //lvItems.Dock = DockStyle.Fill;

            if (SearchType == "Direct")
                lvItems.Columns.Add("Count", 100, HorizontalAlignment.Left);
            else
                lvItems.Columns.Add("Frame:Count", 100, HorizontalAlignment.Left);

            lvItems.Columns.Add("Subject", 170, HorizontalAlignment.Left);
            lvItems.Columns.Add("Class", 150, HorizontalAlignment.Left);


            lvItems.Columns.Add("DisplayTo", 100, HorizontalAlignment.Left);
            lvItems.Columns.Add("DisplayCc", 100, HorizontalAlignment.Left);

            lvItems.Columns.Add("ICalUid", 200, HorizontalAlignment.Left);
            lvItems.Columns.Add("CleanGlobalObjectId", 200, HorizontalAlignment.Left);
            lvItems.Columns.Add("GlobalObjectId", 200, HorizontalAlignment.Left);
 
            lvItems.Columns.Add("RetentionDate", 150, HorizontalAlignment.Left);
            lvItems.Columns.Add("DateTimeCreated", 150, HorizontalAlignment.Left);

            lvItems.Columns.Add("LastModifiedName", 150, HorizontalAlignment.Left);
            lvItems.Columns.Add("LastModifiedTime", 150, HorizontalAlignment.Left);

            lvItems.Columns.Add("IsResend", 100, HorizontalAlignment.Left);
            lvItems.Columns.Add("IsDraft", 100, HorizontalAlignment.Left);

            lvItems.Columns.Add("Size", 70, HorizontalAlignment.Left);
            lvItems.Columns.Add("Attatch", 80, HorizontalAlignment.Left);

            lvItems.Columns.Add("PidLidAppointmentRecur ", 100, HorizontalAlignment.Left);
            lvItems.Columns.Add("PidLidClientIntent ", 100, HorizontalAlignment.Left);
            lvItems.Columns.Add("dispidCalLogClientInfoString ", 100, HorizontalAlignment.Left);

            lvItems.Columns.Add("LogTriggerAction ", 100, HorizontalAlignment.Left);

            lvItems.Columns.Add("FolderPath", 250, HorizontalAlignment.Left);

            lvItems.Columns.Add("StoreEntryId", 250, HorizontalAlignment.Left);
            lvItems.Columns.Add("UniqueId", 250, HorizontalAlignment.Left);
            //lvItems.Columns.Add("ChangeKey", 250, HorizontalAlignment.Left);


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
                if (this.chkUID.Checked == true)
                    AddCondition(ref searchFilterCollection, AppointmentSchema.ICalUid, this.txtUID.Text.Trim(), this.cmboUidConditional.Text); 
                if (this.chkClass.Checked == true)
                    AddCondition(ref searchFilterCollection, AppointmentSchema.ItemClass, this.cmboClass.Text.Trim(), cmboClassConditional.Text);
                if (this.chkSubject.Checked == true)
                    AddCondition(ref searchFilterCollection, AppointmentSchema.Subject, this.txtSubject.Text.Trim(), cmboSubjectConditional.Text); 
                if (this.chkTo.Checked == true)
                    AddCondition(ref searchFilterCollection, AppointmentSchema.DisplayTo, this.txtTo.Text.Trim(), cmboToConditional.Text); 
                if (this.chkCC.Checked == true)
                    AddCondition(ref searchFilterCollection, AppointmentSchema.DisplayCc, this.txtCC.Text.Trim(), cmboCCConditional.Text); 
                if (this.chkBody.Checked == true)
                    AddCondition(ref searchFilterCollection, AppointmentSchema.Body, this.txtBody.Text.Trim(), cmboBodyConditional.Text);


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
                    if (cmboLogicalOperation.Text == "And")
                        searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, searchFilterCollection.ToArray());
                    if (cmboLogicalOperation.Text == "Or")
                        searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.Or, searchFilterCollection.ToArray());
 
                    oFindItemsResults = _CurrentService.FindItems(oFolderId, searchFilter, oItemView);
                }
 
            }

            return oFindItemsResults;
        }

        private bool AddSearchResultsToListViews(FindItemsResults<Item> oFindItemsResults, int iCountMore)
        {
            bool bRet = false;

            lvItemsMessages.Visible = false;
            lvItems.Visible = false;

            ListViewItem oListItem = null;

            int iCount = 0;
 
            oListItem = null;
 
            iCount = 0;
            foreach (Item oItem in oFindItemsResults.Items)
            {


                if (oItem.ItemClass.ToUpper().StartsWith("IPM.APPOINTMENT"))
                {

                    iCount++;
                     
                    CalendarData oCalendarData = new CalendarData();
                    Appointment oAppointment = oCalendarData.GetAppointment(oItem.Service, oItem.Id);
                    oCalendarData.SetAppointmentData(oAppointment);
 

                    if (this.cmboSearchType.Text == "Direct")
                        oListItem = new ListViewItem(iCount.ToString(), 0);
                    else
                        oListItem = new ListViewItem(iCountMore.ToString() + ":" + iCount.ToString(), 0);

                    //CalendarData oCalendarData = new CalendarData();
                    //oCalendarData.SetAppointmentData(oAppointment);

                    oListItem.SubItems.Add(oCalendarData._Subject);
                    oListItem.SubItems.Add(oCalendarData._ItemClass);
                    oListItem.SubItems.Add(oCalendarData._Organizer_Address);

                    oListItem.SubItems.Add(oCalendarData._DisplayTo);
                    oListItem.SubItems.Add(oCalendarData._DisplayCc);
                    oListItem.SubItems.Add(oCalendarData._RequiredAttendees);
                    oListItem.SubItems.Add(oCalendarData._OptionalAttendees);
                    oListItem.SubItems.Add(oCalendarData._ICalUid);

                    oListItem.SubItems.Add(oCalendarData._PidLidCleanGlobalObjectId);
                    oListItem.SubItems.Add(oCalendarData._PidLidGlobalObjectId);

                    oListItem.SubItems.Add(oCalendarData._Start);
                    oListItem.SubItems.Add(oCalendarData._End);

                    oListItem.SubItems.Add(oCalendarData._RetentionDate);
                    oListItem.SubItems.Add(oCalendarData._DateTimeCreated);

                    oListItem.SubItems.Add(oCalendarData._LastModifiedName);
                    oListItem.SubItems.Add(oCalendarData._LastModifiedTime);

                    oListItem.SubItems.Add(oCalendarData._AppointmentType);
                    oListItem.SubItems.Add(oCalendarData._AppointmentState);

                    oListItem.SubItems.Add(oCalendarData._IsAllDayEvent);
                    oListItem.SubItems.Add(oCalendarData._IsCancelled);
                    oListItem.SubItems.Add(oCalendarData._IsRecurring);
                    oListItem.SubItems.Add(oCalendarData._IsReminderSet);

                    oListItem.SubItems.Add(oCalendarData._IsOnlineMeeting);
                    oListItem.SubItems.Add(oCalendarData._IsResend);
                    oListItem.SubItems.Add(oCalendarData._IsDraft);

                    oListItem.SubItems.Add(oCalendarData._Size);
                    oListItem.SubItems.Add(oCalendarData._HasAttachments);

                    oListItem.SubItems.Add(oCalendarData._PidLidAppointmentRecur);
                    oListItem.SubItems.Add(oCalendarData._PidLidClientIntent);
                    oListItem.SubItems.Add(oCalendarData._ClientInfoString);
                    oListItem.SubItems.Add(oCalendarData._LogTriggerAction);

                    oListItem.SubItems.Add(oCalendarData._IsHidden);

                    oListItem.SubItems.Add(oCalendarData._FolderPath);
                    oListItem.SubItems.Add(oCalendarData._StoreEntryId);
                    oListItem.SubItems.Add(oCalendarData._UniqueId);
 
                    //


                 

                    oListItem.Tag = new ItemTag(oAppointment.Id, oAppointment.ItemClass);
                    lvItems.Items.AddRange(new ListViewItem[] { oListItem }); ;
                    oListItem = null;

                    bRet = true;

                }

                if (oItem.ItemClass.ToUpper().StartsWith("IPM.NOTE"))
                {
                    iCount++;

                    if (this.cmboSearchType.Text == "Direct")
                        oListItem = new ListViewItem(iCount.ToString(), 0);
                    else
                        oListItem = new ListViewItem(iCountMore.ToString() + ":" + iCount.ToString(), 0);

                    oListItem.SubItems.Add(oItem.Subject);
                    oListItem.SubItems.Add(oItem.ItemClass);

                    oListItem.SubItems.Add(oItem.DisplayTo);
                    oListItem.SubItems.Add(oItem.DisplayCc);

                    oListItem.SubItems.Add("");  // ICalUid

                    byte[] bytearrVal;
                    if (oItem.TryGetProperty(PidLidCleanGlobalObjectId, out bytearrVal))  // CleanGlobalObjectId
                        oListItem.SubItems.Add(Convert.ToBase64String(bytearrVal));  // reverse: Convert.FromBase64String(string data)
                    else
                        oListItem.SubItems.Add("");


                    if (oItem.TryGetProperty(PidLidGlobalObjectId, out bytearrVal))  // GlobalObjectId
                        oListItem.SubItems.Add(Convert.ToBase64String(bytearrVal));  // reverse: Convert.FromBase64String(string data)
                    else
                        oListItem.SubItems.Add("");
 
                    oListItem.SubItems.Add(oItem.RetentionDate.ToString());
                    oListItem.SubItems.Add(oItem.DateTimeCreated.ToString());
                    oListItem.SubItems.Add(oItem.LastModifiedName);
                    oListItem.SubItems.Add(oItem.LastModifiedTime.ToString());

                    oListItem.SubItems.Add(""); //oItem.IsReminderSet.ToString());

                    oListItem.SubItems.Add(oItem.IsResend.ToString());
                    oListItem.SubItems.Add(oItem.IsDraft.ToString());

                    oListItem.SubItems.Add(oItem.Size.ToString());
                    oListItem.SubItems.Add(oItem.HasAttachments.ToString());


                    byte[] byteArrVal;
                    if (oItem.TryGetProperty(PidLidAppointmentRecur, out byteArrVal))
                        oListItem.SubItems.Add(ConversionHelper.GetStringFromBytes(byteArrVal));
                    else
                        oListItem.SubItems.Add("");

                    int lVal;
                    if (oItem.TryGetProperty(PidLidClientIntent, out lVal))
                        oListItem.SubItems.Add(lVal.ToString());
                    else
                        oListItem.SubItems.Add("");

                    string sVal;
                    if (oItem.TryGetProperty(ClientInfoString, out sVal))
                        oListItem.SubItems.Add(sVal);
                    else
                        oListItem.SubItems.Add("");

                    string sVal2;
                    if (oItem.TryGetProperty(LogTriggerAction, out sVal2))
                        oListItem.SubItems.Add(sVal2);
                    else
                        oListItem.SubItems.Add("");

                    if (oItem.StoreEntryId != null)
                        oListItem.SubItems.Add(ConversionHelper.GetStringFromBytes(oItem.StoreEntryId));
                    else
                        oListItem.SubItems.Add("");

                  
                    string sFolderPath = string.Empty;
                    if (EwsFolderHelper.GetFolderPath(_CurrentService, oItem.ParentFolderId, ref sFolderPath))
                        oListItem.SubItems.Add(sFolderPath);
                    else
                        oListItem.SubItems.Add("");

                    oListItem.SubItems.Add(oItem.Id.UniqueId);
                    //oListItem.SubItems.Add(oItem.Id.ChangeKey);

                    oListItem.Tag = new ItemTag(oItem.Id, oItem.ItemClass);
                    lvItemsMessages.Items.AddRange(new ListViewItem[] { oListItem }); ;
                    oListItem = null;
 
                    bRet = true;

                }

            }

            oListItem = null;

            lvItemsMessages.Visible = true;
            lvItems.Visible = true;


            return bRet;
        }

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

                    oItemView.PropertySet =  GetPropertySet();
 
                    oItemView.OrderBy.Add(AppointmentSchema.LastModifiedTime, SortDirection.Descending);

                    //oItemView.Traversal = ItemTraversal.Shallow; // shallow, associated, soft deleted

                    SetSearchDepth(ref oItemView);

                    FindItemsResults<Item> oFindItemsResults = null;
                    oFindItemsResults = DoSearch(oFolderId, ref oItemView);


                    ConfigureListView_Calendar(ref lvItems, cmboSearchType.Text.Trim());

                    ConfigureListView_Message(ref lvItemsMessages, cmboSearchType.Text.Trim());

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
 
                    int iCountMore = 0;

                    while (MoreItems)
                    {
                        iCountMore++;

                         
                        ItemView oItemView = new ItemView(iPageSize, offset, OffsetBasePoint.Beginning);

   
                        oItemView.PropertySet = GetPropertySet();

                      
                        oItemView.OrderBy.Add(ContactSchema.LastModifiedTime, SortDirection.Ascending);
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

            PropertySet oPropertySet = new PropertySet(BasePropertySet.FirstClassProperties);

            oPropertySet.Add(PidLidAppointmentRecur);
            oPropertySet.Add(PidLidClientIntent);
            oPropertySet.Add(ClientInfoString);

            oPropertySet.Add(LogTriggerAction);
 
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

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvItems_DoubleClick(object sender, EventArgs e)
        {
            DisplayItem();
        }

        private void DisplayItem()
        {
            if (lvItems.SelectedItems.Count > 0)
            {
      
                string sId = lvItems.SelectedItems[0].SubItems[34].Text;
                ItemId oItemId = new ItemId(sId);


                List<ItemId> item = new List<ItemId>();
                item.Add(oItemId);

                ItemsContentForm.Show(
                    "Displaying item",
                    item,
                    _CurrentService,
                    this);
            }
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

        // 
        private CalendarData GetRecurrenceInfo(Appointment oAppointment)
        {
            CalendarData oCalendarData = new CalendarData();

            string StartingDateRange = string.Empty;
            string RecurrStartTime = string.Empty;
            string RecurrEndTime = string.Empty;
            string RecurrencePattern = string.Empty;
            string RecurrencePatternInterval = string.Empty;
            string RecurrencePatternDaysOfTheWeek = string.Empty;
            string RecurrMonthlyPatternDayOfMonth = string.Empty;
            string RecurrMonthlyPatternEveryMonths = string.Empty;
            string RecurrDayOfTheWeekIndex  = string.Empty;
            string RecurrDayOfWeek = string.Empty;
            string RecurrInterval  = string.Empty;
            string RecurrYearlyOnSpecificDay  = string.Empty;                   
            string RecurrYearlyOnSpecificDayForMonthOf  = string.Empty;
            string RecurrYearlyOnDayPatternDayOfWeekIndex = string.Empty;                 
            string RecurrYearlyOnDayPatternDayOfWeek  = string.Empty;                   
            string RecurrYearlyOnDayPatternMonth  = string.Empty;
            string RangeHasEnd  = string.Empty;
            string RangeNumberOccurrences  = string.Empty;
            string RangeEndByDate  = string.Empty;
 
            if (oAppointment.Recurrence != null)
            {

                StartingDateRange  = oAppointment.Recurrence.StartDate.ToString();
                RecurrStartTime = oAppointment.Recurrence.StartDate.ToString();

                if (oAppointment.Recurrence.EndDate.HasValue)
                    RecurrEndTime= oAppointment.Recurrence.EndDate.ToString();
                else
                    RecurrEndTime = oAppointment.Recurrence.StartDate.ToString();

                if (oAppointment.Recurrence is Recurrence.DailyPattern)
                {
                    RecurrencePattern = "DailyPattern";
                    Recurrence.DailyPattern o = (Recurrence.DailyPattern)oAppointment.Recurrence;

                    RecurrencePatternInterval = o.Interval.ToString();

                    o = null; 
                }

                if (oAppointment.Recurrence is Recurrence.WeeklyPattern)
                {
                    RecurrencePattern = "WeeklyPattern";
                    Recurrence.WeeklyPattern o = (Recurrence.WeeklyPattern)oAppointment.Recurrence;
 
                    RecurrencePatternInterval = o.Interval.ToString();
                    
                     

                    foreach (DayOfTheWeek dotw in o.DaysOfTheWeek)
                    {
                        switch(dotw)
                        {
                            case DayOfTheWeek.Sunday:
                                RecurrencePatternDaysOfTheWeek += "Sunday,";
                                break;
                            case DayOfTheWeek.Monday:
                                RecurrencePatternDaysOfTheWeek += "Monday,";
                                break;
                            case DayOfTheWeek.Tuesday:
                                RecurrencePatternDaysOfTheWeek += "Tuesday,";
                                break;
                            case DayOfTheWeek.Wednesday:
                                RecurrencePatternDaysOfTheWeek += "Wednesday,";
                                break;
                            case DayOfTheWeek.Thursday:
                                RecurrencePatternDaysOfTheWeek += "Thursday,";
                                break;
                            case DayOfTheWeek.Friday:
                                RecurrencePatternDaysOfTheWeek += "Friday,";
                                break;
                            case DayOfTheWeek.Saturday:
                                RecurrencePatternDaysOfTheWeek += "Saturday,";
                                break;
                            default:
                                break;
                        }
                    }

                    if (RecurrencePatternDaysOfTheWeek.EndsWith(","))
                        RecurrencePatternDaysOfTheWeek.Remove(RecurrencePatternDaysOfTheWeek.Length, 1);
                    o = null; 
      
                }

               if (oAppointment.Recurrence is Recurrence.MonthlyPattern)
               {
                   RecurrencePattern = "MonthlyPattern";

                   Recurrence.MonthlyPattern o = (Recurrence.MonthlyPattern)oAppointment.Recurrence;
                   RecurrMonthlyPatternDayOfMonth = o.DayOfMonth.ToString();
                   RecurrMonthlyPatternEveryMonths = o.Interval.ToString();

               }

                if (oAppointment.Recurrence is Recurrence.RelativeMonthlyPattern)
                {
                    RecurrencePattern = "RelativeMonthlyPattern";
                     
                    Recurrence.RelativeMonthlyPattern o = (Recurrence.RelativeMonthlyPattern)oAppointment.Recurrence;
  
                    RecurrDayOfTheWeekIndex = o.DayOfTheWeekIndex.ToString();
                    RecurrDayOfWeek= o.DayOfTheWeek.ToString();
                    RecurrInterval = o.Interval.ToString();
                     
                }

                if (oAppointment.Recurrence is Recurrence.YearlyPattern)
                {
                    RecurrencePattern = "YearlyPattern";

                    Recurrence.YearlyPattern o = (Recurrence.YearlyPattern)oAppointment.Recurrence;

                    RecurrYearlyOnSpecificDay = o.DayOfMonth.ToString();
                   
                    RecurrYearlyOnSpecificDayForMonthOf = Enum.GetName(typeof(Month), o.Month);

                    o = null;
                }

                if (oAppointment.Recurrence is Recurrence.RelativeYearlyPattern)
                {
                    RecurrencePattern = "RelativeYearlyPattern";
 
                    Recurrence.RelativeYearlyPattern o = (Recurrence.RelativeYearlyPattern)oAppointment.Recurrence;
 
                    RecurrYearlyOnDayPatternDayOfWeekIndex= o.DayOfTheWeekIndex.ToString();
                    RecurrYearlyOnDayPatternDayOfWeekIndex = Enum.GetName(typeof(DayOfTheWeekIndex), o.DayOfTheWeekIndex);                     
                    RecurrYearlyOnDayPatternDayOfWeek = Enum.GetName(typeof(DayOfTheWeek), o.DayOfTheWeek);                    
                    RecurrYearlyOnDayPatternMonth = Enum.GetName(typeof(Month), o.Month);
                     
                    o = null;
                }
  
                // Range
                if (oAppointment.Recurrence.HasEnd == true)
                {
                    RangeHasEnd = oAppointment.Recurrence.HasEnd.ToString();
                    RangeNumberOccurrences = "";
                    RangeEndByDate = "";
                    //RangeEndByDate = oAppointment.Recurrence.EndDate.Value;  // ??
                }
                else
                {

                    if (oAppointment.Recurrence.NumberOfOccurrences.HasValue )
                    {   
                        RangeNumberOccurrences = oAppointment.Recurrence.NumberOfOccurrences.ToString();
                    }
                    else
                    {
                        RangeNumberOccurrences = "";
                        if (oAppointment.Recurrence.EndDate.HasValue )
                        {
                            RangeEndByDate  = oAppointment.Recurrence.EndDate.ToString();
                        }
                    }
                }
        }

                           if (oAppointment.Recurrence is Recurrence.MonthlyPattern)
               {
                   RecurrencePattern = "MonthlyPattern";

                   Recurrence.MonthlyPattern o = (Recurrence.MonthlyPattern)oAppointment.Recurrence;
                   RecurrMonthlyPatternDayOfMonth = o.DayOfMonth.ToString();
                   RecurrMonthlyPatternEveryMonths = o.Interval.ToString();

               }

                if (oAppointment.Recurrence is Recurrence.RelativeMonthlyPattern)
                {
                    RecurrencePattern = "RelativeMonthlyPattern";
                     
                    Recurrence.RelativeMonthlyPattern o = (Recurrence.RelativeMonthlyPattern)oAppointment.Recurrence;
  
                    RecurrDayOfTheWeekIndex = o.DayOfTheWeekIndex.ToString();
                    RecurrDayOfWeek= o.DayOfTheWeek.ToString();
                    RecurrInterval = o.Interval.ToString();
                     
                }

                if (oAppointment.Recurrence is Recurrence.YearlyPattern)
                {
                    RecurrencePattern = "YearlyPattern";

                    Recurrence.YearlyPattern o = (Recurrence.YearlyPattern)oAppointment.Recurrence;

                    RecurrYearlyOnSpecificDay = o.DayOfMonth.ToString();
                   
                    RecurrYearlyOnSpecificDayForMonthOf = Enum.GetName(typeof(Month), o.Month);

                    o = null;
                }

                if (oAppointment.Recurrence is Recurrence.RelativeYearlyPattern)
                {
                    RecurrencePattern = "RelativeYearlyPattern";
 
                    Recurrence.RelativeYearlyPattern o = (Recurrence.RelativeYearlyPattern)oAppointment.Recurrence;
 
                    RecurrYearlyOnDayPatternDayOfWeekIndex= o.DayOfTheWeekIndex.ToString();
                    RecurrYearlyOnDayPatternDayOfWeekIndex = Enum.GetName(typeof(DayOfTheWeekIndex), o.DayOfTheWeekIndex);                     
                    RecurrYearlyOnDayPatternDayOfWeek = Enum.GetName(typeof(DayOfTheWeek), o.DayOfTheWeek);                    
                    RecurrYearlyOnDayPatternMonth = Enum.GetName(typeof(Month), o.Month);
                     
                    o = null;
                }
  
                // Range
                if (oAppointment.Recurrence.HasEnd == true)
                {
                    RangeHasEnd = oAppointment.Recurrence.HasEnd.ToString();
                    RangeNumberOccurrences = "";
                    RangeEndByDate = "";
                    //RangeEndByDate = oAppointment.Recurrence.EndDate.Value;  // ??
                }
                else
                {

                    if (oAppointment.Recurrence.NumberOfOccurrences.HasValue )
                    {   
                        RangeNumberOccurrences = oAppointment.Recurrence.NumberOfOccurrences.ToString();
                    }
                    else
                    {
                        RangeNumberOccurrences = "";
                        if (oAppointment.Recurrence.EndDate.HasValue )
                        {
                            RangeEndByDate  = oAppointment.Recurrence.EndDate.ToString();
                        }
                    }
                }

                return oCalendarData;
        }
   
    }
 
    public class CalendarExport 
    {
        private static ExtendedPropertyDefinition PidLidAppointmentRecur = new ExtendedPropertyDefinition(new Guid("00062002-0000-0000-C000-000000000046"), 0x8216, MapiPropertyType.Binary); // dispidApptRecur
        private static ExtendedPropertyDefinition PidLidClientIntent = new ExtendedPropertyDefinition(new Guid("11000E07-B51B-40D6-AF21-CAA85EDAB1D0"), 0x0015, MapiPropertyType.Integer); // dispidClientIntent

        private static ExtendedPropertyDefinition ClientInfoString = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x000B, MapiPropertyType.String); //  
        private static ExtendedPropertyDefinition LogTriggerAction = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x0006, MapiPropertyType.String); //  

        private static ExtendedPropertyDefinition PidLidCleanGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0023, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PidLidGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0003, MapiPropertyType.Binary);

        public static bool SaveToFile(string sFile, ExchangeService _Service, Item[] oItems)
        {
            bool bRet = true;



            return bRet;
        }

        public static Appointment LoadProperties(ExchangeService _Service, ItemId oItemId)
        {
            Appointment oAppointment = Appointment.Bind(_Service, oItemId);

            return oAppointment;
        }

 
    }

    public class CalendarData
    {       
        private static ExtendedPropertyDefinition Prop_PR_FOLDER_PATH = new ExtendedPropertyDefinition(0x66B5, MapiPropertyType.String);   // Folder Path - PR_Folder_Path
        //private static ExtendedPropertyDefinition Prop_PR_FOLDER_TYPE = new ExtendedPropertyDefinition(0x3601, MapiPropertyType.Integer);  // PR_FOLDER_TYPE 0x3601 (13825)

        private static ExtendedPropertyDefinition PidLidAppointmentRecur = new ExtendedPropertyDefinition(new Guid("00062002-0000-0000-C000-000000000046"), 0x8216, MapiPropertyType.Binary); // dispidApptRecur
        private static ExtendedPropertyDefinition PidLidClientIntent = new ExtendedPropertyDefinition(new Guid("11000E07-B51B-40D6-AF21-CAA85EDAB1D0"), 0x0015, MapiPropertyType.Integer); // dispidClientIntent

        private static ExtendedPropertyDefinition ClientInfoString = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x000B, MapiPropertyType.String); //  
        private static ExtendedPropertyDefinition LogTriggerAction = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x0006, MapiPropertyType.String); //  

        private static ExtendedPropertyDefinition PidLidCleanGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0023, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PidLidGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0003, MapiPropertyType.Binary);

        private static ExtendedPropertyDefinition Prop_PR_POLICY_TAG = new ExtendedPropertyDefinition(0x301B, MapiPropertyType.Binary);  // PR_POLICY_TAG 0x3019   Data type: PtypBinary, 0x0102
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_FLAGS = new ExtendedPropertyDefinition(0x301D, MapiPropertyType.Integer);   // PR_RETENTION_FLAGS 0x301D   
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_PERIOD = new ExtendedPropertyDefinition(0x301A, MapiPropertyType.Integer);  // PR_RETENTION_PERIOD 0x301A    
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_DATE = new ExtendedPropertyDefinition(0x301C, MapiPropertyType.SystemTime); // Prop_PR_RETENTION_DATE 0x301C    
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_TAG = new ExtendedPropertyDefinition(0x3018, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_PERIOD = new ExtendedPropertyDefinition(0x301E, MapiPropertyType.Integer); // Prop_PR_RETENTION_DATE 0x301C    
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_DATE = new ExtendedPropertyDefinition(0x301F, MapiPropertyType.SystemTime);
        private static ExtendedPropertyDefinition Prop_PR_ENTRYID = new ExtendedPropertyDefinition(0x0FFF, MapiPropertyType.Binary);  // PidTagEntryId, PidTagMemberEntryId, ptagEntryId
        private static ExtendedPropertyDefinition Prop_PR_STORE_ENTRYID = new ExtendedPropertyDefinition(0x0FB0, MapiPropertyType.Binary);  // PidTagStoreEntryId

        private static ExtendedPropertyDefinition Prop_PR_IS_HIDDEN = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.Boolean);

        public string _UniqueId = string.Empty;
        public string _FolderPath = string.Empty;
        public string _Organizer_Address = string.Empty;
        public string _ParentFolderId = string.Empty;
         
        public string _Subject = string.Empty;
        public string _DisplayTo = string.Empty;
         
        public string _ICalUid = string.Empty;
        public string _DisplayCc = string.Empty;

        public string _RequiredAttendees = string.Empty;
        public string _OptionalAttendees = string.Empty;

        public string _DateTimeCreated = string.Empty;

        public string _LastModifiedName = string.Empty;
        public string _LastModifiedTime = string.Empty;
        public string _HasAttachments = string.Empty;
        public string _ItemClass = string.Empty;
        public string _Start = string.Empty;
        public string _End = string.Empty;

        public string _IsAllDayEvent = string.Empty;
        public string _IsCancelled = string.Empty;
        public string _AppointmentState = string.Empty;
        public string _AppointmentType = string.Empty;

        public string _IsRecurring = string.Empty;
        public string _IsReminderSet = string.Empty;
        public string _IsOnlineMeeting = string.Empty;
        public string _RetentionDate = string.Empty;

        public string _ICalRecurrenceId = string.Empty;
        public string _IsResend = string.Empty;
        public string _IsDraft = string.Empty;
        public string _Size = string.Empty;
        public string _StoreEntryId = string.Empty;

        public string _PidLidAppointmentRecur = string.Empty;
        public string _PidLidClientIntent = string.Empty;
        public string _ClientInfoString = string.Empty;
        public string _LogTriggerAction = string.Empty;
        public string _PidLidCleanGlobalObjectId = string.Empty;
        public string _PidLidGlobalObjectId = string.Empty;
        public string _IsHidden = string.Empty;

        public string _AppointmentReplyTime = string.Empty;
        public string _AllowNewTimeProposal = string.Empty;
        public string _AllowedResponseActions = string.Empty;
        public string _AdjacentMeetingCount = string.Empty;
        public string _AppointmentSequenceNumber = string.Empty;
        public string _Body = string.Empty;
        public string _Categories = string.Empty;
        public string _ConferenceType = string.Empty;
        public string _ConflictingMeetingCount = string.Empty;
        public string _ConflictingMeetings = string.Empty;
        public string _Culture = string.Empty;
        public string _DateTimeReceived = string.Empty;
        public string _Duration = string.Empty;
        public string _EffectiveRights = string.Empty;
        public string _ICalDateTimeStamp = string.Empty;
        public string _Importance = string.Empty;
        public string _InReplyTo = string.Empty;
        public string _InternetMessageHeaders = string.Empty;                         
        public string _IsResponseRequested = string.Empty;
        public string _IsSubmitted = string.Empty;
        public string _IsUnmodified = string.Empty;
        public string _LegacyFreeBusyStatus = string.Empty;
        public string _Location = string.Empty;
        public string _MeetingRequestWasSent = string.Empty;
        public string _MeetingWorkspaceUrl = string.Empty;
        public string _MimeContent   = string.Empty;          
        public string _MyResponseType = string.Empty;
        public string _NetShowUrl = string.Empty;  
        public string _ModifiedOccurrences = string.Empty;
        public string _ReminderDueBy = string.Empty;
        public string _ReminderMinutesBeforeStart = string.Empty;
        public string _Resources  = string.Empty;     
        public string _StartTimeZone = string.Empty;
        public string _Sensitivity = string.Empty;
        public string _When  = string.Empty;

        public string _Recurr_StartingDateRange = string.Empty;
        public string _Recurr_RecurrStartTime = string.Empty;
        public string _Recurr_RecurrEndTime = string.Empty;
        public string _Recurr_RecurrencePattern = string.Empty;
        public string _Recurr_RecurrencePatternInterval = string.Empty;
        public string _Recurr_RecurrencePatternDaysOfTheWeek = string.Empty;
        public string _Recurr_RecurrMonthlyPatternDayOfMonth = string.Empty;
        public string _Recurr_RecurrMonthlyPatternEveryMonths = string.Empty;
        public string _Recurr_RecurrDayOfTheWeekIndex = string.Empty;
        public string _Recurr_RecurrDayOfWeek = string.Empty;
        public string _Recurr_RecurrInterval = string.Empty;
        public string _Recurr_RecurrYearlyOnSpecificDay = string.Empty;
        public string _Recurr_RecurrYearlyOnSpecificDayForMonthOf = string.Empty;
        public string _Recurr_RecurrYearlyOnDayPatternDayOfWeekIndex = string.Empty;
        public string _Recurr_RecurrYearlyOnDayPatternDayOfWeek = string.Empty;
        public string _Recurr_RecurrYearlyOnDayPatternMonth = string.Empty;
        public string _Recurr_RangeHasEnd = string.Empty;
        public string _Recurr_RangeNumberOccurrences = string.Empty;
        public string _Recurr_RangeEndByDate = string.Empty;

        public Appointment GetAppointment(ExchangeService oExchangeService, ItemId oItemId)
        {
            Appointment oAppointment = Appointment.Bind(oExchangeService, oItemId, GetCalendarPropset());
            CalendarData oCalendarData = new CalendarData();
            oCalendarData.SetAppointmentData(oAppointment);
            return oAppointment;
        }
 
        public void SetAppointmentData(Appointment oAppointment)
        {
            // Appointment:
            byte[] byteArrVal;
            StringBuilder oSB = new StringBuilder();

            _Subject = oAppointment.Subject;
            _ItemClass = oAppointment.ItemClass;
            _Organizer_Address = oAppointment.Organizer.Address;
            _DisplayTo = oAppointment.DisplayTo;
            _DisplayCc = oAppointment.DisplayCc;

            _Subject = oAppointment.Subject;
            _Subject = oAppointment.Subject;


            if (oAppointment.RequiredAttendees != null)
            {
                StringBuilder sbRequired = new StringBuilder();
                foreach (Attendee oAttendee in oAppointment.RequiredAttendees)
                    sbRequired.AppendFormat("{0} <{1}>;", oAttendee.Name, oAttendee.Address);
                _RequiredAttendees = sbRequired.ToString();
            }
            else
                _RequiredAttendees = string.Empty;


            if (oAppointment.OptionalAttendees != null)
            {
                StringBuilder sbOptional = new StringBuilder();
                foreach (Attendee oAttendee in oAppointment.OptionalAttendees)
                    sbOptional.AppendFormat("{0} <{1}>;", oAttendee.Name, oAttendee.Address);
                _OptionalAttendees = sbOptional.ToString();
            }
            else
            { 
                _OptionalAttendees = string.Empty;
            }

            _ICalUid = oAppointment.ICalUid;         

            byte[] bytearrVal;
            if (oAppointment.TryGetProperty(PidLidCleanGlobalObjectId, out bytearrVal))  // CleanGlobalObjectId
                _PidLidCleanGlobalObjectId = Convert.ToBase64String(bytearrVal);  // reverse: Convert.FromBase64String(string data)
            else
                _PidLidCleanGlobalObjectId = "";


            if (oAppointment.TryGetProperty(PidLidGlobalObjectId, out bytearrVal))  // GlobalObjectId
                _PidLidGlobalObjectId = Convert.ToBase64String(bytearrVal);  // reverse: Convert.FromBase64String(string data)
            else
                _PidLidGlobalObjectId = "";

            _Start = oAppointment.Start.ToString();
            _End = oAppointment.End.ToString();

 

            _DateTimeCreated = oAppointment.DateTimeCreated.ToString();

            _Start = oAppointment.Start.ToString();
            _End = oAppointment.End.ToString();

            _LastModifiedName = oAppointment.LastModifiedName;
            _LastModifiedTime = oAppointment.LastModifiedTime.ToString();

            _AppointmentType = oAppointment.AppointmentType.ToString();
            _AppointmentState = oAppointment.AppointmentState.ToString();

            _IsAllDayEvent = oAppointment.IsAllDayEvent.ToString();
            _IsCancelled = oAppointment.IsCancelled.ToString();
            _IsRecurring = oAppointment.IsRecurring.ToString();
            _IsReminderSet = oAppointment.IsReminderSet.ToString();
 
            _IsOnlineMeeting = oAppointment.IsOnlineMeeting.ToString();
            _IsResend = oAppointment.IsResend.ToString();
            _IsDraft = oAppointment.IsDraft.ToString();

            _Size = oAppointment.Size.ToString();
            _HasAttachments = oAppointment.HasAttachments.ToString();


 
            if (oAppointment.TryGetProperty(PidLidAppointmentRecur, out byteArrVal))
                _PidLidAppointmentRecur =  ConversionHelper.GetStringFromBytes(byteArrVal);
            else
                _PidLidAppointmentRecur = "";

            int lVal;
            if (oAppointment.TryGetProperty(PidLidClientIntent, out lVal))
                _PidLidClientIntent = lVal.ToString();
            else
                _PidLidClientIntent = "";

            string sVal;
            if (oAppointment.TryGetProperty(ClientInfoString, out sVal))
                _ClientInfoString = sVal;
            else
                _ClientInfoString = "";

            string sVal2;
            if (oAppointment.TryGetProperty(LogTriggerAction, out sVal2))
                _LogTriggerAction = sVal2;
            else
                _LogTriggerAction = "";
 
             
            string sFolderPath = string.Empty;
            if (EwsFolderHelper.GetFolderPath(oAppointment.Service, oAppointment.ParentFolderId, ref sFolderPath))
                _FolderPath = sFolderPath;
            else
                _FolderPath = "";

 
            //if (oAppointment.TryGetProperty(Prop_PR_STORE_ENTRYID, out byteArrVal))
            //    _StoreEntryId = ConversionHelper.GetStringFromBytes(byteArrVal);
            //else
            //    _StoreEntryId = "";

            //  ?????
            if (oAppointment.TryGetProperty(Prop_PR_ENTRYID, out byteArrVal))    
                _StoreEntryId = ConversionHelper.GetStringFromBytes(byteArrVal);
            else
                _StoreEntryId = "";

  
 
            if (oAppointment.TryGetProperty(Prop_PR_RETENTION_DATE, out byteArrVal))
                _RetentionDate = ConversionHelper.GetStringFromBytes(byteArrVal);
            else
                _RetentionDate = "";

            bool bolVal = false;
            if (oAppointment.TryGetProperty(Prop_PR_IS_HIDDEN, out bolVal))
                _RetentionDate = bolVal.ToString();
            else
                _RetentionDate = "";

            //if (oAppointment.AppointmentReplyTime != null) _AppointmentReplyTime = oAppointment.AppointmentReplyTime.ToString();   Not being returned
            try
            {
                _AllowNewTimeProposal = oAppointment.AllowNewTimeProposal.ToString();
            }
            catch (Exception ex)
            {
                _AllowNewTimeProposal = "";
            }
            //if (oAppointment.AllowNewTimeProposal != null) _AllowNewTimeProposal = oAppointment.AllowNewTimeProposal.ToString();
            _AllowedResponseActions = oAppointment.AllowedResponseActions.ToString();
            _AdjacentMeetingCount = oAppointment.AdjacentMeetingCount.ToString();
            _AppointmentSequenceNumber = oAppointment.AppointmentSequenceNumber.ToString();
            _Body = oAppointment.Body;
            _Categories = oAppointment.Categories.ToString();
            // _ConferenceType = oAppointment.ConferenceType.ToString();  Not being returned
            _ConflictingMeetingCount = oAppointment.ConflictingMeetingCount.ToString();


            if (oAppointment.ConflictingMeetings != null)
            {
                oSB = new StringBuilder();
                foreach (Appointment a in oAppointment.ConflictingMeetings)
                {
                    oSB.AppendFormat("Subject: {0}  Start: {1}  End: {2}  UniqueId: {3} \r\n", a.Subject, a.Start, a.End, a.Id.UniqueId);
                }
                _ConflictingMeetings = oSB.ToString();
            }
            else
                _ConflictingMeetings = "";

            _Culture = oAppointment.Culture.ToString();
            _DateTimeReceived = oAppointment.DateTimeReceived.ToString();
            _Duration = oAppointment.Duration.ToString();
            _EffectiveRights = oAppointment.EffectiveRights.ToString();
            _ICalDateTimeStamp = oAppointment.ICalDateTimeStamp.ToString();
            _Importance = oAppointment.Importance.ToString();
            if (oAppointment.InReplyTo != null)
                _InReplyTo = oAppointment.InReplyTo.ToString();
            if (oAppointment.InternetMessageHeaders != null)
                _InternetMessageHeaders = oAppointment.InternetMessageHeaders.ToString();

            bool boolVal = false;
            if (oAppointment.TryGetProperty(Prop_PR_IS_HIDDEN, out boolVal))
                _IsHidden = boolVal.ToString();
            else
                _IsHidden = "";

            _IsResponseRequested = oAppointment.IsResponseRequested.ToString();
            _IsSubmitted = oAppointment.IsSubmitted.ToString();
            _IsUnmodified = oAppointment.IsUnmodified.ToString();
            _LegacyFreeBusyStatus = oAppointment.LegacyFreeBusyStatus.ToString();
            if (oAppointment.Location != null)
                _Location = oAppointment.Location.ToString();
            _MeetingRequestWasSent = oAppointment.MeetingRequestWasSent.ToString();
            if (oAppointment.MeetingWorkspaceUrl != null)
                _MeetingWorkspaceUrl = oAppointment.MeetingWorkspaceUrl.ToString();
            _MimeContent   = oAppointment.MimeContent.ToString();         
            _MyResponseType = oAppointment.MyResponseType.ToString();
            if (oAppointment.NetShowUrl != null)
                _NetShowUrl = oAppointment.NetShowUrl;
           
            try
            { 
                _ReminderDueBy = oAppointment.ReminderDueBy.ToString();
            }
            catch (Exception ex)
            {
                _ReminderDueBy = "";
            }
 
            _ReminderMinutesBeforeStart = oAppointment.ReminderMinutesBeforeStart.ToString();
            

             oSB = new StringBuilder();
             foreach (Attendee oAttendee in oAppointment.Resources)
                 oSB.AppendFormat("{0} <{1}>;", oAttendee.Name, oAttendee.Address);
             _Resources = _Resources.ToString();

            _StartTimeZone = oAppointment.StartTimeZone.ToString();
            _Sensitivity = oAppointment.Sensitivity.ToString();
            if (oAppointment.When != null) 
                _When = oAppointment.When.ToString();

 
 
            //private static ExtendedPropertyDefinition Prop_PR_POLICY_TAG = new ExtendedPropertyDefinition(0x301B, MapiPropertyType.Binary);  // PR_POLICY_TAG 0x3019   Data type: PtypBinary, 0x0102
            //private static ExtendedPropertyDefinition Prop_PR_RETENTION_FLAGS = new ExtendedPropertyDefinition(0x301D, MapiPropertyType.Integer);   // PR_RETENTION_FLAGS 0x301D   
            //private static ExtendedPropertyDefinition Prop_PR_RETENTION_PERIOD = new ExtendedPropertyDefinition(0x301A, MapiPropertyType.Integer);  // PR_RETENTION_PERIOD 0x301A    
            //private static ExtendedPropertyDefinition Prop_PR_RETENTION_DATE = new ExtendedPropertyDefinition(0x301C, MapiPropertyType.SystemTime); // Prop_PR_RETENTION_DATE 0x301C    
            //private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_TAG = new ExtendedPropertyDefinition(0x3018, MapiPropertyType.Binary);
            //private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_PERIOD = new ExtendedPropertyDefinition(0x301E, MapiPropertyType.Integer); // Prop_PR_RETENTION_DATE 0x301C    
            //private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_DATE = new ExtendedPropertyDefinition(0x301F, MapiPropertyType.SystemTime);
            //private static ExtendedPropertyDefinition Prop_PR_ENTRYID = new ExtendedPropertyDefinition(0x0FFF, MapiPropertyType.Binary);  // PidTagEntryId, PidTagMemberEntryId, ptagEntryId
            //private static ExtendedPropertyDefinition Prop_PR_STORE_ENTRYID = new ExtendedPropertyDefinition(0x0FB0, MapiPropertyType.Binary);  // PidTagStoreEntryId

                    
            _UniqueId = oAppointment.Id.UniqueId;

            SetAppointmentRecurrenceData(oAppointment);
 
        }

        private void SetAppointmentRecurrenceData(Appointment oAppointment)
        { 
            //  Recurrence  -----------------------------------------------------------------------

            if (oAppointment.Recurrence != null)
            {

                _Recurr_StartingDateRange = oAppointment.Recurrence.StartDate.ToString();
                _Recurr_RecurrStartTime = oAppointment.Recurrence.StartDate.ToString();

                if (oAppointment.Recurrence.EndDate.HasValue)
                    _Recurr_RecurrEndTime = oAppointment.Recurrence.EndDate.ToString();
                else
                    _Recurr_RecurrEndTime = oAppointment.Recurrence.StartDate.ToString();

                if (oAppointment.Recurrence is Recurrence.DailyPattern)
                {
                    _Recurr_RecurrencePattern = "DailyPattern";
                    Recurrence.DailyPattern o = (Recurrence.DailyPattern)oAppointment.Recurrence;

                    _Recurr_RecurrencePatternInterval = o.Interval.ToString();

                    o = null;
                }

                if (oAppointment.Recurrence is Recurrence.WeeklyPattern)
                {
                    _Recurr_RecurrencePattern = "WeeklyPattern";
                    Recurrence.WeeklyPattern o = (Recurrence.WeeklyPattern)oAppointment.Recurrence;

                    _Recurr_RecurrencePatternInterval = o.Interval.ToString();



                    foreach (DayOfTheWeek dotw in o.DaysOfTheWeek)
                    {
                        switch (dotw)
                        {
                            case DayOfTheWeek.Sunday:
                                _Recurr_RecurrencePatternDaysOfTheWeek += "Sunday, ";
                                break;
                            case DayOfTheWeek.Monday:
                                _Recurr_RecurrencePatternDaysOfTheWeek += "Monday, ";
                                break;
                            case DayOfTheWeek.Tuesday:
                                _Recurr_RecurrencePatternDaysOfTheWeek += "Tuesday, ";
                                break;
                            case DayOfTheWeek.Wednesday:
                                _Recurr_RecurrencePatternDaysOfTheWeek += "Wednesday, ";
                                break;
                            case DayOfTheWeek.Thursday:
                                _Recurr_RecurrencePatternDaysOfTheWeek += "Thursday, ";
                                break;
                            case DayOfTheWeek.Friday:
                                _Recurr_RecurrencePatternDaysOfTheWeek += "Friday, ";
                                break;
                            case DayOfTheWeek.Saturday:
                                _Recurr_RecurrencePatternDaysOfTheWeek += "Saturday, ";
                                break;
                            default:
                                break;
                        }
                    }

                    if (_Recurr_RecurrencePatternDaysOfTheWeek.EndsWith(", "))
                        _Recurr_RecurrencePatternDaysOfTheWeek = _Recurr_RecurrencePatternDaysOfTheWeek.Remove(_Recurr_RecurrencePatternDaysOfTheWeek.Length - 2, 2);
                    o = null;

                }

                if (oAppointment.Recurrence is Recurrence.MonthlyPattern)
                {
                    _Recurr_RecurrencePattern = "MonthlyPattern";

                    Recurrence.MonthlyPattern o = (Recurrence.MonthlyPattern)oAppointment.Recurrence;
                    _Recurr_RecurrMonthlyPatternDayOfMonth = o.DayOfMonth.ToString();
                    _Recurr_RecurrMonthlyPatternEveryMonths = o.Interval.ToString();

                }

                if (oAppointment.Recurrence is Recurrence.RelativeMonthlyPattern)
                {
                    _Recurr_RecurrencePattern = "RelativeMonthlyPattern";

                    Recurrence.RelativeMonthlyPattern o = (Recurrence.RelativeMonthlyPattern)oAppointment.Recurrence;

                    _Recurr_RecurrDayOfTheWeekIndex = o.DayOfTheWeekIndex.ToString();
                    _Recurr_RecurrDayOfWeek = o.DayOfTheWeek.ToString();
                    _Recurr_RecurrInterval = o.Interval.ToString();

                }

                if (oAppointment.Recurrence is Recurrence.YearlyPattern)
                {
                    _Recurr_RecurrencePattern = "YearlyPattern";

                    Recurrence.YearlyPattern o = (Recurrence.YearlyPattern)oAppointment.Recurrence;

                    _Recurr_RecurrYearlyOnSpecificDay = o.DayOfMonth.ToString();

                    _Recurr_RecurrYearlyOnSpecificDayForMonthOf = Enum.GetName(typeof(Month), o.Month);

                    o = null;
                }

                if (oAppointment.Recurrence is Recurrence.RelativeYearlyPattern)
                {
                    _Recurr_RecurrencePattern = "RelativeYearlyPattern";

                    Recurrence.RelativeYearlyPattern o = (Recurrence.RelativeYearlyPattern)oAppointment.Recurrence;

                    _Recurr_RecurrYearlyOnDayPatternDayOfWeekIndex = o.DayOfTheWeekIndex.ToString();
                    _Recurr_RecurrYearlyOnDayPatternDayOfWeekIndex = Enum.GetName(typeof(DayOfTheWeekIndex), o.DayOfTheWeekIndex);
                    _Recurr_RecurrYearlyOnDayPatternDayOfWeek = Enum.GetName(typeof(DayOfTheWeek), o.DayOfTheWeek);
                    _Recurr_RecurrYearlyOnDayPatternMonth = Enum.GetName(typeof(Month), o.Month);

                    o = null;
                }

                // Range
                if (oAppointment.Recurrence.HasEnd == true)
                {
                    _Recurr_RangeHasEnd = oAppointment.Recurrence.HasEnd.ToString();
                    _Recurr_RangeNumberOccurrences = "";
                    _Recurr_RangeEndByDate = "";
                    //RangeEndByDate = oAppointment.Recurrence.EndDate.Value;  // ??
                }
                else
                {

                    if (oAppointment.Recurrence.NumberOfOccurrences.HasValue)
                    {
                        _Recurr_RangeNumberOccurrences = oAppointment.Recurrence.NumberOfOccurrences.ToString();
                    }
                    else
                    {
                        _Recurr_RangeNumberOccurrences = "";
                        if (oAppointment.Recurrence.EndDate.HasValue)
                        {
                            _Recurr_RangeEndByDate = oAppointment.Recurrence.EndDate.ToString();
                        }
                    }
                }


                if (oAppointment.Recurrence is Recurrence.MonthlyPattern)
                {
                    _Recurr_RecurrencePattern = "MonthlyPattern";

                    Recurrence.MonthlyPattern o = (Recurrence.MonthlyPattern)oAppointment.Recurrence;
                    _Recurr_RecurrMonthlyPatternDayOfMonth = o.DayOfMonth.ToString();
                    _Recurr_RecurrMonthlyPatternEveryMonths = o.Interval.ToString();

                }

                if (oAppointment.Recurrence is Recurrence.RelativeMonthlyPattern)
                {
                    _Recurr_RecurrencePattern = "RelativeMonthlyPattern";

                    Recurrence.RelativeMonthlyPattern o = (Recurrence.RelativeMonthlyPattern)oAppointment.Recurrence;

                    _Recurr_RecurrDayOfTheWeekIndex = o.DayOfTheWeekIndex.ToString();
                    _Recurr_RecurrDayOfWeek = o.DayOfTheWeek.ToString();
                    _Recurr_RecurrInterval = o.Interval.ToString();

                }

                if (oAppointment.Recurrence is Recurrence.YearlyPattern)
                {
                    _Recurr_RecurrencePattern = "YearlyPattern";

                    Recurrence.YearlyPattern o = (Recurrence.YearlyPattern)oAppointment.Recurrence;

                    _Recurr_RecurrYearlyOnSpecificDay = o.DayOfMonth.ToString();

                    _Recurr_RecurrYearlyOnSpecificDayForMonthOf = Enum.GetName(typeof(Month), o.Month);

                    o = null;
                }

                if (oAppointment.Recurrence is Recurrence.RelativeYearlyPattern)
                {
                    _Recurr_RecurrencePattern = "RelativeYearlyPattern";

                    Recurrence.RelativeYearlyPattern o = (Recurrence.RelativeYearlyPattern)oAppointment.Recurrence;

                    _Recurr_RecurrYearlyOnDayPatternDayOfWeekIndex = o.DayOfTheWeekIndex.ToString();
                    _Recurr_RecurrYearlyOnDayPatternDayOfWeekIndex = Enum.GetName(typeof(DayOfTheWeekIndex), o.DayOfTheWeekIndex);
                    _Recurr_RecurrYearlyOnDayPatternDayOfWeek = Enum.GetName(typeof(DayOfTheWeek), o.DayOfTheWeek);
                    _Recurr_RecurrYearlyOnDayPatternMonth = Enum.GetName(typeof(Month), o.Month);

                    o = null;
                }

                // Range
                if (oAppointment.Recurrence.HasEnd == true)
                {
                    _Recurr_RangeHasEnd = oAppointment.Recurrence.HasEnd.ToString();
                    _Recurr_RangeNumberOccurrences = "";
                    _Recurr_RangeEndByDate = "";
                    //RangeEndByDate = oAppointment.Recurrence.EndDate.Value;  // ??
                }
                else
                {

                    if (oAppointment.Recurrence.NumberOfOccurrences.HasValue)
                    {
                        _Recurr_RangeNumberOccurrences = oAppointment.Recurrence.NumberOfOccurrences.ToString();
                    }
                    else
                    {
                        _Recurr_RangeNumberOccurrences = "";
                        if (oAppointment.Recurrence.EndDate.HasValue)
                            _Recurr_RangeEndByDate = oAppointment.Recurrence.EndDate.ToString();
                    }
                }
            }

        }

        private PropertySet GetCalendarPropset()
        {

            PropertySet appointmentPropertySet = new PropertySet(BasePropertySet.IdOnly,
 
                AppointmentSchema.AdjacentMeetingCount,
                AppointmentSchema.AdjacentMeetings,
                AppointmentSchema.AllowedResponseActions,
                AppointmentSchema.AllowNewTimeProposal,
                /* AppointmentSchema.AppointmentReplyTime,  */
                AppointmentSchema.AppointmentSequenceNumber,
                AppointmentSchema.AppointmentState,
                AppointmentSchema.AppointmentType,
                AppointmentSchema.Attachments,
                AppointmentSchema.Body,
                AppointmentSchema.Categories,
                /*  AppointmentSchema.ConferenceType,   */
                AppointmentSchema.ConflictingMeetingCount,
                AppointmentSchema.ConflictingMeetings,  
                AppointmentSchema.Culture,
                AppointmentSchema.DateTimeCreated,
                AppointmentSchema.DateTimeReceived,
                AppointmentSchema.DateTimeSent,
                AppointmentSchema.DeletedOccurrences,
                AppointmentSchema.DisplayCc,
                AppointmentSchema.DisplayTo,
                AppointmentSchema.Duration,
                AppointmentSchema.EffectiveRights,
                AppointmentSchema.End,
                AppointmentSchema.HasAttachments,
                AppointmentSchema.ICalDateTimeStamp,
                AppointmentSchema.ICalRecurrenceId,
                AppointmentSchema.ICalUid,
                AppointmentSchema.Id,
                AppointmentSchema.Importance,
                AppointmentSchema.InReplyTo,
                AppointmentSchema.InternetMessageHeaders,

                AppointmentSchema.IsAllDayEvent,
                AppointmentSchema.IsCancelled,
                AppointmentSchema.IsDraft,
                AppointmentSchema.IsFromMe,
                AppointmentSchema.IsMeeting,
                AppointmentSchema.IsOnlineMeeting,
                AppointmentSchema.IsRecurring,
                AppointmentSchema.IsReminderSet,
                AppointmentSchema.IsResend,
                AppointmentSchema.IsResponseRequested,
                AppointmentSchema.IsSubmitted,
                AppointmentSchema.IsUnmodified,
                AppointmentSchema.ItemClass, 
                AppointmentSchema.LastModifiedName,
                AppointmentSchema.LastModifiedTime,
                AppointmentSchema.LegacyFreeBusyStatus,
                AppointmentSchema.Location,
                AppointmentSchema.MeetingRequestWasSent,
                AppointmentSchema.MeetingWorkspaceUrl,
                AppointmentSchema.MimeContent,
                AppointmentSchema.ModifiedOccurrences,
                AppointmentSchema.MyResponseType,
                AppointmentSchema.NetShowUrl,
                AppointmentSchema.OptionalAttendees,
                AppointmentSchema.Organizer,
                AppointmentSchema.OriginalStart,
                AppointmentSchema.ParentFolderId,
                AppointmentSchema.Recurrence,
                AppointmentSchema.ReminderDueBy,
                AppointmentSchema.ReminderMinutesBeforeStart,
                AppointmentSchema.RequiredAttendees,
                AppointmentSchema.Resources,  
                AppointmentSchema.Sensitivity,
                AppointmentSchema.Size,
                AppointmentSchema.Start,
                AppointmentSchema.StartTimeZone,
                AppointmentSchema.Subject,
                AppointmentSchema.TimeZone,
                AppointmentSchema.When

 
              );

            // Not included:
            //    AppointmentSchema.FirstOccurrence.,
            //    AppointmentSchema.LastOccurrence,
            //    AppointmentSchema.ModifiedOccurrences,
            //    AppointmentSchema.DeletedOccurrences,
            //    AppointmentSchema.ExtendedProperties

            // These are version specific:
            //      AppointmentSchema.Hashtags,                     2015+
            //      AppointmentSchema.MentionedMe,                  2015+
            //      AppointmentSchema.Mentions                      2015+
            //      AppointmentSchema.MimeContentUTF8,              Exchange2013_SP1+
            //      AppointmentSchema.ArchiveTag,                   2013+                +
            //      AppointmentSchema.ConversationId                2010+                +
            //      AppointmentSchema.EndTimeZone,                  2010+                 
            //      AppointmentSchema.EnhancedLocation,             2013+
            //      AppointmentSchema.EntityExtractionResult,       2013+
            //      AppointmentSchema.Flag,                         2013+
            //      AppointmentSchema.IconIndex,                    2013+                +
            //      AppointmentSchema.InstanceKey,                  2013+                +
            //      AppointmentSchema.IsAssociated,                 2010+
            //      AppointmentSchema.JoinOnlineMeetingUrl,         2013+
            //      AppointmentSchema.NormalizedBody,               2013+
            //      AppointmentSchema.OnlineMeetingSettings,        2013+
            //      AppointmentSchema.PolicyTag,                    2013+                +
            //      AppointmentSchema.Preview,                      2013+
            //      AppointmentSchema.RetentionDate,                2013+                +
            //      AppointmentSchema.StoreEntryId,                 2013+                +
            //      AppointmentSchema.TextBody,                     2013+
            //      AppointmentSchema.UniqueBody,                   2010+
            //      AppointmentSchema.WebClientEditFormQueryString, 2010+
            //      AppointmentSchema.WebClientReadFormQueryString, 2010+
      
            // Problems loading or need extra work to implement:
            //   AppointmentSchema.AppointmentReplyTime 
            //   AppointmentSchema.ConferenceType 
          
  


            // Need to add these:
            appointmentPropertySet.Add(PidLidAppointmentRecur);
            appointmentPropertySet.Add(PidLidClientIntent);
            appointmentPropertySet.Add(ClientInfoString);
            appointmentPropertySet.Add(LogTriggerAction);
            appointmentPropertySet.Add(PidLidCleanGlobalObjectId);
            appointmentPropertySet.Add(PidLidGlobalObjectId);
         
            appointmentPropertySet.Add(Prop_PR_POLICY_TAG);

            appointmentPropertySet.Add(Prop_PR_RETENTION_FLAGS);
            appointmentPropertySet.Add(Prop_PR_RETENTION_PERIOD);
            appointmentPropertySet.Add(Prop_PR_ARCHIVE_TAG);
            appointmentPropertySet.Add(Prop_PR_ARCHIVE_PERIOD);
            appointmentPropertySet.Add(Prop_PR_ARCHIVE_DATE);
            appointmentPropertySet.Add(Prop_PR_ENTRYID);

            appointmentPropertySet.Add(Prop_PR_RETENTION_DATE);
            appointmentPropertySet.Add(Prop_PR_STORE_ENTRYID);
            appointmentPropertySet.Add(Prop_PR_IS_HIDDEN);
 
            return appointmentPropertySet;
        }
    }
 
}
