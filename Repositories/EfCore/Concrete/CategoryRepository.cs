using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EfCore.Concrete
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCategory(Category category) => Create(category);

        public void DeleteCategory(Category category) => Delete(category);


        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();


        public async Task<Category> GetCategoryByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(c => c.CategoryId.Equals(id), trackChanges)
                .SingleOrDefaultAsync();

        public void UpdateCategory(Category category) => Update(category);
    }
}
