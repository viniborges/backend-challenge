using Microsoft.EntityFrameworkCore;
using MotoFleet.Api.Endpoints;
using MotoFleet.Api.Extensions;
using MotoFleet.Application.Abstractions.DeliveryPerson;
using MotoFleet.Application.Abstractions.Motorcycle;
using MotoFleet.Application.Abstractions.Rental;
using MotoFleet.Application.UseCases.DeliveryPersons;
using MotoFleet.Application.UseCases.Motorcycles;
using MotoFleet.Application.UseCases.Rentals;
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
builder.Services.AddScoped<IDeliveryPersonRepository, DeliveryPersonRepository>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();
builder.Services.AddScoped<CreateMotorcycle>();
builder.Services.AddScoped<GetByPlateMotorcycle>();
builder.Services.AddScoped<GetByIdMotorcycle>();
builder.Services.AddScoped<UpdatePlateMotorcycle>();
builder.Services.AddScoped<DeleteMotorcycle>();
builder.Services.AddScoped<CreateDeliveryPerson>();
builder.Services.AddScoped<CreateRental>();
builder.Services.AddScoped<GetByIdRental>();
builder.Services.AddScoped<UpdateDevolutionRental>();
builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

// app.UseHttpsRedirection();

app.MapMotorcycleEndpoints();
app.MapDeliveryPersonEndpoints();
app.MapRentalEndpoints();

await app.RunAsync();
