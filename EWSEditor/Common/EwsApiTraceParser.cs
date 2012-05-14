using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EWSEditor.Settings;

namespace EWSEditor.Common
{
    internal class EwsApiTraceParser
    {
        private static string TraceLogBeginTag
        {
            get
            {
                string beginTag = string.Empty;

                switch (EnvironmentInfo.EwsApiVersion)
                {
                    case EwsApiVersions.OnePointZero:
                    case EwsApiVersions.OnePointZeroHot:
                        beginTag = "<EwsLogEntry";
                        break;
                    default:
                        beginTag = "<Trace";
                        break;
                }

                return beginTag;
            }
        }

        internal static string TraceLogEndTag
        {
            get
            {
                string endTag = string.Empty;

                switch (EnvironmentInfo.EwsApiVersion)
                {
                    case EwsApiVersions.OnePointZero:
                    case EwsApiVersions.OnePointZeroHot:
                        endTag = "</EwsLogEntry>";
                        break;
                    default:
                        endTag = "</Trace>";
                        break;
                }

                return endTag;
            }
        }

        /// <summary>
        /// String that echoes the original message type given
        /// </summary>
        internal string OriginalTraceMessageType { get; private set; }

        /// <summary>
        /// String that echoes the original trace message given
        /// </summary>
        internal string OriginalTraceMessage { get; private set; }

        internal string UniqueKey { get; private set; }
        internal string Method { get; private set; }

        internal EwsApiTraceParser(string type, string message)
        {
            this.OriginalTraceMessage = message;
            this.OriginalTraceMessageType = type;

            //// Determine the trace log version
            //switch (EnvironmentInfo.EwsApiVersion)
            //{
            //    case EwsApiVersions.OnePointOne:
            //    case EwsApiVersions.OnePointOneHot:
            //        this.UniqueKey = GetHeader_OnePointZero(message);
            //        this.Method = GetMethod_OnePointZero(message);
            //        break;
            //    case EwsApiVersions.OnePointZero:
            //    case EwsApiVersions.OnePointZeroHot:
            //        this.UniqueKey = GetHeader_OnePointZero(message);
            //        this.Method = GetMethod_OnePointZero(message);
            //        break;
            //    default:
            //        this.UniqueKey = string.Empty;
            //        this.Method = string.Empty;
            //        break;
            //}
            
            this.UniqueKey = GetHeader_OnePointZero(message);
            this.Method = GetMethod_OnePointZero(message);

        }

        private static string GetHeader_OnePointZero(string message)
        {
            return message.Substring(0, message.IndexOf(">", 0) + 1);
        }

        private static string GetMethod_OnePointZero(string message)
        {
            string method = string.Empty;
            if ((message.Contains("EwsResponse") || message.Contains("EwsRequest"))
                && !message.Contains("EwsResponseHttpHeaders"))
            {
                if (message.Contains("<m:"))
                {
                    method = message.Substring(message.IndexOf("<m:")).Replace("<m:", "").Replace(">", " ");
                    method = method.Split(' ')[0];
                }
            }

            return method;
        }

        //private static string LogEWSChatter(string message)
        //{
        //    // Parse out the text to be used as the header
        //    if (message.StartsWith(Constants.TraceLogBeginTag))
        //    {

        //        CurrentHeaders.Add(header, method);

        //        // Write the message to the EWSChatter log
        //        File.AppendAllText(ChatterLogFilePath, message);

        //        // Write the header to the EWSEditor log as well to match
        //        // up EWSChatter to the application logs
        //        if (method.Length > 0)
        //        {
        //            TraceHelper.WriteInfo(String.Format("Header: {0} | Method: {1}", header, method));
        //        }
        //        else
        //        {
        //            TraceHelper.WriteInfo(String.Format("Header: {0}", header));
        //        }

        //        return header;
        //    }
        //    else
        //    {
        //        TraceHelper.WriteVerbose(String.Format("The following message could not be parsed\n'{0}'", message));
        //        throw new ArgumentException("Could not parse trace message");
        //    }
        //}
    }
}
