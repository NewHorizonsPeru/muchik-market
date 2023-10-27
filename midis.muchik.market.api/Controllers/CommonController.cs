using Microsoft.AspNetCore.Mvc;

namespace midis.muchik.market.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        [HttpGet("getProducts")]
        public IActionResult GetProducts()
        {
            return Ok("Manzana 🍏");
        }
    }
}
