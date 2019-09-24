using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Torshia.Web.Startup))]
namespace Torshia.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
