using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ParkingPlace : AuditableEntity
    {
        public int Number { get; set; }

        public int ParkingId { get; set; }

        public Parking Parking { get; set; }

        public List<Payment> Payments { get; set; }
    }
}
