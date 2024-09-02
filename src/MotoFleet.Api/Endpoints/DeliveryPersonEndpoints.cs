using Microsoft.AspNetCore.Mvc;
using MotoFleet.Application.DTOs.DeliveryPersons;
using MotoFleet.Application.UseCases.DeliveryPersons;

namespace MotoFleet.Api.Endpoints;

public static class DeliveryPersonEndpoints
{
    public static void MapDeliveryPersonEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/entregadores", async (
                [FromBody] CreateDeliveryPersonRequestDto request,
                CreateDeliveryPerson createDeliveryPerson,
                CancellationToken cancellationToken) =>
            {
                var result = await createDeliveryPerson.Handle(request, cancellationToken);
                return result.IsSuccess
                    ? Results.Created($"/entregadores/{result.Data.Id}", result.Data)
                    : Results.BadRequest(result.ErrorMessage);
            })
            .WithName("CreateDeliveryPerson")
            .WithOpenApi();
    }
}
