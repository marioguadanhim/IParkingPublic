using AutoMapper;
using IParking.Application.ViewModel.Car;
using IParking.Application.ViewModel.Customer;
using IParking.Application.ViewModel.Invoice;
using IParking.Application.ViewModel.Parking;
using IParking.Domain.Entities;
using IParking.Domain.ValueObjects;

namespace IParking.Application.AutoMapper
{
    public class DomainToMvcMapper : Profile
    {
        public DomainToMvcMapper()
        {
            CreateMap<Customer, FullCustomerViewModel>()
                .ForMember(_ => _.TypeDescription, from => from.MapFrom(prop => prop.CustomerType.TypeDescription));

            CreateMap<Car, CarViewModel>();

            CreateMap<ParkingTime, ParkingBillDetailsViewModel>()
            .ForMember(_ => _.Model, from => from.MapFrom(prop => prop.Car.Model))
            .ForMember(_ => _.Plate, from => from.MapFrom(prop => prop.Car.Plate))
            .ForMember(_ => _.FullName, from => from.MapFrom(prop => prop.Car.Customer.FullName))
            .ForMember(_ => _.TypeDescription, from => from.MapFrom(prop => prop.Car.Customer.CustomerType.TypeDescription));

            CreateMap<ParkingTime, ParkingBillViewModel>()
           .ForMember(_ => _.Model, from => from.MapFrom(prop => prop.Car.Model))
           .ForMember(_ => _.Plate, from => from.MapFrom(prop => prop.Car.Plate));

            CreateMap<CustomerMonthlyInvoiceVo, MonthlyInvoiceViewModel>()
                            .ForMember(_ => _.FullName, from => from.MapFrom(prop => prop.Customer.FullName))
                            .ForMember(_ => _.TypeDescription, from => from.MapFrom(prop => prop.Customer.CustomerType.TypeDescription))
                             .ForMember(_ => _.ParkingTime, from => from.MapFrom(prop => prop.ParkingTimes));

            CreateMap<Car, CarDetailsViewModel>();

            CreateMap<Car, FullCarViewModel>()
                .ForMember(_ => _.CustomerId, from => from.MapFrom(prop => prop.Customer.CustomerId))
                .ForMember(_ => _.FullName, from => from.MapFrom(prop => prop.Customer.FullName))
                .ForMember(_ => _.TypeDescription, from => from.MapFrom(prop => prop.Customer.CustomerType.TypeDescription));

            CreateMap<Customer, SimpleCustomerViewModel>();
            CreateMap<ParkingTime, SimpleParkingViewModel>();

        }
    }
}
