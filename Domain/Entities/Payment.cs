using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Payment : AuditableEntity
    {
        public int ParkingPlaceId { get; set; }

        public ParkingPlace ParkingPlace { get; set; }

        public DateTime? RentFrom { get; set; }

        public DateTime? RentTo { get; set; }
    }
}
