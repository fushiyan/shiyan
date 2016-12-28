using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(shiyan.Startup))]
namespace shiyan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
