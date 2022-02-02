using System;
using IParking.Domain.Entities;
using IParking.Domain.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IParking.Test.TimeCalculation
{
    [TestClass]
    public class TimeCalculationRegular_Test
    {
        private ParkingCalculatorFactory parkingCalculator;

        [TestInitialize]
        public void InitTest()
        {
            parkingCalculator = new ParkingCalculatorFactory();
        }

        [TestMethod]
        public void TimeCalculation_Daily_Regular_6()
        {
            DateTime startTime = new DateTime(2019, 4, 1, 12, 0, 0);

            DateTime endTime = new DateTime(2019, 4, 1, 15, 0, 0);

            var parkingPremium = parkingCalculator.CreateParkingCalculator(EnumCustomerType.Regular);

            var amount = parkingPremium.CalculateMethod(startTime, endTime);

            Assert.AreEqual(amount, 9);

        }

        [TestMethod]
        public void TimeCalculation_Nightly_Regular_6()
        {
            DateTime startTime = new DateTime(2019, 4, 1, 19, 0, 0);

            DateTime endTime = new DateTime(2019, 4, 1, 23, 0, 0);

            var parkingPremium = parkingCalculator.CreateParkingCalculator(EnumCustomerType.Regular);

            var amount = parkingPremium.CalculateMethod(startTime, endTime);

            Assert.AreEqual(amount, 8);

        }

        [TestMethod]
        public void TimeCalculation_Mixed_Regular()
        {
            DateTime startTime = new DateTime(2019, 4, 1, 17, 0, 0);

            DateTime endTime = new DateTime(2019, 4, 1, 20, 0, 0);

            var parkingPremium = parkingCalculator.CreateParkingCalculator(EnumCustomerType.Regular);

            var amount = parkingPremium.CalculateMethod(startTime, endTime);

            Assert.AreEqual(amount, 8);

        }


    }
}
