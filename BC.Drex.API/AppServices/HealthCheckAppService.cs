using BC.Drex.API.AppServices.Interfaces;
using BC.Drex.Domain.Interfaces.Services;

namespace BC.Drex.API.AppServices
{
    public class HealthCheckAppService : IHealthCheckAppService
    {
        private readonly IHealthCheckService _service;

        public HealthCheckAppService(IHealthCheckService service)
        {
            _service = service;
        }

        public async Task<bool> CheckHealthAsync()
        {
            return await _service.CheckDatabaseConnectionAsync();
        }
    }
}
