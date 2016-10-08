using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SwypeInBackService.Startup))]

namespace SwypeInBackService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
            app.MapSignalR();
        }
    }
}