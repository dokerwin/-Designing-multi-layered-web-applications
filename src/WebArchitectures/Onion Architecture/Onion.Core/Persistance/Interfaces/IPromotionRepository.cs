using Onion.Domain.Model.Entities;

namespace Onion.Domain.Services.Persistance.Interfaces;
public interface IPromotionRepository : IRepository<Promotion>
{
    Task<Promotion> FindByName(string name);
}
