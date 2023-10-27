using Microsoft.AspNetCore.Mvc;
using midis.muchik.market.infrastructure.context;

namespace midis.muchik.market.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly MuchikContext _context;

        public CommonController(MuchikContext context)
        {
            _context = context;
        }

        [HttpGet("getProducts")]
        public IActionResult GetProducts()
        {
            return Ok(_context.Brands);
        }
    }
}
