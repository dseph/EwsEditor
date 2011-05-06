using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

using EWSEditor.Common;

namespace EWSEditor.Forms
{
    public partial class NetworkCredDialog : DialogForm
    {
        private string ServiceURL = null;

        public static DialogResult ShowDialog(string serviceURL, ref NetworkCredential cred)
        {
            NetworkCredDialog form = new NetworkCredDialog();
            
            form.ServiceURL = serviceURL;
            form.txtUserName.Text = cred.UserName;
            
            form.txtDomain.Text = cred.Domain;

            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                cred.Domain = form.txtDomain.Text;
                cred.Password = form.txtPassword.Text;
                cred.UserName = form.txtUserName.Text;
            }

            return result;
        }

        private NetworkCredDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length > 0 &&
                txtPassword.Text.Length > 0 &&
                txtDomain.Text.Length > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                ErrorDialog.ShowInfo("You must input a user name, password, and domain!");
            }
        }

        private void NetworkCredDialog_Load(object sender, EventArgs e)
        {
            this.lblService.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "Enter credentials for {0}", ServiceURL);

            if (this.txtUserName.Text.Length > 0)
            {
                this.SelectNextControl(this.txtUserName, true, true, false, false);
            }
        }
    }
}
