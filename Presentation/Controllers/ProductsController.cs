using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Product;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    //[ApiVersion("1.0")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/products")]
    //[ResponseCache(CacheProfileName = "1mins")]
    //[Route("api/{v:apiversion}/products")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ProductsController(IServiceManager manager) => _manager = manager;

        [Authorize]
        [HttpHead]
        [HttpGet(Name = "GetAllProductsAsync")]
        //[ResponseCache(Duration = 60)]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetAllProductsAsync([FromQuery] ProductParameters productParameters)
        {
            var d = @"\";
            var linkParameters = new LinkParameters
            {
                ProductParameters = productParameters,
                HttpContext = HttpContext
            };

            var result = await _manager
                .ProductService
                .GetAllProductsAsync(linkParameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));
            return result.linkResponse.HasLinks ?
                Ok(result.linkResponse.LinkedEntities) :
                Ok(result.linkResponse.ShapedEntities);
        }
        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductAsync([FromRoute(Name = "id")] int id)
        {
            var product = await _manager
                .ProductService
                .GetProductByIdAsync(id: id, trackChanges: false);
            return Ok(product);
        }

        [Authorize]
        [HttpGet("details")]
        public async Task<IActionResult> GetAllBooksWithDetailsAsync()
        {
            return Ok(await _manager.ProductService.GetAllProducstWithDetailsAsync(false));
        }

        [Authorize(Roles = "Editor, Admin")]
        [ServiceFilter(typeof(ActionFilters.ValidationFilterAttribute))]
        [HttpPost(Name = "CreateProductAsync")]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductDtoForInsertion productDto)
        {
            await _manager.ProductService.CreateProductAsync(productDto);
            return StatusCode(201, productDto);
        }

        [Authorize(Roles = "Editor, Admin")]
        [ServiceFilter(typeof(ActionFilters.ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProductAsync([FromRoute(Name = "id")] int id, [FromBody] ProductDtoForUpdate productDtoForUpdate)
        {
            await _manager.ProductService.UpdateProductAsync(id: id, productDto: productDtoForUpdate, trackChanges: false);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute(Name = "id")] int id)
        {
            await _manager.ProductService.DeleteProductAsync(id: id, trackChanges: false);
            return NoContent();
        }

        [Authorize(Roles = "Editor, Admin")]
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateProductAsync([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<ProductDtoForUpdate> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest();

            var result = await _manager.ProductService.GetProductForPatchAsync(id: id, trackChanges: false);

            patchDoc.ApplyTo(result.productDtoForUpdate, ModelState);

            TryValidateModel(result.productDtoForUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _manager.ProductService.SaveChangesForPatchAsync(result.productDtoForUpdate, result.product);

            return NoContent();
        }

        [Authorize]
        [HttpOptions]
        public IActionResult GetProductActions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, PATCH, DELETE, HEAD, OPTIONS");
            return Ok();
        }
    }
}
