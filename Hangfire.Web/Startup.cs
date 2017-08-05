using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Hangfire.Web.Startup))]

namespace Hangfire.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("HangfileDb");
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
