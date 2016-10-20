using System;
using System.Configuration;
using System.Threading;
using Microsoft.Azure.WebJobs;

namespace WebJobsSample.WebJobs
{
    internal static class Program
    {
        public static void Main()
        {
            Thread continousWebJobThread = new Thread(() =>
            {
                while (DateTime.UtcNow < DateTime.MaxValue)
                {
                    Console.WriteLine($"{DateTime.UtcNow.ToLongDateString()} - Web job woring very hard ;)");
                    Thread.Sleep(TimeSpan.FromHours(1));
                }
            });
            continousWebJobThread.Start();

            var jobHostConfiguration = new JobHostConfiguration();

            jobHostConfiguration.StorageConnectionString = ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ConnectionString;
            jobHostConfiguration.DashboardConnectionString = ConfigurationManager.ConnectionStrings["AzureWebJobsDashboard"].ConnectionString;
            jobHostConfiguration.HostId = "web-jobs-sample";
            jobHostConfiguration.UseCore();
            jobHostConfiguration.UseTimers();

            new JobHost(jobHostConfiguration).RunAndBlock();
        }

    }
}