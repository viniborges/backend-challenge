namespace MotoFleet.Domain.Plans;

public record Plan(Guid Id, int NumberDays, decimal Price, decimal FinePercentage);
