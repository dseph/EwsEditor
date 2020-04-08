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
    public partial class FolderArchiveSettings : Form
    {
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_TAG = new ExtendedPropertyDefinition(0x3018, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_PERIOD = new ExtendedPropertyDefinition(0x301E, MapiPropertyType.Integer);
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_FLAGS = new ExtendedPropertyDefinition(0x301D, MapiPropertyType.Integer);

        ExchangeService _ExchangeService = null;
        FolderId _FolderId = null;

        public FolderArchiveSettings()
        {
            InitializeComponent();
        }

        public FolderArchiveSettings(ExchangeService oExchangeService, FolderId oFolderId)
        {
            InitializeComponent();
            _ExchangeService = oExchangeService;
            _FolderId = oFolderId;
        }


        private void FolderArchiveSettings_Load(object sender, EventArgs e)
        {
            LoadForm();

            // Compare:
            // https://blogs.msdn.microsoft.com/akashb/2012/12/07/stamping-archive-policy-tag-using-ews-managed-api-from-powershellexchange-2010/
            // to
            // https://blogs.msdn.microsoft.com/akashb/2011/08/10/stamping-retention-policy-tag-using-ews-managed-api-1-1-from-powershellexchange-2010/

            // And see: https://blogs.technet.microsoft.com/anya/2014/11/19/understanding-of-managed-folder-assistant-with-retention-policies/
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveForm();
            this.Close();
        }

        //public FolderArchiveSettings(ExchangeService oExchangeService, FolderId oFolderId)
        //{
        //    InitializeComponent();
        //    _ExchangeService = oExchangeService;
        //    _FolderId = oFolderId;
        //}

        private PropertySet GetPropSet()
        {
            PropertySet oPropertySet = new PropertySet(BasePropertySet.IdOnly,
                    Prop_PR_ARCHIVE_PERIOD,
                    Prop_PR_RETENTION_FLAGS,
                    Prop_PR_ARCHIVE_TAG
                    );
            return oPropertySet;
        }

        private void LoadForm()
        {
            PropertySet oPropertySet = GetPropSet();
            _ExchangeService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            Folder oFolder = Folder.Bind(_ExchangeService, _FolderId, oPropertySet);
            string sFrom = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oFolder, Prop_PR_ARCHIVE_TAG);

            if (sFrom != "")
            {
                byte[] oFromBytes = System.Convert.FromBase64String(sFrom);
                Guid guidTemp = new Guid(oFromBytes);
                string sPR_ARCHIVE_TAG = guidTemp.ToString();
                string sPR_RETENTION_FLAGS = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oFolder, Prop_PR_RETENTION_FLAGS);
                string sPR_ARCHIVE_PERIOD = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oFolder, Prop_PR_ARCHIVE_PERIOD);

                txtPR_ARCHIVE_TAG.Text = sPR_ARCHIVE_TAG;
                txtPR_RETENTION_FLAGS.Text = sPR_RETENTION_FLAGS;
                txtPR_ARCHIVE_PERIOD.Text = sPR_ARCHIVE_PERIOD;
            }
            else
            {
                txtPR_ARCHIVE_TAG.Text = "";
                txtPR_RETENTION_FLAGS.Text = "";
                txtPR_ARCHIVE_PERIOD.Text = "";
            }

        }

        private void SaveForm()
        {
            PropertySet oPropertySet = GetPropSet();
            _ExchangeService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            Folder oFolder = Folder.Bind(_ExchangeService, _FolderId, oPropertySet);

            Guid guidPR_ARCHIVE_TAG = new Guid(txtPR_ARCHIVE_TAG.Text.Trim());  // Guid
            int intPR_RETENTION_FLAGS = Convert.ToInt32(txtPR_RETENTION_FLAGS.Text.Trim());
            int intPR_ARCHIVE_PERIOD = Convert.ToInt32(txtPR_ARCHIVE_PERIOD.Text.Trim());

            oFolder.SetExtendedProperty(Prop_PR_ARCHIVE_TAG, guidPR_ARCHIVE_TAG.ToByteArray());
            oFolder.SetExtendedProperty(Prop_PR_RETENTION_FLAGS, intPR_RETENTION_FLAGS);
            oFolder.SetExtendedProperty(Prop_PR_ARCHIVE_PERIOD, intPR_ARCHIVE_PERIOD);

            oFolder.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
            oFolder.Update();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPR_ARCHIVE_PERIOD_TextChanged(object sender, EventArgs e)
        {
            //string s = txtPR_RETENTION_FLAGS.Text.Trim();
            //if (s != "")
            //{
            //    try
            //    {
            //        int i = Convert.ToInt32(s);
            //        RetentionFlags c = (RetentionFlags)i;
            //        lblInfo.Text = GetRetentionFlagSettingAsString(c);
            //    }
            //    catch (Exception ex)
            //    {
            //        lblInfo.Text = "";
            //    }

            //}
        }
 
        
        string GetRetentionFlagSettingAsString(RetentionFlags r)
        {
            string sRet = "";
            int i = (int)r;
            sRet = "0x" + (i.ToString("X4")) + " = ";

           // https://msdn.microsoft.com/en-us/library/ee202166(v=exchg.80).aspx

            if (r == RetentionFlags.None)
                sRet += "None (0x000). ";      
            else
            {
                if (r.HasFlag(RetentionFlags.ExplicitTag)) sRet += "ExplicitTag (0x001) + ";

                if (r.HasFlag(RetentionFlags.UserOverride)) sRet += "UserOverride (0x002) + ";
                if (r.HasFlag(RetentionFlags.Autotag)) sRet += "Autotag (0x004) + ";
                if (r.HasFlag(RetentionFlags.PersonalTag)) sRet += "PersonalTag (0x0008) + ";
                if (r.HasFlag(RetentionFlags.ExplictArchiveTag)) sRet += "ExplictArchiveTag (0x0010) + ";
                if (r.HasFlag(RetentionFlags.KeepInPlace)) sRet += "KeepInPlace. (0x0020) + ";
                if (r.HasFlag(RetentionFlags.SystemData)) sRet += "SystemData. (0x0040) + ";
                if (r.HasFlag(RetentionFlags.NeedsRescan)) sRet += "NeedsRescan. (0x0080) + ";
                if (r.HasFlag(RetentionFlags.PendingRescan)) sRet += "PendingRescan. (0x0100)";
            }
            if (sRet.EndsWith(" + "))
            {
                sRet = sRet.Remove(sRet.Length - 3, 3);
                sRet += ".";
            }
            return sRet;
        }

        //string GetRetentionFlagSettingAsString(RetentionFlags r)
        //{
        //    string sRet = "";

        //    https://msdn.microsoft.com/en-us/library/ee202166(v=exchg.80).aspx

        //    if (r == RetentionFlags.None)
        //        sRet += "None (0x000). ";      
        //    else
        //    {
        //        if (r.HasFlag(RetentionFlags.ExplicitTag)) sRet += "ExplicitTag (0x001) + ";

        //        if (r.HasFlag(RetentionFlags.UserOverride)) sRet += "UserOverride (0x002) + ";
        //        if (r.HasFlag(RetentionFlags.Autotag)) sRet += "Autotag (0x004) + ";
        //        if (r.HasFlag(RetentionFlags.PersonalTag)) sRet += "PersonalTag (0x0008) + ";
        //        if (r.HasFlag(RetentionFlags.ExplictArchiveTag)) sRet += "ExplictArchiveTag (0x0010) + ";
        //        if (r.HasFlag(RetentionFlags.KeepInPlace)) sRet += "KeepInPlace. (0x0020) + ";
        //        if (r.HasFlag(RetentionFlags.SystemData)) sRet += "SystemData. (0x0040) + ";
        //        if (r.HasFlag(RetentionFlags.NeedsRescan)) sRet += "NeedsRescan. (0x0080) + ";
        //        if (r.HasFlag(RetentionFlags.PendingRescan)) sRet += "PendingRescan. (0x0100)";
        //    }
        //    if (sRet.EndsWith(" + "))
        //    {
        //        sRet.Remove(sRet.Length - 4, 3);
        //        sRet += ".".
        //    }
        //    return sRet;
        //}

        [Flags]
        private enum RetentionFlags
        {
            None = 0,
            ExplicitTag = 1,
            UserOverride = 2,
            Autotag = 4,
            PersonalTag = 8,
            ExplictArchiveTag = 16,
            KeepInPlace = 32,
            SystemData = 64,
            NeedsRescan = 128,
            PendingRescan = 256,
        }

        private void txtPR_RETENTION_FLAGS_TextChanged(object sender, EventArgs e)
        {
            string s = txtPR_RETENTION_FLAGS.Text.Trim();
            if (s != "")
            {
                try
                {
                    int i = Convert.ToInt32(s);
                    RetentionFlags c = (RetentionFlags)i;
                    lblInfo.Text = GetRetentionFlagSettingAsString(c);
                }
                catch (Exception ex)
                {
                    string x = ex.Message.ToString();
                    lblInfo.Text = "";
                }

            }
        }
    }

}
