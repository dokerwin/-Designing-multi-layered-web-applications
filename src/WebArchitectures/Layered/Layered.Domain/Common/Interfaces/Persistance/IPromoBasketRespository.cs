using Layered.Domain.Entities;
using Layered.Domain.ValueObjects;

namespace Layered.Common.Interfaces.Persistance;
public interface IPromoBasketRepository : IRepository<PromoBasket>
{
    Task<IEnumerable<PromoBasket>> FindMatchedBaskets(RawBasket rawBaskets);
}
