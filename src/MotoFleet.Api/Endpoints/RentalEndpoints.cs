using Microsoft.AspNetCore.Mvc;
using MotoFleet.Application.DTOs.Rentals;
using MotoFleet.Application.UseCases.Rentals;

namespace MotoFleet.Api.Endpoints;

public static class RentalEndpoints
{
    public static void MapRentalEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/locacao", async (
                [FromBody] CreateRentalRequestDto request,
                CreateRental createRental,
                CancellationToken cancellationToken) =>
            {
                var result = await createRental.Handle(request, cancellationToken);
                return result.IsSuccess
                    ? Results.Created($"/locacao/{result.Data.Id}", result.Data)
                    : Results.BadRequest(result.ErrorMessage);
            })
            .WithName("CreateRental")
            .WithOpenApi();
        
        app.MapGet("locacao/{id:guid}", async (
                Guid id,
                GetByIdRental getRentalById,
                CancellationToken cancellationToken) =>
            {
                var result = await getRentalById.Handle(id, cancellationToken);
                return result.IsSuccess
                    ? Results.Ok(result.Data)
                    : Results.NotFound(result.ErrorMessage);
            })
            .WithName("GetRentalById")
            .WithOpenApi();
        
        app.MapPut("/locacao/{id:guid}/devolucao", async (
                Guid id,
                [FromBody] UpdateRentalDevolutionRequestDto input,
                UpdateDevolutionRental updateRental,
                CancellationToken cancellationToken) =>
            {
                var result = await updateRental.Handle(id, input, cancellationToken);
                return result.IsSuccess
                    ? Results.Ok(result.Data)
                    : Results.BadRequest(result.ErrorMessage);
            })
            .WithName("UpdateRental")
            .WithOpenApi();
    }
}
