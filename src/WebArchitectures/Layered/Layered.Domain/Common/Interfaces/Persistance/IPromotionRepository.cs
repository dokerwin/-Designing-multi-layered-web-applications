using Layered.Domain.Entities;

namespace Layered.Common.Interfaces.Persistance;
public interface IPromotionRepository : IRepository<Promotion>
{
     Task<Promotion> FindByName(string name);
}
