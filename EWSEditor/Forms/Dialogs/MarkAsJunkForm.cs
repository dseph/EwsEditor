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
using EWSEditor.Exchange;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class MarkAsJunkForm : Form
    {

        ExchangeService _service = null;
        ItemId _itemId = null;

        public MarkAsJunkForm()
        {
            InitializeComponent();
        }

        public MarkAsJunkForm(ExchangeService service, ItemId itemId)
        {
            _service = service;
            _itemId = itemId;

            InitializeComponent();
        }

        private void ShowState()
        {
            string s = string.Empty;

            if (chkIsJunk.Checked == true && chkMoveItem.Checked == true)
                s = "The sender of the target email message is added to the blocked sender list and the email message is moved to the Junk Dmail folder.";
            if (chkIsJunk.Checked == true && chkMoveItem.Checked == false)
                s = "The sender of the target email message is added to the blocked sender list and the email message is not moved from the folder.";
            if (chkIsJunk.Checked == false && chkMoveItem.Checked == true)
                s = "The sender of the target email message is removed from the blocked sender list and the email message is moved to the Inbox folder.";
            if (chkIsJunk.Checked == false && chkMoveItem.Checked == false)
                s = "Tthe sender of the target email message is removed from the blocked sender list and the email message is not moved from the folder.";
            txtInfo.Text = s;
        }


        private void MarkAsJunkForm_Load(object sender, EventArgs e)
        {
            StringBuilder oSB = new StringBuilder();
            oSB.AppendFormat("* {0}",
                "If the IsJunk attribute is set to true, and the MoveItem attribute is set to true, the sender of the target email message is added to the blocked sender list and the email message is moved to the Junk Dmail folder.");
            oSB.AppendLine();
            oSB.AppendFormat("* {0}",
               "If the IsJunk attribute is set to true, and the MoveItem attribute is set to false, the sender of the target email message is added to the blocked sender list and the email message is not moved from the folder.");
            oSB.AppendLine();
            oSB.AppendFormat("* {0}",
               "If the IsJunk attribute is set to false, and the MoveItem attribute is set to true, the sender of the target email message is removed from the blocked sender list and the email message is moved to the Inbox folder.");
            oSB.AppendLine();
            oSB.AppendFormat("* {0}",
               "If the IsJunk attribute is set to false, and the MoveItem attribute is set to false, the sender of the target email message is removed from the blocked sender list and the email message is not moved from the folder.");
            oSB.AppendLine();
            txtHelp.Text = oSB.ToString();

            ShowState();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            List<ItemId> oItemIds = new List<ItemId>();
            oItemIds.Add(_itemId);
            try
            {
                _service.MarkAsJunk(oItemIds, chkIsJunk.Checked, chkMoveItem.Checked);
            }
            catch (ServiceResponseException exServiceResponseException)
            {
                Console.WriteLine("Error marking item as junk: {0}", exServiceResponseException.Message);
               // Console.WriteLine("Error marking item as junk: {0}", exServiceResponseException.ErrorCode;
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error marking item as junk: {0}", ex.Message);
                return;
            }
            this.Close();
        }

        private void chkMoveItem_CheckedChanged(object sender, EventArgs e)
        {
            ShowState();
        }

        private void chkIsJunk_CheckedChanged(object sender, EventArgs e)
        {
            ShowState();
        }
    }
}
