using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCity.Core.Abstractions;
using MyCity.Core.Abstractions.Services;
using MyCity.Core.Domain;
using MyCity.Dtos.MediaFileDtos;

namespace MyCity.Services
{
    public class MediaFileService : IMediaFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MediaFileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MediaFile>> GetAllAsync()
        {
            return await _unitOfWork.MediaFilesRepository.GetAll().ToListAsync();
        }

        public async Task<MediaFile?> GetAsync(Guid id)
        {
            return await _unitOfWork.MediaFilesRepository
                .GetById(id)
                .FirstOrDefaultAsync();
        }

        public async Task<Guid> CreateAsync(CreateOrUpdateMediaFileDto mediaFile)
        {
            var mediaFileForCreate = _mapper.Map<MediaFile>(mediaFile);
            
            await _unitOfWork.MediaFilesRepository.AddAsync(mediaFileForCreate);
            await _unitOfWork.SaveChangesAsync();
            return mediaFileForCreate.Id;
        }

        public async Task<bool> UpdateAsync(Guid id, CreateOrUpdateMediaFileDto mediaFile)
        {
            var currentMediaFile = await _unitOfWork
                .MediaFilesRepository.GetById(id)
                .FirstOrDefaultAsync();
            if (currentMediaFile is null)
                return false;

            currentMediaFile.Description = mediaFile.Description;
            currentMediaFile.MediaFileType = mediaFile.MediaFileType;
            currentMediaFile.Uri = mediaFile.Uri;

            await _unitOfWork.MediaFilesRepository.UpdateAsync(currentMediaFile);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var currentMediaFile = await _unitOfWork
                .MediaFilesRepository.GetById(id)
                .FirstOrDefaultAsync();
            if (currentMediaFile is null)
                return false;

            currentMediaFile.IsActive = false;

            await _unitOfWork.MediaFilesRepository.UpdateAsync(currentMediaFile);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
