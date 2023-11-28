using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using midis.muchik.market.application.dto;
using midis.muchik.market.application.dto.common;
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
        [HttpPost("addCategory")]
        public IActionResult AddCategory([FromBody] AddCategoryDto addCategoryDto)
        {
            return Ok(_commonService.AddCategory(addCategoryDto));
        }
        [HttpPut("updateCategory")]
        public IActionResult UpdateCategory([FromQuery] string CategoryId, [FromBody] AddCategoryDto updateCategoryDto)
        {
            return Ok(_commonService.UpdateCategory(CategoryId, updateCategoryDto));
        }
        [HttpDelete("removeCategory")]
        public IActionResult RemoveCategory([FromQuery] string CategoryId)
        {
            return Ok(_commonService.RemoveCategory(CategoryId));
        }
        [HttpGet("getCategoryById")]
        public IActionResult GetCategoryById(string CategoryId)
        {
            return Ok(_commonService.GetCategoryById(CategoryId));
        }
        [HttpGet("getCategories")]
        public IActionResult GetCategories()
        {
            return Ok(_commonService.GetCategories());
        }
        #endregion

        #region Products
        [HttpPost("addProduct")]
        public IActionResult AddProduct([FromBody] AddProductDto addProductDto)
        {
            return Ok(_commonService.AddProduct(addProductDto));
        }
        [HttpPut("updateProduct")]
        public IActionResult UpdateProduct([FromQuery] string productId, [FromBody] AddProductDto updateProductDto)
        {
            return Ok(_commonService.UpdateProduct(productId, updateProductDto));
        }
        [HttpDelete("removeProduct")]
        public IActionResult RemoveProduct([FromQuery] string productId)
        {
            return Ok(_commonService.RemoveProduct(productId));
        }
        [HttpGet("getProductById")]
        public IActionResult GetProductById(string productId)
        {
            return Ok(_commonService.GetProductById(productId));
        }
        [HttpGet("getProducts")]
        public IActionResult GetProducts()
        {
            return Ok(_commonService.GetProducts());
        }
        [HttpGet("getProductsByName")]
        public IActionResult GetProductsByName([FromQuery] string search, [FromQuery] int skip, [FromQuery] int take, [FromQuery] string categoryId = "", [FromQuery] string brandId = "")
        {
            return Ok(_commonService.GetProductsByName(search, categoryId, brandId, skip, take));
        }
        #endregion

        #region Customers
        [HttpPost("addCustomer")]
        public IActionResult AddCustomer([FromBody] CustomerDto customerDto)
        {
            return Ok(_commonService.AddCustomer(customerDto));
        }
        [HttpPut("updateCustomer")]
        public IActionResult UpdateCustomer([FromQuery] string customerId, [FromBody] AddCustomerDto updateCustomerDto)
        {
            return Ok(_commonService.UpdateCustomer(customerId, updateCustomerDto));
        }
        [HttpDelete("removeCustomer")]
        public IActionResult RemoveCustomer([FromQuery] string customerId)
        {
            return Ok(_commonService.RemoveCustomer(customerId));
        }
        [HttpGet("getCustomerById")]
        public IActionResult GetCustomerById(string customerId)
        {
            return Ok(_commonService.GetCustomerById(customerId));
        }
        [HttpGet("getCustomers")]
        public IActionResult GetCustomers()
        {
            return Ok(_commonService.GetCustomers());
        }
        #endregion
    }
}
