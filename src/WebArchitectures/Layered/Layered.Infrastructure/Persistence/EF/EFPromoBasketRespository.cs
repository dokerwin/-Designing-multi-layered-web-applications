using Layered.Common.Interfaces.Persistance;
using Layered.Domain.Entities;
using Layered.Domain.ValueObjects;
using Layered.EntityFramework.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Layered.Infrastructure.Persistence.EF;

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
