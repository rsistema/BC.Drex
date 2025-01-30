using BC.Drex.API.Dtos;
using BC.Drex.API.Dtos.Wallet;

namespace BC.Drex.API.AppServices.Interfaces
{
    public interface IWalletAppService
    {
        Task<ResultResponse<WalletResponse>> PostCreateWalletAsync(string userId);
        Task<ResultResponse<WalletResponse>> GetWalletByUserIdAsync(string userId);
        Task<ResultResponse<WalletTransferResponse>> PostWalletTransferAmountAsync(WalletTransferRequest request);
        Task<ResultResponse<WalletResponse>> PostAddAmountAsync(decimal amount, string userId);
    }
}
