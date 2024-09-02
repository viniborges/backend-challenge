using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoFleet.Domain.DeliveryPersons;

namespace MotoFleet.Infrastructure.Database.Configuration;

internal sealed class DeliveryPersonConfiguration :IEntityTypeConfiguration<DeliveryPerson>
{
    public void Configure(EntityTypeBuilder<DeliveryPerson> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.CnpjCpf).IsUnique();
        builder.HasIndex(u => u.Cnh).IsUnique();
    }
}
