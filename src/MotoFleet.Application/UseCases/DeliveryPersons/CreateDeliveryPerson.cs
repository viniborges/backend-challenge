using MotoFleet.Application.Abstractions.DeliveryPerson;
using MotoFleet.Application.DTOs.DeliveryPersons;
using MotoFleet.SharedKernel;

namespace MotoFleet.Application.UseCases.DeliveryPersons;

public class CreateDeliveryPerson(IDeliveryPersonRepository repository, IDateTimeProvider dateTimeProvider)
{
    public async Task<Result<DeliveryPersonResponseDto>> Handle(CreateDeliveryPersonRequestDto requestDto,
        CancellationToken cancellationToken)
    {
        var deliveryPerson = requestDto.CreatedAt(dateTimeProvider.UtcNow).ToEntity();
        var result = await repository.AddAsync(deliveryPerson, cancellationToken);
        var dto = DeliveryPersonResponseDto.ToDto(result.Data);
        return Result<DeliveryPersonResponseDto>.Success(dto);
    }
}
