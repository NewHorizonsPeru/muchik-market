using midis.muchik.market.application.dto;
using midis.muchik.market.application.dto.common;
using midis.muchik.market.crosscutting.models;

namespace midis.muchik.market.application.interfaces
{
    public interface ICommonService
    {
        GenericResponse<BrandDto> AddBrand(AddBrandDto addBrandDto);
        GenericResponse<BrandDto> UpdateBrand(string brandId, AddBrandDto addBrandDto);
        GenericResponse<BrandDto> RemoveBrand(string brandId);
        GenericResponse<BrandDto> GetBrandById(string brandId);
        GenericResponse<IEnumerable<BrandDto>> GetBrands();

        GenericResponse<CategoryDto> AddCategory(AddCategoryDto addCategoryDto);
        GenericResponse<CategoryDto> UpdateCategory(string categoryId, AddCategoryDto addCategoryDto);
        GenericResponse<CategoryDto> RemoveCategory(string categoryId);
        GenericResponse<CategoryDto> GetCategoryById(string categoryId);
        GenericResponse<IEnumerable<CategoryDto>> GetCategories();

        GenericResponse<ProductDto> AddProduct(AddProductDto addProductDto);
        GenericResponse<ProductDto> UpdateProduct(string productId, AddProductDto addProductDto);
        GenericResponse<ProductDto> RemoveProduct(string productId);
        GenericResponse<ProductDto> GetProductById(string productId);
        GenericResponse<IEnumerable<ProductDto>> GetProducts();
        GenericResponse<IEnumerable<ProductDto>> GetProductsByName(string search, string categoryId, string brandId, int skip, int take);

        GenericResponse<CustomerDto> AddCustomer(CustomerDto customerDto);
        GenericResponse<CustomerDto> UpdateCustomer(string customerId, AddCustomerDto addCustomerDto);
        GenericResponse<CustomerDto> RemoveCustomer(string customerId);
        GenericResponse<CustomerDto> GetCustomerById(string customerId);
        GenericResponse<IEnumerable<CustomerDto>> GetCustomers();
    }
}
