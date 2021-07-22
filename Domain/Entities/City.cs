using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class City : AuditableEntity
    {
        public string Name { get; set; }

        public List<Parking> Parkings { get; set; }
    }
}
