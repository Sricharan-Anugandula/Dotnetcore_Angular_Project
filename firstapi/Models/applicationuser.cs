using Microsoft.AspNetCore.Identity;

namespace firstapi.Models
{
    public class applicationuser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
