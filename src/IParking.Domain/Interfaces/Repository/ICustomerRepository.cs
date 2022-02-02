using System.Collections.Generic;
using IParking.Domain.Entities;
using IParking.Domain.Interfaces.Base;

namespace IParking.Domain.Interfaces.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer FullCustomerById(int id);
        Customer InsertNewCustomer(Customer customer);
        List<Customer> GetAllCustomers();
    }
}
