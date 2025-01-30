using BC.Drex.Domain.Interfaces.Repositories;
using BC.Drex.Domain.Interfaces.Services;

namespace BC.Drex.Application.Services
{
    public class HealthCheckService : IHealthCheckService
    {
        private readonly IHealthCheckRepository _repository;

        public HealthCheckService(IHealthCheckRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CheckDatabaseConnectionAsync()
        {
            return await _repository.CanConnectAsync();
        }
    }
}
