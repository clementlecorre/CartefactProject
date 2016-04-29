using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentCar3ASP.Startup))]
namespace RentCar3ASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
