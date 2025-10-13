using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO.User
{
    public class LoginDTORequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
