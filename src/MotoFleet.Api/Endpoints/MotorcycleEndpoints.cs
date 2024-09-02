using MotoFleet.Application.UseCases.Motorcycles;
using Microsoft.AspNetCore.Mvc;
using MotoFleet.Application.DTOs.Motorcycles;

namespace MotoFleet.Api.Endpoints;

public static class MotorcycleEndpoints
{
    public static void MapMotorcycleEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/motos", async (
                [FromBody] CreateMotorcycleRequestDto request,
                CreateMotorcycle createMotorcycle,
                CancellationToken cancellationToken) =>
            {
                var result = await createMotorcycle.Handle(request, cancellationToken);
                return result.IsSuccess
                    ? Results.Created($"/motos/{result.Data.Id}", result.Data)
                    : Results.BadRequest(result.ErrorMessage);
            })
            .WithName("CreateMotorcycle")
            .WithOpenApi();

        app.MapGet("/motos/", async (
                [FromHeader(Name = "Placa")] string? placa,
                GetByPlateMotorcycle getByPlateMotorcycle,
                CancellationToken cancellationToken) =>
            {
                var result = await getByPlateMotorcycle.Handle(placa, cancellationToken);
                return Results.Ok(result.Data);
            })
            .WithName("GetMotorcycleByPlate")
            .WithOpenApi();
        
        app.MapGet("/motos/{id:guid}", async (
                Guid id,
                GetByIdMotorcycle getByIdMotorcycle,
                CancellationToken cancellationToken) =>
            {
                var result = await getByIdMotorcycle.Handle(id, cancellationToken);
                return result.IsSuccess
                    ? Results.Ok(result.Data)
                    : Results.NotFound(result.ErrorMessage);
            })
            .WithName("GetMotorcycleById")
            .WithOpenApi();
        
        app.MapPut("/motos/{id:guid}/placa", async (
                Guid id,
                [FromBody] UpdatePlateMotorcycleDto input,
                UpdatePlateMotorcycle updatePlateMotorcycle,
                CancellationToken cancellationToken) =>
            {
                var result = await updatePlateMotorcycle.Handle(id, input.placa, cancellationToken);
                return result.IsSuccess
                    ? Results.Ok(result.Data)
                    : Results.BadRequest(result.ErrorMessage);
            })
            .WithName("UpdatePlateMotorcycle")
            .WithOpenApi();
        
        app.MapDelete("/motos/{id:guid}", async (
                Guid id,
                DeleteMotorcycle deleteMotorcycle,
                CancellationToken cancellationToken) =>
            {
                var result = await deleteMotorcycle.Handle(id, cancellationToken);
                return result.IsSuccess
                    ? Results.Ok(result.Data)
                    : Results.BadRequest(result.ErrorMessage);
            })
            .WithName("DeleteMotorcycle")
            .WithOpenApi();
    }
}
