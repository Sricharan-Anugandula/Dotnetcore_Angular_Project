using Microsoft.AspNetCore.Mvc;

namespace firstapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FirstController : Controller
    {
        [HttpGet]
        public string GetFirst()
        {
            return" hello sricharan you will win";
        }
    }
}
