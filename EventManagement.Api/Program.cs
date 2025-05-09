using FlightReservation.Application.Services;
using FlightReservation.Infrastructure.Persistence;
using FlightReservation.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FlightReservation.Domain.Repositories;
using FlightReservation.Application.Contracts.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FlightReservationDbContext>(options =>
    options.UseSqlite("Data Source=flightreservation.db"));

builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationServiceApp, ReservationServiceApp>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FlightReservationDbContext>();
    SeedData.Initialize(dbContext);
}


app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
