using midis.muchik.market.application.dto;
using midis.muchik.market.application.dto.common;
using midis.muchik.market.crosscutting.models;

namespace midis.muchik.market.application.interfaces
{
    public interface ICommonService
    {
        GenericResponse<CustomerDto> AddCustomer(CustomerDto customerDto);

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

        GenericResponse<IEnumerable<ProductDto>> GetProducts();
    }
}
