using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeatherWidget.Startup))]
namespace WeatherWidget
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
