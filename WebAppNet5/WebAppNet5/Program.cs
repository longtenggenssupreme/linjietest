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
                log.Info("������־����");
                CreateHostBuilder(args).Build().Run();
            }
            catch (System.Exception ex)
            {
                log.Error($"{ex}");
            }
            finally {
                log.Info("��־����ر�");
                NLog.LogManager.Shutdown();
            }  
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //.ConfigureLogging(logbuild => logbuild.AddLog4Net("Config/log4net.config"))//log4net��һ��ʹ�÷���
            .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseStartup<Startup>();
                    //�໷��---������໷�� ====�Զ�Ѱ��ָ�������¶��ڵ�Startup��===StartupDemo
                    //webBuilder.UseStartup(System.Reflection.Assembly.GetExecutingAssembly().FullName);
                    //�໷��---�������еķ����໷�� Startup��===����� ConfigureDemoServices��ConfigureDemo����׺Demo
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
