using IParking.Domain.ValueObjects;

namespace IParking.Domain.Interfaces.Service
{
    public interface IInvoiceService
    {
        CustomerMonthlyInvoiceVo GenerateMontlhyInvoiceForCustomer(int customerId, int month, int year);
    }
}