using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoFleet.Domain.DeliveryPersons;
using MotoFleet.Domain.Motorcycles;
using MotoFleet.Domain.Plans;
using MotoFleet.Domain.Rentals;

namespace MotoFleet.Infrastructure.Database.Configuration;

public class RentalConfiguration :IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasOne<Motorcycle>().WithMany().HasForeignKey(u => u.MotorcycleId);
        builder.HasOne<DeliveryPerson>().WithMany().HasForeignKey(u => u.DeliveryPersonId);
        builder.HasOne<Plan>().WithMany().HasForeignKey(u => u.PlanId);
    }
}
