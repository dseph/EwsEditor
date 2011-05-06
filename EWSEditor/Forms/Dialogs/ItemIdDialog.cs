using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class ItemIdDialog : DialogForm
    {
        private ItemIdDialog()
        {
            InitializeComponent();
        }

        public static DialogResult ShowDialog(out ItemId itemId)
        {
            itemId = null;

            ItemIdDialog diag = new ItemIdDialog();
            diag.Text = "Enter a Item's Id...";
            DialogResult res = diag.ShowDialog();

            if (res == DialogResult.OK)
            {
                itemId = new ItemId(diag.txtUniqueId.Text);
            }

            return res;
        }
    }
}
