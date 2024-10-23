using Bussines.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Data.Configurations;
public class TransportConfiguration : IEntityTypeConfiguration<Transport>
{
    public void Configure(EntityTypeBuilder<Transport> builder)
    {
        builder.ToTable(nameof(Transport));

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
                .IsRequired();

        builder.Property(t => t.FlightCarrier)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(t => t.FlightNumber)
               .IsRequired();

    }
}
