namespace FlightReservation.Domain.Repositories;

using FlightReservation.Domain.Entities;

public interface IReservationRepository
{
    Task AddAsync(Reservation reservation);
}
