using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DBTest.Startup))]
namespace DBTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
