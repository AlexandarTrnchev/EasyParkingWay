using Application.Parkings.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ParkingPlaces.Models
{
    public class ParkingPlaceDtoListModel
    {
        public ParkingDto Parking { get; set; }
        public List<ParkingPlaceDto> ParkingPlaces { get; set; }
    }
}
