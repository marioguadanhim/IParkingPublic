using System.Collections.Generic;
using IParking.Domain.Entities;
using IParking.Domain.Interfaces.Factory;
using IParking.Domain.Interfaces.Repository;
using IParking.Domain.Interfaces.Service;

namespace IParking.Domain.Services.Parking
{
    public class ParkingService : IParkingService
    {
        #region Properties
        private IParkingCalculatorFactory _parkingCalculatorFactory;
        private IParkingTimeRepository _parkingTimeRepository;
        #endregion

        #region Construtor
        public ParkingService(
            IParkingCalculatorFactory parkingCalculatorFactory,
            IParkingTimeRepository parkingTimeRepository
            )
        {
            _parkingCalculatorFactory = parkingCalculatorFactory;
            _parkingTimeRepository = parkingTimeRepository;
        }
        #endregion

        #region Methods
        public ParkingTime AddParkingTime(ParkingTime parkingTime)
        {
            var parkingCalculator = _parkingCalculatorFactory.CreateParkingCalculator((EnumCustomerType)parkingTime.Car.Customer.CustomerTypeId);

            parkingTime.Total = parkingCalculator.CalculateMethod(parkingTime.StartTime, parkingTime.EndTime);

            return _parkingTimeRepository.InsertNewParkingTime(parkingTime);

        }

        public ParkingTime GetFullParkingTime(int Id)
        {
            return _parkingTimeRepository.GetFullParkingTime(Id);
        }

        public List<ParkingTime> GetAllParkingTimeByCar(int Id)
        {
            return _parkingTimeRepository.GetAllParkingTimeByCar(Id);
        }

        public List<ParkingTime> GetAllParkingTimeByCustomer(int Id)
        {
            return _parkingTimeRepository.GetAllParkingTimeByCustomer(Id);
        }
        #endregion

    }
}
