using BC.Drex.Application.Services;
using BC.Drex.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BC.Drex.Application
{
    public static class BCDrexApplicationDependency
    {
        public static void AddBCDrexApplicationDependency(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IHealthCheckService, HealthCheckService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IWalletService, WalletService>();
        }
    }
}
