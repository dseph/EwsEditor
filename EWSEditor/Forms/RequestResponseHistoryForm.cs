namespace EWSEditor.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    using EWSEditor.Common;
    using EWSEditor.Diagnostics;
    using EWSEditor.Resources;

    public partial class RequestResponseHistoryForm : CountedForm
    {
        private static RequestResponseHistoryForm CurrentForm = null; 
        private DateTime StartLogTime = DateTime.MinValue;

        private RequestResponseHistoryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Display the form, but only ever show one instance of
        /// the form.
        /// </summary>
        public static new void Show()
        {
            if (CurrentForm == null)
            {
                CurrentForm = new RequestResponseHistoryForm();
            }

            if (CurrentForm.Visible == false)
            {
                CurrentForm.Visible = true;
            }
            else
            {
                CurrentForm.LoadMessages();
                CurrentForm.Activate();
            }
        }

        /// <summary>
        /// If the form is showing, refresh the list of messages.
        /// </summary>
        public static void RefreshMessages()
        {
            if (CurrentForm != null && CurrentForm.Visible == true)
            {
                CurrentForm.LoadMessages();
            }
        }

        /// <summary>
        /// Show the form and display the current messages logged
        /// since EWSEditor started.
        /// </summary>
        private void ChatterLogForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                LoadMessages();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Load the list of message headers into the ListView
        /// </summary>
        private void LoadMessages()
        {
            this.lstMessages.Items.Clear();

            foreach (string header in EWSEditorTraceListener.GetAllLogHeaders())
            {
                ListViewItem item = new ListViewItem();

                // Add the raw header in the Tag for later retrieval
                // of the message.
                item.Tag = header;

                string ATTRIBUTE_TIMESTAMP = string.Empty;
                string ATTRIBUTE_ENTRYKIND = string.Empty;
                switch (Constants.EwsApiVersion)
                {
                    case EwsApiVersions.OnePointZero:
                    case EwsApiVersions.OnePointZeroHot:
                        ATTRIBUTE_TIMESTAMP = "Timestamp=\"";
                        ATTRIBUTE_ENTRYKIND = "EntryKind=\"";
                        break;
                    case EwsApiVersions.OnePointOne:
                    case EwsApiVersions.OnePointOneHot:
                        ATTRIBUTE_TIMESTAMP = "Time=\"";
                        ATTRIBUTE_ENTRYKIND = "Tag=\"";
                        break;
                    default:
                        return;
                }
                

                // Parse the Timestamp out of the header
                if (header.IndexOf(ATTRIBUTE_TIMESTAMP) == -1)
                {
                    throw new ApplicationException("Cannot find timestamp in message header.");
                }
                int startOfDate = header.IndexOf(ATTRIBUTE_TIMESTAMP) + ATTRIBUTE_TIMESTAMP.Length;
                int lengthOfDate = header.IndexOf("\"", startOfDate) - startOfDate;
                string date = header.Substring(startOfDate, lengthOfDate);
                DateTime time = Convert.ToDateTime(date);

                // If there is a log start time set, make sure the logs
                // occur after it.
                if (this.StartLogTime == DateTime.MinValue || this.StartLogTime < time)
                {

                    // /Parse the EntryKind out of the header
                    if (header.IndexOf(ATTRIBUTE_ENTRYKIND) == 0)
                    {
                        throw new ApplicationException("Cannot find EntryKind in message header.");
                    }
                    int startOfKind = header.IndexOf(ATTRIBUTE_ENTRYKIND) + ATTRIBUTE_ENTRYKIND.Length;
                    int lengthOfKind = header.IndexOf("\"", startOfKind) - startOfKind;

                    // For requests and responses, display the method name or response type
                    // rather than the log type.
                    string kind = EWSEditorTraceListener.GetMethodFromHeader(header);
                    if (kind.Length == 0)
                    {
                        kind = header.Substring(startOfKind, lengthOfKind);
                    }

                    item.Text = time.ToLongTimeString();
                    item.SubItems.Add(kind);

                    lstMessages.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Clear the CurrentForm so that a new ChatterLogForm will
        /// open next time.
        /// </summary>
        private void ChatterLogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CurrentForm = null;
        }

        /// <summary>
        /// Get the selected message written to disk and display the file
        /// in the web browser control.
        /// </summary>
        private void lstMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Don't do anything if no messages are selected.
            if (lstMessages.SelectedItems.Count != 1) return;

            // Get the path to the temp file where the message has been written.
            string tempFile = string.Empty;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                tempFile = EWSEditorTraceListener.GetEWSMessage(lstMessages.SelectedItems[0].Tag.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            if (System.IO.File.Exists(tempFile))
            {
                browser.Navigate(tempFile);
            }
            else
            {
                ErrorDialog.ShowWarning(DisplayStrings.WARN_EWS_LOG_MESSAGE_NOT_FOUND);
            }
        }

        /// <summary>
        /// Reset the start time to show all messages logged since
        /// EWSEditor started.
        /// </summary>
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            this.StartLogTime = DateTime.MinValue;
            LoadMessages();
        }

        /// <summary>
        /// Clear the messages list and reset the start log time
        /// to the current time - only show messages that are logged
        /// from 'now' onward.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.StartLogTime = DateTime.Now;
            this.browser.Navigate("");
            this.lstMessages.Items.Clear();
        }

        /// <summary>
        /// Adjust the width of the messsage type column to
        /// grow with the ListView.
        /// </summary>
        private void lstMessages_Resize(object sender, EventArgs e)
        {
            colType.Width = lstMessages.Width - colTime.Width - 5;
        }

        /// <summary>
        /// Copy the currently selected request or response to the clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(
                System.IO.File.ReadAllText(
                    EWSEditorTraceListener.GetEWSMessage(lstMessages.SelectedItems[0].Tag.ToString())));
        }
    }
}

