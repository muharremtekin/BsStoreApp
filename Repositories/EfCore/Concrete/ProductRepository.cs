using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EfCore.Extensions;

namespace Repositories.EfCore.Concrete
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateProduct(Product product) => Create(product);
        public void DeleteProduct(Product product) => Delete(product);
        public void UpdateProduct(Product product) => Update(product);

        public async Task<PagedList<Product>> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges)
        {
            var products = await FindAll(trackChanges)
                .FilterProducts(productParameters.MinPrice, productParameters.MaxPrice)
                .Search(productParameters.SerachTerm)
                .Sort(productParameters.OrderBy)
                .ToListAsync();

            return PagedList<Product>
                .ToPagedList(products,
                productParameters.PageNumber,
                productParameters.PageSize);
        }

        public async Task<Product> GetProductByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(p => p.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Product>> GetAllProducstWithDetailsAsync(bool trackChanges)
        {
            return await _repositoryContext
                .Products
                .Include(p => p.Category)
                .OrderBy(p => p.Id)
                .ToListAsync();
        }
    }
}
