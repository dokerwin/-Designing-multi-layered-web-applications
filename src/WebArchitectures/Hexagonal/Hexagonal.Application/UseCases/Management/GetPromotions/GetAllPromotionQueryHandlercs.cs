using AutoMapper;
using Hexagonal.Domain.Services.Services.Interfaces;
using Hexagonal.Shared.Application.DTOs;
using MediatR;

namespace Hexagonal.Application.UseCases.Management;

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
