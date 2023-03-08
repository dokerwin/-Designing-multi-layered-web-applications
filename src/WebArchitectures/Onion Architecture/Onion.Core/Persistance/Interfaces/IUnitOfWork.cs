namespace Onion.Domain.Services.Persistance.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IPromotionRepository Promotions { get; }
    IPromoBasketRepository PromoBaskets { get; }
    Task CompleteAsync();
}

