using System.Collections.Generic;
using IParking.Domain.Entities;
using IParking.Domain.Interfaces.Repository;
using IParking.Domain.Interfaces.Service;

namespace IParking.Domain.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        #region Properties
        private ICustomerRepository _customerRepository;
        #endregion

        #region Ctor
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion

        #region Methods
        public Customer AddCustomer(Customer customer)
        {
            return _customerRepository.InsertNewCustomer(customer);
        }

        public Customer FindById(int id)
        {
            return _customerRepository.FindById(id);
        }

        public Customer FullCustomerById(int id)
        {
            return _customerRepository.FullCustomerById(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }
        #endregion

    }
}
