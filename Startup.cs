using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MIS4200ProjectTeam7.Startup))]
namespace MIS4200ProjectTeam7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
