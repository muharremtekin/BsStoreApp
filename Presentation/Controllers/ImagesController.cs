using Entities.DataTransferObjects.Image;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(ActionFilters.LogFilterAttribute))]
    [ApiController]
    [Route("api/images")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ImagesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ImagesController(IServiceManager manager) => _manager = manager;

        [HttpGet("{entityId:int}")]
        public async Task<IActionResult> GetAllImagesByEntityIdAsync([FromRoute(Name = "entityId")] int entityId)
        {
            var images = await _manager.ImageService.GetAllImagesByEntityIdAsync(entityId, trackChanges: false);
            return Ok(images);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImageAsync([FromBody] ImageDtoForInsertion imageDto)
        {
            await _manager.ImageService.CreateImageAsync(imageDto);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteImageAsync([FromRoute(Name = "id")] int id)
        {
            await _manager.ImageService.DeleteImageAsync(id, trackChanges: false);
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateImageAsync([FromRoute(Name = "id")] int id, [FromBody] ImageDtoForUpdate imageDto)
        {
            await _manager.ImageService.UpdateImageAsync(id, imageDto, trackChanges: false);
            return Ok();
        }
    }
}
