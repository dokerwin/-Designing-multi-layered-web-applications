using Hexagonal.Domain.Model.Entities;
using Hexagonal.Domain.Services.Persistance.Interfaces;
using Hexagonal.Domain.Services.Services.Interfaces;

namespace Hexagonal.Domain.Services.Services;

public class StandardPromoService : IPromoService
{
    private readonly IUnitOfWork _unitOfWork;

    public StandardPromoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
        catch (Exception)
        {
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
}
