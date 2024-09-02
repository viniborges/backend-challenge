namespace MotoFleet.Domain.DeliveryPersons;

public record DeliveryPerson(
    Guid Id,
    string Name,
    string CnpjCpf,
    DateTime DateBirth,
    string Cnh,
    string CnhType,
    DateTime CreatedAt
    );
