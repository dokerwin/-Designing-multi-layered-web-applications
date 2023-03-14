using Layered.Common.Interfaces.Persistance;
using Layered.Domain.Entities;
using Layered.Domain.Services.Interfaces;

namespace Layered.Aplication.Services;

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

    public async Task<bool> UpdatePromotion(Promotion promotion)
    {
        bool result;
        try
        {
            await _unitOfWork.Promotions.Upsert(promotion);
            await _unitOfWork.CompleteAsync();
            result = true;
            // Send domain notifications
        }
        catch (Exception)
        {
            result = false;
        }
        return result;
    }
}

