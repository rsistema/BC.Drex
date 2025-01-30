using AutoMapper;
using BC.Drex.API.Dtos;
using BC.Drex.API.Dtos.User;
using BC.Drex.Domain.Entities;
using BC.Drex.API.AppServices.Interfaces;
using BC.Drex.Domain.Interfaces.Services;

namespace BC.Drex.API.AppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public UserAppService(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ResultResponse<UserResponse>> GetUserByIdAsync(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return _mapper.Map<ResultResponse<UserResponse>>(result);
        }

        public async Task<ResultResponse<IEnumerable<UserResponse>>> GetAllUsersAsync()
        {
            var result = await _service.GetAllAsync();
            return _mapper.Map<ResultResponse<IEnumerable<UserResponse>>>(result);
        }

        public async Task<ResultResponse<UserResponse>> UpdateUserAsync(UserRequest request)
        {
            var user = _mapper.Map<User>(request); 
            var result = await _service.UpdateAsync(user);
            return _mapper.Map<ResultResponse<UserResponse>>(result);
        }

        public async Task<ResultResponse<bool>> DeleteUserAsync(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return _mapper.Map<ResultResponse<bool>>(result);
        }
    }
}
