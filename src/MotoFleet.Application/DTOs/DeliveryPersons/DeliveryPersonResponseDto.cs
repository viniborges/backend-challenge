using MotoFleet.Domain.DeliveryPersons;

namespace MotoFleet.Application.DTOs.DeliveryPersons;

public record DeliveryPersonResponseDto(
    Guid Id,
    string Nome,
    string CnpjCpf,
    DateTime DataNascimento,
    string Cnh,
    string TipoCnh,
    DateTime DataCadastro)
{
    public static DeliveryPersonResponseDto ToDto(DeliveryPerson? deliveryPerson)
    {
        if (deliveryPerson is not null)
        {
            return new DeliveryPersonResponseDto(
                deliveryPerson.Id,
                deliveryPerson.Name,
                deliveryPerson.CnpjCpf,
                deliveryPerson.DateBirth,
                deliveryPerson.Cnh,
                deliveryPerson.CnhType,
                deliveryPerson.CreatedAt);
        }

        return null;
    }
}
