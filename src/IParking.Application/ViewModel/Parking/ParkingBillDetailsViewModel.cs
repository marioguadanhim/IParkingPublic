using System;

namespace IParking.Application.ViewModel.Parking
{
    public class ParkingBillDetailsViewModel
    {
        public int ParkingTimeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Total { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
        public string FullName { get; set; }
        public string TypeDescription { get; set; }
    }
}
