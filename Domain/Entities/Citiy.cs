using Domain.Common;

namespace Domain.Entities
{
    class Citiy : AuditableEntity
    {
        public string Name { get; set; }

        //public List<Parking> Parkings { get; set; }
    }
}
