using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EWSEditor.Logging;
using EWSEditor.PropertyInformation;
using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Data;
using System.Diagnostics;

namespace EWSEditor.Forms
{
    public partial class ErrorDialog : EWSEditor.Forms.DialogForm
    {
        private const string WarningTitle = "Warning";
        private const string ErrorTitle = "Exception";
        private const string InfoTitle = "Information";

        private const string Crlf = "\r\n";

        public ErrorDialog()
        {
            InitializeComponent();
        }

        public static void ShowError(string text)
        {
            MessageBox.Show(
                text,
                BaseForm.GetFormTitle(ErrorTitle),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);

            DebugLog.WriteInfo("Showed error dialog", text);
        }

        public static void ShowWarning(string text)
        {
            MessageBox.Show(
                text,
                BaseForm.GetFormTitle(WarningTitle),
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1);

            DebugLog.WriteInfo("Showed warning dialog", text);
        }

        public static void ShowInfo(string text)
        {
            MessageBox.Show(
                text,
                BaseForm.GetFormTitle(InfoTitle),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

 
        /// <summary>
        /// Displayt the given Exception in the ErrorDialog
        /// </summary>
        /// <param name="ex">Exception to display</param>
        public static void ShowError(Exception ex)
        {
            if (ex == null || String.IsNullOrEmpty(ex.Message))
            {
                // This shouldn't ever happen
                DebugLog.WriteVerbose("ex is NULL?!?!");
                return;
            }

            ErrorDialog dialog = new ErrorDialog();
            dialog.Text = ErrorTitle;
            dialog.ErrorIcon.Image = EWSEditor.Forms.FormsUtil.ConvertIconToImage(SystemIcons.Error);

            // Set the header text of the dialog with the exception message 
            // and calling method.
            dialog.ExceptionMessage.Text = ex.Message;
            dialog.FromWhere.Text = EwsMethodFromStackTrace(ex);

            // Add verbose exception details
            dialog.ExceptionDetailBox.Text = BuildExceptionDetail(ex);

            Form parent = Form.ActiveForm;
            if (parent == null)
            {
                foreach (Form openForm in Application.OpenForms)
                {
                    DebugLog.WriteVerbose(String.Format("Type: {0} Focused: {0} Visible: {0} Modal: {0}", openForm.GetType().FullName, openForm.Focused.ToString(), openForm.Visible.ToString(), openForm.Modal.ToString()));

                    if (openForm.Visible)
                    {
                        parent = openForm;
                    }

                    if (openForm.Modal && openForm.Visible)
                    {
                        parent = openForm;
                    }
                }
            }
            
            dialog.BringToFront();
            dialog.ShowDialog(parent);
        }

        public static void ShowServiceResponseMsgBox(ServiceResponse response, string message, string caption, MessageBoxIcon icon)
        {
            StringBuilder details = new StringBuilder(message);
            details.AppendLine();
            details.AppendLine();
            AppendServiceResponse(response, details);

            MessageBox.Show(
                details.ToString(),
                FormatDialogCaption(caption, icon),
                MessageBoxButtons.OK,
                icon,
                MessageBoxDefaultButton.Button1);
                
        }

        public static DialogResult ShowServiceExceptionMsgBox(ServiceResponseException srex, bool offerRetry, MessageBoxIcon icon)
        {
            StringBuilder message = new StringBuilder();
            AppendServiceResponseExceptionDetail(srex, message);

            // If there were bad properties in the request, display Yes/No options 
            // and offer to retry the request.
            if (offerRetry && (srex.Response.ErrorProperties.Count > 0))
            {
                message.AppendLine();
                message.AppendLine("Do you want to retry the request without the offending property?");
                return MessageBox.Show(
                    message.ToString(),
                    FormatDialogCaption(string.Empty, icon),
                    MessageBoxButtons.YesNo,
                    icon,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                return MessageBox.Show(
                    message.ToString(),
                    FormatDialogCaption(string.Empty, icon),
                    MessageBoxButtons.OK,
                    icon,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private static string EwsMethodFromStackTrace(Exception ex)
        {
            StackTrace stack = null;
            if (ex != null)
            {
                stack = new System.Diagnostics.StackTrace(ex);
            }

            // Find the first stack from in EWSEditor that is not GetCallingMethod
            StackFrame targetFrame = null;
            foreach (StackFrame f in stack.GetFrames())
            {
                System.Reflection.MethodBase method = f.GetMethod();
                if ((method != null) &&
                    (method.Module.Equals("EWSEditor.exe")) &&
                    (!method.Name.Equals("GetCallingMethod")))
                {
                    targetFrame = f;
                    break;
                }
            }

            if (targetFrame == null)
            {
                targetFrame = stack.GetFrame(2);
            }

            return string.Format("{0}.{1}()", targetFrame.GetMethod().DeclaringType.FullName, targetFrame.GetMethod().Name);
        }

        /// <summary>
        /// Format the dialog's caption according to which type of message it is by
        /// prefixing the standard EWSEditor prefix and the error dialog type based
        /// on MessageBoxIcon to the current caption.
        /// </summary>
        /// <param name="caption">Caption to add text to</param>
        /// <param name="icon">MessageBoxIcon used to determine what dialog prefix to prepend</param>
        /// <returns>Returns a new caption</returns>
        private static string FormatDialogCaption(string caption, MessageBoxIcon icon)
        {
            string prefix = string.Empty;

            switch (icon)
            {
                case MessageBoxIcon.Warning:
                    prefix = WarningTitle;
                    break;
                case MessageBoxIcon.Error:
                    prefix = ErrorTitle;
                    break;
                case MessageBoxIcon.Information:
                    prefix = InfoTitle;
                    break;
                default:
                    break;
            }

            // If there's supposed to be a prefix append it
            if (String.IsNullOrEmpty(prefix))
            {
                caption = String.IsNullOrEmpty(caption) ? prefix : String.Concat(prefix, ": ", caption);
            }

            return BaseForm.GetFormTitle(caption);
        }

        private static string BuildExceptionDetail(Exception ex)
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

        private static void AppendServiceResponseExceptionDetail(ServiceResponseException srex, StringBuilder details)
        {
            if (srex != null)
            {
                AppendServiceResponse(srex.Response, details);
            }           
        }

        private static void AppendServiceResponse(ServiceResponse response, StringBuilder details)
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
                        details.AppendLine(PropertyInterpretation.GetPropertyName(prop));
                    }
                }
            }
        }

        private static void AppendAutodiscoverRemoteExceptionDetail(AutodiscoverRemoteException arex, StringBuilder details)
        {
            if (arex != null || arex.Error != null)
            {
                details.AppendLine("AutodiscoverError:");
                details.AppendFormat(" DebugData: {0}{1}", arex.Error.DebugData, Crlf);
                details.AppendFormat(" ErrorCode: {0}{1}", arex.Error.ErrorCode, Crlf);
                details.AppendFormat(" Id: {0}{1}", arex.Error.Id, Crlf);
                details.AppendFormat(" Message: {0}{1}", arex.Error.Message, Crlf);
                details.AppendFormat(" Time: {0}{1}", arex.Error.Time, Crlf);
            }
        }
    }
}
