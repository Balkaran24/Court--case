using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourtCases_Balkaran.Startup))]
namespace CourtCases_Balkaran
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
