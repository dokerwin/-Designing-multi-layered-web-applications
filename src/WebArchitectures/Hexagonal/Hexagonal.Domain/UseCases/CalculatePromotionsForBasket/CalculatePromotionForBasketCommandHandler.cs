using AutoMapper;
using MediatR;
using Hexagonal.Domain.Model.ValueObjects;
using Hexagonal.Domain.Services.Services.Interfaces;

namespace Hexagonal.Application.UseCases.CalculatePromotionsForBasket;

public class CalculatePromotionForBasketCommandHandler : IRequestHandler<CalculatePromotionForBasketCommand, CalculatedBasket>
{
    private readonly IPromoCalculator _promoCalculator;
    private readonly IMapper _mapper;

    public CalculatePromotionForBasketCommandHandler(IPromoCalculator promoCalculator, IMapper mapper)
    {
        _promoCalculator = promoCalculator;
        _mapper = mapper;
    }
    public async Task<CalculatedBasket> Handle(CalculatePromotionForBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = _mapper.Map<RawBasket>(request.Basket);
        return await _promoCalculator.CalculatePromotion(basket);
    }
}
