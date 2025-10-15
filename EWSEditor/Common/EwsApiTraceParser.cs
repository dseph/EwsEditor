using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EWSEditor.Settings;

namespace EWSEditor.Common
{
    //internal class EwsApiTraceParser
    //{
    //    private static string TraceLogBeginTag
    //    {
    //        get
    //        {
    //            string beginTag = string.Empty;

    //            switch (EnvironmentInfo.EwsApiVersion)
    //            {
    //                case EwsApiVersions.OnePointZero:
    //                case EwsApiVersions.OnePointZeroHot:
    //                    beginTag = "<EwsLogEntry";
    //                    break;
    //                default:
    //                    beginTag = "<Trace";
    //                    break;
    //            }

    //            return beginTag;
    //        }
    //    }

    //    internal static string TraceLogEndTag
    //    {
    //        get
    //        {
    //            string endTag = string.Empty;

    //            switch (EnvironmentInfo.EwsApiVersion)
    //            {
    //                case EwsApiVersions.OnePointZero:
    //                case EwsApiVersions.OnePointZeroHot:
    //                    endTag = "</EwsLogEntry>";
    //                    break;
    //                default:
    //                    endTag = "</Trace>";
    //                    break;
    //            }

    //            return endTag;
    //        }
    //    }

    //    /// <summary>
    //    /// String that echoes the original message type given
    //    /// </summary>
    //    internal string OriginalTraceMessageType { get; private set; }

    //    /// <summary>
    //    /// String that echoes the original trace message given
    //    /// </summary>
    //    internal string OriginalTraceMessage { get; private set; }

    //    internal string UniqueKey { get; private set; }
    //    internal string Method { get; private set; }

    //    internal EwsApiTraceParser(string type, string message)
    //    {
    //        this.OriginalTraceMessage = message;
    //        this.OriginalTraceMessageType = type;

            
    //        this.UniqueKey = GetHeader_OnePointZero(message);
    //        this.Method = GetMethod_OnePointZero(message);

    //    }

    //    private static string GetHeader_OnePointZero(string message)
    //    {
    //        return message.Substring(0, message.IndexOf(">", 0) + 1);
    //    }

    //    private static string GetMethod_OnePointZero(string message)
    //    {
    //        string method = string.Empty;
    //        if ((message.Contains("EwsResponse") || message.Contains("EwsRequest"))
    //            && !message.Contains("EwsResponseHttpHeaders"))
    //        {
    //            if (message.Contains("<m:"))
    //            {
    //                method = message.Substring(message.IndexOf("<m:")).Replace("<m:", "").Replace(">", " ");
    //                method = method.Split(' ')[0];
    //            }
    //        }

    //        return method;
    //    }
         
    //}
}
