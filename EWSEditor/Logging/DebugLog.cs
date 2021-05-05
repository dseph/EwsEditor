using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using EWSEditor.Settings;
using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Logging
{
    #region DebugLogType

    internal enum DebugLogType
    {
        EwsTrace,
        Error,
        Information,
        Verbose
    }

    #endregion

    #region DebugLogItem

    internal class DebugLogItem
    {
        internal int Logid { get; private set; }

        internal DebugLogType Type { get; private set; }

        internal DateTime Time { get; private set; }

        internal string Title { get; private set; }

        internal string Data { get; private set; }

        internal string Source { get; private set; }

        private DebugLogItem() { }

        internal DebugLogItem(int logId, DateTime time, string source, DebugLogType type, string title, string data)
        {
            this.Logid = logId;
            this.Type = type;
            this.Time = time;
            this.Source = source;
            this.Title = title;
            this.Data = data;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Time.ToString("s"));
            sb.Append("|");
            sb.Append(this.Type.ToString());
            sb.Append("|");
            sb.Append(this.Source);
            sb.Append("|");
            sb.Append(this.Title);
            sb.AppendLine();

            if (!String.IsNullOrEmpty(this.Data))
            {
                sb.Append(this.Data);
            }

            return sb.ToString();
        }
    }

    #endregion

    internal class DebugLog
    {
        private static readonly string LogFile = GlobalSettings.LogFilePath;

        private static readonly bool LogSecurityToken  = GlobalSettings.LogSecurityToken;

        private static readonly bool ShouldSaveDebugOutput = GlobalSettings.ShouldSaveLogToFile;

        private static bool DebugLogDiskCommitEnabled = true;

        private static List<DebugLogItem> LogItems = new List<DebugLogItem>();
        private static object BigBadLock = new object();

        internal static DebugLogItem[] DebugLogItems
        {
            get
            {
                DebugLogItem[] logs = null;

                // Make this "thread safe"
                lock (BigBadLock)
                {
                    logs = LogItems.ToArray();
                }

                return logs;
            }
        }

        internal static void WriteException(string title, Exception ex)
        {
            StackTrace stack = new StackTrace();
            StackFrame frame = stack.GetFrame(1);
            WriteLogItem(DateTime.Now, frame.GetMethod().Name, DebugLogType.Error, title, ExceptionToString(ex));
        }

        internal static void WriteException(string title, AutodiscoverLocalException ex)
        {
            StackTrace stack = new StackTrace();
            StackFrame frame = stack.GetFrame(1);
            WriteLogItem(DateTime.Now, frame.GetMethod().Name, DebugLogType.Error, title, ExceptionToString(ex));
        }

        internal static void WriteInfo(string title, params string[] lines)
        {
            StackTrace stack = new StackTrace();
            StackFrame frame = stack.GetFrame(1);

            StringBuilder combinedLines = new StringBuilder();
            foreach (string line in lines)
            {
                combinedLines.AppendLine(line);
            }

            WriteLogItem(DateTime.Now, frame.GetMethod().Name, DebugLogType.Information, title, combinedLines.ToString());
        }

        internal static void WriteVerbose(params string[] lines)
        {
            StackTrace stack = new StackTrace();
            StackFrame frame = stack.GetFrame(1);

            StringBuilder builder = new StringBuilder();
            foreach (string line in lines)
            {
                builder.AppendLine(line);
            }

            WriteLogItem(DateTime.Now, frame.GetMethod().Name, DebugLogType.Verbose, "", builder.ToString());
        }

        internal static void WriteVerbose(string title, Exception ex)
        {
            StackTrace stack = new StackTrace();
            StackFrame frame = stack.GetFrame(1);
            WriteLogItem(DateTime.Now, frame.GetMethod().Name, DebugLogType.Verbose, title, ExceptionToString(ex));
        }

        internal static void WriteEwsLog(string traceType, string traceMessage)
        {
            StackTrace stack = new StackTrace();

            foreach (StackFrame frame in stack.GetFrames())
            {
                if (frame != stack.GetFrame(0) &&
                    frame != stack.GetFrame(1) &&
                    frame.GetMethod().DeclaringType.FullName.Contains("EWSEditor"))
                {
                    WriteLogItem(DateTime.Now, frame.GetMethod().Name, DebugLogType.EwsTrace, traceType, traceMessage);
                    return;
                }
            }
        }

        internal static void WriteLogItem(
            DateTime time,
            string source,
            DebugLogType type,
            string title,
            string data)
        {
            // Make this "thread safe"
            lock (BigBadLock)
            {
                try
                {
                    int logid = DebugLog.LogItems.Count;

                    DebugLogItem item = new DebugLogItem(logid, time, source, type, title, data);

                    DebugLog.TryWriteToMemory(item);

                    // If the user wants to save debug output and we haven't disabled, then commit debug logs
                    // to disk as well
                    if (DebugLog.ShouldSaveDebugOutput && DebugLog.DebugLogDiskCommitEnabled)
                    {
                        if (!TryWriteToDisk(item))
                        {
                            // Don't keep trying to write to disk if it fails once
                            DebugLog.DebugLogDiskCommitEnabled = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Write some debug output to help troubleshoot this
                    System.Diagnostics.Debug.WriteLine(
                        "Exception at WriteTraceMessage: \n" +
                        ex.Message);
                }
            }
        }

        private static bool TryWriteToMemory(DebugLogItem item)
        {
            try
            {
                DebugLog.LogItems.Add(item);
                return true;
            }
            catch (Exception ex)
            {
                // Write some debug output to help troubleshoot this
                System.Diagnostics.Debug.WriteLine(
                    "Exception at TryWriteDebugLogToMemory: " +
                    ex.Message);

                return false;
            }
        }

        private static bool TryWriteToDisk(DebugLogItem item)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(item.Time.ToString("s"));
                sb.Append("|");
                sb.Append(item.Type.ToString());
                sb.Append("|");
                sb.Append(item.Source);
                sb.Append("|");
                sb.Append(item.Title);
                sb.Append("|");
                sb.AppendLine();

                if (!String.IsNullOrEmpty(item.Data))
                {
                    sb.Append(item.Data);
                    sb.AppendLine();
                }

                // Write the debug log to the output file
                string LogEntry = sb.ToString();
                System.IO.File.AppendAllText(DebugLog.LogFile, LogEntry);
                return true;
            }
            catch (Exception ex)
            {
                // Write some debug output to help troubleshoot this
                System.Diagnostics.Debug.WriteLine(
                    "Exception at TryWriteDebugLogToDisk: " +
                    ex.Message);

                return false;
            }
        }

        private static string ExceptionToString(Exception ex)
        {
            // Create the exception detail text
            StringBuilder details = new StringBuilder();
            Exception currentException = ex;
            do
            {
                details.AppendLine("Exception details:");
                details.AppendLine(String.Concat("Message: ", currentException.Message));
                details.AppendLine(String.Concat("Type: ", currentException.GetType()));
                details.AppendLine(String.Concat("Source: ", currentException.Source));

                // Add exception type specific details
                if (currentException is ServiceResponseException)
                {
                    AppendServiceResponseExceptionDetail(
                        currentException as ServiceResponseException,
                        details);
                }
                else if (currentException is AutodiscoverRemoteException)
                {
                    AppendAutodiscoverRemoteExceptionDetail(
                        currentException as AutodiscoverRemoteException,
                        details);
                }

                details.AppendLine("Stack Trace:");
                details.AppendLine(currentException.StackTrace);

                currentException = currentException.InnerException;
            }
            while (currentException != null);

            return details.ToString();
        }

        internal static void AppendServiceResponseExceptionDetail(ServiceResponseException srex, StringBuilder details)
        {
            if (srex != null)
            {
                AppendServiceResponse(srex.Response, details);
            }
        }

        internal static void AppendServiceResponse(ServiceResponse response, StringBuilder details)
        {
            if (response != null)
            {
                details.AppendLine(String.Concat("ErrorCode: ", response.ErrorCode.ToString()));

                if (response.ErrorDetails.Count > 0)
                {
                    details.AppendLine("ErrorDetails:");
                    foreach (string key in response.ErrorDetails.Keys)
                    {
                        details.AppendLine(String.Concat(key, ": ", response.ErrorDetails[key]));
                    }
                }

                details.AppendLine(String.Concat("ErrorMessage: ", response.ErrorMessage));

                if (response.ErrorProperties.Count > 0)
                {
                    details.AppendLine("ErrorProperties:");
                    foreach (PropertyDefinitionBase prop in response.ErrorProperties)
                    {
                        //details.AppendLine(PropertyInterpretation.GetPropertyName(prop));
                    }
                }
            }
        }

        internal static void AppendAutodiscoverRemoteExceptionDetail(AutodiscoverRemoteException arex, StringBuilder details)
        {
            if (arex != null || arex.Error != null)
            {
                details.AppendLine("AutodiscoverError:");
                details.AppendLine(" DebugData: {0}" + arex.Error.DebugData);
                details.AppendLine(" ErrorCode: {0}" + arex.Error.ErrorCode);
                details.AppendLine(" Id: {0}" + arex.Error.Id);
                details.AppendLine(" Message: {0}" + arex.Error.Message);
                details.AppendLine(" Time: {0}" + arex.Error.Time);
            }
        }
    }
}
