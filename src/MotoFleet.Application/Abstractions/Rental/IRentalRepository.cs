using MotoFleet.Domain.Plans;
using MotoFleet.SharedKernel;

namespace MotoFleet.Application.Abstractions.Rental;

public interface IRentalRepository
{
    Task<Result<Domain.Rentals.Rental>> AddAsync(Domain.Rentals.Rental rental, CancellationToken cancellationToken);
    Task<Result<Plan>> GetPlanByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Result<Domain.Rentals.Rental>> GetRentalById(Guid id, CancellationToken cancellationToken);

    Task<Result<Domain.Rentals.Rental>> UpdateDevolutionAsync(Guid id, DateTime dataDevolucao, decimal calculatedPrice,
        CancellationToken cancellationToken);
}
