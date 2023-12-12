using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Upload([FromBody] IFormFile formFile)
        {
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "Media");
            if (Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var path = Path.Combine(folder, formFile.FileName);



            return Ok();
        }
    }
}
