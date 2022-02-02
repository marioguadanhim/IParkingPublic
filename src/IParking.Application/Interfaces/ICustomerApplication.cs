using System.Collections.Generic;
using IParking.Application.ViewModel.Customer;

namespace IParking.Application.Interfaces
{
    public interface ICustomerApplication
    {
        FullCustomerViewModel AddCustomer(NewCustomerViewModel newCustomer);
        FullCustomerViewModel FindById(int Id);
        List<SimpleCustomerViewModel> GetAllCustomers();
    }
}