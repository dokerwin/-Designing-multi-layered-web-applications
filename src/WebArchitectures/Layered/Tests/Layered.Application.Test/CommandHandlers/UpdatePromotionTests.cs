using AutoMapper;
using Layered.Application.DTOs;
using Layered.Application.UseCases.UpdatePromotion;
using Layered.Domain.Entities;
using Layered.Domain.Services.Interfaces;
using Moq;

namespace Layered.Application.Test.UseCases;

public class UpdatePromotionTests
{
    [Fact]
    public async Task Handle_WithValidCommand_ReturnsTrue()
    {
        // Arrange
        var promoServiceMock = new Mock<IPromoService>();
        promoServiceMock.Setup(x => x.UpdatePromotion(It.IsAny<Promotion>()))
                        .ReturnsAsync(true);

        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(x => x.Map<Promotion>(It.IsAny<object>()))
                  .Returns(new Promotion());

        var promotion = new PromotionDto();

        var handler = new UpdatePromotionCommandHandler(promoServiceMock.Object, mapperMock.Object);
        var command = new UpdatePromotionCommand (promotion);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
        promoServiceMock.Verify(x => x.UpdatePromotion(It.IsAny<Promotion>()), Times.Once);
        mapperMock.Verify(x => x.Map<Promotion>(command.PromotionDto), Times.Once);
    }
}
