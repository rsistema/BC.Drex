using BC.Drex.Domain.Entities;

namespace BC.Drex.Domain.Interfaces.Services
{
    public interface IWalletService : IBaseService<Wallet>
    {
        Task<ServiceResult<Wallet>> CreateAsync(Guid userId);
        Task<ServiceResult<WalletTransferLog>> TransferAsync(Guid fromUserId, Guid toWalletId, decimal amount);
        Task<ServiceResult<Wallet>> GetUserWalletAsync(Guid userId);
        Task<ServiceResult<Wallet>> AddAmountAsync(decimal amount, Guid userId);
    }
}
