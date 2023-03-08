using AutoMapper;
using Layered.Application.DTOs;
using Layered.Domain.Services.Interfaces;
using Layered.Domain.ValueObjects;
using MediatR;

namespace Layered.Application.UseCases.CalculatePromotionsForBasket;

public class CalculatePromotionForBasketCommandHandler : IRequestHandler<CalculatePromotionForBasketCommand, CalculatedBasketDto>
{
    private readonly IPromoCalculator _promoCalculator;
    private readonly IMapper _mapper;

    public CalculatePromotionForBasketCommandHandler(IPromoCalculator promoCalculator, IMapper mapper)
    {
        _promoCalculator = promoCalculator;
        _mapper = mapper;
    }
    public async Task<CalculatedBasketDto> Handle(CalculatePromotionForBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = _mapper.Map<RawBasket>(request.Basket);
        var result = await _promoCalculator.CalculatePromotion(basket);
        return _mapper.Map<CalculatedBasketDto>(result);
    }
}
