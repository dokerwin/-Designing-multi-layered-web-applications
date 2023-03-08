using Onion.Domain.Model.Entities;
using Onion.Domain.Services.Persistance.Interfaces;
using Onion.Domain.Services.Services.Interfaces;

namespace Onion.Domain.Services.Services;

public class StandardPromoService : IPromoService
{
    private readonly IUnitOfWork _unitOfWork;

    public StandardPromoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> AddNewPromotion(Promotion promotion)
    {
        try
        {
            await _unitOfWork.Promotions.Add(promotion);

            await _unitOfWork.CompleteAsync();
            // Send domain notifications

            return true;
        }
        catch (Exception)
        {
            return false;
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
