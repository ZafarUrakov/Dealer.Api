using Microsoft.AspNetCore.Mvc;

namespace Dealer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Welcome!";
        }
    }
}