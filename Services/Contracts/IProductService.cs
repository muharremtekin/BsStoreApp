using Entities.DataTransferObjects.Product;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<(IEnumerable<ProductDto> products, MetaData metaData)> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges);
        Task<ProductDto> GetProductByIdAsync(int id, bool trackChanges);
        Task<ProductDto> CreateProductAsync(ProductDtoForInsertion product);
        Task UpdateProductAsync(int id, ProductDtoForUpdate productDto, bool trackChanges);
        Task DeleteProductAsync(int id, bool trackChanges);
        Task<(ProductDtoForUpdate productDtoForUpdate, Product product)> GetProductForPatchAsync(int id, bool trackChanges);
        Task SaveChangesForPatchAsync(ProductDtoForUpdate productDtoForUpdate, Product product);
    }
}
