using Services.Contracts;

namespace Services.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly IFaultService _faultService;
        private readonly IImageService _imageService;
        private readonly IExcelService _excelService;
        private readonly IPdfService _pdfService;
        private readonly IMailService _mailService;
        private readonly IAuthenticationService _authenticationService;
        private readonly ICategoryService _categoryService;

        public ServiceManager(IProductService productService,
            IFaultService faultService,
            IImageService imageService,
            IExcelService excelService,
            IPdfService pdfService,
            IMailService mailService,
            IAuthenticationService authenticationService,
            ICategoryService categoryService)
        {
            _productService = productService;
            _faultService = faultService;
            _imageService = imageService;
            _excelService = excelService;
            _pdfService = pdfService;
            _mailService = mailService;
            _authenticationService = authenticationService;
            _categoryService = categoryService;
        }

        public IProductService ProductService => _productService;

        public IFaultService FaultService => _faultService;

        public IImageService ImageService => _imageService;

        public IExcelService ExcelService => _excelService;

        public IPdfService PdfService => _pdfService;

        public IMailService MailService => _mailService;

        public IAuthenticationService AuthenticationService => _authenticationService;

        public ICategoryService CategoryService => _categoryService;
    }
}
