using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EfCore.Concrete
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
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
                .OrderBy(p => p.Id)
                .ToListAsync();

            return PagedList<Product>
                .ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
        }

        public async Task<Product> GetProductByIdAsync(int id, bool trackChanges)
        {
            var product = await FindByCondition(p => p.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
            return product;
        }


    }
}
