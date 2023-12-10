using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IFaultService> _faultService;
        private readonly Lazy<IImageService> _imageService;
        private readonly Lazy<IExcelService> _excelService;
        private readonly Lazy<IPdfService> _pdfService;
        private readonly Lazy<IMailService> _mailService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<ICategoryService> _categoryService;


        public ServiceManager
            (IRepositoryManager repositoryManager,
            ILoggerService loggerService,
            IMapper mapper,
            IExcelService excelService,
            IPdfService pdfService,
            IMailService mailService,
            IProductLinks productLinks,
            IConfiguration configration,
            //ICategoryService categoryService,
            UserManager<User> userManager)
        {
            _categoryService = new Lazy<ICategoryService>(() => new CategoryManager(repositoryManager));
            _productService = new Lazy<IProductService>(() => new ProductManager(repositoryManager, mapper, productLinks, _categoryService.Value));
            _faultService = new Lazy<IFaultService>(() => new FaultManager(repositoryManager, mapper, mailService: mailService, excelService: excelService, pdfService: pdfService));
            _imageService = new Lazy<IImageService>(() => new ImageManager(repositoryManager, mapper));
            _excelService = new Lazy<IExcelService>(() => new ExcelManager());
            _pdfService = new Lazy<IPdfService>(() => new PdfManager());
            _mailService = new Lazy<IMailService>(() => new MailManager());

            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationManager(loggerService, mapper, userManager, configration));
        }

        public IProductService ProductService => _productService.Value;

        public IFaultService FaultService => _faultService.Value;

        public IImageService ImageService => _imageService.Value;

        public IExcelService ExcelService => _excelService.Value;

        public IPdfService PdfService => _pdfService.Value;

        public IMailService MailService => _mailService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public ICategoryService CategoryService => _categoryService.Value;
    }
}
