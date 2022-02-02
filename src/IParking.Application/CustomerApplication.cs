using System.Collections.Generic;
using AutoMapper;
using IParking.Application.Interfaces;
using IParking.Application.ViewModel.Customer;
using IParking.Domain.Entities;
using IParking.Domain.Interfaces.Service;

namespace IParking.Application
{
    public class CustomerApplication : ICustomerApplication
    {
        #region Properties
        private ICustomerService _customerService;
        private IMapper _mapper;
        #endregion

        #region Ctor
        public CustomerApplication(
            ICustomerService customerService,
            IMapper mapper
            )
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public FullCustomerViewModel AddCustomer(NewCustomerViewModel newCustomer)
        {
            var customer = _mapper.Map<Customer>(newCustomer);
            customer =  _customerService.AddCustomer(customer);
            var fullCustomer = _mapper.Map<FullCustomerViewModel>(customer);
            return fullCustomer;
        }

        public FullCustomerViewModel FindById(int Id)
        {
            var customer = _customerService.FullCustomerById(Id);
            var fullCustomer = _mapper.Map<FullCustomerViewModel>(customer);
            return fullCustomer;
        }

        public List<SimpleCustomerViewModel> GetAllCustomers()
        {
            var allCustomer = _customerService.GetAllCustomers();
            var simpleCustomer = _mapper.Map<List<SimpleCustomerViewModel>>(allCustomer);
            return simpleCustomer;
        }
        #endregion

    }
}
