using AutoMapper;
using Entities.DataTransferObjects.Fault;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete
{
    public class FaultManager : IFaultService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;
        private readonly IPdfService _pdfService;
        private readonly IMailService _mailService;

        public FaultManager(IRepositoryManager manager, IMapper mapper, IMailService mailService, IExcelService excelService, IPdfService pdfService)
        {
            _manager = manager;
            _mapper = mapper;
            _mailService = mailService;
            _excelService = excelService;
            _pdfService = pdfService;
        }
        public async Task<FaultDto> CreateFaultAsync(FaultDtoForInsertion faultDtoForInsertion)
        {
            var entity = _mapper.Map<Fault>(faultDtoForInsertion);
            _manager.Fault.CreateFault(entity);
            await _manager.SaveAsync();
            return _mapper.Map<FaultDto>(entity);
        }
        public async Task DeleteFaultAsync(int id, bool trackChanges)
        {
            var entity = await GetFaultByIdAndExistAsync(id, trackChanges);
            _manager.Fault.DeleteFault(entity);
            await _manager.SaveAsync();
        }
        public async Task<(IEnumerable<FaultDto> faults, MetaData metaData)> GetAllFaultsAsync(FaultParameters faultParameters, bool trackChanges)
        {
            var faultsWithMetaData = await _manager.Fault.GetAllFaultsAsync(faultParameters, trackChanges);
            var faultsDto = _mapper.Map<IEnumerable<FaultDto>>(faultsWithMetaData);
            return (faultsDto, faultsWithMetaData.MetaData);
        }
        public async Task<FaultDto> GetFaultByIdAsync(int id, bool trackChanges)
        {
            var fault = await GetFaultByIdAndExistAsync(id, trackChanges);
            return _mapper.Map<FaultDto>(fault);
        }
        public async Task<(FaultDtoForUpdate faultDtoForUpdate, Fault fault)> GetFaultForPatchAsync(int id, bool trackChanges)
        {
            var fault = await GetFaultByIdAndExistAsync(id, trackChanges);
            var faultDtoForUpdate = _mapper.Map<FaultDtoForUpdate>(fault);
            return (faultDtoForUpdate, fault);
        }
        public async Task SaveChangesForPatchAsync(FaultDtoForUpdate faultDtoForUpdate, Fault fault)
        {
            _mapper.Map(faultDtoForUpdate, fault);
            await _manager.SaveAsync();
        }
        public async Task UpdateFaultAsync(int id, FaultDtoForUpdate faultDto, bool trackChanges)
        {
            var entity = await GetFaultByIdAndExistAsync(id, trackChanges);
            entity = _mapper.Map<Fault>(faultDto);
            _manager.Fault.UpdateFault(entity);
            await _manager.SaveAsync();
        }
        private async Task<Fault> GetFaultByIdAndExistAsync(int id, bool trackChanges)
        {
            var entity = await _manager.Fault.GetFaultByIdAsync(id, trackChanges);
            if (entity is null) throw new FaultNotFoundException(id: id);
            return entity;
        }
        public async Task SendMailWithId(int id, bool trackChanges)
        {
            var entity = await GetFaultByIdAndExistAsync(id, trackChanges);
            List<Fault> list = new List<Fault> { entity };
            byte[] pdfBytes = await _pdfService.ExportPdfListAsync(list);
            byte[] excelBytes = await _excelService.ExportExcelListAsync(list, "A1");

            string body = "Bir arıza rapor edildi!";
            if (pdfBytes is null || excelBytes is null) throw new PdfOrExcelBytesNullException("PDF ya da Excel'e dönüştürülürken hata oluştu!");

            _mailService.SendEmailWithAttachments(toEmail: "nurd.contact@gmail.com", body: body, subject: "SUBJECT", pdfBytes: pdfBytes, excelBytes: excelBytes, isHtml: false);
        }
    }
}
