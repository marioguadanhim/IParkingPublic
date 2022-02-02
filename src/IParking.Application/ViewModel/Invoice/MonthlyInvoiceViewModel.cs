using System.Collections.Generic;
using IParking.Application.ViewModel.Parking;

namespace IParking.Application.ViewModel.Invoice
{
    public class MonthlyInvoiceViewModel
    {
        public string MonthOfInvoice { get; set; }
        public string FullName { get; set; }
        public string TypeDescription { get; set; }
        public decimal MonthlyFee { get; set; }
        public decimal Total { get; set; }
        public List<ParkingBillViewModel> ParkingTime { get; set; }
    }
}
