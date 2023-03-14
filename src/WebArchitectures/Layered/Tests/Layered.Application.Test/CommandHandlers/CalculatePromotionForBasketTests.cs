using AutoMapper;
using Layered.Application.DTOs;
using Layered.Application.UseCases.CalculatePromotionsForBasket;
using Layered.Domain.Services.Interfaces;
using Layered.Domain.ValueObjects;
using Moq;

namespace Layered.Application.Tests.CalculatePromotionsForBasket;

public class CalculatePromotionForBasketTests
{
    private readonly Mock<IPromoCalculator> _promoCalculatorMock;
    private readonly IMapper _mapper;

    public CalculatePromotionForBasketTests()
    {
        _promoCalculatorMock = new Mock<IPromoCalculator>();
        var mapperConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<RawBasket, RawBasketDto>().ReverseMap();
            config.CreateMap<CalculatedBasket, CalculatedBasketDto>().ReverseMap();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task Handle_ShouldReturnCalculatedBasketDto()
    {
        // Arrange
        var command = new CalculatePromotionForBasketCommand(new RawBasketDto());
        var expectedCalculatedBasket = new CalculatedBasket();
        _promoCalculatorMock.Setup(x => x.CalculatePromotion(It.IsAny<RawBasket>())).ReturnsAsync(expectedCalculatedBasket);

        var handler = new CalculatePromotionForBasketCommandHandler(_promoCalculatorMock.Object, _mapper);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsType<CalculatedBasketDto>(result);
        _promoCalculatorMock.Verify(x => x.CalculatePromotion(It.IsAny<RawBasket>()), Times.Once);
    }
}