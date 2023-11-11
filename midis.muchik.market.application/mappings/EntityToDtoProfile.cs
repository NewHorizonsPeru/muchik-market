using AutoMapper;
using midis.muchik.market.application.dto;
using midis.muchik.market.domain.entities;

namespace midis.muchik.market.application.mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile() 
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<User, UserDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<Order, OrderDto>();
        }
    }
}
