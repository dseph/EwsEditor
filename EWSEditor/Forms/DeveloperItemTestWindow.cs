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
using EWSEditor.Logging;
using EWSEditor.Resources;
using EWSEditor.Settings;
using System.Net;
using System.Xml;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class DeveloperItemTestWindow : Form
    {
        ExchangeService _service = null;
        ItemId _itemId = null;

        public DeveloperItemTestWindow()
        {
            InitializeComponent();
        }

        public DeveloperItemTestWindow(ExchangeService service, ItemId itemId)
        {
            InitializeComponent();
            _service = service;
            _itemId = itemId;
        }

        private void DeveloperItemTestWindow_Load(object sender, EventArgs e)
        {
            StringBuilder oSB = new StringBuilder();
            oSB.Append("This window is to be used by develpers with EWSEditor source in order that they may test their EWS Managed API code  to work on a selected item.  ");
            oSB.Append("  The ExchangeService and ItemId are availible in ths form so that you can use them in your custom test code.");
            oSB.AppendLine("");
            oSB.AppendLine("");
            oSB.AppendLine("ItemId.UniqueId: " + _itemId.UniqueId);
            oSB.AppendLine("");
            oSB.AppendLine("ItemId.ChangeKey: " + _itemId.ChangeKey);
           
             
            textBox1.Text = oSB.ToString();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

        }
    }
}
