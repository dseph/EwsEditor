using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EWSEditor.Common.Exports;
using EWSEditor.Common;
using EWSEditor.Common.Extensions;
using EWSEditor.Resources;
using Microsoft.Exchange.WebServices.Data;
using System.Net;
using System.Xml;


namespace EWSEditor.Forms
{
    public partial class FindSearchFolder : Form
    {
        ExchangeService _ExchangeService = null;
  

        public FindSearchFolder()
        {
            InitializeComponent();

            // https://msdn.microsoft.com/en-us/library/office/dn592094%28v=exchg.150%29.aspx?f=255&MSPPError=-2147217396
        }
        public FindSearchFolder(ExchangeService oExchangeService)
        {
            InitializeComponent();
            _ExchangeService = oExchangeService;

        }

        private void button1_Click(object sender, EventArgs e)
        {
 
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            // https://msdn.microsoft.com/en-us/library/office/dn592094(v=exchg.150).aspx
            FindSarachfolders(_ExchangeService);

    

        }
         

        private void FindSearchFolder_Load(object sender, EventArgs e)
        {
            PrepareFolderLV();
        }


        private void FindSarachfolders(ExchangeService oService)
        {
            int offset = 0;
            bool MoreItems = true;
            int iPageSize = 250;
            int folderViewSize = 250;
            
            ListViewItem oListItem = null;
            Object oPath = null;
            string sPath = string.Empty;
            bool bIsHidden = false;
 
            Folder oRootFolder = Folder.Bind(_ExchangeService, WellKnownFolderName.Root);
            //Folder oMsgFolderRoot = Folder.Bind(_ExchangeService, WellKnownFolderName.MsgFolderRoot);
            Folder oSearchFolders = Folder.Bind(_ExchangeService, WellKnownFolderName.SearchFolders);
 

            ExtendedPropertyDefinition PR_Folder_Path = new ExtendedPropertyDefinition(26293, MapiPropertyType.String);
            ExtendedPropertyDefinition isHiddenProp = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.Boolean);
            StringBuilder oSB = new StringBuilder();

            PrepareFolderLV();
            bool bProcess = false;

            int iCountPages = 0;
            int iCountTotalItems = 0;

            while (MoreItems)
            {
              
                iCountPages++;

                FolderView oFolderView = new FolderView(folderViewSize, offset, OffsetBasePoint.Beginning);
                //ItemView oItemView = new ItemView(iPageSize, offset, OffsetBasePoint.Beginning);
                oFolderView.PropertySet = new PropertySet(
                    BasePropertySet.IdOnly,
                    FolderSchema.ParentFolderId,
                    FolderSchema.DisplayName,
                    FolderSchema.FolderClass,
                    FolderSchema.TotalCount,
                    isHiddenProp,
                    FolderSchema.Id,
                    PR_Folder_Path
                    );

                List<SearchFilter> searchFilterCollection = new List<SearchFilter>();
                oFolderView.Traversal = FolderTraversal.Deep;

                oService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 

                FindFoldersResults oFindFoldersResults = oService.FindFolders(WellKnownFolderName.Root, oFolderView);
                MoreItems = oFindFoldersResults.MoreAvailable;

                foreach (Folder oFolder in oFindFoldersResults.Folders)
                {
                    iCountTotalItems++;
                    bProcess = false;

                    if (oFolder is SearchFolder)
                    {

                        if (chkShowFoldersUnderRootFolder.Checked == true)
                        {
                            if (oFolder.ParentFolderId.UniqueId == oRootFolder.Id.UniqueId)
                            {

                                bProcess = true;
                            }
                        }
                        else
                        {
                            if (chkShowFolderUnderSharedFolders.Checked == true)
                            {
                                if (oFolder.ParentFolderId.UniqueId == oSearchFolders.Id.UniqueId)
                                {
                                    bProcess = true;
                                }

                            }
                            else
                            {
                                if (chkShowSearchFoldersNotUnderSharedFoldersAndNotUnderRoot.Checked == true)
                                {
                                    if (oFolder.ParentFolderId.UniqueId != oRootFolder.Id.UniqueId && oFolder.ParentFolderId.UniqueId != oSearchFolders.Id.UniqueId)
                                        bProcess = true;
                                }

                            }
                        
                        }

 

                    }
                    else
                        bProcess = false;

                    if (bProcess == true)
                    {
                        oFolder.TryGetProperty(PR_Folder_Path, out oPath);
                        // https://social.technet.microsoft.com/Forums/exchange/en-US/e5d07492-f8a3-4db5-b137-46e920ab3dde/exchange-ews-managed-getting-full-path-for-a-folder?forum=exchangesvrdevelopment
                        sPath = Encoding.Unicode.GetString(HexStringToByteArray(BitConverter.ToString(UnicodeEncoding.Unicode.GetBytes((String)oPath)).Replace("FE-FF", "5C-00").Replace("-", "")));

                        oFolder.TryGetProperty(isHiddenProp, out bIsHidden);

                        oListItem = new ListViewItem(oFolder.FolderClass, 0);
                        oListItem.SubItems.Add(oFolder.DisplayName);
                        oListItem.SubItems.Add(sPath);

                        oListItem.SubItems.Add(bIsHidden.ToString());
                        oListItem.SubItems.Add(oFolder.TotalCount.ToString());

                        oListItem.SubItems.Add(oFolder.Id.UniqueId);
 
                        oListItem.Tag = new FolderTag(oFolder.Id, oFolder.FolderClass);
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
               //MoreItems = false;
            }


        }

        private void PrepareFolderLV()
        {

            lvFolders.Clear();
            lvFolders.View = View.Details;
            lvFolders.GridLines = true;

            lvFolders.Columns.Add("Folder Class", 150, HorizontalAlignment.Left);
            lvFolders.Columns.Add("Folder Name", 170, HorizontalAlignment.Left);
            lvFolders.Columns.Add("Folder Path", 200, HorizontalAlignment.Left);

            lvFolders.Columns.Add("IsHidden", 80, HorizontalAlignment.Left);
            lvFolders.Columns.Add("Item Count", 80, HorizontalAlignment.Right);

            lvFolders.Columns.Add("Unique Id", 250, HorizontalAlignment.Left);


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

        private void lvFolders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
