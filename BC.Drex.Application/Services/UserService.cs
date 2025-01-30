using BC.Drex.Domain.Entities;
using BC.Drex.Domain.Interfaces.Repositories;
using BC.Drex.Domain.Interfaces.Services;

namespace BC.Drex.Application.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<IEnumerable<User>>> GetAllAsync()
        {
            try
            {
                var users = await _repository.GetAll();
                return ServiceResult<IEnumerable<User>>.SuccessResult(users);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<User>>.FailureResult($"Error, {ex.Message}");
            }
        }

        public async Task<ServiceResult<User>> GetByIdAsync(Guid id)
        {
            try
            {
                var user = await _repository.GetByIdAsync(id);
                if (user == null)
                    return ServiceResult<User>.FailureResult("User doesn't exist.");

                return ServiceResult<User>.SuccessResult(user);
            }
            catch (Exception ex)
            {
                return ServiceResult<User>.FailureResult($"Error, {ex.Message}");
            }
        }

        public async Task<ServiceResult<User>> UpdateAsync(User entity)
        {
            try
            {
                var exist = await _repository.GetByIdAsync(entity.Id);
                if (exist == null)
                    return ServiceResult<User>.FailureResult("User doesn't exist.");

                exist.Name = entity.Name;

                await _repository.UpdateAsync(exist);
                return ServiceResult<User>.SuccessResult(exist);
            }
            catch (Exception ex)
            {
                return ServiceResult<User>.FailureResult($"Error, {ex.Message}");
            }
        }
    }
}
