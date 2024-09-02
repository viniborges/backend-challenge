using MotoFleet.Application.Abstractions.Rental;
using MotoFleet.Application.DTOs.Rentals;
using MotoFleet.SharedKernel;

namespace MotoFleet.Application.UseCases.Rentals;

public class UpdateDevolutionRental(IRentalRepository repository)
{
    public async Task<Result<RentalResponseDto>> Handle(Guid id, UpdateRentalDevolutionRequestDto input, CancellationToken cancellationToken)
    {
        var rental = await repository.GetRentalById(id, cancellationToken);
        
        var plan = await repository.GetPlanByIdAsync(rental.Data.PlanId, cancellationToken);

        if (!plan.IsSuccess)
        {
            return Result<RentalResponseDto>.Failure(plan.ErrorMessage);
        }
        
        var finalPrice = rental.Data.CalculateRentalPrice(plan);
        
        var result = await repository.UpdateDevolutionAsync(id, input.dataDevolucao, finalPrice, cancellationToken);
        
        var responseDto = new RentalResponseDto
        (
            result.Data.Id,
            result.Data.DeliveryPersonId,
            result.Data.MotorcycleId,
            result.Data.PlanId,
            result.Data.StartDate,
            result.Data.EndDate,
            result.Data.ExpectedEndDate,
            plan.Data.Price,
            result.Data.IsReturned,
            result.Data.CalculatedPrice,
            (result.Data.EndDate! - result.Data.StartDate).Value.Days
        );
        
        return result.IsSuccess
            ? Result<RentalResponseDto>.Success(responseDto)
            : Result<RentalResponseDto>.Failure(result.ErrorMessage);
    }
}
