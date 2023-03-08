using Layered.Common.Interfaces.Persistance;
using Layered.Infrastructure.Persistence.EF;
using Layered.PromotionService.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Layered.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddRepositorises();
        return services;
    }

    private static IServiceCollection AddRepositorises(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPromotionRepository, EFPromotionRepository>();
        services.AddScoped<IPromoBasketRepository, EFPromoBasketRepository>();
        return services;
    }
}