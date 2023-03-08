using Layered.Domain.Entities.Base;

namespace Layered.Domain.Entities;

public class Promotion : EntityBase<Guid>
{
    public string Name { get; set; }
    public List<PromoBasket> PromoBaskets { get; set; }
    public DateTime StartOn { get; set; }
    public DateTime EndOn { get; set; }

}
