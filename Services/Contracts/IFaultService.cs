using Entities.DataTransferObjects.Fault;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts
{
    public interface IFaultService
    {
        Task<(IEnumerable<FaultDto> faults, MetaData metaData)> GetAllFaultsAsync(FaultParameters faultParameters, bool trackChanges);
        Task<FaultDto> GetFaultByIdAsync(int id, bool trackChanges);
        Task<FaultDto> CreateFaultAsync(FaultDtoForInsertion fault);
        Task UpdateFaultAsync(int id, FaultDtoForUpdate faultDto, bool trackChanges);
        Task DeleteFaultAsync(int id, bool trackChanges);
        Task<(FaultDtoForUpdate faultDtoForUpdate, Fault fault)> GetFaultForPatchAsync(int id, bool trackChanges);
        Task SaveChangesForPatchAsync(FaultDtoForUpdate faultDtoForUpdate, Fault fault);
        Task SendMailWithId(int id, bool trackChanges);
    }
}
