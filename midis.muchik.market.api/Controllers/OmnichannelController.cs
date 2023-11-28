using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using midis.muchik.market.application.dto.omnichannel;
using midis.muchik.market.application.interfaces;

namespace midis.muchik.market.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OmnichannelController : ControllerBase
    {
        private readonly IOmnichannelService _omnichannelService;

        public OmnichannelController(IOmnichannelService omnichannelService)
        {
            _omnichannelService = omnichannelService;
        }

        [HttpPost("addOrder")]
        public IActionResult AddOrder([FromBody] AddOrderDto addOrderDto) 
        {
            return Ok(_omnichannelService.AddOrder(addOrderDto));
        }
    }
}
