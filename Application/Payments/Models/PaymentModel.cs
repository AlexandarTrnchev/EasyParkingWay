using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Payments.Models
{
    public class PaymentModel
    {
        public string  City { get; set; }

        public string  ParkingName { get; set; }

        public int  ParkingPlaceId{ get; set; }

        public string  Address { get; set; }

        public decimal Amount { get; set; }

        public DateTime RentFrom { get; set; }

        public DateTime RentTo { get; set; }
    }
}
