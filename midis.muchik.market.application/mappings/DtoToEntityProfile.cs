using AutoMapper;
using midis.muchik.market.application.dto;
using midis.muchik.market.application.dto.common;
using midis.muchik.market.application.dto.omnichannel;
using midis.muchik.market.application.dto.security;
using midis.muchik.market.domain.entities;

namespace midis.muchik.market.application.mappings
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile() 
        {
            CreateMap<SignUpRequestDto, User>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<AddBrandDto, Brand>();
            CreateMap<AddCategoryDto, Category>();
            CreateMap<AddCustomerDto, Customer>();
            CreateMap<AddProductDto, Product>();
            CreateMap<OrderDetailDto, OrderDetail>();
            CreateMap<OrderDto, Order>();
            CreateMap<AddOrderDetailDto, OrderDetail>();
            CreateMap<AddOrderDto, Order>();

        }
    }
}
