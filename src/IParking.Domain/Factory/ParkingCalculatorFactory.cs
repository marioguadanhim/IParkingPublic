using IParking.Domain.Entities;
using IParking.Domain.Interfaces.Factory;
using IParking.Domain.Services.Parking.ParkingCalculators;

namespace IParking.Domain.Factory
{
    public class ParkingCalculatorFactory : IParkingCalculatorFactory
    {
        public ParkingCalculator CreateParkingCalculator(EnumCustomerType enumCustomerType)
        {
            ParkingCalculator parkingCalculator = null;
            switch (enumCustomerType)
            {
                case EnumCustomerType.Premium:
                    parkingCalculator = new ParkingCalculatorPremium();
                    break;
                case EnumCustomerType.Regular:
                    parkingCalculator = new ParkingCalculatorRegular();
                    break;
                default:
                    parkingCalculator = new ParkingCalculatorRegular();
                    break;
            }

            return parkingCalculator;
        }
    }
}
