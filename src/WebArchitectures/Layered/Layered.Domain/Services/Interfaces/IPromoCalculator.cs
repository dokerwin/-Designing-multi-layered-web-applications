using Layered.Domain.ValueObjects;

namespace Layered.Domain.Services.Interfaces;

public interface IPromoCalculator
{
    Task<CalculatedBasket> CalculatePromotion(RawBasket rawBasket);
    decimal GetPromoValueAmount(decimal unitPrice, decimal quantitity, decimal promotionValue);
    decimal GetPromoValuePercent(decimal unitPrice, decimal promotionValue);
}
