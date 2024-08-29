using MotoFleet.Application.Abstractions.Motorcycle;
using MotoFleet.Application.DTOs.Motorcycles;
using MotoFleet.SharedKernel;

namespace MotoFleet.Application.UseCases.Motorcycles;

public class GetByIdMotorcycle(IMotorcycleRepository repository)
{
    public async Task<Result<MotorcycleResponseDto>> Handle(Guid id, CancellationToken cancellationToken)
    {
        var result = await repository.GetById(id, cancellationToken);

        return result.IsSuccess
            ? Result<MotorcycleResponseDto>.Success(MotorcycleResponseDto.ToDto(result.Data))
            : Result<MotorcycleResponseDto>.Failure(result.ErrorMessage);
    }
}
