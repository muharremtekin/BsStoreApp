using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;

namespace Entities.DataTransferObjects
{
    public record LinkParameters
    {
        public ProductParameters ProductParameters { get; init; }
        public HttpContext HttpContext { get; init; }
    }
}
