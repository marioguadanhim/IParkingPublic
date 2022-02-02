using System;

namespace IParking.Application.ViewModel.Parking
{
    public class SimpleParkingViewModel
    {
        public int ParkingTimeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Total { get; set; }
        public int CarId { get; set; }
    }
}
