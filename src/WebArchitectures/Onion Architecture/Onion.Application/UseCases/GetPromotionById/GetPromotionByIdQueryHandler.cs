﻿using Onion.Application.DTOs;
using MediatR;
using AutoMapper;
using Onion.Domain.Services.Services.Interfaces;

namespace Onion.Application.UseCases.GetPromotionById;

public class GetPromotionByIdQueryHandler : IRequestHandler<GetPromotionsByIdQuery, PromotionDto>
{
    private readonly IPromoService _promoService;
    private readonly IMapper _mapper;

    public GetPromotionByIdQueryHandler(IPromoService promoService, IMapper mapper)
    {
        _promoService = promoService;
        _mapper = mapper;
    }


    public async Task<PromotionDto> Handle(GetPromotionsByIdQuery request, CancellationToken cancellationToken)
    {
        var allPromotions = await _promoService.GetPromotionById(request.Id);
        var allPromotionDtos = _mapper.Map<PromotionDto>(allPromotions);
        return allPromotionDtos;
    }
}
