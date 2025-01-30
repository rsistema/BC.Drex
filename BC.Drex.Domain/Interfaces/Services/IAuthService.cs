using BC.Drex.Domain.Entities;

namespace BC.Drex.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<ServiceResult<string>> RegisterAsync(string name, string email, string password);
        Task<string> LoginAsync(string email, string password);
    }
}
