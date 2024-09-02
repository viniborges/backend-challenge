using MotoFleet.Application.Abstractions.Motorcycle;
using MotoFleet.Application.DTOs.Motorcycles;
using MotoFleet.Domain.Motorcycles;
using MotoFleet.SharedKernel;

namespace MotoFleet.Application.UseCases.Motorcycles;

public class UpdatePlateMotorcycle(IMotorcycleRepository repository)
{
    public async Task<Result<string>> Handle(Guid id, string placa, CancellationToken cancellationToken)
    {
        var result = await repository.UpdatePlateAsync(id, placa, cancellationToken);

        return result > 0 
            ? Result<string>.Success("Placa modificada com sucesso") 
            : Result<string>.Failure("Dados inválidos");
    }
}
