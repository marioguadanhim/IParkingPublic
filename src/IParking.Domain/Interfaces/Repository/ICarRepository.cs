using IParking.Domain.Entities;
using IParking.Domain.Interfaces.Base;

namespace IParking.Domain.Interfaces.Repository
{
    public interface ICarRepository : IRepository<Car>
    {
        Car FullCarById(int id);
        Car InsertNewCar(Car car);
    }
}