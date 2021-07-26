using Application.Common.Mappings;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.ParkingPlaces.Models
{
    public class ParkingPlaceDto : IMapFrom<ParkingPlace>
    {
        public int Number { get; set; }

        public bool IsFree { get; set; }

        public List<Payment> Payments { get; set; }
    }
}
