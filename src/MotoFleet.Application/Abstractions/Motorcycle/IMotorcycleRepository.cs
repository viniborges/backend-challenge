using MotoFleet.SharedKernel;

namespace MotoFleet.Application.Abstractions.Motorcycle;

public interface IMotorcycleRepository
{
    Task<Result<Domain.Motorcycles.Motorcycle>> AddAsync(Domain.Motorcycles.Motorcycle motorcycle, CancellationToken cancellationToken);
    Task<Result<List<Domain.Motorcycles.Motorcycle>>> GetByPlate(string? plate, CancellationToken cancellationToken);
    Task<Result<List<Domain.Motorcycles.Motorcycle>>> GetAll(CancellationToken cancellationToken);
    Task<Result<Domain.Motorcycles.Motorcycle>> GetById(Guid id, CancellationToken cancellationToken);
    Task<int> UpdatePlateAsync(Guid id, string plate, CancellationToken cancellationToken);
    Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken);
}
