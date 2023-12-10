using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Product
{
    public record ProductDtoForInsertion : ProductDtoForManipulation
    {
        [Required(ErrorMessage = "CategoryId is required")]
        public int CategoryId { get; init; }
    }
}
