using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Untt_test.Startup))]
namespace Untt_test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
