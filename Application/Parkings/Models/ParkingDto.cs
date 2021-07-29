using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Parkings.Models
{
    public class ParkingDto : IMapFrom<Parking>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public decimal PricePerParkingPlace { get; set; }

        public decimal longitude { get; set; }

        public decimal Latitude { get; set; }

        public string ImageUrl { get; set; }

        public City City { get; set; }

        public List<ParkingPlace> ParkingPlaces { get; set; }
    }
}
