using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Product
{
    public abstract record ProductDtoForManipulation
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MinLength(2, ErrorMessage = "Name must consist of at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Name must consist of at max 100 characters.")]
        public string Name { get; init; }
        public string Category { get; init; }
        public string Model { get; init; }

        [Required(ErrorMessage = "Price is a required field.")]
        public decimal Price { get; init; }

    }
}
