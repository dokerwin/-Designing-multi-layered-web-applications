using Hexagonal.Domain.Model.Entities;
using Hexagonal.Domain.Model.ValueObjects;
using Hexagonal.Domain.Services.Persistance.Interfaces;
using Hexagonal.Hexagonal.EF.Adapter.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hexagonal.EF.Adapter.Persistence;

public class EFPromoBasketRepository : EFRepository<PromoBasket>, IPromoBasketRepository
{
    public EFPromoBasketRepository(PromotionServiceContext context,
        ILogger<EFPromoBasketRepository> logger) : base(context, logger)
    {
    }

    public async Task<IEnumerable<PromoBasket>> FindMatchedBaskets(RawBasket rawBasket)
    {
        var matchedPromoBaskets = new List<PromoBasket>();

        var _promoBaskets = await _dbSet.ToListAsync();

        var result = new List<PromoBasket>();

        foreach (var rawItem in rawBasket.Items)
        {
            foreach (var promoBasket in _promoBaskets)
            {
                if (promoBasket.Items.Any(item => item.Id == rawItem.Id))
                {
                    result.Add(promoBasket);
                }
            }
        }

        return result;
    }
}
