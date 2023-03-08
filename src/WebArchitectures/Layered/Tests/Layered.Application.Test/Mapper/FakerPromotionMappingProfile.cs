using AutoMapper;
using Layered.Application.DTOs;
using Layered.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered.Application.UnitTest.Mapper;
public class FakerPromotionMappingProfile : Profile
{
    public FakerPromotionMappingProfile()
    {
        CreateMap<Promotion, PromotionDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartOn))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndOn))
            .ReverseMap();
    }
}