using Microsoft.EntityFrameworkCore;
using MotoFleet.Application.Abstractions.Motorcycle;
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

    public async Task<Result<List<Motorcycle>>> GetByPlate(string? plate, CancellationToken cancellationToken)
    {
        var result = await context.Motorcycles
            .Where(m => m.Plate == plate)
            .ToListAsync(cancellationToken);

        return Result<List<Motorcycle>>.Success(result);
    }

    public async Task<Result<List<Motorcycle>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await context.Motorcycles
            .ToListAsync(cancellationToken);
        return Result<List<Motorcycle>>.Success(result);
    }

    public async Task<Result<Motorcycle>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await context.Motorcycles
            .Where(m => m.Id == id)
            .SingleOrDefaultAsync(cancellationToken);

        return result is null 
            ? Result<Motorcycle>.Failure(MotorcycleErrors.NotFound(id)) 
            : Result<Motorcycle>.Success(result);
    }

    public async Task<int> UpdatePlateAsync(Guid id, string plate, CancellationToken cancellationToken)
    {
        var result = await context.Motorcycles
            .Where(m => m.Id == id)
            .ExecuteUpdateAsync(x =>
                x.SetProperty(m => m.Plate, plate), cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return result;
    }
    
    public async Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await context.Motorcycles
            .Where(m => m.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);

        return result;
    }
    
    
}
