using Bussines.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.Data.Configurations;
public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.ToTable(nameof(Flight));

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id).IsRequired();

        builder.Property(f => f.Origin)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(f => f.Destination)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(f => f.Price)
               .IsRequired()
               .HasColumnType("float");

    }
}
