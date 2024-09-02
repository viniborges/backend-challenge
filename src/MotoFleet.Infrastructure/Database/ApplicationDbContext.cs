using Microsoft.EntityFrameworkCore;
using MotoFleet.Domain.DeliveryPersons;
using MotoFleet.Domain.Motorcycles;
using MotoFleet.Domain.Plans;
using MotoFleet.Domain.Rentals;
using MotoFleet.Infrastructure.Database.Configuration;

namespace MotoFleet.Infrastructure.Database;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Motorcycle> Motorcycles { get; set; }
    public DbSet<DeliveryPerson> DeliveryPersons { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.HasDefaultSchema(Schemas.Default);
        
        modelBuilder.PlanDataSeed();
    }
}
