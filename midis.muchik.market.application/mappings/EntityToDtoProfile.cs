using AutoMapper;
using midis.muchik.market.application.dto;
using midis.muchik.market.domain.entities;

namespace midis.muchik.market.application.mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile() 
        {
            CreateMap<Brand, BrandDto>()
                .ForMember(d => d.BrandId, s => s.MapFrom(e => e.Id))
                .ForMember(d => d.BrandName, s => s.MapFrom(e => e.Name))
                .ForMember(d => d.BrandDescription, s => s.MapFrom(e => e.Description));

            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.CategoryId, s => s.MapFrom(e => e.Id))
                .ForMember(d => d.CategoryName, s => s.MapFrom(e => e.Name))
                .ForMember(d => d.CategoryDescription, s => s.MapFrom(e => e.Description));

            CreateMap<Product, ProductDto>()
                .ForMember(d => d.ProductId, s => s.MapFrom(e => e.Id))
                .ForMember(d => d.ProductName, s => s.MapFrom(e => e.Name))
                .ForMember(d => d.ProductDescription, s => s.MapFrom(e => e.Description))
                .ForMember(d => d.ProductSku, s => s.MapFrom(e => e.Sku))
                .ForMember(d => d.ProductScore, s => s.MapFrom(e => e.Score))
                .ForMember(d => d.ProductPrice, s => s.MapFrom(e => e.Price))
                .ForMember(d => d.ProductStock, s => s.MapFrom(e => e.Stock));

            CreateMap<Role, RoleDto>();

            CreateMap<User, UserDto>();

            CreateMap<Customer, CustomerDto>();
        }
    }
}
