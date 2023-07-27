using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Fault
{
    public record FaultDtoForUpdate : FaultDtoForManipulation
    {
        [Required]
        public int Id { get; set; }
    }
}
