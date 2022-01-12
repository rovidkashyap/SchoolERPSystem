using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SchoolERPSystem.Models;
using SchoolERPSystem.Models.Authentication;

[assembly: OwinStartupAttribute(typeof(SchoolERPSystem.Web.Startup))]
namespace SchoolERPSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}
