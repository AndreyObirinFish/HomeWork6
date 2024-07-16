using MyCity.Core.Domain;
using MyCity.Dtos.PointOfInterestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCity.Core.Abstractions.Services
{
    public interface IPointOfInterestService
    {
        Task<List<PointOfInterest>> GetAllAsync();
        Task<PointOfInterest?> GetAsync(Guid id);
        Task<Guid> CreateAsync(CreateOrUpdatePointOfInterestDto pointOfInterest);
        Task<bool> UpdateAsync(Guid id, CreateOrUpdatePointOfInterestDto pointOfInterest);
        Task<bool> DeleteAsync(Guid id);
    }
}
