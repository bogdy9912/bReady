using System.ComponentModel.DataAnnotations;

namespace bReady.Models.DTOs
{
    public class AuthRequestDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
