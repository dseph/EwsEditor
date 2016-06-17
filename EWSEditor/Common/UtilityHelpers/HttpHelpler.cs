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
        public static bool HtppCall(
            string sVerb,
            string sUrl,
            string sContentType,
            string sAuthentication,
            string User, 
            string Password, 
            string Domain, 

            List<KeyValuePair<string, string>> oHeadersList,
            WebProxy oWebProxy,
            string sRequestBody,

            //string sProxyServer,
            //int iProxyPort,

            int iTimeoutSeconds,
            bool bPragmaNoCache,
            bool bTranslateF,
            bool bAllowAutoRedirect,
            string sUserAgent,

            ref string sRequestHeaders,
            ref string sResult,
            ref string sResponeHeaders,

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

            string sHeader = string.Empty;

            HttpWebResponse oHttpWebResponse = null;
            HttpWebRequest oHttpWebRequest = null;

            string sErrorBody = string.Empty;  // body of response gathered in thrown error
 
            try
            {

                oHttpWebRequest = (HttpWebRequest)WebRequest.Create(sUrl);
                oHttpWebRequest.Method = sVerb;
                oHttpWebRequest.ContentType = sContentType;
                if (sUserAgent.TrimEnd().Length != 0)
                    oHttpWebRequest.UserAgent = sUserAgent.TrimEnd();

                oHttpWebRequest.Timeout = 1000 * iTimeoutSeconds;

                // Set Credentials
                SetCredentials(
                        ref oHttpWebRequest,
                        sAuthentication,
                        User,
                        Password,
                        Domain,
                        sUrl
                    );
 
 
                if (bTranslateF)
                    oHttpWebRequest.Headers.Add("Translate", "f");
                if (bPragmaNoCache)
                    oHttpWebRequest.Headers.Add("Pragma", "no-cache");

                if (oWebProxy != null)
                    oHttpWebRequest.Proxy = oWebProxy;

                // Add Additional Headers:
                SetRequestHeaders(ref oHttpWebRequest, oHeadersList);
 
 
                oHttpWebRequest.AllowAutoRedirect = bAllowAutoRedirect;

                // Add body to request
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

                // =============================================
                // Do the EWS call:

                Encoding oEncoding = System.Text.Encoding.GetEncoding("utf-8");
                oHttpWebResponse = (HttpWebResponse)oHttpWebRequest.GetResponse();
                StreamReader oStreadReader = new StreamReader(oHttpWebResponse.GetResponseStream(), oEncoding);
                sResult = oStreadReader.ReadToEnd();

                // ============================================

 
            }
            catch (WebException ex)
            {
                sError = ex.Message.ToString();

                using (Stream oStream = ex.Response.GetResponseStream())
                using (StreamReader reader = new StreamReader(oStream))
                {
                    sResult = reader.ReadToEnd() + "\r\n";
                }
              
                bSuccess = false;
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                sError = ex.Message.ToString();
                bSuccess = false;
            }
            catch (Exception ex)
            {
                sError = ex.Message.ToString();
                bSuccess = false;
            }
            finally 
            {

                // Get Request headers:                
                if (oHttpWebRequest != null)
                {
                    if (oHttpWebRequest.Headers != null)
                    {
                        StringBuilder oSB_RequestHeaders = new StringBuilder();
                        //for (int i = 0; i < oHttpWebRequest.Headers.Count; ++i)
                        //{

                            foreach (string key in oHttpWebRequest.Headers.AllKeys)
                            {
                                sHeader = string.Format("    {0}: {1}", key, oHttpWebRequest.Headers[key]);
                                oSB_RequestHeaders.AppendLine(sHeader);
                            }
                        //}
                        sRequestHeaders = oSB_RequestHeaders.ToString();
                    }
                }

               // Get Response headers:
                if (oHttpWebResponse != null)
                {
                    if (oHttpWebResponse.Headers != null)
                    {
                        StringBuilder oSB_ResponseHeaders = new StringBuilder();
                        //for (int i = 0; i < oHttpWebResponse.Headers.Count; ++i)
                        //{

                            foreach (string key in oHttpWebResponse.Headers.AllKeys)
                            {
                                sHeader = string.Format("    {0}: {1}", key, oHttpWebResponse.Headers[key]);
                                oSB_ResponseHeaders.AppendLine(sHeader);
                            }
                        //}
                        sResponeHeaders = oSB_ResponseHeaders.ToString();
                    }
                }

                if (oHttpWebResponse != null)
                {
                    sResponseStatusCode = oHttpWebResponse.StatusCode.ToString();
                    iResponseStatusCodeNumber = (int)oHttpWebResponse.StatusCode;
                    sResponseStatusDescription = oHttpWebResponse.StatusDescription;
                }
 
            }
            // System.Net.Sockets.SocketException

            //try { HttpWebRequest x; oHttpWebRequest.GetResponse(); }
            //catch (exce xx) { };


 
            return bSuccess;


        }

        // GetPropertySetHeadersList - Gets list of headers which are set on the HttpWebRequest 
        // via properties rather than setting them by adding to the headers collection.
        private static List<string> GetPropertySetHeadersList()
        {
            List<string> oHeadersList = new List<string>();
            oHeadersList.Add("Accept".ToUpper());
            oHeadersList.Add("Connection".ToUpper());
            oHeadersList.Add("Content-Length".ToUpper());
            oHeadersList.Add("Content-Type".ToUpper());
            oHeadersList.Add("Expect".ToUpper());
            oHeadersList.Add("Date".ToUpper());
            oHeadersList.Add("Host".ToUpper());
            oHeadersList.Add("If-Modified-Since".ToUpper());
            oHeadersList.Add("Range".ToUpper());
            oHeadersList.Add("Referrer".ToUpper());
            oHeadersList.Add("Transfer-Encoding".ToUpper());
            oHeadersList.Add("User-Agent".ToUpper());

            return oHeadersList;
        }

        public static bool DoHttpWebRequest(
                ref HttpWebRequest oHttpWebRequest,
                ref string sRequestHeaders,
                ref string sResult,
                ref string sResponeHeaders,

                ref string sError,
                ref string sResponseStatusCode,
                ref int iResponseStatusCodeNumber,
                ref string sResponseStatusDescription  
            )
        {
            bool bRet = false;
             
            HttpWebResponse oHttpWebResponse = null;
            string sHeader = string.Empty;

            try
            { 
                oHttpWebResponse = (HttpWebResponse)oHttpWebRequest.GetResponse();
                StreamReader oStreadReader = new StreamReader(oHttpWebResponse.GetResponseStream());
                sResult = oStreadReader.ReadToEnd();
                bRet = true;
            }
            catch (WebException ex)
            {
                sError = ex.Message.ToString();
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                sError = ex.Message.ToString();
            }
            catch (Exception ex)
            {
                sError = ex.Message.ToString();
            }
            finally 
            {
                // Get Request headers:                
                if (oHttpWebRequest != null)
                {
                    if (oHttpWebRequest.Headers != null)
                    {
                        StringBuilder oSB_RequestHeaders = new StringBuilder();
                        //for (int i = 0; i < oHttpWebRequest.Headers.Count; ++i)
                        //{

                        foreach (string key in oHttpWebRequest.Headers.AllKeys)
                        {
                            sHeader = string.Format("    {0}: {1}", key, oHttpWebRequest.Headers[key]);
                            oSB_RequestHeaders.AppendLine(sHeader);
                        }
                        //}
                        sRequestHeaders = oSB_RequestHeaders.ToString();
                    }
                }


               // Get Response headers:
                if (oHttpWebResponse != null)
                {
                    if (oHttpWebResponse.Headers != null)
                    {
                        StringBuilder oSB_ResponseHeaders = new StringBuilder();
                        //for (int i = 0; i < oHttpWebResponse.Headers.Count; ++i)
                        //{

                            foreach (string key in oHttpWebResponse.Headers.AllKeys)
                            {
                                sHeader = string.Format("    {0}: {1}", key, oHttpWebResponse.Headers[key]);
                                oSB_ResponseHeaders.AppendLine(sHeader);
                            }
                        //}
                        sResponeHeaders = oSB_ResponseHeaders.ToString();
                    }
                }

                if (oHttpWebResponse != null)
                {
                    sResponseStatusCode = oHttpWebResponse.StatusCode.ToString();
                    iResponseStatusCodeNumber = (int)oHttpWebResponse.StatusCode;
                    sResponseStatusDescription = oHttpWebResponse.StatusDescription;
                }
 
            }

            return bRet;
 
        }

        public static HttpWebRequest EntirePostRequestToHttpWebRequest(
                string sRequest, 
                string sAuthentication,
                string sUser,
                string sPassword,
                string sDomain,
                WebProxy oWebProxy
            )
        {
            HttpWebRequest oHttpWebRequest = null;
            string sUseWholeText = string.Empty;
            sUseWholeText = sRequest.Replace("\r\n", "\n");
            sUseWholeText = sUseWholeText.Replace("\r", "\n");
            sUseWholeText = sUseWholeText.Replace("\n", "\r\n");
            string[] sArrSplit = { "\r\n" };
            string[] sArr;


            sArr = sUseWholeText.Split(sArrSplit, StringSplitOptions.None);
            bool bProcessingHeaders = false;
            bool bProcessingBody = false;
            bool bIsFirstLine = true;
            
            string sFirstLine = string.Empty;
            StringBuilder sbBody = new StringBuilder();
            List<string> listHeaders = new List<string>();

            foreach (string sLine in sArr)
            {
                if (bIsFirstLine)
                {
                    sFirstLine = sLine.Trim();  // Should be like: POST https://outlook.office365.com/EWS/Exchange.asmx  
                    bIsFirstLine = false;
                    bProcessingHeaders = true;
                    bProcessingBody = false;
                }
                else
                {
                    // We should be past the first line....

                    // Check for blank line - it means we are going from the headers to the body.
                    if (sLine.Trim().Length == 0 && bProcessingHeaders == true)
                    {

                        // shold be at empty line which seperates headers from body
                        bProcessingHeaders = false;
                        bProcessingBody = true;
                        // bReachedBlankLineAfterPostLine = false;
                    }
                    else
                    {
                        // Now we are either processing the headers or the body...

                        if (bProcessingHeaders == true)
                        {
                            listHeaders.Add(sLine);
                        }

                        if (bProcessingBody == true)
                        {
                            sbBody.AppendLine(sLine);
                        }
                    }
                }

            }

            // sFirstLine - holds the first line
            // listHeaders  holds the headers.
            // sbBody  - holds the body

            // First line:
            string[] sFirstLineArrSplit = {" "};
            string[] sFirstLineArr;
            sFirstLineArr = sFirstLine.Split(sFirstLineArrSplit, StringSplitOptions.None);
            string sVerb = sFirstLineArr[0];
            string sURL = sFirstLineArr[1];
            oHttpWebRequest = (HttpWebRequest)WebRequest.Create(sURL);
            oHttpWebRequest.Method = sVerb;


            // Set Credentials
            SetCredentials(
                ref oHttpWebRequest,
                sAuthentication,
                sUser,
                sPassword,
                sDomain,
                sURL
                );
 

            // Headers:
            char[] sHeadereArrSplit = {':'};
            string[] sHeaderLineArr;
            string sKey = string.Empty;
            string sValue = string.Empty;
            List<KeyValuePair<string, string>> oHeadersList = new List<KeyValuePair<string, string>>();
            foreach (string sHeader in listHeaders)
            {
                 
                sHeaderLineArr = sHeader.Split(sHeadereArrSplit);
                sKey = sHeaderLineArr[0];
                sValue = sHeaderLineArr[1].TrimStart();
                oHeadersList.Add(new KeyValuePair<string, string>(sKey, sValue));

            }
            SetRequestHeaders(ref oHttpWebRequest, oHeadersList);

            // Change proxy settings?
            if (oWebProxy != null)
                oHttpWebRequest.Proxy = oWebProxy;

            // Add body to request
            string sRequestBody = sbBody.ToString();
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

            return oHttpWebRequest;

        }

        private static void SetCredentials(ref HttpWebRequest oHttpWebRequest, string sAuthentication, string User, string Password, string Domain, string Url)
        {
            NetworkCredential oNetworkCredential = null;
            CredentialCache oCredentialCache = null;

            oCredentialCache = new CredentialCache();

            Uri oUri = new Uri(Url);

            switch (sAuthentication)
            {
                case "Anonymous":
                    oCredentialCache = null;
                    break;
                case "DefaultNetworkCredentials":
                    oHttpWebRequest.Credentials = CredentialCache.DefaultNetworkCredentials;
                    break;
                case "DefaultCredentials":
                    oHttpWebRequest.Credentials = CredentialCache.DefaultCredentials;
                    break;
                case "Basic":
                case "NTLM":
                case "Digest":
                case "Kerberos":
                case "Negotiate":
                    if (Domain.Trim().Length == 0)
                        oNetworkCredential = new NetworkCredential(User, Password);
                    else
                        oNetworkCredential = new NetworkCredential(User, Password, Domain);
                    oCredentialCache.Add(oUri, sAuthentication, oNetworkCredential);
                    oHttpWebRequest.Credentials = oCredentialCache;
                    break;
                default:
                    break;
            }

            // http://msdn.microsoft.com/en-us/library/59x2s2s6(v=vs.110).aspx
        }

        public static void SetRequestHeaders(ref HttpWebRequest oHttpWebRequest, List<KeyValuePair<string, string>> oHeadersList)
        {
            
            // Add Additional Headers:
            //List<string> oPropertySetHeaders = (List<string>)GetPropertySetHeadersList();
            IFormatProvider oCulture = new System.Globalization.CultureInfo("en-US", true);
            string sKey = string.Empty;
            //// http://msdn.microsoft.com/en-us/library/system.net.httpwebrequest(v=vs.110).aspx
            foreach (KeyValuePair<string, string> k in oHeadersList)
            {
          
                sKey = k.Key.ToUpper();
                //if (oPropertySetHeaders.Contains(sKey) == false)
                //{
                //    oHttpWebRequest.Headers.Add(k.Key, k.Value);
                //}
                //else
                //{
                // Note: Every header which maps to a header property on the httpswebrequest object needs to be in this select statement.
                //       This article has a table containing that list: http://msdn.microsoft.com/en-us/library/system.net.httpwebrequest(v=vs.110).aspx
                switch (sKey)
                {
                    //case "AUTHORIZATION":  // This needs to be set on the object by user entered data.
                    //    break;
                    case "CONNECTION":
                        oHttpWebRequest.Connection = k.Value;
                        break;
                    case "CONTENT-LENGTH":
                        oHttpWebRequest.ContentLength = Convert.ToUInt32(Convert.ToUInt32(k.Value));
                        break;
                    case "CONTENT-TYPE":
                        oHttpWebRequest.ContentType = k.Value;
                        break;
                    case "EXPECT":
                        //oHttpWebRequest.Expect =  k.Value;
                        break;
                    case "DATE":
                        DateTime oDtDate = DateTime.Parse(k.Value, oCulture, System.Globalization.DateTimeStyles.AssumeLocal);
                        oHttpWebRequest.Date = oDtDate;
                        break;
                    case "HOST":
                        oHttpWebRequest.Host = k.Value;
                        break;
                    case "IF-MODIFIED-SINCE":
                        DateTime oDtIfModifiedSince = DateTime.Parse(k.Value, oCulture, System.Globalization.DateTimeStyles.AssumeLocal);
                        oHttpWebRequest.IfModifiedSince = oDtIfModifiedSince;
                        break;
                    case "RANGE":
                        oHttpWebRequest.AddRange(Convert.ToUInt32(Convert.ToUInt32(k.Value)));
                        break;
                    case "REFERRER":
                        oHttpWebRequest.Referer = k.Value;
                        break;
                    case "TRANSFER-ENCODING":
                        oHttpWebRequest.TransferEncoding = k.Value;
                        break;
                    case "USER-AGENT":
                        oHttpWebRequest.UserAgent = k.Value;
                        break;
                    default:
                        oHttpWebRequest.Headers.Add(k.Key, k.Value);
                        break;

                }
 
            }

        }

        // Public Function DoRawDavCall(ByVal sRawText As String) As String
        //    Dim sBuildRawRequest As String = ""
        //    Dim HttpWRequest As System.Net.HttpWebRequest = Nothing
        //    'Dim HttpWRequest As System.Net.HttpWebRequest = Nothing
        //    Dim myUri As System.Uri = Nothing
        //    Dim sText As String = ""
        //    Dim sRequestText As String = ""

        //    Dim sURI As String = ""
        //    Dim strBody As String = ""
        //    Dim sCommand As String = ""
        //    Dim sContentType As String = ""

        //    Dim PartProcessing As String = "Top"

        //    Dim sRangeArr() As String
        //    Dim sRangeParts() As String
        //    Dim sRangeItem As String = ""
        //    Dim iRangePartCounter As Integer
        //    Dim saRange() As String
        //    Dim sRangeFrom As String = ""
        //    Dim sRangeTo As String = ""

        //    Dim sArr() As String
        //    Dim sLine As String = ""
        //    Dim sLinePart() As String
        //    Dim iCounter As Integer = 0
        //    Dim bTopDone As Boolean = False
        //    Dim bDoneProcessingRawText As Boolean = False
        //    Dim sUseText As String = ""
        //    Dim sHeaderItem As String = ""
        //    Dim sHeaderValue As String = ""

        //    If m_Connection.FbaHadError = True Then   ' Had an FBA Failure!
        //        Return ""  ' Skip it!
        //    End If

        //    sUseText = sRawText.Replace(vbCrLf, vbLf)
        //    sUseText = sUseText.Replace(vbCr, vbLf)
        //    sUseText = sUseText.Replace(vbLf, vbCrLf)

        //    sArr = sUseText.Split(vbCrLf)
        //    Dim iLower As Integer = sArr.GetLowerBound(0)
        //    Dim iUpper As Integer = sArr.GetUpperBound(0)
        //    For iCounter = iLower To iUpper
        //        sLine = sArr(iCounter)
        //        If PartProcessing = "Top" And bTopDone = True Then
        //            PartProcessing = "Headers"
        //        End If
        //        If PartProcessing = "Headers" And sLine.Trim = "" Then
        //            PartProcessing = "Body"
        //        End If

        //        If sLine <> "" Then
        //            If PartProcessing = "Top" And bTopDone = False Then
        //                sLinePart = sLine.Split(" ".ToCharArray())
        //                sCommand = sLinePart(0).ToString
        //                sURI = sLinePart(1).ToString

        //                ' ----------- Initialize request object ---------
        //                Try
        //                    myUri = New System.Uri(sURI)
        //                Catch exa As Exception
        //                    sText = exa.ToString
        //                    LastWebDavResponse.ResponseText = sText
        //                    LastWebDavResponse.StatusDescription = exa.Message
        //                    LastWebDavResponse.HadError = True
        //                    Return "" ' Return sText
        //                End Try

        //                Try
        //                    HttpWRequest = CType(WebRequest.Create(myUri), HttpWebRequest)

        //                Catch exb As Exception
        //                    sText = exb.ToString
        //                    LastWebDavResponse.ResponseText = sText
        //                    LastWebDavResponse.StatusDescription = exb.Message
        //                    'LastWebDavResponse.ErrorMessage = exb.Message
        //                    LastWebDavResponse.HadError = True
        //                    Return "" ' Return sText
        //                End Try
        //                HttpWRequest.Method = sCommand
        //                HttpWRequest.KeepAlive = True
        //                HttpWRequest.Timeout = 300000 'set the request timeout to 5 min.
        //                bTopDone = True
        //            End If
        //            If PartProcessing = "Headers" And bTopDone = True Then
        //                sLinePart = sLine.Split(" ".ToCharArray())
        //                sHeaderItem = sLinePart(0).Trim
        //                sHeaderValue = sLinePart(1).Trim
        //                If sHeaderItem.EndsWith(":") Then
        //                    sHeaderItem = sHeaderItem.Remove(sHeaderItem.Length - 1, 1)
        //                End If
        //                If sHeaderItem = "" Then MsgBox("Header not formatted correctly")
        //                If sHeaderValue = "" Then MsgBox("Header value not formatted correctly")

        //                Select Case sHeaderItem.ToUpper
        //                    Case "Accept".ToUpper
        //                        Try
        //                            HttpWRequest.Accept = sHeaderValue
        //                        Catch exAccept As Exception
        //                            MsgBox("Error setting Accept header: " & exAccept.Message)
        //                        End Try
        //                    Case "Connection".ToUpper
        //                        Try
        //                            HttpWRequest.Connection = sHeaderValue ' Connection: Keep-Alive
        //                        Catch exConnection As Exception
        //                            MsgBox("Error setting Connection header: " & exConnection.Message)
        //                        End Try
        //                        HttpWRequest.Connection = sHeaderValue
        //                        ''Try
        //                        ''    If sHeaderValue.ToUpper.StartsWith("T") Then
        //                        ''        HttpWRequest.Connection = True
        //                        ''    End If
        //                        ''    If sHeaderValue.ToUpper.StartsWith("F") Then
        //                        ''        HttpWRequest.Connection = False
        //                        ''    End If
        //                        ''Catch exConnection As Exception
        //                        ''    MsgBox("Error setting Connection header: " & exConnection.Message)
        //                        ''End Try
        //                    Case "Content-Length".ToUpper   ' Content-Length: 10522
        //                        Try
        //                            HttpWRequest.ContentLength = CInt(sHeaderValue)
        //                        Catch exContentLength As Exception
        //                            MsgBox("Error setting Content-Length header: " & exContentLength.Message)
        //                        End Try
        //                    Case "Content-Type".ToUpper  ' Content-Type: text/xml
        //                        Try
        //                            HttpWRequest.ContentType = sHeaderValue ' "text/xml" , "message/rfc822", etc
        //                            sContentType = sHeaderValue
        //                        Catch exContentType As Exception
        //                            MsgBox("Error setting Content-Type header: " & exContentType.Message)
        //                        End Try
        //                    Case "Expect".ToUpper
        //                        Try
        //                            HttpWRequest.Expect = sHeaderValue
        //                        Catch exExpect As Exception
        //                            MsgBox("Error setting Expect header: " & exExpect.Message)
        //                        End Try
        //                    Case "Date".ToUpper ' Date: Wed, 03 Jun 2009 22:36:11 GMT
        //                        MsgBox("'Date' header mapping to request is not implemented. ")
        //                        'This is set to the currentsystem date
        //                    Case "Host".ToUpper
        //                        'This is set to the current system host 
        //                        ' the host is server the call is going against.
        //                        MsgBox("'Host' header mapping to request is not implemented. ")
        //                    Case "If-Modified-Since".ToUpper
        //                        Try
        //                            HttpWRequest.IfModifiedSince = CDate(sHeaderValue)
        //                        Catch exIfModifiedSince As Exception
        //                            MsgBox("Error setting If-Modified-Since header: " & exIfModifiedSince.Message)
        //                        End Try
        //                    Case "Range".ToUpper
        //                        Try
        //                            sRangeParts = sHeaderValue.Split("=".ToCharArray())
        //                            sRangeArr = sRangeParts(1).Split(",".ToCharArray())

        //                            For iRangePartCounter = sRangeArr.GetLowerBound(0) To sRangeArr.GetUpperBound(0)
        //                                If sRangeArr(iRangePartCounter).Trim.StartsWith("-") Then
        //                                    HttpWRequest.AddRange("rows", CInt(sRangeArr(iRangePartCounter).Trim)) ' 2
        //                                Else
        //                                    saRange = sRangeArr(iRangePartCounter).Split("-".ToCharArray())
        //                                    sRangeFrom = saRange(0)
        //                                    sRangeTo = saRange(1)
        //                                    HttpWRequest.AddRange("rows", CInt(sRangeFrom), CInt(sRangeTo)) ' 1
        //                                End If
        //                            Next
        //                            ' rows=20-39
        //                            ' rows=20-39,10-15,20-25
        //                            ' rows=-50
        //                            ' rows=20-39,-70
        //                            ' rows=20-39
        //                        Catch exRange As Exception
        //                            MsgBox("Error setting Range header: " & exRange.Message)
        //                        End Try

        //                    Case "Referer".ToUpper
        //                        Try
        //                            HttpWRequest.Referer = sHeaderValue
        //                        Catch exReferer As Exception
        //                            MsgBox("Error setting Referer header: " & exReferer.Message)
        //                        End Try
        //                    Case "Transfer-Encoding".ToUpper
        //                        Try
        //                            'HttpWRequest.SendChunked = True
        //                            HttpWRequest.TransferEncoding = sHeaderValue ' "text/xml" , "message/rfc822", etc
        //                        Catch exTransferEncoding As Exception
        //                            MsgBox("Error setting Transfer-Encoding header: " & exTransferEncoding.Message)
        //                        End Try
        //                    Case "User-Agent".ToUpper
        //                        ' HttpWRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; InfoPath.1)"
        //                        Try
        //                            HttpWRequest.UserAgent = sHeaderValue
        //                        Catch exUserAgent As Exception
        //                            MsgBox("Error setting User-Agent header: " & exUserAgent.Message)
        //                        End Try
        //                    Case "Proxy-Connection"
        //                        'xxxxx
        //                        MsgBox("'Proxy-Connection' header mapping to request not implemented.")
        //                    Case Else
        //                        Try
        //                            HttpWRequest.Headers.Set(sHeaderItem, sHeaderValue.ToString)
        //                        Catch exElse As Exception
        //                            MsgBox("Error setting " & sHeaderItem & " header: " & exElse.Message)
        //                        End Try
        //                End Select

        //            End If

        //            If PartProcessing = "Body" Then
        //                Dim iStart As Integer
        //                Dim iEnd As Integer
        //                Dim iBPLineCount As Integer
        //                iStart = iCounter
        //                iEnd = sArr.GetUpperBound(0)
        //                strBody = ""
        //                For iBPLineCount = iStart To iEnd
        //                    strBody &= sArr(iBPLineCount)
        //                Next
        //                If sCommand.ToUpper <> "PUT" And sCommand <> "GET" Then
        //                    strBody = strBody.Trim
        //                End If
        //                bDoneProcessingRawText = True
        //            End If
        //        End If
        //        If bDoneProcessingRawText = True Then
        //            Exit For
        //        End If
        //    Next

        //    ' ----------- Set starting LastWebDavResponse values ---------
        //    LastWebDavResponse.Reset()
        //    LastWebDavResponse.UserID = m_Connection.UserName
        //    LastWebDavResponse.Domain = m_Connection.Domain
        //    LastWebDavResponse.AuthenticationType = m_Connection.AuthenticationType.ToString
        //    LastWebDavResponse.HREF = m_Connection.BaseURI
        //    LastWebDavResponse.ContentType = sContentType
        //    LastWebDavResponse.Verb = sCommand
        //    LastWebDavResponse.RequestText = strBody
        //    LastWebDavResponse.RequestDateTime = Now.ToString
        //    'LastWebDavResponse.RequestText = strBody

        //    sBuildRawRequest = ""
        //    sBuildRawRequest = sCommand & " " & sURI & " HTTP/" & HttpWRequest.ProtocolVersion.ToString & vbLf
        //    sBuildRawRequest &= HttpWRequest.Headers.ToString
        //    sBuildRawRequest &= strBody
        //    LastWebDavResponse.RawRequest = sBuildRawRequest



        //    '--------------------------- Set Credentials --------------------------------------
        //    Dim myCred As NetworkCredential
        //    Dim MyCredentialCache As CredentialCache
        //    Select Case m_Connection.AuthenticationType
        //        Case AuthenticationTypes.Basic
        //            If m_Connection.Domain.Trim.Length = 0 Then
        //                myCred = New NetworkCredential(m_Connection.UserName, m_Connection.Password)
        //            Else
        //                myCred = New NetworkCredential(m_Connection.UserName, m_Connection.Password, m_Connection.Domain)
        //            End If
        //            MyCredentialCache = New CredentialCache
        //            MyCredentialCache.Add(myUri, "Basic", myCred)
        //            HttpWRequest.Credentials = MyCredentialCache
        //        Case AuthenticationTypes.NTLM
        //            If m_Connection.Domain.Trim.Length = 0 Then
        //                myCred = New NetworkCredential(m_Connection.UserName, m_Connection.Password)
        //            Else
        //                myCred = New NetworkCredential(m_Connection.UserName, m_Connection.Password, m_Connection.Domain)
        //            End If
        //            ' myCred = New NetworkCredential("xxxxx", m_Connection.Password, "northamerica")
        //            MyCredentialCache = New CredentialCache
        //            MyCredentialCache.Add(myUri, "NTLM", myCred)
        //            HttpWRequest.Credentials = MyCredentialCache
        //        Case AuthenticationTypes.Windows
        //            HttpWRequest.Credentials = CredentialCache.DefaultCredentials
        //        Case AuthenticationTypes.FBA
        //            'MsgBox(m_Connection.AuthenticationType.ToString & " Not Implemented as yet")
        //            'HttpWRequest.Credentials = CredentialCache.DefaultCredentials
        //            Dim strPassedCookies As String
        //            If m_Connection.strReusableCookies.Trim.Length = 0 Then
        //                strPassedCookies = m_Connection.FBACookies() ' Get new cookies
        //                If strPassedCookies = "Error" Then
        //                    ' had an error getting the cookie!
        //                    LastWebDavResponse.ResponseText = m_Connection.FbaResponseText
        //                    LastWebDavResponse.StatusDescription = m_Connection.FbaStatusDescription
        //                    LastWebDavResponse.HadError = True
        //                    If m_Connection.LoggingEnabled = True Then
        //                        LastWebDavResponse.SaveToLogfile(m_Connection.LogFilePath)
        //                    End If
        //                    strPassedCookies = ""  ' Reset
        //                    m_Connection.strReusableCookies = "" ' Reset
        //                    Return ""
        //                Else
        //                    ' No errors getting the cookie
        //                    m_Connection.strReusableCookies = strPassedCookies ' Use New Cookies
        //                End If
        //            Else
        //                strPassedCookies = m_Connection.strReusableCookies ' Use Existing cookies
        //            End If
        //            HttpWRequest.Headers.Add("Cookie", strPassedCookies)
        //            HttpWRequest.ContentType = "text/xml"
        //            HttpWRequest.KeepAlive = True
        //            HttpWRequest.AllowAutoRedirect = False

        //        Case AuthenticationTypes.Certificate
        //            MsgBox(m_Connection.AuthenticationType.ToString & " Not Implemented as yet")
        //        Case AuthenticationTypes.None
        //            'MsgBox(m_Connection.AuthenticationType.ToString & " Unknown authentication type")
        //    End Select



        //    Select Case sCommand
        //        Case "OPTIONS"
        //        Case "GET"
        //        Case "MOVE"
        //            'HttpWRequest.Headers.Set("Destination", strBody)
        //        Case "COPY"
        //            'HttpWRequest.Headers.Set("Destination", strBody)
        //        Case Else
        //            '  PUT, PROPFIND, PROPPATCH, SEARCH - verbs with arguments.
        //            Select Case sCommand
        //                Case "PROPFIND"
        //                    ''HttpWRequest.Headers.Set("Depth", "0")
        //                Case "BPROPFIND"
        //                    'HttpWRequest.Headers.Set("Depth", "0")
        //                    ' HttpWRequest.Headers.Set("Brief", "t") ' Don't report 404 - not found
        //                Case "SEARCH"
        //                    'HttpWRequest.Headers.Set("Depth", "0")
        //                Case Else
        //            End Select

        //            ' Add on the body of the request...

        //            HttpWRequest.ContentLength = strBody.Length
        //            ' we need to store the Request data into a byte array
        //            Dim ByteQuery() As Byte = System.Text.Encoding.ASCII.GetBytes(strBody)
        //            HttpWRequest.ContentLength = ByteQuery.Length

        //            Dim QueryStream As Stream
        //            Try
        //                QueryStream = HttpWRequest.GetRequestStream() ' *** Do the call
        //            Catch exqs As Exception
        //                sText = exqs.ToString
        //                LastWebDavResponse.ResponseText = sText
        //                LastWebDavResponse.StatusDescription = exqs.Message
        //                LastWebDavResponse.HadError = True
        //                If m_Connection.LoggingEnabled = True Then
        //                    LastWebDavResponse.SaveToLogfile(m_Connection.LogFilePath)
        //                End If
        //                sText = ""
        //                Return "" 'Return sText
        //            End Try

        //            ' write the data to be posted to the Request Stream
        //            QueryStream.Write(ByteQuery, 0, ByteQuery.Length)
        //            QueryStream.Close()
        //    End Select

        //    If m_Connection.LoggingEnabled = True Then
        //        If HttpWRequest.Connection <> Nothing Then
        //            sRequestText &= "  Request Connection: " & HttpWRequest.Connection.ToString & vbCrLf
        //        End If
        //        If HttpWRequest.Headers.Count <> 0 Then
        //            sRequestText &= "  Request Headers: " & HttpWRequest.Headers.ToString & vbCrLf
        //        End If
        //    End If
        //    LastWebDavResponse.RequestText = sRequestText

        //    Dim HttpWResponse As HttpWebResponse '  HttpWebResponse
        //    Dim iStatCode As Integer = 0
        //    Dim sStatus As String = ""
        //    Try
        //        ' Send Request and Get Response
        //        HttpWResponse = HttpWRequest.GetResponse()

        //        ' Get Status and Headers
        //        iStatCode = HttpWResponse.StatusCode
        //        'string strMe = Response.StatusCode.ToString();
        //        sStatus = iStatCode.ToString()

        //        LastWebDavResponse.StatusCode = HttpWResponse.StatusCode.ToString
        //        LastWebDavResponse.StatusDescription = HttpWResponse.StatusDescription
        //        LastWebDavResponse.ResponseHeaders = HttpWResponse.Headers.ToString

        //        Dim strm As Stream = HttpWResponse.GetResponseStream()

        //        Dim sr As StreamReader = New StreamReader(strm) ' Read the Response Steam
        //        sText = sr.ReadToEnd()
        //        'LastWebDavResponse.ResponseStream = strm ' Only set for testing
        //        strm.Close()    ' Close Stream
        //        If m_Connection.LoggingEnabled = True Then
        //            LastWebDavResponse.SaveToLogfile(m_Connection.LogFilePath)
        //        End If
        //        sr = Nothing
        //        strm = Nothing
        //    Catch ex As Exception

        //        sText = ex.ToString
        //        LastWebDavResponse.ResponseText = sText
        //        LastWebDavResponse.StatusDescription = ex.Message
        //        LastWebDavResponse.HadError = True
        //        If m_Connection.LoggingEnabled = True Then
        //            LastWebDavResponse.SaveToLogfile(m_Connection.LogFilePath)
        //        End If
        //        sText = ""
        //        Return ""
        //    End Try
        //    ' Clean Up
        //    HttpWRequest = Nothing
        //    HttpWResponse = Nothing
        //    MyCredentialCache = Nothing
        //    myCred = Nothing

        //    LastWebDavResponse.HadError = False
        //    LastWebDavResponse.ResponseText = sText
        //    If m_Connection.LoggingEnabled = True Then
        //        LastWebDavResponse.SaveToLogfile(m_Connection.LogFilePath)
        //    End If

        //    Return sText
        //End Function





    }

}
