using System.IO;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions;
using Microsoft.Azure.WebJobs.Host;

namespace WebJobsSample.WebJobs
{
    public static class ExceptionHandling
    {
        public static void ErrorMonitor([ErrorTrigger("00:00:05", 1)] TraceFilter filter, TextWriter textWriter)
        {
            TraceEvent[] traceEvents = filter.Events.ToArray();

            foreach (TraceEvent traceEvent in traceEvents)
            {
                textWriter.WriteLine(traceEvent.Message);
            }
        }
    }
}