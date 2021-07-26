using Domain.Common;

namespace Domain.Entities
{
    public class Configuration : AuditableEntity
    {
        public decimal PricePerDay { get; set; }
    }
}
