using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WlanTestSystem.UI.WlanTestSystem.Startup))]
namespace WlanTestSystem.UI.WlanTestSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
