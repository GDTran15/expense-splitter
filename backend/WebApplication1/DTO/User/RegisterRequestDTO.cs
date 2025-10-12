using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO.User
{
    public class RegisterRequestDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters")]
        public string Username { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Pasword must be at least 5 characters")]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

    }
}
