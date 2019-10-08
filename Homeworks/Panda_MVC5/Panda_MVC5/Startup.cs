using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Panda_MVC5.Startup))]
namespace Panda_MVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
