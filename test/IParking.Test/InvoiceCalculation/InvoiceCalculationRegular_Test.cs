using System.Collections.Generic;
using IParking.Domain.Entities;
using IParking.Domain.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IParking.Test.InvoiceCalculation
{
    [TestClass]
    public class InvoiceCalculationRegular_Test
    {

        private InvoiceCalculatorFactory invoiceCalculator;

        [TestInitialize]
        public void InitTest()
        {
            invoiceCalculator = new InvoiceCalculatorFactory();
        }

        [TestMethod]
        public void InvoiceCalculation_Regular_PremiumNotNecessary()
        {
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

            var invoicePremium = invoiceCalculator.CreateInvoiceCalculator(EnumCustomerType.Regular);

            var total = invoicePremium.CalculateMonthlyInvoice(parkingTimes);

            Assert.AreEqual(total, 60);

        }


        [TestMethod]
        public void InvoiceCalculation_Regular_PremiumNecessary()
        {
            List<ParkingTime> parkingTimes = new List<ParkingTime>();
            parkingTimes.Add(new ParkingTime()
            {
                Total = 125
            });
            parkingTimes.Add(new ParkingTime()
            {
                Total = 20.5M
            });
            parkingTimes.Add(new ParkingTime()
            {
                Total = 56.7M
            });
            parkingTimes.Add(new ParkingTime()
            {
                Total = 192.05M
            });

            var invoicePremium = invoiceCalculator.CreateInvoiceCalculator(EnumCustomerType.Regular);

            var total = invoicePremium.CalculateMonthlyInvoice(parkingTimes);

            Assert.AreEqual(total, 394.25M);
        }

    }
}
