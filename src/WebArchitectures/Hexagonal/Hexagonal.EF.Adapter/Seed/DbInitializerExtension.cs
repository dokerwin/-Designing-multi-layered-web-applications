using Hexagonal.EF.Adapter.Seed;
using Hexagonal.Hexagonal.EF.Adapter.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Hexagonal.Hexagonal.EF.Adapter.Seed;

public static class DbInitializerExtension
{
    public static IApplicationBuilder UseItToSeedSqlServer(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<PromotionServiceContext>();
            PromotionServiceDbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {

        }

        return app;
    }
}
