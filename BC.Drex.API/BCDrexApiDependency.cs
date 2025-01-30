using BC.Drex.API.AppServices;
using BC.Drex.API.AppServices.Interfaces;

namespace BC.Drex.API
{
    public static class BCDrexApiDependency
    {
        public static void AddBCDrexApiDependency(this IServiceCollection services)
        {
            services.AddScoped<IHealthCheckAppService, HealthCheckAppService>();
            services.AddScoped<IAuthAppService, AuthAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IWalletAppService, WalletAppService>();
        }
    }
}
