using Entities.DataTransferObjects.Fault;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [Route("api/faults")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class FaultsController : ControllerBase
    {
        IServiceManager _manager;
        public FaultsController(IServiceManager manager) => _manager = manager;

        [HttpGet]
        public async Task<IActionResult> GetAllFaults([FromQuery] FaultParameters faultParameters)
        {
            var pagedResault = await _manager.FaultService.GetAllFaultsAsync(faultParameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResault.metaData));
            return Ok(pagedResault.faults);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFaultById([FromRoute(Name = "id")] int id)
        {
            var fault = await _manager.FaultService.GetFaultByIdAsync(id, false);
            return Ok(fault);
        }
        [ServiceFilter(typeof(ActionFilters.ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateFault([FromBody] FaultDtoForInsertion faultDto)
        {
            await _manager.FaultService.CreateFaultAsync(faultDto);
            return StatusCode(201, faultDto);
        }
        [ServiceFilter(typeof(ActionFilters.ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateFault([FromRoute(Name = "id")] int id, [FromBody] FaultDtoForUpdate faultDtoForUpdate)
        {
            await _manager.FaultService.UpdateFaultAsync(id, faultDtoForUpdate, false);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFault([FromRoute(Name = "id")] int id)
        {
            await _manager.FaultService.DeleteFaultAsync(id, false);
            return NoContent();
        }
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateFault([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<FaultDtoForUpdate> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest();

            var entity = await _manager.FaultService.GetFaultForPatchAsync(id, false);

            patchDoc.ApplyTo(entity.faultDtoForUpdate, ModelState);

            TryValidateModel(entity.faultDtoForUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _manager.FaultService.SaveChangesForPatchAsync(entity.faultDtoForUpdate, entity.fault);
            return NoContent();
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> SendMailWithId([FromRoute] int id)
        {

            await _manager.FaultService.SendMailWithId(id, false);
            return Ok("Repor mail olarak gönderildi.");
        }

    }
}