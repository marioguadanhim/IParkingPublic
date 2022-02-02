using System;
using IParking.Domain.Entities;
using IParking.Domain.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IParking.Test.TimeCalculation
{
    [TestClass]
    public class InvoiceCalculationPremium_Test
    {
        private ParkingCalculatorFactory parkingCalculator;

        [TestInitialize]
        public void InitTest()
        {
            parkingCalculator = new ParkingCalculatorFactory();
        }

        [TestMethod]
        public void TimeCalculation_Daily_Premium_6()
        {
            DateTime startTime = new DateTime(2019, 4, 1, 12, 0, 0);

            DateTime endTime = new DateTime(2019, 4, 1, 15, 0, 0);

            var parkingPremium = parkingCalculator.CreateParkingCalculator(EnumCustomerType.Premium);

            var amount = parkingPremium.CalculateMethod(startTime, endTime);

            Assert.AreEqual(amount, 6);

        }

        [TestMethod]
        public void TimeCalculation_Nightly_Premium_6()
        {
            DateTime startTime = new DateTime(2019, 4, 1, 19, 0, 0);

            DateTime endTime = new DateTime(2019, 4, 1, 23, 0, 0);

            var parkingPremium = parkingCalculator.CreateParkingCalculator(EnumCustomerType.Premium);

            var amount = parkingPremium.CalculateMethod(startTime, endTime);

            Assert.AreEqual(amount, 6);

        }

        [TestMethod]
        public void TimeCalculation_Mixed_Premium()
        {
            DateTime startTime = new DateTime(2019, 4, 1, 17, 0, 0);

            DateTime endTime = new DateTime(2019, 4, 1, 20, 0, 0);

            var parkingPremium = parkingCalculator.CreateParkingCalculator(EnumCustomerType.Premium);

            var amount = parkingPremium.CalculateMethod(startTime, endTime);

            Assert.AreEqual(amount, 5.5M);

        }


    }
}
