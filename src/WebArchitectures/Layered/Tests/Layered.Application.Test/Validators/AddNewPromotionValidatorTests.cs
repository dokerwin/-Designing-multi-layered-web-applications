using FluentValidation.TestHelper;
using Layered.Aplications.Validators;
using Layered.Application.DTOs;
using Layered.Common.Interfaces.Persistance;
using Layered.Domain.Entities;
using Moq;

namespace Layered.Application.UnitTest.Validators;

public class AddNewPromotionValidatorTests
{
    private readonly AddNewPromotionValidator _validator;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public AddNewPromotionValidatorTests()
    {
        Mock<IPromotionRepository> repositoryMock = new Mock<IPromotionRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _unitOfWorkMock.Setup(uow => uow.Promotions).Returns(repositoryMock.Object);
        _validator = new AddNewPromotionValidator(_unitOfWorkMock.Object);
    }

    [Fact]
    public async Task ShouldHaveValidationError_WhenNameIsEmpty()
    {
        // Arrange
        var promotionDto = new PromotionDto { Name = "" };

        // Act
        var result = await _validator.TestValidateAsync(promotionDto);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Name);
    }

    [Fact]
    public async Task ShouldHaveValidationError_WhenNameIsTooShort()
    {
        // Arrange
        var promotionDto = new PromotionDto { Name = "Short" };

        // Act
        var result = await _validator.TestValidateAsync(promotionDto);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Name);
    }

    [Fact]
    public async Task ShouldHaveValidationError_WhenNameIsTooLong()
    {
        // Arrange
        var promotionDto = new PromotionDto { StartTime = new DateTime(2023, 3, 10),
            EndTime = new DateTime(2023, 3, 11),
            Name = "This name is too long. It exceeds the maximum length. This name is too long.It exceeds the maximum length."
        };

        // Act
        var result = await _validator.TestValidateAsync(promotionDto);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Name);
    }

    [Fact]
    public async Task ShouldHaveValidationError_WhenStartTimeIsGreaterThanEndTime()
    {
        // Arrange
        var promotionDto = new PromotionDto { StartTime = new DateTime(2023, 3, 10), EndTime = new DateTime(2023, 3, 9) };

        // Act
        var result = await _validator.TestValidateAsync(promotionDto);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.StartTime);
    }

    [Fact]
    public async Task ShouldHaveValidationError_WhenPromotionNameIsTaken()
    {
        // Arrange
        var promotionDto = new PromotionDto { Name = "Promotion 1" };
        var existingPromotion = new Promotion { Id = Guid.NewGuid(), Name = "Promotion 1" };
        _unitOfWorkMock.Setup(uow => uow.Promotions.FindByName(promotionDto.Name)).ReturnsAsync(existingPromotion);

        // Act
        var result = await _validator.TestValidateAsync(promotionDto);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Name).WithErrorMessage("Promotion name is taken");
    }

}
