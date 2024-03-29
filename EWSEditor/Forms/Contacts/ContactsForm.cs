﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Common;
using EWSEditor.Exchange;
using EWSEditor.Logging;
using EWSEditor.Resources;
using EWSEditor.Settings;
 


namespace EWSEditor.Forms
{
    public partial class ContactsForm : Form
    {
        private bool _IsExistingContact = false;
        private ExchangeService _CurrentService = null;
        private Contact _Contact = null;
        private bool _ContactWasSaved = false;
        //private ItemId _ItemId = null;
        private FolderId _FolderId = null;
        private bool _isDirty = false;

        public ContactsForm()
        {
            InitializeComponent();
        }

        // New Contact.
        public ContactsForm(ExchangeService CurrentService, FolderId oFolderId)
        {
            InitializeComponent();
            _CurrentService = CurrentService;
            _Contact = new Contact(CurrentService);
            _IsExistingContact = false;
            _FolderId = oFolderId;
            ClearForm();
            if (_ContactWasSaved == false)
                _ContactWasSaved = false;

            _isDirty = false;

            if (_isDirty == true)
            {
                // Do nothing
            }
        }

        // Existing Contact.
        public ContactsForm(ExchangeService CurrentService, ItemId oItemId)
        {
            InitializeComponent();
            _CurrentService = CurrentService;
             
            _Contact = LoadContactForEdit(CurrentService, oItemId);
            _IsExistingContact = true;
            SetFormFromContact(_Contact);
            if (_ContactWasSaved == false)
                _ContactWasSaved = false;

            _isDirty = false;
        }


        public ContactsForm(ExchangeService CurrentService, ref Contact oContact)
        {
            InitializeComponent();
            _CurrentService = CurrentService;
            _Contact = oContact;        // TODO: Load a new record with form specific data or get more data for existing record.
            _IsExistingContact = true;
            SetFormFromContact(oContact);
            if (_ContactWasSaved == false)
                _ContactWasSaved = false;

            _isDirty = false;
        }

        private Contact LoadContactForEdit(ExchangeService CurrentService, ItemId oItemId)
        {
 
           
            ItemView oView = new ItemView(9999);
            //PropertySet oPropertySet = new PropertySet(EmailMessageSchema.ExtendedProperties);
            PropertySet oPropertySet = new PropertySet(
                BasePropertySet.IdOnly,
                ContactSchema.GivenName,
                ContactSchema.MiddleName,
                ContactSchema.Surname,
                ContactSchema.CompanyName,
                ContactSchema.JobTitle,
                ContactSchema.Body,
                ContactSchema.PhysicalAddresses,
                ContactSchema.PhoneNumbers,
                ContactSchema.HasPicture,
                ContactSchema.HasAttachments,
                ContactSchema.IsAssociated,
                ContactSchema.Isdn,
                ContactSchema.IsDraft,
                ContactSchema.IsFromMe,
                //ContactSchema.IsReminderSet,   duplicate
                ContactSchema.IsReminderSet,
                ContactSchema.IsResend,
                ContactSchema.IsSubmitted,
                ContactSchema.IsUnmodified,
                ContactSchema.ItemClass,
                ContactSchema.JobTitle,
                ContactSchema.LastModifiedName,
                ContactSchema.LastModifiedTime,
                ContactSchema.Manager,
                ContactSchema.MiddleName, 
                ContactSchema.PhoneNumbers,
                ContactSchema.Profession,
                ContactSchema.SpouseName,
                ContactSchema.Subject,
                ContactSchema.Sensitivity,
                ContactSchema.Surname,
                ContactSchema.UniqueBody,
                ContactSchema.WeddingAnniversary,
                ContactSchema.DateTimeCreated,
                ContactSchema.DateTimeReceived,
                ContactSchema.DateTimeSent,
                ContactSchema.LastModifiedTime,
                ContactSchema.LastModifiedName,
                ContactSchema.AssistantName,
                ContactSchema.AssistantPhone,
                ContactSchema.Categories,
                ContactSchema.Attachments,
                ContactSchema.PostalAddressIndex 
                 
  
                );

            //// https://msdn.microsoft.com/en-us/library/microsoft.exchange.webservices.data.contact.postaladdressindex(v=exchg.80).aspx
            //// ContactSchema.PostalAddressIndexSpecified 
            //mExtendedPropertyPostalAddressId = new ExtendedPropertyDefinition(myGuidPostalAddressId, myPropertyIdPostalAddressId, MapiPropertyType.Integer);
            
            //oPropertySet.Add();
            CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            Contact oContact = Contact.Bind(CurrentService, oItemId, oPropertySet);
             
 
            return oContact;
        }

        private void ContactsForm_Load(object sender, EventArgs e)
        {
            this.cmboPostalAddressIndex.Items.Add("Not Set");
            this.cmboPostalAddressIndex.Items.Add("None");
            this.cmboPostalAddressIndex.Items.Add("Other");
            this.cmboPostalAddressIndex.Items.Add("Home");
            this.cmboPostalAddressIndex.Items.Add("Business"); 
        }


        private bool SetContactFromForm(ref Contact oContact)
        {
            bool bRet = false;

            oContact.GivenName = txtGivenName.Text;
            oContact.MiddleName = txtMiddleName.Text ;
            oContact.Surname = txtSurname.Text ;
            oContact.CompanyName =  txtCompanyName.Text;
            oContact.JobTitle = txtJobTitle.Text;
            //oContact.Notes = txtNotes.Text;  /// Its read only???
            PhysicalAddressEntry oPhysicalAddress = null;

            //PhysicalAddressEntry oBusinessAddress = null;
            if (
                (txtBA_Street.Text.Trim().Length != 0) ||
                (txtBA_City.Text.Trim().Length != 0) ||
                (txtBA_State.Text.Trim().Length != 0) ||
                (txtBA_CountryOrRegion.Text.Trim().Length != 0) ||
                (txtBA_PostalCode.Text.Trim().Length != 0)
                )
            {

               // if (oContact.PhysicalAddresses.TryGetValue(PhysicalAddressKey.Business, out oPhysicalAddress))
       
                //txtBA_Street.Text = oPhysicalAddress.Street;
                oPhysicalAddress = null;
                if (oContact.PhysicalAddresses.TryGetValue(PhysicalAddressKey.Business, out oPhysicalAddress) == false)
                    oContact.PhysicalAddresses[PhysicalAddressKey.Business] = new PhysicalAddressEntry();
                oPhysicalAddress = null;

                //if (oContact.PhysicalAddresses[PhysicalAddressKey.Business] == null)
                //    oContact.PhysicalAddresses[PhysicalAddressKey.Business] = new PhysicalAddressEntry();
                

                oContact.PhysicalAddresses[PhysicalAddressKey.Business].Street = txtBA_Street.Text;
                oContact.PhysicalAddresses[PhysicalAddressKey.Business].City = txtBA_City.Text;
                oContact.PhysicalAddresses[PhysicalAddressKey.Business].State = txtBA_State.Text;
                oContact.PhysicalAddresses[PhysicalAddressKey.Business].CountryOrRegion = txtBA_CountryOrRegion.Text;
                oContact.PhysicalAddresses[PhysicalAddressKey.Business].PostalCode = txtBA_PostalCode.Text;

 
            }

            //PhysicalAddressEntry oHomeAddress = null;
            if (
                (txtHA_Street.Text.Trim().Length != 0) ||
                (txtHA_City.Text.Trim().Length != 0) ||
                (txtHA_State.Text.Trim().Length != 0) ||
                (txtHA_CountryOrRegion.Text.Trim().Length != 0) ||
                (txtHA_PostalCode.Text.Trim().Length != 0)
                )
            {

                oPhysicalAddress = null;
                if (oContact.PhysicalAddresses.TryGetValue(PhysicalAddressKey.Home, out oPhysicalAddress) == false)
                    oContact.PhysicalAddresses[PhysicalAddressKey.Home] = new PhysicalAddressEntry();
                oPhysicalAddress = null;

                //if (oContact.PhysicalAddresses[PhysicalAddressKey.Home] == null)
               //     oContact.PhysicalAddresses[PhysicalAddressKey.Home] = new PhysicalAddressEntry();
 
                oContact.PhysicalAddresses[PhysicalAddressKey.Home].Street = txtHA_Street.Text;
                oContact.PhysicalAddresses[PhysicalAddressKey.Home].City = txtHA_City.Text;
                oContact.PhysicalAddresses[PhysicalAddressKey.Home].State = txtHA_State.Text;
                oContact.PhysicalAddresses[PhysicalAddressKey.Home].CountryOrRegion = txtHA_CountryOrRegion.Text;
                oContact.PhysicalAddresses[PhysicalAddressKey.Home].PostalCode = txtHA_PostalCode.Text;
           
 
                
            }

            //PhysicalAddressEntry oOtherAddress = null;
            if (
                (txtOA_Street.Text.Trim().Length != 0) ||
                (txtOA_City.Text.Trim().Length != 0) ||
                (txtOA_State.Text.Trim().Length != 0) ||
                (txtOA_CountryOrRegion.Text.Trim().Length != 0) ||
                (txtOA_PostalCode.Text.Trim().Length != 0)
                )
            {

                oPhysicalAddress = null;
                if (oContact.PhysicalAddresses.TryGetValue(PhysicalAddressKey.Other, out oPhysicalAddress) == false)
                    oContact.PhysicalAddresses[PhysicalAddressKey.Other] = new PhysicalAddressEntry();
                oPhysicalAddress = null;

                //if (oContact.PhysicalAddresses[PhysicalAddressKey.Other] == null)
                //    oContact.PhysicalAddresses[PhysicalAddressKey.Other] = new PhysicalAddressEntry();

                oContact.PhysicalAddresses[PhysicalAddressKey.Other].Street = txtOA_Street.Text;
                oContact.PhysicalAddresses[PhysicalAddressKey.Other].City = txtOA_City.Text;
                oContact.PhysicalAddresses[PhysicalAddressKey.Other].State = txtOA_State.Text;
                oContact.PhysicalAddresses[PhysicalAddressKey.Other].CountryOrRegion = txtOA_CountryOrRegion.Text;
                oContact.PhysicalAddresses[PhysicalAddressKey.Other].PostalCode = txtOA_PostalCode.Text;


                //oOtherAddress = new PhysicalAddressEntry();
                //oOtherAddress.Street = txtOA_Street.Text;
                //oOtherAddress.City = txtOA_City.Text;
                //oOtherAddress.State = txtOA_State.Text;
                //oOtherAddress.CountryOrRegion = txtOA_CountryOrRegion.Text;
                //oOtherAddress.PostalCode = txtOA_PostalCode.Text;
                //oContact.PhysicalAddresses[PhysicalAddressKey.Other]. = oOtherAddress;
                
            }

            switch (cmboPostalAddressIndex.Text)
            {
                case "None":
                    oContact.PostalAddressIndex = (PhysicalAddressIndex)PhysicalAddressIndex.None;
                    break;
                case "Other":
                    oContact.PostalAddressIndex = (PhysicalAddressIndex)PhysicalAddressIndex.Other;
                    break;
                case "Home":
                    oContact.PostalAddressIndex = (PhysicalAddressIndex)PhysicalAddressIndex.Home;
                    break;
                case "Business":
                    oContact.PostalAddressIndex = (PhysicalAddressIndex)PhysicalAddressIndex.Business;
                    break;
            }
             
 
            bRet = true;
 

            return bRet;

        }
        private void ClearForm()
        {

            txtMiddleName.Text = string.Empty;
            txtSurname.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtJobTitle.Text = string.Empty;
            txtJobTitle.Text = string.Empty;
            txtNotes.Text = string.Empty;
             

            txtBA_Street.Text = string.Empty;
            txtBA_City.Text = string.Empty;
            txtBA_State.Text = string.Empty;
            txtBA_PostalCode.Text = string.Empty;
            txtBA_CountryOrRegion.Text = string.Empty;

            txtHA_Street.Text = string.Empty;
            txtHA_City.Text = string.Empty;
            txtHA_State.Text = string.Empty;
            txtHA_PostalCode.Text = string.Empty;
            txtHA_CountryOrRegion.Text = string.Empty;

            txtOA_Street.Text = string.Empty;
            txtOA_City.Text = string.Empty;
            txtOA_State.Text = string.Empty;
            txtOA_PostalCode.Text = string.Empty;
            txtOA_CountryOrRegion.Text = string.Empty;

            pbContactPhoto.Image = null;

            this.cmboPostalAddressIndex.Text = "None";
            
        }

        private bool SetFormFromContact(Contact oContact)
        {
            bool bRet = false;
            ClearForm();
             
            txtGivenName.Text = oContact.GivenName;
            txtMiddleName.Text = oContact.MiddleName;
            txtSurname.Text = oContact.Surname;
            txtCompanyName.Text = oContact.CompanyName;
            txtJobTitle.Text = oContact.JobTitle;
            txtNotes.Text = oContact.Body.Text;
            //if (oContact.HasPicture)
            //{
            //    FileAttachment oFileAttachment = null;
            //    System.IO.Stream oStream = null;
            //    oFileAttachment = oContact.GetContactPictureAttachment();
            //    oFileAttachment.Load(oStream );
            //   // pbContactPhoto.Image = Image.FromStream(oStream);

            //    // For saving image: 
            //    // http://social.technet.microsoft.com/Forums/en-US/exchangesvrdevelopment/thread/6be416f7-c8f0-425c-879c-7954c572afc8#662c7497-3898-42dc-8bd4-3dd168724a3f
            //    //// Stream attachment contents into a file.
            //    //FileStream theStream = new FileStream("C:\\temp\\Stream_" + fileAttachment.Name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //    //fileAttachment.Load(theStream);
            //    //theStream.Close();
            //    //theStream.Dispose();
            //    // http://support.microsoft.com/kb/317701

            //}

 
            FileAttachment oFileAttachment = null;

            // Note that you need to have ContactSchema.Attachments loaded you will get a general error...
            oFileAttachment = _Contact.GetContactPictureAttachment();
            if (oFileAttachment != null)
            {
                System.IO.MemoryStream oMemoryStream = new System.IO.MemoryStream();
                oFileAttachment.Load(oMemoryStream);
                pbContactPhoto.Image = Image.FromStream(oMemoryStream);
            }
     
            string sInfo = string.Empty;
            foreach(Attachment oAttachment in oContact.Attachments)
            {
               oFileAttachment = oAttachment as FileAttachment;

               sInfo += "Name: " + oAttachment.Name; 
               sInfo += "\r\nIsInline: " + oAttachment.IsInline.ToString();
               if (oFileAttachment.IsContactPhoto)
               {
                   sInfo += "\r\nIsContactPhoto: True";
               }
               else
               {
                   sInfo += "\r\nIsContactPhoto: False";
               }
               sInfo += "\r\nSize: " + oAttachment.Size.ToString();
               sInfo += "\r\nId: " + oAttachment.Id;
               sInfo += "\r\nContentId: " + oAttachment.ContentId;
               sInfo += "\r\nContentLocation: " + oAttachment.ContentLocation;
               sInfo += "\r\nContentType: " + oAttachment.ContentType;
               sInfo += "\r\nLastModifiedTime: " + oAttachment.LastModifiedTime.ToString();
               sInfo += "\r\nContentId: " + oAttachment.ContentId;
               sInfo += "\r\nContentType: " + oAttachment.ContentType;

               sInfo += "\r\n--------------------\r\n";
   
                // This is another way to get at the Contact Photo
                if (oFileAttachment.IsContactPhoto)
                {
                    // Note that you need to have ContactSchema.Attachments loaded or you will get nothing back.
                    //System.IO.MemoryStream oMemoryStreamx = new System.IO.MemoryStream();
                    //oFileAttachment.Load(oMemoryStream);
                    //pbContactPhoto.Image = Image.FromStream(oMemoryStreamx);
                    //oMemoryStream = null;
                }

                oFileAttachment = null;
                this.txtAttachments.Text = sInfo;

                _isDirty = false;
            }

            PhysicalAddressEntry oPhysicalAddress = null;

            if (oContact.PhysicalAddresses.TryGetValue(PhysicalAddressKey.Business, out oPhysicalAddress))
            {

                txtBA_Street.Text = oPhysicalAddress.Street;
                txtBA_City.Text = oPhysicalAddress.City;
                txtBA_State.Text = oPhysicalAddress.State;
                txtBA_PostalCode.Text = oPhysicalAddress.PostalCode;
                txtBA_CountryOrRegion.Text = oPhysicalAddress.CountryOrRegion;
            }

            if (oContact.PhysicalAddresses.TryGetValue(PhysicalAddressKey.Home, out oPhysicalAddress))
            {
                txtHA_Street.Text = oPhysicalAddress.Street;
                txtHA_City.Text = oPhysicalAddress.City;
                txtHA_State.Text = oPhysicalAddress.State;
                txtHA_PostalCode.Text = oPhysicalAddress.PostalCode;
                txtHA_CountryOrRegion.Text = oPhysicalAddress.CountryOrRegion;
            }

            if (oContact.PhysicalAddresses.TryGetValue(PhysicalAddressKey.Other, out oPhysicalAddress))
            {
                txtOA_Street.Text = oPhysicalAddress.Street;
                txtOA_City.Text = oPhysicalAddress.City;
                txtOA_State.Text = oPhysicalAddress.State;
                txtOA_PostalCode.Text = oPhysicalAddress.PostalCode;
                txtOA_CountryOrRegion.Text = oPhysicalAddress.CountryOrRegion;
            }

            bool bSet = false;  //Makes setting values for copied lines of code easier.
            txtEmailAddress1_Address.Enabled = bSet;
            txtEmailAddress1_Name.Enabled = bSet;
            txtEmailAddress1_MailboxType.Enabled = bSet;
            txtEmailAddress1_RoutingType.Enabled = bSet;
            txtEmailAddress1_MailboxType.Enabled = bSet;
            txtEmailAddress1_Id_UniqueId.Enabled = bSet;
            txtEmailAddress1_Id_ChangeKey.Enabled = bSet;

            txtEmailAddress2_Address.Enabled = bSet;
            txtEmailAddress2_Name.Enabled = bSet;
            txtEmailAddress2_MailboxType.Enabled = bSet;
            txtEmailAddress2_RoutingType.Enabled = bSet;
            txtEmailAddress2_MailboxType.Enabled = bSet;
            txtEmailAddress2_Id_UniqueId.Enabled = bSet;
            txtEmailAddress2_Id_ChangeKey.Enabled = bSet;

            txtEmailAddress3_Address.Enabled = bSet;
            txtEmailAddress3_Name.Enabled = bSet;
            txtEmailAddress3_MailboxType.Enabled = bSet;
            txtEmailAddress3_RoutingType.Enabled = bSet;
            txtEmailAddress3_MailboxType.Enabled = bSet;
            txtEmailAddress3_Id_UniqueId.Enabled = bSet;
            txtEmailAddress3_Id_ChangeKey.Enabled = bSet;

            EmailAddress oEmailAddress = null;
            if (oContact.EmailAddresses.TryGetValue(EmailAddressKey.EmailAddress1, out oEmailAddress))
            {
                txtEmailAddress1_Address.Text = oEmailAddress.Address;
                txtEmailAddress1_Name.Text = oEmailAddress.Name;
                txtEmailAddress1_MailboxType.Text = oEmailAddress.MailboxType.ToString();
                txtEmailAddress1_RoutingType.Text = oEmailAddress.RoutingType;
                txtEmailAddress1_MailboxType.Text = oEmailAddress.MailboxType.Value.ToString();
                if (oEmailAddress.Id != null)
                {
                    txtEmailAddress1_Id_UniqueId.Text = oEmailAddress.Id.UniqueId;
                    txtEmailAddress1_Id_ChangeKey.Text = oEmailAddress.Id.ChangeKey;
                }
                else
                {
                    txtEmailAddress1_Id_UniqueId.Text = "";
                    txtEmailAddress1_Id_ChangeKey.Text = "";
                }

                bSet = false;  // Make read-only until the code can be enhanced.
                txtEmailAddress1_Address.Enabled = bSet;
                txtEmailAddress1_Name.Enabled = bSet;
                txtEmailAddress1_MailboxType.Enabled = bSet;
                txtEmailAddress1_RoutingType.Enabled = bSet;
                txtEmailAddress1_MailboxType.Enabled = bSet;
                txtEmailAddress1_Id_UniqueId.Enabled = false;
                txtEmailAddress1_Id_ChangeKey.Enabled = false;
            }
            if (oContact.EmailAddresses.TryGetValue(EmailAddressKey.EmailAddress2, out oEmailAddress))
            {
                txtEmailAddress2_Address.Text = oEmailAddress.Address;
                txtEmailAddress2_Name.Text = oEmailAddress.Name;
                txtEmailAddress2_MailboxType.Text = oEmailAddress.MailboxType.ToString();
                txtEmailAddress2_RoutingType.Text = oEmailAddress.RoutingType;
                txtEmailAddress2_MailboxType.Text = oEmailAddress.MailboxType.Value.ToString();
                if (oEmailAddress.Id != null)
                {
                    txtEmailAddress2_Id_UniqueId.Text = oEmailAddress.Id.UniqueId;
                    txtEmailAddress2_Id_ChangeKey.Text = oEmailAddress.Id.ChangeKey;
                }
                else
                {
                    txtEmailAddress2_Id_UniqueId.Text = "";
                    txtEmailAddress2_Id_ChangeKey.Text = "";
                }

                bSet = false;  // Make read-only until the code can be enhanced.
                txtEmailAddress2_Address.Enabled = bSet;
                txtEmailAddress2_Name.Enabled = bSet;
                txtEmailAddress2_MailboxType.Enabled = bSet;
                txtEmailAddress2_RoutingType.Enabled = bSet;
                txtEmailAddress2_MailboxType.Enabled = bSet;
                txtEmailAddress2_Id_UniqueId.Enabled = false;
                txtEmailAddress2_Id_ChangeKey.Enabled = false;
            }
            if (oContact.EmailAddresses.TryGetValue(EmailAddressKey.EmailAddress3, out oEmailAddress))
            {
                txtEmailAddress3_Address.Text = oEmailAddress.Address;
                txtEmailAddress3_Name.Text = oEmailAddress.Name;
                txtEmailAddress3_MailboxType.Text = oEmailAddress.MailboxType.ToString();
                txtEmailAddress3_RoutingType.Text = oEmailAddress.RoutingType;
                txtEmailAddress3_MailboxType.Text = oEmailAddress.MailboxType.Value.ToString();
                if (oEmailAddress.Id != null)
                {
                    txtEmailAddress3_Id_UniqueId.Text = oEmailAddress.Id.UniqueId;
                    txtEmailAddress3_Id_ChangeKey.Text = oEmailAddress.Id.ChangeKey;
                }
                else
                {
                    txtEmailAddress3_Id_UniqueId.Text = "";
                    txtEmailAddress3_Id_ChangeKey.Text = "";
                }

                bSet = false;  // Make read-only until the code can be enhanced.
                txtEmailAddress3_Address.Enabled = bSet;
                txtEmailAddress3_Name.Enabled = bSet;
                txtEmailAddress3_MailboxType.Enabled = bSet;
                txtEmailAddress3_RoutingType.Enabled = bSet;
                txtEmailAddress3_MailboxType.Enabled = bSet;
                txtEmailAddress3_Id_UniqueId.Enabled = false;
                txtEmailAddress3_Id_ChangeKey.Enabled = false;
            }

            string sValue = "Not Set";
            //sValue = oContact.PostalAddressIndex.ToString();
           // bool bHasValue = false;
            try
            {
                // [Microsoft.Exchange.WebServices.Data.ServiceObjectPropertyException] = {"This property was requested, but it wasn't returned by the server."}
               // Message = "This property was requested, but it wasn't returned by the server."
                sValue = oContact.PostalAddressIndex.ToString();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                //MessageBox.Show(ex.ToString());
            }
             
            //PostalAddressIndex.ToString((PostalAddressIndexType)PostalAddressIndex.)
            if (sValue != "Not Set")
            {
                switch (sValue)
                {
                    case "None":
                        this.cmboPostalAddressIndex.Text = "None";
                        break;
                    case "Other":
                        this.cmboPostalAddressIndex.Text = "Other";
                        break;
                    case "Home":
                        this.cmboPostalAddressIndex.Text = "Home";
                        break;
                    case "Business":
                        this.cmboPostalAddressIndex.Text = "Business";
                        break;
                }
            }
            else
            {
                this.cmboPostalAddressIndex.Text = "Not Set";
            }

            ////x = (int)oContact.PostalAddressIndex.Value;
            ////if (oContact.PostalAddressIndex != null)
            //if (sValue != null)
            //{
            //    switch (oContact.PostalAddressIndex.Value)
            //    {
            //        case PhysicalAddressIndex.None:
            //            this.cmboPostalAddressIndex.Text = "None";
            //            break;
            //        case PhysicalAddressIndex.Other:
            //            this.cmboPostalAddressIndex.Text = "Other";
            //            break;
            //        case PhysicalAddressIndex.Home:
            //            this.cmboPostalAddressIndex.Text = "Home";
            //            break;
            //        case PhysicalAddressIndex.Business:
            //            this.cmboPostalAddressIndex.Text = "Business";
            //            break;
            //    }
            //}
            //else
            //{
            //    this.cmboPostalAddressIndex.Text = "Not Set";
            //}

 
 
          
            bRet = true;
            return bRet;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtGivenName.Text.Trim().Length != 0)
            {
                try
                {

                    SetContactFromForm(ref _Contact);
                    if (_IsExistingContact == true)
                    {
                        _Contact.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                        _Contact.Update(ConflictResolutionMode.AlwaysOverwrite); 
                    }
                    else
                    {
                        _Contact.Save(_FolderId);
                    }
                    _ContactWasSaved = true;
                    this.Close();
                }
                catch (Exception ex3)
                {
                    MessageBox.Show(ex3.InnerException.ToString(), "Error Saving");
                }
                 
            }
            else
            {
                MessageBox.Show("Contact name needs to be set.", "Missing information");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _ContactWasSaved = false;
            this.Close();
        }

        private void txtBA_City_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void cmboPhoneNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void pbContactPhoto_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAttachments_Click(object sender, EventArgs e)
        {
            Item oItem = (Item)_Contact;
            AddRemoveAttachments oAddRemoveAttachments = new AddRemoveAttachments(ref oItem, true ); //_IsExistingContact);
            oAddRemoveAttachments.ShowDialog();
            if (oAddRemoveAttachments.IsDirty == true)
                _isDirty = true;
        }

        private void txtGivenName_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtJobTitle_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtBA_Street_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtBA_State_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBA_PostalCode_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtBA_CountryOrRegion_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtHA_Street_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtHA_City_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtHA_State_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtHA_PostalCode_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtHA_CountryOrRegion_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtOA_Street_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtOA_City_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtOA_State_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtOA_CountryOrRegion_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtOA_PostalCode_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

    }
}
