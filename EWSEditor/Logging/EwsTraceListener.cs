using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Logging
{
    public class EwsTraceListener : ITraceListener
    {
        public void Trace(string traceType, string traceMessage)
        {
            DebugLog.WriteEwsLog(
                traceType,
                traceMessage);
        }
    }
}
