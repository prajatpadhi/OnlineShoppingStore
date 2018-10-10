using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentitySecurity.Startup))]
namespace IdentitySecurity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
