using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(alytaloV2.Startup))]
namespace alytaloV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
