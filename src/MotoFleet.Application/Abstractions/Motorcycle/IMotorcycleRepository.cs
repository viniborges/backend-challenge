using MotoFleet.Domain.Motorcycles;
using MotoFleet.SharedKernel;

namespace MotoFleet.Application.Abstractions.Motorcycles;

public interface IMotorcycleRepository
{
    Task<Result<Motorcycle>> AddAsync(Motorcycle motorcycle, CancellationToken cancellationToken);
}
