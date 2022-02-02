using System.Collections.Generic;

namespace IParking.Domain.Entities
{
    public class CustomerType
    {
        public CustomerType()
        {
            Customers = new HashSet<Customer>();
        }

        public int CustomerTypeId { get; set; }
        public string TypeDescription { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }

    public enum EnumCustomerType
    {
        Premium = 1,
        Regular = 2
    }
}
