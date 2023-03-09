using Hexagonal.Domain.Model.Entities;
using Hexagonal.Domain.Model.ValueObjects;

namespace Hexagonal.Domain.Services.Persistance.Interfaces;
public interface IPromoBasketRepository : IRepository<PromoBasket>
{
    Task<IEnumerable<PromoBasket>> FindMatchedBaskets(RawBasket rawBaskets);
}
