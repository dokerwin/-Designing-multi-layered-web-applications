using Layered.Domain.Entities.Base;
using Layered.Domain.Enums;

namespace Layered.Domain.Entities;

public class PromoBasket : EntityBase<Guid>
{
    public List<Item> Items { get; set; }
    public decimal PromotionValue { get; set; }
    public PromotionType PromotionType { get; set; }
   
}
