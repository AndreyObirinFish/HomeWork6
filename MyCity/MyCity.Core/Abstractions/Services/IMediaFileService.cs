using MyCity.Core.Domain;
using MyCity.Dtos.MediaFileDtos;

namespace MyCity.Core.Abstractions.Services
{
    public interface IMediaFileService
    {
        Task<List<MediaFile>> GetAllAsync();
        Task<MediaFile?> GetAsync(Guid id);
        Task<Guid> CreateAsync(CreateOrUpdateMediaFileDto mediaFile);
        Task<bool> UpdateAsync(Guid id, CreateOrUpdateMediaFileDto mediaFile);
        Task<bool> DeleteAsync(Guid id);
    }
}
