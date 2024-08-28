using MotoFleet.Application.Abstractions.Motorcycles;
using MotoFleet.Domain.Motorcycles;
using MotoFleet.SharedKernel;

namespace MotoFleet.Application.UseCases.Motorcycles;

public record CreateMotorcycleRequest(string Identificador, ushort Ano, string Modelo, string Placa);

public class CreateMotorcycle(IMotorcycleRepository repository, IDateTimeProvider dateTimeProvider)
{
   

    public async Task<Result<string>> Create(CreateMotorcycleRequest request, CancellationToken cancellationToken)
    {
        var motorcycle = new Motorcycle(
            Guid.NewGuid(), 
            request.Identificador, 
            request.Ano, 
            request.Modelo, 
            request.Placa,
            dateTimeProvider.UtcNow);
        
        await repository.AddAsync(motorcycle, cancellationToken);
        
        return Result<string>.Success(motorcycle.Id.ToString());
    }
    
}
