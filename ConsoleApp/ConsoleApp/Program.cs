using Hangfire;
using Microsoft.Owin.Hosting;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"开始启动。。。");
            WebApp.Start<Startup1>("http://*:5533/");
            var enstr = BackgroundJob.Enqueue(() => Writelog("添加任务到队列"));
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
