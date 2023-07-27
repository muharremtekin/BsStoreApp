using Repositories.Contracts;

namespace Repositories.EfCore.Concrete
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IFaultRepository> _faultRepository;
        private readonly Lazy<IImageRepository> _imageRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_repositoryContext));
            _faultRepository = new Lazy<IFaultRepository>(() => new FaultRepository(_repositoryContext));
            _imageRepository = new Lazy<IImageRepository>(() => new ImageRepository(_repositoryContext));

        }

        public IProductRepository Product => _productRepository.Value;
        public IFaultRepository Fault => _faultRepository.Value;

        public IImageRepository Image => _imageRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
