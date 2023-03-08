using Layered.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Layered.EntityFramework.Persistence;

public class PromotionServiceContext : DbContext
{
    private readonly IConfiguration _configuration;
    public PromotionServiceContext(DbContextOptions<PromotionServiceContext> dbContextOptions, IConfiguration configuration = null)
           : base()
    {
        _configuration = configuration;
    }


    public PromotionServiceContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<PromoBasket> PromoBaskets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PromotionServiceContext).Assembly);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlite(_configuration.GetConnectionString("SCO_PromotionService_ConnectionString"));
    }
}

