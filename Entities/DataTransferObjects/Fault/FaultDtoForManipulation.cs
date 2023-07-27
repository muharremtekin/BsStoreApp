using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Fault
{
    public record FaultDtoForManipulation
    {
        [Required(ErrorMessage = "ProductId is a required field.")]
        public int EntityId { get; set; }
        public string Description { get; set; }
        public DateTime ReportedAt { get; set; }
        public bool IsResolved { get; set; }
    }
}
