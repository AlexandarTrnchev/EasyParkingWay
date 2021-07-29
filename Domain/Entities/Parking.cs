using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Parking : AuditableEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public decimal PricePerParkingPlace { get; set; }

        public decimal longitude { get; set; }

        public decimal Latitude { get; set; }

        public string ImageUrl { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public List<ParkingPlace> ParkingPlaces { get; set; }
    }
}
