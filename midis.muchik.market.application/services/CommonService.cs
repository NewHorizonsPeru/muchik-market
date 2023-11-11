using AutoMapper;
using midis.muchik.market.application.dto;
using midis.muchik.market.application.dto.common;
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

        #region Customers
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
        public GenericResponse<CustomerDto> UpdateCustomer(string customerId, AddCustomerDto addCustomerDto)
        {
            var customerExists = _customerRepository.GetById(customerId);
            if (customerExists == null) { throw new MuchikException("El cliente ingresado no se encuentra registrado."); }

            _mapper.Map(addCustomerDto, customerExists);
            var successSave = _customerRepository.Save();

            if (!successSave) { throw new MuchikException("Ocurrió un error registrando el cliente, intenta nuevamente."); }

            return new GenericResponse<CustomerDto>(_mapper.Map<CustomerDto>(customerExists));

        }
        public GenericResponse<CustomerDto> RemoveCustomer(string customerId)
        {
            var customerExists = _customerRepository.GetById(customerId);
            if (customerExists == null) { throw new MuchikException("El cliente ingresado no se encuentra registrado."); }

            customerExists.IsActive = false;

            var successSave = _customerRepository.Save();
            if (!successSave) { throw new MuchikException("Ocurrió un error eliminando el cliente, intenta nuevamente."); }

            return new GenericResponse<CustomerDto>(_mapper.Map<CustomerDto>(customerExists));
        }
        public GenericResponse<CustomerDto> GetCustomerById(string customerId)
        {
            var customerExists = _customerRepository.GetById(customerId);
            if (customerExists == null) { throw new MuchikException("El cliente ingresado no se encuentra registrada."); }

            return new GenericResponse<CustomerDto>(_mapper.Map<CustomerDto>(customerExists));
        }
        public GenericResponse<IEnumerable<CustomerDto>> GetCustomers()
        {
            var customersEntity = _customerRepository.List(w => w.IsActive);
            return new GenericResponse<IEnumerable<CustomerDto>>(_mapper.Map<IEnumerable<CustomerDto>>(customersEntity));
        }
        #endregion

        #region Brands
        public GenericResponse<BrandDto> AddBrand(AddBrandDto addBrandDto)
        {
            var brandExists = _brandRepository.List(w => w.Name.Equals(addBrandDto.Name)).FirstOrDefault();
            if (brandExists != null) { throw new MuchikException("La marca ingresada ya se encuentra registrada."); }

            var brandEntity = _mapper.Map<Brand>(addBrandDto);
            _brandRepository.Add(brandEntity);
            var successSave = _brandRepository.Save(); 
            
            if (!successSave) { throw new MuchikException("Ocurrió un error registrando la marca, intenta nuevamente."); }

            return new GenericResponse<BrandDto>(_mapper.Map<BrandDto>(brandEntity));

        }
        public GenericResponse<BrandDto> UpdateBrand(string brandId, AddBrandDto addBrandDto)
        {
            var brandExists = _brandRepository.GetById(brandId);
            if (brandExists == null) { throw new MuchikException("La marca ingresada no se encuentra registrada."); }

            _mapper.Map(addBrandDto, brandExists);
            var successSave = _brandRepository.Save();

            if (!successSave) { throw new MuchikException("Ocurrió un error registrando la marca, intenta nuevamente."); }

            return new GenericResponse<BrandDto>(_mapper.Map<BrandDto>(brandExists));

        }
        public GenericResponse<BrandDto> RemoveBrand(string brandId)
        {
            var brandExists = _brandRepository.GetById(brandId);
            if (brandExists == null) { throw new MuchikException("La marca ingresada no se encuentra registrada."); }

            brandExists.IsActive = false;

            var successSave = _brandRepository.Save();
            if (!successSave) { throw new MuchikException("Ocurrió un error eliminando la marca, intenta nuevamente."); }

            return new GenericResponse<BrandDto>(_mapper.Map<BrandDto>(brandExists));
        }
        public GenericResponse<BrandDto> GetBrandById(string brandId)
        {
            var brandExists = _brandRepository.GetById(brandId);
            if (brandExists == null) { throw new MuchikException("La marca ingresada no se encuentra registrada."); }

            return new GenericResponse<BrandDto>(_mapper.Map<BrandDto>(brandExists));
        }
        public GenericResponse<IEnumerable<BrandDto>> GetBrands()
        {
            var brandsEntity = _brandRepository.List(w => w.IsActive);
            return new GenericResponse<IEnumerable<BrandDto>>(_mapper.Map<IEnumerable<BrandDto>>(brandsEntity));
        }
        #endregion

        #region Categories
        public GenericResponse<CategoryDto> AddCategory(AddCategoryDto addCategoryDto)
        {
            var categoryExists = _categoryRepository.List(w => w.Name.Equals(addCategoryDto.Name)).FirstOrDefault();
            if (categoryExists != null) { throw new MuchikException("La categoría ingresada ya se encuentra registrada."); }

            var categoryEntity = _mapper.Map<Category>(addCategoryDto);
            _categoryRepository.Add(categoryEntity);
            var successSave = _categoryRepository.Save();

            if (!successSave) { throw new MuchikException("Ocurrió un error registrando la categoría, intenta nuevamente."); }

            return new GenericResponse<CategoryDto>(_mapper.Map<CategoryDto>(categoryEntity));
        }
        public GenericResponse<CategoryDto> UpdateCategory(string categoryId, AddCategoryDto addCategoryDto)
        {
            var categoryExists = _categoryRepository.GetById(categoryId);
            if (categoryExists == null) { throw new MuchikException("La categoría ingresada no se encuentra registrada."); }

            _mapper.Map(addCategoryDto, categoryExists);
            var successSave = _categoryRepository.Save();

            if (!successSave) { throw new MuchikException("Ocurrió un error registrando la categoría, intenta nuevamente."); }

            return new GenericResponse<CategoryDto>(_mapper.Map<CategoryDto>(categoryExists));
        }
        public GenericResponse<CategoryDto> RemoveCategory(string categoryId)
        {
            var categoryExists = _categoryRepository.GetById(categoryId);
            if (categoryExists == null) { throw new MuchikException("La categoría ingresada no se encuentra registrada."); }

            categoryExists.IsActive = false;

            var successSave = _categoryRepository.Save();
            if (!successSave) { throw new MuchikException("Ocurrió un error eliminando la categoría, intenta nuevamente."); }

            return new GenericResponse<CategoryDto>(_mapper.Map<CategoryDto>(categoryExists));
        }
        public GenericResponse<CategoryDto> GetCategoryById(string categoryId)
        {
            var categoryExists = _categoryRepository.GetById(categoryId);
            if (categoryExists == null) { throw new MuchikException("La categoría ingresada no se encuentra registrada."); }

            return new GenericResponse<CategoryDto>(_mapper.Map<CategoryDto>(categoryExists));
        }
        public GenericResponse<IEnumerable<CategoryDto>> GetCategories()
        {
            var categoriesEntity = _categoryRepository.List();
            return new GenericResponse<IEnumerable<CategoryDto>>(_mapper.Map<IEnumerable<CategoryDto>>(categoriesEntity));
        }
        #endregion

        #region Products
        public GenericResponse<ProductDto> AddProduct(AddProductDto addProductDto)
        {
            var productExists = _productRepository.List(w => w.Name.Equals(addProductDto.Name)).FirstOrDefault();
            if (productExists != null) { throw new MuchikException("El producto ingresado ya se encuentra registrado."); }

            var productEntity = _mapper.Map<Product>(addProductDto);
            _productRepository.Add(productEntity);
            var successSave = _productRepository.Save();

            if (!successSave) { throw new MuchikException("Ocurrió un error registrando el producto, intenta nuevamente."); }

            return new GenericResponse<ProductDto>(_mapper.Map<ProductDto>(productEntity));
        }
        public GenericResponse<ProductDto> UpdateProduct(string productId, AddProductDto addProductDto)
        {
            var productExists = _productRepository.GetById(productId);
            if (productExists == null) { throw new MuchikException("El producto ingresado no se encuentra registrado."); }

            _mapper.Map(addProductDto, productExists);
            var successSave = _productRepository.Save();

            if (!successSave) { throw new MuchikException("Ocurrió un error actualizando el producto, intenta nuevamente."); }

            return new GenericResponse<ProductDto>(_mapper.Map<ProductDto>(productExists));
        }
        public GenericResponse<ProductDto> RemoveProduct(string productId)
        {
            var productExists = _productRepository.GetById(productId);
            if (productExists == null) { throw new MuchikException("El producto ingresado no se encuentra registrado."); }

            productExists.IsActive = false;

            var successSave = _productRepository.Save();
            if (!successSave) { throw new MuchikException("Ocurrió un error eliminando el producto, intenta nuevamente."); }

            return new GenericResponse<ProductDto>(_mapper.Map<ProductDto>(productExists));
        }
        public GenericResponse<ProductDto> GetProductById(string productId)
        {
            var productExists = _productRepository.GetById(productId);
            if (productExists == null) { throw new MuchikException("El producto ingresado no se encuentra registrado."); }

            return new GenericResponse<ProductDto>(_mapper.Map<ProductDto>(productExists));
        }
        public GenericResponse<IEnumerable<ProductDto>> GetProducts()
        {
            var productsEntity = _productRepository.List();
            return new GenericResponse<IEnumerable<ProductDto>>(_mapper.Map<IEnumerable<ProductDto>>(productsEntity));
        }
        #endregion
    }
}
