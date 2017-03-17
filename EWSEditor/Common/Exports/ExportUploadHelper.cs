using System;
using System.Net;
using EWSEditor.Common.Extensions;
//using EWSEditor.EwsVsProxy;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Resources;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using EWSEditor.Common;
using EWSEditor.Forms;
using EWSEditor.Forms.Controls;

namespace EWSEditor.Exchange
{ 
    public class ExportUploadHelper
    {
      

        public static bool ExportItemPost(string ServerVersion, string sItemId, string sFile)
        {
            bool bSuccess = false;
            string sResponseText = string.Empty;
            System.Net.HttpWebRequest oHttpWebRequest = null;
            EwsProxyFactory.CreateHttpWebRequest(ref oHttpWebRequest);
            oHttpWebRequest.Headers.Add("client-request-id", Guid.NewGuid().ToString());
            oHttpWebRequest.Headers.Add("return-client-request-id: ", "true"); 

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

                    try
                    {
                        oDoc.LoadXml(sResponseText);
                        //try
                        //{

                        XmlNode oData = oDoc.SelectSingleNode("//m:Data", namespaces);
                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show(ex.Message.ToString() + "\r\n\r\n" + "Response: \r\n" + sResponseText, "Error");
                        //}

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
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message.ToString() + "\r\n\r\n" + "Response: \r\n" + sResponseText, "Error");

                    }
                }
                
 
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Error");

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
            oHttpWebRequest.Headers.Add("client-request-id", Guid.NewGuid().ToString());
            oHttpWebRequest.Headers.Add("return-client-request-id: ", "true"); 

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

         
         
    }
}
