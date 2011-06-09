namespace EWSEditor.Diagnostics
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Microsoft.Exchange.WebServices.Data;

    using EWSEditor.Common;

    /// <summary>
    /// Handles the recording of SOAP message traffic between
    /// EWSEditor and Exchange servers.
    /// </summary>
    public class EWSEditorTraceListener : ITraceListener
    {
        private const string EWSCHATTER_TEMP_MESSAGE_FILE = "EWSLogEntry.xml";

        private static string TraceLogBeginTag
        {
            get
            {
                string beginTag = string.Empty;

                switch (Constants.EwsApiVersion)
                {
                    case EwsApiVersions.OnePointOne:
                    case EwsApiVersions.OnePointOneHot:
                        beginTag = "<Trace";
                        break;
                    default:
                        beginTag = "<EwsLogEntry";
                        break;
                }

                return beginTag;
            }
        }

        private static string TraceLogEndTag
        {
            get
            {
                string endTag = string.Empty;

                switch (Constants.EwsApiVersion)
                {
                    case EwsApiVersions.OnePointOne:
                    case EwsApiVersions.OnePointOneHot:
                        endTag = "</Trace>";
                        break;
                    default:
                        endTag = "</EwsLogEntry>";
                        break;
                }

                return endTag;
            }
        }

        private static Dictionary<string, string> CurrentHeaders = new Dictionary<string, string>();

        private static string ChatterLogFilePath
        {
            get
            {
                return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}EWSChatter_{1}.log",
                    TraceHelper.LogDirectory,
                    TraceHelper.LogKey);
            }
        }

        public void Trace(string messageType, string message)
        {
            try
            {
                // Log all SOAP communication.
                LogEWSChatter(message);

                // Ping the ChatterLogForm that new messages arrived
                EWSEditor.Forms.RequestResponseHistoryForm.RefreshMessages();
            }
            catch (Exception ex)
            {
                TraceHelper.WriteVerbose("Failed to record EWSChatter log.");
                TraceHelper.WriteVerbose(ex);
            }
        }

        /// <summary>
        /// Get an array of the current message headers available
        /// </summary>
        /// <returns>String array of headers</returns>
        public static string[] GetAllLogHeaders()
        {
            string[] headers = new string[CurrentHeaders.Count];
            CurrentHeaders.Keys.CopyTo(headers, 0);

            return headers;
        }

        /// <summary>
        /// Look to see if a method name is available for the given
        /// header.
        /// </summary>
        /// <param name="header">Header to look up.</param>
        /// <returns>Method name for header if found.</returns>
        public static string GetMethodFromHeader(string header)
        {
            return CurrentHeaders[header];
        }

        /// <summary>
        /// Finds a message in the communication log by its header, 
        /// saves the message to a temporary file, and returns the 
        /// temporary file path.
        /// </summary>
        /// <param name="header">Header of message to lookup</param>
        /// <returns>Path to an XML file in the Temp directory</returns>
        public static string GetEWSMessage(string header)
        {
            TextReader reader = File.OpenText(ChatterLogFilePath);
            StringBuilder message = null;

            try
            {
                bool keepReading = true;
                while (keepReading)
                {
                    string data = reader.ReadLine();

                    // If we reached the end, stop.
                    if (data == null)
                    {
                        break;
                    }

                    // Found the message!
                    if (data.Contains(header))
                    {
                        data = data.Substring(data.IndexOf(header));
                        message = new StringBuilder();
                    }

                    // If message is not null then we are
                    // saving message text and need to write.
                    if (message != null)
                    {
                        // Once the end tag is written bail out.
                        if (data.Contains(EWSEditorTraceListener.TraceLogEndTag))
                        {
                            data = data.Substring(0, data.IndexOf(EWSEditorTraceListener.TraceLogEndTag) + EWSEditorTraceListener.TraceLogEndTag.Length);
                            keepReading = false;
                        }

                        message.AppendLine(data);
                    }
                }

                // If the message was found, write it
                // to a temp file and return the path.
                if (message != null)
                {
                    string tempPath = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}{1}", Path.GetTempPath(), EWSCHATTER_TEMP_MESSAGE_FILE);
                    File.WriteAllText(tempPath, message.ToString());
                    return tempPath;
                }

                return string.Empty;
            }
            finally
            {
                reader.Close();
            }

        }

        /// <summary>
        /// Delete the chatter log file
        /// </summary>
        public static void DeleteChatterLog()
        {
            File.Delete(ChatterLogFilePath);
        }

        /// <summary>
        /// Add the message header to the CurrentHeaders
        /// collection and write the message to the EWSChatter log.
        /// </summary>
        /// <param name="message">SOAP message to be logged</param>
        /// <returns>Header used to identify the message</returns>
        private static string LogEWSChatter(string message)
        {
            // Parse out the text to be used as the header
            if (message.StartsWith(EWSEditorTraceListener.TraceLogBeginTag))
            {
                string header = message.Substring(0, message.IndexOf(">", 0) + 1);

                // The original headers are not going to always be
                // unique.  If we find a duplicate simply add a tag
                // to make it unique.  If this happens we need to update
                // the message as well to keep it in sync with the headers
                // we'll use to look up the message later.
                if (CurrentHeaders.ContainsKey(header))
                {
                    // Loop until the header is no longer a duplicate - Unique="1", Unique="2", etc...
                    int i = 0;
                    string newHeader = header.Replace(">", string.Format(System.Globalization.CultureInfo.CurrentCulture, " Unique=\"{0}\" >", i.ToString()));
                    while (CurrentHeaders.ContainsKey(newHeader))
                    {
                        i++;
                        newHeader = header.Replace(">", string.Format(System.Globalization.CultureInfo.CurrentCulture, " Unique=\"{0}\" >", i.ToString()));
                    }

                    message = message.Replace(header, newHeader);
                    header = newHeader;
                }

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

                CurrentHeaders.Add(header, method);

                // Write the message to the EWSChatter log
                File.AppendAllText(ChatterLogFilePath, message);

                // Write the header to the EWSEditor log as well to match
                // up EWSChatter to the application logs
                if (method.Length > 0)
                {
                    TraceHelper.WriteInfo(String.Format("Header: {0} | Method: {1}", header, method));
                }
                else
                {
                    TraceHelper.WriteInfo(String.Format("Header: {0}", header));
                }

                return header;
            }
            else
            {
                TraceHelper.WriteVerbose(String.Format("The following message could not be parsed\n'{0}'", message));
                throw new ArgumentException("Could not parse trace message");
            }
        }
    }
}
