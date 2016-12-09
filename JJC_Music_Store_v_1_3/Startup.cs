using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JJC_Music_Store_v_1_3.Startup))]
namespace JJC_Music_Store_v_1_3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
