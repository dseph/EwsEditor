using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using EWSEditor.Logging;
using EWSEditor.PropertyInformation;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms.Controls
{    public enum PropertyListItemType
    {
        FirstClass,
        Extended
    }

    public partial class PropertyDetialsGrid : UserControl
    {
        private const int MAX_VALUE_LENGTH = 10000;

        public object CurrentObject = null;
        public ExchangeService CurrentService = null;

        public delegate void PropertyChangedEventHandler(object sender, EventArgs e);
        public event PropertyChangedEventHandler PropertyChanged;

        public PropertyDetialsGrid()
        {
            InitializeComponent();
        }

        public void LoadItem(ExchangeService service, ItemId itemId, PropertySet propertySet)
        {
            Item item = null;
            Dictionary<PropertyDefinitionBase, Exception> errorProperties = new Dictionary<PropertyDefinitionBase, Exception>();

            bool retry = false;
            do
            {
                try
                {
                    service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
                    item = Item.Bind(service, itemId, propertySet);
                    retry = false;
                    this.CurrentObject = item;
                }
                catch (ServiceResponseException srex)
                {
                    DebugLog.WriteVerbose("Handled exception when retrieving property", srex);

                    // Remove the bad properties from the PropertySet and try again.
                    foreach (PropertyDefinitionBase propDef in srex.Response.ErrorProperties)
                    {
                        errorProperties.Add(propDef, srex);
                        propertySet.Remove(propDef); 
                        retry = true;
                    }
                }
            } while (retry);

            GridDataTables.PropertyListDataTable propList = GetPropertyList(item);

            // Add properties which had errors to the list
            foreach (PropertyDefinitionBase errProp in errorProperties.Keys)
            {
                GridDataTables.PropertyListRow errRow = propList.NewPropertyListRow();

                errRow.Name = PropertyInterpretation.GetPropertyName(errProp);
                errRow.KnownNames = PropertyInterpretation.GetAlternateNames(errProp);
                
                errRow.Value = errorProperties[errProp].Message;
                //errRow.SmartView = PropertyInterpretation.GetSmartView(errorProperties[errProp]);
                errRow.Type = errorProperties[errProp].GetType().ToString();
                errRow.PropertyObject = errProp;

                // SortName is simply the property name with a prefix to ensure
                // that first class properties and extended properties stay grouped
                // together.
                if (errProp is PropertyDefinition)
                {
                    errRow.Icon = global::EWSEditor.Properties.Resources.FirstProp;
                    errRow.SortName = string.Concat("a", errRow.Name);
                }
                else if (errProp is ExtendedPropertyDefinition)
                {
                    errRow.Icon = global::EWSEditor.Properties.Resources.ExtProp;
                    errRow.SortName = string.Concat("b", errRow.Name);
                }

                // Add the row to the table
                propList.AddPropertyListRow(errRow);
            }

            // Add properties to the list who were not found on the item
            bool isFound = false;
            foreach (ExtendedPropertyDefinition propDef in propertySet)
            {
                foreach (ExtendedProperty extProp in item.ExtendedProperties)
                {
                    if (propDef == extProp.PropertyDefinition)
                    {
                        isFound = true;
                        break;
                    }
                }

                if (isFound == false)
                {
                    GridDataTables.PropertyListRow missRow = propList.NewPropertyListRow();
                    missRow.Name = PropertyInterpretation.GetPropertyName(propDef);
                    missRow.KnownNames = PropertyInterpretation.GetAlternateNames(propDef);
                    missRow.Type = PropertyInterpretation.GetPropertyType(propDef);
                    propList.AddPropertyListRow(missRow);
                }
            }

            this.PropertyListDataGridView.DataSource = GetPropertyList(this.CurrentObject);
            this.PropertyListDataGridView.Sort(this.NameColumn, ListSortDirection.Ascending);

            // If the width of the control minus all other column widths is greater
            // than the default width of the ValueColumn, extend the width of the
            // ValueColumn to display as much data as possible.
            int availableWidth = this.PropertyListDataGridView.Width -
                 (this.NameColumn.Width + this.KnownNamesColumn.Width + this.TypeColumn.Width + this.SmartViewColumn.Width);
            if (availableWidth > this.ValueColumn.Width)
                this.ValueColumn.Width = availableWidth;
        }

        public void LoadObject(object o)
        {
            this.CurrentObject = o;
            this.PropertyListDataGridView.DataSource = GetPropertyList(this.CurrentObject);
            this.PropertyListDataGridView.Sort(this.NameColumn, ListSortDirection.Ascending);

            // If the width of the control minus all other column widths is greater
            // than the default width of the ValueColumn, extend the width of the
            // ValueColumn to display as much data as possible.
            int availableWidth = this.PropertyListDataGridView.Width - 
                 (this.NameColumn.Width + this.KnownNamesColumn.Width + this.TypeColumn.Width + this.SmartViewColumn.Width);
            if (availableWidth > this.ValueColumn.Width)
                this.ValueColumn.Width = availableWidth;
        }

        public void Clear()
        {
            PropertyListDataGridView.DataSource = null;
        }

        #region DataGridView Events

        private void PropertyListDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string colName = PropertyListDataGridView.Rows[e.RowIndex].Cells["NameColumn"].Value.ToString();
            DebugLog.WriteVerbose(String.Format("Row index {0}, data error on {1}", e.RowIndex, colName), e.Exception);
        }

        /// <summary>
        /// Set the context menu based on the object that is being displayed.  Certain objects
        /// like ExchangeService will have no individual property editing available.
        /// </summary>
        private void PropertyListDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (this.CurrentObject is ServiceObject)
                {
                    this.PropertyListDataGridView.Rows[e.RowIndex].ContextMenuStrip = this.mnuPropertyContext;
                }
            }
        }

        /// <summary>
        /// Double clicking a row on the data grid displays the editor for that
        /// property.
        /// </summary>
        private void PropertyListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataRowView viewRow = this.PropertyListDataGridView.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (viewRow != null)
                {
                    GridDataTables.PropertyListRow row = (GridDataTables.PropertyListRow)viewRow.Row;
                    ShowEditor(row);
                }
            }
        }

        /// <summary>
        /// When the user clicks on the Name column, actually sort by the SortName
        /// column which has text better suited for sorting were the Name column has
        /// text suited for display.
        /// </summary>
        private void PropertyListDataGridView_Sorted(object sender, EventArgs e)
        {
            try
            {
                // Unwire the event handler so we don't create a callback storm
                this.PropertyListDataGridView.Sorted -= PropertyListDataGridView_Sorted;

                if (this.PropertyListDataGridView.SortedColumn == this.NameColumn)
                {
                    switch (this.PropertyListDataGridView.SortOrder)
                    {
                        case SortOrder.Ascending:
                            this.PropertyListDataGridView.Sort(this.SortNameColumn, ListSortDirection.Ascending);
                            this.NameColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                            break;
                        case SortOrder.Descending:
                            this.PropertyListDataGridView.Sort(this.SortNameColumn, ListSortDirection.Descending);
                            this.NameColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending;
                            break;
                        case SortOrder.None:
                            // What do we do here?
                            this.NameColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                            break;
                    }
                }
                else if (PropertyListDataGridView.SortedColumn != this.SortNameColumn)
                {
                    this.NameColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            finally
            {
                this.PropertyListDataGridView.Sorted += PropertyListDataGridView_Sorted;
            }
        }

        /// <summary>
        /// Force the custom sorting of the Name column
        /// </summary>
        private void PropertyListDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.PropertyListDataGridView.Columns[e.ColumnIndex] == this.NameColumn)
            {
                switch (this.NameColumn.HeaderCell.SortGlyphDirection)
                {
                    case SortOrder.Descending:
                    case SortOrder.None:
                        this.PropertyListDataGridView.Sort(this.NameColumn, ListSortDirection.Ascending);
                        break;
                    case SortOrder.Ascending:
                        this.PropertyListDataGridView.Sort(this.NameColumn, ListSortDirection.Descending);
                        break;
                }
            }
        }

#endregion

        #region Context Menu

        private void mnuRemoveProperty_Click(object sender, EventArgs e)
        {
            if (this.PropertyListDataGridView.SelectedRows.Count != 1) { return; }

            DataRowView viewRow = this.PropertyListDataGridView.SelectedRows[0].DataBoundItem as DataRowView;
            
            // If there's no row then we can't find the property to remove
            if (viewRow == null) { return; }

            GridDataTables.PropertyListRow row = (GridDataTables.PropertyListRow)viewRow.Row;

            // Only extended properties can be removed
            ExtendedPropertyDefinition exPropDef = row.PropertyObject as ExtendedPropertyDefinition;
            if (exPropDef == null) { return; }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                Item item = this.CurrentObject as Item;
                if (item != null)
                {
                    item.RemoveExtendedProperty(exPropDef);
                    item.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                    item.Update(ConflictResolutionMode.AutoResolve);
                }
                else
                {
                    Folder folder = this.CurrentObject as Folder;
                    if (folder != null) { return; }

                    folder.RemoveExtendedProperty(exPropDef);
                    folder.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                    folder.Update();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Edit click from the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuEditProperty_Click(object sender, EventArgs e)
        {
            if (this.PropertyListDataGridView.SelectedRows.Count != 1) { return; }

            DataRowView viewRow = this.PropertyListDataGridView.SelectedRows[0].DataBoundItem as DataRowView;
            if (viewRow != null)
            {
                GridDataTables.PropertyListRow row = (GridDataTables.PropertyListRow)viewRow.Row;
                ShowEditor(row);
            }
        }

        #endregion

        /// <summary>
        /// Convert a given object into a PropertyListDataTable.
        /// </summary>
        /// <param name="obj">Object to convert</param>
        /// <returns>DataTable filled out for each property of the given item</returns>
        private static GridDataTables.PropertyListDataTable GetPropertyList(object obj)
        {
            if (obj == null) { throw new ApplicationException("Cannot load null object in PropertyList"); }

            GridDataTables.PropertyListDataTable propList = new GridDataTables.PropertyListDataTable();

            ServiceObject so = obj as ServiceObject;
            if (so != null)
            {
                foreach (PropertyDefinitionBase baseProp in so.GetLoadedPropertyDefinitions())
                {
                    if (baseProp != ItemSchema.ExtendedProperties)
                    {
                        GridDataTables.PropertyListRow row = propList.NewPropertyListRow();

                        PropertyInterpretation propInter = new PropertyInterpretation(so, baseProp);

                        if (propInter.Name != null)
                        {
                            row.Name = propInter.Name;
                        }
                        else
                        {
                            row.Name = "";
                        }

                        row.Value = propInter.Value;
                        row.SmartView = propInter.SmartView;
                        row.Type = propInter.TypeName;
                        row.KnownNames = propInter.AlternateNames;
                        row.PropertyObject = baseProp;

                        // SortName is simply the property name with a prefix to ensure
                        // that first class properties and extended properties stay grouped
                        // together.
                        if (baseProp is PropertyDefinition)
                        {
                            row.Icon = global::EWSEditor.Properties.Resources.FirstProp;
                            row.SortName = string.Concat("a", row.Name);
                        }
                        else if (baseProp is ExtendedPropertyDefinition)
                        {
                            row.Icon = global::EWSEditor.Properties.Resources.ExtProp;
                            row.SortName = string.Concat("b", row.Name);
                        }

                        // Add the row to the table
                        propList.AddPropertyListRow(row);
                    }
                }
            }
            else
            {
                Type objType = obj.GetType();

                foreach (PropertyInfo propInfo in objType.GetProperties())
                {
                    GridDataTables.PropertyListRow row = propList.NewPropertyListRow();

                    PropertyInterpretation propInter = new PropertyInterpretation(obj, propInfo);

                    row.Name = propInter.Name;

                    row.Value = propInter.Value.Substring(
                        0,
                        propInter.Value.Length > MAX_VALUE_LENGTH ? MAX_VALUE_LENGTH : propInter.Value.Length);
                    row.Type = propInter.TypeName;
                    row.PropertyObject = propInfo;
                    row.Icon = global::EWSEditor.Properties.Resources.FirstProp;
                    row.SortName = string.Concat("a", row.Name);

                    // Add the row to the table
                    propList.AddPropertyListRow(row);
                }
            }

            return propList;
        }

        /// <summary>
        /// Display the PropertyEditor dialog, if the property
        /// was changed fire the PropertyChanged event.
        /// </summary>
        /// <param name="row">PropertyListRow row to display in the PropertyEditor</param>
        private void ShowEditor(GridDataTables.PropertyListRow row)
        {
            DialogResult res = DialogResult.Cancel;

            if (row.PropertyObject is ExtendedPropertyDefinition &&
                (((ExtendedPropertyDefinition)row.PropertyObject).MapiType == MapiPropertyType.Binary))
            {
                res = PropertyEditorDialog.ShowDialog(this.CurrentObject as ServiceObject,
                     row.PropertyObject as PropertyDefinitionBase,
                     true);
            }
            else if (this.CurrentObject is ServiceObject)
            {
                res = PropertyEditorDialog.ShowDialog(this.CurrentObject as ServiceObject,
                     row.PropertyObject as PropertyDefinitionBase,
                     false);
            }
            else
            {
                res = PropertyEditorDialog.ShowDialog(
                    row.IsNameNull() ? string.Empty : row.Name, 
                    row.IsTypeNull() ? string.Empty : row.Type,
                    row.IsKnownNamesNull() ? string.Empty : row.KnownNames,
                    row.IsValueNull() ? string.Empty : row.Value, 
                    row.IsSmartViewNull() ? string.Empty : row.SmartView);
            }

            // Fire the PropertyChanged event
            if (res == DialogResult.OK && PropertyChanged != null)
            {
                PropertyChanged(this, new EventArgs());
            }
        }
    }

    
}
