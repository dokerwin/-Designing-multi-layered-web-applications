using Onion.Domain.Model.Enums;

namespace Onion.Core.Entities;

public class BasketInfo
{
    public PromotionType PromotionType { get; set; }
    public decimal PromoValue { get; set; }
}
