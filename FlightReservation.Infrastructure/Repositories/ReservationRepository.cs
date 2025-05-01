namespace FlightReservation.Infrastructure.Repositories;

using FlightReservation.Domain.Entities;
using FlightReservation.Domain.Repositories;
using FlightReservation.Infrastructure.Persistence;

public class ReservationRepository : IReservationRepository
{
    private readonly FlightReservationDbContext _context;

    public ReservationRepository(FlightReservationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
    }
}
