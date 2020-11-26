using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ConsoleApp.Startup1))]

namespace ConsoleApp
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
            //GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source =localhost;Initial Catalog=mynetcore;Persist Security Info=True;User Id=sa;Password=sa123;");
            GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source=localhost;Initial Catalog=mydb;Integrated Security=True;");
            app.UseHangfireServer();
            app.UseHangfireDashboard();
        }
    }
}
