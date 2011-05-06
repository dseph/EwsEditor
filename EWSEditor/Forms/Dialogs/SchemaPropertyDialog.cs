using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using Microsoft.Exchange.WebServices.Data;

using EWSEditor.Common;
using EWSEditor.Resources;

namespace EWSEditor.Forms
{
    public partial class SchemaPropertyDialog : EWSEditor.Forms.DialogForm
    {
        PropertyDefinitionBase propDef = null;

        public SchemaPropertyDialog()
        {
            InitializeComponent();
        }

        public static DialogResult Show(IWin32Window owner, out PropertyDefinitionBase propDef)
        {
            SchemaPropertyDialog spd = new SchemaPropertyDialog();
            DialogResult ret = spd.ShowDialog(owner);

            propDef = spd.propDef;
            
            return ret;
        }

        private void SchemaPropertyDialog_Load(object sender, EventArgs e)
        {
            LoadSchemas();
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

            tvwSchemas.Sort();
        }

        private void LoadSchemaIntoTreeView(Type objType)
        {
            TreeNode rootNode = tvwSchemas.Nodes.Add(objType.Name);

            foreach (FieldInfo fieldInfo in objType.GetFields())
            {
                PropertyDefinitionBase def = (PropertyDefinitionBase)fieldInfo.GetValue(objType);
                TreeNode newNode = rootNode.Nodes.Add(fieldInfo.Name);
                newNode.Tag = def;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.tvwSchemas.SelectedNode != null)
            {
                // The form currently does support multiple selections.
                // If a parent node is selected, warn the user and bail
                // out of this method.
                if (this.tvwSchemas.SelectedNode.Nodes.Count > 0)
                {
                    ErrorDialog.ShowWarning(DisplayStrings.WARN_SELECT_SCHEMA_PROPS);
                    this.DialogResult = DialogResult.Ignore;
                    return;
                }

                this.propDef = this.tvwSchemas.SelectedNode.Tag as PropertyDefinitionBase;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
