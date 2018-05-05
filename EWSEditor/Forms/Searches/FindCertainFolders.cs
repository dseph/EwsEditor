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

namespace EWSEditor.Forms.Searches
{
    public partial class FindCertainFolders : Form
    {
        private ExchangeService _CurrentService = null;
        EWSEditor.Common.EwsSession _CurrentEwsSessionSettings = null;

        public FindCertainFolders()
        {
            InitializeComponent();
        }
        public FindCertainFolders(ExchangeService oExchangeService, EWSEditor.Common.EwsSession oCurrentEwsSessionSettings)
        {
            InitializeComponent();
            _CurrentService = oExchangeService;
            _CurrentEwsSessionSettings = oCurrentEwsSessionSettings;
        }

         
        private void rdoSaveToCsvFile_CheckedChanged(object sender, EventArgs e)
        {
            OutPutCheckChanged();
        }

        private void OutPutCheckChanged()
        {
            txtCsvFilePath.Enabled = rdoSaveToCsvFile.Enabled;
            lvFolders.Enabled = rdoDisplayHere.Checked;
        }

        private void rdoDisplayHere_CheckedChanged(object sender, EventArgs e)
        {
            OutPutCheckChanged();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
             

            string s = this.txtMailboxes.Text.Trim();
            if (s.Length == 0)
            {
                MessageBox.Show("Add mailboxe SMTP addresses one per line to the list to process.", "Entry Required");

            }
            else
            {
                // Clean-up whatever was entered so it can be made into an array.
                s = s.Replace(" ", "\r");
                s = s.Replace("\'", "\r");
                s = s.Replace("\"", "\r");
                s = s.Replace("\t", "\r");
                s = s.Replace("\r\n", "\r");
                s = s.Replace("\r\r", "\r");
                s = s.Replace(",", "\r");
                s = s.Replace("\r", ";");
                s = s.Replace(";;", ";");

                string[] sMailboxes = s.Split(';').Select(sValue => sValue.Trim()).ToArray();
                
                foreach (string sMailbox in sMailboxes)
                {
                    // do autodiscover to get the URL for each mailbox
                    // Impersonate

                    SearchMailboxForFolders(sMailbox, _CurrentService);
                }
            }
        }

        private void SearchMailboxForFolders(string sMailbox, ExchangeService oService)
        {
            int offset = 0;      
            bool MoreItems = true;
            int iPageSize = 250;
            int folderViewSize = 250;
            int iCountMore = 0;
            ListViewItem oListItem = null;
            Object oPath = null;
            string sPath = string.Empty;
            bool bIsHidden = false;

            //if (oService.HttpHeaders.("X-AnchorMailbox"))
            oService.HttpHeaders.Remove("X-AnchorMailbox");
            oService.HttpHeaders.Add("X-AnchorMailbox", sMailbox);
            oService.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, sMailbox);

            ExtendedPropertyDefinition PR_Folder_Path = new ExtendedPropertyDefinition(26293, MapiPropertyType.String);
            
            ExtendedPropertyDefinition isHiddenProp = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.Boolean);
 
            StringBuilder oSB = new StringBuilder();

            PrepareFolderLV();

            while (MoreItems)
            {
                iCountMore++;

             
                FolderView view = new FolderView(folderViewSize);
                ItemView oItemView = new ItemView(iPageSize, offset, OffsetBasePoint.Beginning);
                            view.PropertySet = new PropertySet(
                            BasePropertySet.IdOnly, 
                            FolderSchema.DisplayName, 
                            FolderSchema.FolderClass, 
                            FolderSchema.TotalCount, 
                            isHiddenProp,
                            FolderSchema.Id,
                            PR_Folder_Path
                            );
                List<SearchFilter> searchFilterCollection = new List<SearchFilter>();
                view.Traversal = FolderTraversal.Deep;

                if (this.chkClass.Checked == true)
                    if (this.txtClass.Text.Length != 0)
                        searchFilterCollection.Add(new SearchFilter.ContainsSubstring(FolderSchema.FolderClass, this.txtClass.Text));
                if (this.chkName.Checked == true)
                    if (this.txtName.Text.Length != 0)
                        searchFilterCollection.Add(new SearchFilter.ContainsSubstring(FolderSchema.DisplayName, this.txtName.Text));

               SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.Or, searchFilterCollection.ToArray());

               oService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
               FindFoldersResults oFindFoldersResults = oService.FindFolders(WellKnownFolderName.MsgFolderRoot, searchFilter, view);
 
               
                foreach (Folder oFolder in oFindFoldersResults.Folders)
                {
                     
                    oFolder.TryGetProperty(PR_Folder_Path, out oPath);
                    // https://social.technet.microsoft.com/Forums/exchange/en-US/e5d07492-f8a3-4db5-b137-46e920ab3dde/exchange-ews-managed-getting-full-path-for-a-folder?forum=exchangesvrdevelopment
                    sPath = Encoding.Unicode.GetString(HexStringToByteArray(BitConverter.ToString(UnicodeEncoding.Unicode.GetBytes((String)oPath)).Replace("FE-FF", "5C-00").Replace("-", "")));

                    oFolder.TryGetProperty(isHiddenProp, out bIsHidden);

                    if (this.rdoSaveToCsvFile.Checked == true)
                    {
                        if (this.txtCsvFilePath.Text.Trim().Length !=0)
                        {
                            oSB.AppendFormat("{0},", sMailbox);
                            oSB.AppendFormat("{0},", oFolder.FolderClass);
                            oSB.AppendFormat("{0},", oFolder.DisplayName);
                            oSB.AppendFormat("{0},", oFolder.TotalCount.ToString());
                            oSB.AppendFormat("{0},", bIsHidden.ToString());
                            oSB.AppendFormat("{0},", oFolder.Id.UniqueId); 
                            oSB.AppendFormat("{0}", sPath);

                            System.IO.File.AppendText(oSB.ToString());
                        }
                    }
                    if (this.rdoDisplayHere.Checked == true)
                    {
                        oListItem = new ListViewItem(sMailbox, 0);
                        oListItem.SubItems.Add(oFolder.FolderClass);
                        oListItem.SubItems.Add(oFolder.DisplayName);
                        oListItem.SubItems.Add(oFolder.TotalCount.ToString());
                        oListItem.SubItems.Add(bIsHidden.ToString());
                        oListItem.SubItems.Add(oFolder.Id.UniqueId);
                        oListItem.SubItems.Add(sPath);
                        oListItem.Tag = new  FolderTag(oFolder.Id, oFolder.FolderClass);
                        lvFolders.Items.AddRange(new ListViewItem[] { oListItem }); ;
                        oListItem = null;
                    }
                }

                // Set the flag to discontinue paging.
                if (!oFindFoldersResults.MoreAvailable)
                {
                    MoreItems = false;
                }

                // Update the offset if there are more items to page.
                if (MoreItems)
                {
                    offset += iPageSize;
                }
            }
 

        }
        static Byte[] HexStringToByteArray(String HexString)
        {
            Byte[] ByteArray = new Byte[HexString.Length / 2];
            for (int i = 0; i < HexString.Length; i += 2)
            {
                ByteArray[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
            }
            return ByteArray;
        }

        private void PrepareFolderLV() 
        {

            lvFolders.Clear();
            lvFolders.View = View.Details;
            lvFolders.GridLines = true;

            lvFolders.Columns.Add("Mailbox", 170, HorizontalAlignment.Left);
            lvFolders.Columns.Add("Folder Class", 170, HorizontalAlignment.Left);
            lvFolders.Columns.Add("Folder Name", 170, HorizontalAlignment.Left);
            lvFolders.Columns.Add("IsHidden", 170, HorizontalAlignment.Left);
            lvFolders.Columns.Add("Item Count", 170, HorizontalAlignment.Left);
            lvFolders.Columns.Add("Unique Id", 250, HorizontalAlignment.Left);
            lvFolders.Columns.Add("FolderPath", 250, HorizontalAlignment.Left);
        }

        private void FindCertainFolders_Load(object sender, EventArgs e)
        {

        }
    }
}
