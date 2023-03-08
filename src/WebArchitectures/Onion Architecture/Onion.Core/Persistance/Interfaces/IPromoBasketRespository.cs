using Onion.Domain.Model.Entities;
using Onion.Domain.Model.ValueObjects;

namespace Onion.Domain.Services.Persistance.Interfaces;
public interface IPromoBasketRepository : IRepository<PromoBasket>
{
    Task<IEnumerable<PromoBasket>> FindMatchedBaskets(RawBasket rawBaskets);
}
