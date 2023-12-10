using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Product;
using Entities.Exceptions;
using Entities.LinkModels;
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
        private readonly IProductLinks _productLinks;
        private readonly ICategoryService _categoryService;

        public ProductManager(IRepositoryManager manager, IMapper mapper, IProductLinks productLinks, ICategoryService categoryService)
        {
            _manager = manager;
            _mapper = mapper;
            _productLinks = productLinks;
            _categoryService = categoryService;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDtoForInsertion product)
        {
            var category = await _categoryService.GetCategoryByIdAsync(product.CategoryId, false);


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

        public async Task<(LinkResponse linkResponse, MetaData metaData)> GetAllProductsAsync(LinkParameters linkParameters, bool trackChanges)
        {
            //if (!linkParameters.ProductParameters.ValidPriceRage)
            //    throw new PriceOutofRangeBadRequestException();

            var productsWithMetaData = await _manager
                .Product
                .GetAllProductsAsync(linkParameters.ProductParameters, trackChanges);

            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsWithMetaData);

            var links = _productLinks
                .TryGenerateLinks(productsDto, linkParameters.ProductParameters.Fields, linkParameters.HttpContext);

            return (linkResponse: links, metaData: productsWithMetaData.MetaData);
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

        public async Task<IEnumerable<Product>> GetAllProducstWithDetailsAsync(bool trackChanges) => await _manager
                .Product
                .GetAllProducstWithDetailsAsync(false);
    }
}
