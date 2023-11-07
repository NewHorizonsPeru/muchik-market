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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public CommonService(
            IMapper mapper, 
            IBrandRepository brandRepository, 
            ICategoryRepository categoryRepository, 
            IProductRepository productRepository
            )
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public IEnumerable<BrandDto> GetBrands()
        {
            var brandsEntity = _brandRepository.List();
            return _mapper.Map<IEnumerable<BrandDto>>(brandsEntity);
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            var categoriesEntity = _categoryRepository.List();
            return _mapper.Map<IEnumerable<CategoryDto>>(categoriesEntity);
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            var productsEntity = _productRepository.List();
            return _mapper.Map<IEnumerable<ProductDto>>(productsEntity);
        }
    }
}
