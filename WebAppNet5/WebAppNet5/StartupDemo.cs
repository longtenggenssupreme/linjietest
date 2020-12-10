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

namespace WebAppNet5
{
    /// <summary>
    /// 多环境---启动类多环境 
    /// 1、WebAppNet5下Properties下的launchSettings.json 修改"ASPNETCORE_ENVIRONMENT": "Development"为"ASPNETCORE_ENVIRONMENT": "Demo"
    /// 2、Program下的CreateHostBuilder中的 webBuilder.UseStartup<Startup>();改成
    /// </summary>
    public class StartupDemo
    {
        public StartupDemo(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public Startup(IWebHostEnvironment env)
        //{
        //    var builder = new ConfigurationBuilder();
        //    builder.AddJsonFile("Config/NLog.config",true).AddEnvironmentVariables();
        //    Configuration = builder.Build();
        //}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<ITestA, TestA>();
            services.AddTransient<ITestB, TestB>();
            NLog.LogManager.GetCurrentClassLogger().Info("测试nlog日志。。。。。");
            //NLog.LogManager.Shutdown();
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
    }
}
