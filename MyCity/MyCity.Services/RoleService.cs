using AutoMapper;
using Dtos.RoleDtos;
using Microsoft.EntityFrameworkCore;
using MyCity.Core.Abstractions;
using MyCity.Core.Abstractions.Services;
using MyCity.Core.Domain;

namespace MyCity.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateOrUpdateRoleDto role)
        {
            var roleForCreate = _mapper.Map<Role>(role);
            
            await _unitOfWork.RolesRepository.AddAsync(roleForCreate);
            await _unitOfWork.SaveChangesAsync();
            return roleForCreate.Id;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entityForRemove = await _unitOfWork
                                            .RolesRepository.GetById(id)
                                            .FirstOrDefaultAsync();
            if (entityForRemove is null)
                return false;

            await _unitOfWork.RolesRepository.DeleteAsync(entityForRemove);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _unitOfWork.RolesRepository.GetAll().ToListAsync();
        }

        public async Task<Role> GetAsync(Guid id)
        {
            return await _unitOfWork.RolesRepository
                                        .GetById(id)
                                        .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Guid id, CreateOrUpdateRoleDto role)
        {
            var currentRole = await _unitOfWork
                                           .RolesRepository.GetById(id)
                                           .FirstOrDefaultAsync();
            if (currentRole is null)
                return false;

            currentRole.Name = role.Name;
            await _unitOfWork.RolesRepository.UpdateAsync(currentRole);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
