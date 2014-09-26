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
    public partial class DistributionListExpansionForm : Form
    {
        ExchangeService _CurrentService = null;

        MailboxType _MailboxType = MailboxType.PublicGroup;

        public DistributionListExpansionForm()
        {
            InitializeComponent();
        }

        public DistributionListExpansionForm(ExchangeService CurrentService)
        {
            InitializeComponent();
            _CurrentService = CurrentService;
           
        }

        private void DistributionListForm_Load(object sender, EventArgs e)
        {
 

        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            string sSmpt = txtListSmtp.Text.Trim();
            if (sSmpt.Length != 0)
            {

                tvDistributionLists.Nodes.Clear();
                lvItems.Items.Clear();

                TreeNode oRoot = null;
 
                oRoot = tvDistributionLists.Nodes.Add(sSmpt);
                EmailAddress oEmailAddress = new EmailAddress(sSmpt);
                oRoot.Tag = oEmailAddress;

                ExpandDL_PublicGroup(ref oRoot, sSmpt);
 
            }
        }

        private void ExpandDL_PublicGroup(ref TreeNode oParentNode, string sSmtp)
        {
 
             
            try
            {
                // Return the expanded group.
                ExpandGroupResults myGroupMembers = _CurrentService.ExpandGroup(sSmtp);
         
                // Display the group members.
                foreach (EmailAddress address in myGroupMembers)
                {
                    if (address.MailboxType == MailboxType.PublicGroup || address.MailboxType == MailboxType.ContactGroup )
                    {
                        oParentNode = AddNode(ref oParentNode, address);
                        //address.MailboxType = MailboxType.ContactGroup
                        //address.RoutingType = string
                        oParentNode.Nodes.Add(""); // Add dummy       
                    }
                }
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //private void ExpandDL_ContactGroup(ref TreeNode oParentNode, string sSmtp)
        //{

        //    try
        //    {
        //        // Return the expanded group.
        //        ExpandGroupResults myGroupMembers = _CurrentService.ExpandGroup(sSmtp);

        //        // Display the group members.
        //        foreach (EmailAddress address in myGroupMembers.Members)
        //        {
        //            if (address.MailboxType == MailboxType.ContactGroup)
        //            {
        //                oParentNode = AddNode(ref oParentNode, address);
        //                //address.MailboxType = MailboxType.ContactGroup
        //                //address.RoutingType = string
        //                oParentNode.Nodes.Add(""); // Add dummy       
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}


        //private TreeNode AddNode(ref TreeNode oParentNode, EmailAddress address, string sNote)
       private TreeNode AddNode(ref TreeNode oParentNode, EmailAddress address)
        {
            TreeNode oNode = null;
            oNode = oParentNode.Nodes.Add(address.Name + " <" + address.Address + "> ( Mbx Type: " + address.MailboxType + ")"+ " (Routing Type: " + address.RoutingType + ")"  );
            oNode.Tag = address;
            return oNode;
        }


         

        private void tvDistributionLists_AfterSelect(object sender, TreeViewEventArgs e)
        {

            DispalyNonDls(e.Node);
        }

        private void DispalyNonDls(TreeNode oParentNode)
        {

            lvItems.Items.Clear();
 
            EmailAddress oEmailAddress = (EmailAddress)oParentNode.Tag;
        
 
            if (oEmailAddress != null)
            {
                string sSmtp = oEmailAddress.Address;
                ListViewItem oItem = null;

                try
                {
                    // Return the expanded group.
                    ExpandGroupResults myGroupMembers = _CurrentService.ExpandGroup(oEmailAddress);

                    // Display the group members.
                    
                    foreach (EmailAddress address in myGroupMembers.Members)
                    {

                        if (address.MailboxType != MailboxType.PublicGroup && address.MailboxType != MailboxType.PublicGroup)
                        {

                            oItem = lvItems.Items.Add(address.Name);
                            oItem.SubItems.Add(address.Address);
                            oItem.SubItems.Add(address.MailboxType.ToString());
                            oItem.SubItems.Add(address.RoutingType);
                            if (address.Id != null)
                                oItem.SubItems.Add(address.Id.UniqueId);
                            else
                                oItem.SubItems.Add("");
                            oItem.Tag = address;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void tvDistributionLists_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1)
            {
                if (e.Node.Nodes[0].Text == "")  // veryify the dummy  
                {
                    TreeNode oNode = e.Node;
                    EmailAddress oEmailAddress = (EmailAddress)oNode.Tag;

                    oNode.Nodes.Clear();
                    ExpandDL_PublicGroup(ref oNode, oEmailAddress.Address);
                }
            }
        }

        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
