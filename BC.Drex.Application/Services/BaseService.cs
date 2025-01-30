using BC.Drex.Domain.Interfaces.Services;
using BC.Drex.Domain.Interfaces.Repositories;

namespace BC.Drex.Application.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
            await Task.CompletedTask;
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                await _repository.DeleteAsync(id);
                return true;
            }
            return false;
        }
    }
}
