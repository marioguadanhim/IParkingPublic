using System.Collections.Generic;
using System.Linq;
using Dapper;
using IParking.Domain.Entities;
using IParking.Domain.Interfaces.Repository;
using IParking.Infra.Data.Context;
using IParking.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IParking.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private IUnitOfWork _unitOfWork;

        public CustomerRepository(IParkingContext context, IUnitOfWork unitOfWork)
            : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public Customer FullCustomerById(int Id)
        {
            return DbSet.Where(_ => _.CustomerId == Id)
                .Include(_ => _.Cars)
                .Include(_ => _.CustomerType).FirstOrDefault();
        }

        public Customer InsertNewCustomer(Customer customer)
        {
            customer.Cars = null;
            customer.CustomerType = null;
            _unitOfWork.BeginTransaction();
            customer = Insert(customer);
            _unitOfWork.Commit();
            return customer;
        }

        public List<Customer> GetAllCustomers()
        {
            using (var conn = Db.Database.GetDbConnection())
            {
                return conn.Query<Customer>("SELECT CustomerId, FullName FROM Customer").ToList();
            }
        }

    }
}
