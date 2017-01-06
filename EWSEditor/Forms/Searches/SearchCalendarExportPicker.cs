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

namespace EWSEditor.Forms
{
    public partial class SearchCalendarExportPicker : Form
    {
        public bool bChoseOk = false;

        public SearchCalendarExportPicker()
        {
            InitializeComponent();
        }

        private void SearchCalendarExportPicker_Load(object sender, EventArgs e)
        {
            string StarFolder = Application.StartupPath  + "";
            this.txtDisplayedResultsFolderPath.Text = StarFolder + "\\Export\\ExportedSearchCalendarResults.CSV";
            this.txtAppointmentDetailedFolderPath.Text = StarFolder + "\\Export\\ExportedDetailedAppointmentResults.CSV";
            this.txtMeetingMessageDetailedFolderPath.Text = StarFolder + "\\Export\\ExportedDetailedMeetingMessageResults.CSV";
            this.txtBlobFolderPath.Text = Application.StartupPath + "\\Export";
           
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
 
            txtAppointmentDetailedFolderPath.Text = ChooseFilePath(txtAppointmentDetailedFolderPath.Text.Trim() );


            //System.Windows.Forms.SaveFileDialog oFD = new System.Windows.Forms.SaveFileDialog();
            //string sFullPath = txtAppointmentDetailedFolderPath.Text;
            ////System.Windows.Forms.FolderBrowserDialog oFDB = new FolderBrowserDialog();
             
            //oFD.InitialDirectory = Path.GetPathRoot(sFullPath);
            //oFD.FileName = sFullPath; // = Path.GetFileName(sFullPath);
            //oFD.CheckFileExists = true;
            //oFD.CheckPathExists = true;
            //oFD.DefaultExt = "bin";
            //oFD.Filter = "Bin files (*.bin)|*.bin";
            //oFD.FilterIndex = 1;
            //oFD.Title = "Save item as blob";

            //if (oFD.ShowDialog() == DialogResult.OK)
            //{
            //    sFullPath = oFD.FileName;
            //    txtAppointmentDetailedFolderPath.Text = sFolderPath;
            //}
        }

        private string ChooseFilePath(string sFullPath )
        {
            //string sFolderPath = string.Empty;
            string sNewFullPath = string.Empty;
           
            System.Windows.Forms.SaveFileDialog oFD = new System.Windows.Forms.SaveFileDialog();
            //string sFullPath = txtAppointmentDetailedFolderPath.Text;
            //System.Windows.Forms.FolderBrowserDialog oFDB = new FolderBrowserDialog();

            sNewFullPath = sFullPath;

            oFD.InitialDirectory = Path.GetDirectoryName(sFullPath);
            oFD.FileName = sFullPath; // = Path.GetFileName(sFullPath);
            //oFD.CheckFileExists = true;
            oFD.CheckPathExists = true;
            oFD.DefaultExt = "csv";
            oFD.Filter = "Bin files (*.csv)|*.csv";
            oFD.FilterIndex = 1;
            oFD.Title = "Save item as csv";

            if (oFD.ShowDialog() == DialogResult.OK)
            {
                sNewFullPath = oFD.FileName;
 
                //txtAppointmentDetailedFolderPath.Text = sFolderPath;
            }
            return sNewFullPath;
        }

        private void btnPickFolderMeetingMessageDetailedProperties_Click(object sender, EventArgs e)
        {
            txtMeetingMessageDetailedFolderPath.Text = ChooseFilePath(txtMeetingMessageDetailedFolderPath.Text.Trim());

 
            //string sFolderPath = string.Empty;
            //System.Windows.Forms.FolderBrowserDialog oFDB = new FolderBrowserDialog();

            //oFDB.SelectedPath = txtMeetingMessageDetailedFolderPath.Text;
            //if (oFDB.ShowDialog() == DialogResult.OK)
            //{
            //    sFolderPath = oFDB.SelectedPath;

            //    txtMeetingMessageDetailedFolderPath.Text = sFolderPath;
            //}

        }

        private void btnPickFolderDisplayedResults_Click(object sender, EventArgs e)
        {

            txtDisplayedResultsFolderPath.Text = ChooseFilePath(txtDisplayedResultsFolderPath.Text.Trim());

            //string sFolderPath = string.Empty;
            //System.Windows.Forms.FolderBrowserDialog oFDB = new FolderBrowserDialog();

            //oFDB.SelectedPath = txtDisplayedResultsFolderPath.Text;
            //if (oFDB.ShowDialog() == DialogResult.OK)
            //{
            //    sFolderPath = oFDB.SelectedPath;

            //    txtDisplayedResultsFolderPath.Text = sFolderPath;
            //}
        }

        private void btnPickFolderBlobProperties_Click(object sender, EventArgs e)
        {
            string sFolderPath = string.Empty;
            System.Windows.Forms.FolderBrowserDialog oFDB = new FolderBrowserDialog();

            oFDB.SelectedPath = txtBlobFolderPath.Text;
            if (oFDB.ShowDialog() == DialogResult.OK)
            {
                sFolderPath = oFDB.SelectedPath;

                txtBlobFolderPath.Text = sFolderPath;
            }
        }
    }
}
