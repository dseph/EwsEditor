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
        /// Indicagtes if the Bearer token should be logged or not.
        /// </summary>
        public static bool LogSecurityToken
        {
            get
            {
                return UserSettings.Default.LogSecurityToken;
            }
            set
            {
                UserSettings.Default.LogSecurityToken = value;
 
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
        /// Enables SCP Lookups used for Autodisocver
        /// </summary>
        public static bool EnableScpLookups
        {
            get
            {
                return UserSettings.Default.EnableScpLookups;
            }
            set
            {
                UserSettings.Default.EnableScpLookups = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Enables PreAuthenticate used for EWS calls.
        /// </summary>
        public static bool PreAuthenticate
        {
            get
            {
                return UserSettings.Default.PreAuthenticate;
            }
            set
            {
                UserSettings.Default.PreAuthenticate = value;
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

        /// <summary>
        /// This bool indicates if the client timezone should be overrridden on the service object.
        /// </summary>
        public static bool OverrideTimezone
        {
            get
            {
                return UserSettings.Default.OverrideTimezone;
            }
            set
            {
                UserSettings.Default.OverrideTimezone = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// This bool indicates if the client timezone should be overrridden on the service object.
        /// </summary>
        public static string SelectedTimeZoneId
        {
            get
            {
                return UserSettings.Default.SelectedTimeZoneId;
            }
            set
            {
                UserSettings.Default.SelectedTimeZoneId = value;
                UserSettings.Default.Save();
            }
        }

 

        /// <summary>
        /// This indicates if the timeout should be overriden on the session object. 
        ///  
        /// </summary>
        public static bool OverrideTimeout
        {
            get
            {
                return UserSettings.Default.OverrideTimeout;
            }
            set
            {
                UserSettings.Default.OverrideTimeout = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// This integer sets the timeout override on the session object
        /// sent from EWSEditor
        /// </summary>
        public static int Timeout
        {
            get
            {
                return UserSettings.Default.Timeout;
            }
            set
            {
                UserSettings.Default.Timeout = value;
                UserSettings.Default.Save();
            }
        }

   
 
 
        /// <summary>
        /// Gets or sets a bool to override to indicate that the WebProxy settings should be overridden and set to the respose to getdefaultproxy
        /// </summary>
        public static bool SetDefaultProxy
        {
            get
            {
                return UserSettings.Default.SetDefaultProxy;
            }
            set
            {
                UserSettings.Default.SetDefaultProxy = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets a bool to override to indicate that the WebProxy settings should be overridden.
        /// </summary>
        public static bool SpecifyProxySettings
        {
            get
            {
                return UserSettings.Default.SpecifyProxySettings;
            }
            set
            {
                UserSettings.Default.SpecifyProxySettings = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets the override proxy server name
        /// </summary>
        public static string ProxyServerName
        {
            get
            {
                return UserSettings.Default.ProxyServerName;
 
            }
            set
            {
                UserSettings.Default.ProxyServerName = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets the override proxy server name
        /// </summary>
        public static int ProxyServerPort
        {
            get
            {
                return UserSettings.Default.ProxyServerPort;
 
            }
            set
            {
                UserSettings.Default.ProxyServerPort = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets a bool to override to indicate that the WebProxy settings should Bypass the proxy for a local address
        /// </summary>
        public static bool BypassProxyForLocalAddress
        {
            get
            {
                return UserSettings.Default.BypassProxyForLocalAddress;
            }
            set
            {
                UserSettings.Default.BypassProxyForLocalAddress = value;
                UserSettings.Default.Save();
            }
        }



 

        /// <summary>
        /// Gets or sets a bool to override to indicate that the WebProxy credentials should be overridden.
        /// </summary>
        public static bool OverrideProxyCredentials
        {
            get
            {
                return UserSettings.Default.OverrideProxyCredentials;
            }
            set
            {
                UserSettings.Default.OverrideProxyCredentials = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets the override proxy user
        /// </summary>
        public static string ProxyServerUser
        {
            get
            {
                return UserSettings.Default.ProxyServerUser;

            }
            set
            {
                UserSettings.Default.ProxyServerUser = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets the override proxy password
        /// </summary>
        public static string ProxyServerPassword
        {
            get
            {
                return UserSettings.Default.ProxyServerPassword;
 
            }
            set
            {
                UserSettings.Default.ProxyServerPassword = value;
                UserSettings.Default.Save();
            }
        }

                /// <summary>
        /// Gets or sets the override proxy domain
        /// </summary>
        public static string ProxyServerDomain
        {
            get
            {
                return UserSettings.Default.ProxyServerDomain;
 
            }
            set
            {
                UserSettings.Default.ProxyServerDomain = value;
                UserSettings.Default.Save();
            }
        }


        /// <summary>
        /// Gets or sets a bool to override to indicate that the TimeZoneContext should be set.
        /// This is not set by the EWS Managed API if the server version is past 2007 SP1.
        /// </summary>
        public static bool AddTimeZoneContext
        {
            get
            {
                return UserSettings.Default.AddTimeZoneContext;
            }
            set
            {
                UserSettings.Default.AddTimeZoneContext = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// This bool indicates if the client timezone Contex should be overrridden on the service object.
        /// </summary>
        public static string SelectedTimeZoneContextId
        {
            get
            {
                return UserSettings.Default.SelectedTimeZoneContextId;
            }
            set
            {
                UserSettings.Default.SelectedTimeZoneContextId = value;
                UserSettings.Default.Save();
            }
        }

        //
            //        this.chkAdditionalHeader1.Text = GlobalSettings.EnableAdditionalHeader1;
            //this.txtAdditionalHeader1.Text = GlobalSettings.AdditionalHeader1;
            //this.txtAdditionalHeaderValue1.Text = GlobalSettings.AdditionalHeaderValue1;
            //this.chkAdditionalHeader2.Text = GlobalSettings.EnableAdditionalHeader2;
            //this.txtAdditionalHeader2.Text = GlobalSettings.AdditionalHeader2;
            //this.txtAdditionalHeaderValue2.Text = GlobalSettings.AdditionalHeaderValue2;
            //this.chkAdditionalHeader3.Text = GlobalSettings.EnableAdditionalHeader3;
            //this.txtAdditionalHeader3.Text = GlobalSettings.AdditionalHeader3;
            //this.txtAdditionalHeaderValue3.Text = GlobalSettings.AdditionalHeaderValue3;

        /// <summary>
        /// Enables setting of Additional Header 1
        /// </summary>
        /// 
        public static bool EnableAdditionalHeader1
        {
            get
            {
                return UserSettings.Default.EnableAdditionalHeader1;
            }
            set
            {
                UserSettings.Default.EnableAdditionalHeader1 = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets Additional Header 1
        /// </summary>
        public static string AdditionalHeader1
        {
            get
            {
                return UserSettings.Default.AdditionalHeader1;

            }
            set
            {
                UserSettings.Default.AdditionalHeader1 = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets Additional Header Value 1
        /// </summary>
        public static string AdditionalHeaderValue1
        {
            get
            {
                return UserSettings.Default.AdditionalHeaderValue1;

            }
            set
            {
                UserSettings.Default.AdditionalHeaderValue1 = value;
                UserSettings.Default.Save();
            }
        }

        //



        /// <summary>
        /// Enables setting of Additional Header 2
        /// </summary>
        /// 
        public static bool EnableAdditionalHeader2
        {
            get
            {
                return UserSettings.Default.EnableAdditionalHeader2;
            }
            set
            {
                UserSettings.Default.EnableAdditionalHeader2 = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets Additional Header 2
        /// </summary>
        public static string AdditionalHeader2
        {
            get
            {
                return UserSettings.Default.AdditionalHeader2;

            }
            set
            {
                UserSettings.Default.AdditionalHeader2 = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets Additional Header Value 2
        /// </summary>
        public static string AdditionalHeaderValue2
        {
            get
            {
                return UserSettings.Default.AdditionalHeaderValue2;

            }
            set
            {
                UserSettings.Default.AdditionalHeaderValue2 = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Enables setting of Additional Header 3
        /// </summary>
        /// 
        public static bool EnableAdditionalHeader3
        {
            get
            {
                return UserSettings.Default.EnableAdditionalHeader3;
            }
            set
            {
                UserSettings.Default.EnableAdditionalHeader3 = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets Additional Header 3
        /// </summary>
        public static string AdditionalHeader3
        {
            get
            {
                return UserSettings.Default.AdditionalHeader3;

            }
            set
            {
                UserSettings.Default.AdditionalHeader3 = value;
                UserSettings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets Additional Header Value 3
        /// </summary>
        public static string AdditionalHeaderValue3
        {
            get
            {
                return UserSettings.Default.AdditionalHeaderValue3;

            }
            set
            {
                UserSettings.Default.AdditionalHeaderValue3 = value;
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
