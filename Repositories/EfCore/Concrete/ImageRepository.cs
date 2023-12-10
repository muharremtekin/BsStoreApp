using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EfCore.Concrete
{
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateImage(Image image) => Create(image);

        public void DeleteImage(Image image) => Delete(image);

        public async Task<List<Image>> GetAllImagesByEntityIdAsync(int entityId, bool trackChanges) =>
            await FindByCondition(i => i.EntityId.Equals(entityId), trackChanges)
            .ToListAsync();

        public async Task<Image> GetImageByIdAsync(int id, bool trackChanges) =>
             await FindByCondition(i => i.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void UpdateImage(Image image) => Update(image);
    }
}
