using IParking.Application.ViewModel.Invoice;

namespace IParking.Application.Interfaces
{
    public interface IInvoiceApplication
    {
        MonthlyInvoiceViewModel GenerateMonthlyInvoiceForCustomer(int CustomerId, int Month = 0, int Year = 0);
    }
}