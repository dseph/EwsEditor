namespace EWSEditor.Forms
{
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
    using EWSEditor.Forms.Controls;

    public partial class PermissionsDialog : DialogForm
    {
        private Folder CurrentFolder = null;
        private FolderId CurrentFolderId = null;
        private FolderPermissionLevel? LastPermLevel = null;

        private EnumComboBox<FolderPermissionLevel> permissionLevelCombo = new EnumComboBox<FolderPermissionLevel>();

        private PermissionsDialog()
        {
            InitializeComponent();
        }

        public static DialogResult Show(ExchangeService service, FolderId id)
        {
            PermissionsDialog diag = new PermissionsDialog();
            diag.CurrentFolderId = id;
            diag.CurrentService = service;

            return diag.ShowDialog();
        }

        /// <summary>
        /// Initialize form controls based on the current Permissions
        /// settings.
        /// </summary>
        private void PermissionsDialog_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Get the Folder with just the Id and Permissions properties
                PropertySet propSet = new PropertySet(BasePropertySet.IdOnly);
                propSet.Add(FolderSchema.Permissions);
                CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
                this.CurrentFolder = Folder.Bind(CurrentService, CurrentFolderId, propSet);

                this.permissionLevelCombo.TransformComboBox(this.TempPermissionLevelCombo);
                this.permissionLevelCombo.HasEmptyItem = true;

                // Load the list box of all the users who have
                // permissions
                foreach (FolderPermission fp in this.CurrentFolder.Permissions)
                {
                    AddFolderPermissionToList(fp);
                }

                // If there are items in the list, select the first.
                if (lstUsers.Items.Count > 0)
                {
                    lstUsers.Items[0].Selected = true;
                }

                PermissionToFormState();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Update the FolderPermission to reflect control changes
        /// </summary>
        private void FolderPermissionChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                FormStateToPermission();

                PermissionToFormState();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Update changes to the PermissionLevel and reload the
        /// form controls
        /// </summary>
        private void cboPermissionLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                FormStateToPermission();

                PermissionToFormState();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Update that form controls based on the FolderPermission
        /// settings of the selected user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (lstUsers.SelectedIndices.Count == 0)
                {
                    btnRemove.Enabled = false;
                }
                else
                {
                    btnRemove.Enabled = true;
                }

                // Reset this field each time a delegate is selected.
                LastPermLevel = null;

                PermissionToFormState();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Remove the selected user from the list, when the
        /// form is committed the FolderPermission will be
        /// removed from the collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                lstUsers.Items.Remove(lstUsers.SelectedItems[0]);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Commit the changes made to the Permissions
        /// collection.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Clear the current set of permissions
                this.CurrentFolder.Permissions.Clear();

                // Add the updated set of permissions
                foreach (ListViewItem item in lstUsers.Items)
                {
                    FolderPermission newPermission = item.Tag as FolderPermission;
                    this.CurrentFolder.Permissions.Add(newPermission);
                }

                // Commit changes.
                this.CurrentFolder.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                this.CurrentFolder.Update();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Translate the state of the form's controls into
        /// property values on the selected FolderPermission.
        /// </summary>
        private void FormStateToPermission()
        {
            // There shouldn't be more than one item selected
            if (lstUsers.SelectedItems.Count != 1) return;

            FolderPermission selectedPermission = lstUsers.SelectedItems[0].Tag as FolderPermission;
            
            selectedPermission.CanCreateItems = chkCreateItems.Checked;
            selectedPermission.CanCreateSubFolders = chkCreateSubFolders.Checked;

            if (rdoDeleteAll.Checked)
            {
                selectedPermission.DeleteItems = PermissionScope.All;
            }
            else if (rdoDeleteNone.Checked)
            {
                selectedPermission.DeleteItems = PermissionScope.None;
            }
            else if (rdoDeleteOwn.Checked)
            {
                selectedPermission.DeleteItems = PermissionScope.Owned;
            }

            if (chkEditAll.Checked)
            {
                selectedPermission.EditItems = PermissionScope.All;
            }
            else if (chkEditOwn.Checked && !chkEditAll.Checked)
            {
                selectedPermission.EditItems = PermissionScope.Owned;
            }
            else if (!chkEditAll.Checked && !chkEditOwn.Checked)
            {
                selectedPermission.EditItems = PermissionScope.None;
            }

            selectedPermission.IsFolderContact = chkContact.Checked;
            selectedPermission.IsFolderOwner = chkOwner.Checked;
            selectedPermission.IsFolderVisible = chkVisible.Checked;

            if (rdoReadFull.Checked)
            {
                selectedPermission.ReadItems = FolderPermissionReadAccess.FullDetails;
            }
            else if (rdoReadNone.Checked)
            {
                selectedPermission.ReadItems = FolderPermissionReadAccess.None;
            }
            else if (rdoTimeOnly.Checked)
            {
                selectedPermission.ReadItems = FolderPermissionReadAccess.TimeOnly;
            }
            else if (rdoTimeSubjectLocation.Checked)
            {
                selectedPermission.ReadItems = FolderPermissionReadAccess.TimeAndSubjectAndLocation;
            }

            // If the permission level was changed and is not custom, then it
            // trumps any individual settings on the form.
            FolderPermissionLevel permLevel = this.permissionLevelCombo.SelectedItem.Value;

            if (LastPermLevel.Value != permLevel)
            {
                if (permLevel != FolderPermissionLevel.Custom)
                {
                    selectedPermission.PermissionLevel = permLevel;
                }
            }
        }

        /// <summary>
        /// Use the selected FolderPermission to update the
        /// form's controls.
        /// </summary>
        private void PermissionToFormState()
        {
            try
            {
                // Since we're programmatically changing all these controls we
                // want to disable events so we don't get a storm of event
                // notifications
                DisableFormEvents();

                // There shouldn't be more than one item selected
                if (lstUsers.SelectedItems.Count != 1) return;

                FolderPermission selectedPermission = lstUsers.SelectedItems[0].Tag as FolderPermission;

                lstUsers.SelectedItems[0].SubItems[1].Text = selectedPermission.PermissionLevel.ToString();
                this.permissionLevelCombo.SelectedItem = selectedPermission.PermissionLevel;

                if (!LastPermLevel.HasValue)
                {
                    LastPermLevel = selectedPermission.PermissionLevel;
                }

                switch (selectedPermission.ReadItems)
                {
                    case FolderPermissionReadAccess.None:
                        rdoReadNone.Checked = true;
                        break;
                    case FolderPermissionReadAccess.FullDetails:
                        rdoReadFull.Checked = true;
                        break;
                    case FolderPermissionReadAccess.TimeAndSubjectAndLocation:
                        rdoTimeSubjectLocation.Checked = true;
                        break;
                    case FolderPermissionReadAccess.TimeOnly:
                        rdoTimeOnly.Checked = true;
                        break;
                }

                switch (selectedPermission.DeleteItems)
                {
                    case PermissionScope.All:
                        rdoDeleteAll.Checked = true;
                        break;
                    case PermissionScope.None:
                        rdoDeleteNone.Checked = true;
                        break;
                    case PermissionScope.Owned:
                        rdoDeleteOwn.Checked = true;
                        break;
                }

                chkCreateItems.Checked = selectedPermission.CanCreateItems;
                chkCreateSubFolders.Checked = selectedPermission.CanCreateSubFolders;

                switch (selectedPermission.EditItems)
                {
                    case PermissionScope.Owned:
                        chkEditOwn.Checked = true;
                        chkEditAll.Checked = false;
                        break;
                    case PermissionScope.All:
                        chkEditOwn.Checked = true;
                        chkEditAll.Checked = true;
                        break;
                    case PermissionScope.None:
                        chkEditAll.Checked = false;
                        chkEditOwn.Checked = false;
                        break;
                }

                chkOwner.Checked = selectedPermission.IsFolderOwner;
                chkVisible.Checked = selectedPermission.IsFolderVisible;
                chkContact.Checked = selectedPermission.IsFolderContact;
            }
            finally
            {
                // Always turn the events back on.
                EnableFormEvents();
            }
        }

        /// <summary>
        /// Add the given permission to the ListView
        /// </summary>
        private void AddFolderPermissionToList(FolderPermission permission)
        {
            ListViewItem item = new ListViewItem();

            // Store the actul FolderPermission object for later use
            item.Tag = permission;

            // Standard users like Default and Anonymous don't
            // have a UserId.DisplayName, use UserId.StandardUser
            // instead.
            if (permission.UserId.DisplayName != null)
            {
                item.Text = permission.UserId.DisplayName;
            }
            else
            {
                item.Text = permission.UserId.StandardUser.ToString();
            }
            item.SubItems.Add(permission.PermissionLevel.ToString());

            lstUsers.Items.Add(item);
        }

        /// <summary>
        /// Enable the form events on permission controls
        /// </summary>
        private void EnableFormEvents()
        {
            this.lstUsers.SelectedIndexChanged += lstUsers_SelectedIndexChanged;
            this.permissionLevelCombo.SelectedIndexChanged += cboPermissionLevel_SelectedIndexChanged;

            this.chkContact.CheckedChanged += FolderPermissionChanged;
            this.chkCreateItems.CheckedChanged += FolderPermissionChanged;
            this.chkCreateSubFolders.CheckedChanged += FolderPermissionChanged;
            this.chkEditAll.CheckedChanged += FolderPermissionChanged;
            this.chkEditOwn.CheckedChanged += FolderPermissionChanged;
            this.chkOwner.CheckedChanged += FolderPermissionChanged;
            this.chkVisible.CheckedChanged += FolderPermissionChanged;

            this.rdoDeleteAll.CheckedChanged += FolderPermissionChanged;
            this.rdoDeleteNone.CheckedChanged += FolderPermissionChanged;
            this.rdoDeleteOwn.CheckedChanged += FolderPermissionChanged;
            this.rdoReadFull.CheckedChanged += FolderPermissionChanged;
            this.rdoReadNone.CheckedChanged += FolderPermissionChanged;
            this.rdoTimeOnly.CheckedChanged += FolderPermissionChanged;
            this.rdoTimeSubjectLocation.CheckedChanged += FolderPermissionChanged;
        }

        /// <summary>
        /// Disable the form events on permission controls
        /// </summary>
        private void DisableFormEvents()
        {
            this.lstUsers.SelectedIndexChanged -= lstUsers_SelectedIndexChanged;
            this.permissionLevelCombo.SelectedIndexChanged -= cboPermissionLevel_SelectedIndexChanged;

            this.chkContact.CheckedChanged -= FolderPermissionChanged;
            this.chkCreateItems.CheckedChanged -= FolderPermissionChanged;
            this.chkCreateSubFolders.CheckedChanged -= FolderPermissionChanged;
            this.chkEditAll.CheckedChanged -= FolderPermissionChanged;
            this.chkEditOwn.CheckedChanged -= FolderPermissionChanged;
            this.chkOwner.CheckedChanged -= FolderPermissionChanged;
            this.chkVisible.CheckedChanged -= FolderPermissionChanged;

            this.rdoDeleteAll.CheckedChanged -= FolderPermissionChanged;
            this.rdoDeleteNone.CheckedChanged -= FolderPermissionChanged;
            this.rdoDeleteOwn.CheckedChanged -= FolderPermissionChanged;
            this.rdoReadFull.CheckedChanged -= FolderPermissionChanged;
            this.rdoReadNone.CheckedChanged -= FolderPermissionChanged;
            this.rdoTimeOnly.CheckedChanged -= FolderPermissionChanged;
            this.rdoTimeSubjectLocation.CheckedChanged -= FolderPermissionChanged;
        }

        /// <summary>
        /// Show the ResolveNameDialog to get a Mailbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            NameResolution name = null;

            // Show the ResolveNamesDialog to pick a user
            if (ResolveNameDialog.ShowDialog(this.CurrentService, out name) == DialogResult.OK)
            {
                // Create a FolderPermission and add it to the ListView
                UserId user = new UserId();
                user.DisplayName = name.Mailbox.Name;
                user.PrimarySmtpAddress = name.Mailbox.Address;

                FolderPermission permission = new FolderPermission(user, FolderPermissionLevel.None);

                AddFolderPermissionToList(permission);
            }
        }
    }
}
