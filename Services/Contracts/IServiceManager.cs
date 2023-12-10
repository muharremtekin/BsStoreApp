namespace Services.Contracts
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
        IFaultService FaultService { get; }
        IImageService ImageService { get; }
        IExcelService ExcelService { get; }
        IPdfService PdfService { get; }
        IMailService MailService { get; }
        ICategoryService CategoryService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
