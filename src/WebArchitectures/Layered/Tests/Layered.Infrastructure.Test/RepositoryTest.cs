using Layered.Common.Interfaces.Persistance;
using Layered.Domain.Entities;
using Layered.EntityFramework.Persistence;
using Layered.Infrastructure.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Layered.Infrastructure.Test;
public class EFPromotionRepositoryTests
{
    private DbContextOptionsBuilder _options;
    private PromotionServiceContext _context;
    private EFPromotionRepository _repository;

    public EFPromotionRepositoryTests()
    {
        _options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(
                    Guid.NewGuid().ToString() // Use GUID so every test will use a different db
        );

        _context = new PromotionServiceContext(_options.Options);
        _repository = new EFPromotionRepository(_context);

       
    }

    [Fact]
    public async Task FindByName_ShouldReturnPromotion_WhenPromotionExists()
    {
        var name = "test";
        _context.Promotions.Add(new Promotion()
        {
            Name = name
        }) ;

        await _context.SaveChangesAsync();

        var sut = new EFPromotionRepository(_context);

        // Act
        Promotion result = await sut.FindByName(name);

        // Assert
        Assert.NotNull(result);
    }


    [Fact]
    public async Task GetPromotions_ShouldReturnPromotionList_WhenPromotionsExists()
    {
        _context.Promotions.AddRange(GetPromotions());

        await _context.SaveChangesAsync();

        var sut = new EFPromotionRepository(_context);

        // Act
        List<Promotion> result = (List<Promotion>)await sut.All();

        // Assert
        Assert.NotNull(result);
    }


    [Fact]
    public async Task GetById_ShouldReturnPromotion_WhenPromotionExists()
    {
        // Arrange
        var promotion = new Promotion { Id = Guid.NewGuid(), Name = "Test Promotion" };
        await _repository.Add(promotion);

        // Act
        var result = await _repository.GetById(promotion.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(promotion.Id, result.Id);
        Assert.Equal(promotion.Name, result.Name);
    }

    [Fact]
    public async Task GetById_ShouldReturnNull_WhenPromotionDoesNotExist()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();

        // Act
        var result = await _repository.GetById(nonExistentId);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Add_ShouldAddPromotionToDatabase()
    {
        // Arrange
        var promotion = new Promotion { Id = Guid.NewGuid(), Name = "Test Promotion" };

        // Act
        await _repository.Add(promotion);
        var result = await _repository.GetById(promotion.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(promotion.Id, result.Id);
        Assert.Equal(promotion.Name, result.Name);
    }

    [Fact]
    public async Task Delete_ShouldDeletePromotionFromDatabase_WhenPromotionExists()
    {
        // Arrange
        var promotion = new Promotion { Id = Guid.NewGuid(), Name = "Test Promotion" };
        await _repository.Add(promotion);

        // Act
        var result = await _repository.Delete(promotion.Id);

        // Assert
        Assert.True(result);

        var deletedPromotion = await _repository.GetById(promotion.Id);
        Assert.Null(deletedPromotion);
    }

    [Fact]
    public async Task Delete_ShouldReturnFalse_WhenPromotionDoesNotExist()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();

        // Act
        var result = await _repository.Delete(nonExistentId);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task All_ShouldReturnAllPromotionsFromDatabase()
    {
        // Arrange
        var promotion1 = new Promotion { Id = Guid.NewGuid(), Name = "Test Promotion 1" };
        var promotion2 = new Promotion { Id = Guid.NewGuid(), Name = "Test Promotion 2" };
        await _repository.Add(promotion1);
        await _repository.Add(promotion2);

        await _context.SaveChangesAsync();
        // Act
        var result = await _repository.All();

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Contains(promotion1, result);
        Assert.Contains(promotion2, result);
    }

    // Create a method that returns a list of promotions
    private static List<Promotion> GetPromotions()
    {
        return new List<Promotion>
    {
        new Promotion { Id = Guid.NewGuid(), Name = "Promo 1" },
        new Promotion { Id = Guid.NewGuid(), Name = "Promo 2" },
        new Promotion { Id = Guid.NewGuid(), Name = "Promo 3" }
    };
    }

}
