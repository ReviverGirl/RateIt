using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RateIt.Startup))]
namespace RateIt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
