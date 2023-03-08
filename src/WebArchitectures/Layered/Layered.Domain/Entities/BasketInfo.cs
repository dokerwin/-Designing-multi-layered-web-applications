using Layered.Domain.Enums;

namespace Layered.Domain.Entities;

public class BasketInfo
{
    public PromotionType PromotionType { get; set; }
    public decimal PromoValue { get; set; }
}
