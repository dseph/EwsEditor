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
using EWSEditor.PropertyInformation;

namespace EWSEditor.Forms
{
    public partial class DelegateDialog : DialogForm
    {
        private Mailbox _principalMailbox = null;
        public Mailbox PrincipalMailbox
        {
            get
            {
                this._principalMailbox = new Mailbox(this.txtPrincipal.Text);
                return _principalMailbox;
            }
            set
            {
                if (value != null)
                {
                    this.txtPrincipal.Text = value.Address;
                    this._principalMailbox = value;
                }
                else
                {
                    this.txtPrincipal.Text = string.Empty;
                    this._principalMailbox = value;
                }
            }
        }

        private DelegateInformation DelegateInformation = null;

        private DelegateDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show the form used to display and edit DelegateInformation on the 
        /// default mailbox. 
        /// </summary>
        /// <param name="binding">ServiceBinding to use to make calls.</param>
        /// <returns></returns>
        public static DialogResult ShowDialog(ExchangeService service)
        {
            return ShowDialog(service, null);
        }

        /// <summary>
        /// Show the form used to display and edit DelegateInformation on the 
        /// given mailbox.
        /// </summary>
        /// <param name="binding">ServiceBinding to use to make calls.</param>
        /// <returns>DialogResult - DialogResult.OK means changes were committed.</returns>
        public static DialogResult ShowDialog(ExchangeService service, Mailbox delegator)
        {
            DelegateDialog dialog = new DelegateDialog();
            dialog.PrincipalMailbox = delegator;
            dialog.CurrentService = service;

            return dialog.ShowDialog();
        }

        /// <summary>
        /// Load the dialog with the current delegate settings
        /// by calling RefreshDelegates()
        /// </summary>
        private void DelegateDialog_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // If there is no principal mailbox then there's nothing to do
                if (this.PrincipalMailbox == null) { return; }

                GetDelegateInformation();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Get the delegate list by calling GetDelegates passing the
        /// principal mailbox specified in txtPrincipal
        /// </summary>
        private void btnGetDelegates_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // If there is no principal mailbox then there's nothing to do
                if (this.PrincipalMailbox == null)
                {
                    ErrorDialog.ShowWarning("A principal mailbox must be specified before calling GetDelegates.");
                    return;
                }

                GetDelegateInformation();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Display the DelegateUserDialog to get a new DelegateUser.  After
        /// getting that call AddDelegate
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DelegateUser newDelegate = null;

            if (DelegateUserDialog.ShowDialog(this.CurrentService, ref newDelegate) == DialogResult.OK &&
                newDelegate != null)
            {
                ICollection<DelegateUserResponse> results;

                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    results = this.CurrentService.AddDelegates(
                        this.PrincipalMailbox,
                        GetScopeFromForm(),
                        new DelegateUser[] { newDelegate });
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }

                foreach (DelegateUserResponse result in results)
                {
                    if (result.Result == ServiceResult.Error)
                    {
                        ErrorDialog.ShowWarning(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Failed to add {0}.  {1}, {2}",
                            result.DelegateUser.UserId.StandardUser.HasValue ?
                                result.DelegateUser.UserId.StandardUser.Value.ToString() :
                                result.DelegateUser.UserId.PrimarySmtpAddress,
                             result.ErrorCode.ToString(),
                             result.ErrorMessage));
                    }
                }

                GetDelegateInformation();
            }
        }

        /// <summary>
        /// Display the UserIdDialog to get a UserId of the user to
        /// remove.  Prepopulate UserIdDialog if a delegate is selected
        /// in the delegate list.  After getting a UserId, call RemoveDelegate
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            UserId removeUser = null;

            if (GetSelectedDelegateUser() != null)
            {
                removeUser = GetSelectedDelegateUser().UserId;
            }

            if (UserIdDialog.ShowDialog(this.CurrentService, ref removeUser) == DialogResult.OK &&
                removeUser != null)
            {

                ICollection<DelegateUserResponse> results;
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    results = this.CurrentService.RemoveDelegates(this.PrincipalMailbox,
                        new UserId[] { removeUser });
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }

                foreach (DelegateUserResponse result in results)
                {
                    if (result.Result == ServiceResult.Error)
                    {
                        ErrorDialog.ShowWarning(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Failed to remove delegate.  {0}, {1}",
                             result.ErrorCode.ToString(),
                             result.ErrorMessage));
                    }
                }

                GetDelegateInformation();
            }
        }

        /// <summary>
        /// Show the DelegatePermissionDialog for the selected user.
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // If the dialog result returned is actionable, change the edit
            // state.
            DelegateUser delegateUser = GetSelectedDelegateUser();
            if (DelegateUserDialog.ShowDialog(this.CurrentService, ref delegateUser) == DialogResult.OK)
            {
                ICollection<DelegateUserResponse> results;

                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    results = this.CurrentService.UpdateDelegates(
                        this.PrincipalMailbox,
                        GetScopeFromForm(),
                        new DelegateUser[] { delegateUser });
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }

                foreach (DelegateUserResponse result in results)
                {
                    if (result.Result == ServiceResult.Error)
                    {
                        ErrorDialog.ShowWarning(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Failed to update {0}.  {1}, {2}",
                            result.DelegateUser.UserId.StandardUser.HasValue ?
                                result.DelegateUser.UserId.StandardUser.Value.ToString() :
                                result.DelegateUser.UserId.PrimarySmtpAddress,
                             result.ErrorCode.ToString(),
                             result.ErrorMessage));
                    }
                }

                GetDelegateInformation();
            }
        }

        /// <summary>
        /// If the meeting request delivery scope was updated, commit
        /// the change by calling UpdateDelegate
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            // TODO: A potential problem here is that clicking OK closes the dialog.  The current UI
            // here offers no way to modify MeetingRequestsDeliveryScope on a principal without closing
            // the dialog.  Right now this dialog is typically used to view the delegates of the
            // Act As Account and switching to others won't be common.  If that changes this UI design
            // could be annoying. - mstehle, 9/23/2009
            if (GetScopeFromForm() == this.DelegateInformation.MeetingRequestsDeliveryScope) { return; }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // TODO: There's no way to JUST update the MeetingRequestsDeliveryScope
                //this.CurrentService.AddDelegates(this.PrincipalMailbox, GetScopeFromForm(), new DelegateUser[0]);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Display the ResolveNamesDialog to get a principal mailbox
        /// </summary>
        private void btnResolvePrin_Click(object sender, EventArgs e)
        {
            NameResolution principal = null;
            DialogResult res = ResolveNameDialog.ShowDialog(this.CurrentService, out principal);

            // If no name is returned or dialog result wasn't okay then bailout
            if (res != DialogResult.OK || principal == null) { return; }

            this.PrincipalMailbox = new Mailbox(principal.Mailbox.Address);
        }

        private DelegateUser GetSelectedDelegateUser()
        {
            foreach (DelegateUserResponse userResponse in this.DelegateInformation.DelegateUserResponses)
            {
                if (userResponse.DelegateUser != null &&
                    userResponse.DelegateUser.UserId != null)
                {
                    if (userResponse.DelegateUser.UserId.PrimarySmtpAddress == this.lstDelegates.SelectedItem.ToString())
                    {
                        return userResponse.DelegateUser;
                    }
                }
            }

            return null;
        }

        private void GetDelegateInformation()
        {
            this.lstDelegates.Items.Clear();

            // Get the list of users currently configured as delegates
            this.DelegateInformation = this.CurrentService.GetDelegates(this.PrincipalMailbox, true, new UserId[0]);
            this.grpDelInfo.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "Delegate information for {0}", this.PrincipalMailbox.Address);

            // Convert the list of delegate Display Names into a list
            // of UserIds
            foreach (DelegateUserResponse delegateUser in this.DelegateInformation.DelegateUserResponses)
            {
                if (delegateUser.Result == ServiceResult.Success)
                {
                    lstDelegates.Items.Add(delegateUser.DelegateUser.UserId.PrimarySmtpAddress);
                }
                else
                {
                    // TODO: Design the error behavior here better.
                    //StringBuilder sb = new StringBuilder();
                    //sb.AppendLine("There is a problem with one of the delegates and it cannot be retrieved.");
                    //sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Error: {0}", delegateUser.ErrorCode.ToString()));
                    //sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Message: {0}", delegateUser.ErrorMessage));
                    //ErrorDialog.ShowWarning(sb.ToString());

                    lstDelegates.Items.Add(delegateUser.ErrorCode.ToString());
                }
            }

            // Set the check boxes appropriately
            switch (this.DelegateInformation.MeetingRequestsDeliveryScope)
            {
                case MeetingRequestsDeliveryScope.DelegatesOnly:
                    rdoDelegateOnly.Checked = true;
                    rdoDelegateAndMe.Checked = false;
                    rdoDelegateAndCopy.Checked = false;
                    break;
                case MeetingRequestsDeliveryScope.DelegatesAndSendInformationToMe:
                    rdoDelegateOnly.Checked = false;
                    rdoDelegateAndMe.Checked = false;
                    rdoDelegateAndCopy.Checked = true;
                    break;
                case MeetingRequestsDeliveryScope.DelegatesAndMe:
                    rdoDelegateOnly.Checked = false;
                    rdoDelegateAndMe.Checked = true;
                    rdoDelegateAndCopy.Checked = false;
                    break;
                default:
                    // If we got here then something went really wrong
                    throw new ApplicationException(
                        string.Format(System.Globalization.CultureInfo.CurrentCulture, "Unexpected MeetingRequestsDeliveryScope: {0}",
                        this.DelegateInformation.MeetingRequestsDeliveryScope.ToString()));
            }
        }

        private MeetingRequestsDeliveryScope GetScopeFromForm()
        {
            if (rdoDelegateOnly.Checked)
            {
                return MeetingRequestsDeliveryScope.DelegatesOnly;
            }
            else if (rdoDelegateAndCopy.Checked)
            {
                return MeetingRequestsDeliveryScope.DelegatesAndSendInformationToMe;
            }
            else
            {
                return MeetingRequestsDeliveryScope.DelegatesAndMe;
            }
        }

    }
}
