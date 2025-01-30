using BC.Drex.Domain.Entities;
using BC.Drex.Domain.Interfaces.Repositories;
using BC.Drex.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BC.Drex.Infrastructure.Repositories
{
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(DrexDbContext context) : base(context) { }

        public async Task<Wallet?> GetByUserId(Guid userId)
        {
            return await _context.Wallets.Include(w => w.User).FirstOrDefaultAsync(w => w.UserId == userId);
        }

    }
}
