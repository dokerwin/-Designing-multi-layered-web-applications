using AutoMapper;
using Hexagonal.Application.UseCases.CreatePromotion;
using Hexagonal.Application.UseCases.Management;
using Hexagonal.Domain.Model.Entities;
using Hexagonal.Domain.Services.Services.Interfaces;
using Hexagonal.Shared.Application.DTOs;
using Moq;

namespace Hexagonal.Application.Tests.UseCases.CreatePromotion;

public class AddPromotionCommandHandlerTests
{
    private readonly Mock<IPromoService> _promoServiceMock;
    private readonly IMapper _mapper;

    public AddPromotionCommandHandlerTests()
    {
        _promoServiceMock = new Mock<IPromoService>();
        var mapperConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<PromotionDto, Promotion>();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task Handle_ShouldReturnPromotionResultDto()
    {
        var expectedPromotionId = Guid.NewGuid();
        // Arrange
        var command = new AddPromotionCommand(new PromotionDto()
        {
            Id = Guid.NewGuid()
        }); 
       
        _promoServiceMock.Setup(x => x.AddNewPromotion(It.IsAny<Promotion>())).ReturnsAsync(expectedPromotionId);

        var handler = new AddPromotionCommandHandler(_promoServiceMock.Object, _mapper);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsType<PromotionResultDto>(result);
        Assert.Equal(expectedPromotionId, result.PromotionId);
        _promoServiceMock.Verify(x => x.AddNewPromotion(It.IsAny<Promotion>()), Times.Once);
    }
}