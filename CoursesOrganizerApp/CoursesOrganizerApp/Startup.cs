using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoursesOrganizerApp.Startup))]
namespace CoursesOrganizerApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
