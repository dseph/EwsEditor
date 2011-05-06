using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class SchemaPropertiesDialog : DialogForm
    {
        List<PropertyDefinitionBase> propList = new List<PropertyDefinitionBase>();

        internal class SchemaPropertyListItem
        {
            internal readonly string Name;
            internal readonly PropertyDefinition PropDef;

            internal SchemaPropertyListItem(string name, PropertyDefinition def)
            {
                this.Name = name;
                this.PropDef = def;
            }

            public override string ToString()
            {
                return this.Name;
            }
        }

        public SchemaPropertiesDialog()
        {
            InitializeComponent();
        }

        private void SchemaPropertiesDialog_Load(object sender, EventArgs e)
        {
            this.propList.Add(ContactSchema.AssistantName);

            // Load all the schemas and properties into the tree view...
            LoadSchemas();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TreeNode node = tvwSchemas.SelectedNode;

            // Bail out if there is no selected node(s)
            if (node == null) { return; }

            // If the selected node is a root node then add
            // all the children, otherwise add just the
            // selected node
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode propNode in node.Nodes)
                {
                    // Create a list item to hold the PropertyDefinition
                    SchemaPropertyListItem item = new SchemaPropertyListItem(
                            GetListItemName(propNode), 
                            (PropertyDefinition)propNode.Tag);

                    lstProps.Items.Add(item);
                }

                // Remove all the selected nodes so they can't be
                // selected twice
                node.Nodes.Clear();
            }
            else
            {
                // Create a list item to hold the PropertyDefinition
                SchemaPropertyListItem item = new SchemaPropertyListItem(
                            GetListItemName(node),
                            (PropertyDefinition)node.Tag);

                lstProps.Items.Add(item);
                
                // Remove the selected node so it can't be
                // selected again
                node.Remove();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            List<SchemaPropertyListItem> removeItems = new List<SchemaPropertyListItem>();

            // Restore selected items to the tree view
            foreach (object item in this.lstProps.SelectedItems)
            {
                SchemaPropertyListItem listItem = (SchemaPropertyListItem)item;
                RestoreNode(listItem.Name);

                removeItems.Add(listItem);
            }

            // Remove items from the list box
            foreach (SchemaPropertyListItem listItem in removeItems)
            {
                this.lstProps.Items.Remove(listItem);
            }
        }

        private void LoadSchemas()
        {
            LoadSchemaIntoTreeView(typeof(AppointmentSchema));
            LoadSchemaIntoTreeView(typeof(ContactSchema));
            //LoadSchemaIntoTreeView(typeof(DistributionListSchema));
            LoadSchemaIntoTreeView(typeof(EmailMessageSchema));
            LoadSchemaIntoTreeView(typeof(FolderSchema));
            LoadSchemaIntoTreeView(typeof(ItemSchema));
            LoadSchemaIntoTreeView(typeof(MeetingMessageSchema));
            LoadSchemaIntoTreeView(typeof(PostItemSchema));
            LoadSchemaIntoTreeView(typeof(SearchFolderSchema));
            LoadSchemaIntoTreeView(typeof(TaskSchema));
        }

        private void LoadSchemaIntoTreeView(Type objType)
        {
            TreeNode rootNode = tvwSchemas.Nodes.Add(objType.Name);
            foreach (FieldInfo fieldInfo in objType.GetFields())
            {
                PropertyDefinitionBase def = (PropertyDefinitionBase)fieldInfo.GetValue(objType);
                TreeNode newNode = rootNode.Nodes.Add(fieldInfo.Name);
                newNode.Tag = def;

                if (IsPropertyDefinitionInList(def))
                {
                    this.lstProps.Items.Add(new SchemaPropertyListItem(GetListItemName(newNode), (PropertyDefinition)def));
                    newNode.Remove();
                }
                
            }
        }

        private bool IsPropertyDefinitionInList(PropertyDefinitionBase propDef)
        {
            foreach (PropertyDefinitionBase item in this.propList)
            {
                if (item == propDef)
                {
                    return true;
                }
            }

            return false;
        }

        private string GetListItemName(TreeNode propNode)
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}:{1}", propNode.Parent.Text.ToLower().Replace("schema", ""), propNode.Text);
        }

        private void RestoreNode(string itemText)
        {
            string parentName = string.Empty;
            string propName = string.Empty;

            parentName = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}schema", itemText.Split(new char[] { ':' })[0]);
            propName = itemText.Split(new char[] { ':' })[1];

            foreach (TreeNode node in tvwSchemas.Nodes)
            {
                if (node.Text.ToLower() == parentName.ToLower())
                {
                    node.Nodes.Add(propName);
                }
            }
        }
    }
}
