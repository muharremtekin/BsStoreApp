using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.User
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "UserName is required field")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password is required field")]
        public string? Password { get; init; }
    }
}
