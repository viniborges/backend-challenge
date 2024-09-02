using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoFleet.Domain.Plans;

namespace MotoFleet.Infrastructure.Database.Configuration;

internal sealed class PlanConfiguration : IEntityTypeConfiguration<Plan>   
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.HasKey(u => u.Id);
    }
}
