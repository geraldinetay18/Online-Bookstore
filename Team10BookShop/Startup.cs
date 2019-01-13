using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Team10BookShop.Startup))]
namespace Team10BookShop
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
