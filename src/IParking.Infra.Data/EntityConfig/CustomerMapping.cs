using IParking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IParking.Infra.Data.EntityConfig
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(_ => _.CustomerId);

            builder.HasMany(_ => _.Cars)
                .WithOne(_ => _.Customer)
                .HasForeignKey(_ => _.CustomerId);

            builder.Property(_ => _.FullName).IsRequired();

            builder.ToTable("Customer");
        }
    }
}
