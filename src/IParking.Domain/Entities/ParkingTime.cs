using System;

namespace IParking.Domain.Entities
{
    public class ParkingTime
    {
        public int ParkingTimeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Total { get; set; }
        public int CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
