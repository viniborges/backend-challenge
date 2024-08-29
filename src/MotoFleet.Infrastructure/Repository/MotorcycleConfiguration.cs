using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoFleet.Domain.Motorcycles;

namespace MotoFleet.Infrastructure.Repository;

internal sealed class MotorcycleConfiguration : IEntityTypeConfiguration<Motorcycle>
{
    public void Configure(EntityTypeBuilder<Motorcycle> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Plate).IsUnique();
    }
}
