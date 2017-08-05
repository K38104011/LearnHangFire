using System;
using System.Threading.Tasks;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Hangfire.Web.Startup))]

namespace Hangfire.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("HangfileDb",
                new SqlServerStorageOptions
                {
                    QueuePollInterval = TimeSpan.FromSeconds(1)
                });
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
