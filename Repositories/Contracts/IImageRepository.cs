using Entities.Models;

namespace Repositories.Contracts
{
    public interface IImageRepository : IRepositoryBase<Image>
    {
        void CreateImage(Image image);
        void UpdateImage(Image image);
        void DeleteImage(Image image);
        Task<Image> GetImageByIdAsync(int id, bool trackChanges);
        Task<List<Image>> GetAllImagesByEntityIdAsync(int productId, bool trackChanges);
    }
}
