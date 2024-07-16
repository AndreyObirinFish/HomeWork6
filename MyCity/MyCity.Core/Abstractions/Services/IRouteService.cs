using MyCity.Core.Domain;
using MyCity.Dtos.RouteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCity.Core.Abstractions.Services
{
    public interface IRouteService
    {
        Task<List<Route>> GetAllAsync();
        Task<Route?> GetAsync(Guid id);
        Task<Guid> CreateAsync(CreateOrUpdateRouteDto route);
        Task<bool> UpdateAsync(Guid id, CreateOrUpdateRouteDto route);
        Task<bool> DeleteAsync(Guid id);
    }
}
