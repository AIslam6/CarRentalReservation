using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarRentalReservation.UI.Startup))]
namespace CarRentalReservation.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
