using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(wishlistsdsdesuService.Startup))]

namespace wishlistsdsdesuService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}