using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InternalJobPortalApp.Startup))]
namespace InternalJobPortalApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
