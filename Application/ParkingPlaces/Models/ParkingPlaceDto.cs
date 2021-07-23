using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ParkingPlaces.Models
{
    public class ParkingPlaceDto : IMapFrom<ParkingPlace>
    {
        public int Number { get; set; }

        public bool IsFree { get; set; }

        public DateTime RentFrom { get; set; }

        public DateTime RentTo { get; set; }

        public List<Payment> Payments { get; set; }
    }
}
