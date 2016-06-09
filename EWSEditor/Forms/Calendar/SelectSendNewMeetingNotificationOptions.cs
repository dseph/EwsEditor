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
    public partial class SelectSendNewMeetingNotificationOptions : Form
    {
        public bool ChoseOK = false;
        public string SelectedOption = "SendToAllAndSaveCopy";
        public SendInvitationsMode SelectedSendInvitationsMode = SendInvitationsMode.SendToAllAndSaveCopy;


        public SelectSendNewMeetingNotificationOptions()
        {
            InitializeComponent();
        }

        private void SelectSendNewMeetingNotificationOptions_Load(object sender, EventArgs e)
        {
            lbOptions.SelectedIndex = 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ChoseOK = true;
            this.Close();
        }

        private void lbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedOption = lbOptions.SelectedItem.ToString();

            switch (SelectedOption)
            {
                case "SendOnlyToAll":
                    SelectedSendInvitationsMode = SendInvitationsMode.SendOnlyToAll;
                    break;
                case "SendToAllAndSaveCopy":
                    SelectedSendInvitationsMode = SendInvitationsMode.SendToAllAndSaveCopy;
                    break;
                case "SendToNone":
                    SelectedSendInvitationsMode = SendInvitationsMode.SendToNone;
                    break;
            }
        }
    }
}
