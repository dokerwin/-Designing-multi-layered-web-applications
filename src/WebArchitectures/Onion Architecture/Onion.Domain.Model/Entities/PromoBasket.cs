using Onion.Domain.Model.Entities.Base;
using Onion.Domain.Model.Enums;

namespace Onion.Domain.Model.Entities;

public class PromoBasket : EntityBase<Guid>
{
    public List<Item> Items { get; set; }
    public decimal PromotionValue { get; set; }
    public PromotionType PromotionType { get; set; }
   
}
