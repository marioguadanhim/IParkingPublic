using IParking.Domain.Entities;
using IParking.Domain.Services.Invoice.InvoiceCalculators;

namespace IParking.Domain.Interfaces.Factory
{
    public interface IInvoiceCalculatorFactory
    {
        InvoiceCalculatorBase CreateInvoiceCalculator(EnumCustomerType enumCustomerType);
    }
}