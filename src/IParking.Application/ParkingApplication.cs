using System.Collections.Generic;
using AutoMapper;
using IParking.Application.Interfaces;
using IParking.Application.ViewModel.Parking;
using IParking.Domain.Entities;
using IParking.Domain.Interfaces.Service;

namespace IParking.Application
{
    public class ParkingApplication : IParkingApplication
    {
        #region Properties
        private IMapper _mapper;
        private ICarService _carService;
        private IParkingService _parkingService;
        #endregion

        #region Ctor
        public ParkingApplication(
             IMapper mapper,
             ICarService carService,
             IParkingService parkingService
            )
        {
            _mapper = mapper;
            _carService = carService;
            _parkingService = parkingService;
        }
        #endregion

        #region Methods
        public SimpleParkingViewModel AddParkingTime(NewParkingBillViewModel newParkingBillViewModel)
        {
            var parkingTime = _mapper.Map<ParkingTime>(newParkingBillViewModel);

            var car = _carService.FullCarById(parkingTime.CarId);
            if (car == null)
                return null;

            parkingTime.Car = car;

            return _mapper.Map<SimpleParkingViewModel>(_parkingService.AddParkingTime(parkingTime));
        }

        public ParkingBillDetailsViewModel GetFullParkingTime(int Id)
        {
            var parkingTime = _parkingService.GetFullParkingTime(Id);

            var parkingTimeViewModel = _mapper.Map<ParkingBillDetailsViewModel>(parkingTime);

            return parkingTimeViewModel;
        }

        public List<ParkingBillDetailsViewModel> GetAllParkingTimeByCar(int CarId)
        {
            var parkingTime = _parkingService.GetAllParkingTimeByCar(CarId);

            var parkingTimeViewModel = _mapper.Map<List<ParkingBillDetailsViewModel>>(parkingTime);

            return parkingTimeViewModel;
        }

        public List<ParkingBillDetailsViewModel> GetAllParkingTimeByCustomer(int CustomerId)
        {
            var parkingTime = _parkingService.GetAllParkingTimeByCustomer(CustomerId);

            var parkingTimeViewModel = _mapper.Map<List<ParkingBillDetailsViewModel>>(parkingTime);

            return parkingTimeViewModel;
        }

        #endregion

    }
}
