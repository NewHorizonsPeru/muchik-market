using AutoMapper;
using midis.muchik.market.application.dto;
using midis.muchik.market.application.interfaces;
using midis.muchik.market.crosscutting.exceptions;
using midis.muchik.market.crosscutting.models;
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
        private readonly ICustomerRepository _customerRepository;

        public CommonService(
            IMapper mapper, 
            IBrandRepository brandRepository, 
            ICategoryRepository categoryRepository, 
            IProductRepository productRepository,
            ICustomerRepository customerRepository
            )
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        public GenericResponse<CustomerDto> AddCustomer(CustomerDto customerDto)
        {
            var customerExists = _customerRepository.Find(w => w.DocumentNumber.Equals(customerDto.DocumentNumber)).FirstOrDefault();
            if (customerExists != null) { throw new MuchikException("El número de documento ya se encuentra registrado."); }
            var customerEntity = _mapper.Map<Customer>(customerDto);
            _customerRepository.Add(customerEntity);
            
            var successSave = _customerRepository.Save();
            
            if (!successSave)
            {
                throw new MuchikException("Ocurrió un error registrando al cliente, intente en unos minutos.");
            }

            return new GenericResponse<CustomerDto>(_mapper.Map<CustomerDto>(customerEntity));
        }

        public GenericResponse<IEnumerable<BrandDto>> GetBrands()
        {
            var brandsEntity = _brandRepository.List();
            return new GenericResponse<IEnumerable<BrandDto>>(_mapper.Map<IEnumerable<BrandDto>>(brandsEntity));
        }

        public GenericResponse<IEnumerable<CategoryDto>> GetCategories()
        {
            var categoriesEntity = _categoryRepository.List();
            return new GenericResponse<IEnumerable<CategoryDto>>(_mapper.Map<IEnumerable<CategoryDto>>(categoriesEntity));
        }

        public GenericResponse<IEnumerable<ProductDto>> GetProducts()
        {
            var productsEntity = _productRepository.List();
            return new GenericResponse<IEnumerable<ProductDto>>(_mapper.Map<IEnumerable<ProductDto>>(productsEntity));
        }
    }
}
