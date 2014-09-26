using System;
using System.Net;
using EWSEditor.Common.Extensions;
using EWSEditor.EwsVsProxy;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Resources;
using System.Text;
using System.IO;
using System.Xml;
using EWSEditor.Common;
using EWSEditor.Forms;
using EWSEditor.Forms.Controls;

namespace EWSEditor.Exchange
{
    public class ExportUploadHelper
    {
        ///// <summary>
        ///// Restore an item from a stream to a given folder using the UploadItems operation which is not
        ///// in the EWS API so the given ExchangeService object must be converted to a proxy binding
        ///// to make the request.
        ///// </summary>
        ///// <param name="service">ExchangeService object to convert to a WCF client</param>
        ///// <param name="folderId">Id of target folder where item will be uploaded to</param>
        ///// <param name="data">Stream to import</param>
        //public static void UploadItem(ExchangeService service, FolderId folderId, CreateActionType oCreateActionType, string sItemId, byte[] data)
        //{
        //    ExchangeServiceBinding client = ConvertExchangeService(service);
        //    var upload = new UploadItemsType();
        //    var item = new UploadItemType();
             
        //    item.IsAssociated = false;
        //    item.ParentFolderId = new FolderIdType();
        //    item.ParentFolderId.Id = folderId.UniqueId;
        //    item.ParentFolderId.ChangeKey = folderId.ChangeKey;
        //    item.Data = data;
 
        //    if (oCreateActionType == CreateActionType.UpdateOrCreate ||
        //        oCreateActionType == CreateActionType.Update)
        //    {
   
        //        ItemIdType oItem = new ItemIdType() ;
        //        oItem.Id = sItemId;
        //        item.ItemId = oItem;   
        //    }


        //    // TODO: Finish changes to make this an option instead of hardcoding in the future
   
        //    item.CreateAction = oCreateActionType;

        //    upload.Items = new UploadItemType[]
        //    {
        //        item
        //    };

 
        //    UploadItemsResponseType response = client.UploadItems(upload);

        //    // Look for errors in the response
        //    ThrowIfResponseError(response);
        //}

        ///// <summary>
        ///// Get a stream from an item using the ExportItems operation which is not implemented in the EWS API
        ///// so the given ExchangeService object must be converted to a proxy binding to make the request.
        ///// </summary>
        ///// <param name="service">ExchangeService object to convert to a WCF client</param>
        ///// <param name="itemId">Id of target item to export</param>
        ///// <param name="data">Stream that was exported</param>
        //public static void ExportItem(ExchangeService service, ItemId itemId, out byte[] data)
        //{
        //    data = null;
            
        //    ExchangeServiceBinding client = ConvertExchangeService(service);
        //    ExportItemsType export = new ExportItemsType();
        //    export.ItemIds = new ItemIdType[]
        //    {
        //        ConvertItemId(itemId)
        //    };

        //    ExportItemsResponseType response = client.ExportItems(export);

        //    // Look for errors in the response
        //    ThrowIfResponseError(response);

        //    ExportItemsResponseMessageType exportResponse = 
        //        response.ResponseMessages.Items[0] as ExportItemsResponseMessageType;

        //    if (exportResponse == null)
        //    {
        //        throw new ApplicationException("Unexpected ExportItems response message type");
        //    }

        //    data = exportResponse.Data;
        //}


        public static bool ExportItemPost(string ServerVersion, string sItemId, string sFile)
        {
            bool bSuccess = false;
            string sResponseText = string.Empty;
            System.Net.HttpWebRequest oHttpWebRequest = null;
            EwsProxyFactory.CreateHttpWebRequest(ref oHttpWebRequest);

            // Build request body...
            string EwsRequest = TemplateEwsRequests.ExportItems;
            EwsRequest = EwsRequest.Replace("##RequestServerVersion##", ServerVersion);
            EwsRequest = EwsRequest.Replace("##ItemId##", sItemId);
       
            try
            {
 
                // Use request to do POST to EWS so we get back the data for the item to export.
                byte[] bytes = Encoding.UTF8.GetBytes(EwsRequest);
                oHttpWebRequest.ContentLength = bytes.Length;
                using (Stream requestStream = oHttpWebRequest.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Flush();
                    requestStream.Close();
                }
 
                // Get response
                HttpWebResponse oHttpWebResponse = (HttpWebResponse)oHttpWebRequest.GetResponse();

                StreamReader oStreadReader = new StreamReader(oHttpWebResponse.GetResponseStream());
                sResponseText = oStreadReader.ReadToEnd();

   
                // OK?
                if (oHttpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    int BUFFER_SIZE = 1024;
                    int iReadBytes = 0;

                    XmlDocument oDoc = new XmlDocument();
                    XmlNamespaceManager namespaces = new XmlNamespaceManager(oDoc.NameTable);
                    namespaces.AddNamespace("m", "http://schemas.microsoft.com/exchange/services/2006/messages");
                    oDoc.LoadXml(sResponseText);
                    XmlNode oData = oDoc.SelectSingleNode("//m:Data", namespaces);
 
                     // Write base 64 encoded text Data XML string into a binary base 64 text/XML file
                    BinaryWriter oBinaryWriter = new BinaryWriter(File.Open(sFile, FileMode.Create));
                    StringReader oStringReader = new StringReader(oData.OuterXml);
                    XmlTextReader oXmlTextReader = new XmlTextReader(oStringReader);
                    oXmlTextReader.MoveToContent();
                    byte[] buffer = new byte[BUFFER_SIZE];
                    do
                    {
                        iReadBytes = oXmlTextReader.ReadBase64(buffer, 0, BUFFER_SIZE);
                        oBinaryWriter.Write(buffer, 0, iReadBytes);
                    }
                    while (iReadBytes >= BUFFER_SIZE);

                    oXmlTextReader.Close();

                    oBinaryWriter.Flush();
                    oBinaryWriter.Close();

                    bSuccess = true;
                }
                
 
            }
            finally 
            {
 

            }

            return bSuccess;
 
        }


        public static bool UploadItemPost(string ServerVersion, FolderId ParentFolderId, CreateActionType oCreateActionType, string sItemId, string sFile)
        { 
            
            bool bSuccess = false;
            string sResponseText = string.Empty;
            System.Net.HttpWebRequest oHttpWebRequest = null;
            EwsProxyFactory.CreateHttpWebRequest(ref oHttpWebRequest);

            string EwsRequest = string.Empty;

            if (oCreateActionType != CreateActionType.CreateNew)
            {  
                EwsRequest = TemplateEwsRequests.UploadItems_Update;
                 
                if (oCreateActionType == CreateActionType.Update)
                    EwsRequest = EwsRequest.Replace("##CreateAction##", "Update");
                else
                    EwsRequest = EwsRequest.Replace("##CreateAction##", "UpdateOrCreate");
                EwsRequest = EwsRequest.Replace("##ItemId##", sItemId);    
            }
            else
            {
                EwsRequest = TemplateEwsRequests.UploadItems_CreateNew;
                EwsRequest = EwsRequest.Replace("##CreateAction##", "CreateNew");
            }
            EwsRequest = EwsRequest.Replace("##RequestServerVersion##", ServerVersion);
            EwsRequest = EwsRequest.Replace("##ParentFolderId_Id##", ParentFolderId.UniqueId);

            string sBase64Data = string.Empty;
            sBase64Data = EWSEditor.Common.FileHelper.GetBinaryFileAsBase64(sFile);
            System.Diagnostics.Debug.WriteLine("sBase64: " + sBase64Data);
 
            // Convert byte array to base64
            EwsRequest = EwsRequest.Replace("##Data##", sBase64Data);
 
            // Now inject the base64 body into the stream:
            try
            {

 

                byte[] bytes = Encoding.UTF8.GetBytes(EwsRequest);
                oHttpWebRequest.ContentLength = bytes.Length;

                using (Stream requestStream = oHttpWebRequest.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Flush();
                    requestStream.Close();
                }

                // Get response
                HttpWebResponse oHttpWebResponse = (HttpWebResponse)oHttpWebRequest.GetResponse();

                StreamReader oStreadReader = new StreamReader(oHttpWebResponse.GetResponseStream());
                sResponseText = oStreadReader.ReadToEnd();
 

                if (oHttpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    bSuccess = true;
                }
                else
                {

                }
            }
            finally
            {


            }

            return bSuccess;
        }

         

        /// <summary>
        /// Throw an exception if an error message is found in the response
        /// messages collection of the given response
        /// </summary>
        /// <param name="response">Response to search for errors</param>
        private static void ThrowIfResponseError(BaseResponseMessageType response)
        {
            foreach (EwsVsProxy.ResponseMessageType msg in response.ResponseMessages.Items)
            {
                if (msg.ResponseCodeSpecified && msg.ResponseCode != ResponseCodeType.NoError)
                {
                    throw new ApplicationException(msg.ResponseCode.ToString() + ": " + msg.MessageText);
                }
            }
        }

        /// <summary>
        /// Convert an EWS API ItemId type into a proxy ItemIdType object
        /// </summary>
        /// <param name="id">EWS API ItemId to convert</param>
        /// <returns>WCF proxy ItemIdType</returns>
        private static ItemIdType ConvertItemId(ItemId id)
        {
            ItemIdType proxyItemId = new ItemIdType();
            proxyItemId.Id = id.UniqueId;
            proxyItemId.ChangeKey = id.ChangeKey;

            return proxyItemId;
        }

        /// <summary>
        /// Convert an EWS API, ExchangeService object into proxy objects to be used
        /// to invoke EWS operations not implemented in the EWS API
        /// </summary>
        /// <param name="service"></param>
        /// <param name="client"></param>
        /// <param name="impersonation"></param>
        /// <param name="culture"></param>
        /// <param name="version"></param>
        private static ExchangeServiceBinding ConvertExchangeService(ExchangeService service)
        {
            var binding = new ExchangeServiceBinding();
            binding.AllowAutoRedirect = false;
            binding.Url = service.Url.AbsoluteUri;
            binding.Credentials = service.GetNetworkCredential();
            binding.UserAgent = service.UserAgent;
            binding.Timeout = service.Timeout;

            binding.ExchangeImpersonation = new ExchangeImpersonationType();
             

            if (service.UseDefaultCredentials)
            {
                binding.UseDefaultCredentials = service.UseDefaultCredentials;
            }

            // Create the ExchangeImpersonationType if needed
            if (service.ImpersonatedUserId != null)
            {
                binding.ExchangeImpersonation = new ExchangeImpersonationType();
                binding.ExchangeImpersonation.ConnectingSID = new ConnectingSIDType();
                binding.ExchangeImpersonation.ConnectingSID.Item = service.ImpersonatedUserId.Id;
                switch (service.ImpersonatedUserId.IdType)
                {
                    case ConnectingIdType.PrincipalName:
                        //binding.ExchangeImpersonation.ConnectingSID.ItemElementName = ItemChoiceType.PrincipalName;
                        binding.ExchangeImpersonation.ConnectingSID.Item = new PrincipalNameType { Value = service.ImpersonatedUserId.Id };
                        break;
                    case ConnectingIdType.SID:
                        //binding.ExchangeImpersonation.ConnectingSID.ItemElementName = ItemChoiceType.SID;
                        binding.ExchangeImpersonation.ConnectingSID.Item = new SIDType { Value = service.ImpersonatedUserId.Id };
                        break;
                    case ConnectingIdType.SmtpAddress:
                        //binding.ExchangeImpersonation.ConnectingSID.ItemElementName = ItemChoiceType.SmtpAddress;
                        binding.ExchangeImpersonation.ConnectingSID.Item = new SmtpAddressType { Value = service.ImpersonatedUserId.Id };
                        break;
                }
          
               
 
            }

            // Create a PreferredCulture if needed
            if (service.PreferredCulture != null)
            {
                binding.MailboxCulture = new MailboxCultureType();
                binding.MailboxCulture.Value = service.PreferredCulture.ToString();
            }

            // Set the RequestServerVersionValue
            binding.RequestServerVersionValue = new EwsVsProxy.RequestServerVersion();
            switch (service.RequestedServerVersion)
            {
                case ExchangeVersion.Exchange2007_SP1:
                    binding.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2007_SP1;
                    break;
                case ExchangeVersion.Exchange2010:
                    binding.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2010;
                    break;
                case ExchangeVersion.Exchange2010_SP1:
                    binding.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2010_SP1;
                    break;
                case ExchangeVersion.Exchange2010_SP2:
                    binding.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2010_SP2;
                    break;
                case ExchangeVersion.Exchange2013:
                    binding.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2013;
                    break;
                case ExchangeVersion.Exchange2013_SP1:
                    binding.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2013_SP1; 
                    break;
            }

 

            return binding;
        }
    }
}
