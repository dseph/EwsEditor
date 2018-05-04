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
   
        //private PropertySet _CurrentPropSet;

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

                //NameResolutionCollection oNameResolutionCollection = this.CurrentService.ResolveName(
                //    txtName.Text,
                //    ResolveNameSearchLocation.DirectoryThenContacts, 
                //    chkReturnContactDetails.Checked 
                //    );

                ResolveNameSearchLocation oResolveNameSearchLocation = ResolveNameSearchLocation.ContactsThenDirectory;
                switch (cmboResolveNameSearchLocation.Text)
                {
                    case "DirectoryOnly":
                        oResolveNameSearchLocation = ResolveNameSearchLocation.DirectoryOnly;
                        break;
                    case "DirectoryThenContacts":
                        oResolveNameSearchLocation = ResolveNameSearchLocation.ContactsThenDirectory;
                        break;
                    case "ContactsOnly":
                        oResolveNameSearchLocation = ResolveNameSearchLocation.ContactsOnly;
                        break;
                    case "ContactsThenDirectory":
                        oResolveNameSearchLocation = ResolveNameSearchLocation.DirectoryThenContacts;
                        break;
                }

                NameResolutionCollection oNameResolutionCollection = this.CurrentService.ResolveName(
                        txtName.Text,
                       oResolveNameSearchLocation,
                        chkReturnContactDetails.Checked
                );

                // Clear out previous results
                lstNames.Items.Clear();

                // Load new results
                foreach (NameResolution name in oNameResolutionCollection)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = name.Mailbox.Name;
                    item.Tag = name;
                    item.SubItems.Add(name.Mailbox.Address);
                    item.SubItems.Add(name.Mailbox.RoutingType);
                    if (name.Mailbox.Id != null)
                        item.SubItems.Add(name.Mailbox.Id.UniqueId);
                    else
                        item.SubItems.Add("");
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResolveNameDialog_Load(object sender, EventArgs e)
        {

            //_CurrentPropSet = new PropertySet(
            //    BasePropertySet.FirstClassProperties,
            //    ContactSchema.GivenName,
            //    ContactSchema.MiddleName,
            //    ContactSchema.Surname,
            //    ContactSchema.CompanyName,
            //    ContactSchema.JobTitle,
            //    ContactSchema.Body,
            //    ContactSchema.PhysicalAddresses,
            //    ContactSchema.PhoneNumbers,
            //    ContactSchema.HasPicture,
            //    ContactSchema.HasAttachments,
            //    ContactSchema.IsAssociated,
            //    ContactSchema.Isdn,
            //    ContactSchema.IsDraft,
            //    ContactSchema.IsFromMe,
            //    ContactSchema.IsReminderSet,
            //    ContactSchema.IsReminderSet,
            //    ContactSchema.IsResend,
            //    ContactSchema.IsSubmitted,
            //    ContactSchema.IsUnmodified,
            //    ContactSchema.ItemClass,
            //    ContactSchema.JobTitle,
            //    ContactSchema.LastModifiedName,
            //    ContactSchema.LastModifiedTime,
            //    ContactSchema.Manager,
            //    ContactSchema.MiddleName,
            //    ContactSchema.PhoneNumbers,
            //    ContactSchema.Profession,
            //    ContactSchema.SpouseName,
            //    ContactSchema.Subject,
            //    ContactSchema.Sensitivity,
            //    ContactSchema.Surname,
            //    ContactSchema.UniqueBody,
            //    ContactSchema.WeddingAnniversary,
            //    ContactSchema.DateTimeCreated,
            //    ContactSchema.DateTimeReceived,
            //    ContactSchema.DateTimeSent,
            //    ContactSchema.LastModifiedTime,
            //    ContactSchema.LastModifiedName,
            //    ContactSchema.AssistantName,
            //    ContactSchema.AssistantPhone,
            //    ContactSchema.Categories,
            //    ContactSchema.Attachments,
            //    new ExtendedPropertyDefinition(0x001A, MapiPropertyType.String) // item class

            //);

 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void lstNames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
