using Layered.EntityFramework.Persistence;

namespace Layered.EntityFramework.Persistence.Seed;
public class PromotionServiceDbInitializer
{
    public static void Initialize(PromotionServiceContext _dbContext)
    {
        if (_dbContext.Database.CanConnect())
        {
            if (!_dbContext.Promotions.Any())
            {
                _dbContext.Promotions.AddRange(PromotionSeeder.GetPromotions());
                _dbContext.SaveChanges();
            }
        }
    }
}
