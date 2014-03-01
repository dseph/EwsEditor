using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Common;

namespace EWSEditor.Common
{
    public class ListViewItemHelper
    {

        public static bool LoadCalendarMaster(ExchangeService oExchangeService, ref ListView oListView, FolderTag oFolderTag, DateTime oSeedDateTime)
        {
            bool bRet = true;

            oListView.Clear();
            oListView.View = View.Details;
            oListView.GridLines = true;
            oListView.Dock = DockStyle.Fill;

            oListView.Columns.Add("Start", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("End", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("Subject", 250, HorizontalAlignment.Left);
            oListView.Columns.Add("AppointmentType", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("ItemClass", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("ICalUid", 50, HorizontalAlignment.Left);
            oListView.Columns.Add("UniqueId", 250, HorizontalAlignment.Left);
            oListView.Columns.Add("ChangeKey", 250, HorizontalAlignment.Left);
            SearchFilter.SearchFilterCollection searchFilter = new SearchFilter.SearchFilterCollection();
            searchFilter.Add(new SearchFilter.IsGreaterThanOrEqualTo(AppointmentSchema.Start, new DateTime(2000, 1, 1)));
            ItemView view = new ItemView(2000);
            view.PropertySet = new PropertySet(BasePropertySet.IdOnly,
                                                AppointmentSchema.Subject,
                                                AppointmentSchema.Start,
                                                AppointmentSchema.End,
                                                AppointmentSchema.AppointmentType,
                                                AppointmentSchema.IsRecurring,
                                                AppointmentSchema.ItemClass,
                                                AppointmentSchema.ICalUid

                                                );

            try
            {
                //FindItemsResults<Item> findResults = this._ExchangeService.FindItems(oFolderTag.Id, searchFilter, view);
                FindItemsResults<Item> findResults = oExchangeService.FindItems(oFolderTag.Id, view);
                ListViewItem oListItem = null;
                foreach (Item item in findResults.Items)
                {
                    Appointment appt = item as Appointment;
                    if (appt != null)
                    {
                        oListItem = new ListViewItem(appt.Start.ToString() + " - " + appt.End.ToShortTimeString(), 0);
                        oListItem.SubItems.Add(appt.End.ToString());
                        oListItem.SubItems.Add(appt.Subject);
                        oListItem.SubItems.Add(appt.AppointmentType.ToString());
                        oListItem.SubItems.Add(appt.ItemClass);
                        oListItem.SubItems.Add(appt.ICalUid);
                        oListItem.SubItems.Add(appt.Id.UniqueId);
                        oListItem.SubItems.Add(appt.Id.ChangeKey);
                        //oListItem.SubItems.Add(appt.IsRecurring.ToString());

                        oListItem.Tag = new ItemTag(appt.Id, appt.ItemClass);

                        //if (appt.AppointmentType == AppointmentType.RecurringMaster)
                        //{
                        //    oListItem.Tag = new CalendarItemTag(appt.Id, true);
                        //}
                        //else
                        //{
                        //    oListItem.Tag = new CalendarItemTag(appt.Id, false);
                        //}
                        oListView.Items.AddRange(new ListViewItem[] { oListItem });

                        oListItem = null;
                    }

                }
                oListItem = null;
                bRet = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                bRet = false;
            }

            return bRet;
        }

        public static bool LoadCalendarInstances(ExchangeService oExchangeService, FolderId oFolder,
                                ref ListView oListView,
                                DateTime oFromDateTime, DateTime oToDateTime)
        {
            bool bRet = false;

            // Configure ListView before adding data.

            oListView.Clear();
            oListView.View = View.Details;
            oListView.GridLines = true;


            oListView.Columns.Add("Subject", 200, HorizontalAlignment.Left);
            oListView.Columns.Add("Location", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("From", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("To", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("IsRecurring", 80, HorizontalAlignment.Left);
            oListView.Columns.Add("AppointmentType", 100, HorizontalAlignment.Left);

            oListView.Columns.Add("Id", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("UniqueId", 250, HorizontalAlignment.Left);
            oListView.Columns.Add("ChangeKey", 250, HorizontalAlignment.Left);




            try
            {

                // http://msdn.microsoft.com/en-us/library/dd633700(EXCHG.80).aspx 
                try
                {

                    //http://msdn.microsoft.com/en-us/library/dd633700(EXCHG.80).aspx

                    //SearchFilter.SearchFilterCollection searchFilter = new SearchFilter.SearchFilterCollection();
                    //searchFilter.Add(new SearchFilter.IsGreaterThanOrEqualTo(AppointmentSchema.Start, new DateTime(2009, 1, 1)));

                    CalendarView oCalendarView = new CalendarView(oFromDateTime, oToDateTime);

                    oCalendarView.PropertySet = new PropertySet(BasePropertySet.IdOnly,
                        AppointmentSchema.Subject,
                        AppointmentSchema.Location,
                        AppointmentSchema.Start,
                        AppointmentSchema.End,
                        AppointmentSchema.IsRecurring,
                        AppointmentSchema.AppointmentType,
                        AppointmentSchema.ItemClass
                        );

                    //oView.OrderBy.Add(AppointmentSchema.Start, SortDirection.Descending);
                    FindItemsResults<Appointment> findResults = oExchangeService.FindAppointments(oFolder, oCalendarView);


                    ListViewItem oListItem = null;

                    foreach (Appointment oApointment in findResults)
                    {

                        oListItem = new ListViewItem(oApointment.Subject, 0);
                        oListItem.SubItems.Add(oApointment.Location);
                        oListItem.SubItems.Add(oApointment.Start.ToString());
                        oListItem.SubItems.Add(oApointment.End.ToString());
                        oListItem.SubItems.Add(oApointment.IsRecurring.ToString());
                        oListItem.SubItems.Add(oApointment.AppointmentType.ToString());
                        oListItem.SubItems.Add(oApointment.Id.UniqueId);
                        oListItem.SubItems.Add(oApointment.Id.ChangeKey);
                        oListItem.Tag = new  ItemTag(oApointment.Id, oApointment.ItemClass);
                        oListView.Items.AddRange(new ListViewItem[] { oListItem });

                        oListItem = null;
                    }
                    bRet = true;
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Error while doing FindItems: " + ex1.ToString());
                    bRet = false;
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show("Error while binding to folder prior to calling FindItems: " + ex2.ToString());
                bRet = false;
            }

            return bRet;

        }


        public static bool LoadItems(ExchangeService oExchangeService, ref ListView oListView, FolderTag oFolderTag)
        {
            bool bRet = false;

            // Configure ListView before adding data.
            //oListView.Dock = DockStyle.None;
            oListView.Clear();
            oListView.View = View.Details;
            oListView.GridLines = true;
            oListView.Dock = DockStyle.Fill;

            oListView.Columns.Add("Subject", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("Class", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("DisplayTo", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("Attatch", 50, HorizontalAlignment.Left);
            oListView.Columns.Add("Id", 50, HorizontalAlignment.Left);
            oListView.Columns.Add("UniqueId", 250, HorizontalAlignment.Left);
            oListView.Columns.Add("ChangeKey", 250, HorizontalAlignment.Left);

            FolderId oFolder;
            oFolder = oFolderTag.Id;

            ItemView oView = new ItemView(9999);
            try
            {
                Folder folder = Folder.Bind(oExchangeService, oFolder);  
                //Folder folder = GetFolderBinding(oFolder);
                try
                {
                    FindItemsResults<Item> oResults = folder.FindItems(oView);


                    ListViewItem oListItem = null;

                    foreach (Item o in oResults)
                    {

                        oListItem = new ListViewItem(o.Subject, 0);
                        oListItem.SubItems.Add(o.ItemClass);
                        oListItem.SubItems.Add(o.DisplayTo);
                        oListItem.SubItems.Add(o.HasAttachments.ToString());
                        oListItem.SubItems.Add(o.Id.UniqueId);
                        oListItem.SubItems.Add(o.Id.ChangeKey);
                        oListItem.Tag = new ItemTag(o.Id, o.ItemClass);
                        oListView.Items.AddRange(new ListViewItem[] { oListItem });
                        //oListView.Items.AddRange(new ListViewItem() { oListItem });
                        oListItem = null;
                    }
                    bRet = true;
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Error while doing FindItems: " + ex1.ToString());
                    bRet = false;
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show("Error while binding to folder prior to calling FindItems: " + ex2.ToString());
                bRet = false;
            }
            return bRet;
        }


        public static bool LoadLvMessages(ExchangeService oExchangeService, ref ListView oListView, FolderTag oFolderTag)
        {
            bool bRet = true;
            // Configure ListView before adding data.
            //oListView.Dock = DockStyle.None;
            oListView.Clear();
            oListView.View = View.Details;
            oListView.GridLines = true;
            oListView.Dock = DockStyle.Fill;

            oListView.Columns.Add("Subject", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("Class", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("DisplayTo", 100, HorizontalAlignment.Left);
            oListView.Columns.Add("Attatch", 50, HorizontalAlignment.Left);

            FolderId oFolder;
            oFolder = oFolderTag.Id;

            ItemView oView = new ItemView(9999);
            Folder folder = Folder.Bind(oExchangeService, oFolder);
            FindItemsResults<Microsoft.Exchange.WebServices.Data.Item> oResults = folder.FindItems(oView);

            ListViewItem oListItem = null;

            foreach (Item o in oResults)
            {

                oListItem = new ListViewItem(o.Subject, 0);
                oListItem.SubItems.Add(o.ItemClass);
                oListItem.SubItems.Add(o.DisplayTo);
                oListItem.SubItems.Add(o.HasAttachments.ToString());
                oListItem.Tag = new ItemTag(o.Id, o.ItemClass);
                oListView.Items.AddRange(new ListViewItem[] { oListItem });
                //oListView.Items.AddRange(new ListViewItem() { oListItem });
                oListItem = null;
            }

            return bRet;
        }

        public static bool LoadLvContacts(ExchangeService oExchangeService, ref ListView oListView, FolderTag oFolderTag)
        {
            bool bRet = true;
            // Configure ListView before adding data.
            //oListView.Dock = DockStyle.None;
            oListView.Clear();
            oListView.View = View.Details;
            oListView.GridLines = true;
            oListView.Dock = DockStyle.Fill;

            oListView.Columns.Add("Type", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("DisplayName", 150, HorizontalAlignment.Left);
            oListView.Columns.Add("Department", 50, HorizontalAlignment.Left);
            oListView.Columns.Add("Manager", 50, HorizontalAlignment.Left);


            oListView.Columns.Add("Business Street", 50, HorizontalAlignment.Left);
            oListView.Columns.Add("Business City", 50, HorizontalAlignment.Left);
            oListView.Columns.Add("Business State", 50, HorizontalAlignment.Left);
            oListView.Columns.Add("Business Zip", 50, HorizontalAlignment.Left);
            oListView.Columns.Add("Business CountryOrRegion", 50, HorizontalAlignment.Left);
            oListView.Columns.Add("Business Phone", 50, HorizontalAlignment.Left);

            oListView.Columns.Add("Home Street", 50, HorizontalAlignment.Left);
            oListView.Columns.Add("Home City", 50, HorizontalAlignment.Left);
            oListView.Columns.Add("Home State", 50, HorizontalAlignment.Left);
            oListView.Columns.Add("Home Zip", 50, HorizontalAlignment.Left);
            oListView.Columns.Add("Home CountryOrRegion", 50, HorizontalAlignment.Left);
            oListView.Columns.Add("Home Phone", 50, HorizontalAlignment.Left);

            FolderId oFolder;
            oFolder = oFolderTag.Id;

            PropertySet oPropSet = new PropertySet(PropertySet.FirstClassProperties);
            oPropSet.Add(ContactSchema.ItemClass);
            oPropSet.Add(ContactSchema.DisplayName);
            oPropSet.Add(ContactSchema.Department);
            oPropSet.Add(ContactSchema.Manager);

            oPropSet.Add(ContactSchema.BusinessAddressStreet);
            oPropSet.Add(ContactSchema.BusinessAddressCity);
            oPropSet.Add(ContactSchema.BusinessAddressState);
            oPropSet.Add(ContactSchema.BusinessAddressPostalCode);
            oPropSet.Add(ContactSchema.BusinessPhone);

            oPropSet.Add(ContactSchema.HomeAddressStreet);
            oPropSet.Add(ContactSchema.HomeAddressCity);
            oPropSet.Add(ContactSchema.HomeAddressState);
            oPropSet.Add(ContactSchema.HomeAddressPostalCode);
            oPropSet.Add(ContactSchema.HomePhone);


            ItemView oView = new ItemView(9999);
            Folder folder = Folder.Bind(oExchangeService, oFolder, oPropSet);


            FindItemsResults<Microsoft.Exchange.WebServices.Data.Item> oResults = folder.FindItems(oView);

            ListViewItem oListItem = null;

            //Contact contact = Contact.Bind(service, new ItemId("AAMkA="));
            string sAddress = string.Empty;
            PhysicalAddressEntry oAddress = null;
            string sPhone = string.Empty;

            foreach (Item o in oResults)
            {
                Contact oContact = o as Contact;
                ContactGroup oContactGroup = o as ContactGroup;


                if (oContact != null)
                {
                    oListItem = new ListViewItem("Contact", 0);
                    oListItem.SubItems.Add(oContact.DisplayName);
                    oListItem.SubItems.Add(oContact.Department);
                    oListItem.SubItems.Add(oContact.Manager);

                    if (oContact.PhysicalAddresses.TryGetValue(PhysicalAddressKey.Business, out oAddress))
                    {

                        oListItem.SubItems.Add(oAddress.Street);
                        oListItem.SubItems.Add(oAddress.City);
                        oListItem.SubItems.Add(oAddress.State);
                        oListItem.SubItems.Add(oAddress.PostalCode);
                        oListItem.SubItems.Add(oAddress.CountryOrRegion);
                        //sAddress = oAddress.Street;
                    }
                    else
                    {
                        oListItem.SubItems.Add("");
                        oListItem.SubItems.Add("");
                        oListItem.SubItems.Add("");
                        oListItem.SubItems.Add("");
                        oListItem.SubItems.Add("");
                    }

                    sPhone = string.Empty;
                    if (oContact.PhoneNumbers.TryGetValue(PhoneNumberKey.BusinessPhone, out sPhone))
                        oListItem.SubItems.Add(sPhone);
                    else
                        oListItem.SubItems.Add("");

                    if (oContact.PhysicalAddresses.TryGetValue(PhysicalAddressKey.Home, out oAddress))
                    {

                        oListItem.SubItems.Add(oAddress.Street);
                        oListItem.SubItems.Add(oAddress.State);
                        oListItem.SubItems.Add(oAddress.City);
                        oListItem.SubItems.Add(oAddress.PostalCode);
                        oListItem.SubItems.Add(oAddress.CountryOrRegion);
                        sAddress = oAddress.Street;
                    }
                    else
                    {
                        oListItem.SubItems.Add("");
                        oListItem.SubItems.Add("");
                        oListItem.SubItems.Add("");
                        oListItem.SubItems.Add("");
                        oListItem.SubItems.Add("");
                    }

                    sPhone = string.Empty;
                    if (oContact.PhoneNumbers.TryGetValue(PhoneNumberKey.HomePhone, out sPhone))
                        oListItem.SubItems.Add(sPhone);
                    else
                        oListItem.SubItems.Add("");

                    oListItem.Tag = new ItemTag(o.Id, o.ItemClass);
                    oListView.Items.AddRange(new ListViewItem[] { oListItem });

                    oContact = null;
                    oContactGroup = null;
                    oListItem = null;
                    oAddress = null;
                }
               



            }

            return bRet;
        }




    }
}
