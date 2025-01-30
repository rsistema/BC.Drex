using BC.Drex.Infrastructure.Data;
using BC.Drex.Domain.Interfaces.Repositories;

namespace BC.Drex.Infrastructure.Repositories
{
    public class HealthCheckRepository : IHealthCheckRepository
    {
        private readonly DrexDbContext _context;

        public HealthCheckRepository(DrexDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CanConnectAsync()
        {
            return await _context.Database.CanConnectAsync();
        }
    }
}
