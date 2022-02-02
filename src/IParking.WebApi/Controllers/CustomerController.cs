using System.Collections.Generic;
using IParking.Application.Interfaces;
using IParking.Application.ViewModel.Customer;
using Microsoft.AspNetCore.Mvc;

namespace IParking.WebApi.Controllers
{
    /// <summary>
    /// Endpoint to Insert and Get the Customers Information
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private ICustomerApplication _customerApplication;

        public CustomerController(
            ICustomerApplication customerApplication
        )
        {
            _customerApplication = customerApplication;
        }


        /// <summary>
        /// Insert new customer
        /// </summary>
        /// <param name="FullNameOfTheCustomer">Full name of the customer</param>
        /// <param name="TypeOfTheCustomer">1 - Premium, 2 - Regular</param>
        /// <returns>Data of the new customer including the new Id</returns>
        [HttpPost]
        public FullCustomerViewModel AddNewCustomer(string FullNameOfTheCustomer, int TypeOfTheCustomer)
        {
            return _customerApplication.AddCustomer(new NewCustomerViewModel() { FullName = FullNameOfTheCustomer, CustomerTypeId = TypeOfTheCustomer });
        }


        /// <summary>
        /// Get Customer Information
        /// </summary>
        /// <param name="Id">Id of the customer</param>
        /// <returns></returns>
        [HttpGet]
        public FullCustomerViewModel FindById(int Id)
        {
            return _customerApplication.FindById(Id);
        }

        /// <summary>
        /// Get all customer in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCustomers")]
        public List<SimpleCustomerViewModel> GetAllCustomers()
        {
            return _customerApplication.GetAllCustomers();
        }


    }
}
