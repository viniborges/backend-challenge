using MotoFleet.Application.Abstractions.Rental;
using MotoFleet.Application.DTOs.Rentals;
using MotoFleet.Domain.Rentals;
using MotoFleet.SharedKernel;

namespace MotoFleet.Application.UseCases.Rentals;

public class GetByIdRental(IRentalRepository repository)
{
    public async Task<Result<RentalResponseDto>> Handle(Guid id, CancellationToken cancellationToken)
    {
        var result = await repository.GetRentalById(id, cancellationToken);
        
        var plan = await repository.GetPlanByIdAsync(result.Data.PlanId, cancellationToken);

        if (!plan.IsSuccess)
        {
            return Result<RentalResponseDto>.Failure(plan.ErrorMessage);
        }

        var responseDto = new RentalResponseDto
        (
            result.Data.Id,
            result.Data.DeliveryPersonId,
            result.Data.MotorcycleId,
            result.Data.PlanId,
            result.Data.StartDate,
            result.Data.ExpectedEndDate,
            plan.Data.Price,
            result.Data.IsReturned
        );
        
        if (result is { IsSuccess: true, Data.IsReturned: true })
        {
            responseDto.DataDevolucao = result.Data.EndDate;
            responseDto.ValorTotal = result.Data.CalculatedPrice;
            responseDto.QuantidadeDiasLocacao =  (result.Data.EndDate! - result.Data.StartDate).Value.Days;
        }
        
        return result.IsSuccess
            ? Result<RentalResponseDto>.Failure(result.ErrorMessage)
            : Result<RentalResponseDto>.Success(responseDto);
    }
}
