using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Onion.Api.Conrollers;
using Onion.Application.DTOs;

namespace Layered.Api.Test;

public class PromotionControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly PromotionController _controller;

    public PromotionControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new PromotionController(_mediatorMock.Object);
    }

    [Fact]
    public void Get_Returns_With_PromotionDto()
    {
        // Arrange
        var id = Guid.NewGuid();
        var promotionDto = new PromotionDto { Id = id, Name = "Test Promotion" };
        _mediatorMock.Setup(x => x.Send(It.IsAny<GetPromotionsByIdQuery>(), default))
            .ReturnsAsync(promotionDto);

        // Act
        var result = _controller.Get(id);

        // Assert
        var returnedPromotionDto = Assert.IsAssignableFrom<PromotionDto>(result.Result);
        Assert.Equal(promotionDto, returnedPromotionDto);
    }

    [Fact]
    public async Task Get_Returns_With_PromotionDtos()
    {
        // Arrange
        var promotionDtos = new List<PromotionDto> { new PromotionDto { Name = "Promotion 1" } };
        _mediatorMock.Setup(x => x.Send(It.IsAny<GetAllPromotionsQuery>(), default))
            .ReturnsAsync(promotionDtos);

        // Act
        var result = await _controller.Get();

        // Assert
        var returnedPromotionDtos = Assert.IsAssignableFrom<IEnumerable<PromotionDto>>(result);
        Assert.Equal(promotionDtos, returnedPromotionDtos);
    }

    [Fact]
    public async Task AddPromotion_Returns_With_PromotionResultDto()
    {
        // Arrange
        var newPromo = new PromotionDto { Name = "New Promotion" };
        var promotionResultDto = new PromotionResultDto { Success = true };
        _mediatorMock.Setup(x => x.Send(It.IsAny<AddPromotionCommand>(), default))
            .ReturnsAsync(promotionResultDto);

        // Act
        var result = await _controller.AddPromotion(newPromo);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedPromotionResultDto = Assert.IsAssignableFrom<PromotionResultDto>(okResult.Value);
        Assert.Equal(promotionResultDto, returnedPromotionResultDto);
    }
}