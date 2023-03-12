using Hexagonal.Domain.Model.Entities;

namespace Hexagonal.Domain.Services.Services.Interfaces;

public interface IPromoService
{
    Task<Guid> AddNewPromotion(Promotion promotion);
    Task<bool> DeletePromotion(Guid promotionID);
    Task<IEnumerable<Promotion>> GetAllPromotions();
    Task<Promotion> GetPromotionById(Guid promotionID);
    Task<bool> UpdatePromotion(Promotion promotion);
}