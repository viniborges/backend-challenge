using MotoFleet.SharedKernel;

namespace MotoFleet.Application.Abstractions.DeliveryPerson;

public interface IDeliveryPersonRepository
{
    Task<Result<Domain.DeliveryPersons.DeliveryPerson>> AddAsync(Domain.DeliveryPersons.DeliveryPerson deliveryPerson, CancellationToken cancellationToken);
}
