namespace FlightReservation.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using FlightReservation.Domain.Entities;

public class FlightReservationDbContext : DbContext
{
    public DbSet<Flight> Flights => Set<Flight>();
    public DbSet<Seat> Seats => Set<Seat>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<Passenger> Passengers => Set<Passenger>();

    public FlightReservationDbContext(DbContextOptions<FlightReservationDbContext> options)
        : base(options)
    {
    }
}
