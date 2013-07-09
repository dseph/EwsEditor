using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Forms;

namespace EWSEditor.Forms
{
    public partial class SelectSendMeetingNotificationOptions : Form
    {
        public bool ChoseOK = false;
        public string SelectedOption = "SendToAllAndSaveCopy";
        public SendInvitationsOrCancellationsMode SelectedSendInvitationsOrCancellationsMode = SendInvitationsOrCancellationsMode.SendToAllAndSaveCopy;

        public SelectSendMeetingNotificationOptions()
        {
            InitializeComponent();
        }

        private void SelectSendMeetingNotificationOptions_Load(object sender, EventArgs e)
        {
            lbOptions.SelectedIndex = 2;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ChoseOK = true;
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedOption = lbOptions.SelectedItem.ToString();

            switch (SelectedOption)
            {
                case "SendOnlyToAll":
                    SelectedSendInvitationsOrCancellationsMode = SendInvitationsOrCancellationsMode.SendOnlyToAll;
                    break;
                case "SendOnlyToChanged":
                    SelectedSendInvitationsOrCancellationsMode = SendInvitationsOrCancellationsMode.SendOnlyToChanged;
                    break;
                case "SendToAllAndSaveCopy":
                    SelectedSendInvitationsOrCancellationsMode = SendInvitationsOrCancellationsMode.SendToAllAndSaveCopy;
                    break;
                case "SendToChangedAndSaveCopy":
                    SelectedSendInvitationsOrCancellationsMode = SendInvitationsOrCancellationsMode.SendToChangedAndSaveCopy;
                    break;
                case "SendToNone":
                    SelectedSendInvitationsOrCancellationsMode = SendInvitationsOrCancellationsMode.SendToNone;
                    break;
            }
        }
    }
}
