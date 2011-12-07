using System;
using System.Windows.Forms;
using EWSEditor.Forms.Controls;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class FolderIdDialog : DialogForm
    {
        private FolderId currentFolderId = null;
        private EnumComboBox<WellKnownFolderName> wellKnownFolderCombo = new EnumComboBox<WellKnownFolderName>();

        private FolderIdDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show modal FolderIdDialog, if 'OK' not clicked return
        /// NULL.
        /// </summary>
        /// <param name="id">Output parameter.</param>
        /// <returns>
        /// DialogResult indicating whether the user clicked
        /// OK or cancelled the dialog.
        /// </returns>
        public static DialogResult ShowDialog(ref FolderId id)
        {
            id = null;

            FolderIdDialog dialog = new FolderIdDialog();

            DialogResult res = ((Form)dialog).ShowDialog();

            if (res == DialogResult.OK)
            {
                id = dialog.currentFolderId;
            }

            return res;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (UniqueIdRadio.Checked)
            {
                if (this.SpecFolderIdText.Text.Length == 0)
                {
                    ErrorDialog.ShowWarning("A FolderId must be entered.");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                this.currentFolderId = new FolderId(this.SpecFolderIdText.Text);
            }
            else if (WellKnownRadio.Checked)
            {
                WellKnownFolderName name = this.wellKnownFolderCombo.SelectedItem.Value;

                // Exchange throws a schema validation error if FolderId(WellKnownName, Mailbox)
                // is passed an empty string for mailbox address so don't do that!
                if (this.MailboxAddressText.Text.Length == 0)
                {
                    this.currentFolderId = new FolderId(name);
                }
                else
                {
                    this.currentFolderId = new FolderId(name, new Mailbox(MailboxAddressText.Text));
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
            }
        }

        private void FolderIdDialog_Load(object sender, EventArgs e)
        {
            this.UniqueIdRadio.Checked = true;

            this.wellKnownFolderCombo.TransformComboBox(this.TempWellKnownFolderCombo);
            this.wellKnownFolderCombo.SelectedItem = WellKnownFolderName.Root;
        }
    }
}
