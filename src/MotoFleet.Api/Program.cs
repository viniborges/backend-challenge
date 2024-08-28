using Microsoft.EntityFrameworkCore;
using MotoFleet.Api.Endpoints;
using MotoFleet.Application.Abstractions.Motorcycles;
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
builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMotorcycleEndpoints();

await app.RunAsync();
