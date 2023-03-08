using Layered.EntityFramework.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Layered.PromotionService.EntityFramework;

public static class DependencyInjection
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<PromotionServiceContext>(
        optionsAction => optionsAction.UseSqlite(Configuration.GetConnectionString("SCO_PromotionService_ConnectionString"),
        x => x.MigrationsAssembly("Layered.EntityFramework.DbMigrations")));
        return services;
    }
}
