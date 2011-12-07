using System;
using System.Diagnostics;
using System.Reflection;
using EWSEditor.Logging;

namespace EWSEditor.Settings
{
    internal enum EwsApiVersions
    {
        OnePointZero,
        OnePointZeroHot,
        OnePointOne,
        OnePointOneHot,
        Unknown
    }

    internal class EnvironmentInfo
    {
        internal const string BuiltForEwsManagedApiVersion = "14.02.0051.000";
        internal const string Framework35RegistryPath = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5";
        internal const string EwsManagedApiInstallPath = @"C:\Program Files\Microsoft\Exchange\Web Services\1.1\Microsoft.Exchange.WebServices.dll";
        internal const string EwsManagedApiDownloadUrl = "http://www.microsoft.com/downloads/details.aspx?displaylang=en&FamilyID=c3342fb3-fbcc-4127-becf-872c746840e1";
        internal const string EwsEditorProjectUrl = "http://ewseditor.codeplex.com";
        internal const string EwsEditorBlogPostsUrl = "http://blogs.msdn.com/mstehle/archive/tags/EWSEditor/default.aspx";

        internal static string EwsEditorVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        internal static string EwsEditorTitle
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

        internal static string EwsEditorDescription
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

        internal static string EwsEditorProduct
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

        internal static string EwsEditorCopyright
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

        internal static string EwsEditorCompany
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

        internal static EwsApiVersions EwsApiVersion
        {
            get
            {
                if (EnvironmentInfo.EwsApiFileVersion.FileMajorPart == 14 &&
                    EnvironmentInfo.EwsApiFileVersion.FileMinorPart == 0)
                {
                    if (EnvironmentInfo.EwsApiFileVersion.FileBuildPart == 650 &&
                        EnvironmentInfo.EwsApiFileVersion.FilePrivatePart == 7)
                    {
                        return EwsApiVersions.OnePointZero;
                    }
                    else if (EnvironmentInfo.EwsApiFileVersion.FileBuildPart > 650)
                    {
                        return EwsApiVersions.OnePointZeroHot;
                    }
                }
                else if (EnvironmentInfo.EwsApiFileVersion.FileMajorPart == 14 &&
                    EnvironmentInfo.EwsApiFileVersion.FileMinorPart == 2)
                {
                    return EwsApiVersions.OnePointOneHot;
                }

                return EwsApiVersions.Unknown;
            }
        }

        internal static FileVersionInfo EwsApiFileVersion
        {
            get
            {
                System.Reflection.Assembly ewsapi = System.Reflection.Assembly.GetAssembly(typeof(Microsoft.Exchange.WebServices.Data.ExchangeService));
                System.Diagnostics.FileVersionInfo info = System.Diagnostics.FileVersionInfo.GetVersionInfo(ewsapi.Location);
                return info;
            }
        }

        internal static string EwsApiPath
        {
            get
            {
                System.Reflection.Assembly ewsapi = System.Reflection.Assembly.GetAssembly(typeof(Microsoft.Exchange.WebServices.Data.ExchangeService));
                return ewsapi.Location;
            }
        }

        internal static bool IsDotNetFramework35SP1
        {
            get
            {
                try
                {
                    Microsoft.Win32.RegistryKey key = null;
                    key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(Framework35RegistryPath);

                    if (key != null)
                    {
                        return Convert.ToInt32(key.GetValue("SP")) == 1;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    DebugLog.WriteVerbose("Handled exception and returned false.", ex);
                    return false;
                }
            }
        }

        internal static string DotNetFrameworkVersion
        {
            get
            {
                Microsoft.Win32.RegistryKey key = null;
                key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(Framework35RegistryPath);

                if (key != null)
                {
                    return key.GetValue("Version").ToString();
                }

                return string.Empty;
            }
        }
    }
}