using System;
using System.Windows.Forms;
using EWSEditor.Forms.Controls;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Forms.Dialogs;

namespace EWSEditor.Forms
{
    public partial class FolderIdDialog : DialogForm
    {
        public bool ChoseOK = false;
        public FolderId ChosenFolderId = null;
        private EnumComboBox<WellKnownFolderName> wellKnownFolderCombo = new EnumComboBox<WellKnownFolderName>();
        private ExchangeService _ExchangeService = null;

        public FolderIdDialog()
        {
            InitializeComponent();
        }

        public FolderIdDialog(ExchangeService oExchangeService)
        {
            InitializeComponent();

            _ExchangeService = oExchangeService;
  
        }

         
        ///// <summary>
        ///// Show modal FolderIdDialog, if 'OK' not clicked return
        ///// NULL.
        ///// </summary>
        ///// <param name="id">Output parameter.</param>
        ///// <returns>
        ///// DialogResult indicating whether the user clicked
        ///// OK or cancelled the dialog.
        ///// </returns>
        //public static DialogResult ShowDialog(ref FolderId )
        //{
        //    id = null;

        //    //dialog._ExchangeService = oExchangeService;

        //    FolderIdDialog dialog = new FolderIdDialog();

        //    DialogResult res = ((Form)dialog).ShowDialog();

        //    if (res == DialogResult.OK)
        //    {
        //        id = dialog.currentFolderId;
        //    }

        //    return res;
        //}

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (UniqueIdRadio.Checked)
            {
                if (this.SpecFolderIdText.Text.Length == 0)
                {
                    ErrorDialog.ShowWarning("A FolderId must be entered.");
                   // this.DialogResult = DialogResult.None;
                    this.ChoseOK = false;
                }
                else
                {
                    this.ChosenFolderId = new FolderId(this.SpecFolderIdText.Text);
                    this.ChoseOK = true;
                    this.Close();
                }
            }

            if (WellKnownRadio.Checked)
            {
                WellKnownFolderName name = this.wellKnownFolderCombo.SelectedItem.Value;

                // Exchange throws a schema validation error if FolderId(WellKnownName, Mailbox)
                // is passed an empty string for mailbox address so don't do that!
                if (this.MailboxAddressText.Text.Length == 0)
                {
                    this.ChosenFolderId = new FolderId(name);
                }
                else
                {
                    this.ChosenFolderId = new FolderId(name, new Mailbox(MailboxAddressText.Text));
                }

                this.ChoseOK = true;
                this.Close();
            }
             
            if (this.rdoSelectFolder.Checked)
            {
                if (this.txtPickedFolder.Text.Trim().Length == 0)
                {
                    ErrorDialog.ShowWarning("A Folder must be selected.");
                    //this.DialogResult = DialogResult.None;
                    this.ChoseOK = false;
                }
                else
                {
                    // base = {AAMkADE3ZDEyNzIyLWNmYTEtNDJjNC1iMDcxLWQ1YzRlOTllNThmZgAuAAAAAAAPhJtWhlq+R7kfwUCSYEOdAQATi1dys5KiTYjQdU3KXtHXAAABXjDIAAA=}
                    ChosenFolderId = new FolderId(this.txtPickedFolder.Text);
                    this.ChoseOK = true;
                    this.Close();
                }
                 
            }
        }

        private void UniqueIdRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (this.UniqueIdRadio.Checked)
            {
                this.SpecFolderIdText.Enabled = true;
                this.UniqueIdGroup.Enabled = true;

                this.WellKnownRadio.Checked = false;
                this.wellKnownFolderCombo.Enabled = false;
                this.MailboxAddressText.Enabled = false;
                this.WellKnownGroup.Enabled = false;

                this.btnPickFolder.Enabled = false;
                this.txtPickedFolder.Enabled = false;
            }
        }

        private void WellKnownRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (this.WellKnownRadio.Checked)
            {
                this.wellKnownFolderCombo.Enabled = true;
                this.MailboxAddressText.Enabled = true;
                this.WellKnownGroup.Enabled = true;

                this.UniqueIdRadio.Checked = false;
                this.SpecFolderIdText.Enabled = false;
                this.UniqueIdGroup.Enabled = false;

                this.btnPickFolder.Enabled = false;
                this.txtPickedFolder.Enabled = false;
            }
        }

        private void FolderIdDialog_Load(object sender, EventArgs e)
        {
            this.UniqueIdRadio.Checked = true;

            this.wellKnownFolderCombo.TransformComboBox(this.TempWellKnownFolderCombo);
            this.wellKnownFolderCombo.SelectedItem = WellKnownFolderName.Root;
        }

        private void btnPickFolder_Click(object sender, EventArgs e)
        {
            //FolderId oFolderId = null;  // WellKnownFolderName.Root
            FolderId oFolder = WellKnownFolderName.Root;
            SelectFolder oform = new SelectFolder(_ExchangeService, oFolder);
            oform.ShowDialog();
            if (oform.ChoseOK == true)
            {
                //oform.ChosenFolderId;
                this.txtPickedFolder.Text = oform.ChosenFolderId.UniqueId;
                this.ChosenFolderId = oform.ChosenFolderId;
            }

        }

        private void rdoSelectFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoSelectFolder.Checked)
            {

                this.wellKnownFolderCombo.Enabled = false;
                this.MailboxAddressText.Enabled = false;
                this.WellKnownGroup.Enabled = false;

                this.UniqueIdRadio.Checked = false;
                this.SpecFolderIdText.Enabled = false;

                this.btnPickFolder.Enabled = true;
                this.txtPickedFolder.Enabled = false;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ChoseOK = false;
            this.Close();
        }

        private void TempWellKnownFolderCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
