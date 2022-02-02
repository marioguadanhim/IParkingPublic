using IParking.Application.Interfaces;
using IParking.Application.ViewModel.Invoice;
using Microsoft.AspNetCore.Mvc;

namespace IParking.WebApi.Controllers
{
    /// <summary>
    /// Endpoint to create the monthly invoice of the customer
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : Controller
    {
        private IInvoiceApplication _invoiceApplication;

        public InvoiceController(
            IInvoiceApplication invoiceApplication
        )
        {
            _invoiceApplication = invoiceApplication;
        }

        /// <summary>
        /// Generate a monthly invoice to the customer with all parkings of the month
        /// </summary>
        /// <param name="CustomerId">Id of the customer to generate the invoice</param>
        /// <param name="Month">0 means the current month</param>
        /// <param name="Year">0 means the current year</param>
        /// <returns></returns>
        [HttpGet("GenerateMonthlyInvoice")]
        public MonthlyInvoiceViewModel GenerateMonthlyInvoiceForCustomer(int CustomerId, int Month = 0, int Year = 0)
        {
            return _invoiceApplication.GenerateMonthlyInvoiceForCustomer(CustomerId, Month, Year);
        }
    }
}
