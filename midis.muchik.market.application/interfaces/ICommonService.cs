using midis.muchik.market.application.dto;

namespace midis.muchik.market.application.interfaces
{
    public interface ICommonService
    {
        IEnumerable<BrandDto> GetBrands();
    }
}
