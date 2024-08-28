using Microsoft.EntityFrameworkCore;
using MotoFleet.Application.Abstractions.Motorcycles;
using MotoFleet.Domain.Motorcycles;
using MotoFleet.Infrastructure.Database;
using MotoFleet.SharedKernel;

namespace MotoFleet.Infrastructure.Repository;

public class MotorcycleRepository(ApplicationDbContext context) : IMotorcycleRepository
{
    public async Task<Result<Motorcycle>> AddAsync(Motorcycle motorcycle, CancellationToken cancellationToken)
    {
        context.Motorcycles.Add(motorcycle);
        await context.SaveChangesAsync(cancellationToken);
        
        return Result<Motorcycle>.Success(motorcycle);
    }
}
