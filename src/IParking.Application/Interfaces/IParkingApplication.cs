using System.Collections.Generic;
using IParking.Application.ViewModel.Parking;

namespace IParking.Application.Interfaces
{
    public interface IParkingApplication
    {
        SimpleParkingViewModel AddParkingTime(NewParkingBillViewModel newParkingBillViewModel);
        ParkingBillDetailsViewModel GetFullParkingTime(int Id);
        List<ParkingBillDetailsViewModel> GetAllParkingTimeByCar(int CarId);
        List<ParkingBillDetailsViewModel> GetAllParkingTimeByCustomer(int CustomerId);
    }
}