namespace EWSEditor.Common
{
    using System;
    using System.Collections.Generic;
    using System.DirectoryServices;
    using System.Linq;
    using System.Text;

    public class ActiveDirectoryHelper
    {
        /// <summary>
        /// Get the primary SMTP address of the given user name
        /// </summary>
        /// <param name="upnUserName">UPN formatted user name to look up</param>
        /// <returns>Primary SMTP address of the user if found</returns>
        public static string GetPrimarySmtp(string upnUserName)
        {
            string primarySmtp = string.Empty;

            // Use the current user's identity to get their
            // default SMTP address from the default domain.
            // In other words - make a lot of assumptions!

            // This logic is very thin but maybe it will stand up...
            // Expecting the format of the identity to be
            // 'DomainName\sAMAccountName', if not BOOM!
            if (!upnUserName.Contains("\\"))
            {
                throw new ApplicationException("Unknown identity name pattern, cannot retrieve default SMTP address.");
            }

            // Tear off the sAMAccountName from the identity string
            string sAMAccountName = upnUserName.Split(new char[] { '\\' })[1];

            // Search AD for the sAMAccountName
            DirectorySearcher ds = new DirectorySearcher();
            ds.Filter = string.Format(System.Globalization.CultureInfo.CurrentCulture, "sAMAccountName={0}", sAMAccountName);

            SearchResult result = ds.FindOne();
            if (result != null)
            {
                // Get the 'mail' property and assume the
                // first value is the primary SMTP address
                return result.Properties["mail"][0].ToString();
            }
            else
            {
                // If there are no results go BOOM!
                throw new ApplicationException("Directory entry not found, cannot retrieve default SMTP address.");
            }

            return string.Empty;
        }
    }
}
