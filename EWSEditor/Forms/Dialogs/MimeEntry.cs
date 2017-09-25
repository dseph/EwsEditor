using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EWSEditor.Exchange;
using EWSEditor.PropertyInformation;
using EWSEditor.Resources;
using EWSEditor.Settings;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor
{
    public partial class MimeEntry : Form
    {
        public bool ChoseOK = false;
        public bool ItemCreated = false;

        ExchangeService _Service = null;
        Folder _Folder = null;

        public MimeEntry()
        {
            InitializeComponent();
        }

        public MimeEntry(ExchangeService oService, Folder oFolder)
        {
            InitializeComponent();
            _Service = oService;
            _Folder = oFolder;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ItemCreated = true;
            this.Close();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            ChoseOK = true;
            this.Close();
        }

        private bool TryCreateItem()
        {
            bool bItemCreated = false;

            try
            {

                if (_Folder.FolderClass.StartsWith("IPF.Appointment"))
                {

                    Appointment item = new Appointment(_Service);
                    item.MimeContent = new MimeContent();
                    //item.MimeContent = new MimeContent();

                    //MimeEntry oMimeEntry = new MimeEntry();
                    //oMimeEntry.ShowDialog();
                    string sContent = string.Empty;

                    if (chkIsBase64Encoded.Checked == true)
                        item.MimeContent.Content = Convert.FromBase64String(txtEntry.Text.Trim());
                    else
                        item.MimeContent.Content = System.Text.Encoding.UTF8.GetBytes(txtEntry.Text);

                    item.Save(_Folder.Id);
 
                    bItemCreated = true;
                    item = null;

                }
                if (_Folder.FolderClass.StartsWith("IPF.Contact"))
                {

                    Contact item = new Contact(_Service);
                    item.MimeContent = new MimeContent();

                    if (chkIsBase64Encoded.Checked == true)
                        item.MimeContent.Content = Convert.FromBase64String(txtEntry.Text.Trim());
                    else
                        item.MimeContent.Content = System.Text.Encoding.UTF8.GetBytes(txtEntry.Text);

                    item.Save(_Folder.Id);
                    //this.RefreshContentAndDetails();
               

                    bItemCreated = true;
                    item = null;
                }
                if (_Folder.FolderClass.StartsWith("IPF.Note"))
                {

                    EmailMessage item = new EmailMessage(_Service);
                    item.MimeContent = new MimeContent();

                    if (chkIsBase64Encoded.Checked == true)
                        item.MimeContent.Content = Convert.FromBase64String(txtEntry.Text.Trim());
                    else
                    {
                       // item.MimeContent = new MimeContent();
                        item.MimeContent.Content = System.Text.Encoding.UTF8.GetBytes(txtEntry.Text);
                         
                        //item.MimeContentUTF8.Content = System.Text.Encoding.UTF8.GetBytes(txtEntry.Text);
                    }

                    item.Save(_Folder.Id);
                    //this.RefreshContentAndDetails();
 

                    bItemCreated = true;
                    item = null;

                }

            }
            catch (Exception ex)
            {
                bItemCreated = false;
                MessageBox.Show(ex.InnerException.ToString(), "Error creating item");

            }

            return bItemCreated;

        }
        private void MimeEntry_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (TryCreateItem() == true)
            {
                ItemCreated = true;
                this.Close();
            }
        }
    }
}
