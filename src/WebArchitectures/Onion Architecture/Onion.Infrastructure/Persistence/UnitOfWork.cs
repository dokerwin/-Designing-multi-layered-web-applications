using Microsoft.Extensions.Logging;
using Onion.Domain.Services.Persistance.Interfaces;
using Onion.EntityFramework.Persistence;

namespace Onion.PromotionService.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    // Instance of context for accessing the database
    private readonly PromotionServiceContext _context;

    // Instance of logger for logging purposes
    private readonly ILogger<UnitOfWork> _logger;

    // Repository for handling promotions data
    public IPromotionRepository Promotions { get; set; }

    // Repository for handling promotions basket data
    public IPromoBasketRepository PromoBaskets { get;  set; }

    // Constructor that initializes the context, logger, and promotion repository
    public UnitOfWork(PromotionServiceContext context,
        ILogger<UnitOfWork> loggerFactory,
        IPromotionRepository promotions,
        IPromoBasketRepository promoBasketRepository)
    {
        // Store the context instance
        _context = context;

        // Store the logger instance
        _logger = loggerFactory;

        // Store the promotion repository instance
        Promotions = promotions;

        // Store the promotion basket repository instance
        PromoBaskets = promoBasketRepository;
    }

    // Method for saving changes to the database asynchronously
    public async Task CompleteAsync() => await _context.SaveChangesAsync();

    // Method for disposing the context instance
    public void Dispose() => _context.Dispose();
}