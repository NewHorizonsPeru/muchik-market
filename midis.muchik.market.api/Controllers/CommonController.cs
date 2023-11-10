using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using midis.muchik.market.application.dto;
using midis.muchik.market.application.dto.common;
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

        #region Brands
        [HttpPost("addBrand")]
        public IActionResult AddBrand([FromBody] AddBrandDto addBrandDto)
        {
            return Ok(_commonService.AddBrand(addBrandDto));
        }
        [HttpPut("updateBrand")]
        public IActionResult UpdateBrand([FromQuery] string brandId,[FromBody] AddBrandDto updateBrandDto)
        {
            return Ok(_commonService.UpdateBrand(brandId, updateBrandDto));
        }
        [HttpDelete("removeBrand")]
        public IActionResult RemoveBrand([FromQuery] string brandId)
        {
            return Ok(_commonService.RemoveBrand(brandId));
        }
        [HttpGet("getBrandById")]
        public IActionResult GetBrandById(string brandId)
        {
            return Ok(_commonService.GetBrandById(brandId));
        }
        [HttpGet("getBrands")]
        public IActionResult GetBrands() 
        {
            return Ok(_commonService.GetBrands());
        }
        #endregion

        #region Categories
        [HttpGet("getCategories")]
        public IActionResult GetCategories()
        {
            return Ok(_commonService.GetCategories());
        }
        #endregion

        #region Products
        [HttpGet("getProducts")]
        public IActionResult GetProducts()
        {
            return Ok(_commonService.GetProducts());
        }
        #endregion

        #region Customers
        [HttpPost("addCustomer")]
        public IActionResult AddCustomer([FromBody] CustomerDto customerDto)
        {
            return Ok(_commonService.AddCustomer(customerDto));
        }
        #endregion
    }
}
