using BC.Drex.API.Dtos;
using BC.Drex.API.Dtos.Auth;

namespace BC.Drex.API.AppServices.Interfaces
{
    public interface IAuthAppService
    {
        Task<ResultResponse<string>> RegisterAsync(RegisterRequest request);
        Task<string> LoginAsync(LoginRequest request);
    }
}
