using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(colegio7.Startup))]
namespace colegio7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
