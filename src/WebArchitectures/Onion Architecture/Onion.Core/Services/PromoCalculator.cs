using Onion.Domain.Model.Enums;
using Onion.Domain.Model.ValueObjects;
using Onion.Domain.Services.Persistance.Interfaces;
using Onion.Domain.Services.Services.Interfaces;

namespace Onion.Core.Services;

public class PromoCalculator : IPromoCalculator
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPromoCalculator _promoCalculator;

    public PromoCalculator(IUnitOfWork unitOfWork, IPromoCalculator promoCalculator)
    {
        _unitOfWork = unitOfWork;
        _promoCalculator = promoCalculator;
    }

    public  decimal GetPromoValueAmount(decimal unitPrice, decimal quantitity, decimal promotionValue)
    {
        return (unitPrice - promotionValue / quantitity);
    }

    public  decimal GetPromoValuePercent(decimal unitPrice, decimal promotionValue)
    {
        return (unitPrice - unitPrice / 100 * promotionValue);
    }

    public async Task<CalculatedBasket> CalculatePromotion(RawBasket rawBasket)
    {
        var calculatedBasket = new CalculatedBasket();
        var mathcedBasket = await _unitOfWork.PromoBaskets.FindMatchedBaskets(rawBasket);

        foreach (var rawItem in rawBasket.Items)
        {
            var promoBasket = mathcedBasket.FirstOrDefault(s => s.Items.Any(s => s.Id == rawItem.Id));
            if (promoBasket != null)
            {
                if (promoBasket.PromotionType == PromotionType.PromotionPercent)
                {
                    calculatedBasket.Items.Add(new CalculatedItem()
                    {
                        Id = rawItem.Id,
                        OldUnitPrice = rawItem.UnitPrice,
                        UnitPrice = _promoCalculator.GetPromoValuePercent(rawItem.UnitPrice, promoBasket.PromotionValue),
                        Quantitity = rawItem.Quantitity,
                        Promoted = false
                    });
                }
                else if (promoBasket.PromotionType == PromotionType.PromotionAmount)
                {
                    calculatedBasket.Items.Add(new CalculatedItem()
                    {
                        Id = rawItem.Id,
                        OldUnitPrice = rawItem.UnitPrice,
                        UnitPrice = _promoCalculator.GetPromoValueAmount(rawItem.UnitPrice, (decimal)rawItem.Quantitity, promoBasket.PromotionValue),
                        Quantitity = rawItem.Quantitity,
                        Promoted = false
                    });
                }
            }
            else
            {
                calculatedBasket.Items.Add(new CalculatedItem()
                {
                    Id = rawItem.Id,
                    OldUnitPrice = rawItem.UnitPrice,
                    UnitPrice = rawItem.UnitPrice,
                    Quantitity = rawItem.Quantitity,
                    Promoted = false
                });
            }
        }

        return calculatedBasket;
    }
}
