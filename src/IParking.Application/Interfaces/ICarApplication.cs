using IParking.Application.ViewModel.Car;

namespace IParking.Application.Interfaces
{
    public interface ICarApplication
    {
        CarDetailsViewModel AddCar(NewCarViewModel newCar);
        FullCarViewModel FindById(int CarId);
    }
}