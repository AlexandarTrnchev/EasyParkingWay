using Application.Parkings.Models;
using System;
using System.Collections.Generic;

namespace Application.ParkingPlaces.Models
{
    public class ParkingPlaceDtoListModel
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public ParkingDto Parking { get; set; }
        public List<ParkingPlaceDto> ParkingPlaces { get; set; }
    }
}
