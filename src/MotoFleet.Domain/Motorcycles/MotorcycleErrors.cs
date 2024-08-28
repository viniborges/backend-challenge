namespace MotoFleet.Domain.Motorcycles;

public static class MotorcycleErrors
{
    public static string NotFound(Guid motorcycleId) =>
        $"The motorcycle with the Id = '{motorcycleId}' was not found";
    
    public static string NotFoundByPlate(string plate) =>
        $"The motorcycle with the plate = '{plate}' was not found";
    
    public static string PlateNotUnique(string plate) =>
        $"The provided plate '{plate}' is already in use";
    
    public static string MotorcycleIsRented(Guid motorcycleId) =>
        $"The motorcycle with the Id = '{motorcycleId}' is already rented";
}
