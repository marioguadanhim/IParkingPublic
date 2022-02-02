using IParking.Domain.Entities;
using IParking.Domain.Interfaces.Factory;
using IParking.Domain.Services.Invoice.InvoiceCalculators;

namespace IParking.Domain.Factory
{
    public class InvoiceCalculatorFactory : IInvoiceCalculatorFactory
    {


        public InvoiceCalculatorBase CreateInvoiceCalculator(EnumCustomerType enumCustomerType)
        {
            InvoiceCalculatorBase invoiceCalculator = null;
            switch (enumCustomerType)
            {
                case EnumCustomerType.Premium:
                    invoiceCalculator = new InvoiceCalculatorPremium();
                    break;
                case EnumCustomerType.Regular:
                    invoiceCalculator = new InvoiceCalculatorRegular();
                    break;
                default:
                    invoiceCalculator = new InvoiceCalculatorRegular();
                    break;
            }

            return invoiceCalculator;
        }
    }
}
