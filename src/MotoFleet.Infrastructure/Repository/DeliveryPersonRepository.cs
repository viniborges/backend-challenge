using MotoFleet.Application.Abstractions.DeliveryPerson;
using MotoFleet.Domain.DeliveryPersons;
using MotoFleet.Infrastructure.Database;
using MotoFleet.SharedKernel;

namespace MotoFleet.Infrastructure.Repository;

public class DeliveryPersonRepository(ApplicationDbContext context) : IDeliveryPersonRepository
{
    public async Task<Result<DeliveryPerson>> AddAsync(DeliveryPerson deliveryPerson, CancellationToken cancellationToken)
    {
        context.DeliveryPersons.Add(deliveryPerson);
        await context.SaveChangesAsync(cancellationToken);
        
        return Result<DeliveryPerson>.Success(deliveryPerson);
    }
}
