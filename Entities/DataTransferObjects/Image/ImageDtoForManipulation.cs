using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Image
{
    public abstract record ImageDtoForManipulation
    {
        [Required(ErrorMessage = "Name is a required field.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "ImageData is a required field.")]
        public byte[] ImageData { get; set; }
        [Required(ErrorMessage = "ProductId is a required field.")]
        public int ProductId { get; set; }
    }
}
