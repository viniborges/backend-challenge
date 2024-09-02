using Microsoft.EntityFrameworkCore;
using MotoFleet.Application.Abstractions.Rental;
using MotoFleet.Domain.Plans;
using MotoFleet.Domain.Rentals;
using MotoFleet.Infrastructure.Database;
using MotoFleet.SharedKernel;

namespace MotoFleet.Infrastructure.Repository;

public class RentalRepository(ApplicationDbContext context) : IRentalRepository
{
    public async Task<Result<Rental>> AddAsync(Rental rental, CancellationToken cancellationToken)
    {
        context.Rentals.Add(rental);
        await context.SaveChangesAsync(cancellationToken);

        return Result<Rental>.Success(rental);
    }

    public async Task<Result<Plan>> GetPlanByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var plan = await context.Plans
            .Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);

        return plan is null
            ? Result<Plan>.Failure(PlanErros.NotFound(id))
            : Result<Plan>.Success(plan);
    }

    public async Task<Result<Rental>> GetRentalById(Guid id, CancellationToken cancellationToken)
    {
        var rental = await context.Rentals
            .Where(r => r.Id == id).FirstOrDefaultAsync(cancellationToken);

        return rental is null
            ? Result<Rental>.Failure(RentalErros.NotFound(id))
            : Result<Rental>.Success(rental);
    }

    public async Task<Result<Rental>> UpdateDevolutionAsync(Guid id, DateTime dataDevolucao, decimal calculatedPrice,
        CancellationToken cancellationToken)
    {
        await context.Rentals
            .Where(r => r.Id == id)
            .ExecuteUpdateAsync(x => x
                    .SetProperty(r => r.EndDate, dataDevolucao)
                    .SetProperty(r => r.IsReturned, true)
                    .SetProperty(r => r.CalculatedPrice, calculatedPrice)
                , cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        var rental = await context.Rentals
            .Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);

        return rental is null
            ? Result<Rental>.Failure(PlanErros.NotFound(id))
            : Result<Rental>.Success(rental);
    }
}
