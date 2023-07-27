using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Presentation.ActionFilters;
using Repositories.Contracts;
using Repositories.EfCore.Concrete;
using Services.Concrete;
using Services.Contracts;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(
                options => options
                .UseSqlServer(configuration
                .GetConnectionString("sqlConnection"))
            );
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerManager>();
        public static void ConfigureEmailService(this IServiceCollection services) =>
            services.AddScoped<IMailService, MailManager>();
        public static void ConfigurePdfService(this IServiceCollection services) =>
            services.AddScoped<IPdfService, PdfManager>();
        public static void ConfigureExcelService(this IServiceCollection services)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            services.AddScoped<IExcelService, ExcelManager>();
        }

        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddSingleton<LogFilterAttribute>();
        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination"));
            });
        }
    }
}
