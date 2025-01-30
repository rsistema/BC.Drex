using System.Linq.Expressions;

namespace BC.Drex.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
