using Microsoft.EntityFrameworkCore;
using MotoFleet.Api.Endpoints;
using MotoFleet.Api.Extensions;
using MotoFleet.Application.Abstractions.Motorcycle;
using MotoFleet.Application.UseCases.Motorcycles;
using MotoFleet.Infrastructure.Database;
using MotoFleet.Infrastructure.Repository;
using MotoFleet.Infrastructure.Time;
using MotoFleet.SharedKernel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
builder.Services.AddScoped<CreateMotorcycle>();
builder.Services.AddScoped<GetByPlateMotorcycle>();
builder.Services.AddScoped<GetByIdMotorcycle>();
builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
#pragma warning disable CA1303
    Console.WriteLine("Running in development mode");
#pragma warning restore CA1303
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.MapMotorcycleEndpoints();

await app.RunAsync();
