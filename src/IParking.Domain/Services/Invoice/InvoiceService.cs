using System;
using System.Globalization;
using IParking.Domain.Entities;
using IParking.Domain.Interfaces.Factory;
using IParking.Domain.Interfaces.Repository;
using IParking.Domain.Interfaces.Service;
using IParking.Domain.ValueObjects;

namespace IParking.Domain.Services.Invoice
{
    public class InvoiceService : IInvoiceService
    {
        #region Properties
        private IInvoiceCalculatorFactory _invoiceCalculatorFactory;
        private ICustomerRepository _customerRepository;
        private IParkingTimeRepository _parkingTimeRepository;
        #endregion

        #region Ctor
        public InvoiceService(
            IInvoiceCalculatorFactory invoiceCalculatorFactory,
            ICustomerRepository customerRepository,
            IParkingTimeRepository parkingTimeRepository
        )
        {
            _invoiceCalculatorFactory = invoiceCalculatorFactory;
            _customerRepository = customerRepository;
            _parkingTimeRepository = parkingTimeRepository;
        }
        #endregion

        #region Methods
        public CustomerMonthlyInvoiceVo GenerateMontlhyInvoiceForCustomer(int customerId, int month, int year)
        {
            var customer = _customerRepository.FullCustomerById(customerId);
            if (customer == null)
                return null;

            var arrParkingTimes = _parkingTimeRepository.GetMonthlyParkingTimeOfCustomer(customerId, month, year);
            if (arrParkingTimes == null)
                return null;

            var invoiceCalculator = _invoiceCalculatorFactory.CreateInvoiceCalculator((EnumCustomerType)customer.CustomerTypeId);
            var total = invoiceCalculator.CalculateMonthlyInvoice(arrParkingTimes);

            CustomerMonthlyInvoiceVo customerMonthlyInvoice = new CustomerMonthlyInvoiceVo(customer, total, invoiceCalculator.MonthlyFee, arrParkingTimes, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month == 0 ? DateTime.Now.Month : month));

            return customerMonthlyInvoice;
        }


        #endregion

    }
}
