using Entities.DataTransferObjects.Product;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync([FromQuery] ProductParameters productParameters)
        {
            var pagedResult = await _manager
                .ProductService
                .GetAllProductsAsync(productParameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductAsync([FromRoute(Name = "id")] int id)
        {
            var product = await _manager
                .ProductService
                .GetProductByIdAsync(id: id, trackChanges: false);
            return Ok(product);
        }

        [ServiceFilter(typeof(ActionFilters.ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductDtoForInsertion productDto)
        {
            await _manager.ProductService.CreateProductAsync(productDto);
            return StatusCode(201, productDto);
        }

        [ServiceFilter(typeof(ActionFilters.ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProductAsync([FromRoute(Name = "id")] int id, [FromBody] ProductDtoForUpdate productDtoForUpdate)
        {
            await _manager.ProductService.UpdateProductAsync(id: id, productDto: productDtoForUpdate, trackChanges: false);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute(Name = "id")] int id)
        {
            await _manager.ProductService.DeleteProductAsync(id: id, trackChanges: false);
            return NoContent();
        }

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

    }
}
