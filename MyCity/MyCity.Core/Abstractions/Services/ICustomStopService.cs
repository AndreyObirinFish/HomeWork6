using MyCity.Core.Domain;
using MyCity.Dtos.CustomStopDtos;
using MyCity.Dtos.RouteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCity.Core.Abstractions.Services
{
    public interface ICustomStopService
    {
        Task<List<CustomStop>> GetAllAsync();
        Task<CustomStop?> GetAsync(Guid id);
        Task<Guid> CreateAsync(CreateOrUpdateCustomStopDto customStop);
        Task<bool> UpdateAsync(Guid id, CreateOrUpdateCustomStopDto customStop);
        Task<bool> DeleteAsync(Guid id);
    }
}
