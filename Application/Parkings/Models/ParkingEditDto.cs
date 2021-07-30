using Application.Common.Mappings;
using Domain.Entities;


namespace Application.Parkings.Models
{
    public class ParkingEditDto : IMapFrom<Parking>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public decimal PricePerParkingPlace { get; set; }
    }
}
