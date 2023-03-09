using Hexagonal.Domain.Model.ValueObjects;

namespace Hexagonal.Domain.Services.Services.Interfaces;

public interface IPromoCalculator
{
    Task<CalculatedBasket> CalculatePromotion(RawBasket rawBasket);
    decimal GetPromoValueAmount(decimal unitPrice, decimal quantitity, decimal promotionValue);
    decimal GetPromoValuePercent(decimal unitPrice, decimal promotionValue);
}
