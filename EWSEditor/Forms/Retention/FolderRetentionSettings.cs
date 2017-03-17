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
    public partial class FolderRetentionSettings : Form
    {
        private static ExtendedPropertyDefinition Prop_PR_POLICY_TAG = new ExtendedPropertyDefinition(0x3019, MapiPropertyType.Binary);  // PR_POLICY_TAG 0x3019   Data type: PtypBinary, 0x0102
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_FLAGS = new ExtendedPropertyDefinition(0x301D, MapiPropertyType.Integer);   // PR_RETENTION_FLAGS 0x301D   
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_PERIOD = new ExtendedPropertyDefinition(0x301A, MapiPropertyType.Integer);  // PR_RETENTION_PERIOD 0x301A    

        ExchangeService _ExchangeService = null;
        FolderId _FolderId = null;

        public FolderRetentionSettings()
        {
            InitializeComponent();
        }


        public FolderRetentionSettings(ExchangeService oExchangeService, FolderId oFolderId)
        {
            InitializeComponent();
            _ExchangeService = oExchangeService;
            _FolderId = oFolderId;
        }

        private PropertySet GetPropSet()
        {
            PropertySet oPropertySet =  new PropertySet(BasePropertySet.IdOnly,
                    Prop_PR_RETENTION_PERIOD,
                    Prop_PR_RETENTION_FLAGS,
                    Prop_PR_POLICY_TAG 
                    );
            return oPropertySet;              
        }

        private void FolderRetentionSettings_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        { 
            PropertySet oPropertySet = GetPropSet();
            _ExchangeService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            Folder oFolder = Folder.Bind(_ExchangeService, _FolderId, oPropertySet);
            string sFrom = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oFolder, Prop_PR_POLICY_TAG);

            if (sFrom != "")
            {
                byte[] oFromBytes = System.Convert.FromBase64String(sFrom);
                Guid guidTemp = new Guid(oFromBytes);
                string sPR_POLICY_TAG = guidTemp.ToString();
                string sPR_RETENTION_FLAGS = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oFolder, Prop_PR_RETENTION_FLAGS);
                string sPR_RETENTION_PERIOD = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oFolder, Prop_PR_RETENTION_PERIOD);

                txtPR_POLICY_TAG.Text = sPR_POLICY_TAG;
                txtPR_RETENTION_FLAGS.Text = sPR_RETENTION_FLAGS;
                txtPR_RETENTION_PERIOD.Text = sPR_RETENTION_PERIOD;
            }
            else
            {
                txtPR_POLICY_TAG.Text = "";
                txtPR_RETENTION_FLAGS.Text = "";
                txtPR_RETENTION_PERIOD.Text = "";
            }
            
        }

        private void SaveForm()
        {
            PropertySet oPropertySet = GetPropSet();
            _ExchangeService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            Folder oFolder = Folder.Bind(_ExchangeService, _FolderId, oPropertySet);

            Guid guidPR_POLICY_TAG = new Guid(txtPR_POLICY_TAG.Text.Trim());  // Guid
            int intPR_RETENTION_FLAGS = Convert.ToInt32(txtPR_RETENTION_FLAGS.Text.Trim());
            int intPR_RETENTION_PERIOD = Convert.ToInt32(txtPR_RETENTION_PERIOD.Text.Trim());

            oFolder.SetExtendedProperty(Prop_PR_POLICY_TAG, guidPR_POLICY_TAG.ToByteArray());
            oFolder.SetExtendedProperty(Prop_PR_RETENTION_FLAGS,intPR_RETENTION_FLAGS);
            oFolder.SetExtendedProperty(Prop_PR_RETENTION_PERIOD, intPR_RETENTION_PERIOD);

            oFolder.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
            oFolder.Update();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveForm();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
       

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
                    lblInfo.Text =  GetRetentionFlagSettingAsString(c);
                }
                catch (Exception ex)
                {
                    lblInfo.Text = "";
                }

            }
        }

        string GetRetentionFlagSettingAsString(RetentionFlags r)
        {
            string sRet = "";

            

            if (r.HasFlag(RetentionFlags.None)) sRet += "None.  ";
            if (r.HasFlag(RetentionFlags.ExplicitTag)) sRet += "ExplicitTag.  ";
            if (r.HasFlag(RetentionFlags.UserOverride)) sRet += "UserOverride. ";
            if (r.HasFlag(RetentionFlags.Autotag)) sRet += "Autotag.  ";
            if (r.HasFlag(RetentionFlags.PersonalTag)) sRet += "PersonalTag.  ";
            if (r.HasFlag(RetentionFlags.AllRetentionFlags)) sRet += "AllRetentionFlags.  ";
            if (r.HasFlag(RetentionFlags.ExplictArchiveTag)) sRet += "ExplictArchiveTag.  ";
            if (r.HasFlag(RetentionFlags.KeepInPlace)) sRet += "KeepInPlace.  ";
            if (r.HasFlag(RetentionFlags.AllArchiveFlags)) sRet += "AllArchiveFlags.  ";
            if (r.HasFlag(RetentionFlags.NeedsRescan)) sRet += "NeedsRescan.  ";
            if (r.HasFlag(RetentionFlags.PendingRescan)) sRet += "PendingRescan.  ";
               
            return sRet;
        }

        [Flags]
        private enum RetentionFlags      
        {     
            None = 0,
            ExplicitTag = 1,
            UserOverride = 2,
            Autotag = 4,
            PersonalTag = 8,
            AllRetentionFlags = 15,
            ExplictArchiveTag = 16,
            KeepInPlace = 32,
            AllArchiveFlags = 64,
            NeedsRescan = 128,
            PendingRescan = 256,
        }

    }
}
