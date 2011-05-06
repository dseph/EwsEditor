namespace EWSEditor.Diagnostics
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    internal class DiagUtil
    {
        internal static string EwsMethodFromStackTrace(Exception ex)
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

        internal static string MethodInfoFromStackFrame(StackFrame frame)
        {
            System.Reflection.MethodBase method = frame.GetMethod();

            if (method == null)
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();

            builder.Append(method.DeclaringType.FullName);
            builder.Append(".");
            builder.Append(method.Name);

            // Write paramter types and names
            builder.Append("(");
            bool isFirstParam = true;
            foreach (ParameterInfo info in method.GetParameters())
            {
                if (!isFirstParam)
                {
                    builder.Append(", ");
                }
                else
                {
                    isFirstParam = false;
                }

                string name = "<UnknownType>";
                if (info.ParameterType != null)
                {
                    name = info.ParameterType.Name;
                }
                builder.Append(name + " " + info.Name);
            }
            builder.Append(")");

            // Write private symbol information if available
            if (!String.IsNullOrEmpty(frame.GetFileName()))
            {
                builder.Append(' ');
                builder.AppendFormat(CultureInfo.CurrentCulture, "in {0}:line {1}", frame.GetFileName(), frame.GetFileLineNumber());
            }
            
            return builder.ToString();
        }
    }
}
