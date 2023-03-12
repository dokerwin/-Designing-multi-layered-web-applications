using Hexagonal.Hexagonal.EF.Adapter.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hexagonal.EF.Adapter;

public static class DependencyInjection
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<PromotionServiceContext>(
        optionsAction => optionsAction.UseSqlite(Configuration.GetConnectionString("Onion_ConnectionString"),
        x => x.MigrationsAssembly("Onion.EntityFramework.DbMigrations")));
        return services;
    }
}
