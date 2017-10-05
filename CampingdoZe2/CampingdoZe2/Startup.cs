using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CampingdoZe2.Startup))]
namespace CampingdoZe2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
