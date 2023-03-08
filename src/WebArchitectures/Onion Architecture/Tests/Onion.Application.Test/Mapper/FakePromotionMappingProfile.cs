using AutoMapper;
using Onion.Application.DTOs;
using Onion.Domain.Model.Entities;

namespace Layered.Application.UnitTest.Mapper;
public class FakePromotionMappingProfile : Profile
{
    public FakePromotionMappingProfile()
    {
        CreateMap<Promotion, PromotionDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartOn))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndOn))
            .ReverseMap();
    }
}