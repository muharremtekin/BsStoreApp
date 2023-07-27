using Entities.DataTransferObjects.Image;

namespace Services.Contracts
{
    public interface IImageService
    {
        Task<IEnumerable<ImageDto>> GetAllImagesByEntityIdAsync(int entityId, bool trackChanges);
        Task<ImageDto> CreateImageAsync(ImageDtoForInsertion imageDtoForInsertion);
        Task DeleteImageAsync(int id, bool trackChanges);
        Task UpdateImageAsync(int id, ImageDtoForUpdate imageDto, bool trackChanges);

    }
}
