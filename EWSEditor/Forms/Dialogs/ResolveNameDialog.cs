using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;

using EWSEditor.Common;

namespace EWSEditor.Forms
{
    public partial class ResolveNameDialog : DialogForm
    {
        private ResolveNameDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Allow the dialog to return a single result selection
        /// from the list of results from ResolveName
        /// </summary>
        /// <param name="service">ServiceBinding to use to make calls.</param>
        /// <param name="name">Selected name.</param>
        public static DialogResult ShowDialog(ExchangeService service, out NameResolution name)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service", ExceptionHelper.ExchangeServiceRequiredMessage);
            }

            ResolveNameDialog diag = new ResolveNameDialog();
            diag.CurrentService = service;

            DialogResult res = diag.ShowDialog();

            if (res == DialogResult.OK && diag.lstNames.SelectedItems.Count == 1)
            {
                name = diag.lstNames.SelectedItems[0].Tag as NameResolution;
            }
            else
            {
                name = null;
            }

            return res;
        }

        public static DialogResult ShowDialog(ExchangeService service)
        {
            NameResolution name = null;
            return ResolveNameDialog.ShowDialog(service, out name);
        }

        /// <summary>
        /// Call ResolveName and display results
        /// </summary>
        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                NameResolutionCollection names = this.CurrentService.ResolveName(
                    txtName.Text,
                    ResolveNameSearchLocation.DirectoryThenContacts, 
                    true);

                // Clear out previous results
                lstNames.Items.Clear();

                // Load new results
                foreach (NameResolution name in names)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = name.Mailbox.Name;
                    item.Tag = name;
                    item.SubItems.Add(name.Mailbox.Address);
                    lstNames.Items.Add(item);
                }

                // Select the first result by default
                if (lstNames.Items.Count > 0)
                {
                    this.lstNames.Items[0].Selected = true;
                    this.lstNames.Focus();
                }

                // Pressing <enter> will now execute the OK button
                this.AcceptButton = this.btnOK;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Double clicking selects the item and closes the form.
        /// </summary>
        private void lstNames_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // Pressing <enter> will now execute the Go button
            this.AcceptButton = this.btnGo;
        }
    }
}
