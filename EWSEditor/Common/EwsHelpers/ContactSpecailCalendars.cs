using Microsoft.Exchange.WebServices.Data;
using System;

namespace EWSEditor.Common.EwsHelpers
{

    // ToDo:  Finish and implemnt in UI.

    public class ContactSpecailCalendars
    {
        // PidLidAnniversaryEventEntryId
        //      https://msdn.microsoft.com/en-us/library/office/cc765710.aspx
        //      https://msdn.microsoft.com/en-us/library/ee204213(v=exchg.80).aspx
        //
        //      Note:  The appointment specified by the dispidAnniversaryEventEID property must be linked to this contact by 
        //          using the dispidContactLinkEntry (PidLidContactLinkEntry), dispidContactLinkSearchKey (PidLidContactLinkSearchKey), 
        //          and dispidContactLinkName (PidLidContactLinkName) properties, as detailed in [MS-OXCMSG].
        //
        // PidLidBirthdayEventEntryId 
        //      https://msdn.microsoft.com/en-us/library/cc839623(v=office.12).aspx  
        //      https://msdn.microsoft.com/en-us/library/cc839623(v=office.12).aspx
        //
        //      Note: The appointment this is specified by this property must be linked to this contact by 
        //          using the dispidApptStateFlags(PidLidContactLinkEntry), dispidContactLinkSearchKey(PidLidContactLinkSearchKey), 
        //          and dispidContactLinkName(PidLidContactLinkName) properties, as specified in [MS-OXCMSG].
        //      
        // Protocol documents to review:
        //
        //      [MS-OXCMSG]: Message and Attachment Object Protocol
        //      https://msdn.microsoft.com/en-us/library/cc463900(v=exchg.80).aspx
        //      http://interoperability.blob.core.windows.net/files/MS-OXCMSG/[MS-OXCMSG].pdf
        //
        // More:
        //      https://social.msdn.microsoft.com/Forums/onedrive/en-US/f08c4573-2f9d-4322-a83d-02a9620e8f8c/contact-created-using-ews-does-not-have-the-birthday-displayed-in-the-calendar?forum=exchangesvrdevelopment
        //      http://gsexdev.blogspot.com/2016/11/using-birthday-calendar-in-ews-in.html#!/2016/11/using-birthday-calendar-in-ews-in.html
        //      https://support.office.com/en-us/article/Add-a-birthday-or-anniversary-for-a-contact-333ccb47-1d57-405a-8d61-3cc39b80912e
        //      https://gallery.technet.microsoft.com/office/Add-Birthday-or-Anniversary-e111b73d
        //      https://msdn.microsoft.com/en-us/library/ee159359(v=exchg.80).aspx
        //      https://blogs.msdn.microsoft.com/emeamsgdev/2014/06/17/programmatically-add-links-to-outlook-contactitems-in-outlook-2013/

        static ExtendedPropertyDefinition PidLidAnniversaryEventEntryId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Address, 0x0000804E, MapiPropertyType.Binary);
        static ExtendedPropertyDefinition PidLidBirthdayEventEntryId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Address, 0x0000804D, MapiPropertyType.Binary);

        static ExtendedPropertyDefinition BirthDayLocal = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Address, 0x80DE, MapiPropertyType.SystemTime);

        static ExtendedPropertyDefinition PidLidContactLinkEntry = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x00008585, MapiPropertyType.Binary);
        static ExtendedPropertyDefinition PidLidContactLinkName = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x00008586, MapiPropertyType.String);
        static ExtendedPropertyDefinition PidLidContactLinkSearchKey = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x00008584, MapiPropertyType.Binary);


        // Contact				PSETID_Address				00062004-0000-0000-C000-000000000046

        public FolderId GetBirthdayCalendarFolder(ExchangeService oExchangeService, string sSmtp)
        {
            return GetFolderId_FromExtendedPropertyDefinition(oExchangeService, sSmtp, PidLidBirthdayEventEntryId);   
        }
        public FolderId GetAnniversaryCalendarFolder(ExchangeService oExchangeService, string sSmtp)
        {
            
            return GetFolderId_FromExtendedPropertyDefinition(oExchangeService, sSmtp, PidLidAnniversaryEventEntryId);
        }


        public  String Get_EwsIdFromEntryID(ExchangeService oExchangeService, String sSmtp, String sEntryID)
        {
            // https://blogs.msdn.microsoft.com/brijs/2010/09/09/how-to-convert-exchange-items-entryid-to-ews-unique-itemid-via-ews-managed-api-convertid-call/

            // Create a request to convert identifiers. 
            AlternateId objAltID = new AlternateId();
            objAltID.Format = IdFormat.EntryId;
            objAltID.Mailbox = sSmtp;
            objAltID.UniqueId = sEntryID;

            //Convert  PR_ENTRYID identifier format to an EWS identifier. 
            AlternateIdBase objAltIDBase = oExchangeService.ConvertId(objAltID, IdFormat.EwsId);
            AlternateId objAltIDResp = (AlternateId)objAltIDBase;
            return objAltIDResp.UniqueId;
        }


        public FolderId GetFolderId_FromExtendedPropertyDefinition(ExchangeService oExchangeService, string sSmtp, ExtendedPropertyDefinition oEPD_Folder )
        {
            Folder oFoundFolder = null;
            FolderId oFolderEWSId = null;
            string sBirthdayFolderEWSId = string.Empty;
            string sHexEntryId = string.Empty;

            FolderId oRoot = new FolderId(WellKnownFolderName.Root, sSmtp);
            PropertySet psPropset = new PropertySet(BasePropertySet.FirstClassProperties);
            psPropset.Add(oEPD_Folder);
            Folder EWSRootFolder = Folder.Bind(oExchangeService, oRoot, psPropset);
            byte[] oFolderEntryIdValue;

 
            if (EWSRootFolder.TryGetProperty(oEPD_Folder, out oFolderEntryIdValue))
            {
                sHexEntryId = System.BitConverter.ToString(oFolderEntryIdValue).Replace("-", "");

                sBirthdayFolderEWSId = Get_EwsIdFromEntryID(oExchangeService, sSmtp, sHexEntryId);

                oFoundFolder = Folder.Bind(oExchangeService, oFolderEWSId);
                return oFoundFolder.Id;
            }
            else
            {
                return null;
            }
        }

        public ItemId AddBirthdaysForContact(ExchangeService oExchangeServcie, string sSmtp, ref Contact oContact, DateTime oBirthDate)
        {
            //ItemId oItemId;

            return null;
        }

        public ItemId GetBirthdayForContact(ExchangeService oExchangeServcie, string sSmtp, Contact oContact)
        {

            // Converted from:  http://gsexdev.blogspot.com/2016/11/using-birthday-calendar-in-ews-in.html#!/2016/11/using-birthday-calendar-in-ews-in.html

            //ItemId oAppointmentId = null;
 
            DateTime oStartDateTime = DateTime.Now;
            DateTime oEndDateTime = DateTime.Now;

            PropertySet psPropset = new PropertySet(BasePropertySet.FirstClassProperties);
            psPropset.Add(BirthDayLocal);
            FolderId oBirthDayCalendarFolder = GetBirthdayCalendarFolder(oExchangeServcie, sSmtp);


            //            $CalendarView.PropertySet = $psPropset
            //            $fiItems = $service.FindAppointments($BirthdayFolder.Id,$CalendarView)    
            //            foreach($Item in $fiItems.Items){      
            //                $exportObj = "" | Select subject, StartTime, EndTime, DateOfBirth, Age
            //                $exportObj.StartTime = $Item.Start
            //                $exportObj.EndTime = $Item.End
            //                $exportObj.Subject = $Item.Subject
            //                $BirthDavLocalValue = $null
            //                if($Item.TryGetProperty($BirthDayLocal,[ref]$BirthDavLocalValue)){
            //                    $exportObj.DateOfBirth = $BirthDavLocalValue
            //                    $exportObj.Age = [Math]::Truncate(($Item.Start – $BirthDavLocalValue).TotalDays / 365); 
            //                }
            //    Write-Output $exportObj

            //        $strtime = (Get - date).Year.ToString() + "0101"
            //        $endtime = (Get - date).AddYears(1).Year.ToString() + "0101"
            //        $StartDate =  [datetime]::ParseExact($strtime, "yyyyMMdd",$null)
            //        $EndDate =  [datetime]::ParseExact($endtime, "yyyyMMdd",$null)

            //        $folderid = new- object Microsoft.Exchange.WebServices.Data.FolderId([Microsoft.Exchange.WebServices.Data.WellKnownFolderName]::Root,$MailboxName)   
            //        $BirthdayCalendarFolderEntryId = New - Object Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition([Microsoft.Exchange.WebServices.Data.DefaultExtendedPropertySet]::Common,"BirthdayCalendarFolderEntryId",[Microsoft.Exchange.WebServices.Data.MapiPropertyType]::Binary); 
            //        $psPropset= new-object Microsoft.Exchange.WebServices.Data.PropertySet([Microsoft.Exchange.WebServices.Data.BasePropertySet]::FirstClassProperties)
            //        $psPropset.Add($BirthdayCalendarFolderEntryId)
            // $EWSRootFolder = [Microsoft.Exchange.WebServices.Data.Folder]::Bind($service,$folderid,$psPropset)
            //        $BirthdayCalendarFolderEntryIdValue = $null
            // $BirthdayCalendarFolderHexValue = $null
            //        if($EWSRootFolder.TryGetProperty($BirthdayCalendarFolderEntryId,[ref]$BirthdayCalendarFolderEntryIdValue)){
            //   $BirthdayFolderEWSId = new-object Microsoft.Exchange.WebServices.Data.FolderId((ConvertId -HexId ([System.BitConverter]::ToString($BirthdayCalendarFolderEntryIdValue).Replace("-",""))))
            //   $BirthdayFolder = [Microsoft.Exchange.WebServices.Data.Folder]::Bind($service,$BirthdayFolderEWSId);
            //   $CalendarView = New-Object Microsoft.Exchange.WebServices.Data.CalendarView($StartDate,$EndDate,1000)
            //            $psPropset= new-object Microsoft.Exchange.WebServices.Data.PropertySet([Microsoft.Exchange.WebServices.Data.BasePropertySet]::FirstClassProperties)
            //            $BirthDayLocal = new-object Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition([Microsoft.Exchange.WebServices.Data.DefaultExtendedPropertySet]::Address,0x80DE, [Microsoft.Exchange.WebServices.Data.MapiPropertyType]::SystemTime)
            //            $psPropset.Add($BirthDayLocal)
            //            $CalendarView.PropertySet = $psPropset
            //            $fiItems = $service.FindAppointments($BirthdayFolder.Id,$CalendarView)    
            //            foreach($Item in $fiItems.Items){      
            //                $exportObj = "" | Select subject, StartTime, EndTime, DateOfBirth, Age
            //                $exportObj.StartTime = $Item.Start
            //                $exportObj.EndTime = $Item.End
            //                $exportObj.Subject = $Item.Subject
            //                $BirthDavLocalValue = $null
            //                if($Item.TryGetProperty($BirthDayLocal,[ref]$BirthDavLocalValue)){
            //                    $exportObj.DateOfBirth = $BirthDavLocalValue
            //                    $exportObj.Age = [Math]::Truncate(($Item.Start – $BirthDavLocalValue).TotalDays / 365); 
            //                }
            //    Write-Output $exportObj
            //}
            //        }
            // else
            // {   
            //         throw [System.IO.FileNotFoundException] "folder not found."
            // }
            //    }

            return null;
        }

        public bool LinkBirthdayEventToContact()
        {
            //  Note: The appointment this is specified by this property must be linked to this contact by 
            //          using the dispidApptStateFlags(PidLidContactLinkEntry), dispidContactLinkSearchKey(PidLidContactLinkSearchKey), 
            //          and dispidContactLinkName(PidLidContactLinkName) properties, as specified in [MS-OXCMSG].

            return false;
        }

        public bool LinkAnniversaryEventToContact()
        {
            //  Note:   The appointment specified by the dispidAnniversaryEventEID property must be linked to this contact by using 
            //      the dispidContactLinkEntry (PidLidContactLinkEntry), dispidContactLinkSearchKey (PidLidContactLinkSearchKey), and 
            //      dispidContactLinkName(PidLidContactLinkName) properties, as detailed in [MS-OXCMSG].

            return false;
        }

    }

}
