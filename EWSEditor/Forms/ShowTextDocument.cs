using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EWSEditor.Forms;

namespace EWSEditor.Forms
{
    public partial class ShowTextDocument : Form
    {
        public ShowTextDocument()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowTextDocument_Load(object sender, EventArgs e)
        {

        }
    }
}
