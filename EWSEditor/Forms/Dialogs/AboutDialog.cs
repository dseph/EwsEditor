namespace EWSEditor.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Windows.Forms;

    using EWSEditor.Common;

    public partial class AboutDialog : DialogForm
    {
        private static AboutDialog currentDialog = null;

        public AboutDialog()
        {
            InitializeComponent();
            this.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "About {0}", this.AssemblyTitle);
            this.lblProductName.Text = this.AssemblyProduct;
            this.lblProductVersion.Text = this.AssemblyVersion;
            this.lblCopyright.Text = this.AssemblyCopyright;

            StringBuilder descrip = new StringBuilder();
            
            descrip.AppendLine(string.Format(
                System.Globalization.CultureInfo.CurrentCulture, 
                "Target EWS Managed API Version: {0}", 
                Constants.BuiltForEwsManagedApiVersion));

            descrip.AppendLine(string.Format(
                System.Globalization.CultureInfo.CurrentCulture, 
                "Loaded EWS Managed API Version: {0}",
                Constants.EWSManagedAPIFileVersion.FileVersion));

            descrip.AppendLine(string.Format(
                    System.Globalization.CultureInfo.CurrentCulture, 
                    "Loaded EWS Managed API Path: {0}", 
                    Constants.EWSManagedAPIPath));

            descrip.AppendLine(string.Format(
                System.Globalization.CultureInfo.CurrentCulture, 
                "Loaded .NET Framework Version: {0}",
                Constants.FrameworkVersion));

            descrip.AppendLine();
            descrip.AppendLine("EWSEditor demonstrates the Exchange Web Services Managed API.");
            descrip.AppendLine();

            descrip.AppendLine(string.Format(
                System.Globalization.CultureInfo.CurrentCulture, 
                "This build assumes you are using a build of the EWS Managed API version {0} or later.  Other versions may or may not work, good luck!", 
                Constants.BuiltForEwsManagedApiVersion));

            this.txtDescription.Text = descrip.ToString();
            this.btnOK.Select();
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != string.Empty)
                    {
                        return titleAttribute.Title;
                    }
                }

                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }

                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }

                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }

                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }

                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        public static new void ShowDialog()
        {
            if (currentDialog == null)
            {
                currentDialog = new AboutDialog();
                ((Form)currentDialog).ShowDialog();
                currentDialog = null;
            }
            else
            {
                currentDialog.BringToFront();
            }
        }

        private void AboutDialog_Load(object sender, EventArgs e)
        {
            this.chkStartup.Checked = ConfigHelper.ShowSplash;
        }

        private void ChkStartup_CheckedChanged(object sender, EventArgs e)
        {
            ConfigHelper.ShowSplash = this.chkStartup.Checked;
        }

        private void CodeGalleryLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://code.msdn.microsoft.com/ewseditor");
        }

        private void MoreEwsEditor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://blogs.msdn.com/mstehle/archive/tags/EWSEditor/default.aspx");
        }
    }
}
