using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Services.Concrete;
using Services.Contracts;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
    config.CacheProfiles.Add("1mins", new CacheProfile() { Duration = 60 });
})
    .AddCustomCSVFormatter()
    .AddXmlDataContractSerializerFormatters()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize);


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();

builder.Services.ConfigureEmailService();
builder.Services.ConfigurePdfService();
builder.Services.ConfigureExcelService();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureActionFilters();
builder.Services.ConfigureCors();
builder.Services.ConfigureDataShaper();
builder.Services.AddCustomMediaTypes();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddScoped<IProductLinks, ProductLinks>();
builder.Services.ConfigureVersioning();
builder.Services.ConfigureresponseCaching();
builder.Services.ConfigureHttpCacheHeaders();
builder.Services.AddMemoryCache();
builder.Services.ConfigureRateLimitationOptions();
builder.Services.AddHttpContextAccessor();

builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.RegisterRepositories();
builder.Services.RegisterServices();

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var logger = app.Services.GetRequiredService<ILoggerService>();

app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(sw =>
    {
        sw.SwaggerEndpoint("/swagger/v1/swagger.json", "Store App v1");
        sw.SwaggerEndpoint("/swagger/v2/swagger.json", "Store App v2");
    });
}

if (!app.Environment.IsProduction()) app.UseHsts();

app.UseHttpsRedirection();

app.UseIpRateLimiting();

app.UseCors("CorsPolicy");

app.UseResponseCaching();

app.UseHttpCacheHeaders();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
