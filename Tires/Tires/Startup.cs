using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tires.Startup))]
namespace Tires
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
