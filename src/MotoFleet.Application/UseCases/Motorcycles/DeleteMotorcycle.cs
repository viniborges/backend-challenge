using MotoFleet.Application.Abstractions.Motorcycle;
using MotoFleet.SharedKernel;

namespace MotoFleet.Application.UseCases.Motorcycles;

public class DeleteMotorcycle(IMotorcycleRepository repository)
{
    public async Task<Result<string>> Handle(Guid id, CancellationToken cancellationToken)
    {
        var result = await repository.DeleteAsync(id, cancellationToken);

        return result > 0 
            ? Result<string>.Success("Moto removida com sucesso") 
            : Result<string>.Failure("Dados inválidos");
    }
}
