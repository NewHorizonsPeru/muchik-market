using midis.muchik.market.application.dto;
using midis.muchik.market.crosscutting.models;

namespace midis.muchik.market.application.interfaces
{
    public interface ICommonService
    {
        GenericResponse<CustomerDto> AddCustomer(CustomerDto customerDto);
        GenericResponse<IEnumerable<BrandDto>> GetBrands();
        GenericResponse<IEnumerable<CategoryDto>> GetCategories();
        GenericResponse<IEnumerable<ProductDto>> GetProducts();
    }
}
