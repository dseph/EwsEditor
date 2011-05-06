using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{

    using EWSEditor.Forms.Controls;

    public partial class AutodiscoverViewerForm : EWSEditor.Forms.CountedForm
    {
        public new static DialogResult ShowDialog()
        {
            AutodiscoverViewerForm dialog = new AutodiscoverViewerForm();
            return ((Form)dialog).ShowDialog();
        }

        private AutodiscoverViewerForm()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            AutodiscoverService service = new AutodiscoverService(ExchangeVersion.Exchange2007_SP1);
            GetUserSettingsResponse response = service.GetUserSettings("mstehle@microsoft.com", 
                System.Enum.GetValues(typeof(UserSettingName)) as UserSettingName[]);

            grdDetails.LoadObject(response);
        }
    }
}
