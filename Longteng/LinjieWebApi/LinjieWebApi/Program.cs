using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;

namespace LinjieWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var log = NLogBuilder.ConfigureNLog("Config/nlog.config").GetCurrentClassLogger();
            try
            {
                log.Info("开启日志服务");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                log.Error($"{ex}");
            }
            finally
            {
                log.Info("日志服务关闭");
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
               .UseServiceProviderFactory(new AutofacServiceProviderFactory())//添加AutofacServiceProviderFactory依赖注入容器
               .ConfigureLogging(logging =>
                {
                 logging.ClearProviders();//清除其他的文件日志文件提供器
                 logging.SetMinimumLevel(LogLevel.Error);//Logging LogLevel设置 优先级 command > appsettings.json > 硬编码
               })
              .UseNLog();//依赖注入NLog日志组件
    }
}
