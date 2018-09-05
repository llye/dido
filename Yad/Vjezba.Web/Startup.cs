using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vjezba.Web.Startup))]
namespace Vjezba.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
