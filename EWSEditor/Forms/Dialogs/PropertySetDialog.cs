using System;
using System.Data;
using System.Windows.Forms;
using EWSEditor.Forms.Controls;
using EWSEditor.PropertyInformation;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class PropertySetDialog : EWSEditor.Forms.DialogForm
    {
        private EnumComboBox<BasePropertySet> basePropertySetCombo = new EnumComboBox<BasePropertySet>();
        private EnumComboBox<BodyType> bodyTypeCombo = new EnumComboBox<BodyType>();
        private EnumComboBox<bool> filterHtmlCombo = new EnumComboBox<bool>();

        private DataTable propertyDisplayTable = new DataTable();
        private PropertySet initialPropertySet = new PropertySet();
        
        public PropertySetDialog()
        {
            InitializeComponent();
        }

        #region Properties

        /// <summary>
        /// Gets a value indicating whether the current PropertySet defined 
        /// is different than the initial PropertySet.
        /// </summary>
        private bool IsDirty
        {
            get
            {
                if (this.initialPropertySet.BasePropertySet != this.CurrentPropertySet.BasePropertySet)
                {
                    return true;
                }

                if (this.initialPropertySet.FilterHtmlContent != this.CurrentPropertySet.FilterHtmlContent)
                {
                    return true;
                }

                if (this.initialPropertySet.RequestedBodyType != this.CurrentPropertySet.RequestedBodyType)
                {
                    return true;
                }

                // If the property count is simply different then we're definitely dirty
                if (this.initialPropertySet.Count != this.CurrentPropertySet.Count)
                {
                    return true;
                }

                // If one of the current properties is not in the initial property set
                // then we've added a property and are dirty
                foreach (PropertyDefinitionBase prop in this.CurrentPropertySet)
                {
                    if (!this.initialPropertySet.Contains(prop))
                    {
                        return true;
                    }
                }

                // If one of the initial properties is not in the current property set
                // then we've removed a property and are dirty
                foreach (PropertyDefinitionBase prop in this.initialPropertySet)
                {
                    if (!this.CurrentPropertySet.Contains(prop))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Gets a PropertySet based on the current form's control state.
        /// </summary>
        private PropertySet CurrentPropertySet
        {
            get
            {
                PropertySet propSet = new PropertySet();

                propSet.RequestedBodyType = this.bodyTypeCombo.SelectedItem;

                if (this.basePropertySetCombo.SelectedItem.HasValue)
                {
                    propSet.BasePropertySet = this.basePropertySetCombo.SelectedItem.Value;
                }

                propSet.FilterHtmlContent = this.filterHtmlCombo.SelectedItem;

                foreach (DataRow row in this.propertyDisplayTable.Rows)
                {
                    PropertyDefinitionBase prop = (PropertyDefinitionBase)row["PropertyDefinitionBase"];
                    propSet.Add(prop);
                }

                return propSet;
            }
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Show the form and the list of props passed in 
        /// </summary>
        /// <param name="origPropertySet">
        /// The original PropertySet used to populate the initial state
        /// of the form.
        /// </param>
        /// <returns>
        /// DialogResult.OK indicates that the PropertySet was updated.
        /// </returns>
        public static DialogResult Show(ref PropertySet origPropertySet)
        {
            PropertySetDialog dialog = new PropertySetDialog();
            dialog.initialPropertySet = origPropertySet;

            DialogResult res = dialog.ShowDialog();

            // Don't update props unless DialogResult == OK. If
            // the dialog is canceled, props goes unchanged
            if (res == DialogResult.OK)
            {
                // Only reutrn OK if the PropertySet changed
                if (dialog.IsDirty)
                {
                    origPropertySet = dialog.CurrentPropertySet;
                    return DialogResult.OK;
                }
                else
                {
                    return DialogResult.Ignore;
                }
            }

            return res;
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Initialize form controls and load the current property set if available.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void PropertySetDialog_Load(object sender, EventArgs e)
        {
            // Convert regular ComboBoxes to EnumComboBoxes and set values
            this.basePropertySetCombo.TransformComboBox(this.TempBasePropertySetCombo);
            this.basePropertySetCombo.HasEmptyItem = true;
            this.basePropertySetCombo.SelectedItem = this.initialPropertySet.BasePropertySet;

            this.bodyTypeCombo.TransformComboBox(this.TempBodyTypeCombo);
            this.bodyTypeCombo.HasEmptyItem = true;
            this.bodyTypeCombo.SelectedItem = this.initialPropertySet.RequestedBodyType;

            this.filterHtmlCombo.TransformComboBox(this.TempFilterHtmlCombo);
            this.filterHtmlCombo.HasEmptyItem = true;
            this.filterHtmlCombo.SelectedItem = this.initialPropertySet.FilterHtmlContent;

            // Initialize the datatable used to display the properties in the PropertySet.
            this.propertyDisplayTable.Columns.Add("PropertyName", typeof(string));
            this.propertyDisplayTable.Columns.Add("PropertyType", typeof(string));
            this.propertyDisplayTable.Columns.Add("WellKnownName", typeof(string));
            this.propertyDisplayTable.Columns.Add("PropertyDefinitionBase", typeof(PropertyDefinitionBase));
            this.propertyDisplayTable.Columns.Add("PropertyNameSortString", typeof(string));
            this.propertyDisplayTable.PrimaryKey = new DataColumn[] { this.propertyDisplayTable.Columns["PropertyName"] };

            this.PropertiesGrid.DataSource = this.propertyDisplayTable;
            this.PropertiesGrid.Columns["PropertyName"].Width = this.PropertiesGrid.Width / 2;
            this.PropertiesGrid.Columns["PropertyType"].Width = this.PropertiesGrid.Width / 4;
            this.PropertiesGrid.Columns["WellKnownName"].Width = this.PropertiesGrid.Width / 4;
            this.PropertiesGrid.Columns["PropertyDefinitionBase"].Visible = false;
            this.PropertiesGrid.Columns["PropertyNameSortString"].Visible = false;
            this.PropertiesGrid.ScrollBars = ScrollBars.Both;

            foreach (PropertyDefinitionBase prop in this.initialPropertySet)
            {
                this.AddPropertyToDisplayTable(prop);
            }
        }

        /// <summary>
        /// Remove the selected property from the list 
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            DataRowView view = this.PropertiesGrid.SelectedRows[0].DataBoundItem as DataRowView;
            if (view != null)
            {
                this.propertyDisplayTable.Rows.Remove(view.Row);
            }
        }

        /// <summary>
        /// Remove all properties from the list
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            this.propertyDisplayTable.Rows.Clear();
        }

        /// <summary>
        /// When sorting the Property Name column use the value of
        /// the PropertyNameSortString column to sort rather than
        /// Property Name.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void PropertiesGrid_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "PropertyName")
            {
                e.SortResult = String.Compare(
                    this.PropertiesGrid.Rows[e.RowIndex1].Cells["PropertyName"].Value.ToString(),
                    this.PropertiesGrid.Rows[e.RowIndex2].Cells["PropertyName"].Value.ToString());
            }

            e.Handled = true;
        }

        /// <summary>
        /// Add all WellKnownProperties to the PropertySet
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void BtnAddAllProps_Click(object sender, EventArgs e)
        {
            foreach (PropertyDefinitionBase prop in KnownExtendedProperties.Instance().GetAllPropertyDefinitions())
            {
                this.AddPropertyToDisplayTable(prop);
            }
        }

        /// <summary>
        /// Launch form to get ExtendedPropertyDefinition information
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void BtnAddExtended_Click(object sender, EventArgs e)
        {
            ExtendedPropertyDefinition epd = null;

            if (ExtendedPropertyDialog.ShowDialog(ref epd) == DialogResult.OK)
            {
                this.AddPropertyToDisplayTable(epd);
            }
        }

        /// <summary>
        /// Launch form to get Schema Property information
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void BtnAddSchema_Click(object sender, EventArgs e)
        {
            PropertyDefinitionBase prop = null;

            if (SchemaPropertyDialog.Show(this, out prop) == DialogResult.OK && prop != null)
            {
                this.AddPropertyToDisplayTable(prop);
            }
        }

        #endregion

        /// <summary>
        /// Add the given property to the display table.  The grid is
        /// customized as to how it sorts and displays property
        /// information.
        /// </summary>
        /// <param name="prop">Property to be added to the table.</param>
        private void AddPropertyToDisplayTable(PropertyDefinitionBase prop)
        {
            // If there is no property then bail out
            if (prop == null) 
            { 
                return; 
            }

            DataRow row = this.propertyDisplayTable.NewRow();

            row["PropertyName"] = PropertyInterpretation.GetPropertyName(prop);
            row["PropertyType"] = PropertyInterpretation.GetPropertyType(prop);
            row["WellKnownName"] = PropertyInterpretation.GetAlternateNames(prop);
            row["PropertyDefinitionBase"] = prop;

            // Don't add the row if it already exists
            if (!this.propertyDisplayTable.Rows.Contains(row["PropertyName"]))
            {
                this.propertyDisplayTable.Rows.Add(row);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
