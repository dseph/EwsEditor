using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Exchange.WebServices.Data;

using EWSEditor.Forms;

namespace EWSEditor
{
    public partial class SyncFolderItemsForm : CountedForm
    {
        private PropertySet CurrentPropertySet = new PropertySet();
        private FolderId CurrentFolderId;

        public SyncFolderItemsForm()
        {
            InitializeComponent();
        }

        public static void Show(ExchangeService service)
        {
            Show(service, null);
        }

        public static void Show(ExchangeService service, FolderId parentFolderId)
        {
            SyncFolderItemsForm diag = new SyncFolderItemsForm();

            // Only try to populate CurrentFolderId if we were passed a value
            if (parentFolderId != null)
            {
                diag.SetAndDisplayFolderId(parentFolderId);
            }
            diag.CurrentService = service;

            diag.Show();
        }

        private void btnSynchronize_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool keepGoing = true;
                int totalItems = 0;

                this.lstChanges.Items.Clear();

                while (keepGoing)
                {
                    ChangeCollection<ItemChange> changes = this.CurrentService.SyncFolderItems(
                        this.CurrentFolderId,
                        this.CurrentPropertySet,
                        null,
                        500,
                        SyncFolderItemsScope.NormalItems,
                        this.txtSyncState.Text);

                    keepGoing = changes.MoreChangesAvailable;

                    foreach (ItemChange change in changes)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = change;
                        item.Text = change.ChangeType.ToString();
                        item.SubItems.Add(change.IsRead.ToString());
                        item.SubItems.Add(change.ItemId.UniqueId);

                        lstChanges.Items.Add(item);
                    }

                    this.txtSyncState.Text = changes.SyncState;
                    totalItems = totalItems + changes.Count;
                }

                this.lblLastSyncTime.Text = string.Format(Application.CurrentCulture, "Last SyncFolderItems: {0}", DateTime.Now.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Display the GetFolderIdDialog to get a valid FolderId object and
        /// call SetAndDisplayFolderId.
        /// </summary>
        private void btnGetFolderId_Click(object sender, EventArgs e)
        {
            FolderId folderId = null;
            if (Forms.FolderIdDialog.ShowDialog(ref folderId) == DialogResult.OK)
            {
                SetAndDisplayFolderId(folderId);
            }
        }

        /// <summary>
        /// Configure the PropertySet for the SyncFolderItems request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPropSet_Click(object sender, EventArgs e)
        {
            // Display PropertiesDialog
            PropertySet propSet = this.CurrentPropertySet;
            if (PropertySetDialog.Show(ref propSet) == DialogResult.OK)
            {
                this.CurrentPropertySet = propSet;
            }
        }

        /// <summary>
        /// Set the class variable and disaply the proper text for the given
        /// FolderId
        /// </summary>
        /// <param name="folderId"></param>
        private void SetAndDisplayFolderId(FolderId folderId)
        {
            this.txtFolderId.Text = PropertyInformation.TypeValues.FolderIdTypeValue.GetValue(folderId, true);
            this.CurrentFolderId = folderId;

            // Reset form elements
            this.lstChanges.Items.Clear();
            this.lblLastSyncTime.Text = string.Empty;
        }

        private void lstChanges_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
