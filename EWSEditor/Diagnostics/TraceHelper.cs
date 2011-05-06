namespace EWSEditor.Diagnostics
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;

    using EWSEditor.Resources;

    using Microsoft.Exchange.WebServices.Data;

    public class TraceHelper
    {
        private static string logKey = string.Empty;
        private static string logDirectoryPath = string.Empty;
        private static string logFilePath = string.Empty;

        private static TraceSwitch currentTraceSwitch = new TraceSwitch("EWSEditorTracing", "EWSEditor tracing level.");

        /// <summary>
        /// Gets the directory used to store log files for this session.
        /// </summary>
        public static string LogDirectory
        {
            get
            {
                if (logDirectoryPath.Length == 0)
                {
                    throw new ApplicationException("Log file direcotry is not initialized.");
                }

                return logDirectoryPath;
            }
        }

        /// <summary>
        /// Gets the log file key used to distinguished the log file for this session
        /// </summary>
        public static string LogKey
        {
            get
            {
                if (String.IsNullOrEmpty(logKey))
                {
                    throw new ApplicationException("Log file key is not initialized.");
                }

                return logKey;
            }
        }

        /// <summary>
        /// Gets the path to the EWSEditor log file for this session
        /// </summary>
        public static string LogFilePath
        {
            get
            {
                if (String.IsNullOrEmpty(logFilePath))
                {
                    throw new ApplicationException("Log file path is not initialized.");
                }

                return logFilePath;
            }
        }

        /// <summary>
        /// Initiailize the TraceHelper by specifying the directory where
        /// log files are to be stored.
        /// </summary>
        /// <param name="logDirecotry">
        /// File path to the direcotry where log files will be saved.
        /// </param>
        public static void Initialize(string logDirecotry)
        {
            logKey = DateTime.Now.Ticks.ToString();

            // Make sure that the log directory ends in a '\'
            if (!logDirecotry.EndsWith("\\"))
            {
                logDirecotry = string.Concat(logDirecotry, "\\");
            }
            logDirectoryPath = logDirecotry;

            // Create the log file for this session
            logFilePath = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}EWSEditor_{1}.log", LogDirectory, LogKey);
            try
            {
                if (!File.Exists(logFilePath))
                {
                    using (File.CreateText(logFilePath))
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                // If we can't create the logging file don't fail to start EWSEditor, just
                // disable tracing and move on.
                currentTraceSwitch.Level = TraceLevel.Off;
                throw new ApplicationException(
                    string.Format(DisplayStrings.FailCreateLogFileException, logFilePath),
                    ex);
            }
        }

        #region Public Methods

        public static void WriteError(string message)
        {
            WriteTraceMessage(String.Empty, message, TraceLevel.Error);
        }

        public static void WriteError(Exception ex)
        {
            WriteTraceMessage(String.Empty, GetExceptionMessage(ex), TraceLevel.Error);
        }

        public static void WriteWarning(string message)
        {
            WriteTraceMessage(String.Empty, message, TraceLevel.Warning);
        }

        public static void WriteInfo(String message)
        {
            WriteTraceMessage(String.Empty, message, TraceLevel.Info);
        }

        public static void WriteVerbose(Exception ex)
        {
            WriteTraceMessage(String.Empty, GetExceptionMessage(ex), TraceLevel.Verbose);
        }

        public static void WriteVerbose(string message)
        {
            WriteTraceMessage(String.Empty, message, TraceLevel.Verbose);
        }

        #endregion

        /// <summary>
        /// Standardize the output format and destination of all trace messages.
        /// </summary>
        /// <param name="source">The caller who requested this trace message be output</param>
        /// <param name="message">The message to output</param>
        /// <param name="level">The trace level of this message</param>
        /// <returns></returns>
        private static void WriteTraceMessage(string source, string message, TraceLevel level)
        {
            if (currentTraceSwitch.Level < level)
            {
                return;
            }

            if (String.IsNullOrEmpty(source))
            {
                StackTrace stack = new StackTrace();

                // Find the first stack from in EWSEditor that is not GetCallingMethod
                foreach (StackFrame f in stack.GetFrames())
                {
                    System.Reflection.MethodBase method = f.GetMethod();
                    if ((method != null) &&
                        (method.DeclaringType.FullName != "EWSEditor.Diagnostics.TraceHelper"))
                    {
                        source = DiagUtil.MethodInfoFromStackFrame(f);
                        break;
                    }
                }
            }

            StringBuilder traceMessage = new StringBuilder();
            traceMessage.Append(System.DateTime.Now.ToString("s"));
            traceMessage.Append("|");
            traceMessage.Append(level.ToString());
            traceMessage.Append("|");
            traceMessage.Append(source);
            traceMessage.Append("|");
            traceMessage.Append(message);
            traceMessage.Append("\r\n");

            Debug.Write(traceMessage.ToString());

            File.AppendAllText(LogFilePath, traceMessage.ToString());
        }

        private static string GetExceptionMessage(Exception ex)
        {
            StringBuilder message = new StringBuilder();
            message.AppendFormat("ExceptionType: {0} | ExceptionMessage: {1}", ex.GetType(), ex.Message);
            
            return message.ToString();
        }
    }
}
