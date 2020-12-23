using Autofac;
using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinjieWebApi
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
            services.AddControllers();
        }
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            #region 添加拦截器的精简写法
            //添加拦截器的精简写法
            containerBuilder.RegisterType<LoggerAsyncInterceptor>().AsSelf();//IAsyncInterceptor拦截器
            containerBuilder.RegisterType<LoggerInterceptor>().AsSelf();//Interceptor拦截器
            var typeTests = GetType().Assembly.ExportedTypes.Where(t => t.Name.EndsWith("ServiceBase")).ToArray();//注册以ServiceBase结尾的方法和接口
            containerBuilder.RegisterTypes(typeTests).AsImplementedInterfaces().EnableInterfaceInterceptors().InterceptedBy(typeof(LoggerInterceptor)); 
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
