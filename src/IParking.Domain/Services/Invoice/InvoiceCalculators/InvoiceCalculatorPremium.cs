using System.Collections.Generic;
using IParking.Domain.Entities;

namespace IParking.Domain.Services.Invoice.InvoiceCalculators
{
    public class InvoiceCalculatorPremium : InvoiceCalculatorBase
    {
        public InvoiceCalculatorPremium()
            : base(20)
        {

        }

        public override decimal CalculateMonthlyInvoice(List<ParkingTime> arrParkingTime)
        {
            var total = base.CalculateMonthlyInvoice(arrParkingTime);

            if (total >= 300)
                return 300;
            else
                return total;
        }
    }
}
