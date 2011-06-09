namespace EWSEditor.Common
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Text;

    using Microsoft.Win32;

    using EWSEditor.Diagnostics;

    public class ConfigHelper
    {
        private ConfigHelper()
        {
        }

        #region Constants

        // Defined registry value names
        private const string REG_KEY_APP_KEY_PATH = @"Software\Microsoft\EWSEditor\";
        private const string REG_VALUE_SHOWSPLASH = "ShowSplash";

        // Defined configuration key names
        private const string CONFIGKEY_CALENDAR_VIEW_SIZE = "CalendarViewSize";
        private const string CONFIGKEY_FIND_FOLDER_VIEW_SIZE = "FindFolderViewSize";
        private const string CONFIGKEY_FIND_ITEM_VIEW_SIZE = "FindItemViewSize";
        private const string CONFIGKEY_DUMP_FOLDER_VIEW_SIZE = "DumpFolderViewSize";
        private const string CONFIGKEY_OVERRIDE_CERT_VALIDATION = "OverrideServerCertificateValidation";
        private const string CONFIGKEY_OVERRIDE_AUTODISC_VALIDATION = "OverrideAutodiscValidation";

        // Defined default values for config settings
        private const int DEFAULT_CALENDAR_VIEW_SIZE = 100;
        private const int DEFAULT_FIND_FOLDER_VIEW_SIZE = 100;
        private const int DEFAULT_FIND_ITEM_VIEW_SIZE = 100;
        private const int DEFAULT_DUMP_FOLDER_VIEW_SIZE = 100;

        #endregion

        #region Configuration Properties

        /// <summary>
        /// Defines the default page size used when issuing a CalendarView call
        /// </summary>
        public static int CalendarViewSize
        {
            get
            {
                int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings[CONFIGKEY_CALENDAR_VIEW_SIZE], System.Globalization.CultureInfo.CurrentCulture);
                if (pageSize == 0)
                {
                    pageSize = DEFAULT_CALENDAR_VIEW_SIZE;
                }

                return pageSize;
            }
        }
        
        /// <summary>
        /// Defines the default page size used when issuing a FindFolder call
        /// </summary>
        public static int FindFolderViewSize
        {
            get
            {
                int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings[CONFIGKEY_FIND_FOLDER_VIEW_SIZE], System.Globalization.CultureInfo.CurrentCulture);
                if (pageSize == 0)
                {
                    pageSize = DEFAULT_FIND_FOLDER_VIEW_SIZE;
                }

                return pageSize;
            }
        }

        /// <summary>
        /// Defines the default page size used when issuing a FindItem call
        /// </summary>
        public static int FindItemViewSize
        {
            get
            {
                int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings[CONFIGKEY_FIND_ITEM_VIEW_SIZE], System.Globalization.CultureInfo.CurrentCulture);
                if (pageSize == 0)
                {
                    pageSize = DEFAULT_FIND_ITEM_VIEW_SIZE;
                }

                return pageSize;
            }
        }

        /// <summary>
        /// Defines the default page size used when dumping folder contents
        /// </summary>
        public static int DumpFolderViewSize
        {
            get
            {
                int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings[CONFIGKEY_DUMP_FOLDER_VIEW_SIZE], System.Globalization.CultureInfo.CurrentCulture);
                if (pageSize == 0)
                {
                    pageSize = DEFAULT_DUMP_FOLDER_VIEW_SIZE;
                }

                return pageSize;
            }
        }

        /// <summary>
        /// If true, override SSL certificate validation when sending requests
        /// to an Exchange CAS server.  This is useful for test environments that
        /// rarely have valid certificates.
        /// </summary>
        public static bool OverrideCertValidation
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings[CONFIGKEY_OVERRIDE_CERT_VALIDATION], System.Globalization.CultureInfo.CurrentCulture);
            }
        }

        public static bool AllowAutodiscoverRedirect
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings[CONFIGKEY_OVERRIDE_AUTODISC_VALIDATION], System.Globalization.CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// This flag is used to suppress the splash screen when starting
        /// EWSEditor.
        /// </summary>
        public static bool ShowSplash
        {
            get
            {
                // If there is a value return it, otherwise return the default
                object keyValue = GetAppRegKey(false).GetValue(REG_VALUE_SHOWSPLASH);

                // Default to true
                return keyValue == null ? true : Convert.ToBoolean(keyValue, System.Globalization.CultureInfo.CurrentCulture);
            }
            set
            {
                GetAppRegKey(true).SetValue(REG_VALUE_SHOWSPLASH, Convert.ToInt16(value), RegistryValueKind.DWord);
            }
        }

        #endregion

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
                    TraceHelper.WriteInfo("Couldn't find HKCU\\Software");
                    throw new KeyNotFoundException("Unable to create registry key.");
                }

                RegistryKey msftRegKey = softRegKey.OpenSubKey("Microsoft", true);
                if (msftRegKey == null)
                {
                    TraceHelper.WriteInfo("Couldn't find HKCU\\Software\\Microsoft");
                    throw new KeyNotFoundException("Unable to create registry key.");
                }

                appRegKey = msftRegKey.CreateSubKey("EWSEditor");
            }

            return appRegKey;
        }
    }
}
