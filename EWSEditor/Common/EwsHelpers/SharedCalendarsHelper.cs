using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Forms.Controls;
using EWSEditor.Logging;
using EWSEditor.Common;

namespace EWSEditor.Common
{
    public class SharedCalendarsHelper
    {
        /// Don't use - not sure what its tring to pull - its not pulling the shared calendars
        /// 

        //EWS - Access All Shared Calendars
       //http://stackoverflow.com/questions/23766747/ews-access-all-shared-calendars
        // http://stackoverflow.com/questions/23766747/ews-access-all-shared-calendars
        public static Dictionary<string, Folder> GetSharedCalendarFolders(ExchangeService service, String mbMailboxname)
        {
            Dictionary<String, Folder> rtList = new System.Collections.Generic.Dictionary<string, Folder>();

            FolderId rfRootFolderid = new FolderId(WellKnownFolderName.Root, mbMailboxname);
            FolderView fvFolderView = new FolderView(1000);
            SearchFilter sfSearchFilter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, "Common Views");
            service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            FindFoldersResults ffoldres = service.FindFolders(rfRootFolderid, sfSearchFilter, fvFolderView);
            if (ffoldres.Folders.Count == 1)
            {

                PropertySet psPropset = new PropertySet(BasePropertySet.FirstClassProperties);
                ExtendedPropertyDefinition PidTagWlinkAddressBookEID = new ExtendedPropertyDefinition(0x6854, MapiPropertyType.Binary);
                ExtendedPropertyDefinition PidTagWlinkFolderType = new ExtendedPropertyDefinition(0x684F, MapiPropertyType.Binary);
                ExtendedPropertyDefinition PidTagWlinkGroupName = new ExtendedPropertyDefinition(0x6851, MapiPropertyType.String);

                psPropset.Add(PidTagWlinkAddressBookEID);
                psPropset.Add(PidTagWlinkFolderType);
                ItemView iv = new ItemView(1000);
                iv.PropertySet = psPropset;
                iv.Traversal = ItemTraversal.Associated;

                SearchFilter cntSearch = new SearchFilter.IsEqualTo(PidTagWlinkGroupName, "Other Calendars");
                service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.             
                FindItemsResults<Item> fiResults = ffoldres.Folders[0].FindItems(cntSearch, iv);
                foreach (Item itItem in fiResults.Items)
                {
                    try
                    {
                        //object GroupName = null;
                        object WlinkAddressBookEID = null;
                        if (itItem.TryGetProperty(PidTagWlinkAddressBookEID, out WlinkAddressBookEID))
                        {

                            byte[] ssStoreID = (byte[])WlinkAddressBookEID;
                            int leLegDnStart = 0;
                            String lnLegDN = "";
                            for (int ssArraynum = (ssStoreID.Length - 2); ssArraynum != 0; ssArraynum--)
                            {
                                if (ssStoreID[ssArraynum] == 0)
                                {
                                    leLegDnStart = ssArraynum;
                                    lnLegDN = System.Text.ASCIIEncoding.ASCII.GetString(ssStoreID, leLegDnStart + 1, (ssStoreID.Length - (leLegDnStart + 2)));
                                    ssArraynum = 1;
                                }
                            }
                            NameResolutionCollection ncCol = service.ResolveName(lnLegDN, ResolveNameSearchLocation.DirectoryOnly, true);
                            if (ncCol.Count > 0)
                            {

                                FolderId SharedCalendarId = new FolderId(WellKnownFolderName.Calendar, ncCol[0].Mailbox.Address);
                                service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
                                Folder SharedCalendaFolder = Folder.Bind(service, SharedCalendarId);
                                rtList.Add(ncCol[0].Mailbox.Address, SharedCalendaFolder);


                            }

                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }

                }
            }
            return rtList;
        }

        public static string Test(ExchangeService service, String sMailboxname)
        {
            StringBuilder oSB = new StringBuilder();
            string sEmailAddress = string.Empty;
            string sFolder = string.Empty;
            string sFolderId = string.Empty;
            Folder oFolder = null;

            Dictionary<string, Folder> dResult = new Dictionary<string, Folder>();

            dResult = GetSharedCalendarFolders(service, sMailboxname);

            for (int index = 0; index < dResult.Count; index++)
            {

                 
                var item = dResult.ElementAt(index);
                sEmailAddress = item.Key;
                oFolder = (Folder)item.Value;
                sFolder = oFolder.DisplayName;
                sFolderId = oFolder.Id.UniqueId;

                oSB.AppendFormat("Email Address: %0   Folder: %1  UniqueId: %2\r\n", sEmailAddress, sFolder);
            }

            string sRet = oSB.ToString();

            return sRet;
        }
    }

}
