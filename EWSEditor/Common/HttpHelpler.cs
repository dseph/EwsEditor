using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;


//using Microsoft.Exchange.WebServices.Data

namespace EWSEditor.Common
{
    public class HttpHelper
    {
        public static bool RawHtppCall(
            string sVerb,
            string sUrl,
            string sContentType,
            CredentialCache oCrentialCache,
            string sRequestBody,

            int iTimeoutSeconds,
            bool bPragmaNoCache,
            bool bTranslateF,
            bool bAllowAutoRedirect,
            //string sUserAgent,

            ref string sResult,
            ref string sError,
            ref string sResponseStatusCode,
            ref int iResponseStatusCodeNumber,
            ref string sResponseStatusDescription 
            //ref string sAdditionalReturnValues
            )
        {
             
            string sRet = string.Empty;
            bool bSuccess = true;

            sResult = string.Empty;
            sError = string.Empty;
            sResponseStatusCode = string.Empty;
            iResponseStatusCodeNumber = 0;
            sResponseStatusDescription = string.Empty;
            //sAdditionalReturnValues = string.Empty;

            HttpWebResponse oHttpWebResponse = null;
            HttpWebRequest oHttpWebRequest = null;

 
            try
            {

                oHttpWebRequest = (HttpWebRequest)WebRequest.Create(sUrl);
                oHttpWebRequest.Method = sVerb;
                oHttpWebRequest.ContentType = sContentType;
                //oHttpWebRequest.UserAgent = sUserAgent;

                oHttpWebRequest.Timeout = 1000 * iTimeoutSeconds;


                oHttpWebRequest.Credentials = oCrentialCache;
 
                if (bTranslateF)
                    oHttpWebRequest.Headers.Add("Translate", "f");
                if (bPragmaNoCache)
                    oHttpWebRequest.Headers.Add("Pragma", "no-cache");
                oHttpWebRequest.AllowAutoRedirect = bAllowAutoRedirect;

                byte[] bytes = Encoding.UTF8.GetBytes(sRequestBody);
                oHttpWebRequest.ContentLength = bytes.Length;
                if (sRequestBody.Trim().Length != 0)
                {

                    using (Stream requestStream = oHttpWebRequest.GetRequestStream())
                    {
                        requestStream.Write(bytes, 0, bytes.Length);
                        requestStream.Flush();
                        requestStream.Close();
                    }
 
                }

                // Get response
                oHttpWebResponse = (HttpWebResponse)oHttpWebRequest.GetResponse();

                StreamReader oStreadReader = new StreamReader(oHttpWebResponse.GetResponseStream());
                sResult = oStreadReader.ReadToEnd();

                sResponseStatusCode = oHttpWebResponse.StatusCode.ToString();
                iResponseStatusCodeNumber = (int)oHttpWebResponse.StatusCode;
                sResponseStatusDescription = oHttpWebResponse.StatusDescription;

            }
            catch (Exception ex)
            {
                sError = ex.Message;

                bSuccess = false;

            }
 
            return bSuccess;


        }


    }

}
