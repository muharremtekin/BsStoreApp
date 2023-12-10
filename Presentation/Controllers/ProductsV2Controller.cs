using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    //[ApiVersion("2.0", Deprecated = true)]
    [ApiController]
    [Route("api/products")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class ProductsV2Controller : ControllerBase
    {
        private readonly IServiceManager _manager;
        public ProductsV2Controller(IServiceManager manager) => _manager = manager;

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            await Task.Delay(100);
            return Ok("Version 2 aviable");
        }
    }
}
