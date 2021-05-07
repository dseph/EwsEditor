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
    public partial class NewFolderForm : Form
    {
        public string ChosenFolderName = string.Empty;
        public string ChosenFolderClass = string.Empty;
        public bool ChoseOK = true;

        public NewFolderForm()
        {
            InitializeComponent();
        }

        public NewFolderForm(string sFolderName, string sFolderClass)
        {
            ChosenFolderName = sFolderName;
            ChosenFolderClass = sFolderClass;

            txtFolderName.Text = sFolderName;

            InitializeComponent();
        }

        private void NewFolderForm_Load(object sender, EventArgs e)
        {
            AddLine("", "Not set.");
            AddLine("IPF.Note", "Mail items.");
            AddLine("IPF.Appointment", "Calendar items.");
            AddLine("IPF.Contact", "Contact Items.");
            AddLine("IPF.Journal", "Journal Items.");
            AddLine("IPF.StickyNote", "Sticky Note Items.");
            AddLine("IPF.Task", "Task Items.");
        }

        private void AddLine(  string ItemName,   string ItemDescription)
        {
            ListViewItem oItem = null;
            oItem = lvItems.Items.Add(ItemName);
            oItem.SubItems.Add(ItemDescription);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems.Count > 0)
            {
                ChosenFolderClass = lvItems.SelectedItems[0].Text;
            }
            ChosenFolderName = txtFolderName.Text.Trim();

            ChoseOK = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ChoseOK = false;
            this.Close();
        }
    }
}
