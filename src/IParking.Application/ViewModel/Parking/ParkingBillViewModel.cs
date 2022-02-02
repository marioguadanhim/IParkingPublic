using System;

namespace IParking.Application.ViewModel.Parking
{
    public class ParkingBillViewModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Total { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
    }
}
