using Application.Common.Mappings;
using Domain.Entities;
using System;

namespace Application.Payments.Models
{
    public class PaymentModel : IMapFrom<Payment>
    {
        public string  City { get; set; }

        public string  ParkingName { get; set; }

        public int  ParkingNumber { get; set; }

        public int  ParkingPlaceId{ get; set; }

        public int  ParkingId{ get; set; }

        public string  Address { get; set; }

        public decimal Amount { get; set; }

        public DateTime RentFrom { get; set; }

        public DateTime RentTo { get; set; }
    }
}
