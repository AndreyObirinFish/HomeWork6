using MyCity.Core.Domain;
using MyCity.Dtos.ReviewDto;

namespace MyCity.Core.Abstractions.Services
{
    public interface IReviewService
    {
        Task<List<Review>> GetAllAsync();
        Task<Review?> GetAsync(Guid id);
        Task<Guid> CreateAsync(CreateOrUpdateReviewDto review);
        Task<bool> UpdateAsync(Guid id, CreateOrUpdateReviewDto review);
        Task<bool> DeleteAsync(Guid id);
    }
}
