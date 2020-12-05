using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EZKARAPP.Startup))]
namespace EZKARAPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
