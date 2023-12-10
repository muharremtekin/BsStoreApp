using Entities.DataTransferObjects.Product;
using Entities.LinkModels;
using Microsoft.AspNetCore.Http;

namespace Services.Contracts
{
    public interface IProductLinks
    {
        LinkResponse TryGenerateLinks(IEnumerable<ProductDto> productDtos, string fields, HttpContext httpContext);
    }
}