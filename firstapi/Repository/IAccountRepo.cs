using firstapi.Models;
using Microsoft.AspNetCore.Identity;

namespace firstapi.Repository
{
    public interface IAccountRepo
    {
        Task<IdentityResult> SignUpAsync(Signup signUpModel);
        Task<string> LoginAsync(SignIn signInModel);
    }
}
