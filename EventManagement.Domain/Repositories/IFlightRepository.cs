namespace FlightReservation.Domain.Repositories;

using FlightReservation.Domain.Entities;

public interface IFlightRepository
{
    Task<Flight?> GetFlightAsync(Guid id);
}
