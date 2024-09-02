using MotoFleet.Domain.Rentals;

namespace MotoFleet.Application.DTOs.Rentals;

public record CreateRentalRequestDto(Guid entregador_id, Guid moto_id, Guid plano_id)
{
    private DateTime _createdAt { get; set; }
    private DateTime _startDate { get; set; }
    private DateTime _expectedEndDate { get; set; }

    public CreateRentalRequestDto CreatedAt(DateTime datetime)
    {
        _createdAt = datetime;
        return this;
    }

    public CreateRentalRequestDto SetStartDate(DateTime datetime)
    {
        _startDate = datetime;
        return this;
    }

    public CreateRentalRequestDto SetExpectedEndDate(DateTime datetime)
    {
        _expectedEndDate = datetime;
        return this;
    }
    
    public Rental ToEntity()
    {
        return new Rental(
            Guid.NewGuid(),
            moto_id,
            entregador_id,
            plano_id,
            _startDate,
            null,
            _expectedEndDate,
            false,
            null,
            _createdAt
        );
    }
};
