using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EFCOREDB.Startup1))]

namespace EFCOREDB
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
            GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source=MOP6EXV9E5J1M1F;Initial Catalog=mydb;Integrated Security=True;");
            //启用Hangfire服务
            //app.UseHangfireServer();
            ////启用Hangfire Dashboard面板
            //app.UseHangfireDashboard();
        }
    }
}
