using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using midis.muchik.market.application.dto;
using midis.muchik.market.application.interfaces;
using midis.muchik.market.crosscutting.models;

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

        [HttpPost("addCustomer")]
        public GenericResponse<CustomerDto> AddCustomer([FromBody] CustomerDto customerDto)
        {
            return _commonService.AddCustomer(customerDto);
        }
    }
}
