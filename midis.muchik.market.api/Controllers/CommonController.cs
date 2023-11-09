using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using midis.muchik.market.application.interfaces;

namespace midis.muchik.market.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("getCategories")]
        public IActionResult GetCategories()
        {
            return Ok(_commonService.GetCategories());
        }

        [HttpGet("getProducts")]
        public IActionResult GetProducts()
        {
            return Ok(_commonService.GetProducts());
        }
    }
}
