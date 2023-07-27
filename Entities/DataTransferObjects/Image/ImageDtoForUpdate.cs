using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Image
{
    public record ImageDtoForUpdate : ImageDtoForManipulation
    {
        [Required(ErrorMessage = "Id is a required field.")]
        public int Id { get; set; }
    }
}
