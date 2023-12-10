using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Product;
using Entities.LinkModels;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<(LinkResponse linkResponse, MetaData metaData)> GetAllProductsAsync(LinkParameters linkParameters, bool trackChanges);
        Task<IEnumerable<Product>> GetAllProducstWithDetailsAsync(bool trackChanges);
        Task<ProductDto> GetProductByIdAsync(int id, bool trackChanges);
        Task<ProductDto> CreateProductAsync(ProductDtoForInsertion product);
        Task UpdateProductAsync(int id, ProductDtoForUpdate productDto, bool trackChanges);
        Task DeleteProductAsync(int id, bool trackChanges);
        Task<(ProductDtoForUpdate productDtoForUpdate, Product product)> GetProductForPatchAsync(int id, bool trackChanges);
        Task SaveChangesForPatchAsync(ProductDtoForUpdate productDtoForUpdate, Product product);
    }
}
