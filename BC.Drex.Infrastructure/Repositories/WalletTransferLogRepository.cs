using BC.Drex.Domain.Entities;
using BC.Drex.Infrastructure.Data;
using BC.Drex.Domain.Interfaces.Repositories;

namespace BC.Drex.Infrastructure.Repositories
{
    public class WalletTransferLogRepository : BaseRepository<WalletTransferLog>, IWalletTransferLogRepository
    {
        public WalletTransferLogRepository(DrexDbContext context) : base(context) { }

    }
}
