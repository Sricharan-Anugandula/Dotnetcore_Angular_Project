using System.ComponentModel.DataAnnotations;

namespace firstapi.Models
{
  
    public class Signup
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        [Compare("CofirmPassword")]
        public string Password { get; set; }
        [Required]
        public string CofirmPassword { get; set; }
      
                
    }
}
