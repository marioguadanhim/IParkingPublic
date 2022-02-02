using System.Collections.Generic;
using IParking.Domain.Entities;
using IParking.Domain.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IParking.Test.InvoiceCalculation
{
    [TestClass]
    public class InvoiceGeneration_Test
    {

        private InvoiceCalculatorFactory invoiceCalculator;

        [TestInitialize]
        public void InitTest()
        {
            invoiceCalculator = new InvoiceCalculatorFactory();
        }

        [TestMethod]
        public void InvoiceCalculation_Premium_PlusFee()
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
                Total = 5
            });
            parkingTimes.Add(new ParkingTime()
            {
                Total = 30
            });

            var invoicePremium = invoiceCalculator.CreateInvoiceCalculator(EnumCustomerType.Premium);

            var total = invoicePremium.CalculateMonthlyInvoice(parkingTimes);

            Assert.AreEqual(total, 85);

        }


        [TestMethod]
        public void InvoiceCalculation_Premium_MaximumValue()
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

            var invoicePremium = invoiceCalculator.CreateInvoiceCalculator(EnumCustomerType.Premium);

            var total = invoicePremium.CalculateMonthlyInvoice(parkingTimes);

            Assert.AreEqual(total, 300);

        }

    }
}
