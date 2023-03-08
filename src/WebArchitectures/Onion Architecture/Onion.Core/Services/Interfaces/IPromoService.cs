using Onion.Domain.Model.Entities;

namespace Onion.Domain.Services.Services.Interfaces
{
    public interface IPromoService
    {
        Task<bool> AddNewPromotion(Promotion promotion);
        Task<bool> DeletePromotion(Guid promotionID);
        Task<IEnumerable<Promotion>> GetAllPromotions();
        Task<Promotion> GetPromotionById(Guid promotionID);
    }
}