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
        }
    }
}
