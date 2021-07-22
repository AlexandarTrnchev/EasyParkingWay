using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ParkingPlace : AuditableEntity
    {
        public string Number { get; set; }

        public bool IsFree { get; set; }

        public DateTime RentFrom { get; set; }

        public DateTime RentTo { get; set; }

        public int ParkingId { get; set; }

        public Parking Parking { get; set; }

        public List<Payment> Payments { get; set; }
    }
}
