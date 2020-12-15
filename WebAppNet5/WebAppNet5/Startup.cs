using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

namespace WebAppNet5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region ��ȡ�����ļ���ʽ
            ////��һ�ֶ�ȡ�����ļ���ʽ---ֱ�Ӷ�ȡ���ã�ͨ��������ȡ
            //var writeConnectString = Configuration["ConnectingStrings:WriteConnecting"];//��ȡ��Ӧ�����ã����¼�֮��ʹ��ð�ŷָ�
            //Console.WriteLine($"��һ�ֶ�ȡ�����ļ���ʽ: writeConnectString={writeConnectString}");
            //var testConnectStringServer = Configuration["ConnectingStrings:TestConnecting:Server"];
            //Console.WriteLine($"��һ�ֶ�ȡ�����ļ���ʽ: testConnectStringServer={testConnectStringServer}");
            //var testConnectString = Configuration["ConnectingStrings:TestConnecting:Microsoft.Hosting.Lifetime"];
            //Console.WriteLine($"��һ�ֶ�ȡ�����ļ���ʽ: testConnectString={testConnectString}");
            ////var testConnectString22 = Configuration.GetSection("ConnectingStrings");
            ////Console.WriteLine($"��һ�ֶ�ȡ�����ļ���ʽ: testConnectString={testConnectString}");
            //Console.WriteLine($"---------------------");

            ////�ڶ��ֶ�ȡ�����ļ���ʽ---�����ļ���ָ���Ķ���
            ////ȱ��:�����ȴ����ð󶨵Ķ���֮�����ʹ�ã�������
            //Rootobject rootobject = new Rootobject();
            //Configuration.Bind(rootobject);
            //Connectingstrings option = new Connectingstrings();
            //Configuration.GetSection("ConnectingStrings").Bind(option);

            ////�����ȴ����ð󶨵Ķ���������Ҫ�ĵط�ʹ�ù��캯������ע�� IOptions<Connectingstrings> options ��ȡoptions.Value����ʹ��
            ////ʹ��IServiceCollectionע�������ļ�����ָ����ʵ������
            //services.Configure<Rootobject>(Configuration);
            //services.Configure<Connectingstrings>(Configuration.GetSection("ConnectingStrings"));

            //Console.WriteLine($"�ڶ��ֶ�ȡ�����ļ���ʽ: writeConnectString={writeConnectString}");
            //Console.WriteLine($"---------------------");

            ////�����ֶ�ȡ�����ļ���ʽ
            //var ip = Configuration["ip"];//dotnet WenAppNet5.dll --urls="http://*:8081" --ip="127.0.0.1" --port=8082
            //var port = Configuration["port"];//dotnet WenAppNet5.dll --urls="http://*:8081" --ip="127.0.0.1" --port=8082
            //Console.WriteLine($"�����ֶ�ȡ�����ļ���ʽ: writeConnectString={writeConnectString}");
            //Console.WriteLine($"---------------------");
            #endregion

            services.Configure<Rootobject>(Configuration);
            services.AddControllersWithViews();
            services.AddTransient<ITestA, TestA>();
            services.AddTransient<ITestB, TestB>();
            //NLog.LogManager.GetCurrentClassLogger().Info("����nlog��־����������");
            //NLog.LogManager.Shutdown();
            services.AddRazorPages().AddRazorRuntimeCompilation();//������Ԥ���룬Ĭ��ϵͳ�Ὣ��ͼ�������Ԥ���봦�����ջὫ����õ���ͼ
            //.NETӦ��ʵ�ֶ�ʱ����
            services.AddFeatureManagement().AddFeatureFilter<TimeWindowFilter>();
        }

        // This method gets called by the runtime. Use this method to add services to the Autofac container.
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            //ԭ���ķ������������Զ�ע�ᵽ��ǰAutofac container������ȥ������Ҫʹ��containerBuilder.Populate(services);

            //containerBuilder.RegisterType<TestA>().As<ITestA>().InstancePerDependency();
            //containerBuilder.RegisterType<TestB>().As<ITestB>().InstancePerDependency();
            containerBuilder.RegisterType<TestC>().As<ITestC>().InstancePerDependency();
            containerBuilder.RegisterType<TestD>().As<ITestD>().InstancePerDependency();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*, ILoggerFactory loggerFactory*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //loggerFactory.AddLog4Net("Config/log4net.config");//log4net�ڶ���ʹ�÷���
            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //���� Microsoft.Extensions.FileProviders; PhysicalFileProvider
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot"))
                //FileProvider = new PhysicalFileProvider("wwwroot")//ʹ��ָ���ľ�̬�ļ�wwwroot�µ�js��css�ļ��������汾һ�㲻��Ҫд�����Զ�ʹ��
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        #region �໷��--�����໷�� Demo���� 
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureDemoServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<ITestA, TestA>();
            services.AddTransient<ITestB, TestB>();
            NLog.LogManager.GetCurrentClassLogger().Info("����nlog��־����������");
            //NLog.LogManager.Shutdown();
        }

        // This method gets called by the runtime. Use this method to add services to the Autofac container.
        public void ConfigureDemoContainer(ContainerBuilder containerBuilder)
        {
            //ԭ���ķ������������Զ�ע�ᵽ��ǰAutofac container������ȥ������Ҫʹ��containerBuilder.Populate(services);

            //containerBuilder.RegisterType<TestA>().As<ITestA>().InstancePerDependency();
            //containerBuilder.RegisterType<TestB>().As<ITestB>().InstancePerDependency();
            containerBuilder.RegisterType<TestC>().As<ITestC>().InstancePerDependency();
            containerBuilder.RegisterType<TestD>().As<ITestD>().InstancePerDependency();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureDemo(IApplicationBuilder app, IWebHostEnvironment env/*, ILoggerFactory loggerFactory*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //loggerFactory.AddLog4Net("Config/log4net.config");//log4net�ڶ���ʹ�÷���
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        #endregion
    }
}
