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
            #region 读取配置文件方式
            ////第一种读取配置文件方式---直接读取配置，通过索引读取
            //var writeConnectString = Configuration["ConnectingStrings:WriteConnecting"];//读取对应的配置，上下级之间使用冒号分割
            //Console.WriteLine($"第一种读取配置文件方式: writeConnectString={writeConnectString}");
            //var testConnectStringServer = Configuration["ConnectingStrings:TestConnecting:Server"];
            //Console.WriteLine($"第一种读取配置文件方式: testConnectStringServer={testConnectStringServer}");
            //var testConnectString = Configuration["ConnectingStrings:TestConnecting:Microsoft.Hosting.Lifetime"];
            //Console.WriteLine($"第一种读取配置文件方式: testConnectString={testConnectString}");
            ////var testConnectString22 = Configuration.GetSection("ConnectingStrings");
            ////Console.WriteLine($"第一种读取配置文件方式: testConnectString={testConnectString}");
            //Console.WriteLine($"---------------------");

            ////第二种读取配置文件方式---配置文件绑定指定的对象
            ////缺点:必须先创建该绑定的对象，之后才能使用，不方便
            //Rootobject rootobject = new Rootobject();
            //Configuration.Bind(rootobject);
            //Connectingstrings option = new Connectingstrings();
            //Configuration.GetSection("ConnectingStrings").Bind(option);

            ////无需先创建该绑定的对象，其他需要的地方使用构造函数依赖注入 IOptions<Connectingstrings> options 获取options.Value即可使用
            ////使用IServiceCollection注册配置文件，绑定指定的实例对象
            //services.Configure<Rootobject>(Configuration);
            //services.Configure<Connectingstrings>(Configuration.GetSection("ConnectingStrings"));

            //Console.WriteLine($"第二种读取配置文件方式: writeConnectString={writeConnectString}");
            //Console.WriteLine($"---------------------");

            ////第三种读取配置文件方式
            //var ip = Configuration["ip"];//dotnet WenAppNet5.dll --urls="http://*:8081" --ip="127.0.0.1" --port=8082
            //var port = Configuration["port"];//dotnet WenAppNet5.dll --urls="http://*:8081" --ip="127.0.0.1" --port=8082
            //Console.WriteLine($"第三种读取配置文件方式: writeConnectString={writeConnectString}");
            //Console.WriteLine($"---------------------");
            #endregion

            services.Configure<Rootobject>(Configuration);
            services.AddControllersWithViews();
            services.AddTransient<ITestA, TestA>();
            services.AddTransient<ITestB, TestB>();
            //NLog.LogManager.GetCurrentClassLogger().Info("测试nlog日志。。。。。");
            //NLog.LogManager.Shutdown();
            services.AddRazorPages().AddRazorRuntimeCompilation();//启动的预编译，默认系统会将视图编译进行预编译处理，最终会将编译好的视图
            //.NET应用实现定时开关
            services.AddFeatureManagement().AddFeatureFilter<TimeWindowFilter>();
        }

        // This method gets called by the runtime. Use this method to add services to the Autofac container.
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            //原生的服务容器，会自动注册到当前Autofac container容器中去，不需要使用containerBuilder.Populate(services);

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
            //loggerFactory.AddLog4Net("Config/log4net.config");//log4net第二种使用方法
            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //引入 Microsoft.Extensions.FileProviders; PhysicalFileProvider
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot"))
                //FileProvider = new PhysicalFileProvider("wwwroot")//使用指定的静态文件wwwroot下的js和css文件，发布版本一般不需要写，会自动使用
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

        #region 多环境--方法多环境 Demo环境 
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureDemoServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<ITestA, TestA>();
            services.AddTransient<ITestB, TestB>();
            NLog.LogManager.GetCurrentClassLogger().Info("测试nlog日志。。。。。");
            //NLog.LogManager.Shutdown();
        }

        // This method gets called by the runtime. Use this method to add services to the Autofac container.
        public void ConfigureDemoContainer(ContainerBuilder containerBuilder)
        {
            //原生的服务容器，会自动注册到当前Autofac container容器中去，不需要使用containerBuilder.Populate(services);

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
            //loggerFactory.AddLog4Net("Config/log4net.config");//log4net第二种使用方法
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
