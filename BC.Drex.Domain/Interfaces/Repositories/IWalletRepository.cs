using BC.Drex.Domain.Entities;

namespace BC.Drex.Domain.Interfaces.Repositories
{
    public interface IWalletRepository : IBaseRepository<Wallet>
    {
        Task<Wallet?> GetByUserId(Guid Id);
    }
}
