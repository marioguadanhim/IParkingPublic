using System.Collections.Generic;
using IParking.Domain.Entities;
using IParking.Domain.Interfaces.Base;

namespace IParking.Domain.Interfaces.Repository
{
    public interface IParkingTimeRepository : IRepository<ParkingTime>
    {
        ParkingTime InsertNewParkingTime(ParkingTime parkingTime);
        ParkingTime GetFullParkingTime(int id);
        List<ParkingTime> GetMonthlyParkingTimeOfCustomer(int customerId, int month, int year);
        List<ParkingTime> GetAllParkingTimeByCar(int carId);
        List<ParkingTime> GetAllParkingTimeByCustomer(int customerId);
    }
}
