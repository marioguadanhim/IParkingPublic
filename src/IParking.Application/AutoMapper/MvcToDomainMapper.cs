using AutoMapper;
using IParking.Application.ViewModel.Car;
using IParking.Application.ViewModel.Customer;
using IParking.Application.ViewModel.Parking;
using IParking.Domain.Entities;

namespace IParking.Application.AutoMapper
{
    public class MvcToDomainMapper : Profile
    {
        public MvcToDomainMapper()
        {
            CreateMap<NewParkingBillViewModel, ParkingTime>();
            CreateMap<NewCustomerViewModel, Customer>();
            CreateMap<NewCarViewModel, Car>();
        }
    }
}
