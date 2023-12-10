namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        IFaultRepository Fault { get; }
        IImageRepository Image { get; }
        ICategoryRepository Category { get; }
        Task SaveAsync();
    }
}
