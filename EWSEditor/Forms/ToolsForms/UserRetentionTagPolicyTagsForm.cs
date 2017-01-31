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
using EWSEditor.PropertyInformation;
using EWSEditor.Common.EwsHelpers;
using EWSEditor.Forms.Controls;

// https://blogs.technet.microsoft.com/surama/2011/10/19/search-and-replace-retention-tag-on-microsoft-exchange-2010-mrm/
// https://msdn.microsoft.com/en-us/library/office/dn592093(v=exchg.150).aspx

namespace EWSEditor.Forms 
{
    public partial class UserRetentionTagPolicyTagsForm : Form
    {
        private ExchangeService _ExchangeService = null;
        private EnumComboBox<WellKnownFolderName> wellKnownFolderCombo = new EnumComboBox<WellKnownFolderName>();

        private static ExtendedPropertyDefinition Prop_PR_POLICY_TAG = new ExtendedPropertyDefinition(0x3019, MapiPropertyType.Binary);  // PR_POLICY_TAG 0x3019   Data type: PtypBinary, 0x0102
        //private static ExtendedPropertyDefinition Prop_PR_START_DATE_ETC = new ExtendedPropertyDefinition(0x3019, MapiPropertyType.String); // PR_START_DATE_ETC  GUID 0x30190102

  

        private static ExtendedPropertyDefinition Prop_PR_RETENTION_FLAGS = new ExtendedPropertyDefinition(0x301D, MapiPropertyType.Integer);   // PR_RETENTION_FLAGS 0x301D   
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_PERIOD = new ExtendedPropertyDefinition(0x301A, MapiPropertyType.Integer);  // PR_RETENTION_PERIOD 0x301A    
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_DATE = new ExtendedPropertyDefinition(0x301C, MapiPropertyType.SystemTime); // Prop_PR_RETENTION_DATE 0x301C    
       
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_TAG = new ExtendedPropertyDefinition(0x3018, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_PERIOD = new ExtendedPropertyDefinition(0x301E, MapiPropertyType.Integer); // Prop_PR_RETENTION_DATE 0x301C    
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_DATE = new ExtendedPropertyDefinition(0x301F, MapiPropertyType.SystemTime);

        private static ExtendedPropertyDefinition Prop_PR_FOLDER_PATH = new ExtendedPropertyDefinition(0x66B5, MapiPropertyType.String);   // Folder Path - PR_Folder_Path
        private static ExtendedPropertyDefinition Prop_PR_IS_HIDDEN = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.Boolean);

 


        // Folder:  Prop_PR_START_DATE_ETC, PR_RETENTION_PERIOD, PR_RETENTION_FLAGS
        // Items:  Prop_PR_START_DATE_ETC, PR_RETENTION_PERIOD, DefaultRetentionPeriod, PR_RETENTION_DATE, PR_POLICY_TAG,
        //  PR_ARCHIVE_TAG, PR_ARCHIVE_PERIOD, PR_ARCHIVE_DATE
 
        public UserRetentionTagPolicyTagsForm()
        {
            InitializeComponent();
        }

        public UserRetentionTagPolicyTagsForm(ExchangeService oExchangeService)
        {
            InitializeComponent();

            _ExchangeService = oExchangeService;
        }

        private void btnDisplayUsersRetentionTags_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DisplayRetentionPoliciesInListView(_ExchangeService, ref this.lvUserRetentionTags);
            this.Cursor = Cursors.Default;
        }

        private void DisplayRetentionPoliciesInListView(ExchangeService oExchangeService, ref ListView oListView)
        {

            oListView.Clear();
            oListView.View = View.Details;
            oListView.GridLines = true;

            oListView.Columns.Add("DisplayName", 200,  HorizontalAlignment.Left);
            oListView.Columns.Add("Description", 250, HorizontalAlignment.Left);

            oListView.Columns.Add("Type", 70, HorizontalAlignment.Left);
            oListView.Columns.Add("OptedInto", 70, HorizontalAlignment.Left);

            oListView.Columns.Add("RetentionAction", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("RetentionId", 250, HorizontalAlignment.Left);
            oListView.Columns.Add("RetentionPeriod", 100, HorizontalAlignment.Left);

            oListView.Columns.Add("IsArchive", 70, HorizontalAlignment.Left);
            oListView.Columns.Add("IsVisible", 70, HorizontalAlignment.Left);

            GetUserRetentionPolicyTagsResponse oResponse = null;
            oResponse = _ExchangeService.GetUserRetentionPolicyTags();

            ListViewItem oListViewItem = null;

    

            foreach (RetentionPolicyTag o in oResponse.RetentionPolicyTags)
            {
                oListViewItem = oListView.Items.Add(o.DisplayName);
                oListViewItem.SubItems.Add(o.Description);
                oListViewItem.SubItems.Add(o.Type.ToString());
                oListViewItem.SubItems.Add(o.OptedInto.ToString());

                oListViewItem.SubItems.Add(o.RetentionAction.ToString());
                oListViewItem.SubItems.Add(o.RetentionId.ToString());
            
                oListViewItem.SubItems.Add(o.RetentionPeriod.ToString());

                oListViewItem.SubItems.Add(o.IsArchive.ToString());
                oListViewItem.SubItems.Add(o.IsVisible.ToString());
            }

 
        }

        private void lvUserRetentionTags_DoubleClick(object sender, EventArgs e)
        {
            if (lvUserRetentionTags.SelectedItems.Count > 0)
            {
                ListViewItem o = lvUserRetentionTags.SelectedItems[0];

                StringBuilder oSB = new StringBuilder();
                oSB.AppendFormat("{0}:  {1}\r\n", "DisplayName:      ", o.Text);
                oSB.AppendFormat("{0}:  {1}\r\n", "Description:      ", o.SubItems[0].Text);
                oSB.AppendFormat("{0}:  {1}\r\n", "Type:             ", o.SubItems[1].Text);
                oSB.AppendFormat("{0}:  {1}\r\n", "OptedInto:        ", o.SubItems[2].Text);

                oSB.AppendFormat("{0}:  {1}\r\n", "RetentionAction:  ", o.SubItems[3].Text);
                oSB.AppendFormat("{0}:  {1}\r\n", "RetentionId:      ", o.SubItems[4].Text);
                oSB.AppendFormat("{0}:  {1}\r\n", "RetentionPeriod:  ", o.SubItems[5].Text);

                oSB.AppendFormat("{0}:  {1}\r\n", "IsArchive:        ", o.SubItems[6].Text);
                oSB.AppendFormat("{0}:  {1}\r\n", "IsVisible:        ", o.SubItems[7].Text);

                ShowTextDocument oForm = new ShowTextDocument();
                oForm.Text = "User Retention Tag";
                oForm.txtEntry.Text = oSB.ToString();
                oForm.ShowDialog();
                oForm = null;

            }
        }

        private void UserRetentionTagPolicyTagsForm_Load(object sender, EventArgs e)
        {
            this.wellKnownFolderCombo.TransformComboBox(this.TempWellKnownFolderCombo);
            this.wellKnownFolderCombo.SelectedItem = WellKnownFolderName.Root;
            cmboSearchDepth.Text = "Shallow";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

 

        private void oLvRetionStampedFolders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFindRetentionStampedFolders_Click(object sender, EventArgs e)
        {

        }

        private void FindRetentionStampedFolders()
        { 
            string sPolicy = string.Empty;
            this.Cursor = Cursors.WaitCursor;

            if (txtTagId.Text.Trim().Length == 0)
            {
                MessageBox.Show("Retention Id must be enered before seraching folders.", "Entry Error");
            }
           
            if (lvUserRetentionTags.SelectedItems.Count > 0)
            {
                ListViewItem o = lvUserRetentionTags.SelectedItems[0];
                sPolicy = txtTagId.Text.Trim(); // o.SubItems[5].Text;
                WellKnownFolderName oParentFolder = this.wellKnownFolderCombo.SelectedItem.Value;

                DisplayFindRetentionStampedFoldersInListView(
                    _ExchangeService, 
                    oParentFolder, 
                    sPolicy, 
                    ref this.oLvRetionStampedFolders);
            }
            this.Cursor = Cursors.Default;
         }

        private FolderTraversal GetSearchDepth(string sSearchDepth)
        {
            FolderTraversal oFolderTraversal = FolderTraversal.Shallow; 

            switch (sSearchDepth)
            {
                case "Shallow":
                    oFolderTraversal = FolderTraversal.Shallow; // Shallow, Deep, SoftDeleted
                    break;
                case "Deep":
                    oFolderTraversal = FolderTraversal.Deep; // Shallow, Deep, SoftDeleted
                    break;
                case "SoftDeleted":
                    oFolderTraversal = FolderTraversal.SoftDeleted; // Shallow, Deep, SoftDeleted
                    break;
            }

            return oFolderTraversal;
        }

        private void DisplayFindRetentionStampedFoldersInListView(
            ExchangeService oExchangeService,
            WellKnownFolderName oParentFolder,
            string sPolicy,
            ref ListView oListView)
        {

 
            oListView.Clear();
            oListView.View = View.Details;
            oListView.GridLines = true;

            oListView.Columns.Add("Id", 200, HorizontalAlignment.Left);
            oListView.Columns.Add("FolderName", 250, HorizontalAlignment.Left);
            oListView.Columns.Add("Folder Path", 400, HorizontalAlignment.Left);
            oListView.Columns.Add("PR_POLICY_TAG", 100, HorizontalAlignment.Left);
            //oListView.Columns.Add("PR_START_DATE_ETC", 100, HorizontalAlignment.Left);
   
            oListView.Columns.Add("PR_RETENTION_FLAGS", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("PR_RETENTION_DATE", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("ARCHIVE_TAG", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("PR_IS_HIDDEN", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("TotalCount", 100, HorizontalAlignment.Left);

 

            GetUserRetentionPolicyTagsResponse oResponse = null;
           // oResponse = _ExchangeService.GetUserRetentionPolicyTags();

 
            FolderTraversal oFolderTraversal = GetSearchDepth(cmboSearchDepth.Text);
            FindFoldersWithPolicyTag(_ExchangeService, oParentFolder, sPolicy, ref oLvRetionStampedFolders, oFolderTraversal);
        }


        static void FindFoldersWithPolicyTag(ExchangeService oExchangeService, 
            WellKnownFolderName oParentFolder, 
            string sPolicyTag, 
            ref ListView oListView,
            FolderTraversal oFolderTraversal)
        {
            int pageSize = 5;
            int offset = 0;

            FolderView oFolderView = new FolderView(pageSize + 1, offset);
            //ItemView view = new ItemView(pageSize + 1, offset);

            PropertySet oPropertySet = new PropertySet(BasePropertySet.IdOnly);
            oPropertySet.Add(FolderSchema.DisplayName);
            oPropertySet.Add(FolderSchema.FolderClass);
            //oPropertySet.Add(Prop_PR_START_DATE_ETC);
            oPropertySet.Add(Prop_PR_POLICY_TAG);
            oPropertySet.Add(Prop_PR_RETENTION_FLAGS);
            oPropertySet.Add(Prop_PR_RETENTION_DATE);
            oPropertySet.Add(Prop_PR_ARCHIVE_TAG);
            oPropertySet.Add(Prop_PR_ARCHIVE_PERIOD);
            oPropertySet.Add(FolderSchema.TotalCount);
            oPropertySet.Add(Prop_PR_FOLDER_PATH);
            oPropertySet.Add(Prop_PR_IS_HIDDEN);

 

            oFolderView.PropertySet = oPropertySet;

 
            oFolderView.Traversal = oFolderTraversal;
            string sPath = string.Empty; ;
            FindFoldersResults oFindFoldersResults = null;
            ListViewItem oListViewItem = null;
            bool moreItems = true;
            //FolderId anchorId = null;
            while (moreItems)
            {   
                try 
                {

                    oFindFoldersResults = oExchangeService.FindFolders(oParentFolder, oFolderView);
                    moreItems = oFindFoldersResults.MoreAvailable;
 
                    if (moreItems)
                        oFolderView.Offset += pageSize;
                    
      
                    int displayCount = oFindFoldersResults.Folders.Count > pageSize ? pageSize : oFindFoldersResults.Folders.Count;

 
                    for (int i = 0; i < displayCount; i++)
                    {
                        Folder oFolder = oFindFoldersResults.Folders[i];
                        string sResult = EwsExtendedPropertyHelper.GetExtendedProp_ByteArr_AsString(oFolder, Prop_PR_POLICY_TAG);

                        if (sResult != "")
                        {
                          
                            Console.WriteLine("Folder: " + oFolder.DisplayName + "      Policy: " + sResult);
                        }
                        if (sResult == sPolicyTag)
                        {
                            oListViewItem = oListView.Items.Add(oFolder.Id.ToString());
                            oListViewItem.SubItems.Add(oFolder.DisplayName);
                            EwsFolderHelper.GetFolderPath(oFolder, ref sPath);
                            oListViewItem.SubItems.Add(sPath);
                            oListViewItem.SubItems.Add(EwsExtendedPropertyHelper.GetExtendedProp_ByteArr_AsString(oFolder, Prop_PR_POLICY_TAG));
                            //oListViewItem.SubItems.Add(EwsExtendedPropertyHelper.GetExtendedProp_ByteArr_AsString(oFolder, Prop_PR_START_DATE_ETC));
                            oListViewItem.SubItems.Add(EwsExtendedPropertyHelper.GetExtendedProp_ByteArr_AsString(oFolder, Prop_PR_RETENTION_FLAGS));
                            oListViewItem.SubItems.Add(EwsExtendedPropertyHelper.GetExtendedProp_ByteArr_AsString(oFolder, Prop_PR_RETENTION_DATE));
                            oListViewItem.SubItems.Add(EwsExtendedPropertyHelper.GetExtendedProp_ByteArr_AsString(oFolder, Prop_PR_ARCHIVE_TAG));
                            oListViewItem.SubItems.Add(EwsExtendedPropertyHelper.GetExtendedProp_ByteArr_AsString(oFolder, Prop_PR_IS_HIDDEN));
                            
                            oListViewItem.SubItems.Add(FolderSchema.TotalCount.ToString());
 
                        }
                    }
 

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error while paging results");
                    return;
                }
            }
        }

        private void lvUserRetentionTags_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmboSearchDepth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvUserRetentionTags_Click(object sender, EventArgs e)
        {
            if (lvUserRetentionTags.SelectedItems.Count > 0)
            {
                txtTagId.Text = lvUserRetentionTags.SelectedItems[0].SubItems[5].Text;
            }
        }


        // Read:  https://blogs.technet.microsoft.com/surama/2011/10/19/search-and-replace-retention-tag-on-microsoft-exchange-2010-mrm/
        // 2010 MRM:
        //    * Assigning retention policy tags (RPTs) to default folders, such as the Inbox 
        //    * Applying a default policy tag (DPT) to mailboxes to manage the retention of all untagged items 
        //    * Allowing the user to assign personal tags to custom folders and individual items 
        //    * Separating MRM functionality from users’ Inbox management and filing habits. 
        //      .  Users aren’t required to file messages in managed folders based on retention requirements
        //      .  Individual messages can have a different retention tag than the one applied to the folder in which 
        //         they’re located
    }
}
