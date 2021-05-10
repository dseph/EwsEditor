using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EWSEditor.Common;
using Microsoft.Exchange.WebServices.Data;


namespace EWSEditor.Common
{
    public partial class PostFormQuickHeaders : Form
    {
        bool _choseOK = false;

        public bool choseOK
        {
            get { return _choseOK; }
        }

        public bool choseNewClientRequestId
        {
            get { return this.chkClientRequestId.Checked; }
        }
        public bool choseReturnClientRequestId
        {
            get { return this.chkReturnClientRequestId.Checked; }
        }
        public bool choseLoginToken
        {
            get { return this.chkoAuthHeaderFromLogin.Checked; }
        }

        public bool choseXAnchorMailbox
        {
            get { return this.chkXAnchorMailbox.Checked; }
        }

        public string XAnchorMailbox
        {
            get { return this.txtXAnchorMailbox.Text.Trim(); }
            set { this.txtXAnchorMailbox.Text = value; }
        }


        private EwsEditorAppSettings _CurrentAppSettings = null;

        public PostFormQuickHeaders()
        {
            InitializeComponent();
        }

        public PostFormQuickHeaders(EwsEditorAppSettings oCurrentAppSettings)
        {
            InitializeComponent();
            _CurrentAppSettings = oCurrentAppSettings;
        }

         

        private void btnOK_Click(object sender, EventArgs e)
        {
            _choseOK = true;
            this.Close();
        }

        private void PostFormQuickHeaders_Load(object sender, EventArgs e)
        {
            if (_CurrentAppSettings.oBearerToken.Trim().Length == 0)
                chkoAuthHeaderFromLogin.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _choseOK = false;
            this.Close();
        }
    }
}
