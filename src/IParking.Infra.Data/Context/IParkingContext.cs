using IParking.Domain.Entities;
using IParking.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IParking.Infra.Data.Context
{
    public class IParkingContext : DbContext
    {
        #region Properties
        private IConfiguration _configuration;
        #endregion

        #region DbSets
        public DbSet<Car> Car { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerType> CustomerType { get; set; }
        public DbSet<ParkingTime> ParkingTime { get; set; }
        #endregion

        public IParkingContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetSection("DevConnection").Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarMapping());
            modelBuilder.ApplyConfiguration(new CustomerMapping());
            modelBuilder.ApplyConfiguration(new CustomerTypeMapping());
            modelBuilder.ApplyConfiguration(new ParkingTimeMapping());

        }


    }
}
