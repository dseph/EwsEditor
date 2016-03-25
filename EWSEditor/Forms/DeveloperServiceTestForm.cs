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
    public partial class DeveloperServiceTestForm : Form
    {
        ExchangeService _service = null;

        public DeveloperServiceTestForm()
        {
            InitializeComponent();
        }

        public DeveloperServiceTestForm(ExchangeService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void DeveloperToolsTestWindow_Load(object sender, EventArgs e)
        {
 
            StringBuilder oSB = new StringBuilder();
            oSB.Append("This windows is to be used by developers with EWSEditor source in order that they may test their EWS Managed API code to work on the initialized ExchangeService object.");
            oSB.Append("  The ExchangeService is availible in this form and so that you can use it with your custom test code.");
            oSB.AppendLine("");
            oSB.AppendLine("");
            oSB.AppendFormat("Service.Url.AbsolutePath: {0}\r\n", _service.Url.AbsoluteUri.ToString());
 
    
            textBox1.Text = oSB.ToString();    
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            
        }
    }
}
