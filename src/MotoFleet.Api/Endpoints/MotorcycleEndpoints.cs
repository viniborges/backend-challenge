using MotoFleet.Application.UseCases.Motorcycles;
using Microsoft.AspNetCore.Mvc;

namespace MotoFleet.Api.Endpoints;

public static class MotorcycleEndpoints
{
    public sealed record Request(string Email, string FirstName, string LastName, string Password);
    public static void MapMotorcycleEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/motos", async (
                [FromBody] CreateMotorcycleRequest request,
                CreateMotorcycle useCase,
                CancellationToken cancellationToken) =>
            {
                await useCase.Create(request, cancellationToken);
                return Results.Created();
            })
            .WithName("CreateMotorcycle")
            .WithOpenApi();
    }
}
