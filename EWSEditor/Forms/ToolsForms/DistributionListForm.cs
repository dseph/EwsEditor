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

        //MailboxType _MailboxType = MailboxType.PublicGroup;

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
            TreeNode oNode = null;
            try
            {
                // Return the expanded group.
                ExpandGroupResults myGroupMembers = _CurrentService.ExpandGroup(sSmtp);
         
                // Display the group members.
                foreach (EmailAddress address in myGroupMembers)
                {
                    if (address.MailboxType == MailboxType.PublicGroup || address.MailboxType == MailboxType.ContactGroup )
                    {
                        oNode = AddNode(ref oParentNode, address);
                        //address.MailboxType = MailboxType.ContactGroup
                        //address.RoutingType = string
                        oNode.Nodes.Add(""); // Add dummy       
                    }
                }
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ExpandDL_PublicGroup(ref TreeNode oParentNode, ItemId groupID)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                // Return the expanded group.
                ExpandGroupResults myGroupMembers = _CurrentService.ExpandGroup(groupID);

                // Display the group members.
                foreach (EmailAddress address in myGroupMembers)
                {
                    if (address.MailboxType == MailboxType.PublicGroup || address.MailboxType == MailboxType.ContactGroup)
                    {
                        //oParentNode = AddNode(ref oParentNode, address);
                        //oParentNode.Nodes.Add(""); // Add dummy       

                        ExpandDL_PublicGroup(ref oParentNode, address.Address);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
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
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            lvItems.Items.Clear();

            if (oParentNode.Tag != null)
            {
                // typeof oto = oParentNode.Tag.GetType();
                if (oParentNode.Tag.GetType() != typeof(ItemId)) //(oParentNode.Tag.GetType() == typeof(string))
                {
                    EmailAddress oEmailAddress = (EmailAddress)oParentNode.Tag;
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
                else if (oParentNode.Tag.GetType() == typeof(ItemId))
                {
                    string s =  (oParentNode.Tag.ToString());
                    ItemId oItemId = new ItemId(oParentNode.Tag.ToString());
                    ListViewItem oItem = null;

                    try
                    {
                        // Return the expanded group.
                        ExpandGroupResults myGroupMembers = _CurrentService.ExpandGroup(oItemId);

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
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private ListViewItem NewMethod(EmailAddress address)
        {
            ListViewItem oItem;
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

            return oItem;
        }

        private void tvDistributionLists_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            if (e.Node.Nodes.Count == 1)
            {
                if (e.Node.Nodes[0].Text == "")  // veryify the dummy  
                {
                    TreeNode oNode = e.Node;
                    if (oNode.Tag.GetType() != typeof(ItemId)) // (oNode.Tag.GetType() == typeof(string))
                    {  
                        EmailAddress oEmailAddress = (EmailAddress)oNode.Tag;

                        oNode.Nodes.Clear();
                        ExpandDL_PublicGroup(ref oNode, oEmailAddress.Address);
                    }
                    else if (oNode.Tag.GetType() == typeof(ItemId))
                    {
 
                        oNode.Nodes.Clear();
                        ItemId oItemId = (ItemId)oNode.Tag;
                        ExpandDL_PublicGroup(ref oNode, oItemId);
                    }
                }
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUniqueIdExpand_Click(object sender, EventArgs e)
        {
            string sUniqueId = txtUniqueId.Text.Trim();
            if (sUniqueId.Length != 0)
            {

                tvDistributionLists.Nodes.Clear();
                lvItems.Items.Clear();

                TreeNode oRoot = null;
                ItemId oItemId = new ItemId(sUniqueId);

                oRoot = tvDistributionLists.Nodes.Add(sUniqueId);
 
                oRoot.Tag = oItemId;
               

                ExpandDL_PublicGroup(ref oRoot, oItemId);

            }
        }
    }
}
