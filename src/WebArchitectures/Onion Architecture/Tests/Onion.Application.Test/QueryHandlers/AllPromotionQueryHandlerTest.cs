using AutoMapper;
using Layered.Application.UnitTest.Mapper;
using Moq;
using Onion.Application.DTOs;
using Onion.Application.UseCases.GetPromotions;
using Onion.Domain.Model.Entities;
using Onion.Domain.Services.Services.Interfaces;

namespace Layered.Application.UnitTest.QueryHandlers;

public class GetAllPromotionQueryHandlerTests
{
    private readonly Mock<IPromoService> _promoServiceMock;
    private readonly IMapper _mapper;

    public GetAllPromotionQueryHandlerTests()
    {
        _promoServiceMock = new Mock<IPromoService>();
        var mapperConfiguration = new MapperConfiguration(config =>
        {
            config.AddProfile<FakePromotionMappingProfile>(); // Replace MappingProfile with your AutoMapper profile
        });
        _mapper = mapperConfiguration.CreateMapper();
    }

    [Fact]
    public async Task Handle_ShouldReturnAllPromotions()
    {
        // Arrange
        var expectedPromotions = new List<Promotion>
        {
            new Promotion { Id = Guid.NewGuid(), Name = "Promotion 1" },
            new Promotion { Id = Guid.NewGuid(), Name = "Promotion 2" }
        };
        _promoServiceMock.Setup(x => x.GetAllPromotions()).ReturnsAsync(expectedPromotions);

        var handler = new GetAllPromotionQueryHandler(_promoServiceMock.Object, _mapper);
        var query = new GetAllPromotionsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.IsType<List<PromotionDto>>(result);
        Assert.Equal(expectedPromotions.Count, result.Count());
        Assert.Equal(expectedPromotions[0].Name, result.ElementAt(0).Name);
        Assert.Equal(expectedPromotions[1].Name, result.ElementAt(1).Name);
    }
}
