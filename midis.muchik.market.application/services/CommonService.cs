using AutoMapper;
using midis.muchik.market.application.dto;
using midis.muchik.market.application.interfaces;
using midis.muchik.market.domain.entities;
using midis.muchik.market.domain.interfaces;

namespace midis.muchik.market.application.services
{
    public class CommonService : ICommonService
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;

        public CommonService(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public IEnumerable<BrandDto> GetBrands()
        {
            var bransEntity = _brandRepository.List();
            return _mapper.Map<IEnumerable<BrandDto>>(bransEntity);
        }
    }
}
