using System.Collections.Generic;

namespace IParking.Domain.Entities
{
    public class Customer
    {
        public Customer()
        {
            Cars = new HashSet<Car>();
        }

        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public int CustomerTypeId { get; set; }

        public virtual CustomerType CustomerType { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
