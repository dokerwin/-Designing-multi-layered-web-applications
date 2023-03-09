using AutoMapper;
using MediatR;
using Hexagonal.Application.DTOs;
using Hexagonal.Domain.Services.Services.Interfaces;

namespace Onion.Application.UseCases.GetPromotions;

public class GetAllPromotionQueryHandler : IRequestHandler<GetAllPromotionsQuery, IEnumerable<PromotionDto>>
{
    private readonly IPromoService _promoService;
    private readonly IMapper _mapper;

    public GetAllPromotionQueryHandler(IPromoService promoService, IMapper mapper)
    {
        _promoService = promoService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PromotionDto>> Handle(GetAllPromotionsQuery request, CancellationToken cancellationToken)
    {
        var allPromotions = await _promoService.GetAllPromotions();
        var allPromotionDtos = _mapper.Map<IEnumerable<PromotionDto>>(allPromotions);
        return allPromotionDtos;
    }
}
