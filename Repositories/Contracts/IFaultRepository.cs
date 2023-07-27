using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts
{
    public interface IFaultRepository : IRepositoryBase<Fault>
    {
        Task<PagedList<Fault>> GetAllFaultsAsync(FaultParameters faultParameters, bool trackChanges);
        Task<Fault> GetFaultByIdAsync(int id, bool trackChanges);
        void CreateFault(Fault fault);
        void UpdateFault(Fault fault);
        void DeleteFault(Fault fault);
    }
}
