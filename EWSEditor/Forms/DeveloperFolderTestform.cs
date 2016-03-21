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
    public partial class DeveloperFolderTestform : Form
    {
        ExchangeService _service = null;
        FolderId _folderId = null;

        public DeveloperFolderTestform()
        {
            InitializeComponent();
        }

        public DeveloperFolderTestform(ExchangeService service, FolderId folderId)
        {
            InitializeComponent();
            _service = service;
            _folderId = folderId;
        }

        private void DeveloperFolderTestWindow_Load(object sender, EventArgs e)
        {
            StringBuilder oSB = new StringBuilder();
            oSB.Append("This window is to be used by develpers with EWSEditor source in order that they may test their EWS Managed API code  to work on a selected folder.  ");
            oSB.Append("  The ExchangeService and FolderId are availible in ths form so that you can use them in your custom test code.");
            oSB.AppendLine("");
            oSB.AppendLine("");
            oSB.AppendFormat("Service.Url.AbsolutePath: {0}\r\n", _service.Url.AbsoluteUri.ToString());
            oSB.AppendLine("");
            oSB.AppendLine("FolderId.UniqueId: " + _folderId.UniqueId);
            oSB.AppendLine("");
            oSB.AppendLine("FolderId.ChangeKey: " + _folderId.ChangeKey);
            oSB.AppendLine("");
            oSB.AppendLine("FolderId.FolderName: " + _folderId.FolderName);
            oSB.AppendLine("");
            //oSB.AppendLine("FolderId.ChangeKey: " + _folderId.Mailbox.Address);


            textBox1.Text = oSB.ToString();
        }
    }
}
