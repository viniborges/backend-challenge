using MotoFleet.Application.Abstractions.Motorcycle;
using MotoFleet.Application.DTOs.Motorcycles;
using MotoFleet.Domain.Motorcycles;
using MotoFleet.SharedKernel;

namespace MotoFleet.Application.UseCases.Motorcycles;

public class CreateMotorcycle(IMotorcycleRepository repository, IDateTimeProvider dateTimeProvider)
{
    public async Task<Result<Motorcycle>> Handle(CreateMotorcycleRequestDto requestDto, CancellationToken cancellationToken)
    {
        var existentMotorcycle = await repository.GetByPlate(requestDto.Placa, cancellationToken);
        
        if (existentMotorcycle.Data.Any())
        {
            return Result<Motorcycle>.Failure(MotorcycleErrors.PlateNotUnique(requestDto.Placa));
        }

        var motorcycle = requestDto.CreatedAt(dateTimeProvider.UtcNow).ToEntity();
        
        var result = await repository.AddAsync(motorcycle, cancellationToken);
        Console.WriteLine(result);
        return Result<Motorcycle>.Success(motorcycle);
    }
    
}
