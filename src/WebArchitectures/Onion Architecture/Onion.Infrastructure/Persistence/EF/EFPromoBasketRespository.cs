using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Onion.Domain.Model.Entities;
using Onion.Domain.Model.ValueObjects;
using Onion.Domain.Services.Persistance.Interfaces;
using Onion.EntityFramework.Persistence;

namespace Onion.Infrastructure.Persistence.EF;

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
