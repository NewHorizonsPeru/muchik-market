using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace midis.muchik.market.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OmnichannelController : ControllerBase
    {
    }
}
