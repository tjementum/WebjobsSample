using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Timers;

namespace WebJobsSample.WebJobs.Jobs
{
    public class ScheduledJob
    {
        public void Run([TimerTrigger(typeof(Scheduler))] TimerInfo timerInfo, TextWriter textWriter)
        {
            // This should be triggerede every night at 1AM.... but sometimes it starts at e.g. 2016-10-20T00:59:59.9276305
            // When that happes it saves the "Next run time" in blob storage with a time stamp of 2016-10-20T01:00:00 (8ms after... and not 24hours after)
            //https://webjobschedulerssample.blob.core.windows.net/azure-webjobs-hosts/timers/web-jobs-sample/WebJobsSample.WebJobs.Jobs.ScheduledJob.Run/status
            textWriter.WriteLine($"{DateTime.UtcNow.ToLongDateString()} - Scheduled Job started.");
        }

        private class Scheduler : DailySchedule
        {
            public Scheduler() : base("01:00:00")
            {
            }
        }
    }
}