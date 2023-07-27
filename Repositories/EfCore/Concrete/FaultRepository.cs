using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EfCore.Concrete
{
    public class FaultRepository : RepositoryBase<Fault>, IFaultRepository
    {
        public FaultRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public void CreateFault(Fault fault) => Create(fault);

        public void DeleteFault(Fault fault) => Delete(fault);

        public void UpdateFault(Fault fault) => Update(fault);

        public async Task<PagedList<Fault>> GetAllFaultsAsync(FaultParameters faultParameters, bool trackChanges)
        {
            var faults = await FindAll(trackChanges)
                .OrderBy(f => f.Id)
                .ToListAsync();

            return PagedList<Fault>
                .ToPagedList(faults, faultParameters.PageNumber, faultParameters.PageSize);
        }

        public async Task<Fault> GetFaultByIdAsync(int id, bool trackChanges)
        {
            var fault = await FindByCondition(f => f.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
            return fault;
        }
    }
}
