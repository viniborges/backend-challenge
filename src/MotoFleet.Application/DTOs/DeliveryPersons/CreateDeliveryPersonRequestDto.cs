using MotoFleet.Domain.DeliveryPersons;

namespace MotoFleet.Application.DTOs.DeliveryPersons;

public record CreateDeliveryPersonRequestDto(string Nome, string Cnpj, DateTime DataNascimento, string Cnh, string TipoCnh)
{
    private DateTime _createdAt { get; set; }

    public CreateDeliveryPersonRequestDto CreatedAt(DateTime datetime)
    {
        _createdAt = datetime;
        return this;
    } 
    public DeliveryPerson ToEntity()
    {
        return new DeliveryPerson(
            Guid.NewGuid(),
            Nome,
            Cnpj,
            DataNascimento,
            Cnh,
            TipoCnh,
            _createdAt);
    }
};
