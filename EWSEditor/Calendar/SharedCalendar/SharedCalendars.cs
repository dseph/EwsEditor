using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EWSEditor.Calendar.SharedCalendar
{
    public  class SharedCalendars
    {
        // GetSharedCalendarFolders(ExchangeService service, String mbMailboxname) is from https://stackoverflow.com/questions/23766747/ews-access-all-shared-calendars
        //If so these Items are NavLinks that are stored in the Common Views folder in a Mailbox which is under the
        // NonIPMSubtree(root) see http://msdn.microsoft.com/en-us/library/ee157359(v=exchg.80).aspx. You can use
        // EWS to get the NavLinks from a Mailbox and use the PidTagWlinkAddressBookEID extended property to get
        // the X500 address of the Mailbox these Links refer to and then use Resolve Name to resolve that to a
        // SMTP Address. Then all you need to do is Bind to that folder eg

        // Also see: https://learn.microsoft.com/en-us/openspecs/exchange_server_protocols/ms-oxocfg/086016cd-efcf-420c-a9ef-1beef982dc3e?redirectedfrom=MSDN

        public  Dictionary<string, Folder> GetSharedCalendarFolders(ExchangeService service, String mbMailboxname, String LinkGroupName)
        {
            Dictionary<String, Folder> rtList = new System.Collections.Generic.Dictionary<string, Folder>();

            FolderId rfRootFolderid = new FolderId(WellKnownFolderName.Root, mbMailboxname);
            FolderView fvFolderView = new FolderView(1000);

            //SearchFilter sfSearchFilterx = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, "My Calendars");
            //FindFoldersResults ffoldresx = service.FindFolders(rfRootFolderid, sfSearchFilterx, fvFolderView);

            SearchFilter sfSearchFilter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, "Common Views");
            FindFoldersResults ffoldres = service.FindFolders(rfRootFolderid, sfSearchFilter, fvFolderView);


            if (ffoldres.Folders.Count == 1)
            {

                PropertySet psPropset = new PropertySet(BasePropertySet.FirstClassProperties);
                ExtendedPropertyDefinition PidTagWlinkAddressBookEID = new ExtendedPropertyDefinition(0x6854, MapiPropertyType.Binary);
                ExtendedPropertyDefinition PidTagWlinkGroupName = new ExtendedPropertyDefinition(0x6851, MapiPropertyType.String);

                psPropset.Add(PidTagWlinkAddressBookEID);
                ItemView iv = new ItemView(1000);
                iv.PropertySet = psPropset;
                iv.Traversal = ItemTraversal.Associated;

                //SearchFilter cntSearchx = new SearchFilter.IsEqualTo(PidTagWlinkGroupName, "My Calendars");
                //FindItemsResults<Item> fiResultsx = ffoldres.Folders[0].FindItems(cntSearchx, iv);

                SearchFilter cntSearch = new SearchFilter.IsEqualTo(PidTagWlinkGroupName, LinkGroupName);
                 // Can also find this using PidTagWlinkType = wblSharedFolder
                FindItemsResults<Item> fiResults = ffoldres.Folders[0].FindItems(cntSearch, iv);
                foreach (Item itItem in fiResults.Items)
                {
                    try
                    {
                        object GroupName = null;
                        object WlinkAddressBookEID = null;

                        // This property will only be there in Outlook 2010 and beyond
                        //https://msdn.microsoft.com/en-us/library/ee220131(v=exchg.80).aspx#Appendix_A_30
                        if (itItem.TryGetProperty(PidTagWlinkAddressBookEID, out WlinkAddressBookEID))
                        {

                            byte[] ssStoreID = (byte[])WlinkAddressBookEID;
                            int leLegDnStart = 0;
                            // Can also extract the DN by getting the 28th(or 30th?) byte to the second to last byte 
                            //https://msdn.microsoft.com/en-us/library/ee237564(v=exchg.80).aspx
                            //https://msdn.microsoft.com/en-us/library/hh354838(v=exchg.80).aspx
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
                            NameResolutionCollection ncCol = service.ResolveName(lnLegDN, ResolveNameSearchLocation.DirectoryOnly, false);
                            if (ncCol.Count > 0)
                            {

                                FolderId SharedCalendarId = new FolderId(WellKnownFolderName.Calendar, ncCol[0].Mailbox.Address);
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
    }
}
