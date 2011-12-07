using System;
using System.Collections.Generic;
using EWSEditor.Logging;
using EWSEditor.Settings.Internals;
using Microsoft.Win32;

namespace EWSEditor.Settings
{
    public class GlobalSettings
    {
        // Defined registry value names
        private const string REG_KEY_APP_KEY_PATH = @"Software\Microsoft\EWSEditor\";

        /// <summary>
        /// Gets or sets a bool indicating if the debug log be saved to a file
        /// </summary>
        public static bool ShouldSaveLogToFile
        {
            get
            {
                return UserSettings.Default.ShouldSaveDebugOutput;
            }
            set
            {
                UserSettings.Default.ShouldSaveDebugOutput = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets the file path where the debug log should be saved
        /// </summary>
        public static string LogFilePath
        {
            get
            {
                // If there is no UserSetting set a default
                if (String.IsNullOrEmpty(UserSettings.Default.DebugOutputFile))
                {
                    // Try to get the MyDocuments folder
                    string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    if (!String.IsNullOrEmpty(filePath))
                    {
                        filePath = System.IO.Path.Combine(filePath, "ewseditor.log");
                    }

                    // If we can't get the MyDocuments folder then just try the root of C:\ and pray for rain
                    if (String.IsNullOrEmpty(filePath))
                    {
                        filePath = "C:\\ewseditor.log";
                    }

                    UserSettings.Default.DebugOutputFile = filePath;
                }

                return UserSettings.Default.DebugOutputFile;
            }
            set
            {
                UserSettings.Default.DebugOutputFile = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Defines the default page size used when issuing a CalendarView call
        /// </summary>
        public static int CalendarViewSize
        {
            get
            {
                return UserSettings.Default.CalendarViewSize;
            }
            set
            {
                UserSettings.Default.CalendarViewSize = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Defines the default page size used when issuing a FindFolder call
        /// </summary>
        public static int FindFolderViewSize
        {
            get
            {
                return UserSettings.Default.FindFolderViewSize;
            }
            set
            {
                UserSettings.Default.FindFolderViewSize = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Defines the default page size used when issuing a FindItem call
        /// </summary>
        public static int FindItemViewSize
        {
            get
            {
                return UserSettings.Default.FindItemViewSize;
            }
            set
            {
                UserSettings.Default.FindItemViewSize = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Defines the default page size used when dumping folder contents
        /// </summary>
        public static int DumpFolderViewSize
        {
            get
            {
                return UserSettings.Default.DumpFolderViewSize;
            }
            set
            {
                UserSettings.Default.DumpFolderViewSize = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets a bool to override SSL certificate validation when sending requests
        /// to an Exchange CAS server.  This is useful for test environments that
        /// rarely have valid certificates.
        /// </summary>
        public static bool OverrideCertValidation
        {
            get
            {
                return UserSettings.Default.OverrideCertValidation;
            }
            set
            {
                UserSettings.Default.OverrideCertValidation = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets a bool indicating if detailed SSL certification information should be
        /// written to the log
        /// </summary>
        public static bool EnableSslDetailLogging
        {
            get
            {
                return UserSettings.Default.EnableSslDetailLogging;
            }
            set
            {
                UserSettings.Default.EnableSslDetailLogging = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets a bool to allow following 302 redirects when performing Autodiscover
        /// </summary>
        public static bool AllowAutodiscoverRedirect
        {
            get
            {
                return UserSettings.Default.AllowAutodiscoverRedirect;
            }
            set
            {
                UserSettings.Default.AllowAutodiscoverRedirect = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets a bool to show the splash screen when EWSEditor is starting
        /// EWSEditor.
        /// </summary>
        public static bool ShowSplash
        {
            get
            {
                return UserSettings.Default.ShowSplash;
            }
            set
            {
                UserSettings.Default.ShowSplash = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// This string will be used as the UserAgent header value for all requests
        /// sent from EWSEditor
        /// </summary>
        public static string UserAgent
        {
            get
            {
                return UserSettings.Default.UserAgent;
            }
            set
            {
                UserSettings.Default.UserAgent = value;
                UserSettings.Default.Save();
            }
        }

        #region Private Methods

        /// <summary>
        /// Get the EWSEditor registry key for the current user.  If the
        /// key is initially not found, create it.
        /// </summary>
        private static RegistryKey GetAppRegKey(bool writable)
        {
            RegistryKey appRegKey = Registry.CurrentUser.OpenSubKey(REG_KEY_APP_KEY_PATH, writable);

            if (appRegKey == null)
            {
                RegistryKey softRegKey = Registry.CurrentUser.OpenSubKey("Software");
                if (softRegKey == null)
                {
                    DebugLog.WriteVerbose("Couldn't find HKCU\\Software");
                    throw new KeyNotFoundException("Unable to create registry key.");
                }

                RegistryKey msftRegKey = softRegKey.OpenSubKey("Microsoft", true);
                if (msftRegKey == null)
                {
                    DebugLog.WriteVerbose("Couldn't find HKCU\\Software\\Microsoft");
                    throw new KeyNotFoundException("Unable to create registry key.");
                }

                appRegKey = msftRegKey.CreateSubKey("EWSEditor");
            }

            return appRegKey;
        }

        #endregion
    }
}
