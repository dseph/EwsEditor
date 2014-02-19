using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.Exchange.WebServices.Data;
//using EWSEditor.Forms.Controls;
//using EWSEditor.Logging;
using EWSEditor.Common;

namespace EWSEditor.Forms
{
    public partial class AttachmentSelect : Form
    {

        public bool ChoseOK = false;

        public AttachmentSelect()
        {
            InitializeComponent();
        }

        private void SelectAttachmentToAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ChoseOK = true;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ChoseOK = false;
            this.Close();
        }

        private void btnBrowseForFile_Click(object sender, EventArgs e)
        {
            string sSelectedFile = string.Empty;

            if (UserIoHelper.PickLoadFromFile(Application.UserAppDataPath, "*.png", ref sSelectedFile, "All files (*.*)|*.*"))
            {
                this.txtFile.Text = sSelectedFile;
            };
        }
    }
}
