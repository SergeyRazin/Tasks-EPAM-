using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Epam.ScrumPocker.WebApplication.Startup))]
namespace Epam.ScrumPocker.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
