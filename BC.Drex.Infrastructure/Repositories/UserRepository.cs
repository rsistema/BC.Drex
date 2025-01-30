using BC.Drex.Domain.Entities;
using BC.Drex.Infrastructure.Data;
using BC.Drex.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BC.Drex.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DrexDbContext context) : base(context) { }

        public async Task<bool> GetByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user != null;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.Include(u => u.Wallet).Where(u => u.Deleted == null).ToListAsync();
        }
    }
}
