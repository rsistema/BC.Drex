using BC.Drex.Domain.Entities;

namespace BC.Drex.Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        new Task<ServiceResult<IEnumerable<User>>> GetAllAsync();
        new Task<ServiceResult<User>> UpdateAsync(User entity);
        new Task<ServiceResult<User>> GetByIdAsync(Guid id);
    }
}
