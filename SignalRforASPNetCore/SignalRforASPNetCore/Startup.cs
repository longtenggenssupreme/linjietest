using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace SignalRforASPNetCore
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //���SignalR
            services.AddSignalR();
            //���Session
            services.AddSession();
            //��״̬----��������֤,�÷���ʹ�õ�session+cookie����֤��
            //�ͻ��˵�¼���������֤�ɹ�֮�󱣴�ͻ��˵ĵ�¼�û���Ϣ��session��ȥ�������ظ��ͻ���һ��session��id���浽�ͻ��˵�cookie�У��Ժ������Զ����cookie�е�session��Ϣ
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                option =>
                {
                    //δ��¼ʱ���ض���ָ����½����
                    option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Login/Login");
                    //���ʾܾ�ʱ���ض���ָ������
                    option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Home/Privacy");
                });
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)//���cookie��֤�����Լ�cookie��֤������
            //    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, option =>
            //    {
            //        //��¼·�������ǵ��û���ͼ������Դ��δ���������֤ʱ�����򽫻Ὣ�����ض���������·��
            //        option.LoginPath = new PathString("/Login/Login");
            //        ////��ֹ����·�������û���ͼ������Դʱ����δͨ������Դ���κ���Ȩ���ԣ����󽫱��ض���������·��
            //        option.AccessDeniedPath = new PathString("/Home/Privacy");
            //    });
            //��״̬----��������֤,�÷���ʹ�õ�session+cookie����֤��
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            //���Session
            app.UseSession();
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //��������֤
            app.UseAuthentication();
            //�����Ȩ��֤
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //���SignalR,����ͨ��http://localhost:5000/messagehubʹ�÷���SignalR�����
                endpoints.MapHub<MessageHub>("/messagehub");//"launchSettings.json"�ļ��е� //"applicationUrl": "https://localhost:5001;http://localhost:5000",�޸�Ϊ"applicationUrl": "http://localhost:5000",
            });
        }
    }
}
