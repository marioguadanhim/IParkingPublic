using System.Collections.Generic;
using IParking.Domain.Entities;

namespace IParking.Domain.Interfaces.Service
{
    public interface IParkingService
    {
        ParkingTime AddParkingTime(ParkingTime parkingTime);
        ParkingTime GetFullParkingTime(int id);
        List<ParkingTime> GetAllParkingTimeByCar(int carId);
        List<ParkingTime> GetAllParkingTimeByCustomer(int customerId);
    }
}