using Repositories.Contracts;

namespace Repositories.EfCore.Concrete
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IProductRepository _productRepository;
        private readonly IFaultRepository _faultRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RepositoryManager(RepositoryContext repositoryContext,
            IProductRepository productRepository,
            IFaultRepository faultRepository,
            IImageRepository imageRepository,
            ICategoryRepository categoryRepository)
        {
            _repositoryContext = repositoryContext;
            _productRepository = productRepository;
            _faultRepository = faultRepository;
            _imageRepository = imageRepository;
            _categoryRepository = categoryRepository;
        }

        public IProductRepository Product => _productRepository;
        public IFaultRepository Fault => _faultRepository;
        public IImageRepository Image => _imageRepository;
        public ICategoryRepository Category => _categoryRepository;
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
