using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EWSEditor.Common;
using EWSEditor.Exchange;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class PlayItemOnPhoneForm : Form
    {
        ExchangeService _service = null;
        ItemId _itemId = null;
        string _dialString = string.Empty;
        PhoneCall _phoneCall = null;
        System.Threading.Timer _callTimer = null;

        public PlayItemOnPhoneForm()
        {
            InitializeComponent();
        }

        public PlayItemOnPhoneForm(ExchangeService service, ItemId itemId, string dialString)
        {
            _service = service;
            _itemId = itemId;
            _dialString = dialString;

            InitializeComponent();
        }

        private void btnPlayOnPhone_Click(object sender, EventArgs e)
        {
            string dialString = txtDialString.Text.Trim();
            if (dialString.Length < 3)
            {
                MessageBox.Show("Phone number is not long enough.");
            }
            else
            {
                PlayOnPhone(_service, _itemId, dialString);
                btnEndCall.Enabled = true;
                btnPlayOnPhone.Enabled = false;
            }
        }

        private void PlayOnPhone(ExchangeService service, ItemId itemId, string dialstring)
        {
            txtBody.Text = "";

            _phoneCall = service.UnifiedMessaging.PlayOnPhone(itemId, dialstring);
            txtBody.Text += string.Format("Call Number: {0}\r\n", dialstring);
            txtBody.Text += string.Format("Call Status: {0}\r\n", _phoneCall.State);

            // Create a timer that will start immediately. The timer will call callback every three seconds.
            _callTimer = new System.Threading.Timer(RefreshPhoneCallState, _phoneCall, 0, 3000);
        }

        // Callback method for refreshing call state for the phone call.
        private void RefreshPhoneCallState(object pCall)
        {
            PhoneCall call = (PhoneCall)pCall;
            call.Refresh();
            //string sAdd = "Call Status: " + call.State + "\r\n";
            //txtBody.Text += sAdd;  // TODO: need to get the body to display updates...
        }

        private void PlayItemOnPhoneForm_Load(object sender, EventArgs e)
        {

        }
 
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBody_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEndCall_Click(object sender, EventArgs e)
        {
 
            // Disconnect the phone call if it is not already disconnected.
            if (_phoneCall.State != PhoneCallState.Disconnected)
            {
                txtBody.Text += string.Format("Disconnecting...\r\n");
                _phoneCall.Disconnect();
                txtBody.Text += string.Format("Disconnected.\r\n\r\n");
              
            }

            // Clean up the timer.
            _callTimer.Dispose();

            btnPlayOnPhone.Enabled = true;
            btnEndCall.Enabled = false;
        }
    }
}
