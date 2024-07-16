using AutoMapper;
using MyCity.Core.Abstractions.Services;
using MyCity.Core.Abstractions;
using MyCity.Core.Domain;
using MyCity.Dtos.PointOfInterestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyCity.Services
{
    public class PointOfInterestService : IPointOfInterestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public PointOfInterestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateOrUpdatePointOfInterestDto pointOfinterest)
        {
            var pointForCreate = _mapper.Map<PointOfInterest>(pointOfinterest);
            await _unitOfWork.PointOfInterestRepository.AddAsync(pointForCreate);
            await _unitOfWork.SaveChangesAsync();
            return pointForCreate.Id;
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            var entityForRemove = await _unitOfWork
                    .PointOfInterestRepository.GetById(id)
                    .FirstOrDefaultAsync();
            if (entityForRemove is null)
                return false;

            await _unitOfWork.PointOfInterestRepository.DeleteAsync(entityForRemove);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<PointOfInterest>> GetAllAsync()
        {
            return await _unitOfWork.PointOfInterestRepository.GetAll().ToListAsync();
        }

        public async Task<PointOfInterest?> GetAsync(Guid id)
        {
            return await _unitOfWork.PointOfInterestRepository
                .GetById(id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Guid id, CreateOrUpdatePointOfInterestDto pointOfinterest)
        {
            var currentPoint = await _unitOfWork
                     .PointOfInterestRepository
                     .GetById(id)
                     .FirstOrDefaultAsync();
            if (currentPoint is null)
                return false;

            currentPoint.Name = pointOfinterest.Name;
            currentPoint.Description = pointOfinterest.Description;
            currentPoint.Address = pointOfinterest.Address;
            currentPoint.Version = pointOfinterest.Version;
            currentPoint.ContactInfo = pointOfinterest.ContactInfo;
            currentPoint.Status = pointOfinterest.Status;

            await _unitOfWork.PointOfInterestRepository.UpdateAsync(currentPoint);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }


    }
}

