using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EWSEditor
{
    public partial class MimeEntry : Form
    {
        public bool ChoseOK = false;

        public MimeEntry()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ChoseOK = false;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ChoseOK = true;
            this.Close();
        }
    }
}
