using BC.Drex.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BC.Drex.Infrastructure.Repositories;
using BC.Drex.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BC.Drex.Infrastructure
{
    public static class BCDrexInfrastructureDependency
    {
        public static void AddBCDrexInfrastructureDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DrexDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IHealthCheckRepository, HealthCheckRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IWalletTransferLogRepository, WalletTransferLogRepository>();
        }
    }
}
