using AutoMapper;
using Layered.Application.DTOs;
using Layered.Application.UseCases.CreatePromotion;
using Layered.Domain.Entities;
using Layered.Domain.Services.Interfaces;
using Moq;

namespace Layered.Application.UnitTest.CommandHandlers;

public class AddPromotionCommandHandlerTests
{
    private readonly Mock<IPromoService> _promoServiceMock;
    private readonly Mock<IMapper> _mapperMock;

    public AddPromotionCommandHandlerTests()
    {
        _promoServiceMock = new Mock<IPromoService>();
        _mapperMock = new Mock<IMapper>();
    }

    [Fact]
    public async Task Handle_ShouldReturnPromotionResultDto_WhenAddNewPromotionSucceeds()
    {
        // Arrange
        var promotionDto = new PromotionDto();
        var command = new AddPromotionCommand(promotionDto);
        var promotion = new Promotion();
        var expectedDto = new PromotionResultDto { Success = true };

        _mapperMock.Setup(m => m.Map<Promotion>(promotionDto)).Returns(promotion);
        _promoServiceMock.Setup(s => s.AddNewPromotion(promotion)).ReturnsAsync(true);

        var handler = new AddPromotionCommandHandler(_promoServiceMock.Object, _mapperMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(expectedDto.Success, result.Success);
    }

    [Fact]
    public async Task Handle_ShouldReturnPromotionResultDto_WhenAddNewPromotionFails()
    {
        // Arrange
        var command = new AddPromotionCommand(new PromotionDto());
        var promotionDto = new PromotionDto();
        var promotion = new Promotion();
        var expectedDto = new PromotionResultDto { Success = false };

        _mapperMock.Setup(m => m.Map<Promotion>(promotionDto)).Returns(promotion);
        _promoServiceMock.Setup(s => s.AddNewPromotion(promotion)).ReturnsAsync(false);

        var handler = new AddPromotionCommandHandler(_promoServiceMock.Object, _mapperMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(expectedDto.Success, result.Success);
    }
}