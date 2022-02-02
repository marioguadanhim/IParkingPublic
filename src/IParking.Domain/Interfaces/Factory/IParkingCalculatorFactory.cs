using IParking.Domain.Entities;
using IParking.Domain.Services.Parking.ParkingCalculators;

namespace IParking.Domain.Interfaces.Factory
{
    public interface IParkingCalculatorFactory
    {
        ParkingCalculator CreateParkingCalculator(EnumCustomerType enumCustomerType);
    }
}