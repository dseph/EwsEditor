using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EWSEditor.Forms.Dialogs
{
    public partial class EnterTextForm : Form
    {
        public string UserTextEntry = string.Empty;
        public bool ChoseOK = false;

        public EnterTextForm()
        {
            InitializeComponent();
        }

        public EnterTextForm(string sTextEntry)
        {
            InitializeComponent();
            UserTextEntry = sTextEntry; // Save
            txtEntry.Text = sTextEntry;
        }

        private void EnterTextForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ChoseOK = true;
            UserTextEntry = txtEntry.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ChoseOK = false;
            //UserTextEntry = txtEntry.Text;
            this.Close();
        }
    }
}
