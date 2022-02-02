using IParking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IParking.Infra.Data.EntityConfig
{
    public class CustomerTypeMapping : IEntityTypeConfiguration<CustomerType>
    {
        public void Configure(EntityTypeBuilder<CustomerType> builder)
        {
            builder.HasKey(_ => _.CustomerTypeId);

            builder.HasMany(_ => _.Customers)
                .WithOne(_ => _.CustomerType)
                .HasForeignKey(_ => _.CustomerTypeId);

            builder.Property(_ => _.TypeDescription).IsRequired();

            builder.ToTable("CustomerType");
        }
    }
}
