using BC.Drex.Domain.Entities;

namespace BC.Drex.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> GetByEmail(string email);
        Task<IEnumerable<User>> GetAll();
    }
}
