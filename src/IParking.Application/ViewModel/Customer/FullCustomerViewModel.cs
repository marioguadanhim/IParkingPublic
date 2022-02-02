using System.Collections.Generic;
using IParking.Application.ViewModel.Car;

namespace IParking.Application.ViewModel.Customer
{
    public class FullCustomerViewModel
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string TypeDescription { get; set; }
        public List<CarViewModel> Cars { get; set; }
    }
}
