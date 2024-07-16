using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCity.Core.Abstractions;
using MyCity.Core.Abstractions.Services;
using MyCity.Core.Domain;
using MyCity.Dtos.CustomStopDtos;
using MyCity.Dtos.RouteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCity.Services
{
    public class CustomStopService:ICustomStopService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CustomStopService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateOrUpdateCustomStopDto customStop)
        {
            var pointForCreate = _mapper.Map<CustomStop>(customStop);
            await _unitOfWork.CustomStopRepository.AddAsync(pointForCreate);
            await _unitOfWork.SaveChangesAsync();
            return pointForCreate.Id;
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            var entityForRemove = await _unitOfWork
                    .CustomStopRepository.GetById(id)
                    .FirstOrDefaultAsync();
            if (entityForRemove is null)
                return false;

            await _unitOfWork.CustomStopRepository.DeleteAsync(entityForRemove);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<CustomStop>> GetAllAsync()
        {
            return await _unitOfWork.CustomStopRepository.GetAll().ToListAsync();
        }

        public async Task<CustomStop?> GetAsync(Guid id)
        {
            return await _unitOfWork.CustomStopRepository
                .GetById(id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Guid id, CreateOrUpdateCustomStopDto customStop)
        {
            var _customStop = await _unitOfWork
                     .CustomStopRepository
                     .GetById(id)
                     .FirstOrDefaultAsync();
            if (_customStop is null)
                return false;
            _customStop.PointOfInterestId = customStop.PointOfInterestId;
            _customStop.Description = customStop.Description;


            await _unitOfWork.CustomStopRepository.UpdateAsync(_customStop);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
