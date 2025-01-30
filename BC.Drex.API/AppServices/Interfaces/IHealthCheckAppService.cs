namespace BC.Drex.API.AppServices.Interfaces
{
    public interface IHealthCheckAppService
    {
        Task<bool> CheckHealthAsync();
    }
}
