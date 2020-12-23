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
            #region ����������ľ���д��
            //����������ľ���д��
            containerBuilder.RegisterType<LoggerAsyncInterceptor>().AsSelf();//IAsyncInterceptor������
            containerBuilder.RegisterType<LoggerInterceptor>().AsSelf();//Interceptor������
            var typeTests = GetType().Assembly.ExportedTypes.Where(t => t.Name.EndsWith("ServiceBase")).ToArray();//ע����ServiceBase��β�ķ����ͽӿ�
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
