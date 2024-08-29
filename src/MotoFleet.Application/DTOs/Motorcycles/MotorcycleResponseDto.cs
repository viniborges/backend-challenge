using MotoFleet.Domain.Motorcycles;

namespace MotoFleet.Application.DTOs.Motorcycles;

public record MotorcycleResponseDto(
    Guid Id,
    string Identificador,
    ushort Ano,
    string Modelo,
    string Placa,
    DateTime DataCadastro)
{
    public static MotorcycleResponseDto ToDto(Motorcycle? motorcycle)
    {
        if (motorcycle is not null)
        {
            return new MotorcycleResponseDto(
                motorcycle.Id,
                motorcycle.Name,
                motorcycle.Year,
                motorcycle.Model,
                motorcycle.Plate,
                motorcycle.CreatedAt);
        }

        return null;
    }
};
