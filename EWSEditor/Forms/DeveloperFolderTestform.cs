
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
using EWSEditor.Exchange;
using EWSEditor.Logging;
using EWSEditor.Resources;
using EWSEditor.Settings;
using System.Net;
using System.Xml;
using Microsoft.Exchange.WebServices.Data;

// This form is a convient place for a developer to integrate their code on a folder level in order to do testing.
// 
namespace EWSEditor.Forms
{
    public partial class DeveloperFolderTestform : Form
    {
        ExchangeService _service = null;
        FolderId _folderId = null;

        public DeveloperFolderTestform()
        {
            InitializeComponent();
        }

        public DeveloperFolderTestform(ExchangeService service, FolderId folderId)
        {
            InitializeComponent();
            _service = service;
            _folderId = folderId;
        }

        private void DeveloperFolderTestWindow_Load(object sender, EventArgs e)
        {
            StringBuilder oSB = new StringBuilder();
            oSB.Append("This window is to be used by develpers with EWSEditor source in order that they may test their EWS Managed API code  to work on a selected folder.  ");
            oSB.Append("  The ExchangeService and FolderId are availible in ths form so that you can use them in your custom test code.");
            oSB.AppendLine("");
            oSB.AppendLine("");
            oSB.AppendFormat("Service.Url.AbsolutePath: {0}\r\n", _service.Url.AbsoluteUri.ToString());
            oSB.AppendLine("");
            oSB.AppendLine("FolderId.UniqueId: " + _folderId.UniqueId);
            oSB.AppendLine("");
            oSB.AppendLine("FolderId.ChangeKey: " + _folderId.ChangeKey);
            oSB.AppendLine("");
            oSB.AppendLine("FolderId.FolderName: " + _folderId.FolderName);
            oSB.AppendLine("");
            //oSB.AppendLine("FolderId.ChangeKey: " + _folderId.Mailbox.Address);


            textBox1.Text = oSB.ToString();
        }

        // LoadFolder
        // This will load an Folder by ID.
        // Test code to load a folder object with many properties - modify as needed for your code.
        private bool LoadFolder(ExchangeService oService, FolderId oFolderId, out Folder oFolder)
        {
            // https://blogs.msdn.microsoft.com/akashb/2013/06/13/generating-a-report-which-folders-have-a-personal-tag-applied-to-it-using-ews-managed-api-from-powershell-exchange-2010/
            
            bool bRet = true;

            Folder oReturnFolder = null;
            oFolder = null;

            List<FolderId> oFolders = new List<FolderId>();
            oFolders.Add(oFolderId);

            ExtendedPropertyDefinition Prop_IsHidden = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.Boolean);
            
            // Folder Path
            ExtendedPropertyDefinition Prop_FolderPath = new ExtendedPropertyDefinition(26293, MapiPropertyType.String);

            // PR_RETENTION_FLAGS 0x301D  
            ExtendedPropertyDefinition Prop_RetentionFlags = new ExtendedPropertyDefinition(0x301D, MapiPropertyType.Integer);

            // PR_RETENTION_PERIOD 0x301A
            ExtendedPropertyDefinition Prop_Retention_Period = new ExtendedPropertyDefinition(0x301A, MapiPropertyType.Integer);

 
            PropertySet oPropertySet = new PropertySet(
                BasePropertySet.IdOnly,
                FolderSchema.FolderClass,
                FolderSchema.DisplayName,
                Prop_IsHidden);

            // Add more properties?
            oPropertySet.Add(FolderSchema.TotalCount);
            oPropertySet.Add(FolderSchema.UnreadCount);
            oPropertySet.Add(FolderSchema.WellKnownFolderName);
            oPropertySet.Add(FolderSchema.ChildFolderCount);

            oPropertySet.Add(Prop_FolderPath);
            oPropertySet.Add(Prop_Retention_Period);
            oPropertySet.Add(Prop_RetentionFlags);

 
            ServiceResponseCollection<GetFolderResponse> oGetFolderResponses = oService.BindToFolders(oFolders, oPropertySet);

            foreach (GetFolderResponse oGetItemResponse in oGetFolderResponses)
            {
                switch (oGetItemResponse.Result)
                {
                    case ServiceResult.Success:

                        oReturnFolder = oGetItemResponse.Folder;

                        MessageBox.Show("ServiceResult.Success");

                        break;
                    case ServiceResult.Error:
                        string sError =
                                "ErrorCode:           " + oGetItemResponse.ErrorCode.ToString() + "\r\n" +
                                "\r\nErrorMessage:    " + oGetItemResponse.ErrorMessage + "\r\n";

                        MessageBox.Show(sError, "ServiceResult.Error");

                        break;
                    case ServiceResult.Warning:
                        string sWarning =
                               "ErrorCode:           " + oGetItemResponse.ErrorCode.ToString() + "\r\n" +
                               "\r\nErrorMessage:    " + oGetItemResponse.ErrorMessage + "\r\n";

                        MessageBox.Show(sWarning, "ServiceResult.Warning");

                        break;
                    //default:
                    //    // Should never get here.
                    //    string sSomeError =
                    //            "ErrorCode:           " + oGetItemResponse.ErrorCode.ToString() + "\r\n" +
                    //            "\r\nErrorMessage:    " + oGetItemResponse.ErrorMessage + "\r\n";

                    //    MessageBox.Show(sSomeError, "Some sort of error");
                    //    break;
                }

            }

            oFolder = oReturnFolder;

            return bRet;

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            bool bRet = false;
            Folder oFolder = null;

            bRet = LoadFolder(_service, _folderId, out oFolder);

            // Load the item for _itemId
            //bRet = CallMyCustomCode(oFolder);  // Modify to call your code.
        }

        // ******************************************************************************
        // Your code below **************************************************************
        // ******************************************************************************
    }
}
