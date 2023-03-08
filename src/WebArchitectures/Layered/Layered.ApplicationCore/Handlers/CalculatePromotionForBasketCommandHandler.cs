using Layered.Domain.Services.Interfaces;
using Layered.Domain.ValueObjects;
using MediatR;

namespace Layered.Application.Handlers;

public class CalculatePromotionForBasketCommandHandler : IRequestHandler<CalculatePromotionForBasketCommand, CalculatedBasket>
{
    private readonly IPromoCalculator _promoCalculator;

    public CalculatePromotionForBasketCommandHandler(IPromoCalculator promoCalculator)
    {
        _promoCalculator = promoCalculator;
    }
    public async Task<CalculatedBasket> Handle(CalculatePromotionForBasketCommand request, CancellationToken cancellationToken)
    {
        return await _promoCalculator.CalculatePromotion(request.Basket);
    }
}
