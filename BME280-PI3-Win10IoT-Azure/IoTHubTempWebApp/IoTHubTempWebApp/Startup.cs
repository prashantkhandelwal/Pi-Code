using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IoTHubTempWebApp.Startup))]
namespace IoTHubTempWebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}