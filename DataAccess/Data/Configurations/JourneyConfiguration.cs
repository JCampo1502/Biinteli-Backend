using Bussines.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.Data.Configurations;
public class JourneyConfiguration : IEntityTypeConfiguration<Journey>
{
    public void Configure(EntityTypeBuilder<Journey> builder)
    {
        builder.ToTable(nameof(Journey));

        builder.HasKey(j => j.Id);

        builder.Property(j => j.Id)
              .IsRequired();

        builder.Property(j => j.Origin)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(j => j.Destination)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(j => j.Price)
               .IsRequired()
               .HasColumnType("float");
    }
}
