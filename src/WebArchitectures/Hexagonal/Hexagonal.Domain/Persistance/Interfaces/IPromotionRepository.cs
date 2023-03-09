using Hexagonal.Domain.Model.Entities;

namespace Hexagonal.Domain.Services.Persistance.Interfaces;
public interface IPromotionRepository : IRepository<Promotion>
{
    Task<Promotion> FindByName(string name);
}
