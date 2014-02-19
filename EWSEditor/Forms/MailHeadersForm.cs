using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EWSEditor.Forms
{
    public partial class MailHeadersForm : Form
    {
        public bool bChoseSave = false;
        public MailHeadersForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Length == 0 || this.txtName.Text.Length == 0)
            {

            }
            else
            { 
                bChoseSave = true;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bChoseSave = false;
            this.Close();
        }

        private void MailHeadersForm_Load(object sender, EventArgs e)
        {

        }
    }
}
