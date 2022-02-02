using IParking.Domain.Entities;
using IParking.Domain.Interfaces.Repository;
using IParking.Domain.Interfaces.Service;

namespace IParking.Domain.Services.Cars
{
    public class CarService : ICarService
    {
        #region Properties
        private ICarRepository _carRepository;
        #endregion

        #region Ctor
        public CarService(
            ICarRepository carRepository
        )
        {
            _carRepository = carRepository;
        }
        #endregion

        #region Methods
        public Car AddCar(Car newCar)
        {
            return _carRepository.InsertNewCar(newCar);
        }

        public Car FullCarById(int carId)
        {
            return _carRepository.FullCarById(carId);
        }
        #endregion


    }
}
