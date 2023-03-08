using Microsoft.Extensions.DependencyInjection;
using Onion.Domain.Services.Persistance.Interfaces;
using Onion.Infrastructure.Persistence.EF;
using Onion.PromotionService.Infrastructure.Persistence;

namespace Onion.Infrastructure;
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