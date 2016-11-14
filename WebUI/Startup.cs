using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebUI.Startup))]
namespace WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
