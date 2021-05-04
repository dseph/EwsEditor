﻿using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Logging
{
    public class EwsTraceListener : ITraceListener
    {
        private const string XDiagInfoHeaderName = "X-DiagInfo: ";
        private const string RequestIdHeaderName = "RequestId: ";

        public string LastDiagInfoHeader { get; private set; }
        public string LastRequestIdHeader { get; private set; }

        public void Trace(string traceType, string traceMessage)
        {
            if (traceType == "EwsResponseHttpHeaders")
            {
                string diagInfo = null;
                if (TryGetResponseHeader(traceMessage, XDiagInfoHeaderName, out diagInfo))
                {
                    DebugLog.WriteInfo("X-DiagInfo", diagInfo);
                    this.LastDiagInfoHeader = diagInfo;
                }

                string requestId = null;
                if (TryGetResponseHeader(traceMessage, RequestIdHeaderName, out requestId))
                {
                    DebugLog.WriteInfo("RequestId", requestId);
                    this.LastRequestIdHeader = requestId;
                }
            }

            if (traceType == "EwsResponseHttpHeaders" || traceType == "EwsRequestHttpHeaders")
            {
                // Make it easier to read the headers returned by changing \n to \r\n.  This will make it easier to view in the log viewer.
                string sCleaned_traceMessage = string.Empty;
                sCleaned_traceMessage = traceMessage.Replace("\r\n", "\n");
                sCleaned_traceMessage = sCleaned_traceMessage.Replace("\n", "\r\n");
                //"<Trace Tag=\"EwsRequestHttpHeaders\" Tid=\"1\" Time=\"2017-07-07 16:06:43Z\">\r\nPOST /EWS/Exchange.asmx HTTP/1.1\r\nContent-Type: text/xml; charset=utf-8\r\nAccept: text/xml\r\nUser-Agent: EWSEditor (ExchangeServicesClient/0.0.0.0)\r\nAccept-Encoding: gzip,deflate\r\nclient-request-id: c3c5dc97-9433-4b15-bfa1-8867e96e2cfd\r\nreturn-client-request-id: true\r\n\r\n\r\n</Trace>\r\n"
                sCleaned_traceMessage = sCleaned_traceMessage.Replace("\r\n\r\n\r\n</Trace>", "\r\n</Trace>");
                sCleaned_traceMessage = sCleaned_traceMessage.Replace("\r\n\r\n</Trace>", "\r\n</Trace>");
                DebugLog.WriteEwsLog(
                    traceType,
                    sCleaned_traceMessage);
 
            }
            else
            {
                DebugLog.WriteEwsLog(
                traceType,
                traceMessage);
            }
        }

        private static bool TryGetResponseHeader(string traceMessage, string headerName, out string headerValue)
        {
            headerValue = null;

            if (!traceMessage.Contains(headerName))
            {
                return false;

            }

            int start = traceMessage.IndexOf(headerName) + headerName.Length;
            int end = traceMessage.IndexOf("\n", start);

            headerValue = traceMessage.Substring(start, end - start);

            return true;
        }
    }
}
