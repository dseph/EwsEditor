using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using EWSEditor.Logging;
using EWSEditor.PropertyInformation;
using EWSEditor.Settings;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Exchange;

namespace EWSEditor.Common
{
    public class DumpHelper
    {
        private DumpHelper()
        {

            //Appointment x;
            
 
        }

        /// <summary>
        /// Dump the MIME content of every message in the given folder.
        /// </summary>
        /// <param name="source">Source folder to get items from</param>
        /// <param name="traversal">The traversal level to pull items from</param>
        /// <param name="destinationFolderPath">Folder to save messages to</param>
        /// <param name="service">ExchangeService to use to make EWS calls</param>
        public static void DumpMIME(
            Folder source, 
            ItemTraversal traversal, 
            string destinationFolderPath, 
            ExchangeService service)
        {
            DebugLog.WriteVerbose("Dumping MIME contents of " + source.DisplayName);
            List<ItemId> itemIds = GetItemIds(source, service, traversal);

            DumpMIME(itemIds, destinationFolderPath, service);
        }

        /// <summary>
        /// Get the MimeContent of each Item specified in itemIds and write it
        /// to the destination folder.
        /// </summary>
        /// <param name="itemIds">ItemIds to retrieve</param>
        /// <param name="destinationFolderPath">Folder to save messages to</param>
        /// <param name="service">ExchangeService to use to make EWS calls</param>
        public static void DumpMIME(
            List<ItemId> itemIds,
            string destinationFolderPath,
            ExchangeService service)
        {
            DebugLog.WriteVerbose(String.Format("Getting {0} items by ItemId.", itemIds.Count));

            PropertySet mimeSet = new PropertySet(BasePropertySet.IdOnly);

            mimeSet.Add(EmailMessageSchema.MimeContent);
            mimeSet.Add(EmailMessageSchema.Subject);
             
            
            //mimeSet.Add(AppointmentSchema.MimeContent);
            //mimeSet.Add(AppointmentSchema.Subject);
            //mimeSet.Add(AppointmentSchema.RequiredAttendees);
            //mimeSet.Add(AppointmentSchema.OptionalAttendees);
            service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            ServiceResponseCollection<GetItemResponse> responses = service.BindToItems(itemIds, mimeSet);

            DebugLog.WriteVerbose("Finished getting items.");

            foreach (GetItemResponse response in responses)
            {
                switch (response.Result)
                {
                    case ServiceResult.Success:
                        DumpMIME(response.Item, destinationFolderPath);
                        break;
                    case ServiceResult.Error:
                        DumpErrorResponseXML(response, destinationFolderPath);
                        break;
                    case ServiceResult.Warning:
                        throw new NotImplementedException("DumpMIME doesn't handle ServiceResult.Warning.");
                    default:
                        throw new NotImplementedException("DumpMIME encountered an unexpected ServiceResult.");
                }
            }

            DebugLog.WriteVerbose("Finished dumping MimeContents for each item.");
        }

 
        /// <summary>
        /// Get the MimeContent of each Item specified in itemIds and write it
        /// to a string.
        /// </summary>
        /// <param name="itemIds">ItemIds to retrieve</param>
        /// <param name="destinationFolderPath">Folder to save messages to</param>
        /// <param name="service">ExchangeService to use to make EWS calls</param>
        /// <param name="TheMime">MIME string to set</param>
        public static void DumpMIMEToString(
            List<ItemId> itemIds,
            ExchangeService service,
            ref string TheMime)
        {
            DebugLog.WriteVerbose(String.Format("Getting {0} items by ItemId.", itemIds.Count));
            string MimeToReturn = string.Empty;
            PropertySet mimeSet = new PropertySet(BasePropertySet.IdOnly);

            mimeSet.Add(EmailMessageSchema.MimeContent);
            mimeSet.Add(EmailMessageSchema.Subject);

            service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            ServiceResponseCollection<GetItemResponse> responses = service.BindToItems(itemIds, mimeSet);

            DebugLog.WriteVerbose("Finished getting items.");

            foreach (GetItemResponse response in responses)
            {
                switch (response.Result)
                {
                    case ServiceResult.Success:
                        if (response.Item.MimeContent == null)
                        {
                            throw new ApplicationException("No MIME content to write");
                        }
                        UTF8Encoding oUTF8Encoding = new UTF8Encoding();
                        MimeToReturn = oUTF8Encoding.GetString(response.Item.MimeContent.Content);
                         
                        break;
                    case ServiceResult.Error:
                        MimeToReturn =
                                "ErrorCode:           " + response.ErrorCode.ToString() + "\r\n" +
                                "\r\nErrorMessage:    " + response.ErrorMessage + "\r\n";
 
                        break;
                    case ServiceResult.Warning:
                        throw new NotImplementedException("DumpMIMEToString doesn't handle ServiceResult.Warning.");
                    default:
                        throw new NotImplementedException("DumpMIMEToString encountered an unexpected ServiceResult.");
                }
            }

            TheMime = MimeToReturn;

            DebugLog.WriteVerbose("Finished dumping MimeContents for each item.");
        }

 

        /// <summary>
        /// Get the MIME for the item and return MIME as a string. 
        /// 
        /// </summary>
        /// <param name="oItemId">ItemId of Item with the MimeContent to get</param>
        /// <param name="service">Exchagne service to use</param>
        /// <param name="TheMime">MIME string to set</param>
        public static void GetItemMime(ItemId oItemId,
            ExchangeService service,
            ref string TheMime)
        {
            DebugLog.WriteVerbose(String.Format("Getting item MIME." ));
            string MimeToReturn = string.Empty;
            try
            {

                PropertySet oMimePropertySet = new PropertySet(ItemSchema.MimeContent);
                //Appointment oItem = (Appointment)Item.Bind(service, oItemId, oMimePropertySet);

                service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
                Item oItem = Item.Bind(service, oItemId, oMimePropertySet);
                if (oItem.MimeContent == null)
                    throw new ApplicationException("No MIME content to write");
                else
                    MimeToReturn = oItem.MimeContent.ToString();
            }
            catch (Exception ex)
            {
                MimeToReturn = "Error getting MIME: \r\n" + ex.Message;
            }
            TheMime = MimeToReturn;

            DebugLog.WriteVerbose(String.Format("Finished item MIME."));
        }

        /// <summary>
        /// Get the MIME for the item and return MIME as a string. 
        /// 
        /// </summary>
        /// <param name="item">Item with the MimeContent to get</param>
        /// <param name="service">Exchagne service to use</param>
        /// <param name="TheMime">MIME string to set</param>
        public  static void  GetItemMime(Item oItem,
            ExchangeService service,
            ref string TheMime)
        {
            DebugLog.WriteVerbose(String.Format("Getting item MIME."));
            string MimeToReturn = string.Empty;
            try 
            {
                PropertySet oMimePropertySet = new PropertySet(ItemSchema.MimeContent);
                oItem.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
                oItem.Load(oMimePropertySet);
 
                if (oItem.MimeContent == null)
                    throw new ApplicationException("No MIME content to write");
                else
                    TheMime =  oItem.MimeContent.ToString();
                
            }
            catch (Exception ex)
            {
                MimeToReturn = "Error getting MIME: \r\n" + ex.Message;
            }
            TheMime = MimeToReturn;

            DebugLog.WriteVerbose(String.Format("Finished item MIME.")); 
        }




        /// <summary>
        /// Dump the MimeContent property of the given Item the given folder
        /// path.
        /// </summary>
        /// <param name="item">Item with the MimeContent to dump</param>
        /// <param name="destinationFolderPath">Folder to save messages to</param>
        public static void DumpMIME(
            Item item,
            string destinationFolderPath)
        {
            // If there's no MIMEContent to write out that's bad
            if (item.MimeContent == null)
            {
                throw new ApplicationException("No MIME content to write");
            }

            DebugLog.WriteVerbose("Writing MimeContent to file.");

            // Create a file path to save the MIME content to
            string fileName = string.Format(
                System.Globalization.CultureInfo.CurrentCulture, 
                "{0}\\{1}.eml",
                destinationFolderPath,
                FileHelper.SanitizeFileName(item.Subject));

            // Write MIME content to file
            System.IO.File.WriteAllBytes(
                FileHelper.EnsureUniqueFileName(fileName),
                item.MimeContent.Content);

            DebugLog.WriteVerbose(String.Format("Wrote item to file, {0}.", fileName));
        }

        /// <summary>
        /// Dump the properties from the given PropertySet of every message in the 
        /// given folder to XML files.
        /// </summary>
        /// <param name="source">Source folder to get items from</param>
        /// <param name="traversal">The traversal level to pull items from</param>
        /// <param name="propertySet">PropertySet to use when getting items</param>
        /// <param name="destinationFolderPath">Folder to save messages to</param>
        /// <param name="service">ExchangeService to use to make EWS calls</param>
        public static void DumpXML(
            Folder source,
            ItemTraversal traversal,
            PropertySet propertySet,
            string destinationFolderPath,
            ExchangeService service)
        {
            List<ItemId> itemIds = GetItemIds(source, service, traversal);

            DumpXML(itemIds, propertySet, destinationFolderPath, service);
        }

        /// <summary>
        /// Dump the properties from the given PropertySet of every item in the 
        /// ItemId list to XML files.
        /// </summary>
        /// <param name="itemIds">List of ItemIds to get</param>
        /// <param name="propertySet">PropertySet to use when getting items</param>
        /// <param name="destinationFolderPath">Folder to save messages to</param>
        /// <param name="service">ExchangeService to use to make EWS calls</param>
        public static void DumpXML(
            List<ItemId> itemIds,
            PropertySet propertySet,
            string destinationFolderPath,
            ExchangeService service)
        {
            DebugLog.WriteVerbose(String.Format("Getting {0} items by ItemId.", itemIds.Count));
            service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            ServiceResponseCollection<GetItemResponse> responses = service.BindToItems(itemIds, propertySet);
            DebugLog.WriteVerbose("Finished getting items.");

            DebugLog.WriteVerbose("Started writing XML dumps to files.");
            foreach (GetItemResponse response in responses)
            {
                switch (response.Result)
                {
                    case ServiceResult.Success:
                        DumpXML(response.Item, destinationFolderPath);
                        break;
                    case ServiceResult.Error:
                        DumpErrorResponseXML(response, destinationFolderPath);
                        break;
                    case ServiceResult.Warning:
                        throw new NotImplementedException("DumpXML doesn't handle ServiceResult.Warning.");
                    default:
                        throw new NotImplementedException("Unexpected ServiceResult.");
                }
            }

            DebugLog.WriteVerbose("Finished writing XML dumps to files.");
        }

        /// <summary>
        /// Dump the properties from the given Item to an XML file in the given
        /// destination folder.
        /// </summary>
        /// <param name="item">Loaded Item whose properties are to be dumped</param>
        /// <param name="destinationFolderPath">Folder to save messages to</param>
        public static void DumpXMLbyFileName(
            Item item,
            string destinationFolderPath)
        {
            DebugLog.WriteVerbose("Writing item to file.");

            // Create a file path to save the item properties to
            string fileName = null;
            fileName = string.Format(
                System.Globalization.CultureInfo.CurrentCulture, 
                "{0}\\{1}.xml",
                destinationFolderPath,
                FileHelper.SanitizeFileName(item.Subject));

            XmlDocument xmlDoc = new XmlDocument();
            XmlNode xmlMessage = xmlDoc.CreateNode(XmlNodeType.Element, "Message", string.Empty);
            xmlDoc.AppendChild(xmlMessage);
            XmlNode xmlProperties = xmlDoc.CreateNode(XmlNodeType.Element, "Properties", string.Empty);
            xmlMessage.AppendChild(xmlProperties);

            foreach (PropertyDefinitionBase baseProp in item.GetLoadedPropertyDefinitions())
            {
                if (baseProp != ItemSchema.ExtendedProperties)
                {
                    PropertyInterpretation propInter = new PropertyInterpretation(item, baseProp);
                    xmlProperties.AppendChild(propInter.ToXML(xmlDoc));
                }
            }

            // Write XML content to file
            System.IO.File.WriteAllText(
                FileHelper.EnsureUniqueFileName(fileName),
                xmlDoc.OuterXml);

            DebugLog.WriteVerbose(String.Concat("Wrote item to file, {0}", fileName));
        }

        /// <summary>
        /// Dump the properties from the given Item to an XML file in the given
        /// destination folder.
        /// </summary>
        /// <param name="item">Loaded Item whose properties are to be dumped</param>
        /// <param name="destinationFolderPath">Folder to save messages to</param>
        public static void DumpXML(
            Item item,
            string destinationFolderPath)
        {
            DebugLog.WriteVerbose("Writing item to file.");

            // Create a file path to save the item properties to
            string fileName = null;
            fileName = string.Format(
                System.Globalization.CultureInfo.CurrentCulture,
                "{0}\\{1}.xml",
                destinationFolderPath,
                FileHelper.SanitizeFileName(item.Subject));

            XmlDocument xmlDoc = new XmlDocument();
            XmlNode xmlMessage = xmlDoc.CreateNode(XmlNodeType.Element, "Message", string.Empty);
            xmlDoc.AppendChild(xmlMessage);
            XmlNode xmlProperties = xmlDoc.CreateNode(XmlNodeType.Element, "Properties", string.Empty);
            xmlMessage.AppendChild(xmlProperties);

            foreach (PropertyDefinitionBase baseProp in item.GetLoadedPropertyDefinitions())
            {
                if (baseProp != ItemSchema.ExtendedProperties)
                {
                    PropertyInterpretation propInter = new PropertyInterpretation(item, baseProp);
                    xmlProperties.AppendChild(propInter.ToXML(xmlDoc));
                }
            }

            // Write XML content to file
            System.IO.File.WriteAllText(
                FileHelper.EnsureUniqueFileName(fileName),
                xmlDoc.OuterXml);

            DebugLog.WriteVerbose(String.Concat("Wrote item to file, {0}", fileName));
        }

        /// <summary>
        /// Dump an error response as XML
        /// </summary>
        /// <param name="response">Response to get data from</param>
        /// <param name="destinationFolderPath">Folder to save messages to</param>
        private static void DumpErrorResponseXML(
            GetItemResponse response,
            string destinationFolderPath)
        {
            DebugLog.WriteVerbose("Writing error to file.");

            XmlDocument xmlDoc = new XmlDocument();
            XmlNode xmlMessage = xmlDoc.CreateNode(XmlNodeType.Element, "Message", string.Empty);
            xmlDoc.AppendChild(xmlMessage);
            XmlNode xmlProperties = xmlDoc.CreateNode(XmlNodeType.Element, "Properties", string.Empty);
            xmlMessage.AppendChild(xmlProperties);

            // Create a file path to save the error message to
            string fileName = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}\\_ERROR.txt", destinationFolderPath);

            // Get error message contents
            XmlNode xmlError = xmlDoc.CreateNode(XmlNodeType.Element, "Error", string.Empty);

            XmlNode xmlErrorCode = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorCode", string.Empty);
            xmlErrorCode.InnerText = response.ErrorCode.ToString();
            xmlError.AppendChild(xmlErrorCode);

            XmlNode xmlErrorMessage = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorMessage", string.Empty);
            xmlErrorMessage.InnerText = response.ErrorMessage;
            xmlError.AppendChild(xmlErrorMessage);

            if (response.ErrorDetails != null && response.ErrorDetails.Count > 0)
            {
                XmlNode xmlErrorDetails = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorDetails", string.Empty);
                StringBuilder detailsText = new StringBuilder();

                foreach (KeyValuePair<string, string> detail in response.ErrorDetails)
                {
                    XmlNode xmlErrorDetail = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorDetail", string.Empty);
                    XmlNode xmlKeyAttr = xmlDoc.CreateNode(XmlNodeType.Attribute, "Key", string.Empty);
                    xmlKeyAttr.Value = detail.Key;
                    xmlErrorDetail.AppendChild(xmlKeyAttr);
                    xmlErrorDetail.InnerText = detail.Value;

                    xmlErrorDetails.AppendChild(xmlErrorDetail);
                }

                xmlError.AppendChild(xmlErrorDetails);
            }

            if (response.ErrorProperties != null && response.ErrorProperties.Count > 0)
            {
                XmlNode xmlErrorProps = xmlDoc.CreateNode(XmlNodeType.Element, "ErrorProperties", string.Empty);
                StringBuilder propsText = new StringBuilder();

                foreach (PropertyDefinitionBase baseProp in response.ErrorProperties)
                {
                    PropertyInterpretation prop = new PropertyInterpretation(response.Item, baseProp);
                    xmlErrorProps.AppendChild(prop.ToXML(xmlDoc));
                }

                xmlError.AppendChild(xmlErrorProps);
            }

            xmlProperties.AppendChild(xmlError);

            // Write MIME content to file
            System.IO.File.WriteAllText(
                FileHelper.EnsureUniqueFileName(fileName),
                xmlDoc.OuterXml);

            DebugLog.WriteVerbose(String.Format("Wrote error to file, {0}.", fileName));
        }

        private static List<ItemId> GetItemIds(Folder source, ExchangeService service, ItemTraversal traversal)
        {
            // Collect the Ids of all the items in the folder
            List<ItemId> itemIds = new List<ItemId>();

            FindItemsResults<Item> findResults = null;
            while (findResults == null || findResults.MoreAvailable == true)
            {
                DebugLog.WriteVerbose("Calling FindItems.");

                ItemView view = new ItemView(
                    GlobalSettings.DumpFolderViewSize,
                    itemIds.Count);

                view.Traversal = traversal;
                view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
                source.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
                findResults = source.FindItems(view);

                DebugLog.WriteVerbose(String.Concat("FindItems returned {0} items", findResults.Items.Count));

                foreach (Item foundItem in findResults.Items)
                {
                    itemIds.Add(foundItem.Id);
                }
            }

            return itemIds;
        }
    }
}
