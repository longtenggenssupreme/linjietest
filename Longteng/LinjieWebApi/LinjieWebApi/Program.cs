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
                log.Info("������־����");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                log.Error($"{ex}");
            }
            finally
            {
                log.Info("��־����ر�");
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
               .UseServiceProviderFactory(new AutofacServiceProviderFactory())//���AutofacServiceProviderFactory����ע������
               .ConfigureLogging(logging =>
                {
                 logging.ClearProviders();//����������ļ���־�ļ��ṩ��
                 logging.SetMinimumLevel(LogLevel.Error);//Logging LogLevel���� ���ȼ� command > appsettings.json > Ӳ����
               })
              .UseNLog();//����ע��NLog��־���
    }
}
