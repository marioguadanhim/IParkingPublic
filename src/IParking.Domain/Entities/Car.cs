using System.Collections.Generic;

namespace IParking.Domain.Entities
{
    public class Car
    {
        public Car()
        {
            ParkingTime = new HashSet<ParkingTime>();
        }

        public int CarId { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<ParkingTime> ParkingTime { get; set; }
    }
}
