using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Boilerplate.WebFormsUI.Startup))]
namespace Boilerplate.WebFormsUI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
