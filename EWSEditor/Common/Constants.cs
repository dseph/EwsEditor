namespace EWSEditor.Common
{
    using System;
    using System.Diagnostics;

    using EWSEditor.Diagnostics;

    internal class Constants
    {
        internal const string BuiltForEwsManagedApiVersion = "14.00.0650.*";
        internal const string Framework35RegistryPath = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5";
        internal const string EwsManagedApiInstallPath = @"C:\Program Files\Microsoft\Exchange\Web Services\1.0\Microsoft.Exchange.WebServices.dll";
        internal const string EwsManagedApiDownloadUrl = "http://www.microsoft.com/downloads/details.aspx?displaylang=en&FamilyID=c3342fb3-fbcc-4127-becf-872c746840e1";

        internal enum EwsManagedApiVersions
        {
            RTM,
            RTMHot,
            SP1,
            SP1Hot,
            Unknown
        }

        internal static EwsManagedApiVersions LoadedEWSManagedAPIRelease
        {
            get
            {
                if (Constants.EWSManagedAPIFileVersion.FileMajorPart == 14 &&
                    Constants.EWSManagedAPIFileVersion.FileMinorPart == 0)
                {
                    if (Constants.EWSManagedAPIFileVersion.FileBuildPart == 650 &&
                        Constants.EWSManagedAPIFileVersion.FilePrivatePart == 7)
                    {
                        return EwsManagedApiVersions.RTM;
                    }
                    else if (Constants.EWSManagedAPIFileVersion.FileBuildPart > 650)
                    {
                        return EwsManagedApiVersions.RTMHot;
                    }
                }
                else if (Constants.EWSManagedAPIFileVersion.FileMajorPart == 14 &&
                    Constants.EWSManagedAPIFileVersion.FileMinorPart == 1)
                {
                    return EwsManagedApiVersions.SP1Hot;
                }

                return EwsManagedApiVersions.Unknown;
            }
        }

        internal static FileVersionInfo EWSManagedAPIFileVersion
        {
            get
            {
                System.Reflection.Assembly ewsapi = System.Reflection.Assembly.GetAssembly(typeof(Microsoft.Exchange.WebServices.Data.ExchangeService));
                System.Diagnostics.FileVersionInfo info = System.Diagnostics.FileVersionInfo.GetVersionInfo(ewsapi.Location);
                return info;
            }
        }

        internal static string EWSManagedAPIPath
        {
            get
            {
                System.Reflection.Assembly ewsapi = System.Reflection.Assembly.GetAssembly(typeof(Microsoft.Exchange.WebServices.Data.ExchangeService));
                return ewsapi.Location;
            }
        }

        internal static bool IsFramework_35SP1
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
                    TraceHelper.WriteVerbose(ex);
                    return false;
                }
            }
        }

        internal static string FrameworkVersion
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

        internal static string TraceLogBeginTag
        {
            get
            {
                string beginTag = string.Empty;

                switch (Constants.LoadedEWSManagedAPIRelease)
                {
                    case EwsManagedApiVersions.SP1Hot:
                        beginTag = "<Trace";
                        break;
                    default:
                        beginTag = "<EwsLogEntry";
                        break;
                }

                return beginTag;
            }
        }

        internal static string TraceLogEndTag
        {
            get
            {
                string endTag = string.Empty;

                switch (Constants.LoadedEWSManagedAPIRelease)
                {
                    case EwsManagedApiVersions.SP1Hot:
                        endTag = "</Trace>";
                        break;
                    default:
                        endTag = "</EwsLogEntry>";
                        break;
                }

                return endTag;
            }
        }
    }
}