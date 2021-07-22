using Domain.Common;

namespace Domain.Entities
{
    public class Payment : AuditableEntity
    {
        public int ParkingPlaceId { get; set; }
        public ParkingPlace ParkingPlace { get; set; }
    }
}
