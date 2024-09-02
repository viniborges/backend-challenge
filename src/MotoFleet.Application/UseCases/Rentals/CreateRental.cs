using MotoFleet.Application.Abstractions.Rental;
using MotoFleet.Application.DTOs.Rentals;
using MotoFleet.Domain.Plans;
using MotoFleet.Domain.Rentals;
using MotoFleet.SharedKernel;

namespace MotoFleet.Application.UseCases.Rentals;

public class CreateRental(IRentalRepository repository, IDateTimeProvider dateTimeProvider)
{
    public async Task<Result<RentalResponseDto>> Handle(CreateRentalRequestDto requestDto,
        CancellationToken cancellationToken)
    {
        var plan = await repository.GetPlanByIdAsync(requestDto.plano_id, cancellationToken);

        if (!plan.IsSuccess)
        {
            return Result<RentalResponseDto>.Failure(plan.ErrorMessage);
        }

        var dateTimeNow = dateTimeProvider.UtcNow;

        // O inicio da locação obrigatóriamente é o primeiro dia após a data de criação.
        var startDate = dateTimeNow.AddDays(1);

        // data prevista da devolução é a data de início da locação + número de dias do plano
        var expectedEndDate = startDate.AddDays(plan.Data.NumberDays);

        var rental = requestDto
            .CreatedAt(dateTimeNow)
            .SetStartDate(startDate)
            .SetExpectedEndDate(expectedEndDate)
            .ToEntity();

        var result = await repository.AddAsync(rental, cancellationToken);

        var responseDto = new RentalResponseDto
        (
            result.Data.Id,
            result.Data.DeliveryPersonId,
            result.Data.MotorcycleId,
            result.Data.PlanId,
            result.Data.StartDate,
            result.Data.ExpectedEndDate,
            plan.Data.Price,
            false
        );

        return Result<RentalResponseDto>.Success(responseDto);
    }
}
