namespace MotoFleet.Domain.Plans;

public static class PlanErros
{
    public static string NotFound(Guid motorcycleId) =>
        $"The plan with the Id = '{motorcycleId}' was not found";
}
