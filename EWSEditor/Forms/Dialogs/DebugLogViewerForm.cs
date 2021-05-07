using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using EWSEditor.Logging;

namespace EWSEditor.Forms
{
    public partial class DebugLogViewerForm : BaseForm
    {
        private static DebugLogViewerForm visibleForm = null;

        public DebugLogViewerForm()
        {
            InitializeComponent();
        }

        public new static void Show()
        {
            if (visibleForm != null)
            {
                visibleForm.BringToFront();
                return;
            }

            visibleForm = new DebugLogViewerForm();
            ((Form)visibleForm).Show();
        }

        private void DebugLogViewerForm_Load(object sender, EventArgs e)
        {
            LoadLogItems();
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            LoadLogItems();
        }

        private void LogItemsGrid_SelectionChanged(object sender, EventArgs e)
        {
            DebugLogItem item = null;

            // Make sure there is a selected raow
            if (this.LogItemsGrid.SelectedRows.Count == 1)
            {
                item = this.LogItemsGrid.SelectedRows[0].Tag as DebugLogItem;
            }

            LoadLogItemDetails(item);
        }

        private List<DebugLogType> SelectedLogTypes()
        {
            List<DebugLogType> types = new List<DebugLogType>();

            if (ErrorTypeCheck.Checked)
            {
                types.Add(DebugLogType.Error);
            }

            if (InformationTypeCheck.Checked)
            {
                types.Add(DebugLogType.Information);
            }

            if (VerboseTypeCheck.Checked)
            {
                types.Add(DebugLogType.Verbose);
            }

            if (EwsTraceTypeCheck.Checked)
            {
                types.Add(DebugLogType.EwsTrace);
            }

            return types;
        }

        private void LoadLogItems()
        {
            int selectedId = -1;

            // Save the selected log item..
            if (this.LogItemsGrid.SelectedRows.Count != 0)
            {
                DebugLogItem selectedItem = this.LogItemsGrid.SelectedRows[0].Tag as DebugLogItem;
                selectedId = selectedItem.Logid;
            }

            // Save sorting state..
            DataGridViewColumn sortColumn = this.LogItemsGrid.SortedColumn;
            SortOrder sortOrder = this.LogItemsGrid.SortOrder;

            // Filter debug log...
            List<DebugLogType> allowedTypes = SelectedLogTypes();
            var filteredLog = from i in DebugLog.DebugLogItems
                              where allowedTypes.Contains(i.Type)
                              select i;

            this.LogItemsGrid.Rows.Clear();

            foreach (DebugLogItem item in filteredLog)
            {
                int index = this.LogItemsGrid.Rows.Add(
                    item.Time,
                    item.Source,
                    item.Type,
                    item.Title);

                // Reapply selection..
                if (item.Logid == selectedId)
                {
                    this.LogItemsGrid.Rows[index].Selected = true;
                }

                // Save the item with the row for use later
                this.LogItemsGrid.Rows[index].Tag = item;
            }

            // Reapply sorting..
            if (sortOrder == SortOrder.Ascending)
            {
                this.LogItemsGrid.Sort(sortColumn, ListSortDirection.Ascending);
            }
            else if (sortOrder == SortOrder.Descending)
            {
                this.LogItemsGrid.Sort(sortColumn, ListSortDirection.Descending);
            }

            // Select the first log item if none was selected before..
            if (selectedId == -1 && this.LogItemsGrid.Rows.Count > 0)
            {
                this.LogItemsGrid.Rows[0].Selected = true;
            }

            // Reload the selected item
            LogItemsGrid_SelectionChanged(null, null);
        }

        private void LoadLogItemDetails(DebugLogItem item)
        {
            if (item == null)
            {
                this.TimeLabel.Text = string.Empty;
                this.TypeLabel.Text = string.Empty;
                this.SourceLabel.Text = string.Empty;
                this.TitleLabel.Text = string.Empty;
                this.TextDataViewText.Text = string.Empty;
                this.WebDataBrowser.Navigate("");
                return;
            }

            // Load the item properties into the details panel
            this.TimeLabel.Text = item.Time.ToString();
            this.TypeLabel.Text = item.Type.ToString();
            this.SourceLabel.Text = item.Source;
            this.TitleLabel.Text = item.Title;
            this.TextDataViewText.Text = item.Data;

            // Save the data to a temp file for "XML View"
            string tempFile = System.IO.Path.Combine(
                System.IO.Path.GetTempPath(),
                item.Type == DebugLogType.EwsTrace ? "ewseditordebuglogdata.xml" : "ewseditordebuglogdata.txt");
            System.IO.File.WriteAllText(tempFile, item.Data);
            this.WebDataBrowser.Navigate(tempFile);
        }

        private void DebugLogViewerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            visibleForm = null;
        }
    }
}
