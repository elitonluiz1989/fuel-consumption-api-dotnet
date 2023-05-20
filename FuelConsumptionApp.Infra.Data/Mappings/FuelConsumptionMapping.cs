using FuelConsumptionApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelConsumptionApp.Infra.Data.Mappings
{
    internal class FuelConsumptionMapping : IEntityTypeConfiguration<FuelConsumption>
    {
        public static void Confingure(EntityTypeBuilder<FuelConsumption> builder)
        {
            var instance = new FuelConsumptionMapping();
            instance.Configure(builder);
        }

        public void Configure(EntityTypeBuilder<FuelConsumption> builder)
        {
            builder.HasKey(p => p.SerialNumber);
            builder.Property(p => p.Capacity)
                .IsRequired();
            builder.Property (p => p.Owner)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Ignore(p => p.IsRecorded);
        }
    }
}
