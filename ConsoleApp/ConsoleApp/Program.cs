using Hangfire;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WebApp.Start<Startup1>("http://127.0.0.1:8097/");
            var enstr = BackgroundJob.Enqueue(() => Writelog("田间任务到队列"));
            BackgroundJob.Schedule(() => Writelog("延迟任务。。。"), TimeSpan.FromSeconds(10));
            BackgroundJob.ContinueJobWith(enstr, () => Writelog("上个任务执行完后，后续任务执行"));
            RecurringJob.AddOrUpdate(() => Writelog("循环任务"), Cron.Minutely);
            Console.Read();
        }

        public static void Writelog(string str)
        {
            Console.WriteLine($"{str}");
        }
    }
}
