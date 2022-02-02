using System.Collections.Generic;
using IParking.Domain.Entities;

namespace IParking.Domain.ValueObjects
{
    public class CustomerMonthlyInvoiceVo
    {
        public CustomerMonthlyInvoiceVo(
            Customer customer,
            decimal total,
            decimal monthlyFee,
            List<ParkingTime> parkingTimes,
            string monthOfInvoice
            )
        {
            this.Customer = customer;
            this.Total = total;
            this.MonthlyFee = monthlyFee;
            this.ParkingTimes = parkingTimes;
            this.MonthOfInvoice = monthOfInvoice;
        }

        public Customer Customer { get; set; }
        public decimal Total { get; set; }
        public decimal MonthlyFee { get; set; }
        public string MonthOfInvoice { get; set; }
        public List<ParkingTime> ParkingTimes { get; set; }
    }
}
