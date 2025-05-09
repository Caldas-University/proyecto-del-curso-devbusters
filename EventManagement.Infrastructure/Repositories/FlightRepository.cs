namespace FlightReservation.Infrastructure.Repositories;

using FlightReservation.Domain.Entities;
using FlightReservation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using FlightReservation.Infrastructure.Persistence;

public class FlightRepository : IFlightRepository
{
    private readonly FlightReservationDbContext _context;

    public FlightRepository(FlightReservationDbContext context)
    {
        _context = context;
    }

    public async Task<Flight?> GetFlightAsync(Guid id)
    {
        return await _context.Flights
            .Include(f => f.Seats)
            .FirstOrDefaultAsync(f => f.Id == id);
    }
}
