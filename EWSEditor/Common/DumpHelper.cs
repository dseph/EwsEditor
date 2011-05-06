namespace EWSEditor.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;

    using EWSEditor.Diagnostics;
    using EWSEditor.PropertyInformation;

    using Microsoft.Exchange.WebServices.Data;

    public class DumpHelper
    {
        private DumpHelper()
        {
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
            TraceHelper.WriteVerbose(String.Format("Dumping MIME contents of {0}.", source.DisplayName));
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
            TraceHelper.WriteVerbose(String.Format("Getting {0} items by ItemId.", itemIds.Count));

            PropertySet mimeSet = new PropertySet(BasePropertySet.IdOnly);
            mimeSet.Add(EmailMessageSchema.MimeContent);
            mimeSet.Add(EmailMessageSchema.Subject);
            ServiceResponseCollection<GetItemResponse> responses = service.BindToItems(itemIds, mimeSet);

            TraceHelper.WriteVerbose("Finished getting items.");

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

            TraceHelper.WriteVerbose("Finished dumping MimeContents for each item.");
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

            TraceHelper.WriteVerbose("Writing MimeContent to file.");

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

            TraceHelper.WriteVerbose(String.Format("Wrote item to file, {0}.", fileName));
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
            TraceHelper.WriteVerbose(String.Format("Getting {0} items by ItemId.", itemIds.Count));
            ServiceResponseCollection<GetItemResponse> responses = service.BindToItems(itemIds, propertySet);
            TraceHelper.WriteVerbose("Finished getting items.");

            TraceHelper.WriteVerbose("Started writing XML dumps to files.");
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

            TraceHelper.WriteVerbose("Finished writing XML dumps to files.");
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
            TraceHelper.WriteVerbose("Writing item to file.");

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

            TraceHelper.WriteVerbose(String.Concat("Wrote item to file, {0}", fileName));
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
            TraceHelper.WriteVerbose("Writing error to file.");

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

            TraceHelper.WriteVerbose(String.Format("Wrote error to file, {0}.", fileName));
        }

        private static List<ItemId> GetItemIds(Folder source, ExchangeService service, ItemTraversal traversal)
        {
            // Collect the Ids of all the items in the folder
            List<ItemId> itemIds = new List<ItemId>();

            FindItemsResults<Item> findResults = null;
            while (findResults == null || findResults.MoreAvailable == true)
            {
                TraceHelper.WriteVerbose("Calling FindItems.");

                ItemView view = new ItemView(
                    ConfigHelper.DumpFolderViewSize,
                    itemIds.Count);

                view.Traversal = traversal;
                view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
                findResults = source.FindItems(view);

                TraceHelper.WriteVerbose(String.Concat("FindItems returned {0} items", findResults.Items.Count));

                foreach (Item foundItem in findResults.Items)
                {
                    itemIds.Add(foundItem.Id);
                }
            }

            return itemIds;
        }
    }
}
