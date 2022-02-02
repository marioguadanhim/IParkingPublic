using System;
using System.Collections.Generic;
using System.Linq;
using IParking.Domain.Entities;
using IParking.Domain.Interfaces.Repository;
using IParking.Infra.Data.Context;
using IParking.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IParking.Infra.Data.Repository
{
    public class ParkingTimeRepository : Repository<ParkingTime>, IParkingTimeRepository
    {
        private IUnitOfWork _unitOfWork;

        public ParkingTimeRepository(IParkingContext context, IUnitOfWork unitOfWork)
            : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public ParkingTime InsertNewParkingTime(ParkingTime parkingTime)
        {
            parkingTime.Car = null;
            _unitOfWork.BeginTransaction();
            parkingTime = Insert(parkingTime);
            _unitOfWork.Commit();
            return parkingTime;
        }

        public ParkingTime GetFullParkingTime(int Id)
        {
            return DbSet.Where(_ => _.ParkingTimeId == Id)
             .Include(_ => _.Car)
             .Include(_ => _.Car.Customer)
             .Include(_ => _.Car.Customer.CustomerType)
             .FirstOrDefault();
        }

        public List<ParkingTime> GetAllParkingTimeByCustomer(int CustomerId)
        {
            return DbSet.Where(_ => _.Car.CustomerId == CustomerId)
             .Include(_ => _.Car)
             .Include(_ => _.Car.Customer)
             .Include(_ => _.Car.Customer.CustomerType)
             .ToList();
        }

        public List<ParkingTime> GetAllParkingTimeByCar(int CarId)
        {
            return DbSet.Where(_ => _.CarId == CarId)
             .Include(_ => _.Car)
             .Include(_ => _.Car.Customer)
             .Include(_ => _.Car.Customer.CustomerType)
             .ToList();
        }

        public List<ParkingTime> GetMonthlyParkingTimeOfCustomer(int CustomerId, int Month, int Year)
        {
            DateTime startMonth = new DateTime(Year, Month, 1);
            DateTime endMonth = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));

            return DbSet.Where(_ =>
            _.Car.CustomerId == CustomerId
            &&
            _.StartTime >= startMonth
            &&
            _.EndTime <= endMonth
            )
             .Include(_ => _.Car)
             .ToList();
        }

    }
}
