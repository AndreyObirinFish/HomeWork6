using Dtos.RoleDtos;
using MyCity.Core.Domain;

namespace MyCity.Core.Abstractions.Services
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllAsync();
        Task<Role> GetAsync(Guid id);
        Task<Guid> CreateAsync(CreateOrUpdateRoleDto role);
        Task<bool> UpdateAsync(Guid id, CreateOrUpdateRoleDto role);
        Task<bool> DeleteAsync(Guid id);
    }
}
