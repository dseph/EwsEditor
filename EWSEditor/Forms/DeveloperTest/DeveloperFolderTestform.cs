
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
            //oSB.AppendLine("FolderId.FolderName: " + _folderId.FolderName);
            //oSB.AppendLine("");
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
            ExtendedPropertyDefinition Prop_PR_FOLDER_PATH = new ExtendedPropertyDefinition(26293, MapiPropertyType.String);

            // PR_POLICY_TAG 0x3019   Data type: PtypBinary, 0x0102
            ExtendedPropertyDefinition Prop_PR_POLICY_TAG = new ExtendedPropertyDefinition(0x3019, MapiPropertyType.Binary);

            // PR_RETENTION_TAG 0x3019  (12313)
            //ExtendedPropertyDefinition Prop_Retention_Tag = new ExtendedPropertyDefinition(0x3019, MapiPropertyType.Integer);

            // PR_RETENTION_FLAGS 0x301D (12317)  PtypInteger32
            ExtendedPropertyDefinition Prop_Retention_Flags = new ExtendedPropertyDefinition(0x301D, MapiPropertyType.Integer);

            // PR_RETENTION_PERIOD 0x301A (12314)  PtypInteger32, 0x0003
            ExtendedPropertyDefinition Prop_Retention_Period = new ExtendedPropertyDefinition(0x301A, MapiPropertyType.Integer);

            // http://gsexdev.blogspot.com/2011/04/using-ews-to-calculate-age-of-items-and.html#!/2011/04/using-ews-to-calculate-age-of-items-and.html

            // PR_FOLDER_TYPE 0x3601 (13825)
            ExtendedPropertyDefinition Prop_PR_FOLDER_TYPE = new ExtendedPropertyDefinition(0x3601, MapiPropertyType.Integer);

            // PR_MESSAGE_SIZE_EXTENDED 0x0E08 (3592)    PT_I8   https://msdn.microsoft.com/en-us/library/office/cc839933.aspx
            ExtendedPropertyDefinition Prop_PR_MESSAGE_SIZE_EXTENDED = new ExtendedPropertyDefinition(0x0E08, MapiPropertyType.Long);

            // PR_DELETED_MESSAGE_SIZE_EXTENDED  0x669B (26267)  PtypInteger64, 0x0014
            ExtendedPropertyDefinition Prop_PR_DELETED_MESSAGE_SIZE_EXTENDED = new ExtendedPropertyDefinition(0x669B, MapiPropertyType.Long);

            // PR_ATTACH_ON_NORMAL_MSG_COUNT  0x66B1  
            ExtendedPropertyDefinition Prop_PR_ATTACH_ON_NORMAL_MSG_COUNT = new ExtendedPropertyDefinition(0x66B1, MapiPropertyType.Long);

            // PR_ARCHIVE_TAG  0x3018  
            ExtendedPropertyDefinition Prop_PidTagPolicyTag = new ExtendedPropertyDefinition(0x66B1, MapiPropertyType.Long);

            // private static ExtendedPropertyDefinition Prop_PidTagArchiveTag = new ExtendedPropertyDefinition(0x3018, MapiPropertyType.Binary);              // Guid of Archive tag - PR_ARCHIVE_TAG - PidTagArchiveTag 
            // private static ExtendedPropertyDefinition Prop_PidTagPolicyTag = new ExtendedPropertyDefinition(0x3019, MapiPropertyType.Integer);              // Item - PidTagPolicyTag - PR_POLICY_TAG
            // private static ExtendedPropertyDefinition Prop_PidTagRetentionPeriod = new ExtendedPropertyDefinition(0x301A, MapiPropertyType.Integer);        // Message - PidTagRetentionPeriod - PR_RETENTION_PERIOD 
  
      

            PropertySet oPropertySet = new PropertySet(
                BasePropertySet.IdOnly,
                FolderSchema.FolderClass,
                FolderSchema.DisplayName,
                Prop_IsHidden);

            // Add more properties?
            oPropertySet.Add(FolderSchema.TotalCount);
            oPropertySet.Add(FolderSchema.UnreadCount);
            //oPropertySet.Add(FolderSchema.WellKnownFolderName);
            oPropertySet.Add(FolderSchema.ChildFolderCount);

           // oPropertySet.Add(Prop_FolderPath);
            //oPropertySet.Add(Prop_Retention_Tag);
            oPropertySet.Add(Prop_Retention_Period);
            oPropertySet.Add(Prop_PR_POLICY_TAG);
            oPropertySet.Add(Prop_Retention_Flags);
            oPropertySet.Add(Prop_PR_FOLDER_TYPE);
            oPropertySet.Add(Prop_PR_FOLDER_PATH);
            oPropertySet.Add(Prop_PR_MESSAGE_SIZE_EXTENDED);
            oPropertySet.Add(Prop_PR_DELETED_MESSAGE_SIZE_EXTENDED);
            oPropertySet.Add(Prop_PR_ATTACH_ON_NORMAL_MSG_COUNT);

            // https://blogs.msdn.microsoft.com/akashb/2011/08/10/stamping-retention-policy-tag-using-ews-managed-api-1-1-from-powershellexchange-2010/
 
   

            StringBuilder oSB = new StringBuilder();
            int iVal = 0;
            long lVal = 0;
            string sVal = string.Empty;
            object oVal  = null;
             

            ServiceResponseCollection<GetFolderResponse> oGetFolderResponses = oService.BindToFolders(oFolders, oPropertySet);

            foreach (GetFolderResponse oGetItemResponse in oGetFolderResponses)
            {
                switch (oGetItemResponse.Result)
                {
                    case ServiceResult.Success:

                        oReturnFolder = oGetItemResponse.Folder;



                        oSB.AppendFormat("DisplayName: {0}\r\n", oReturnFolder.DisplayName);
                        oSB.AppendFormat("FolderClass: {0}\r\n", oReturnFolder.FolderClass);

                        if (oReturnFolder.TryGetProperty(Prop_PR_FOLDER_TYPE, out iVal))
                            oSB.AppendFormat("PR_FOLDER_TYPE:  {0}\r\n", iVal);
                        else
                            oSB.AppendLine("PR_FOLDER_TYPE: Not found.");

                        string sPath = string.Empty;
                        if (EwsFolderHelper.GetFolderPath(oReturnFolder, ref sPath))
                            oSB.AppendFormat("Prop_PR_FOLDER_PATH:  {0}\r\n", sPath);
                        else
                            oSB.AppendLine("Prop_PR_FOLDER_PATH: Not found.");

 
 
                        if (oReturnFolder.TryGetProperty(Prop_PR_MESSAGE_SIZE_EXTENDED, out lVal))
                            oSB.AppendFormat("PR_MESSAGE_SIZE_EXTENDED:  {0}\r\n", lVal);
                        else
                            oSB.AppendLine("PR_MESSAGE_SIZE_EXTENDED: Not found.");

                        if (oReturnFolder.TryGetProperty(Prop_PR_DELETED_MESSAGE_SIZE_EXTENDED, out lVal))
                            oSB.AppendFormat("PR_DELETED_MESSAGE_SIZE_EXTENDED:  {0}\r\n", lVal);
                        //else
                        //    oSB.AppendLine("PR_DELETED_MESSAGE_SIZE_EXTENDED: Not found.");


                        if (oReturnFolder.TryGetProperty(Prop_PR_ATTACH_ON_NORMAL_MSG_COUNT, out lVal))
                            oSB.AppendFormat("PR_ATTACH_ON_NORMAL_MSG_COUNT:  {0}\r\n", lVal);
                        else
                            oSB.AppendLine("PR_ATTACH_ON_NORMAL_MSG_COUNT: Not found.");

 
 


                        MessageBox.Show(oSB.ToString(), "ServiceResult.Success");

                        break;
                    case ServiceResult.Error:
                        string sError =
                                "ErrorCode:           " + oGetItemResponse.ErrorCode.ToString() + "\r\n" +
                                "\r\nErrorMessage:    " + oGetItemResponse.ErrorMessage + "\r\n";
                   
                        if (oGetItemResponse.ErrorProperties.Count >0)
                        {
                            sError += "\r\nErrorProperties: ";
                            foreach (ExtendedPropertyDefinition x in oGetItemResponse.ErrorProperties)
                            {
                                if (x.Name != null)
                                    sError += "\r\n    Name: " + x.Name;

                                if (x.Tag != null)
                                {
                                    //sError += "\r\n    Tag: " + x.Tag;
                                    iVal = (int)x.Tag;
                                    if (iVal == 13825)
                                        sError += string.Format("\r\n    PR_FOLDER_TYPE Hex: {00:X} Int: {1} ", iVal, iVal);
                                    if (iVal == 26293)
                                        sError += string.Format("\r\n    Prop_PR_FOLDER_PATH Hex: {00:X} Int: {1} ", iVal, iVal);
                                    if (iVal == 3592)
                                        sError += string.Format("\r\n    PR_MESSAGE_SIZE_EXTENDED Hex: {00:X} Int: {1} ", iVal, iVal);
                                    if (iVal == 26267)
                                        sError += string.Format("\r\n    PR_DELETED_MESSAGE_SIZE_EXTENDED Hex: {00:X} Int: {1} ", iVal, iVal);
                                }

                                if (x.Type != null)
                                    sError += "\r\n    Type: " + x.Type; 

                                //  sHex = string.Format("{00:X}", iValue).PadLeft(2, '0');
                            }

                            //for (int i= 0; i < oGetItemResponse.ErrorProperties.Count; i++)
                            //{
 
                            //}

                        }

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

        static Byte[] HexStringToByteArray(String HexString)
        {
            // http://gsexdev.blogspot.com/2011/03/using-prfolderpath-property-in-exchange.html#!/2011/03/using-prfolderpath-property-in-exchange.html

            Byte[] ByteArray = new Byte[HexString.Length / 2];
            for (int i = 0; i < HexString.Length; i += 2)
            {
                ByteArray[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
            }
            return ByteArray;
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
