using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentCatalogVDos.Startup))]
namespace StudentCatalogVDos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
