using Hexagonal.Domain.Services.Persistance.Interfaces;
using Hexagonal.EF.Adapter.Persistence;
using Hexagonal.PromotionService.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Hexagonal.Infrastructure;
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
        services.AddScoped<IUnitOfWork, EFUnitOfWork>();
        services.AddScoped<IPromotionRepository, EFPromotionRepository>();
        services.AddScoped<IPromoBasketRepository, EFPromoBasketRepository>();
        return services;
    }
}