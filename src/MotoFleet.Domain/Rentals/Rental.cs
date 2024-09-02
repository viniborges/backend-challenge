using MotoFleet.Domain.DeliveryPersons;
using MotoFleet.Domain.Motorcycles;
using MotoFleet.Domain.Plans;

namespace MotoFleet.Domain.Rentals;

public record Rental(
    Guid Id,
    Guid MotorcycleId,
    Guid DeliveryPersonId,
    Guid PlanId,
    DateTime StartDate,
    DateTime? EndDate,
    DateTime ExpectedEndDate,
    bool IsReturned,
    decimal? CalculatedPrice,
    DateTime CreatedAt
)
{
    // Quando a data informada for inferior a data prevista do término, será cobrado o valor das
    // diárias e uma multa adicional, adicionando a porcentagem em cima das diárias não efetivadas.
    // Quando a data informada for superior a data prevista do término, será cobrado um valor adicional de R$50,00 por diária.
    public decimal CalculateRentalPrice( Plan plan)
    {
        var finalPrice = plan.Price * plan.NumberDays;
        
        if (EndDate < ExpectedEndDate)
        {
            var daysNotRented = (ExpectedEndDate - EndDate).Value.Days;
            var priceDaysNotRented = daysNotRented * plan.Price;
            var fineValue = priceDaysNotRented * plan.FinePercentage / 100;
            return finalPrice + fineValue;
        }
        
        if (EndDate > ExpectedEndDate)
        {
            var daysExceeded = (EndDate - ExpectedEndDate).Value.Days;
            var priceDaysExceeded = daysExceeded * 50;
            return finalPrice + priceDaysExceeded;
        }
        
        return finalPrice;
    }
};
