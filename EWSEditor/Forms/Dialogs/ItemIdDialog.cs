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

        public static DialogResult ShowDialog(out ItemId itemId, ExchangeService _CurrentService )
        {
            itemId = null;

            ItemIdDialog diag = new ItemIdDialog();
            diag.Text = "Enter a Item's Id...";

             

            DialogResult res = diag.ShowDialog();

            if (res == DialogResult.OK)
            {
                if (diag.cmboIdType.Text == "UniqueId")
                    itemId = new ItemId(diag.txtUniqueId.Text);

                if (diag.cmboIdType.Text == "StoreId")
                {
                    string sUniqueId = string.Empty;

                    AlternateId FromId = new AlternateId(
                        IdFormat.StoreId,
                        diag.txtUniqueId.Text.Trim(),
                        diag.txtSmtpAddress.Text.Trim()
                        );
                    //FromId.Format = IdFormat.StoreId;
                    //FromId.Mailbox = diag.txtSmtpAddress.Text.Trim();
                    //FromId.UniqueId = diag.txtUniqueId.Text.Trim();

                    AlternateId ToId =
                        (AlternateId)_CurrentService.ConvertId(FromId, IdFormat.EwsId);

                    sUniqueId = ToId.UniqueId;

                    itemId = new ItemId(diag.txtUniqueId.Text);
                }
            }

            return res;
        }

        private void ItemIdDialog_Load(object sender, EventArgs e)
        {
            cmboIdType.Text = "UniqueId";
        }

        private void cmboIdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmboIdType.Text =="UniqueId")
            {
                lblSmtpAddress.Visible = false;
                txtSmtpAddress.Visible = false;
            }
            else
            {  // for converting to storeid
                lblSmtpAddress.Visible = true;
                txtSmtpAddress.Visible = true;
            }
        }
    }
}
