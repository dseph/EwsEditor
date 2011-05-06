namespace EWSEditor.Common.ServiceProfiles
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;

    using Microsoft.Exchange.WebServices.Data;

    using EWSEditor.Common;
    using EWSEditor.Common.Extensions;
    using EWSEditor.Diagnostics;
    using EWSEditor.Forms;
    using EWSEditor.PropertyInformation;

    internal struct ServiceProfileItem
    {
        internal readonly ExchangeService Service;
        internal readonly FolderId[] RootFolderIds;

        internal ServiceProfileItem(ExchangeService service, FolderId[] rootFolderIds)
        {
            Service = service;
            RootFolderIds = rootFolderIds;
        }
    }

    internal class ServiceProfile
    {
        private List<ServiceProfileItem> profileItems = new List<ServiceProfileItem>();

        /// <summary>
        /// Returns the collection of ServiceProfileItems loaded in this ServiceProfile.
        /// </summary>
        internal ServiceProfileItem[] Items
        {
            get
            {
                return this.profileItems.ToArray();
            }
        }

        /// <summary>
        /// Constructor which creates an empty ServiceProfile to add items to
        /// and save.
        /// </summary>
        internal ServiceProfile()
        {
            // Do nothing.
        }

        /// <summary>
        /// Constructor which loads a saved ServiceProfile from a file at the
        /// given path.
        /// </summary>
        /// <param name="profilePath">Path to ServiceProfile XML file.</param>
        /// /// <param name="showDialogs">Indicates whether to show UI when needed.</param>
        /// /// <param name="testServices">Indicates whether to test the ExchangeServices before returning them.</param>
        internal ServiceProfile(string profilePath, bool showDialogs, bool testServices)
        {
            ServicesProfile.ServiceBindingDataTable dt = new ServicesProfile.ServiceBindingDataTable();
            dt.ReadXml(profilePath);

            foreach (ServicesProfile.ServiceBindingRow row in dt.Rows)
            {
                try
                {
                    ExchangeService service = null;

                    if (!row.UsesDefaultCredentials)
                    {
                        // Display the Name of the binding in the dialog rather than the URL which
                        // can be ambiguous...
                        System.Net.NetworkCredential cred = null;

                        // For the sake of debugging, we could allow a tester to hard code a user name
                        // and password into the ServiceProfile.
                        cred = new System.Net.NetworkCredential(
                            row.IsUserNameNull() ? null: row.UserName, 
                            row.IsPasswordNull() ? null : row.Password, 
                            row.IsDomainNull() ? null : row.Domain);

                        if (row.IsUserNameNull() || row.IsPasswordNull() || row.IsDomainNull())
                        {
                            // If we are allowed to show dialogs, pop up a credential dialog to get
                            // input from the user.
                            if (showDialogs)
                            {
                                // If we have a service name to display, use it as the caption for
                                // the credential dialog.
                                if (!row.IsNameNull())
                                {
                                    NetworkCredDialog.ShowDialog(row.Name, ref cred);
                                }
                                else
                                {
                                    NetworkCredDialog.ShowDialog(row.ServicesURL, ref cred);
                                }
                            }
                        }
                        else
                        {
                            
                        }

                        // If we still don't have credentials, throw.
                        if (cred != null)
                        {
                            service = LoadExchangeServiceFromProfileRow(row, cred);
                        }
                        else
                        {
                            throw new ApplicationException(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Cannot load binding {0} without credentials.", row.Name));
                        }
                    }
                    else
                    {
                        service = LoadExchangeServiceFromProfileRow(row, null);
                    }

                    if (testServices)
                    {
                        service.TestExchangeService(ConfigHelper.OverrideCertValidation);
                    }

                    FolderId[] rootFolderIds = LoadRootFolderIdsFromProfileRow(row);

                    this.profileItems.Add(new ServiceProfileItem(service, rootFolderIds));
                }
                catch (Exception ex)
                {
                    TraceHelper.WriteVerbose("Handled exception when loading profile:");
                    TraceHelper.WriteVerbose(ex);

                    // If we are allowed to show dialogs, display the exception.  If not, keep
                    // on loading ServiceProfileItems
                    if (showDialogs)
                    {
                        // Catch and handle each exception within the loop so that failing
                        // to load one ExchangeService doesn't cause the remaining to be skipped.
                        ErrorDialog.ShowError(ex);
                    }

                    // Because there might be multiple profiles loaded, instead of waiting for
                    // each one to fail, give the option to stop loading the entire profile
                    DialogResult result = MessageBox.Show(
                        "Do you want to continue to load ExchangeServices from this profile?",
                        BaseForm.GetFormTitle(""),
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.No)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Save the current ServiceBinding settings to the DataTable
        /// </summary>
        /// <param name="service">ExchangeService to store in profile.</param>
        /// <param name="rootFolderIds">Array of root folder ids to store with the ExchangeService.</param>
        internal void AddServiceToProfile(ExchangeService service, FolderId[] rootFolderIds)
        {
            this.profileItems.Add(new ServiceProfileItem(service, rootFolderIds));
        }

        /// <summary>
        /// Save the current profile and its items to the given file path.
        /// </summary>
        /// <param name="profilePath">File to save the profile information.</param>
        internal void SaveProfile(string profilePath)
        {
            ServicesProfile.ServiceBindingDataTable data = new ServicesProfile.ServiceBindingDataTable();

            foreach (ServiceProfileItem item in this.profileItems)
            {
                ServicesProfile.ServiceBindingRow row = data.NewServiceBindingRow();

                row.Name = PropertyInterpretation.GetPropertyValue(item.Service);

                //row.AutoDiscoverEmail = this.AutodiscoverEmailUsed;

                row.ServicesURL = item.Service.Url.OriginalString;

                row.RequestedServerVersion = item.Service.RequestedServerVersion.ToString();

                if (item.Service.ImpersonatedUserId != null)
                {
                    row.ImpersonationId = item.Service.ImpersonatedUserId.Id;
                    row.ImpersonationType = item.Service.ImpersonatedUserId.IdType.ToString();
                }

                row.UsesDefaultCredentials = item.Service.UseDefaultCredentials;
                row.UserName = item.Service.GetNetworkCredential().UserName;
                row.Domain = item.Service.GetNetworkCredential().Domain;

                // Add root folders to the data table.
                StringBuilder sb = new StringBuilder();
                foreach (FolderId id in item.RootFolderIds)
                {
                    // If this is not the first FolderId add a separator
                    if (sb.Length > 0)
                    {
                        sb.Append("|");
                    }

                    if (id.FolderName.HasValue && id.Mailbox != null)
                    {
                        sb.Append(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Name:{0},Mbx:{1}", id.FolderName.ToString(), id.Mailbox.Address));
                    }
                    else if (id.FolderName.HasValue)
                    {
                        sb.Append(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Name:{0}", id.FolderName.ToString()));
                    }
                    else
                    {
                        sb.Append(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Id:{0}", id.UniqueId));
                    }
                }
                row.RootFolderIds = sb.ToString();

                data.AddServiceBindingRow(row);
            }

            data.WriteXml(profilePath);
        }

        /// <summary>
        /// Get the ExchangeService from a given row.
        /// </summary>
        private ExchangeService LoadExchangeServiceFromProfileRow(
            ServicesProfile.ServiceBindingRow row,
            NetworkCredential cred)
        {
            // Create the ExchangeService
            ExchangeService service = new ExchangeService();

            if (!row.IsRequestedServerVersionNull())
            {
                // Convert the string to an ExchangeVersion enumeration
                ExchangeVersion req =
                    (ExchangeVersion)System.Enum.Parse(typeof(ExchangeVersion), row.RequestedServerVersion);
                service = new ExchangeService(req);
            }
            else
            {
                service = new ExchangeService();
            }

            // Setup request/response tracer...
            service.TraceEnabled = true;
            service.TraceListener = new EWSEditorTraceListener();

            // Load autodiscover email if found
            if (!row.IsAutoDiscoverEmailNull())
            {
                if (ConfigHelper.OverrideAutodiscValidation)
                {
                    service.AutodiscoverUrl(row.AutoDiscoverEmail,
                        delegate(string url) { return true; });
                }
                else
                {
                    service.AutodiscoverUrl(row.AutoDiscoverEmail);
                }
            }
            else
            {
                service.Url = new Uri(row.ServicesURL);
            }

            // If ImpersonationType is specified then we assume an Id is as well
            if (!row.IsImpersonationTypeNull())
            {
                // Convert the string to a ConnectingIdType enumeration
                ConnectingIdType impType =
                    (ConnectingIdType)System.Enum.Parse(typeof(ConnectingIdType), row.ImpersonationType);
                service.ImpersonatedUserId = new ImpersonatedUserId(impType, row.ImpersonationId);
            }

            // If credentials are not required then use DefaultCredentials
            if (row.UsesDefaultCredentials)
            {
                service.UseDefaultCredentials = true;
                //service.Credentials =
                //    (NetworkCredential)System.Net.CredentialCache.DefaultCredentials;
            }
            else
            {
                if (cred != null)
                {
                    service.Credentials = (ExchangeCredentials)cred;
                }
                else
                {
                    throw new ApplicationException("Credentials are required for this binding.");
                }
            }

            return service;
        }

        /// <summary>
        /// Get root folder ids from the given row.
        /// </summary>
        private FolderId[] LoadRootFolderIdsFromProfileRow(ServicesProfile.ServiceBindingRow row)
        {
            List<FolderId> ids = new List<FolderId>();

            // If the field has no value, bail out
            if (row.IsRootFolderIdsNull() || row.RootFolderIds.Length == 0) return ids.ToArray();

            foreach (string idText in row.RootFolderIds.Split('|'))
            {
                string uniqueId = string.Empty;
                WellKnownFolderName? name = null;
                Mailbox mailbox = null;

                foreach (string piece in idText.Split(','))
                {
                    // Clean up the piece separator
                    piece.Replace(",", "");

                    // Strip out the data from the pieces
                    if (piece.StartsWith("Name:"))
                    {
                        name = (WellKnownFolderName?)System.Enum.Parse(typeof(WellKnownFolderName), piece.Replace("Name:",""));
                    }
                    else if (piece.StartsWith("Mbx:"))
                    {
                        mailbox = new Mailbox(piece.Replace("Mbx:", ""));
                    }
                    else if (piece.StartsWith("Id:"))
                    {
                        uniqueId = piece.Replace("Id:", "");
                    }
                }

                FolderId id;
                if (name.HasValue)
                {
                    if (mailbox != null)
                    {
                        id = new FolderId(name.Value, mailbox.Address);
                    }
                    else
                    {
                        id = new FolderId(name.Value);
                    }
                }
                else
                {
                    id = new FolderId(uniqueId);
                }
                ids.Add(id);
            }

            return ids.ToArray();
        }
    }
}
