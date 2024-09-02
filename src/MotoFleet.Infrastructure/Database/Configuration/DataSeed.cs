using Microsoft.EntityFrameworkCore;
using MotoFleet.Domain.Plans;

namespace MotoFleet.Infrastructure.Database.Configuration;

public static class DataSeed
{
    public static void PlanDataSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plan>().HasData(
            new Plan(Guid.NewGuid(), 7,30, 20),
            new Plan(Guid.NewGuid(), 15, 28, 40),
            new Plan(Guid.NewGuid(), 30, 22, 40),
            new Plan(Guid.NewGuid(), 45, 20, 40),
            new Plan(Guid.NewGuid(), 50, 18, 40) );
    }
}
