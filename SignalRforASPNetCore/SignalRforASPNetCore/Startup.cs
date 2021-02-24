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
            //添加SignalR
            services.AddSignalR();
            //添加Session
            services.AddSession();
            //有状态----添加身份认证,该方法使用的session+cookie的验证，
            //客户端登录，服务端验证成功之后保存客户端的登录用户信息到session中去，并返回给客户端一个session的id保存到客户端的cookie中，以后请求自动添加cookie中的session信息
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                option =>
                {
                    //未登录时，重定向到指定登陆界面
                    option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Login/Login");
                    //访问拒绝时，重定向到指定界面
                    option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Home/Privacy");
                });
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)//添加cookie验证主题以及cookie验证的设置
            //    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, option =>
            //    {
            //        //登录路径：这是当用户试图访问资源但未经过身份验证时，程序将会将请求重定向到这个相对路径
            //        option.LoginPath = new PathString("/Login/Login");
            //        ////禁止访问路径：当用户试图访问资源时，但未通过该资源的任何授权策略，请求将被重定向到这个相对路径
            //        option.AccessDeniedPath = new PathString("/Home/Privacy");
            //    });
            //无状态----添加身份认证,该方法使用的session+cookie的验证，
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
            //添加Session
            app.UseSession();
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //添加身份认证
            app.UseAuthentication();
            //添加授权验证
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //添加SignalR,可以通过http://localhost:5000/messagehub使用访问SignalR服务端
                endpoints.MapHub<MessageHub>("/messagehub");//"launchSettings.json"文件中的 //"applicationUrl": "https://localhost:5001;http://localhost:5000",修改为"applicationUrl": "http://localhost:5000",
            });
        }
    }
}
