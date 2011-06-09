namespace EWSEditor
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using EWSEditor.Common;
    using EWSEditor.Diagnostics;
    using EWSEditor.Forms;

    static class Program
    {
        static Program()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }

        /// <summary>
        /// Handle situation where a dependeny fails to load gracefully.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="args">The parameter is not used.</param>
        /// <returns>
        /// In the case of Microsoft.Exchange.WebServices we can attempt to load the assembly
        /// from another location.  All other cases we just display a message and die.
        /// </returns>
        private static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            // Special handling just for the EWS Managed API
            if (args.Name.Contains("Microsoft.Exchange.WebServices"))
            {
                // Try to load the DLL from the install location if not found in the .NET assembly path
                if (System.IO.File.Exists(Constants.EwsManagedApiInstallPath))
                {
                    return System.Reflection.Assembly.LoadFrom(Constants.EwsManagedApiInstallPath);
                }

                // If the API is not found on the machine then display an error message and offer to
                // take the user to the download page.
                EWSEditor.Forms.ManagedApiDialog.ShowDialog();

                // If we failed to load an assembly there's nothing left to do so kill the process
                System.Environment.Exit(0);
            }

            return null;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

                // Require .NET Framework 3.5 SP1 before starting
                if (!Constants.IsDotNetFramework35SP1)
                {
                    ErrorDialog.ShowError("EWSEditor and the Exchange Web Services Managed API require at least the .NET Framework 3.5 SP1.");
                    TraceHelper.WriteInfo(String.Format("Framework version {0}, is not .NET Framework 3.5 SP1", Constants.DotNetFrameworkVersion));
                    return;
                }

                // If we have command line arguments, parse them...
                if (Environment.GetCommandLineArgs().Length > 1)
                {
                    string profile = Environment.GetCommandLineArgs()[1];
                    Application.Run(new HiddenMainForm(profile));
                }
                else
                {
                    Application.Run(new HiddenMainForm());
                }
            }
            catch (System.Security.SecurityException ex)
            {
                ErrorDialog.ShowError("EWSEditor may not work from a network share due to code access security features in the .NET framework.");

                TraceHelper.WriteVerbose("Exception handled, assumed to be a running from network share.");
                TraceHelper.WriteVerbose(ex);
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            TraceHelper.WriteError(e.Exception);
            ErrorDialog.ShowError(e.Exception);
        }
    }
}