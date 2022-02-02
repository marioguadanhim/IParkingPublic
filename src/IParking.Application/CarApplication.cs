using AutoMapper;
using IParking.Application.Interfaces;
using IParking.Application.ViewModel.Car;
using IParking.Domain.Entities;
using IParking.Domain.Interfaces.Service;

namespace IParking.Application
{
    public class CarApplication : ICarApplication
    {
        #region Properties
        private IMapper _mapper;
        private ICarService _carService;
        #endregion

        #region Ctor
        public CarApplication(
            IMapper mapper,
            ICarService carService
            )
        {
            _mapper = mapper;
            _carService = carService;
        }
        #endregion

        #region Methods
        public CarDetailsViewModel AddCar(NewCarViewModel newCar)
        {
            var car = _mapper.Map<Car>(newCar);
            car = _carService.AddCar(car);
            var carDetails = _mapper.Map<CarDetailsViewModel>(car);
            return carDetails;
        }

        public FullCarViewModel FindById(int CarId)
        {
            var car = _carService.FullCarById(CarId);
            var carDetails = _mapper.Map<FullCarViewModel>(car);
            return carDetails;
        }
        #endregion

    }
}
