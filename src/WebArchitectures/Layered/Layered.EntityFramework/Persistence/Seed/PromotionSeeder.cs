using Layered.Domain.Entities;
using Layered.Domain.Enums;

namespace Layered.EntityFramework.Persistence.Seed;

public class PromotionSeeder
{
    public static List<Promotion> GetPromotions()
    {
        return new List<Promotion>()
        {
            new Promotion()
            {
                Name = "Two sodas at one price",
                PromoBaskets = new List<PromoBasket>()
                {
                    new PromoBasket()
                    {
                        PromotionType = PromotionType.PromotionAmount,
                        Items = new List<Item>
                        {
                            new Item()
                            {
                                Id = Guid.Parse("36dc193f-d101-43d5-8449-28c268a115e0"),
                                Barcode = "ABC-abc-1229"
                            }
                        }
                    },
                    new PromoBasket()
                    {
                        PromotionType = PromotionType.PromotionAmount,
                        Items = new List<Item>
                        {
                            new Item()
                            {
                                Id = Guid.Parse("36dc193f-d101-43d5-8449-28c268a115e1"),
                                Barcode = "ABC-abc-1230"
                            }
                        }
                    }
                }
            }
        };
    }
}

