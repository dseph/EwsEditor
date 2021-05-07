using System;
using System.Windows.Forms;
using EWSEditor.Logging;
using EWSEditor.Settings;

namespace EWSEditor.Forms
{
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
            DebugLog.WriteInfo(
                "Environment information",
                "EWSEditorVersion: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                "EWSEditorPath: " + Application.ExecutablePath,
                "OSVersion: " + Environment.OSVersion,
                "ImageRuntimeVersion: " + System.Reflection.Assembly.GetExecutingAssembly().ImageRuntimeVersion,
                "FrameworkVesion: " + EnvironmentInfo.DotNetFrameworkVersion,
                "EWSManagedAPIVersion: " + EnvironmentInfo.EwsApiFileVersion.FileVersion,
                "EWSManagedAPIPath: " + EnvironmentInfo.EwsApiPath);

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
            if (GlobalSettings.ShowSplash)
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
                Application.Exit();
            }
        }
    }
}