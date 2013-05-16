using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EWSEditor.EwsVsProxy;

namespace EWSEditor.Forms
{
 
    public partial class UploadItemForm : Form
    {

        CreateActionType _CreateActionType = new CreateActionType();

        public bool ChoseOk = false;
        public string ChoseFileToUpload = string.Empty;
        public CreateActionType ChoseCreateActionType = CreateActionType.CreateNew;
        public string ChoseItemId = string.Empty;

        public UploadItemForm()
        {
            InitializeComponent();
        }

        private void rdoCreateNew_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCreateActionRelated(CreateActionType.CreateNew );

             
        }

        private void UpdateCreateActionRelated(CreateActionType oCreateActionType)
        {
            _CreateActionType = oCreateActionType;
             
            switch (oCreateActionType)
            {
                case CreateActionType.CreateNew:
                    txtItemId.Enabled = false;
                    break;
                case CreateActionType.Update:
                    txtItemId.Enabled = true;
                    break;
                case CreateActionType.UpdateOrCreate:
                    txtItemId.Enabled = true;
                    break;
            }
        }

        private void rdoUpdateOrCreate_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCreateActionRelated(CreateActionType.UpdateOrCreate);
        }
 

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool bFail = false;
 
            if (_CreateActionType == CreateActionType.UpdateOrCreate ||
                _CreateActionType == CreateActionType.Update)
            {
                if (txtFile.Text.Trim().Length == 0)
                {
                    MessageBox.Show("ItemId is required for Update and UpdateOrCreate operations.", "EntryID required");
                    bFail = true;
                }
            }

            if (bFail == false)
            {
                if (System.IO.File.Exists(txtFile.Text.Trim()) == false)
                {
                    MessageBox.Show("The file specified does not exist.", "File Not Found");
                    bFail = true;
                }
            }

            if (bFail == false)
            {
                this.ChoseOk = true;
                this.ChoseFileToUpload = txtFile.Text.Trim();
                this.ChoseItemId = txtItemId.Text.Trim();
                this.ChoseCreateActionType = _CreateActionType;

                this.Close();
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ChoseOk = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose an export stream file to import...";
            ofd.Multiselect = false;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.txtFile.Text = ofd.FileName; 
            }
             
        }

        private void UploadItemForm_Load(object sender, EventArgs e)
        {
            rdoCreateNew.Checked = true;
        }

        private void rdoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCreateActionRelated(CreateActionType.Update);
        }
    }
}
