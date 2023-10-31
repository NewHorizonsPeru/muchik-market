using Microsoft.AspNetCore.Mvc;
using midis.muchik.market.application.interfaces;

namespace midis.muchik.market.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;

        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpGet("getBrands")]
        public IActionResult GetBrands() 
        {
            return Ok(_commonService.GetBrands());
        }
    }
}
