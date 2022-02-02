using System;
using AutoMapper;
using IParking.Application.Interfaces;
using IParking.Application.ViewModel.Invoice;
using IParking.Domain.Interfaces.Service;

namespace IParking.Application
{
    public class InvoiceApplication : IInvoiceApplication
    {
        #region Properties
        private IMapper _mapper;
        private IInvoiceService _invoiceService;
        #endregion

        #region Ctor
        public InvoiceApplication(
            IMapper mapper,
            IInvoiceService invoiceService
            )
        {
            _mapper = mapper;
            _invoiceService = invoiceService;
        }
        #endregion

        #region Methods
        public MonthlyInvoiceViewModel GenerateMonthlyInvoiceForCustomer(int CustomerId, int Month = 0, int Year = 0)
        {
            if (Month == 0)
                Month = DateTime.Now.Month;

            if (Year == 0)
                Year = DateTime.Now.Year;

            var invoice = _invoiceService.GenerateMontlhyInvoiceForCustomer(CustomerId, Month, Year);

            var invoiceViewModel = _mapper.Map<MonthlyInvoiceViewModel>(invoice);

            return invoiceViewModel;
        }
        #endregion

    }
}
