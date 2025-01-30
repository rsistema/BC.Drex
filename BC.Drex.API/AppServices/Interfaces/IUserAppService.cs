using BC.Drex.API.Dtos;
using BC.Drex.API.Dtos.User;
using BC.Drex.Domain.Entities;

namespace BC.Drex.API.AppServices.Interfaces
{
    public interface IUserAppService
    {
        Task<ResultResponse<UserResponse>> GetUserByIdAsync(Guid id);
        Task<ResultResponse<IEnumerable<UserResponse>>> GetAllUsersAsync();
        Task<ResultResponse<UserResponse>> UpdateUserAsync(UserRequest request);
        Task<ResultResponse<bool>> DeleteUserAsync(Guid id);
    }
}
