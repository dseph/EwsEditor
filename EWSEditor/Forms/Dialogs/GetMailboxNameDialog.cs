using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class GetMailboxNameDialog : DialogForm
    {
        private GetMailboxNameDialog()
        {
            InitializeComponent();
        }

        public static DialogResult ShowDialog(ref Mailbox mbx)
        {
            GetMailboxNameDialog dialog = new GetMailboxNameDialog();
            DialogResult res = dialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                mbx = new Mailbox(dialog.txtSMTP.Text);
            }

            return res;
        }
    }
}