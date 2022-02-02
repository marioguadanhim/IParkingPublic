using IParking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IParking.Infra.Data.EntityConfig
{
    public class CarMapping : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(_ => _.CarId);

            builder.HasOne(_ => _.Customer)
                .WithMany(_ => _.Cars)
                .HasForeignKey(_ => _.CustomerId);

            builder.Property(_ => _.Plate).IsRequired();

            builder.ToTable("Car");
        }
    }
}
