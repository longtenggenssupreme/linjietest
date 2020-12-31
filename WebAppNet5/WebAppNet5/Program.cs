using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Autofac.Extensions.DependencyInjection;
using NLog.Web;

namespace WebAppNet5
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
            catch (System.Exception ex)
            {
                log.Error($"{ex}");
            }
            finally {
                log.Info("日志服务关闭");
                NLog.LogManager.Shutdown();
            }  
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //.ConfigureLogging(logbuild => logbuild.AddLog4Net("Config/log4net.config"))//log4net第一种使用方法
            .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseStartup<Startup>();
                    //多环境---启动类多环境 ====自动寻找指定程序集下对于的Startup类===StartupDemo
                    //webBuilder.UseStartup(System.Reflection.Assembly.GetExecutingAssembly().FullName);
                    //多环境---启动类中的方法多环境 Startup类===新添加 ConfigureDemoServices和ConfigureDemo，后缀Demo
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
