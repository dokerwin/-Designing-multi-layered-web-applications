using Layered.Domain.Entities;

namespace Layered.Domain.Services.Interfaces
{
    public interface IPromoService
    {
        Task<bool> AddNewPromotion(Promotion promotion);
        Task<bool> DeletePromotion(Guid promotionID);
        Task<IEnumerable<Promotion>> GetAllPromotions();
        Task<Promotion> GetPromotionById(Guid promotionID);
        Task<bool> UpdatePromotion(Promotion promotion);
    }
}