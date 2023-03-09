using Hexagonal.Domain.Model.Entities;

namespace Hexagonal.Domain.Services.Services.Interfaces;

public interface IPromoService
{
    Task<bool> AddNewPromotion(Promotion promotion);
    Task<bool> DeletePromotion(Guid promotionID);
    Task<IEnumerable<Promotion>> GetAllPromotions();
    Task<Promotion> GetPromotionById(Guid promotionID);
}