namespace BC.Drex.Domain.Interfaces.Repositories
{
    public interface IHealthCheckRepository
    {
        Task<bool> CanConnectAsync();
    }
}
