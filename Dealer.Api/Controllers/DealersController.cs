using Microsoft.AspNetCore.Mvc;

namespace Dealer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
    public class DealersController : Controller
    {
        [HttpPost]
        public ActionResult Import()
        {
            return Ok();
        }
    }
}