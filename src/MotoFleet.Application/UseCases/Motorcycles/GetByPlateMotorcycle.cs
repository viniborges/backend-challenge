using MotoFleet.Application.Abstractions.Motorcycle;
using MotoFleet.Application.DTOs.Motorcycles;
using MotoFleet.Domain.Motorcycles;
using MotoFleet.SharedKernel;

namespace MotoFleet.Application.UseCases.Motorcycles;

public class GetByPlateMotorcycle(IMotorcycleRepository repository)
{
    public async Task<Result<IEnumerable<MotorcycleResponseDto>>> Handle(string? placa, CancellationToken cancellationToken)
    {
        var result = !string.IsNullOrEmpty(placa)
            ? await repository.GetByPlate(placa, cancellationToken)
            : await repository.GetAll(cancellationToken);

        var response = result.Data.Select(MotorcycleResponseDto.ToDto);
        
        return Result<IEnumerable<MotorcycleResponseDto>>.Success(response);
    }
}
