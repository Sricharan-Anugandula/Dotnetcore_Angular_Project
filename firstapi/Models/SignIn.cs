using System.ComponentModel.DataAnnotations;

namespace firstapi.Models
{
    public class SignIn
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set;}
    }
}
