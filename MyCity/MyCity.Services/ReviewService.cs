using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCity.Core.Abstractions;
using MyCity.Core.Abstractions.Services;
using MyCity.Core.Domain;
using MyCity.Dtos.ReviewDto;

namespace MyCity.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await _unitOfWork.ReviewRepository.GetAll().ToListAsync();
        }

        public async Task<Review?> GetAsync(Guid id)
        {
            return await _unitOfWork.ReviewRepository
                .GetById(id)
                .FirstOrDefaultAsync();
        }

        public async Task<Guid> CreateAsync(CreateOrUpdateReviewDto review)
        {
            var reviewForCreate = _mapper.Map<Review>(review);
            
            await _unitOfWork.ReviewRepository.AddAsync(reviewForCreate);
            await _unitOfWork.SaveChangesAsync();
            return reviewForCreate.Id;
        }

        public async Task<bool> UpdateAsync(Guid id, CreateOrUpdateReviewDto review)
        {
            var currentReview = await _unitOfWork
                .ReviewRepository.GetById(id)
                .FirstOrDefaultAsync();
            if (currentReview is null)
                return false;

            currentReview.Rating = review.Rating;
            currentReview.Text = review.Text;

            await _unitOfWork.ReviewRepository.UpdateAsync(currentReview);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var currentReview = await _unitOfWork
                .ReviewRepository.GetById(id)
                .FirstOrDefaultAsync();
            if (currentReview is null)
                return false;

            currentReview.IsActive = false;

            await _unitOfWork.ReviewRepository.UpdateAsync(currentReview);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
