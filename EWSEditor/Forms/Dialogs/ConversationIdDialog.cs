using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class ConversationIdDialog : DialogForm
    {
        public PropertySet CurrentPropertySet = null;
        public ConversationId CurrentConversationId = null;
        public FolderId CurrentFolderId = null; 
        public bool ChoseOK = false;

        public ConversationIdDialog()
        {
            InitializeComponent();

            CurrentPropertySet = new PropertySet(BasePropertySet.FirstClassProperties);
 
        }
 

        private void btnPropSet_Click(object sender, EventArgs e)
        {
            PropertySet propSet = this.CurrentPropertySet;
            if (PropertySetDialog.Show(ref propSet) == DialogResult.OK)
            {
                this.CurrentPropertySet = propSet;
            }
        }

        private void btnGetFolderId_Click(object sender, EventArgs e)
        {
            FolderIdDialog oForm = new FolderIdDialog(this.CurrentService);
            oForm.ShowDialog();
            if (oForm.ChoseOK == true)
            {
                //oForm.ChosenFolderId 

                CurrentFolderId = oForm.ChosenFolderId;
                this.txtFolderId.Text = PropertyInformation.TypeValues.FolderIdTypeValue.GetValue(oForm.ChosenFolderId, true);
            }

            //FolderId oFolder = null;
            //if (Forms.FolderIdDialog.ShowDialog(ref oFolder) == DialogResult.OK)
            //{
            //    CurrentFolderId = oFolder;
            //    this.txtFolderId.Text = PropertyInformation.TypeValues.FolderIdTypeValue.GetValue(oFolder, true);

            //}
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool bFail =false;
            if (txtConversationId.Text.Trim() == string.Empty )
            {
                bFail = true;
                MessageBox.Show("Conversation Id must not be blank.");
            }
            if (CurrentFolderId == null)
            {
                bFail = true;
                MessageBox.Show("FolderId is not set.");
            }
            if (CurrentPropertySet == null)
            {
                bFail = true;
                MessageBox.Show("PropertySet is not set.");
            }

            if (bFail == false)
            {
                CurrentConversationId = new ConversationId(txtConversationId.Text);
                ChoseOK = true;
                this.Close();
            }
        }

        private void ConversationIdDialog_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ChoseOK = false;
        }

       

 
 
    }
}
