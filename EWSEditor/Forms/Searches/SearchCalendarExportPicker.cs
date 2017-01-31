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
using Microsoft.Exchange.WebServices.Data;


//using EWSEditor.Common.Exports;

namespace EWSEditor.Forms
{
    public partial class SearchCalendarExportPicker : Form
    {
        public bool bChoseOk = false;
        public List<EWSEditor.Common.Exports.AdditionalPropertyDefinition> AdditionalPropertyDefinitions = null;
        public List<ExtendedPropertyDefinition> ExtendedPropertyDefinitions = null;

        public SearchCalendarExportPicker()
        {
            InitializeComponent();
        }

        private void SearchCalendarExportPicker_Load(object sender, EventArgs e)
        {
            string StartFolder = Application.StartupPath  + "";
            this.txtDisplayedResultsFolderPath.Text = StartFolder + "\\Export\\ExportedSearchCalendarResults.CSV";
            this.txtAppointmentDetailedFolderPath.Text = StartFolder + "\\Export\\ExportedDetailedAppointmentResults.CSV";
            this.txtMeetingMessageDetailedFolderPath.Text = StartFolder + "\\Export\\ExportedDetailedMeetingMessageResults.CSV";
            this.txtDiagnosticExportFolderPath.Text = StartFolder + "\\Export\\ExportedDiagnosticMeetingMessageResults.CSV";
            this.txtBlobFolderPath.Text = Application.StartupPath + "\\Export";
            this.txtIncludeUsersAdditionalPropertiesFile.Text = Application.StartupPath + "\\AdditionalPropertiesExamples";
           
            SetEnablement();
        }

        private void btnPickFolder_Click(object sender, EventArgs e)
        {
            string sFolderPath = string.Empty;
            System.Windows.Forms.FolderBrowserDialog oFDB = new FolderBrowserDialog();

            oFDB.SelectedPath = txtAppointmentDetailedFolderPath.Text;
            if (oFDB.ShowDialog() == DialogResult.OK)
            {
              sFolderPath =  oFDB.SelectedPath;
            }
 
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (rdoExportDisplayedResults.Checked)
            {
                if (File.Exists(txtDisplayedResultsFolderPath.Text.Trim()))
                {
                    MessageBox.Show("File Already Exists", "File already exists.  Choose a different file name.");
                }
            }

            if (this.rdoExportDisplayedResults.Checked)
            {
                if (File.Exists(this.txtAppointmentDetailedFolderPath.Text.Trim()))
                {
                    MessageBox.Show("File Already Exists", "File already exists.  Choose a different file name.");
                }
            }

            bChoseOk = true;
            this.Close();
        }

        private void rdoExportDisplayedResults_CheckedChanged(object sender, EventArgs e)
        {
            SetEnablement();
        }

        private void SetEnablement()
        {
            //chkIncludeAttachments.Enabled =  rdoExportDetailedProperties.Checked;          
            chkIncludeBodyProperties.Enabled =  rdoExportDetailedProperties.Checked;
            chkIncludeMime.Enabled =  rdoExportDetailedProperties.Checked;
            txtAppointmentDetailedFolderPath.Enabled = rdoExportDetailedProperties.Checked;
            txtMeetingMessageDetailedFolderPath.Enabled = rdoExportDetailedProperties.Checked;
            btnPickFolderAppointmentDetailedProperties.Enabled = rdoExportDetailedProperties.Checked;
            btnPickFolderMeetingMessageDetailedProperties.Enabled = rdoExportDetailedProperties.Checked;

            txtDisplayedResultsFolderPath.Enabled = rdoExportDisplayedResults.Checked;
            btnPickFolderDisplayedResults.Enabled = rdoExportDisplayedResults.Checked;

            txtBlobFolderPath.Enabled = rdoExportItemsAsBlobs.Checked;
            btnPickFolderBlobProperties.Enabled = rdoExportItemsAsBlobs.Checked;

            txtIncludeUsersAdditionalPropertiesFile.Enabled = chkIncludeUsersAdditionalProperties.Checked;
            //btnPickFolderIncludeUsersAdditionalProperties.Enabled = chkIncludeUsersAdditionalProperties.Checked;
        }

        private void rdoExportItemsAsBlobs_CheckedChanged(object sender, EventArgs e)
        {
            SetEnablement();
        }

        private void rdoExportDetailedProperties_CheckedChanged(object sender, EventArgs e)
        {
            SetEnablement();
        }

        private void btnPickFolderDetailedProperties_Click(object sender, EventArgs e)
        {
            string sFolderPath = string.Empty;
            System.Windows.Forms.FolderBrowserDialog oFDB = new FolderBrowserDialog();

            oFDB.SelectedPath = txtAppointmentDetailedFolderPath.Text;
            if (oFDB.ShowDialog() == DialogResult.OK)
            {
                sFolderPath = oFDB.SelectedPath;
            }
        }

        private void btnPickFolderAppointmentDetailedProperties_Click(object sender, EventArgs e)
        {
 
            txtAppointmentDetailedFolderPath.Text = ChooseFilePath(txtAppointmentDetailedFolderPath.Text.Trim(), "CSV");
 
        }

        private string ChooseFilePath(string sFullPath, string sExtensionType)
        {
            //string sFolderPath = string.Empty;
            string sNewFullPath = string.Empty;
           
            System.Windows.Forms.SaveFileDialog oFD = new System.Windows.Forms.SaveFileDialog();
 
            sNewFullPath = sFullPath;

            oFD.InitialDirectory = Path.GetDirectoryName(sFullPath);
            oFD.FileName = sFullPath;  
            
            oFD.CheckPathExists = true;
            if (sExtensionType.ToUpper() == "CSV")
            {
                oFD.DefaultExt = "csv";
                oFD.Filter = "csv files (*.csv)|*.csv";
                oFD.FilterIndex = 1;
                oFD.Title = "Save item as csv";
            }

            if (sExtensionType.ToUpper() == "BIN")
            {
                oFD.DefaultExt = "bin";
                oFD.Filter = "bin files (*.bin)|*.bin";
                oFD.FilterIndex = 1;
                oFD.Title = "Save item as bin";
            }

            if (oFD.ShowDialog() == DialogResult.OK)
            {
                sNewFullPath = oFD.FileName;
  
            }
            return sNewFullPath;
        }

        private void btnPickFolderMeetingMessageDetailedProperties_Click(object sender, EventArgs e)
        {
            txtMeetingMessageDetailedFolderPath.Text = ChooseFilePath(txtMeetingMessageDetailedFolderPath.Text.Trim(), "CSV");

 

        }

        private void btnPickFolderDisplayedResults_Click(object sender, EventArgs e)
        {

            txtDiagnosticExportFolderPath.Text = ChooseFilePath(txtDiagnosticExportFolderPath.Text.Trim(), "CSV");
 
        }

        private void btnPickFolderBlobProperties_Click(object sender, EventArgs e)
        {
            string sFolderPath = string.Empty;
            System.Windows.Forms.FolderBrowserDialog oFDB = new FolderBrowserDialog();

            //oFDB.DefaultExt = "bin";
            //oFDB.Filter = "bin files (*.bin)|*.bin";
            //oFDB.FilterIndex = 1;
            //oFDB.Title = "Save item as bin";

            oFDB.SelectedPath = txtBlobFolderPath.Text;
            if (oFDB.ShowDialog() == DialogResult.OK)
            {
                sFolderPath = oFDB.SelectedPath;

                txtBlobFolderPath.Text = sFolderPath;
            }
        }

        private void chkIncludeMime_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkIncludeUsersAdditionalProperties_CheckedChanged(object sender, EventArgs e)
        {
           // txtIncludeUsersAdditionalPropertiesFile.Enabled = chkIncludeUsersAdditionalProperties.Checked;
            btnPickFolderIncludeUsersAdditionalProperties.Enabled = chkIncludeUsersAdditionalProperties.Checked;
        }
        
        private void btnPickFolderIncludeUsersAdditionalProperties_Click(object sender, EventArgs e)
        {

            List<AdditionalPropertyDefinition> oAPD = null;
            List<ExtendedPropertyDefinition> oEPD = null;
 
            string sChosenFile = string.Empty;
             
            sChosenFile = txtIncludeUsersAdditionalPropertiesFile.Text;
             
            if (AdditionalProperties.GetAdditionalPropertiesFromCsv(ref sChosenFile, ref oAPD, ref oEPD))
            {
                AdditionalPropertyDefinitions = oAPD;
                ExtendedPropertyDefinitions = oEPD;

                this.txtIncludeUsersAdditionalPropertiesFile.Text = sChosenFile;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
