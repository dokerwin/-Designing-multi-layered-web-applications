using Layered.Application.UseCases.DeletePromotion;
using Layered.Domain.Services.Interfaces;
using Moq;

namespace Layered.Application.Test.UseCases;

public class DeletePromotionTest
{
    private readonly Mock<IPromoService> _promoServiceMock;

    public DeletePromotionTest()
    {
        _promoServiceMock = new Mock<IPromoService>();
    }

    [Fact]
    public async Task Handle_WithValidCommand_ReturnsTrue()
    {
        // Arrange

        var promoServiceMock = new Mock<IPromoService>();
        promoServiceMock.Setup(x => x.DeletePromotion(It.IsAny<Guid>()))
                        .ReturnsAsync(true);

        var handler = new DeletePromotionCommandHandler(promoServiceMock.Object);
        var command = new DeletePromotionCommand(Guid.NewGuid());

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result );
        promoServiceMock.Verify(x => x.DeletePromotion(command.Id), Times.Once);
    }
}