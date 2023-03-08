
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Onion.Domain.Model.Entities;
using Onion.Domain.Services.Persistance.Interfaces;
using Onion.EntityFramework.Persistence;

namespace Onion.Infrastructure.Persistence.EF;

public class EFPromotionRepository : EFRepository<Promotion>, IPromotionRepository
{
    public EFPromotionRepository(PromotionServiceContext context,
        ILogger<EFPromotionRepository> logger = null) : base(context, logger)
    {
    }


    public async Task<Promotion> FindByName(string name)
    {
        try
        {
            var promo = await _dbSet.Where(x => x.Name == name).FirstOrDefaultAsync();
            if (promo is not null)
                return promo;

            return new Promotion();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} FindByEmailAsync function error", typeof(EFPromotionRepository));
            return new Promotion();
        }
    }
}

