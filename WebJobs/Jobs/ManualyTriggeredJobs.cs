using System;
using System.IO;
using Microsoft.Azure.WebJobs;

namespace WebJobsSample.WebJobs.Jobs
{
    public class ManualyTriggeredJobs
    {
        [NoAutomaticTrigger]
        public void ManualyTriggeredJob1(TextWriter textWriter)
        {
            //This Azure Web Job Function is triggerede directly from the Azure WebJobs dashboard, by clicking "Run"
            textWriter.WriteLine($"{DateTime.UtcNow.ToLongDateString()} - {nameof(ManualyTriggeredJob1)} started.");
        }

        [NoAutomaticTrigger]
        public void ManualyTriggeredJob2(TextWriter textWriter)
        {
            //This Azure Web Job Function is triggerede directly from the Azure WebJobs dashboard, by clicking "Run"
            textWriter.WriteLine($"{DateTime.UtcNow.ToLongDateString()} - {nameof(ManualyTriggeredJob2)} started.");
        }
    }
}