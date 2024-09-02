namespace MotoFleet.Domain.Rentals;

public static class RentalErros
{
    public static string NotFound(Guid rentalId) =>
        $"The rental with the Id = '{rentalId}' was not found";
}
