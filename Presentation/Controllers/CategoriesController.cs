using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public CategoriesController(IServiceManager manager) => _manager = manager;

        [HttpGet]
        public async Task<IActionResult> GetAllCategories() =>
            Ok(await _manager.CategoryService.GetAllCategoriesAsync(false));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAllCategories([FromRoute] int id) =>
            Ok(await _manager.CategoryService.GetCategoryByIdAsync(id, false));
    }
}
