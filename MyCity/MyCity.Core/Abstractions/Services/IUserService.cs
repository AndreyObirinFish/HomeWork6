using Dtos.UserDtos;
using MyCity.Core.Domain;

namespace MyCity.Core.Abstractions.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetAsync(Guid id);
        Task<Guid> CreateAsync(CreateOrUpdateUserDto user);
        Task<bool> UpdateAsync(Guid id, CreateOrUpdateUserDto user);
        Task<bool> DeleteAsync(Guid id);
    }
}
    