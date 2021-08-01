using Application.Common.CustomAnnotation;
using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Parkings.Models
{
    public class ParkingDto : IMapFrom<Parking>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        [NoZero(ErrorMessage = "Need a positive number, bigger than 0")]
        public decimal PricePerParkingPlace { get; set; }

        public decimal longitude { get; set; }

        public decimal Latitude { get; set; }

        public string ImageUrl { get; set; }

        public City City { get; set; }

        public List<ParkingPlace> ParkingPlaces { get; set; }
    }
}
