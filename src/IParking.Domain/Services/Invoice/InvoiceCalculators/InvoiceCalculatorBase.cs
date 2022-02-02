using System.Collections.Generic;
using System.Linq;
using IParking.Domain.Entities;

namespace IParking.Domain.Services.Invoice.InvoiceCalculators
{
    public abstract class InvoiceCalculatorBase
    {
        #region Properties
        public decimal MonthlyFee { get; private set; }
        #endregion

        #region Ctor
        public InvoiceCalculatorBase(
            decimal monthlyFee
        )
        {
            this.MonthlyFee = monthlyFee;
        }
        #endregion

        #region Methods
        public virtual decimal CalculateMonthlyInvoice(List<ParkingTime> arrParkingTime)
        {
            var totalMonthly = (arrParkingTime?.Sum(_ => _.Total) ?? 0) + MonthlyFee;

            return totalMonthly;
        }
        #endregion

    }
}
