using System;
using System.Windows.Forms;
using EWSEditor.Logging;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    /// <summary>
    /// This base form makes it really easy to implement new, specialized content
    /// forms for different types of content.  The steps to implement a new form
    /// are:
    /// 1. Override SetupForm, LoadContents, and LoadSelectionDetails
    ///    (see method comments for implementation notes)
    /// 2. Set RowIdColumnName to a column that uniquely identifies a row in the
    ///    ContentsGrid
    /// </summary>
    public partial class BaseContentForm : EWSEditor.Forms.BrowserForm
    {
        private Form callingForm = null;
        private string contentIdColumnName = string.Empty;
        private string detailIdColumnName = string.Empty;
        private PropertySet overrideDetailPropertySet = null;

        public BaseContentForm()
        {
            InitializeComponent();
            this.CenterToParent();
        }

        /// <summary>
        /// Gets or sets the form which created this form.
        /// </summary>
        protected Form CallingForm
        {
            get
            {
                return this.callingForm;
            }

            set
            {
                this.callingForm = value;
            }
        }

        /// <summary>
        /// Gets or sets the form which created this form.
        /// </summary>
        protected PropertySet OverrideDetailPropertySet  
        {
            get
            {
                return this.overrideDetailPropertySet;
            }

            set
            {
                this.overrideDetailPropertySet = value;
            }
        }

        /// <summary>
        /// Gets or sets the column name is used in RefreshContentAndDetails() 
        /// to identify the column which represents a unique identifier for 
        /// the selected row in the ContentsGrid and maintain the selection 
        /// after refreshing the data.
        /// </summary>
        protected string ContentIdColumnName
        {
            get
            {
                return this.contentIdColumnName;
            }

            set
            {
                this.contentIdColumnName = value;
            }
        }

        /// <summary>
        /// Gets or sets the column name is used in RefreshContentAndDetails() 
        /// to identify the column which represents a unique identifier for 
        /// the selected row in the DetailsGrid and maintain the selection 
        /// after refreshing the data.
        /// </summary>
        protected string DetialIdColumnName
        {
            get
            {
                return this.detailIdColumnName;
            }

            set
            {
                this.detailIdColumnName = value;
            }
        }

        /// <summary>
        /// Refresh the data displayed in the content and details grids.
        /// </summary>
        protected void RefreshContentAndDetails()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // Remember which content row was selected if there is a column
                // identified to uniquely identify rows
                string selectedId = this.GetSelectedContentId();

                // Reload the contents grid
                this.ContentsGrid.Rows.Clear();
                this.LoadContents();

                // Find and select the previously selected row if we saved the Id
                if (selectedId.Length > 0)
                {
                    foreach (DataGridViewRow row in this.ContentsGrid.Rows)
                    {
                        if (row.Cells[this.contentIdColumnName].Value != null &&
                            row.Cells[this.contentIdColumnName].Value.ToString().Equals(selectedId))
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }

                // Reload the details grid
                this.PropertyDetailsGrid.Clear();
                this.LoadSelectionDetails();
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        /// <summary>
        /// Get the value of the designated Id column of the currently
        /// selected row.  If no row is selected, return NULL.
        /// </summary>
        /// <returns>
        /// Returns the value of the Id column in the selected row of the
        /// ContentsGrid if found.  Otherwise it returns string.Empty.
        /// </returns>
        protected string GetSelectedContentId()
        {
            if (this.contentIdColumnName.Length == 0 || 
                !this.ContentsGrid.Columns.Contains(this.ContentIdColumnName)) 
            {

                DebugLog.WriteVerbose(String.Concat("Invalid value for RowIdColumnName, ", this.ContentIdColumnName));
                throw new InvalidOperationException("RowIdColumnName must be set to a valid column name.");
            }

            if (this.ContentsGrid.SelectedRows.Count > 0 &&
                this.ContentsGrid.SelectedRows[0] != null &&
                this.ContentsGrid.SelectedRows[0].Cells[this.ContentIdColumnName].Value != null)
            {
                return this.ContentsGrid.SelectedRows[0].Cells[this.ContentIdColumnName].Value.ToString();
            }

            return string.Empty;
        }

        protected virtual void LoadContents()
        {
            // Do Nothing...
        }

        protected virtual void LoadSelectionDetails()
        {
            // Do Nothing...
        }

        protected virtual void SetupForm()
        {
            // Do Nothing...
        }

        #region Events

        private void BaseContentForm_Load(object sender, EventArgs e)
        {
            // CurrentService should only be NULL here if we are in design mode
            // or there is an bug in form so bail out and do nothing.
            if (this.CurrentService == null) 
            { 
                return; 
            }

            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                this.ContentsGrid.Columns.Clear();

                this.SetupForm();

                // Set the form height and width to that
                // of the parent, just like MFCMAPI does
                if (this.callingForm != null)
                {
                    if (this.callingForm.WindowState == FormWindowState.Maximized)
                    {
                        this.WindowState = FormWindowState.Maximized;
                    }
                    else if (this.callingForm.WindowState == FormWindowState.Normal)
                    {
                        this.Size = this.callingForm.Size;
                        this.Location = this.callingForm.Location;
                    }
                }

                this.LoadContents();

                this.LoadSelectionDetails();

                this.mnuRefresh.Click += new EventHandler(this.MnuRefresh_Click);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        /// <summary>
        /// Right click should select the row that was clicked and
        /// display the context menu.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void ContentsGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.ContentsGrid.Rows[e.RowIndex].Selected = true;
            }
        }

        /// <summary>
        /// Call LoadSelectionDetails() if a row in the ContentsGrid is selected
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void ContentsGrid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                if (this.ContentsGrid.SelectedRows.Count != 1)
                {
                    return;
                }
                else
                {
                    this.LoadSelectionDetails();
                }
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        /// <summary>
        /// Refresh the contents and details grids, remember which content item was previously selected
        /// and select it again.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshContentAndDetails();
        }

        #endregion

        private void ContentsGrid_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.ValueType == typeof(DateTime))
            {
                DateTime date1 = Convert.ToDateTime(e.CellValue1);
                DateTime date2 = Convert.ToDateTime(e.CellValue2);

                e.SortResult = System.DateTime.Compare(date1, date2);
                e.Handled = true;
            }
        }

        private void ContentsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }
    }
}
