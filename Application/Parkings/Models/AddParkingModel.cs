using Application.Common.CustomAnnotation;
using Application.Common.Mappings;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Parkings.Models
{
    public class AddParkingModel : IMapFrom<Parking>
    {
        [BindProperty]
        [Required(ErrorMessage = "Name is required")]
        public string  Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal PricePerParkingPlace { get; set; }

        public decimal longitude { get; set; }

        public decimal Latitude { get; set; }

        [Required] 
        [NoZero(ErrorMessage = "need a positive number, bigger than 0")]
        public int CityId { get; set; }

        public List<ParkingPlace> ParkingPlaces { get; set; }

        [Required(ErrorMessage = "Number Parking Places is required")]
        public int NumberParkingPlaces { get; set; }

    }
}
