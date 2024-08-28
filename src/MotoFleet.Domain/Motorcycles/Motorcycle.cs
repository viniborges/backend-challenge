namespace MotoFleet.Domain.Motorcycles;

public record Motorcycle(
    Guid Id, 
    string Name, 
    ushort Year , 
    string Model, 
    string Plate, 
    DateTime CreatedAt
    );
