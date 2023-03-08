using Layered.Aplication.Services;
using Layered.Common.Interfaces.Persistance;
using Layered.Domain.Entities;
using Moq;

namespace Layered.Aplication.Tests.Services
{
    public class StandardPromoServiceTests
    {
        private  Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly StandardPromoService _promoService;

        public StandardPromoServiceTests()
        {
            Mock<IPromotionRepository> repositoryMock = new Mock<IPromotionRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(uow => uow.Promotions).Returns(repositoryMock.Object);
            _promoService = new StandardPromoService(_mockUnitOfWork.Object);
        }


        [Fact]
        public async Task AddNewPromotion_ShouldCallUnitOfWorkAdd()
        {
            // Arrange
            var promotion = new Promotion();

            // Act
            var result = await _promoService.AddNewPromotion(promotion);

            // Assert
            _mockUnitOfWork.Verify(uow => uow.Promotions.Add(promotion), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public async Task AddNewPromotion_ShouldReturnFalseWhenExceptionIsThrown()
        {
            // Arrange
            var promotion = new Promotion();
            _mockUnitOfWork.Setup(uow => uow.Promotions.Add(promotion)).ThrowsAsync(new Exception());

            // Act
            var result = await _promoService.AddNewPromotion(promotion);

            // Assert
            Assert.False(result);
        }


        [Fact]
        public async Task DeletePromotion_ShouldReturnFalseWhenExceptionIsThrown()
        {
            // Arrange
            var promotionId = Guid.NewGuid();
            _mockUnitOfWork.Setup(uow => uow.Promotions.Delete(promotionId)).ThrowsAsync(new Exception());

            // Act
            var result = await _promoService.DeletePromotion(promotionId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task GetPromotionById_ShouldCallUnitOfWorkGetById()
        {
            // Arrange
            var promotionId = Guid.NewGuid();
            var expectedPromotion = new Promotion() { Id = promotionId };
            _mockUnitOfWork.Setup(uow => uow.Promotions.GetById(promotionId)).ReturnsAsync(expectedPromotion);

            // Act
            var result = await _promoService.GetPromotionById(promotionId);

            // Assert
            _mockUnitOfWork.Verify(uow => uow.Promotions.GetById(promotionId), Times.Once);
            Assert.Equal(expectedPromotion, result);
        }
        [Fact]
        public async Task DeletePromotion_ShouldCallUnitOfWorkDelete()
        {
            // Arrange
            var promotionId = Guid.NewGuid();

            // Act
            var result = await _promoService.DeletePromotion(promotionId);

            // Assert
            _mockUnitOfWork.Verify(uow => uow.Promotions.Delete(promotionId), Times.Once);
            Assert.True(result);
        }


        [Fact]
        public async Task GetPromotionById_ShouldReturnEmptyPromotionWhenExceptionIsThrown()
        {
            // Arrange
            var promotionId = Guid.NewGuid();
            _mockUnitOfWork.Setup(uow => uow.Promotions.GetById(promotionId)).ThrowsAsync(new Exception());

            // Act
            var result = await _promoService.GetPromotionById(promotionId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Promotion>(result);
        }

        [Fact]
        public async Task GetAllPromotions_ShouldCallUnitOfWorkAll()
        {
            // Arrange
            var expectedPromotions = new List<Promotion> { new Promotion(), new Promotion() };
            _mockUnitOfWork.Setup(uow => uow.Promotions.All()).ReturnsAsync(expectedPromotions);

            // Act
            var result = await _promoService.GetAllPromotions();

            // Assert
            _mockUnitOfWork.Verify(uow => uow.Promotions.All(), Times.Once);
            Assert.Equal(expectedPromotions, result);
        }

        [Fact]
        public async Task GetAllPromotions_ShouldReturnEmptyListWhenExceptionIsThrown()
        {
            // Arrange
            _mockUnitOfWork.Setup(uow => uow.Promotions.All()).ThrowsAsync(new Exception());

            // Act
            var result = await _promoService.GetAllPromotions();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(((List<Promotion>)result));
        }
    }
}