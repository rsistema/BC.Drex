using AutoMapper;
using BC.Drex.API.Dtos;
using BC.Drex.API.Dtos.Wallet;
using BC.Drex.API.AppServices.Interfaces;
using BC.Drex.Domain.Interfaces.Services;

namespace BC.Drex.API.AppServices
{
    public class WalletAppService : IWalletAppService
    {
        private readonly IWalletService _service;
        private readonly IMapper _mapper;
        public WalletAppService(IWalletService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ResultResponse<WalletResponse>> PostCreateWalletAsync(string userId)
        {
            var result = await _service.CreateAsync(Guid.Parse(userId));
            return _mapper.Map<ResultResponse<WalletResponse>>(result);
        }

        public async Task<ResultResponse<WalletResponse>> GetWalletByUserIdAsync(string userId)
        {
            var result = await _service.GetUserWalletAsync(Guid.Parse(userId));
            return _mapper.Map<ResultResponse<WalletResponse>>(result);
        }

        public async Task<ResultResponse<WalletTransferResponse>> PostWalletTransferAmountAsync(WalletTransferRequest request)
        {
            var result = await _service.TransferAsync(request.FromUserId.Value, request.ToWalletId, request.Amount);
            return _mapper.Map<ResultResponse<WalletTransferResponse>>(result);
        }

        public async Task<ResultResponse<WalletResponse>> PostAddAmountAsync(decimal amount, string userId)
        {
            var result = await _service.AddAmountAsync(amount, Guid.Parse(userId));
            return _mapper.Map<ResultResponse<WalletResponse>>(result);
        }

    }
}
