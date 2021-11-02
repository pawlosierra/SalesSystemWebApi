using System.ComponentModel.DataAnnotations;

namespace SalesSystem.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "The field Email is required")]
        [EmailAddress(ErrorMessage = "Email not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field Password is required")]
        public string Password { get; set; }
    }
}
