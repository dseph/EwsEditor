namespace EWSEditor.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    using EWSEditor.Common;
    using EWSEditor.Diagnostics;
    using EWSEditor.Resources;

    // HiddenMainForm sits in the background and keeps
    // a form count.  When all forms are closed then it
    // exits the entire process.
    public partial class HiddenMainForm : Form
    {
        private static int _formCount = 0;
        private string CommandLineProfile = string.Empty;

        public HiddenMainForm(string profile)
        {
            InitializeComponent();
            this.CommandLineProfile = profile;
        }

        public HiddenMainForm()
        {
            InitializeComponent();
        }

        private void HiddenMainForm_Load(object sender, EventArgs e)
        {
            this.Visible = false;

            // Log a bunch of information about the current environment
            TraceHelper.Initialize(Application.LocalUserAppDataPath);
            TraceHelper.WriteInfo(string.Format(System.Globalization.CultureInfo.CurrentCulture, "EWSEditorVersion: {0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()));
            TraceHelper.WriteInfo(string.Format(System.Globalization.CultureInfo.CurrentCulture, "EWSEditorPath: {0}", Application.ExecutablePath));
            TraceHelper.WriteInfo(string.Format(System.Globalization.CultureInfo.CurrentCulture, "OSVersion: {0}", Environment.OSVersion));
            TraceHelper.WriteInfo(string.Format(System.Globalization.CultureInfo.CurrentCulture, "ImageRuntimeVersion: {0}", System.Reflection.Assembly.GetExecutingAssembly().ImageRuntimeVersion));
            TraceHelper.WriteInfo(string.Format(System.Globalization.CultureInfo.CurrentCulture, "FrameworkVesion: {0}", Constants.FrameworkVersion));
            TraceHelper.WriteInfo(string.Format(System.Globalization.CultureInfo.CurrentCulture, "EWSManagedAPIVersion: {0}", Constants.EWSManagedAPIFileVersion.FileVersion));
            TraceHelper.WriteInfo(string.Format(System.Globalization.CultureInfo.CurrentCulture, "EWSManagedAPIPath: {0}", Constants.EWSManagedAPIPath));

            Form firstForm = null;
            if (this.CommandLineProfile.Length > 0)
            {
                firstForm = new FolderTreeForm(this.CommandLineProfile);
            }
            else
            {
                firstForm = new FolderTreeForm();
            }
            
            firstForm.Show();

            // Display the AboutDialog as a splash screen
            if (ConfigHelper.ShowSplash)
            {
                AboutDialog.ShowDialog();
            }
        }

        // Each non-modal form should call this method
        // when loading to let this hidden controller
        // form now that there are forms alive.
        internal static void AddForm()
        {
            // Increase the open form count
            _formCount++;
        }

        // Each non-modal form should call this method
        // when closing to let this hidden controller
        // form know that that there is one less form
        // alive.  When all forms are closed then quit.
        internal static void ReleaseForm()
        {
            // Decrement the form count
            _formCount--;

            // If there are no forms, shutdown
            if (_formCount < 1)
            {
                DialogResult res = MessageBox.Show(
                    "EWSEditor automatically generates a history of the Exchange Web Services requests and responses.  Do you want to save this file after exiting?",
                    BaseForm.GetFormTitle("Save request/response history?"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (res == DialogResult.No)
                {
                    EWSEditorTraceListener.DeleteChatterLog();
                }

                Application.Exit();
            }
        }
    }
}