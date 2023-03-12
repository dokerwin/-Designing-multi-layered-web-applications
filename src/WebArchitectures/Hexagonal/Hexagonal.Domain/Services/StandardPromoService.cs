using Hexagonal.Domain.Model.Entities;
using Hexagonal.Domain.Services.Persistance.Interfaces;
using Hexagonal.Domain.Services.Services.Interfaces;

namespace Hexagonal.Domain.Services.Services;

public class StandardPromoService : IPromoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<StandardPromoService>  _logger;
    public StandardPromoService(IUnitOfWork unitOfWork, ILogger<StandardPromoService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Guid> AddNewPromotion(Promotion promotion)
    {
        try
        {
            await _unitOfWork.Promotions.Add(promotion);

            await _unitOfWork.CompleteAsync();
            // Send domain notifications

            return promotion.Id;
        }
        catch (Exception)
        {
            return Guid.Empty;
        }
    }


    public async Task<bool> DeletePromotion(Guid promotionID)
    {
        try
        {
            await _unitOfWork.Promotions.Delete(promotionID);

            // Send domain notifications

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return false;
        }
    }

    public async Task<Promotion> GetPromotionById(Guid promotionID)
    {
        try
        {
            var result = await _unitOfWork.Promotions.GetById(promotionID);
            return result;
        }
        catch (Exception)
        {
            return new Promotion();
        }
    }

    public async Task<IEnumerable<Promotion>> GetAllPromotions()
    {
        try
        {
            var result = await _unitOfWork.Promotions.All();
            return result;
        }
        catch (Exception)
        {
            return new List<Promotion>();
        }
    }

    public async Task<bool> UpdatePromotion(Promotion promotion)
    {
        bool result;
        try
        {
            await _unitOfWork.Promotions.Upsert(promotion);

            result = await _unitOfWork.CompleteAsync();
            // Send domain notifications
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            result = false;
        }
        return result;
    }
}
