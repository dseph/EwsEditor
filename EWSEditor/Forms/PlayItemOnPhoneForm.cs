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
            PlayOnPhone(_service, _itemId, _dialString);
        }

        private void PlayOnPhone(ExchangeService service, ItemId itemId, string dialstring)
        {
            txtBody.Text = "";

            _phoneCall = service.UnifiedMessaging.PlayOnPhone(itemId, dialstring);
            txtBody.Text += string.Format("Call Number: {0}", dialstring);
            txtBody.Text += string.Format("Call Status: {0}", _phoneCall.State);

            // Create a timer that will start immediately. The timer will call callback every two seconds.
            _callTimer = new System.Threading.Timer(RefreshPhoneCallState, _phoneCall, 0, 2000);
        }

        // Callback method for refreshing call state for the phone call.
        static void RefreshPhoneCallState(object pCall)
        {
            PhoneCall call = (PhoneCall)pCall;
            call.Refresh();
            string sAdd = "Call Status: " + call.State + "\r\n";
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
            // Create a timer that will start immediately. The timer will call callback every two seconds.
            _callTimer = new System.Threading.Timer(RefreshPhoneCallState, _phoneCall, 0, 2000);
 
            // Disconnect the phone call if it is not already disconnected.
            if (_phoneCall.State != PhoneCallState.Disconnected)
            {
                txtBody.Text += string.Format("Disconnecting...");
                _phoneCall.Disconnect();
                txtBody.Text += string.Format("Disconnected.");
            }

            // Clean up the timer.
            _callTimer.Dispose();
        }
    }
}
