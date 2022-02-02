using AutoMapper;
using IParking.Application;
using IParking.Application.Interfaces;
using IParking.Domain.Factory;
using IParking.Domain.Interfaces.Factory;
using IParking.Domain.Interfaces.Repository;
using IParking.Domain.Interfaces.Service;
using IParking.Domain.Services.Cars;
using IParking.Domain.Services.Customers;
using IParking.Domain.Services.Invoice;
using IParking.Domain.Services.Parking;
using IParking.Infra.Data.Context;
using IParking.Infra.Data.Interfaces;
using IParking.Infra.Data.Repository;
using IParking.Infra.Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace IParking.Infra.CrossCutting.IoC
{
    public class IParkingContainer
    {
        public static ServiceProvider Register(IServiceCollection services)
        {
            services.AddAutoMapper();

            #region Application
            services.AddScoped(typeof(ICustomerApplication), typeof(CustomerApplication));
            services.AddScoped(typeof(IParkingApplication), typeof(ParkingApplication));
            services.AddScoped(typeof(IInvoiceApplication), typeof(InvoiceApplication));
            services.AddScoped(typeof(ICarApplication), typeof(CarApplication));
            #endregion

            #region Domain
            services.AddScoped(typeof(ICustomerService), typeof(CustomerService));
            services.AddScoped(typeof(IParkingCalculatorFactory), typeof(ParkingCalculatorFactory));
            services.AddScoped(typeof(ICarService), typeof(CarService));
            services.AddScoped(typeof(IParkingService), typeof(ParkingService));
            services.AddScoped(typeof(IInvoiceCalculatorFactory), typeof(InvoiceCalculatorFactory));
            services.AddScoped(typeof(IInvoiceService), typeof(InvoiceService));
            #endregion

            #region Infra
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
            services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
            services.AddScoped(typeof(IParkingTimeRepository), typeof(ParkingTimeRepository));

            services.AddScoped(typeof(IParkingContext));
            #endregion

            return services.BuildServiceProvider();
        }

    }
}
