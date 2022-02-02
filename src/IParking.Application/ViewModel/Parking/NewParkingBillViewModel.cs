using System;

namespace IParking.Application.ViewModel.Parking
{
    public class NewParkingBillViewModel
    {
        public int CarId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
