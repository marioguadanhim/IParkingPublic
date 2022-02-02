using System.Collections.Generic;
using IParking.Domain.Entities;
using IParking.Domain.Interfaces.Factory;
using IParking.Domain.Interfaces.Repository;
using IParking.Domain.Interfaces.Service;
using IParking.Domain.Services.Invoice;
using IParking.Domain.Services.Invoice.InvoiceCalculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IParking.Test.InvoiceGeneration
{
    [TestClass]
    public class InvoiceGeneration_Test
    {
        Mock<IInvoiceCalculatorFactory> mockIInvoiceCalculatorFactory;
        Mock<ICustomerRepository> mockICustomerRepository;
        Mock<IParkingTimeRepository> mockIParkingTimeRepository;

        [TestInitialize]
        public void Init()
        {
            mockIInvoiceCalculatorFactory = new Mock<IInvoiceCalculatorFactory>();
            mockICustomerRepository = new Mock<ICustomerRepository>();
            mockIParkingTimeRepository = new Mock<IParkingTimeRepository>();
        }

        [TestMethod]
        public void InvoiceGenerationCustomerNotFounded()
        {
            Customer customer = null;
            mockICustomerRepository.Setup(_ => _.FullCustomerById(It.IsAny<int>())).Returns(customer);

            IInvoiceService invoiceService = new InvoiceService(mockIInvoiceCalculatorFactory.Object, mockICustomerRepository.Object, mockIParkingTimeRepository.Object);

            var invoice = invoiceService.GenerateMontlhyInvoiceForCustomer(1, 1, 1);

            Assert.IsNull(invoice);
        }

        [TestMethod]
        public void InvoiceGenerationNoParkingsFounded()
        {
            Customer customer = new Customer
            {
                FullName = "Mario",
                CustomerTypeId = (int)EnumCustomerType.Premium
            };
            mockICustomerRepository.Setup(_ => _.FullCustomerById(It.IsAny<int>())).Returns(customer);

            List<ParkingTime> parkingTimes = null;
            mockIParkingTimeRepository.Setup(_ => _.GetMonthlyParkingTimeOfCustomer(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(parkingTimes);

            IInvoiceService invoiceService = new InvoiceService(mockIInvoiceCalculatorFactory.Object, mockICustomerRepository.Object, mockIParkingTimeRepository.Object);

            var invoice = invoiceService.GenerateMontlhyInvoiceForCustomer(1, 1, 1);

            Assert.IsNull(invoice);
        }


        [TestMethod]
        public void InvoiceGenerationComplete()
        {
            Customer customerMario = new Customer
            {
                CustomerId = 1,
                FullName = "Mario",
                CustomerTypeId = (int)EnumCustomerType.Premium
            };
            Customer customerFooBar = new Customer
            {
                CustomerId = 2,
                FullName = "FooBar",
                CustomerTypeId = (int)EnumCustomerType.Regular
            };
            mockICustomerRepository.Setup(_ => _.FullCustomerById(1)).Returns(customerMario);
            mockICustomerRepository.Setup(_ => _.FullCustomerById(2)).Returns(customerFooBar);

            List<ParkingTime> parkingTimes = new List<ParkingTime>();
            parkingTimes.Add(new ParkingTime()
            {
                Total = 10
            });
            parkingTimes.Add(new ParkingTime()
            {
                Total = 20
            });
            parkingTimes.Add(new ParkingTime()
            {
                Total = 30
            });
            mockIParkingTimeRepository.Setup(_ => _.GetMonthlyParkingTimeOfCustomer(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(parkingTimes);
            
            mockIInvoiceCalculatorFactory.Setup(_ => _.CreateInvoiceCalculator(EnumCustomerType.Premium)).Returns(new InvoiceCalculatorPremium());
            mockIInvoiceCalculatorFactory.Setup(_ => _.CreateInvoiceCalculator(EnumCustomerType.Regular)).Returns(new InvoiceCalculatorRegular());

            IInvoiceService invoiceService = new InvoiceService(mockIInvoiceCalculatorFactory.Object, mockICustomerRepository.Object, mockIParkingTimeRepository.Object);

            var invoice = invoiceService.GenerateMontlhyInvoiceForCustomer(2, 1, 1);

            Assert.AreEqual(invoice.Total, 60);
            Assert.AreEqual(invoice.MonthlyFee, 0);

            invoice = invoiceService.GenerateMontlhyInvoiceForCustomer(1, 1, 1);

            Assert.AreEqual(invoice.Total, 80);
            Assert.AreEqual(invoice.MonthlyFee, 20);

        }




    }
}
