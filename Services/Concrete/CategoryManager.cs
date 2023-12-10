using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;
        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges) =>
            await _manager.Category.GetAllCategoriesAsync(trackChanges);


        public async Task<Category> GetCategoryByIdAsync(int id, bool trackChanges)
        {
            var category = await _manager.Category.GetCategoryByIdAsync(id, trackChanges);

            if (category is null)
                throw new CategoryNotFoundException(id);

            return category;
        }
    }
}
