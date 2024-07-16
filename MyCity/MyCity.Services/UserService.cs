using AutoMapper;
using Dtos.UserDtos;
using Microsoft.EntityFrameworkCore;
using MyCity.Core.Abstractions;
using MyCity.Core.Abstractions.Services;
using MyCity.Core.Domain;

namespace MyCity.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateOrUpdateUserDto user)
        {
            var userForCreate = _mapper.Map<User>(user);

            var role = await _unitOfWork.RolesRepository.GetAll().FirstOrDefaultAsync();

            userForCreate.RoleId = role.Id;

            await _unitOfWork.UsersRepository.AddAsync(userForCreate);
            await _unitOfWork.SaveChangesAsync();
            return userForCreate.Id;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entityForRemove = await _unitOfWork
                                            .UsersRepository.GetById(id)
                                            .FirstOrDefaultAsync();
            if (entityForRemove is null)
                return false;

            await _unitOfWork.UsersRepository.DeleteAsync(entityForRemove);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _unitOfWork.UsersRepository.GetAll().ToListAsync();
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await _unitOfWork.UsersRepository
                                        .GetById(id)
                                        .Include(x => x.Role)
                                        .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Guid id, CreateOrUpdateUserDto user)
        {
            var currentUser = await _unitOfWork
                                           .UsersRepository
                                           .GetById(id)
                                           .FirstOrDefaultAsync();
            if (currentUser is null)
                return false;

            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.MiddleName = user.MiddleName;
            currentUser.Nickname = user.Nickname;
            currentUser.Email = user.Email;
            currentUser.Password = user.Password;
            currentUser.AgreeOnPersonalDataProcessing = user.AgreeOnPersonalDataProcessing;
            
            await _unitOfWork.UsersRepository.UpdateAsync(currentUser);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
