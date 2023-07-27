using AutoMapper;
using Entities.DataTransferObjects.Image;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ImageManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ImageDto> CreateImageAsync(ImageDtoForInsertion imageDtoForInsertion)
        {
            var entity = _mapper.Map<Image>(imageDtoForInsertion);
            _manager.Image.CreateImage(entity);
            await _manager.SaveAsync();
            return _mapper.Map<ImageDto>(entity);
        }

        public async Task DeleteImageAsync(int id, bool trackChanges)
        {
            var entity = await GetImageByIdAndExistAsync(id, false);
            _manager.Image.DeleteImage(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<ImageDto>> GetAllImagesByEntityIdAsync(int entityId, bool trackChanges)
        {
            var images = await _manager.Image.GetAllImagesByEntityIdAsync(entityId, trackChanges);
            return _mapper.Map<IEnumerable<ImageDto>>(images);
        }

        public async Task UpdateImageAsync(int id, ImageDtoForUpdate imageDtoForUpdate, bool trackChanges)
        {
            var entity = await GetImageByIdAndExistAsync(id, trackChanges);
            entity = _mapper.Map(imageDtoForUpdate, entity);
            _manager.Image.UpdateImage(entity);
            await _manager.SaveAsync();
        }
        private async Task<Image> GetImageByIdAndExistAsync(int id, bool trackChanges)
        {
            var entity = await _manager.Image.GetImageByIdAsync(id, trackChanges);
            if (entity is null) throw new ImageNotFoundException(id: id);
            return entity;
        }
    }
}
