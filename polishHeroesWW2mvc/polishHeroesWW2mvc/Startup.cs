using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(polishHeroesWW2mvc.Startup))]
namespace polishHeroesWW2mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
