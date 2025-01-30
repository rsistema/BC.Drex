namespace BC.Drex.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
