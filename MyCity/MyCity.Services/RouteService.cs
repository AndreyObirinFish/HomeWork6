using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCity.Core.Abstractions;
using MyCity.Core.Abstractions.Services;
using MyCity.Core.Domain;
using MyCity.Dtos.PointOfInterestDtos;
using MyCity.Dtos.RouteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCity.Services
{
    public class RouteService : IRouteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public RouteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateOrUpdateRouteDto pointOfinterest)
        {
            var pointForCreate = _mapper.Map<Route>(pointOfinterest);
            await _unitOfWork.RouteRepository.AddAsync(pointForCreate);
            await _unitOfWork.SaveChangesAsync();
            return pointForCreate.Id;
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            var entityForRemove = await _unitOfWork
                    .RouteRepository.GetById(id)
                    .FirstOrDefaultAsync();
            if (entityForRemove is null)
                return false;

            await _unitOfWork.RouteRepository.DeleteAsync(entityForRemove);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<Route>> GetAllAsync()
        {
            return await _unitOfWork.RouteRepository.GetAll().ToListAsync();
        }

        public async Task<Route?> GetAsync(Guid id)
        {
            return await _unitOfWork.RouteRepository
                .GetById(id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Guid id, CreateOrUpdateRouteDto route)
        {
            var currentPoint = await _unitOfWork
                     .RouteRepository
                     .GetById(id)
                     .FirstOrDefaultAsync();
            if (currentPoint is null)
                return false;

            currentPoint.Name = route.Name;
            currentPoint.Description = route.Description;

            await _unitOfWork.RouteRepository.UpdateAsync(currentPoint);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }


    }
    
}
