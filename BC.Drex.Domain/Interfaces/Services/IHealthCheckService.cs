namespace BC.Drex.Domain.Interfaces.Services
{
    public interface IHealthCheckService
    {
        Task<bool> CheckDatabaseConnectionAsync();
    }
}
