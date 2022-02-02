using IParking.Domain.Entities;

namespace IParking.Domain.Interfaces.Service
{
    public interface ICarService
    {
        Car FullCarById(int id);
        Car AddCar(Car newCar);
    }
}