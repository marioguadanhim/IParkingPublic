using IParking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IParking.Infra.Data.EntityConfig
{
    public class ParkingTimeMapping : IEntityTypeConfiguration<ParkingTime>
    {
        public void Configure(EntityTypeBuilder<ParkingTime> builder)
        {
            builder.HasKey(_ => _.ParkingTimeId);

            builder.HasOne(_ => _.Car)
               .WithMany(_ => _.ParkingTime)
               .HasForeignKey(_ => _.CarId);

            builder.ToTable("ParkingTime");

        }
    }
}
