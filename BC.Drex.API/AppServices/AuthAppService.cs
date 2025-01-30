using AutoMapper;
using BC.Drex.API.Dtos;
using BC.Drex.API.Dtos.Auth;
using BC.Drex.API.AppServices.Interfaces;
using BC.Drex.Domain.Interfaces.Services;

namespace BC.Drex.API.AppServices
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IAuthService _service;
        private readonly IMapper _mapper;
        public AuthAppService(IAuthService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ResultResponse<string>> RegisterAsync(RegisterRequest request)
        {
            var result = await _service.RegisterAsync(request.Name, request.Email, request.Password);
            return _mapper.Map<ResultResponse<string>>(result);
        }

        public async Task<string> LoginAsync(LoginRequest request)
        {
            return await _service.LoginAsync(request.Email, request.Password);
        }
    }
}
