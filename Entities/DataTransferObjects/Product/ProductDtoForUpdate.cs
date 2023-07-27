using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Product
{
    public record ProductDtoForUpdate : ProductDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }
}
