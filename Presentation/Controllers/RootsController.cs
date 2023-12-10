using Entities.LinkModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class RootsController : ControllerBase
    {
        private readonly LinkGenerator _linkGenerator;
        public RootsController(LinkGenerator linkGenerator) => _linkGenerator = linkGenerator;

        [HttpGet(Name = "GetRoot")]
        public async Task<IActionResult> GetRoot([FromHeader(Name = "Accept")] string mediaType)
        {
            if (mediaType.Contains("application/vnd.btkakademi.apiroot"))
            {
                var list = new List<Link>
                {
                    new Link
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext,nameof(GetRoot),new{}),
                        Rel="_self",
                        Method="GET"
                    },
                    new Link
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext,nameof(ProductsController.GetAllProductsAsync),new{}),
                        Rel="products",
                        Method="GET"
                    },
                    new Link
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext,nameof(ProductsController.CreateProductAsync),new{}),
                        Rel="products",
                        Method="POST"
                    },
                };
                return Ok(list);
            }
            return NoContent();
        }
    }
}
