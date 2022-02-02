using System.Linq;
using IParking.Domain.Entities;
using IParking.Domain.Interfaces.Repository;
using IParking.Infra.Data.Context;
using IParking.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IParking.Infra.Data.Repository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private IUnitOfWork _unitOfWork;

        public CarRepository(IParkingContext context, IUnitOfWork unitOfWork)
            : base(context)
        {
            _unitOfWork = unitOfWork;
        }


        public Car FullCarById(int Id)
        {
            return DbSet.Where(_ => _.CarId == Id)
                  .Include(_ => _.Customer)
                  .Include(_ => _.Customer.CustomerType)
                  .FirstOrDefault();
        }

        public Car InsertNewCar(Car car)
        {
            car.ParkingTime = null;
            car.Customer = null;
            _unitOfWork.BeginTransaction();
            car = Insert(car);
            _unitOfWork.Commit();
            return car;
        }

    }
}
