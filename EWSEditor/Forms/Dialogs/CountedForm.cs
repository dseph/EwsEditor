using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EWSEditor.Forms
{
    public partial class CountedForm : BaseForm
    {
        protected internal CountedForm()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(CountedForm_FormClosed);
            this.Load += new EventHandler(CountedForm_Load);
        }

        protected internal void CountedForm_Load(object sender, EventArgs e)
        {
            HiddenMainForm.AddForm();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }

        protected internal void CountedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HiddenMainForm.ReleaseForm();
        }

        private void CountedForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            AboutDialog.ShowDialog();
        }

        private void CountedForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
