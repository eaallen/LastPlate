using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheLastPlate2.Startup))]
namespace TheLastPlate2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
