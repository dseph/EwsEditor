using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Forms.Controls;
using EWSEditor.Logging;
using EWSEditor.Common;

namespace EWSEditor.Forms
{
    public partial class RoomsForm : Form
    {
        ExchangeService _CurrentService = null;
        public RoomsForm()
        {
            InitializeComponent();
        }



        public RoomsForm(ExchangeService CurrentService)
        {
            InitializeComponent();
            _CurrentService = CurrentService;
           
        }

        private void RoomsForm_Load(object sender, EventArgs e)
        {
            lblTotalLists.Text = string.Empty;
            lblTotalRooms.Text = string.Empty;
 

        }

 
        private void btnRoomLists_Click(object sender, EventArgs e)
        {
            int iCount = 0;
            lblTotalLists.Text = string.Empty;
            lblWarning.Visible = false;
            lblTotalRooms.Text = string.Empty;

            lvRoomLists.Clear();
            lvRoomLists.View = View.Details;
            lvRoomLists.GridLines = true;
            lvRoomLists.FullRowSelect = true;
            lvRoomLists.Columns.Add("Address", 250, HorizontalAlignment.Left);
            lvRoomLists.Columns.Add("Name", 400, HorizontalAlignment.Left);
 
            ListViewItem oListItem = null;
            try
            {
                EmailAddressCollection oEmailAddressCollection = null;
                oEmailAddressCollection = _CurrentService.GetRoomLists();
                foreach (EmailAddress oAddress in oEmailAddressCollection)
                {
 
                    oListItem = new ListViewItem(oAddress.Address, 0);
                    oListItem.SubItems.Add(oAddress.Name);


                    lvRoomLists.Items.AddRange(new ListViewItem[] { oListItem });
                    oListItem = null;

                    iCount++;
                }

                lblTotalLists.Text = "Total Room Lists: " + iCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);

            }

             

        }

        private void btnGetRooms_Click(object sender, EventArgs e)
        {
            GetAllRooms(txtListSmtp.Text.Trim());
        }

        private void GetAllRooms(string sEmailAddress) 
        { 
            int iCount = 0;
            lblWarning.Visible = false;
            lblTotalRooms.Text = string.Empty;

            lvRooms.Clear();
            lvRooms.View = View.Details;
            lvRooms.GridLines = true;
            lvRooms.FullRowSelect = true;
            lvRooms.Columns.Add("Address", 250, HorizontalAlignment.Left);
            lvRooms.Columns.Add("Name", 400, HorizontalAlignment.Left);

            ListViewItem oListItem = null;
            try
            {
                
                if (txtListSmtp.Text.Trim().Length != 0)
                {
                    EmailAddress oEmailAddress = new EmailAddress(sEmailAddress);
                    System.Collections.ObjectModel.Collection<EmailAddress> oAddresses = null;
                    oAddresses = _CurrentService.GetRooms(oEmailAddress);
                    foreach (EmailAddress oAddress in oAddresses)
                    {
                        oListItem = new ListViewItem(oAddress.Address, 0);
                        oListItem.SubItems.Add(oAddress.Name);


                        lvRooms.Items.AddRange(new ListViewItem[] { oListItem });
                        oListItem = null;

                        iCount++;
                    }

                    lblTotalRooms.Text = "Total Rooms: " + iCount.ToString();

                    if (iCount == 100)
                    {
                        lblWarning.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");

            }

             
        }

        private void lvRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }

        private void lvRoomLists_Click(object sender, EventArgs e)
        {

 
        }

        private void lvRoomLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sSMTP = string.Empty;

            if (lvRoomLists.SelectedItems.Count != 0)
            {
                sSMTP = lvRoomLists.SelectedItems[0].Text;
                if (sSMTP.Length != 0)
                {
                    txtListSmtp.Text = sSMTP;

                    if (chkAutoPopulate.Checked == true)
                        GetAllRooms(sSMTP);
                }
            }
        }

 
    }
}
