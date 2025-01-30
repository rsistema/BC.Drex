using BC.Drex.Domain.Entities;
using BC.Drex.Domain.Interfaces.Services;
using BC.Drex.Domain.Interfaces.Repositories;

namespace BC.Drex.Application.Services
{
    public class WalletService : BaseService<Wallet>, IWalletService
    {
        private readonly IWalletRepository _repository;
        private readonly IWalletTransferLogRepository _logRepository;
        public WalletService(
            IWalletRepository repository,
            IWalletTransferLogRepository logRepository) : base(repository)
        {
            _repository = repository;
            _logRepository = logRepository;
        }

        public async Task<ServiceResult<Wallet>> CreateAsync(Guid userId)
        {
            try
            {
                var wallet = await _repository.GetByUserId(userId);
                if (wallet != null)
                    return ServiceResult<Wallet>.FailureResult("Wallet already exists for this user.");

                var newWallet = new Wallet { UserId = userId, Amount = 5000, Active = true };
                await _repository.AddAsync(newWallet);
                return ServiceResult<Wallet>.SuccessResult(newWallet, "Wallet created successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<Wallet>.FailureResult($"Error: {ex.Message}");
            }
        }

        public async Task<ServiceResult<Wallet>> GetUserWalletAsync(Guid userId)
        {
            try
            {
                var wallet = await _repository.GetByUserId(userId);
                if (wallet == null)
                    return ServiceResult<Wallet>.FailureResult("User still doesn't have a wallet.");

                return ServiceResult<Wallet>.SuccessResult(wallet);
            }
            catch (Exception ex)
            {
                return ServiceResult<Wallet>.FailureResult($"Error: {ex.Message}");
            }
        }

        public async Task<ServiceResult<WalletTransferLog>> TransferAsync(Guid from, Guid to, decimal amount)
        {
            var fromWallet = await _repository.GetByUserId(from);
            var toWallet = await _repository.GetByIdAsync(to);

            if (fromWallet == null)
                return ServiceResult<WalletTransferLog>.FailureResult("Sender wallet not found.");

            if (toWallet == null)
                return ServiceResult<WalletTransferLog>.FailureResult("Recipient wallet not found.");

            if (fromWallet.Amount < amount)
                return ServiceResult<WalletTransferLog>.FailureResult("Insufficient funds.");

            fromWallet.Amount -= amount;
            toWallet.Amount += amount;

            var transferLog = new WalletTransferLog
            {
                FromWalletId = fromWallet.Id,
                ToWalletId = toWallet.Id,
                Amount = amount
            };

            await _logRepository.AddAsync(transferLog);

            return ServiceResult<WalletTransferLog>.SuccessResult(transferLog, "Transaction completed.");
        }

        public async Task<ServiceResult<Wallet>> AddAmountAsync(decimal amount, Guid userId)
        {
            try
            {
                var wallet = await _repository.GetByUserId(userId);
                if (wallet == null)
                    return ServiceResult<Wallet>.FailureResult("User still doesn't have a wallet.");

                wallet.Amount += amount;
                await _repository.UpdateAsync(wallet);
                return ServiceResult<Wallet>.SuccessResult(wallet, "Amount added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<Wallet>.FailureResult($"Error: {ex.Message}");
            }
        }
    }
}
