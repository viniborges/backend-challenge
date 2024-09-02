using MotoFleet.Domain.Motorcycles;

namespace MotoFleet.Application.DTOs.Motorcycles;

public record CreateMotorcycleRequestDto(string Identificador, ushort Ano, string Modelo, string Placa)
{
    private DateTime _createdAt { get; set; }

    public CreateMotorcycleRequestDto CreatedAt(DateTime datetime)
    {
        _createdAt = datetime;
        return this;
    } 
    public Motorcycle ToEntity()
    {
        return new Motorcycle(
            Guid.NewGuid(),
            Identificador,
            Ano,
            Modelo,
            Placa,
            _createdAt);
    }
};
