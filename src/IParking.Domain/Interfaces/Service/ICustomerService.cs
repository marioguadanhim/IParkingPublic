using System.Collections.Generic;
using IParking.Domain.Entities;

namespace IParking.Domain.Interfaces.Service
{
    public interface ICustomerService
    {
        Customer AddCustomer(Customer customer);
        Customer FindById(int id);
        Customer FullCustomerById(int id);
        List<Customer> GetAllCustomers();
    }
}