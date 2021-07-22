using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Parking : AuditableEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public List<ParkingPlace> ParkingPlaces { get; set; }
    }
}
