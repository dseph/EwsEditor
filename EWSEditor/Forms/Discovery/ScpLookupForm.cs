using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace EWSEditor.Forms
{
    public partial class ScpLookupForm : Form
    {
        // GUID for SCP URL keyword.
        private const string ScpUrlGuidString = @"77378F46-2C66-4aa9-A6A6-3E7A48B19596";

        // GUID for SCP pointer keyword.
        private const string ScpPtrGuidString = @"67661d7F-8FC4-4fa7-BFAC-E1D7794C1F68";

        private StringBuilder oLog = new StringBuilder();

        public ScpLookupForm()
        {
            InitializeComponent();
        }

        private void ScpLookupForm_Load(object sender, EventArgs e)
        {
            // See AutodiscoverInfo.cs
            // https://msdn.microsoft.com/en-us/library/office/dn467397(v=exchg.150).aspx
            // https://blogs.msdn.microsoft.com/webdav_101/2013/06/25/exchange-autodiscover-checker/
        }

       
        private void btnRun_Click(object sender, EventArgs e)
        {
            oLog = new StringBuilder();
            string domain = txtDomain.Text.Trim();
            if (domain.Length != 0)
                ScpLookupLookup(domain);
            else
                MessageBox.Show("Domain must be set.");
            txtResults.Text = oLog.ToString();
        }
        private void ScpLookupLookup(string domain)
        {

            oLog.AppendFormat("Performing SCP lookup for {0}.\r\n\r\n", domain);

            List<string> scpUrls = GetScpUrls(null, domain);

            oLog.AppendFormat("Ordered List of Autodiscover endpoints:\r\n\r\n");
            foreach (string url in scpUrls)
            {
                oLog.AppendFormat("  {0}\r\n\r\n", url);
            }

            oLog.AppendFormat("SCP lookup done.\r\n\r\n");
        }

        List<string> GetScpUrls(string ldapServer, string domain)
        {
            // Create a new list to return.
            List<string> scpUrlList = new List<string>();

            string rootDSEPath = null;

            // If ldapServer is null/empty, use LDAP://RootDSE to
            // connect to Active Directory Domain Services (AD DS). Otherwise, use
            // LDAP://SERVERNAME/RootDSE to connect to a specific server.
            if (string.IsNullOrEmpty(ldapServer))
            {
                rootDSEPath = "LDAP://RootDSE";
            }
            else
            {
                rootDSEPath = ldapServer + "/RootDSE";
            }

            SearchResultCollection scpEntries = null;

            try
            {
                // Get the root directory entry.
                DirectoryEntry rootDSE = new DirectoryEntry(rootDSEPath);

                // Get the configuration path.
                string configPath = rootDSE.Properties["configurationNamingContext"].Value as string;

                // Get the configuration entry.
                DirectoryEntry configEntry = new DirectoryEntry("LDAP://" + configPath);

                // Create a search object for the configuration entry.
                DirectorySearcher configSearch = new DirectorySearcher(configEntry);

                // Set the search filter to find SCP URLs and SCP pointers.
                configSearch.Filter = "(&(objectClass=serviceConnectionPoint)" +
                    "(|(keywords=" + ScpPtrGuidString + ")(keywords=" + ScpUrlGuidString + ")))";

                // Specify which properties you want to retrieve.
                configSearch.PropertiesToLoad.Add("keywords");
                configSearch.PropertiesToLoad.Add("serviceBindingInformation");

                scpEntries = configSearch.FindAll();
            }
            catch (Exception ex)
            {
                oLog.AppendFormat("SCP lookup failed with: \r\n\r\n");
                oLog.AppendFormat(ex.ToString() + "n");
            }

            // If no SCP entries were found, then exit.
            if (scpEntries == null || scpEntries.Count <= 0)
            {
                oLog.AppendFormat("No SCP records found.\r\n\r\n");
                return null;
            }

            string fallBackLdapPath = null;

            // Check for SCP pointers.
            foreach (SearchResult scpEntry in scpEntries)
            {
                ResultPropertyValueCollection entryKeywords = scpEntry.Properties["keywords"];

                if (CollectionContainsExactValue(entryKeywords, ScpPtrGuidString))
                {
                    string ptrLdapPath = scpEntry.Properties["serviceBindingInformation"][0] as string;

                    // Determine whether this pointer is scoped to the user's domain.
                    if (CollectionContainsExactValue(entryKeywords, "Domain=" + domain))
                    {
                        oLog.AppendFormat("Found SCP pointer for " + domain + " in " + scpEntry.Path + "\r\n\r\n");

                        // Restart SCP lookup with the server assigned for the domain.
                        oLog.AppendFormat("Restarting SCP lookup in {0}\r\n\r\n", ptrLdapPath);
                        return GetScpUrls(ptrLdapPath, domain);
                    }
                    else
                    {
                        // Save the first SCP pointer that is not scoped to a domain as a fallback
                        // in case you do not get any results from this server.
                        if (entryKeywords.Count == 1 && string.IsNullOrEmpty(fallBackLdapPath))
                        {
                            fallBackLdapPath = ptrLdapPath;
                            oLog.AppendFormat("Saved fallback SCP pointer: {0}\r\n\r\n", fallBackLdapPath);
                        }
                    }
                }
            }

            string computerSiteName = null;

            try
            {
                // Get the name of the ActiveDirectorySite the computer
                // belongs to (if it belongs to one).
                ActiveDirectorySite site = ActiveDirectorySite.GetComputerSite();
                computerSiteName = site.Name;

                oLog.AppendFormat("Local computer in site: {0}\r\n\r\n", computerSiteName);
            }
            catch (Exception ex)
            {
                oLog.AppendFormat("Unable to get computer site name.\n");
                oLog.AppendFormat(ex.ToString() + "\r\n\r\n");
            }

            if (!string.IsNullOrEmpty(computerSiteName))
            {
                // Scan the search results for SCP URLs.
                // SCP URLs fit into three tiers:
                //   Priority 1: The URL is scoped to the computer's Active Directory site.
                //   Priority 2: The URL is not scoped to any Active Directory site.
                //   Priority 3: The URL is scoped to a different Active Directory site.

                // Temporary lists to hold priority 2 and 3 URLs.
                List<string> priorityTwoUrls = new List<string>();
                List<string> priorityThreeUrls = new List<string>();

                foreach (SearchResult scpEntry in scpEntries)
                {
                    ResultPropertyValueCollection entryKeywords = scpEntry.Properties["keywords"];

                    // Check for SCP URLs.
                    if (CollectionContainsExactValue(entryKeywords, ScpUrlGuidString))
                    {
                        string scpUrlPath = scpEntry.Properties["adsPath"][0] as string;
                        oLog.AppendFormat("SCP URL found at: {0}\r\n\r\n", scpUrlPath);

                        string scpUrl = scpEntry.Properties["serviceBindingInformation"][0] as string;
                        scpUrl = scpUrl.ToLower();

                        // Determine whether this entry is scoped to the computer's site.
                        if (CollectionContainsExactValue(entryKeywords, "Site=" + computerSiteName))
                        {
                            // Priority 1.
                            if (!scpUrlList.Contains(scpUrl.ToLower()))
                            {
                                oLog.AppendFormat("Adding priority 1 SCP URL: {0}\r\n\r\n", scpUrl.ToLower());
                                scpUrlList.Add(scpUrl);
                            }
                            else
                            {
                                oLog.AppendFormat("Priority 1 SCP URL already found: {0}\r\n\r\n", scpUrl);
                            }
                        }
                        else
                        {
                            // Determine whether this is a priority 2 or 3 URL.
                            if (CollectionContainsPrefixValue(entryKeywords, "Site="))
                            {
                                // Priority 3.
                                if (!priorityThreeUrls.Contains(scpUrl))
                                {
                                    oLog.AppendFormat("Adding priority 3 SCP URL: {0}\r\n\r\n", scpUrl);
                                    priorityThreeUrls.Add(scpUrl);
                                }
                                else
                                {
                                    oLog.AppendFormat("Priority 3 SCP URL already found: {0}\r\n\r\n", scpUrl);
                                }
                            }
                            else
                            {
                                // Priority 2.
                                if (!priorityTwoUrls.Contains(scpUrl))
                                {
                                    oLog.AppendFormat("Adding priority 2 SCP URL: {0}\r\n\r\n", scpUrl);
                                    priorityTwoUrls.Add(scpUrl);
                                }
                                else
                                {
                                    oLog.AppendFormat("Priority 2 SCP URL already found: {0}\r\n\r\n", scpUrl);
                                }
                            }
                        }
                    }
                }

                // Now add the priority 2 URLs into the main list.
                foreach (string priorityTwoUrl in priorityTwoUrls)
                {
                    // If the URL is already in the list as a priority 1, 
                    // don't add it again.
                    if (!scpUrlList.Contains(priorityTwoUrl))
                    {
                        scpUrlList.Add(priorityTwoUrl);
                    }
                }

                // Now add the priority 3 URLs into the main list.
                foreach (string priorityThreeUrl in priorityThreeUrls)
                {
                    // If the URL is already in the list as a priority 1
                    // or priority 2, don't add it again.
                    if (!scpUrlList.Contains(priorityThreeUrl))
                    {
                        scpUrlList.Add(priorityThreeUrl);
                    }
                }

                // If after all this, you still have no URLs in your list,
                // try the fallback SCP pointer, if you have one.
                if (scpUrlList.Count == 0 && fallBackLdapPath != null)
                {
                    return GetScpUrls(fallBackLdapPath, domain);
                }
            }

            return scpUrlList;
        }

        private bool CollectionContainsExactValue(ResultPropertyValueCollection collection, string value)
        {
            foreach (object obj in collection)
            {
                string entry = obj as string;
                if (entry != null)
                {
                    if (string.Compare(value, entry, true) == 0)
                        return true;
                }
            }

            return false;
        }

        private bool CollectionContainsPrefixValue(ResultPropertyValueCollection collection, string value)
        {
            foreach (object obj in collection)
            {
                string entry = obj as string;
                if (entry != null)
                {
                    if (entry.StartsWith(value))
                        return true;
                }
            }

            return false;
        }

    }
}
