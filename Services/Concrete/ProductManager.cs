using AutoMapper;
using Entities.DataTransferObjects.Product;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDtoForInsertion product)
        {
            var entity = _mapper.Map<Product>(product);
            _manager.Product.CreateProduct(entity);
            await _manager.SaveAsync();
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task DeleteProductAsync(int id, bool trackChanges)
        {
            var entity = await GetProductByIdAndExistAsync(id, trackChanges);
            _manager.Product.DeleteProduct(entity);
            await _manager.SaveAsync();
        }

        private async Task<Product> GetProductByIdAndExistAsync(int id, bool trackChanges)
        {
            var entity = await _manager.Product.GetProductByIdAsync(id, trackChanges);
            if (entity is null) throw new ProductNotFoundException(id: id);
            return entity;
        }

        public async Task<(IEnumerable<ProductDto> products, MetaData metaData)> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges)
        {
            var productsWithMetaData = await _manager.Product.GetAllProductsAsync(productParameters, trackChanges);
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsWithMetaData);
            return (productsDto, productsWithMetaData.MetaData);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id, bool trackChanges)
        {
            var product = await GetProductByIdAndExistAsync(id, trackChanges);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<(ProductDtoForUpdate productDtoForUpdate, Product product)> GetProductForPatchAsync(int id, bool trackChanges)
        {
            var product = await GetProductByIdAndExistAsync(id, trackChanges);
            var productDtoForUpdate = _mapper.Map<ProductDtoForUpdate>(product);
            return (productDtoForUpdate, product);
        }

        public async Task SaveChangesForPatchAsync(ProductDtoForUpdate productDtoForUpdate, Product product)
        {
            _mapper.Map(productDtoForUpdate, product);
            await _manager.SaveAsync();
        }

        public async Task UpdateProductAsync(int id, ProductDtoForUpdate productDto, bool trackChanges)
        {
            var entity = await GetProductByIdAndExistAsync(id, trackChanges);
            entity = _mapper.Map<Product>(productDto);
            _manager.Product.UpdateProduct(entity);
            await _manager.SaveAsync();
        }
    }
}
