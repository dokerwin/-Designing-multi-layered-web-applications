using Hexagonal.Domain.Model.Entities.Base;
using Hexagonal.Domain.Model.Enums;

namespace Hexagonal.Domain.Model.Entities;

public class PromoBasket : EntityBase<Guid>
{
    public List<Item> Items { get; set; }
    public decimal PromotionValue { get; set; }
    public PromotionType PromotionType { get; set; }

}
