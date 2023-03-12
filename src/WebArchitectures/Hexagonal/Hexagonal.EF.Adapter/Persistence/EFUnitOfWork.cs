using Hexagonal.Domain.Services.Persistance.Interfaces;
using Hexagonal.Domain.Services.Services.Interfaces;
using Hexagonal.Hexagonal.EF.Adapter.Persistence;

namespace Hexagonal.PromotionService.Infrastructure.Persistence;

public class EFUnitOfWork : IUnitOfWork, IDisposable
{
    // Instance of context for accessing the database
    private readonly PromotionServiceContext _context;

    // Instance of logger for logging purposes
    private readonly ILogger<EFUnitOfWork> _logger;

    // Repository for handling promotions data
    public IPromotionRepository Promotions { get; set; }

    // Repository for handling promotions basket data
    public IPromoBasketRepository PromoBaskets { get;  set; }

    // Constructor that initializes the context, logger, and promotion repository
    public EFUnitOfWork(PromotionServiceContext context,
        ILogger<EFUnitOfWork> logger,
        IPromotionRepository promotions,
        IPromoBasketRepository promoBasketRepository)
    {
        // Store the context instance
        _context = context;

        // Store the logger instance
        _logger = logger;

        // Store the promotion repository instance
        Promotions = promotions;

        // Store the promotion basket repository instance
        PromoBaskets = promoBasketRepository;
    }

    // Method for saving changes to the database asynchronously
    public async Task<bool> CompleteAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return false;
        }
    }

    // Method for disposing the context instance
    public void Dispose() => _context.Dispose();
}